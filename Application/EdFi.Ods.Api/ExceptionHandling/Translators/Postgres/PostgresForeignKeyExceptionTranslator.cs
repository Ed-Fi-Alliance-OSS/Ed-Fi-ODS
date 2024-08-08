// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresForeignKeyExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IDomainModelProvider _domainModelProvider;

        public PostgresForeignKeyExceptionTranslator(IDomainModelProvider domainModelProvider)
        {
            _domainModelProvider = domainModelProvider;
        }

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            var exceptionToEvaluate = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exceptionToEvaluate is PostgresException postgresException)
            {
                if (postgresException.SqlState == PostgresSqlStates.ForeignKeyViolation)
                {
                    // Try to get the entity affected
                    if (_domainModelProvider.GetDomainModel()
                        .EntityByFullName.TryGetValue(new FullName(postgresException.SchemaName, postgresException.TableName), out var entity))
                    {
                        // For "insert or update" violations, extract table name from the constraint name
                        //     EXAMPLE: insert or update on table "school" violates foreign key constraint "fk_6cd2e3_localeducationagency"
                        if (postgresException.MessageText.Contains("insert or update"))
                        {
                            // Iterate the incoming associations looking for the offending constraint
                            var association = entity?.IncomingAssociations.SingleOrDefault(
                                a =>
                                    a.Association.ConstraintByDatabaseEngine[DatabaseEngine.Postgres.Value]
                                    .EqualsIgnoreCase(postgresException.ConstraintName));

                            if (association != null)
                            {
                                problemDetails = new UnresolvedReferenceException(association.OtherEntity.Name);

                                return true;
                            }
                        }
                        else if (postgresException.MessageText.Contains("update or delete"))
                        {
                            // NOTE: FK violations won't happen in the ODS for "update" because where key updates are allowed, cascade updates are applied.
                            // So this scenario will only happen with deletes where there are child aggregate/resources that must be removed first.
                            // In this case, the PostgreSQL exception identifies the dependent table (no translation is necesssary)

                            problemDetails = new DependentResourceItemExistsException(entity);

                            return true;
                        }
                    }

                    // Unable to determine details, probably due to long table name munging for Postgres identities
                    problemDetails = postgresException.MessageText.Contains("update or delete")
                        ? new DependentResourceItemExistsException()
                        : new UnresolvedReferenceException();

                    return true;
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

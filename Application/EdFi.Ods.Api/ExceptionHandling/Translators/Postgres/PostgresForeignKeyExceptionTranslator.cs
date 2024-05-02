// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresForeignKeyExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        public PostgresForeignKeyExceptionTranslator(
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
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
                    var entity = _dataManagementResourceContextProvider.Get()
                        .Resource.Entity.Aggregate.Members.SingleOrDefault(
                            e => 
                                e.Schema.EqualsIgnoreCase(postgresException.SchemaName)
                                && e.TableNameByDatabaseEngine[DatabaseEngine.Postgres].EqualsIgnoreCase(postgresException.TableName));

                    var association = entity?.IncomingAssociations.SingleOrDefault(
                        a => 
                            a.Association.ConstraintByDatabaseEngine[DatabaseEngine.Postgres.Value]
                            .EqualsIgnoreCase(postgresException.ConstraintName));

                    if (association == null)
                    {
                        problemDetails = postgresException.MessageText.Contains("update or delete")
                            ? new DependentResourceItemExistsException()
                            : new UnresolvedReferenceException();

                        return true;
                    }

                    problemDetails = postgresException.MessageText.Contains("update or delete")
                        ? new DependentResourceItemExistsException(association.ThisEntity.Name)
                        : new UnresolvedReferenceException(association.OtherEntity.Name);

                    return true;
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

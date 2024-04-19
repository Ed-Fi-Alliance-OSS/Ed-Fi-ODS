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
        
        private const string InsertOrUpdateMessageFormat = "The referenced '{0}' resource does not exist.";
        private const string UpdateOrDeleteMessageFormat = "The operation cannot be performed because the resource is a dependency of the '{0}' resource.";

        private const string NoDetailsInsertOrUpdateMessage = "A referenced resource does not exist.";
        private const string NoDetailsUpdateOrDeleteMessage = "The operation cannot be performed because the resource is a dependency of another resource.";

        public PostgresForeignKeyExceptionTranslator(IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
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
                        string noDetailsMessage = postgresException.MessageText.Contains("update or delete")
                            ? NoDetailsUpdateOrDeleteMessage
                            : NoDetailsInsertOrUpdateMessage;

                        problemDetails = new InvalidReferenceConflictException("scenario47.");

                        return true;
                    }

                    string message = postgresException.MessageText.Contains("update or delete")
                        ? string.Format(UpdateOrDeleteMessageFormat, association.ThisEntity.Name)
                        : string.Format(InsertOrUpdateMessageFormat, association.OtherEntity.Name);

                    problemDetails = new InvalidReferenceConflictException("scenario48.");

                    return true;
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresForeignKeyExceptionTranslator : IExceptionTranslator
    {
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        
        private const string InsertOrUpdateMessageFormat = "The value supplied for the related '{0}' resource does not exist.";
        private const string UpdateOrDeleteMessageFormat = "The resource (or a subordinate entity of the resource) cannot be deleted because it is a dependency of the '{0}' entity.";

        private const string NoDetailsUpdateOrDeleteMessage = "The resource (or a subordinate entity of the resource) cannot be deleted because it is a dependency of another entity.";
        private const string NoDetailsInsertOrUpdateMessage = "The value supplied for a related resource does not exist.";

        public PostgresForeignKeyExceptionTranslator(IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }
        
        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is PostgresException postgresException)
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

                        webServiceError = CreateError(noDetailsMessage);

                        return true;
                    }

                    string message = postgresException.MessageText.Contains("update or delete")
                        ? string.Format(UpdateOrDeleteMessageFormat, association.ThisEntity.Name)
                        : string.Format(InsertOrUpdateMessageFormat, association.OtherEntity.Name);

                    webServiceError = new RESTError
                    {
                        Code = (int) HttpStatusCode.Conflict,
                        Type = "Conflict",
                        Message = message
                    };

                    return true;
                }
            }

            return false;

            RESTError CreateError(string message) => new RESTError
            {
                Code = (int)HttpStatusCode.Conflict,
                Type = "Conflict",
                Message = message
            };
        }
    }
}

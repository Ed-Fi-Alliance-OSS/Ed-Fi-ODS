// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using EdFi.Common.Configuration;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class DuplicateNaturalKeyCreateExceptionTranslator : IExceptionTranslator
    {
        private const string MessageFormat =
            "A natural key conflict occurred when attempting to create a new resource '{0}' with a duplicate key. The duplicated columns and values are [{1}] {2}.";

        private static readonly Regex MatchPattern = new Regex(
            @"^Violation of PRIMARY KEY constraint '(?<IndexName>\w+)'\.\s+Cannot insert duplicate key in object '[a-z]+\.(?<TableName>\w+)'\.\s+The duplicate key value is (?<Values>\(.*\))\.\s+The statement has been terminated\.\s*$");

        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        public DuplicateNaturalKeyCreateExceptionTranslator(IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is SqlException)
            {
                var match = MatchPattern.Match(exception.Message);

                if (match.Success)
                {
                    var resourceEntity = _dataManagementResourceContextProvider.Get().Resource.Entity;

                    string values = match.Groups["Values"]
                                         .Value;

                    string columnNames = resourceEntity.BaseEntity == null ? 
                        string.Join(", ", resourceEntity.Identifier.Properties.Select(x => x.PropertyName))
                        : string.Join(", ", resourceEntity.BaseEntity.Identifier.Properties.Select(x => x.PropertyName));

                    var message = string.Format(MessageFormat, resourceEntity.Name, columnNames, values);

                    webServiceError = new RESTError
                                      {
                                          Code = (int) HttpStatusCode.Conflict, Type = HttpStatusCode.Conflict.ToString(), Message = message
                                      };

                    return true;
                }
            }

            return false;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Extensions;
using NHibernate.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class SqlServerUniqueIndexExceptionTranslator : IExceptionTranslator
    {
        private static readonly Regex expression = new Regex(
            @"^Cannot insert duplicate key row in object '[a-z]+\.(?<TableName>\w+)' with unique index '(?<IndexName>\w+)'(?:\. The duplicate key value is (?<Values>\(.*\))\.)?|^Violation of UNIQUE KEY constraint '(?<IndexName>\w+)'. Cannot insert duplicate key in object '[a-z]+\.(?<TableName>\w+)'.");
        
        private static readonly string singleMessageFormat =
            "The value {0} supplied for property '{1}' of entity '{2}' is not unique.";

        private static readonly string multipleMessageFormat =
            "The values {0} supplied for properties '{1}' of entity '{2}' are not unique.";
        
        private readonly IDatabaseMetadataProvider _databaseMetadataProvider;

        public SqlServerUniqueIndexExceptionTranslator(IDatabaseMetadataProvider databaseMetadataProvider)
        {
            _databaseMetadataProvider = databaseMetadataProvider;
        }

        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            translationResult = null;

            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is SqlException)
            {
                var match = expression.Match(exception.Message);

                if (match.Success)
                {
                    string indexName = match.Groups["IndexName"].Value;

                    string values = match.Groups["Values"].Value;

                    if (string.IsNullOrWhiteSpace(values))
                    {
                        values = "unknown";
                    }

                    var indexDetails = _databaseMetadataProvider.GetIndexDetails(indexName);

                    string tableName = indexDetails == null
                        ? "unknown"
                        : indexDetails.TableName.ToCamelCase();

                    string columnNames = indexDetails == null
                        ? "unknown"
                        : string.Join("', '", indexDetails.ColumnNames.Select(x => x.ToCamelCase()));

                    string message;

                    if (indexDetails.ColumnNames.Count == 1)
                    {
                        message = string.Format(singleMessageFormat, values, columnNames, tableName);
                    }
                    else
                    {
                        message = string.Format(multipleMessageFormat, values, columnNames, tableName);
                    }

                    var error = new RESTError
                    {
                        Code = (int) HttpStatusCode.Conflict,
                        Type = "Conflict",
                        Message = message
                    };

                    translationResult = new ExceptionTranslationResult(error, ex);
                    
                    return true;
                }
            }

            return false;
        }
    }
}

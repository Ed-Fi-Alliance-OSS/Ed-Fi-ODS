// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Exceptions;
using NHibernate.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class SqlServerUniqueIndexExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private static readonly Regex _expression = new Regex(
            @"^Cannot insert duplicate key row in object '[a-z]+\.(?<TableName>\w+)' with unique index '(?<IndexName>\w+)'(?:\. The duplicate key value is (?<Values>\(.*\))\.)?|^Violation of UNIQUE KEY constraint '(?<IndexName>\w+)'. Cannot insert duplicate key in object '[a-z]+\.(?<TableName>\w+)'.");

        private const string SingleMessageFormat = "The value {0} supplied for property '{1}' of entity '{2}' is not unique.";
        private const string MultipleMessageFormat = "The values {0} supplied for properties '{1}' of entity '{2}' are not unique.";

        private readonly IDatabaseMetadataProvider _databaseMetadataProvider;

        public SqlServerUniqueIndexExceptionTranslator(IDatabaseMetadataProvider databaseMetadataProvider)
        {
            _databaseMetadataProvider = databaseMetadataProvider;
        }

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is SqlException)
            {
                var match = _expression.Match(exception.Message);

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
                        message = string.Format(SingleMessageFormat, values, columnNames, tableName);
                    }
                    else
                    {
                        message = string.Format(MultipleMessageFormat, values, columnNames, tableName);
                    }

                    problemDetails = new NonUniqueConflictException("scenario59.");
                    return true;
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

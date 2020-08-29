// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using NHibernate.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class DuplicateNaturalKeyCreateExceptionTranslator : IExceptionTranslator
    {
        private const string MessageFormat =
            "A natural key conflict occurred when attempting to create a new resource '{0}' with a duplicate key.  The duplicated columns and values are [{1}] {2} This is likely caused by multiple resources with the same key in the same file. Exactly one of these resources was inserted.";

        private static readonly Regex MatchPattern = new Regex(
            @"^Violation of PRIMARY KEY constraint '(?<IndexName>\w+)'\.\s+Cannot insert duplicate key in object '[a-z]+\.(?<TableName>\w+)'\.\s+The duplicate key value is (?<Values>\(.*\))\.\s+The statement has been terminated\.\s*$");
        private readonly IDatabaseMetadataProvider _databaseMetadataProvider;

        public DuplicateNaturalKeyCreateExceptionTranslator(IDatabaseMetadataProvider databaseMetadataProvider)
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
                var match = MatchPattern.Match(exception.Message);

                if (match.Success)
                {
                    string indexName = match.Groups["IndexName"].Value;

                    string values = match.Groups["Values"].Value;

                    var indexDetails = _databaseMetadataProvider.GetIndexDetails(indexName);

                    string tableName = indexDetails == null
                        ? "unknown"
                        : indexDetails.TableName;

                    string columnNames = indexDetails == null
                        ? "unknown"
                        : string.Join(", ", indexDetails.ColumnNames.Select(x => x));

                    var message = string.Format(MessageFormat, tableName, columnNames, values);

                    var error = new RESTError
                    {
                        Code = (int) HttpStatusCode.Conflict,
                        Type = HttpStatusCode.Conflict.ToString(),
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

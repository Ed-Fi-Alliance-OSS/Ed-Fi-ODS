// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Text.RegularExpressions;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresDuplicatedKeyExceptionTranslator : IExceptionTranslator
    {
        private const string SimpleKeyMessageFormat = "The value {0} supplied for property '{1}' of entity '{2}' is not unique.";
        private const string ComposedKeyMessageFormat = "The values {0} supplied for properties '{1}' of entity '{2}' are not unique.";
        private static readonly Regex _expression = new Regex( @"(?<ErrorCode>\d*): duplicate key value violates unique constraint ""(?<ConstraintName>.*?)""");
        private static readonly Regex _detailExpression = new Regex(@"Key \((?<KeyColumns>.*?)\)=\((?<KeyValues>.*?)\) (?<ConstraintType>already exists).");

        public bool TryTranslateMessage(Exception ex, out ExceptionTranslationResult translationResult)
        {
            translationResult = null;

            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is PostgresException postgresException)
            {
                var match = _expression.Match(postgresException.Message);

                if (match.Success)
                {
                    var exceptionInfo = new PostgresExceptionInfo(postgresException, _detailExpression);

                    string message = string.Format(
                        exceptionInfo.IsComposedKeyConstraint
                            ? ComposedKeyMessageFormat
                            : SimpleKeyMessageFormat,
                        exceptionInfo.Values,
                        exceptionInfo.ColumnNames,
                        exceptionInfo.TableName);

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

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
    public class PostgresForeignKeyExceptionTranslator : IExceptionTranslator
    {
        private const string InsertOrUpdateMessageFormat = "The value supplied for the related '{0}' resource does not exist.";
        private const string UpdateOrDeleteMessageFormat = "The resource (or a subordinate entity of the resource) cannot be deleted because it is a dependency of the '{1}' value of the '{0}' entity.";
        private static readonly Regex _expression = new Regex(@"(?<ErrorCode>\d*): (?<ConstraintType>insert or update|update or delete) on table ""(?<TableName>\w+)"" violates foreign key constraint ""(?<ConstraintName>.*?)"".*?");
        private static readonly Regex _detailExpression = new Regex(@"Key \((?<KeyColumns>.*?)\)=\((?<KeyValues>.*?)\) is (?<ConstraintType>not present in|still referenced from) table ""(?<TableName>\w+)"".");

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

                    var handledMessage = GetHandledMessage(exceptionInfo, match);

                    var error = new RESTError
                    {
                        Code = (int) HttpStatusCode.Conflict,
                        Type = "Conflict",
                        Message = handledMessage
                    };

                    translationResult = new ExceptionTranslationResult(error, ex);

                    return true;
                }
            }

            return false;
        }

        private static string GetHandledMessage(PostgresExceptionInfo exceptionInfo, Match exceptionMessageMatch)
        {
            switch (exceptionInfo.ConstraintType)
            {
                case PostgresExceptionConstraintType.InsertOrUpdateForeignKey:
                    return string.Format(InsertOrUpdateMessageFormat, exceptionInfo.TableName);
                case PostgresExceptionConstraintType.UpdateOrDeleteForeignKey:
                    return string.Format(UpdateOrDeleteMessageFormat, exceptionInfo.TableName, exceptionInfo.ColumnNames);
                default:
                    return GetHandledMessageFromExceptionMessage(exceptionInfo, exceptionMessageMatch);
            }
        }

        private static string GetHandledMessageFromExceptionMessage(
            PostgresExceptionInfo exceptionInfo,
            Match exceptionMessageMatch)
        {
            var constraintTypeText = exceptionMessageMatch.Groups["ConstraintType"].Value;
            var tableName = exceptionMessageMatch.Groups["TableName"].Value;

            return constraintTypeText.Equals("insert or update")
                ? string.Format(InsertOrUpdateMessageFormat, tableName)
                : string.Format(UpdateOrDeleteMessageFormat, tableName, exceptionInfo.ColumnNames);
        }
    }
}

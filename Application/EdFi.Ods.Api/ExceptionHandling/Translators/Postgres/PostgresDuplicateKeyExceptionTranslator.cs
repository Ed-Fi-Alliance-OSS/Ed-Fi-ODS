// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresDuplicateKeyExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        private static readonly Regex _expression = new(@"(?<ErrorCode>\d*): duplicate key value violates unique constraint ""(?<ConstraintName>.*?)""");
        private static readonly Regex _detailExpression = new(@"Key \((?<KeyColumns>.*?)\)=\((?<KeyValues>.*?)\) (?<ConstraintType>already exists).");

        private const string GenericMessage = "The value(s) supplied for the resource are not unique.";
        
        private const string SimpleKeyMessageFormat = "The value supplied for property '{0}' of entity '{1}' is not unique.";
        private const string CompositeKeyMessageFormat = "The values supplied for properties '{0}' of entity '{1}' are not unique.";

        private const string PrimaryKeyNameSuffix = "_pk";

        public PostgresDuplicateKeyExceptionTranslator(
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
                var match = _expression.Match(postgresException.Message);

                if (match.Success)
                {
                    var constraintName = match.Groups["ConstraintName"].ValueSpan;

                    string message = GetMessageUsingRequestContext(constraintName)
                        ?? GetMessageUsingPostgresException();

                    problemDetails = new NonUniqueConflictException("scenario58.");

                    return true;
                }

                string GetMessageUsingRequestContext(ReadOnlySpan<char> constraintName)
                {
                    // Rely on PK suffix naming convention to identify PK constraint violation (which covers almost all scenarios for this violation)
                    if (constraintName.EndsWith(PrimaryKeyNameSuffix, StringComparison.OrdinalIgnoreCase))
                    {
                        var tableName = constraintName.Slice(0, constraintName.Length - PrimaryKeyNameSuffix.Length).ToString();

                        // Look for matching class in the request's targeted resource
                        if (_dataManagementResourceContextProvider.Get()?.Resource?
                                .ContainedItemTypeByName.TryGetValue(tableName, out var resourceClass) ?? false)
                        {
                            var pkPropertyNames = resourceClass.IdentifyingProperties.Select(p => p.PropertyName).ToArray();

                            return  string.Format(
                                (pkPropertyNames.Length > 1)
                                    ? CompositeKeyMessageFormat
                                    : SimpleKeyMessageFormat,
                                string.Join("', '", pkPropertyNames),
                                resourceClass.Name);
                        }
                    }

                    return null;
                }

                string GetMessageUsingPostgresException()
                {
                    string message;
                    var exceptionInfo = new PostgresExceptionInfo(postgresException, _detailExpression);

                    // Column names will only be available form Postgres if a special argument is added to the connection string
                    if (exceptionInfo.ColumnNames.Length > 0 && exceptionInfo.ColumnNames != PostgresExceptionInfo.UnknownValue)
                    {
                        message = string.Format(
                            exceptionInfo.IsComposedKeyConstraint
                                ? CompositeKeyMessageFormat
                                : SimpleKeyMessageFormat,
                            exceptionInfo.ColumnNames,
                            exceptionInfo.TableName);
                    }
                    else
                    {
                        message = GenericMessage;
                    }

                    return message;
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

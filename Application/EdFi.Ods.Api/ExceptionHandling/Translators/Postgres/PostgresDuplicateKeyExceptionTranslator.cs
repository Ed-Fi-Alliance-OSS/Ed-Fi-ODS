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

        private static readonly Regex _expression = new(
            @"(?<ErrorCode>\d*): duplicate key value violates unique constraint ""(?<ConstraintName>.*?)""",
            RegexOptions.Compiled);

        private static readonly Regex _detailExpression = new(
            @"Key \((?<KeyColumns>.*?)\)=\((?<KeyValues>.*?)\) (?<ConstraintType>already exists).", 
            RegexOptions.Compiled);

        private const string DuplicatePrimaryKeyErrorFormat =
            "A primary key conflict occurred when attempting to create or update a record in the '{0}' table. The duplicate key is ({1}) = ({2}).";

        private const string SimpleKeyErrorMessageFormat = "The value supplied for property '{0}' of entity '{1}' is not unique.";
        private const string CompositeKeyErrorMessageFormat = "The values supplied for properties '{0}' of entity '{1}' are not unique.";

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
                if (postgresException.SqlState == PostgresErrorCodes.UniqueViolation)
                {
                    // Examples:
                    // ----------------------------------------
                    // INSERT duplicate AK values
                    // [23505] ERROR: duplicate key value violates unique constraint "student_ui_studentuniqueid" Detail: Key (studentuniqueid)=(ABC) already exists.
                    
                    // INSERT duplicate PK values
                    // [23505] ERROR: duplicate key value violates unique constraint "educationorganization_pk" Detail: Key (educationorganizationid)=(123) already exists.
                    
                    // UPDATE PK to duplicate PK values
                    // [23505] ERROR: duplicate key value violates unique constraint "educationorganization_pk" Detail: Key (educationorganizationid)=(123) already exists.
                    // ----------------------------------------

                    var match = _expression.Match(postgresException.Message);

                    if (match.Success)
                    {
                        var constraintName = match.Groups["ConstraintName"].ValueSpan;

                        problemDetails = GetNonUniqueIdentityException(constraintName)
                            ?? GetMessageUsingPostgresException() 
                            ?? new NonUniqueValuesException(NonUniqueValuesException.DefaultDetail);

                        return true;
                    }

                    EdFiProblemDetailsExceptionBase GetNonUniqueIdentityException(ReadOnlySpan<char> constraintName)
                    {
                        // Rely on PK suffix naming convention to identify PK constraint violation (which covers almost all scenarios for this violation)
                        if (constraintName.EndsWith(PrimaryKeyNameSuffix, StringComparison.OrdinalIgnoreCase))
                        {
                            var tableName = constraintName.Slice(0, constraintName.Length - PrimaryKeyNameSuffix.Length).ToString();

                            // If detail is available, use it.
                            if (!string.IsNullOrEmpty(postgresException.Detail))
                            {
                                var exceptionInfo = new PostgresExceptionInfo(postgresException, _detailExpression);

                                if (!string.IsNullOrEmpty(exceptionInfo.ColumnNames) && !string.IsNullOrEmpty(exceptionInfo.Values))
                                {
                                    string errorMessage = string.Format(
                                        DuplicatePrimaryKeyErrorFormat,
                                        exceptionInfo.TableName,
                                        exceptionInfo.ColumnNames,
                                        exceptionInfo.Values);

                                    return new NonUniqueIdentityException(NonUniqueIdentityException.DefaultDetail, [errorMessage]);
                                }
                            }

                            // Look for matching class in the request's targeted resource
                            if (_dataManagementResourceContextProvider.Get()?.Resource?
                                    .ContainedItemTypeByName.TryGetValue(tableName, out var resourceClass) ?? false)
                            {
                                var pkPropertyNames = resourceClass.IdentifyingProperties.Select(p => p.PropertyName).ToArray();

                                string errorMessage = string.Format(
                                    (pkPropertyNames.Length > 1)
                                        ? CompositeKeyErrorMessageFormat
                                        : SimpleKeyErrorMessageFormat,
                                    string.Join("', '", pkPropertyNames),
                                    resourceClass.Name);

                                return new NonUniqueIdentityException(NonUniqueIdentityException.DefaultDetail, [errorMessage]);
                            }
                        }

                        return null;
                    }

                    EdFiProblemDetailsExceptionBase GetMessageUsingPostgresException()
                    {
                        var exceptionInfo = new PostgresExceptionInfo(postgresException, _detailExpression);

                        // Column names will only be available form Postgres if a special argument is added to the connection string
                        if (exceptionInfo.ColumnNames.Length > 0 && exceptionInfo.ColumnNames != PostgresExceptionInfo.UnknownValue)
                        {
                            string detail = string.Format(
                                exceptionInfo.IsComposedKeyConstraint
                                    ? CompositeKeyErrorMessageFormat
                                    : SimpleKeyErrorMessageFormat,
                                exceptionInfo.ColumnNames,
                                exceptionInfo.TableName);

                            return new NonUniqueValuesException(detail);
                        }

                        return null;
                    }
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

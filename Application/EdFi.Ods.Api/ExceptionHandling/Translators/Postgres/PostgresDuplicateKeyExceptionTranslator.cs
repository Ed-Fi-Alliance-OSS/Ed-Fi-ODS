// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;
using Npgsql;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    public class PostgresDuplicateKeyExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
        private readonly IDomainModelProvider _domainModelProvider;

        private static readonly Regex _detailExpression = new(
            @"Key \((?<KeyColumns>.*?)\)=\((?<KeyValues>.*?)\) (?<ConstraintType>already exists).", 
            RegexOptions.Compiled);

        private const string DuplicatePrimaryKeyTableOnlyErrorFormat =
            "A primary key conflict occurred when attempting to create or update a record in the '{0}' table.";

        private const string DuplicatePrimaryKeyErrorFormat =
            "A primary key conflict occurred when attempting to create or update a record in the '{0}' table. The duplicate key is ({1}) = ({2}).";

        private const string SimpleKeyErrorMessageFormat = "The value supplied for property '{0}' of entity '{1}' is not unique.";
        private const string CompositeKeyErrorMessageFormat = "The values supplied for properties '{0}' of entity '{1}' are not unique.";

        private const string PrimaryKeyNameSuffix = "_pk";

        public PostgresDuplicateKeyExceptionTranslator(
            IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider,
            IDomainModelProvider domainModelProvider)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
            _domainModelProvider = domainModelProvider;
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

                    problemDetails = 
                        GetNonUniqueIdentityException()
                        ?? GetNonUniqueValuesException() 
                        ?? new NonUniqueValuesException(NonUniqueValuesException.DefaultDetail);

                    return true;

                    EdFiProblemDetailsExceptionBase GetNonUniqueIdentityException()
                    {
                        // Rely on PK suffix naming convention to identify PK constraint violation (which covers almost all scenarios for this violation)
                        if (postgresException.ConstraintName!.EndsWith(PrimaryKeyNameSuffix, StringComparison.OrdinalIgnoreCase))
                        {
                            var tableName = postgresException.TableName;

                            // If detail is available, use it.
                            if (!string.IsNullOrEmpty(postgresException.Detail) && !postgresException.Detail.StartsWith("Detail redacted"))
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

                            // Look for matching entity from schema information (to provide normalized name in exception)
                            if (_domainModelProvider.GetDomainModel()
                                .EntityByFullName.TryGetValue(
                                    new FullName(postgresException.SchemaName, postgresException.TableName),
                                    out var entity))
                            {
                                return new NonUniqueIdentityException(
                                    NonUniqueIdentityException.DefaultDetail,
                                    [
                                        string.Format(DuplicatePrimaryKeyTableOnlyErrorFormat, entity.Name)
                                    ]);
                            }

                            // Use the literal Postgres table name provided on the exception
                            return new NonUniqueIdentityException(
                                NonUniqueIdentityException.DefaultDetail,
                                [
                                    string.Format(DuplicatePrimaryKeyTableOnlyErrorFormat, tableName)
                                ]);
                        }

                        return null;
                    }

                    EdFiProblemDetailsExceptionBase GetNonUniqueValuesException()
                    {
                        var exceptionInfo = new PostgresExceptionInfo(postgresException, _detailExpression);

                        // Column names will only be available from Postgres if the "Include Error Detail=true" value is added to the connection string
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

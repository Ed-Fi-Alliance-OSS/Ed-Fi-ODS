// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;
using NHibernate.Exceptions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class SqlServerPrimaryKeyConstraintExceptionTranslator : IProblemDetailsExceptionTranslator
    {
        private const string MessageFormat =
            "A natural key conflict occurred when attempting to create a new resource '{0}' with a duplicate key. The duplicated columns and values are [{1}] {2}.";

        private static readonly Regex _matchPattern = new(
            @"^Violation of PRIMARY KEY constraint '(?<IndexName>\w+)'\.\s+Cannot insert duplicate key in object '[a-z]+\.(?<TableName>\w+)'\.\s+The duplicate key value is (?<Values>\(.*\))\.\s+The statement has been terminated\.\s*$");

        private readonly IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;

        public SqlServerPrimaryKeyConstraintExceptionTranslator(IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider)
        {
            _dataManagementResourceContextProvider = dataManagementResourceContextProvider;
        }

        public bool TryTranslate(Exception ex, out IEdFiProblemDetails problemDetails)
        {
            var exception = ex is GenericADOException
                ? ex.InnerException
                : ex;

            if (exception is SqlException)
            {
                var match = _matchPattern.Match(exception.Message);

                if (match.Success)
                {
                    var resourceEntity = _dataManagementResourceContextProvider.Get().Resource.Entity;

                    string values = match.Groups["Values"].Value;

                    string columnNames = resourceEntity.BaseEntity == null ? 
                        string.Join(", ", resourceEntity.Identifier.Properties.Select(x => x.PropertyName))
                        : string.Join(", ", resourceEntity.BaseEntity.Identifier.Properties.Select(x => x.PropertyName));

                    var message = string.Format(MessageFormat, resourceEntity.Name, columnNames, values);

                    problemDetails = new NaturalKeyConflictException("scenario56.");
                    return true;
                }
            }

            problemDetails = null;
            return false;
        }
    }
}

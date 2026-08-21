// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using EdFi.Ods.Common.Infrastructure.SqlServer;

namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public class SqlServerDialect : Dialect
    {
        // Must match RelationshipAuthorizationConventions.ClaimsParameterName (in EdFi.Ods.Api, which cannot be
        // referenced from this assembly), prefixed with '@'.
        public const string ClaimsParameterName = "@ClaimEducationOrganizationIds";

        public const string ClaimsTempTableName = "#ClaimEdOrgIds";

        // TVPs carry no statistics on their values, causing the optimizer to catastrophically misestimate the
        // relationship-based authorization joins for large claim lists. Landing the TVP contents into a temp table
        // inside the batch provides the optimizer with statistics, while the TVP remains the transport on the wire
        // (required to stay under the 2,100 parameter limit for clients with very large EdOrg counts).
        private const string ClaimsTempTableLandingSql =
            $"CREATE TABLE {ClaimsTempTableName} (Id BIGINT PRIMARY KEY); INSERT INTO {ClaimsTempTableName} (Id) SELECT Id FROM {ClaimsParameterName};";

        public override string GetTemplateString(string sourceTableName)
        {
            return $"/**prologue**/{base.GetTemplateString(sourceTableName)}";
        }

        public override string GetCountTemplateString(string countTableCteName)
        {
            return $"/**prologue**/{base.GetCountTemplateString(countTableCteName)}";
        }

        public override string GetLimitOffsetString(string limitParameter, string offsetParameter)
        {
            if (offsetParameter == null && limitParameter == null)
            {
                return null;
            }

            if (offsetParameter != null && limitParameter != null)
            {
                return $"OFFSET {offsetParameter} ROWS FETCH NEXT {limitParameter} ROWS ONLY";
            }

            if (offsetParameter != null)
            {
                return $"OFFSET {offsetParameter} ROWS";
            }

            return $"OFFSET 0 ROWS FETCH NEXT {limitParameter} ROWS ONLY";
        }

        public override (string sql, object parameters, string prologue) GetInClause(string columnName, string parameterName, IList values)
        {
            // If list is empty, replace the IN clause with literal false condition
            if (values.Count == 0)
            {
                return ("1 = 0", null, null);
            }

            var itemSystemType = values[0].GetType();

            // ODS does not support TVPs using shorts, so use int instead
            if (itemSystemType == typeof(short))
            {
                itemSystemType = typeof(int);
            }

            var tvp = SqlServerTableValuedParameterHelper.CreateIdDataTable(values, itemSystemType)
                .AsTableValuedParameter(SqlServerStructuredMappings.StructuredTypeNameBySystemType[itemSystemType]);

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new[] { new KeyValuePair<string, object>(parameterName, tvp) });

            if (parameterName == ClaimsParameterName)
            {
                return ($"{columnName} IN (SELECT Id FROM {ClaimsTempTableName})", parameters, ClaimsTempTableLandingSql);
            }

            return ($"{columnName} IN (SELECT Id FROM {parameterName})", parameters, null);
        }

        public override string GetGreatestString(string expression1, string expression2)
        {
            // For SQL 2022 and later, this override is not need. For SQL 2019 and earlier, CASE must be used
            return $"CASE WHEN {expression1} > {expression2} THEN {expression1} ELSE {expression2} END";
        }

        /// <summary>
        /// Gets the maximum number of allowed parameters for SQL Server (see https://learn.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?view=sql-server-ver16).
        /// </summary>
        /// <returns>2100</returns>
        public override int GetMaxParameterCount() => 2100;

        public override (string keywords, string aliasedExpression) GetCrossJoinString(string expression, string alias, string[] columnNames = null)
        {
            return ("CROSS APPLY", $"{expression} AS {alias}{(columnNames == null ? string.Empty : $"({string.Join(", ", columnNames)})")}");
        }
    }
}

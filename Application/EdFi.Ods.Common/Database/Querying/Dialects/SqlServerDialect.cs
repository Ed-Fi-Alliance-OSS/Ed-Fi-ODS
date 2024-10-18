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

        public override (string sql, object parameters) GetInClause(string columnName, string parameterName, IList values)
        {
            // If list is empty, replace the IN clause with literal false condition
            if (values.Count == 0)
            {
                return ("1 = 0", null);
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

            return ($"{columnName} IN (SELECT Id FROM {parameterName})", parameters);
        }

        public override string GetGreatestString(string expression1, string expression2)
        {
            // For SQL 2022 and later, this override is not need. For SQL 2019 and earlier, CASE must be used
            return $"CASE WHEN {expression1} > {expression2} THEN {expression1} ELSE {expression2} END";
        }
    }
}

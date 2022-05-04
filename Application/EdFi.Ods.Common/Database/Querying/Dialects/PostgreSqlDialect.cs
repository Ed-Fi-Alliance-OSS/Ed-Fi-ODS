// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;

namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public class PostgreSqlDialect : Dialect
    {
        public override string GetLimitOffsetString(int? limit, int? offset)
        {
            if (offset == null && limit == null)
            {
                return null;
            }

            if (offset != null && limit != null)
            {
                return $"LIMIT {limit} OFFSET {offset}";
            }

            if (offset != null)
            {
                return $"OFFSET {offset}";
            }

            return $"LIMIT {limit}";
        }

        public override (string sql, object parameters) GetInClause(string columnName, string parameterName, IList values)
        {
            var parameters = new Dictionary<string, object>();

            int parameterIndex = 0;

            foreach (object value in values)
            {
                string itemParameterName = $"{parameterName}_{parameterIndex++}";
                parameters.Add(itemParameterName, value);
            }

            return ($"{columnName} IN (VALUES ({string.Join("), (", parameters.Keys)}) )", parameters);
        }
    }
}

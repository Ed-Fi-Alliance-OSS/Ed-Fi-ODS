// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using Dapper;

namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public class SqlServerDialect : Dialect
    {
        public override string GetLimitOffsetString(int? limit, int? offset)
        {
            if (offset == null && limit == null)
            {
                return null;
            }

            if (offset != null && limit != null)
            {
                return $"OFFSET {offset} ROWS FETCH NEXT {limit} ROWS ONLY";
            }

            if (offset != null)
            {
                return $"OFFSET {offset} ROWS";
            }

            return $"OFFSET 0 ROWS FETCH NEXT {limit} ROWS ONLY";
        }

        public override (string sql, object parameters) GetInClause(string columnName, string parameterName, IList values)
        {
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(new[] { new KeyValuePair<string, object>(parameterName, values) });

            return ($"{columnName} IN {parameterName}", parameters);
        }
    }
}

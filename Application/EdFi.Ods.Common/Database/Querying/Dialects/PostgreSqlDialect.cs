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
        public override string GetLimitOffsetString(string limitParameter, string offsetParameter)
        {
            if (offsetParameter == null && limitParameter == null)
            {
                return null;
            }

            if (offsetParameter != null && limitParameter != null)
            {
                return $"LIMIT {limitParameter} OFFSET {offsetParameter}";
            }

            if (offsetParameter != null)
            {
                return $"OFFSET {offsetParameter}";
            }

            return $"LIMIT {limitParameter}";
        }

        public override (string sql, object parameters) GetInClause(string columnName, string parameterName, IList values)
        {
            // If list is empty, replace the IN clause with literal false condition
            if (values.Count == 0)
            {
                return ("1 = 0", null);
            }

            var parameters = new Dictionary<string, object>();

            int parameterIndex = 0;

            foreach (object value in values)
            {
                string itemParameterName = $"{parameterName}_{parameterIndex++}";
                parameters.Add(itemParameterName, value);
            }

            return ($"{columnName} IN (VALUES ({string.Join("), (", parameters.Keys)}) )", parameters);
        }

        public override string GetNextSequenceValueString(string sequenceSchema, string sequenceName) 
            => $"nextval('{sequenceSchema}.{sequenceName}')";

        /// <summary>
        /// Gets the maximum number of allowed parameters for PostgreSQL (see https://www.postgresql.org/docs/current/limits.html).
        /// </summary>
        /// <returns>65535</returns>
        public override int GetMaxParameterCount() => 65535;
    }
}

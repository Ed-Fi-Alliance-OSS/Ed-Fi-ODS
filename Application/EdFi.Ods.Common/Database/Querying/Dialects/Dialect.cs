// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;

namespace EdFi.Ods.Common.Database.Querying.Dialects
{
    public abstract class Dialect
    {
        public virtual string GetTemplateString(string sourceTableName)
        {
            return
                $"/**with**/ SELECT /**distinct**/ /**select**/ FROM {sourceTableName}/**innerjoin**/ /**leftjoin**/ /**rightjoin**/ /**crossjoin**/ /**where**/ /**groupby**/ /**orderby**/ /**paging**/";
        }

        public virtual string GetCountTemplateString(string countTableCteName)
        {
            return $"/**with**/ SELECT /**distinct**/ /**select**/ FROM {countTableCteName}";
        }

        public virtual string GetSelectCountString()
        {
            return "COUNT(1)";
        }

        public abstract string GetLimitOffsetString(string limitParameter, string offsetParameter);

        /// <summary>
        /// Gets the SQL for an IN clause along with its parameters, and (optionally) a prologue statement that must be
        /// emitted once at the start of the batch containing the IN clause (e.g. to materialize parameter values into
        /// a temp table); returns a <b>null</b> prologue when no batch preparation is needed.
        /// </summary>
        public abstract (string sql, object parameters, string prologue) GetInClause(string columnName, string parameterName, IList values);

        public virtual string GetCteString(string cteName, string sql)
        {
            return $"{cteName} AS ({sql})";
        }

        public virtual string GetGreatestString(string expression1, string expression2)
        {
            return $"GREATEST({expression1}, {expression2})";
        }

        public abstract int GetMaxParameterCount();

        public abstract (string keywords, string aliasedExpression) GetCrossJoinString(string expression, string alias, string[] columnNames = null);
    }
}

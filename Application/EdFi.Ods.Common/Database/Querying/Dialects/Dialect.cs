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
                $"/**with**/ SELECT /**select**/ FROM {sourceTableName}/**innerjoin**/ /**leftjoin**/ /**rightjoin**/ /**where**/ /**groupby**/ /**orderby**/ /**paging**/";
        }

        public virtual string GetCountTemplateString(string countTableCteName)
        {
            return $"/**with**/ SELECT /**select**/ FROM {countTableCteName}";
        }

        public virtual string GetSelectCountString()
        {
            return "COUNT(1)";
        }

        public abstract string GetLimitOffsetString(int? limit, int? offset);

        public abstract (string sql, object parameters) GetInClause(string columnName, string parameterName, IList values);

        public virtual string GetCteString(string cteName, string sql)
        {
            return $"{cteName} AS ({sql})";
        }
    }
}

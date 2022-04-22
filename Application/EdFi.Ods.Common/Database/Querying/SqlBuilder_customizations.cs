// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database.Querying
{
    public partial class SqlBuilder
    {
        protected internal SqlBuilder LimitOffset(string sql, dynamic parameters = null)
        {
            if (sql != null)
            {
                if (_data.TryGetValue("paging", out var clauses))
                {
                    // Clear existing paging
                    clauses.Clear();
                }
                
                AddClause("paging", sql, parameters, "", "\n ", "\n", false);
            }

            return this;
        }
        
        protected internal SqlBuilder With(string sql, dynamic parameters = null)
        {
            if (sql != null)
            {
                AddClause("with", sql, parameters, ", ", "WITH ", "\n", false);
            }

            return this;
        }

        public SqlBuilder Clone()
        {
            // Get the new builder's data
            var newBuilder = new SqlBuilder();
        
            // Copy the state (of immutable clauses) over
            foreach (var item in _data)
            {
                newBuilder._data[item.Key] = item.Value.Clone();
            }
        
            // Copy the seq value
            newBuilder._seq = _seq;
        
            // Return the cloned builder
            return newBuilder;
        }

        private partial class Clauses
        {
            public Clauses Clone()
            {
                var newClauses = new Clauses(_joiner, _prefix, _postfix);
                newClauses.AddRange(this);

                return newClauses;
            }
        }
    }
}

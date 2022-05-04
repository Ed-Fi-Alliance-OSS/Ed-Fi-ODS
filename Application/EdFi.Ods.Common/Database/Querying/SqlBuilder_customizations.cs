// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Database.Querying
{
    public partial class SqlBuilder
    {
        /// <summary>
        /// Sets a clause that should only appear once within the resulting query (e.g. paging).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected SqlBuilder SetClause(string name, string sql, object parameters)
        {
            if (!_data.TryGetValue(name, out var clauses))
            {
                clauses = new Clauses(string.Empty, "\n", "\n");
                _data[name] = clauses;
            }
            else
            {
                // Clear existing clause
                clauses.Clear();
            }

            clauses.Add(new Clause(sql, parameters, isInclusive: false));
            _seq++;
            return this;
        }

        public SqlBuilder LimitOffset(string sql, dynamic parameters = null) =>
            SetClause("paging", sql, parameters);

        public SqlBuilder With(string sql, dynamic parameters = null) =>
            AddClause("with", sql, parameters, ", ", "WITH ", "\n", false);

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

        /// <summary>
        /// Clones the intrinsic state and immutable clauses contained within this instance.
        /// </summary>
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

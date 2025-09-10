// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Database.Querying
{
    public partial class SqlBuilder
    {
        private const string Space = " ";

        /// <summary>
        /// Sets a clause that should only appear once within the resulting query (e.g. paging).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="prefix"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        private SqlBuilder SetClause(string name, string sql, object parameters, string prefix = "\n", string postfix = "\n")
        {
            if (!_data.TryGetValue(name, out var clauses))
            {
                clauses = new Clauses(string.Empty, prefix, postfix);
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

        public SqlBuilder ClearClause(string name)
        {
            if (_data.TryGetValue(name, out var clauses))
            {
                // Clear existing clause
                clauses.Clear();
            }

            return this;
        }

        public SqlBuilder Distinct() =>
            SetClause("distinct", "DISTINCT", null, null, null);

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
        /// Copies the internal data for the specified keys into current SqlBuilder.
        /// </summary>
        /// <param name="source">The <see cref="SqlBuilder" /> instance from which internal data is to be copied.</param>
        /// <param name="keys">The keys to be copied (e.g. "innerjoin", "join", etc.)</param>
        protected internal void CopyDataFrom(SqlBuilder source, params string[] keys)
        {
            source._data
                .Where(kvp => keys.Contains(kvp.Key))
                .ForEach(kvp => AddClauses(kvp.Key, kvp.Value));
        }
        
        private void AddClauses(string name, Clauses clauses)
        {
            if (!_data.TryGetValue(name, out Clauses existingClauses))
            {
                existingClauses = clauses.Clone(); // new Clauses(joiner, prefix, postfix);
                _data[name] = existingClauses;
            }
            else
            {
                existingClauses.AddRange(clauses);
            }
            
            _seq++;
        }

        /// <summary>
        /// Adds the supplied query builder as a CTE entry in the current <see cref="SqlBuilder" /> instance, flattening any
        /// contained CTE expressions as necessary.
        /// </summary>
        /// <param name="cteName">The name for the CTE expression.</param>
        /// <param name="cteSqlBuilder">The <see cref="SqlBuilder" /> instance representing the query to be added as a CTE expression.</param>
        /// <param name="templateString">The SQL template to be applied to the supplied <see cref="SqlBuilder" /> to produce the raw SQL for the query.</param>
        /// <param name="createCteRawSql">A function that takes the CTE name and the raw query SQL and returns the final raw SQL for use in the CTE expression.</param>
        /// <returns>The current <see cref="SqlBuilder" />.</returns>
        public SqlBuilder With(
            string cteName,
            SqlBuilder cteSqlBuilder,
            string templateString,
            Func<string, string, string> createCteRawSql)
        {
            // Copy WITH clauses from the supplied SqlBuilder for the CTE up to the main SqlBuilder (this one)
            if (cteSqlBuilder._data.TryGetValue("with", out var withClauses))
            {
                // Copy with clauses up to the current SqlBuilder
                foreach (Clause withClause in withClauses)
                {
                    With(withClause.Sql);
                }
            }

            // Apply supplied template to the nested SqlBuilder (stripping the WITH and ORDER BY clauses, if present)
            string templateStringWithoutWith = templateString.Replace("/**with**/", string.Empty);

            // Apply the query of the nested SqlBuilder as another CTE
            var nestedTemplate = cteSqlBuilder.AddTemplate(templateStringWithoutWith);
            string cteRawSql = createCteRawSql(cteName, nestedTemplate.RawSql);

            return With(cteRawSql, nestedTemplate.Parameters);
        }

        public SqlBuilder CrossJoin(string sql, string dialectKeywords, dynamic parameters = null) =>
            AddClause("crossjoin", sql, parameters, $"\n{dialectKeywords} (", $"\n{dialectKeywords} ", "\n", false);

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

        public bool IsEmpty()
        {
            return _data.Count == 0;
        }

        public bool HasWhereClause()
        {
            return HasClause(ClauseKey.Where);
        }

        public bool HasDistinct()
        {
            return HasClause(ClauseKey.Distinct);
        }

        private bool HasClause(string clausekey)
        {
            return _data.Any(kvp => kvp.Key == clausekey);
        }
    }

    public static class ClauseKey
    {
        public static string Intersect = "intersect";
        public static string InnerJoin = "innerjoin";
        public static string LeftJoin = "leftjoin";
        public static string RightJoin = "rightjoin";
        public static string Where = "where";
        public static string OrderBy = "orderby";
        public static string Select = "select";
        public static string Parameters = "--parameters";
        public static string Join = "join";
        public static string GroupBy = "groupby";
        public static string Having = "having";
        public static string Set = "set";
        public static string Distinct = "distinct";
        public static string With = "with";
    }
}

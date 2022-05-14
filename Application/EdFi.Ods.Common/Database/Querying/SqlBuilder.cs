// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Dapper;

namespace EdFi.Ods.Common.Database.Querying
{
    // NOTE: Copied from commit 5c87dc9 (modified on May 1, 2020) from Dapper GitHub repository and modified
    // to make Clause immutable. 
    // Add functionality to this class by adding code to the partial class SqlBuilder_customizations.cs
    // See: https://github.com/DapperLib/Dapper/blob/5c87dc97382aa79422ff05b29abbadd035a72b62/Dapper.SqlBuilder/SqlBuilder.cs
    
    public partial class SqlBuilder
    {
        private readonly Dictionary<string, Clauses> _data = new Dictionary<string, Clauses>();
        private int _seq;

        private class Clause
        {
            public Clause(string sql, object parameters, bool isInclusive)
            {
                Sql = sql;
                Parameters = parameters;
                IsInclusive = isInclusive;
            }

            public string Sql { get; }
            public object Parameters { get; }
            public bool IsInclusive { get; }
        }

        private partial class Clauses : List<Clause>
        {
            private readonly string _joiner, _prefix, _postfix;

            public Clauses(string joiner, string prefix = "", string postfix = "")
            {
                _joiner = joiner;
                _prefix = prefix;
                _postfix = postfix;
            }

            public string ResolveClauses(DynamicParameters p)
            {
                foreach (var item in this)
                {
                    try
                    {
                        p.AddDynamicParams(item.Parameters);
                    }
                    catch (ArgumentException ex)
                    {
                        throw new ArgumentException($"Parameter processing failed while resolving SqlBuilder clauses (consider using explicit parameter names in CTE queries to avoid name conflicts). Clause SQL: {item.Sql}", ex);
                    }
                }

                return this.Any(a => a.IsInclusive)
                    ? _prefix +
                      string.Join(_joiner,
                          this.Where(a => !a.IsInclusive)
                              .Select(c => c.Sql)
                              .Union(new[]
                              {
                                  " ( " +
                                  string.Join(" OR ", this.Where(a => a.IsInclusive).Select(c => c.Sql).ToArray()) +
                                  " ) "
                              }).ToArray()) + _postfix
                    : _prefix + string.Join(_joiner, this.Select(c => c.Sql).ToArray()) + _postfix;
            }
        }

        public class Template
        {
            private readonly string _sql;
            private readonly SqlBuilder _builder;
            private readonly object _initParams;
            private int _dataSeq = -1; // Unresolved

            public Template(SqlBuilder builder, string sql, dynamic parameters)
            {
                _initParams = parameters;
                _sql = sql;
                _builder = builder;
            }

            private static readonly Regex _regex = new Regex(@"\/\*\*.+?\*\*\/", RegexOptions.Compiled | RegexOptions.Multiline);

            private void ResolveSql()
            {
                if (_dataSeq != _builder._seq)
                {
                    var p = new DynamicParameters(_initParams);

                    rawSql = _sql;

                    foreach (var pair in _builder._data)
                    {
                        rawSql = rawSql.Replace("/**" + pair.Key + "**/", pair.Value.ResolveClauses(p));
                    }
                    parameters = p;

                    // replace all that is left with empty
                    rawSql = _regex.Replace(rawSql, string.Empty);

                    _dataSeq = _builder._seq;
                }
            }

            private string rawSql;
            private object parameters;

            public string RawSql
            {
                get { ResolveSql(); return rawSql; }
            }

            public object Parameters
            {
                get { ResolveSql(); return parameters; }
            }
        }

        public Template AddTemplate(string sql, dynamic parameters = null) =>
            new Template(this, sql, parameters);

        protected SqlBuilder AddClause(string name, string sql, object parameters, string joiner, string prefix = "", string postfix = "", bool isInclusive = false)
        {
            if (!_data.TryGetValue(name, out Clauses clauses))
            {
                clauses = new Clauses(joiner, prefix, postfix);
                _data[name] = clauses;
            }

            clauses.Add(new Clause(sql, parameters, isInclusive));
            _seq++;
            return this;
        }

        public SqlBuilder Intersect(string sql, dynamic parameters = null) =>
            AddClause("intersect", sql, parameters, "\nINTERSECT\n ", "\n ", "\n", false);

        public SqlBuilder InnerJoin(string sql, dynamic parameters = null) =>
            AddClause("innerjoin", sql, parameters, "\nINNER JOIN ", "\nINNER JOIN ", "\n", false);

        public SqlBuilder LeftJoin(string sql, dynamic parameters = null) =>
            AddClause("leftjoin", sql, parameters, "\nLEFT JOIN ", "\nLEFT JOIN ", "\n", false);

        public SqlBuilder RightJoin(string sql, dynamic parameters = null) =>
            AddClause("rightjoin", sql, parameters, "\nRIGHT JOIN ", "\nRIGHT JOIN ", "\n", false);

        public SqlBuilder Where(string sql, dynamic parameters = null) =>
            AddClause("where", sql, parameters, " AND ", "WHERE ", "\n", false);

        public SqlBuilder OrWhere(string sql, dynamic parameters = null) =>
            AddClause("where", sql, parameters, " OR ", "WHERE ", "\n", true);

        public SqlBuilder OrderBy(string sql, dynamic parameters = null) =>
            AddClause("orderby", sql, parameters, " , ", "ORDER BY ", "\n", false);

        public SqlBuilder Select(string sql, dynamic parameters = null) =>
            AddClause("select", sql, parameters, " , ", string.Empty, "\n", false);

        public SqlBuilder AddParameters(dynamic parameters) =>
            AddClause("--parameters", string.Empty, parameters, string.Empty, string.Empty, string.Empty, false);

        public SqlBuilder Join(string sql, dynamic parameters = null) =>
            AddClause("join", sql, parameters, "\nJOIN ", "\nJOIN ", "\n", false);

        public SqlBuilder GroupBy(string sql, dynamic parameters = null) =>
            AddClause("groupby", sql, parameters, " , ", "\nGROUP BY ", "\n", false);

        public SqlBuilder Having(string sql, dynamic parameters = null) =>
            AddClause("having", sql, parameters, "\nAND ", "HAVING ", "\n", false);

        public SqlBuilder Set(string sql, dynamic parameters = null) =>
             AddClause("set", sql, parameters, " , ", "SET ", "\n", false);
    }
}

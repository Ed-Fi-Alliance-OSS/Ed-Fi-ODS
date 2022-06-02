// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Dapper;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Database.Querying.Dialects;

namespace EdFi.Ods.Common.Database.Querying
{
    public class QueryBuilder
    {
        private readonly List<Cte> _ctes = new List<Cte>();
        private readonly Dialect _dialect;

        private readonly ParameterIndexer _parameterIndexer = new ParameterIndexer();
        private readonly SqlBuilder _sqlBuilder = new SqlBuilder();

        public QueryBuilder(Dialect dialect)
        {
            _dialect = dialect;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder"/> class for use in a nested scope.
        /// </summary>
        /// <param name="dialect"></param>
        /// <param name="parameterIndexer"></param>
        private QueryBuilder(Dialect dialect, ParameterIndexer parameterIndexer)
        {
            _dialect = dialect;
            _parameterIndexer = parameterIndexer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder"/> class for the purpose of creating a clone instance.
        /// </summary>
        /// <param name="dialect"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="tableName"></param>
        /// <param name="parameterIndexer"></param>
        private QueryBuilder(Dialect dialect, SqlBuilder sqlBuilder, string tableName, ParameterIndexer parameterIndexer)
        {
            _dialect = dialect;
            _sqlBuilder = sqlBuilder;
            _parameterIndexer = parameterIndexer;
            TableName = tableName;
        }

        public string TableName { get; private set; }

        private IDictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Clones the current instance with all its state so it can be used as a starting point for future queries.
        /// </summary>
        /// <returns>A copy of the current <see cref="QueryBuilder" />.</returns>
        public QueryBuilder Clone()
        {
            return new QueryBuilder(_dialect, _sqlBuilder.Clone(), TableName, _parameterIndexer.Clone());
        }

        public QueryBuilder From(string tableName)
        {
            TableName = tableName;

            return this;
        }

        public QueryBuilder Where(string column, object value)
        {
            return Where(column, "=", value);
        }

        public QueryBuilder Where(string column, string op, object value)
        {
            (DynamicParameters parameters, string parameterName) = GetParametersFromObject(value);

            _sqlBuilder.Where($"{column} {op} {parameterName}", parameters);

            return this;
        }

        private (DynamicParameters parameters, string parameterName) GetParametersFromObject(
            object value,
            string parameterNameDisposition = null)
        {
            DynamicParameters parameters = null;
            string parameterName;

            if (value is Parameter parameter)
            {
                Parameters.Add(parameter.Name, parameter.Value);
                parameterName = parameter.Name;
            }
            else if (value is IList values)
            {
                parameters = new DynamicParameters();
                parameterName = parameterNameDisposition ?? $"@p{_parameterIndexer.Increment()}";
                parameters.AddDynamicParams(new[] { new KeyValuePair<string, object>(parameterName, values) });
            }
            else
            {
                // Inline parameter, automatically named
                parameters = new DynamicParameters();
                parameterName = parameterNameDisposition ?? $"@p{_parameterIndexer.Increment()}";
                parameters.Add(parameterName, value);
            }

            return (parameters, parameterName);
        }

        public QueryBuilder Where(Func<QueryBuilder, QueryBuilder> nestedWhereApplicator)
        {
            var childScope = new QueryBuilder(_dialect, _parameterIndexer);

            // Execute supplied criteria applicator against the child scope
            nestedWhereApplicator(childScope);

            SqlBuilder childScopeSqlBuilder = childScope._sqlBuilder;

            // If no changes were made to the child scope, don't generate any SQL
            if (childScopeSqlBuilder.IsEmpty())
            {
                return this;
            }

            var template = childScopeSqlBuilder.AddTemplate(
                "/**where**/",
                childScope.Parameters.Any()
                    ? new DynamicParameters(childScope.Parameters)
                    : null);

            // Wrap the WHERE clause directly
            _sqlBuilder.Where($"({template.RawSql.Replace("WHERE ", string.Empty)})", template.Parameters);

            // Incorporate the JOINs into this builder
            _sqlBuilder.CopyDataFrom(childScopeSqlBuilder, "innerjoin", "leftjoin", "rightjoin", "join");

            return this;
        }

        public QueryBuilder OrWhere(Func<QueryBuilder, QueryBuilder> nestedWhereApplicator)
        {
            var childScope = new QueryBuilder(_dialect, _parameterIndexer);

            // Execute supplied criteria applicator against the child scope
            nestedWhereApplicator(childScope);

            SqlBuilder childScopeSqlBuilder = childScope._sqlBuilder;

            // If no changes were made to the child scope, don't generate any SQL
            if (childScopeSqlBuilder.IsEmpty())
            {
                return this;
            }
            
            var template = childScopeSqlBuilder.AddTemplate(
                "/**where**/",
                childScope.Parameters.Any()
                    ? new DynamicParameters(childScope.Parameters)
                    : null);

            // Wrap the WHERE clause directly
            _sqlBuilder.OrWhere($"({template.RawSql.Replace("WHERE ", string.Empty)})", template.Parameters);

            // Incorporate the JOINs into this builder
            _sqlBuilder.CopyDataFrom(childScopeSqlBuilder, "innerjoin", "leftjoin", "rightjoin", "join");

            return this;
        }

        public QueryBuilder OrWhereNull(string column)
        {
            _sqlBuilder.OrWhere($"{column} IS NULL");

            return this;
        }

        public QueryBuilder WhereLike(string columnName, object value)
        {
            (DynamicParameters parameters, string parameterName) = GetParametersFromObject(value);

            _sqlBuilder.Where($"{columnName} LIKE {parameterName}", parameters);

            return this;
        }

        public QueryBuilder OrWhereLike(string expression, object value)
        {
            (DynamicParameters parameters, string parameterName) = GetParametersFromObject(value);

            _sqlBuilder.OrWhere($"{expression} LIKE {parameterName}", parameters);

            return this;
        }

        public QueryBuilder WhereNull(string columnName)
        {
            _sqlBuilder.Where($"{columnName} IS NULL");

            return this;
        }

        public QueryBuilder WhereNotNull(string columnName)
        {
            _sqlBuilder.Where($"{columnName} IS NOT NULL");

            return this;
        }

        public QueryBuilder WhereIn(string columnName, IList values)
        {
            string parameterName = $"@p{_parameterIndexer.Increment()}";

            var (sql, parameters) = _dialect.GetInClause(columnName, parameterName, values);

            _sqlBuilder.Where(sql, parameters);

            return this;
        }

        public QueryBuilder OrWhereIn(string columnName, IList values)
        {
            string parameterName = $"@p{_parameterIndexer.Increment()}";

            var (sql, parameters) = _dialect.GetInClause(columnName, parameterName, values);

            _sqlBuilder.OrWhere(sql, parameters);

            return this;
        }

        public QueryBuilder With(string cteName, QueryBuilder cteQueryBuilder)
        {
            // Apply the nested query builder as a WITH clause to this query builder
            string templateString = _dialect.GetTemplateString(cteQueryBuilder.TableName);
            _sqlBuilder.With(cteName, cteQueryBuilder._sqlBuilder, templateString, _dialect.GetCteString);

            return this;
        }

        public QueryBuilder Join(string tableName, string thisExpression, string otherExpression)
        {
            _sqlBuilder.InnerJoin($"{tableName} ON {thisExpression} = {otherExpression}");

            return this;
        }

        public QueryBuilder Join(string table, Func<Join, Join> joiner)
        {
            var join = joiner(new Join(table));

            _sqlBuilder.InnerJoin(
                $"{join.TableName} ON {string.Join(" AND ", join.Segments.Select(s => $"{s.first} {s.@operator} {s.second}"))}");

            return this;
        }

        // public QueryBuilder Join(QueryBuilder query, Func<Join, Join> joiner, string type = "inner join")
        // {
        //     return this;
        // }

        public QueryBuilder LeftJoin(string tableName, string thisExpression, string otherExpression)
        {
            _sqlBuilder.LeftJoin($"{tableName} ON {thisExpression} = {otherExpression}");

            return this;
        }

        public QueryBuilder LeftJoin(string table, Func<Join, Join> joiner)
        {
            var join = joiner(new Join(table));

            _sqlBuilder.LeftJoin(
                $"{join.TableName} ON {string.Join(" AND ", join.Segments.Select(s => $"{s.first} {s.@operator} {s.second}"))}");

            return this;
        }

        // public QueryBuilder LeftJoin(QueryBuilder query, Func<Join, Join> joiner, string type = "inner join")
        // {
        //     return this;
        // }

        public QueryBuilder Select(params string[] columns)
        {
            columns.ForEach(c => _sqlBuilder.Select(c));

            return this;
        }

        public QueryBuilder SelectRaw(string expression)
        {
            _sqlBuilder.Select(expression);

            return this;
        }

        public QueryBuilder GroupBy(params string[] columns)
        {
            columns.ForEach(c => _sqlBuilder.GroupBy(c));

            return this;
        }

        public QueryBuilder OrderBy(params string[] columns)
        {
            columns.ForEach(c => _sqlBuilder.OrderBy(c));

            return this;
        }

        public QueryBuilder LimitOffset(int limit, int offset = 0)
        {
            // Apply paging
            _sqlBuilder.LimitOffset(_dialect.GetLimitOffsetString(limit, offset));

            return this;
        }

        public SqlBuilder.Template BuildTemplate()
        {
            // Build the template
            string template = _dialect.GetTemplateString(TableName);

            var parameters = Parameters.Any()
                ? new DynamicParameters(Parameters)
                : null;

            return _sqlBuilder.AddTemplate(template, parameters);
        }

        public SqlBuilder.Template BuildCountTemplate()
        {
            var parameters = Parameters.Any()
                ? new DynamicParameters(Parameters)
                : null;

            // Build the Count SQL builder
            var countSqlBuilder = new SqlBuilder();

            // Wrap main query with the count query builder as a CTE expression
            string countableTemplateString = _dialect.GetTemplateString(TableName)
                .Replace("/**orderby**/", string.Empty)
                .Replace("/**paging**/", string.Empty);

            const string CountQueryCteName = "__count_data";
            
            countSqlBuilder.With(CountQueryCteName, _sqlBuilder, countableTemplateString, _dialect.GetCteString);
            countSqlBuilder.Select(_dialect.GetSelectCountString());
            countSqlBuilder.AddParameters(parameters);

            // Return the template for the count query 
            return countSqlBuilder.AddTemplate(_dialect.GetCountTemplateString(CountQueryCteName));
        }

        public class Cte
        {
            public Cte(string name, QueryBuilder queryBuilder, object parameters = null)
            {
                Name = name;
                QueryBuilder = queryBuilder;
                Parameters = parameters;
            }

            public string Name { get; }

            public QueryBuilder QueryBuilder { get; }

            public object Parameters { get; }
        }

        protected class ParameterIndexer
        {
            private int _parameterIndex = -1;

            public ParameterIndexer() { }

            private ParameterIndexer(int parameterIndex)
            {
                _parameterIndex = parameterIndex;
            }

            public int Increment() => Interlocked.Increment(ref _parameterIndex);

            /// <summary>
            /// Gets the next parameter name, incrementing the index with a call to <see cref="Increment" />.
            /// </summary>
            /// <returns></returns>
            public string NextParameterName() => $"@p{Increment()}";

            public ParameterIndexer Clone()
            {
                return new ParameterIndexer(_parameterIndex);
            }
        }
    }

    public class Join
    {
        private readonly List<(string first, string second, string @operator)> _segments =
            new List<(string first, string second, string @operator)>();

        public Join(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; }

        public IReadOnlyList<(string first, string second, string @operator)> Segments
        {
            get => _segments;
        }

        public Join On(string first, string second, string @operator = "=")
        {
            _segments.Add((first, second, @operator));

            return this;
        }
    }
}

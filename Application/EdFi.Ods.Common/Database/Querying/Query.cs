// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using EdFi.Common.Utils.Extensions;

namespace EdFi.Ods.Common.Database.Querying
{
    public class Query
    {
        protected class ParameterIndexer
        {
            private int _parameterIndex = -1;

            public int Increment() => Interlocked.Increment(ref _parameterIndex);

            public ParameterIndexer() { }
            
            private ParameterIndexer(int parameterIndex)
            {
                _parameterIndex = parameterIndex;
            }
            
            public ParameterIndexer Clone()
            {
                return new ParameterIndexer(_parameterIndex);
            }
        }
        
        protected internal readonly SqlBuilder SqlBuilder = new SqlBuilder();
        
        protected internal int? _offset;
        protected internal int? _limit;
        protected internal string _tableName;

        private readonly ParameterIndexer _parameterIndexer = new ParameterIndexer();

        public Query() { }

        public Query(string tableName)
        {
            From(tableName);
        }

        protected Query(ParameterIndexer parameterIndexer)
        {
            _parameterIndexer = parameterIndexer;
        }

        private Query(SqlBuilder sqlBuilder, string tableName, int? offset, int? limit, ParameterIndexer parameterIndexer)
        {
            SqlBuilder = sqlBuilder;
            _parameterIndexer = parameterIndexer;
            _tableName = tableName;
            _offset = offset;
            _limit = limit;
        }

        public Query Clone()
        {
            return new Query(SqlBuilder.Clone(), _tableName, _offset, _limit, _parameterIndexer.Clone());
        }

        public IDictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        // public Dialect Dialect { get; set; }

        public Query From(string tableName)
        {
            _tableName = tableName;
            return this;
        }
        
        public Query Where(string column, object value)
        {
            return Where(column, "=", value);
        }
        
        public Query Where(string column, string op, object value)
        {
            (DynamicParameters parameters, string parameterName) = GetParametersFromObject(value);

            SqlBuilder.Where($"{column} {op} {parameterName}", parameters);

            return this;
        }

        private (DynamicParameters parameters, string parameterName) GetParametersFromObject(object value, string parameterNameDisposition = null)
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

        public Query Where(Func<Query, Query> nestedWhereApplicator)
        {
            var childScope = new Query(_parameterIndexer);
            nestedWhereApplicator(childScope);

            var template = childScope.SqlBuilder.AddTemplate("/**where**/", 
                childScope.Parameters.Any() ? new DynamicParameters(childScope.Parameters) : null);

            SqlBuilder.Where(
                $"({template.RawSql.Replace("WHERE ", string.Empty)})", template.Parameters);

            return this;
        }

        public Query OrWhere(Func<Query, Query> nestedWhereApplicator)
        {
            var childScope = new Query(_parameterIndexer);
            nestedWhereApplicator(childScope);

            var template = childScope.SqlBuilder.AddTemplate("/**where**/",
                childScope.Parameters.Any() ? new DynamicParameters(childScope.Parameters) : null);

            SqlBuilder.OrWhere(
                $"({template.RawSql.Replace("WHERE ", string.Empty)})", template.Parameters);
            
            return this;
        }

        public Query OrWhereNull(string column)
        {
            SqlBuilder.OrWhere($"{column} IS NULL");
            
            return this;
        }

        public Query WhereLike(string columnName, object value)
        {
            (DynamicParameters parameters, string parameterName) = GetParametersFromObject(value);
            
            SqlBuilder.Where($"{columnName} LIKE {parameterName}", parameters);
            return this;
        }

        public Query OrWhereLike(string expression, object value)
        {
            (DynamicParameters parameters, string parameterName) = GetParametersFromObject(value);

            SqlBuilder.OrWhere($"{expression} LIKE {parameterName}", parameters);
            return this;
        }

        public Query WhereNull(string columnName)
        {
            SqlBuilder.Where($"{columnName} IS NULL");
            return this;
        }

        public Query WhereNotNull(string columnName)
        {
            SqlBuilder.Where($"{columnName} IS NOT NULL");
            return this;
        }

        public Query WhereIn(string columnName, object values)
        {
            string parameterName = $"@p{_parameterIndexer.Increment()}";

            var (sql, parameters) = GetInClauseMsSql(columnName, parameterName, values);
            // var (sql, parameters) = GetInClausePgSql(columnName, parameterName, values);
            
            SqlBuilder.Where(sql , parameters);
            
            return this;
        }

        private (string sql, object parameters) GetInClauseMsSql(string columnName, string parameterName, object values)
        {
            // Sql Server
            (DynamicParameters parameters, string actualParameterName) = GetParametersFromObject(values, parameterName);
            return ($"{columnName} IN {actualParameterName}", parameters);
        }
        
        private (string sql, object parameters) GetInClausePgSql(string columnName, string parameterName, object values)
        {
            // Postgres
            var parameters = new Dictionary<string, object>();

            int parameterIndex = 0; 

            foreach (object value in (IEnumerable) values)
            {
                string expansionParameterName = $"{parameterName}_{parameterIndex++}";
                parameters.Add(expansionParameterName, value);
            }
            
            return ($"{columnName} IN (VALUES ({string.Join("), (", parameters.Keys)}) )", parameters);
        }
        
        public class Cte
        {
            public Cte(string name, Query query, object parameters = null)
            {
                Name = name;
                Query = query;
                Parameters = parameters;
            }

            public string Name { get; }
            public Query Query { get; }
            public object Parameters { get; }
        }

        protected internal readonly List<Cte> _ctes = new List<Cte>();
        
        public Query With(string cteName, Query cteQuery, object parameters = null)
        {
            _ctes.Add(new Cte(cteName, cteQuery, parameters));
            
            return this;
        }

        // public Query LeftJoin(string tableName, string thisExpression, string otherExpression)
        // {
        //     return this;
        // }
        
        public Query Join(string tableName, string thisExpression, string otherExpression)
        {
            SqlBuilder.InnerJoin($"{tableName} ON {thisExpression} = {otherExpression}");

            return this;
        }

        public Query LeftJoin(string table, Func<Join, Join> joiner)
        {
            var join = joiner(new Join(table));

            SqlBuilder.LeftJoin(
                $"{join.TableName} ON {string.Join(" AND ", join.Segments.Select(s => $"{s.first} {s.@operator} {s.second}"))}");

            return this;
        }
        
        // private ConcurrentDictionary<string, List<Join>>
        
        public Query Join(string table, Func<Join, Join> joiner)
        {
            var join = joiner(new Join(table));

            SqlBuilder.InnerJoin(
                $"{join.TableName} ON {string.Join(" AND ", join.Segments.Select(s => $"{s.first} {s.@operator} {s.second}"))}");

            return this;
        }
        
        // public Query Join(Query query, Func<Join, Join> joiner, string type = "inner join")
        // {
        //     return this;
        // }

        public Query Select(params string[] columns)
        {
            columns.ForEach(c => SqlBuilder.Select(c));
            return this;
        }
        
        public Query SelectRaw(string expression)
        {
            SqlBuilder.Select(expression);
            return this;
        }

        public Query GroupBy(params string[] columns)
        {
            columns.ForEach(c => SqlBuilder.GroupBy(c));
            return this;
        }
        
        public Query OrderBy(params string[] columns)
        {
            columns.ForEach(c => SqlBuilder.OrderBy(c));
            return this;
        }

        public Query Offset(int offset)
        {
            _offset = offset;
            return this;
        }

        public Query Limit(int limit)
        {
            _limit = limit;
            return this;
        }
        
        public Task<dynamic> GetAsync()
        {
            return Task.FromResult((dynamic) null);
        }

        public Task<T> CountAsync<T>()
        {
            return Task.FromResult(default(T));
        }
    }

    public class Join
    {
        private readonly List<(string first, string second, string @operator)> _segments =
            new List<(string first, string second, string @operator)>();

        public string TableName { get; }

        public IReadOnlyList<(string first, string second, string @operator)> Segments
        {
            get => _segments;
        }

        public Join(string tableName)
        {
            TableName = tableName;
        }

        public Join On(string first, string second, string @operator = "=")
        {
            _segments.Add((first, second, @operator));

            return this;
        }
    }
}

using System.Linq;
using Dapper;
using EdFi.Ods.Common.Database.Querying.Dialects;

namespace EdFi.Ods.Common.Database.Querying.Compilers
{
    public abstract class Compiler
    {
        public SqlResult Compile(Query query)
        {
            // Build the template
            string template = GetTemplate(query);
            
            // Apply paging
            query.SqlBuilder.LimitOffset(Dialect.GetOffsetLimitString(query._offset, query._limit));

            // Apply CTEs
            query._ctes.ForEach(
                cte =>
                {
                    var cteTemplate = cte.Query.SqlBuilder.AddTemplate(GetTemplate(cte.Query), cte.Parameters);
                    query.SqlBuilder.With($"{cte.Name} AS ({cteTemplate.RawSql})", cteTemplate.Parameters);
                }); 
            
            return new SqlResult(query.SqlBuilder.AddTemplate(template, 
                query.Parameters.Any() ? new DynamicParameters(query.Parameters) : null));
        }

        protected abstract string GetTemplate(Query query);

        protected abstract Dialect Dialect { get; } 
    }
}
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Generator.Database.NamingConventions;
using log4net;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueriesPreparer : TrackedChangesQueriesPreparerBase, IDeletedItemsQueriesPreparer
    {
        private readonly Compiler _sqlCompiler;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletedItemsQueriesPreparer));
        
        public DeletedItemsQueriesPreparer(Compiler sqlCompiler, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, IDatabaseNamingConvention namingConvention)
            : base(sqlCompiler, defaultPageSizeLimitProvider, namingConvention)
        {
            _sqlCompiler = sqlCompiler;
        }

        protected override Query PrepareDataQuery(
            QueryFactory db,
            Query mainQuery,
            IQueryParameters queryParameters,
            Resource resource)
        {
            var query = db.FromQuery(mainQuery);

            ApplyPaging(query, queryParameters);
            ApplyChangeVersionCriteria(query, queryParameters);

            if (_logger.IsDebugEnabled)
            {
                var sqlResult = _sqlCompiler.Compile(query);
                _logger.Debug(sqlResult.Sql);
            }

            return query;
        }
    }
}
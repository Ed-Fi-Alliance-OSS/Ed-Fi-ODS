using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Compilers;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems;
using log4net;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueriesPreparer : TrackedChangesQueriesPreparerBase, IKeyChangesQueriesPreparer
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletedItemsQueriesPreparer));
        
        private readonly Compiler _sqlCompiler;
        private readonly IDatabaseNamingConvention _namingConvention;
        private readonly ITrackedChangesIdentifierProjectionsProvider _trackedChangesIdentifierProjectionsProvider;

        public KeyChangesQueriesPreparer(
            Compiler sqlCompiler, 
            IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, IDatabaseNamingConvention namingConvention,
            ITrackedChangesIdentifierProjectionsProvider trackedChangesIdentifierProjectionsProvider)
            : base(sqlCompiler, defaultPageSizeLimitProvider, namingConvention)
        {
            _sqlCompiler = sqlCompiler;
            _namingConvention = namingConvention;
            _trackedChangesIdentifierProjectionsProvider = trackedChangesIdentifierProjectionsProvider;
        }

        protected override Query PrepareDataQuery(
            QueryFactory db,
            Query mainQuery,
            IQueryParameters queryParameters,
            Resource resource)
        {
            // Apply the change version filtering to the main query (the CTE in this case)
            ApplyChangeVersionCriteria(mainQuery, queryParameters);

            // Create the data query that uses the CTE (i.e. the "main" query provided)
            var dataQuery = CreateDataQuery(mainQuery, resource);
            
            var preparedDataQuery = db.FromQuery(dataQuery);

            // Apply paging
            ApplyPaging(preparedDataQuery, queryParameters);

            if (_logger.IsDebugEnabled)
            {
                var sqlResult = _sqlCompiler.Compile(preparedDataQuery);
                _logger.Debug(sqlResult.Sql);
            }

            return preparedDataQuery;
        }

        private Query CreateDataQuery(Query changeWindowVersionsCteQuery, Resource resource)
        {
            var entity = resource.Entity;

            string idColumnName = _namingConvention.ColumnName("Id");
            string changeVersionColumnName = _namingConvention.ColumnName(ChangeQueriesDatabaseConstants.ChangeVersionColumnName);
            
            string changeQueriesTableName =
                $"{ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix}{_namingConvention.Schema(entity)}.{_namingConvention.TableName(entity)}";

            string oldAlias =
                $"{_namingConvention.IdentifierName(ChangeQueriesDatabaseConstants.TrackedChangesAlias, suffix: "_old")}";

            string newAlias =
                $"{_namingConvention.IdentifierName(ChangeQueriesDatabaseConstants.TrackedChangesAlias, suffix: "_new")}";

            string changeWindowCteName = _namingConvention.IdentifierName("ChangeWindow");
            const string ChangeWindowAlias = "cw";

            string initialChangeVersionColumnName = _namingConvention.ColumnName("InitialChangeVersion");
            string finalChangeVersionColumnName = _namingConvention.ColumnName("FinalChangeVersion");

            var identifierProjections = _trackedChangesIdentifierProjectionsProvider.GetIdentifierProjections(resource);

            var dataQuery = new Query($"{changeWindowCteName} AS {ChangeWindowAlias}")
                .With(changeWindowCteName, changeWindowVersionsCteQuery)
                .Join(
                    $"{changeQueriesTableName} AS {oldAlias}",
                    j => j.On($"{ChangeWindowAlias}.{idColumnName}", $"{oldAlias}.{idColumnName}")
                        .On($"{ChangeWindowAlias}.{initialChangeVersionColumnName}", $"{oldAlias}.{changeVersionColumnName}"))
                .Join(
                    $"{changeQueriesTableName} AS {newAlias}",
                    j => j.On($"{ChangeWindowAlias}.{idColumnName}", $"{newAlias}.{idColumnName}")
                        .On($"{ChangeWindowAlias}.{finalChangeVersionColumnName}", $"{newAlias}.{changeVersionColumnName}"))
                .Select(
                    $"{ChangeWindowAlias}.{idColumnName}",
                    $"{ChangeWindowAlias}.{finalChangeVersionColumnName} AS {changeVersionColumnName}")
                .Select(QueryFactoryHelper.IdentifyingColumns(identifierProjections, oldAlias, newAlias))
                .OrderBy($"{ChangeWindowAlias}.{finalChangeVersionColumnName}");

            return dataQuery;
        }
    }
}
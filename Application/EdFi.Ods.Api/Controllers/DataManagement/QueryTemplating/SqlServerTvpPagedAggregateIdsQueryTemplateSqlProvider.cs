using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.QueryTemplating
{
    public class SqlServerTvpPagedAggregateIdsQueryTemplateSqlProvider : IPagedAggregateIdsQueryTemplateSqlProvider
    {
        private readonly IDatabaseArtifactPhysicalNameProvider _physicalNameProvider;

        public SqlServerTvpPagedAggregateIdsQueryTemplateSqlProvider(IDatabaseArtifactPhysicalNameProvider databaseArtifactPhysicalNameProvider)
        {
            _physicalNameProvider = databaseArtifactPhysicalNameProvider;
        }
        
        /// <inheritdoc />
        public string GetSqlTemplate(Entity entity)
            => $@"
    DECLARE @ids as dbo.UniqueIdentifierTable

    INSERT INTO @ids
    SELECT /**select**/ FROM {_physicalNameProvider.GetSchemaName(entity)}.{_physicalNameProvider.GetTableName(entity)} AS e
    /**innerjoin**/
    /**leftjoin**/
    /**where**/
    /**orderby**/
    OFFSET @offset ROWS
    FETCH NEXT @limit ROWS ONLY";

        /// <inheritdoc />
        public bool IsBatchable
        {
            get => true;
        }
    }
}
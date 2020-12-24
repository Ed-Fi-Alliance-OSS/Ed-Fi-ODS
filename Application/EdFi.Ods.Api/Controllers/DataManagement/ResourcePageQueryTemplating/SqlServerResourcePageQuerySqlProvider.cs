using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQueryTemplating
{
    public class SqlServerResourcePageQuerySqlProvider : IResourcePageQuerySqlProvider
    {
        private readonly IPhysicalNamesProvider _physicalNamesProvider;

        public SqlServerResourcePageQuerySqlProvider(IPhysicalNamesProvider physicalNamesProvider)
        {
            _physicalNamesProvider = physicalNamesProvider;
        }
        
        /// <inheritdoc />
        public string GetSqlTemplate(Entity entity)
            => $@"DECLARE @ids as dbo.UniqueIdentifierTable

INSERT INTO @ids
SELECT /**select**/ FROM {_physicalNamesProvider.FullName(entity)} AS e
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
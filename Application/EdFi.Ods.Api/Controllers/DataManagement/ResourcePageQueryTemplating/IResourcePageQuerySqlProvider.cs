using Dapper;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.ResourcePageQueryTemplating
{
    public interface IResourcePageQuerySqlProvider
    {
        /// <summary>
        /// Gets the content of the SQL template for use with the Dapper <see cref="SqlBuilder" />.
        /// </summary>
        /// <param name="entity">The aggregate root entity.</param>
        /// <returns>The content of the SQL template.</returns>
        string GetSqlTemplate(Entity entity);
        
        /// <summary>
        /// Indicates whether the resulting query can be batched with the other queries for the resource data
        /// without requiring a separate round-trip to the database to first obtain the paged resources Ids.
        /// </summary>
        bool IsBatchable { get; }
    }
}
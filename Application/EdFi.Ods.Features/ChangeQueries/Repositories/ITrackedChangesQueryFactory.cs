using EdFi.Ods.Common.Models.Resource;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public interface ITrackedChangesQueryFactory
    {
        /// <summary>
        /// Gets the query that determines basis for inclusion/exclusion of records in the query (and where authorization
        /// filters should be applied).
        /// </summary>
        /// <param name="resource">The resource that is the subject of the query.</param>
        /// <returns>The Query for further modification and execution.</returns>
        Query CreateMainQuery(Resource resource);
    }
}
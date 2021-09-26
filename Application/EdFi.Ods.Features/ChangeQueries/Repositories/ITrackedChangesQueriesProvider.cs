using System.Data.Common;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public interface ITrackedChangesQueriesProvider
    {
        TrackedChangesQueries GetQueries(DbConnection connection, Resource resource, IQueryParameters queryParameters);
    }
}
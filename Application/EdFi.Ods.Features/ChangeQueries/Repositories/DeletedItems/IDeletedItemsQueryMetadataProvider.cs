using EdFi.Ods.Common.Models.Resource;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public interface IDeletedItemsQueryMetadataProvider
    {
        Query GetTemplateQuery(Resource resource);
        
        QueryProjection[] GetIdentifierProjections(Resource resource);
    }
}
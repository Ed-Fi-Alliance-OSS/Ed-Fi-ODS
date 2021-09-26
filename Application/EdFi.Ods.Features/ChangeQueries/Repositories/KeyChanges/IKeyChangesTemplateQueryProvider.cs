using EdFi.Ods.Common.Models.Resource;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public interface IKeyChangesTemplateQueryProvider
    {
        Query GetTemplateQuery(Resource resource);
        
        QueryProjection[] GetIdentifierProjections(Resource resource);
    }
}
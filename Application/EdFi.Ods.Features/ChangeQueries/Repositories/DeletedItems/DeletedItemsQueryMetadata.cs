using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.DeletedItems
{
    public class DeletedItemsQueryMetadata
    {
        public Query TemplateQuery { get; set; }
        public QueryProjection[] Projections { get; set; } 
    }
}
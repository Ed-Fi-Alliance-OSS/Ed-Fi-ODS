using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges
{
    public class KeyChangesQueryMetadata
    {
        public Query TemplateQuery { get; set; }
        public QueryProjection[] Projections { get; set; } 
    }
}
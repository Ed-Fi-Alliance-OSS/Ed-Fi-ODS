using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Models;
using EdFi.Ods.Generator.Rendering;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers.PostgreSql
{
    [RenderCondition("DatabaseEngine", "PostgreSql")]
    public class DeleteTriggerTableEnhancer : ITableEnhancer
    {
        private readonly IDatabaseNamingConvention _namingConvention;
        
        public DeleteTriggerTableEnhancer(
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDatabaseOptions databaseOptions)
        {
            _namingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseOptions.DatabaseEngine);
        }
        
        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            if (entity.IsAggregateRoot)
            {
                tableProps.ChangeQueries ??= new DynamicModel();

                tableProps.ChangeQueries.TrackedDeleteTriggerName = 
                    _namingConvention.IdentifierName(entity.Name, suffix: "_tr_deltrkg");
            }

            return table;
        }
    }
}
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;
using EdFi.Ods.Generator.Extensions;
using EdFi.Ods.Generator.Rendering;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers.PostgreSql
{
    [RenderCondition("DatabaseEngine", "PostgreSql")]
    public class ShortHashTableEnhancer : ITableEnhancer
    {
        private readonly IDatabaseNamingConvention _namingConvention;

        public ShortHashTableEnhancer(
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDatabaseOptions databaseOptions)
        {
            _namingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseOptions.DatabaseEngine);
        }

        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            tableProps.TableNameShortHash = entity.Name.GetTruncatedHash();

            return table;
        }
    }
}
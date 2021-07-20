using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace Nde.Adviser.Lds.SqlGeneration.Enhancers
{
    public class DescriptorDiscriminatorColumnTableEnhancer : ITableEnhancer
    {
        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            // Add a discriminator column for the Descriptor base table - in contrast to the existing model logic
            tableProps.DiscriminatorColumnForLds = entity.HasDiscriminator() || entity.IsDescriptorBaseEntity()
                ? ColumnHelper.CreateDiscriminatorColumn()
                : null;

            return table;
        }
    }
}
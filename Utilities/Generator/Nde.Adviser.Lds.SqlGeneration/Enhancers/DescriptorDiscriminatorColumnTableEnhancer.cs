using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator;
using EdFi.Ods.Generator.Database;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace Nde.Adviser.Lds.SqlGeneration.Enhancers
{
    public class DescriptorDiscriminatorColumnTableEnhancer : ITableEnhancer
    {
        private readonly IDatabaseNamingConvention _databaseNamingConvention;
        private readonly IDatabaseTypeTranslator _databaseTypeTranslator;

        public DescriptorDiscriminatorColumnTableEnhancer(
            IDatabaseTypeTranslatorFactory databaseTypeTranslatorFactory,
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDatabaseOptions databaseOptions)
        {
            _databaseNamingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseOptions.DatabaseEngine);
            _databaseTypeTranslator = databaseTypeTranslatorFactory.CreateTranslator(databaseOptions.DatabaseEngine);
        }
        
        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            // Add a discriminator column for the Descriptor base table - in contrast to the existing model logic
            tableProps.DiscriminatorColumnForLds = entity.HasDiscriminator() || entity.IsDescriptorBaseEntity()
                ? ColumnHelper.CreateDiscriminatorColumn(_databaseNamingConvention, _databaseTypeTranslator)
                : null;

            return table;
        }
    }
}
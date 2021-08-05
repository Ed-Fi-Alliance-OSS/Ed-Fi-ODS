using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator;
using EdFi.Ods.Generator.Database;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.NamingConventions;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers
{
    /// <summary>
    /// Implements a table enhancer that adds a Discriminator column to the Descriptor base table (which is currently explicitly
    /// excluded from the MetaEd model for edfi.Descriptor).
    /// </summary>
    public class DescriptorDiscriminatorTableEnhancer : ITableEnhancer
    {
        private readonly IDatabaseNamingConvention _databaseNamingConvention;
        private readonly IDatabaseTypeTranslator _databaseTypeConvention;

        public DescriptorDiscriminatorTableEnhancer(
            IDatabaseTypeTranslatorFactory databaseTypeTranslatorFactory,
            IDatabaseNamingConventionFactory databaseNamingConventionFactory,
            IDatabaseOptions databaseOptions)
        {
            _databaseNamingConvention = databaseNamingConventionFactory.CreateNamingConvention(databaseOptions.DatabaseEngine);
            _databaseTypeConvention = databaseTypeTranslatorFactory.CreateTranslator(databaseOptions.DatabaseEngine);
        }
        
        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            if (entity.IsDescriptorBaseEntity())
            {
                // Add the Discriminator column, if it's not already there
                if (table.DiscriminatorColumn == null)
                {
                    table.DiscriminatorColumn = ColumnHelper.CreateDiscriminatorColumn(_databaseNamingConvention, _databaseTypeConvention);
                }
            }

            return table;
        }
    }
}
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace Nde.Adviser.Lds.SqlGeneration.Enhancers
{
    public class ContextSchoolYearTableEnhancer : ITableEnhancer
    {
        public Table EnhanceTable(Entity entity, Table table, dynamic tableProps)
        {
            if (entity.Properties.Any(p => p.PropertyName == "ContextSchoolYear"))
            {
                tableProps.HasSchoolYearContext = true;
            }
            else
            {
                tableProps.HasSchoolYearContext = false;
            }

            // if (entity.IsAggregateRoot 
            //     && entity.Identifier.Properties.Count() == 1
            //     && entity.Identifier.Properties.First().PropertyType.DbType == DbType.Int32
            //     && entity.AlternateIdentifiers.Any())
            // {
            //     table.PrimaryKeyColumns.First()
            // }
            return table;
        }
    }
}
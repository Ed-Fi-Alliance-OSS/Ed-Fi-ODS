using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.TemplateModelProviders;

namespace Nde.Adviser.Lds.SqlGeneration.Enhancers
{
    public class ContextSchoolYearColumnEnhancer : IColumnEnhancer
    {
        public Column EnhanceColumn(EntityProperty property, Column column, dynamic columnProps)
        {
            if (property.PropertyName == "ContextSchoolYear")
            {
                columnProps.IsSchoolYearContext = true;
            }

            return column;
        }
    }
}
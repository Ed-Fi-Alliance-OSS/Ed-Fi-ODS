using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Generator.Common.Database.TemplateModelProviders
{
    public interface IColumnEnhancer
    {
        Column EnhanceColumn(EntityProperty property, Column column, dynamic columnProps);
    }
}
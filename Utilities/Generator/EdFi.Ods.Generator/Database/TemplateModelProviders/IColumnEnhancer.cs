using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Generator.Database.TemplateModelProviders
{
    public interface IColumnEnhancer
    {
        Column EnhanceColumn(EntityProperty property, Column column, dynamic columnProps);
    }
}
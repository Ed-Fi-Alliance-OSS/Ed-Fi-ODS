using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Generator.Database.TemplateModelProviders
{
    public interface ITableEnhancer
    {
        Table EnhanceTable(Entity entity, Table table, dynamic tableProps);
    }
}
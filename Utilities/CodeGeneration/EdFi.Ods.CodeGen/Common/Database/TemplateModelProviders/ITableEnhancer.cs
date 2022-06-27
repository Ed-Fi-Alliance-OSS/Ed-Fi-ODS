using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Generator.Common.Database.TemplateModelProviders
{
    public interface ITableEnhancer
    {
        Table EnhanceTable(Entity entity, Table table, dynamic tableProps);
    }
}
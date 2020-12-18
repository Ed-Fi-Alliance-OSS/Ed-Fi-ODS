using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming
{
    public interface IDatabaseArtifactPhysicalNameProvider
    {
        string GetSchemaName(Entity entity);

        string GetTableName(Entity entity);

        string GetColumnName(EntityProperty property);
    }
}
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames
{
    /// <summary>
    /// Defines methods for obtaining database-specific physical names for various artifacts and identifiers. 
    /// </summary>
    public interface IPhysicalNamesProvider
    {
        string GetSchemaName(Entity entity);

        string GetTableName(Entity entity);

        string GetColumnName(EntityProperty property);
    }
}
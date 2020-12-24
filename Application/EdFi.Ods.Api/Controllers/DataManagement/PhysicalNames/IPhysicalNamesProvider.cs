using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames
{
    /// <summary>
    /// Defines methods for obtaining database-specific physical names for various artifacts and identifiers. 
    /// </summary>
    public interface IPhysicalNamesProvider
    {
        string Schema(Entity entity);

        string Table(Entity entity);

        /// <summary>
        /// Gets the fully-qualified table name consisting of the schema and table name.
        /// </summary>
        /// <param name="entity">The Entity for which the fully qualified name should be returned.</param>
        /// <returns>The fully qualified name.</returns>
        string FullName(Entity entity);

        string Column(EntityProperty property);

        string Identifier(string suggestedName);
    }
}
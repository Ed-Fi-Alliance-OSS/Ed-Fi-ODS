using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming
{
    public class SqlServerDatabaseArtifactPhysicalNameProvider : IDatabaseArtifactPhysicalNameProvider
    {
        public string GetSchemaName(Entity entity) => entity.Schema;

        public string GetTableName(Entity entity) => entity.FullName.Name;

        public string GetColumnName(EntityProperty property) => property.PropertyName;
    }
}
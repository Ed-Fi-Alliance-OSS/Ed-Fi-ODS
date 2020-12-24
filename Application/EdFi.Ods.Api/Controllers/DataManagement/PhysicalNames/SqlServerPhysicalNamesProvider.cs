using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames
{
    public class SqlServerPhysicalNamesProvider : IPhysicalNamesProvider
    {
        public string Schema(Entity entity) => entity.Schema;

        public string Table(Entity entity) => entity.Name;

        public string FullName(Entity entity) => entity.FullName.ToString();

        public string Column(EntityProperty property) => property.PropertyName;

        public string Identifier(string suggestedName) => suggestedName;
    }
}
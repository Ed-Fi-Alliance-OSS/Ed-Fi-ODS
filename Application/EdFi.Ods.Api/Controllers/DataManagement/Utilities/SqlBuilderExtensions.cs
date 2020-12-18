using System.Linq;
using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNaming;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Utilities
{
    public static class SqlBuilderExtensions
    {
        public static void OrderByPrimaryKey(
            this SqlBuilder sqlBuilder,
            Entity entity,
            IDatabaseArtifactPhysicalNameProvider physicalNameProvider)
        {
            // Sort results ascending by primary key
            foreach (var property in entity.Identifier.Properties)
            {
                sqlBuilder.OrderBy($"e.{physicalNameProvider.GetColumnName(property)}");
            }
        }
        
        public static void ApplyJoinToBaseEntity(this SqlBuilder sqlBuilder, Entity entity, IDatabaseArtifactPhysicalNameProvider physicalNameProvider)
        {
            string joinCriteria = string.Join(
                " AND ",
                entity.BaseAssociation.PropertyMappings.Select(
                    pm => $"e.{physicalNameProvider.GetColumnName(pm.ThisProperty)} = b.{physicalNameProvider.GetColumnName(pm.OtherProperty)}"));

            string join = $"{entity.BaseEntity.FullName} AS b ON {joinCriteria}";

            sqlBuilder.InnerJoin(@join);
        }
    }
}
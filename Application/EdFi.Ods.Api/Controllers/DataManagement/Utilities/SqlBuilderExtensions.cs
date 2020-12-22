using System.Linq;
using Dapper;
using EdFi.Ods.Api.Controllers.DataManagement.PhysicalNames;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Utilities
{
    public static class SqlBuilderExtensions
    {
        public static void OrderByPrimaryKey(
            this SqlBuilder sqlBuilder,
            Entity entity,
            IPhysicalNamesProvider physicalNamesProvider)
        {
            // Sort results ascending by primary key
            foreach (var property in entity.Identifier.Properties)
            {
                sqlBuilder.OrderBy($"e.{physicalNamesProvider.GetColumnName(property)}");
            }
        }
        
        public static void ApplyJoinToBaseEntity(this SqlBuilder sqlBuilder, Entity entity, IPhysicalNamesProvider physicalNamesProvider)
        {
            string joinCriteria = string.Join(
                " AND ",
                entity.BaseAssociation.PropertyMappings.Select(
                    pm => $"e.{physicalNamesProvider.GetColumnName(pm.ThisProperty)} = b.{physicalNamesProvider.GetColumnName(pm.OtherProperty)}"));

            string join = $"{entity.BaseEntity.FullName} AS b ON {joinCriteria}";

            sqlBuilder.InnerJoin(@join);
        }
    }
}
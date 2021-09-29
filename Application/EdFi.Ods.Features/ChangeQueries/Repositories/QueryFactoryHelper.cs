using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.NamingConventions;
using SqlKata;

namespace EdFi.Ods.Features.ChangeQueries.Repositories
{
    public static class QueryFactoryHelper
    {
        public static void ApplyDiscriminatorCriteriaForDerivedEntities(
            Query query,
            Entity entity,
            IDatabaseNamingConvention namingConvention)
        {
            // Add discriminator criteria, for derived types with a Discriminator on the base type only
            if (entity.IsDerived)
            {
                query.Where($"{ChangeQueriesDatabaseConstants.TrackedChangesAlias}.{namingConvention.ColumnName("Discriminator")}", entity.FullName.ToString());
            }
        }
        
        public static string[] IdentifyingColumns(
            QueryProjection[] identifierProjections,
            string oldColumnAlias = ChangeQueriesDatabaseConstants.TrackedChangesAlias, 
            string newColumnAlias = ChangeQueriesDatabaseConstants.TrackedChangesAlias,
            ColumnGroups columnGroups = ColumnGroups.OldValue | ColumnGroups.NewValue)
        {
            string[] selectColumns = identifierProjections.SelectMany(x => x.SelectColumns)
                .Where(sc => (sc.ColumnGroup & columnGroups) != 0)
                .Select(sc => $"{(sc.ColumnGroup == ColumnGroups.OldValue ? oldColumnAlias : newColumnAlias)}.{sc.ColumnName}")
                .ToArray();

            return selectColumns;
        }
        
        public static Query CreateBaseTrackedChangesQuery(IDatabaseNamingConvention namingConvention, Entity entity)
        {
            var (changeTableSchema, changeTableName) = entity.IsDerived
                ? (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + namingConvention.Schema(entity.BaseEntity),
                    namingConvention.TableName(entity.BaseEntity))
                : (ChangeQueriesDatabaseConstants.TrackedChangesSchemaPrefix + namingConvention.Schema(entity),
                    namingConvention.TableName(entity));

            var templateQuery =
                new Query($"{changeTableSchema}.{changeTableName} AS {ChangeQueriesDatabaseConstants.TrackedChangesAlias}");

            return templateQuery;
        }
    }
}
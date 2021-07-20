using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Database.DataTypes;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers
{
    public static class ChangeQueriesHelpers
    {
        public static IEnumerable<EntityProperty> GetChangeQueriesPropertiesForColumns(Entity e)
        {
            return e.Identifier.Properties
                .Union(e.AlternateIdentifiers.SelectMany(i => i.Properties.Where(p => !IsResourceIdentifier(p))))
                .Union(e.BaseEntity?.AlternateIdentifiers.SelectMany(i => i.Properties.Where(p => !IsResourceIdentifier(p))) 
                    ?? Enumerable.Empty<EntityProperty>());
    
            bool IsResourceIdentifier(EntityProperty property) => property.PropertyName == "Id";
        }
    }
    
    public static class PropertyExtensions
    {
        public static IEnumerable<SimpleColumn> ExpandForApiResourceData(this EntityProperty property, int joinAliasIndex, 
            IDatabaseNamingConvention databaseNamingConvention,
            IDatabaseTypeTranslator databaseTypeTranslator)
        {
            yield return new SimpleColumn(
                databaseNamingConvention.ColumnName(property.PropertyName), 
                databaseTypeTranslator.GetSqlType(property.PropertyType));
            
            if (property.IsLookup)
            {
                yield return new SimpleColumn(
                    databaseNamingConvention.ColumnName(property.PropertyName.ReplaceSuffix("Id", "Namespace")),
                    databaseTypeTranslator.GetSqlType(property.LookupEntity.BaseEntity.PropertyByName["Namespace"].PropertyType),
                    $"j{joinAliasIndex}.{databaseNamingConvention.ColumnName(property.LookupEntity.BaseEntity.PropertyByName["Namespace"].PropertyName)}");

                yield return new SimpleColumn(
                    databaseNamingConvention.ColumnName(property.PropertyName.ReplaceSuffix("Id", "CodeValue")),
                    databaseTypeTranslator.GetSqlType(property.LookupEntity.BaseEntity.PropertyByName["CodeValue"].PropertyType),
                    $"j{joinAliasIndex}.{databaseNamingConvention.ColumnName(property.LookupEntity.BaseEntity.PropertyByName["CodeValue"].PropertyName)}");
            }
            else if (property.IsUSIUsage())
            {
                var personEntity = property.PersonEntity();
                
                yield return new SimpleColumn(
                    databaseNamingConvention.ColumnName(property.PropertyName.ReplaceSuffix("USI", "UniqueId")),
                    databaseTypeTranslator.GetSqlType(personEntity.PropertyByName[personEntity.Name + "UniqueId"].PropertyType), 
                    $"j{joinAliasIndex}.{databaseNamingConvention.ColumnName(personEntity.PropertyByName[personEntity.Name + "UniqueId"].PropertyName)}");
            }
        }
        
        public static IEnumerable<SingleColumnJoin> JoinForApiResourceData(this EntityProperty property, int joinAliasIndex,
            IDatabaseNamingConvention databaseNamingConvention)
        {
            if (property.IsLookup)
            {
                yield return new SingleColumnJoin(
                    property.LookupEntity.BaseEntity.Schema,
                    databaseNamingConvention.TableName(property.LookupEntity.BaseEntity),
                    $"j{joinAliasIndex}",
                    property.PropertyType.IsNullable,
                    databaseNamingConvention.ColumnName(property),
                    databaseNamingConvention.ColumnName(property.LookupEntity.BaseAssociation.PropertyMappings.Single().OtherProperty)
                );
            }
            else if (property.IsUSIUsage())
            {
                var personEntity = property.PersonEntity();
                
                yield return new SingleColumnJoin(
                    personEntity.Schema, 
                    databaseNamingConvention.TableName(personEntity),
                    $"j{joinAliasIndex}",
                    property.PropertyType.IsNullable,
                    databaseNamingConvention.ColumnName(property),
                    databaseNamingConvention.ColumnName(personEntity.Identifier.Properties.Single())
                );
            }
        }
    }
}
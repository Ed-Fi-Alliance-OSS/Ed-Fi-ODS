using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

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
}
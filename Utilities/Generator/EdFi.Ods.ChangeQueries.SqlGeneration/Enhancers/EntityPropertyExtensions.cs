using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Generator.Extensions;

namespace EdFi.Ods.ChangeQueries.SqlGeneration.Enhancers
{
    public static class EntityPropertyExtensions
    {
        /// <summary>
        /// Indicates whether the entity property represent a <em>usage</em> of an USI (internal surrogate id for a person)
        /// rather than the definition of it (on a the associated Person entity).
        /// </summary>
        /// <param name="entityProperty">The entity property to be evaluated.</param>
        /// <returns><b>true</b> is the property is a usage (downstream foreign key of the USI definition); otherwise <b>false</b>.</returns>
        public static bool IsUSIUsage(this EntityProperty entityProperty)
        {
            return
                entityProperty.PropertyName.EndsWith("USI")
                && entityProperty.IncomingAssociations.Any()
                && entityProperty.Entity.Name != entityProperty.PropertyName.TrimSuffix("USI");
        }
        public static Entity PersonEntity(this EntityProperty entityProperty)
        {
            if (!IsUSIUsage(entityProperty))
                return null;
            var currentProperty = entityProperty;
            while (currentProperty.IncomingAssociations.Any())
            {
                currentProperty = currentProperty.IncomingAssociations.First()
                    .PropertyMappingByThisName[currentProperty.PropertyName]
                    .OtherProperty;
            }
            return currentProperty.Entity;
        }
    }
}
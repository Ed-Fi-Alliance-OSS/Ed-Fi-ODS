using System;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Generator.Database.Conventions
{
    public static class ColumnConventions
    {
        public static bool IsBoilerplate(this EntityProperty property)
        {
            return IsBoilerplate(property.PropertyName);
        }
        
        public static bool IsBoilerplate(this string propertyName)
        {
            return (Enum.TryParse(typeof(BoilerplateColumn), propertyName, out object value));
        }

        public enum BoilerplateColumn
        {
            CreateDate,
            LastModifiedDate,
            Id,
        }
    }
}
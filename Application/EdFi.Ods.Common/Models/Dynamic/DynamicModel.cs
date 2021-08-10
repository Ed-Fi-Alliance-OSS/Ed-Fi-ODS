using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace EdFi.Ods.Common.Models.Dynamic
{
    public class DynamicModel : DynamicObject, IDynamicModel
    {
        private readonly IDictionary<string, object> _properties
            = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        IDictionary<string, object> IDynamicModel.DynamicProperties
        {
            get => _properties;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder.Name == "DynamicProperties")
                return false;
            
            var propertyInfo = GetType().GetProperty(binder.Name);

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(this, value);

                return true;
            }

            _properties[binder.Name] = value;

            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            
            if (binder.Name == "DynamicProperties")
                return false;
            
            var propertyInfo = GetType().GetProperty(binder.Name);

            if (propertyInfo != null)
            {
                result = propertyInfo.GetValue(this);

                return true;
            }

            if (!_properties.TryGetValue(binder.Name, out result))
            {
                // Default the value to null
                result = null;
            }
            
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Select(x => x.Name)
                .Except(new [] {"DynamicProperties"})
                .Concat(_properties.Keys);
        }
    }
}
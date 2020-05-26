// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Create a UniqueId
    /// </summary>
    public class UniqueIdPropertyBuilder : BaseBuilder
    {
        public UniqueIdPropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType != typeof(string) || !propertyInfo.Name.EndsWith("UniqueId"))
            {
                return false;
            }

            propertyInfo.SetValue(obj, BuildRandomString(9));
            return true;
        }
    }
}

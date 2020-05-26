// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     if a type is nullable, skip it.
    /// </summary>
    public class SimplePropertyBuilder : BaseBuilder
    {
        public SimplePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (IsTypeMatch<bool>(propertyInfo))
            {
                propertyInfo.SetValue(obj, false);
                return true;
            }

            if (IsTypeMatch<int>(propertyInfo) || IsTypeMatch<long>(propertyInfo))
            {
                if (IsRequired(propertyInfo))
                {
                    propertyInfo.SetValue(obj, Random.Next(1, 100));
                }

                return true;
            }

            if (IsTypeMatch<double>(propertyInfo))
            {
                if (IsRequired(propertyInfo))
                {
                    propertyInfo.SetValue(obj, Random.NextDouble() * 10.0);
                }

                return true;
            }

            return false;
        }
    }
}

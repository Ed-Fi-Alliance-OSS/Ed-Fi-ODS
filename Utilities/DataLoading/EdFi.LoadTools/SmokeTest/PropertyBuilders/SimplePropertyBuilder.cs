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
        private int _counter = 50; // Start from 50 to not collide with existing EdOrgIds if running over the populated template

        public SimplePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (IsTypeMatch<bool>(propertyInfo))
            {
                propertyInfo.SetValue(obj, false);
                return true;
            }

            if (IsTypeMatch<int>(propertyInfo) || IsTypeMatch<long>(propertyInfo) || IsTypeMatch<double>(propertyInfo))
            {
                if (IsRequired(propertyInfo))
                {
                    propertyInfo.SetValue(obj, _counter++);
                }

                return true;
            }

            return false;
        }
    }
}

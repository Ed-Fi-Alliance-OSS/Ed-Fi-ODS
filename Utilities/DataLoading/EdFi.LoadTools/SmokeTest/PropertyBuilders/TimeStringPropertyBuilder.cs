// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    /// <summary>
    ///     Any string ending in "Time" is expected to be foramtted HH:mm:ss
    /// </summary>
    public class TimeStringPropertyBuilder : StringPropertyBuilder
    {
        public TimeStringPropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        protected override string RandomTestString => DateTime.Now.AddMilliseconds(-Random.Next()).ToString("HH:mm:ss");

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType != typeof(string) || !propertyInfo.Name.EndsWith("Time"))
            {
                return false;
            }

            return base.BuildProperty(obj, propertyInfo);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class DateTimePropertyBuilder : BaseBuilder
    {
        private readonly List<string> PastDateNames = new List<string>
        {
            "birthDate",
            "beginDate"
        };

        public DateTimePropertyBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (!IsTypeMatch<DateTime>(propertyInfo))
            {
                return false;
            }

            if (IsRequired(propertyInfo))
            {
                var randomDate = IsPastDate(propertyInfo)
                    ? DateTime.Today.AddDays(-Random.Next(5 * 365, 99 * 365))
                    : DateTime.Today.AddDays(Random.Next(100));

                propertyInfo.SetValue(obj, randomDate);
            }

            return true;
        }

        private bool IsPastDate(PropertyInfo propertyInfo)
        {
            return PastDateNames.Contains(propertyInfo.Name, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Common;
using EdFi.Ods.Common.Inflection;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class EducationOrganizationAddressBuilder : BaseBuilder
    {
        private readonly List<string> _requiredProperties = new List<string>
        {
            "City",
            "PostalCode",
            "StreetNumberName"
        };

        public EducationOrganizationAddressBuilder(IPropertyInfoMetadataLookup metadataLookup)
            : base(metadataLookup) { }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            string parentTypeName = Inflector.MakeInitialLowerCase(propertyInfo.DeclaringType?.Name);

            if (obj.GetType().Name.Contains("EducationOrganizationAddress") &&  _requiredProperties.Any(x => x.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                propertyInfo.SetValue(obj, RandomTestString);
                return true;
            }

            return false;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class EducationOrganizationIdBuilder : BaseBuilder
    {
        private readonly IReadOnlyDictionary<string, int> _educationOrganizationIdOverrides;

        public EducationOrganizationIdBuilder(
            IPropertyInfoMetadataLookup metadataLookup,
            IDestructiveTestConfiguration configuration)
            : base(metadataLookup)
        {
            _educationOrganizationIdOverrides = new Dictionary<string, int>(
                configuration.EducationOrganizationIdOverrides, StringComparer.OrdinalIgnoreCase);
        }

        public override bool BuildProperty(object obj, PropertyInfo propertyInfo)
        {
            if (!_educationOrganizationIdOverrides.ContainsKey(propertyInfo.Name))
            {
                // EdOrg ids that aren't relevant for authorization are initialized in the SimplePropertyBuilder
                return false;
            }

            propertyInfo.SetValue(obj, _educationOrganizationIdOverrides[propertyInfo.Name]);
            return true;
        }
    }
}

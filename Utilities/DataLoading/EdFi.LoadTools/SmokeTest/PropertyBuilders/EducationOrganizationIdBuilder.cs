// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.LoadTools.Engine;

namespace EdFi.LoadTools.SmokeTest.PropertyBuilders
{
    public class EducationOrganizationIdBuilder : BaseBuilder
    {
        // EducationOrganization identifier names (and their subtype-specific variants) recognized so that
        // non-overridden EdOrg ids are generated from an EdOrg-safe range instead of the generic numeric
        // fallback. Matched as suffixes (case-insensitive) so prefixed forms such as ResponsibilitySchoolId
        // are also covered.
        private static readonly string[] EducationOrganizationIdSuffixes =
        {
            "EducationOrganizationId",
            "StateEducationAgencyId",
            "LocalEducationAgencyId",
            "EducationServiceCenterId",
            "SchoolId",
            "CommunityProviderId",
            "CommunityOrganizationId",
            "EducationOrganizationNetworkId",
            "PostSecondaryInstitutionId",
            "OrganizationDepartmentId"
        };

        private readonly IReadOnlyDictionary<string, int> _educationOrganizationIdOverrides;
        private int _educationOrganizationFallbackValue =
            DestructiveTestConfigurationDefaults.EducationOrganizationFallbackStart;

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
            if (_educationOrganizationIdOverrides.ContainsKey(propertyInfo.Name))
            {
                propertyInfo.SetValue(obj, _educationOrganizationIdOverrides[propertyInfo.Name]);
                return true;
            }

            // Non-overridden EdOrg ids are not relevant for authorization, but they still must avoid
            // colliding with EdOrg ids that already exist on a populated template. Generate them from the
            // dedicated EdOrg-safe range here rather than letting them fall through to the generic
            // 1..DefaultNumericFallbackMax fallback in SimplePropertyBuilder, which is sized for capped decimals.
            // When OpenAPI actually publishes numeric bounds for the id, defer to SimplePropertyBuilder so the
            // published bounds are honored.
            if (IsRequired(propertyInfo)
                && IsEducationOrganizationId(propertyInfo.Name)
                && !HasPublishedNumericBounds(propertyInfo)
                && (IsTypeMatch<int>(propertyInfo) || IsTypeMatch<long>(propertyInfo) || IsTypeMatch<double>(propertyInfo)))
            {
                var targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                propertyInfo.SetValue(obj, Convert.ChangeType(_educationOrganizationFallbackValue++, targetType));
                return true;
            }

            return false;
        }

        private static bool IsEducationOrganizationId(string propertyName)
            => EducationOrganizationIdSuffixes.Any(
                suffix => propertyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
    }
}

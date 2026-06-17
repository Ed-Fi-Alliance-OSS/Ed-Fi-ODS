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
                // Convert the configured (int) override to the property's underlying numeric type so nullable
                // long/double EdOrg ids accept it instead of throwing on the boxed int, matching the
                // non-overridden path below.
                var overrideTargetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                propertyInfo.SetValue(
                    obj, Convert.ChangeType(_educationOrganizationIdOverrides[propertyInfo.Name], overrideTargetType));
                return true;
            }

            // Non-overridden EdOrg ids are not relevant for authorization, but they still must avoid
            // colliding with EdOrg ids that already exist on a populated template. Generate them from the
            // dedicated EdOrg-safe range here rather than letting them fall through to the generic
            // 1..DefaultNumericFallbackMax fallback in SimplePropertyBuilder, which is sized for capped decimals.
            if (IsRequired(propertyInfo)
                && IsEducationOrganizationId(propertyInfo.Name)
                && (IsTypeMatch<int>(propertyInfo) || IsTypeMatch<long>(propertyInfo) || IsTypeMatch<double>(propertyInfo)))
            {
                // Defer to SimplePropertyBuilder only when OpenAPI publishes a parseable maximum (a bounded or
                // max-only range) it can actually honor. A min-only bound, or an unparseable Minimum/Maximum
                // string, leaves SimplePropertyBuilder with the generic 1..DefaultNumericFallbackMax range, which
                // would reintroduce the populated-template collision risk for EdOrg ids, so those cases stay here.
                if (HasParseableMaximum(propertyInfo))
                {
                    return false;
                }

                var targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var value = _educationOrganizationFallbackValue++;

                // Honor a published, parseable minimum while keeping values monotonic within the EdOrg-safe range.
                if (TryGetParseableMinimum(propertyInfo, out var minimum))
                {
                    value = Math.Max(value, minimum);
                }

                propertyInfo.SetValue(obj, Convert.ChangeType(value, targetType));
                return true;
            }

            return false;
        }

        private static bool IsEducationOrganizationId(string propertyName)
            => EducationOrganizationIdSuffixes.Any(
                suffix => propertyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
    }
}

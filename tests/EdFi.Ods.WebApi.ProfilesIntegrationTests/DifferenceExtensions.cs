// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using KellermanSoftware.CompareNetObjects;

namespace EdFi.Ods.WebApi.ProfileSpecFlowTests
{
    public static class DifferenceExtensions
    {
        public static List<Difference> RelevantDifferences(this ComparisonResult comparisonResult)
            => comparisonResult.Differences.Where(d => d.IsRelevantForEntityComparison()).ToList();

        public static List<string> RelevantPropertyDifferences(this ComparisonResult comparisonResult)
            => comparisonResult.RelevantDifferences()
                .Select(x => x.PropertyName.TrimStart('.').Split('[')[0])

                // since we are not managing the descriptor ids we can exclude them
                .Where(x => !x.EndsWithIgnoreCase("DescriptorId"))
                .Distinct()
                .ToList();

        public static List<string> RelevantCollectionPropertyDifferences(this ComparisonResult comparisonResult)
            => comparisonResult.RelevantDifferences()
                .Select(x => x.PropertyName.Split('.').Last())

                // since we are not managing the descriptor ids we can exclude them
                .Where(x => !x.EndsWithIgnoreCase("DescriptorId"))
                .Distinct()
                .ToList();

        public static bool IsRelevantForEntityComparison(this string propertyName)
            => !IsReferenceDataRelated(propertyName)
               && !IsExtensionRelated(propertyName)
               && !IsTechnicalImplementationProperty(propertyName)
               && !IsResourceIdentifier(propertyName);

        public static bool IsRelevantForEntityComparison(this PropertyInfo p) => p.Name.IsRelevantForEntityComparison();

        public static bool IsRelevantForEntityComparison(this Difference d)
            => !IsReferenceDataRelated(d)
               && !IsExtensionRelated(d.PropertyName)
               && !IsTechnicalImplementationProperty(d.PropertyName)
               && !IsResourceIdentifier(d.PropertyName);

        private static bool IsResourceIdentifier(string name) => name.EqualsIgnoreCase("Id");

        private static bool IsTechnicalImplementationProperty(string name)
            => new[]
            {
                "CreateDate",
                "LastModifiedDate",
                "ChangeVersion",
                "ETag",
                "CreatedByOwnershipTokenId"
            }.Contains(name) || name.EndsWith("PersistentList");

        private static bool IsExtensionRelated(string propertyName)
            => propertyName == "Extensions"
               || propertyName == "AggregateExtensions"
               || propertyName == "_ext";

        private static bool IsReferenceDataRelated(string name) => name.EndsWith("ReferenceData");

        private static bool IsReferenceDataRelated(Difference d)
            => IsReferenceDataRelated(d.Object1TypeName)
               || IsReferenceDataRelated(d.PropertyName)
               || IsReferenceDataRelated(d.ParentPropertyName);
    }
}

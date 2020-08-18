// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Extensions;
using KellermanSoftware.CompareNetObjects;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public static class DifferenceExtensions
    {
        public static List<Difference> RelevantEntityDifferences(this ComparisonResult comparisonResult)
        {
            return comparisonResult.Differences.Where(d => d.IsRelevantForEntityComparison()).ToList();
        }

        public static bool IsRelevantForEntityComparison(this string propertyName)
        {
            return
                !IsReferenceDataRelated(propertyName)
                && !IsExtensionRelated(propertyName)
                && !IsTechnicalImplementationProperty(propertyName)
                && !IsResourceIdentifier(propertyName);
        }

        public static bool IsRelevantForEntityComparison(this PropertyInfo p)
        {
            return p.Name.IsRelevantForEntityComparison();
        }

        public static bool IsRelevantForEntityComparison(this Difference d)
        {
            return !IsReferenceDataRelated(d)
                   && !IsExtensionRelated(d.PropertyName)
                   && !IsTechnicalImplementationProperty(d.PropertyName)
                   && !IsResourceIdentifier(d.PropertyName);
        }

        private static bool IsResourceIdentifier(string name)
        {
            return name.EqualsIgnoreCase("Id");
        }

        private static bool IsTechnicalImplementationProperty(string name)
        {
            return (new[]
            {
                "CreateDate",
                "LastModifiedDate",
                "ChangeVersion",
                "ETag",
                "CreatedByOwnershipTokenId"
            }).Contains(name) || name.EndsWith("PersistentList");
        }

        private static bool IsExtensionRelated(string propertyName)
        {
            return (propertyName == "Extensions"
                    || propertyName == "AggregateExtensions"
                    || propertyName == "_ext");
        }

        private static bool IsReferenceDataRelated(string name)
        {
            return name.EndsWith("ReferenceData");
        }

        private static bool IsReferenceDataRelated(Difference d)
        {
            return
                IsReferenceDataRelated(d.Object1TypeName)
                || IsReferenceDataRelated(d.PropertyName)
                || IsReferenceDataRelated(d.ParentPropertyName);
        }
    }
}
#endif
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Features.Composites
{
    public static class CompositeDefinitionHelper
    {
        public const string BaseResource = "BaseResource";
        public const string LogicalSchema = "logicalSchema";
        public const string ReferencedResource = "ReferencedResource";
        public const string EmbeddedObject = "EmbeddedObject";
        public const string Collection = "Collection";
        public const string LinkedCollection = "LinkedCollection";

        public const string HierarchicalReferenceName = "hierarchicalReferenceName";
        public const string Name = "name";
        public const string Flatten = "flatten";
        public const string IncludeResourceSubtype = "includeResourceSubtype";
        public const string UseHierarchy = "useHierarchy";
        public const string UseReferencedHierarchy = "useReferencedHierarchy";
        public const string Property = "Property";
        public const string DisplayName = "displayName";

        public const string AliasPrefix = "comp_";
        public const string Fields = "fields";
        public const string NamespaceMarker = "__Namespace";
        public const string Marker = "__";
        public const string HierarchyMarker = "H_";
        public const string PassThroughMarker = "__PassThrough";
        public const string UniqueId = "UniqueId";

        public static bool ShouldFlatten(XElement childElement)
        {
            Preconditions.ThrowIfNull(childElement, nameof(childElement));

            bool.TryParse((string) childElement.AttributeValue(Flatten), out bool result);

            return result;
        }

        public static IReadOnlyDictionary<string, ResourceProperty> ValidPropertiesByName(
            CompositeDefinitionProcessorContext processorContext,
            IReadOnlyDictionary<string, ResourceProperty> propertiesByName)
        {
            Preconditions.ThrowIfNull(processorContext, nameof(processorContext));
            Preconditions.ThrowIfNull(propertiesByName, nameof(propertiesByName));

            return processorContext.ShouldIncludeResourceSubtype()
                ? propertiesByName
                 .Where(p => p.Value.IsIdentifying)
                 .ToDictionary(k => k.Key, v => v.Value)
                : propertiesByName;
        }

        public static List<PropertyNameWithDisplayName> GetValidProperties(
            List<PropertyNameWithDisplayName> selectedElements,
            IReadOnlyDictionary<string, ResourceProperty> validPropertiesByName)
        {
            Preconditions.ThrowIfNull(selectedElements, nameof(selectedElements));
            Preconditions.ThrowIfNull(validPropertiesByName, nameof(validPropertiesByName));

            return selectedElements
                  .Where(x => validPropertiesByName.ContainsKey(x.Name))
                  .ToList();
        }

        public static List<PropertyNameWithDisplayName> CreateSelectedElements(IEnumerable<XElement> propertyElements)
        {
            Preconditions.ThrowIfNull(propertyElements, nameof(propertyElements));

            return propertyElements.Select(
                                        e =>
                                        {
                                            string name = e.AttributeValue(Name);
                                            string displayName = e.AttributeValue(DisplayName);

                                            return new PropertyNameWithDisplayName(name, displayName);
                                        }
                                    )
                                   .ToList();
        }
    }
}

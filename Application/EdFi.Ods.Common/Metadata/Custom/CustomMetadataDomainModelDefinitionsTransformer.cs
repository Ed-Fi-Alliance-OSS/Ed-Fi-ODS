// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Definitions.Transformers;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Metadata.Custom
{
    /// <summary>
    /// A transformer that adjusts domain model definitions by applying custom metadata provided
    /// by one or more custom metadata providers.
    /// </summary>
    public class CustomMetadataDomainModelDefinitionsTransformer : IDomainModelDefinitionsTransformer
    {
        // Array of data providers that provide custom metadata for transforming domain model definitions.
        private readonly IDomainModelCustomMetadataProvider[] _domainModelCustomMetadataProviders;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMetadataDomainModelDefinitionsTransformer"/> class using the supplied custom metadata providers.
        /// </summary>
        /// <param name="domainModelCustomMetadataProviders">
        /// An array of providers that supply custom metadata for domain model transformation.
        /// </param>
        public CustomMetadataDomainModelDefinitionsTransformer(IDomainModelCustomMetadataProvider[] domainModelCustomMetadataProviders)
        {
            _domainModelCustomMetadataProviders = domainModelCustomMetadataProviders;
        }

        /// <summary>
        /// Transforms the provided domain model definitions by applying custom metadata such as date range validations.
        /// </summary>
        /// <param name="domainModelDefinitions">The original domain model definitions to be transformed.</param>
        /// <returns>
        /// An enumerable collection of transformed domain model definitions with custom metadata applied.
        /// </returns>
        public IEnumerable<DomainModelDefinitions> TransformDefinitions(IEnumerable<DomainModelDefinitions> domainModelDefinitions)
        {
            // Create a dictionary of date range validations keyed by property identifier
            var dateRangeByProperty = GetCustomMetadata()
                .SelectMany(md => md.DateRangeValidations)
                .ToDictionary(
                    m => string.Join(".", m.Schema, m.EntityName, m.PropertyName), // Composite key: Schema.Entity.Property
                    m => (m.MinValue, m.MaxValue), // Min and Max value ranges
                    StringComparer.OrdinalIgnoreCase);

            // If custom date range validations are present, apply them to the domain model definitions
            if (dateRangeByProperty.Any())
            {
                foreach (var domainModelDefinition in domainModelDefinitions)
                {
                    foreach (var entityDefinition in domainModelDefinition.EntityDefinitions)
                    {
                        foreach (dynamic propertyDefinition in entityDefinition.LocallyDefinedProperties)
                        {
                            // Build the unique key for the property
                            string key = string.Join(".", entityDefinition.Schema, entityDefinition.Name, propertyDefinition.PropertyName);

                            // Apply custom date range if a match is found
                            if (dateRangeByProperty.TryGetValue(key, out var range))
                            {
                                propertyDefinition.MinValueDate = range.MinValue;
                                propertyDefinition.MaxValueDate = range.MaxValue;
                            }
                        }
                    }

                    // Process all inheritance relationships to ensure the association properties also have the metadata applied
                    foreach (var associationDefinition in domainModelDefinition.AssociationDefinitions.Where(d => d.Cardinality == Cardinality.OneToOneInheritance))
                    {
                        associationDefinition.PrimaryEntityProperties.ForEach((pd, i) =>
                        {
                            string baseRangeMetadataKey = GetRangeMetadataKey(associationDefinition.PrimaryEntityFullName, pd);

                            dynamic basePropertyDefinition = pd;
                            dynamic derivedPropertyDefinition = associationDefinition.SecondaryEntityProperties[i];

                            // Apply custom date range to base and inherited properties if a match is found
                            if (dateRangeByProperty.TryGetValue(baseRangeMetadataKey, out var baseRange))
                            {
                                basePropertyDefinition.MinValueDate = baseRange.MinValue;
                                basePropertyDefinition.MaxValueDate = baseRange.MaxValue;
                                derivedPropertyDefinition.MinValueDate = baseRange.MinValue;
                                derivedPropertyDefinition.MaxValueDate = baseRange.MaxValue;
                            }

                            string derivedRangeMetadataKey = GetRangeMetadataKey(associationDefinition.SecondaryEntityFullName, pd);

                            // Override inherited range validation metadata with explicitly assigned metadata on the derived property
                            if (dateRangeByProperty.TryGetValue(derivedRangeMetadataKey, out var derivedRange))
                            {
                                derivedPropertyDefinition.MinValueDate = derivedRange.MinValue;
                                derivedPropertyDefinition.MaxValueDate = derivedRange.MaxValue;
                            }
                        });

                        string GetRangeMetadataKey(FullName entityName, dynamic propertyDefinition)
                        {
                            return string.Join(".", entityName, propertyDefinition.PropertyName);
                        }
                    }
                }
            }

            return domainModelDefinitions;

            // Helper method to retrieve custom metadata from all registered providers
            IEnumerable<DomainModelCustomMetadata> GetCustomMetadata()
            {
                foreach (var customMetadataProvider in _domainModelCustomMetadataProviders)
                {
                    // Try to load custom metadata from the current provider
                    // If successful, yield return the custom metadata for processing
                    if (customMetadataProvider.TryLoadCustomMetadata(out var customMetadata))
                    {
                        yield return customMetadata;
                    }
                }
            }
        }
    }
}
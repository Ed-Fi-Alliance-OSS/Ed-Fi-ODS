// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Features.OpenApiMetadata.Strategies
{
    /// <summary>
    /// Provides domain-based filtering logic for OpenAPI metadata components.
    /// </summary>
    public class OpenApiMetadataDomainFilter : IOpenApiMetadataDomainFilter
    {
        private readonly HashSet<string> _excludedDomains;
        private readonly bool _hasExclusions;

        public OpenApiMetadataDomainFilter(ApiSettings apiSettings)
        {
            if (apiSettings?.DomainsExcludedFromOpenApi == null || string.IsNullOrWhiteSpace(apiSettings.DomainsExcludedFromOpenApi))
            {
                _excludedDomains = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                _hasExclusions = false;
            }
            else
            {
                var excluded = apiSettings.DomainsExcludedFromOpenApi
                    .Split(',')
                    .Where(d => !string.IsNullOrWhiteSpace(d))
                    .Select(d => d.Trim())
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                _excludedDomains = excluded;
                _hasExclusions = excluded.Count > 0;
            }
        }

        /// <summary>
        /// Determines if an entity should be excluded based on its domains.
        /// Returns true if the entity should be excluded from OpenAPI metadata.
        /// </summary>
        /// <param name="entity">The entity to check for domain-based exclusion.</param>
        /// <returns>True if the entity should be excluded; otherwise, false.</returns>
        public bool ShouldExcludeByDomain(Entity entity)
        {
            if (!_hasExclusions)
                return false;

            if (entity == null)
                return false;

            var domains = entity.Domains;

            if (domains == null || domains.Length == 0)
            {
                return false; // If no domain metadata, always include
            }

            // Exclude only if ALL domains are in the exclusion set
            return domains.All(d => _excludedDomains.Contains(d));
        }

        public bool HasExclusions => _hasExclusions;

        public IReadOnlySet<string> ExcludedDomains => _excludedDomains;
    }
}

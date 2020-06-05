// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Security.AuthorizationStrategies
{
    /// <summary>
    /// Implements the <see cref="IResourceAuthorizationMetadataProvider"/> interface using the security repository 
    /// for access to the authorization metadata.
    /// </summary>
    public class ResourceAuthorizationMetadataProvider : IResourceAuthorizationMetadataProvider
    {
        private readonly ISecurityRepository _securityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAuthorizationMetadataProvider"/> class.
        /// </summary>
        /// <param name="securityRepository"></param>
        public ResourceAuthorizationMetadataProvider(
            ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        /// <summary>
        /// Gets the lineage of all resource claims (going up the resource claims taxonomy) that can be used to authorize the 
        /// request for specified resource and action, including the explicitly assigned authorization strategy (if applicable).
        /// </summary>
        /// <param name="resourceClaimUri">The URI representation of the resource claim associated with the request.</param>
        /// <param name="action">The action associated with the request.</param>
        /// <returns>The lineage of resource claims.</returns>
        public IEnumerable<ResourceClaimAuthorizationMetadata> GetResourceClaimAuthorizationMetadata(
            string resourceClaimUri,
            string action)
        {
            Preconditions.ThrowIfNull(resourceClaimUri, nameof(resourceClaimUri));
            Preconditions.ThrowIfNull(action, nameof(action));

            List<string> resourceClaimNameLineage;

            try
            {
                // hit the ResourceClaimAuthorizationStrategy table
                resourceClaimNameLineage = _securityRepository.GetResourceClaimLineage(resourceClaimUri).ToList();
            }
            catch (InvalidOperationException ex)
            {
                // This occurs when there is no authorization metadata configured.
                // Translate it to an exception that will result in a 500 status with message.
                throw new ApiSecurityConfigurationException(ex.Message);
            }

            if (!resourceClaimNameLineage.Any())
            {
                return Enumerable.Empty<ResourceClaimAuthorizationMetadata>();
            }
            
            var resourceClaimLineageWithMetadata =
                _securityRepository
                    .GetResourceClaimLineageMetadata(resourceClaimUri, action)
                    .ToList();

            var resourceClaimsLineage =
                from c in resourceClaimNameLineage
                select new ResourceClaimAuthorizationMetadata
                {
                    ClaimName = c,
                    AuthorizationStrategy =
                        resourceClaimLineageWithMetadata
                            .Where(x => c.EqualsIgnoreCase(x.ResourceClaim.ClaimName))
                            .Select(x => x.AuthorizationStrategy.AuthorizationStrategyName)
                            .SingleOrDefault()
                };

            return resourceClaimsLineage;
        }
    }
}

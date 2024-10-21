// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies
{
    /// <summary>
    /// Implements the <see cref="IResourceClaimAuthorizationMetadataLineageProvider"/> interface using the security repository
    /// for access to the authorization metadata.
    /// </summary>
    public class ResourceClaimAuthorizationMetadataLineageProvider : IResourceClaimAuthorizationMetadataLineageProvider
    {
        private readonly ISecurityRepository _securityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceClaimAuthorizationMetadataLineageProvider"/> class.
        /// </summary>
        /// <param name="securityRepository"></param>
        public ResourceClaimAuthorizationMetadataLineageProvider(
            ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        /// <inheritdoc cref="IResourceClaimAuthorizationMetadataLineageProvider.GetAuthorizationLineage" />
        public IEnumerable<DefaultResourceClaimMetadata> GetAuthorizationLineage(
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
                throw new SecurityConfigurationException(
                    "A problem with the security configuration has been detected. The request cannot be authorized.",
                    ex.Message); // Multiple resource claims with the same name found in security metadata
            }

            if (!resourceClaimNameLineage.Any())
            {
                return Enumerable.Empty<DefaultResourceClaimMetadata>();
            }

            var resourceClaimLineageWithMetadata =
                _securityRepository
                    .GetResourceClaimLineageMetadata(resourceClaimUri, action)
                    .ToList();

            var resourceClaimsLineage =
                from c in resourceClaimNameLineage
                select new DefaultResourceClaimMetadata
                {
                    ClaimName = c,
                    AuthorizationStrategies =
                        resourceClaimLineageWithMetadata
                            .Where(x => c.EqualsIgnoreCase(x.ResourceClaim.ClaimName))
                            .SelectMany(x => x.AuthorizationStrategies.Select(y => y.AuthorizationStrategy.AuthorizationStrategyName))
                            .ToArray()
                };

            return resourceClaimsLineage;
        }
    }
}

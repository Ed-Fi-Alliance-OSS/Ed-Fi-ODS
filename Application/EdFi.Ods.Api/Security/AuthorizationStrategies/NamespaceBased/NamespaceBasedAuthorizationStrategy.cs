// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationStrategy : IAuthorizationStrategy
    {
        private const string AuthorizationStrategyName = "NamespaceBased";

        private readonly ConcurrentDictionary<FullName, string> _namespacePropertyByResourceFullName = new();

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            EdFiResourceClaim[] relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            var claimNamespacePrefixes = NamespaceBasedAuthorizationHelpers.GetClaimNamespacePrefixes(authorizationContext);

            var resource = authorizationContext.Resource;

            string subjectEndpointName = _namespacePropertyByResourceFullName.GetOrAdd(
                resource.FullName,
                fn => NamespaceAuthorizationConvention.GetNamespacePropertyName(
                    resource.FullName.ToString(),
                    resource.AllPropertyByName.Keys));

            return new AuthorizationStrategyFiltering
            {
                AuthorizationStrategyName = AuthorizationStrategyName,
                Filters = new[]
                {
                    new AuthorizationFilterContext
                    {
                        FilterName = "Namespace",
                        SubjectEndpointName = subjectEndpointName,
                        ClaimEndpointValues = claimNamespacePrefixes.Cast<object>().ToArray(),
                        ClaimParameterName = "Namespace",
                        ClaimParameterValueMap = prefix => $"{prefix}%"
                    }
                },
                Operator = FilterOperator.And
            };
        }
    }
}

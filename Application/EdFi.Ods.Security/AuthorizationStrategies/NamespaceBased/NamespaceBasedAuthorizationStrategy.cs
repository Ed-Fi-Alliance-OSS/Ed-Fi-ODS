// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Security.AuthorizationStrategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationStrategy : IEdFiAuthorizationStrategy
    {
        private readonly AuthorizationContextDataFactory _authorizationContextDataFactory
            = new AuthorizationContextDataFactory();

        public Task AuthorizeSingleItemAsync(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext,
            CancellationToken cancellationToken)
        {
            var claimNamespacePrefixes = GetClaimNamespacePrefixes(authorizationContext);

            var contextData = _authorizationContextDataFactory
               .CreateContextData<NamespaceBasedAuthorizationContextData>(
                    authorizationContext.Data);

            if (contextData == null)
            {
                throw new NotSupportedException(
                    "No 'Namespace' property could be found on the resource in order to perform authorization. Should a different authorization strategy be used?");
            }

            if (string.IsNullOrWhiteSpace(contextData.Namespace))
            {
                throw new EdFiSecurityException(
                    "Access to the resource item could not be authorized because the Namespace of the resource is empty.");
            }

            if (!claimNamespacePrefixes.Any(ns => contextData.Namespace.StartsWithIgnoreCase(ns)))
            {
                string claimNamespacePrefixesText = string.Join("', '", claimNamespacePrefixes);

                throw new EdFiSecurityException(
                    $"Access to the resource item with namespace '{contextData.Namespace}' could not be authorized based on the caller's NamespacePrefix claims: '{claimNamespacePrefixesText}'.");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            var claimNamespacePrefixes = GetClaimNamespacePrefixes(authorizationContext);

            return new[]
            {
                new AuthorizationFilterDetails
                {
                    FilterName = "Namespace",
                    SubjectEndpointName = "Namespace",
                    ClaimEndpointName = "Namespace",
                    ClaimValues = claimNamespacePrefixes.Select(prefix => $"{prefix}%").Cast<object>().ToArray(),
                }
            };
        }

        private static IReadOnlyList<string> GetClaimNamespacePrefixes(EdFiAuthorizationContext authorizationContext)
        {
            var namespacePrefixes = authorizationContext.Principal.Claims
                .Where(c => c.Type == EdFiOdsApiClaimTypes.NamespacePrefix)
                .Select(c => c.Value)
                .ToList();

            if (!namespacePrefixes.Any() || namespacePrefixes.All(string.IsNullOrEmpty))
            {
                throw new EdFiSecurityException($"Access to the resource could not be authorized because the caller did not have any NamespacePrefix claims ('{EdFiOdsApiClaimTypes.NamespacePrefix}') or the claim values were all empty.");
            }

            return namespacePrefixes;
        }
    }
}

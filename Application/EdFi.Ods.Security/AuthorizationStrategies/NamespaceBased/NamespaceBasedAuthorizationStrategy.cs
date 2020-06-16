// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
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
            var claimNamespacePrefix = GetClaimNamespacePrefix(authorizationContext);

            var contextData = _authorizationContextDataFactory
               .CreateContextData<NamespaceBasedAuthorizationContextData>(
                    authorizationContext.Data);

            if (contextData == null)
            {
                throw new NotSupportedException(
                    "No 'Namespace' property could be found on the resource in order to perform authorization.  Should a different authorization strategy be used?");
            }

            if (string.IsNullOrWhiteSpace(contextData.Namespace))
            {
                throw new EdFiSecurityException(
                    "Access to the resource item could not be authorized because the Namespace of the resource is empty.");
            }

            if (!contextData.Namespace.StartsWith(claimNamespacePrefix))
            {
                throw new EdFiSecurityException(
                    string.Format(
                        "Access to the resource item with namespace '{0}' could not be authorized based on the caller's NamespacePrefix claim of '{1}'.",
                        contextData.Namespace,
                        claimNamespacePrefix));
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
            var claimNamespacePrefix = GetClaimNamespacePrefix(authorizationContext);

            return new[]
            {
                new AuthorizationFilterDetails
                {
                    FilterName = "Namespace",
                    ClaimEndpointName = "Namespace",
                    ClaimValues = new object[] {claimNamespacePrefix + "%"}
                }
            };
        }

        private static string GetClaimNamespacePrefix(EdFiAuthorizationContext authorizationContext)
        {
            var namespaceClaim =
                authorizationContext.Principal.Claims.FirstOrDefault(
                    c => c.Type == EdFiOdsApiClaimTypes.NamespacePrefix);

            if (namespaceClaim == null || string.IsNullOrWhiteSpace(namespaceClaim.Value))
            {
                throw new EdFiSecurityException(
                    string.Format(
                        "Access to the resource could not be authorized because the caller did not have a NamespacePrefix claim ('{0}') or the claim value was empty.",
                        EdFiOdsApiClaimTypes.NamespacePrefix));
            }

            return namespaceClaim.Value;
        }
    }
}

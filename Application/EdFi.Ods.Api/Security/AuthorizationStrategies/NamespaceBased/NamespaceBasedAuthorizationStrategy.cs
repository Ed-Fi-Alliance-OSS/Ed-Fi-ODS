// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased
{
    public class NamespaceBasedAuthorizationStrategy : IAuthorizationStrategy
    {
        private readonly IDataManagementRequestContextProvider _dataManagementRequestContextProvider;
        private const string AuthorizationStrategyName = "NamespaceBased";

        private readonly ConcurrentDictionary<FullName, string> _namespacePropertyByResourceFullName = new();

        public NamespaceBasedAuthorizationStrategy(IDataManagementRequestContextProvider dataManagementRequestContextProvider)
        {
            _dataManagementRequestContextProvider = dataManagementRequestContextProvider;
        }
        
        /// <summary>
        /// Applies filtering to a multiple-item request.
        /// </summary>
        /// <param name="relevantClaims">The subset of the caller's claims that are relevant for the authorization decision.</param>
        /// <param name="authorizationContext">The authorization context.</param>
        /// <returns>The collection of authorization filters to be applied to the query.</returns>
        public AuthorizationStrategyFiltering GetAuthorizationStrategyFiltering(
            IEnumerable<Claim> relevantClaims,
            EdFiAuthorizationContext authorizationContext)
        {
            var claimNamespacePrefixes = NamespaceBasedAuthorizationHelpers.GetClaimNamespacePrefixes(authorizationContext);

            var resource = _dataManagementRequestContextProvider.GetResource();

            string subjectEndpointName = _namespacePropertyByResourceFullName.GetOrAdd(
                resource.FullName,
                fn =>
                {
                    try
                    {
                        // First, look for a property named "Namespace" (with no prefix)
                        if (resource.AllPropertyByName.ContainsKey("Namespace"))
                        {
                            return "Namespace";
                        }
                        
                        // Now look for a single property suffixed with Namespace
                        return resource.AllProperties.Single(p => p.PropertyName.EndsWith("Namespace")).PropertyName;
                    }
                    catch (Exception ex)
                    {
                        // Throw an exception spelling out the ambiguity
                        throw new EdFiSecurityException(
                            $"Unable to definitively identify a Namespace-based property in the '{resource.FullName}' resource to use for Namespace-based authorization.", ex);
                    }
                });
            
            return new AuthorizationStrategyFiltering
            {
                AuthorizationStrategyName = AuthorizationStrategyName,
                Filters = new []
                {
                    new AuthorizationFilterContext
                    {
                        FilterName = "Namespace",
                        SubjectEndpointName = subjectEndpointName,
                        ClaimEndpointValues = claimNamespacePrefixes.Cast<object>().ToArray(),
                        ClaimParameterName = "Namespace",
                        ClaimParameterValueMap =  prefix => $"{prefix}%"
                    }
                },
                Operator = FilterOperator.And
            };
        }
    }
}

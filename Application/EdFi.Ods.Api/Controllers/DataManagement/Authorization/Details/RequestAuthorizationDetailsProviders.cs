// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Controllers.DataManagement.Authorization.SecurityMetadata;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Details
{
    public class RequestAuthorizationDetailsProviders : IRequestAuthorizationDetailsProvider
    {
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IApiKeyContextProvider _apiKeyContextProvider;

        private readonly XDocument _securityDocument;

        private readonly ConcurrentDictionary<RequestAuthorizationDetails.Key, RequestAuthorizationDetails> _authorizationDetailsByKey
            = new ConcurrentDictionary<RequestAuthorizationDetails.Key, RequestAuthorizationDetails>();

        public RequestAuthorizationDetailsProviders(
            ISecurityMetadataProvider securityMetadataProvider,
            IAuthorizationContextProvider authorizationContextProvider,
            IApiKeyContextProvider apiKeyContextProvider)
        {
            _authorizationContextProvider = authorizationContextProvider;
            _apiKeyContextProvider = apiKeyContextProvider;
            _securityDocument = securityMetadataProvider.GetSecurityMetadata();
        }
        
        public RequestAuthorizationDetails GetRequestAuthorizationDetails()
        {
            var resourceClaimUris = _authorizationContextProvider.GetResourceUris();
            var actionUri = _authorizationContextProvider.GetAction();
            var actionName = actionUri.Split('/').Last().ToMixedCase();
            var claimSetName = _apiKeyContextProvider.GetApiKeyContext().ClaimSetName;
            
            // Iterate through possible claims for the resource looking for previously resolved authorization details
            foreach (string resourceClaimUri in resourceClaimUris)
            {
                var key = new RequestAuthorizationDetails.Key(resourceClaimUri, actionUri, claimSetName);

                if (_authorizationDetailsByKey.TryGetValue(key, out RequestAuthorizationDetails details))
                {
                    return details;
                }
            }

            foreach (string resourceClaimUri in resourceClaimUris)
            {
                // Attempt to find the target resource in the security metadata
                var targetResourceClaim = _securityDocument
                    .XPathSelectElements($"//Claim[@name='{resourceClaimUri}']")
                    .SingleOrDefault();

                if (targetResourceClaim != null)
                {
                    var details = GetAuthorizationDetails(targetResourceClaim, actionName, claimSetName);

                    _authorizationDetailsByKey.TryAdd(
                        new RequestAuthorizationDetails.Key(resourceClaimUri, actionUri, claimSetName),
                        details);

                    return details;
                }
            }

            // NOTE: This is a server-level security metadata configuration error
            // Unable to find security metadata for the resource
            throw new ApiSecurityConfigurationException($"Security metadata for the resource claims ['{string.Join("', '", resourceClaimUris)}'] was not defined.");
        }
        
        private RequestAuthorizationDetails GetAuthorizationDetails(XElement targetResourceClaim, string actionName, string claimSetName)
        {
            string resourceClaimUri = targetResourceClaim.Attribute("name")?.Value;
            
            // TODO: API Simplification - Need to implement logic to iterate up this set of nodes if information isn't found on first one
            // Look up the claims hierarchy for a Claim with explicit permissions defined for the claim set
            var permissionsResourceClaim = targetResourceClaim.XPathSelectElements(
                    $"ancestor-or-self::Claim[ClaimSets/ClaimSet[@name='{claimSetName}']]")
                .Reverse()
                .FirstOrDefault();
	
            if (permissionsResourceClaim == null)
            {
                // No permissions defined
                return null;
            }
            
            //permissionsResource.Dump($"Permissions Resource ({claimsetName} / {resourceName})");
	
            // Look for permissions for the specific action
            var actionElement = permissionsResourceClaim.XPathSelectElements(
                    $"ClaimSets/ClaimSet[@name='{claimSetName}']/Actions/Action[@name='{actionName}']")
                .SingleOrDefault();

            if (actionElement == null)
            {
                // No permissions defined for this action
                // TODO: API Simplification - If at first you don't succeed, keep looking up the hierarchy.
                return null;
            }

            // Determine if there's an authorization strategy override defined at this level
            string authorizationStrategy = actionElement.Attribute("authorizationStrategyOverride")?.Value;

            XElement claimWithDefaultAuthorizationStrategy = null; // TODO: API Simplification - Iterate on this until all levels exhausted

            if (authorizationStrategy == null)
            {
                // Debug.WriteLine($"No authorization strategy override for {actionName} defined on {permissionsResourceClaim}. Looking for inherited default...");
		
                // Find default authorization definition for the action, looking up the hierarchy
                claimWithDefaultAuthorizationStrategy = permissionsResourceClaim
                    .XPathSelectElements($"ancestor-or-self::Claim[DefaultAuthorization/Action[@name='{actionName}']]")
                    .Reverse()
                    .FirstOrDefault();
                
                if (claimWithDefaultAuthorizationStrategy == null)
                {
                    // No default authorization defined for resource, or any ancestor -- this is a configuration error
                    throw new Exception($"No default authorizations defined for action '{actionName}' on resource claim '{resourceClaimUri}'");
                }
                
                var actionWithDefaultAuthorizationStrategy = claimWithDefaultAuthorizationStrategy
                    .XPathSelectElements($"DefaultAuthorization/Action[@name='{actionName}']")
                    .First();
                
                // Try to get the default authorization strategy
                authorizationStrategy = actionWithDefaultAuthorizationStrategy.Attribute("authorizationStrategy")?.Value;

                if (authorizationStrategy == null)
                {
                    // No default authorization strategy defined for resource, or any ancestor -- this is a configuration error
                    throw new Exception($"No default authorization strategy defined for action '{actionName}' on resource claim '{resourceClaimUri}'");
                }
            }

            return new RequestAuthorizationDetails(
                authorizationStrategy,
                null, // TODO: API Simplification - Need to add support for validation rule sets
                new RequestAuthorizationDetails.Diagnostics(
                    permissionsResourceClaim.Attribute("name")?.Value,
                    claimWithDefaultAuthorizationStrategy?.Attribute("name")?.Value),
                null); // TODO: API Simplification - Need to add support for validation rule sets diagnostics
        }
    }
}

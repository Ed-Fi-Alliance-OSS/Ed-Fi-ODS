// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;
using log4net;

namespace EdFi.Ods.Api.Security.Authorization;

public class AuthorizationBasisMetadataSelector : IAuthorizationBasisMetadataSelector
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(AuthorizationBasisMetadataSelector));
        
    private readonly IResourceAuthorizationMetadataProvider _resourceAuthorizationMetadataProvider;
    private readonly Dictionary<string, IAuthorizationStrategy> _authorizationStrategyByName;

    private readonly Lazy<Dictionary<string, int>> _bitValuesByAction;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizationBasisMetadataSelector"/> class.
    /// </summary>
    /// <param name="resourceAuthorizationMetadataProvider">The component that will be used to supply the claims/strategies that can be used to authorize the resource.</param>
    /// <param name="securityRepository"></param>
    /// <param name="authorizationStrategies"></param>
    public AuthorizationBasisMetadataSelector(
        IResourceAuthorizationMetadataProvider resourceAuthorizationMetadataProvider,
        ISecurityRepository securityRepository,
        IAuthorizationStrategy[] authorizationStrategies)
    {
        _resourceAuthorizationMetadataProvider = resourceAuthorizationMetadataProvider;
            
        // Lazy initialization
        _bitValuesByAction = new Lazy<Dictionary<string, int>>(
            () => new Dictionary<string, int>
            {
                { securityRepository.GetActionByName("Create").ActionUri, 0x1 },
                { securityRepository.GetActionByName("Read").ActionUri, 0x2 },
                { securityRepository.GetActionByName("Update").ActionUri, 0x4 },
                { securityRepository.GetActionByName("Delete").ActionUri, 0x8 },
                { securityRepository.GetActionByName("ReadChanges").ActionUri, 0x16 },
            });
            
        _authorizationStrategyByName = CreateAuthorizationStrategyByNameDictionary(authorizationStrategies);
            
        Dictionary<string, IAuthorizationStrategy> CreateAuthorizationStrategyByNameDictionary(
            IAuthorizationStrategy[] authorizationStrategies)
        {
            var strategyByName = new Dictionary<string, IAuthorizationStrategy>(
                StringComparer.InvariantCultureIgnoreCase);

            foreach (var strategy in authorizationStrategies)
            {
                string strategyTypeName = GetStrategyTypeName(strategy);

                const string authorizationStrategyNameSuffix = "AuthorizationStrategy";

                // TODO: Embedded convention
                // Enforce naming conventions on authorization strategies
                if (!strategyTypeName.EndsWith(authorizationStrategyNameSuffix))
                {
                    throw new ArgumentException(
                        string.Format(
                            "The authorization strategy '{0}' does not follow proper naming conventions, ending with 'AuthorizationStrategy'.",
                            strategyTypeName));
                }

                string strategyName = strategyTypeName.TrimSuffix(authorizationStrategyNameSuffix);
                strategyByName.Add(strategyName, strategy);
            }

            return strategyByName;
        }

        string GetStrategyTypeName(IAuthorizationStrategy strategy)
        {
            string rawTypeName = strategy.GetType().Name;

            int genericMarkerPos = rawTypeName.IndexOf("`");

            string strategyTypeName = genericMarkerPos < 0
                ? rawTypeName
                : rawTypeName.Substring(0, genericMarkerPos);

            return strategyTypeName;
        }
    }
        
    /// <inheritdoc cref="IAuthorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata" />
    public AuthorizationBasisMetadata SelectAuthorizationBasisMetadata(EdFiAuthorizationContext authorizationContext)
    {
        var claimCheckResponse = PerformClaimCheck(authorizationContext);
            
        if (!claimCheckResponse.Success)
        {
            throw new EdFiSecurityException(claimCheckResponse.SecurityExceptionMessage);
        }

        var relevantPrincipalClaims = claimCheckResponse.RelevantClaims;

        // Only use the caller's first matching going up the hierarchy
        var relevantPrincipalClaim = relevantPrincipalClaims.First();

        // Look for an authorization strategy override on the caller's claims (flow the overrides down, even if they aren't the first claim encountered going up the hierarchy)
        var authorizationStrategyOverrideNames = relevantPrincipalClaims
            .Select(rpc => rpc.ToEdFiResourceClaimValue()
                .GetAuthorizationStrategyNameOverrides(claimCheckResponse.RequestedAction))
            .FirstOrDefault(x => x != null);

        var metadataAuthorizationStrategyNames =
            claimCheckResponse.AuthorizationMetadata
                .Where(s => s.AuthorizationStrategies != null && s.AuthorizationStrategies.Any())
                .Select(s => s.AuthorizationStrategies )
                .FirstOrDefault();

        // Use the claim's override, if present
        var authorizationStrategyNames =
            authorizationStrategyOverrideNames
            ?? metadataAuthorizationStrategyNames;

        // No authorization strategies were defined for this request
        if (authorizationStrategyNames == null || !authorizationStrategyNames.Any())
        {
            throw new Exception(
                string.Format(
                    "No authorization strategies were defined for the requested action '{0}' against resource URIs ['{1}'] matched by the caller's claim '{2}'.",
                    claimCheckResponse.RequestedAction,
                    string.Join("', '", claimCheckResponse.RequestedResourceUris),
                    relevantPrincipalClaim.Type));
        }

        _logger.DebugFormat(
            "Authorization strategy '{0}' selected for request against resource '{1}'.",
            string.Join("', '", authorizationStrategyNames),
            authorizationContext.ResourceClaims.First()
                .Value);

        // Look for an authorization validation rule set name override on the caller's claims (flow the overrides down, even if they aren't the first claim encountered going up the hierarchy)
        string ruleSetNameOverride =
            (from rpc in relevantPrincipalClaims
                select rpc.ToEdFiResourceClaimValue()
                    .GetAuthorizationValidationRuleSetNameOverride(claimCheckResponse.RequestedAction))
            .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

        var metadataRuleSetName =
            (from rcas in claimCheckResponse.AuthorizationMetadata
                select rcas.ValidationRuleSetName)
            .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

        string ruleSetName =
            ruleSetNameOverride
            ?? metadataRuleSetName;

        // Set outbound authorization details
        return new AuthorizationBasisMetadata(
            GetAuthorizationStrategies(authorizationStrategyNames),
            relevantPrincipalClaim,
            ruleSetName);
            
        IReadOnlyList<IAuthorizationStrategy> GetAuthorizationStrategies(IReadOnlyList<string> strategyNames)
        {
            return strategyNames.Select(
                    strategyName =>
                    {
                        if (!_authorizationStrategyByName.ContainsKey(strategyName))
                        {
                            throw new Exception(
                                string.Format(
                                    "Could not find authorization implementation for strategy '{0}' based on naming convention of '{{strategyName}}AuthorizationStrategy'.",
                                    strategyName));
                        }

                        return _authorizationStrategyByName[strategyName];
                    })
                .ToArray();
        }
    }
        
    private ClaimCheckResponse PerformClaimCheck(EdFiAuthorizationContext authorizationContext)
    {
        // Validate the context
        ValidateAuthorizationContext(authorizationContext);

        // Extract individual values
        string[] requestedResourceClaimUris = authorizationContext.ResourceClaims.Select(x => x.Value).ToArray();

        string requestedAction = authorizationContext.Action.Single().Value;

        // NOTE: GKM - Review all use of the ClaimsPrincipal, and consider eliminating it for CallContext
        var principal = authorizationContext.Principal;

        // Obtain the resource claim/authorization strategy pairs that could be used for authorizing this particular request
        var resourceClaimAuthorizationMetadata = GetResourceClaimAuthorizationMetadatas(requestedResourceClaimUris, requestedAction);

        // Get the names of the resource claims that could be used for authorization
        var authorizingResourceClaimNames = resourceClaimAuthorizationMetadata
            .Select(x => x.ClaimName)
            .ToList();

        // Intersect the potentially authorizing resource claims against the principal's claims
        var claimCheckResponse = GetRelevantPrincipalClaims(authorizingResourceClaimNames, requestedAction, principal);

        if (claimCheckResponse.Success)
        {
            claimCheckResponse.RequestedAction = requestedAction;
            claimCheckResponse.RequestedResourceUris = requestedResourceClaimUris;
            claimCheckResponse.AuthorizationMetadata = resourceClaimAuthorizationMetadata;
        }

        return claimCheckResponse;
            
        void ValidateAuthorizationContext(EdFiAuthorizationContext authorizationContext)
        {
            if (authorizationContext == null)
            {
                throw new ArgumentNullException("authorizationContext");
            }

            if (authorizationContext.ResourceClaims == null || authorizationContext.ResourceClaims.All(r => string.IsNullOrWhiteSpace(r.Value)))
            {
                throw new AuthorizationContextException("Authorization can only be performed if a resource is specified.");
            }

            if (authorizationContext.ResourceClaims.Count > 2)
            {
                throw new AuthorizationContextException($"Unexpected number of Resource URIs found in the authorization context. Expected up to 2, but found {authorizationContext.ResourceClaims.Count}.");
            }

            if (authorizationContext.Action == null || authorizationContext.Action.All(a => string.IsNullOrWhiteSpace(a.Value)))
            {
                throw new AuthorizationContextException("Authorization can only be performed if an action is specified.");
            }

            if (authorizationContext.Action.Count > 1)
            {
                throw new AuthorizationContextException("Authorization can only be performed on requests with a single action.");
            }
        }

        List<ResourceClaimAuthorizationMetadata> GetResourceClaimAuthorizationMetadatas(
            string[] requestedResourceClaimUris,
            string requestedAction)
        {
            // Processing the URIs in order of priority, return the first one found with associated
            // authorization metadata
            var resourceClaimAuthorizationMetadata =
                requestedResourceClaimUris
                    .Select(
                        requestedResourceClaimUri => _resourceAuthorizationMetadataProvider
                            .GetResourceClaimAuthorizationMetadata(requestedResourceClaimUri, requestedAction)
                            .ToList())
                    .FirstOrDefault(x => x.Any());

            // Return the authorization metadata located, or an empty list.
            return resourceClaimAuthorizationMetadata
                ?? new List<ResourceClaimAuthorizationMetadata>();
        }

        ClaimCheckResponse GetRelevantPrincipalClaims(
            IList<string> authorizingClaimNames,
            string requestedAction,
            ClaimsPrincipal principal)
        {
            var response = new ClaimCheckResponse();

            // Find matching claims, while preserving the ordering of the incoming claim names
            var principalClaimsToEvaluate = (from cn in authorizingClaimNames
                join pc in principal.Claims on cn equals pc.Type
                select pc).ToList();

            // 1) First check: Lets make sure the principal at least has a claim that applies for this resource.
            if (!principalClaimsToEvaluate.Any())
            {
                response.Success = false;

                var apiClientResourceClaims = principal.Claims.Select(c => c.Type)
                    .Where(x => x.StartsWith(EdFiConventions.EdFiOdsResourceClaimBaseUri));

                string apiClientClaimSetName =
                    principal.Claims.SingleOrDefault(c => c.Type == EdFiOdsApiClaimTypes.ClaimSetName)?.Value;

                response.SecurityExceptionMessage =
                    $@"Access to the resource could not be authorized. Are you missing a claim? This resource can be authorized by the following claims:
    {string.Join(Environment.NewLine + "    ", authorizingClaimNames)}
The API client has been assigned the '{apiClientClaimSetName}' claim set with the following resource claims:
    {string.Join(Environment.NewLine + "    ", apiClientResourceClaims)}";

                return response;
            }

            // 2) Second check: Of the claims that apply for this resource do we have any that match the action requested or a higher action?
            var edfiClaimValuesToEvaluate = principalClaimsToEvaluate.Select(
                x => new
                {
                    Claim = x,
                    EdFiResourceClaimValue = x.ToEdFiResourceClaimValue()
                });

            var claimsWithMatchingActions = edfiClaimValuesToEvaluate.Where(
                    x => IsRequestedActionSatisfiedByClaimActions(
                        requestedAction,
                        x.EdFiResourceClaimValue.Actions.Select(y => y.Name)))
                .ToList();

            if (!claimsWithMatchingActions.Any())
            {
                response.Success = false;

                response.SecurityExceptionMessage = string.Format(
                    "Access to the resource could not be authorized for the requested action '{0}'.",
                    requestedAction);

                return response;
            }

            response.Success = true;

            response.RelevantClaims = claimsWithMatchingActions.Select(x => x.Claim).ToList();

            return response;
        }

        bool IsRequestedActionSatisfiedByClaimActions(string requestedAction, IEnumerable<string> principalClaimActions)
        {
            int requestedActionValue = GetBitValuesByAction(requestedAction);

            // Determine if any of the claim actions can satisfy the requested action
            return principalClaimActions.Any(x => (requestedActionValue & GetBitValuesByAction(x)) != 0);
        }

        int GetBitValuesByAction(string action)
        {
            int result;

            if (_bitValuesByAction.Value.TryGetValue(action, out result))
            {
                return result;
            }

            // Should never happen
            throw new NotSupportedException("The requested action is not a supported action.  Authorization cannot be performed.");
        }

    }

    private class ClaimCheckResponse
    {
        public bool Success { get; set; }

        public List<Claim> RelevantClaims { get; set; }

        public string RequestedAction { get; set; }

        public string[] RequestedResourceUris { get; set; }

        public List<ResourceClaimAuthorizationMetadata> AuthorizationMetadata { get; set; }

        public string SecurityExceptionMessage { get; set; }
    }
}

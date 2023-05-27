// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.Claims;
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

    private static readonly string _newLineWithIndent = $"{Environment.NewLine}    ";
    private const string AuthorizationStrategyNameSuffix = "AuthorizationStrategy";

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
            
        _authorizationStrategyByName = CreateAuthorizationStrategyByNameDictionary();

        Dictionary<string, IAuthorizationStrategy> CreateAuthorizationStrategyByNameDictionary()
        {
            var strategyByName = new Dictionary<string, IAuthorizationStrategy>(StringComparer.OrdinalIgnoreCase);

            foreach (var strategy in authorizationStrategies)
            {
                string strategyTypeName = GetStrategyTypeName(strategy);

                // TODO: Embedded convention
                // Enforce naming conventions on authorization strategies
                if (!strategyTypeName.EndsWith(AuthorizationStrategyNameSuffix))
                {
                    throw new ArgumentException(
                        $"The authorization strategy '{strategyTypeName}' does not follow proper naming conventions, ending with 'AuthorizationStrategy'.");
                }

                string strategyName = strategyTypeName.TrimSuffix(AuthorizationStrategyNameSuffix);
                strategyByName.Add(strategyName, strategy);
            }

            return strategyByName;
        }

        string GetStrategyTypeName(IAuthorizationStrategy strategy)
        {
            string rawTypeName = strategy.GetType().Name;

            int genericMarkerPos = rawTypeName.IndexOf('`');

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

        var relevantClaimSetClaims = claimCheckResponse.RelevantClaims;

        // Only use the caller's first matching going up the hierarchy
        var relevantClaimSetClaim = relevantClaimSetClaims.First();

        // Look for an authorization strategy override on the caller's claims (flow the overrides down, even if they aren't the first claim encountered going up the hierarchy)
        var authorizationStrategyOverrideNames = relevantClaimSetClaims
            .Select(rpc => rpc.ClaimValue.GetAuthorizationStrategyNameOverrides(claimCheckResponse.RequestedAction))
            .FirstOrDefault(x => x != null);

        var metadataAuthorizationStrategyNames =
            claimCheckResponse.AuthorizationMetadata
                .Where(s => s.AuthorizationStrategies != null && s.AuthorizationStrategies.Any())
                .Select(s => s.AuthorizationStrategies )
                .FirstOrDefault();

        // Use the claim's override, if present
        var authorizationStrategyNames = authorizationStrategyOverrideNames ?? metadataAuthorizationStrategyNames;

        // No authorization strategies were defined for this request
        if (authorizationStrategyNames == null || !authorizationStrategyNames.Any())
        {
            throw new Exception(
                string.Format(
                    "No authorization strategies were defined for the requested action '{0}' against resource URIs ['{1}'] matched by the caller's claim '{2}'.",
                    claimCheckResponse.RequestedAction,
                    string.Join("', '", claimCheckResponse.RequestedResourceUris),
                    relevantClaimSetClaim.ClaimName));
        }

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                $"Authorization strategy '{string.Join("', '", authorizationStrategyNames)}' selected for request against resource '{authorizationContext.ResourceClaimUris.First()}'.");
        }

        // Look for an authorization validation rule set name override on the caller's claims (flow the overrides down, even if they aren't the first claim encountered going up the hierarchy)
        string ruleSetNameOverride = relevantClaimSetClaims
            .Select(rpc => rpc.ClaimValue.GetAuthorizationValidationRuleSetNameOverride(claimCheckResponse.RequestedAction))
            .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

        var metadataRuleSetName =
            claimCheckResponse.AuthorizationMetadata.Select(rcas => rcas.ValidationRuleSetName)
            .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));

        string ruleSetName = ruleSetNameOverride ?? metadataRuleSetName;

        // Set outbound authorization details
        return new AuthorizationBasisMetadata(
            GetAuthorizationStrategies(authorizationStrategyNames),
            relevantClaimSetClaim,
            ruleSetName);

        IReadOnlyList<IAuthorizationStrategy> GetAuthorizationStrategies(IReadOnlyList<string> strategyNames)
        {
            return strategyNames.Select(
                    strategyName =>
                    {
                        if (!_authorizationStrategyByName.ContainsKey(strategyName))
                        {
                            throw new Exception(
                                $"Could not find authorization implementation for strategy '{strategyName}' based on naming convention of '{{strategyName}}AuthorizationStrategy'.");
                        }

                        return _authorizationStrategyByName[strategyName];
                    })
                .ToArray();
        }
    }
        
    private ClaimCheckResponse PerformClaimCheck(EdFiAuthorizationContext authorizationContext)
    {
        string apiClientClaimSetName = authorizationContext.ApiKeyContext.ClaimSetName;
        var claimSetClaims = authorizationContext.ClaimSetClaims;
        
        // Validate the context
        ValidateAuthorizationContext();

        // Extract individual values
        string[] requestedResourceClaimUris = authorizationContext.ResourceClaimUris;

        string requestedAction = authorizationContext.Action;

        // Obtain the resource claim/authorization strategy pairs that could be used for authorizing this particular request
        var resourceClaimAuthorizationMetadata = GetResourceClaimAuthorizationMetadatas();

        // Get the names of the resource claims that could be used for authorization
        var authorizingResourceClaimNames = resourceClaimAuthorizationMetadata
            .Select(x => x.ClaimName)
            .ToArray();

        // Intersect the potentially authorizing resource claims against the principal's claims
        var claimCheckResponse = GetRelevantPrincipalClaims(authorizingResourceClaimNames);

        if (claimCheckResponse.Success)
        {
            claimCheckResponse.RequestedAction = requestedAction;
            claimCheckResponse.RequestedResourceUris = requestedResourceClaimUris;
            claimCheckResponse.AuthorizationMetadata = resourceClaimAuthorizationMetadata;
        }

        return claimCheckResponse;
            
        void ValidateAuthorizationContext()
        {
            if (authorizationContext == null)
            {
                throw new ArgumentNullException(nameof(authorizationContext));
            }

            if (authorizationContext.ResourceClaimUris == null || authorizationContext.ResourceClaimUris.All(string.IsNullOrWhiteSpace))
            {
                throw new AuthorizationContextException("Authorization can only be performed if a resource is specified.");
            }

            if (authorizationContext.ResourceClaimUris.Length > 2)
            {
                throw new AuthorizationContextException($"Unexpected number of Resource URIs found in the authorization context. Expected up to 2, but found {authorizationContext.ResourceClaimUris.Length}.");
            }

            if (authorizationContext.Action == null)
            {
                throw new AuthorizationContextException("Authorization can only be performed if an action is specified.");
            }
        }

        IReadOnlyList<ResourceClaimAuthorizationMetadata> GetResourceClaimAuthorizationMetadatas()
        {
            // Processing the URIs in order of priority, return the first one found with associated
            // authorization metadata
            IReadOnlyList<ResourceClaimAuthorizationMetadata> metadatas = requestedResourceClaimUris
                    .Select(
                        requestedResourceClaimUri => _resourceAuthorizationMetadataProvider
                            .GetResourceClaimAuthorizationMetadata(requestedResourceClaimUri, requestedAction)
                            .ToArray())
                    .FirstOrDefault(x => x.Any());

            // Return the authorization metadata located, or an empty list.
            return metadatas ?? Array.Empty<ResourceClaimAuthorizationMetadata>();
        }

        ClaimCheckResponse GetRelevantPrincipalClaims(IList<string> authorizingClaimNames)
        {
            var response = new ClaimCheckResponse();

            // Find matching claims, while preserving the ordering of the incoming claim names
            var principalClaimsToEvaluate = authorizingClaimNames
                .Join(claimSetClaims, 
                    cn => cn, 
                    pc => pc.ClaimName, 
                    (cn, pc) => pc)
                .ToArray();

            // 1) First check: Lets make sure the principal at least has a claim that applies for this resource.
            if (!principalClaimsToEvaluate.Any())
            {
                response.Success = false;

                var apiClientResourceClaims = claimSetClaims.Select(c => c.ClaimName)
                    .Where(x => x.StartsWith(EdFiConventions.EdFiOdsResourceClaimBaseUri));

                response.SecurityExceptionMessage =
                    $@"Access to the resource could not be authorized. The API client has been assigned the '{apiClientClaimSetName}' claim set.
Assign a different claim set which includes one of the following claims to access this resource:
    {string.Join(_newLineWithIndent, authorizingClaimNames)}";

                return response;
            }

            // 2) Second check: Of the claims that apply for this resource do we have any that match the action requested or a higher action?
            var edfiClaimValuesToEvaluate = principalClaimsToEvaluate.Select(
                x => new
                {
                    Claim = x,
                    EdFiResourceClaimValue = x.ClaimValue
                });

            var claimsWithMatchingActions = edfiClaimValuesToEvaluate
                .Where(
                    x => IsRequestedActionSatisfiedByClaimActions(x.EdFiResourceClaimValue.Actions.Select(y => y.Name)))
                .ToArray();

            if (!claimsWithMatchingActions.Any())
            {
                response.Success = false;

                response.SecurityExceptionMessage =
                    $"Access to the resource could not be authorized for the requested action '{requestedAction}'.";

                return response;
            }

            response.Success = true;

            response.RelevantClaims = claimsWithMatchingActions.Select(x => x.Claim).ToArray();

            return response;
        }

        bool IsRequestedActionSatisfiedByClaimActions(IEnumerable<string> principalClaimActions)
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

        public IReadOnlyList<EdFiResourceClaim> RelevantClaims { get; set; }

        public string RequestedAction { get; set; }

        public string[] RequestedResourceUris { get; set; }

        public IReadOnlyList<ResourceClaimAuthorizationMetadata> AuthorizationMetadata { get; set; }

        public string SecurityExceptionMessage { get; set; }
    }
}

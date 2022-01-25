// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Utils.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Validation;
using EdFi.Security.DataAccess.Repositories;
using log4net;

namespace EdFi.Ods.Api.Security.Authorization
{
    /// <summary>
    /// Performs authorization appropriate to the claims, resource, action and context data supplied in the <see cref="EdFiAuthorizationContextData"/>.
    /// </summary>
    public class EdFiAuthorizationProvider : IEdFiAuthorizationProvider
    {
        private readonly Dictionary<string, IEdFiAuthorizationStrategy> _authorizationStrategyByName;
        private readonly Lazy<Dictionary<string, int>> _bitValuesByAction;
        private readonly IExplicitObjectValidator[] _explicitObjectValidators;

        private readonly ILog _logger = LogManager.GetLogger(typeof(EdFiAuthorizationProvider));
        private readonly IResourceAuthorizationMetadataProvider _resourceAuthorizationMetadataProvider;
        private readonly ISecurityRepository _securityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdFiAuthorizationProvider"/> class using the specified
        /// authorization strategy provider.
        /// </summary>
        /// <param name="resourceAuthorizationMetadataProvider">The component that will be used to supply the claims/strategies that can be used to authorize the resource.</param>
        /// <param name="authorizationStrategies"></param>
        /// <param name="securityRepository"></param>
        /// <param name="explicitObjectValidators"></param>
        public EdFiAuthorizationProvider(
            IResourceAuthorizationMetadataProvider resourceAuthorizationMetadataProvider,
            IEdFiAuthorizationStrategy[] authorizationStrategies,
            ISecurityRepository securityRepository,
            IExplicitObjectValidator[] explicitObjectValidators)
        {
            if (resourceAuthorizationMetadataProvider == null)
            {
                throw new ArgumentNullException("resourceAuthorizationMetadataProvider");
            }

            if (securityRepository == null)
            {
                throw new ArgumentNullException("securityRepository");
            }

            _resourceAuthorizationMetadataProvider = resourceAuthorizationMetadataProvider;
            _securityRepository = securityRepository;
            _explicitObjectValidators = explicitObjectValidators;

            _authorizationStrategyByName = CreateAuthorizationStrategyByNameDictionary(authorizationStrategies);

            // Lazy initialization
            _bitValuesByAction = new Lazy<Dictionary<string, int>>(
                () => new Dictionary<string, int>
                      {
                          {
                              _securityRepository.GetActionByName("Create")
                                                 .ActionUri,
                              0x1
                          },
                          {
                              _securityRepository.GetActionByName("Read")
                                                 .ActionUri,
                              0x2
                          },
                          {
                              _securityRepository.GetActionByName("Update")
                                                 .ActionUri,
                              0x4
                          },
                          {
                              _securityRepository.GetActionByName("Delete")
                                                 .ActionUri,
                              0x8
                          }
                      });
        }

        /// <summary>
        /// Authorizes a single-item request using the claims, resource, action and entity instance supplied in the <see cref="EdFiAuthorizationContext"/>.
        /// </summary>
        /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
        public async Task AuthorizeSingleItemAsync(EdFiAuthorizationContext authorizationContext, CancellationToken cancellationToken)
        {
            var details = GetAuthorizationDetails(authorizationContext);

            // If there are explicit object validators, and we're modifying data
            if (_explicitObjectValidators.Any()
                && IsCreateUpdateOrDelete(authorizationContext))
            {
                // Validate the object using explicit validation
                var validationResults = _explicitObjectValidators.ValidateObject(
                    authorizationContext.Data,
                    details.ValidationRuleSetName);

                if (!validationResults.IsValid())
                {
                    throw new ValidationException(
                        string.Format(
                            "Validation of '{0}' failed.\n{1}",
                            authorizationContext.Data.GetType()
                                                .Name,
                            string.Join("\n", validationResults.GetAllMessages(indentLevel: 1))));
                }
            }

            var tasks = details.AuthorizationStrategies.Select(x => x.AuthorizeSingleItemAsync(new[] { details.RelevantClaim }, authorizationContext, cancellationToken));
            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Authorizes a multiple-item read request using the claims, resource, and action supplied in the <see cref="EdFiAuthorizationContext"/>.
        /// </summary>
        /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
        /// <returns>The list of filters to be applied to the query for authorization.</returns>
        public IReadOnlyList<AuthorizationFilterDetails> GetAuthorizationFilters(EdFiAuthorizationContext authorizationContext)
        {
            var details = GetAuthorizationDetails(authorizationContext);

            var relevantClaims = new[] { details.RelevantClaim };

            var authorizationFilters = details.AuthorizationStrategies
                .Distinct()
                .SelectMany(x => x.GetAuthorizationFilters(relevantClaims, authorizationContext))
                .ToArray();

            return authorizationFilters;
        }

        /// <summary>
        /// Performs a claims authorization evaluation on the request related to the resource and action only 
        /// without performing any authorization strategies normally performed for authorization decisions.
        /// </summary>
        /// <param name="authorizationContext">The current authorization context of the request.</param>
        /// <param name="securityExceptionMessage">In the event of authorization failure, will contain the security exception message.</param>
        /// <returns><b>true</b> if the caller is authorization to perform the requested action on the requested resource (without regard to application of authorization strategies); otherwise <b>false</b>.</returns>
        public bool TryAuthorizeResourceActionOnly(EdFiAuthorizationContext authorizationContext, out string securityExceptionMessage)
        {
            securityExceptionMessage = null;

            var claimCheckResponse = PerformClaimCheck(authorizationContext);

            if (!claimCheckResponse.Success)
            {
                securityExceptionMessage = claimCheckResponse.SecurityExceptionMessage;
            }

            return claimCheckResponse.Success;
        }

        private static Dictionary<string, IEdFiAuthorizationStrategy> CreateAuthorizationStrategyByNameDictionary(
            IEdFiAuthorizationStrategy[] authorizationStrategies)
        {
            var strategyByName = new Dictionary<string, IEdFiAuthorizationStrategy>(
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

        private static string GetStrategyTypeName(IEdFiAuthorizationStrategy strategy)
        {
            string rawTypeName = strategy.GetType()
                                         .Name;

            int genericMarkerPos = rawTypeName.IndexOf("`");

            string strategyTypeName = genericMarkerPos < 0
                ? rawTypeName
                : rawTypeName.Substring(0, genericMarkerPos);

            return strategyTypeName;
        }

        private void ValidateAuthorizationContext(EdFiAuthorizationContext authorizationContext)
        {
            if (authorizationContext == null)
            {
                throw new ArgumentNullException("authorizationContext");
            }

            if (authorizationContext.Resource == null || authorizationContext.Resource.All(r => string.IsNullOrWhiteSpace(r.Value)))
            {
                throw new AuthorizationContextException("Authorization can only be performed if a resource is specified.");
            }

            if (authorizationContext.Resource.Count > 2)
            {
                throw new AuthorizationContextException($"Unexpected number of Resource URIs found in the authorization context. Expected up to 2, but found {authorizationContext.Resource.Count}.");
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

        private bool IsCreateUpdateOrDelete(EdFiAuthorizationContext authorizationContext)
        {
            return (_bitValuesByAction.Value[authorizationContext.Action.Single()
                                                                 .Value] & 13) != 0;
        }

        /// <summary>
        /// Performs a claims authorization evaluation on the request related to the resource and action only 
        /// without performing any authorization strategies normally performed for authorization decisions.
        /// </summary>
        /// <param name="authorizationContext">The current authorization context of the request.</param>
        public void AuthorizeResourceActionOnly(EdFiAuthorizationContext authorizationContext)
        {
            var claimCheckResponse = PerformClaimCheck(authorizationContext);

            if (!claimCheckResponse.Success)
                throw new EdFiSecurityException(claimCheckResponse.SecurityExceptionMessage);
        }

        /// <summary>
        /// Performs authorization appropriate to the claims, resource, action and context data supplied in the <see cref="EdFiAuthorizationContextData"/>.
        /// </summary>
        /// <param name="authorizationContext">The authorization context to be used in making the authorization decision.</param>
        private AuthorizationDetails GetAuthorizationDetails(EdFiAuthorizationContext authorizationContext)
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
            
            // TODO: GKM - When claimset-specific override support is added, use this logic
            //string claimSpecificOverrideAuthorizationStrategyName =
            //    resourceClaimAuthorizationStrategies
            //        // Find the resource claim that matches the relevant principal claim
            //        .SkipWhile(s => !s.ClaimName.EqualsIgnoreCase(relevantPrincipalClaim.Type))
            //        .Select(s => s.AuthorizationStrategyOverride)
            //        .FirstOrDefault();

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
                authorizationContext.Resource.First()
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
            return new AuthorizationDetails(
                GetAuthorizationStrategies(authorizationStrategyNames),
                relevantPrincipalClaim,
                ruleSetName);
        }

        private ClaimCheckResponse PerformClaimCheck(EdFiAuthorizationContext authorizationContext)
        {
            // Validate the context
            ValidateAuthorizationContext(authorizationContext);

            // Extract individual values
            string[] requestedResourceClaimUris = authorizationContext.Resource.Select(x => x.Value).ToArray();

            string requestedAction = authorizationContext.Action.Single().Value;

            var principal = authorizationContext.Principal;

            // Obtain the resource claim/authorization strategy pairs that could be used for authorizing this particular request
            var resourceClaimAuthorizationMetadata = GetResourceClaimAuthorizationMetadatas(requestedResourceClaimUris, requestedAction);

            // Get the names of the resource claims that could be used for authorization
            var authorizingResourceClaimNames = resourceClaimAuthorizationMetadata.Select(x => x.ClaimName)
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
        }

        private List<ResourceClaimAuthorizationMetadata> GetResourceClaimAuthorizationMetadatas(
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

        private ClaimCheckResponse GetRelevantPrincipalClaims(
            IList<string> authorizingClaimNames,
            string requestedAction,
            ClaimsPrincipal principal)
        {
            var response = new ClaimCheckResponse();

            // Find matching claims, while preserving the ordering of the incoming claim names
            var principalClaimsToEvaluate =
                (from cn in authorizingClaimNames
                 join pc in principal.Claims on cn equals pc.Type
                 select pc)
               .ToList();

            // 1) First check: Lets make sure the principal at least has a claim that applies for this resource.
            if (!principalClaimsToEvaluate.Any())
            {
                response.Success = false;

                var apiClientResourceClaims = principal.Claims.Select(c => c.Type)
                    .Where(x => x.StartsWith(EdFi.Ods.Common.Conventions.EdFiConventions.EdFiOdsResourceClaimBaseUri));

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

            response.RelevantClaims = claimsWithMatchingActions.Select(x => x.Claim)
                                                               .ToList();

            return response;
        }

        private bool IsRequestedActionSatisfiedByClaimActions(string requestedAction, IEnumerable<string> principalClaimActions)
        {
            int requestedActionValue = GetBitValuesByAction(requestedAction);

            // Determine if any of the claim actions can satisfy the requested action
            return principalClaimActions.Any(x => (requestedActionValue & GetBitValuesByAction(x)) != 0);
        }

        private int GetBitValuesByAction(string action)
        {
            int result;

            if (_bitValuesByAction.Value.TryGetValue(action, out result))
            {
                return result;
            }

            // Should never happen
            throw new NotSupportedException("The requested action is not a supported action.  Authorization cannot be performed.");
        }

        private IReadOnlyList<IEdFiAuthorizationStrategy> GetAuthorizationStrategies(IReadOnlyList<string> strategyNames)
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

        private class AuthorizationDetails
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AuthorizationDetails"/> class.
            /// </summary>
            public AuthorizationDetails(IReadOnlyList<IEdFiAuthorizationStrategy> authorizationStrategies, Claim relevantClaim, string validationRuleSetName)
            {
                AuthorizationStrategies = authorizationStrategies;
                RelevantClaim = relevantClaim;
                ValidationRuleSetName = validationRuleSetName;
            }

            public IReadOnlyList<IEdFiAuthorizationStrategy> AuthorizationStrategies { get; }

            public Claim RelevantClaim { get; }

            public string ValidationRuleSetName { get; }
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
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

[Intercept(InterceptorCacheKeys.Security)]
public interface IClaimSetRequestEvaluator
{
    /// <summary>
    /// Returns whether the claim set name is authorized to perform the action on the resource. 
    /// </summary>
    ClaimSetRequestEvaluation EvaluateRequest(string claimSetName, IList<string> resourceClaimUris, string requestAction);
}

public class ClaimSetRequestEvaluator : IClaimSetRequestEvaluator
{
    private readonly IClaimSetClaimsProvider _claimSetClaimsProvider;
    private readonly IAuthorizationContextValidator _authorizationContextValidator;
    private readonly IResourceClaimAuthorizationMetadataLineageProvider _resourceClaimAuthorizationMetadataLineageProvider;
    private readonly IActionBitValueProvider _actionBitValueProvider;

    private const string SecurityExceptionDetailForResource = "You do not have permissions to access this data.";
    private const string SecurityExceptionDetailForAction = "You do not have permissions to perform the requested operation on the data.";
    private static readonly string[] _accessDeniedResourceParts = ["access-denied", "resource"];
    private static readonly string[] _accessDeniedActionParts = ["access-denied", "action"];
 
    /// <summary>
    /// Initializes a new instance of the <see cref="ClaimSetRequestEvaluator"/> class.
    /// </summary>
    /// <param name="claimSetClaimsProvider"></param>
    /// <param name="authorizationContextValidator"></param>
    /// <param name="resourceClaimAuthorizationMetadataLineageProvider">The component that will be used to supply the lineage of claims/strategies that can be used to authorize the resource.</param>
    /// <param name="actionBitValueProvider"></param>
    public ClaimSetRequestEvaluator(
        IClaimSetClaimsProvider claimSetClaimsProvider,
        IAuthorizationContextValidator authorizationContextValidator,
        IResourceClaimAuthorizationMetadataLineageProvider resourceClaimAuthorizationMetadataLineageProvider,
        IActionBitValueProvider actionBitValueProvider)
    {
        _claimSetClaimsProvider = claimSetClaimsProvider;
        _authorizationContextValidator = authorizationContextValidator;
        _resourceClaimAuthorizationMetadataLineageProvider = resourceClaimAuthorizationMetadataLineageProvider;
        _actionBitValueProvider = actionBitValueProvider;
    }

    /// <inheritdoc cref="IClaimSetRequestEvaluator.EvaluateRequest" />
    public ClaimSetRequestEvaluation EvaluateRequest(string claimSetName, IList<string> resourceClaimUris, string requestAction)
    {
        // Validate the context
        _authorizationContextValidator.Validate(resourceClaimUris, requestAction);

        var claimSetClaims = _claimSetClaimsProvider.GetClaims(claimSetName);

        // Obtain the resource claim/authorization strategy pairs that could be used for authorizing this particular request
        var resourceClaimAuthorizationMetadataLineage = GetResourceClaimAuthorizationLineageMetadata();

        // Get the names of the resource claims that could be used for authorization
        var authorizingResourceClaimNameLineage = resourceClaimAuthorizationMetadataLineage
            .Select(x => x.ClaimName)
            .ToList();

        // If there's not security metadata available for this resource, it's an error condition
        if (authorizingResourceClaimNameLineage.Count == 0)
        {
            throw new SecurityConfigurationException(
                SecurityConfigurationException.DefaultDetail,
                "No security metadata has been configured for this resource.");
        }

        // Intersect the potentially authorizing resource claims against the principal's claims
        var (success, relevantClaimsLineage, securityException) = GetRelevantClaimSetClaimsLineage();

        if (success)
        {
            return new ClaimSetRequestEvaluation()
            {
                Success = true,
                ClaimSetResourceClaimLineage = relevantClaimsLineage,
                RequestedAction = requestAction,
                RequestedResourceUris = resourceClaimUris,
                DefaultResourceClaimLineage = resourceClaimAuthorizationMetadataLineage,
            };
        }

        return new ClaimSetRequestEvaluation()
        {
            Success = false,
            SecurityException = securityException
        };

        IList<DefaultResourceClaimMetadata> GetResourceClaimAuthorizationLineageMetadata()
        {
            // Processing the URIs in order of priority, return the first one found with associated authorization metadata
            var resourceClaimLineages = resourceClaimUris.Select(
                    requestedResourceClaimUri => _resourceClaimAuthorizationMetadataLineageProvider
                        .GetAuthorizationLineage(requestedResourceClaimUri, requestAction)
                        .ToArray())
                .ToArray();

            // If we are processing more than 1 possible resource claim, and we've found metadata lineages for both, this is a security metadata configuration error
            if (resourceClaimUris.Count > 1 && resourceClaimLineages.Count(l => l.Length > 0) > 1)
            {
                throw new SecurityConfigurationException(
                    SecurityConfigurationException.DefaultDetail,
                    $"Authorization metadata was found for more than one of the supplied resource claims ('{string.Join(", ", resourceClaimUris)}') resulting in an ambiguous basis for authorization.");
            }

            // Return the authorization metadata located, or an empty array.
            return resourceClaimLineages.FirstOrDefault(l => l.Length > 0) ?? Array.Empty<DefaultResourceClaimMetadata>();
        }

        (bool success, List<ClaimSetResourceClaimMetadata> relevantClaimsLineage, SecurityAuthorizationException securityException) GetRelevantClaimSetClaimsLineage()
        {
            // Find matching claims, while preserving the ordering of the incoming claim names
            var claimSetClaimsEvaluationLineage = authorizingResourceClaimNameLineage
                .Join(claimSetClaims, 
                    cn => cn, 
                    pc => pc.ClaimName, 
                    (cn, pc) => pc)
                .ToList();

            // 1) First check: Lets make sure the claim set at least has a claim that applies for this resource.
            if (!claimSetClaimsEvaluationLineage.Any())
            {
                string errorMessage = $"The API client's assigned claim set (currently '{claimSetName}') must include one of the following resource claims to provide access to this resource: '{string.Join("', '", authorizingResourceClaimNameLineage)}'.";

                var exception =
                    new SecurityAuthorizationException(
                        $"{SecurityAuthorizationException.DefaultDetail} {SecurityExceptionDetailForResource}",
                        errorMessage)
                    {
                        InstanceTypeParts = _accessDeniedResourceParts
                    };

                return (false, null, exception);
            }

            // 2) Second check: Of the claims that apply for this resource do we have any that match the action requested or a higher action?
            var claimsWithMatchingActionsLineage = claimSetClaimsEvaluationLineage
                .Where(rc => IsRequestedActionSatisfiedByClaimActions(rc.Actions.Select(y => y.Name)))
                .ToList();

            if (!claimsWithMatchingActionsLineage.Any())
            {
                string errorMessage = $"The API client's assigned claim set (currently '{claimSetName}') must grant permission of the '{requestAction}' action on one of the following resource claims: '{string.Join("', '", authorizingResourceClaimNameLineage)}'.";

                var exception =
                    new SecurityAuthorizationException(
                        $"{SecurityAuthorizationException.DefaultDetail} {SecurityExceptionDetailForAction}",
                        errorMessage)
                    {
                        InstanceTypeParts = _accessDeniedActionParts
                    };

                return (false, null, exception);
            }

            return (true, claimsWithMatchingActionsLineage, null);
        }

        bool IsRequestedActionSatisfiedByClaimActions(IEnumerable<string> resourceClaimActionNames)
        {
            int requestActionBitValue = _actionBitValueProvider.GetBitValue(requestAction);

            // Determine if any of the claim actions can satisfy the requested action
            return resourceClaimActionNames.Any(x => (requestActionBitValue & _actionBitValueProvider.GetBitValue(x)) != 0);
        }
    }
}

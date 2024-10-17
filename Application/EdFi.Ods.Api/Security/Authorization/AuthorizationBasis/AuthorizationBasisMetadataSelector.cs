// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Exceptions;
using log4net;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

public class AuthorizationBasisMetadataSelector : IAuthorizationBasisMetadataSelector
{
    private readonly IAuthorizationStrategyResolver _authorizationStrategyResolver;
    private readonly IClaimSetRequestEvaluator _claimSetRequestEvaluator;
    private readonly IRequestEvaluationStrategiesSelector _requestEvaluationStrategiesSelector;
    private readonly IRequestEvaluationValidationRuleSetSelector _requestEvaluationValidationRuleSetSelector;

    private readonly ILog _logger = LogManager.GetLogger(typeof(AuthorizationBasisMetadataSelector));

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizationBasisMetadataSelector"/> class.
    /// </summary>
    /// <param name="authorizationStrategyResolver"></param>
    /// <param name="claimSetRequestEvaluator"></param>
    /// <param name="requestEvaluationStrategiesSelector"></param>
    /// <param name="requestEvaluationValidationRuleSetSelector"></param>
    public AuthorizationBasisMetadataSelector(
        IAuthorizationStrategyResolver authorizationStrategyResolver,
        IClaimSetRequestEvaluator claimSetRequestEvaluator,
        IRequestEvaluationStrategiesSelector requestEvaluationStrategiesSelector,
        IRequestEvaluationValidationRuleSetSelector requestEvaluationValidationRuleSetSelector)
    {
        _authorizationStrategyResolver = authorizationStrategyResolver;
        _claimSetRequestEvaluator = claimSetRequestEvaluator;
        _requestEvaluationStrategiesSelector = requestEvaluationStrategiesSelector;
        _requestEvaluationValidationRuleSetSelector = requestEvaluationValidationRuleSetSelector;
    }

    /// <inheritdoc cref="IAuthorizationBasisMetadataSelector.SelectAuthorizationBasisMetadata" />
    public AuthorizationBasisMetadata SelectAuthorizationBasisMetadata(
        string claimSetName,
        IList<string> requestResourceClaimUris,
        string requestAction)
    {
        // Perform basic claims check (and get relevant security metadata)
        var requestEvaluation = _claimSetRequestEvaluator.EvaluateRequest(claimSetName, requestResourceClaimUris, requestAction);

        if (!requestEvaluation.Success)
        {
            throw requestEvaluation.SecurityException;
        }

        // Get the authorization strategies to apply for this request
        if (!_requestEvaluationStrategiesSelector.TryGetAuthorizationStrategyNames(
                requestEvaluation,
                out var authorizationStrategyNames))
        {
            // No authorization strategies were defined for this request
            throw new SecurityConfigurationException(
                SecurityConfigurationException.DefaultDetail,
                string.Format(
                    "No authorization strategies were defined for the requested action '{0}' against resource URIs ['{1}'] matched by the caller's claim '{2}'.",
                    requestEvaluation.RequestedAction,
                    string.Join("', '", requestEvaluation.RequestedResourceUris),
                    requestEvaluation.ClaimSetResourceClaimLineage.First().ClaimName));
        }

        if (_logger.IsDebugEnabled)
        {
            _logger.Debug(
                $"Authorization strategy '{string.Join("', '", authorizationStrategyNames)}' selected for request against resource '{requestResourceClaimUris.First()}'.");
        }

        string validationRuleSetName = _requestEvaluationValidationRuleSetSelector.GetValidationRuleSetName(requestEvaluation);

        // Set outbound authorization details
        return new AuthorizationBasisMetadata(
            _authorizationStrategyResolver.GetAuthorizationStrategies(authorizationStrategyNames),
            requestEvaluation.ClaimSetResourceClaimLineage.First(),
            validationRuleSetName);
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Security.Claims;
using Autofac.Extras.DynamicProxy;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization;

[Intercept("cache-security")]
public interface IAuthorizationBasisMetadataSelector
{
    /// <summary>
    /// Finds the authorization metadata appropriate for the current request based on the claims, resource, action and context data (if available) in the <see cref="EdFiAuthorizationContext.Data"/>.
    /// </summary>
    AuthorizationBasisMetadata SelectAuthorizationBasisMetadata(
        string claimSetName,
        IList<string> requestResourceClaimUris,
        string requestAction);
}

public class AuthorizationBasisMetadata
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizationBasisMetadata"/> class.
    /// </summary>
    public AuthorizationBasisMetadata(
        IReadOnlyList<IAuthorizationStrategy> authorizationStrategies,
        EdFiResourceClaim relevantClaim,
        string validationRuleSetName)
    {
        AuthorizationStrategies = authorizationStrategies;
        RelevantClaim = relevantClaim;
        ValidationRuleSetName = validationRuleSetName;
    }

    public IReadOnlyList<IAuthorizationStrategy> AuthorizationStrategies { get; }

    public EdFiResourceClaim RelevantClaim { get; }

    public string ValidationRuleSetName { get; }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Security.Claims;

namespace EdFi.Ods.Api.Security.Authorization.AuthorizationBasis;

public interface IAuthorizationContextValidator
{
    void Validate(IList<string> resourceClaimUris, string requestAction);
}

public class AuthorizationContextValidator : IAuthorizationContextValidator
{
    public void Validate(IList<string> resourceClaimUris, string requestAction)
    {
        if (resourceClaimUris == null || resourceClaimUris.All(string.IsNullOrWhiteSpace))
        {
            throw new AuthorizationContextException("Authorization can only be performed if a resource is specified.");
        }

        if (resourceClaimUris.Count > 2)
        {
            throw new AuthorizationContextException($"Unexpected number of Resource URIs found in the authorization context. Expected up to 2, but found {resourceClaimUris.Count}.");
        }

        if (string.IsNullOrEmpty(requestAction))
        {
            throw new AuthorizationContextException("Authorization can only be performed if an action is specified.");
        }
    }
}

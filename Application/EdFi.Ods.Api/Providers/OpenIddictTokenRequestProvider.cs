// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;

namespace EdFi.Ods.Api.Providers;

public class OpenIddictTokenRequestProvider(IApiClientAuthenticator apiClientAuthenticator) : TokenRequestProviderBase(apiClientAuthenticator)
{
    // If this method ends up identical as to ClientCredentialsTokenRequestProvider (i.e. no custom handling is required besides
    // validating the scopes are present as resources) this implementation can be moved back into TokenRequestProviderBase
    public override async Task<AuthenticationResponse> HandleAsync(TokenRequest tokenRequest)
    {
        var authentication = await ValidateAndAuthenticateRequest(tokenRequest);
        if (!authentication.IsSuccessful)
        {
            return new AuthenticationResponse(){ TokenError = authentication.Error };
        }

        // Translate OneRoster scopes if needed
        //Save token
        // Return success response

        throw new NotImplementedException();
    }

    protected override bool HasValidScope(TokenRequest request, ApiClientAuthenticator.AuthenticationResult result, out TokenError error)
    {
        throw new NotImplementedException();

        //Validate scope is either:
        // - null/empty
        // - only a number
        // - a number followed by OneRoster scopes
        // - only OneRoster scopes

        //Validate any requested OneRoster scopes map to resources / claimsets present on client
        //Use configuration to map known OneRoster resources to scopes
    }
}

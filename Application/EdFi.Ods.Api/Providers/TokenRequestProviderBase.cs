// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.Tokens;

namespace EdFi.Ods.Api.Providers;

public abstract class TokenRequestProviderBase(IApiClientAuthenticator apiClientAuthenticator)
{

    protected abstract bool HasValidScope(TokenRequest request, ApiClientAuthenticator.AuthenticationResult result, out TokenError error);

    protected async Task<TokenAuthResult> ValidateAndAuthenticateRequest(TokenRequest tokenRequest)
    {
        if (!RequestIsRequiredGrantType(tokenRequest)) // Only handle the "client_credentials" grant type
        {
            return TokenAuthResult.RequestFailure(new TokenError(TokenErrorType.UnsupportedGrantType));
        }

        if (!HasIdAndSecret(tokenRequest)) // Verify client_id and client_secret are present
        {
            return TokenAuthResult.RequestFailure(new TokenError(TokenErrorType.InvalidRequest));
        }

        var authenticationResult = await apiClientAuthenticator.TryAuthenticateAsync(
            tokenRequest.Client_id,
            tokenRequest.Client_secret);

        if (!authenticationResult.IsAuthenticated)
        {
            return TokenAuthResult.Unauthenticated();
        }

        if (!HasValidScope(tokenRequest, authenticationResult, out var scopeError))
        {
            return TokenAuthResult.RequestFailure(scopeError);
        }

        return TokenAuthResult.Success(authenticationResult);
    }

    private bool RequestIsRequiredGrantType(TokenRequest request) => request.Grant_type.EqualsIgnoreCase("client_credentials");

    private bool HasIdAndSecret(TokenRequest request)
        => !string.IsNullOrEmpty(request.Client_secret) && !string.IsNullOrEmpty(request.Client_id);

    protected class TokenAuthResult
    {
        private TokenAuthResult(bool isSuccessful, ApiClientAuthenticator.AuthenticationResult result, TokenError error)
        {
            Error = error;
            IsSuccessful = isSuccessful;
            Result = result;
        }

        public static TokenAuthResult Success(ApiClientAuthenticator.AuthenticationResult tokenAuthResult) => new(true, tokenAuthResult, null);
        public static TokenAuthResult Unauthenticated() => new(false, null, new TokenError(TokenErrorType.InvalidClient));
        public static TokenAuthResult RequestFailure(TokenError error) => new(false, null, error);

        public bool IsSuccessful { get; }
        public ApiClientAuthenticator.AuthenticationResult Result { get; }
        public TokenError Error { get; }
    }
}

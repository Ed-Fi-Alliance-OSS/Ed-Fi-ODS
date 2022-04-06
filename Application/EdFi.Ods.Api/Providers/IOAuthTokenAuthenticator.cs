// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EdFi.Ods.Api.Providers
{
    /// <summary>
    /// Defines a method for authenticating a bearer token with the authorization scheme supplied in the authorization header.
    /// </summary>
    public interface IOAuthTokenAuthenticator
    {
        /// <summary>
        /// Authenticates the supplied bearer token with authorization scheme.
        /// </summary>
        /// <param name="token">The bearer token value.</param>
        /// <param name="authorizationScheme">The scheme used for authorization.</param>
        /// <returns></returns>
        Task<AuthenticateResult> AuthenticateAsync(string token, string authorizationScheme);
    }
}
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;

namespace EdFi.Common.Security
{
    /// <summary>
    /// Defines a method for obtaining the API client's details from their OAuth bearer access token.
    /// </summary>
    [Intercept("cache-api-client-details")]
    public interface IApiClientDetailsProvider
    {
        /// <summary>
        /// Loads the API client details for the supplied token.
        /// </summary>
        /// <param name="token">The OAuth security token for which API client details should be retrieved.</param>
        /// <returns>A <see cref="ApiClientDetails"/> instance if a matching token is found; otherwise <b>null</b>.</returns>
        /// <remarks>This method is used during token authentication.</remarks>
        Task<ApiClientDetails> GetApiClientDetailsForTokenAsync(string token);
        
        /// <summary>
        /// Loads the API client details for the supplied API client key.
        /// </summary>
        /// <param name="key">The key of the API client for which details should be retrieved.</param>
        /// <returns>A <see cref="ApiClientDetails"/> instance if a matching key is found; otherwise <b>null</b>.</returns>
        /// <remarks>This method is used during API client authentication, returning the secret for verification.</remarks>
        Task<ApiClientDetails> GetApiClientDetailsForKeyAsync(string key);
    }
}

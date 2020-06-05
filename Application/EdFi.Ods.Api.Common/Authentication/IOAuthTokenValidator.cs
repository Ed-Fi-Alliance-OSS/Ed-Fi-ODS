// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;

namespace EdFi.Ods.Api.Common.Authentication
{
    /// <summary>
    /// Defines a method for obtaining the API client's details from their OAuth security token.
    /// </summary>
    public interface IOAuthTokenValidator
    {
        /// <summary>
        /// Gets the API client details for the supplied OAuth security token.
        /// </summary>
        /// <param name="token">The OAuth security token.</param>
        /// <returns>The <see cref="ApiClientDetails"/> associated with the token.</returns>
        Task<ApiClientDetails> GetClientDetailsForTokenAsync(string token);
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.Common.Authentication
{
    /// <summary>
    /// Implements a token validator that retrieves the API client's details from the Admin database.
    /// </summary>
    public class OAuthTokenValidator : IOAuthTokenValidator
    {
        private readonly IAccessTokenClientRepo _accessTokenClientRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthTokenValidator"/> class.
        /// </summary>
        /// <param name="accessTokenClientRepo">The access token client repository</param>
        public OAuthTokenValidator(IAccessTokenClientRepo accessTokenClientRepo)
        {
            _accessTokenClientRepo = Preconditions.ThrowIfNull(accessTokenClientRepo, nameof(accessTokenClientRepo));
        }

        /// <summary>
        /// Loads the API client details for the supplied token from the Admin database.
        /// </summary>
        /// <param name="token">The OAuth security token for which API client details should be retrieved.</param>
        /// <returns>A populated <see cref="ApiClientDetails"/> instance.</returns>
        public async Task<ApiClientDetails> GetClientDetailsForTokenAsync(string token)
        {
            if (!Guid.TryParse(token, out Guid tokenAsGuid))
            {
                return new ApiClientDetails();
            }

            // TODO SF ODS-3459: this ought to be running as an independent task, scheduled multiple times a day.
            await _accessTokenClientRepo.DeleteExpiredTokensAsync();

            var clientForToken = await _accessTokenClientRepo.GetClientForTokenAsync(tokenAsGuid);

            return ApiClientDetails.Create(clientForToken);
        }

    }
}

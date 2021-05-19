// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;

namespace EdFi.Admin.DataAccess.Repositories
{
    public interface IAccessTokenClientRepo
    {
        Task<IReadOnlyList<OAuthTokenClient>> GetClientForTokenAsync(Guid accessToken);

        Task DeleteExpiredTokensAsync();

        ClientAccessToken AddClientAccessToken(int apiClientId, string tokenRequestScope = null);

        Task<ClientAccessToken> AddClientAccessTokenAsync(int apiClientId, string tokenRequestScope = null);
    }
}

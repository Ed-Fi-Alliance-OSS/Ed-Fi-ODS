// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Castle.MicroKernel.Lifestyle.Scoped;
using EdFi.Admin.DataAccess.Models;

namespace EdFi.Ods.Api.Services.Authentication.ClientCredentials
{
    public class TokenResponse
    {
        public string Access_token { get; private set; }

        public int? Expires_in { get; private set; }

        public string Token_type => "bearer";

        public string Scope { get; private set; }

        public void SetToken(ClientAccessToken token)
        {
            Access_token = token.Id.ToString("N");
            Expires_in = (int) token.Duration.TotalSeconds;
            Scope = token.Scope;
        }
    }
}

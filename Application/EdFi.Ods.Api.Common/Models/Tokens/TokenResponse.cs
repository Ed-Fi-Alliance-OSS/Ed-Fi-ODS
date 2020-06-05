// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.Models.Tokens
{
    public class TokenResponse
    {
        public string Access_token { get; private set; }

        public int? Expires_in { get; private set; }

        public string Token_type
        {
            get => "bearer";
        }

        public string Scope { get; private set; }

        public void SetToken(Guid tokenId, int expiresIn, string scope)
        {
            Access_token = tokenId.ToString("N");
            Expires_in = expiresIn;
            Scope = scope;
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Ods.Api.Models.Tokens;

namespace EdFi.Ods.Api.Models.ClientCredentials
{
    public class AuthenticationResponse
    {
        public TokenError TokenError { get; set; }

        public TokenResponse TokenResponse { get; set; }
    }
}
#endif

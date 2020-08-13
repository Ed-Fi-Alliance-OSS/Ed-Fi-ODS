﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Threading.Tasks;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;

namespace EdFi.Ods.Api.Providers
{
    public interface ITokenRequestProvider
    {
        Task<AuthenticationResponse> HandleAsync(TokenRequest tokenRequest);
    }
}
#endif
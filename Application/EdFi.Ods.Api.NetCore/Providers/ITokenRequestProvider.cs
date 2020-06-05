// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.NetCore.Models.ClientCredentials;

namespace EdFi.Ods.Api.NetCore.Providers
{
    public interface ITokenRequestProvider
    {
        Task<AuthenticationResponse> HandleAsync(TokenRequest tokenRequest);
    }
}

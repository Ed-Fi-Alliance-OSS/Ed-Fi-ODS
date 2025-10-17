// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using OpenIddict.Abstractions;
using OpenIddict.Server;

namespace EdFi.Ods.Api.Security.Jwt;

public class ValidateTokenHandler(ApiSettings config) : IOpenIddictServerHandler<OpenIddictServerEvents.ValidateTokenRequestContext>
{
    private readonly OpenIddictSettings _config = config.Services.OpenIddict;
    public ValueTask HandleAsync(OpenIddictServerEvents.ValidateTokenRequestContext context)
    {
        if (!string.Equals(context.ClientId, _config.ClientId, StringComparison.Ordinal))
        {
            context.Reject(
                error: OpenIddictConstants.Errors.InvalidClient,
                description: "The specified 'client_id' doesn't match a known Client ID.");
        }
        return default;
    }
}

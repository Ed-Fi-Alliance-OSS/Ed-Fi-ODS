// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Security.Claims;
using EdFi.Ods.Common.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server;

namespace EdFi.Ods.Api.Security.Jwt;

public static class OpenIddictServerServiceExtensions
{
    public static OpenIddictBuilder Configure(this OpenIddictBuilder builder, ApiSettings config)
    {
        builder.AddCore(options => { });

        builder.AddServer(options =>
        {
            options.EnableDegradedMode();
            options.SetTokenEndpointUris("connect/token");

            options.AllowClientCredentialsFlow();

            options.AddDevelopmentEncryptionCertificate();
            options.AddDevelopmentSigningCertificate();

            options.AddEventHandler<OpenIddictServerEvents.ValidateTokenRequestContext>(builder =>
                builder.UseScopedHandler<ValidateTokenHandler>());

            options.AddEventHandler<OpenIddictServerEvents.HandleTokenRequestContext>(builder =>
                builder.UseInlineHandler(context =>
                {
                    var identity = new ClaimsIdentity(
                        TokenValidationParameters.DefaultAuthenticationType, OpenIddictConstants.Claims.Name,
                        OpenIddictConstants.Claims.Role);

                    var cp = new ClaimsPrincipal(identity);
                    cp.SetScopes(context.Request.GetScopes());

                    context.Principal = cp;

                    return default;
                }));

            options.UseAspNetCore().EnableTokenEndpointPassthrough();
        });

        builder.AddValidation(options =>
        {
            options.UseLocalServer();
            options.UseAspNetCore();
        });

        return builder;
    }
}

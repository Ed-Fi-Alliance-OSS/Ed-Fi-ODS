// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.Api.Middleware
{
    public class EdFiApiAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        
        private readonly IApiKeyContextProvider _apiKeyContextProvider;

        public EdFiApiAuthenticationMiddleware(RequestDelegate next, IAuthenticationSchemeProvider schemes,
            IApiKeyContextProvider apiKeyContextProvider)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            
            if (schemes == null)
            {
                throw new ArgumentNullException(nameof(schemes));
            }

            _next = next;
            _apiKeyContextProvider = apiKeyContextProvider;
            
            Schemes = schemes;
        }

        public IAuthenticationSchemeProvider Schemes { get; set; }

        public async Task Invoke(HttpContext context)
        {
            context.Features.Set<IAuthenticationFeature>(new AuthenticationFeature
            {
                OriginalPath = context.Request.Path,
                OriginalPathBase = context.Request.PathBase
            });

            // Give any IAuthenticationRequestHandler schemes a chance to handle the request
            var handlers = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            foreach (var scheme in await Schemes.GetRequestHandlerSchemesAsync())
            {
                var handler = await handlers.GetHandlerAsync(context, scheme.Name) as IAuthenticationRequestHandler;
                if (handler != null && await handler.HandleRequestAsync())
                {
                    return;
                }
            }

            var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                var result = await context.AuthenticateAsync(defaultAuthenticate.Name);
                if (result?.Principal != null)
                {
                    context.User = result.Principal;
                    
                    _apiKeyContextProvider.SetApiKeyContext((ApiKeyContext) result.Ticket.Properties.Parameters["ApiKeyContext"]);
                }
            }

            await _next(context);
        }
    }
}

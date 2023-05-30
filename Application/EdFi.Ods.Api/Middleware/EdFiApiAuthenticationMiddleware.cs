// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Common.Security;
using log4net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EdFi.Ods.Api.Middleware
{
    public class EdFiApiAuthenticationMiddleware
    {
        private readonly IApiClientContextProvider _apiClientContextProvider;
        private readonly RequestDelegate _next;

        public EdFiApiAuthenticationMiddleware(RequestDelegate next, IAuthenticationSchemeProvider schemes,
            IApiClientContextProvider apiClientContextProvider)
        {
            if (schemes != null)
            {
                _next = next ?? throw new ArgumentNullException(nameof(next));
                _apiClientContextProvider = apiClientContextProvider;

                Schemes = schemes;
            }
            else
            {
                throw new ArgumentNullException(nameof(schemes));
            }
        }

        public IAuthenticationSchemeProvider Schemes { get; set; }

        public async Task Invoke(HttpContext context)
        {
            context.Features.Set<IAuthenticationFeature>(
                new AuthenticationFeature
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

                    // NOTE: For our use case we set the api key context into the call context storage. The rest of this code
                    // is the default implementation and may need to be update on version updates.
                    // see https://github.com/dotnet/aspnetcore/blob/v3.1.9/src/Security/Authentication/Core/src/AuthenticationMiddleware.cs
                    var apiClientContext = (ApiClientContext)result.Ticket.Properties.Parameters["ApiClientContext"];
                    _apiClientContextProvider.SetApiClientContext(apiClientContext);
                    LogicalThreadContext.Properties["ApiClientId"] = apiClientContext.ApiClientId;
                }
            }

            await _next(context);
        }
    }
}

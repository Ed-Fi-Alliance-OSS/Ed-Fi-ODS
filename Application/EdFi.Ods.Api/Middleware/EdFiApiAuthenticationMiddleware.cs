// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
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
        private readonly ILogContextAccessor _logContextAccessor;

        public EdFiApiAuthenticationMiddleware(RequestDelegate next,
            IAuthenticationSchemeProvider schemes,
            IApiClientContextProvider apiClientContextProvider,
            ILogContextAccessor logContextAccessor)
        {
            if (schemes != null)
            {
                _next = next ?? throw new ArgumentNullException(nameof(next));
                _apiClientContextProvider = apiClientContextProvider;
                Schemes = schemes;
                _logContextAccessor = logContextAccessor;
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
                    var apiClientContext = (ApiClientContext)result.Ticket.Properties.Parameters[nameof(ApiClientContext)];
                    _apiClientContextProvider.SetApiClientContext(apiClientContext);
                    LogicalThreadContext.Properties[nameof(apiClientContext.ApiClientId)] = apiClientContext.ApiClientId;
                }
                else if (context.Request.Path.StartsWithSegments("/data") ||
                        context.Request.Path.StartsWithSegments("/composites") ||
                        context.Request.Path.StartsWithSegments("/changeQueries"))
                {
                    var problemDetails = GetProblemDetailsExceptionFromResult(result);
                    problemDetails.CorrelationId = _logContextAccessor.GetCorrelationId();;

                    await context.Response.WriteProblemDetailsAsync(problemDetails);

                    return;
                }
            }

            await _next(context);

            EdFiProblemDetailsExceptionBase GetProblemDetailsExceptionFromResult(AuthenticateResult result)
            {
                EdFiProblemDetailsExceptionBase problemDetails;

                if (result.None)
                {
                    problemDetails = new SecurityAuthenticationException("scenario79.");
                }
                else
                {
                    problemDetails = new SecurityAuthenticationException("scenario80.", result.Failure);
                }

                return problemDetails;
            }
        }
    }
}

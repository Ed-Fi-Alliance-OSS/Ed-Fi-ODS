// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class OAuthContentTypeValidationMiddleware : IMiddleware
    {
        private readonly ILogContextAccessor _logContextAccessor;
        public OAuthContentTypeValidationMiddleware(ILogContextAccessor logContextAccessor)
        {
            _logContextAccessor = logContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.ToString().Contains("oauth", StringComparison.OrdinalIgnoreCase) &&
                context.Request.Method == HttpMethods.Post)
            {
                if (!context.Request.Headers.ContainsKey(HeaderConstants.ContentType))
                {
                    var problemDetails = new UnsupportedMediaTypeException(
                        UnsupportedMediaTypeException.DefaultDetail,
                        UnsupportedMediaTypeException.MissingContetTypeErrorText)
                    {
                        CorrelationId = _logContextAccessor.GetCorrelationId()
                    };

                    await context.Response.WriteProblemDetailsAsync(problemDetails);
                    return;
                }
            }

            await next.Invoke(context);
        }
    }
}

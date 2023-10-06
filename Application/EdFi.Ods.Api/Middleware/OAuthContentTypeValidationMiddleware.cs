﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.Middleware
{
    public class OAuthContentTypeValidationMiddleware : IMiddleware
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(OAuthContentTypeValidationMiddleware));

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path.ToString().Contains("oauth", StringComparison.OrdinalIgnoreCase))
            {
                if (!context.Request.Headers.ContainsKey("Content-Type"))
                {
                    context.Response.StatusCode = StatusCodes.Status415UnsupportedMediaType;
                    await context.Response.WriteAsync("Content-Type header is missing.");
                    return;
                }
            }

            await next.Invoke(context);
        }
    }
}

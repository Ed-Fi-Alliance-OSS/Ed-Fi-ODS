// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.NetCore.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;
using EdFi.Ods.Features.OpenApiMetadata.Providers;
using log4net;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Features.Middleware
{
    public class OpenApiMetadataMiddleware : IMiddleware
    {
        private readonly IOpenApiMetadataDocumentProvider _metadataDocumentProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataMiddleware));

        public OpenApiMetadataMiddleware(IOpenApiMetadataDocumentProvider metadataDocumentProvider)
        {
            _metadataDocumentProvider = metadataDocumentProvider;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // if the request is not a get or ends with swagger.json we abort and move to the next pipeline step
            if (context.Request.Method != HttpMethods.Get || !context.Request.Path.ToString().EndsWithIgnoreCase("swagger.json"))
            {
                await next(context);
                return;
            }

            if (!_metadataDocumentProvider.TryGetSwaggerDocument(context.Request, out string document))
            {
                await next(context);
                return;
            }

            if (!string.IsNullOrEmpty(document))
            {
                var etag = HashHelper.GetSha256Hash(document)
                    .ToHexString()
                    .DoubleQuoted();

                if (context.Request.TryGetRequestHeader(HeaderConstants.IfNoneMatch, out string headerValue))
                {
                    if (headerValue.EqualsIgnoreCase(etag))
                    {
                        _logger.Debug($"swagger document was not modified");
                        context.Response.StatusCode = StatusCodes.Status304NotModified;
                        context.Response.ContentType = GetContentType();
                        return;
                    }
                }
                else
                {
                    context.Response.Headers[HeaderConstants.ETag] = etag;
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.ContentType = GetContentType();

                    await context.Response.WriteAsync(document);
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }

            string GetContentType() => "application/json";
        }
    }
}
#endif

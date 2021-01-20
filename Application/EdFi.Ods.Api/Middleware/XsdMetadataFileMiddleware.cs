// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;

namespace EdFi.Ods.Api.Middleware
{
    public class XsdMetadataFileMiddleware : IMiddleware
    {
        private readonly ApiSettings _apiSettings;
        private readonly IAssembliesProvider _assembliesProvider;
        private readonly ConcurrentDictionary<string, EmbeddedFileProvider> _embeddedFileProviderByAssemblyName =
            new ConcurrentDictionary<string, EmbeddedFileProvider>(StringComparer.InvariantCultureIgnoreCase);
        private readonly IXsdFileInformationProvider _xsdFileInformationProvider;

        public XsdMetadataFileMiddleware(IXsdFileInformationProvider xsdFileInformationProvider,
            IAssembliesProvider assembliesProvider,
            ApiSettings apiSettings)
        {
            _xsdFileInformationProvider = xsdFileInformationProvider;
            _assembliesProvider = assembliesProvider;
            _apiSettings = apiSettings;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Method != HttpMethods.Get)
            {
                await next(context);
                return;
            }

            var routeMatcher = new RouteMatcher();

            if (!routeMatcher.TryMatch(CreateRouteTemplate(), context.Request.Path, out RouteValueDictionary routeValues))
            {
                await next(context);
                return;
            }

            var schema = routeValues["schema"].ToString();

            var xsdFileInformationByUriSegment = _xsdFileInformationProvider.XsdFileInformationByUriSegment(schema);

            if (xsdFileInformationByUriSegment == default)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            string assemblyName = xsdFileInformationByUriSegment.AssemblyName;
            string fullQualifiedFileName = $"Artifacts/Schemas/{routeValues["file"]}.xsd";

            var embeddedFileProvider = _embeddedFileProviderByAssemblyName.GetOrAdd(
                assemblyName, key => new EmbeddedFileProvider(_assembliesProvider.Get(assemblyName)));

            context.Response.ContentType = "application/xml";
            context.Response.StatusCode = StatusCodes.Status200OK;

            await context.Response.SendFileAsync(embeddedFileProvider.GetFileInfo(fullQualifiedFileName));

            string CreateRouteTemplate()
            {
                string template = $"metadata/";

                if (_apiSettings.GetApiMode() == ApiMode.YearSpecific)
                {
                    template += RouteConstants.SchoolYearFromRoute;
                }

                if (_apiSettings.GetApiMode() == ApiMode.InstanceYearSpecific)
                {
                    template += RouteConstants.InstanceIdFromRoute;
                    template += RouteConstants.SchoolYearFromRoute;
                }

                return template + "xsd/{schema}/{file}.xsd";
            }
        }
    }
}

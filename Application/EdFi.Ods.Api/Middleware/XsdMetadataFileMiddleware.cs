// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EdFi.Ods.Api.Middleware
{
    public class XsdMetadataFileMiddleware : IMiddleware
    {
        private readonly ApiSettings _apiSettings;
        private readonly IEmbeddedFileProvider _embeddedFileProvider;
        private readonly IXsdFileInformationProvider _xsdFileInformationProvider;

        public XsdMetadataFileMiddleware(IXsdFileInformationProvider xsdFileInformationProvider,
            IEmbeddedFileProvider embeddedFileProvider,
            ApiSettings apiSettings)
        {
            _xsdFileInformationProvider = xsdFileInformationProvider;
            _embeddedFileProvider = embeddedFileProvider;
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

            var xsdFileInformationByUriSegment = _xsdFileInformationProvider.XsdFileInformationByUriSegment();

            if (!xsdFileInformationByUriSegment.ContainsKey(schema))
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            string assemblyName = xsdFileInformationByUriSegment[schema].AssemblyName;
            string fullQualifiedFileName = $"{assemblyName}.Artifacts.Schemas.{routeValues["file"]}.xsd";

            context.Response.ContentType = "application/xml";
            context.Response.StatusCode = StatusCodes.Status200OK;

            await context.Response.WriteAsync(_embeddedFileProvider.File(assemblyName, fullQualifiedFileName));

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

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NetCore.Extensions;
using EdFi.Ods.Api.NetCore.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class EnabledOpenApiMetadataDocumentProvider : IOpenApiMetadataDocumentProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EnabledOpenApiMetadataDocumentProvider));

        private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
        private readonly IList<IOpenApiMetadataRouteInformation> _routeInformations;
        private readonly bool _useReverseProxyHeaders;
        private readonly Lazy<IReadOnlyList<SchemaNameMap>> _schemaNameMaps;

        public EnabledOpenApiMetadataDocumentProvider(
            IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
            IList<IOpenApiMetadataRouteInformation> routeInformations,
            ISchemaNameMapProvider schemaNameMapProvider,
            ApiSettings apiSettings)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            _routeInformations = routeInformations;
            _useReverseProxyHeaders = apiSettings.UseReverseProxyHeaders.HasValue && apiSettings.UseReverseProxyHeaders.Value;

            _schemaNameMaps = new Lazy<IReadOnlyList<SchemaNameMap>>(schemaNameMapProvider.GetSchemaNameMaps);
        }

        public bool TryGetSwaggerDocument(HttpRequest request, out string document)
        {
            document = null;

            var openApiMetadataRequest = CreateOpenApiMetadataRequest(request.Path);

            var openApiContent = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(openApiMetadataRequest.GetFeedName());

            if (openApiContent == null)
            {
                _logger.Debug($"Unable to locate swagger document for {openApiMetadataRequest.GetFeedName()}");
                return false;
            }

            document = GetMetadataForContent(openApiContent, request);

            return true;
        }

        private string GetMetadataForContent(OpenApiContent content, HttpRequest request)
        {
            string basePath = request.PathBase.Value.EnsureSuffixApplied("/") + content.BasePath;

            return content.Metadata
                .Replace("%HOST%", Host())
                .Replace("%TOKEN_URL%", TokenUrl())
                .Replace("%BASE_PATH%", basePath);

            string TokenUrl() => $"{request.RootUrl(_useReverseProxyHeaders)}/oauth/token";

            string Host() => $"{request.Host(_useReverseProxyHeaders)}:{request.Port(_useReverseProxyHeaders)}";
        }

        private OpenApiMetadataRequest CreateOpenApiMetadataRequest(string path)
        {
            // need to build the request model manually as binding does not exist in the middleware pipeline.
            // this is less effort that rewriting the open api metadata cache.
            var openApiMetadataRequest = new OpenApiMetadataRequest();

            var matcher = new RouteMatcher();

            foreach (var routeInformation in _routeInformations)
            {
                string routeTemplate = routeInformation.GetRouteInformation()
                    .Template;

                if (matcher.TryMatch(routeTemplate, path, out RouteValueDictionary values))
                {
                    if (values.ContainsKey("document"))
                    {
                        // the route for resources/descriptors is the same format as the schema endpoint.
                        // we need to validate that it is a schema instead.
                        string documentName = values["document"]
                            .ToString();

                        if (_schemaNameMaps.Value.Any(x => x.UriSegment.EqualsIgnoreCase(documentName)))
                        {
                            openApiMetadataRequest.SchemaName = documentName;
                        }

                        if (documentName.EqualsIgnoreCase("resources") || documentName.EqualsIgnoreCase("descriptors"))
                        {
                            openApiMetadataRequest.ResourceType = documentName;
                        }
                    }

                    if (values.ContainsKey("schoolYearFromRoute"))
                    {
                        string schoolYear = values["schoolYearFromRoute"]
                            .ToString();

                        if (int.TryParse(schoolYear, out int schoolYearFromRoute))
                        {
                            openApiMetadataRequest.SchoolYearFromRoute = schoolYearFromRoute;
                        }
                    }

                    if (values.ContainsKey("organizationCode"))
                    {
                        openApiMetadataRequest.SchemaName = values["organizationCode"]
                            .ToString();
                    }

                    if (values.ContainsKey("compositeCategoryName"))
                    {
                        openApiMetadataRequest.CompositeCategoryName = values["compositeCategoryName"]
                            .ToString();
                    }

                    if (values.ContainsKey("other"))
                    {
                        openApiMetadataRequest.OtherName = values["other"]
                            .ToString();
                    }
                }
            }

            return openApiMetadataRequest;
        }
    }
}
#endif

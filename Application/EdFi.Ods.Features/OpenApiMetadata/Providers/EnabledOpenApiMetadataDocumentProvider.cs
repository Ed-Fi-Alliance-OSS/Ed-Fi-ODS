// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers
{
    public class EnabledOpenApiMetadataDocumentProvider : IOpenApiMetadataDocumentProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EnabledOpenApiMetadataDocumentProvider));

        private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
        private readonly IOdsRouteRootTemplateProvider _routeRootTemplateProvider;
        private readonly IList<IOpenApiMetadataRouteInformation> _routeInformations;
        private readonly ReverseProxySettings _reverseProxySettings;
        private readonly Lazy<IReadOnlyList<SchemaNameMap>> _schemaNameMaps;
        private readonly bool _multitenancyEnabled;
        private readonly string _odsContextRoutePath;

        public EnabledOpenApiMetadataDocumentProvider(
            IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
            IList<IOpenApiMetadataRouteInformation> routeInformations,
            ISchemaNameMapProvider schemaNameMapProvider,
            ApiSettings apiSettings,
            IOdsRouteRootTemplateProvider routeRootTemplateProvider)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            _routeInformations = routeInformations;
            this._reverseProxySettings = apiSettings.GetReverseProxySettings();
            _multitenancyEnabled = apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName());
            _schemaNameMaps = new Lazy<IReadOnlyList<SchemaNameMap>>(schemaNameMapProvider.GetSchemaNameMaps);
            _routeRootTemplateProvider = routeRootTemplateProvider;
            _odsContextRoutePath = apiSettings.GetOdsContextRoutePath() ?? string.Empty;
        }

        public bool TryGetSwaggerDocument(HttpRequest request, out string document, bool upcastToV30 = false)
        {
            document = null;

            var openApiMetadataRequest = CreateOpenApiMetadataRequest(request.Path);

            var openApiContent = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(openApiMetadataRequest.GetFeedName());

            if (openApiContent == null)
            {
                _logger.Debug($"Unable to locate swagger document for {openApiMetadataRequest.GetFeedName()}");
                return false;
            }

            document = GetMetadataForContent(openApiContent, request, openApiMetadataRequest.OdsContext, openApiMetadataRequest.InstanceId, openApiMetadataRequest.TenantIdentifierFromRoute);

            if (upcastToV30)
            {
                document = UpcastOasJsonToV3(document);
            }
            return true;
            
            string UpcastOasJsonToV3(string json)
            {
                var openApiDocument = new OpenApiStringReader().Read(json, out _);
                TranformServersConfiguration(ref openApiDocument);
                return openApiDocument.Serialize(OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json);
            }
        }

        private OpenApiDocument TranformServersConfiguration(ref OpenApiDocument openApiDocument)
        {
            var request = new HttpContextAccessor()?.HttpContext?.Request;
            
            openApiDocument.Servers.Clear();

            var rootUrl = request.RootUrl(this._reverseProxySettings);

            openApiDocument.Servers.Add(
                new OpenApiServer()
                {
                    Url = $"{rootUrl}/{{tenant}}/{{schoolYear}}",
                    Variables = new Dictionary<string, OpenApiServerVariable>()
                    {
                        {
                            "tenant", new OpenApiServerVariable()
                            {
                                Enum = new List<string>()
                                {
                                    "tenant1",
                                    "tenant2",
                                    "tenant3"
                                },
                                Default = "tenant1"
                            }
                        },
                        {
                            "schoolYear", new OpenApiServerVariable()
                            {
                                Enum = new List<string>()
                                {
                                    "2020",
                                    "2021",
                                    "2022",
                                    "2023",
                                    "2024"
                                },
                                Default = "2024"
                            }
                        }
                    }
                });

            return openApiDocument;
        }

        private string GetMetadataForContent(OpenApiContent content, HttpRequest request, string odsContextName, string instanceId, string tenantIdentifier)
        {
            var odsContextRouteValue = string.IsNullOrEmpty(odsContextName) ? string.Empty : $"{odsContextName}/";
            var instanceIdRouteValue = string.IsNullOrEmpty(instanceId) ? string.Empty : $"{instanceId}/";
            var tenantIdentifierRouteValue = string.IsNullOrEmpty(tenantIdentifier) ? string.Empty : $"{tenantIdentifier}/";

            string basePath = request.PathBase.Value.EnsureSuffixApplied("/") + tenantIdentifierRouteValue + odsContextRouteValue + content.BasePath.EnsureSuffixApplied("/") + instanceIdRouteValue;
 
            return content.Metadata
                .Replace("%HOST%", Host())
                .Replace("%TOKEN_URL%", TokenUrl())
                .Replace("%BASE_PATH%", basePath)
                .Replace("%SCHEME%", request.Scheme(this._reverseProxySettings));

            string TokenUrl() {
                var rootUrl = request.RootUrl(this._reverseProxySettings);
                return $"{rootUrl}/" + tenantIdentifierRouteValue + odsContextRouteValue + $"{instanceId}oauth/token";
            }

            string Host() => $"{request.Host(this._reverseProxySettings)}:{request.Port(this._reverseProxySettings)}";
        }

        private OpenApiMetadataRequest CreateOpenApiMetadataRequest(string path)
        {
            // need to build the request model manually as binding does not exist in the middleware pipeline.
            // this is less effort that rewriting the open api metadata cache.
            var openApiMetadataRequest = new OpenApiMetadataRequest();

            var odsContextVariableName = _odsContextRoutePath?.TrimStart('{').TrimEnd('}');

            var matcher = new RouteMatcher();

            foreach (var routeInformation in _routeInformations)
            {
                string routeTemplate = routeInformation.GetRouteInformation()
                    .Template;

                if (_multitenancyEnabled || !string.IsNullOrEmpty(_odsContextRoutePath))
                    routeTemplate = _routeRootTemplateProvider.GetOdsRouteRootTemplate() + routeTemplate;

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

                    if (odsContextVariableName != null && values.ContainsKey(odsContextVariableName))
                    {
                        openApiMetadataRequest.OdsContext = values[odsContextVariableName]
                            .ToString();
                    }

                    if (values.ContainsKey("instanceIdFromRoute"))
                    {
                        var instance = values["instanceIdFromRoute"];
                        var instanceId = instance as string;

                        if (!string.IsNullOrEmpty(instanceId))
                        {
                            openApiMetadataRequest.InstanceId = instanceId;
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

                    if (values.ContainsKey("profileName"))
                    {
                        openApiMetadataRequest.ProfileName = values["profileName"]
                            .ToString();
                    }

                    if (values.ContainsKey("other"))
                    {
                        openApiMetadataRequest.OtherName = values["other"]
                            .ToString();
                    }

                    if(values.ContainsKey("tenantIdentifier"))
                    {
                        openApiMetadataRequest.TenantIdentifierFromRoute = values["tenantIdentifier"]                            
                            .ToString();
                    }
                }
            }

            return openApiMetadataRequest;
        }
    }
}

﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Conventions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Routing;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi;

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
            IFeatureManager featureManager,
            ApiSettings apiSettings,
            IOdsRouteRootTemplateProvider routeRootTemplateProvider)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            _routeInformations = routeInformations;
            _reverseProxySettings = apiSettings.GetReverseProxySettings();
            _multitenancyEnabled = featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy);
            _schemaNameMaps = new Lazy<IReadOnlyList<SchemaNameMap>>(schemaNameMapProvider.GetSchemaNameMaps);
            _routeRootTemplateProvider = routeRootTemplateProvider;
            _odsContextRoutePath = apiSettings.GetOdsContextRoutePath() ?? string.Empty;
        }

        public bool TryGetSwaggerDocument(HttpRequest request, out string document, OpenApiSpecVersion openApiSpecVersion)
        {
            document = null;

            var openApiMetadataRequest = CreateOpenApiMetadataRequest(request.Path);

            var openApiContent = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(openApiMetadataRequest.GetFeedName());

            if (openApiContent == null)
            {
                _logger.Debug($"Unable to locate swagger document for {openApiMetadataRequest.GetFeedName()}");
                return false;
            }

            document = GetMetadataForContent(
                openApiContent, request, openApiMetadataRequest.OdsContext, openApiMetadataRequest.InstanceId,
                openApiMetadataRequest.TenantIdentifierFromRoute, openApiSpecVersion);

            return true;
        }

        private string GetMetadataForContent(OpenApiContent content, HttpRequest request, string odsContextName,
            string instanceId, string tenantIdentifier, OpenApiSpecVersion openApiSpecVersion)
        {
            var odsContextRouteValue = string.IsNullOrEmpty(odsContextName)
                ? string.Empty
                : $"{odsContextName}/";

            var instanceIdRouteValue = string.IsNullOrEmpty(instanceId)
                ? string.Empty
                : $"{instanceId}/";

            var tenantIdentifierRouteValue = string.IsNullOrEmpty(tenantIdentifier)
                ? string.Empty
                : $"{tenantIdentifier}/";

            string basePath = request.PathBase.Value.EnsureSuffixApplied("/") + tenantIdentifierRouteValue +
                              odsContextRouteValue + content.BasePath.EnsureSuffixApplied("/") + instanceIdRouteValue;

            string document = content.Metadata(openApiSpecVersion)
                .Replace("%HOST%", Host())
                .Replace("%TOKEN_URL%", TokenUrl())
                .Replace("%BASE_PATH%", basePath)
                .Replace("%SCHEME%", request.Scheme(this._reverseProxySettings));

            document = document.Replace("{apiDataPath}", content.BasePath);

            document = document.Replace("{currentTenant}", openApiSpecVersion == OpenApiSpecVersion.OpenApi3_0
                ? $"{tenantIdentifierRouteValue}"
                : "");

            return document;

            string TokenUrl()
            {
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

                    if (values.ContainsKey("tenantIdentifier"))
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

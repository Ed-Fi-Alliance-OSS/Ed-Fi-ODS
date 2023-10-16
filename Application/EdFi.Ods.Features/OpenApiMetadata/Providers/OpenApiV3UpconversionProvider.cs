// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers;

/// <summary>
/// Provides a mechanism for upconverting an OpenAPI v2 json document to an OpenAPI v3 document while also transforming the servers configuration.
/// </summary>
public class OpenApiV3UpconversionProvider : IOpenApiUpconversionProvider
{
    private readonly ApiSettings _apiSettings;
    private readonly ReverseProxySettings _reverseProxySettings;
    private readonly IEdFiAdminRawOdsInstanceConfigurationDataProvider _IEdFiAdminRawOdsInstanceConfigurationDataProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IOptionsMonitor<TenantsSection> _tenantsConfigurationOptions;

    public OpenApiV3UpconversionProvider(ApiSettings apiSettings,
        IEdFiAdminRawOdsInstanceConfigurationDataProvider IEdFiAdminRawOdsInstanceConfigurationDataProvider,
        IHttpContextAccessor httpContextAccessor,
        IOptionsMonitor<TenantsSection> tenantsConfigurationOptions)
    {
        _apiSettings = apiSettings;
        _reverseProxySettings = apiSettings.GetReverseProxySettings();
        _IEdFiAdminRawOdsInstanceConfigurationDataProvider = IEdFiAdminRawOdsInstanceConfigurationDataProvider;
        _httpContextAccessor = httpContextAccessor;
        _tenantsConfigurationOptions = tenantsConfigurationOptions;
    }

    public string GetUpconvertedOpenApiJson(string openApiJson)
    {
        var openApiDocument = new OpenApiStringReader().Read(openApiJson, out _);
        PopulateServersConfiguration(ref openApiDocument);
        return openApiDocument.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0);
    }

    private void PopulateServersConfiguration(ref OpenApiDocument openApiDocument)
    {
        openApiDocument.Servers.Clear();

        var uriBase =
            $"{_httpContextAccessor.HttpContext?.Request.Scheme(this._reverseProxySettings)}://{_httpContextAccessor.HttpContext?.Request.Host(this._reverseProxySettings)}:{_httpContextAccessor.HttpContext?.Request.Port(this._reverseProxySettings)}";

        var routeContextSegment = "";

        if (!string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
        {
            routeContextSegment = $"/{{{string.Join("}/{", _apiSettings.GetOdsContextRouteTemplateKeys())}}}";
        }

        var odsServer = new OpenApiServer()
        {
            Url = $"{uriBase}{{currentTenant}}{routeContextSegment}/data/v{ApiVersionConstants.Ods}/",
            Variables = new Dictionary<string, OpenApiServerVariable>()
        };

        openApiDocument.Servers.Add(odsServer);

        try
        {
            foreach (var server in openApiDocument.Servers)
            {
                if (!string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
                {
                    foreach (var contextRouteTemplateKey in _apiSettings.GetOdsContextRouteTemplateKeys())
                    {
                        var routeContextValues =
                            _IEdFiAdminRawOdsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(
                                contextRouteTemplateKey);

                        server.Variables.Add(
                            contextRouteTemplateKey,
                            new OpenApiServerVariable()
                            {
                                Enum = routeContextValues
                                    .Result.ToList(),
                                Default = routeContextValues
                                    .Result.ToList().Last()
                            });

                        openApiDocument.Components.SecuritySchemes.Single().Value.Flows.ClientCredentials.TokenUrl = new Uri(
                            $"{uriBase}/{routeContextValues.Result.ToList().Last()}{{currentTenant}}/oauth/token");
                    }
                }
                else
                {
                    openApiDocument.Components.SecuritySchemes.Single().Value.Flows.ClientCredentials.TokenUrl = new Uri(
                        $"{uriBase}{{currentTenant}}/oauth/token");
                }
            }
        }
        catch { }
    }
}

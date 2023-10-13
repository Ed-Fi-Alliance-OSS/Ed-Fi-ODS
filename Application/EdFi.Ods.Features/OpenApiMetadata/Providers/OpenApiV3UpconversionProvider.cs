// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using Autofac.Core.Activators.Delegate;
using Azure.Core.Pipeline;
using EdFi.Admin.DataAccess.Models;
using EdFi.Common.Security;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.MultiTenancy;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.VisualBasic;
using NHibernate.MultiTenancy;

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
        
        if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()))
        {
            foreach (var tenant in _tenantsConfigurationOptions.CurrentValue.Tenants.Keys)
            {
                var odsServer = new OpenApiServer()
                {
                    Url = $"{_httpContextAccessor.HttpContext?.Request.RootUrl(this._reverseProxySettings)}/{tenant}",
                    Variables = new Dictionary<string, OpenApiServerVariable>()
                };

                openApiDocument.Servers.Add(odsServer);
            }
        }
        else
        {
            var odsServer = new OpenApiServer()
            {
                Url = $"{_httpContextAccessor.HttpContext?.Request.RootUrl(this._reverseProxySettings)}",
                Variables = new Dictionary<string, OpenApiServerVariable>()
            };
            openApiDocument.Servers.Add(odsServer);
        }

        if (!string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
        {
            foreach (var contextRouteTemplateKey in _apiSettings.GetOdsContextRouteTemplateKeys())
            {
                try
                {
                    var routeContextValues =
                        _IEdFiAdminRawOdsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(
                            contextRouteTemplateKey);

                    foreach (var server in openApiDocument.Servers)
                    {
                        server.Variables.Add(
                            contextRouteTemplateKey,
                            new OpenApiServerVariable()
                            {
                                Enum = routeContextValues
                                    .Result.ToList()
                            });

                        server.Url = $"{server.Url}/{{{contextRouteTemplateKey}}}";
                    }
                }
                catch { }
            }
        }

        
    }
}

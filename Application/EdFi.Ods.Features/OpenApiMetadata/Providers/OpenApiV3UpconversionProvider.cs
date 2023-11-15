// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Configuration.Sections;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.MultiTenancy;
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
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly ITenantConfigurationMapProvider _tenantConfigurationMapProvider;

    public OpenApiV3UpconversionProvider(ApiSettings apiSettings,
        IEdFiAdminRawOdsInstanceConfigurationDataProvider IEdFiAdminRawOdsInstanceConfigurationDataProvider,
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        IHttpContextAccessor httpContextAccessor,
        ITenantConfigurationMapProvider tenantConfigurationMapProvider = null)
    {
        _apiSettings = apiSettings;
        _reverseProxySettings = apiSettings.GetReverseProxySettings();
        _IEdFiAdminRawOdsInstanceConfigurationDataProvider = IEdFiAdminRawOdsInstanceConfigurationDataProvider;
        _adminDatabaseConnectionStringProvider = adminDatabaseConnectionStringProvider;
        _httpContextAccessor = httpContextAccessor;
        _tenantConfigurationMapProvider = tenantConfigurationMapProvider;
    }

    public string GetUpconvertedOpenApiJson(string openApiJson)
    {
        var openApiDocument = new OpenApiStringReader().Read(openApiJson, out _);
        PopulateServersConfiguration(ref openApiDocument);

        foreach (var securityScheme in openApiDocument.Components.SecuritySchemes)
        {
            var securityRequirement = new OpenApiSecurityRequirement();
            securityScheme.Value.Reference = new OpenApiReference() { Id = securityScheme.Key, Type =  ReferenceType.SecurityScheme};
            securityRequirement.Add(securityScheme.Value, new List<string>());
            openApiDocument.SecurityRequirements.Add(securityRequirement);
        }
        
        return openApiDocument.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0);
    }

    private void PopulateServersConfiguration(ref OpenApiDocument openApiDocument)
    {
        openApiDocument.Servers.Clear();
        openApiDocument.Components.SecuritySchemes.Clear();
        openApiDocument.SecurityRequirements.Clear();

        var baseServerUrl =
            $"{_httpContextAccessor.HttpContext?.Request.Scheme(this._reverseProxySettings)}://{_httpContextAccessor.HttpContext?.Request.Host(this._reverseProxySettings)}:{_httpContextAccessor.HttpContext?.Request.Port(this._reverseProxySettings)}";

        var serverUrl = "";

        if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()) ||
            !string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
        {
            serverUrl = $"{baseServerUrl}/{{ODS Selection}}";
        }
        else
        {
            serverUrl = baseServerUrl;
        }

        var odsServer = new OpenApiServer()
        {
            Url = $"{serverUrl.EnsureSuffixApplied("/")}{{apiDataPath}}",
            Variables = new Dictionary<string, OpenApiServerVariable>()
        };

        IDictionary<string, TenantConfiguration> tenantMap =
            _tenantConfigurationMapProvider?.GetMap() ?? new Dictionary<string, TenantConfiguration>();

        openApiDocument.Servers.Add(odsServer);

        OpenApiServerVariable serverVariable = new OpenApiServerVariable();
        serverVariable.Description = "ODS Selection";

        var odsRouteContextKeys = _apiSettings.GetOdsContextRouteTemplateKeys().ToList();

        foreach (var server in openApiDocument.Servers)
        {
            if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()))
            {
                foreach (var tenantMapEntry in tenantMap)
                {
                    var connectionString = tenantMapEntry.Value.AdminConnectionString;

                    serverVariable.Enum.AddRange(
                        GenerateContextValuePathCombinations(
                            new List<string>() { $"{tenantMapEntry.Key}" }, odsRouteContextKeys.ToList(), connectionString));
                }
            }
            else
            {
                serverVariable.Enum.AddRange(
                    GenerateContextValuePathCombinations(
                        new List<string>() { $"" }, odsRouteContextKeys,
                        _adminDatabaseConnectionStringProvider.GetConnectionString()));
            }

            var routeContextKeys = _apiSettings.GetOdsContextRouteTemplateKeys().ToList();
            
            if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()))
            {
                foreach (KeyValuePair<string, TenantConfiguration> tenant in tenantMap)
                {
                    AddSecurityScheme(ref openApiDocument, routeContextKeys, tenant.Value);
                }
            }
            else
            {
                var singleValidContextValueForEachKey = new List<string>();

                if (routeContextKeys.Count > 0)
                {
                    singleValidContextValueForEachKey.AddRange(
                        routeContextKeys.Select(
                            routeContextKey => _IEdFiAdminRawOdsInstanceConfigurationDataProvider
                                .GetDistinctOdsInstanceContextValuesAsync(routeContextKey).Result.First()));
                }

                AddSecurityScheme(ref openApiDocument, singleValidContextValueForEachKey);
            }

            serverVariable.Default = serverVariable.Enum.FirstOrDefault() ?? "";

            if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()) ||
                !string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
            {
                server.Variables.Add("ODS Selection", serverVariable);
            }
        }

        return;

        // Recursively adds all combinations of valid route context values to the end of the strings in currentEnumValues
        List<string> GenerateContextValuePathCombinations(List<string> currentEnumValues, List<string> routeContextKeys, string adminConnectionString)
        {
            var currentRouteContextKey = routeContextKeys.FirstOrDefault();

            if (currentRouteContextKey is null)
            {
                return currentEnumValues;
            }

            var routeContextValuesForKey =
                _IEdFiAdminRawOdsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(
                    currentRouteContextKey, adminConnectionString).Result;

            List<string> newEnumValues = (from routeContextValue in routeContextValuesForKey
                from enumValue in currentEnumValues
                select $"{enumValue}/{routeContextValue}").ToList();

            routeContextKeys.Remove(currentRouteContextKey);

            return routeContextKeys.Count > 0
                ? GenerateContextValuePathCombinations(newEnumValues, routeContextKeys, adminConnectionString)
                : newEnumValues;
        }

        void AddSecurityScheme(ref OpenApiDocument openApiDocument, List<string> validRouteContextKeyValues,
            TenantConfiguration tenant = null)
        {
            var routeContextValueSegment = "";

            if (validRouteContextKeyValues.Count > 0)
            {
                routeContextValueSegment = string.Join(
                    '/',
                    validRouteContextKeyValues.Select(
                        routeContextKey => _IEdFiAdminRawOdsInstanceConfigurationDataProvider
                            .GetDistinctOdsInstanceContextValuesAsync(routeContextKey, tenant?.AdminConnectionString).Result
                            .FirstOrDefault() ?? "")).EnsureSuffixApplied("/");
            }

            string tenantSegment = tenant is null
                ? ""
                : $"{tenant.TenantIdentifier}/";

            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme();

            securityScheme.Type = SecuritySchemeType.OAuth2;
            securityScheme.Description = "Ed-Fi ODS/API OAuth 2.0 Client Credentials Grant Type authorization";

            securityScheme.Flows = new OpenApiOAuthFlows()
            {
                ClientCredentials = new OpenApiOAuthFlow
                {
                    TokenUrl = new Uri($"{baseServerUrl}/{tenantSegment}{routeContextValueSegment}oauth/token")
                }
            };

            var tenantOauthSegment = tenant is null ? "" : $"{tenant.TenantIdentifier}_";
            securityScheme.Name = $"{tenantOauthSegment}oauth2_client_credentials";
            openApiDocument.Components.SecuritySchemes.Add($"{tenantOauthSegment}oauth2_client_credentials", securityScheme);
        }
    }
}

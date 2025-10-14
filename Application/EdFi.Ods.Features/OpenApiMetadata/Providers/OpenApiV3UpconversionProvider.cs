// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;
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
    private readonly IFeatureManager _featureManager;
    private readonly ApiSettings _apiSettings;
    private readonly ReverseProxySettings _reverseProxySettings;
    private readonly IEdFiAdminRawOdsInstanceConfigurationDataProvider _IEdFiAdminRawOdsInstanceConfigurationDataProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAdminDatabaseConnectionStringProvider _adminDatabaseConnectionStringProvider;
    private readonly ITenantConfigurationMapProvider _tenantConfigurationMapProvider;

    public OpenApiV3UpconversionProvider(
        IFeatureManager featureManager,
        ApiSettings apiSettings,
        IEdFiAdminRawOdsInstanceConfigurationDataProvider IEdFiAdminRawOdsInstanceConfigurationDataProvider,
        IAdminDatabaseConnectionStringProvider adminDatabaseConnectionStringProvider,
        IHttpContextAccessor httpContextAccessor,
        ITenantConfigurationMapProvider tenantConfigurationMapProvider = null)
    {
        _featureManager = featureManager;
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
        openApiDocument.Servers.Clear();
        openApiDocument.Components.SecuritySchemes.Clear();
        openApiDocument.SecurityRequirements.Clear();

        // Configure OpenAPI Servers array
        var baseServerUrl = $"{_httpContextAccessor.HttpContext?.Request.Scheme(this._reverseProxySettings)}://{_httpContextAccessor.HttpContext?.Request.Host(this._reverseProxySettings)}:{_httpContextAccessor.HttpContext?.Request.Port(this._reverseProxySettings)}{_httpContextAccessor.HttpContext?.Request.PathBase}";
        var serverUrl = "";

        if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy) || !string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
        {
            serverUrl = $"{baseServerUrl}/{{{GetTenantContextTitle()}}}";
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

        IDictionary<string, TenantConfiguration> tenantMap = _tenantConfigurationMapProvider?.GetMap() ?? new Dictionary<string, TenantConfiguration>();
        
        OpenApiServerVariable serverVariable = new OpenApiServerVariable { Description = GetTenantContextTitle(), Enum = new() };
        openApiDocument.Servers.Add(odsServer);

        var odsRouteContextKeys = _apiSettings.GetOdsContextRouteTemplateKeys().ToList();

        foreach (var server in openApiDocument.Servers)
        {
            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
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
            
            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                foreach (KeyValuePair<string, TenantConfiguration> tenant in tenantMap)
                {
                    AddSecurityScheme(routeContextKeys, tenant.Value);
                }
            }
            else
            {
                AddSecurityScheme(routeContextKeys);
            }

            serverVariable.Default = serverVariable.Enum.FirstOrDefault() ?? "";

            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy) ||
                !string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
            {
                server.Variables.Add(GetTenantContextTitle(), serverVariable);
            }
        }
        
        // Configure OpenAPI SecuritySchemes array
        foreach (KeyValuePair<string, OpenApiSecurityScheme> securityScheme in openApiDocument.Components.SecuritySchemes)
        {
            var securityRequirement = new OpenApiSecurityRequirement();
            securityScheme.Value.Reference = new OpenApiReference() { Id = securityScheme.Key, Type =  ReferenceType.SecurityScheme};
            securityRequirement.Add(securityScheme.Value, new List<string>());
            openApiDocument.SecurityRequirements.Add(securityRequirement);
        }
        
        // Remove response content content-types to all responses for each path object on GET requests.
        // This is necessary because the OpenAPI v2 spec does not support multiple content-types per response,
        // and the process defaults to application/json for all non-200 responses.
        foreach (var path in openApiDocument.Paths)
        {
            foreach (var operation in path.Value.Operations)
            {
                OpenApiResponses newResponses = new OpenApiResponses();

                // Replace all responses except 500, 400, 409, and 200 with new responses having no content-type set
                foreach (KeyValuePair<string, OpenApiResponse> response in operation.Value.Responses.Where(
                             r => r.Key != "500" && r.Key != "200" && r.Key != "400" && r.Key != "409"))
                {
                    response.Value.Content.Clear();
                }
            }
        }

        return openApiDocument.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0);

        // Recursively adds all combinations of valid route context values to the end of the strings in currentEnumValues
        List<string> GenerateContextValuePathCombinations(List<string> currentEnumValues, List<string> routeContextKeys, string adminConnectionString)
        {
            var currentRouteContextKey = routeContextKeys.FirstOrDefault();

            var routeContextValuesForKey =
                _IEdFiAdminRawOdsInstanceConfigurationDataProvider.GetDistinctOdsInstanceContextValuesAsync(
                    currentRouteContextKey, adminConnectionString).Result.ToList();

            if (!routeContextValuesForKey.Any())
            {
                routeContextValuesForKey.Add("");
            }
            
            List<string> newEnumValues = (from routeContextValue in routeContextValuesForKey
                from enumValue in currentEnumValues
                select $"{enumValue}/{routeContextValue}").ToList();

            routeContextKeys.Remove(currentRouteContextKey);

            return routeContextKeys.Count > 0
                ? GenerateContextValuePathCombinations(newEnumValues, routeContextKeys, adminConnectionString)
                : newEnumValues.Select(x => x.Trim('/')).ToList();
        }

        void AddSecurityScheme(List<string> validRouteContextKeys,
            TenantConfiguration tenant = null)
        {
            var routeContextValueSegment = "";

            if (validRouteContextKeys.Count > 0)
            {
                routeContextValueSegment = string.Join(
                    '/',
                    validRouteContextKeys.Select(
                        routeContextKey => _IEdFiAdminRawOdsInstanceConfigurationDataProvider
                            .GetDistinctOdsInstanceContextValuesAsync(routeContextKey, tenant?.AdminConnectionString).Result
                            .FirstOrDefault() ?? "")).EnsureSuffixApplied("/");
            }

            string tenantSegment = tenant is null
                ? ""
                : $"{tenant.TenantIdentifier}/";

            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme { Type = SecuritySchemeType.OAuth2,
                Description = "Ed-Fi ODS/API OAuth 2.0 Client Credentials Grant Type authorization",
                Flows = new OpenApiOAuthFlows()
                {
                    ClientCredentials = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri($"{baseServerUrl}/{tenantSegment}{routeContextValueSegment}oauth/token")
                    }
                }
            };

            var tenantOauthSegment = tenant is null ? "" : $"{tenant.TenantIdentifier}_";
            securityScheme.Name = $"{tenantOauthSegment}oauth2_client_credentials";
            openApiDocument.Components.SecuritySchemes.Add($"{tenantOauthSegment}oauth2_client_credentials", securityScheme);
        }

        string GetTenantContextTitle()
        {
            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy) &&
                !string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
            {
                return "Tenant/Context Selection";
            }

            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                return "Tenant Selection";
            }

            return "Context Selection";
        }
    }
}

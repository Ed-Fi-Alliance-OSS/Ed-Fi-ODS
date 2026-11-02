// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using EdFi.Admin.DataAccess.Providers;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Configuration;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.FeatureManagement;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Writers;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;

namespace EdFi.Ods.Features.OpenApiMetadata.Providers;

/// <summary>
/// Provides a mechanism for upconverting an OpenAPI v2 json document to an OpenAPI v3 document while also transforming the servers configuration.
/// </summary>
public class OpenApiV3UpconversionProvider : IOpenApiUpconversionProvider
{
    private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiV3UpconversionProvider));
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
        // Updated for Microsoft.OpenApi v2.x - Read now returns ReadResult
        var readResult = new OpenApiStringReader().Read(openApiJson, out var diagnostic);
        var openApiDocument = readResult;

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
        var unavailableTenantIdentifiers = new List<string>();

        foreach (var server in openApiDocument.Servers)
        {
            var routeContextKeys = _apiSettings.GetOdsContextRouteTemplateKeys().ToList();

            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                foreach (var tenantMapEntry in tenantMap)
                {
                    // A tenant whose admin database is not available is left out so it does not break the document for
                    // every other tenant. Nothing is added for the tenant until all of its lookups succeed:
                    // AddSecurityScheme runs its lookups before it adds the scheme, and it must stay before Enum.AddRange.
                    try
                    {
                        var tenantContextValuePaths = GenerateContextValuePathCombinations(
                            new List<string> { tenantMapEntry.Key }, odsRouteContextKeys.ToList(),
                            tenantMapEntry.Value.AdminConnectionString);

                        AddSecurityScheme(routeContextKeys, tenantMapEntry.Value);
                        serverVariable.Enum.AddRange(tenantContextValuePaths);
                    }
                    catch (Exception exception) when (TryGetDatabaseException(exception, out var databaseException))
                    {
                        unavailableTenantIdentifiers.Add(tenantMapEntry.Key);

                        _logger.Warn(
                            $"Tenant '{tenantMapEntry.Key}' was omitted from the OpenAPI metadata because its admin database is not available: {databaseException.Message}",
                            databaseException);
                    }
                }
            }
            else
            {
                serverVariable.Enum.AddRange(
                    GenerateContextValuePathCombinations(
                        new List<string>() { $"" }, odsRouteContextKeys,
                        _adminDatabaseConnectionStringProvider.GetConnectionString()));

                AddSecurityScheme(routeContextKeys);
            }

            serverVariable.Default = serverVariable.Enum.FirstOrDefault() ?? "";

            if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy) ||
                !string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
            {
                server.Variables.Add(GetTenantContextTitle(), serverVariable);
            }
        }

        // Tell consumers which tenants are missing from this document; the admin database errors stay in the server log only
        if (unavailableTenantIdentifiers.Any())
        {
            openApiDocument.Info.Description += CreateUnavailableTenantsNotice(
                unavailableTenantIdentifiers, tenantMap.Count, GetTenantContextTitle());
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

        // Updated for Microsoft.OpenApi v2.x - SerializeAsJson signature changed
        using var stringWriter = new StringWriter();
        var jsonWriter = new OpenApiJsonWriter(stringWriter);
        openApiDocument.SerializeAsV3(jsonWriter);
        return stringWriter.ToString();

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

    private static bool TryGetDatabaseException(Exception exception, out DbException databaseException)
    {
        // The admin database lookups are read synchronously with .Result, so the provider exception arrives wrapped
        // in an AggregateException
        databaseException = exception switch
        {
            AggregateException aggregateException =>
                aggregateException.Flatten().InnerExceptions.OfType<DbException>().FirstOrDefault(),
            DbException providerException => providerException,
            _ => null
        };

        return databaseException != null;
    }

    private static string CreateUnavailableTenantsNotice(
        IReadOnlyCollection<string> unavailableTenantIdentifiers,
        int configuredTenantCount,
        string tenantSelectionTitle)
    {
        var tenantList = string.Join(", ", unavailableTenantIdentifiers);

        if (unavailableTenantIdentifiers.Count == configuredTenantCount)
        {
            return $"\n > **No tenants are available:** {tenantList}. "
                + "Their configuration database could not be reached when this documentation was generated (for example, during database maintenance). "
                + "Requests sent from this page will fail until they are restored. "
                + "Contact the API administrator. \n***\n";
        }

        return $"\n > **Unavailable tenants:** {tenantList}. "
            + "These tenants are configured in this API, but their configuration database could not be reached when this documentation was generated (for example, during database maintenance), "
            + $"so they are not listed under {tenantSelectionTitle} or in the Authorize dialog. "
            + "This documentation is refreshed periodically. "
            + "If you use one of these tenants, contact the API administrator. \n***\n";
    }
}

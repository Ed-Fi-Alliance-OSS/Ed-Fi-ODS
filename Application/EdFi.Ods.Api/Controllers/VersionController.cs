// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    [AllowAnonymous]
    public class VersionController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;
        private readonly IApiVersionProvider _apiVersionProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly ApiSettings _apiSettings;

        public VersionController(
            IDomainModelProvider domainModelProvider,
            IApiVersionProvider apiVersionProvider,
            IFeatureManager featureManager,
            ApiSettings apiSettings)
        {
            _featureManager = Preconditions.ThrowIfNull(featureManager, nameof(featureManager));
            _domainModelProvider = Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            _apiVersionProvider = Preconditions.ThrowIfNull(apiVersionProvider, nameof(apiVersionProvider));
            _apiSettings = Preconditions.ThrowIfNull(apiSettings, nameof(apiSettings));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var content = new VersionResponse(
                _apiVersionProvider.Version,
                _apiVersionProvider.ApplicationName,
                _apiVersionProvider.InformationalVersion,
                _apiVersionProvider.Suite,
                _apiVersionProvider.Build,
                _domainModelProvider.GetDomainModel()
                    .Schemas.Select(s => new DataModelVersion(s.LogicalName, s.Version, s.InformationalVersion))
                    .ToArray(),
                GetUrlsByName());

            return Ok(content);

            Dictionary<string, string> GetUrlsByName()
            {
                var urlsByName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                var rootUrl = Request.RootUrl(_apiSettings.GetReverseProxySettings());

                if (_featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
                {
                    if (HttpContext.Request.RouteValues.TryGetValue("tenantIdentifier", out object tenantIdentifier))
                    {
                        rootUrl = $"{rootUrl}/{tenantIdentifier}";
                    }
                    else
                    {
                        rootUrl = $"{rootUrl}/{{tenantIdentifier}}";
                    }
                }

                if (!string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
                {
                    string odsContextUriTemplatePath = _apiSettings.GetOdsContextRoutePath();
                    string[] odsContextRouteKeys = _apiSettings.GetOdsContextRouteTemplateKeys();

                    // Perform URI template replacements from route values, if available on current request
                    foreach (string odsContextRouteKey in odsContextRouteKeys)
                    {
                        if (HttpContext.Request.RouteValues.TryGetValue(odsContextRouteKey, out object odsContextRouteValue))
                        {
                            odsContextUriTemplatePath = odsContextUriTemplatePath.Replace(
                                $"{{{odsContextRouteKey}}}",
                                (string)odsContextRouteValue);
                        }
                    }

                    rootUrl = $"{rootUrl}/{odsContextUriTemplatePath}";
                }

                if (_featureManager.IsFeatureEnabled(ApiFeature.AggregateDependencies))
                {
                    urlsByName["dependencies"] = $"{rootUrl}/metadata/data/v{ApiVersionConstants.Ods}/dependencies";
                }

                if (_featureManager.IsFeatureEnabled(ApiFeature.OpenApiMetadata))
                {
                    urlsByName["openApiMetadata"] = $"{rootUrl}/metadata/";
                }

                urlsByName["oauth"] = $"{rootUrl}/oauth/token";
                urlsByName["oauthTokenIntrospection"] = $"{rootUrl}/oauth/token_info";

                urlsByName["dataManagementApi"] = $"{rootUrl}/data/v{ApiVersionConstants.Ods}/";

                if (_featureManager.IsFeatureEnabled(ApiFeature.XsdMetadata))
                {
                    urlsByName["xsdMetadata"] = $"{rootUrl}/metadata/xsd";
                }

                if (_featureManager.IsFeatureEnabled(ApiFeature.ChangeQueries))
                {
                    urlsByName["changeQueries"] = $"{rootUrl}/changeQueries/v{ApiVersionConstants.ChangeQuery}/";
                }

                if (_featureManager.IsFeatureEnabled(ApiFeature.Composites))
                {
                    urlsByName["composites"] = $"{rootUrl}/composites/v{ApiVersionConstants.Composite}/";
                }

                if (_featureManager.IsFeatureEnabled(ApiFeature.IdentityManagement))
                {
                    urlsByName["identity"] = $"{rootUrl}/identity/v{ApiVersionConstants.Identity}/";
                }

                if (_featureManager.IsFeatureEnabled(ApiFeature.OneRoster))
                {
                    urlsByName["oneRoster"] = _apiSettings.OneRosterVersionUrl;
                }

                return urlsByName;
            }
        }

        public record VersionResponse(
            string version,
            string applicationName,
            string informationalVersion,
            string suite,
            string build,
            DataModelVersion[] dataModels,
            Dictionary<string, string> urls);

        public record DataModelVersion(string name, string version, string informationalVersion);
    }
}

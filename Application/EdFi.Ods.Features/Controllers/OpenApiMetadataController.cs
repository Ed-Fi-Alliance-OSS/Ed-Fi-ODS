// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    [ApplyOdsRouteRootTemplate]
    [Route("metadata")]
    public class OpenApiMetadataController : ControllerBase
    {
        private readonly bool _isEnabled;
        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataController));
        private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
        private readonly ReverseProxySettings _reverseProxySettings;
        private readonly bool _isOneRosterEnabled;
        private readonly string _oneRosterVersionUrl;

        public OpenApiMetadataController(
            IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
            IFeatureManager featureManager,
            ApiSettings apiSettings)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            _reverseProxySettings = apiSettings.GetReverseProxySettings();
            _isEnabled = featureManager.IsFeatureEnabled(ApiFeature.OpenApiMetadata);
            _isOneRosterEnabled = featureManager.IsFeatureEnabled(ApiFeature.OneRoster);
            _oneRosterVersionUrl = apiSettings.OneRosterVersionUrl;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] OpenApiMetadataSectionRequest request, [FromQuery(Name = "version")] string version = null)
        {
            if (!IsFeatureEnabled())
            {
                return NotFound();
            }
            
            if (Request.Query.ContainsKey("sdk"))
            {
                if (bool.TryParse(Request.Query["sdk"], out bool sdk))
                {
                    request.Sdk = sdk;
                }
            }


            var content = _openApiMetadataCacheProvider.GetAllSectionDocuments(request.Sdk)
                .OrderBy(x => x.Section)
                .ThenBy(x => x.Name)
                .Select(x => GetSwaggerSectionDetailsForCacheItem(x, version == "2" ? OpenApiSpecVersion.OpenApi2_0 : OpenApiSpecVersion.OpenApi3_0))
                .ToList();

            if (_isOneRosterEnabled)
            {
                content.Add(new OpenApiMetadataSectionDetails
                {
                    EndpointUri = $"{_oneRosterVersionUrl}/{OpenApiMetadataDocumentHelper.Json}",
                    Name = "OneRoster",
                    Prefix = "Ed-Fi OneRoster"
                });
            }

            var eTag = HashHelper.GetSha256Hash(JsonConvert.SerializeObject(content))
                .ToHexString()
                .DoubleQuoted();

            if (Request.TryGetRequestHeader(HeaderConstants.IfNoneMatch, out string headerValue))
            {
                if (headerValue.EqualsIgnoreCase(eTag))
                {
                    return StatusCode((int)HttpStatusCode.NotModified);
                }
            }

            Response.GetTypedHeaders().ETag = new EntityTagHeaderValue(eTag);

            return Ok(content);

            OpenApiMetadataSectionDetails GetSwaggerSectionDetailsForCacheItem(OpenApiContent apiContent,
                OpenApiSpecVersion openApiSpecVersion)
            {
                var rootUrl = Request.ResourceUri(this._reverseProxySettings);

                // Construct fully qualified metadata url
                var url =
                    new Uri(
                        new Uri(rootUrl.EnsureSuffixApplied("/")),
                        GetMetadataUrlSegmentForCacheItem(apiContent));

                return new OpenApiMetadataSectionDetails
                {
                    EndpointUri =
                        $"{url.AbsoluteUri.Replace("%7B", "{").Replace("%7D", "}")}{(openApiSpecVersion == OpenApiSpecVersion.OpenApi2_0 ? "?version=2" : "")}",
                    Name = apiContent.Name.NormalizeCompositeTermForDisplay('-')
                        .Replace(" ", "-"),
                    Prefix =
                        apiContent.Section.EqualsIgnoreCase(OpenApiMetadataSections.SwaggerUi)
                            ? string.Empty
                            : apiContent.Section
                };
            }

            string GetMetadataUrlSegmentForCacheItem(OpenApiContent apiContent)
            {
                // 'Other' sections (Identity) do not live under 'ods' as other metadata endpoints do.
                // eg identity/v1/2017/swagger.json,
                // eg identity/v1/swagger.json,
                // SDKgen All
                // eg data/v3/2017/swagger.json,
                // eg data/v3/swagger.json,
                var basePath = GetBasePath(apiContent);

                // Profiles and composites endpoints have an extra url segment (profiles or composites).
                // eg data/v3/2017/profiles/assessment/swagger.json
                // eg data/v3/profiles/assessment/swagger.json
                // eg composites/v1/2017/ed-fi/swagger.json
                // eg composites/v1/ed-fi/assessment/swagger.json
                var relativeSectionUri = string.IsNullOrWhiteSpace(apiContent.RelativeSectionPath)
                    ? string.Empty
                    : apiContent.RelativeSectionPath.EnsureSuffixApplied("/");

                return $"{basePath}/{relativeSectionUri}{OpenApiMetadataDocumentHelper.Json}".ToLowerInvariant();
            }

            string GetBasePath(OpenApiContent apiContent)
            {
                return $"{apiContent.BasePath}";
            }

            bool IsFeatureEnabled()
            {
                if (_isEnabled)
                {
                    return true;
                }

                _logger.Info("Open Api Metadata is disabled.");
                return false;
            }
        }
    }
}

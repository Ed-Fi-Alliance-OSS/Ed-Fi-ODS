// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace EdFi.Ods.Features.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("metadata")]
    [AllowAnonymous]
    public class OpenApiMetadataController : ControllerBase
    {
        private readonly bool _isEnabled;
        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataController));

        private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
        private readonly ReverseProxySettings _reverseProxySettings;

        public OpenApiMetadataController(
            IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
            ApiSettings apiSettings)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            _reverseProxySettings = apiSettings.GetReverseProxySettings();
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.OpenApiMetadata.GetConfigKeyName());
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromRoute] OpenApiMetadataSectionRequest request)
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
                .Select(GetSwaggerSectionDetailsForCacheItem)
                .ToList();

            var eTag = HashHelper.GetSha256Hash(content.ToString())
                .ToHexString()
                .DoubleQuoted();

            if (Request.TryGetRequestHeader(HeaderConstants.IfNoneMatch, out string headerValue))
            {
                if (headerValue.EqualsIgnoreCase(eTag))
                {
                    return StatusCode((int) HttpStatusCode.NotModified);
                }
            }

            Response.GetTypedHeaders().ETag = new EntityTagHeaderValue(eTag);

            return Ok(content);

            OpenApiMetadataSectionDetails GetSwaggerSectionDetailsForCacheItem(OpenApiContent apiContent)
            {
                var rootUrl = Request.RootUrl(this._reverseProxySettings);

                // Construct fully qualified metadata url
                var url =
                    new Uri(
                        new Uri(
                            new Uri(rootUrl.EnsureSuffixApplied("/")),
                            "metadata/"),
                        GetMetadataUrlSegmentForCacheItem(apiContent, request.SchoolYearFromRoute, request.InstanceIdFromRoute));

                return new OpenApiMetadataSectionDetails
                {
                    EndpointUri = url.AbsoluteUri,
                    Name = apiContent.Name.NormalizeCompositeTermForDisplay('-')
                        .Replace(" ", "-"),
                    Prefix =
                        apiContent.Section.EqualsIgnoreCase(OpenApiMetadataSections.SwaggerUi)
                            ? string.Empty
                            : apiContent.Section
                };
            }

            string GetMetadataUrlSegmentForCacheItem(OpenApiContent apiContent, int? schoolYear, string instanceId)
            {
                // 'Other' sections (Identity) do not live under 'ods' as other metadata endpoints do.
                // eg identity/v1/2017/swagger.json,
                // eg identity/v1/swagger.json,
                // SDKgen All
                // eg data/v3/2017/swagger.json,
                // eg data/v3/swagger.json,
                var basePath = GetBasePath(apiContent, schoolYear, instanceId);

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

            string GetBasePath(OpenApiContent apiContent, int? schoolYear, string instanceId)
            {
                string basePath = $"{apiContent.BasePath}";

                if (!string.IsNullOrEmpty(instanceId))
                {
                    basePath += $"/{instanceId}";
                }

                if (schoolYear.HasValue)
                {
                    basePath += $"/{schoolYear.Value}";
                }

                return basePath;
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

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Linq;
using System.Net;
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.NetCore.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("metadata")]
    [AllowAnonymous]
    public class OpenApiMetadataController : ControllerBase
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataController));

        private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
        private readonly bool _useProxyHeaders;
        private readonly bool _isEnabled;

        public OpenApiMetadataController(
            IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
            ApiSettings apiSettings)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            _useProxyHeaders = apiSettings.UseReverseProxyHeaders.HasValue && apiSettings.UseReverseProxyHeaders.Value;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.OpenApiMetadata.GetConfigKeyName());
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery] OpenApiMetadataSectionRequest request)
        {
            if (!IsFeatureEnabled())
            {
                return NotFound();
            }

            var content = _openApiMetadataCacheProvider.GetAllSectionDocuments(request.Sdk)
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

            Response.Headers[HeaderConstants.ETag] = eTag;

            return Ok(content);

            OpenApiMetadataSectionDetails GetSwaggerSectionDetailsForCacheItem(OpenApiContent apiContent)
            {
                // Construct fully qualified metadata url
                var url =
                    new Uri(
                        new Uri(
                            new Uri(Request.RootUrl(_useProxyHeaders).EnsureSuffixApplied("/")),
                            "metadata/"),
                        GetMetadataUrlSegmentForCacheItem(apiContent, request.SchoolYearFromRoute));

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

            string GetMetadataUrlSegmentForCacheItem(OpenApiContent apiContent, int? schoolYear)
            {
                // 'Other' sections (Identity) do not live under 'ods' as other metadata endpoints do.
                // eg identity/v1/2017/swagger.json,
                // eg identity/v1/swagger.json,
                // SDKgen All
                // eg data/v3/2017/swagger.json,
                // eg data/v3/swagger.json,
                var basePath = GetBasePath(apiContent, schoolYear);

                // Profiles and composites endpoints have an extra url segment (profiles or composites).
                // eg data/v3/2017/profiles/assessment/swagger.json
                // eg data/v3/profiles/assessment/swagger.json
                // eg composites/v1/2017/ed-fi/swagger.json
                // eg composites/v1/ed-fi/assessment/swagger.json
                var relativeSectionUri = string.IsNullOrWhiteSpace(apiContent.RelativeSectionPath)
                    ? string.Empty
                    : apiContent.RelativeSectionPath.EnsureSuffixApplied("/");

                return $"{basePath}/{relativeSectionUri}{SwaggerDocumentHelper.SwaggerJson}".ToLowerInvariant();
            }

            string GetBasePath(OpenApiContent apiContent, int? schoolYear)
            {
                string basePath = $"{apiContent.BasePath}";

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
#endif

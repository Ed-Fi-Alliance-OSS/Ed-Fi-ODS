#if NETFRAMEWORK
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security.Helpers;
using EdFi.Ods.Features.OpenApiMetadata.Factories;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using log4net;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.OpenApiMetadata.Controllers
{
    public class OpenApiMetadataController : ApiController
    {
        private const string UseReverseProxyHeadersConfigKey = "UseReverseProxyHeaders";
        private readonly ILog _logger = LogManager.GetLogger(typeof(OpenApiMetadataController));

        private readonly IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
        private readonly bool _useProxyHeaders;

        public OpenApiMetadataController(IOpenApiMetadataCacheProvider openApiMetadataCacheProvider,
                                         IConfigValueProvider configValueProvider)
        {
            _openApiMetadataCacheProvider = openApiMetadataCacheProvider;
            bool tempConfigValue;

            _useProxyHeaders = bool.TryParse(
                                   configValueProvider.GetValue(UseReverseProxyHeadersConfigKey),
                                   out tempConfigValue) && tempConfigValue;
        }

        public HttpResponseMessage Get([FromUri] OpenApiMetadataRequest request)
        {
            _logger.Info($"Looking up document for feedname = {request.GetFeedName()}");

            var openApiContent = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(request.GetFeedName());

            if (openApiContent == null)
            {
                _logger.Warn($"Unable to load swagger document for {request.GetFeedName()}");
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var metadata = GetMetadataForContent(openApiContent, request);

            var etag = new EntityTagHeaderValue(
                HashHelper.GetSha256Hash(metadata)
                          .ToHexString()
                          .DoubleQuoted());

            if (ActionContext.Request.Headers.IfNoneMatch.Contains(etag))
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK)
                         {
                             Headers =
                             {
                                 ETag = etag
                             },
                             Content = new StringContent(metadata)
                         };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(SwaggerDocumentHelper.ContentType);

            return result;
        }

        public HttpResponseMessage GetSections([FromUri] OpenApiMetadataSectionRequest request)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(
                    _openApiMetadataCacheProvider.GetAllSectionDocuments(request.Sdk)
                                                 .Select(x => GetSwaggerSectionDetailsForCacheItem(x, request))));

            var eTag = new EntityTagHeaderValue(HashHelper.GetSha256Hash(content.ToString()).ToHexString().DoubleQuoted());

            if (ActionContext.Request.Headers.IfNoneMatch.Contains(eTag))
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK)
                         {
                             Content = content, Headers =
                             {
                                 ETag = eTag
                             }
                         };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(SwaggerDocumentHelper.ContentType);

            return result;
        }

        private string GetMetadataForContent(OpenApiContent content, OpenApiMetadataRequest request)
        {
            string basePath = Request.VirtualPath()
                                     .EnsureSuffixApplied("/") + GetBasePath(content, request.SchoolYearFromRoute);

            return content.Metadata
                          .Replace("%HOST%", $"{Request.Host(_useProxyHeaders)}:{Request.Port(_useProxyHeaders)}")
                          .Replace("%TOKEN_URL%", TokenUrl())
                          .Replace("%BASE_PATH%", basePath);
        }

        private SwaggerSectionDetails GetSwaggerSectionDetailsForCacheItem(OpenApiContent apiContent,
                                                                           OpenApiMetadataSectionRequest request)
        {
            // Construct fully qualified metadata url
            var url =
                new Uri(
                    new Uri(new Uri(Request.RootUrl(_useProxyHeaders).EnsureSuffixApplied("/")), "metadata/"),
                    GetMetadataUrlSegmentForCacheItem(apiContent, request.SchoolYearFromRoute));

            return new SwaggerSectionDetails
                   {
                       EndpointUri = url.AbsoluteUri, Name = apiContent.Name.NormalizeCompositeTermForDisplay('-').Replace(" ", "-"), Prefix =
                           apiContent.Section.EqualsIgnoreCase(OpenApiMetadataSections.SwaggerUi)
                               ? string.Empty
                               : apiContent.Section
                   };
        }

        private string TokenUrl() => $"{Request.RootUrl(_useProxyHeaders)}/oauth/token";

        private string GetMetadataUrlSegmentForCacheItem(OpenApiContent apiContent, int? schoolYear)
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

        private string GetBasePath(OpenApiContent apiContent, int? schoolYear)
        {
            string basePath = $"{apiContent.BasePath}";

            if (schoolYear.HasValue)
            {
                basePath += $"/{schoolYear.Value}";
            }

            return basePath;
        }
    }
}
#endif
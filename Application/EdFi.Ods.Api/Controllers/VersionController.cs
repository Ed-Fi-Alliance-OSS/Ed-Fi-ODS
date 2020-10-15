// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    [AllowAnonymous]
    public class VersionController : ControllerBase
    {
        private readonly IApiVersionProvider _apiVersionProvider;
        private readonly ISystemDateProvider _systemDateProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly ApiSettings _apiSettings;

        public VersionController(
            IDomainModelProvider domainModelProvider,
            IApiVersionProvider apiVersionProvider,
            ISystemDateProvider systemDateProvider,
            ApiSettings apiSettings)
        {
            _domainModelProvider = Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            _apiVersionProvider = Preconditions.ThrowIfNull(apiVersionProvider, nameof(apiVersionProvider));
            _systemDateProvider = Preconditions.ThrowIfNull(systemDateProvider, nameof(systemDateProvider));
            _apiSettings = Preconditions.ThrowIfNull(apiSettings, nameof(apiSettings));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var dataModels = _domainModelProvider
                .GetDomainModel()
                .Schemas
                .Select(
                    s => new
                    {
                        name = s.LogicalName,
                        version = s.Version
                    })
                .ToArray();

            var exposedUrls = GetUrls();

            var content = new
            {
                version = _apiVersionProvider.Version,
                informationalVersion = _apiVersionProvider.InformationalVersion,
                suite = _apiVersionProvider.Suite,
                build = _apiVersionProvider.Build,
                apiMode = _apiSettings.GetApiMode().DisplayName,
                dataModels = dataModels,
                urls = new
                {
                    openApiMetadata = exposedUrls.MetaDataUrl,
                    dependencies = exposedUrls.DependenciesUrl,
                    oauth = exposedUrls.OauthUrl,
                    dataManagementApi = exposedUrls.ApiUrl,
                }
            };

            return Ok(content);

            ExposedUrls GetUrls()
            {
                var currentYear = _systemDateProvider.GetDate().Year.ToString();

                bool isYearSpecific = _apiSettings.GetApiMode().Equals(ApiMode.YearSpecific);

                bool useReverseProxyHeaders = _apiSettings.UseReverseProxyHeaders ?? false;

                var exposedUrls = new ExposedUrls
                {
                    DependenciesUrl = Request.RootUrl(useReverseProxyHeaders) +
                                      (isYearSpecific
                                          ? $"/metadata/data/v{ApiVersionConstants.Ods}/" + currentYear + "/dependencies"
                                          : $"/metadata/data/v{ApiVersionConstants.Ods}/dependencies"),
                    MetaDataUrl = Request.RootUrl(useReverseProxyHeaders) + "/metadata/" +
                                  (isYearSpecific
                                      ? currentYear
                                      : string.Empty),
                    OauthUrl = Request.RootUrl(useReverseProxyHeaders) + "/oauth/token",
                    ApiUrl = Request.RootUrl(useReverseProxyHeaders) +
                             $"/data/v{ApiVersionConstants.Ods}/" +
                             (isYearSpecific
                                 ? currentYear
                                 : string.Empty)
                };

                return exposedUrls;
            }
        }
    }
}

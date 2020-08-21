// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Http.Extensions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Services.Controllers
{
    public class VersionController : ApiController
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IApiVersionProvider _apiVersionProvider;
        private readonly ISystemDateProvider _systemDateProvider;
        private const string UseReverseProxyHeadersConfigKey = "UseReverseProxyHeaders";
        private readonly bool _useProxyHeaders;

        public VersionController(
            IApiConfigurationProvider apiConfigurationProvider,
            IDomainModelProvider domainModelProvider,
            IApiVersionProvider apiVersionProvider,
            ISystemDateProvider systemDateProvider,
            IConfigValueProvider configValueProvider)
        {
            Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
            Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            Preconditions.ThrowIfNull(apiVersionProvider, nameof(apiVersionProvider));
            Preconditions.ThrowIfNull(systemDateProvider, nameof(systemDateProvider));

            _apiConfigurationProvider = apiConfigurationProvider;
            _domainModelProvider = domainModelProvider;
            _apiVersionProvider = apiVersionProvider;
            _systemDateProvider = systemDateProvider;

            bool tempConfigValue;

            _useProxyHeaders = bool.TryParse(
                configValueProvider.GetValue(UseReverseProxyHeadersConfigKey),
                out tempConfigValue) && tempConfigValue;
        }

        [Route("")]
        public IHttpActionResult Get()
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
                apiMode = _apiConfigurationProvider.Mode.DisplayName,
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
        }

        private ExposedUrls GetUrls()
        {
            var currentYear = _systemDateProvider.GetDate().Year.ToString();

            var exposedUrls = new ExposedUrls();

            exposedUrls.DependenciesUrl = new Uri(new Uri(Request.RootUrl(_useProxyHeaders)), 
                _apiConfigurationProvider.IsYearSpecific() ? $"/metadata/data/v{ApiVersionConstants.Ods}/" + currentYear + "/dependencies"
                : $"/metadata/data/v{ApiVersionConstants.Ods}/").ToString();

            exposedUrls.MetaDataUrl = new Uri(new Uri(Request.RootUrl(_useProxyHeaders)), 
                "metadata/" + (_apiConfigurationProvider.IsYearSpecific()
                            ? currentYear : string.Empty)).ToString();

            exposedUrls.OauthUrl = new Uri(new Uri(Request.RootUrl(_useProxyHeaders)), "oauth/token").ToString();

            exposedUrls.ApiUrl = new Uri(new Uri(Request.RootUrl(_useProxyHeaders)), $"data/v{ApiVersionConstants.Ods}/" +
                                         (_apiConfigurationProvider.IsYearSpecific()
                                             ? _systemDateProvider.GetDate().Year.ToString()
                                             : string.Empty)).ToString();

            return exposedUrls;

        }
    }
}

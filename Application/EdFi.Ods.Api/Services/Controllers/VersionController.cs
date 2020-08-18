// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Web.Http;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Services.Controllers
{
    public class VersionController : ApiController
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IApiVersionProvider _apiVersionProvider;
        private readonly ISystemDateProvider _systemDateProvider;
        

        public VersionController(
            IApiConfigurationProvider apiConfigurationProvider,
            IDomainModelProvider domainModelProvider,
            IApiVersionProvider apiVersionProvider,
            ISystemDateProvider systemDateProvider)
        {
            Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
            Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            Preconditions.ThrowIfNull(apiVersionProvider, nameof(apiVersionProvider));
            Preconditions.ThrowIfNull(systemDateProvider, nameof(systemDateProvider));

            _apiConfigurationProvider = apiConfigurationProvider;
            _domainModelProvider = domainModelProvider;
            _apiVersionProvider = apiVersionProvider;
            _systemDateProvider = systemDateProvider;
        }

       // [Route("")]
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
                    Url.Request.RequestUri.AbsolutePath,
                    Url.Request.RequestUri.AbsoluteUri
                }
            };

            return Ok(content);
        }

        private ExposedUrls GetUrls()
        {
            var exposedUrls = new ExposedUrls();

            if (_apiConfigurationProvider.IsYearSpecific())
            {
                var currentSchoolYear = _systemDateProvider.GetDate().Year.ToString();
                exposedUrls.MetaDataUrl = Url.Link("MetadataSections", new { controller = "openapimetadata", action = "getsections", schoolYearFromRoute = currentSchoolYear });
                exposedUrls.DependenciesUrl = Url.Link("AggregateDependencies", new { controller = "aggregatedependency", action = "get", schoolYearFromRoute = currentSchoolYear });
            }
            else
            {
                exposedUrls.MetaDataUrl = Url.Link("MetadataSections", new { controller = "openapimetadata", action = "getsections" });
                exposedUrls.DependenciesUrl = Url.Link("AggregateDependencies", new { controller = "aggregatedependency", action = "get" });
            }

            exposedUrls.OauthUrl = Url.Link("OAuthToken", new { controller = "Token" });

            var versionUrl =  Url.Link("Root", new { controller = "Version"});

           // var versionUrl = Url.Link("ApiDefaultItem");

            exposedUrls.ApiUrl = new Uri(
                new Uri(versionUrl),
                 $"/data/v{ApiVersionConstants.Ods}/" +
                (_apiConfigurationProvider.IsYearSpecific()
                    ? _systemDateProvider.GetDate().Year.ToString()
                    : string.Empty)).ToString();

            return exposedUrls;
        }
    }
}

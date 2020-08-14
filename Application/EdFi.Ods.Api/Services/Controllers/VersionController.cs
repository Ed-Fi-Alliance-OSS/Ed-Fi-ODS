// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using System.Security.Policy;
using System.Web.Http;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Api.Services.Controllers
{
    public class VersionController : ApiController
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IApiVersionProvider _apiVersionProvider;
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;

        public VersionController(
            IApiConfigurationProvider apiConfigurationProvider,
            IDomainModelProvider domainModelProvider,
            IApiVersionProvider apiVersionProvider,
            ISchoolYearContextProvider schoolYearContextProvider)
        {
            Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
            Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            Preconditions.ThrowIfNull(apiVersionProvider, nameof(apiVersionProvider));
            Preconditions.ThrowIfNull(schoolYearContextProvider, nameof(schoolYearContextProvider));

            _apiConfigurationProvider = apiConfigurationProvider;
            _domainModelProvider = domainModelProvider;
            _apiVersionProvider = apiVersionProvider;
            _schoolYearContextProvider = schoolYearContextProvider;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var metaDataUrl = string.Empty;
            var dependenciesUrl = string.Empty;
            var oauthUrl = string.Empty;

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

            if (_apiConfigurationProvider.IsYearSpecific())
            {
                var schoolYear = _schoolYearContextProvider.GetSchoolYear();
                metaDataUrl = Url.Link("MetadataSections", new { controller = "openapimetadata", action = "getsections", schoolYearFromRoute = schoolYear });
                dependenciesUrl = Url.Link("AggregateDependencies", new { controller = "aggregatedependency", action = "get", schoolYearFromRoute = schoolYear });
                oauthUrl = Url.Link("OAuthToken", new { controller = "Token" });
            }
            else
            {
                metaDataUrl = Url.Link("MetadataSections", new { controller = "openapimetadata", action = "getsections" });
                dependenciesUrl = Url.Link("AggregateDependencies", new { controller = "aggregatedependency", action = "get" });
                oauthUrl = Url.Link("OAuthToken", new { controller = "Token" });
            }


            var content = new
            {
                version = _apiVersionProvider.Version,
                informationalVersion = _apiVersionProvider.InformationalVersion,
                suite = _apiVersionProvider.Suite,
                build = _apiVersionProvider.Build,
                apiMode = _apiConfigurationProvider.Mode.DisplayName,
                dataModels = dataModels,
                metaDataUrl = metaDataUrl,
                dependenciesUrl = dependenciesUrl,
                oauthUrl = oauthUrl,
                apiUrl = new Uri(new Uri(Url.Request.RequestUri.AbsoluteUri), $"/data/v{_apiVersionProvider.InformationalVersion}/").ToString()
        };

            return Ok(content);
        }
    }
}

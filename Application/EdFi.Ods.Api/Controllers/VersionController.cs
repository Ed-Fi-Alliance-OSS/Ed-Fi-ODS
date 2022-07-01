// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
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
            var content = new
            {
                version = _apiVersionProvider.Version,
                informationalVersion = _apiVersionProvider.InformationalVersion,
                suite = _apiVersionProvider.Suite,
                build = _apiVersionProvider.Build,
                apiMode = _apiSettings.GetApiMode().DisplayName,
                dataModels = _domainModelProvider
                    .GetDomainModel()
                    .Schemas
                    .Select(
                        s => new
                        {
                            name = s.LogicalName,
                            version = s.Version,
                            informationalVersion = s.InformationalVersion
                        })
                    .ToArray(),
                urls = GetUrlsByName()
            };

            return Ok(content);

            Dictionary<string, string> GetUrlsByName()
            {
                var currentYear = _systemDateProvider.GetDate().Year.ToString();

                // since instance is dynamic and given through url, this value is just a place holder
                var instance = "{instance}";

                bool isInstanceYearSpecific = _apiSettings.GetApiMode().Equals(ApiMode.InstanceYearSpecific);

                bool isYearSpecific = _apiSettings.GetApiMode().Equals(ApiMode.YearSpecific)
                                      || isInstanceYearSpecific;

                var urlsByName = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

                var rootUrl = Request.RootUrl(_apiSettings.GetReverseProxySettings());

                if (_apiSettings.IsFeatureEnabled(ApiFeature.AggregateDependencies.GetConfigKeyName()))
                {
                    urlsByName["dependencies"] = rootUrl +
                                                    (isInstanceYearSpecific
                                                        ? $"/metadata/data/v{ApiVersionConstants.Ods}/" + $"{instance}/" +
                                                          currentYear + "/dependencies"
                                                        : (isYearSpecific
                                                            ? $"/metadata/data/v{ApiVersionConstants.Ods}/" + currentYear +
                                                              "/dependencies"
                                                            : $"/metadata/data/v{ApiVersionConstants.Ods}/dependencies"));
                }

                if (_apiSettings.IsFeatureEnabled(ApiFeature.OpenApiMetadata.GetConfigKeyName()))
                {
                    urlsByName["openApiMetadata"] = rootUrl + "/metadata/" +
                                                (isInstanceYearSpecific
                                                    ? $"{instance}/"
                                                    : string.Empty) +
                                                (isYearSpecific
                                                    ? currentYear
                                                    : string.Empty);
                }

                urlsByName["oauth"] = rootUrl +
                                         (isInstanceYearSpecific
                                             ? $"/{instance}"
                                             : string.Empty) +
                                         "/oauth/token";

                urlsByName["dataManagementApi"] = rootUrl +
                                       $"/data/v{ApiVersionConstants.Ods}/" +
                                       (isInstanceYearSpecific
                                           ? $"{instance}/"
                                           : string.Empty) +
                                       (isYearSpecific
                                           ? currentYear
                                           : string.Empty);

                if (_apiSettings.IsFeatureEnabled(ApiFeature.XsdMetadata.GetConfigKeyName()))
                {
                    urlsByName["xsdMetadata"] = rootUrl + "/metadata/" +
                                                   (isInstanceYearSpecific
                                                       ? $"{instance}/"
                                                       : string.Empty) +
                                                   (isYearSpecific
                                                       ? $"{currentYear}/"
                                                       : string.Empty) +
                                                   "xsd";
                }

                if (_apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName()))
                {
                    urlsByName["changeQueries"] = rootUrl +
                                                  $"/changeQueries/v{ApiVersionConstants.ChangeQuery}/" +
                                                  (isInstanceYearSpecific
                                                      ? $"{instance}/"
                                                      : string.Empty) +
                                                  (isYearSpecific
                                                      ? currentYear
                                                      : string.Empty);
                }

                if (_apiSettings.IsFeatureEnabled(ApiFeature.Composites.GetConfigKeyName()))
                {
                    urlsByName["composites"] = rootUrl +
                                                       $"/composites/v{ApiVersionConstants.Composite}/" +
                                                       (isInstanceYearSpecific
                                                           ? $"{instance}/"
                                                           : string.Empty) +
                                                       (isYearSpecific
                                                           ? currentYear
                                                           : string.Empty);
                }

                if (_apiSettings.IsFeatureEnabled(ApiFeature.IdentityManagement.GetConfigKeyName()))
                {
                    urlsByName["identity"] = rootUrl +
                                             $"/identity/v{ApiVersionConstants.Identity}/" +
                                             (isInstanceYearSpecific
                                                 ? $"{instance}/"
                                                 : string.Empty) +
                                             (isYearSpecific
                                                 ? currentYear
                                                 : string.Empty);
                }
                return urlsByName;
            }
        }
    }
}

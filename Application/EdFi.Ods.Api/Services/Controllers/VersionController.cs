// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Linq;
using System.Web.Http;
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

        public VersionController(
            IApiConfigurationProvider apiConfigurationProvider,
            IDomainModelProvider domainModelProvider,
            IApiVersionProvider apiVersionProvider)
        {
            Preconditions.ThrowIfNull(apiConfigurationProvider, nameof(apiConfigurationProvider));
            Preconditions.ThrowIfNull(domainModelProvider, nameof(domainModelProvider));
            Preconditions.ThrowIfNull(apiVersionProvider, nameof(apiVersionProvider));

            _apiConfigurationProvider = apiConfigurationProvider;
            _domainModelProvider = domainModelProvider;
            _apiVersionProvider = apiVersionProvider;
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

            var content = new
            {
                version = _apiVersionProvider.Version,
                informationalVersion = _apiVersionProvider.InformationalVersion,
                suite = _apiVersionProvider.Suite,
                build = _apiVersionProvider.Build,
                apiMode = _apiConfigurationProvider.Mode.DisplayName,
                dataModels = dataModels
            };

            return Ok(content);
        }
    }
}

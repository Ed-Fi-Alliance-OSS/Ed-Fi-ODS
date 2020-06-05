// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.NetCore.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    [AllowAnonymous]
    public class VersionController : ControllerBase
    {
        private readonly IApiConfigurationProvider _apiConfigurationProvider;
        private readonly IApiVersionProvider _apiVersionProvider;
        private readonly IDomainModelProvider _domainModelProvider;

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

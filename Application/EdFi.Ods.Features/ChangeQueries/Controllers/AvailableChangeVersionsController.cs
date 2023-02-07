// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Http.Json;
using System.Net.Mime;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.ChangeQueries.Providers;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.ChangeQueries.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("changeQueries")]
    public class AvailableChangeVersionsController : ControllerBase
    {
        private readonly IAvailableChangeVersionProvider _availableChangeVersionProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AvailableChangeVersionsController));
        private readonly bool _isEnabled;

        public AvailableChangeVersionsController(
            IAvailableChangeVersionProvider availableChangeVersionProvider,
            ApiSettings apiSettings)
        {
            _availableChangeVersionProvider = availableChangeVersionProvider;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!_isEnabled)
            {
                _logger.Debug("ChangeQueries is disabled.");
                return NotFound();
            }

            return new ObjectResult(await _availableChangeVersionProvider.GetAvailableChangeVersion());
        }
    }
}

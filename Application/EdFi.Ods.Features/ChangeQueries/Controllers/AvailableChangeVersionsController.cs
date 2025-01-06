// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Features.ChangeQueries.Providers;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace EdFi.Ods.Features.ChangeQueries.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApplyOdsRouteRootTemplate]
    [Route($"{ChangeQueriesConstants.RoutePrefix}/availableChangeVersions")]
    public class AvailableChangeVersionsController : ControllerBase
    {
        private readonly IAvailableChangeVersionProvider _availableChangeVersionProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AvailableChangeVersionsController));
        private readonly bool _isEnabled;

        public AvailableChangeVersionsController(
            IAvailableChangeVersionProvider availableChangeVersionProvider,
            IFeatureManager featureManager)
        {
            _availableChangeVersionProvider = availableChangeVersionProvider;
            _isEnabled = featureManager.IsFeatureEnabled(ApiFeature.ChangeQueries);
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

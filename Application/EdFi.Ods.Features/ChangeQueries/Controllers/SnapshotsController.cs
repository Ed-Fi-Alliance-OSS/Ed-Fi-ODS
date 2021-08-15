// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Features.ChangeQueries.Repositories.Snapshots;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.ChangeQueries.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("snapshots")]
    public class SnapshotsController : ControllerBase
    {
        private readonly IGetSnapshots _getSnapshots;
        private readonly ILog _logger = LogManager.GetLogger(typeof(SnapshotsController));
        private readonly bool _isEnabled;

        // NOTE: The optional dependency is necessary to be able to return a 404 Not Found
        // instead of a 500 Internal Server Error if the route is requested by the API client
        // when the feature is disabled (and the IGetSnapshots service is not registered).
        public SnapshotsController(ApiSettings apiSettings, IGetSnapshots getSnapshots = null)
        {
            _getSnapshots = getSnapshots;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            if (!_isEnabled)
            {
                _logger.Debug($"{nameof(SnapshotsController)} was matched to handle the request, but the '{ApiFeature.ChangeQueries}' feature is disabled.");

                // Not Found
                return ControllerHelpers.NotFound();
            }

            var snapshots = await _getSnapshots.GetAllAsync(new QueryParameters(urlQueryParametersRequest));
            return Ok(snapshots);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            if (!_isEnabled)
            {
                _logger.Debug($"{nameof(SnapshotsController)} was matched to handle the request, but the '{ApiFeature.ChangeQueries}' feature is disabled.");

                // Not Found
                return ControllerHelpers.NotFound();
            }

            var snapshot = await _getSnapshots.GetByIdAsync(id);

            if (snapshot == null)
            {
                // Not Found
                return ControllerHelpers.NotFound();
            }
            
            return Ok(snapshot);
        }
    }
}

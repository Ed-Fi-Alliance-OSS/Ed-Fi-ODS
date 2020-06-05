// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using EdFi.Ods.Api.Common.Configuration;
using EdFi.Ods.Api.Common.Constants;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Common.Models.Queries;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.ChangeQueries.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("deletes")]
    public class DeletesController : ControllerBase
    {
        private readonly IGetDeletedResourceIds _getDeletedResourceIdsRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletesController));
        private readonly bool _isEnabled;

        public DeletesController(IGetDeletedResourceIds getDeletedResourceIds, ApiSettings apiSettings)
        {
            _getDeletedResourceIdsRepository = getDeletedResourceIds;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName());
        }

        [HttpGet]
        public IActionResult Get(string schema, string resource, [FromQuery] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            if (!_isEnabled)
            {
                _logger.Debug("ChangeQueries is not enabled.");
                return NotFound();
            }
            var queryParameter = new QueryParameters(urlQueryParametersRequest);

            var result = _getDeletedResourceIdsRepository.Execute(schema, resource, queryParameter);

            return Ok(result);
        }
    }
}
#endif
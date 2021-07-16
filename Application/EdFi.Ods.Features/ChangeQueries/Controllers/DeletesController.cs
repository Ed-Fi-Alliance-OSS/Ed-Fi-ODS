// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Mime;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Features.ChangeQueries.Repositories;
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
    [Route("{schema}/{resource}/deletes")]
    public class DeletesController : ControllerBase
    {
        private readonly IGetDeletedResourceItems _getDeletedResourceItemsRepository;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletesController));
        private readonly bool _isEnabled;

        public DeletesController(IGetDeletedResourceItems getDeletedResourceItems, ApiSettings apiSettings)
        {
            _getDeletedResourceItemsRepository = getDeletedResourceItems;
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

            var deletedItemsResponse = _getDeletedResourceItemsRepository.Execute(schema, resource, queryParameter);

            // Add the total count, if requested
            if (urlQueryParametersRequest.TotalCount)
            {
                Response.Headers.Add("Total-Count", deletedItemsResponse.Count.ToString());
            }
            
            // Explicitly serialize the response to remain backwards compatible with pre .net core
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(deletedItemsResponse),
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
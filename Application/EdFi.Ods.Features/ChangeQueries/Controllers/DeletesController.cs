// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Mime;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models;
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
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IDeletedItemsResourceDataProvider _deletedItemsResourceDataProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeletesController));
        private readonly bool _isEnabled;

        public DeletesController(
            IDomainModelProvider domainModelProvider,
            IDeletedItemsResourceDataProvider deletedItemsResourceDataProvider, 
            ApiSettings apiSettings)
        {
            _domainModelProvider = domainModelProvider;
            _deletedItemsResourceDataProvider = deletedItemsResourceDataProvider;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName());
        }

        [HttpGet]
        public async Task<IActionResult> Get(string schema, string resource, [FromQuery] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            if (!_isEnabled)
            {
                _logger.Debug("ChangeQueries is not enabled.");
                return NotFound();
            }
            
            var queryParameter = new QueryParameters(urlQueryParametersRequest);

            var resourceClass = _domainModelProvider.GetDomainModel().ResourceModel.GetResourceByApiCollectionName(schema, resource);

            if (resourceClass == null)
            {
                return new NotFoundResult();
            }
            
            var deletedItemsResponse = await _deletedItemsResourceDataProvider.GetResourceDataAsync(resourceClass, queryParameter, Request.Query);

            // Add the total count, if requested
            if (urlQueryParametersRequest.TotalCount)
            {
                Response.Headers.Add("Total-Count", deletedItemsResponse.Count.ToString());
            }
            
            // Explicitly serialize the response to remain backwards compatible with pre .net core
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(deletedItemsResponse.DeletedResources),
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
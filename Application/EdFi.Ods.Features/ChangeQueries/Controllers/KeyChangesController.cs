// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net.Mime;
using System.Threading.Tasks;
using EdFi.Ods.Api.Helpers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Serialization;
using EdFi.Ods.Features.ChangeQueries.Repositories.KeyChanges;
using EdFi.Ods.Security.Authorization;
using EdFi.Security.DataAccess.Repositories;
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
    [Route("{schema}/{resource}/keyChanges")]
    public class KeyChangesController : ControllerBase
    {
        private readonly IDomainModelProvider _domainModelProvider;
        private readonly IKeyChangesResourceDataProvider _keyChangesResourceDataProvider;
        private readonly IAuthorizationContextProvider _authorizationContextProvider;
        private readonly IResourceClaimUriProvider _resourceClaimUriProvider;
        private readonly ISecurityRepository _securityRepository;

        private readonly ILog _logger = LogManager.GetLogger(typeof(KeyChangesController));
        private readonly bool _isEnabled;

        public KeyChangesController(
            IDomainModelProvider domainModelProvider,
            IKeyChangesResourceDataProvider keyChangesResourceDataProvider,
            IAuthorizationContextProvider authorizationContextProvider,
            IResourceClaimUriProvider resourceClaimUriProvider,
            ISecurityRepository securityRepository,
            ApiSettings apiSettings)
        {
            _domainModelProvider = domainModelProvider;
            _keyChangesResourceDataProvider = keyChangesResourceDataProvider;
            _authorizationContextProvider = authorizationContextProvider;
            _resourceClaimUriProvider = resourceClaimUriProvider;
            _securityRepository = securityRepository;

            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.ChangeQueries.GetConfigKeyName());
        }

        [HttpGet]
        public async Task<IActionResult> Get(string schema, string resource, [FromQuery] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            if (!_isEnabled)
            {
                _logger.Debug("ChangeQueries is not enabled.");

                return ControllerHelpers.NotFound();
            }
            
            var resourceClass = _domainModelProvider.GetDomainModel().ResourceModel.GetResourceByApiCollectionName(schema, resource);

            if (resourceClass == null)
            {
                return ControllerHelpers.NotFound();
            }
            
            // Set authorization context (should this be moved?)
            _authorizationContextProvider.SetResourceUris(_resourceClaimUriProvider.GetResourceClaimUris(resourceClass));
            _authorizationContextProvider.SetAction(_securityRepository.GetActionByName("ReadChanges").ActionUri);

            // TODO: Validate the parameter here (and rather than deeper in the call stack)
            var queryParameter = new QueryParameters(urlQueryParametersRequest);

            var keyChangesResponse = await _keyChangesResourceDataProvider.GetResourceDataAsync(resourceClass, queryParameter);

            // Add the total count, if requested
            if (urlQueryParametersRequest.TotalCount)
            {
                Response.Headers.Add("Total-Count", keyChangesResponse.Count.ToString());
            }
            
            // Explicitly serialize the response to remain backwards compatible with pre .net core
            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(keyChangesResponse.KeyChanges, new Iso8601UtcDateOnlyConverter()),
                ContentType = MediaTypeNames.Application.Json,
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}

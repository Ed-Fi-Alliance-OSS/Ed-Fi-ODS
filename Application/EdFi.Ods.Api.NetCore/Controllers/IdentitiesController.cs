// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Api.Common.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.NetCore.Controllers
{
    /// <summary>
    /// Manage Identity identity, create and lookup people
    /// </summary>
    /// <remarks>
    /// Delegates implementation to the registered IIdentityService and IIdentityServiceAsync implementations
    /// </remarks>
    [Description("Retrieve or create Unique Ids for a Identity, and add or update their information")]
    [Authorize]
    // [ApiController]
    [Produces("application/json")]
    public class IdentitiesController : ControllerBase
    {
        private const string InvalidServerResponse = "Invalid response from identity service: ";
        private const string NoIdentitySystem = "There is no integrated Unique Identity System";
        private readonly IIdentityService _identitySubsystem;
        private readonly IIdentityServiceAsync _identitySubsystemAsync;

        public IdentitiesController(IIdentityService identitySubsystem, IIdentityServiceAsync identitySubsystemAsync)
        {
            _identitySubsystem = identitySubsystem;
            _identitySubsystemAsync = identitySubsystemAsync;
        }

        /// <summary>
        /// Retrieve a single person record from their Unique Id.
        /// </summary>
        /// <param name="uniqueId">Unique Id of the identity to be retrieved</param>
        /// <remarks>Returns either a single identity or 404 and no data</remarks>
        /// <response code="200" type="IdentityResponse">The returned identity matches the provided Unique Id.</response>
        /// <response code="404">No identity matching the provided Unique Id was found.</response>
        /// <response code="501">The server does not support the requested function.</response>
        /// <response code="502">The underlying identity system returned an error.</response>
        /// <returns>The identity information for the provided Unique Id</returns>
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery(Name = "id")] string uniqueId)
        {
            try
            {
                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Find) == 0)
                {
                    return NotImplemented();
                }

                var identitySearchResponse = await _identitySubsystem.Find(uniqueId)
                    .ConfigureAwait(false);

                switch (identitySearchResponse.StatusCode)
                {
                    case IdentityStatusCode.Success:
                        var identity = identitySearchResponse.Data.SearchResponses[0]
                            .Responses[0];

                        return identity.Score == 100
                            ? (IActionResult) Ok(identity)
                            : NotFound(new NotFoundException());
                    case IdentityStatusCode.Incomplete:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                    case IdentityStatusCode.InvalidProperties:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                    case IdentityStatusCode.NotFound:
                        return NotFound(new NotFoundException());
                    default:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadGateway, ex);
            }
        }

        /// <summary>
        /// Creates a new Unique Id for the given Identity information.
        /// </summary>
        /// <param name="request">Identity object to be created.</param>
        /// <remarks>Assumption here is that the user has verified that possible matches are not correct matches. Returns the created identity information along with the assigned Unique Id.</remarks>
        /// <response code="200" type="string">An Identity was created. The new Unique Id is returned in the returned Identity record.</response>
        /// <response code="400">There were invalid properties.</response>
        /// <response code="501">The server does not support the requested function.</response>
        /// <response code="502">The underlying identity system returned an error.</response>
        [HttpPost]
        [Produces("application/text")]
        public async Task<IActionResult> Create([FromBody] IdentityCreateRequest request)
        {
            try
            {
                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Create) == 0)
                {
                    return NotImplemented();
                }

                var result = await _identitySubsystem.Create(request);

                switch (result.StatusCode)
                {
                    case IdentityStatusCode.Success:
                        var route = Url.Link("IdentitiesGetById", new {id = result.Data});
                        return Created(new Uri(route), result.Data);
                    case IdentityStatusCode.InvalidProperties:
                        return StatusCode((int) HttpStatusCode.BadRequest, result.Data);
                    case IdentityStatusCode.Incomplete:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                    case IdentityStatusCode.NotFound:
                        return NotFound(new NotFoundException());
                    default:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadGateway, ex);
            }
        }

        /// <summary>
        /// Retrieve a multiple person records from their Unique Ids.
        /// </summary>
        /// <param name="uniqueIds">Unique Ids of the persons to be retrieved.</param>
        /// <response code="200" type="IdentitySearchResponse">The returned identities match the provided Unique Id.</response>
        /// <response code="202">The identity query was accepted for asynchronous processing. The result will be available at the URL indicated in the location response header.</response>
        /// <response code="501">The server does not support the requested function.</response>
        /// <response code="502">The underlying identity system returned an error.</response>
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] string[] uniqueIds)
        {
            try
            {
                if ((_identitySubsystemAsync.IdentityServiceCapabilities & IdentityServiceCapabilities.Find) != 0)
                {
                    var result = await _identitySubsystemAsync.Find(uniqueIds);

                    switch (result.StatusCode)
                    {
                        case IdentityStatusCode.Success:
                            var route = Url.Link("IdentitiesSearchResult", new {id = result.Data});
                            return Accepted(route);
                        case IdentityStatusCode.Incomplete:
                            return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                        case IdentityStatusCode.InvalidProperties:
                            return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                        case IdentityStatusCode.NotFound:
                            return NotFound(InvalidServerResponse + "Not Found");
                        default:
                            return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                    }
                }

                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Find) != 0)
                {
                    var result = await _identitySubsystem.Find(uniqueIds);

                    if (result.StatusCode == IdentityStatusCode.Success)
                    {
                        return Ok(result.Data);
                    }
                }

                return NotImplemented();
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadGateway, ex);
            }
        }

        /// <summary>
        /// Lookup existing Unique Ids for a persons, or suggest possible matches.
        /// </summary>
        /// <param name="criteria">One or more identity search request objects.</param>
        /// <response code="200" type="IdentitySearchResponse">The returned identities are possible matches for the provided identity search requests.</response>
        /// <response code="202">The identity query was accepted for asynchronous processing. The result will be available at the URL indicated in the location response header.</response>
        /// <response code="501">The server does not support the requested function.</response>
        /// <response code="502">The underlying identity system returned an error.</response>
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] IdentitySearchRequest[] criteria)
        {
            try
            {
                if ((_identitySubsystemAsync.IdentityServiceCapabilities & IdentityServiceCapabilities.Search) != 0)
                {
                    var result = await _identitySubsystemAsync.Search(criteria);

                    switch (result.StatusCode)
                    {
                        case IdentityStatusCode.Success:
                            var route = Url.Link("IdentitiesSearchResult", new {id = result.Data});
                            return Accepted(route);
                        case IdentityStatusCode.Incomplete:
                            return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                        case IdentityStatusCode.InvalidProperties:
                            return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                        case IdentityStatusCode.NotFound:
                            return NotFound(InvalidServerResponse + "Not Found");
                        default:
                            return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                    }
                }

                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Search) != 0)
                {
                    return Ok((await _identitySubsystem.Search(criteria)).Data);
                }

                return NotImplemented();
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadGateway, ex);
            }
        }

        /// <summary>
        /// Retrieve asynchronous search results from a previously created request.
        /// </summary>
        /// <param name="searchToken">The search token provided by a Find or Search request.</param>
        /// <response code="200" type="IdentitySearchResponse">The identity results are contained in the body of this response.</response>
        /// <response code="404">No identity search matching the provided search token was found.</response>
        /// <response code="501">The server does not support the requested function.</response>
        /// <response code="502">The underlying identity system returned an error.</response>
        [HttpGet]
        public async Task<IActionResult> Result([FromQuery(Name = "id")] string searchToken)
        {
            try
            {
                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Results) == 0)
                {
                    return NotImplemented();
                }

                var result = await _identitySubsystemAsync.Response(searchToken);

                switch (result.StatusCode)
                {
                    case IdentityStatusCode.Success:
                        return Ok(result.Data);
                    case IdentityStatusCode.Incomplete:
                        Response.Headers["Location"] = Request.GetDisplayUrl();
                        return Ok(result.Data);
                    case IdentityStatusCode.NotFound:
                        return NotFound("No identity search matching the provided search token was found.");
                    case IdentityStatusCode.InvalidProperties:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                    default:
                        return StatusCode((int) HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadGateway, ex);
            }
        }

        private IActionResult NotImplemented()
        {
            return StatusCode((int) HttpStatusCode.NotImplemented, NoIdentitySystem);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EdFi.Ods.Api.Common.Exceptions;
using EdFi.Ods.Api.Common.Models.Identity;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Filters;

namespace EdFi.Ods.Api.Services.Controllers.IdentityManagement
{
    /// <summary>
    /// Manage Identity identity, create and lookup people
    /// </summary>
    /// <remarks>
    /// Delegates implementation to the registered IIdentityService and IIdentityServiceAsync implementations
    /// </remarks>
    [Description("Retrieve or create Unique Ids for a Identity, and add or update their information")]
    [Authenticate]
    [EdFiAuthorization(Resource = "Identity")]
    public class IdentitiesController : ApiController
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
        [ResponseType(typeof(IdentityResponse))]
        public async Task<HttpResponseMessage> GetById([FromUri(Name = "id")] string uniqueId)
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

                        var response = identity.Score == 100
                            ? Request.CreateResponse(HttpStatusCode.OK, identity)
                            : Request.CreateErrorResponse(HttpStatusCode.NotFound, new NotFoundException());

                        return response;
                    case IdentityStatusCode.Incomplete:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                    case IdentityStatusCode.InvalidProperties:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                    case IdentityStatusCode.NotFound:
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, new NotFoundException());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex);
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
        [ResponseType(typeof(string))]
        public async Task<HttpResponseMessage> Create([FromBody] IdentityCreateRequest request)
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
                        var response = Request.CreateResponse(HttpStatusCode.Created);
                        response.Content = new StringContent(result.Data, Encoding.UTF8, "application/text");

                        var route = Url.Link(
                            "IdentitiesGetById",
                            new
                            {
                                id = result.Data
                            });

                        response.Headers.Location = new Uri(route);
                        return response;
                    case IdentityStatusCode.InvalidProperties:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, result.Data);
                    case IdentityStatusCode.Incomplete:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                    case IdentityStatusCode.NotFound:
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, new NotFoundException());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex);
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
        [ResponseType(typeof(IdentitySearchResponse))]
        public async Task<HttpResponseMessage> Find([FromBody] string[] uniqueIds)
        {
            try
            {
                if ((_identitySubsystemAsync.IdentityServiceCapabilities & IdentityServiceCapabilities.Find) != 0)
                {
                    var result = await _identitySubsystemAsync.Find(uniqueIds);

                    switch (result.StatusCode)
                    {
                        case IdentityStatusCode.Success:
                            var response = Request.CreateResponse(HttpStatusCode.Accepted);

                            var route = Url.Link(
                                "IdentitiesSearchResult",
                                new
                                {
                                    id = result.Data
                                });

                            response.Headers.Location = new Uri(route);
                            return response;
                        case IdentityStatusCode.Incomplete:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                        case IdentityStatusCode.InvalidProperties:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                        case IdentityStatusCode.NotFound:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Not Found");
                        default:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                    }
                }

                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Find) != 0)
                {
                    var result = await _identitySubsystem.Find(uniqueIds);

                    if (result.StatusCode == IdentityStatusCode.Success)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, result.Data);
                    }
                }

                return NotImplemented();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex);
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
        [ResponseType(typeof(IdentitySearchResponse))]
        public async Task<HttpResponseMessage> Search([FromBody] IdentitySearchRequest[] criteria)
        {
            try
            {
                if ((_identitySubsystemAsync.IdentityServiceCapabilities & IdentityServiceCapabilities.Search) != 0)
                {
                    var result = await _identitySubsystemAsync.Search(criteria);

                    switch (result.StatusCode)
                    {
                        case IdentityStatusCode.Success:
                            var response = Request.CreateResponse(HttpStatusCode.Accepted);

                            var route = Url.Link(
                                "IdentitiesSearchResult",
                                new
                                {
                                    id = result.Data
                                });

                            response.Headers.Location = new Uri(route);
                            return response;
                        case IdentityStatusCode.Incomplete:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Incomplete");
                        case IdentityStatusCode.InvalidProperties:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                        case IdentityStatusCode.NotFound:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Not Found");
                        default:
                            return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                    }
                }

                if ((_identitySubsystem.IdentityServiceCapabilities & IdentityServiceCapabilities.Search) != 0)
                {
                    var result = await _identitySubsystem.Search(criteria);
                    var response = Request.CreateResponse(HttpStatusCode.OK, result.Data);
                    return response;
                }

                return NotImplemented();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex);
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
        [ResponseType(typeof(IdentitySearchResponse))]
        public async Task<HttpResponseMessage> Result([FromUri(Name = "id")] string searchToken)
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
                        return Request.CreateResponse(HttpStatusCode.OK, result.Data);
                    case IdentityStatusCode.Incomplete:
                        var response = Request.CreateResponse(HttpStatusCode.OK, result.Data);
                        response.Headers.Location = Request.RequestUri;
                        return response;
                    case IdentityStatusCode.NotFound:

                        return Request.CreateErrorResponse(
                            HttpStatusCode.NotFound,
                            "No identity search matching the provided search token was found.");
                    case IdentityStatusCode.InvalidProperties:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Invalid Properties");
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, InvalidServerResponse + "Unknown");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex);
            }
        }

        private HttpResponseMessage NotImplemented()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, NoIdentitySystem);
        }
    }
}

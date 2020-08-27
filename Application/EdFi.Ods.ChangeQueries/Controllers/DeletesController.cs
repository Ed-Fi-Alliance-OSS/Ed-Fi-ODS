// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Web.Http;
using EdFi.Ods.Api.ChangeQueries;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Queries;

namespace EdFi.Ods.ChangeQueries.Controllers
{
    [Authenticate]
    public class DeletesController : ApiController
    {
        private readonly IGetDeletedResourceIds _getDeletedResourceIdsRepository;

        public DeletesController(IGetDeletedResourceIds getDeletedResourceIds)
        {
            _getDeletedResourceIdsRepository = getDeletedResourceIds;
        }

        [HttpGet]
        public IHttpActionResult Get(string schema, string resource, [FromUri] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            var queryParameter = new QueryParameters(urlQueryParametersRequest);

            var result = _getDeletedResourceIdsRepository.Execute(schema, resource, queryParameter);

            return Json(result);
        }
    }
}

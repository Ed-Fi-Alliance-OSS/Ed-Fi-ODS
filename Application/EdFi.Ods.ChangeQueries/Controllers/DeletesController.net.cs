// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Web.Http;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Api.Common.Models.Queries;
using EdFi.Ods.Api.Services.Authentication;

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
#endif

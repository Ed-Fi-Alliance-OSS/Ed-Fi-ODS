// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Web.Http;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.ChangeQueries.Providers;
using log4net;

namespace EdFi.Ods.ChangeQueries.Controllers
{
    [Authenticate]
    [Authorize]
    public class AvailableChangeVersionsController : ApiController
    {
        private readonly IAvailableChangeVersionProvider _availableChangeVersionProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AvailableChangeVersionsController));

        public AvailableChangeVersionsController(IAvailableChangeVersionProvider availableChangeVersionProvider)
        {
            _availableChangeVersionProvider = availableChangeVersionProvider;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(_availableChangeVersionProvider.GetAvailableChangeVersion());
        }
    }
}
#endif
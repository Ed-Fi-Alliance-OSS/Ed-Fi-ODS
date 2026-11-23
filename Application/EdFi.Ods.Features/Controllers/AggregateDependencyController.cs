// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.Ods.Features.AggregateDependencies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using QuickGraph;

namespace EdFi.Ods.Features.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [ApplyOdsRouteRootTemplate]
    [Route($"metadata/{RouteConstants.DataManagementRoutePrefix}/dependencies")]
    public class AggregateDependencyController : ControllerBase
    {
        private readonly IAggregateDependencyProvider _aggregateDependencyProvider;
        private readonly ILogContextAccessor _logContextAccessor;
        private readonly bool _isEnabled;

        public AggregateDependencyController(
            IFeatureManager featureManager,
            IAggregateDependencyProvider aggregateDependencyProvider,
            ILogContextAccessor logContextAccessor)
        {
            _isEnabled = featureManager.IsFeatureEnabled(ApiFeature.AggregateDependencies);
            _aggregateDependencyProvider = aggregateDependencyProvider;
            _logContextAccessor = logContextAccessor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            try
            {
                return IsGraphMLRequest()
                    ? Ok(_aggregateDependencyProvider.GetGraphML())
                    : Ok(_aggregateDependencyProvider.GetLoadOrder());
            }
            catch (NonAcyclicGraphException e)
            {
                // return a bad request if a circular reference occurs, with the path information of the reference.
                string message = e.Message.Replace($"{Environment.NewLine}    is used by ", " -> ")
                    .Replace(Environment.NewLine, " ");

                return BadRequest(
                    new BadRequestException(
                        "There was a problem preparing the resource dependency information.",
                        new[] { message })
                    {
                        CorrelationId = _logContextAccessor.GetCorrelationId()
                    }.AsSerializableModel());
            }

            bool IsGraphMLRequest()
            {
                return Request.GetTypedHeaders().Accept != null
                    && Request.GetTypedHeaders().Accept.Any(a => a.MediaType.Value.EqualsIgnoreCase(CustomMediaContentTypes.GraphML));
            }
        }
    }
}

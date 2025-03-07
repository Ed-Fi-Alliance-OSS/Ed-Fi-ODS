﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EdFi.Common.Inflection;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Metadata.Composites;
using EdFi.Ods.Common.ProblemDetails;
using EdFi.Ods.Features.Composites.Infrastructure;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.FeatureManagement;
using Newtonsoft.Json;
using static Microsoft.AspNetCore.WebUtilities.QueryHelpers;

namespace EdFi.Ods.Features.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Produces("application/json")]
    [ApiController]
    [ApplyOdsRouteRootTemplate]
    [Route("composites/")]
    public class CompositeResourceController : ControllerBase
    {
        private static readonly HashSet<string> _standardApiRouteKeys
            = new(StringComparer.OrdinalIgnoreCase)
            {
                "compositeVersion",
                "compositeCategory",
                "compositeName",
                "controller",
                "id",
                "organizationCode",
                "action" // required for net core
            };
        private readonly ICompositesMetadataProvider _compositeMetadataProvider;
        private readonly ICompositeResourceResponseProvider _compositeResourceResponseProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(CompositeResourceController));
        private readonly IEdFiProblemDetailsProvider _problemDetailsProvider;
        private readonly ILogContextAccessor _logContextAccessor;
        private readonly bool _isEnabled;

        public CompositeResourceController(
            ICompositeResourceResponseProvider compositeResourceResponseProvider,
            ICompositesMetadataProvider compositeMetadataProvider,
            IEdFiProblemDetailsProvider problemDetailsProvider,
            ILogContextAccessor logContextAccessor,
            IFeatureManager featureManager,
            ApiSettings apiSettings)
        {
            _compositeResourceResponseProvider = compositeResourceResponseProvider;
            _compositeMetadataProvider = compositeMetadataProvider;
            _problemDetailsProvider = problemDetailsProvider;
            _logContextAccessor = logContextAccessor;
            _isEnabled = featureManager.IsFeatureEnabled(ApiFeature.Composites);

            if (featureManager.IsFeatureEnabled(ApiFeature.MultiTenancy))
            {
                _standardApiRouteKeys.Add("tenantIdentifier");
            }

            if (!string.IsNullOrEmpty(apiSettings.OdsContextRouteTemplate))
            {
                foreach (var odsContextRouteKey in apiSettings.GetOdsContextRouteTemplateKeys())
                {
                    _standardApiRouteKeys.Add(odsContextRouteKey);
                }
            }
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            object json = null;
            IEdFiProblemDetails problemDetails = null;

            try
            {
                var routeDataValues = Request.RouteValues;

                string organizationCode = (string) routeDataValues["organizationCode"];
                string compositeCategory = (string) routeDataValues["compositeCategory"];
                string compositeCollectionName = (string) routeDataValues["compositeName"];
                string compositeResourceName = CompositeTermInflector.MakeSingular(compositeCollectionName);

                // Try to find the composite definition that matches the incoming URIs composite category/name
                if (!_compositeMetadataProvider.TryGetCompositeDefinition(
                    organizationCode,
                    compositeCategory,
                    compositeResourceName,
                    out XElement compositeDefinition))
                {
                    return NotFound();
                }

                // Prepare query string parameters
                var rawQueryStringParameters = ParseQuery(Request.QueryString.ToString());

                var queryStringParameters =
                    rawQueryStringParameters.Keys.ToDictionary<string, string, object>(

                        // Replace underscores with periods for appropriate processing
                        kvp => kvp.Replace('_', '.'),
                        kvp => rawQueryStringParameters[kvp],
                        StringComparer.InvariantCultureIgnoreCase);

                //respond quickly to DOS style requests (should we catch these earlier?  e.g. attribute filter?)

                if (queryStringParameters.TryGetValue("limit", out object limitAsObject))
                {
                    if (int.TryParse(limitAsObject.ToString(), out int limit)
                        && (limit <= 0 || limit > 100))
                    {
                        problemDetails = new BadRequestParameterException(
                            "The limit parameter was incorrect.",
                            new[] { "Limit must be omitted or set to a value between 1 and 100." })
                        {
                            CorrelationId = _logContextAccessor.GetCorrelationId()
                        }.AsSerializableModel();
                
                        return BadRequest(problemDetails);
                    }
                }

                // Process specification for route and query string parameters
                var specificationParameters = GetCompositeSpecificationParameters();

                // Ensure all matched route key values were used by the current composite
                var suppliedSpecificationParameters =
                    routeDataValues
                        .Where(kvp => !_standardApiRouteKeys.Contains(kvp.Key))
                        .ToList();

                var unusedSpecificationParameters =
                    suppliedSpecificationParameters
                        .Where(kvp => !specificationParameters.ContainsKey(kvp.Key))
                        .ToList();

                if (unusedSpecificationParameters.Any())
                {
                    return NotFound();
                }

                AddInherentSupportForIdParameter();

                json = _compositeResourceResponseProvider.Get(
                    compositeDefinition,
                    specificationParameters,
                    queryStringParameters,
                    GetNullValueHandling());

                void AddInherentSupportForIdParameter()
                {
                    if (!Request.RouteValues.TryGetValue("id", out object idAsObject))
                    {
                        return;
                    }

                    if (!Guid.TryParse(idAsObject.ToString(), out Guid id))
                    {
                        throw new BadRequestParameterException(
                            "The supplied data identifier is invalid.",
                            new []{ "The identifier could not be processed as a GUID."});
                    }

                    specificationParameters.Add(
                        "Id",
                        new CompositeSpecificationParameter
                        {
                            FilterPath = "Id",
                            Value = id
                        });
                }

                IDictionary<string, CompositeSpecificationParameter> GetCompositeSpecificationParameters()
                {
                    var specificationElt = compositeDefinition.Element("Specification");

                    if (specificationElt == null)
                    {
                        return new Dictionary<string, CompositeSpecificationParameter>();
                    }

                    var specificationFilterByName = specificationElt
                        .Elements("Parameter")
                        .ToDictionary(
                            p => p.AttributeValue("name"),
                            p => new
                            {
                                FilterPath = p.AttributeValue("filterPath"),
                                Queryable = p.AttributeValue("queryable") == "true"
                            },
                            StringComparer.InvariantCultureIgnoreCase);

                    // Identify relevant route values
                    var matchingRouteValues = routeDataValues
                        .Where(x => specificationFilterByName.ContainsKey(x.Key));

                    // Copy route values that match the specification to the parameter dictionary
                    var parameters = matchingRouteValues.ToDictionary(
                        kvp => kvp.Key, kvp => new CompositeSpecificationParameter
                        {
                            FilterPath = specificationFilterByName[kvp.Key]
                                .FilterPath,
                            Value = kvp.Value
                        });

                    // Identify relevant query string values
                    var matchingQueryStringParameters = queryStringParameters

                        // Skip query string parameter matching if the key was already matched by the route
                        .Where(x => !parameters.ContainsKey(x.Key))
                        .Where(
                            x => specificationFilterByName.ContainsKey(x.Key)
                                 && specificationFilterByName[x.Key]
                                     .Queryable)
                        .ToList();

                    // Copy route values that match the specification to the parameter dictionary
                    foreach (var kvp in matchingQueryStringParameters)
                    {
                        // Guids aren't "coerced" by SqlParameter correctly
                        object value = Guid.TryParse(kvp.Value as string, out Guid guidValue)
                            ? guidValue
                            : kvp.Value;

                        parameters.Add(
                            kvp.Key,
                            new CompositeSpecificationParameter
                            {
                                FilterPath = specificationFilterByName[kvp.Key]
                                    .FilterPath,
                                Value = value
                            });

                        // Remove the processed Specification-based query string parameter
                        queryStringParameters.Remove(kvp.Key);
                    }

                    return parameters;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                HttpContext.Items.Add("Exception", ex);

                // Process translations to Problem Details
                problemDetails = _problemDetailsProvider.GetProblemDetails(ex);
            }

            if (problemDetails != null)
            {
                return StatusCode(problemDetails.Status, problemDetails);
            }

            return Ok(json);

            NullValueHandling GetNullValueHandling()
            {
                // The custom 'IncludeNulls' header is supported for testing purposes.
                if (Request.Headers.TryGetValue("IncludeNulls", out StringValues headerValues)
                    && headerValues.Contains("true"))
                {
                    return NullValueHandling.Include;
                }

                return NullValueHandling.Ignore;
            }
        }
    }
}
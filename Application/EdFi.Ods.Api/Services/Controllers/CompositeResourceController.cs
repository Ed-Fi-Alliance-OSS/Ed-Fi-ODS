// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Xml.Linq;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Common.Infrastructure.Composites;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Inflection;
using EdFi.Ods.Common.Metadata;
using log4net;
using Newtonsoft.Json;

namespace EdFi.Ods.Api.Services.Controllers
{
    // TODO: As part of ODS-2973 move this to another namespace so it doesn't get registered with the other api controllers, and explicitly register it in the CompositesFeatureInstaller
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authenticate]
    public class CompositeResourceController : ApiController
    {
        private static readonly HashSet<string> StandardApiRouteKeys
            = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
            {
                "compositeVersion",
                "compositeCategory",
                "compositeName",
                "controller",
                "id",
                "organizationCode",
                "schoolYearFromRoute",
            };
        private readonly ICompositesMetadataProvider _compositeMetadataProvider;
        private readonly ICompositeResourceResponseProvider _compositeResourceResponseProvider;
        private readonly ILog _logger = LogManager.GetLogger(typeof(CompositeResourceController));
        private readonly IRESTErrorProvider _restErrorProvider;

        public CompositeResourceController(
            ICompositeResourceResponseProvider compositeResourceResponseProvider,
            ICompositesMetadataProvider compositeMetadataProvider,
            IRESTErrorProvider restErrorProvider)
        {
            _compositeResourceResponseProvider = compositeResourceResponseProvider;
            _compositeMetadataProvider = compositeMetadataProvider;
            _restErrorProvider = restErrorProvider;
        }

        public virtual IHttpActionResult Get()
        {
            string json = null;
            RESTError restError = null;

            try
            {
                var routeDataValues = ActionContext.RequestContext.RouteData.Values;

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
                var rawQueryStringParameters = ActionContext.Request.RequestUri.ParseQueryString();

                var queryStringParameters =
                    rawQueryStringParameters.AllKeys.ToDictionary<string, string, object>(

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
                        return BadRequest("Limit must be omitted or set to a value between 1 and 100.");
                    }
                }

                // Process specification for route and query string parameters
                var specificationParameters = GetCompositeSpecificationParameters(
                    compositeDefinition, routeDataValues, queryStringParameters);

                // Ensure all matched route key values were used by the current composite
                var suppliedSpecificationParameters =
                    routeDataValues
                        .Where(kvp => !StandardApiRouteKeys.Contains(kvp.Key));

                var unusedSpecificationParameters =
                    suppliedSpecificationParameters
                        .Where(kvp => !specificationParameters.ContainsKey(kvp.Key));

                if (unusedSpecificationParameters.Any())
                {
                    return new StatusCodeResult(HttpStatusCode.NotFound, this);
                }

                AddInherentSupportForIdParameter(specificationParameters);

                json = _compositeResourceResponseProvider.GetJson(
                    compositeDefinition,
                    specificationParameters,
                    queryStringParameters,
                    GetNullValueHandling());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                restError = _restErrorProvider.GetRestErrorFromException(ex);
            }

            if (restError != null)
            {
                return string.IsNullOrWhiteSpace(restError.Message)
                    ? new StatusCodeResult((HttpStatusCode) restError.Code, this)
                    : new StatusCodeResult((HttpStatusCode) restError.Code, this).WithError(restError.Message);
            }

            return new ResponseMessageResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                });
        }

        private NullValueHandling GetNullValueHandling()
        {
            NullValueHandling nullHandling = NullValueHandling.Ignore;

            // The custom 'IncludeNulls' header is supported for testing purposes.
            if (ActionContext.Request.Headers.TryGetValues("IncludeNulls", out IEnumerable<string> headerValues)
                && headerValues.Contains("true"))
            {
                nullHandling = NullValueHandling.Include;
            }

            return nullHandling;
        }

        private void AddInherentSupportForIdParameter(IDictionary<string, CompositeSpecificationParameter> parameters)
        {
            if (!ActionContext.RequestContext.RouteData.Values.TryGetValue("id", out object idAsObject))
            {
                return;
            }

            if (!Guid.TryParse(idAsObject.ToString(), out Guid id))
            {
                throw new BadRequestException("The supplied resource identifier is invalid.");
            }

            parameters.Add(
                "Id",
                new CompositeSpecificationParameter
                {
                    FilterPath = "Id",
                    Value = id
                });
        }

        private static IDictionary<string, CompositeSpecificationParameter>
            GetCompositeSpecificationParameters(
            XElement compositeDefinition,
            IDictionary<string, object> routeDataValues,
            IDictionary<string, object> queryStringParameters)
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

            var parameters = new Dictionary<string, CompositeSpecificationParameter>();

            // Identify relevant route values
            var matchingRouteValues = routeDataValues
                .Where(x => specificationFilterByName.ContainsKey(x.Key));

            // Copy route values that match the specification to the parameter dictionary
            foreach (var kvp in matchingRouteValues)
            {
                parameters.Add(
                    kvp.Key,
                    new CompositeSpecificationParameter
                    {
                        FilterPath = specificationFilterByName[kvp.Key]
                            .FilterPath,
                        Value = kvp.Value
                    });
            }

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
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.XsdMetadata
{
    [ApiController]
    [Produces("application/json")]
    [AllowAnonymous]
    [ApplyOdsRouteRootTemplate]
    [Route("metadata/xsd")]
    public class XsdMetadataController : ControllerBase
    {
        private readonly ApiSettings _apiSettings;
        private readonly bool _isEnabled;
        private readonly IXsdFileInformationProvider _xsdFileInformationProvider;

        public XsdMetadataController(ApiSettings apiSettings,
            IXsdFileInformationProvider xsdFileInformationProvider)
        {
            _xsdFileInformationProvider = xsdFileInformationProvider;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.XsdMetadata.GetConfigKeyName());
            _apiSettings = apiSettings;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            var uriSegments = _xsdFileInformationProvider.Schemas();

            if (!uriSegments.Any())
            {
                return Ok(Array.Empty<Dictionary<string, object>>());
            }

            return Ok(
                uriSegments
                    .Select(uriSegment => _xsdFileInformationProvider.XsdFileInformationByUriSegment(uriSegment))
                    .Select(
                        xsdFileInformation =>
                            new
                            {
                                description = xsdFileInformation.IsCore()
                                    ? $"Core schema ({xsdFileInformation.SchemaNameMap.LogicalName}) files for the data model"
                                    : $"Extension {xsdFileInformation.SchemaNameMap.LogicalName} blended with Core schema files for the data model",
                                name = xsdFileInformation.SchemaNameMap.LogicalName,
                                version = xsdFileInformation.Version,
                                files = new Uri(
                                    GetMetadataAbsoluteUrl("files", xsdFileInformation.SchemaNameMap.UriSegment))
                            }));
        }

        [HttpGet]
        [Route("{schema}/files")]
        public IActionResult GetFiles([FromRoute] string schema)
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            var schemaInformation = _xsdFileInformationProvider.XsdFileInformationByUriSegment(schema);

            if (schemaInformation == default)
            {
                return Ok(new Uri[0]);
            }

            var results = schemaInformation.SchemaFiles
                .Select(x => GetMetadataAbsoluteUrl(x, schemaInformation.SchemaNameMap.UriSegment))
                .ToList();

            if (!schemaInformation.IsCore())
            {
                var coreInformation = _xsdFileInformationProvider.CoreXsdFileInformation();

                results.AddRange(
                    coreInformation.SchemaFiles
                        .Select(x => GetMetadataAbsoluteUrl(x, coreInformation.SchemaNameMap.UriSegment)));
            }

            return Ok(results.OrderBy(x => x.ToString()));
        }

        private string GetMetadataAbsoluteUrl(string schemaFile, string uriSegment)
        {
            string rootUrl = Request.RootUrl(_apiSettings.GetReverseProxySettings());

            if (_apiSettings.IsFeatureEnabled(ApiFeature.MultiTenancy.GetConfigKeyName()))
            {
                if (HttpContext.Request.RouteValues.TryGetValue("tenantIdentifier", out object tenantIdentifier))
                {
                    rootUrl = $"{rootUrl}/{tenantIdentifier}";
                }
            }

            if (!string.IsNullOrEmpty(_apiSettings.OdsContextRouteTemplate))
            {
                string odsContextUriTemplatePath = _apiSettings.GetOdsContextRoutePath();
                string[] odsContextRouteKeys = _apiSettings.GetOdsContextRouteTemplateKeys();

                // Perform URI template replacements from route values, if available on current request
                foreach (string odsContextRouteKey in odsContextRouteKeys)
                {
                    if (HttpContext.Request.RouteValues.TryGetValue(odsContextRouteKey, out object odsContextRouteValue))
                    {
                        odsContextUriTemplatePath = odsContextUriTemplatePath.Replace(
                            $"{{{odsContextRouteKey}}}",
                            (string)odsContextRouteValue);
                    }
                }

                rootUrl = $"{rootUrl}/{odsContextUriTemplatePath}";
            }

            return $"{rootUrl}/metadata/xsd/{uriSegment}/{schemaFile}";
        }
    }
}

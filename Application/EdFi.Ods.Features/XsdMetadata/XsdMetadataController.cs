// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Features.XsdMetadata.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.XsdMetadata
{
    [ApiController]
    [Produces("application/json")]
    [Route("xsd")]
    [AllowAnonymous]
    public class XsdMetadataController : ControllerBase
    {
        private readonly bool _isEnabled;
        private readonly IUrlHelper _urlHelper;
        private readonly IXsdFileInformationProvider _xsdFileInformationProvider;

        public XsdMetadataController(ApiSettings settings,
            IXsdFileInformationProvider xsdFileInformationProvider,
            IUrlHelper urlHelper)
        {
            _xsdFileInformationProvider = xsdFileInformationProvider;
            _urlHelper = urlHelper;
            _isEnabled = settings.IsFeatureEnabled(ApiFeature.XsdMetadata.GetConfigKeyName());
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
                return Ok(new Dictionary<string, object>[0]);
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
                                name = xsdFileInformation.SchemaNameMap.UriSegment,
                                version = xsdFileInformation.Version,
                                files = new Uri(
                                    $"{_urlHelper.ActionLink("Get", ControllerContext.ActionDescriptor.ControllerName)}/{xsdFileInformation.SchemaNameMap.UriSegment}/files/")

                                // TODO ODS-4773
                                // ["combined"] = new Uri(
                                //     $"{_urlHelper.ActionLink("Get", ControllerContext.ActionDescriptor.ControllerName)}/{xsdFileInformation.SchemaNameMap.UriSegment}/"),
                            }));
        }

        [HttpGet]
        [Route("{schema}/files")]
        public IActionResult GetFiles([FromRoute] XsdMetadataRequest request)
        {
            if (!_isEnabled)
            {
                return NotFound();
            }

            var schemaInformation = _xsdFileInformationProvider.XsdFileInformationByUriSegment(request.Schema);

            if (schemaInformation == default)
            {
                return Ok(new Uri[0]);
            }

            var results = schemaInformation.SchemaFiles
                .Select(x=> GetMetadataAbsoluteUrl(x, schemaInformation.SchemaNameMap.UriSegment))
                .ToList();
            
            if (!schemaInformation.IsCore())
            {
                var coreInformation = _xsdFileInformationProvider.CoreXsdFileInformation();

                results.AddRange(coreInformation.SchemaFiles
                        .Select(x => GetMetadataAbsoluteUrl(x, coreInformation.SchemaNameMap.UriSegment))
                        .ToList());
            }

            string GetMetadataAbsoluteUrl(string schemaFile, string uriSegment)
            {
                // Construct fully qualified metadata url
                var url =
                    new Uri(
                        new Uri(
                            new Uri(Request.RootUrl(_useProxyHeaders).EnsureSuffixApplied("/")),
                            "metadata/"),
                        $"{request.SchoolYearFromRoute}/{ControllerContext.ActionDescriptor.ControllerName.Substring(0, 3)}/{uriSegment}/{schemaFile}");

                return url.AbsoluteUri;
            }

            return Ok(results.OrderBy(x => x.ToString()));
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
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
        private readonly ApiSettings _apiSettings;
        private readonly IInstanceIdContextProvider _instanceIdContextProvider;
        private readonly bool _isEnabled;
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;
        private readonly IXsdFileInformationProvider _xsdFileInformationProvider;

        public XsdMetadataController(ApiSettings apiSettings,
            IXsdFileInformationProvider xsdFileInformationProvider,
            ISchoolYearContextProvider schoolYearContextProvider = null,
            IInstanceIdContextProvider instanceIdContextProvider = null)
        {
            _xsdFileInformationProvider = xsdFileInformationProvider;
            _schoolYearContextProvider = schoolYearContextProvider;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.XsdMetadata.GetConfigKeyName());
            _apiSettings = apiSettings;
            _instanceIdContextProvider = instanceIdContextProvider;
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
            bool isInstanceYearSpecific = _apiSettings.GetApiMode().Equals(ApiMode.InstanceYearSpecific);

            bool isYearSpecific = _apiSettings.GetApiMode().Equals(ApiMode.YearSpecific)
                                  || isInstanceYearSpecific;

            bool useReverseProxyHeaders = _apiSettings.UseReverseProxyHeaders ?? false;

            string basicPath = Request.RootUrl(useReverseProxyHeaders) + "/metadata/" +
                               (isInstanceYearSpecific
                                   ? $"{_instanceIdContextProvider.GetInstanceId()}/"
                                   : string.Empty) +
                               (isYearSpecific
                                   ? $"{_schoolYearContextProvider.GetSchoolYear()}/"
                                   : string.Empty) +
                               "xsd";

            return $"{basicPath}/{uriSegment}/{schemaFile}";
        }
    }
}

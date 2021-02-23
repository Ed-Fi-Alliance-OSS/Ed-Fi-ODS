// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EdFi.LoadTools.Engine;
using log4net;
using Newtonsoft.Json;

namespace EdFi.LoadTools.ApiClient.XsdMetadata
{
    public class XsdMetadataInformationProvider : IXsdMetadataInformationProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(XsdMetadataInformationProvider));

        public async Task<List<XsdMetadataInformation>> GetXsdMetadataInformationAsync(HttpClient httpClient,
            string xsdMetadataUrl)
        {
            _logger.Info($"Getting all xsd metadata information from '{xsdMetadataUrl}'");

            var response = await httpClient.GetAsync(xsdMetadataUrl).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<XsdMetadataInformation>>
                (await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EdFi.LoadTools.ApiClient
{
    public class OdsVersionRetriever : IOdsVersionRetriever
    {
        private readonly IConfiguration _configuration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(OdsVersionInformation));

        public OdsVersionRetriever(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<OdsVersionInformation> GetApiVersionInformationAsync()
        {
            using var client = new HttpClient {Timeout = new TimeSpan(0, 0, 5, 0)};

            var url = _configuration.GetValue<string>("OdsApi:Url");

            _logger.Info($"Getting version information from '{url}");

            var response = await client.GetAsync(url)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<OdsVersionInformation>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}

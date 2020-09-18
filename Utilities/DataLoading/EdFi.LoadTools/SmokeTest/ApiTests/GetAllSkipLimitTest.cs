// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public class GetAllSkipLimitTest : GetBaseTest
    {
        public GetAllSkipLimitTest(
            Resource resource,
            Dictionary<string, JArray> resultsDictionary,
            IApiConfiguration configuration,
            IOAuthTokenHandler tokenHandler,
            HttpClient client = null)
            : base(resource, resultsDictionary, configuration, tokenHandler, client) { }

        protected override bool ShouldPerformTest()
        {
            return !Operation.parameters.Any(p => p.name == "id" && p.required == true && p.@in == "path");
        }

        protected override string OnGetPath(string path)
        {
            return path + "?offset=1&limit=1";
        }

        protected override bool IsExpectedResponse(HttpResponseMessage response, JArray results)
        {
            var stored = ResultsDictionary.FirstOrDefault(r => Resource.Name == r.Key);

            if (string.IsNullOrEmpty(stored.Key))
            {
                return false;
            }

            // If there is only one object in the unfiltered results,
            // then the API seems to ignore offset and returns the one every time
            return stored.Value.Count <= 1 || results.Count == 1 && stored.Value.Count >= 2;
        }
    }
}

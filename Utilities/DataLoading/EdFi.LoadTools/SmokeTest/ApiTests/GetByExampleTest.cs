// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public class GetByExampleTest : GetBaseTest
    {
        public GetByExampleTest(
            Resource resource,
            Dictionary<string, JArray> resultsDictionary,
            IApiConfiguration configuration,
            IOAuthTokenHandler tokenHandler)
            : base(resource, resultsDictionary, configuration, tokenHandler) { }

        protected override bool ShouldPerformTest()
        {
            return !Operation
                   .Parameters
                   .Any(
                        p => "id".Equals(p.Name, StringComparison.CurrentCultureIgnoreCase) &&
                             p.Required == true &&
                             p.In == ParameterLocation.Path);
        }

        protected override string OnGetPath(string path)
        {
            var obj = GetResult();

            if (obj == null)
            {
                return path;
            }

            var jobj = Flatten(obj);

            return path + "?" + string.Join(
                       "&",
                       Operation.Parameters.Where(x => x.In == ParameterLocation.Query && x.Name != "id")
                                .Select(
                                     x => jobj[x.Name] == null
                                         ? null
                                         : x.Schema.Type == "date-time"
                                             ? $"{x.Name}={jobj[x.Name]:yyyy-MM-dd}"
                                             : $"{x.Name}={Uri.EscapeDataString(jobj[x.Name].ToString())}")
                                .Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}

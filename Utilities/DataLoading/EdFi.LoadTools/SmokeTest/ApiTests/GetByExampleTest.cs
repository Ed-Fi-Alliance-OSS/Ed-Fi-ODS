// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
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
                   .parameters
                   .Any(
                        p => "id".Equals(p.name, StringComparison.CurrentCultureIgnoreCase) &&
                             p.required == true &&
                             "path".Equals(p.@in, StringComparison.CurrentCultureIgnoreCase));
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
                       Operation.parameters.Where(x => x.@in == "query" && x.name != "id")
                                .Select(
                                     x => jobj[x.name] == null
                                         ? null
                                         : x.type == "date-time"
                                             ? $"{x.name}={jobj[x.name]:yyyy-MM-dd}"
                                             : $"{x.name}={Uri.EscapeDataString(jobj[x.name].ToString())}")
                                .Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}

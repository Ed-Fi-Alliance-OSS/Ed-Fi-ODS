// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;

namespace EdFi.LoadTools.SmokeTest.ApiTests
{
    public class GetByIdTest : GetBaseTest
    {
        public GetByIdTest(
            Resource resource,
            Dictionary<string, JArray> resultsDictionary,
            IApiConfiguration configuration,
            IOAuthTokenHandler tokenHandler)
            : base(resource, resultsDictionary, configuration, tokenHandler) { }

        protected override bool ShouldPerformTest()
        {
            return GetParameters().Any();
        }

        protected override string OnGetPath(string path)
        {
            var name = GetParameters().First().Name;

            var obj = GetResult()?[name];

            if (obj == null)
            {
                throw new Exception(string.Format("Unable to find the test data for {0}.", Resource.Name));
            }

            return Path.Combine(path, obj.ToString());
        }

        private IEnumerable<OpenApiParameter> GetParameters()
        {
            return Operation.Parameters.Where(p => p.Name == "id" && p.Required == true && p.In == ParameterLocation.Path);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Api.Constants;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebApi.IntegrationTests.Controllers
{
    [TestFixture]
    public class VersionControllerTests : HttpClientTestsBase
    {
        [Test]
        public async Task VersionEndpointGetShouldBeValid()
        {
            var response = await HttpClient.GetAsync(TestConstants.BaseUrl);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldNotBeNullOrWhiteSpace();

            var results = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            results["version"].ShouldBe(ApiVersionConstants.Version);
            results["informationalVersion"].ShouldBe(ApiVersionConstants.Version);
            results["suite"].ShouldBe(ApiVersionConstants.Suite);
            results["build"].ShouldNotBeNull();
            results["apiMode"].ShouldNotBeNull();
            results["dataModels"].ShouldNotBeNull();
            results["urls"].ShouldNotBeNull();
        }
    }
}
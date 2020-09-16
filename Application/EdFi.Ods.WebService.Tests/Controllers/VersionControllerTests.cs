// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebService.Tests
{
    [TestFixture]
    public class VersionControllerTests : HttpClientTestsBase
    {
        [Test]
        public async Task VersionEndpointGetShouldBeValid()
        {
            var response = await _httpClient.GetAsync(TestConstants.BaseUrl);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldNotBeNullOrWhiteSpace();

            var results = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            results["version"].ShouldNotBeNull();
            results["informationalVersion"].ShouldNotBeNull();
            results["suite"].ShouldNotBeNull();
            results["build"].ShouldNotBeNull();
            results["apiMode"].ShouldNotBeNull();
            results["dataModels"].ShouldNotBeNull();
            results["urls"].ShouldNotBeNull();
        }
    }
}
#endif
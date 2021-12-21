// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Net;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebApi.IntegrationTests.Sandbox.Controllers
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter), typeof(NUnitReporter))]
    public class HealthCheckControllerTests : HttpClientTestsBase
    {
        [Test]
        public async Task HealthCheckEndpointGetShouldBeValid()
        {
            var response = await HttpClient.GetAsync(TestConstants.SandboxBaseUrl + "health/");

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var result = await response.Content.ReadAsStringAsync();

            result.ShouldNotBeNullOrWhiteSpace();
            result.Equals("Healthy").ShouldBeTrue();
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebService.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter), typeof(NUnitReporter))]
    public class VersionControllerTests : HttpClientTestsBase
    {
        [Test]
        public async Task VersionEndpointGetShouldBeValid()
        {
            var response = await _httpClient.GetAsync(TestConstants.BaseUrl);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldNotBeNullOrWhiteSpace();

            // hack for team city
            var filename = Path.Combine(TestContext.CurrentContext.TestDirectory, "VersionControllerTests.VersionEndpointGetShouldBeValid.received.txt");
            await File.AppendAllTextAsync(filename, json.Replace("\r\n", "\n"), CancellationToken.None);

            Approvals.VerifyFile(filename);
        }
    }
}
#endif
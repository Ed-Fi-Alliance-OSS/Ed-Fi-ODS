// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using EdFi.Ods.Api.Constants;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebApi.IntegrationTests.Controllers
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter), typeof(NUnitReporter))]
    public class AggregateDependencyControllerTests : HttpClientTestsBase
    {
        [Test]
        public async Task Should_Get_Dependencies()
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString());

            var response = await HttpClient.GetAsync(TestConstants.BaseUrl + UriHelper.BuildOdsUri("dependencies", null, null, true));

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            json.ShouldNotBeNullOrWhiteSpace();

            // fix for teamcity
            Approvals.Verify(json, s =>  s.Replace(@"\r\n", @"\n"));
        }

        [Test]
        public async Task Should_Get_Dependencies_GraphML()
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CustomMediaContentTypes.GraphML));

            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString());

            var response = await HttpClient.GetAsync(TestConstants.BaseUrl + UriHelper.BuildOdsUri("dependencies", null, null, true));

            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var xml = await response.Content.ReadAsStringAsync();

            xml.ShouldNotBeNullOrWhiteSpace();

            // fix for teamcity
            Approvals.Verify(xml, s => s.Replace(@"\r\n", @"\n"));
        }
    }
}
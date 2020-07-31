// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ApprovalTests;
using ApprovalTests.Reporters;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.WebService.Tests.Owin;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.WebService.Tests.ApprovalTests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class AggregateDependencyControllerTests : OwinTestBase
    {
        [Test]
        public void Should_Get_Dependencies()
        {
            string dependenciesResult;

            using (var startup = new OwinStartup(DatabaseName, DefaultLocalEducationAgencyIds))
            {
                using (var server = TestServer.Create(startup.Configuration))
                {
                    using (var client = new HttpClient(server.Handler))
                    {
                        client.Timeout = new TimeSpan(0, 0, 15, 0);

                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", Guid.NewGuid().ToString());

                        var dependencies = client.GetAsync(OwinUriHelper.BuildOdsUri("dependencies", null, null, true))
                            .GetResultSafely();

                        dependencies.EnsureSuccessStatusCode();

                        dependenciesResult = dependencies.Content.ReadAsStringAsync().GetResultSafely();
                    }
                }
            }

            dependenciesResult.ShouldNotBeNullOrEmpty();
            Approvals.Verify(dependenciesResult);
        }
    }
}

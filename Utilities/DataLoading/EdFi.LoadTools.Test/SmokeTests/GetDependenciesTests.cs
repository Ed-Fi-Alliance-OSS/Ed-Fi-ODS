// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Configuration;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest.CommonTests;
using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class GetDependenciesTests
    {
        [Test]
        public async System.Threading.Tasks.Task Should_succeed_against_a_running_serverAsync()
        {
            var address = "http://localhost:23456/";

            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(
                    webHost =>
                    {
                        // Add TestServer
                        webHost.UseTestServer();
                        
                        webHost.Configure(
                            app => app.Run(
                                async ctx =>
                                    await ctx.Response.WriteAsync("successful result")));
                    });

            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();
            client.BaseAddress = new System.Uri(address);

            var request = new HttpRequestMessage(HttpMethod.Get, address);
            var response = await client.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("successful result", responseString);
        }

        [Test]
        public void Should_fail_against_no_server()
        {
            const string DependenciesUrl = "http://localhost:12345";
            var configuration = Mock.Of<IApiMetadataConfiguration>(cfg => cfg.DependenciesUrl == DependenciesUrl);
            var subject = new GetStaticDependenciesTest(configuration);
            var result = subject.PerformTest().Result;
            Assert.IsFalse(result);
        }
    }
}

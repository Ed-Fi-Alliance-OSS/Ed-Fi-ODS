// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest.CommonTests;
using FakeItEasy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class GetVersionTests
    {
        private static string _address;

        public static IHost Host { get; private set; }

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            _address = config.GetSection("TestingWebServerAddress").Value;

            // Create and start up the host
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseUrls(_address);

                        webBuilder.Configure(
                            app => app.Run(
                                async ctx =>
                                    await ctx.Response.WriteAsync("successful result")));
                    })
                .Build();

            await Host.StartAsync();
        }

        [OneTimeTearDown]
        public async Task OneTmeTearDown()
        {
            await Host?.StopAsync();
            Host?.Dispose();
        }

        [Test]
        public async Task Should_succeed_against_a_running_serverAsync()
        {
            var configuration = A.Fake<IApiMetadataConfiguration>();
            A.CallTo(() => configuration.Url).Returns(_address);

            var subject = new GetStaticVersionTest(configuration);
            var result = await subject.PerformTest();
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Should_fail_against_no_serverAsync()
        {
            const string Url = "http://localhost:12345";

            var configuration = A.Fake<IApiMetadataConfiguration>();
            A.CallTo(() => configuration.Url).Returns(Url);

            var subject = new GetStaticVersionTest(configuration);
            var result = await subject.PerformTest();
            Assert.IsFalse(result);
        }
    }
}

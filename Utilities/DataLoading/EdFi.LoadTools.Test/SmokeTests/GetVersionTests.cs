// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Configuration;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest.CommonTests;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Moq;
using Owin;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class GetVersionTests
    {
        [Test]
        public void Should_succeed_against_a_running_server()
        {
            var address = ConfigurationManager.AppSettings["TestingWebServerAddress"];

            using (WebApp.Start(
                address, app => { app.Run(async context => { await context.Response.WriteAsync("successful result"); }); }))
            {
                var configuration = Mock.Of<IApiMetadataConfiguration>(cfg => cfg.Url == address);
                var subject = new GetStaticVersionTest(configuration);
                var result = subject.PerformTest().Result;
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void Should_fail_against_no_server()
        {
            const string Url = "http://localhost:12345";
            var configuration = Mock.Of<IApiMetadataConfiguration>(cfg => cfg.Url == Url);
            var subject = new GetStaticVersionTest(configuration);
            var result = subject.PerformTest().Result;
            Assert.IsFalse(result);
        }
    }
}

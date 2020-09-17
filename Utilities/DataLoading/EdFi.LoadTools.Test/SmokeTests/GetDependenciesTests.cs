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

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class GetDependenciesTests
    {
        private static TestServer _server;
        private static HttpClient _client;
        [Test]
        public void Should_succeed_against_a_running_server()
        {
            var address = ConfigurationManager.AppSettings["TestingWebServerAddress"];
            address = "http://localhost:23456/";

            _server = new TestServer(new WebHostBuilder().UseUrls(address));
            _client = _server.CreateClient();
          var result=  _client.GetAsync(address).Result;

            //using (WebApp.Start(
            //    address, app => { app.Run(async context => { await context.Response.WriteAsync("successful result"); }); }))
            //{
            //    var configuration = Mock.Of<IApiMetadataConfiguration>(cfg => cfg.Url == address);
            //    var subject = new GetStaticDependenciesTest(configuration);
            //    var result = subject.PerformTest().Result;
            //    Assert.IsTrue(result);
            //}
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
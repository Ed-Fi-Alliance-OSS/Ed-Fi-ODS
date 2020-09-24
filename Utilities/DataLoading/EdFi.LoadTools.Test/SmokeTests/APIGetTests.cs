// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.SmokeTest.ApiTests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class ApiGetTests
    {
        public static IHost Host { get; private set; }

        private const string ResourceName = "testResource";
        private const string IdName = "id";
        private const string KeyName = "aKey";
        private const string PropertyName = "aProperty";

        private const string Swagger =
            @"{ 
            paths: {
              ""TestNamespace/TestResource"": {
                ""get"": {
                  ""parameters"": [
                    {
                      ""name"": ""TestIdentifier"",
                      ""in"": ""query"",
                      ""required"": false,
                      ""type"": ""string""
                    }
                  ],
                  ""responses"": {
                    ""200"": {
                      ""schema"": {
                        ""type"": ""array"",
                        ""items"": {
                            ""$ref"": ""#/definitions/edFi_academicWeek""
                        }
                      }
                    }
                  }
                }
              }
            }}";

        private static string Address = string.Empty;

        private static readonly JObject Obj1 = new JObject(
            new JProperty(IdName, 1), new JProperty("aKey", "a"),
            new JProperty("aProperty", "b"));

        private static readonly JObject Obj2 = new JObject(
            new JProperty(IdName, 2), new JProperty("aKey", "b"),
            new JProperty("aProperty", "b"));

        private readonly JArray _data = new JArray(Obj1, Obj2);
        private readonly IOAuthSessionToken _token = Mock.Of<IOAuthSessionToken>(t => t.SessionToken == "something");

        private readonly SwaggerDocument Doc = JsonConvert.DeserializeObject<SwaggerDocument>(Swagger);

        private readonly IOAuthTokenHandler tokenHandler = Mock.Of<IOAuthTokenHandler>();

        private Resource _resource;

        [OneTimeSetUp]
        public async Task Setup()
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(TestContext.CurrentContext.TestDirectory)
            //    .AddJsonFile("appsettings.json", optional: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            Address = "http://localhost:23456/"; //config.GetSection("TestingWebServerAddress").Value;

            _resource = new Resource
            {
                Name = ResourceName,
                BasePath = "",
                Path = Doc.paths.Values.First()
            };

            var hostBuilder = new HostBuilder()
                    .ConfigureWebHost(
                        webHost =>
                        {
                            // Add TestServer
                            webHost.UseTestServer();
                            webHost.UseUrls(Address);

                            webHost.Configure(
                                app => app.Run(
                                    async context =>
                                    {
                                        context.Response.ContentType = "application/json";
                                        var pathSegments = context.Request.Path.Value.Split('/');

                                        if (pathSegments.Last() != ResourceName)
                                        {
                                            var id = int.Parse(pathSegments.Last());

                                            await context.Response.WriteAsync(
                                                JsonConvert.SerializeObject(
                                                    _data.SingleOrDefault(x => x[IdName].Value<int>() == id)));
                                        }
                                        else if (!string.IsNullOrEmpty(context.Request.Query["offset"]) &&
                                                 !string.IsNullOrEmpty(context.Request.Query["limit"]))
                                        {
                                            var skip = int.Parse(context.Request.Query["offset"]);
                                            var take = int.Parse(context.Request.Query["limit"]);

                                            await context.Response.WriteAsync(
                                                JsonConvert.SerializeObject(_data.Skip(skip).Take(take)));
                                        }
                                        else if (!string.IsNullOrEmpty(context.Request.Query[KeyName]))
                                        {
                                            var keyValue = context.Request.Query[KeyName];

                                            await context.Response.WriteAsync(
                                                JsonConvert.SerializeObject(
                                                    _data.SingleOrDefault(
                                                        x =>
                                                            x[KeyName].Value<string>() == keyValue)));
                                        }
                                        else if (!string.IsNullOrEmpty(context.Request.Query[PropertyName]))
                                        {
                                            var propertyValue = context.Request.Query[PropertyName];

                                            await context.Response.WriteAsync(
                                                JsonConvert.SerializeObject(
                                                    _data.Where(
                                                        x =>
                                                            x[PropertyName].Value<string>() == propertyValue)));
                                        }
                                        else
                                        {
                                            await context.Response.WriteAsync(JsonConvert.SerializeObject(_data));
                                        }
                                    }));
                        })
                ;

            Host = hostBuilder.Build();
            await Host.StartAsync();
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            await Host.StopAsync();
            Host.Dispose();
        }

        [Test]
        public async Task GetAll_should_store_results_in_dictionaryAsync()
        {
            var dictionary = new Dictionary<string, JArray>();

            var client = Host.GetTestClient();
            client.BaseAddress = new System.Uri(Address);

            var configuration = Mock.Of<IApiConfiguration>(cfg => cfg.Url == Address);

            var subject = new GetAllTest(_resource, dictionary, configuration, tokenHandler);
            var result = await subject.PerformTest();

            Assert.IsNotNull(dictionary[ResourceName]);
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetSkipLimitTest_should_retrieve_second_objectAsync()
        {
            var dictionary = new Dictionary<string, JArray> { [ResourceName] = _data };

            var configuration = Mock.Of<IApiConfiguration>(cfg => cfg.Url == Address);
            var subject = new GetAllSkipLimitTest(_resource, dictionary, configuration, tokenHandler);
            var result = await subject.PerformTest();

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetByIdTest_should_retrieve_single_objectAsync()
        {
            var dictionary = new Dictionary<string, JArray> { [ResourceName] = _data };
            var client = Host.GetTestClient();
            client.BaseAddress = new System.Uri(Address);

            var configuration = Mock.Of<IApiConfiguration>(cfg => cfg.Url == Address);
            var subject = new GetByIdTest(_resource, dictionary, configuration, tokenHandler);
            var result = await subject.PerformTest();

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetByExampleTest_should_retrieve_arrayAsync()
        {
            var dictionary = new Dictionary<string, JArray> { [ResourceName] = _data };
            var client = Host.GetTestClient();
            client.BaseAddress = new System.Uri(Address);

            var configuration = Mock.Of<IApiConfiguration>(cfg => cfg.Url == Address);
            var subject = new GetByExampleTest(_resource, dictionary, configuration, tokenHandler);
            var result = await subject.PerformTest();

            Assert.IsTrue(result);
        }
    }
}

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
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Owin;
using Swashbuckle.Swagger;

namespace EdFi.LoadTools.Test.SmokeTests
{
    [TestFixture]
    public class ApiGetTests
    {
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

        private static readonly string Address = ConfigurationManager.AppSettings["TestingWebServerAddress"];

        private static readonly JObject Obj1 = new JObject(
            new JProperty(IdName, 1), new JProperty("aKey", "a"),
            new JProperty("aProperty", "b"));

        private static readonly JObject Obj2 = new JObject(
            new JProperty(IdName, 2), new JProperty("aKey", "b"),
            new JProperty("aProperty", "b"));

        private readonly IApiConfiguration _configuration = Mock.Of<IApiConfiguration>(cfg => cfg.Url == Address);

        private readonly JArray _data = new JArray(Obj1, Obj2);
        private readonly IOAuthSessionToken _token = Mock.Of<IOAuthSessionToken>(t => t.SessionToken == "something");

        private readonly SwaggerDocument Doc = JsonConvert.DeserializeObject<SwaggerDocument>(Swagger);

        private readonly IOAuthTokenHandler tokenHandler = Mock.Of<IOAuthTokenHandler>();

        private Resource _resource;
        private IDisposable _webApp;

        [SetUp]
        public void Setup()
        {
            _resource = new Resource
                        {
                            Name = ResourceName, BasePath = "", Path = Doc.paths.Values.First()
                        };

            _webApp = WebApp.Start(
                Address, app =>
                         {
                             app.Run(
                                 async context =>
                                 {
                                     context.Response.ContentType = "application/json";
                                     var pathSegments = context.Request.Path.Value.Split('/');

                                     if (pathSegments.Last() != ResourceName)
                                     {
                                         var id = int.Parse(pathSegments.Last());

                                         await context.Response.WriteAsync(
                                             JsonConvert.SerializeObject(_data.SingleOrDefault(x => x[IdName].Value<int>() == id)));
                                     }
                                     else if (context.Request.Query["offset"] != null && context.Request.Query["limit"] != null)
                                     {
                                         var skip = int.Parse(context.Request.Query["offset"]);
                                         var take = int.Parse(context.Request.Query["limit"]);
                                         await context.Response.WriteAsync(JsonConvert.SerializeObject(_data.Skip(skip).Take(take)));
                                     }
                                     else if (context.Request.Query[KeyName] != null)
                                     {
                                         var keyValue = context.Request.Query[KeyName];

                                         await context.Response.WriteAsync(
                                             JsonConvert.SerializeObject(
                                                 _data.SingleOrDefault(
                                                     x =>
                                                         x[KeyName].Value<string>() == keyValue)));
                                     }
                                     else if (context.Request.Query[PropertyName] != null)
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
                                 });
                         });
        }

        [TearDown]
        public void Cleanup()
        {
            _webApp.Dispose();
        }

        [Test]
        public void GetAll_should_store_results_in_dictionary()
        {
            var dictionary = new Dictionary<string, JArray>();

            var subject = new GetAllTest(_resource, dictionary, _configuration, tokenHandler);
            var result = subject.PerformTest().Result;

            Assert.IsNotNull(dictionary[ResourceName]);
            Assert.IsTrue(result);
        }

        [Test]
        public void GetSkipLimitTest_should_retrieve_second_object()
        {
            var dictionary = new Dictionary<string, JArray>
                             {
                                 [ResourceName] = _data
                             };

            var subject = new GetAllSkipLimitTest(_resource, dictionary, _configuration, tokenHandler);
            var result = subject.PerformTest().Result;

            Assert.IsTrue(result);
        }

        [Test]
        public void GetByIdTest_should_retrieve_single_object()
        {
            var dictionary = new Dictionary<string, JArray>
                             {
                                 [ResourceName] = _data
                             };

            var subject = new GetByIdTest(_resource, dictionary, _configuration, tokenHandler);
            var result = subject.PerformTest().Result;

            Assert.IsTrue(result);
        }

        [Test]
        public void GetByExampleTest_should_retrieve_array()
        {
            var dictionary = new Dictionary<string, JArray>
                             {
                                 [ResourceName] = _data
                             };

            var subject = new GetByExampleTest(_resource, dictionary, _configuration, tokenHandler);
            var result = subject.PerformTest().Result;

            Assert.IsTrue(result);
        }
    }
}

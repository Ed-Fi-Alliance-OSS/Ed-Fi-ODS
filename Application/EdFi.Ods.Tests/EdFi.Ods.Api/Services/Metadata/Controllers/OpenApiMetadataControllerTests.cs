// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.OpenApiMetadata.Controllers;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Controllers
{
    public class OpenApiMetadataControllerTests
    {
        [TestFixture]
        public class When_calling_the_metadata_controller : LegacyTestFixtureBase
        {
            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var configValueProvider = new NameValueCollectionConfigValueProvider();
                configValueProvider.Values.Add("UseReverseProxyHeaders", "false");

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                _openApiMetadataCacheProvider.Stub(x => x.GetOpenApiContentByFeedName(Arg<string>.Is.Anything))
                                             .Return(OpenApiMetadataHelper.GetIdentityContent());

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);
                var config = new HttpConfiguration();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/metadata");
                var route = config.Routes.MapHttpRoute("default", "{controller}");

                config.Routes.MapHttpRoute(
                    "OAuthAuthorize",
                    "oauth/authorize",
                    new
                    {
                        controller = "Authorize"
                    });

                config.Routes.MapHttpRoute(
                    "OAuthToken",
                    "oauth/token",
                    new
                    {
                        controller = "Token"
                    });

                var routeData = new HttpRouteData(
                    route,
                    new HttpRouteValueDictionary
                    {
                        {
                            "controller", "metadata"
                        }
                    });

                _controller.ControllerContext = new HttpControllerContext(config, routeData, request);
                _controller.Request = request;
                _controller.Url = new UrlHelper(request);
                _controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
                _controller.RequestContext.VirtualPathRoot = "/";
            }

            [Assert]
            public async Task Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataRequest
                              {
                                  OtherName = "identity"
                              };

                HttpResponseMessage response = _controller.Get(request);
                Assert.IsNotNull(response);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

                var content = await response.Content.ReadAsStringAsync();
                Assert.IsNotNull(content);
                Assert.IsTrue(content.Contains("localhost:80"));
                Assert.IsTrue(content.Contains("http://localhost/oauth/token"));
            }
        }

        [TestFixture]
        public class When_calling_the_metadata_controller_with_use_reverse_proxy_and_forwarded_headers : LegacyTestFixtureBase
        {
            private const string XForwardedProto = "X-Forwarded-Proto";
            private const string XForwardedHost = "X-Forwarded-Host";
            private const string XForwardedPort = "X-Forwarded-Port";

            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var configValueProvider = new NameValueCollectionConfigValueProvider();
                configValueProvider.Values.Add("UseReverseProxyHeaders", "true");

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                _openApiMetadataCacheProvider.Stub(x => x.GetOpenApiContentByFeedName(Arg<string>.Is.Anything))
                                             .Return(OpenApiMetadataHelper.GetIdentityContent());

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);
                var config = new HttpConfiguration();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/metadata");
                var route = config.Routes.MapHttpRoute("default", "{controller}");

                config.Routes.MapHttpRoute(
                    "OAuthAuthorize",
                    "oauth/authorize",
                    new
                    {
                        controller = "Authorize"
                    });

                config.Routes.MapHttpRoute(
                    "OAuthToken",
                    "oauth/token",
                    new
                    {
                        controller = "Token"
                    });

                var routeData = new HttpRouteData(
                    route,
                    new HttpRouteValueDictionary
                    {
                        {
                            "controller", "metadata"
                        }
                    });

                _controller.ControllerContext = new HttpControllerContext(config, routeData, request);
                _controller.Request = request;
                _controller.Url = new UrlHelper(request);
                _controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
                _controller.RequestContext.VirtualPathRoot = "/";

                _controller.Request.Headers.Add(XForwardedProto, "https");
                _controller.Request.Headers.Add(XForwardedHost, "api.com");
                _controller.Request.Headers.Add(XForwardedPort, "443");
            }

            [Assert]
            public async Task Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataRequest
                              {
                                  OtherName = "identity"
                              };

                HttpResponseMessage response = _controller.Get(request);
                Assert.IsNotNull(response);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

                var content = await response.Content.ReadAsStringAsync();
                Assert.IsNotNull(content);
                Assert.IsTrue(content.Contains("api.com:443"));
                Assert.IsTrue(content.Contains("https://api.com/oauth/token"));
            }
        }

        [TestFixture]
        public class When_calling_the_metadata_controller_with_use_reverse_proxy_and_no_forwarded_headers : LegacyTestFixtureBase
        {
            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var configValueProvider = new NameValueCollectionConfigValueProvider();
                configValueProvider.Values.Add("UseReverseProxyHeaders", "true");

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                _openApiMetadataCacheProvider.Stub(x => x.GetOpenApiContentByFeedName(Arg<string>.Is.Anything))
                                             .Return(OpenApiMetadataHelper.GetIdentityContent());

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);
                var config = new HttpConfiguration();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/metadata");
                var route = config.Routes.MapHttpRoute("default", "{controller}");

                config.Routes.MapHttpRoute(
                    "OAuthAuthorize",
                    "oauth/authorize",
                    new
                    {
                        controller = "Authorize"
                    });

                config.Routes.MapHttpRoute(
                    "OAuthToken",
                    "oauth/token",
                    new
                    {
                        controller = "Token"
                    });

                var routeData = new HttpRouteData(
                    route,
                    new HttpRouteValueDictionary
                    {
                        {
                            "controller", "metadata"
                        }
                    });

                _controller.ControllerContext = new HttpControllerContext(config, routeData, request);
                _controller.Request = request;
                _controller.Url = new UrlHelper(request);
                _controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
                _controller.RequestContext.VirtualPathRoot = "/";
            }

            [Assert]
            public async Task Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataRequest
                              {
                                  OtherName = "identity"
                              };

                HttpResponseMessage response = _controller.Get(request);
                Assert.IsNotNull(response);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

                var content = await response.Content.ReadAsStringAsync();
                Assert.IsNotNull(content);
                Assert.IsTrue(content.Contains("localhost:80"));
                Assert.IsTrue(content.Contains("http://localhost/oauth/token"));
            }
        }
    }
}

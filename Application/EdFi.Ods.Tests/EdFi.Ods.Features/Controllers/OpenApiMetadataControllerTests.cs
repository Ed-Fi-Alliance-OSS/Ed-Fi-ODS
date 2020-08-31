// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System.Net;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.OpenApiMetadata.Models;
using EdFi.Ods.Tests.EdFi.Ods.Api.Services.Metadata.Helpers;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    public class OpenApiMetadataControllerTests
    {
        [TestFixture]
        public class When_calling_the_metadata_controller : TestFixtureBase
        {
            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;
            private const string XForwardedProto = "X-Forwarded-Proto";
            private const string XForwardedHost = "X-Forwarded-Host";
            private const string XForwardedPort = "X-Forwarded-Port";

            protected override void Arrange()
            {
                var configValueProvider = new ApiSettings();
                configValueProvider.UseReverseProxyHeaders = true;
                configValueProvider.Features.Add(new Feature { Name = "openApiMetadata", IsEnabled = true });

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(A<string>._))
                    .Returns(OpenApiMetadataHelper.GetIdentityContent());

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);
                // // var config = new HttpConfiguration();
                // var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/metadata");
                // var route = config.Routes.MapHttpRoute("default", "{controller}");
                //
                // config.Routes.MapHttpRoute(
                //     "OAuthAuthorize",
                //     "oauth/authorize",
                //     new
                //     {
                //         controller = "Authorize"
                //     });
                //
                // config.Routes.MapHttpRoute(
                //     "OAuthToken",
                //     "oauth/token",
                //     new
                //     {
                //         controller = "Token"
                //     });
                //
                // var routeData2 = new HttpRouteData(
                //     route,
                //     new HttpRouteValueDictionary
                //     {
                //         {
                //             "controller", "metadata"
                //         }
                //     });

                HttpContext httpContext = A.Fake<HttpContext>();
                RouteData routeData = new RouteData();
                ActionDescriptor actionDescriptor = A.Fake<ControllerActionDescriptor>();
                ActionContext context = new ActionContext(httpContext, routeData, actionDescriptor);

                _controller.ControllerContext = new ControllerContext(context);

                _controller.Request.Headers.Add(XForwardedProto, "https");
                _controller.Request.Headers.Add(XForwardedHost, "api.com");
                _controller.Request.Headers.Add(XForwardedPort, "443");

            }

            [Assert]
            public void Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataSectionRequest
                {
                    Sdk = true
                };


                var results =  (OkObjectResult)_controller.Get(request);

                Assert.IsNotNull(results);
                Assert.AreEqual(results.StatusCode, (int)HttpStatusCode.OK);

                //var content = await response.ExecuteResultAsync().Wait();
                //Assert.IsNotNull(content);
                //Assert.IsTrue(content.Contains("localhost:80"));
                //Assert.IsTrue(content.Contains("http://localhost/oauth/token"));
            }
        }

        [TestFixture]
        public class When_calling_the_metadata_controller_with_use_reverse_proxy_and_forwarded_headers : TestFixtureBase
        {
            private const string XForwardedProto = "X-Forwarded-Proto";
            private const string XForwardedHost = "X-Forwarded-Host";
            private const string XForwardedPort = "X-Forwarded-Port";

            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var apisetting = new ApiSettings();
                apisetting.UseReverseProxyHeaders = true;
                apisetting.Features.Add(new Feature{Name= "openApiMetadata",IsEnabled=true });

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(A<string>._))
                    .Returns(OpenApiMetadataHelper.GetIdentityContent());

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, apisetting);
                // var config = new HttpConfiguration();
                // var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/metadata");
                // var route = config.Routes.MapHttpRoute("default", "{controller}");
                //
                // config.Routes.MapHttpRoute(
                //     "OAuthAuthorize",
                //     "oauth/authorize",
                //     new
                //     {
                //         controller = "Authorize"
                //     });
                //
                // config.Routes.MapHttpRoute(
                //     "OAuthToken",
                //     "oauth/token",
                //     new
                //     {
                //         controller = "Token"
                //     });
                //
                // var routeData2 = new HttpRouteData(
                //     route,
                //     new HttpRouteValueDictionary
                //     {
                //         {
                //             "controller", "metadata"
                //         }
                //     });

                HttpContext httpContext = A.Fake<HttpContext>();
                RouteData routeData = new RouteData();
                ActionDescriptor actionDescriptor = A.Fake<ControllerActionDescriptor>();
                ActionContext context = new ActionContext(httpContext, routeData, actionDescriptor);

                _controller.ControllerContext = new ControllerContext(context);

                _controller.Request.Headers.Add(XForwardedProto, "https");
                _controller.Request.Headers.Add(XForwardedHost, "api.com");
                _controller.Request.Headers.Add(XForwardedPort, "443");
            }

            [Assert]
            public void Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataSectionRequest
                {
                    Sdk = true
                };

                var results = (OkObjectResult)_controller.Get(request);

                Assert.IsNotNull(results);
                Assert.AreEqual(results.StatusCode, (int)HttpStatusCode.OK);
            }
        }

        [TestFixture]
        public class When_calling_the_metadata_controller_with_use_reverse_proxy_and_no_forwarded_headers : TestFixtureBase
        {
            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var configValueProvider = new ApiSettings();
                configValueProvider.UseReverseProxyHeaders = false;
                configValueProvider.Features.Add(new Feature { Name = "openApiMetadata", IsEnabled = true });
                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(A<string>._))
                    .Returns(OpenApiMetadataHelper.GetIdentityContent());

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);
                // var config = new HttpConfiguration();
                // var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/metadata");
                // var route = config.Routes.MapHttpRoute("default", "{controller}");
                //
                // config.Routes.MapHttpRoute(
                //     "OAuthAuthorize",
                //     "oauth/authorize",
                //     new
                //     {
                //         controller = "Authorize"
                //     });
                //
                // config.Routes.MapHttpRoute(
                //     "OAuthToken",
                //     "oauth/token",
                //     new
                //     {
                //         controller = "Token"
                //     });
                //
                // var routeData2 = new HttpRouteData(
                //     route,
                //     new HttpRouteValueDictionary
                //     {
                //         {
                //             "controller", "metadata"
                //         }
                //     });

                //_controller.ControllerContext = new HttpControllerContext(config, routeData, request);
                //_controller.Request = request;
                //_controller.Url = new UrlHelper(request);
                //_controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
                //_controller.RequestContext.VirtualPathRoot = "/";


                ActionContext context = new ActionContext();
                context.HttpContext = A.Fake<HttpContext>();
                context.RouteData = A.Fake<RouteData>();

                context.ActionDescriptor = Stub<ControllerActionDescriptor>();

                _controller.ControllerContext = new ControllerContext(context);
            }

            [Assert]
            public void Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataSectionRequest
                {
                    Sdk = true
                };

                var results = (OkObjectResult)_controller.Get(request);

                Assert.IsNotNull(results);
                Assert.AreEqual(results.StatusCode, (int)HttpStatusCode.OK);

                //HttpResponseMessage response = _controller.Get(request);
                //Assert.IsNotNull(response);
                //Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

                //var content = await response.Content.ReadAsStringAsync();
                //Assert.IsNotNull(content);
                //Assert.IsTrue(content.Contains("localhost:80"));
                //Assert.IsTrue(content.Contains("http://localhost/oauth/token"));
            }
        }
    }
}
#endif
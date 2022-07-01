// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Net;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
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
using NHibernate.Criterion;
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

            protected override void Arrange()
            {
                var configValueProvider = new ApiSettings();
                configValueProvider.UseReverseProxyHeaders = false;
                Feature item = new Feature();
                item.IsEnabled = true;
                item.Name = "openApiMetadata";
                configValueProvider.Features.Add(item);

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(A<string>._))
                    .Returns(OpenApiMetadataHelper.GetIdentityContent());

                var fakeopenAPIcontent = A.Fake<List<OpenApiContent>>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetAllSectionDocuments(A<bool>._)).Returns(fakeopenAPIcontent);

                var sectiondata = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName("openApiMetadata");
                fakeopenAPIcontent.Add(sectiondata);

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);

                var request = A.Fake<HttpRequest>();
                request.Method = "Post";
                request.Scheme = "http";

                A.CallTo(() => request.Host).Returns(new HostString("localhost", 80));

                request.PathBase = "/";
                request.RouteValues = new RouteValueDictionary { {
                            "controller", "Token"
                        } };

                var httpContext = A.Fake<HttpContext>();

                A.CallTo(() => httpContext.Request).Returns(request);

                var controllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                };
                RouteValueDictionary dictionary = new RouteValueDictionary();
                dictionary.Add("controller", "Token");

                controllerContext.RouteData = new RouteData(dictionary);
                _controller.ControllerContext = controllerContext;
            }

            [Assert]
            public void Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataSectionRequest
                {
                    Sdk = true,
                    SchoolYearFromRoute = 2020
                };

                var response = (OkObjectResult)_controller.Get(request);
                var openapisectionlist = (List<OpenApiMetadataSectionDetails>)response.Value;

                Assert.AreEqual(200, response.StatusCode);
                Assert.IsNotNull(response);
                Assert.IsTrue(openapisectionlist.Count > 0);
                Assert.AreEqual("Identity", openapisectionlist[0].Name);
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("localhost"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("metadata"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("2020"));
                Assert.AreEqual("Other", openapisectionlist[0].Prefix);
            }
        }

        [TestFixture]
        public class When_calling_the_metadata_controller_with_use_reverse_proxy_and_forwarded_headers : TestFixtureBase
        {
            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var configValueProvider = new ApiSettings();
                configValueProvider.UseReverseProxyHeaders = true;
                configValueProvider.OverrideForForwardingHostPort = 80;
                configValueProvider.OverrideForForwardingHostServer = "localhost";

                Feature item = new Feature();
                item.IsEnabled = true;
                item.Name = "openApiMetadata";
                configValueProvider.Features.Add(item);

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(A<string>._))
                    .Returns(OpenApiMetadataHelper.GetIdentityContent());

                var fakeopenAPIcontent = A.Fake<List<OpenApiContent>>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetAllSectionDocuments(A<bool>._)).Returns(fakeopenAPIcontent);

                var sectiondata = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName("openApiMetadata");
                fakeopenAPIcontent.Add(sectiondata);
                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);

                var request = A.Fake<HttpRequest>();
                request.Method = "Post";
                request.Scheme = "http";

                A.CallTo(() => request.Host).Returns(new HostString("localhost", 80));

                request.PathBase = "/";
                request.RouteValues = new RouteValueDictionary { {
                            "controller", "Token"
                        } };

                var headerDictionary = A.Fake<IHeaderDictionary>();

                HeaderDictionary dict = new HeaderDictionary();
                dict.Add(HeaderConstants.XForwardedProto, "https");
                dict.Add(HeaderConstants.XForwardedHost, "api.com");
                dict.Add(HeaderConstants.XForwardedPort, "443");

                A.CallTo(() => request.Headers).Returns(dict);

                var httpContext = A.Fake<HttpContext>();

                A.CallTo(() => httpContext.Request).Returns(request);

                var controllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                };
                RouteValueDictionary dictionary = new RouteValueDictionary();
                dictionary.Add("controller", "Token");

                controllerContext.RouteData = new RouteData(dictionary);

                _controller.ControllerContext = controllerContext;
            }

            [Assert]
            public void Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataSectionRequest
                {
                    Sdk = true,
                    SchoolYearFromRoute = 2020
                };

                var response = (OkObjectResult)_controller.Get(request);

                var openapisectionlist = (List<OpenApiMetadataSectionDetails>)response.Value;
                Assert.AreEqual(200, response.StatusCode);
                Assert.IsNotNull(response);
                Assert.IsTrue(openapisectionlist.Count > 0);
                Assert.AreEqual("Identity", openapisectionlist[0].Name);
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("localhost"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("https"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("metadata"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("2020"));
                Assert.AreEqual("Other", openapisectionlist[0].Prefix);
            }
        }

        [TestFixture]
        public class When_calling_the_metadata_controller_with_use_reverse_proxy_and_no_forwarded_headers : TestFixtureBase
        {
            private OpenApiMetadataController _controller;
            private IOpenApiMetadataCacheProvider _openApiMetadataCacheProvider;

            protected override void Arrange()
            {
                var configValueProvider = new ApiSettings
                {
                    UseReverseProxyHeaders = true,
                    OverrideForForwardingHostPort = 80,
                    OverrideForForwardingHostServer = "localhost"
                };

                Feature item = new Feature();
                item.IsEnabled = true;
                item.Name = "openApiMetadata";
                configValueProvider.Features.Add(item);

                _openApiMetadataCacheProvider = Stub<IOpenApiMetadataCacheProvider>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetOpenApiContentByFeedName(A<string>._))
                    .Returns(OpenApiMetadataHelper.GetIdentityContent());

                var fakeopenAPIcontent = A.Fake<List<OpenApiContent>>();

                A.CallTo(() => _openApiMetadataCacheProvider.GetAllSectionDocuments(A<bool>._)).Returns(fakeopenAPIcontent);

                var sectiondata = _openApiMetadataCacheProvider.GetOpenApiContentByFeedName("openApiMetadata");
                fakeopenAPIcontent.Add(sectiondata);

                _controller = new OpenApiMetadataController(_openApiMetadataCacheProvider, configValueProvider);

                var request = A.Fake<HttpRequest>();
                request.Method = "Post";
                request.Scheme = "http";

                A.CallTo(() => request.Host).Returns(new HostString("localhost", 80));

                request.PathBase = "/";
                request.RouteValues = new RouteValueDictionary { {
                            "controller", "Token"
                        } };

                var httpContext = A.Fake<HttpContext>();

                A.CallTo(() => httpContext.Request).Returns(request);

                var controllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                };
                RouteValueDictionary dictionary = new RouteValueDictionary();
                dictionary.Add("controller", "Token");

                controllerContext.RouteData = new RouteData(dictionary);

                _controller.ControllerContext = controllerContext;
            }

            [Assert]
            public void Should_return_valid_http_response_message()
            {
                var request = new OpenApiMetadataSectionRequest
                {
                    Sdk = true,
                    SchoolYearFromRoute = 2020
                };

                var response = (OkObjectResult)_controller.Get(request);
                var openapisectionlist = (List<OpenApiMetadataSectionDetails>)response.Value;

                Assert.AreEqual(200, response.StatusCode);
                Assert.IsNotNull(response);
                Assert.IsTrue(openapisectionlist.Count > 0);
                Assert.AreEqual("Identity", openapisectionlist[0].Name);
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("localhost"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("metadata"));
                Assert.IsTrue(openapisectionlist[0].EndpointUri.Contains("2020"));
            }
        }
    }
}
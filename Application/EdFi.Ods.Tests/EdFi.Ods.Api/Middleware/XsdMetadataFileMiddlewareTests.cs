// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware
{
    [TestFixture]
    public class XsdMetadataFileMiddlewareTests
    {
        private static Dictionary<string, XsdFileInformation> CreateXsdFileInformationByUriSegment()
        {
            return new Dictionary<string, XsdFileInformation>(StringComparer.InvariantCultureIgnoreCase)
            {
                {
                    "ed-fi", new XsdFileInformation(
                        "EdFi.Ods.Standard",
                        "3.2.0-c",
                        new SchemaNameMap("Ed-Fi", "edfi", "ed-fi", "EdFi"),
                        new[] {"Ed-Fi-Core.xsd"})
                },
                {
                    "sample", new XsdFileInformation(
                        "EdFi.Ods.Extensions.Sample",
                        "1.0.0",
                        new SchemaNameMap("Sample", "sample", "sample", "Sample"),
                        new[] {"Sample.xsd"})
                }
            };
        }

        public class SandboxTests
        {
            private IEmbeddedFileProvider _embeddedFileProvider;
            private XsdMetadataFileMiddleware _sut;
            private IXsdFileInformationProvider _xsdFileInformationProvider;

            [SetUp]
            public void SetUp()
            {
                _xsdFileInformationProvider = A.Fake<IXsdFileInformationProvider>();
                _embeddedFileProvider = A.Fake<IEmbeddedFileProvider>();

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi"))
                    .Returns(CreateXsdFileInformationByUriSegment()["ed-fi"]);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("sample"))
                    .Returns(CreateXsdFileInformationByUriSegment()["sample"]);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("notfound"))
                    .Returns(default);

                A.CallTo(() => _embeddedFileProvider.Stream(A<string>._, A<string>._))
                    .Returns(new MemoryStream(Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>")));

                _sut = new XsdMetadataFileMiddleware(
                    _xsdFileInformationProvider, _embeddedFileProvider, new ApiSettings {Mode = ApiMode.Sandbox.Value});
            }

            [Test]
            public async Task Should_not_process_for_non_get_requests()
            {
                var httpContext = new DefaultHttpContext();

                httpContext.Request.Method = HttpMethods.Post;
                httpContext.Request.Path = new PathString("/metadata/xsd/ed-fi/Ed-Fi-Core.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi")).MustNotHaveHappened();
            }

            [Test]
            public async Task Should_not_found_if_schema_is_not_available()
            {
                var httpContext = new DefaultHttpContext();

                httpContext.Request.Method = HttpMethods.Get;
                httpContext.Request.Path = new PathString("/metadata/xsd/notfound/notfound.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("notfound")).MustHaveHappened();
                httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            }

            [Test]
            public async Task Should_create_a_schema_file_for_a_matching_route_for_core()
            {
                var httpContext = new DefaultHttpContext();
                httpContext.Request.Method = HttpMethods.Get;
                httpContext.Request.Path = new PathString("/metadata/xsd/ed-fi/Ed-Fi-Core.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi")).MustHaveHappened();

                A.CallTo(
                        () => _embeddedFileProvider.Stream(
                            "EdFi.Ods.Standard", "EdFi.Ods.Standard.Artifacts.Schemas.Ed-Fi-Core.xsd"))
                    .MustHaveHappened();

                // because the context here is a default http context, we will not get the content in the body as we would expect.
                // so we will just check the status and the content type
                httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
                httpContext.Response.ContentType.ShouldBe("application/xml");
            }

            [Test]
            public async Task Should_create_a_schema_file_for_a_matching_route_for_an_extension()
            {
                var httpContext = new DefaultHttpContext();
                httpContext.Request.Method = HttpMethods.Get;
                httpContext.Request.Path = new PathString("/metadata/xsd/sample/Sample.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("sample")).MustHaveHappened();

                A.CallTo(
                        () => _embeddedFileProvider.Stream(
                            "EdFi.Ods.Extensions.Sample", "EdFi.Ods.Extensions.Sample.Artifacts.Schemas.Sample.xsd"))
                    .MustHaveHappened();

                // because the context here is a default http context, we will not get the content in the body as we would expect.
                // so we will just check the status and the content type
                httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
                httpContext.Response.ContentType.ShouldBe("application/xml");
            }
        }

        public class YearSpecific
        {
            private IEmbeddedFileProvider _embeddedFileProvider;
            private XsdMetadataFileMiddleware _sut;
            private IXsdFileInformationProvider _xsdFileInformationProvider;

            [SetUp]
            public void SetUp()
            {
                _xsdFileInformationProvider = A.Fake<IXsdFileInformationProvider>();
                _embeddedFileProvider = A.Fake<IEmbeddedFileProvider>();

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi"))
                    .Returns(CreateXsdFileInformationByUriSegment()["ed-fi"]);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("sample"))
                    .Returns(CreateXsdFileInformationByUriSegment()["sample"]);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("notfound"))
                    .Returns(default);

                A.CallTo(() => _embeddedFileProvider.Stream(A<string>._, A<string>._))
                    .Returns(new MemoryStream(Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>")));

                _sut = new XsdMetadataFileMiddleware(
                    _xsdFileInformationProvider, _embeddedFileProvider, new ApiSettings {Mode = ApiMode.YearSpecific.Value});
            }

            [Test]
            public async Task Should_not_process_for_non_get_requests()
            {
                var httpContext = new DefaultHttpContext();

                httpContext.Request.Method = HttpMethods.Post;
                httpContext.Request.Path = new PathString("/metadata/2021/xsd/ed-fi/Ed-Fi-Core.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi")).MustNotHaveHappened();
            }

            [Test]
            public async Task Should_not_found_if_schema_is_not_available()
            {
                var httpContext = new DefaultHttpContext();

                httpContext.Request.Method = HttpMethods.Get;
                httpContext.Request.Path = new PathString("/metadata/2021/xsd/notfound/notfound.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("notfound")).MustHaveHappened();
                httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            }

            [Test]
            public async Task Should_create_a_schema_file_for_a_matching_route_for_core()
            {
                var httpContext = new DefaultHttpContext();
                httpContext.Request.Method = HttpMethods.Get;
                httpContext.Request.Path = new PathString("/metadata/2021/xsd/ed-fi/Ed-Fi-Core.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi")).MustHaveHappened();

                A.CallTo(
                        () => _embeddedFileProvider.Stream(
                            "EdFi.Ods.Standard", "EdFi.Ods.Standard.Artifacts.Schemas.Ed-Fi-Core.xsd"))
                    .MustHaveHappened();

                // because the context here is a default http context, we will not get the content in the body as we would expect.
                // so we will just check the status and the content type
                httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
                httpContext.Response.ContentType.ShouldBe("application/xml");
            }

            [Test]
            public async Task Should_create_a_schema_file_for_a_matching_route_for_an_extension()
            {
                var httpContext = new DefaultHttpContext();
                httpContext.Request.Method = HttpMethods.Get;
                httpContext.Request.Path = new PathString("/metadata/2021/xsd/sample/Sample.xsd");

                await _sut.InvokeAsync(httpContext, context => Task.CompletedTask);

                A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("sample")).MustHaveHappened();

                A.CallTo(
                        () => _embeddedFileProvider.Stream(
                            "EdFi.Ods.Extensions.Sample", "EdFi.Ods.Extensions.Sample.Artifacts.Schemas.Sample.xsd"))
                    .MustHaveHappened();

                // because the context here is a default http context, we will not get the content in the body as we would expect.
                // so we will just check the status and the content type
                httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
                httpContext.Response.ContentType.ShouldBe("application/xml");
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Reflection;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common;
using EdFi.Ods.Standard;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware
{
    [TestFixture]
    public class XsdMetadataFileMiddlewareTests
    {
        private IAssembliesProvider _assembliesProvider;
        private XsdMetadataFileMiddleware _sut;
        private IXsdFileInformationProvider _xsdFileInformationProvider;

        [SetUp]
        public void SetUp()
        {
            _xsdFileInformationProvider = A.Fake<IXsdFileInformationProvider>();

            _assembliesProvider = A.Fake<IAssembliesProvider>();

            A.CallTo(() => _assembliesProvider.Get(A<string>._))
                .Returns(Assembly.GetAssembly(typeof(Marker_EdFi_Ods_Standard)));

            A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("ed-fi"))
                .Returns(
                    new XsdFileInformation(
                        "EdFi.Ods.Standard",
                        "3.2.0-c",
                        new SchemaNameMap("Ed-Fi", "edfi", "ed-fi", "EdFi"),
                        new[] {"Ed-Fi-Core.xsd"}));

            A.CallTo(() => _xsdFileInformationProvider.XsdFileInformationByUriSegment("notfound"))
                .Returns(default);

            _sut = new XsdMetadataFileMiddleware(_xsdFileInformationProvider, _assembliesProvider);
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

            A.CallTo(() => _assembliesProvider.Get("EdFi.Ods.Standard")).MustHaveHappened();

            // because the context here is a default http context, we will not get the content in the body as we would expect.
            // so we will just check the status and the content type
            httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
            httpContext.Response.ContentType.ShouldBe("application/xml");
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using System.Text;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware
{
    [TestFixture]
    public class OAuthContentTypeValidationMiddlewareTests
    {
        private OAuthContentTypeValidationMiddleware _middleware;

        [SetUp]
        public void Setup()
        {
            var logContextAccessor = A.Fake<ILogContextAccessor>();
            A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey))
                .Returns(A.Dummy<string>());

            _middleware = new OAuthContentTypeValidationMiddleware(logContextAccessor);
        }

        [Test]
        public async Task Middleware_Returns_BadRequest_When_Content_Type_Is_Missing_For_OAuth_Post_Request()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/oauth/token";
            context.Request.Method = HttpMethods.Post;
            context.Response.Body = new MemoryStream();
            var next = A.Fake<RequestDelegate>();

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            context.Response.StatusCode.ShouldBe(415);
        }

        [Test]
        public async Task Middleware_Passes_Through_When_Content_Type_Is_Present_For_OAuth_Post_Request()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/oauth/token";
            context.Request.Method = HttpMethods.Post;
            context.Request.ContentType = "application/json";
            var next = A.Fake<RequestDelegate>();

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => next(context)).MustHaveHappened();
        }

        [Test]
        public async Task Middleware_Passes_Through_For_Non_OAuth_Post_Request()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/data/v3/ed-fi/localEducationAgencies";
            context.Request.Method = HttpMethods.Post;
            var next = A.Fake<RequestDelegate>();

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => next(context)).MustHaveHappened();
        }

        [Test]
        public async Task Middleware_Passes_Through_For_NonPost_OAuth_Request()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Path = "/data/v3/ed-fi/localEducationAgencies";
            context.Request.Method = HttpMethods.Options;
            var next = A.Fake<RequestDelegate>();

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => next(context)).MustHaveHappened();
        }
    }
}

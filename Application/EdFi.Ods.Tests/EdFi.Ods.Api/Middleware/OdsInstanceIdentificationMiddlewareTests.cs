// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

// NOTE: Initial test fixture generated using ChatGPT
namespace EdFi.Ods.Api.Middleware.Tests
{
    [TestFixture]
    public class OdsInstanceIdentificationMiddlewareTests
    {
        private IContextProvider<OdsInstanceConfiguration> _contextProvider;
        private IOdsInstanceSelector _instanceSelector;
        private OdsInstanceIdentificationMiddleware _middleware;
        private ILogContextAccessor _logContextAccessor;

        [SetUp]
        public void SetUp()
        {
            _contextProvider = A.Fake<IContextProvider<OdsInstanceConfiguration>>();
            _instanceSelector = A.Fake<IOdsInstanceSelector>();
            _logContextAccessor = A.Fake<ILogContextAccessor>();
            _middleware = new OdsInstanceIdentificationMiddleware(_contextProvider, _instanceSelector, _logContextAccessor);
        }

        [Test]
        public async Task InvokeAsync_WithValidConfiguration_SetsContextAndInvokesNext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var next = A.Fake<RequestDelegate>();
            var configuration = new OdsInstanceConfiguration(1, 1, "TheConnectionString", 
                new Dictionary<string, string>(), new Dictionary<DerivativeType, string>());

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync(context.Request.RouteValues)).Returns(configuration);

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => _contextProvider.Set(configuration)).MustHaveHappened();
            A.CallTo(() => next(context)).MustHaveHappened();
        }

        [Test]
        public async Task InvokeAsync_WithNullConfiguration_DoesNotSetContextAndInvokesNext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var next = A.Fake<RequestDelegate>();

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync(context.Request.RouteValues)).Returns(Task.FromResult(null as OdsInstanceConfiguration));

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            A.CallTo(() => _contextProvider.Set(A<OdsInstanceConfiguration>._)).MustNotHaveHappened();
            A.CallTo(() => next(context)).MustHaveHappened();
        }

        [Test]
        public async Task InvokeAsync_WhenSelectorDeniesAuthorization_WritesForbiddenProblemDetailsAndDoesNotInvokeNext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var next = A.Fake<RequestDelegate>();

            A.CallTo(() => _logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns("TheCorrelationId");

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync(context.Request.RouteValues))
                .ThrowsAsync(new SecurityAuthorizationException(SecurityAuthorizationException.DefaultDetail, "Not authorized."));

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            var body = ReadResponseBody(context);

            context.Response.StatusCode.ShouldBe(StatusCodes.Status403Forbidden);
            context.Response.ContentType.ShouldBe("application/problem+json");
            body.GetProperty("type").GetString().ShouldBe("urn:ed-fi:api:security:authorization");
            body.GetProperty("correlationId").GetString().ShouldBe("TheCorrelationId");
            body.GetProperty("errors")[0].GetString().ShouldBe("Not authorized.");
            A.CallTo(() => _contextProvider.Set(A<OdsInstanceConfiguration>._)).MustNotHaveHappened();
            A.CallTo(() => next(context)).MustNotHaveHappened();
        }

        [Test]
        public async Task InvokeAsync_WhenSelectorFindsNoInstance_WritesNotFoundProblemDetailsAndDoesNotInvokeNext()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            var next = A.Fake<RequestDelegate>();

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync(context.Request.RouteValues))
                .ThrowsAsync(new NotFoundException(NotFoundException.DefaultDetail, "No ODS instance found."));

            // Act
            await _middleware.InvokeAsync(context, next);

            // Assert
            var body = ReadResponseBody(context);

            context.Response.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            context.Response.ContentType.ShouldBe("application/problem+json");
            body.GetProperty("type").GetString().ShouldBe("urn:ed-fi:api:not-found");
            A.CallTo(() => _contextProvider.Set(A<OdsInstanceConfiguration>._)).MustNotHaveHappened();
            A.CallTo(() => next(context)).MustNotHaveHappened();
        }

        [Test]
        public void InvokeAsync_WhenDownstreamDeniesAuthorization_DoesNotHandleTheException()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var next = A.Fake<RequestDelegate>();

            A.CallTo(() => _instanceSelector.GetOdsInstanceAsync(context.Request.RouteValues))
                .Returns(Task.FromResult(null as OdsInstanceConfiguration));

            A.CallTo(() => next(context))
                .ThrowsAsync(new SecurityAuthorizationException(SecurityAuthorizationException.DefaultDetail, "Not authorized."));

            // Act + Assert
            Assert.ThrowsAsync<SecurityAuthorizationException>(() => _middleware.InvokeAsync(context, next));
        }

        private static JsonElement ReadResponseBody(HttpContext context)
        {
            context.Response.Body.Position = 0;
            return JsonDocument.Parse(context.Response.Body).RootElement;
        }
    }
}

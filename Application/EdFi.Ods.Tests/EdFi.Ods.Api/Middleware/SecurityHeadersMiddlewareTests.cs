// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware;

[TestFixture]
public class SecurityHeadersMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_AddsSecurityHeaders_WhenResponseStarts_AndCallsNext()
    {
        // Arrange
        var (context, responseFeature) = CreateContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var middleware = new SecurityHeadersMiddleware(nextMiddleware);

        // Act
        await middleware.InvokeAsync(context);
        await responseFeature.StartAsync();

        // Assert
        context.Response.Headers["X-Content-Type-Options"].ToString().ShouldBe("nosniff");
        context.Response.Headers["X-Frame-Options"].ToString().ShouldBe("DENY");
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WhenHeadersAlreadySet_ReplacesThemWithSingleValues()
    {
        // Arrange
        var (context, responseFeature) = CreateContext();
        context.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
        var middleware = new SecurityHeadersMiddleware(A.Fake<RequestDelegate>());

        // Act
        await middleware.InvokeAsync(context);
        await responseFeature.StartAsync();

        // Assert
        context.Response.Headers["X-Frame-Options"].Count.ShouldBe(1);
        context.Response.Headers["X-Frame-Options"].ToString().ShouldBe("DENY");
    }

    [Test]
    public async Task InvokeAsync_WhenDownstreamClearsTheResponse_StillSendsSecurityHeaders()
    {
        // Arrange (an error page clears the response before writing its own)
        var (context, responseFeature) = CreateContext();

        var middleware = new SecurityHeadersMiddleware(
            ctx =>
            {
                ctx.Response.Clear();
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Task.CompletedTask;
            });

        // Act
        await middleware.InvokeAsync(context);
        await responseFeature.StartAsync();

        // Assert
        context.Response.Headers["X-Content-Type-Options"].ToString().ShouldBe("nosniff");
        context.Response.Headers["X-Frame-Options"].ToString().ShouldBe("DENY");
    }

    [Test]
    public async Task InvokeAsync_WhenOAuthContentTypeValidationShortCircuits_StillSendsSecurityHeaders()
    {
        // Arrange (same order as the API pipeline: security headers, then OAuth content type validation)
        var (context, responseFeature) = CreateContext();
        context.Request.Path = "/oauth/token";
        context.Request.Method = HttpMethods.Post;
        context.Response.Body = new MemoryStream();

        var logContextAccessor = A.Fake<ILogContextAccessor>();
        A.CallTo(() => logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns(A.Dummy<string>());
        var oauthContentTypeValidation = new OAuthContentTypeValidationMiddleware(logContextAccessor);
        var endpoint = A.Fake<RequestDelegate>();

        var middleware = new SecurityHeadersMiddleware(ctx => oauthContentTypeValidation.InvokeAsync(ctx, endpoint));

        // Act
        await middleware.InvokeAsync(context);
        await responseFeature.StartAsync();

        // Assert
        context.Response.StatusCode.ShouldBe(StatusCodes.Status415UnsupportedMediaType);
        context.Response.Headers["X-Content-Type-Options"].ToString().ShouldBe("nosniff");
        context.Response.Headers["X-Frame-Options"].ToString().ShouldBe("DENY");
        A.CallTo(() => endpoint(A<HttpContext>._)).MustNotHaveHappened();
    }

    private static (HttpContext context, OnStartingResponseFeature responseFeature) CreateContext()
    {
        var context = new DefaultHttpContext();
        var responseFeature = new OnStartingResponseFeature();
        context.Features.Set<IHttpResponseFeature>(responseFeature);

        return (context, responseFeature);
    }

    /// <summary>
    /// Captures the OnStarting callbacks so that a test can start the response, as the server does.
    /// </summary>
    private class OnStartingResponseFeature : HttpResponseFeature
    {
        private readonly Stack<(Func<object, Task> callback, object state)> _onStarting = new();

        public override void OnStarting(Func<object, Task> callback, object state)
            => _onStarting.Push((callback, state));

        public async Task StartAsync()
        {
            while (_onStarting.Count > 0)
            {
                var (callback, state) = _onStarting.Pop();
                await callback(state);
            }
        }
    }
}

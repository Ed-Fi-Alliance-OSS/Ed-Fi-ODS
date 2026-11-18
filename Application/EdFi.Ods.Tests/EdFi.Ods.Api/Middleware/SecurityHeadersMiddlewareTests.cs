// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware;

[TestFixture]
public class SecurityHeadersMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_AddsSecurityHeaders_AndCallsNext()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var middleware = new SecurityHeadersMiddleware(nextMiddleware);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.Headers["X-Content-Type-Options"].ToString().ShouldBe("nosniff");
        context.Response.Headers["X-Frame-Options"].ToString().ShouldBe("SAMEORIGIN");
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WhenHeadersAlreadySet_ReplacesThemWithSingleValues()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Response.Headers["X-Frame-Options"] = "DENY";
        var middleware = new SecurityHeadersMiddleware(A.Fake<RequestDelegate>());

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.Headers["X-Frame-Options"].Count.ShouldBe(1);
        context.Response.Headers["X-Frame-Options"].ToString().ShouldBe("SAMEORIGIN");
    }
}

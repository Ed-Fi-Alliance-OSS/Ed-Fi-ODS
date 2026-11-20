// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware;

[TestFixture]
public class HttpToHttpsRedirectMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_WhenRequestIsHttps_CallsNext()
    {
        // Arrange
        var context = CreateContext("https", "api.example.org", "/data/v3/students");
        var next = A.Fake<RequestDelegate>();
        var middleware = new HttpToHttpsRedirectMiddleware(next, new ApiSettings());

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        A.CallTo(() => next(context)).MustHaveHappenedOnceExactly();
        context.Response.Headers.Location.Count.ShouldBe(0);
    }

    [Test]
    public async Task InvokeAsync_WhenRequestIsHttp_RedirectsToHttps_KeepingPathBasePathAndQuery()
    {
        // Arrange
        var context = CreateContext("http", "api.example.org:8080", "/data/v3/students", "?limit=5");
        context.Request.PathBase = "/api";
        var next = A.Fake<RequestDelegate>();
        var middleware = new HttpToHttpsRedirectMiddleware(next, new ApiSettings());

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.StatusCode.ShouldBe(StatusCodes.Status307TemporaryRedirect);
        context.Response.Headers.Location.ToString().ShouldBe("https://api.example.org/api/data/v3/students?limit=5");
        A.CallTo(() => next(A<HttpContext>._)).MustNotHaveHappened();
    }

    [Test]
    public async Task InvokeAsync_WhenHttpsRedirectionPortIsSet_RedirectsToThatPort()
    {
        // Arrange
        var context = CreateContext("http", "api.example.org", "/data/v3/students");
        var middleware = new HttpToHttpsRedirectMiddleware(
            A.Fake<RequestDelegate>(), new ApiSettings { HttpsRedirectionPort = 8443 });

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.Headers.Location.ToString().ShouldBe("https://api.example.org:8443/data/v3/students");
    }

    [Test]
    public async Task InvokeAsync_BehindReverseProxy_UsesHostAndPortOverrides()
    {
        // Arrange
        var context = CreateContext("http", "ed-fi-ods-api", "/data/v3/students");
        var apiSettings = new ApiSettings
        {
            UseReverseProxyHeaders = true,
            OverrideForForwardingHostServer = "api.district.org",
            OverrideForForwardingHostPort = 8443
        };
        var middleware = new HttpToHttpsRedirectMiddleware(A.Fake<RequestDelegate>(), apiSettings);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.Headers.Location.ToString().ShouldBe("https://api.district.org:8443/data/v3/students");
    }

    [Test]
    public async Task InvokeAsync_WhenOverridesAreSetWithoutReverseProxyHeaders_IgnoresThem()
    {
        // Arrange
        var context = CreateContext("http", "api.example.org", "/data/v3/students");
        var apiSettings = new ApiSettings
        {
            OverrideForForwardingHostServer = "api.district.org",
            OverrideForForwardingHostPort = 8443
        };
        var middleware = new HttpToHttpsRedirectMiddleware(A.Fake<RequestDelegate>(), apiSettings);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.Headers.Location.ToString().ShouldBe("https://api.example.org/data/v3/students");
    }

    [Test]
    public async Task InvokeAsync_BehindReverseProxy_IgnoresTheForwardedHttpPort()
    {
        // Arrange
        var context = CreateContext("http", "api.example.org", "/data/v3/students");
        context.Items[ForwardedPortMiddleware.ForwardedPortItemKey] = 80;
        var middleware = new HttpToHttpsRedirectMiddleware(
            A.Fake<RequestDelegate>(), new ApiSettings { UseReverseProxyHeaders = true });

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        context.Response.Headers.Location.ToString().ShouldBe("https://api.example.org/data/v3/students");
    }

    [TestCase("/health")]
    [TestCase("/Health")]
    public async Task InvokeAsync_ForHealthCheck_CallsNextWithoutRedirect(string path)
    {
        // Arrange
        var context = CreateContext("http", "10.0.0.5", path);
        var next = A.Fake<RequestDelegate>();
        var middleware = new HttpToHttpsRedirectMiddleware(next, new ApiSettings());

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        A.CallTo(() => next(context)).MustHaveHappenedOnceExactly();
        context.Response.Headers.Location.Count.ShouldBe(0);
    }

    private static HttpContext CreateContext(string scheme, string host, string path, string queryString = "")
    {
        var context = new DefaultHttpContext();
        context.Request.Scheme = scheme;
        context.Request.Host = new HostString(host);
        context.Request.Path = path;
        context.Request.QueryString = new QueryString(queryString);

        return context;
    }
}

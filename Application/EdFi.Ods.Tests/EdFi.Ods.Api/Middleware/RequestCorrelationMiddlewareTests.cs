// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware;

[TestFixture]
public class RequestCorrelationMiddlewareTests
{
    [Test]
    public async Task InvokeAsync_WithHeader_CapturesCorrelationId()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[CorrelationConstants.HttpHeader] = "123456";

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, "123456")).MustHaveHappenedOnceExactly();
    }
    
    [Test]
    public async Task InvokeAsync_WithCustonHeader_CapturesCorrelationId()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();
        var customCorrelationIdHeaderName = "a-custom-header";
        apiSettings.OdsCorrelationIdHttpHeaderName = customCorrelationIdHeaderName;
        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[customCorrelationIdHeaderName] = "123456";

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, "123456")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WithQueryString_CapturesCorrelationId()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.QueryString = new QueryString("?correlationId=7890");

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, "7890")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WithHeaderAndQueryString_PrefersHeader()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[CorrelationConstants.HttpHeader] = "123456";
        context.Request.QueryString = new QueryString("?correlationId=7890");

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, "123456")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WithoutCorrelationId_SetsPropertyToANewGuid()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, A<object>.That.Matches(x => IsGuid(x)))).MustHaveHappenedOnceExactly();
    }

    private static bool IsGuid(object x) => Guid.TryParse(x as string, out var ignored);
}

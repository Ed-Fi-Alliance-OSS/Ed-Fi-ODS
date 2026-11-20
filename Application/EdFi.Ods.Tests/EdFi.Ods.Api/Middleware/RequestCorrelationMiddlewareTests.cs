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

    [TestCase("abc\r\n2026-11-10 12:00:00 INFO forged line")]
    [TestCase("abc\nforged")]
    [TestCase("abc\tdef")]
    [TestCase("abc\u0000def")]
    [TestCase("abc\u0085def")]
    [TestCase("abc\u2028def")]
    [TestCase("abc\u2029def")]
    [TestCase("")]
    [TestCase("   ")]
    public async Task InvokeAsync_WithInvalidHeaderValue_SetsPropertyToANewGuid(string suppliedValue)
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[CorrelationConstants.HttpHeader] = suppliedValue;

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, A<object>.That.Matches(x => IsGuid(x)))).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WithEncodedNewLineInQueryString_SetsPropertyToANewGuid()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.QueryString = new QueryString("?correlationId=abc%0D%0A2026-11-10%20INFO%20forged");

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => nextMiddleware(context)).MustHaveHappenedOnceExactly();
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, A<object>.That.Matches(x => IsGuid(x)))).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WithValueAtMaximumLength_CapturesCorrelationId()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();
        var suppliedValue = new string('a', RequestCorrelationMiddleware.MaxCorrelationIdLength);

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[CorrelationConstants.HttpHeader] = suppliedValue;

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, suppliedValue)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task InvokeAsync_WithValueOverMaximumLength_SetsPropertyToANewGuid()
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[CorrelationConstants.HttpHeader] = new string('a', RequestCorrelationMiddleware.MaxCorrelationIdLength + 1);

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, A<object>.That.Matches(x => IsGuid(x)))).MustHaveHappenedOnceExactly();
    }

    [TestCase("2b1a6f0e-3c4d-4e5f-8a9b-0c1d2e3f4a5b")]
    [TestCase("a1:b2:c3:d4:e5:f6")]
    [TestCase("bulk-load 2026-11-10 #42")]
    public async Task InvokeAsync_WithPrintableValue_CapturesCorrelationId(string suppliedValue)
    {
        // Arrange
        var context = new DefaultHttpContext();
        var nextMiddleware = A.Fake<RequestDelegate>();
        var logContextWriter = A.Fake<ILogContextAccessor>();
        var apiSettings = A.Fake<ApiSettings>();

        var middleware = new RequestCorrelationMiddleware(logContextWriter, apiSettings);
        context.Request.Headers[CorrelationConstants.HttpHeader] = suppliedValue;

        // Act
        await middleware.InvokeAsync(context, nextMiddleware);

        // Assert
        A.CallTo(() => logContextWriter.SetValue(CorrelationConstants.LogContextKey, suppliedValue)).MustHaveHappenedOnceExactly();
    }

    private static bool IsGuid(object x) => Guid.TryParse(x as string, out var ignored);
}

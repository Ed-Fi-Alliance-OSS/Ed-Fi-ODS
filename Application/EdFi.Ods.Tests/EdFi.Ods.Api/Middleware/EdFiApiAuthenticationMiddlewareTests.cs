// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using EdFi.Ods.Api.Middleware;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Security;
using FakeItEasy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Middleware;

[TestFixture]
public class EdFiApiAuthenticationMiddlewareTests
{
    private const string GuidToken = "d49f5c606f03406db2e01b1c82d2997f";

    private RequestDelegate _next;
    private IApiClientContextProvider _apiClientContextProvider;
    private ILogContextAccessor _logContextAccessor;
    private IOAuthTokenAuthenticator _oauthTokenAuthenticator;
    private EdFiApiAuthenticationMiddleware _middleware;

    [SetUp]
    public void SetUp()
    {
        _next = A.Fake<RequestDelegate>();
        _apiClientContextProvider = A.Fake<IApiClientContextProvider>();
        _logContextAccessor = A.Fake<ILogContextAccessor>();
        _oauthTokenAuthenticator = A.Fake<IOAuthTokenAuthenticator>();

        A.CallTo(() => _logContextAccessor.GetValue(CorrelationConstants.LogContextKey)).Returns("TheCorrelationId");

        var schemes = A.Fake<IAuthenticationSchemeProvider>();

        A.CallTo(() => schemes.GetRequestHandlerSchemesAsync()).Returns(Array.Empty<AuthenticationScheme>());

        A.CallTo(() => schemes.GetDefaultAuthenticateSchemeAsync())
            .Returns(new AuthenticationScheme(JwtBearerDefaults.AuthenticationScheme, null, typeof(JwtBearerHandler)));

        _middleware = new EdFiApiAuthenticationMiddleware(
            _next,
            schemes,
            _apiClientContextProvider,
            _logContextAccessor,
            _oauthTokenAuthenticator);
    }

    // Creates a request whose JWT passed validation, with the ODS/API token in the "jti" claim
    private static DefaultHttpContext CreateContextWithValidatedJwt()
    {
        var principal = new ClaimsPrincipal(
            new ClaimsIdentity([new Claim(JwtRegisteredClaimNames.Jti, GuidToken)], JwtBearerDefaults.AuthenticationScheme));

        var authenticationService = A.Fake<IAuthenticationService>();

        A.CallTo(() => authenticationService.AuthenticateAsync(A<HttpContext>._, JwtBearerDefaults.AuthenticationScheme))
            .Returns(AuthenticateResult.Success(new AuthenticationTicket(principal, JwtBearerDefaults.AuthenticationScheme)));

        var services = new ServiceCollection()
            .AddSingleton(authenticationService)
            .AddSingleton(A.Fake<IAuthenticationHandlerProvider>())
            .BuildServiceProvider();

        var context = new DefaultHttpContext { RequestServices = services };
        context.Request.Path = "/data/v3/ed-fi/schools";
        context.Response.Body = new MemoryStream();

        return context;
    }

    private static JsonElement ReadResponseBody(HttpContext context)
    {
        context.Response.Body.Position = 0;

        return JsonDocument.Parse(new StreamReader(context.Response.Body).ReadToEnd()).RootElement;
    }

    [Test]
    public async Task Should_return_invalid_token_when_the_token_in_the_JWT_is_no_longer_valid()
    {
        // The JWT is still accepted within the clock skew, but its token is expired or revoked
        A.CallTo(() => _oauthTokenAuthenticator.AuthenticateAsync(GuidToken, "Bearer"))
            .Returns(AuthenticateResult.Fail(AuthenticationFailureMessages.InvalidToken));

        var context = CreateContextWithValidatedJwt();

        await _middleware.Invoke(context);

        context.Response.StatusCode.ShouldBe(StatusCodes.Status401Unauthorized);

        var body = ReadResponseBody(context);
        body.GetProperty("errors").EnumerateArray().Select(e => e.GetString()).ShouldBe([AuthenticationFailureMessages.InvalidToken]);
        body.GetProperty("correlationId").GetString().ShouldBe("TheCorrelationId");

        A.CallTo(() => _next(A<HttpContext>._)).MustNotHaveHappened();
        A.CallTo(() => _apiClientContextProvider.SetApiClientContext(A<ApiClientContext>._)).MustNotHaveHappened();
    }

    [Test]
    public async Task Should_set_the_API_client_context_when_the_token_in_the_JWT_is_valid()
    {
        var apiClientContext = new ApiClientContext();

        var ticket = new AuthenticationTicket(
            new ClaimsPrincipal(new ClaimsIdentity("Bearer")),
            new AuthenticationProperties(
                new Dictionary<string, string>(),
                new Dictionary<string, object> { { nameof(ApiClientContext), apiClientContext } }),
            "Bearer");

        A.CallTo(() => _oauthTokenAuthenticator.AuthenticateAsync(GuidToken, "Bearer"))
            .Returns(AuthenticateResult.Success(ticket));

        var context = CreateContextWithValidatedJwt();

        await _middleware.Invoke(context);

        A.CallTo(() => _apiClientContextProvider.SetApiClientContext(apiClientContext)).MustHaveHappened();
        A.CallTo(() => _next(context)).MustHaveHappened();
    }
}

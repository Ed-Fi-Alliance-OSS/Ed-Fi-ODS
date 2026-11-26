// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Net;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers;

[TestFixture]
public class TokenControllerRateLimitTests
{
    private const string ClientCredentialsGrantType = "client_credentials";

    private IApiClientAuthenticator _apiClientAuthenticator;
    private TokenRequestRateLimiter _rateLimiter;

    [SetUp]
    public void SetUp()
    {
        _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

        A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
            .Returns(new ApiClientAuthenticator.AuthenticationResult { IsAuthenticated = false });

        A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "rightSecret"))
            .Returns(
                new ApiClientAuthenticator.AuthenticationResult
                {
                    IsAuthenticated = true,
                    ApiClientDetails = new ApiClientDetails { ApiKey = "clientId", ApiClientId = 1 }
                });
    }

    [TearDown]
    public void TearDown() => _rateLimiter?.Dispose();

    [Test]
    public async Task When_disabled_repeated_failures_are_not_limited()
    {
        var controller = CreateController(new TokenRateLimitSettings());

        for (int i = 0; i < 50; i++)
        {
            (await controller.PostAsync(Request("clientId", "wrongSecret"))).ShouldBeOfType<UnauthorizedObjectResult>();
        }

        (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();
    }

    [Test]
    public async Task Requests_over_the_IP_address_limit_get_429_without_authenticating()
    {
        var controller = CreateController(Enabled(permitsPerIpAddress: 2));

        (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();
        (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();

        var actionResult = await controller.PostAsync(Request("clientId", "rightSecret"));

        AssertTooManyRequests(actionResult, controller);

        A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
            .MustHaveHappenedTwiceExactly();
    }

    [Test]
    public async Task Another_IP_address_is_not_affected_by_the_limit_of_the_first()
    {
        var controller = CreateController(Enabled(permitsPerIpAddress: 1));

        (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();
        AssertTooManyRequests(await controller.PostAsync(Request("clientId", "rightSecret")), controller);

        controller.HttpContext.Connection.RemoteIpAddress = IPAddress.Parse("192.0.2.20");

        (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();
    }

    [Test]
    public async Task A_client_id_over_its_failed_authentication_limit_gets_429_even_with_the_right_secret()
    {
        var controller = CreateController(Enabled(failedAttemptsPerClientId: 3));

        for (int i = 0; i < 3; i++)
        {
            (await controller.PostAsync(Request("clientId", "wrongSecret"))).ShouldBeOfType<UnauthorizedObjectResult>();
        }

        AssertTooManyRequests(await controller.PostAsync(Request("clientId", "rightSecret")), controller);

        A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "rightSecret"))
            .MustNotHaveHappened();
    }

    [Test]
    public async Task Successful_authentications_do_not_count_toward_the_client_id_limit()
    {
        var controller = CreateController(Enabled(failedAttemptsPerClientId: 1));

        for (int i = 0; i < 10; i++)
        {
            (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();
        }
    }

    [Test]
    public async Task Failures_for_one_client_id_do_not_limit_another()
    {
        var controller = CreateController(Enabled(failedAttemptsPerClientId: 1));

        (await controller.PostAsync(Request("otherClientId", "wrongSecret"))).ShouldBeOfType<UnauthorizedObjectResult>();
        AssertTooManyRequests(await controller.PostAsync(Request("otherClientId", "wrongSecret")), controller);

        (await controller.PostAsync(Request("clientId", "rightSecret"))).ShouldBeOfType<OkObjectResult>();
    }

    private TokenController CreateController(TokenRateLimitSettings settings)
    {
        _rateLimiter = new TokenRequestRateLimiter(new ApiSettings { TokenRateLimit = settings });

        var tokenRequestProvider = new ClientCredentialsTokenRequestProvider(
            _apiClientAuthenticator,
            A.Fake<IAccessTokenFactory>(),
            new OptionsWrapper<SecuritySettings>(new SecuritySettings()));

        var httpContext = new DefaultHttpContext();
        httpContext.Connection.RemoteIpAddress = IPAddress.Parse("192.0.2.10");

        return new TokenController(tokenRequestProvider, _rateLimiter)
        {
            ControllerContext = new ControllerContext { HttpContext = httpContext }
        };
    }

    private static TokenRateLimitSettings Enabled(int permitsPerIpAddress = 100, int failedAttemptsPerClientId = 100)
        => new()
        {
            Enabled = true,
            PermitsPerIpAddress = permitsPerIpAddress,
            FailedAttemptsPerClientId = failedAttemptsPerClientId,
            WindowSeconds = 60
        };

    private static TokenRequest Request(string clientId, string clientSecret)
        => new()
        {
            Grant_type = ClientCredentialsGrantType,
            Client_id = clientId,
            Client_secret = clientSecret
        };

    private static void AssertTooManyRequests(IActionResult actionResult, TokenController controller)
    {
        var objectResult = actionResult.ShouldBeOfType<ObjectResult>();

        objectResult.ShouldSatisfyAllConditions(
            () => objectResult.StatusCode.ShouldBe(StatusCodes.Status429TooManyRequests),
            () => objectResult.Value.ShouldBeOfType<TokenError>().Error.ShouldBe(TokenErrorType.InvalidRequest),
            () => int.Parse(controller.Response.Headers.RetryAfter.ToString()).ShouldBeInRange(1, 60));
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.TokenInfo;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    [TestFixture]
    public class TokenInfoControllerTests
    {
        private ITokenInfoProvider _tokenInfoProvider;
        private IApiClientDetailsProvider _apiClientDetailsProvider;
        private IApiClientContextProvider _apiClientContextProvider;
        private ILogContextAccessor _logContextAccessor;
        private IHttpContextAccessor _httpContextAccessor;
        private IOptions<SecuritySettings> _securitySettings;

        // A well-known test token (GUID format, no hyphens)
        private const string TestTokenGuid = "550e8400e29b41d4a716446655440000";
        private const string TestApiKey = "testApiKey";

        [SetUp]
        public void SetUp()
        {
            _tokenInfoProvider = A.Fake<ITokenInfoProvider>();
            _apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
            _apiClientContextProvider = A.Fake<IApiClientContextProvider>();
            _logContextAccessor = A.Fake<ILogContextAccessor>();
            _httpContextAccessor = A.Fake<IHttpContextAccessor>();

            _securitySettings = new OptionsWrapper<SecuritySettings>(
                new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid });
        }

        private TokenInfoController CreateController(string authHeaderToken = TestTokenGuid, bool featureEnabled = true)
        {
            var featureManager = new FakeFeatureManager(featureEnabled);

            var controller = new TokenInfoController(
                _tokenInfoProvider,
                _apiClientDetailsProvider,
                _apiClientContextProvider,
                _logContextAccessor,
                featureManager,
                _securitySettings,
                _httpContextAccessor);

            var httpContext = new DefaultHttpContext();

            if (authHeaderToken != null)
            {
                httpContext.Request.Headers["Authorization"] = $"Bearer {authHeaderToken}";
            }

            A.CallTo(() => _httpContextAccessor.HttpContext).Returns(httpContext);

            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };

            return controller;
        }

        private static ApiClientContext CreateApiClientContext(string apiKey = TestApiKey)
        {
            return new ApiClientContext(
                apiKey, "TestClaimSet", new[] { 1234L }, new[] { "uri://ed-fi.org" },
                new List<string>(), "descriptor", null, null, null, 0);
        }

        [Test]
        public async Task GetTokenInformation_WhenFeatureIsDisabled_ReturnsNotFound()
        {
            var controller = CreateController(featureEnabled: false);

            var result = await controller.PostAsync(new TokenInfoRequest { Token = TestTokenGuid });

            result.ShouldBeOfType<NotFoundResult>();
        }

        [Test]
        public async Task GetTokenInformation_WhenTokenIsNull_ReturnsBadRequest()
        {
            var controller = CreateController();

            var result = await controller.PostAsync(new TokenInfoRequest { Token = null });

            result.ShouldBeOfType<BadRequestObjectResult>();
        }

        [Test]
        public async Task GetTokenInformation_WhenTokenIsNotAValidGuid_ReturnsBadRequest()
        {
            var controller = CreateController(authHeaderToken: "not-a-guid");

            var result = await controller.PostAsync(new TokenInfoRequest { Token = "not-a-guid" });

            var badRequestResult = result.ShouldBeOfType<BadRequestObjectResult>();
            var problemDetails = badRequestResult.Value.ShouldBeAssignableTo<IEdFiProblemDetails>();
            problemDetails.Detail.ShouldContain("invalid token");
        }

        [Test]
        public async Task GetTokenInformation_WhenTokenIsNotFound_ReturnsNotFound()
        {
            A.CallTo(() => _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                .Returns(Task.FromResult<ApiClientDetails>(null));

            var controller = CreateController();

            var result = await controller.PostAsync(new TokenInfoRequest { Token = TestTokenGuid });

            result.ShouldBeOfType<NotFoundResult>();
        }

        [Test]
        public async Task GetTokenInformation_WhenTokenBelongsToDifferentApiKey_ReturnsUnauthorized()
        {
            var clientDetails = new ApiClientDetails { ApiKey = "differentApiKey" };

            A.CallTo(() => _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                .Returns(Task.FromResult(clientDetails));

            A.CallTo(() => _apiClientContextProvider.GetApiClientContext())
                .Returns(CreateApiClientContext(TestApiKey));

            var controller = CreateController();

            var result = await controller.PostAsync(new TokenInfoRequest { Token = TestTokenGuid });

            result.ShouldBeOfType<UnauthorizedResult>();
        }

        [Test]
        public async Task GetTokenInformation_WhenRequestIsValid_ReturnsOkWithTokenInfo()
        {
            var clientDetails = new ApiClientDetails { ApiKey = TestApiKey };
            var apiContext = CreateApiClientContext(TestApiKey);
            var tokenInfo = new TokenInfo();

            A.CallTo(() => _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                .Returns(Task.FromResult(clientDetails));

            A.CallTo(() => _apiClientContextProvider.GetApiClientContext())
                .Returns(apiContext);

            A.CallTo(() => _tokenInfoProvider.GetTokenInfoAsync(A<ApiClientContext>._))
                .Returns(Task.FromResult(tokenInfo));

            var controller = CreateController();

            var result = await controller.PostAsync(new TokenInfoRequest { Token = TestTokenGuid });

            var okResult = result.ShouldBeOfType<OkObjectResult>();
            okResult.Value.ShouldBe(tokenInfo);
        }

        [Test]
        public async Task GetTokenInformation_WhenBodyTokenDoesNotMatchAuthHeaderToken_ReturnsBadRequest()
        {
            // Auth header has one token; request body has a different token
            const string headerToken = TestTokenGuid;
            const string bodyToken = "aaaabbbbccccddddeeeeffffaaaabbbb";

            var controller = CreateController(authHeaderToken: headerToken);

            var result = await controller.PostAsync(new TokenInfoRequest { Token = bodyToken });

            var badRequestResult = result.ShouldBeOfType<BadRequestObjectResult>();
            var problemDetails = badRequestResult.Value.ShouldBeAssignableTo<IEdFiProblemDetails>();
            problemDetails.Detail.ShouldBe("The authentication token and the token to inspect must match.");
            problemDetails.Errors.ShouldNotBeEmpty();
            problemDetails.Errors[0].ShouldBe("The authentication token (header) and the token to inspect in the body must match.");
        }
    }
}

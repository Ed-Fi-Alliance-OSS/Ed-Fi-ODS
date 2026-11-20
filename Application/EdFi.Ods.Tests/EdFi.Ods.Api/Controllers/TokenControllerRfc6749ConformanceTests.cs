// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text;
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

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers
{
    [TestFixture]
    public class TokenControllerRfc6749ConformanceTests
    {
        private const string ClientCredentialsGrantType = "client_credentials";

        private IApiClientAuthenticator _apiClientAuthenticator;
        private IAccessTokenFactory _accessTokenFactory;
        private DefaultHttpContext _httpContext;
        private TokenController _controller;

        [SetUp]
        public void SetUp()
        {
            _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();
            _accessTokenFactory = A.Fake<IAccessTokenFactory>();

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .Returns(new ApiClientAuthenticator.AuthenticationResult { IsAuthenticated = false });

            A.CallTo(() => _accessTokenFactory.CreateAccessTokenAsync(A<ApiClientDetails>._, A<string>._))
                .Returns(new AccessToken(Guid.NewGuid().ToString("N"), TimeSpan.FromMinutes(30), null));

            var tokenRequestProvider = new ClientCredentialsTokenRequestProvider(
                _apiClientAuthenticator,
                _accessTokenFactory,
                new OptionsWrapper<SecuritySettings>(new SecuritySettings()));

            _httpContext = new DefaultHttpContext();

            _controller = new TokenController(tokenRequestProvider)
            {
                ControllerContext = new ControllerContext { HttpContext = _httpContext }
            };
        }

        [TestCase("clientId", "secret:with:colons", "clientId", "secret:with:colons")]
        [TestCase("client%3AId", "se%2Bcret%25", "client:Id", "se+cret%")]
        [TestCase("clientId", "two+words", "clientId", "two words")]
        public async Task Header_credentials_are_split_on_the_first_colon_and_form_url_decoded(
            string headerClientId,
            string headerClientSecret,
            string expectedClientId,
            string expectedClientSecret)
        {
            AcceptCredentials(expectedClientId, expectedClientSecret);
            SetBasicAuthorizationHeader($"{headerClientId}:{headerClientSecret}");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            actionResult.ShouldBeOfType<OkObjectResult>();

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(expectedClientId, expectedClientSecret))
                .MustHaveHappenedOnceExactly();
        }

        [TestCase("ab+cd/ef==")]
        [TestCase("100%25off")]
        public async Task Header_credentials_that_only_match_as_received_are_accepted(string storedClientSecret)
        {
            AcceptCredentials("clientId", storedClientSecret);
            SetBasicAuthorizationHeader($"clientId:{storedClientSecret}");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            actionResult.ShouldBeOfType<OkObjectResult>();

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustHaveHappenedTwiceExactly();
        }

        [Test]
        public async Task Header_credentials_that_decoding_does_not_change_are_authenticated_once()
        {
            SetBasicAuthorizationHeader("clientId:wrongSecret");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertInvalidClientWithChallenge(actionResult);

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Header_credentials_that_fail_both_decoded_and_as_received_are_rejected()
        {
            SetBasicAuthorizationHeader("clientId:wrong%2Bsecret");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertInvalidClientWithChallenge(actionResult);

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustHaveHappenedTwiceExactly();
        }

        [Test]
        public async Task Header_credentials_changed_by_decoding_are_not_retried_after_a_scope_error()
        {
            AcceptCredentials("clientId", "se+cret");
            SetBasicAuthorizationHeader("clientId:se%2Bcret");

            var actionResult = await _controller.PostAsync(
                new TokenRequest
                {
                    Grant_type = ClientCredentialsGrantType,
                    Scope = "999"
                });

            AssertBadRequestWithoutChallenge(actionResult, TokenErrorType.InvalidScope);

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Header_credentials_changed_by_decoding_are_not_retried_when_the_client_is_not_approved()
        {
            AcceptCredentials("clientId", "se+cret");
            SetBasicAuthorizationHeader("clientId:se%2Bcret");

            A.CallTo(() => _accessTokenFactory.CreateAccessTokenAsync(A<ApiClientDetails>._, A<string>._))
                .Returns((AccessToken) null);

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertInvalidClientWithChallenge(actionResult);

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustHaveHappenedOnceExactly();
        }

        [TestCase("%20:%20")]
        [TestCase("+:+")]
        public async Task Header_credentials_that_decode_to_whitespace_are_rejected_without_authenticating(
            string decodedCredentials)
        {
            SetBasicAuthorizationHeader(decodedCredentials);

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertInvalidClientWithChallenge(actionResult);

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustNotHaveHappened();
        }

        [Test]
        public async Task Body_credentials_are_not_form_url_decoded()
        {
            AcceptCredentials("clientId", "se%2Bcret");

            var actionResult = await _controller.PostAsync(
                new TokenRequest
                {
                    Grant_type = ClientCredentialsGrantType,
                    Client_id = "clientId",
                    Client_secret = "se%2Bcret"
                });

            actionResult.ShouldBeOfType<OkObjectResult>();

            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Missing_client_credentials_return_invalid_client_with_a_challenge()
        {
            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertInvalidClientWithChallenge(actionResult);
        }

        [Test]
        public async Task Unsupported_authorization_scheme_returns_invalid_client_with_a_challenge()
        {
            _httpContext.Request.Headers.Authorization = "Digest username=\"clientId\"";

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertInvalidClientWithChallenge(actionResult);
        }

        [Test]
        public async Task Client_credentials_in_both_the_header_and_the_body_return_invalid_request_without_a_challenge()
        {
            SetBasicAuthorizationHeader("clientId:clientSecret");

            var actionResult = await _controller.PostAsync(
                new TokenRequest
                {
                    Grant_type = ClientCredentialsGrantType,
                    Client_secret = "clientSecret"
                });

            AssertBadRequestWithoutChallenge(
                actionResult,
                TokenErrorType.InvalidRequest,
                "Client credentials must be supplied in either the Authorization header or the request body, not both.");
        }

        [Test]
        public async Task Header_credentials_without_a_colon_return_invalid_request()
        {
            SetBasicAuthorizationHeader("NoColonHere");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertBadRequestWithoutChallenge(
                actionResult,
                TokenErrorType.InvalidRequest,
                "The decoded Basic credentials must contain a ':' between the client_id and the client_secret.");
        }

        [TestCase("Basic")]
        [TestCase("Basic ")]
        [TestCase("Basic ThisIsNotBase64Encoded")]
        public async Task Malformed_basic_header_returns_invalid_request_with_a_description(string authorizationHeader)
        {
            _httpContext.Request.Headers.Authorization = authorizationHeader;

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = ClientCredentialsGrantType });

            AssertBadRequestWithoutChallenge(
                actionResult,
                TokenErrorType.InvalidRequest,
                "The Authorization header must be 'Basic' followed by the Base64 encoding of client_id:client_secret.");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public async Task Missing_grant_type_returns_invalid_request(string grantType)
        {
            AcceptCredentials("clientId", "clientSecret");
            SetBasicAuthorizationHeader("clientId:clientSecret");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = grantType });

            AssertBadRequestWithoutChallenge(
                actionResult,
                TokenErrorType.InvalidRequest,
                "The 'grant_type' parameter is required.");
        }

        [Test]
        public async Task Unknown_grant_type_returns_unsupported_grant_type()
        {
            AcceptCredentials("clientId", "clientSecret");
            SetBasicAuthorizationHeader("clientId:clientSecret");

            var actionResult = await _controller.PostAsync(new TokenRequest { Grant_type = "password" });

            AssertBadRequestWithoutChallenge(actionResult, TokenErrorType.UnsupportedGrantType);
        }

        private void AcceptCredentials(string clientId, string clientSecret)
        {
            A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(clientId, clientSecret))
                .Returns(
                    new ApiClientAuthenticator.AuthenticationResult
                    {
                        IsAuthenticated = true,
                        ApiClientDetails = new ApiClientDetails { ApiKey = clientId, ApiClientId = 1 }
                    });
        }

        private void SetBasicAuthorizationHeader(string decodedCredentials)
        {
            _httpContext.Request.Headers.Authorization =
                $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(decodedCredentials))}";
        }

        private void AssertInvalidClientWithChallenge(IActionResult actionResult)
        {
            var unauthorizedResult = actionResult.ShouldBeOfType<UnauthorizedObjectResult>();

            unauthorizedResult.ShouldSatisfyAllConditions(
                () => unauthorizedResult.StatusCode.ShouldBe(StatusCodes.Status401Unauthorized),
                () => unauthorizedResult.Value.ShouldBeOfType<TokenError>().Error.ShouldBe(TokenErrorType.InvalidClient),
                () => _httpContext.Response.Headers.WWWAuthenticate.ToString()
                    .ShouldBe("Basic realm=\"Ed-Fi ODS API\", charset=\"UTF-8\""));
        }

        private void AssertBadRequestWithoutChallenge(
            IActionResult actionResult,
            string expectedError,
            string expectedDescription = null)
        {
            var badRequestResult = actionResult.ShouldBeOfType<BadRequestObjectResult>();
            var tokenError = badRequestResult.Value.ShouldBeOfType<TokenError>();

            badRequestResult.ShouldSatisfyAllConditions(
                () => tokenError.Error.ShouldBe(expectedError),
                () =>
                {
                    if (expectedDescription != null)
                    {
                        tokenError.Error_description.ShouldBe(expectedDescription);
                    }
                },
                () => _httpContext.Response.Headers.WWWAuthenticate.ShouldBeEmpty());
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Features.Controllers;
using EdFi.Ods.Features.TokenInfo;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.FeatureManagement;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Controllers
{
    [TestFixture]
    public class TokenInfoControllerTests
    {
        private const string SuppliedApiKey = "test-api-key-abc123";
        private static readonly Guid SuppliedTokenGuid = Guid.NewGuid();

        // ---------------------------------------------------------------------------
        // Helper: build a controller wired with the supplied dependencies
        // ---------------------------------------------------------------------------
        private static TokenInfoController CreateController(
            ITokenInfoProvider tokenInfoProvider,
            IApiClientDetailsProvider apiClientDetailsProvider,
            IApiClientContextProvider apiClientContextProvider,
            ILogContextAccessor logContextAccessor,
            IFeatureManager featureManager,
            SecuritySettings securitySettings,
            IHttpContextAccessor httpContextAccessor)
        {
            return new TokenInfoController(
                tokenInfoProvider,
                apiClientDetailsProvider,
                apiClientContextProvider,
                logContextAccessor,
                featureManager,
                new OptionsWrapper<SecuritySettings>(securitySettings),
                httpContextAccessor);
        }

        // ---------------------------------------------------------------------------
        // Helper: configure an IFeatureManager fake so IsEnabledAsync returns the
        // given bool (the controller calls the synchronous extension which wraps it).
        // ---------------------------------------------------------------------------
        private static IFeatureManager FeatureManagerFor(bool enabled)
        {
            var fm = A.Fake<IFeatureManager>();
            A.CallTo(() => fm.IsEnabledAsync(ApiFeature.TokenInfo.Value))
                .Returns(Task.FromResult(enabled));
            return fm;
        }

        // ---------------------------------------------------------------------------
        // Helper: build a minimal ApiClientContext with the given key.
        // ---------------------------------------------------------------------------
        private static ApiClientContext ClientContextFor(string apiKey)
            => new(apiKey, "claimSet", Array.Empty<long>(), Array.Empty<string>(),
                Array.Empty<string>(), null, null, Array.Empty<short>(),
                Array.Empty<int>(), 1);

        // ---------------------------------------------------------------------------
        // Helper: build an ApiClientDetails whose ApiKey equals the given value.
        // ---------------------------------------------------------------------------
        private static ApiClientDetails DetailsFor(string apiKey)
            => new()
            {
                ApiKey = apiKey,
                ExpiresUtc = DateTime.UtcNow.AddHours(1)
            };

        // ---------------------------------------------------------------------------
        // Helper: create an IHttpContextAccessor fake that returns the given
        // Authorization header value and (optionally) a JTI claim.
        // ---------------------------------------------------------------------------
        private static IHttpContextAccessor HttpContextAccessorFor(
            string authorizationHeader,
            string jtiClaimValue = null)
        {
            var request = A.Fake<HttpRequest>();
            var headers = new HeaderDictionary
            {
                { "Authorization", new StringValues(authorizationHeader) }
            };
            A.CallTo(() => request.Headers).Returns(headers);

            ClaimsPrincipal user;
            if (jtiClaimValue != null)
            {
                user = new ClaimsPrincipal(new ClaimsIdentity(
                    new[] { new Claim(JwtRegisteredClaimNames.Jti, jtiClaimValue) }));
            }
            else
            {
                user = new ClaimsPrincipal(new ClaimsIdentity());
            }

            var httpContext = A.Fake<HttpContext>();
            A.CallTo(() => httpContext.Request).Returns(request);
            A.CallTo(() => httpContext.User).Returns(user);

            // Response headers stub so the controller can set CacheControl
            var response = A.Fake<HttpResponse>();
            var responseHeaders = new HeaderDictionary();
            A.CallTo(() => response.Headers).Returns(responseHeaders);
            A.CallTo(() => httpContext.Response).Returns(response);

            var accessor = A.Fake<IHttpContextAccessor>();
            A.CallTo(() => accessor.HttpContext).Returns(httpContext);
            return accessor;
        }

        // ===========================================================================
        // Feature disabled
        // ===========================================================================

        public class When_TokenInfo_feature_is_disabled : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(false),
                    new SecuritySettings(),
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostAsync(new TokenInfoRequest { Token = SuppliedTokenGuid.ToString() });
            }

            [Test]
            public void Should_return_404_NotFound()
                => _result.ShouldBeOfType<NotFoundResult>();
        }

        // ===========================================================================
        // GUID mode — invalid / missing token
        // ===========================================================================

        public class When_token_request_is_null_in_guid_mode : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostAsync(null);
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        public class When_token_property_is_null_in_guid_mode : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostAsync(new TokenInfoRequest { Token = null });
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        public class When_token_is_not_a_valid_guid : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostAsync(new TokenInfoRequest { Token = "not-a-guid" });
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        // ===========================================================================
        // GUID mode — token not found / belongs to another client
        // ===========================================================================

        public class When_guid_token_is_not_found_in_the_database : TestFixtureAsyncBase
        {
            private IActionResult _result;
            private IApiClientDetailsProvider _apiClientDetailsProvider;

            protected override Task ArrangeAsync()
            {
                _apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => _apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                    .Returns(Task.FromResult<ApiClientDetails>(null));
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                var contextProvider = A.Fake<IApiClientContextProvider>();
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(ClientContextFor(SuppliedApiKey));

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    _apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostAsync(new TokenInfoRequest { Token = SuppliedTokenGuid.ToString() });
            }

            [Test]
            public void Should_return_404_NotFound()
                => _result.ShouldBeOfType<NotFoundResult>();
        }

        public class When_guid_token_belongs_to_a_different_api_client : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                // Token exists but with a different ApiKey than the authenticated caller
                var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                    .Returns(Task.FromResult(DetailsFor("different-api-key")));

                var contextProvider = A.Fake<IApiClientContextProvider>();
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(ClientContextFor(SuppliedApiKey));

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostAsync(new TokenInfoRequest { Token = SuppliedTokenGuid.ToString() });
            }

            [Test]
            public void Should_return_404_NotFound_not_401()
                => _result.ShouldBeOfType<NotFoundResult>();
        }

        // ===========================================================================
        // GUID mode — successful introspection
        // ===========================================================================

        public class When_guid_token_is_valid_and_belongs_to_the_caller : TestFixtureAsyncBase
        {
            private IActionResult _result;
            private TokenInfo _suppliedTokenInfo;

            protected override Task ArrangeAsync()
            {
                _suppliedTokenInfo = TokenInfo.Create(
                    ClientContextFor(SuppliedApiKey),
                    Array.Empty<TokenInfoEducationOrganizationData>(),
                    Array.Empty<TokenInfoResource>(),
                    Array.Empty<TokenInfoService>());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                    .Returns(Task.FromResult(DetailsFor(SuppliedApiKey)));

                var contextProvider = A.Fake<IApiClientContextProvider>();
                var apiContext = ClientContextFor(SuppliedApiKey);
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(apiContext);

                var tokenInfoProvider = A.Fake<ITokenInfoProvider>();
                A.CallTo(() => tokenInfoProvider.GetTokenInfoAsync(apiContext))
                    .Returns(Task.FromResult(_suppliedTokenInfo));

                var httpContext = A.Fake<HttpContext>();
                var response = A.Fake<HttpResponse>();
                A.CallTo(() => response.Headers).Returns(new HeaderDictionary());
                A.CallTo(() => httpContext.Response).Returns(response);
                var accessor = A.Fake<IHttpContextAccessor>();
                A.CallTo(() => accessor.HttpContext).Returns(httpContext);

                var controller = CreateController(
                    tokenInfoProvider,
                    apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    accessor);

                _result = await controller.PostAsync(new TokenInfoRequest { Token = SuppliedTokenGuid.ToString() });
            }

            [Test]
            public void Should_return_200_OK()
                => _result.ShouldBeOfType<OkObjectResult>();

            [Test]
            public void Should_return_token_info_payload()
                => ((OkObjectResult)_result).Value.ShouldBeSameAs(_suppliedTokenInfo);
        }

        // ===========================================================================
        // JWT mode — token mismatch
        // ===========================================================================

        public class When_jwt_submitted_token_does_not_match_bearer_token : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var jtiGuid = Guid.NewGuid();
                var accessor = HttpContextAccessorFor(
                    $"Bearer actual.bearer.token",
                    jtiClaimValue: jtiGuid.ToString());

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeJwt },
                    accessor);

                // Token in body differs from the Bearer token in the Authorization header
                _result = await controller.PostAsync(new TokenInfoRequest { Token = "different.token.value" });
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        public class When_jwt_authorization_header_is_missing : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var request = A.Fake<HttpRequest>();
                A.CallTo(() => request.Headers).Returns(new HeaderDictionary());

                var httpContext = A.Fake<HttpContext>();
                A.CallTo(() => httpContext.Request).Returns(request);
                A.CallTo(() => httpContext.User).Returns(new ClaimsPrincipal(new ClaimsIdentity()));

                var accessor = A.Fake<IHttpContextAccessor>();
                A.CallTo(() => accessor.HttpContext).Returns(httpContext);

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeJwt },
                    accessor);

                _result = await controller.PostAsync(new TokenInfoRequest { Token = "some.jwt.token" });
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        public class When_jwt_jti_claim_is_missing_or_not_a_guid : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                const string bearerToken = "matching.jwt.token";
                // JTI is not a valid GUID
                var accessor = HttpContextAccessorFor(
                    $"Bearer {bearerToken}",
                    jtiClaimValue: "not-a-guid");

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeJwt },
                    accessor);

                _result = await controller.PostAsync(new TokenInfoRequest { Token = bearerToken });
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        // ===========================================================================
        // JWT mode — token not found / belongs to another client
        // ===========================================================================

        public class When_jwt_token_is_not_found_in_the_database : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var jtiGuid = Guid.NewGuid();
                const string bearerToken = "valid.jwt.token";
                var accessor = HttpContextAccessorFor($"Bearer {bearerToken}", jtiGuid.ToString());

                var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                    .Returns(Task.FromResult<ApiClientDetails>(null));

                var contextProvider = A.Fake<IApiClientContextProvider>();
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(ClientContextFor(SuppliedApiKey));

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeJwt },
                    accessor);

                _result = await controller.PostAsync(new TokenInfoRequest { Token = bearerToken });
            }

            [Test]
            public void Should_return_404_NotFound()
                => _result.ShouldBeOfType<NotFoundResult>();
        }

        public class When_jwt_token_belongs_to_a_different_api_client : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var jtiGuid = Guid.NewGuid();
                const string bearerToken = "valid.jwt.token";
                var accessor = HttpContextAccessorFor($"Bearer {bearerToken}", jtiGuid.ToString());

                var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                    .Returns(Task.FromResult(DetailsFor("foreign-key")));

                var contextProvider = A.Fake<IApiClientContextProvider>();
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(ClientContextFor(SuppliedApiKey));

                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeJwt },
                    accessor);

                _result = await controller.PostAsync(new TokenInfoRequest { Token = bearerToken });
            }

            [Test]
            public void Should_return_404_NotFound_not_401()
                => _result.ShouldBeOfType<NotFoundResult>();
        }

        // ===========================================================================
        // JWT mode — successful introspection
        // ===========================================================================

        public class When_jwt_token_is_valid_and_belongs_to_the_caller : TestFixtureAsyncBase
        {
            private IActionResult _result;
            private TokenInfo _suppliedTokenInfo;

            protected override Task ArrangeAsync()
            {
                _suppliedTokenInfo = TokenInfo.Create(
                    ClientContextFor(SuppliedApiKey),
                    Array.Empty<TokenInfoEducationOrganizationData>(),
                    Array.Empty<TokenInfoResource>(),
                    Array.Empty<TokenInfoService>());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                var jtiGuid = Guid.NewGuid();
                const string bearerToken = "valid.jwt.token";
                var accessor = HttpContextAccessorFor($"Bearer {bearerToken}", jtiGuid.ToString());

                var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(jtiGuid.ToString("N")))
                    .Returns(Task.FromResult(DetailsFor(SuppliedApiKey)));

                var contextProvider = A.Fake<IApiClientContextProvider>();
                var apiContext = ClientContextFor(SuppliedApiKey);
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(apiContext);

                var tokenInfoProvider = A.Fake<ITokenInfoProvider>();
                A.CallTo(() => tokenInfoProvider.GetTokenInfoAsync(apiContext))
                    .Returns(Task.FromResult(_suppliedTokenInfo));

                var controller = CreateController(
                    tokenInfoProvider,
                    apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeJwt },
                    accessor);

                _result = await controller.PostAsync(new TokenInfoRequest { Token = bearerToken });
            }

            [Test]
            public void Should_return_200_OK()
                => _result.ShouldBeOfType<OkObjectResult>();

            [Test]
            public void Should_return_token_info_payload()
                => ((OkObjectResult)_result).Value.ShouldBeSameAs(_suppliedTokenInfo);
        }

        // ===========================================================================
        // Consistent error messages — GUID vs. bad token both return same text
        // ===========================================================================

        public class When_token_is_invalid_error_messages_should_not_leak_token_mode : TestFixtureAsyncBase
        {
            private BadRequestObjectResult _guidModeResult;
            private BadRequestObjectResult _missingTokenResult;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var logContextAccessor = A.Fake<ILogContextAccessor>();
                A.CallTo(() => logContextAccessor.GetValue(A<string>._)).Returns(null);

                var guidController = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    logContextAccessor,
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _guidModeResult = (BadRequestObjectResult)await guidController.PostAsync(
                    new TokenInfoRequest { Token = "not-a-guid" });

                _missingTokenResult = (BadRequestObjectResult)await guidController.PostAsync(
                    new TokenInfoRequest { Token = null });
            }

            [Test]
            public void Should_return_same_error_message_regardless_of_failure_reason()
            {
                var guidBody = _guidModeResult.Value?.ToString();
                var missingBody = _missingTokenResult.Value?.ToString();

                AssertHelper.All(
                    () => _guidModeResult.StatusCode.ShouldBe(StatusCodes.Status400BadRequest),
                    () => _missingTokenResult.StatusCode.ShouldBe(StatusCodes.Status400BadRequest),
                    () => guidBody.ShouldNotContain("GUID"),
                    () => guidBody.ShouldNotContain("guid"),
                    () => guidBody.ShouldBe(missingBody));
            }
        }

        // ===========================================================================
        // Form-encoded endpoint delegates to same logic
        // ===========================================================================

        public class When_posting_via_form_encoding_with_invalid_token : TestFixtureAsyncBase
        {
            private IActionResult _result;

            protected override Task ArrangeAsync() => Task.CompletedTask;

            protected override async Task ActAsync()
            {
                var controller = CreateController(
                    A.Fake<ITokenInfoProvider>(),
                    A.Fake<IApiClientDetailsProvider>(),
                    A.Fake<IApiClientContextProvider>(),
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    A.Fake<IHttpContextAccessor>());

                _result = await controller.PostFromFormAsync(new TokenInfoRequest { Token = "not-a-guid" });
            }

            [Test]
            public void Should_return_400_BadRequest()
                => _result.ShouldBeOfType<BadRequestObjectResult>();
        }

        public class When_posting_via_form_encoding_with_valid_guid_token : TestFixtureAsyncBase
        {
            private IActionResult _result;
            private TokenInfo _suppliedTokenInfo;

            protected override Task ArrangeAsync()
            {
                _suppliedTokenInfo = TokenInfo.Create(
                    ClientContextFor(SuppliedApiKey),
                    Array.Empty<TokenInfoEducationOrganizationData>(),
                    Array.Empty<TokenInfoResource>(),
                    Array.Empty<TokenInfoService>());
                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                var apiClientDetailsProvider = A.Fake<IApiClientDetailsProvider>();
                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForTokenAsync(A<string>._))
                    .Returns(Task.FromResult(DetailsFor(SuppliedApiKey)));

                var contextProvider = A.Fake<IApiClientContextProvider>();
                var apiContext = ClientContextFor(SuppliedApiKey);
                A.CallTo(() => contextProvider.GetApiClientContext()).Returns(apiContext);

                var tokenInfoProvider = A.Fake<ITokenInfoProvider>();
                A.CallTo(() => tokenInfoProvider.GetTokenInfoAsync(apiContext))
                    .Returns(Task.FromResult(_suppliedTokenInfo));

                var httpContext = A.Fake<HttpContext>();
                var response = A.Fake<HttpResponse>();
                A.CallTo(() => response.Headers).Returns(new HeaderDictionary());
                A.CallTo(() => httpContext.Response).Returns(response);
                var accessor = A.Fake<IHttpContextAccessor>();
                A.CallTo(() => accessor.HttpContext).Returns(httpContext);

                var controller = CreateController(
                    tokenInfoProvider,
                    apiClientDetailsProvider,
                    contextProvider,
                    A.Fake<ILogContextAccessor>(),
                    FeatureManagerFor(true),
                    new SecuritySettings { AccessTokenType = SecuritySettings.AccessTokenTypeGuid },
                    accessor);

                _result = await controller.PostFromFormAsync(new TokenInfoRequest { Token = SuppliedTokenGuid.ToString() });
            }

            [Test]
            public void Should_return_200_OK()
                => _result.ShouldBeOfType<OkObjectResult>();
        }
    }
}

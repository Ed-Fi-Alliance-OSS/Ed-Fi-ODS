// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Threading.Tasks;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Api.Security.Authentication;
using EdFi.Ods.Common.Configuration;
using FakeItEasy;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Providers
{
    [TestFixture]
    public class ClientCredentialsTokenRequestProviderScopeTests
    {
        private const long EducationOrganizationIdAboveIntMaxValue = 3_000_000_001L;

        private IAccessTokenFactory _accessTokenFactory;
        private ClientCredentialsTokenRequestProvider _provider;

        [SetUp]
        public void SetUp()
        {
            var apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();
            _accessTokenFactory = A.Fake<IAccessTokenFactory>();

            A.CallTo(() => apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                .Returns(
                    new ApiClientAuthenticator.AuthenticationResult
                    {
                        IsAuthenticated = true,
                        ApiClientDetails = new ApiClientDetails
                        {
                            ApiKey = "clientId",
                            EducationOrganizationIds = new[] { 255901L, EducationOrganizationIdAboveIntMaxValue }
                        }
                    });

            A.CallTo(() => _accessTokenFactory.CreateAccessTokenAsync(A<ApiClientDetails>._, A<string>._))
                .ReturnsLazily((ApiClientDetails _, string scope) =>
                    new AccessToken(Guid.NewGuid().ToString("N"), TimeSpan.FromMinutes(30), scope));

            _provider = new ClientCredentialsTokenRequestProvider(
                apiClientAuthenticator,
                _accessTokenFactory,
                new OptionsWrapper<SecuritySettings>(new SecuritySettings()));
        }

        [TestCase("255901")]
        [TestCase("3000000001")]
        public async Task A_scope_matching_an_associated_education_organization_is_issued(string scope)
        {
            var response = await _provider.HandleAsync(CreateTokenRequest(scope));

            response.ShouldSatisfyAllConditions(
                () => response.TokenError.ShouldBeNull(),
                () => response.TokenResponse.Scope.ShouldBe(scope));

            A.CallTo(() => _accessTokenFactory.CreateAccessTokenAsync(A<ApiClientDetails>._, scope))
                .MustHaveHappenedOnceExactly();
        }

        [TestCase("+255901")]
        [TestCase("-255901")]
        [TestCase("255,901")]
        [TestCase("255901 255902")]
        public async Task A_scope_that_is_not_only_digits_is_rejected_without_issuing_a_token(string scope)
        {
            var response = await _provider.HandleAsync(CreateTokenRequest(scope));

            response.TokenError.ShouldNotBeNull().Error.ShouldBe(TokenErrorType.InvalidScope);

            A.CallTo(() => _accessTokenFactory.CreateAccessTokenAsync(A<ApiClientDetails>._, A<string>._))
                .MustNotHaveHappened();
        }

        private static TokenRequest CreateTokenRequest(string scope)
            => new()
            {
                Grant_type = "client_credentials",
                Client_id = "clientId",
                Client_secret = "clientSecret",
                Scope = scope
            };
    }
}

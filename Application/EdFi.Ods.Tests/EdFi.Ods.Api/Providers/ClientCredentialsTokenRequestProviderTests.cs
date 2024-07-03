// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Models.ClientCredentials;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;

// ReSharper disable InconsistentNaming
namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authentication.ClientCredentials
{
    [TestFixture]
    public class ClientCredentialsTokenRequestProviderTests
    {
        private const string ClientId = "clientId";
        private const string ClientSecret = "clientSecret";

        public class When_handling_a_valid_token_request
            : TestFixtureBase
        {
            private TokenRequest _tokenRequest;
            private IAccessTokenClientRepo _accessTokenClientRepo;
            private IApiClientAuthenticator _apiClientAuthenticator;
            private ClientCredentialsTokenRequestProvider _clientCredentialsTokenRequestProvider;
            private AuthenticationResponse _actionResult;

            protected override void Arrange()
            {
                var apiClient = new ApiClient { ApiClientId = 0 };

                _accessTokenClientRepo = A.Fake<IAccessTokenClientRepo>();
                _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                A.CallTo(() => _accessTokenClientRepo.AddClientAccessToken(A<int>._, A<string>._))
                    .Returns(new ClientAccessToken { ApiClient = new ApiClient() });

                _tokenRequest = new TokenRequest
                {
                    Client_id = ClientId,
                    Client_secret = ClientSecret,
                    Grant_type = "client_credentials"
                };

                var clientSecret = new ApiClientSecret
                {
                    IsHashed = true,
                    Secret = ClientSecret
                };

                A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                    .Returns(
                        Task.FromResult<ApiClientAuthenticator.AuthenticationResult>(
                            new ApiClientAuthenticator.AuthenticationResult
                            {
                                IsAuthenticated = true,
                                ApiClientIdentity = new ApiClientIdentity
                                {
                                    Key = ClientId,
                                    EducationOrganizationIds = new List<int>() { 997, 998, 999 }
                                }
                            }));
            }

            protected override void Act()
            {
                _clientCredentialsTokenRequestProvider =
                    new ClientCredentialsTokenRequestProvider( _apiClientAuthenticator, _accessTokenClientRepo);

                _actionResult = _clientCredentialsTokenRequestProvider.HandleAsync(_tokenRequest).GetResultSafely();
            }

            [Assert]
            public void Should_return_a_non_null_action_result()
            {
                Assert.That(_actionResult, Is.Not.Null);
            }

            [Assert]
            public void Should_have_action_result_type_of_authentication_success()
            {
                Assert.That(_actionResult, Is.InstanceOf<AuthenticationResponse>());
            }

            [Assert]
            public void Should_call_try_authenticate_from_the_database_once()
            {
                A.CallTo(
                    () => _apiClientAuthenticator.TryAuthenticateAsync(ClientId, ClientSecret));
            }
        }

        public class When_handling_an_invalid_token_request
            : TestFixtureBase
        {
            private IClientAppRepo _clientAppRepo;
            private IAccessTokenClientRepo _accessTokenClientRepo;
            private IApiClientAuthenticator _apiClientAuthenticator;
            private TokenRequest _tokenRequest;
            private ClientCredentialsTokenRequestProvider _clientCredentialsTokenRequestHandler;
            private AuthenticationResponse _actionResult;

            protected override void Arrange()
            {
                _clientAppRepo = A.Fake<IClientAppRepo>();
                _accessTokenClientRepo = A.Fake<IAccessTokenClientRepo>();
                _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                _tokenRequest = new TokenRequest
                {
                    Client_id = ClientId,
                    Client_secret = ClientSecret,
                    Grant_type = "client_credentials"
                };

                _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                    .Returns(
                        Task.FromResult<ApiClientAuthenticator.AuthenticationResult>(
                            new ApiClientAuthenticator.AuthenticationResult
                            {
                                IsAuthenticated = true,
                                ApiClientIdentity = new ApiClientIdentity
                                {
                                    Key = ClientId,
                                }
                            }));
            }

            protected override void Act()
            {
                _clientCredentialsTokenRequestHandler =
                    new ClientCredentialsTokenRequestProvider(_apiClientAuthenticator, _accessTokenClientRepo);

                _actionResult = _clientCredentialsTokenRequestHandler.HandleAsync(_tokenRequest).Result;
            }

            [Assert]
            public void Should_return_a_non_null_action_result()
            {
                Assert.That(_actionResult, Is.Not.Null);
            }

            [Assert]
            public void Should_have_action_result_type_of_authentication_error()
            {
                Assert.That(_actionResult, Is.InstanceOf<AuthenticationResponse>());
            }

            [Assert]
            public void Should_call_try_authenticate_from_database_once()
            {
                A.CallTo(
                    () => _apiClientAuthenticator.TryAuthenticateAsync(ClientId, ClientSecret)).MustHaveHappened();
            }
        }
    }
}
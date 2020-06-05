// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net.Http;
using System.Web.Http;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.Services.Authentication.ClientCredentials;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Sandbox.Repositories;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Authentication.ClientCredentials
{
    [TestFixture]
    public class ClientCredentialsTokenRequestHandlerTests
    {
        internal const string ClientId = "clientId";
        internal const string ClientSecret = "clientSecret";
        private static readonly ApiClientAuthenticatorHelper _apiClientAuthenticatorHelper = new ApiClientAuthenticatorHelper();

        public class When_handling_a_valid_token_request
            : LegacyTestFixtureBase
        {
            private readonly HttpRequestMessage _httpRequest = null;
            private TokenRequest _tokenRequest;
            private IClientAppRepo _clientAppRepo;
            private IApiClientAuthenticator _apiClientAuthenticator;
            private ClientCredentialsTokenRequestHandler _clientCredentialsTokenRequestHandler;
            private IHttpActionResult _actionResult;

            protected override void Arrange()
            {
                var apiClient = new ApiClient
                                {
                                    ApiClientId = 0
                                };

                _clientAppRepo = mocks.Stub<IClientAppRepo>();

                _clientAppRepo.Expect(c => c.GetClient(Arg<string>.Is.Anything))
                              .Return(apiClient);

                _clientAppRepo.Expect(c => c.AddClientAccessToken(0))
                              .Return(new ClientAccessToken());

                _tokenRequest = new TokenRequest
                                {
                                    Client_id = ClientId, Client_secret = ClientSecret
                                };

                _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

                _clientCredentialsTokenRequestHandler = new ClientCredentialsTokenRequestHandler(_clientAppRepo, _apiClientAuthenticator);
            }

            protected override void Act()
            {
                _clientCredentialsTokenRequestHandler.Handle(_httpRequest, _tokenRequest, out _actionResult);
            }

            [Assert]
            public void Should_return_a_non_null_action_result()
            {
                Assert.That(_actionResult, Is.Not.Null);
            }

            [Assert]
            public void Should_have_action_result_type_of_authentication_success()
            {
                Assert.That(_actionResult, Is.InstanceOf<AuthenticationSuccess>());
            }

            [Assert]
            public void Should_call_get_client_from_the_database_once()
            {
                _clientAppRepo.AssertWasCalled(
                    x => x.GetClient(Arg<string>.Is.Equal(ClientId)),
                    x => x.Repeat.Once());
            }

            [Assert]
            public void Should_call_try_authenticate_from_the_database_once()
            {
                ApiClientIdentity apiClientIdentity;

                _apiClientAuthenticator.AssertWasCalled(
                    x => x.TryAuthenticate(ClientId, ClientSecret, out apiClientIdentity),
                    x => x.Repeat.Once());
            }

            [Assert]
            public void Should_add_the_client_access_token_to_the_database_once()
            {
                _clientAppRepo.AssertWasCalled(c => c.AddClientAccessToken(Arg<int>.Is.Equal(0), Arg<string>.Is.Equal(null)), x => x.Repeat.Once());
            }
        }

        public class When_handling_an_invalid_token_request
            : LegacyTestFixtureBase
        {
            private readonly HttpRequestMessage _httpRequest = null;
            private IClientAppRepo _clientAppRepo;
            private IApiClientAuthenticator _apiClientAuthenticator;
            private TokenRequest _tokenRequest;
            private ClientCredentialsTokenRequestHandler _clientCredentialsTokenRequestHandler;
            private IHttpActionResult _actionResult;

            protected override void Arrange()
            {
                _clientAppRepo = MockRepository.GenerateStub<IClientAppRepo>();

                _tokenRequest = new TokenRequest
                                {
                                    Client_id = ClientId, Client_secret = ClientSecret
                                };

                _apiClientAuthenticator = MockRepository.GenerateStub<IApiClientAuthenticator>();
                ApiClientIdentity apiClientIdentity;

                _apiClientAuthenticator
                   .Expect(aca => aca.TryAuthenticate(null, null, out apiClientIdentity))
                   .IgnoreArguments()
                   .Do(
                        new ApiClientAuthenticatorDelegates.TryAuthenticateDelegate(
                            (string key, string password, out ApiClientIdentity identity) =>
                            {
                                identity = null;
                                return false;
                            }));

                _clientCredentialsTokenRequestHandler = new ClientCredentialsTokenRequestHandler(_clientAppRepo, _apiClientAuthenticator);
            }

            protected override void Act()
            {
                _clientCredentialsTokenRequestHandler.Handle(_httpRequest, _tokenRequest, out _actionResult);
            }

            [Assert]
            public void Should_return_a_non_null_action_result()
            {
                Assert.That(_actionResult, Is.Not.Null);
            }

            [Assert]
            public void Should_have_action_result_type_of_authentication_error()
            {
                Assert.That(_actionResult, Is.InstanceOf<AuthenticationError>());
            }

            [Assert]
            public void Should_call_try_authenticate_from_database_once()
            {
                ApiClientIdentity apiClientIdentity;

                _apiClientAuthenticator.AssertWasCalled(
                    x => x.TryAuthenticate(ClientId, ClientSecret, out apiClientIdentity),
                    x => x.Repeat.Once());
            }

            [Assert]
            public void Should_not_add_the_client_access_token_to_the_database_once()
            {
                _clientAppRepo.AssertWasNotCalled(c => c.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything));
            }
        }
    }
}

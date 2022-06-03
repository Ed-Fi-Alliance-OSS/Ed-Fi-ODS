// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Admin.DataAccess.Repositories;
using EdFi.Common.Security;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Shouldly;
using Test.Common;

// ReSharper disable InconsistentNaming
namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers
{
    [TestFixture]
    public class TokenControllerUsingJsonTests
    {
        [TestFixture]
        public class When_posting_with_the_client_id_and_secret_in_the_body
        {
            public class With_valid_key_and_secret_in_the_body : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient {ApiClientId = 1};

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity {Key = "clientId", EducationOrganizationIds = new List<int>() { 997, 998, 999 }, ApiClientId = _suppliedClient.ApiClientId}
                                }));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials",
                            Client_id = "clientId",
                            Client_secret = "clientSecret"
                        });

                    _tokenResponse = ((ObjectResult) _actionResult).Value as TokenResponse;
                }

                [Test]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                        () => ((OkObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                [Test]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Guid.Parse(_tokenResponse.Access_token).ShouldBe(_suppliedAccessToken);
                }

                [Test]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    _tokenResponse.Token_type.ShouldBe("bearer");
                }

                [Test]
                public void Should_indicate_the_access_token_expires_within_1_second_of_the_supplied_expiration_time()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_tokenResponse.Expires_in));

                    var expectedBegin = _suppliedTTL.Add(TimeSpan.FromSeconds(-1));

                    var expectedEnd = _suppliedTTL;

                    Assert.That(actualTTL, Is.InRange(expectedBegin, expectedEnd));
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_AccessTokenClientRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustHaveHappened();
                }
            }

            public class With_a_scope_matching_an_associated_EdOrgId : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;

                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1
                    };

                    var ApplicationEducationOrganizations = new List<int>() { 997, 998, 999 };

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    // Scope the request to the first associated EdOrg
                    _requestedScope = ApplicationEducationOrganizations
                        .First()
                        .ToString();

                    _suppliedAccessToken = Guid.NewGuid();


                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(
                            new ClientAccessToken(new TimeSpan(0, 10, 0))
                            {
                                ApiClient = _suppliedClient,
                                Id = _suppliedAccessToken
                            });

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity {Key = "clientId", ApiClientId = _suppliedClient.ApiClientId, EducationOrganizationIds = ApplicationEducationOrganizations }
                                }));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials",
                            Scope = _requestedScope,
                            Client_id = "clientId",
                            Client_secret = "clientSecret"
                        });

                    _tokenResponse = ((ObjectResult) _actionResult).Value as TokenResponse;
                }

                [Test]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                        () => ((OkObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                [Test]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Guid.Parse(_tokenResponse.Access_token).ShouldBe(_suppliedAccessToken);
                }

                [Test]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    _tokenResponse.Token_type.ShouldBe("bearer");
                }

                [Test]
                public void Should_indicate_the_access_token_expires_in_10_minutes()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_tokenResponse.Expires_in));

                    var tenMinutes = TimeSpan.FromMinutes(10);
                    var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

                    Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_AccessTokenClientRepo_to_create_token_using_the_supplied_ApiClientId_and_scope()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, _requestedScope))
                        .MustHaveHappened();
                }
            }

            public class With_a_scope_not_matching_an_associated_EdOrgId : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private string _requestedScope;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1
                    };

                    var ApplicationEducationOrganizations = new List<int>() { 997, 998, 999 };
                    // Scope the request to something not in list above
                    _requestedScope = "1000";

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity {Key = "clientId" , EducationOrganizationIds = ApplicationEducationOrganizations, ApiClientId=_suppliedClient.ApiClientId}
                                }));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials",
                            Scope = _requestedScope,
                            Client_id = "clientId",
                            Client_secret = "clientSecret"
                        });

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
                {
                    AssertHelper.All(
                        () => _tokenError.Error.ShouldBe(TokenErrorType.InvalidScope),
                        () => _tokenError.Error_description.ShouldBe(
                            "The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'."));
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_NOT_use_AccessTokenClientRepo_to_create_token()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }

            public class Using_basic_authorization_with_unacceptable_format_value : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1
                    };

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController(_apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials",
                            Client_id = "clientId",
                            Client_secret = "clientSecret"

                        });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_Unauthorized()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<UnauthorizedObjectResult>(),
                        () => ((UnauthorizedObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));
                }

                [Test]
                public void Should_return_an_error_body_indicating_an_invalid_request()
                {
                    AssertHelper.All(
                        () => _tokenError.Error.ShouldBe(TokenErrorType.InvalidClient));
                }

                [Test]
                public void Should_NOT_use_AccessTokenClientRepo_to_create_token()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }

            public class With_a_scope_that_is_not_a_number : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private string _requestedScope;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1
                    };

                    var ApplicationEducationOrganizations = new List<int>() { 997, 998, 999 };

                    // Scope the request to something not in list above
                    _requestedScope = "9a9";

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity {Key = "clientId" , EducationOrganizationIds = ApplicationEducationOrganizations, ApiClientId=_suppliedClient.ApiClientId}
                                }));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials",
                            Scope = _requestedScope,
                            Client_id = "clientId",
                            Client_secret = "clientSecret"
                        });

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
                {
                    AssertHelper.All(
                        () => _tokenError.Error.ShouldBe(TokenErrorType.InvalidScope),
                        () => _tokenError.Error_description.ShouldBe(
                            "The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client)."));
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_NOT_use_AccessTokenClientRepo_to_create_token()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }

            public class With_no_client_and_secret : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient {ApiClientId = 1};

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    var ApplicationEducationOrganizations = new List<int>() { 997, 998, 999 };

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                     _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = false,
                                    ApiClientIdentity = new ApiClientIdentity {Key = "clientId" , EducationOrganizationIds = ApplicationEducationOrganizations, ApiClientId = _suppliedClient.ApiClientId}
                                }));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials",
                            Client_id = "clientId",
                            Client_secret = "clientSecret"
                        });
                }

                [Test]
                public void Should_return_HTTP_status_of_UnAuthorized()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<UnauthorizedObjectResult>(),
                        () => ((UnauthorizedObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));
                }

                [Test]
                public void Should__call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappened();
                }

                [Test]
                public void Should_not_use_AccessTokenClientRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }
        }

        [TestFixture]
        public class When_posting_with_the_client_id_and_secret_in_the_header
        {
            public class With_Header_Invalid_Bearer_Token_Request : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient {ApiClientId = 1};

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    var ApplicationEducationOrganizations = new List<int>() { 997, 998, 999 };

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext = ControllerHelper.CreateControllerContext(
                        new HeaderDictionary {{"Authorization", $"Basic {ControllerHelper.CreateEncodedAuthentication()}"}});

                    _actionResult = await _controller.PostFromJsonAsync(new TokenRequest());
                }

                [Test]
                public void Should_return_HTTP_status_of_UnAuthorized()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_Not_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustNotHaveHappened();
                }

                [Test]
                public void Should_not_use_AccessTokenClientRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }

            public class With_valid_key_and_secret_in_the_header : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;

                protected override Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient {ApiClientId = 1};

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity {Key = "clientId", ApiClientId = _suppliedClient.ApiClientId }
                                }));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext = ControllerHelper.CreateControllerContext(
                        new HeaderDictionary {{"Authorization", $"Basic {ControllerHelper.CreateEncodedAuthentication()}"}});

                    _actionResult = await _controller.PostFromJsonAsync(new TokenRequest {Grant_type = "client_credentials"});

                    _tokenResponse = ((ObjectResult) _actionResult).Value as TokenResponse;
                }

                [Test]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                        () => ((OkObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                [Test]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Guid.Parse(_tokenResponse.Access_token).ShouldBe(_suppliedAccessToken);
                }

                [Test]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    _tokenResponse.Token_type.ShouldBe("bearer");
                }

                [Test]
                public void Should_indicate_the_access_token_expires_within_1_second_of_the_supplied_expiration_time()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_tokenResponse.Expires_in));

                    var expectedBegin = _suppliedTTL.Add(TimeSpan.FromSeconds(-1));

                    var expectedEnd = _suppliedTTL;

                    Assert.That(actualTTL, Is.InRange(expectedBegin, expectedEnd));
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_AccessTokenClientRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustHaveHappened();
                }
            }

            public class Using_digest_authorization : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {

                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext =
                        ControllerHelper.CreateControllerContext(new HeaderDictionary {{"Authorization", "Digest some-value"}});

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials"});

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_Unauthorized()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<UnauthorizedObjectResult>(),
                        () => ((UnauthorizedObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));
                }

                [Test]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    _tokenError.Error.ShouldBe(TokenErrorType.InvalidClient);
                }
            }

            public class Using_basic_authorization_with_no_value : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext =
                        ControllerHelper.CreateControllerContext(new HeaderDictionary {{"Authorization", "Basic "}});

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials"});

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    _tokenError.Error.ShouldBe(TokenErrorType.InvalidRequest);
                }
            }

            public class Using_basic_authorization_with_invalid_value : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;
                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext =
                        ControllerHelper.CreateControllerContext(
                            new HeaderDictionary {{"Authorization", "Basic Tm9Db2xvbkhlcmU="}});

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials"});

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_not_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    _tokenError.Error.ShouldBe(TokenErrorType.InvalidClient);
                }
            }

            public class Using_basic_authorization_with_unencoded_value : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();
                    
                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext =
                        ControllerHelper.CreateControllerContext(
                            new HeaderDictionary {{"Authorization", "Basic ThisIsNotBase64Encoded"}});

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials"});

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    _tokenError.Error.ShouldBe(TokenErrorType.InvalidRequest);
                }
            }

            public class With_an_incorrect_client_id_and_secret : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;
                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult {IsAuthenticated = false}));

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext = ControllerHelper.CreateControllerContext(
                        new HeaderDictionary
                        {
                            {
                                "Authorization",
                                $"Basic {ControllerHelper.CreateEncodedAuthentication("badClientId", "badClientSecret")}"
                            }
                        });

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials"});

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_UnAuthorized()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<UnauthorizedObjectResult>(),
                        () => ((UnauthorizedObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));
                }

                [Test]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    _tokenError.Error.ShouldBe(TokenErrorType.InvalidClient);
                }
            }

            public class With_an_empty_secret : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext = ControllerHelper.CreateControllerContext(
                        new HeaderDictionary
                        {
                            {
                                "Authorization",
                                $"Basic {ControllerHelper.CreateEncodedAuthentication(clientSecret: string.Empty)}"
                            }
                        });

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest
                        {
                            Client_id = "clientId",
                            Client_secret = string.Empty,
                            Grant_type = "client_credentials"
                        });

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    _tokenError.Error.Equals(TokenErrorType.InvalidClient);
                }
            }

            public class With_a_missing_secret : TestFixtureAsyncBase
            {
                private IAccessTokenClientRepo _accessTokenClientRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override Task ArrangeAsync()
                {
                    _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                    return Task.CompletedTask;
                }

                protected override async Task ActAsync()
                {
                    _controller.ControllerContext = ControllerHelper.CreateControllerContext(
                        new HeaderDictionary
                        {
                            {"Authorization", $"Basic {ControllerHelper.CreateEncodedAuthentication(clientSecret: null)}"}
                        });

                    _actionResult = await _controller.PostFromJsonAsync(
                        new TokenRequest {Grant_type = "client_credentials"});

                    _tokenError = ((ObjectResult) _actionResult).Value as TokenError;
                }

                [Test]
                public void Should_return_HTTP_status_of_UnAuthorized()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<UnauthorizedObjectResult>(),
                        () => ((UnauthorizedObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));
                }

                [Test]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    _tokenError.Error.ShouldBe(TokenErrorType.InvalidRequest);
                }
            }
        }

        public class
            With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_id_is_provided_in_the_body_as_well
            : TestFixtureAsyncBase
        {
            private IAccessTokenClientRepo _accessTokenClientRepo;
            private IApiClientAuthenticator _apiClientAuthenticator;
            private TokenController _controller;

            private ApiClient _suppliedClient;
            private IActionResult _actionResult;

            protected override Task ArrangeAsync()
            {
                _suppliedClient = new ApiClient {ApiClientId = 1};

                _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                var request = A.Fake<HttpRequest>();

                var headerDictionary = new HeaderDictionary {{"Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0"}};

                A.CallTo(() => request.Headers).Returns(headerDictionary);

                var httpContext = A.Fake<HttpContext>();
                A.CallTo(() => httpContext.Request).Returns(request);

                var controllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                };

                _controller.ControllerContext = controllerContext;

                _actionResult = await _controller.PostFromJsonAsync(
                    new TokenRequest
                    {
                        Client_id = "clientId",
                        Grant_type = "client_credentials"
                    });

            }

            [Test]
            public void Should_return_HTTP_status_of_BadRequest()
            {
                AssertHelper.All(
                    () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                    () => ((BadRequestObjectResult) _actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
            }

            [Test]
            public void Should_Not_call_try_authenticate_from_the_database_once()
            {
                A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                    .MustNotHaveHappened();
            }

            [Test]
            public void Should_not_use_AccessTokenClientRepo_to_create_token_using_the_supplied_ApiClientId()
            {
                A.CallTo(() => _accessTokenClientRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                    .MustNotHaveHappened();
            }
        }

        public class
            With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_secret_is_provided_in_the_body_as_well
            : TestFixtureAsyncBase
        {
            private IAccessTokenClientRepo _accessTokenClientRepo;
            private IApiClientAuthenticator _apiClientAuthenticator;
            private TokenController _controller;

            private IActionResult _actionResult;


            protected override Task ArrangeAsync()
            {
                _accessTokenClientRepo = Stub<IAccessTokenClientRepo>();

                _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                _controller = ControllerHelper.CreateTokenController( _apiClientAuthenticator, _accessTokenClientRepo);

                return Task.CompletedTask;
            }

            protected override async Task ActAsync()
            {
                _controller.ControllerContext = ControllerHelper.CreateControllerContext(
                    new HeaderDictionary {{"Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0"}});

                _actionResult = await _controller.PostFromJsonAsync(
                    new TokenRequest
                    {
                        Client_id = "clientId",
                        Client_secret = "clientSecret",
                        Grant_type = "client_credentials"
                    });
            }

            [Test]
            public void Should_return_HTTP_status_of_BadRequest()
            {
                _actionResult.ShouldBeOfType<BadRequestObjectResult>();
            }
        }
    }
}

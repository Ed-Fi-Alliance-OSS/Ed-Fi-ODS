// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.Models.Tokens;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.TestFixture;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Shouldly;
using Test.Common;

//ReSharper disable InconsistentNaming

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers
{
    [TestFixture]
    public class TokenControllerTests
    {
        private static TokenController CreateTokenController(ClientCredentialsTokenRequestProvider tokenRequestProvider)
        {
            var controller = new TokenController(tokenRequestProvider);
            var request = A.Fake<HttpRequest>();
            request.Method = "Post";
            request.Scheme = "http";

            A.CallTo(() => request.Host).Returns(new HostString("localhost", 80));

            request.PathBase = "/";
            request.RouteValues = new RouteValueDictionary { { "controller", "authorize" } };

            var httpContext = A.Fake<HttpContext>();
            A.CallTo(() => httpContext.Request).Returns(request);

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            var routeData = A.Fake<RouteData>();
            RouteValueDictionary dictionary = new RouteValueDictionary();
            dictionary.Add("controller", "authorize");

            controllerContext.RouteData = new RouteData(dictionary);
            controller.ControllerContext = controllerContext;

            return controller;
        }

        public class When_using_client_credentials_grant
        {
            public class With_valid_key_and_secret : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient { ApiClientId = 1 };

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _clientAppRepo = Stub<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                        .Returns(Task.FromResult(_suppliedClient));

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.Post(
                        new TokenRequest
                        {
                            Client_id = "clientId",
                            Client_secret = "clientSecret",
                            Grant_type = "client_credentials"
                        });

                    _tokenResponse = ((ObjectResult)_actionResult).Value as TokenResponse;
                }

                [Test]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                        () => ((OkObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                // TODO: ODS-4430 fix this test
                // [Test]
                // public void Should_include_CacheControl_and_Pragma_headers()
                // {
                //     Assert.That(
                //         _actualResponseMessage.Headers.CacheControl,
                //         Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));
                //
                //     Assert.That(
                //         _actualResponseMessage.Headers.Pragma,
                //         Is.EqualTo(
                //             new[]
                //             {
                //                  new NameValueHeaderValue("no-cache")
                //             }));
                // }

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
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_both_the_key_and_secret()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustHaveHappened();
                }
            }

            // TODO: ODS-4430 fix this test
            //public class With_valid_key_and_secret_provided_using_Basic_Authorization_header : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private ApiClient _suppliedClient;
            //    private Guid _suppliedAccessToken;

            //    private TimeSpan _suppliedTTL;
            //    private IActionResult _actionResult;
            //    protected override void Arrange()
            //    {
            //        _suppliedClient = new ApiClient
            //        {
            //            ApiClientId = 1

            //        };

            //        _suppliedAccessToken = Guid.NewGuid();
            //        _suppliedTTL = new TimeSpan(0, 10, 0);

            //        _clientAppRepo = Stub<IClientAppRepo>();

            //        //// Simulate a successful lookup of the client id/secret
            //        A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._)).Returns(_suppliedClient);

            //        _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

            //        var accessToken = new ClientAccessToken(_suppliedTTL);
            //        accessToken.ApiClient = _suppliedClient;
            //        accessToken.Id = _suppliedAccessToken;

            //        A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
            //            .Returns(accessToken);

            //        A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._)).Returns(new ApiClientAuthenticator.AuthenticationResult { IsAuthenticated = true, ApiClientIdentity = new ApiClientIdentity { Key = "clientId" } });
            //        var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();
            //        _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);
            //        _controller = CreateTokenController(_tokenRequestProvider);

            //    }

            //    protected override void Act()
            //    {
            //        var request = A.Fake<HttpRequest>();
            //        var headerDictionary = A.Fake<IHeaderDictionary>();
            //        HeaderDictionary dict = new HeaderDictionary();
            //        dict.Add("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        A.CallTo(() => request.Headers).Returns(dict);

            //        var httpContext = A.Fake<HttpContext>();
            //        A.CallTo(() => httpContext.Request).Returns(request);

            //        var controllerContext = new ControllerContext()
            //        {
            //            HttpContext = httpContext,
            //        };

            //        _controller.ControllerContext = controllerContext;

            //        _actionResult = _controller.Post(
            //                GetTokenRequest()).Result;
            //    }

            //    protected virtual TokenRequest GetTokenRequest() => new TokenRequest
            //    {
            //        Grant_type = "client_credentials"
            //    };

            //    [Assert]
            //    public void Should_return_HTTP_status_of_OK()
            //    {
            //        var result = (OkObjectResult)_actionResult;
            //        Assert.AreEqual(result.StatusCode, StatusCodes.Status200OK);
            //    }

            //    [Assert]
            //    public void Should_include_CacheControl_and_Pragma_headers()
            //    {
            //        //Assert.That(
            //        //    _actualResponseMessage.Headers.CacheControl,
            //        //    Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

            //        //Assert.That(
            //        //    _actualResponseMessage.Headers.Pragma,
            //        //    Is.EqualTo(
            //        //        new[]
            //        //        {
            //        //             new NameValueHeaderValue("no-cache")
            //        //        }));
            //    }

            //    [Assert]
            //    public void Should_include_the_generated_access_token_value_in_the_response()
            //    {
            //        var result = (OkObjectResult)_actionResult;
            //        var tokenResonse = (TokenResponse)result.Value;

            //        Assert.AreEqual(_suppliedAccessToken, Guid.Parse(tokenResonse.Access_token));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_is_a_bearer_token()
            //    {
            //        var result = (OkObjectResult)_actionResult;
            //        var tokenResonse = (TokenResponse)result.Value;

            //        Assert.AreEqual("bearer", tokenResonse.Token_type);
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_expires_in_10_minutes()
            //    {
            //        var tenMinutes = TimeSpan.FromMinutes(10);
            //        var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

            //        var result = (OkObjectResult)_actionResult;
            //        var tokenResonse = (TokenResponse)result.Value;
            //        var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(tokenResonse.Expires_in));

            //        Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
            //    {
            //        A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
            //    }

            //    [Assert]
            //    public void Should_call_try_authenticate_from_the_database_once()
            //    {
            //        A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret")).MustHaveHappenedOnceExactly();
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
            //    {
            //        A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null)).MustHaveHappened();
            //    }

            //}

            // TODO: ODS-4430 fix this test
            //public class With_an_empty_scope : With_valid_key_and_secret_provided_using_Basic_Authorization_header
            //{
            //    protected override TokenRequest GetTokenRequest() => new TokenRequest
            //    {
            //        Grant_type = "client_credentials",
            //        Scope = ""
            //    };
            //}

            // TODO: ODS-4430 fix this tests
            //public class With_a_scope_matching_an_associated_EdOrgId : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private ApiClient _suppliedClient;
            //    private Guid _suppliedAccessToken;
            //    private string _requestedScope;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _suppliedClient = new ApiClient
            //        {
            //            ApiClientId = 1,
            //            ApplicationEducationOrganizations = new List<ApplicationEducationOrganization>()
            //             {
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 997 },
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 998 },
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 999 },
            //             }
            //        };

            //        // Scope the request to the first associated EdOrg
            //        _requestedScope = _suppliedClient.ApplicationEducationOrganizations
            //            .Select(x => x.EducationOrganizationId)
            //            .First()
            //            .ToString();

            //        _suppliedAccessToken = Guid.NewGuid();

            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

            //        // Simulate a successful lookup of the client id/secret
            //        _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
            //            .Return(_suppliedClient);

            //        _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
            //            .Return(
            //                new ClientAccessToken(new TimeSpan(0, 10, 0))
            //                {
            //                    ApiClient = _suppliedClient,
            //                    Id = _suppliedAccessToken
            //                });

            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials",
            //                    Scope = _requestedScope
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_OK()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //    }

            //    [Assert]
            //    public void Should_include_CacheControl_and_Pragma_headers()
            //    {
            //        Assert.That(
            //            _actualResponseMessage.Headers.CacheControl,
            //            Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

            //        Assert.That(
            //            _actualResponseMessage.Headers.Pragma,
            //            Is.EqualTo(
            //                new[]
            //                {
            //                     new NameValueHeaderValue("no-cache")
            //                }));
            //    }

            //    [Assert]
            //    public void Should_include_the_generated_access_token_value_in_the_response()
            //    {
            //        Assert.That(
            //            _actualJsonContent["access_token"]
            //                .Value<string>(),
            //            Is.EqualTo(_suppliedAccessToken.ToString("N")));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_is_a_bearer_token()
            //    {
            //        Assert.That(
            //            _actualJsonContent["token_type"]
            //                .Value<string>(),
            //            Is.EqualTo("bearer"));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_expires_in_10_minutes()
            //    {
            //        var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

            //        var tenMinutes = TimeSpan.FromMinutes(10);
            //        var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

            //        Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
            //    }

            //    [Assert]
            //    public void Should_call_try_authenticate_from_the_database_once()
            //    {
            //        ApiClientIdentity apiClientIdentity;

            //        _apiClientAuthenticator.AssertWasCalled(
            //            x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
            //            x => x.Repeat.Once());
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId_and_scope()
            //    {
            //        _clientAppRepo.AssertWasCalled(x =>
            //            x.AddClientAccessToken(_suppliedClient.ApiClientId, _requestedScope));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_a_scope_not_matching_an_associated_EdOrgId : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private ApiClient _suppliedClient;
            //    private Guid _suppliedAccessToken;
            //    private string _requestedScope;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _suppliedClient = new ApiClient
            //        {
            //            ApiClientId = 1,
            //            ApplicationEducationOrganizations = new List<ApplicationEducationOrganization>()
            //             {
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 997 },
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 998 },
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 999 },
            //             }
            //        };

            //        // Scope the request to something not in list above
            //        _requestedScope = "1000";

            //        _suppliedAccessToken = Guid.NewGuid();

            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

            //        // Simulate a successful lookup of the client id/secret
            //        _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
            //            .Return(_suppliedClient);

            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials",
            //                    Scope = _requestedScope
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties().Count(),
            //            Is.EqualTo(2),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"].Value<string>(),
            //            Is.EqualTo("invalid_scope"));
            //    }

            //    [Assert]
            //    public void Should_return_an_error_body_indicating_the_client_is_not_explicitly_associated_with_EdOrg_specified_in_the_scope()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties().Count(),
            //            Is.EqualTo(2),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error_description"].Value<string>(),
            //            Is.EqualTo("The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'."));
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
            //    }

            //    [Assert]
            //    public void Should_call_try_authenticate_from_the_database_once()
            //    {
            //        ApiClientIdentity apiClientIdentity;

            //        _apiClientAuthenticator.AssertWasCalled(
            //            x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
            //            x => x.Repeat.Once());
            //    }

            //    [Assert]
            //    public void Should_NOT_use_ClientAppRepo_to_create_token()
            //    {
            //        _clientAppRepo.AssertWasNotCalled(x =>
            //            x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_a_scope_that_is_not_a_number : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private ApiClient _suppliedClient;
            //    private Guid _suppliedAccessToken;
            //    private string _requestedScope;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _suppliedClient = new ApiClient
            //        {
            //            ApiClientId = 1,
            //            ApplicationEducationOrganizations = new List<ApplicationEducationOrganization>()
            //             {
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 997 },
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 998 },
            //                 new ApplicationEducationOrganization { EducationOrganizationId = 999 },
            //             }
            //        };

            //        // Scope the request to something not in list above
            //        _requestedScope = "9a9";

            //        _suppliedAccessToken = Guid.NewGuid();

            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

            //        // Simulate a successful lookup of the client id/secret
            //        _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
            //            .Return(_suppliedClient);

            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials",
            //                    Scope = _requestedScope
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties().Count(),
            //            Is.EqualTo(2),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"].Value<string>(),
            //            Is.EqualTo("invalid_scope"));
            //    }

            //    [Assert]
            //    public void Should_return_an_error_body_indicating_the_client_is_not_explicitly_associated_with_EdOrg_specified_in_the_scope()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties().Count(),
            //            Is.EqualTo(2),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error_description"].Value<string>(),
            //            Is.EqualTo("The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client)."));
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
            //    }

            //    [Assert]
            //    public void Should_call_try_authenticate_from_the_database_once()
            //    {
            //        ApiClientIdentity apiClientIdentity;

            //        _apiClientAuthenticator.AssertWasCalled(
            //            x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
            //            x => x.Repeat.Once());
            //    }

            //    [Assert]
            //    public void Should_NOT_use_ClientAppRepo_to_create_token()
            //    {
            //        _clientAppRepo.AssertWasNotCalled(x =>
            //            x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_id_is_provided_in_the_body_as_well
            //    : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private ApiClient _suppliedClient;
            //    private Guid _suppliedAccessToken;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _suppliedClient = new ApiClient
            //        {
            //            ApiClientId = 1
            //        };

            //        _suppliedAccessToken = Guid.NewGuid();

            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

            //        // Simulate a successful lookup of the client id/secret
            //        _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
            //            .Return(_suppliedClient);

            //        _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
            //            .Return(
            //                new ClientAccessToken(new TimeSpan(0, 10, 0))
            //                {
            //                    ApiClient = _suppliedClient,
            //                    Id = _suppliedAccessToken
            //                });

            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "clientId",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_OK()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //    }

            //    [Assert]
            //    public void Should_include_CacheControl_and_Pragma_headers()
            //    {
            //        Assert.That(
            //            _actualResponseMessage.Headers.CacheControl,
            //            Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

            //        Assert.That(
            //            _actualResponseMessage.Headers.Pragma,
            //            Is.EqualTo(
            //                new[]
            //                {
            //                     new NameValueHeaderValue("no-cache")
            //                }));
            //    }

            //    [Assert]
            //    public void Should_include_the_generated_access_token_value_in_the_response()
            //    {
            //        Assert.That(
            //            _actualJsonContent["access_token"]
            //                .Value<string>(),
            //            Is.EqualTo(_suppliedAccessToken.ToString("N")));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_is_a_bearer_token()
            //    {
            //        Assert.That(
            //            _actualJsonContent["token_type"]
            //                .Value<string>(),
            //            Is.EqualTo("bearer"));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_expires_in_10_minutes()
            //    {
            //        var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

            //        var tenMinutes = TimeSpan.FromMinutes(10);
            //        var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

            //        Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
            //    }

            //    [Assert]
            //    public void Should_call_try_authenticate_from_the_database_once()
            //    {
            //        ApiClientIdentity apiClientIdentity;

            //        _apiClientAuthenticator.AssertWasCalled(
            //            x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
            //            x => x.Repeat.Once());
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.AddClientAccessToken(_suppliedClient.ApiClientId, null));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_secret_is_provided_in_the_body_as_well
            //    : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private ApiClient _suppliedClient;
            //    private Guid _suppliedAccessToken;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _suppliedClient = new ApiClient
            //        {
            //            ApiClientId = 1
            //        };

            //        _suppliedAccessToken = Guid.NewGuid();

            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

            //        // Simulate a successful lookup of the client id/secret
            //        _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
            //            .Return(_suppliedClient);

            //        _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
            //            .Return(
            //                new ClientAccessToken(new TimeSpan(0, 10, 0))
            //                {
            //                    ApiClient = _suppliedClient,
            //                    Id = _suppliedAccessToken
            //                });

            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_secret = "clientSecret",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_OK()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            //    }

            //    [Assert]
            //    public void Should_include_CacheControl_and_Pragma_headers()
            //    {
            //        Assert.That(
            //            _actualResponseMessage.Headers.CacheControl,
            //            Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

            //        Assert.That(
            //            _actualResponseMessage.Headers.Pragma,
            //            Is.EqualTo(
            //                new[]
            //                {
            //                     new NameValueHeaderValue("no-cache")
            //                }));
            //    }

            //    [Assert]
            //    public void Should_include_the_generated_access_token_value_in_the_response()
            //    {
            //        Assert.That(
            //            _actualJsonContent["access_token"]
            //                .Value<string>(),
            //            Is.EqualTo(_suppliedAccessToken.ToString("N")));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_is_a_bearer_token()
            //    {
            //        Assert.That(
            //            _actualJsonContent["token_type"]
            //                .Value<string>(),
            //            Is.EqualTo("bearer"));
            //    }

            //    [Assert]
            //    public void Should_indicate_the_access_token_expires_in_10_minutes()
            //    {
            //        var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

            //        var tenMinutes = TimeSpan.FromMinutes(10);
            //        var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

            //        Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
            //    }

            //    [Assert]
            //    public void Should_call_try_authenticate_from_the_database_once()
            //    {
            //        ApiClientIdentity apiClientIdentity;

            //        _apiClientAuthenticator.AssertWasCalled(
            //            x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
            //            x => x.Repeat.Once());
            //    }

            //    [Assert]
            //    public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
            //    {
            //        _clientAppRepo.AssertWasCalled(x => x.AddClientAccessToken(_suppliedClient.ApiClientId, null));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_an_invalid_client_Id_is_provided_in_the_body_as_well
            //    : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;
            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "invalidClientId",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_request"));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class
            //    With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_an_invalid_client_secret_is_provided_in_the_body_as_well
            //    : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;
            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_secret = "invalidClientSecret",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_request"));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class Using_digest_authorization : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("Digest", "some-value");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_Unauthorized()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            //    }

            //    [Assert]
            //    public void Should_include_WWW_Authenticate_header_with_schema_used_by_the_client()
            //    {
            //        Assert.That(
            //            _actualResponseMessage.Headers.WwwAuthenticate.First(),
            //            Is.EqualTo(new AuthenticationHeaderValue("Digest")));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class Using_basic_authorization_with_no_value : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("Basic"); // No value provided

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_request"));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class Using_basic_authorization_with_invalid_value : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("Basic", "Tm9Db2xvbkhlcmU="); // "NoColonHere"

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_request"));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class Using_basic_authorization_with_unencoded_value : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _controller.Request.Headers.Authorization
            //            = new AuthenticationHeaderValue("Basic", "ThisIsNotBase64Encoded");

            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_request"));
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_an_incorrect_client_id_and_secret : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.MockFalse(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "badClientId",
            //                    Client_secret = "badClientSecret",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    [Assert]
            //    public void Should_not_include_any_cache_headers()
            //    {
            //        Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
            //        Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_an_empty_secret : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "clientId",
            //                    Client_secret = string.Empty,
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    [Assert]
            //    public void Should_not_include_any_cache_headers()
            //    {
            //        Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
            //        Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_a_missing_secret : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "clientId",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    [Assert]
            //    public void Should_not_include_any_cache_headers()
            //    {
            //        Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
            //        Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}
        }

        public class When_using_client_credentials_grant_posting_via_form
        {
            public class With_No_Header_Request : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient { ApiClientId = 1 };

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _clientAppRepo = Stub<IClientAppRepo>();

                    //// Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                        .Returns(Task.FromResult(_suppliedClient));

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);

                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromForm(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials"
                        });
                }

                [Test]
                public void Should_return_HTTP_status_of_UnAuthorised()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<UnauthorizedResult>(),
                        () => ((UnauthorizedResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));

                }

                [Test]
                public void Should_Not_use_ClientAppRepo_to_obtain_the_ApiClient_using_both_the_key_and_secret()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustNotHaveHappened();
                }

                [Test]
                public void Should_Not_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustNotHaveHappened();
                }

                [Test]
                public void Should_not_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }

            public class With_Header_Invalid_Bearer_Token_Request : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient { ApiClientId = 1 };

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _clientAppRepo = Stub<IClientAppRepo>();

                    //// Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                        .Returns(Task.FromResult(_suppliedClient));

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);

                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV6");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromForm(
                        new TokenRequest
                        {

                        });
                }

                [Test]
                public void Should_return_HTTP_status_of_UnAuthorised()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));

                }

                [Test]
                public void Should_Not_use_ClientAppRepo_to_obtain_the_ApiClient_using_both_the_key_and_secret()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustNotHaveHappened();
                }

                [Test]
                public void Should_Not_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustNotHaveHappened();
                }

                [Test]
                public void Should_not_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustNotHaveHappened();
                }
            }

            public class With_valid_key_and_secret : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private TimeSpan _suppliedTTL;
                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient { ApiClientId = 1 };

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _clientAppRepo = Stub<IClientAppRepo>();

                    //// Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                        .Returns(Task.FromResult(_suppliedClient));

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    var accessToken = new ClientAccessToken(_suppliedTTL)
                    {
                        ApiClient = _suppliedClient,
                        Id = _suppliedAccessToken
                    };

                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                        .Returns(accessToken);

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);

                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromForm(
                        new TokenRequest
                        {
                            Grant_type = "client_credentials"
                        });

                    _tokenResponse = ((ObjectResult)_actionResult).Value as TokenResponse;
                }

                [Test]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                        () => ((OkObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                // TODO: ODS-4430 fix this test
                // [Test]
                // public void Should_include_CacheControl_and_Pragma_headers()
                // {
                //     Assert.That(
                //         _actualResponseMessage.Headers.CacheControl,
                //         Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));
                //
                //     Assert.That(
                //         _actualResponseMessage.Headers.Pragma,
                //         Is.EqualTo(
                //             new[]
                //             {
                //                  new NameValueHeaderValue("no-cache")
                //             }));
                // }

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
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_both_the_key_and_secret()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustHaveHappened();
                }
            }

            public class With_a_scope_matching_an_associated_EdOrgId : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;

                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1,
                        ApplicationEducationOrganizations = new List<ApplicationEducationOrganization>()
                         {
                             new ApplicationEducationOrganization { EducationOrganizationId = 997 },
                             new ApplicationEducationOrganization { EducationOrganizationId = 998 },
                             new ApplicationEducationOrganization { EducationOrganizationId = 999 },
                         }
                    };

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();
                    // Scope the request to the first associated EdOrg
                    _requestedScope = _suppliedClient.ApplicationEducationOrganizations
                        .Select(x => x.EducationOrganizationId)
                        .First()
                        .ToString();

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = Stub<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                        .Returns(Task.FromResult(_suppliedClient));

                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                       .Returns(new ClientAccessToken(new TimeSpan(0, 10, 0))
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
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);

                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;
                }

                protected override async Task ActAsync()
                {
                    _actionResult = await _controller.PostFromForm(
                           new TokenRequest
                           {
                               Grant_type = "client_credentials",
                           });

                    _tokenResponse = ((ObjectResult)_actionResult).Value as TokenResponse;
                }

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                       () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                       () => ((OkObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                //TODO ODS-4430
                [Assert]
                public void Should_include_CacheControl_and_Pragma_headers()
                {
                    //Assert.That(
                    //    _actualResponseMessage.Headers.CacheControl,
                    //    Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                    //Assert.That(
                    //    _actualResponseMessage.Headers.Pragma,
                    //    Is.EqualTo(
                    //        new[]
                    //        {
                    //             new NameValueHeaderValue("no-cache")
                    //        }));
                }

                [Assert]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Guid.Parse(_tokenResponse.Access_token).ShouldBe(_suppliedAccessToken);
                }

                [Assert]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    _tokenResponse.Token_type.ShouldBe("bearer");
                }

                [Assert]
                public void Should_indicate_the_access_token_expires_in_10_minutes()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_tokenResponse.Expires_in));

                    var tenMinutes = TimeSpan.FromMinutes(10);
                    var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

                    Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
                }

                [Test]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                        .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId_and_scope()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, _requestedScope))
                        .MustHaveHappened();
                }

            }

            public class With_a_scope_not_matching_an_associated_EdOrgId : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;

                private JObject _actualJsonContent;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1,
                        ApplicationEducationOrganizations = new List<ApplicationEducationOrganization>()
                         {
                             new ApplicationEducationOrganization { EducationOrganizationId = 997 },
                             new ApplicationEducationOrganization { EducationOrganizationId = 998 },
                             new ApplicationEducationOrganization { EducationOrganizationId = 999 },
                         }
                    };

                    // Scope the request to something not in list above
                    _requestedScope = "1000";

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = Stub<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                       .Returns(Task.FromResult(_suppliedClient));

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                             .Returns(
                                 Task.FromResult(
                                     new ApiClientAuthenticator.AuthenticationResult
                                     {
                                         IsAuthenticated = true,
                                         ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                     }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                      new TokenRequest
                      {
                          Grant_type = "client_credentials",
                          Scope = _requestedScope
                      });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;

                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                       () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                       () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Assert]
                public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
                {
                    AssertHelper.All(
                        () => _tokenError.Error.Equals("invalid_scope"),
                        () => _tokenError.Error_description.Equals("The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'."));
                }

                [Test]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                       .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_NOT_use_ClientAppRepo_to_create_token()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                                          .MustNotHaveHappened();
                }

            }

            public class With_a_scope_that_is_not_a_number : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;

                private IActionResult _actionResult;
                private TokenError _tokenError;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1,
                        ApplicationEducationOrganizations = new List<ApplicationEducationOrganization>()
                         {
                             new ApplicationEducationOrganization { EducationOrganizationId = 997 },
                             new ApplicationEducationOrganization { EducationOrganizationId = 998 },
                             new ApplicationEducationOrganization { EducationOrganizationId = 999 },
                         }
                    };

                    // Scope the request to something not in list above
                    _requestedScope = "9a9";

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = Stub<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                            .Returns(Task.FromResult(_suppliedClient));

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                       .Returns(
                           Task.FromResult(
                               new ApiClientAuthenticator.AuthenticationResult
                               {
                                   IsAuthenticated = true,
                                   ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                               }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                       new TokenRequest
                       {
                           Grant_type = "client_credentials",
                           Scope = _requestedScope
                       });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                       () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                       () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Test]
                public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
                {
                    AssertHelper.All(
                                         () => _tokenError.Error.Equals("invalid_scope"),
                                         () => _tokenError.Error_description.Equals("The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client)."));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                              .MustHaveHappenedOnceExactly();
                }

                [Assert]
                public void Should_NOT_use_ClientAppRepo_to_create_token()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                             .MustNotHaveHappened();
                }

            }

            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_id_is_provided_in_the_body_as_well
                : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;
                private JObject _actualJsonContent;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1
                    };

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = Stub<IClientAppRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    // Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                       .Returns(Task.FromResult(_suppliedClient));


                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                       .Returns(new ClientAccessToken(new TimeSpan(0, 10, 0))
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
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                                           new TokenRequest
                                           {
                                               Client_id = "clientId",
                                               Grant_type = "client_credentials"
                                           });

                    _tokenResponse = ((ObjectResult)_actionResult).Value as TokenResponse;
                }

                [Test]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                        () => ((OkObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                //TODO  To be covered by ODS-4430
                //[Assert]
                //public void Should_include_CacheControl_and_Pragma_headers()
                //{
                //    Assert.That(
                //        _actualResponseMessage.Headers.CacheControl,
                //        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                //    Assert.That(
                //        _actualResponseMessage.Headers.Pragma,
                //        Is.EqualTo(
                //            new[]
                //            {
                //                 new NameValueHeaderValue("no-cache")
                //            }));
                //}

                [Test]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Guid.Parse(_tokenResponse.Access_token).ShouldBe(_suppliedAccessToken);
                }

                [Assert]
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
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                       .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustHaveHappened();
                }

            }

            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_secret_is_provided_in_the_body_as_well
                : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private IActionResult _actionResult;
                private TokenResponse _tokenResponse;
                private JObject _actualJsonContent;

                protected override async Task ArrangeAsync()
                {
                    _suppliedClient = new ApiClient
                    {
                        ApiClientId = 1
                    };

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = Stub<IClientAppRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    // Simulate a successful lookup of the client id/secret
                    A.CallTo(() => _clientAppRepo.GetClientAsync(A<string>._))
                        .Returns(Task.FromResult(_suppliedClient));

                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(A<int>._, A<string>._))
                          .Returns(new ClientAccessToken(new TimeSpan(0, 10, 0))
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
                                   ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                               }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                        new TokenRequest
                        {
                            Client_secret = "clientSecret",
                            Grant_type = "client_credentials"
                        });

                    _tokenResponse = ((ObjectResult)_actionResult).Value as TokenResponse;
                }

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    AssertHelper.All(
                         () => _actionResult.ShouldBeOfType<OkObjectResult>(),
                         () => ((OkObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status200OK));
                }

                //TODO ODS-4430
                //[Assert]
                //public void Should_include_CacheControl_and_Pragma_headers()
                //{
                //    Assert.That(
                //        _actualResponseMessage.Headers.CacheControl,
                //        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                //    Assert.That(
                //        _actualResponseMessage.Headers.Pragma,
                //        Is.EqualTo(
                //            new[]
                //            {
                //                 new NameValueHeaderValue("no-cache")
                //            }));
                //}

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
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    A.CallTo(() => _clientAppRepo.GetClientAsync("clientId")).MustHaveHappened();
                }

                [Test]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync("clientId", "clientSecret"))
                       .MustHaveHappenedOnceExactly();
                }

                [Test]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    A.CallTo(() => _clientAppRepo.AddClientAccessTokenAsync(_suppliedClient.ApiClientId, null))
                        .MustHaveHappened();
                }

            }

            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_an_invalid_client_Id_is_provided_in_the_body_as_well
                : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;
                private IActionResult _actionResult;
                private TokenError _tokenError;
                
                protected override async Task ArrangeAsync()
                {
                    _clientAppRepo = Stub<IClientAppRepo>();

                    _apiClientAuthenticator = A.Fake<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                       .Returns(
                           Task.FromResult(
                               new ApiClientAuthenticator.AuthenticationResult
                               {
                                   IsAuthenticated = true,
                                   ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                               }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                        new TokenRequest
                        {
                            Client_id = "invalidClientId",
                            Grant_type = "client_credentials"
                        });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                        () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                        () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    AssertHelper.All(
                        () => _tokenError.Error.ShouldBe("invalid_request"));
                }

            }

            public class
                With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_an_invalid_client_secret_is_provided_in_the_body_as_well
                : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;
                private IActionResult _actionResult;
                private TokenError _tokenError;
                protected override async Task ArrangeAsync()
                {
                    _clientAppRepo = Stub<IClientAppRepo>();
                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                       .Returns(
                           Task.FromResult(
                               new ApiClientAuthenticator.AuthenticationResult
                               {
                                   IsAuthenticated = true,
                                   ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                               }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                       new TokenRequest
                       {
                           Client_secret = "invalidClientSecret",
                           Grant_type = "client_credentials"
                       });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                       () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                       () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    AssertHelper.All(
                            () => _tokenError.Error.ShouldBe("invalid_request"));
                }

            }

            public class Using_digest_authorization : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;
                
                protected override async Task ArrangeAsync()
                {
                    _clientAppRepo = Stub<IClientAppRepo>();
                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();
                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                        .Returns(
                            Task.FromResult(
                                new ApiClientAuthenticator.AuthenticationResult
                                {
                                    IsAuthenticated = true,
                                    ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                                }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Digest some-value");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                      new TokenRequest
                      {
                          Grant_type = "client_credentials"
                      });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Assert]
                public void Should_return_HTTP_status_of_Unauthorized()
                {
                    AssertHelper.All(
                         () => _actionResult.ShouldBeOfType<UnauthorizedResult>(),
                         () => ((UnauthorizedResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status401Unauthorized));
                }

                //TODO ODS-4430
                //[Assert]
                //public void Should_include_WWW_Authenticate_header_with_schema_used_by_the_client()
                //{
                //    Assert.That(
                //        _actualResponseMessage.Headers.WwwAuthenticate.First(),
                //        Is.EqualTo(new AuthenticationHeaderValue("Digest")));
                //}

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    AssertHelper.All(
                       () => _tokenError.Error.Equals("invalid_client"));
                }
            }

            public class Using_basic_authorization_with_no_value : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private IActionResult _actionResult;
                private TokenError _tokenError;
                
                protected override async Task ArrangeAsync()
                {
                    _clientAppRepo = Stub<IClientAppRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                       .Returns(
                           Task.FromResult(
                               new ApiClientAuthenticator.AuthenticationResult
                               {
                                   IsAuthenticated = true,
                                   ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                               }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic ");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                      new TokenRequest
                      {
                          Grant_type = "client_credentials"
                      });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                           () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                           () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    AssertHelper.All(
                         () => _tokenError.Error.Equals("invalid_request"));
                }
            }

            public class Using_basic_authorization_with_invalid_value : TestFixtureAsyncBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;
                private IActionResult _actionResult;
                private TokenError _tokenError;
                
                protected override async Task ArrangeAsync()
                {
                    _clientAppRepo = Stub<IClientAppRepo>();

                    _apiClientAuthenticator = Stub<IApiClientAuthenticator>();

                    A.CallTo(() => _apiClientAuthenticator.TryAuthenticateAsync(A<string>._, A<string>._))
                       .Returns(
                           Task.FromResult(
                               new ApiClientAuthenticator.AuthenticationResult
                               {
                                   IsAuthenticated = true,
                                   ApiClientIdentity = new ApiClientIdentity { Key = "clientId" }
                               }));

                    var _tokenRequestProvider = Stub<ClientCredentialsTokenRequestProvider>();

                    _tokenRequestProvider = new ClientCredentialsTokenRequestProvider(_clientAppRepo, _apiClientAuthenticator);

                    _controller = CreateTokenController(_tokenRequestProvider);
                }

                protected override async Task ActAsync()
                {
                    var request = A.Fake<HttpRequest>();
                    var headerDictionary = A.Fake<IHeaderDictionary>();
                    HeaderDictionary dict = new HeaderDictionary();
                    dict.Add("Authorization", "Basic Tm9Db2xvbkhlcmU=");

                    A.CallTo(() => request.Headers).Returns(dict);

                    var httpContext = A.Fake<HttpContext>();
                    A.CallTo(() => httpContext.Request).Returns(request);

                    var controllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext,
                    };

                    _controller.ControllerContext = controllerContext;

                    _actionResult = await _controller.PostFromForm(
                      new TokenRequest
                      {
                          Grant_type = "client_credentials"
                      });

                    _tokenError = ((ObjectResult)_actionResult).Value as TokenError;
                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    AssertHelper.All(
                            () => _actionResult.ShouldBeOfType<BadRequestObjectResult>(),
                            () => ((BadRequestObjectResult)_actionResult).StatusCode.ShouldBe(StatusCodes.Status400BadRequest));
                }

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    AssertHelper.All(
                        () => _tokenError.Error.Equals("invalid_request"));
                }
            }

            public class Using_basic_authorization_with_unencoded_value : TestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
                {
                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("Basic", "ThisIsNotBase64Encoded");

                    _actualResponseMessage = _controller.Post(
                            new TokenRequest
                            {
                                Grant_type = "client_credentials"
                            })
                        .ExecuteAsync(new CancellationToken())
                        .Result;

                    string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
                        .Result;

                    _actualJsonContent = JObject.Parse(actualContent);
                }

                [Assert]
                public void Should_return_HTTP_status_of_BadRequest()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                }

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_request()
                {
                    Assert.That(
                        _actualJsonContent.Properties()
                            .Count(),
                        Is.EqualTo(1),
                        _actualJsonContent.ToString());

                    Assert.That(
                        _actualJsonContent["error"]
                            .Value<string>(),
                        Is.EqualTo("invalid_request"));
                }

            }

            // TODO: ODS-4430 fix this test
            //public class With_an_incorrect_client_id_and_secret : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.MockFalse(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "badClientId",
            //                    Client_secret = "badClientSecret",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    [Assert]
            //    public void Should_not_include_any_cache_headers()
            //    {
            //        Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
            //        Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //        _apiClientAuthenticator.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_an_empty_secret : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "clientId",
            //                    Client_secret = string.Empty,
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    [Assert]
            //    public void Should_not_include_any_cache_headers()
            //    {
            //        Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
            //        Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}

            // TODO: ODS-4430 fix this test
            //public class With_a_missing_secret : TestFixtureBase
            //{
            //    private IClientAppRepo _clientAppRepo;
            //    private IApiClientAuthenticator _apiClientAuthenticator;
            //    private TokenController _controller;

            //    private HttpResponseMessage _actualResponseMessage;
            //    private JObject _actualJsonContent;

            //    protected override void Arrange()
            //    {
            //        _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
            //        _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

            //        _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
            //    }

            //    protected override void Act()
            //    {
            //        _actualResponseMessage = _controller.Post(
            //                new TokenRequest
            //                {
            //                    Client_id = "clientId",
            //                    Grant_type = "client_credentials"
            //                })
            //            .ExecuteAsync(new CancellationToken())
            //            .Result;

            //        string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
            //            .Result;

            //        _actualJsonContent = JObject.Parse(actualContent);
            //    }

            //    [Assert]
            //    public void Should_return_HTTP_status_of_BadRequest()
            //    {
            //        Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            //    }

            //    [Assert]
            //    public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
            //    {
            //        Assert.That(
            //            _actualJsonContent.Properties()
            //                .Count(),
            //            Is.EqualTo(1),
            //            _actualJsonContent.ToString());

            //        Assert.That(
            //            _actualJsonContent["error"]
            //                .Value<string>(),
            //            Is.EqualTo("invalid_client"));
            //    }

            //    [Assert]
            //    public void Should_not_include_any_cache_headers()
            //    {
            //        Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
            //        Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
            //    }

            //    public override void RunOnceAfterAll()
            //    {
            //        _clientAppRepo.VerifyAllExpectations();
            //    }
            //}
        }
    }
}
#endif

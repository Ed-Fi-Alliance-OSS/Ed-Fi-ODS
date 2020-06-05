// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using EdFi.Admin.DataAccess.Models;
using EdFi.Ods.Sandbox.Repositories;
using EdFi.Ods.Api.Common.Models.Tokens;
using EdFi.Ods.Api.Services;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Authentication.ClientCredentials;
using EdFi.Ods.Api.Services.Controllers;
using EdFi.Ods.Common.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

// ReSharper disable InconsistentNaming

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Services.Controllers
{
    public class When_calling_the_token_controller
    {
        private static readonly ApiClientAuthenticatorHelper _apiClientAuthenticatorHelper = new ApiClientAuthenticatorHelper();

        private static TokenController CreateTokenController(
            IClientAppRepo clientAppRepo,
            IApiClientAuthenticator apiClientAuthenticator,
            HttpMethod method = null)
        {
            var handlers = new ITokenRequestHandler[]
                           {
                               new ClientCredentialsTokenRequestHandler(clientAppRepo, apiClientAuthenticator)
                           };

            var controller = new TokenController(handlers.First());

            var config = new HttpConfiguration();

            // configure JSON serialization
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.RequiredMemberSelector = new NoRequiredMemberSelector();

            var request = new HttpRequestMessage(method ?? HttpMethod.Post, "http://localhost/api/token");
            var route = config.Routes.MapHttpRoute("default", "api/{controller}/{id}");

            var routeData = new HttpRouteData(
                route,
                new HttpRouteValueDictionary
                {
                    {
                        "controller", "authorize"
                    }
                });

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            return controller;
        }

        public class Using_client_credentials_grant
        {
            [TestFixture]
            public class With_valid_key_and_secret : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;
                private TimeSpan _suppliedTTL;

                protected override void Arrange()
                {
                    _suppliedClient = new ApiClient
                                      {
                                          ApiClientId = 1
                                      };

                    _suppliedAccessToken = Guid.NewGuid();
                    _suppliedTTL = TimeSpan.FromMinutes(30);

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                                  .Return(
                                       new ClientAccessToken(_suppliedTTL)
                                       {
                                           ApiClient = _suppliedClient, Id = _suppliedAccessToken
                                       });

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);

                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_id = "clientId", Client_secret = "clientSecret",
                                                                 Grant_type = "client_credentials"
                                                             })
                                                        .ExecuteAsync(new CancellationToken())
                                                        .Result;

                    string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
                                                                 .Result;

                    _actualJsonContent = JObject.Parse(actualContent);
                }

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }

                [Assert]
                public void Should_include_CacheControl_and_Pragma_headers()
                {
                    Assert.That(
                        _actualResponseMessage.Headers.CacheControl,
                        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                    Assert.That(
                        _actualResponseMessage.Headers.Pragma,
                        Is.EqualTo(
                            new[]
                            {
                                new NameValueHeaderValue("no-cache")
                            }));
                }

                [Assert]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Assert.That(
                        _actualJsonContent["access_token"]
                           .Value<string>(),
                        Is.EqualTo(_suppliedAccessToken.ToString("N")));
                }

                [Assert]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    Assert.That(
                        _actualJsonContent["token_type"]
                           .Value<string>(),
                        Is.EqualTo("bearer"));
                }

                [Assert]
                public void Should_indicate_the_access_token_expires_within_1_second_of_the_supplied_expiration_time()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

                    var expectedBegin = _suppliedTTL.Add(TimeSpan.FromSeconds(-1));
                    var expectedEnd = _suppliedTTL;

                    Assert.That(actualTTL, Is.InRange(expectedBegin, expectedEnd));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_both_the_key_and_secret()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    _clientAppRepo.AssertWasCalled(x => x.AddClientAccessToken(_suppliedClient.ApiClientId, null));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
                {
                    _suppliedClient = new ApiClient
                                      {
                                          ApiClientId = 1
                                      };

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                                  .Return(
                                       new ClientAccessToken(new TimeSpan(0, 10, 0))
                                       {
                                           ApiClient = _suppliedClient, Id = _suppliedAccessToken
                                       });

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             GetTokenRequest())
                                                        .ExecuteAsync(new CancellationToken())
                                                        .Result;

                    string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
                                                                 .Result;

                    _actualJsonContent = JObject.Parse(actualContent);
                }

                protected virtual TokenRequest GetTokenRequest() => new TokenRequest
                {
                    Grant_type = "client_credentials"
                };

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }

                [Assert]
                public void Should_include_CacheControl_and_Pragma_headers()
                {
                    Assert.That(
                        _actualResponseMessage.Headers.CacheControl,
                        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                    Assert.That(
                        _actualResponseMessage.Headers.Pragma,
                        Is.EqualTo(
                            new[]
                            {
                                new NameValueHeaderValue("no-cache")
                            }));
                }

                [Assert]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Assert.That(
                        _actualJsonContent["access_token"]
                           .Value<string>(),
                        Is.EqualTo(_suppliedAccessToken.ToString("N")));
                }

                [Assert]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    Assert.That(
                        _actualJsonContent["token_type"]
                           .Value<string>(),
                        Is.EqualTo("bearer"));
                }

                [Assert]
                public void Should_indicate_the_access_token_expires_in_10_minutes()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

                    var tenMinutes = TimeSpan.FromMinutes(10);
                    var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

                    Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    _clientAppRepo.AssertWasCalled(x => x.AddClientAccessToken(_suppliedClient.ApiClientId, null));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_an_empty_scope : With_valid_key_and_secret_provided_using_Basic_Authorization_header
            {
                protected override TokenRequest GetTokenRequest() => new TokenRequest
                {
                    Grant_type = "client_credentials",
                    Scope = ""
                };
            }

            [TestFixture]
            public class With_a_scope_matching_an_associated_EdOrgId : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;
                
                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
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

                    // Scope the request to the first associated EdOrg
                    _requestedScope = _suppliedClient.ApplicationEducationOrganizations
                        .Select(x => x.EducationOrganizationId)
                        .First()
                        .ToString();
                    
                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                                  .Return(
                                       new ClientAccessToken(new TimeSpan(0, 10, 0))
                                       {
                                           ApiClient = _suppliedClient, 
                                           Id = _suppliedAccessToken
                                       });

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Grant_type = "client_credentials",
                                                                 Scope = _requestedScope
                                                             })
                                                        .ExecuteAsync(new CancellationToken())
                                                        .Result;

                    string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
                                                                 .Result;

                    _actualJsonContent = JObject.Parse(actualContent);
                }

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }

                [Assert]
                public void Should_include_CacheControl_and_Pragma_headers()
                {
                    Assert.That(
                        _actualResponseMessage.Headers.CacheControl,
                        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                    Assert.That(
                        _actualResponseMessage.Headers.Pragma,
                        Is.EqualTo(
                            new[]
                            {
                                new NameValueHeaderValue("no-cache")
                            }));
                }

                [Assert]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Assert.That(
                        _actualJsonContent["access_token"]
                           .Value<string>(),
                        Is.EqualTo(_suppliedAccessToken.ToString("N")));
                }

                [Assert]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    Assert.That(
                        _actualJsonContent["token_type"]
                           .Value<string>(),
                        Is.EqualTo("bearer"));
                }

                [Assert]
                public void Should_indicate_the_access_token_expires_in_10_minutes()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

                    var tenMinutes = TimeSpan.FromMinutes(10);
                    var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

                    Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId_and_scope()
                {
                    _clientAppRepo.AssertWasCalled(x =>
                            x.AddClientAccessToken(_suppliedClient.ApiClientId, _requestedScope));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }
            
            [TestFixture]
            public class With_a_scope_not_matching_an_associated_EdOrgId : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;
                
                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
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

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Grant_type = "client_credentials",
                                                                 Scope = _requestedScope
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
                public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
                {
                    Assert.That(
                        _actualJsonContent.Properties().Count(),
                        Is.EqualTo(2), 
                        _actualJsonContent.ToString());

                    Assert.That( 
                        _actualJsonContent["error"].Value<string>(), 
                        Is.EqualTo("invalid_scope"));
                }

                [Assert]
                public void Should_return_an_error_body_indicating_the_client_is_not_explicitly_associated_with_EdOrg_specified_in_the_scope()
                {
                    Assert.That(
                        _actualJsonContent.Properties().Count(),
                        Is.EqualTo(2), 
                        _actualJsonContent.ToString());

                    Assert.That( 
                        _actualJsonContent["error_description"].Value<string>(), 
                        Is.EqualTo("The client is not explicitly associated with the EducationOrganizationId specified in the requested 'scope'."));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_NOT_use_ClientAppRepo_to_create_token()
                {
                    _clientAppRepo.AssertWasNotCalled(x =>
                            x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_a_scope_that_is_not_a_number : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;
                private string _requestedScope;
                
                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
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

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Grant_type = "client_credentials",
                                                                 Scope = _requestedScope
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
                public void Should_return_an_error_body_indicating_an_invalid_scope_was_supplied()
                {
                    Assert.That(
                        _actualJsonContent.Properties().Count(),
                        Is.EqualTo(2), 
                        _actualJsonContent.ToString());

                    Assert.That( 
                        _actualJsonContent["error"].Value<string>(), 
                        Is.EqualTo("invalid_scope"));
                }

                [Assert]
                public void Should_return_an_error_body_indicating_the_client_is_not_explicitly_associated_with_EdOrg_specified_in_the_scope()
                {
                    Assert.That(
                        _actualJsonContent.Properties().Count(),
                        Is.EqualTo(2), 
                        _actualJsonContent.ToString());

                    Assert.That( 
                        _actualJsonContent["error_description"].Value<string>(), 
                        Is.EqualTo("The supplied 'scope' was not a number (it should be an EducationOrganizationId that is explicitly associated with the client)."));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_NOT_use_ClientAppRepo_to_create_token()
                {
                    _clientAppRepo.AssertWasNotCalled(x =>
                            x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_id_is_provided_in_the_body_as_well
                : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
                {
                    _suppliedClient = new ApiClient
                                      {
                                          ApiClientId = 1
                                      };

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                                  .Return(
                                       new ClientAccessToken(new TimeSpan(0, 10, 0))
                                       {
                                           ApiClient = _suppliedClient, Id = _suppliedAccessToken
                                       });

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_id = "clientId", Grant_type = "client_credentials"
                                                             })
                                                        .ExecuteAsync(new CancellationToken())
                                                        .Result;

                    string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
                                                                 .Result;

                    _actualJsonContent = JObject.Parse(actualContent);
                }

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }

                [Assert]
                public void Should_include_CacheControl_and_Pragma_headers()
                {
                    Assert.That(
                        _actualResponseMessage.Headers.CacheControl,
                        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                    Assert.That(
                        _actualResponseMessage.Headers.Pragma,
                        Is.EqualTo(
                            new[]
                            {
                                new NameValueHeaderValue("no-cache")
                            }));
                }

                [Assert]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Assert.That(
                        _actualJsonContent["access_token"]
                           .Value<string>(),
                        Is.EqualTo(_suppliedAccessToken.ToString("N")));
                }

                [Assert]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    Assert.That(
                        _actualJsonContent["token_type"]
                           .Value<string>(),
                        Is.EqualTo("bearer"));
                }

                [Assert]
                public void Should_indicate_the_access_token_expires_in_10_minutes()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

                    var tenMinutes = TimeSpan.FromMinutes(10);
                    var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

                    Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    _clientAppRepo.AssertWasCalled(x => x.AddClientAccessToken(_suppliedClient.ApiClientId, null));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_the_client_secret_is_provided_in_the_body_as_well
                : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private ApiClient _suppliedClient;
                private Guid _suppliedAccessToken;

                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
                {
                    _suppliedClient = new ApiClient
                                      {
                                          ApiClientId = 1
                                      };

                    _suppliedAccessToken = Guid.NewGuid();

                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();

                    // Simulate a successful lookup of the client id/secret
                    _clientAppRepo.Expect(x => x.GetClient(Arg<string>.Is.Anything))
                                  .Return(_suppliedClient);

                    _clientAppRepo.Expect(x => x.AddClientAccessToken(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                                  .Return(
                                       new ClientAccessToken(new TimeSpan(0, 10, 0))
                                       {
                                           ApiClient = _suppliedClient, Id = _suppliedAccessToken
                                       });

                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_secret = "clientSecret", Grant_type = "client_credentials"
                                                             })
                                                        .ExecuteAsync(new CancellationToken())
                                                        .Result;

                    string actualContent = _actualResponseMessage.Content.ReadAsStringAsync()
                                                                 .Result;

                    _actualJsonContent = JObject.Parse(actualContent);
                }

                [Assert]
                public void Should_return_HTTP_status_of_OK()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                }

                [Assert]
                public void Should_include_CacheControl_and_Pragma_headers()
                {
                    Assert.That(
                        _actualResponseMessage.Headers.CacheControl,
                        Is.EqualTo(CacheControlHeaderValue.Parse("no-store")));

                    Assert.That(
                        _actualResponseMessage.Headers.Pragma,
                        Is.EqualTo(
                            new[]
                            {
                                new NameValueHeaderValue("no-cache")
                            }));
                }

                [Assert]
                public void Should_include_the_generated_access_token_value_in_the_response()
                {
                    Assert.That(
                        _actualJsonContent["access_token"]
                           .Value<string>(),
                        Is.EqualTo(_suppliedAccessToken.ToString("N")));
                }

                [Assert]
                public void Should_indicate_the_access_token_is_a_bearer_token()
                {
                    Assert.That(
                        _actualJsonContent["token_type"]
                           .Value<string>(),
                        Is.EqualTo("bearer"));
                }

                [Assert]
                public void Should_indicate_the_access_token_expires_in_10_minutes()
                {
                    var actualTTL = TimeSpan.FromSeconds(Convert.ToDouble(_actualJsonContent["expires_in"]));

                    var tenMinutes = TimeSpan.FromMinutes(10);
                    var tenMinutesMinus1Second = tenMinutes.Add(TimeSpan.FromSeconds(-1));

                    Assert.That(actualTTL, Is.InRange(tenMinutesMinus1Second, tenMinutes));
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_obtain_the_ApiClient_using_the_key()
                {
                    _clientAppRepo.AssertWasCalled(x => x.GetClient("clientId"));
                }

                [Assert]
                public void Should_call_try_authenticate_from_the_database_once()
                {
                    ApiClientIdentity apiClientIdentity;

                    _apiClientAuthenticator.AssertWasCalled(
                        x => x.TryAuthenticate("clientId", "clientSecret", out apiClientIdentity),
                        x => x.Repeat.Once());
                }

                [Assert]
                public void Should_use_ClientAppRepo_to_create_token_using_the_supplied_ApiClientId()
                {
                    _clientAppRepo.AssertWasCalled(x => x.AddClientAccessToken(_suppliedClient.ApiClientId, null));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_an_invalid_client_Id_is_provided_in_the_body_as_well
                : LegacyTestFixtureBase
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
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_id = "invalidClientId", Grant_type = "client_credentials"
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

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class
                With_valid_key_and_secret_provided_using_Basic_Authorization_header_and_an_invalid_client_secret_is_provided_in_the_body_as_well
                : LegacyTestFixtureBase
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
                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.Mock(mocks);
                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _controller.Request.Headers.Authorization
                        = new AuthenticationHeaderValue("basic", "Y2xpZW50SWQ6Y2xpZW50U2VjcmV0");

                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_secret = "invalidClientSecret", Grant_type = "client_credentials"
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

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class Using_digest_authorization : LegacyTestFixtureBase
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
                        = new AuthenticationHeaderValue("Digest", "some-value");

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
                public void Should_return_HTTP_status_of_Unauthorized()
                {
                    Assert.That(_actualResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                }

                [Assert]
                public void Should_include_WWW_Authenticate_header_with_schema_used_by_the_client()
                {
                    Assert.That(
                        _actualResponseMessage.Headers.WwwAuthenticate.First(),
                        Is.EqualTo(new AuthenticationHeaderValue("Digest")));
                }

                [Assert]
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    Assert.That(
                        _actualJsonContent.Properties()
                                          .Count(),
                        Is.EqualTo(1),
                        _actualJsonContent.ToString());

                    Assert.That(
                        _actualJsonContent["error"]
                           .Value<string>(),
                        Is.EqualTo("invalid_client"));
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class Using_basic_authorization_with_no_value : LegacyTestFixtureBase
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
                        = new AuthenticationHeaderValue("Basic"); // No value provided

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

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class Using_basic_authorization_with_invalid_value : LegacyTestFixtureBase
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
                        = new AuthenticationHeaderValue("Basic", "Tm9Db2xvbkhlcmU="); // "NoColonHere"

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

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class Using_basic_authorization_with_unencoded_value : LegacyTestFixtureBase
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

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_an_incorrect_client_id_and_secret : LegacyTestFixtureBase
            {
                private IClientAppRepo _clientAppRepo;
                private IApiClientAuthenticator _apiClientAuthenticator;
                private TokenController _controller;

                private HttpResponseMessage _actualResponseMessage;
                private JObject _actualJsonContent;

                protected override void Arrange()
                {
                    _clientAppRepo = mocks.StrictMock<IClientAppRepo>();
                    _apiClientAuthenticator = _apiClientAuthenticatorHelper.MockFalse(mocks);

                    _controller = CreateTokenController(_clientAppRepo, _apiClientAuthenticator);
                }

                protected override void Act()
                {
                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_id = "badClientId", Client_secret = "badClientSecret",
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
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    Assert.That(
                        _actualJsonContent.Properties()
                                          .Count(),
                        Is.EqualTo(1),
                        _actualJsonContent.ToString());

                    Assert.That(
                        _actualJsonContent["error"]
                           .Value<string>(),
                        Is.EqualTo("invalid_client"));
                }

                [Assert]
                public void Should_not_include_any_cache_headers()
                {
                    Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
                    Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                    _apiClientAuthenticator.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_an_empty_secret : LegacyTestFixtureBase
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
                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_id = "clientId", Client_secret = string.Empty,
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
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    Assert.That(
                        _actualJsonContent.Properties()
                                          .Count(),
                        Is.EqualTo(1),
                        _actualJsonContent.ToString());

                    Assert.That(
                        _actualJsonContent["error"]
                           .Value<string>(),
                        Is.EqualTo("invalid_client"));
                }

                [Assert]
                public void Should_not_include_any_cache_headers()
                {
                    Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
                    Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }

            [TestFixture]
            public class With_a_missing_secret : LegacyTestFixtureBase
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
                    _actualResponseMessage = _controller.Post(
                                                             new TokenRequest
                                                             {
                                                                 Client_id = "clientId", Grant_type = "client_credentials"
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
                public void Should_return_a_single_valued_response_with_an_error_indicating_invalid_client()
                {
                    Assert.That(
                        _actualJsonContent.Properties()
                                          .Count(),
                        Is.EqualTo(1),
                        _actualJsonContent.ToString());

                    Assert.That(
                        _actualJsonContent["error"]
                           .Value<string>(),
                        Is.EqualTo("invalid_client"));
                }

                [Assert]
                public void Should_not_include_any_cache_headers()
                {
                    Assert.That(_actualResponseMessage.Headers.CacheControl, Is.Null);
                    Assert.That(_actualResponseMessage.Headers.Pragma, Is.Empty);
                }

                public override void RunOnceAfterAll()
                {
                    _clientAppRepo.VerifyAllExpectations();
                }
            }
        }
    }
}

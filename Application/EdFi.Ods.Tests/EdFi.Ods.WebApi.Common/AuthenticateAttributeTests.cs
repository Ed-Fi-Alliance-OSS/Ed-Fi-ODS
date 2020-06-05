// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using System.Web.Http.Filters;
using System.Web.Http.Hosting;
using Castle.MicroKernel.Registration;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.InversionOfControl;
using EdFi.Ods.Api.Services.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.InversionOfControl;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.WebApi.Common
{
    [TestFixture]
    public class AuthenticateAttributeTests
    {
        private static WindsorContainerEx _container;

        public static void Initialize(
            IOAuthTokenValidator oAuthTokenValidator = null,
            IApiKeyContextProvider apiKeyContextProvider = null,
            IClaimsIdentityProvider claimsIdentityProvider = null,
            IConfigValueProvider configValueProvider = null)
        {
            _container = new WindsorContainerEx();

            //arrange
            var tokenValidator = oAuthTokenValidator ?? MockRepository.GenerateStub<IOAuthTokenValidator>();
            var contextProvider = apiKeyContextProvider ?? MockRepository.GenerateStub<IApiKeyContextProvider>();
            var identityProvider = claimsIdentityProvider ?? MockRepository.GenerateStub<IClaimsIdentityProvider>();
            var configProvider = configValueProvider ?? MockRepository.GenerateStub<IConfigValueProvider>();

            _container.Register(
                Component.For<IOAuthTokenValidator>()
                         .Instance(tokenValidator));

            _container.Register(
                Component.For<IApiKeyContextProvider>()
                         .Instance(contextProvider));

            _container.Register(
                Component.For<IClaimsIdentityProvider>()
                         .Instance(identityProvider));

            _container.Register(
                Component.For<IConfigValueProvider>()
                         .Instance(configProvider));

            _container.Register(
                Component.For<IAuthenticationProvider>()
                         .ImplementedBy<OAuthAuthenticationProvider>());

            // Web API Dependency Injection
            _container.Register(
                Component.For<IDependencyResolver>()
                         .Instance(new WindsorDependencyResolver(_container)));
        }

        public static HttpAuthenticationContext GetBaseAuthenticationContext()
        {
            var request = new HttpRequestMessage();

            request.Properties.Add(HttpPropertyKeys.DependencyScope, new WindsorDependencyResolver(_container));

            var controllerContext = new HttpControllerContext
                                    {
                                        Request = request
                                    };

            var actionDescriptor = MockRepository.GenerateStub<HttpActionDescriptor>();

            var actionContext = new HttpActionContext(controllerContext, actionDescriptor);

            return new HttpAuthenticationContext(actionContext, null);
        }

        public static void SetAuthorizationHeader(HttpAuthenticationContext context, string scheme, string parameter)
        {
            var authorization = new AuthenticationHeaderValue(scheme, parameter);
            var headers = context.Request.Headers;
            headers.Authorization = authorization;
        }

        public class When_OnAuthentication_is_invoked_for_a_request_and_no_authorization_header_is_provided : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;

            protected override void Arrange()
            {
                Initialize();
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_return_response_indicating_missing_credentials()
            {
                AssertHelper.All(
                    () => Assert.That(_context.ErrorResult.GetType(), Is.EqualTo(typeof(AuthenticationFailureResult))),
                    () => Assert.That(
                        _context.ErrorResult.ExecuteAsync(new CancellationToken())
                                .Result.ReasonPhrase,
                        Is.EqualTo("Missing credentials")));
            }

            [Assert]
            public void Should_not_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Null, "Principal should not be set");
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_and_an_invalid_authorization_scheme_is_provided : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;

            protected override void Arrange()
            {
                Initialize();
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();
                SetAuthorizationHeader(_context, "testScheme", null);
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_do_nothing_and_return_OK()
            {
                Assert.That(_context.ErrorResult, Is.Null);
            }

            [Assert]
            public void Should_not_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Null, "Principal should not be set");
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_and_the_authorization_parameter_is_missing : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;

            protected override void Arrange()
            {
                Initialize();
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();
                SetAuthorizationHeader(_context, "Bearer", null);
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_return_response_indicating_missing_parameter()
            {
                AssertHelper.All(
                    () => Assert.That(_context.ErrorResult.GetType(), Is.EqualTo(typeof(AuthenticationFailureResult))),
                    () => Assert.That(
                        _context.ErrorResult.ExecuteAsync(new CancellationToken())
                                .Result.ReasonPhrase,
                        Is.EqualTo("Missing parameter")));
            }

            [Assert]
            public void Should_not_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Null, "Principal should not be set");
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_and_the_authorization_oauth_token_is_invalid : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;

            protected override void Arrange()
            {
                var tokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                tokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                              .Return(Task.FromResult(new ApiClientDetails()));

                Initialize(tokenValidator);
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();

                SetAuthorizationHeader(
                    _context,
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_return_response_indicating_invalid_token()
            {
                AssertHelper.All(
                    () => Assert.That(_context.ErrorResult.GetType(), Is.EqualTo(typeof(AuthenticationFailureResult))),
                    () => Assert.That(
                        _context.ErrorResult.ExecuteAsync(new CancellationToken())
                                .Result.ReasonPhrase,
                        Is.EqualTo("Invalid token")));
            }

            [Assert]
            public void Should_not_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Null, "Principal should not be set");
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_using_sandbox_credentials_in_a_production_deployment : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;

            protected override void Arrange()
            {
                var tokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                tokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                              .Return(
                                   Task.FromResult(
                                       new ApiClientDetails
                                       {
                                           ApiKey = "key", ClaimSetName = "claimSetName", NamespacePrefixes = new List<string>
                                                                                                              {
                                                                                                                  "namespacePrefix"
                                                                                                              },
                                           EducationOrganizationIds = new List<int>(), IsSandboxClient = true
                                       }));

                var contextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

                var identityProvider = MockRepository.GenerateStub<IClaimsIdentityProvider>();

                identityProvider.Stub(
                                     i => i.GetClaimsIdentity(
                                         Arg<IEnumerable<int>>.Is.Anything,
                                         Arg<string>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything))
                                .Return(new ClaimsIdentity());

                var configProvider = MockRepository.GenerateStub<IConfigValueProvider>();

                configProvider.Stub(i => i.GetValue("ExpectedUseSandboxValue"))
                              .Return("false");

                Initialize(tokenValidator, contextProvider, identityProvider, configProvider);
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();

                SetAuthorizationHeader(
                    _context,
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_return_response_indicating_sandbox_credentials_used_to_call_production_api()
            {
                AssertHelper.All(
                    () => Assert.That(_context.ErrorResult.GetType(), Is.EqualTo(typeof(AuthenticationFailureResult))),
                    () => Assert.That(
                        _context.ErrorResult.ExecuteAsync(new CancellationToken())
                                .Result.ReasonPhrase,
                        Is.EqualTo("Sandbox credentials used in call to Production API")));
            }

            [Assert]
            public void Should_not_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Null, "Principal should not be set");
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_using_production_credentials_in_a_sandbox_deployment : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;

            protected override void Arrange()
            {
                var tokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                tokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                              .Return(
                                   Task.FromResult(
                                       new ApiClientDetails
                                       {
                                           ApiKey = "key", ClaimSetName = "claimSetName", NamespacePrefixes = new List<string>
                                                                                                              {
                                                                                                                  "namespacePrefix"
                                                                                                              },
                                           EducationOrganizationIds = new List<int>(), IsSandboxClient = false
                                       }));

                var contextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

                var identityProvider = MockRepository.GenerateStub<IClaimsIdentityProvider>();

                identityProvider.Stub(
                                     i => i.GetClaimsIdentity(
                                         Arg<IEnumerable<int>>.Is.Anything,
                                         Arg<string>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything))
                                .Return(new ClaimsIdentity());

                var configProvider = MockRepository.GenerateStub<IConfigValueProvider>();

                configProvider.Stub(i => i.GetValue("ExpectedUseSandboxValue"))
                              .Return("true");

                Initialize(tokenValidator, contextProvider, identityProvider, configProvider);
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();

                SetAuthorizationHeader(
                    _context,
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_return_response_indicating_production_credentials_used_to_call_sandbox_api()
            {
                AssertHelper.All(
                    () => Assert.That(_context.ErrorResult.GetType(), Is.EqualTo(typeof(AuthenticationFailureResult))),
                    () => Assert.That(
                        _context.ErrorResult.ExecuteAsync(new CancellationToken())
                                .Result.ReasonPhrase,
                        Is.EqualTo("Production credentials used in call to Sandbox API")));
            }

            [Assert]
            public void Should_not_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Null, "Principal should not be set");
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_with_valid_credentials : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;
            private bool _setContextCalled;

            protected override void Arrange()
            {
                _setContextCalled = false;

                var tokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                tokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                              .Return(
                                   Task.FromResult(
                                       new ApiClientDetails
                                       {
                                           ApiKey = "key", ClaimSetName = "claimSetName", NamespacePrefixes = new List<string>
                                                                                                              {
                                                                                                                  "namespacePrefix"
                                                                                                              },
                                           EducationOrganizationIds = new List<int>()
                                       }));

                var contextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

                contextProvider.Stub(c => c.SetApiKeyContext(Arg<ApiKeyContext>.Is.Anything))
                               .WhenCalled(call => { _setContextCalled = true; });

                var identityProvider = MockRepository.GenerateStub<IClaimsIdentityProvider>();

                identityProvider.Stub(
                                     i => i.GetClaimsIdentity(
                                         Arg<IEnumerable<int>>.Is.Anything,
                                         Arg<string>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything))
                                .Return(new ClaimsIdentity());

                var configProvider = MockRepository.GenerateStub<IConfigValueProvider>();

                configProvider.Stub(i => i.GetValue("ExpectedUseSandboxValue"))
                              .Return(null);

                Initialize(tokenValidator, contextProvider, identityProvider, configProvider);
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();

                SetAuthorizationHeader(
                    _context,
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Not.Null, "Principal should be set");
            }

            [Assert]
            public void Should_trigger_SetApiKeyContext_to_Be_call_on_the_apiKeyContextProvider()
            {
                Assert.IsTrue(_setContextCalled);
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_with_valid_sandbox_credentials_in_a_sandbox_deployment : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;
            private bool _setContextCalled;

            protected override void Arrange()
            {
                _setContextCalled = false;

                var tokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                tokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                              .Return(
                                   Task.FromResult(
                                       new ApiClientDetails
                                       {
                                           ApiKey = "key", ClaimSetName = "claimSetName", NamespacePrefixes = new List<string>
                                                                                                              {
                                                                                                                  "namespacePrefix"
                                                                                                              },
                                           EducationOrganizationIds = new List<int>(), IsSandboxClient = true
                                       }));

                var contextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

                contextProvider.Stub(c => c.SetApiKeyContext(Arg<ApiKeyContext>.Is.Anything))
                               .WhenCalled(call => { _setContextCalled = true; });

                var identityProvider = MockRepository.GenerateStub<IClaimsIdentityProvider>();

                identityProvider.Stub(
                                     i => i.GetClaimsIdentity(
                                         Arg<IEnumerable<int>>.Is.Anything,
                                         Arg<string>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything))
                                .Return(new ClaimsIdentity());

                var configProvider = MockRepository.GenerateStub<IConfigValueProvider>();

                configProvider.Stub(i => i.GetValue("ExpectedUseSandboxValue"))
                              .Return("true");

                Initialize(tokenValidator, contextProvider, identityProvider, configProvider);
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();

                SetAuthorizationHeader(
                    _context,
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Not.Null, "Principal should be set");
            }

            [Assert]
            public void Should_trigger_SetApiKeyContext_to_Be_call_on_the_apiKeyContextProvider()
            {
                Assert.IsTrue(_setContextCalled);
            }
        }

        public class When_OnAuthentication_is_invoked_for_a_request_with_valid_production_credentials_in_a_production_deployment : LegacyTestFixtureBase
        {
            private AuthenticateAttribute _filter;
            private HttpAuthenticationContext _context;
            private bool _setContextCalled;

            protected override void Arrange()
            {
                _setContextCalled = false;

                var tokenValidator = MockRepository.GenerateStub<IOAuthTokenValidator>();

                tokenValidator.Stub(t => t.GetClientDetailsForTokenAsync(Arg<string>.Is.Anything))
                              .Return(
                                   Task.FromResult(
                                       new ApiClientDetails
                                       {
                                           ApiKey = "key", ClaimSetName = "claimSetName", NamespacePrefixes = new List<string>
                                                                                                              {
                                                                                                                  "namespacePrefix"
                                                                                                              },
                                           EducationOrganizationIds = new List<int>(), IsSandboxClient = false
                                       }));

                var contextProvider = MockRepository.GenerateStub<IApiKeyContextProvider>();

                contextProvider.Stub(c => c.SetApiKeyContext(Arg<ApiKeyContext>.Is.Anything))
                               .WhenCalled(call => { _setContextCalled = true; });

                var identityProvider = MockRepository.GenerateStub<IClaimsIdentityProvider>();

                identityProvider.Stub(
                                     i => i.GetClaimsIdentity(
                                         Arg<IEnumerable<int>>.Is.Anything,
                                         Arg<string>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything,
                                         Arg<IReadOnlyList<string>>.Is.Anything))
                                .Return(new ClaimsIdentity());

                var configProvider = MockRepository.GenerateStub<IConfigValueProvider>();

                configProvider.Stub(i => i.GetValue("ExpectedUseSandboxValue"))
                              .Return("false");

                Initialize(tokenValidator, contextProvider, identityProvider, configProvider);
                _filter = new AuthenticateAttribute();
                _context = GetBaseAuthenticationContext();

                SetAuthorizationHeader(
                    _context,
                    "Bearer",
                    Guid.NewGuid()
                        .ToString());
            }

            protected override void Act()
            {
                _filter.AuthenticateAsync(_context, new CancellationToken())
                       .Wait();
            }

            [Assert]
            public void Should_set_a_principal_into_the_request_context()
            {
                Assert.That(_context.Principal, Is.Not.Null, "Principal should be set");
            }

            [Assert]
            public void Should_trigger_SetApiKeyContext_to_Be_call_on_the_apiKeyContextProvider()
            {
                Assert.IsTrue(_setContextCalled);
            }
        }
    }
}

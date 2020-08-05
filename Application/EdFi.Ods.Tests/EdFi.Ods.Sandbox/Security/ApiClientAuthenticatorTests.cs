// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Security;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    public class ApiClientAuthenticatorTests
    {
        public class When_trying_to_authenticate_using_valid_key_and_valid_secret : LegacyTestFixtureBase
        {
            private ApiClientIdentity _apiClientIdentity;
            private bool _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                _apiClientIdentity = new ApiClientIdentity
                                     {
                                         Key = "MyKey"
                                     };

                var apiClientIdentityProvider = mocks.Stub<IApiClientIdentityProvider>();

                apiClientIdentityProvider.Stub(x => x.GetApiClientIdentity("MyKey"))
                                         .Return(_apiClientIdentity);

                var apiClientSecret = new ApiClientSecret
                                      {
                                          Secret = "MySecret"
                                      };

                var apiClientSecretProvider = mocks.Stub<IApiClientSecretProvider>();

                apiClientSecretProvider.Expect(x => x.GetSecret("MyKey"))
                                       .Return(apiClientSecret);

                var secretVerifier = mocks.Stub<ISecretVerifier>();

                secretVerifier.Expect(x => x.VerifySecret("MyKey", "MySecret", apiClientSecret))
                              .Return(true);

                _apiClientAuthenticator = new ApiClientAuthenticator(apiClientIdentityProvider, apiClientSecretProvider, secretVerifier);
            }

            protected override void Act()
            {
                _actualResult = _apiClientAuthenticator.TryAuthenticate("MyKey", "MySecret", out _apiClientIdentity);
            }

            [Test]
            public void Should_return_correct_identity()
            {
                Assert.That(_apiClientIdentity, Is.Not.Null);
                Assert.That(_apiClientIdentity.Key, Is.EqualTo("MyKey"));
            }

            [Test]
            public void Should_return_true()
            {
                Assert.That(_actualResult, Is.True);
            }
        }

        public class When_trying_to_authenticate_using_invalid_key_and_valid_secret : LegacyTestFixtureBase
        {
            private ApiClientIdentity _apiClientIdentity;
            private bool _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                var apiClientIdentityProvider = mocks.Stub<IApiClientIdentityProvider>();

                var apiClientSecretProvider = mocks.Stub<IApiClientSecretProvider>();

                apiClientSecretProvider.Expect(x => x.GetSecret("MyInvalidKey"))
                                       .Throw(new ArgumentException());

                var secretVerifier = mocks.Stub<ISecretVerifier>();

                _apiClientAuthenticator = new ApiClientAuthenticator(apiClientIdentityProvider, apiClientSecretProvider, secretVerifier);
            }

            protected override void Act()
            {
                _actualResult = _apiClientAuthenticator.TryAuthenticate("MyInvalidKey", "MySecret", out _apiClientIdentity);
            }

            [Test]
            public void Should_return_false()
            {
                Assert.That(_actualResult, Is.False);
            }

            [Test]
            public void Should_return_null_identity()
            {
                Assert.That(_apiClientIdentity, Is.Null);
            }
        }

        public class When_trying_to_authenticate_using_valid_key_and_invalid_secret : LegacyTestFixtureBase
        {
            private ApiClientIdentity _apiClientIdentity;
            private bool _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                var apiClientSecret = new ApiClientSecret
                                      {
                                          Secret = "MySecret"
                                      };

                var apiClientSecretProvider = mocks.Stub<IApiClientSecretProvider>();

                apiClientSecretProvider.Stub(x => x.GetSecret("MyKey"))
                                       .Return(apiClientSecret);

                var secretVerifier = mocks.Stub<ISecretVerifier>();

                secretVerifier.Expect(x => x.VerifySecret("MyKey", "MyInvalidSecret", apiClientSecret))
                              .Return(false);

                var apiClientIdentityProvider = mocks.Stub<IApiClientIdentityProvider>();

                _apiClientAuthenticator = new ApiClientAuthenticator(apiClientIdentityProvider, apiClientSecretProvider, secretVerifier);
            }

            protected override void Act()
            {
                _actualResult = _apiClientAuthenticator.TryAuthenticate("MyKey", "MyInvalidSecret", out _apiClientIdentity);
            }

            [Test]
            public void Should_return_false()
            {
                Assert.That(_actualResult, Is.False);
            }

            [Test]
            public void Should_return_null_identity()
            {
                Assert.That(_apiClientIdentity, Is.Null);
            }
        }
    }
}

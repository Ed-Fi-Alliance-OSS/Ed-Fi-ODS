// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETCOREAPP
using System;
using EdFi.Ods.Common.Security;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    public class ApiClientAuthenticatorTests
    {
        public class When_trying_to_authenticate_using_valid_key_and_valid_secret : TestFixtureBase
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

                var apiClientIdentityProvider = Stub<IApiClientIdentityProvider>();

                A.CallTo(()=> apiClientIdentityProvider.GetApiClientIdentity("MyKey"))
                    .Returns(_apiClientIdentity);

                var apiClientSecret = new ApiClientSecret
                {
                    Secret = "MySecret"
                };

                var apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                A.CallTo(() => apiClientSecretProvider.GetSecret("MyKey"))
                    .Returns(apiClientSecret);

                var secretVerifier = Stub<ISecretVerifier>();

                A.CallTo(() => secretVerifier.VerifySecret("MyKey", "MySecret", apiClientSecret))
                    .Returns(true);

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

        public class When_trying_to_authenticate_using_invalid_key_and_valid_secret : TestFixtureBase
        {
            private ApiClientIdentity _apiClientIdentity;
            private bool _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                var apiClientIdentityProvider = Stub<IApiClientIdentityProvider>();

                var apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                A.CallTo(() => apiClientSecretProvider.GetSecret("MyInvalidKey")).Throws(new ArgumentException());


                var secretVerifier = Stub<ISecretVerifier>();

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

        public class When_trying_to_authenticate_using_valid_key_and_invalid_secret : TestFixtureBase
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

                var apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                A.CallTo(()=> apiClientSecretProvider.GetSecret("MyKey"))
                    .Returns(apiClientSecret);

                var secretVerifier = Stub<ISecretVerifier>();

                A.CallTo(() => secretVerifier.VerifySecret("MyKey", "MyInvalidSecret", apiClientSecret))
                    .Returns(false);

                var apiClientIdentityProvider = Stub<IApiClientIdentityProvider>();

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
#endif
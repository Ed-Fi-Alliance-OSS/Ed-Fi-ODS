// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Security;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    public class ApiClientAuthenticatorTests
    {
        public class When_trying_to_authenticate_using_valid_key_and_valid_secret : TestFixtureBase
        {
            private ApiClientDetails _apiClientDetails;
            private ApiClientAuthenticator.AuthenticationResult _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                _apiClientDetails = new ApiClientDetails()
                {
                    ApiKey = "MyKey",
                    Secret = "MySecret"
                };

                var apiClientDetailsProvider = Stub<IApiClientDetailsProvider>();

                A.CallTo(() => apiClientDetailsProvider.GetApiClientDetailsForKeyAsync("MyKey"))
                    .Returns(_apiClientDetails);

                var secretVerifier = Stub<ISecretVerifier>();

                A.CallTo(() => secretVerifier.VerifySecret("MyKey", "MySecret", 
                        A<ApiClientSecret>.That.Matches(_ => _.Secret == "MySecret")))
                    .Returns(true);

                _apiClientAuthenticator = new ApiClientAuthenticator(apiClientDetailsProvider, secretVerifier);
            }

            protected override void Act()
            {
                _actualResult = _apiClientAuthenticator.TryAuthenticateAsync("MyKey", "MySecret")
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();;
            }

            [Test]
            public void Should_return_correct_identity()
            {
                Assert.That(_apiClientDetails, Is.Not.Null);
                Assert.That(_apiClientDetails.ApiKey, Is.EqualTo("MyKey"));
            }

            [Test]
            public void Should_return_true()
            {
                _actualResult.IsAuthenticated.ShouldBeTrue();
            }
        }

        public class When_trying_to_authenticate_using_invalid_key_and_valid_secret : TestFixtureBase
        {
            private ApiClientAuthenticator.AuthenticationResult _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                var apiClientDetailsProvider = Stub<IApiClientDetailsProvider>();

                // var apiClientSecretProvider = Stub<IApiClientSecretProvider>();
                // A.CallTo(() => apiClientSecretProvider.GetSecret("MyInvalidKey")).Throws(new ArgumentException());

                var secretVerifier = Stub<ISecretVerifier>();
                _apiClientAuthenticator = new ApiClientAuthenticator(apiClientDetailsProvider, secretVerifier);
            }

            protected override void Act()
            {
                _actualResult = _apiClientAuthenticator.TryAuthenticateAsync("MyInvalidKey", "MySecret")
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();;
            }

            [Test]
            public void Should_return_false()
            {
                _actualResult.IsAuthenticated.ShouldBeFalse();
            }

            [Test]
            public void Should_return_null_identity()
            {
                _actualResult.ApiClientDetails.ShouldBeNull();
            }
        }

        public class When_trying_to_authenticate_using_valid_key_and_invalid_secret : TestFixtureBase
        {
            private ApiClientIdentity _apiClientIdentity;
            private ApiClientAuthenticator.AuthenticationResult _actualResult;
            private IApiClientAuthenticator _apiClientAuthenticator;

            protected override void Arrange()
            {
                var secretVerifier = Stub<ISecretVerifier>();

                A.CallTo(() => secretVerifier.VerifySecret("MyKey", "MySecret", 
                        A<ApiClientSecret>.That.Matches(_ => _.Secret == "MySecret")))
                    .Returns(true);

                var apiClientDetailsProvider = Stub<IApiClientDetailsProvider>();

                _apiClientAuthenticator = new ApiClientAuthenticator(apiClientDetailsProvider, secretVerifier);
            }

            protected override void Act()
            {
                _actualResult = _apiClientAuthenticator.TryAuthenticateAsync("MyKey", "MyInvalidSecret")
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();;
            }

            [Test]
            public void Should_return_false()
            {
                _actualResult.IsAuthenticated.ShouldBeFalse();
            }

            [Test]
            public void Should_return_null_identity()
            {
                _apiClientIdentity.ShouldBeNull();
            }
        }
    }
}
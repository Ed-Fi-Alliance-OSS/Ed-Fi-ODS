// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Sandbox.Security;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Helpers;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Sandbox.Security
{
    [TestFixture]
    public class AutoUpgradingHashedSecretVerifierDecoratorTests
    {
        protected const string Secret = "GoodSecret";
        protected const string Salt = "Salt";
        protected const string Algorithm = "MySuperSecretAlgorithm";
        protected const string Key = "MyKey";

        public class When_using_valid_secret_that_is_hashed_with_current_config : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;

            protected override void Arrange()
            {
                _apiClientSecret = new ApiClientSecret
                                   {
                                       IsHashed = true, Secret = Secret
                                   };

                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                var next = Stub<ISecretVerifier>();

                next.Stub(x => x.VerifySecret(Key, Secret, _apiClientSecret))
                    .Return(true);

                var packedHashConverter = Stub<IPackedHashConverter>();

                packedHashConverter.Stub(x => x.GetPackedHash(Secret))
                                   .Return(
                                        new PackedHash
                                        {
                                            Format = 0, HashAlgorithm = HashHelper.GetSha256Hash(Algorithm).ToInt32(), HashBytes = new byte[]
                                                                                                                                   {
                                                                                                                                       1, 5, 3
                                                                                                                                   },
                                            Salt = new byte[]
                                                   {
                                                       6, 5, 8, 94, 34
                                                   },
                                            Iterations = 321
                                        });

                var configProvider = Stub<IHashConfigurationProvider>();

                configProvider.Stub(x => x.GetHashConfiguration())
                              .Return(
                                   new HashConfiguration
                                   {
                                       Algorithm = Algorithm, Iterations = 321, SaltSize = 40
                                   });

                _autoUpgradingHashedSecretVerifierDecorator =
                    new AutoUpgradingHashedSecretVerifierDecorator(
                        _apiClientSecretProvider, next, packedHashConverter, null, configProvider);
            }

            protected override void Act()
            {
                _expectedResults =
                    _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public virtual void Should_not_save_new_password()
            {
                _apiClientSecretProvider.AssertWasNotCalled(x => x.SetSecret(Key, _apiClientSecret));
            }

            [Test]
            public virtual void Should_succeed()
            {
                Assert.That(_expectedResults, Is.True);
            }
        }

        public class When_using_invalid_secret : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;

            protected override void Arrange()
            {
                _apiClientSecret = new ApiClientSecret();

                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                var next = Stub<ISecretVerifier>();

                next.Stub(x => x.VerifySecret(Key, Secret, _apiClientSecret))
                    .Return(false);

                var packedHashConverter = Stub<IPackedHashConverter>();

                packedHashConverter.Stub(x => x.GetPackedHash(Secret))
                                   .Return(
                                        new PackedHash
                                        {
                                            Format = 0, HashAlgorithm = HashHelper.GetSha256Hash(Algorithm).ToInt32(), HashBytes = new byte[]
                                                                                                                                   {
                                                                                                                                       1, 5, 3
                                                                                                                                   },
                                            Salt = new byte[]
                                                   {
                                                       6, 5, 8, 94, 34
                                                   },
                                            Iterations = 321
                                        });

                var securePackedHashProvider = Stub<ISecurePackedHashProvider>();

                securePackedHashProvider.Stub(x => x.ComputePackedHashString(Secret, 123, 321, 12))
                                        .Return("");

                var configProvider = Stub<IHashConfigurationProvider>();

                configProvider.Stub(x => x.GetHashConfiguration())
                              .Return(
                                   new HashConfiguration
                                   {
                                       Algorithm = Algorithm, Iterations = 321, SaltSize = 5
                                   });

                _autoUpgradingHashedSecretVerifierDecorator = new AutoUpgradingHashedSecretVerifierDecorator(
                    _apiClientSecretProvider,
                    next,
                    packedHashConverter,
                    securePackedHashProvider,
                    configProvider);
            }

            protected override void Act()
            {
                _expectedResults = _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public virtual void Should_not_save()
            {
                _apiClientSecretProvider.AssertWasNotCalled(x => x.SetSecret(Key, _apiClientSecret));
            }

            [Test]
            public virtual void Should_return_false()
            {
                Assert.That(_expectedResults, Is.False);
            }
        }

        public class When_using_valid_secret_that_is_not_hashed : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;

            protected override void Arrange()
            {
                _apiClientSecret = new ApiClientSecret();
                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                var next = Stub<ISecretVerifier>();

                next.Stub(x => x.VerifySecret(Key, Secret, _apiClientSecret))
                    .Return(true);

                var packedHashConverter = Stub<IPackedHashConverter>();

                packedHashConverter.Stub(x => x.GetPackedHash(Secret))
                                   .Throw(new FormatException());

                var securePackedHashProvider = Stub<ISecurePackedHashProvider>();

                securePackedHashProvider.Stub(x => x.ComputePackedHashString(Secret, 123, 321, 12))
                                        .Return("");

                var configProvider = Stub<IHashConfigurationProvider>();

                configProvider.Stub(x => x.GetHashConfiguration())
                              .Return(
                                   new HashConfiguration
                                   {
                                       Algorithm = Algorithm, Iterations = 321, SaltSize = 5
                                   });

                _autoUpgradingHashedSecretVerifierDecorator = new AutoUpgradingHashedSecretVerifierDecorator(
                    _apiClientSecretProvider,
                    next,
                    packedHashConverter,
                    securePackedHashProvider,
                    configProvider);
            }

            protected override void Act()
            {
                _expectedResults =
                    _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public virtual void Should_be_able_to_compute_hash()
            {
                Assert.That(_expectedResults, Is.True);
            }

            [Test]
            public virtual void Should_save_new_secret()
            {
                _apiClientSecretProvider.AssertWasCalled(x => x.SetSecret(Key, _apiClientSecret), o => o.Repeat.Once());
            }
        }

        public class When_using_valid_secret_that_is_hashed_with_different_iterations : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;

            protected override void Arrange()
            {
                _apiClientSecret = new ApiClientSecret();
                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                var next = Stub<ISecretVerifier>();

                next.Stub(x => x.VerifySecret(Key, Secret, _apiClientSecret))
                    .Return(true);

                var packedHashConverter = Stub<IPackedHashConverter>();

                packedHashConverter.Stub(x => x.GetPackedHash(Secret))
                                   .Return(
                                        new PackedHash
                                        {
                                            Format = 0, HashAlgorithm = HashHelper.GetSha256Hash(Algorithm).ToInt32(), HashBytes = new byte[]
                                                                                                                                   {
                                                                                                                                       1, 5, 3
                                                                                                                                   },
                                            Salt = new byte[]
                                                   {
                                                       6, 5, 8, 94, 34
                                                   },
                                            Iterations = 333
                                        });

                var securePackedHashProvider = Stub<ISecurePackedHashProvider>();

                securePackedHashProvider.Stub(x => x.ComputePackedHashString(Secret, 123, 321, 12))
                                        .Return("");

                var configProvider = Stub<IHashConfigurationProvider>();

                configProvider.Stub(x => x.GetHashConfiguration())
                              .Return(
                                   new HashConfiguration
                                   {
                                       Algorithm = Algorithm, Iterations = 321, SaltSize = 5
                                   });

                _autoUpgradingHashedSecretVerifierDecorator = new AutoUpgradingHashedSecretVerifierDecorator(
                    _apiClientSecretProvider,
                    next,
                    packedHashConverter,
                    securePackedHashProvider,
                    configProvider);
            }

            protected override void Act()
            {
                _expectedResults =
                    _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public virtual void Should_be_able_to_compute_hash()
            {
                Assert.That(_expectedResults, Is.True);
            }

            [Test]
            public virtual void Should_save_new_secret()
            {
                _apiClientSecretProvider.AssertWasCalled(x => x.SetSecret(Key, _apiClientSecret), o => o.Repeat.Once());
            }
        }

        public class When_using_valid_secret_that_is_hashed_with_different_hash_algorithm : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;

            protected override void Arrange()
            {
                _apiClientSecret = new ApiClientSecret();
                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                var next = Stub<ISecretVerifier>();

                next.Stub(x => x.VerifySecret(Key, Secret, _apiClientSecret))
                    .Return(true);

                var packedHashConverter = Stub<IPackedHashConverter>();

                packedHashConverter.Stub(x => x.GetPackedHash(Secret))
                                   .Return(
                                        new PackedHash
                                        {
                                            Format = 0, HashAlgorithm = HashHelper.GetSha256Hash(Algorithm).ToInt32(), HashBytes = new byte[]
                                                                                                                                   {
                                                                                                                                       1, 5, 3
                                                                                                                                   },
                                            Salt = new byte[]
                                                   {
                                                       6, 5, 8, 94, 34
                                                   },
                                            Iterations = 321
                                        });

                var securePackedHashProvider = Stub<ISecurePackedHashProvider>();

                securePackedHashProvider.Stub(x => x.ComputePackedHashString(Secret, 123, 321, 12))
                                        .Return("");

                var configProvider = Stub<IHashConfigurationProvider>();

                configProvider.Stub(x => x.GetHashConfiguration())
                              .Return(
                                   new HashConfiguration
                                   {
                                       Algorithm = "MyNEWSuperSecretAlgorithm", Iterations = 321, SaltSize = 40
                                   });

                _autoUpgradingHashedSecretVerifierDecorator = new AutoUpgradingHashedSecretVerifierDecorator(
                    _apiClientSecretProvider,
                    next,
                    packedHashConverter,
                    securePackedHashProvider,
                    configProvider);
            }

            protected override void Act()
            {
                _expectedResults =
                    _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public virtual void Should_be_able_to_compute_hash()
            {
                Assert.That(_expectedResults, Is.True);
            }

            [Test]
            public virtual void Should_save_new_secret()
            {
                _apiClientSecretProvider.AssertWasCalled(x => x.SetSecret(Key, _apiClientSecret), o => o.Repeat.Once());
            }
        }

        public class When_using_valid_secret_that_is_hashed_with_different_salt_size : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;

            protected override void Arrange()
            {
                _apiClientSecret = new ApiClientSecret();
                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();

                var next = Stub<ISecretVerifier>();

                next.Stub(x => x.VerifySecret(Key, Secret, _apiClientSecret))
                    .Return(true);

                var packedHashConverter = Stub<IPackedHashConverter>();

                packedHashConverter.Stub(x => x.GetPackedHash(Secret))
                                   .Return(
                                        new PackedHash
                                        {
                                            Format = 0, HashAlgorithm = HashHelper.GetSha256Hash(Algorithm).ToInt32(), HashBytes = new byte[]
                                                                                                                                   {
                                                                                                                                       1, 5, 3
                                                                                                                                   },
                                            Salt = new byte[]
                                                   {
                                                       6, 5, 8, 94, 34
                                                   },
                                            Iterations = 321
                                        });

                var securePackedHashProvider = Stub<ISecurePackedHashProvider>();

                securePackedHashProvider.Stub(x => x.ComputePackedHashString(Secret, 123, 321, 12))
                                        .Return("");

                var configProvider = Stub<IHashConfigurationProvider>();

                configProvider.Stub(x => x.GetHashConfiguration())
                              .Return(
                                   new HashConfiguration
                                   {
                                       Algorithm = Algorithm, Iterations = 321, SaltSize = 48
                                   });

                _autoUpgradingHashedSecretVerifierDecorator = new AutoUpgradingHashedSecretVerifierDecorator(
                    _apiClientSecretProvider,
                    next,
                    packedHashConverter,
                    securePackedHashProvider,
                    configProvider);
            }

            protected override void Act()
            {
                _expectedResults =
                    _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public virtual void Should_be_able_to_compute_hash()
            {
                Assert.That(_expectedResults, Is.True);
            }

            [Test]
            public virtual void Should_save_new_secret()
            {
                _apiClientSecretProvider.AssertWasCalled(x => x.SetSecret(Key, _apiClientSecret), o => o.Repeat.Once());
            }
        }

        public class When_upgrading_a_valid_secret_that_was_hashed_with_GetHashCode_that_is_valid : LegacyTestFixtureBase
        {
            private IApiClientSecretProvider _apiClientSecretProvider;
            private AutoUpgradingHashedSecretVerifierDecorator _autoUpgradingHashedSecretVerifierDecorator;
            private ApiClientSecret _apiClientSecret;
            private bool _expectedResults;
            private ISecurePackedHashProvider _securePackedHashProvider;
            private IHashConfigurationProvider _configProvider;

            protected override void Arrange()
            {
                var packedHashConverter = new PackedHashConverter();

                var packedHash = new PackedHash
                {
                    Format = 0,
                    HashAlgorithm = "GOOD".GetHashCode(), // simulation of a hash routine that used GetHashCode
                    HashBytes = new byte[]
                    {
                        246, 198, 84, 57, 46, 87, 69, 64, 36, 89, 195, 42, 154,
                        103, 212, 113, 134, 129, 0, 29, 59, 36, 38, 212, 67, 32,
                        67, 113, 96, 103, 22, 129
                    },
                    Iterations = 100,
                    Salt = new byte[] {5, 8, 4, 2, 3, 6, 12, 34}
                };

                _configProvider = new DefaultHashConfigurationProvider();

                _apiClientSecret = new ApiClientSecret
                {
                    IsHashed = true,

                    // GetHashCode is consistent
                    Secret = "ANO2IFlkAAAACAAAAAUIBAIDBgwi9sZUOS5XRUAkWcMqmmfUcYaBAB07JCbUQyBDcWBnFoE="
                };

                _apiClientSecretProvider = Stub<IApiClientSecretProvider>();
                
                var secureHasher = new Pbkdf2HmacSha1SecureHasher(null);
                var next = new SecureHashAwareSecretVerifier(packedHashConverter, secureHasher);

                _securePackedHashProvider = Stub<ISecurePackedHashProvider>();

                _autoUpgradingHashedSecretVerifierDecorator = new AutoUpgradingHashedSecretVerifierDecorator(
                    _apiClientSecretProvider, next, packedHashConverter, _securePackedHashProvider, _configProvider);
            }

            protected override void Act()
            {
                _expectedResults = _autoUpgradingHashedSecretVerifierDecorator.VerifySecret(Key, Secret, _apiClientSecret);
            }

            [Test]
            public void Should_upgrade_the_secret_with_the_new_hash()
            {
                var config = _configProvider.GetHashConfiguration();

                _securePackedHashProvider.AssertWasCalled(x => x.ComputePackedHashString(Secret,
                    config.GetAlgorithmHashCode(), config.Iterations, config.GetSaltSizeInBytes()));
            }

            [Test]
            public void Should_persist_the_packedhash()
            {
                _apiClientSecretProvider.AssertWasCalled(x=> x.SetSecret(Arg<string>.Is.NotNull, Arg<ApiClientSecret>.Is.Equal(_apiClientSecret)));
            }

            [Test]
            public void Should_be_able_to_compute_hash()
            {
                Assert.That(_expectedResults, Is.True);
            }
        }
    }
}

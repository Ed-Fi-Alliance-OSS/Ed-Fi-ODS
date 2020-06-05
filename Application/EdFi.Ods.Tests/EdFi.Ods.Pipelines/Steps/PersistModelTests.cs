// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Threading;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Put;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Steps;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Tests.EdFi.Ods.Common._Stubs.Repositories;
using EdFi.Ods.Tests._Builders;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Pipelines.Steps
{
    public class PersistModelTests
    {
        public class AccountResource : IHasETag
        {
            public string ETag
            {
                get { return "abcd"; }
                set { }
            }
        }

        public class AccountEntity : IDateVersionedEntity, IHasIdentifier
        {
            public DateTime LastModifiedDate
            {
                get { return DateTime.Now; }
                set { }
            }

            public Guid Id
            {
                get { return Guid.NewGuid(); }
                set { }
            }
        }

        [TestFixture]
        public class When_resource_is_neither_updated_nor_created : TestBase
        {
            private readonly PutResult _putResult = new PutResult();

            [OneTimeSetUp]
            public void Setup()
            {
                var resource = new AccountResource();
                var persistentModel = new AccountEntity();

                var context = new PutContext<AccountResource, AccountEntity>(resource, new ValidationState())
                              {
                                  PersistentModel = persistentModel
                              };

                var eTagProvider = Stub<IETagProvider>();

                StubRepository<AccountEntity> repository = New.StubRepository<AccountEntity>()
                                                              .ResourceIsNeverCreatedOrModified;

                var step = new PersistEntityModel<PutContext<AccountResource, AccountEntity>, PutResult, AccountResource, AccountEntity>(
                    repository,
                    eTagProvider);

                step.ExecuteAsync(context, _putResult, CancellationToken.None).WaitSafely();
            }

            [Test]
            public void Should_indicate_resource_was_not_created()
            {
                _putResult.ResourceWasCreated.ShouldBeFalse();
            }

            [Test]
            public void Should_indicate_resource_was_not_updated()
            {
                _putResult.ResourceWasUpdated.ShouldBeFalse();
            }

            [Test]
            public void Should_still_indicate_resource_was_persisted()
            {
                _putResult.ResourceWasPersisted.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_resource_is_created : TestBase
        {
            private readonly PutResult _putResult = new PutResult();

            [OneTimeSetUp]
            public void Setup()
            {
                var resource = new AccountResource();
                var persistentModel = new AccountEntity();

                var context = new PutContext<AccountResource, AccountEntity>(resource, new ValidationState())
                              {
                                  PersistentModel = persistentModel
                              };

                var eTagProvider = Stub<IETagProvider>();

                StubRepository<AccountEntity> repository = New.StubRepository<AccountEntity>()
                                                              .ResourceIsAlwaysCreated;

                var step = new PersistEntityModel<PutContext<AccountResource, AccountEntity>, PutResult, AccountResource, AccountEntity>(
                    repository,
                    eTagProvider);

                step.ExecuteAsync(context, _putResult, CancellationToken.None).WaitSafely();
            }

            [Test]
            public void Should_indicate_resource_was_created()
            {
                _putResult.ResourceWasCreated.ShouldBeTrue();
            }

            [Test]
            public void Should_indicate_resource_was_not_updated()
            {
                _putResult.ResourceWasUpdated.ShouldBeFalse();
            }

            [Test]
            public void Should_still_indicate_resource_was_persisted()
            {
                _putResult.ResourceWasPersisted.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_resource_is_modified : TestBase
        {
            private readonly PutResult _putResult = new PutResult();

            [OneTimeSetUp]
            public void Setup()
            {
                var resource = new AccountResource();
                var persistentModel = new AccountEntity();

                var context = new PutContext<AccountResource, AccountEntity>(resource, new ValidationState())
                              {
                                  PersistentModel = persistentModel
                              };

                var eTagProvider = Stub<IETagProvider>();

                StubRepository<AccountEntity> repository = New.StubRepository<AccountEntity>()
                                                              .ResourceIsAlwaysModified;

                var step = new PersistEntityModel<PutContext<AccountResource, AccountEntity>, PutResult, AccountResource, AccountEntity>(
                    repository,
                    eTagProvider);

                step.ExecuteAsync(context, _putResult, CancellationToken.None).WaitSafely();
            }

            [Test]
            public void Should_indicate_resource_was_not_created()
            {
                _putResult.ResourceWasCreated.ShouldBeFalse();
            }

            [Test]
            public void Should_indicate_resource_was_updated()
            {
                _putResult.ResourceWasUpdated.ShouldBeTrue();
            }

            [Test]
            public void Should_still_indicate_resource_was_persisted()
            {
                _putResult.ResourceWasPersisted.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_the_respository_throws_an_exception : TestBase
        {
            private readonly PutResult _putResult = new PutResult();

            [OneTimeSetUp]
            public void Setup()
            {
                var resource = new AccountResource();
                var persistentModel = new AccountEntity();

                var context = new PutContext<AccountResource, AccountEntity>(resource, new ValidationState())
                              {
                                  PersistentModel = persistentModel
                              };

                var eTagProvider = Stub<IETagProvider>();

                StubRepository<AccountEntity> repository = New.StubRepository<AccountEntity>()
                                                              .OnUpsertThrow(new Exception());

                var step = new PersistEntityModel<PutContext<AccountResource, AccountEntity>, PutResult, AccountResource, AccountEntity>(
                    repository,
                    eTagProvider);

                step.ExecuteAsync(context, _putResult, CancellationToken.None).WaitSafely();
            }

            [Test]
            public void Should_not_indicate_resource_was_persisted()
            {
                _putResult.ResourceWasPersisted.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_etag_provider_throws_an_exception : TestBase
        {
            private readonly PutResult _putResult = new PutResult();

            [OneTimeSetUp]
            public void Setup()
            {
                var resource = new AccountResource();
                var persistentModel = new AccountEntity();

                var context = new PutContext<AccountResource, AccountEntity>(resource, new ValidationState())
                              {
                                  PersistentModel = persistentModel
                              };

                var eTagProvider = Stub<IETagProvider>();

                eTagProvider.Stub(x => x.GetETag(null))
                            .IgnoreArguments()
                            .Throw(new Exception("Some Fun Exception"));

                StubRepository<AccountEntity> repository = New.StubRepository<AccountEntity>()
                                                              .ResourceIsNeverCreatedOrModified;

                var step = new PersistEntityModel<PutContext<AccountResource, AccountEntity>, PutResult, AccountResource, AccountEntity>(
                    repository,
                    eTagProvider);

                step.ExecuteAsync(context, _putResult, CancellationToken.None).WaitSafely();
            }

            [Test]
            public void Should_include_exception_in_result()
            {
                _putResult.Exception.Message.ShouldBe("Some Fun Exception");
            }

            [Test]
            public void Should_indicate_resource_was_persisted()
            {
                _putResult.ResourceWasPersisted.ShouldBeTrue();
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Features.SerializedData.Repositories;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.SerializedData.Repositories
{
    public class ReferenceDataLookupDecoratorTests
    {
        public class TestEntity : IHasIdentifier, IDateVersionedEntity
        {
            public Guid Id { get; set; }

            public DateTime LastModifiedDate { get; set; }

            public ReferenceDataTrackerTests.TestReferenceData SchoolSerializedReferenceData { get; set; }
        }

        public class TestReferenceData : IEntityReferenceData
        {
            public FullName FullName { get; } = new("edfi", "Test");

            public Guid? Id { get; set; }

            public string Discriminator { get; set; }

            public int IsFullyDefinedCallCount { get; private set; }

            // Returns false so that resolution stops before any database access, while recording that it was attempted
            public bool IsFullyDefined()
            {
                IsFullyDefinedCallCount++;

                return false;
            }

            public OrderedDictionary GetPrimaryKeyValues() => new();
        }

        public class TestContextProvider<TContext> : IContextProvider<TContext>
        {
            private TContext _context;

            public TestContextProvider(TContext context) => _context = context;

            public TContext Get() => _context;

            public void Set(TContext context) => _context = context;
        }

        private static ReferenceDataResolver CreateResolver(IContextProvider<ReferenceDataLookupContext> contextProvider)
        {
            var domainModelProvider = A.Fake<IDomainModelProvider>();
            A.CallTo(() => domainModelProvider.GetDomainModel()).Returns(null);

            return new ReferenceDataResolver(domainModelProvider, contextProvider, null, DatabaseEngine.SqlServer, A.Fake<ISessionFactory>());
        }

        // -------------------------------------------------------------------------------------------------------------------
        // Read path: a page mixing deserialized aggregates with aggregates hydrated through NHibernate
        // -------------------------------------------------------------------------------------------------------------------

        [TestFixture]
        public class When_loading_aggregates_through_NHibernate_after_others_were_deserialized
        {
            private ReferenceDataLookupContext _context;
            private TestReferenceData _registeredByDeserializedAggregate;
            private TestReferenceData _registeredWhileSuppressed;
            private IList<TestEntity> _loadedEntities;
            private IList<TestEntity> _result;

            [SetUp]
            public async Task Setup()
            {
                _context = new ReferenceDataLookupContext();
                var contextProvider = new TestContextProvider<ReferenceDataLookupContext>(_context);

                // Unresolved reference data registered while deserializing the first aggregates of the page
                _registeredByDeserializedAggregate = new TestReferenceData();
                _context.Add(_registeredByDeserializedAggregate);

                _loadedEntities = new List<TestEntity> { new() };
                _registeredWhileSuppressed = new TestReferenceData();

                var nhibernateLoader = A.Fake<IGetEntitiesByAggregateIds<TestEntity>>();

                A.CallTo(() => nhibernateLoader.GetByAggregateIdsAsync(A<IList<int>>._, A<CancellationToken>._))
                    .ReturnsLazily(() =>
                    {
                        // NHibernate hydration of reference data suppresses tracking and clears the context
                        _context.Suppress();
                        _context.Add(_registeredWhileSuppressed);

                        return Task.FromResult(_loadedEntities);
                    });

                var decorator = new GetEntitiesByAggregateIdsReferenceDataLookupDecorator<TestEntity>(nhibernateLoader, contextProvider);

                _result = await decorator.GetByAggregateIdsAsync(new List<int> { 1 }, CancellationToken.None);

                await CreateResolver(contextProvider).ResolveReferenceDataAsync();
            }

            [Test]
            public void Should_return_the_entities_loaded_through_NHibernate()
            {
                _result.ShouldBeSameAs(_loadedEntities);
            }

            [Test]
            public void Should_restore_the_lookups_registered_by_the_deserialized_aggregates()
            {
                _context.Items.ShouldContain(_registeredByDeserializedAggregate);
            }

            [Test]
            public void Should_not_resume_tracking()
            {
                _context.IsSuppressed().ShouldBeTrue();
                _context.Items.ShouldNotContain(_registeredWhileSuppressed);
            }

            [Test]
            public void Should_resolve_the_restored_lookups_even_though_tracking_is_suppressed()
            {
                _registeredByDeserializedAggregate.IsFullyDefinedCallCount.ShouldBeGreaterThan(0);
            }
        }

        [TestFixture]
        public class When_loading_aggregates_through_NHibernate_with_no_pending_lookups
        {
            private ReferenceDataLookupContext _context;

            [SetUp]
            public async Task Setup()
            {
                _context = new ReferenceDataLookupContext();
                var contextProvider = new TestContextProvider<ReferenceDataLookupContext>(_context);

                var nhibernateLoader = A.Fake<IGetEntitiesByAggregateIds<TestEntity>>();
                A.CallTo(() => nhibernateLoader.GetByAggregateIdsAsync(A<IList<int>>._, A<CancellationToken>._))
                    .ReturnsLazily(() =>
                    {
                        _context.Suppress();

                        return Task.FromResult<IList<TestEntity>>(new List<TestEntity>());
                    });

                var decorator = new GetEntitiesByAggregateIdsReferenceDataLookupDecorator<TestEntity>(nhibernateLoader, contextProvider);
                await decorator.GetByAggregateIdsAsync(new List<int> { 1 }, CancellationToken.None);
            }

            [Test]
            public void Should_leave_the_context_empty()
            {
                _context.Any().ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_loading_aggregates_through_NHibernate_without_a_lookup_context
        {
            private IList<TestEntity> _loadedEntities;
            private IList<TestEntity> _result;

            [SetUp]
            public async Task Setup()
            {
                _loadedEntities = new List<TestEntity>();

                var nhibernateLoader = A.Fake<IGetEntitiesByAggregateIds<TestEntity>>();
                A.CallTo(() => nhibernateLoader.GetByAggregateIdsAsync(A<IList<int>>._, A<CancellationToken>._))
                    .Returns(Task.FromResult(_loadedEntities));

                var decorator = new GetEntitiesByAggregateIdsReferenceDataLookupDecorator<TestEntity>(
                    nhibernateLoader, new TestContextProvider<ReferenceDataLookupContext>(null));

                _result = await decorator.GetByAggregateIdsAsync(new List<int> { 1 }, CancellationToken.None);
            }

            [Test]
            public void Should_return_the_loaded_entities()
            {
                _result.ShouldBeSameAs(_loadedEntities);
            }
        }

        [TestFixture]
        public class When_resolving_with_a_suppressed_context_that_was_not_restored
        {
            private TestReferenceData _discarded;

            [SetUp]
            public async Task Setup()
            {
                var context = new ReferenceDataLookupContext();
                _discarded = new TestReferenceData();
                context.Add(_discarded);
                context.Suppress();

                await CreateResolver(new TestContextProvider<ReferenceDataLookupContext>(context)).ResolveReferenceDataAsync();
            }

            [Test]
            public void Should_not_attempt_resolution()
            {
                _discarded.IsFullyDefinedCallCount.ShouldBe(0);
            }
        }

        // -------------------------------------------------------------------------------------------------------------------
        // Write path: existing aggregate retrieval followed by the update of the persisted aggregate
        // -------------------------------------------------------------------------------------------------------------------

        public abstract class When_retrieving_an_existing_aggregate_base
        {
            protected ReferenceDataLookupContext Context;
            protected TestReferenceData RegisteredBeforeRetrieval;
            protected TestReferenceData AddedAfterRetrieval;

            [SetUp]
            public async Task Setup()
            {
                Context = new ReferenceDataLookupContext();

                // Reference data registered while mapping the submitted aggregate, then NHibernate hydration of the
                // existing aggregate suppresses tracking
                RegisteredBeforeRetrieval = new TestReferenceData();
                Context.Add(RegisteredBeforeRetrieval);

                if (SuppressedByRetrieval)
                {
                    Context.Suppress();
                }

                await RetrieveAsync(new TestContextProvider<ReferenceDataLookupContext>(Context));

                AddedAfterRetrieval = new TestReferenceData();
                Context.Add(AddedAfterRetrieval);
            }

            protected virtual bool SuppressedByRetrieval => true;

            protected abstract Task RetrieveAsync(IContextProvider<ReferenceDataLookupContext> contextProvider);
        }

        [TestFixture]
        public class When_upserting_an_existing_aggregate_retrieved_by_key : When_retrieving_an_existing_aggregate_base
        {
            protected override async Task RetrieveAsync(IContextProvider<ReferenceDataLookupContext> contextProvider)
            {
                var getByKey = A.Fake<IGetEntityByKey<TestEntity>>();
                A.CallTo(() => getByKey.GetByKeyAsync(A<TestEntity>._, A<CancellationToken>._)).Returns(new TestEntity());

                await new GetEntityByKeyReferenceDataLookupDecorator<TestEntity>(getByKey, contextProvider)
                    .GetByKeyAsync(new TestEntity(), CancellationToken.None);
            }

            [Test]
            public void Should_resume_tracking_for_the_synchronization()
            {
                Context.IsSuppressed().ShouldBeFalse();
                Context.Items.ShouldContain(AddedAfterRetrieval);
            }

            [Test]
            public void Should_discard_the_lookups_of_the_submitted_aggregate()
            {
                Context.Items.ShouldNotContain(RegisteredBeforeRetrieval);
            }
        }

        [TestFixture]
        public class When_upserting_a_new_aggregate_by_key : When_retrieving_an_existing_aggregate_base
        {
            protected override bool SuppressedByRetrieval => false;

            protected override async Task RetrieveAsync(IContextProvider<ReferenceDataLookupContext> contextProvider)
            {
                var getByKey = A.Fake<IGetEntityByKey<TestEntity>>();
                A.CallTo(() => getByKey.GetByKeyAsync(A<TestEntity>._, A<CancellationToken>._)).Returns((TestEntity) null);

                await new GetEntityByKeyReferenceDataLookupDecorator<TestEntity>(getByKey, contextProvider)
                    .GetByKeyAsync(new TestEntity(), CancellationToken.None);
            }

            [Test]
            public void Should_keep_the_lookups_of_the_submitted_aggregate()
            {
                Context.Items.ShouldContain(RegisteredBeforeRetrieval);
                Context.Items.ShouldContain(AddedAfterRetrieval);
            }
        }

        public abstract class When_retrieving_an_aggregate_by_id_base : When_retrieving_an_existing_aggregate_base
        {
            protected abstract string HttpMethod { get; }

            protected virtual bool Found => true;

            protected override async Task RetrieveAsync(IContextProvider<ReferenceDataLookupContext> contextProvider)
            {
                var getById = A.Fake<IGetEntityById<TestEntity>>();
                A.CallTo(() => getById.GetByIdAsync(A<Guid>._, A<CancellationToken>._)).Returns(Found ? new TestEntity() : null);

                var resourceContextProvider = new TestContextProvider<DataManagementResourceContext>(
                    new DataManagementResourceContext(null, HttpMethod));

                await new GetEntityByIdReferenceDataLookupDecorator<TestEntity>(getById, contextProvider, resourceContextProvider)
                    .GetByIdAsync(Guid.NewGuid(), CancellationToken.None);
            }
        }

        [TestFixture]
        public class When_putting_an_existing_aggregate : When_retrieving_an_aggregate_by_id_base
        {
            protected override string HttpMethod => HttpMethods.Put;

            [Test]
            public void Should_resume_tracking_for_the_synchronization()
            {
                Context.IsSuppressed().ShouldBeFalse();
                Context.Items.ShouldContain(AddedAfterRetrieval);
                Context.Items.ShouldNotContain(RegisteredBeforeRetrieval);
            }
        }

        [TestFixture]
        public class When_putting_an_aggregate_that_does_not_exist : When_retrieving_an_aggregate_by_id_base
        {
            protected override string HttpMethod => HttpMethods.Put;

            protected override bool Found => false;

            [Test]
            public void Should_leave_the_context_unchanged()
            {
                Context.IsSuppressed().ShouldBeTrue();
                Context.Any().ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_getting_an_existing_aggregate_by_id : When_retrieving_an_aggregate_by_id_base
        {
            protected override string HttpMethod => HttpMethods.Get;

            protected override bool SuppressedByRetrieval => false;

            [Test]
            public void Should_leave_the_context_unchanged()
            {
                Context.IsSuppressed().ShouldBeFalse();
                Context.Items.ShouldContain(RegisteredBeforeRetrieval);
            }
        }

        [TestFixture]
        public class When_updating_a_persisted_aggregate
        {
            private IReferenceDataTracker _tracker;
            private IReferenceDataResolver _resolver;
            private IUpdateEntity<TestEntity> _next;
            private TestEntity _entity;

            [SetUp]
            public async Task Setup()
            {
                _tracker = A.Fake<IReferenceDataTracker>();
                _resolver = A.Fake<IReferenceDataResolver>();
                _next = A.Fake<IUpdateEntity<TestEntity>>();
                _entity = new TestEntity();

                await new UpdateEntityReferenceDataLookupDecorator<TestEntity>(_next, _resolver, _tracker)
                    .UpdateAsync(_entity, CancellationToken.None);
            }

            [Test]
            public void Should_track_then_resolve_then_persist()
            {
                A.CallTo(() => _tracker.TrackUnresolvedReferenceData(_entity)).MustHaveHappenedOnceExactly()
                    .Then(A.CallTo(() => _resolver.ResolveReferenceDataAsync()).MustHaveHappenedOnceExactly())
                    .Then(A.CallTo(() => _next.UpdateAsync(_entity, A<CancellationToken>._)).MustHaveHappenedOnceExactly());
            }
        }

        [TestFixture]
        public class When_updating_a_persisted_aggregate_with_unresolved_reference_data
        {
            private ReferenceDataLookupContext _context;
            private TestEntity _entity;
            private List<IEntityReferenceData> _pendingAtResolution;
            private bool _resolvedBeforePersisting;

            [SetUp]
            public async Task Setup()
            {
                _context = new ReferenceDataLookupContext();
                var contextProvider = new TestContextProvider<ReferenceDataLookupContext>(_context);

                _entity = new TestEntity { SchoolSerializedReferenceData = new ReferenceDataTrackerTests.TestReferenceData() };

                var resolver = A.Fake<IReferenceDataResolver>();
                A.CallTo(() => resolver.ResolveReferenceDataAsync())
                    .ReturnsLazily(() =>
                    {
                        _pendingAtResolution = _context.Any() ? new List<IEntityReferenceData>(_context.Items) : new();

                        foreach (var item in _pendingAtResolution)
                        {
                            item.Id = Guid.NewGuid();
                        }

                        return Task.CompletedTask;
                    });

                var next = A.Fake<IUpdateEntity<TestEntity>>();
                A.CallTo(() => next.UpdateAsync(A<TestEntity>._, A<CancellationToken>._))
                    .ReturnsLazily(call =>
                    {
                        _resolvedBeforePersisting = _entity.SchoolSerializedReferenceData.Id.HasValue;

                        return Task.CompletedTask;
                    });

                await new UpdateEntityReferenceDataLookupDecorator<TestEntity>(next, resolver, new ReferenceDataTracker(contextProvider))
                    .UpdateAsync(_entity, CancellationToken.None);
            }

            [Test]
            public void Should_have_the_unresolved_reference_data_pending_when_resolving()
            {
                _pendingAtResolution.ShouldContain(_entity.SchoolSerializedReferenceData);
            }

            [Test]
            public void Should_resolve_the_resource_identifiers_before_persisting()
            {
                _resolvedBeforePersisting.ShouldBeTrue();
            }
        }
    }
}

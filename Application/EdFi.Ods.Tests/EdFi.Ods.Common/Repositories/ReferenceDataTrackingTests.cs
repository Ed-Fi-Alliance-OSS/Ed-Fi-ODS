// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using MessagePack;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Repositories
{
    public class ReferenceDataTrackingTests
    {
        public class TestReferenceData : IEntityReferenceData
        {
            private readonly Action _contextualValuesInitializer;

            public TestReferenceData(bool fullyDefined = true, Action contextualValuesInitializer = null)
            {
                FullyDefined = fullyDefined;
                _contextualValuesInitializer = contextualValuesInitializer;
            }

            public FullName FullName { get; } = new("edfi", "Test");

            public Guid? Id { get; set; }

            public string Discriminator { get; set; }

            public bool FullyDefined { get; set; }

            public bool IsFullyDefined() => FullyDefined;

            // Mirrors generated reference data, where key value getters run any deferred contextual initialization
            public OrderedDictionary GetPrimaryKeyValues()
            {
                _contextualValuesInitializer?.Invoke();

                return new OrderedDictionary();
            }
        }

        public class TestAggregateRoot
        {
            public TestReferenceData SchoolSerializedReferenceData { get; set; }

            // Represents the NHibernate-mapped reference data (possibly a lazy proxy), which must never be accessed
            [IgnoreMember]
            public TestReferenceData SchoolReferenceData => throw new InvalidOperationException("NHibernate reference data accessed.");

            public ICollection<TestChild> Children { get; set; } = new List<TestChild>();
        }

        public class TestChild : IChildEntity
        {
            [DomainSignature]
            public TestAggregateRoot Parent { get; set; }

            public TestReferenceData ClassPeriodSerializedReferenceData { get; set; }

            public ICollection<TestGrandchild> Grandchildren { get; set; } = new List<TestGrandchild>();

            public void SetParent(object value) => Parent = (TestAggregateRoot) value;
        }

        public class TestGrandchild : IChildEntity
        {
            [DomainSignature]
            public TestChild Child { get; set; }

            public TestReferenceData ProgramSerializedReferenceData { get; set; }

            public void SetParent(object value) => Child = (TestChild) value;
        }

        public class TestReferenceDataLookupContextProvider : IContextProvider<ReferenceDataLookupContext>
        {
            private ReferenceDataLookupContext _context;

            public ReferenceDataLookupContext Get() => _context;

            public void Set(ReferenceDataLookupContext context) => _context = context;
        }

        public abstract class When_tracking_unresolved_reference_data_base
        {
            protected ReferenceDataLookupContext Context;

            protected virtual bool SerializedDataEnabled => true;

            [SetUp]
            public void Setup()
            {
                var provider = new TestReferenceDataLookupContextProvider();
                Context = new ReferenceDataLookupContext();
                provider.Set(Context);

                GeneratedArtifactStaticDependencies.Resolvers.Set(() => provider);
                GeneratedArtifactStaticDependencies.Resolvers.SetEnabledFeatures(SerializedDataEnabled, resourceLinksEnabled: true);

                Act();
            }

            [TearDown]
            public void TearDown()
            {
                GeneratedArtifactStaticDependencies.Resolvers.Set(() => (IContextProvider<ReferenceDataLookupContext>) null);
                GeneratedArtifactStaticDependencies.Resolvers.SetEnabledFeatures(false, false);
            }

            protected abstract void Act();
        }

        [TestFixture]
        public class When_tracking_an_aggregate_with_unresolved_reference_data : When_tracking_unresolved_reference_data_base
        {
            private TestAggregateRoot _root;
            private TestChild _child;
            private TestChild _childWithResolvedReference;
            private TestChild _childWithUndefinedReference;
            private TestChild _childWithDeferredInitialization;
            private TestGrandchild _grandchild;

            protected override void Act()
            {
                _root = new TestAggregateRoot { SchoolSerializedReferenceData = new TestReferenceData() };

                _grandchild = new TestGrandchild { ProgramSerializedReferenceData = new TestReferenceData() };
                _child = new TestChild { ClassPeriodSerializedReferenceData = new TestReferenceData(), Grandchildren = { _grandchild } };

                _childWithResolvedReference = new TestChild
                {
                    ClassPeriodSerializedReferenceData = new TestReferenceData { Id = Guid.NewGuid() }
                };

                _childWithUndefinedReference = new TestChild
                {
                    ClassPeriodSerializedReferenceData = new TestReferenceData(fullyDefined: false)
                };

                // Reference data hydrated before its parent was assigned only becomes fully defined once initialized
                var deferredReferenceData = new TestReferenceData(fullyDefined: false);
                deferredReferenceData = new TestReferenceData(fullyDefined: false, () => deferredReferenceData.FullyDefined = true);
                _childWithDeferredInitialization = new TestChild { ClassPeriodSerializedReferenceData = deferredReferenceData };

                foreach (var child in new[] { _child, _childWithResolvedReference, _childWithUndefinedReference, _childWithDeferredInitialization })
                {
                    child.SetParent(_root);
                    _root.Children.Add(child);
                }

                _grandchild.SetParent(_child);

                ReferenceDataTracking.TrackUnresolvedReferenceData(_root);
            }

            [Test]
            public void Should_track_the_aggregate_roots_unresolved_reference_data()
            {
                Context.Items.ShouldContain(_root.SchoolSerializedReferenceData);
            }

            [Test]
            public void Should_track_unresolved_reference_data_of_children()
            {
                Context.Items.ShouldContain(_child.ClassPeriodSerializedReferenceData);
            }

            [Test]
            public void Should_track_unresolved_reference_data_of_nested_children()
            {
                Context.Items.ShouldContain(_grandchild.ProgramSerializedReferenceData);
            }

            [Test]
            public void Should_track_reference_data_that_is_fully_defined_after_deferred_initialization()
            {
                Context.Items.ShouldContain(_childWithDeferredInitialization.ClassPeriodSerializedReferenceData);
            }

            [Test]
            public void Should_not_track_reference_data_that_is_already_resolved()
            {
                Context.Items.ShouldNotContain(_childWithResolvedReference.ClassPeriodSerializedReferenceData);
            }

            [Test]
            public void Should_not_track_reference_data_that_is_not_fully_defined()
            {
                Context.Items.ShouldNotContain(_childWithUndefinedReference.ClassPeriodSerializedReferenceData);
            }

            [Test]
            public void Should_track_each_unresolved_reference_exactly_once()
            {
                Context.Items.Count.ShouldBe(4);
            }
        }

        [TestFixture]
        public class When_tracking_a_child_whose_parent_has_unresolved_reference_data : When_tracking_unresolved_reference_data_base
        {
            private TestAggregateRoot _root;
            private TestChild _child;

            protected override void Act()
            {
                _root = new TestAggregateRoot { SchoolSerializedReferenceData = new TestReferenceData() };
                _child = new TestChild { ClassPeriodSerializedReferenceData = new TestReferenceData() };
                _child.SetParent(_root);

                ReferenceDataTracking.TrackUnresolvedReferenceData(_child);
            }

            [Test]
            public void Should_not_walk_up_to_the_parent()
            {
                Context.Items.ShouldNotContain(_root.SchoolSerializedReferenceData);
                Context.Items.ShouldContain(_child.ClassPeriodSerializedReferenceData);
            }
        }

        [TestFixture]
        public class When_tracking_with_serialized_data_disabled : When_tracking_unresolved_reference_data_base
        {
            protected override bool SerializedDataEnabled => false;

            protected override void Act()
            {
                ReferenceDataTracking.TrackUnresolvedReferenceData(
                    new TestAggregateRoot { SchoolSerializedReferenceData = new TestReferenceData() });
            }

            [Test]
            public void Should_not_track_any_reference_data()
            {
                Context.Any().ShouldBeFalse();
            }
        }
    }
}

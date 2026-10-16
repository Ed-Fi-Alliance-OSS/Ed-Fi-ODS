// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Features.SerializedData.Repositories;
using MessagePack;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.SerializedData.Repositories
{
    public class ReferenceDataTrackerTests
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

            // Mirrors the generated (non-generic) aggregate extensions dictionary, keyed by extension schema name
            public IDictionary AggregateExtensions { get; set; } = new Dictionary<string, object>();
        }

        public class TestChild : IChildEntity
        {
            [DomainSignature]
            public TestAggregateRoot Parent { get; set; }

            public TestReferenceData ClassPeriodSerializedReferenceData { get; set; }

            public ICollection<TestGrandchild> Grandchildren { get; set; } = new List<TestGrandchild>();

            // A reference to another child that is not part of the domain signature (allows a non-parent cycle)
            public TestChild Sibling { get; set; }

            public void SetParent(object value) => Parent = (TestAggregateRoot) value;
        }

        public class TestGrandchild : IChildEntity
        {
            [DomainSignature]
            public TestChild Child { get; set; }

            public TestReferenceData ProgramSerializedReferenceData { get; set; }

            public void SetParent(object value) => Child = (TestChild) value;
        }

        public class TestExtension : IChildEntity
        {
            public TestReferenceData ExtensionSerializedReferenceData { get; set; }

            public ICollection<TestChild> ExtensionChildren { get; set; } = new List<TestChild>();

            public void SetParent(object value) { }
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

            protected virtual bool ContextInitialized => true;

            [SetUp]
            public void Setup()
            {
                var provider = new TestReferenceDataLookupContextProvider();
                Context = new ReferenceDataLookupContext();

                if (ContextInitialized)
                {
                    provider.Set(Context);
                }

                Act(new ReferenceDataTracker(provider));
            }

            protected abstract void Act(IReferenceDataTracker tracker);
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

            protected override void Act(IReferenceDataTracker tracker)
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

                tracker.TrackUnresolvedReferenceData(_root);
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

            protected override void Act(IReferenceDataTracker tracker)
            {
                _root = new TestAggregateRoot { SchoolSerializedReferenceData = new TestReferenceData() };
                _child = new TestChild { ClassPeriodSerializedReferenceData = new TestReferenceData() };
                _child.SetParent(_root);

                tracker.TrackUnresolvedReferenceData(_child);
            }

            [Test]
            public void Should_not_walk_up_to_the_parent()
            {
                Context.Items.ShouldNotContain(_root.SchoolSerializedReferenceData);
                Context.Items.ShouldContain(_child.ClassPeriodSerializedReferenceData);
            }
        }

        [TestFixture]
        public class When_tracking_an_aggregate_with_extensions : When_tracking_unresolved_reference_data_base
        {
            private TestExtension _extension;
            private TestChild _extensionChild;

            protected override void Act(IReferenceDataTracker tracker)
            {
                _extensionChild = new TestChild { ClassPeriodSerializedReferenceData = new TestReferenceData() };

                _extension = new TestExtension
                {
                    ExtensionSerializedReferenceData = new TestReferenceData(),
                    ExtensionChildren = { _extensionChild }
                };

                var root = new TestAggregateRoot { AggregateExtensions = { ["Sample"] = _extension } };

                tracker.TrackUnresolvedReferenceData(root);
            }

            [Test]
            public void Should_track_unresolved_reference_data_of_the_extension()
            {
                Context.Items.ShouldContain(_extension.ExtensionSerializedReferenceData);
            }

            [Test]
            public void Should_track_unresolved_reference_data_of_extension_collections()
            {
                Context.Items.ShouldContain(_extensionChild.ClassPeriodSerializedReferenceData);
            }
        }

        [TestFixture]
        public class When_tracking_an_aggregate_whose_children_reference_each_other : When_tracking_unresolved_reference_data_base
        {
            private TestChild _first;
            private TestChild _second;

            protected override void Act(IReferenceDataTracker tracker)
            {
                var root = new TestAggregateRoot();

                _first = new TestChild { ClassPeriodSerializedReferenceData = new TestReferenceData() };
                _second = new TestChild { ClassPeriodSerializedReferenceData = new TestReferenceData() };

                // Non-parent cycle, with each child also reachable through more than one path
                _first.Sibling = _second;
                _second.Sibling = _first;

                root.Children.Add(_first);
                root.Children.Add(_second);
                root.AggregateExtensions["Sample"] = _first;

                tracker.TrackUnresolvedReferenceData(root);
            }

            [Test]
            public void Should_terminate_and_track_each_reference_exactly_once()
            {
                Context.Items.Count.ShouldBe(2);
                Context.Items.ShouldContain(_first.ClassPeriodSerializedReferenceData);
                Context.Items.ShouldContain(_second.ClassPeriodSerializedReferenceData);
            }
        }

        [TestFixture]
        public class When_tracking_without_a_reference_data_lookup_context : When_tracking_unresolved_reference_data_base
        {
            private Exception _exception;

            protected override bool ContextInitialized => false;

            protected override void Act(IReferenceDataTracker tracker)
            {
                try
                {
                    tracker.TrackUnresolvedReferenceData(
                        new TestAggregateRoot { SchoolSerializedReferenceData = new TestReferenceData() });
                }
                catch (Exception ex)
                {
                    _exception = ex;
                }
            }

            [Test]
            public void Should_not_throw()
            {
                _exception.ShouldBeNull();
            }

            [Test]
            public void Should_not_track_any_reference_data()
            {
                Context.Any().ShouldBeFalse();
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Specialized;
using System.Linq;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Repositories;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Repositories
{
    public class ReferenceDataLookupContextTests
    {
        public class TestReferenceData : IEntityReferenceData
        {
            public FullName FullName { get; } = new("edfi", "Test");

            public Guid? Id { get; set; }

            public string Discriminator { get; set; }

            public bool IsFullyDefined() => true;

            public OrderedDictionary GetPrimaryKeyValues() => new();
        }

        [TestFixture]
        public class When_suppressing_after_items_have_been_added
        {
            private ReferenceDataLookupContext _context;
            private TestReferenceData _addedAfterSuppression;
            private bool _addAfterSuppressionResult;

            [SetUp]
            public void Setup()
            {
                _context = new ReferenceDataLookupContext();
                _context.Add(new TestReferenceData());
                _context.Suppress();

                _addedAfterSuppression = new TestReferenceData();
                _addAfterSuppressionResult = _context.Add(_addedAfterSuppression);
            }

            [Test]
            public void Should_discard_items_added_before_suppression()
            {
                _context.Any().ShouldBeFalse();
            }

            [Test]
            public void Should_ignore_items_added_after_suppression()
            {
                _addAfterSuppressionResult.ShouldBeFalse();
            }

            [Test]
            public void Should_report_suppressed()
            {
                _context.IsSuppressed().ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_restoring_pending_items_after_suppression
        {
            private ReferenceDataLookupContext _context;
            private TestReferenceData _pendingBeforeSuppression;
            private TestReferenceData _addedAfterSuppression;

            [SetUp]
            public void Setup()
            {
                _context = new ReferenceDataLookupContext();
                _pendingBeforeSuppression = new TestReferenceData();
                _context.Add(_pendingBeforeSuppression);

                var pendingItems = _context.Items.ToArray();

                // e.g. NHibernate hydration of other aggregates in the same request
                _context.Suppress();
                _addedAfterSuppression = new TestReferenceData();
                _context.Add(_addedAfterSuppression);

                _context.Restore(pendingItems);
            }

            [Test]
            public void Should_contain_the_restored_items()
            {
                _context.Any().ShouldBeTrue();
                _context.Items.ShouldContain(_pendingBeforeSuppression);
            }

            [Test]
            public void Should_not_contain_items_added_while_suppressed()
            {
                _context.Items.ShouldNotContain(_addedAfterSuppression);
            }

            [Test]
            public void Should_remain_suppressed()
            {
                _context.IsSuppressed().ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_resetting_a_suppressed_context
        {
            private ReferenceDataLookupContext _context;
            private TestReferenceData _addedAfterReset;

            [SetUp]
            public void Setup()
            {
                _context = new ReferenceDataLookupContext();
                _context.Add(new TestReferenceData());
                _context.Suppress();

                _context.Reset();

                _addedAfterReset = new TestReferenceData();
                _context.Add(_addedAfterReset);
            }

            [Test]
            public void Should_no_longer_be_suppressed()
            {
                _context.IsSuppressed().ShouldBeFalse();
            }

            [Test]
            public void Should_only_contain_items_added_after_the_reset()
            {
                _context.Items.Count.ShouldBe(1);
                _context.Items.ShouldContain(_addedAfterReset);
            }
        }
    }
}

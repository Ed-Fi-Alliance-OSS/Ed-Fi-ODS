// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Api.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    public class IListExtensionsTests
    {
        public class SynchronizableTestObject : ISynchronizable
        {
            public bool Synchronize(object target)
            {
                return false;
            }
        }

        public abstract class When_synchronizing_list_base
        {
            protected Func<SynchronizableTestObject, bool> IncludeItemFunction;

            protected bool IsModified;

            protected SynchronizableTestObject Object1 = new SynchronizableTestObject();
            protected SynchronizableTestObject Object2 = new SynchronizableTestObject();
            protected Action<SynchronizableTestObject> OnChildAddedCallback;
            protected List<SynchronizableTestObject> SourceList;
            protected List<SynchronizableTestObject> TargetList;

            [SetUp]
            public void Setup()
            {
                SourceList = GetSourceList();
                TargetList = GetTargetList();
                IsModified = SourceList.SynchronizeCollectionTo(TargetList, OnChildAddedCallback, IncludeItemFunction);
            }

            protected abstract List<SynchronizableTestObject> GetSourceList();

            protected abstract List<SynchronizableTestObject> GetTargetList();
        }

        [TestFixture]
        public class When_synchronizing_empty_source_list_to_empty_target_list : When_synchronizing_list_base
        {
            protected override List<SynchronizableTestObject> GetSourceList()
            {
                return new List<SynchronizableTestObject>();
            }

            protected override List<SynchronizableTestObject> GetTargetList()
            {
                return new List<SynchronizableTestObject>();
            }

            [Test]
            public void Should_return_is_not_modified()
            {
                IsModified.ShouldBeFalse();
            }

            [Test]
            public void Should_return_valid_target_list()
            {
                TargetList.ShouldBeEmpty();
            }
        }

        [TestFixture]
        public class When_synchronizing_empty_source_list_to_existing_target_list : When_synchronizing_list_base
        {
            protected override List<SynchronizableTestObject> GetSourceList()
            {
                return new List<SynchronizableTestObject>();
            }

            protected override List<SynchronizableTestObject> GetTargetList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object1
                       };
            }

            [Test]
            public void Should_return_is_modified()
            {
                IsModified.ShouldBeTrue();
            }

            [Test]
            public void Should_return_valid_target_list()
            {
                TargetList.ShouldBeEmpty();
            }
        }

        [TestFixture]
        public class When_synchronizing_new_source_list_to_empty_target_list : When_synchronizing_list_base
        {
            protected override List<SynchronizableTestObject> GetSourceList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object1
                       };
            }

            protected override List<SynchronizableTestObject> GetTargetList()
            {
                return new List<SynchronizableTestObject>();
            }

            [Test]
            public void Should_return_is_modified()
            {
                IsModified.ShouldBeTrue();
            }

            [Test]
            public void Should_return_valid_target_list()
            {
                TargetList.Count.ShouldBe(1);
                TargetList.ShouldContain(Object1);
            }
        }

        [TestFixture]
        public class When_synchronizing_new_source_list_to_existing_target_list : When_synchronizing_list_base
        {
            protected override List<SynchronizableTestObject> GetSourceList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object1
                       };
            }

            protected override List<SynchronizableTestObject> GetTargetList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object2
                       };
            }

            [Test]
            public void Should_return_is_modified()
            {
                IsModified.ShouldBeTrue();
            }

            [Test]
            public void Should_return_valid_target_list()
            {
                TargetList.Count.ShouldBe(1);
                TargetList.ShouldContain(Object1);
            }
        }

        [TestFixture]
        public class When_synchronizing_new_source_list_with_duplicates_to_empty_target_list : When_synchronizing_list_base
        {
            protected override List<SynchronizableTestObject> GetSourceList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object1, Object1
                       };
            }

            protected override List<SynchronizableTestObject> GetTargetList()
            {
                return new List<SynchronizableTestObject>();
            }

            [Test]
            public void Should_return_is_modified()
            {
                IsModified.ShouldBeTrue();
            }

            [Test]
            public void Should_return_valid_target_list()
            {
                // TODO: Should be 2 once synchronize is fixed to use Where instead of Except
                // See https://tracker.ed-fi.org/browse/ODS-900
                TargetList.Count.ShouldBe(1);

                TargetList.All(ti => ti == Object1)
                          .ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_synchronizing_new_source_list_to_existing_target_list_with_duplicates : When_synchronizing_list_base
        {
            protected override List<SynchronizableTestObject> GetSourceList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object1
                       };
            }

            protected override List<SynchronizableTestObject> GetTargetList()
            {
                return new List<SynchronizableTestObject>
                       {
                           Object2, Object2
                       };
            }

            [Test]
            public void Should_return_is_modified()
            {
                IsModified.ShouldBeTrue();
            }

            [Test]
            public void Should_return_valid_target_list()
            {
                TargetList.Count.ShouldBe(1);
                TargetList.ShouldContain(Object1);
            }
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Resource;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using EdFi.TestFixture;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ExcludeOnlyMemberFilterTests
    {
        public class When_filtering_ExcludeOnlyMemberFilter_and_members_are_found : TestFixtureBase
        {
            private IMemberFilter _filter;
            private bool _expectedResult;
            private bool _actualResult;

            protected override void Arrange()
            {
                base.Arrange();
                _expectedResult = false;

                _filter = FilterTestsHelper.CreateExcludeOnlyMemberFilter();
            }

            protected override void Act()
            {
                _actualResult = _filter.ShouldInclude(FilterTestsHelper.PropertyNameArray[2]);
            }

            [Test]
            public void Assert_that_member_should_not_be_included()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_filtering_ExcludeOnlyMemberFilter_and_passing_Id : TestFixtureBase
        {
            private IMemberFilter _filter;

            private bool _expectedResult;
            private bool _actualResult;

            protected override void Arrange()
            {
                base.Arrange();
                _expectedResult = true;

                _filter = FilterTestsHelper.CreateExcludeOnlyMemberFilter();
            }

            protected override void Act()
            {
                _actualResult = _filter.ShouldInclude("Id");
            }

            [Test]
            public void Assert_that_member_should_be_included()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_filtering_ExcludeOnlyMemberFilter_and_members_are_not_found : TestFixtureBase
        {
            private IMemberFilter _filter;
            private bool _expectedResult;
            private bool _actualResult;

            protected override void Arrange()
            {
                base.Arrange();
                _expectedResult = true;

                _filter = FilterTestsHelper.CreateExcludeOnlyMemberFilter();
            }

            protected override void Act()
            {
                _actualResult = _filter.ShouldInclude("Bogus");
            }

            [Test]
            public void Assert_that_member_should_be_included()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_filtering_ExcludeOnlyMemberFilter_and_extensions_are_found : TestFixtureBase
        {
            private IMemberFilter _filter;
            private bool _expectedResult;
            private bool _actualResult;

            protected override void Arrange()
            {
                base.Arrange();
                _expectedResult = false;

                _filter = FilterTestsHelper.CreateExcludeOnlyMemberFilter();
            }

            protected override void Act()
            {
                _actualResult = _filter.ShouldIncludeExtension(FilterTestsHelper.ExtensionNameArray[2]);
            }

            [Test]
            public void Assert_that_member_should_be_included()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }

        public class When_filtering_ExcludeOnlyMemberFilter_and_extensions_are_not_found : TestFixtureBase
        {
            private IMemberFilter _filter;
            private bool _expectedResult;
            private bool _actualResult;

            protected override void Arrange()
            {
                base.Arrange();
                _expectedResult = true;

                _filter = FilterTestsHelper.CreateExcludeOnlyMemberFilter();
            }

            protected override void Act()
            {
                _actualResult = _filter.ShouldIncludeExtension("BadName");
            }

            [Test]
            public void Assert_that_member_should_not_be_included()
            {
                Assert.That(_actualResult, Is.EqualTo(_expectedResult));
            }
        }
    }
}

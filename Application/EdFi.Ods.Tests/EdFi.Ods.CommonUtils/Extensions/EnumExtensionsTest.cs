// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Utils.Extensions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.CommonUtils.Extensions
{
    /// <summary>
    ///This is a test class for EnumExtensionsTest and is intended
    ///to contain all EnumExtensionsTest Unit Tests
    ///</summary>
    [TestFixture]
    public class EnumExtensionsTest
    {
        public enum TestEnum
        {
            one,
            Two,
            THREE,
            NumberFour,
            ILikeSDE
        }

        public enum TestEnum16 : short
        {
            one,
            Two,
            THREE,
            NumberFour,
            ILikeSDE
        }

        [Flags]
        public enum TestFlagsEnum
        {
            None = 0,
            TooTall = 1,
            TooHeavy = 1 << 1,
            TooAfraid = 1 << 2,
            All = (1 << 3) - 1
        }

        [Flags]
        private enum TestFlagsEnum64 : long
        {
            None = 0,
            TooTall = 1,
            TooHeavy = 1 << 1,
            TooAfraid = 1 << 2,
            All = (1 << 3) - 1
        }

        [Flags]
        private enum TestFlagsEnum16 : short
        {
            None = 0,
            TooTall = 1,
            TooHeavy = 1 << 1,
            TooAfraid = 1 << 2,
            All = (1 << 3) - 1
        }

        private const string SecondDesc = "My * Second * One";

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///In should give false when a value is not among a set of 3 values
        ///</summary>
        [Test]
        public void InShouldGiveFalseWhen1NotAmong3()
        {
            TestEnum value = TestEnum.NumberFour;
            bool expected = false;
            bool actual = value.In(TestEnum.Two, TestEnum.ILikeSDE, TestEnum.one);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should give true when a value is among a set of 1 values 
        ///</summary>
        [Test]
        public void InShouldGiveTrueWhen1Among1()
        {
            TestEnum value = TestEnum.one;
            bool expected = true;
            bool actual = value.In(TestEnum.one);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should give true when a value is among a set of 2 values
        ///</summary>
        [Test]
        public void InShouldGiveTrueWhen1Among2()
        {
            TestEnum value = TestEnum.one;
            bool expected = true;
            bool actual = value.In(TestEnum.Two, TestEnum.one);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should give true when a value is among a set of 3 values
        ///</summary>
        [Test]
        public void InShouldGiveTrueWhen1Among3()
        {
            TestEnum value = TestEnum.one;
            bool expected = true;
            bool actual = value.In(TestEnum.Two, TestEnum.ILikeSDE, TestEnum.one);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should return false when a multiple flag value is only partially included in the set of values
        ///</summary>
        [Test]
        public void InShouldReturnFalseWhenMultipleFlagsPartiallyInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooAfraid | TestFlagsEnum.TooTall;
            TestFlagsEnum flags = TestFlagsEnum.TooAfraid | TestFlagsEnum.TooHeavy;
            bool expected = false;
            bool actual = value.In(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should return false when a single flag value is not in the set of values
        ///</summary>
        [Test]
        public void InShouldReturnFalseWhenSingleFlagNotInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooTall;
            TestFlagsEnum flags = TestFlagsEnum.TooHeavy | TestFlagsEnum.TooAfraid;
            bool expected = false;
            bool actual = value.In(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should return true when a multiple flag value is completely included in the set of values
        ///</summary>
        [Test]
        public void InShouldReturnTrueWhenMultipleFlagsInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooTall | TestFlagsEnum.TooAfraid;
            TestFlagsEnum flags = TestFlagsEnum.All;
            bool expected = true;
            bool actual = value.In(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should return true when a single flag value is in the set of values
        ///</summary>
        [Test]
        public void InShouldReturnTrueWhenSingleFlagInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooTall;
            TestFlagsEnum flags = TestFlagsEnum.TooHeavy | TestFlagsEnum.TooTall;
            bool expected = true;
            bool actual = value.In(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should work with Int16 enums
        ///</summary>
        [Test]
        public void InShouldWorkWithInt16Enums()
        {
            TestFlagsEnum16 value = TestFlagsEnum16.TooTall;
            TestFlagsEnum16 flags = TestFlagsEnum16.TooHeavy | TestFlagsEnum16.TooTall;
            bool expected = true;
            bool actual = value.In(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///In should work with Int64 enums
        ///</summary>
        [Test]
        public void InShouldWorkWithInt64Enums()
        {
            TestFlagsEnum64 value = TestFlagsEnum64.TooTall;
            TestFlagsEnum64 flags = TestFlagsEnum64.TooHeavy | TestFlagsEnum64.TooTall;
            bool expected = true;
            bool actual = value.In(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Intersects should return false when a single flag value is not in the set of values
        ///</summary>
        [Test]
        public void IntersectsShouldReturnFalseWhenSingleFlagNotInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooHeavy | TestFlagsEnum.TooTall;
            TestFlagsEnum flags = TestFlagsEnum.TooAfraid;
            bool expected = false;
            bool actual = value.Intersects(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Intersects should return true when a multiple flag value is completely included in the set of values
        ///</summary>
        [Test]
        public void IntersectsShouldReturnTrueWhenMultipleFlagsInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.All;
            TestFlagsEnum flags = TestFlagsEnum.TooTall | TestFlagsEnum.TooAfraid;
            bool expected = true;
            bool actual = value.Intersects(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Intersects should return false when a multiple flag value is only partially included in the set of values
        ///</summary>
        [Test]
        public void IntersectsShouldReturnTrueWhenMultipleFlagsPartiallyInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooAfraid | TestFlagsEnum.TooHeavy;
            TestFlagsEnum flags = TestFlagsEnum.TooAfraid | TestFlagsEnum.TooTall;
            bool expected = true;
            bool actual = value.Intersects(flags);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Intersects should return true when a single flag value is in the set of values
        ///</summary>
        [Test]
        public void IntersectsShouldReturnTrueWhenSingleFlagInSet()
        {
            TestFlagsEnum value = TestFlagsEnum.TooHeavy | TestFlagsEnum.TooTall;
            TestFlagsEnum flags = TestFlagsEnum.TooTall;
            bool expected = true;
            bool actual = value.Intersects(flags);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_return_enum_name_when_calling_GetName()
        {
            StringComparison.InvariantCulture.GetName()
                            .ShouldBe("InvariantCulture");
        }

        /// <summary>
        ///ToEnum should do what Enum.Parse does
        ///</summary>
        [Test]
        public void ToEnumShouldDoWhatEnumParseDoes()
        {
            TestEnum expected = TestEnum.NumberFour;
            TestEnum actual = "NumberFour".ToEnum<TestEnum>();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ToEnum should ignore spaces
        ///</summary>
        [Test]
        public void ToEnumShouldIgnoreSpaces()
        {
            TestEnum expected = TestEnum.NumberFour;
            TestEnum actual = "   Number     Four ".ToEnum<TestEnum>();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///ToEnum should do what Enum.Parse does with Int16 enums
        ///</summary>
        [Test]
        public void ToEnumShouldWorkWithInt16Enums()
        {
            TestEnum16 expected = TestEnum16.NumberFour;
            TestEnum16 actual = "NumberFour".ToEnum<TestEnum16>();
            Assert.AreEqual(expected, actual);
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Models.Domain;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_comparing_FQNs_with_different_casing : TestFixtureBase
    {
        private FullName _lowerFullName;
        private FullName _upperFullName;

        protected override void Act()
        {
            _lowerFullName = new FullName("schema", "name");
            _upperFullName = new FullName("SCHEMA", "NAME");
        }

        [Assert]
        public void Should_indicate_they_are_equal_using_the_Equals_method()
        {
            Assert.That(_lowerFullName.Equals(_upperFullName), Is.True);
        }

        [Test]
        public virtual void Should_indicate_they_are_NOT_the_same_using_inequality_operator()
        {
            Assert.That(_lowerFullName != _upperFullName, Is.False);
        }

        [Test]
        public virtual void Should_indicate_they_are_the_same_using_equality_operator()
        {
            Assert.That(_lowerFullName == _upperFullName, Is.True);
        }

        [Test]
        public virtual void Should_return_the_same_GetHashCode_result()
        {
            Assert.That(_lowerFullName.GetHashCode(), Is.EqualTo(_upperFullName.GetHashCode()));
        }
    }
}

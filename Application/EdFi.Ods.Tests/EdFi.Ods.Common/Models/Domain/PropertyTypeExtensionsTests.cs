// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Models.Domain;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PropertyTypeExtensionsTests
    {
        public class When_requesting_underlying_system_type_for_a_non_nullable_PropertyType : TestFixtureBase
        {
            private Type _actualUnderlyingType;

            protected override void Act()
            {
                var propertyType = new PropertyType(DbType.Int32, 0, 10, 0, isNullable: false);
                _actualUnderlyingType = propertyType.ToUnderlyingSystemType();
            }

            [Assert]
            public void Should_return_the_corresponding_non_nullable_system_type()
            {
                Assert.That(_actualUnderlyingType, Is.EqualTo(typeof(Int32)));
            }
        }

        public class When_requesting_underlying_system_type_for_a_nullable_PropertyType : TestFixtureBase
        {
            private Type _actualUnderlyingType;

            protected override void Act()
            {
                var propertyType = new PropertyType(DbType.Int32, 0, 10, 0, isNullable: true);
                _actualUnderlyingType = propertyType.ToUnderlyingSystemType();
            }

            [Assert]
            public void Should_return_the_corresponding_nullable_system_type()
            {
                Assert.That(_actualUnderlyingType, Is.EqualTo(typeof(Int32)));
            }
        }

        public class When_requesting_the_system_type_for_a_non_nullable_PropertyType : TestFixtureBase
        {
            private Type _actualUnderlyingType;

            protected override void Act()
            {
                var propertyType = new PropertyType(DbType.Int32, 0, 10, 0, isNullable: false);
                _actualUnderlyingType = propertyType.ToSystemType();
            }

            [Assert]
            public void Should_return_the_corresponding_non_nullable_system_type()
            {
                Assert.That(_actualUnderlyingType, Is.EqualTo(typeof(Int32)));
            }
        }

        public class When_requesting_the_system_type_for_a_nullable_PropertyType : TestFixtureBase
        {
            private Type _actualUnderlyingType;

            protected override void Act()
            {
                var propertyType = new PropertyType(DbType.Int32, 0, 10, 0, isNullable: true);
                _actualUnderlyingType = propertyType.ToSystemType();
            }

            [Assert]
            public void Should_return_the_corresponding_non_nullable_system_type()
            {
                Assert.That(_actualUnderlyingType, Is.EqualTo(typeof(Int32?)));
            }
        }
    }
}

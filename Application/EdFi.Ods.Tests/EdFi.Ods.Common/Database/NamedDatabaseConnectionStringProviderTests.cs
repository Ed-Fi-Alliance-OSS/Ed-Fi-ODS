// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Database;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NamedDatabaseConnectionStringProviderTests
    {
        [TestFixture]
        public class When_calling_the_NamedDatabaseConnectionStringProvider_with_a_valid_name_and_standard_security
        {
            [Test]
            public void Should_Get_Named_Connection_string()
            {
                const string suppliedConnectionStringName = "TestStandardConnectionString";

                var expected = ConfigurationManager.ConnectionStrings[suppliedConnectionStringName]
                                                   .ToString();

                var provider = new NamedDatabaseConnectionStringProvider(suppliedConnectionStringName);
                var actual = provider.GetConnectionString();
                actual.ShouldBe(expected);
            }
        }

        [TestFixture]
        public class When_calling_the_NamedDatabaseConnectionStringProvider_with_a_valid_name_and_integrated_security
        {
            [Test]
            public void Should_Get_Named_Connection_string()
            {
                const string suppliedConnectionStringName = "TestIntegratedConnectionString";

                var expected = ConfigurationManager.ConnectionStrings[suppliedConnectionStringName]
                                                   .ToString();

                var provider = new NamedDatabaseConnectionStringProvider(suppliedConnectionStringName);
                var actual = provider.GetConnectionString();
                actual.ShouldBe(expected);
            }
        }

        [TestFixture]
        public class When_calling_the_NamedDatabaseConnectionStringProvider_with_a_NULL_name : TestBase
        {
            private ArgumentNullException _thrown;

            [OneTimeSetUp]
            public void Setup()
            {
                var provider = new NamedDatabaseConnectionStringProvider(null);
                _thrown = TestForException<ArgumentNullException>(() => provider.GetConnectionString());
            }

            [Test]
            public void Should_throw_an_exception()
            {
                _thrown.ShouldNotBeNull();
                _thrown.Message.ShouldContain("connectionStringName");
            }
        }

        [TestFixture]
        public class When_calling_the_NamedDatabaseConnectionStringProvider_with_a_EMPTY_name : TestBase
        {
            private ArgumentNullException _thrown;

            [OneTimeSetUp]
            public void Setup()
            {
                var provider = new NamedDatabaseConnectionStringProvider(string.Empty);
                _thrown = TestForException<ArgumentNullException>(() => provider.GetConnectionString());
            }

            [Test]
            public void Should_throw_an_exception()
            {
                _thrown.ShouldNotBeNull();
                _thrown.Message.ShouldContain("connectionStringName");
            }
        }

        [TestFixture]
        public class When_calling_the_NamedDatabaseConnectionStringProvider_with_a_WHITESPACE_name : TestBase
        {
            private ArgumentNullException _thrown;

            [OneTimeSetUp]
            public void Setup()
            {
                var provider = new NamedDatabaseConnectionStringProvider(" ");
                _thrown = TestForException<ArgumentNullException>(() => provider.GetConnectionString());
            }

            [Test]
            public void Should_throw_an_exception()
            {
                _thrown.ShouldNotBeNull();
                _thrown.Message.ShouldContain("connectionStringName");
            }
        }
    }
}

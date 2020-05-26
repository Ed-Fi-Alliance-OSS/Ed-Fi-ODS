// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Configuration
{
    public class DatabaseEngineProviderTests
    {
        public class When_getting_multiple_valid_database_types_that_are_the_same : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private DatabaseEngine _result;
            private DatabaseEngineProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(
                        new Dictionary<string, string>
                        {
                            {"db", ApiConfigurationConstants.SqlServerProviderName},
                            {"db2", ApiConfigurationConstants.SqlServerProviderName}
                        });

                _systemUnderTest = new DatabaseEngineProvider(_configConnectionStringsProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.DatabaseEngine;
            }

            [Test]
            public void Should_have_database_type_of_sqlserver()
            {
                _result.ShouldBe(DatabaseEngine.SqlServer);
            }
        }

        public class When_getting_mixed_valid_database_types : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;

            protected override void Arrange()
            {
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(
                        new Dictionary<string, string>
                        {
                            {"db", ApiConfigurationConstants.SqlServerProviderName},
                            {"db2", ApiConfigurationConstants.PostgresProviderName}
                        });
            }

            protected override void Act()
            {
                _ = new DatabaseEngineProvider(_configConnectionStringsProvider);
            }

            [Test]
            public void Should_throw_NotSupportedException()
            {
                ActualException.ShouldBeOfType<NotSupportedException>();
            }
        }

        public class When_getting_sqlserver_database_type : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private DatabaseEngine _result;
            private DatabaseEngineProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> {{"db", ApiConfigurationConstants.SqlServerProviderName}});

                _systemUnderTest = new DatabaseEngineProvider(_configConnectionStringsProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.DatabaseEngine;
            }

            [Test]
            public void Should_have_database_type_of_sqlserver()
            {
                _result.ShouldBe(DatabaseEngine.SqlServer);
            }
        }

        public class When_getting_postgres_database_type : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;
            private DatabaseEngine _result;
            private DatabaseEngineProvider _systemUnderTest;

            protected override void Arrange()
            {
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> {{"db", ApiConfigurationConstants.PostgresProviderName}});

                _systemUnderTest = new DatabaseEngineProvider(_configConnectionStringsProvider);
            }

            protected override void Act()
            {
                _result = _systemUnderTest.DatabaseEngine;
            }

            [Test]
            public void Should_have_database_type_of_sqlserver()
            {
                _result.ShouldBe(DatabaseEngine.Postgres);
            }
        }

        public class When_getting_an_invalid_database_type : TestFixtureBase
        {
            private IConfigConnectionStringsProvider _configConnectionStringsProvider;

            protected override void Arrange()
            {
                _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

                A.CallTo(() => _configConnectionStringsProvider.ConnectionStringProviderByName)
                    .Returns(new Dictionary<string, string> { { "db", "invalid" } });
            }

            protected override void Act()
            {
                _ = new DatabaseEngineProvider(_configConnectionStringsProvider);
            }

            [Test]
            public void Should_throw_NotSupportedException()
            {
                ActualException.ShouldBeOfType<NotSupportedException>();
            }
        }
    }
}

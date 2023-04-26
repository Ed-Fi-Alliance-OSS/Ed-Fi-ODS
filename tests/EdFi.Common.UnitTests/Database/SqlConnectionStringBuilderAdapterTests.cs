// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Database;
using EdFi.TestFixture;
using Microsoft.Data.SqlClient;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    [TestFixture]
    public class SqlConnectionStringBuilderAdapterTests
    {
        public class When_getting_and_setting_the_database_name_in_a_SQL_Server_connection_string
            : TestFixtureBase
        {
            private string _actualInitialDatabaseName;
            private string _actualModifiedDatabaseName;
            private string _actualFinalConnectionString;

            private const string SqlServerConnectionStringFormat = @"Server=(local);Database={0};trusted_connection=True;Application Name=EdFi.Ods.WebApi;";

            protected override void Act()
            {
                var adapter = new SqlConnectionStringBuilderAdapter();

                adapter.ConnectionString = string.Format(SqlServerConnectionStringFormat, "OriginalDatabaseName");
                _actualInitialDatabaseName = adapter.DatabaseName;

                adapter.DatabaseName = "ModifiedDatabaseName";
                _actualModifiedDatabaseName = adapter.DatabaseName;

                _actualFinalConnectionString = adapter.ConnectionString;
            }

            [Test]
            public void Should_initially_return_the_database_name_from_the_connection_string()
            {
                _actualInitialDatabaseName.ShouldBe("OriginalDatabaseName");
            }

            [Test]
            public void Should_return_the_modified_database_name_after_it_has_been_changed()
            {
                _actualModifiedDatabaseName.ShouldBe("ModifiedDatabaseName");
            }

            [Test]
            public void Should_incorporate_modified_database_name_into_connection_string_returned_by_the_adapter()
            {
                string formattedConnectionString = string.Format(
                    SqlServerConnectionStringFormat, "ModifiedDatabaseName");

                var builder = new SqlConnectionStringBuilder(formattedConnectionString);
                string expectedConnectionString = builder.ConnectionString;

                _actualFinalConnectionString.ShouldBe(expectedConnectionString);
            }
        }

        public class When_setting_the_database_name_before_setting_the_connection_string : TestFixtureBase
        {
            protected override void Act()
            {
                var builder = new SqlConnectionStringBuilderAdapter();
                builder.DatabaseName = "Database1";
            }

            [Test]
            public void Should_throw_an_InvalidOperationException()
            {
                ActualException.ShouldBeOfType<InvalidOperationException>();
            }
        }

        public class When_getting_and_setting_the_server_name_in_a_SQL_Server_connection_string
            : TestFixtureBase
        {
            private string _actualServerName;
            private string _actualModifiedServerName;

            protected override void Act()
            {
                var adapter = new SqlConnectionStringBuilderAdapter();

                adapter.ConnectionString = @"Server=(local);Database=SomeDatabase;trusted_connection=True;Application Name=EdFi.Ods.WebApi;";
                _actualServerName = adapter.ServerName;

                adapter.ServerName = "ModifiedServerName";
                _actualModifiedServerName = adapter.ServerName;
            }

            [Test]
            public void Should_initially_return_the_server_name_from_the_connection_string()
            {
                _actualServerName.ShouldBe("(local)");
            }

            [Test]
            public void Should_return_the_modified_server_name_after_it_has_been_changed()
            {
                _actualModifiedServerName.ShouldBe("ModifiedServerName");
            }
        }

        public class When_setting_the_server_name_before_setting_the_connection_string : TestFixtureBase
        {
            protected override void Act()
            {
                new SqlConnectionStringBuilderAdapter
                {
                    ServerName = "SomeServer"
                };
            }

            [Test]
            public void Should_throw_an_InvalidOperationException()
            {
                ActualException.ShouldBeOfType<InvalidOperationException>();
            }
        }

        public class When_getting_and_setting_the_applicatuon_name_in_a_SQL_connection_string
            : TestFixtureBase
        {
            private string _actualApplicationName;
            private string _actualModifiedApplicationName;

            protected override void Act()
            {
                var adapter = new SqlConnectionStringBuilderAdapter
                {
                    ConnectionString = @"Server=(local);Database=SomeDatabase;Trusted_Connection=True;Application Name=EdFi.Ods.WebApi;"
                };
                _actualApplicationName = adapter.ApplicationName;

                adapter.ApplicationName = "ModifiedApplicationName";
                _actualModifiedApplicationName = adapter.ApplicationName;
            }

            [Test]
            public void Should_initially_return_the_application_name_from_the_connection_string()
            {
                _actualApplicationName.ShouldBe("EdFi.Ods.WebApi");
            }

            [Test]
            public void Should_return_the_modified_application_name_after_it_has_been_changed()
            {
                _actualModifiedApplicationName.ShouldBe("ModifiedApplicationName");
            }
        }
    }
}

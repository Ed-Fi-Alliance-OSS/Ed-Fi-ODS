// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data.SqlClient;
using EdFi.Ods.Common.Database;
using EdFi.TestFixture;
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

            private const string SqlServerConnectionStringFormat = @"Server=(local);Database={0};Trusted_Connection=True;Application Name=EdFi.Ods.WebApi;";
            
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
    }
}

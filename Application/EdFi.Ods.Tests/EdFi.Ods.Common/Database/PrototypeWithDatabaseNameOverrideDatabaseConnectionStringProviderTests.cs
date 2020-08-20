// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    [Obsolete("This class will soon be deprecated. Use When_building_connection_string_based_on_a_prototype_from_the_connectionStrings_config_section_but_with_a_database_name_replacement_token_override instead.", false)]
    public class When_building_connection_string_based_on_a_prototype_from_the_connectionStrings_config_section_but_with_a_database_name_override
        : LegacyTestFixtureBase
    {
        // Supplied values

        // Actual values
        private string _actualConnectionString;

        // External dependencies
        private IDatabaseNameProvider _databaseNameProvider;
        private IConfigConnectionStringsProvider _configConnectionStringsProvider;

        protected override void Arrange()
        {
            // Set up mocked dependences and supplied values
            _databaseNameProvider = Stub<IDatabaseNameProvider>();

            _databaseNameProvider.Expect(x => x.GetDatabaseName())
                                 .Return("OverrideDatabaseName");

            _configConnectionStringsProvider = Stub<IConfigConnectionStringsProvider>();

            _configConnectionStringsProvider.Expect(x => x.Count)
                                            .Return(1);

            _configConnectionStringsProvider.Expect(x => x.GetConnectionString("SomeConnectionStringName"))
                                            .Return("Server=SomeServer; Database=DATABASE_NAME_TO_BE_REPLACED; UID=SomeUser; Password=SomePassword");
        }

        protected override void Act()
        {
            // Perform the action to be tested
            var provider = new PrototypeWithDatabaseNameOverrideDatabaseConnectionStringProvider(
                "SomeConnectionStringName",
                _databaseNameProvider,
                _configConnectionStringsProvider);

            _actualConnectionString = provider.GetConnectionString();
        }

        [Assert]
        public void Should_substitute_the_database_name_in_the_existing_connection_string_with_the_one_supplied_by_the_database_name_provider()
        {
            _actualConnectionString.ShouldBe("Data Source=SomeServer;Initial Catalog=OverrideDatabaseName;User ID=SomeUser;Password=SomePassword");
        }

        [Assert]
        public void Should_perform_substitution_using_the_SqlConnectionStringBuilder_class()
        {
            // SqlConnectionStringBuilder produces telltale signs in resulting connection string:
            //      "Data Source" replaces "Server" and "Initial Catalog" replaces "Database"
            _actualConnectionString.ShouldContain("Data Source=");
            _actualConnectionString.ShouldContain("Initial Catalog=");
        }
    }

    [Obsolete("This class will soon be deprecated. Use When_building_connection_string_based_on_a_prototype_from_the_connectionStrings_config_section_with_different_database_name_replacement_token_overrides instead.", false)]
    public class When_building_connection_string_based_on_a_prototype_from_the_connectionStrings_config_section_with_different_database_name_overrides
        : LegacyTestFixtureBase
    {
        // Supplied values

        // Actual values
        private string _actualConnectionString1;
        private string _actualConnectionString2;
        private string _actualConnectionString3;

        // External dependencies
        private IDatabaseNameProvider _databaseNameProvider;
        private IConfigConnectionStringsProvider _configConnectionStringsProvider;

        protected override void Arrange()
        {
            // Set up mocked dependences and supplied values
            _databaseNameProvider = Stub<IDatabaseNameProvider>();

            _databaseNameProvider.Expect(x => x.GetDatabaseName())
                                 .Return("OneDatabase")
                                 .Repeat.Once();

            _databaseNameProvider.Expect(x => x.GetDatabaseName())
                                 .Return("AnotherDatabase")
                                 .Repeat.Once();

            _databaseNameProvider.Expect(x => x.GetDatabaseName())
                                 .Return("OneDatabase");

            _configConnectionStringsProvider = Stub<IConfigConnectionStringsProvider>();

            _configConnectionStringsProvider.Expect(x => x.Count)
                                            .Return(1);

            _configConnectionStringsProvider.Expect(x => x.GetConnectionString("SomeConnectionStringName"))
                                            .Return("Server=SomeServer; Database=DATABASE_NAME_TO_BE_REPLACED; UID=SomeUser; Password=SomePassword");
        }

        protected override void Act()
        {
            // Perform the action to be tested
            var provider = new PrototypeWithDatabaseNameOverrideDatabaseConnectionStringProvider(
                "SomeConnectionStringName",
                _databaseNameProvider,
                _configConnectionStringsProvider);

            _actualConnectionString1 = provider.GetConnectionString();
            _actualConnectionString2 = provider.GetConnectionString();
            _actualConnectionString3 = provider.GetConnectionString();
        }

        [Assert]
        public void Should_properly_modify_connection_string_template_with_varying_database_names()
        {
            // Assert the expected results
            _actualConnectionString1.ShouldContain("=OneDatabase;");
            _actualConnectionString2.ShouldContain("=AnotherDatabase;");
            _actualConnectionString3.ShouldContain("=OneDatabase;");
        }
    }
}

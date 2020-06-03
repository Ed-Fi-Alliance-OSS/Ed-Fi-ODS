// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database;
using EdFi.TestFixture;
using Shouldly;
using Test.Common;
using FakeItEasy;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    public class When_building_connection_string_based_on_a_prototype_from_the_connectionStrings_config_section_but_with_a_database_name_replacement_token_override
        : TestFixtureBase
    {
        // Supplied values

        // Actual values
        private string _actualConnectionString;

        // External dependencies
        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;
        private IConfigConnectionStringsProvider _configConnectionStringsProvider;
        private IDbConnectionStringBuilderAdapterFactory _dbConnectionStringBuilderAdapterFactory;

        protected override void Arrange()
        {
            // Set up mocked dependencies and supplied values
            _databaseNameReplacementTokenProvider = A.Fake<IDatabaseNameReplacementTokenProvider>();

            A.CallTo(() => _databaseNameReplacementTokenProvider.GetReplacementToken())
                .Returns("Ods");

            _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

            A.CallTo(() => _configConnectionStringsProvider.Count)
                .Returns(1);

            A.CallTo(() => _configConnectionStringsProvider.GetConnectionString("SomeConnectionStringName"))
                .Returns("Server=SomeServer; Database=EdFi_{0}; UID=SomeUser; Password=SomePassword");

            _dbConnectionStringBuilderAdapterFactory = A.Fake<IDbConnectionStringBuilderAdapterFactory>();

            A.CallTo(() => _dbConnectionStringBuilderAdapterFactory.Get()).Returns(new SqlConnectionStringBuilderAdapter());
        }

        protected override void Act()
        {
            // Perform the action to be tested
            var provider = new PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider(
                "SomeConnectionStringName",
                _databaseNameReplacementTokenProvider,
                _configConnectionStringsProvider,
                _dbConnectionStringBuilderAdapterFactory);

            _actualConnectionString = provider.GetConnectionString();
        }

        [Assert]
        public void Should_substitute_the_database_name_token_in_the_existing_connection_string_with_the_one_supplied_by_the_database_name_replacement_token_provider()
        {
            _actualConnectionString.ShouldBe("Data Source=SomeServer;Initial Catalog=EdFi_Ods;User ID=SomeUser;Password=SomePassword");
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

    public class When_building_connection_string_based_on_a_prototype_from_the_connectionStrings_config_section_with_different_database_name_replacement_token_overrides
        : TestFixtureBase
    {
        // Supplied values

        // Actual values
        private string _actualConnectionString1;
        private string _actualConnectionString2;
        private string _actualConnectionString3;

        // External dependencies
        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;
        private IConfigConnectionStringsProvider _configConnectionStringsProvider;
        private IDbConnectionStringBuilderAdapterFactory _dbConnectionStringBuilderAdapterFactory;

        protected override void Arrange()
        {
            // Set up mocked dependencies and supplied values
            _databaseNameReplacementTokenProvider = A.Fake<IDatabaseNameReplacementTokenProvider>();

            A.CallTo(() => _databaseNameReplacementTokenProvider.GetReplacementToken()).Returns("OneDatabase").Once();

            A.CallTo(() => _databaseNameReplacementTokenProvider.GetReplacementToken()).Returns("AnotherDatabase").Once();

            A.CallTo(() => _databaseNameReplacementTokenProvider.GetReplacementToken()).Returns("OneDatabase").Once();

            _configConnectionStringsProvider = A.Fake<IConfigConnectionStringsProvider>();

            A.CallTo(() => _configConnectionStringsProvider.Count).Returns(1);

            A.CallTo(() => _configConnectionStringsProvider.GetConnectionString("SomeConnectionStringName"))
                .Returns("Server=SomeServer; Database=EdFi_{0}; UID=SomeUser; Password=SomePassword");

            _dbConnectionStringBuilderAdapterFactory = A.Fake<IDbConnectionStringBuilderAdapterFactory>();

            A.CallTo(() => _dbConnectionStringBuilderAdapterFactory.Get()).Returns(new SqlConnectionStringBuilderAdapter());
        }

        protected override void Act()
        {
            // Perform the action to be tested
            var provider = new PrototypeWithDatabaseNameTokenReplacementConnectionStringProvider(
                "SomeConnectionStringName",
                _databaseNameReplacementTokenProvider,
                _configConnectionStringsProvider,
                _dbConnectionStringBuilderAdapterFactory);

            _actualConnectionString1 = provider.GetConnectionString();
            _actualConnectionString2 = provider.GetConnectionString();
            _actualConnectionString3 = provider.GetConnectionString();
        }

        [Assert]
        public void Should_properly_modify_connection_string_template_with_varying_database_names()
        {
            // Assert the expected results
            _actualConnectionString1.ShouldContain("=EdFi_OneDatabase;");
            _actualConnectionString2.ShouldContain("=EdFi_AnotherDatabase;");
            _actualConnectionString3.ShouldContain("=EdFi_OneDatabase;");
        }
    }
}


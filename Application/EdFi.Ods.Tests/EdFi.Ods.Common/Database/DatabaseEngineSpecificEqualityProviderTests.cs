// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Common.Configuration;
using EdFi.Ods.Common.Database;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    [TestFixture]
    public class DatabaseEngineSpecificEqualityComparerProviderTests
    {
        [Test]
        public void Returns_correct_string_comparison_results_when_database_engine_is_sql_server()
        {
            var sqlServerEqualityComparerProvider = new DatabaseEngineSpecificStringComparerProvider(DatabaseEngine.SqlServer);

            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomeString").ShouldBeTrue();
            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SOMESTRING").ShouldBeTrue();
            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "sOMEsTRING").ShouldBeTrue();

            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomeString ").ShouldBeFalse();
            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "Some String ").ShouldBeFalse();
            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomèString").ShouldBeFalse();
            sqlServerEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomeOtherString").ShouldBeFalse();
        }

        [Test]
        public void Returns_correct_string_comparison_results_when_database_engine_is_postgres()
        {
            var postgresEqualityComparerProvider = new DatabaseEngineSpecificStringComparerProvider(DatabaseEngine.Postgres);

            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomeString").ShouldBeTrue();

            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomeString ").ShouldBeFalse();
            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomèString").ShouldBeFalse();
            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SOMESTRING").ShouldBeFalse();
            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "sOMEsTRING").ShouldBeFalse();
            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "Some String ").ShouldBeFalse();
            postgresEqualityComparerProvider.GetEqualityComparer().Equals("SomeString", "SomeOtherString").ShouldBeFalse();
        }

        [Test]
        public void Throws_an_exception_if_the_database_engine_is_not_supported()
        {
            Should.Throw<NotSupportedException>(() => new DatabaseEngineSpecificStringComparerProvider(new DatabaseEngine("Mongo", "MongoDB", "folder")));
        }
    }
}
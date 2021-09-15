// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Database;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    public class When_getting_database_server_name_using_convention_specific_database_server_name_provider
        : TestFixtureBase
    {
        private IDatabaseServerNameProvider _databaseServerNameProvider;
        private const string _databaseNameReplacementToken = "Ods_2021";
        private string _actualServerName;

        protected override void Arrange()
        {
            var databaseNameReplacementTokenProvider = A.Fake<IDatabaseNameReplacementTokenProvider>();

            A.CallTo(() => databaseNameReplacementTokenProvider.GetReplacementToken())
                .Returns(_databaseNameReplacementToken);

            _databaseServerNameProvider =
                new ConventionSpecificDatabaseServerNameProvider(databaseNameReplacementTokenProvider);
        }

        protected override void Act()
        {
            _actualServerName = _databaseServerNameProvider.GetDatabaseServerName();
        }

        [Test]
        public void Should_return_database_name_replacement_token()
        {
            _actualServerName.ShouldBe(_databaseNameReplacementToken);
        }
    }
}
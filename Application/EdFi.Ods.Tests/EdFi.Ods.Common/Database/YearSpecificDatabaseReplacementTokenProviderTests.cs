// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database
{
    public class When_using_year_specific_database_replacement_token_provider_with_valid_school_year_context
        : TestFixtureBase
    {
        private string _actualDatabaseNameReplacementToken;
        private string _actualServerNameReplacementToken;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(2020);

            _databaseReplacementTokenProvider =
                new YearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider);
        }

        protected override void Act()
        {
            _actualDatabaseNameReplacementToken = _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
            _actualServerNameReplacementToken = _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_return_correct_database_name_replacement_token()
        {
            _actualDatabaseNameReplacementToken.ShouldBe("Ods_2020");
        }

        [Test]
        public void Should_return_correct_server_name_replacement_token()
        {
            _actualServerNameReplacementToken.ShouldBe("Ods_2020");
        }
    }

    public class When_getting_database_name_replacement_token_with_missing_school_year_context : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(0);

            _databaseReplacementTokenProvider =
                new YearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }

    public class When_getting_server_name_replacement_token_with_missing_school_year_context : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(0);

            _databaseReplacementTokenProvider =
                new YearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider);
        }

        protected override void Act()
        {
            _databaseReplacementTokenProvider.GetServerNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }
}
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
    public class When_using_year_specific_database_name_replacement_token_provider_with_valid_school_year_context
        : TestFixtureBase
    {
        private string _actualReplacementToken;

        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(2020);

            _databaseNameReplacementTokenProvider =
                new YearSpecificDatabaseNameReplacementTokenProvider(schoolYearContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _databaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_return_correct_value()
        {
            _actualReplacementToken.ShouldBe("Ods_2020");
        }
    }

    public class When_using_year_specific_database_name_replacement_token_provider_with_missing_school_year_context : TestFixtureBase
    {
        private IDatabaseNameReplacementTokenProvider _databaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(0);

            _databaseNameReplacementTokenProvider =
                new YearSpecificDatabaseNameReplacementTokenProvider(schoolYearContextProvider);
        }

        protected override void Act()
        {
           _databaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }
}
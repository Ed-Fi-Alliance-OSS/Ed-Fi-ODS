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
    public class When_using_instance_year_specific_database_replacement_token_provider_with_valid_instance_and_with_valid_school_year_context
        : TestFixtureBase
    {
        private string _actualReplacementToken;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();
            var instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(2020);

            A.CallTo(() => instanceIdContextProvider.GetInstanceId())
                .Returns("instance1");

            _databaseReplacementTokenProvider =
                new InstanceYearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider, instanceIdContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_return_correct_value()
        {
            _actualReplacementToken.ShouldBe("Ods_instance1_2020");
        }
    }

    public class When_using_instance_year_specific_database_replacement_token_provider_with_valid_instance_and_with_missing_school_year_context : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();
            var instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(0);

            A.CallTo(() => instanceIdContextProvider.GetInstanceId())
                .Returns("instance1");

            _databaseReplacementTokenProvider =
                new InstanceYearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider, instanceIdContextProvider);
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

    public class When_using_instance_year_specific_database_replacement_token_provider_with_missing_instance_and_with_valid_school_year_context : TestFixtureBase
    {
        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();
            var instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(2020);

            A.CallTo(() => instanceIdContextProvider.GetInstanceId())
                .Returns("");

            _databaseReplacementTokenProvider =
                new InstanceYearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider, instanceIdContextProvider);
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

    public class When_using_instance_year_specific_database_replacement_token_provider_with_missing_instance_and_with_missing_school_year_context
        : TestFixtureBase
    {
        private string _actualReplacementToken;

        private IDatabaseReplacementTokenProvider _databaseReplacementTokenProvider;

        protected override void Arrange()
        {
            var schoolYearContextProvider = A.Fake<ISchoolYearContextProvider>();
            var instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            A.CallTo(() => schoolYearContextProvider.GetSchoolYear())
                .Returns(0);

            A.CallTo(() => instanceIdContextProvider.GetInstanceId())
                .Returns("");

            _databaseReplacementTokenProvider =
                new InstanceYearSpecificDatabaseReplacementTokenProvider(schoolYearContextProvider, instanceIdContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _databaseReplacementTokenProvider.GetDatabaseNameReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }
}
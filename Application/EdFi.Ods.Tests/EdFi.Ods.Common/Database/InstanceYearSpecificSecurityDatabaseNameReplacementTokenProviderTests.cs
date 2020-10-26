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
    public class When_using_instance_year_specific_security_database_name_replacement_token_provider_with_valid_instance_context
        : TestFixtureBase
    {
        private string _actualReplacementToken;

        private ISecurityDatabaseNameReplacementTokenProvider _securityDatabaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            A.CallTo(() => instanceIdContextProvider.GetInstanceId())
                .Returns("instance1");

            _securityDatabaseNameReplacementTokenProvider = new InstanceYearSpecificSecurityDatabaseNameReplacementTokenProvider(instanceIdContextProvider);
        }

        protected override void Act()
        {
            _actualReplacementToken = _securityDatabaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_return_correct_value()
        {
            _actualReplacementToken.ShouldBe("Security_instance1");
        }
    }

    public class When_using_instance_year_specific_security_database_name_replacement_token_provider_with_missing_instance_context : TestFixtureBase
    {
        private ISecurityDatabaseNameReplacementTokenProvider _securityDatabaseNameReplacementTokenProvider;

        protected override void Arrange()
        {
            var instanceIdContextProvider = A.Fake<IInstanceIdContextProvider>();

            A.CallTo(() => instanceIdContextProvider.GetInstanceId())
                .Returns("");

            _securityDatabaseNameReplacementTokenProvider = new InstanceYearSpecificSecurityDatabaseNameReplacementTokenProvider(instanceIdContextProvider);
        }

        protected override void Act()
        {
            _securityDatabaseNameReplacementTokenProvider.GetReplacementToken();
        }

        [Test]
        public void Should_throw_an_InvalidOperationException()
        {
            ActualException.ShouldBeOfType<InvalidOperationException>();
        }
    }
}
// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections;
using System.Collections.Generic;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Security.Authorization.Filtering;
using NHibernate;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.NHibernate.Filtering
{
    using Parameters = IDictionary<string, IDictionary<string, object>>;

    [TestFixture]
    public class AuthorizationFilterContextProviderTests
    {
        public class When_setting_and_getting_authorization_filter_context : LegacyScenarioFor<AuthorizationFilterContextProvider>
        {
            protected override void Arrange()
            {
                Given<IContextStorage>(new HashtableContextStorage());

                Given<ISession>();

                Supplied<Parameters>(CreateTestParameters());
            }

            protected override void Act()
            {
                TestSubject.SetFilterContext(Supplied<Parameters>());
            }

            [Assert]
            public void Should_save_the_parameters_into_context_storage()
            {
                Assert.That(
                    Given<IContextStorage>().GetValue<Parameters>("FilterContextProvider.FilterContext"), 
                    Is.EquivalentTo(Supplied<Parameters>()));
            }

            [Assert]
            public void Should_return_the_saved_authorization_filter_context()
            {
                Assert.That(TestSubject.GetFilterContext(), Is.EquivalentTo(Supplied<Parameters>()));
            }

            private static Dictionary<string, IDictionary<string, object>> CreateTestParameters() => 
                new Dictionary<string, IDictionary<string, object>>
            {
                { "key1", new Dictionary<string, object> { { "prop1", 1} } },
                { "key2", new Dictionary<string, object> { { "prop1", 1}, { "prop2", "two"} } },
            };
        }
    }
}

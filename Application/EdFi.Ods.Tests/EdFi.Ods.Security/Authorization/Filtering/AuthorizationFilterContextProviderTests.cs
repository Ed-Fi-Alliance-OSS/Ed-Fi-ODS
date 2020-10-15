// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Security.Authorization.Filtering;
using EdFi.TestFixture;
using NHibernate;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization.Filtering
{
    [TestFixture]
    public class AuthorizationFilterContextProviderTests
    {
        public class When_setting_and_getting_authorization_filter_context : ScenarioFor<AuthorizationFilterContextProvider>
        {
            private static AuthorizationFilterContextProvider authProvider;
            private static IContextStorage contextstorage;
            protected override void Arrange()
            {
                Given<IContextStorage>(new HashtableContextStorage());

                Given<ISession>();
                contextstorage = new HashtableContextStorage();
                Supplied<IReadOnlyList<AuthorizationFilterDetails>>(CreateTestParameters());
                authProvider = new AuthorizationFilterContextProvider(contextstorage);
            }

            protected override void Act()
            {
                authProvider.SetFilterContext(Supplied<IReadOnlyList<AuthorizationFilterDetails>>());
            }

            [Assert]
            public void Should_save_the_parameters_into_context_storage()
            {
                Assert.That(
                    authProvider.GetFilterContext(),
                    Is.EquivalentTo(Supplied<IReadOnlyList<AuthorizationFilterDetails>>()));
            }

            [Assert]
            public void Should_return_the_saved_authorization_filter_context()
            {
                Assert.That(authProvider.GetFilterContext(), Is.EquivalentTo(Supplied<IReadOnlyList<AuthorizationFilterDetails>>()));
            }

            private static IReadOnlyList<AuthorizationFilterDetails> CreateTestParameters()
            {
                return new List<AuthorizationFilterDetails>
                {
                    new AuthorizationFilterDetails
                    {
                        FilterName = "key1",
                        ClaimEndpointName = "prop1",
                        ClaimValues = new object[] {1}
                    },
                    new AuthorizationFilterDetails
                    {
                        FilterName = "key1",
                        ClaimEndpointName = "prop2",
                        ClaimValues = new object[] {2}
                    }
                };
            }
        }
    }
}

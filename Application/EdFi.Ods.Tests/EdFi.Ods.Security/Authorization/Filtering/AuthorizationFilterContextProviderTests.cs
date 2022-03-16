// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.TestFixture;
using NHibernate;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Filtering
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
                Supplied(CreateTestParameters());
                authProvider = new AuthorizationFilterContextProvider(contextstorage);
            }

            protected override void Act()
            {
                authProvider.SetFilterContext(Supplied<IReadOnlyList<AuthorizationStrategyFiltering>>());
            }

            [Assert]
            public void Should_save_the_parameters_into_context_storage()
            {
                Assert.That(
                    authProvider.GetFilterContext(),
                    Is.EquivalentTo(Supplied<IReadOnlyList<AuthorizationStrategyFiltering>>()));
            }

            [Assert]
            public void Should_return_the_saved_authorization_filter_context()
            {
                Assert.That(authProvider.GetFilterContext(), Is.EquivalentTo(Supplied<IReadOnlyList<AuthorizationStrategyFiltering>>()));
            }

            private static IReadOnlyList<AuthorizationStrategyFiltering> CreateTestParameters()
            {
                return new[]
                {
                    new AuthorizationStrategyFiltering()
                    {
                        AuthorizationStrategyName = "Test",
                        Filters = new List<AuthorizationFilterContext>
                        {
                            new AuthorizationFilterContext
                            {
                                FilterName = "key1",
                                ClaimEndpointValues = new object[] { 1 },
                                ClaimParameterName = "prop1",
                            },
                            new AuthorizationFilterContext
                            {
                                FilterName = "key1",
                                ClaimEndpointValues = new object[] { 2 },
                                ClaimParameterName = "prop2"
                            }
                        }
                    }
                };
            }
        }
    }
}

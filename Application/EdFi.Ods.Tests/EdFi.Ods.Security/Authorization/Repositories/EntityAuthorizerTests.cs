// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common.Extensions;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using System.Threading;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories
{
    [TestFixture]
    public class EntityAuthorizerTests
    {
        public class When_authorizing_an_unauthorized_caller: ScenarioFor<EntityAuthorizer>
        {
            private const long ExpectedClaimEndpointValue = long.MaxValue;

            /// <summary>
            /// Prepares the state of the scenario (creating stubs, test data, etc.).
            /// </summary>
            protected override void Arrange()
            {
                A.CallTo(
                        () =>
                            Given<IAuthorizationFilteringProvider>().GetAuthorizationFiltering(
                                A<EdFiAuthorizationContext>._, A<AuthorizationBasisMetadata>._))
                    .Returns(
                        new[]
                        {
                            new AuthorizationStrategyFiltering
                            {
                                Operator = FilterOperator.And,
                                Filters = new[]
                                    {
                                        new AuthorizationFilterContext
                                            {
                                                ClaimEndpointValues = new object[] {ExpectedClaimEndpointValue}
                                            }
                                    }
                            }
                        });

                A.CallTo(
                        () =>
                            Given<IAuthorizationFilterDefinitionProvider>().GetFilterDefinition(A<string>._))
                    .Returns(
                        new AuthorizationFilterDefinition(
                            "FilterName",
                            "FriendlyHqlConditionFormat",
                            (_, _, _, _, _) => { },
                            (_, _, _, _, _, _) => { },
                            (_, _) => InstanceAuthorizationResult.NotPerformed()));
            }

            /// <summary>
            /// Executes the code to be exercised for the scenario.
            /// </summary>
            protected override void Act()
            {
                SystemUnderTest.AuthorizeEntityAsync(A.Fake<AggregateRootWithCompositeKey>(), "Action", CancellationToken.None)
                    .WaitSafely();
            }

            [Assert]
            public void Should_throw_a_SecurityAuthorizationException()
            {
                ActualException.ShouldBeOfType<SecurityAuthorizationException>();
            }

            [Assert]
            public void Should_throw_a_SecurityAuthorizationException_indicating_the_caller_claim_endpoint_value()
            {
                ActualException.ToString().ShouldContain(ExpectedClaimEndpointValue.ToString());
            }
        }
    }
}

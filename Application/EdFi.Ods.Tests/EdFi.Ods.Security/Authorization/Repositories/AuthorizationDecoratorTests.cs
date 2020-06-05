// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Ods.Api.Common.Authentication;
using EdFi.Ods.Api.Services.Authorization;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Security.Authorization.Repositories;
using EdFi.Ods.Security.Claims;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using Test.Common._Stubs;

namespace EdFi.Ods.Tests.EdFi.Ods.Security.Authorization.Repositories
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AuthorizationDecoratorTests
    {
        public class When_authorizing_the_operation_on_a_non_existing_entity : ScenarioFor<
            GetEntityByIdAuthorizationDecorator<Student>>
        {
            private Student _actualStudent;

            protected override void Arrange()
            {
                
                A.CallTo(() => 
                        Given<IGetEntityById<Student>>().GetByIdAsync(A<Guid>.Ignored, A<CancellationToken>._))
                        .Returns(Task.FromResult<Student>(null));
            }

            /// <summary>
            /// Executes the code to be exercised for the scenario.
            /// </summary>
            protected override void Act()
            {
                _actualStudent = SystemUnderTest.GetByIdAsync(Guid.NewGuid(), CancellationToken.None).GetResultSafely();
            }

            [Assert]
            public void Should_not_throw_an_exception()
            {
                ActualException.ShouldBeNull();
            }

            [Assert]
            public void Should_return_the_Student_as_null()
            {
                _actualStudent.ShouldBeNull();
            }
        }

        public class When_authorizing_the_operation_on_an_existing_entity : ScenarioFor<
            GetEntityByIdAuthorizationDecorator<Student>>
        {
            private Student _actualStudent;

            /// <summary>
            /// Prepares the state of the scenario (creating stubs, test data, etc.).
            /// </summary>
            protected override void Arrange()
            {
                Supplied(Guid.NewGuid());

                A.CallTo(() => 
                    Given<IGetEntityById<Student>>().GetByIdAsync(Supplied<Guid>(), A<CancellationToken>._))
                    .Returns(Task.FromResult(Supplied(new Student())));

                A.CallTo(() => 
                    Given<IAuthorizationContextProvider>().GetAction())
                    .Returns("Action");

                A.CallTo(() => 
                    Given<IAuthorizationContextProvider>().GetResourceUris())
                    .Returns(new[] {"Resource"});

                var claimsIdentityProvider = new ClaimsIdentityProvider(
                    new ApiKeyContextProvider(new CallContextStorage()),
                    new StubSecurityRepository());

                var apiClientDetails = new ApiClientDetails
                {
                    ApiKey = Guid.NewGuid()
                        .ToString("n"),
                    ApplicationId = 999,
                    ClaimSetName = "SomeClaimSet",
                    NamespacePrefixes = new List<string> {"Namespace"},
                    EducationOrganizationIds = new List<int>
                    {
                        123,
                        234
                    }
                };

                var claimsIdentity = claimsIdentityProvider.GetClaimsIdentity(
                    apiClientDetails.EducationOrganizationIds,
                    apiClientDetails.ClaimSetName,
                    apiClientDetails.NamespacePrefixes,
                    apiClientDetails.Profiles.ToList());

                ClaimsPrincipal.ClaimsPrincipalSelector = () => new ClaimsPrincipal(claimsIdentity);
            }

            /// <summary>
            /// Executes the code to be exercised for the scenario.
            /// </summary>
            protected override void Act()
            {
                _actualStudent = SystemUnderTest.GetByIdAsync(Supplied<Guid>(), CancellationToken.None).GetResultSafely();
            }

            [Assert]
            public void Should_invoke_authorization_on_the_item()
            {
                A.CallTo(() => 
                    Given<IEdFiAuthorizationProvider>()
                        .AuthorizeSingleItemAsync(A<EdFiAuthorizationContext>.That.Matches(ctx => CompareContexts(ctx)), CancellationToken.None))
                    .MustHaveHappened();
            }

            [Assert]
            public void Should_return_the_supplied_student()
            {
                _actualStudent.ShouldBeSameAs(Supplied<Student>());
            }

            private bool CompareContexts(EdFiAuthorizationContext context)
            {
                context.Resource.Single()
                    .Value.ShouldBe("Resource");

                context.Action.Single()
                    .Value.ShouldBe("Action");

                context.Data.ShouldBeSameAs(Supplied<Student>());
                context.Type.ShouldBeSameAs(typeof(Student));

                return true;
            }
        }
    }
}

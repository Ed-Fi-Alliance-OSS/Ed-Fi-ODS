﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Common.Security;
using EdFi.Ods.Api.Security.Authorization;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.Claims;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Repositories;
using EdFi.Ods.Common.Security;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using Test.Common._Stubs;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization.Repositories
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

                Given<IEntityAuthorizer>();
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
                A.CallTo(
                    () => Given<IEntityAuthorizer>()
                        .AuthorizeEntityAsync(Supplied<Student>(), "Action", AuthorizationPhase.ExistingData, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
            }

            [Assert]
            public void Should_return_the_supplied_student()
            {
                _actualStudent.ShouldBeSameAs(Supplied<Student>());
            }

            private bool CompareContexts(DataManagementRequestContext context)
            {
                context.ResourceClaimUris.Single()
                    .ShouldBe("Resource");

                context.Action.ShouldBe("Action");

                context.Data.ShouldBeSameAs(Supplied<Student>());
                context.Type.ShouldBeSameAs(typeof(Student));

                return true;
            }
        }
    }
}
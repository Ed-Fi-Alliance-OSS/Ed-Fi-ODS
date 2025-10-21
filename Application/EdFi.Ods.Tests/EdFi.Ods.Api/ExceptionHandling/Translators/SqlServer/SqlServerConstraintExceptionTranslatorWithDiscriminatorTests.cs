// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Pipelines.Delete;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Builders;
using EdFi.Ods.Tests._Helpers;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ExceptionHandling.Translators.SqlServer
{
    public class SqlServerConstraintExceptionTranslatorWithDiscriminatorTests
    {
        private const string GenericSqlExceptionMessage = "Generic Sql exception message.";

        public class When_delete_conflicts_with_abstract_entity_with_single_discriminator : TestFixtureBase
        {
            private Exception _exception;
            private bool _wasHandled;
            private IEdFiProblemDetails _actualError;
            private IDomainModelProvider _domainModelProvider;
            private IDiscriminatorResolver _discriminatorResolver;
            private IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
            private readonly IContextStorage _contextStorage = new CallContextStorage();

            protected override void Arrange()
            {
                var domainModel = this.LoadDomainModel("GeneralStudentProgramAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                var resourceModel = new ResourceModel(domainModel);
                var studentResource = resourceModel.GetResourceByApiCollectionName("ed-fi", "students");
                _dataManagementResourceContextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                _dataManagementResourceContextProvider.Set(new DataManagementResourceContext(studentResource));

                var studentId = Guid.NewGuid();
                _contextStorage.SetValue(nameof(DeleteContext), new DeleteContext(studentId, "Student"));

                _discriminatorResolver = A.Fake<IDiscriminatorResolver>();
                A.CallTo(() => _discriminatorResolver.GetDistinctDiscriminators(
                        A<string>.Ignored,
                        A<string>.Ignored,
                        A<Entity>.Ignored,
                        A<Guid>.Ignored,
                        A<int>.Ignored))
                    .Returns(new List<string> { "edfi.StudentProgramAssociation" });

                const string message =
                    "The DELETE statement conflicted with the REFERENCE constraint \"FK_GeneralStudentProgramAssociation_Student\". " +
                    "The conflict occurred in database \"EdFi_Ods\", table \"edfi.GeneralStudentProgramAssociation\".\r\n" +
                    "The statement has been terminated.";

                _exception = NHibernateExceptionBuilder.CreateException(
                    GenericSqlExceptionMessage,
                    message);
            }

            protected override void Act()
            {
                var translator = new SqlServerConstraintExceptionTranslator(
                    _domainModelProvider,
                    _discriminatorResolver,
                    _dataManagementResourceContextProvider);

                _wasHandled = translator.TryTranslate(_exception, out _actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                _wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_return_a_409_Conflict_error_with_refined_entity_name()
            {
                _actualError.ShouldSatisfyAllConditions(
                    () => _actualError.ShouldNotBeNull(),
                    () => _actualError.Status.ShouldBe(409),
                    () => _actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    () => _actualError.Detail.ShouldBe(
                        "The requested action cannot be performed because this item is referenced by an existing 'StudentProgramAssociation' item.")
                );
            }
        }

        public class When_delete_conflicts_with_abstract_entity_with_multiple_discriminators : TestFixtureBase
        {
            private Exception _exception;
            private bool _wasHandled;
            private IEdFiProblemDetails _actualError;
            private IDomainModelProvider _domainModelProvider;
            private IDiscriminatorResolver _discriminatorResolver;
            private IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
            private readonly IContextStorage _contextStorage = new CallContextStorage();

            protected override void Arrange()
            {
                var domainModel = this.LoadDomainModel("GeneralStudentProgramAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                var resourceModel = new ResourceModel(domainModel);
                var studentResource = resourceModel.GetResourceByApiCollectionName("ed-fi", "students");
                _dataManagementResourceContextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                _dataManagementResourceContextProvider.Set(new DataManagementResourceContext(studentResource));

                var studentId = Guid.NewGuid();
                _contextStorage.SetValue(nameof(DeleteContext), new DeleteContext(studentId, "Student"));

                _discriminatorResolver = A.Fake<IDiscriminatorResolver>();
                A.CallTo(() => _discriminatorResolver.GetDistinctDiscriminators(
                        A<string>.Ignored,
                        A<string>.Ignored,
                        A<Entity>.Ignored,
                        A<Guid>.Ignored,
                        A<int>.Ignored))
                    .Returns(new List<string> { "edfi.StudentProgramAssociation", "edfi.OtherProgramAssociation" });

                const string message =
                    "The DELETE statement conflicted with the REFERENCE constraint \"FK_GeneralStudentProgramAssociation_Student\". " +
                    "The conflict occurred in database \"EdFi_Ods\", table \"edfi.GeneralStudentProgramAssociation\".\r\n" +
                    "The statement has been terminated.";

                _exception = NHibernateExceptionBuilder.CreateException(
                    GenericSqlExceptionMessage,
                    message);
            }

            protected override void Act()
            {
                var translator = new SqlServerConstraintExceptionTranslator(
                    _domainModelProvider,
                    _discriminatorResolver,
                    _dataManagementResourceContextProvider);

                _wasHandled = translator.TryTranslate(_exception, out _actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                _wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_return_a_409_Conflict_error_with_abstract_entity_name()
            {
                _actualError.ShouldSatisfyAllConditions(
                    () => _actualError.ShouldNotBeNull(),
                    () => _actualError.Status.ShouldBe(409),
                    () => _actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    () => _actualError.Detail.ShouldBe(
                        "The requested action cannot be performed because this item is referenced by an existing 'StudentProgramAssociation' item.")
                );
            }
        }

        public class When_delete_conflicts_with_abstract_entity_but_discriminator_resolution_fails : TestFixtureBase
        {
            private Exception _exception;
            private bool _wasHandled;
            private IEdFiProblemDetails _actualError;
            private IDomainModelProvider _domainModelProvider;
            private IDiscriminatorResolver _discriminatorResolver;
            private IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
            private readonly IContextStorage _contextStorage = new CallContextStorage();

            protected override void Arrange()
            {
                var domainModel = this.LoadDomainModel("GeneralStudentProgramAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                var resourceModel = new ResourceModel(domainModel);
                var studentResource = resourceModel.GetResourceByApiCollectionName("ed-fi", "students");
                _dataManagementResourceContextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                _dataManagementResourceContextProvider.Set(new DataManagementResourceContext(studentResource));

                var studentId = Guid.NewGuid();
                _contextStorage.SetValue(nameof(DeleteContext), new DeleteContext(studentId, "Student"));

                _discriminatorResolver = A.Fake<IDiscriminatorResolver>();
                A.CallTo(() => _discriminatorResolver.GetDistinctDiscriminators(
                        A<string>.Ignored,
                        A<string>.Ignored,
                        A<Entity>.Ignored,
                        A<Guid>.Ignored,
                        A<int>.Ignored))
                    .Throws<InvalidOperationException>();

                const string message =
                    "The DELETE statement conflicted with the REFERENCE constraint \"FK_GeneralStudentProgramAssociation_Student\". " +
                    "The conflict occurred in database \"EdFi_Ods\", table \"edfi.GeneralStudentProgramAssociation\".\r\n" +
                    "The statement has been terminated.";

                _exception = NHibernateExceptionBuilder.CreateException(
                    GenericSqlExceptionMessage,
                    message);
            }

            protected override void Act()
            {
                var translator = new SqlServerConstraintExceptionTranslator(
                    _domainModelProvider,
                    _discriminatorResolver,
                    _dataManagementResourceContextProvider);

                _wasHandled = translator.TryTranslate(_exception, out _actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                _wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_gracefully_fallback_to_abstract_entity_name()
            {
                _actualError.ShouldSatisfyAllConditions(
                    () => _actualError.ShouldNotBeNull(),
                    () => _actualError.Status.ShouldBe(409),
                    () => _actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    () => _actualError.Detail.ShouldBe(
                        "The requested action cannot be performed because this item is referenced by an existing 'GeneralStudentProgramAssociation' item.")
                );
            }
        }

        public class When_delete_conflicts_with_concrete_entity : TestFixtureBase
        {
            private Exception _exception;
            private bool _wasHandled;
            private IEdFiProblemDetails _actualError;
            private IDomainModelProvider _domainModelProvider;
            private IDiscriminatorResolver _discriminatorResolver;
            private IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
            private readonly IContextStorage _contextStorage = new CallContextStorage();

            protected override void Arrange()
            {
                _domainModelProvider = DomainModelDefinitionsProviderHelper.DomainModelProvider;

                var resourceModel = new ResourceModel(_domainModelProvider.GetDomainModel());
                var studentResource = resourceModel.GetResourceByApiCollectionName("ed-fi", "students");
                _dataManagementResourceContextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                _dataManagementResourceContextProvider.Set(new DataManagementResourceContext(studentResource));

                var studentId = Guid.NewGuid();
                _contextStorage.SetValue(nameof(DeleteContext), new DeleteContext(studentId, "Student"));

                _discriminatorResolver = A.Fake<IDiscriminatorResolver>();

                const string message =
                    "The DELETE statement conflicted with the REFERENCE constraint \"FK_StudentSchoolAssociation_School\". " +
                    "The conflict occurred in database \"EdFi_Ods\", table \"edfi.StudentSchoolAssociation\".\r\n" +
                    "The statement has been terminated.";

                _exception = NHibernateExceptionBuilder.CreateException(
                    GenericSqlExceptionMessage,
                    message);
            }

            protected override void Act()
            {
                var translator = new SqlServerConstraintExceptionTranslator(
                    _domainModelProvider,
                    _discriminatorResolver,
                    _dataManagementResourceContextProvider);

                _wasHandled = translator.TryTranslate(_exception, out _actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                _wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_not_attempt_discriminator_resolution()
            {
                A.CallTo(() => _discriminatorResolver.GetDistinctDiscriminators(
                        A<string>.Ignored,
                        A<string>.Ignored,
                        A<Entity>.Ignored,
                        A<Guid>.Ignored,
                        A<int>.Ignored))
                    .MustNotHaveHappened();
            }

            [Test]
            public void Should_return_a_409_Conflict_error_with_concrete_entity_name()
            {
                _actualError.ShouldSatisfyAllConditions(
                    () => _actualError.ShouldNotBeNull(),
                    () => _actualError.Status.ShouldBe(409),
                    () => _actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    () => _actualError.Detail.ShouldContain("StudentSchoolAssociation")
                );
            }
        }

        public class When_delete_conflicts_with_abstract_entity_with_no_discriminators_found : TestFixtureBase
        {
            private Exception _exception;
            private bool _wasHandled;
            private IEdFiProblemDetails _actualError;
            private IDomainModelProvider _domainModelProvider;
            private IDiscriminatorResolver _discriminatorResolver;
            private IContextProvider<DataManagementResourceContext> _dataManagementResourceContextProvider;
            private readonly IContextStorage _contextStorage = new CallContextStorage();

            protected override void Arrange()
            {
                var domainModel = this.LoadDomainModel("GeneralStudentProgramAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                var resourceModel = new ResourceModel(domainModel);
                var studentResource = resourceModel.GetResourceByApiCollectionName("ed-fi", "students");
                _dataManagementResourceContextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                _dataManagementResourceContextProvider.Set(new DataManagementResourceContext(studentResource));

                var studentId = Guid.NewGuid();
                _contextStorage.SetValue(nameof(DeleteContext), new DeleteContext(studentId, "Student"));

                _discriminatorResolver = A.Fake<IDiscriminatorResolver>();
                A.CallTo(() => _discriminatorResolver.GetDistinctDiscriminators(
                        A<string>.Ignored,
                        A<string>.Ignored,
                        A<Entity>.Ignored,
                        A<Guid>.Ignored,
                        A<int>.Ignored))
                    .Returns(new List<string>());

                const string message =
                    "The DELETE statement conflicted with the REFERENCE constraint \"FK_GeneralStudentProgramAssociation_Student\". " +
                    "The conflict occurred in database \"EdFi_Ods\", table \"edfi.GeneralStudentProgramAssociation\".\r\n" +
                    "The statement has been terminated.";

                _exception = NHibernateExceptionBuilder.CreateException(
                    GenericSqlExceptionMessage,
                    message);
            }

            protected override void Act()
            {
                var translator = new SqlServerConstraintExceptionTranslator(
                    _domainModelProvider,
                    _discriminatorResolver,
                    _dataManagementResourceContextProvider);

                _wasHandled = translator.TryTranslate(_exception, out _actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                _wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_return_a_409_Conflict_error_with_abstract_entity_name()
            {
                _actualError.ShouldSatisfyAllConditions(
                    () => _actualError.ShouldNotBeNull(),
                    () => _actualError.Status.ShouldBe(409),
                    () => _actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    () => _actualError.Detail.ShouldBe(
                        "The requested action cannot be performed because this item is referenced by an existing 'GeneralStudentProgramAssociation' item.")
                );
            }
        }
    }
}

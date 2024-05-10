// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Api.ExceptionHandling.Translators.Postgres;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Definitions.Transformers;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Builders;
using EdFi.TestFixture;
using FakeItEasy;
using NHibernate.Exceptions;
using NUnit.Framework;
using Shouldly;
using Test.Common;
using static EdFi.Ods.Tests._Helpers.DomainModelHelper;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [TestFixture]
    public class PostgresDuplicateKeyExceptionTranslatorTests
    {
        private const string GenericSqlExceptionMessage = "Generic Sql exception message.";

        public class When_a_regular_exception_is_thrown : TestFixtureBase
        {
            private Exception exception;
            private bool result;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                exception = new Exception();
                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                _domainModelProvider = Stub<IDomainModelProvider>();
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                result = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                result.ShouldBeFalse();
            }

            [Test]
            public void Should_RestError_be_null()
            {
                actualError.ShouldBeNull();
            }
        }

        public class When_a_generic_ADO_exception_is_thrown_without_an_inner_exception
            : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                exception = new GenericADOException(GenericSqlExceptionMessage, null);
                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                _domainModelProvider = Stub<IDomainModelProvider>();
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle()
            {
                wasHandled.ShouldBeFalse();
            }

            [Test]
            public void Should_RestError_be_null()
            {
                actualError.ShouldBeNull();
            }
        }

        public class When_a_generic_ADO_exception_is_thrown_with_an_inner_exception_with_the_wrong_sql_state
            : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                const string slightlyWrongMessage = "duplicate key value violates index constraint \"PK_UsersId\"";

                exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    slightlyWrongMessage,
                    Npgsql.PostgresErrorCodes.CheckViolation, // Something we don't translate
                    "edfi",
                    "studentschoolassociation",
                    null);
                
                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                _domainModelProvider = Stub<IDomainModelProvider>();
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle()
            {
                wasHandled.ShouldBeFalse();
            }

            [Test]
            public void Should_RestError_be_null()
            {
                actualError.ShouldBeNull();
            }
        }

        public class When_an_insert_or_update_conflicts_with_the_unique_index_on_a_single_column_primary_key : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"something_pk\"";

                exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    message,
                    PostgresSqlStates.UniqueViolation,
                    "edfi",
                    "educationorganization",
                    "something_pk");

                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                var resource = PrepareTestResource(isCompositePrimaryKey: false);
                A.CallTo(() => _contextProvider.Get()).Returns(new DataManagementResourceContext(resource));
                
                var domainModel = this.LoadDomainModel("StudentSchoolAssociation");
                _domainModelProvider = new SuppliedDomainModelProvider(domainModel);
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_single_value_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Status.ShouldBe(409),
                    () => actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:non-unique-identity")),
                    () => actualError.Detail.ShouldBe("The identifying value(s) of the item are the same as another item that already exists."), 
                    () => actualError.Errors.Single().ShouldBe("A primary key conflict occurred when attempting to create or update a record in the 'EducationOrganization' table.") 
                );
            }
        }

        public class When_an_insert_or_update_conflicts_with_the_unique_index_on_a_composite_primary_key : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"Something_PK\"";

                exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    message,
                    PostgresSqlStates.UniqueViolation,
                    "edfi",
                    "studentschoolassociation",
                    "something_pk");

                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                var resource = PrepareTestResource(isCompositePrimaryKey: true);
                A.CallTo(() => _contextProvider.Get()).Returns(new DataManagementResourceContext(resource));
                
                var domainModel = this.LoadDomainModel("StudentSchoolAssociation");
                _domainModelProvider = new SuppliedDomainModelProvider(domainModel);
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_multiple_values_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Status.ShouldBe(409),
                    () => actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:non-unique-identity")),
                    () => actualError.Detail.ShouldBe("The identifying value(s) of the item are the same as another item that already exists."), 
                    () => actualError.Errors.Single().ShouldBe("A primary key conflict occurred when attempting to create or update a record in the 'StudentSchoolAssociation' table.") 
                );
            }
        }

        public class When_an_insert_or_update_conflicts_with_a_non_pk_unique_index_and_details_are_not_available : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"ux_something_property1\"";

                exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    message,
                    PostgresSqlStates.UniqueViolation,
                    null,
                    null,
                    "ux_something_property1");
                
                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                _domainModelProvider = Stub<IDomainModelProvider>();
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_unknown_value_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Status.ShouldBe(409),
                    () => actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:non-unique-values")),
                    () => actualError.Detail.ShouldBe("A value (or values) in the item must be unique, but another item with these values already exists.")
                );
            }
        }
        
        public class When_an_insert_or_update_conflicts_with_a_non_pk_unique_index_and_details_are_available : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IContextProvider<DataManagementResourceContext> _contextProvider;
            private IDomainModelProvider _domainModelProvider;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"ux_something_property1\"";

                const string details =
                "Key (property1, property2, property3)=(VAL-1, 2, It was three) already exists.";

                exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    message,
                    PostgresSqlStates.UniqueViolation,
                    null,
                    "something",
                    "ux_something_property1",
                    details);
                
                _contextProvider = Stub<IContextProvider<DataManagementResourceContext>>();
                _domainModelProvider = Stub<IDomainModelProvider>();
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicateKeyExceptionTranslator(_contextProvider, _domainModelProvider);
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_unknown_value_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Status.ShouldBe(409),
                    () => actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:non-unique-values")),
                    () => actualError.Detail.ShouldBe("The values supplied for properties 'property1, property2, property3' of entity 'something' are not unique.")
                );
            }
        }
        
        private static Resource PrepareTestResource(bool isCompositePrimaryKey)
        {
            var definitions = new DomainModelDefinitions(
                new SchemaDefinition("Ed-Fi", "edfi"),
                new AggregateDefinition[] { new("edfi.Something", new FullName[] { new("edfi.Something") }) },
                new EntityDefinition[]
                {
                    new(
                        "edfi",
                        "Something",
                        new EntityPropertyDefinition[]
                        {
                            new("Property1", new PropertyType(DbType.String), isIdentifying: true),
                            new("Property2", new PropertyType(DbType.String), isIdentifying: isCompositePrimaryKey),
                            new("Property3", new PropertyType(DbType.String)),
                        },
                        new EntityIdentifierDefinition[]
                        {
                            new(
                                "Something_PK",
                                isCompositePrimaryKey 
                                    ? new[] { "Property1", "Property2" }
                                    : new[] { "Property1" }
                                ,
                                isPrimary: true)
                        }),
                },
                Array.Empty<AssociationDefinition>(),
                Array.Empty<AggregateExtensionDefinition>());

            var definitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
            A.CallTo(() => definitionsProvider.GetDomainModelDefinitions()).Returns(definitions);

            var domainModelProvider = new DomainModelProvider(
                new[] { definitionsProvider },
                Array.Empty<IDomainModelDefinitionsTransformer>());

            var resourceModel = new ResourceModel(domainModelProvider.GetDomainModel());
            var resource = resourceModel.GetAllResources().Single();

            return resource;
        }
    }
}

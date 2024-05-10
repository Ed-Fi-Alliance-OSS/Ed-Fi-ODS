// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling.Translators.Postgres;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Tests._Builders;
using EdFi.Ods.Tests._Helpers;
using EdFi.TestFixture;
using NHibernate.Exceptions;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.ExceptionHandling.Translators.Postgres
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PostgresForeignKeyExceptionTranslatorTests
    {
        private const string GenericSqlExceptionMessage = "Generic Sql exception message.";

        public class When_an_instance_of_Exception_is_being_handled : TestFixtureBase
        {
            private Exception exception;
            private bool result;
            private IEdFiProblemDetails actualError;

            protected override void Arrange()
            {
                exception = new Exception();
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator(Stub<IDomainModelProvider>());
                
                result = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                result.ShouldBeFalse();
            }

            [Test]
            public void Should_return_error_as_null()
            {
                actualError.ShouldBeNull();
            }
        }

        public class When_a_GenericAdoException_without_an_inner_exception_is_being_handled
            : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;

            protected override void Arrange()
            {
                exception = new GenericADOException(GenericSqlExceptionMessage, null);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator(Stub<IDomainModelProvider>());

                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                wasHandled.ShouldBeFalse();
            }

            [Test]
            public void Should_return_error_as_null()
            {
                actualError.ShouldBeNull();
            }
        }

        public class When_an_insert_or_update_violated_a_foreign_key_constraint : TestFixtureBase
        {
            private Exception _exception;
            private bool _wasHandled;
            private IEdFiProblemDetails _actualError;
            private IDomainModelProvider _domainModelProvider;
            // private ContextProvider<DataManagementResourceContext> _contextProvider;
            
            /*
                Severity:           ERROR
                InvariantSeverity:  ERROR
                SqlState:           23503
                MessageText:        insert or update on table "studentschoolassociation" violates foreign key constraint "fk_857b52_student"
                Detail:             Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
                SchemaName:         edfi
                TableName:          studentschoolassociation
                ConstraintName:     fk_857b52_student
                File:               ri_triggers.c
                Line:               2463
                Routine:            ri_ReportViolation
             */

            protected override void Arrange()
            {
                var domainModel = this.LoadDomainModel("StudentSchoolAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                // var resourceModel = new ResourceModel(domainModel);
                // var resource = resourceModel.GetResourceByApiCollectionName("ed-fi", "studentSchoolAssociations");
                // _contextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                // _contextProvider.Set(new DataManagementResourceContext(resource));

                const string message = "insert or update on table \"studentschoolassociation\" violates foreign key constraint \"fk_857b52_student\"";

                _exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage, 
                    message, 
                    PostgresSqlStates.ForeignKeyViolation,
                    "edfi",
                    "studentschoolassociation",
                    "fk_857b52_school");
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator(_domainModelProvider);
                _wasHandled = translator.TryTranslate(_exception, out _actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                _wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_simple_constraint_message()
            {
                AssertHelper.All(
                    () => _actualError.ShouldNotBeNull(),
                    () => _actualError.Status.ShouldBe(409),
                    () => _actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:unresolved-reference")),
                    () => _actualError.Detail.ShouldBe("The referenced 'School' item does not exist.")
                );
            }
        }

        public class When_an_update_or_delete_violates_a_foreign_key_constraint : TestFixtureBase
        {
            private Exception _exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IDomainModelProvider _domainModelProvider;
            // private ContextProvider<DataManagementResourceContext> _contextProvider;

            /*
                Severity:           ERROR
                InvariantSeverity:  ERROR
                SqlState:           23503
                MessageText:        update or delete on table "student" violates foreign key constraint "fk_0ff8d6_student" on table "studentacademicrecord"
                Detail:             Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
                SchemaName:         edfi
                TableName:          studentacademicrecord
                ConstraintName:     fk_0ff8d6_student
                File:               ri_triggers.c
                Line:               2476
                Routine:            ri_ReportViolation
             */

            protected override void Arrange()
            {
                //Arrange
                var domainModel = this.LoadDomainModel("StudentSchoolAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                // var resourceModel = new ResourceModel(domainModel);
                // var resource = resourceModel.GetResourceByApiCollectionName("ed-fi", "studentSchoolAssociations");
                // _contextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                // _contextProvider.Set(new DataManagementResourceContext(resource));

                const string message = "update or delete on table \"school\" violates foreign key constraint \"fk_857b52_school\" on table \"studentschoolassociation\"";

                _exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    message,
                    PostgresSqlStates.ForeignKeyViolation,
                    "edfi",
                    "studentschoolassociation",
                    "fk_857b52_school");
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator(_domainModelProvider);
                wasHandled = translator.TryTranslate(_exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_return_a_409_Conflict_error_with_a_message_identifying_the_dependent_entity()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Status.ShouldBe(409),
                    () => actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    () => actualError.Detail.ShouldBe("The requested action cannot be performed because this item is referenced by an existing 'StudentSchoolAssociation' item.") 
                );
            }
        }

        public class When_an_update_or_delete_conflicts_with_a_foreign_key_constraint_that_is_not_defined_in_the_database_metadata : TestFixtureBase
        {
            private Exception _exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;
            private IDomainModelProvider _domainModelProvider;
            // private ContextProvider<DataManagementResourceContext> _contextProvider;

            /*
                Severity:           ERROR
                InvariantSeverity:  ERROR
                SqlState:           23503
                MessageText:        update or delete on table "student" violates foreign key constraint "fk_0ff8d6_student" on table "studentacademicrecord"
                Detail:             Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
                SchemaName:         edfi
                TableName:          studentacademicrecord
                ConstraintName:     fk_0ff8d6_student
                File:               ri_triggers.c
                Line:               2476
                Routine:            ri_ReportViolation
             */

            protected override void Arrange()
            {
                //Arrange
                var domainModel = this.LoadDomainModel("StudentSchoolAssociation");
                _domainModelProvider = new DomainModelHelper.SuppliedDomainModelProvider(domainModel);

                // var resourceModel = new ResourceModel(domainModel);
                // var resource = resourceModel.GetResourceByApiCollectionName("ed-fi", "studentSchoolAssociations");
                // _contextProvider = new ContextProvider<DataManagementResourceContext>(new HashtableContextStorage());
                // _contextProvider.Set(new DataManagementResourceContext(resource));

                const string message = "update or delete on table \"school\" violates foreign key constraint \"fk_857b52_school\" on table \"studentschoolassociation\"";

                _exception = NHibernateExceptionBuilder.CreateWrappedPostgresException(
                    GenericSqlExceptionMessage,
                    message,
                    PostgresSqlStates.ForeignKeyViolation,
                    "edfi",
                    "studentschoolassociation",
                    "NOT-IN-SUPPLIED-METADATA"); // <---------- Constraint name doesn't exist in metadata
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator(_domainModelProvider);
                wasHandled = translator.TryTranslate(_exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_return_a_409_Conflict_error_with_a_message_indicating_a_dependency_exists_even_if_it_cannot_be_identified()
            {
                actualError.ShouldSatisfyAllConditions(
                    e => e.ShouldNotBeNull(),
                    e => e.Status.ShouldBe(409),
                    e => e.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:dependent-item-exists")),
                    e => e.Detail.ShouldBe(
                        "The requested action cannot be performed because this data item is referenced by an existing 'StudentSchoolAssociation' data item."));
            }
        }
    }
}
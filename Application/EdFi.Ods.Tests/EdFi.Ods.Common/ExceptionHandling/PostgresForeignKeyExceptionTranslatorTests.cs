// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.ExceptionHandling.Translators.Postgres;
using EdFi.Ods.Api.Common.Models;
using EdFi.TestFixture;
using NHibernate.Exceptions;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.ExceptionHandling
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PostgresForeignKeyExceptionTranslatorTests
    {
        private const string GenericSqlExceptionMessage = "Generic Sql exception message.";

        public class When_a_regular_exception_is_thrown : TestFixtureBase
        {
            private Exception exception;
            private bool result;
            private RESTError actualError;

            protected override void Arrange()
            {
                exception = new Exception();
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                result = translator.TryTranslateMessage(exception, out actualError);
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
            private RESTError actualError;

            protected override void Arrange()
            {
                exception = new GenericADOException(GenericSqlExceptionMessage, null);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
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

        public class When_a_generic_ADO_exception_is_thrown_with_an_inner_exception_with_the_wrong_message
            : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string slightlyWrongMessage =
                    "inserting or updating on table \"DependentTable\" violates foreign key constraint \"FK_MainTable_DependentTable\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, slightlyWrongMessage);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
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

        public class When_an_insert_or_update_conflicts_with_a_simple_foreign_key : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message =
                    "insert or update on table \"DependentTable\" violates foreign key constraint \"FK_MainTable_DependentTable\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_simple_constraint_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_insert_or_update_conflicts_with_a_composed_foreign_key : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message =
                    "insert or update on table \"DoublePrimaryKeys\" violates foreign key constraint \"FK_DoubleDependent_DoublePrimaryKeys\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_composed_constraint_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_insert_or_update_conflicts_with_a_foreign_key_and_metadata_is_not_provided : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message =
                    "insert or update on table \"DependentTable\" violates foreign key constraint \"FK_MainTable_DependentTable\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_normal_constraint_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_update_or_delete_conflicts_with_a_simple_foreign_key : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message =
                    "update or delete on table \"DependentTable\" violates foreign key constraint \"FK_MainTable_DependentTable\" on table \"MainTable\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_simple_constraint_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_update_or_delete_conflicts_with_a_composed_foreign_key : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message =
                    "update or delete on table \"DoublePrimaryKeys\" violates foreign key constraint \"FK_DoubleDependent_DoublePrimaryKeys\" on table \"DoubleDependent\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_composed_constraint_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_update_or_delete_conflicts_with_a_foreign_key_and_metadata_is_not_provided : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message =
                    "update or delete on table \"DependentTable\" violates foreign key constraint \"FK_MainTable_DependentTable\" on table \"MainTable\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresForeignKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_exception()
            {
                wasHandled.ShouldBeTrue();
            }

            [Test]
            public void Should_RestError_show_unknown_key_message()
            {
                AssertHelper.All(
                    () => actualError.ShouldNotBeNull(),
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }
    }
}

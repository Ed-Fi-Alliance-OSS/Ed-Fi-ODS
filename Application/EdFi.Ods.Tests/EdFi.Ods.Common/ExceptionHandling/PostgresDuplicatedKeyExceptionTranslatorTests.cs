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
    public class PostgresDuplicatedKeyExceptionTranslatorTests
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
                var translator = new PostgresDuplicatedKeyExceptionTranslator();
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
                var translator = new PostgresDuplicatedKeyExceptionTranslator();
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
                const string slightlyWrongMessage = "duplicate key value violates index constraint \"PK_UsersId\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, slightlyWrongMessage);
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicatedKeyExceptionTranslator();
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

        public class When_an_insert_conflicts_with_a_unique_index_with_a_simple_key_constraint : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"PK_ApplicationId\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicatedKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
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
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_insert_conflicts_with_a_unique_index_with_a_composed_key_constraint : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"PK_ApplicationId\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicatedKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
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
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }

        public class When_an_insert_conflicts_with_a_unique_index_and_metadata_is_not_provided : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void Arrange()
            {
                const string message = "duplicate key value violates unique constraint \"PK_ApplicationId\"";

                exception = NHibernateExceptionBuilder.CreatePostgresException(GenericSqlExceptionMessage, message);
            }

            protected override void Act()
            {
                var translator = new PostgresDuplicatedKeyExceptionTranslator();
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
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
                    () => actualError.Code = 409,
                    () => actualError.Type = "Conflict"
                );
            }
        }
    }
}

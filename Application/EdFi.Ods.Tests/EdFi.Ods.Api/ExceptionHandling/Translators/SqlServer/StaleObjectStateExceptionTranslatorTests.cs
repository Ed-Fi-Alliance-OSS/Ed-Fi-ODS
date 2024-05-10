// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.ExceptionHandling.Translators;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Tests._Builders;
using EdFi.TestFixture;
using NHibernate;
using NHibernate.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.ExceptionHandling
{
    public class StaleObjectStateExceptionTranslatorTests
    {
        [TestFixture]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_a_regular_exception_is_thrown : TestFixtureBase
        {
            private Exception exception;
            private bool result;

            protected override void Arrange()
            {
                exception = new Exception();
            }

            protected override void Act()
            {
                var translator = new StaleObjectStateExceptionTranslator();
                IEdFiProblemDetails actualError;
                result = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                result.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_a_generic_ADO_exception_is_thrown_without_an_inner_exception
            : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;

            protected override void Arrange()
            {
                exception = new GenericADOException("Generic exception message", null);
            }

            protected override void Act()
            {
                var translator = new StaleObjectStateExceptionTranslator();
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle()
            {
                wasHandled.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_a_generic_ADO_exception_is_thrown_with_an_inner_exception_with_the_wrong_message
            : TestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private IEdFiProblemDetails actualError;

            protected override void Arrange()
            {
                const string slightlyWrongMessage =
                    "VViolation of PRIMARY KEY constraint 'PK_Session'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). The statement has been terminated.";

                exception = NHibernateExceptionBuilder.CreateException("Some generic SQL Exception message", slightlyWrongMessage);
            }

            protected override void Act()
            {
                var translator = new StaleObjectStateExceptionTranslator();
                wasHandled = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle()
            {
                wasHandled.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_an_nHibernate_StaleObjectState_exception_is_thrown : TestFixtureBase
        {
            private Exception exception;
            private bool result;
            private IEdFiProblemDetails actualError;

            protected override void Arrange()
            {
                exception = new StaleObjectStateException("Some entity", "some object key");
            }

            protected override void Act()
            {
                var translator = new StaleObjectStateExceptionTranslator();
                result = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_handle_this_exception()
            {
                result.ShouldBeTrue();
            }

            [Test]
            public void Should_set_a_reasonable_message()
            {
                actualError.Detail.ShouldBe(
                    "The resource item was modified or deleted by another user while processing the request. Resending this request will either recreate the item, or introduce of copy with a different identifier.");
            }

            [Test]
            public void Should_set_the_exception_type_to_conflict()
            {
                actualError.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "data-conflict:multi-user-conflict"));
            }

            [Test]
            public void Should_translate_the_exception_to_a_409_error()
            {
                actualError.Status.ShouldBe(409);
            }
        }

        [TestFixture]
        public class When_an_nHibernate_ADO_exception_is_thrown_with_an_inner_exception_of_the_wrong_type : TestFixtureBase
        {
            private Exception exception;
            private bool result;
            private IEdFiProblemDetails actualError;

            protected override void Arrange()
            {
                var mess =
                    "Violation of PRIMARY KEY constraint 'PK_Session'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). The statement has been terminated.";

                var innerexception = new Exception(mess);
                exception = new GenericADOException("Generic exception message", innerexception);
            }

            protected override void Act()
            {
                var translator = new StaleObjectStateExceptionTranslator();
                result = translator.TryTranslate(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                result.ShouldBeFalse();
            }
        }
    }
}
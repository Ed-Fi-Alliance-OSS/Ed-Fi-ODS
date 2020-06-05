// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Common.ExceptionHandling.Translators.SqlServer;
using EdFi.Ods.Api.Common.Models;
using EdFi.Ods.Api.Common.Providers;
using NHibernate.Exceptions;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.ExceptionHandling
{
    public class DuplicateNaturalKeyCreateExceptionTranslatorTests
    {
        [TestFixture]
        public class When_a_regular_exception_is_thrown : LegacyTestFixtureBase
        {
            private Exception exception;
            private bool result;

            protected override void EstablishContext()
            {
                exception = new Exception();
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(mocks.StrictMock<IDatabaseMetadataProvider>());
                RESTError actualError;
                result = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                result.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_a_generic_ADO_exception_is_thrown_without_an_inner_exception
            : LegacyTestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void EstablishContext()
            {
                exception = new GenericADOException("Generic exception message", null);
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(mocks.StrictMock<IDatabaseMetadataProvider>());
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_not_handle()
            {
                wasHandled.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_a_generic_ADO_exception_is_thrown_with_an_inner_exception_with_the_wrong_message
            : LegacyTestFixtureBase
        {
            private Exception exception;
            private bool wasHandled;
            private RESTError actualError;

            protected override void EstablishContext()
            {
                const string slightlyWrongMessage =
                    "VViolation of PRIMARY KEY constraint 'PK_Session'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). The statement has been terminated.";

                exception = NHibernateExceptionBuilder.CreateException("Some generic SQL Exception message", slightlyWrongMessage);
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(mocks.StrictMock<IDatabaseMetadataProvider>());
                wasHandled = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_not_handle()
            {
                wasHandled.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_an_nHibernate_ADO_exception_is_thrown_with_an_inner_SQL_exception_primary_key_violation : LegacyTestFixtureBase
        {
            private IDatabaseMetadataProvider suppliedMetadataProvider;
            private Exception exception;
            private bool result;
            private RESTError actualError;

            protected override void EstablishContext()
            {
                const string mess =
                    "Violation of PRIMARY KEY constraint 'PK_Session'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). \r\nThe statement has been terminated.";

                exception = NHibernateExceptionBuilder.CreateException("Generic SQL Exception message...", mess);
                suppliedMetadataProvider = mocks.StrictMock<IDatabaseMetadataProvider>();

                SetupResult.For(suppliedMetadataProvider.GetIndexDetails("PK_Session"))
                           .Return(
                                new IndexDetails
                                {
                                    IndexName = "SomeIndexName", TableName = "Session", ColumnNames = new List<string>
                                                                                                      {
                                                                                                          "Column1", "Column2", "Column3"
                                                                                                      }
                                });
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(suppliedMetadataProvider);
                result = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_this_exception()
            {
                result.ShouldBeTrue();
            }

            [Test]
            public void Should_set_a_reasonable_message()
            {
                actualError.Message.ShouldBe(
                    "A natural key conflict occurred when attempting to create a new resource 'Session' with a duplicate key.  The duplicated columns and values are [Column1, Column2, Column3] (900007, 9, 2014) This is likely caused by multiple resources with the same key in the same file. Exactly one of these resources was inserted.");
            }

            [Test]
            public void Should_set_the_exception_type_to_conflict()
            {
                actualError.Type.ShouldBe("Conflict");
            }

            [Test]
            public void Should_translate_the_exception_to_a_409_error()
            {
                actualError.Code.ShouldBe(409);
            }
        }

        [TestFixture]
        public class When_an_nHibernate_ADO_exception_is_thrown_with_an_inner_SQL_exception_primary_key_violation_for_unknown_index : LegacyTestFixtureBase
        {
            private IDatabaseMetadataProvider suppliedMetadataProvider;
            private Exception exception;
            private bool result;
            private RESTError actualError;

            protected override void EstablishContext()
            {
                const string mess =
                    "Violation of PRIMARY KEY constraint 'PK_Session'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). \r\nThe statement has been terminated.";

                exception = NHibernateExceptionBuilder.CreateException("Generic SQL Exception message...", mess);
                suppliedMetadataProvider = mocks.StrictMock<IDatabaseMetadataProvider>();

                SetupResult.For(suppliedMetadataProvider.GetIndexDetails("PK_Session"))
                           .Return(null);
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(suppliedMetadataProvider);
                result = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_this_exception()
            {
                result.ShouldBeTrue();
            }

            [Test]
            public void Should_set_a_reasonable_message()
            {
                actualError.Message.ShouldBe(
                    "A natural key conflict occurred when attempting to create a new resource 'unknown' with a duplicate key.  The duplicated columns and values are [unknown] (900007, 9, 2014) This is likely caused by multiple resources with the same key in the same file. Exactly one of these resources was inserted.");
            }
        }

        [TestFixture]
        public class When_an_nHibernate_ADO_exception_is_thrown_with_an_inner_SQL_exception_primary_key_violation_and_a_backwards_PK_name
            : LegacyTestFixtureBase
        {
            private IDatabaseMetadataProvider suppliedMetadataProvider;
            private Exception exception;
            private bool result;
            private RESTError actualError;

            protected override void EstablishContext()
            {
                var mess =
                    "Violation of PRIMARY KEY constraint 'BackwardsPkName_PK'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). \r\nThe statement has been terminated.";

                exception = NHibernateExceptionBuilder.CreateException("Generic exception message", mess);
                suppliedMetadataProvider = mocks.StrictMock<IDatabaseMetadataProvider>();

                SetupResult.For(suppliedMetadataProvider.GetIndexDetails("BackwardsPkName_PK"))
                           .Return(null);
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(suppliedMetadataProvider);
                result = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_handle_this_exception()
            {
                result.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_an_nHibernate_ADO_exception_is_thrown_with_an_inner_exception_of_the_wrong_type : LegacyTestFixtureBase
        {
            private Exception exception;
            private bool result;
            private RESTError actualError;

            protected override void EstablishContext()
            {
                var mess =
                    "Violation of PRIMARY KEY constraint 'PK_Session'. Cannot insert duplicate key in object 'edfi.Session'. The duplicate key value is (900007, 9, 2014). The statement has been terminated.";

                var innerexception = new Exception(mess);
                exception = new GenericADOException("Generic exception message", innerexception);
            }

            protected override void ExecuteBehavior()
            {
                var translator = new DuplicateNaturalKeyCreateExceptionTranslator(mocks.StrictMock<IDatabaseMetadataProvider>());
                result = translator.TryTranslateMessage(exception, out actualError);
            }

            [Test]
            public void Should_not_handle_this_exception()
            {
                result.ShouldBeFalse();
            }
        }
    }
}

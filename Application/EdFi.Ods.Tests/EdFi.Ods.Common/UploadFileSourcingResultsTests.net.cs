// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    public class UploadFileSourcingResultsTests
    {
        [TestFixture]
        public class When_result_is_created_without_failure_messages
        {
            private UploadFileSourcingResults _result;

            [OneTimeSetUp]
            public void Setup()
            {
                _result = UploadFileSourcingResults.WithSuccessPath(@"some\crazy\path");
            }

            [Test]
            public void Should_indicate_result_is_not_a_failure()
            {
                _result.IsFailure.ShouldBeFalse();
            }

            [Test]
            public void Should_provide_file_path()
            {
                _result.FilePathIfValid.ShouldBe(@"some\crazy\path");
            }
        }

        [TestFixture]
        public class When_result_is_created_with_multiple_failure_messages
        {
            private UploadFileSourcingResults _result;

            [OneTimeSetUp]
            public void Setup()
            {
                _result = UploadFileSourcingResults.WithValidationErrorMessages(
                    new[]
                    {
                        "foo", "bar"
                    });
            }

            [Test]
            public void Should_indicate_result_is_a_failure()
            {
                _result.IsFailure.ShouldBeTrue();
            }

            [Test]
            public void Should_provide_failure_message()
            {
                _result.ValidationErrorMessages.Length.ShouldBe(2);
                _result.ValidationErrorMessages.ShouldContain("foo");
                _result.ValidationErrorMessages.ShouldContain("bar");
            }
        }

        [TestFixture]
        public class When_result_is_created_with_a_single_failure_message
        {
            private UploadFileSourcingResults _result;

            [OneTimeSetUp]
            public void Setup()
            {
                _result = UploadFileSourcingResults.WithValidationErrorMessage("foo");
            }

            [Test]
            public void Should_indicate_result_is_a_failure()
            {
                _result.IsFailure.ShouldBeTrue();
            }

            [Test]
            public void Should_provide_failure_message()
            {
                _result.ValidationErrorMessages.Length.ShouldBe(1);
                _result.ValidationErrorMessages.ShouldContain("foo");
            }
        }
    }
}

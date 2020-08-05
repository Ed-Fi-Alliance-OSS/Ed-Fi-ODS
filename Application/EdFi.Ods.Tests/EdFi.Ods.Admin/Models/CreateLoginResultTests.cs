// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Admin.Models.Results;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Admin.Models
{
    public class CreateLoginResultTests
    {
        [TestFixture]
        public class When_adding_failures
        {
            private string[] _failingFields;

            [OneTimeSetUp]
            public void Setup()
            {
                var result = new CreateLoginResult()
                            .AddFailingField(x => x.Email)
                            .AddFailingField(x => x.Name)
                            .AddFailingField(x => x.Name) //duplicate
                            .AddFailingField(x => x.Name); //duplicate

                _failingFields = result.FailingFields;
            }

            [Test]
            public void Should_keep_unique_failing_fields()
            {
                _failingFields.Length.ShouldBe(2);
            }

            [Test]
            public void Should_persist_field_names_as_all_lowercase()
            {
                _failingFields.ShouldContain("email");
                _failingFields.ShouldContain("name");
            }
        }

        [TestFixture]
        public class When_result_has_message
        {
            [Test]
            public void Should_indicate_that_message_exists()
            {
                new CreateLoginResult().HasMessage.ShouldBeFalse();

                new CreateLoginResult
                {
                    Message = "Foo"
                }.HasMessage.ShouldBeTrue();
            }
        }
    }
}

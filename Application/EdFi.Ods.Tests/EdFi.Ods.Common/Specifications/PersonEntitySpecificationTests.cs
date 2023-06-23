// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Specifications;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;
using NHibernateEntities = EdFi.Ods.Entities.NHibernate;
using ModelResources = EdFi.Ods.Api.Common.Models.Resources;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    public class PersonType1 { }

    public class NotAPersonType { }

    [TestFixture]
    public class PersonEntitySpecificationTests
    {
        [TestFixture]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_determining_if_an_entity_or_resource_is_a_person : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_person_type_entity_by_type_or_by_name()
            {
                var personTypesProvider = GetPersonTypesProvider();
                var personEntitySpecification = new PersonEntitySpecification(personTypesProvider);

                AssertHelper.All(
                    () => Assert.That(personEntitySpecification.IsPersonEntity(typeof(PersonType1)), Is.True),
                    () => Assert.That(personEntitySpecification.IsPersonEntity(nameof(PersonType1)), Is.True));
            }

            [Assert]
            public void Should_return_false_for_non_person_type_entity()
            {
                var personTypesProvider = GetPersonTypesProvider();
                var personEntitySpecification = new PersonEntitySpecification(personTypesProvider);

                AssertHelper.All(
                    () => Assert.That(personEntitySpecification.IsPersonEntity(typeof(NotAPersonType)), Is.False),
                    () => Assert.That(personEntitySpecification.IsPersonEntity(nameof(NotAPersonType)), Is.False));
            }

            private static IPersonTypesProvider GetPersonTypesProvider()
            {
                var personTypesProvider = A.Fake<IPersonTypesProvider>();

                A.CallTo(() => personTypesProvider.PersonTypes)
                .Returns(
                    new[]
                    {
                        "PersonType1",
                        "PersonType2"
                    });

                return personTypesProvider;
            }
        }
    }
}

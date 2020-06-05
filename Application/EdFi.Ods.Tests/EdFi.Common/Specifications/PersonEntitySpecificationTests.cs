// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using NHibernateEntities = EdFi.Ods.Entities.NHibernate;
using ModelResources = EdFi.Ods.Api.Common.Models.Resources;
using EdFi.Ods.Common.Specifications;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    [TestFixture]
    public class PersonEntitySpecificationTests
    {
        [TestFixture]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class When_determining_if_an_entity_or_resource_is_a_person : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_staff_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            typeof(NHibernateEntities.StaffAggregate.EdFi.Staff)), Is.True),
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            nameof(NHibernateEntities.StaffAggregate.EdFi.Staff)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_staff_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            typeof(ModelResources.Staff.EdFi.Staff)), Is.True),
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            nameof(ModelResources.Staff.EdFi.Staff)), Is.True)
                );
            }

            //Student
            [Assert]
            public void Should_return_true_for_student_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            typeof(NHibernateEntities.StudentAggregate.EdFi.Student)), Is.True),
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            nameof(NHibernateEntities.StudentAggregate.EdFi.Student)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_student_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            typeof(ModelResources.Student.EdFi.Student)), Is.True),
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            nameof(ModelResources.Student.EdFi.Student)), Is.True)
                );
            }
           
            [Assert]
            public void Should_return_true_for_parent_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            typeof(NHibernateEntities.ParentAggregate.EdFi.Parent)), Is.True),
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            nameof(NHibernateEntities.ParentAggregate.EdFi.Parent)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_parent_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            typeof(ModelResources.Parent.EdFi.Parent)), Is.True),
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonEntity(
                            nameof(ModelResources.Parent.EdFi.Parent)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_parent_Identifier_property()
            {
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonIdentifier(
                            nameof(NHibernateEntities.ParentAggregate.EdFi.Parent.ParentUniqueId)), Is.True)
                );
                AssertHelper.All(
                    () => Assert.That(
                        PersonEntitySpecification.IsPersonIdentifier(
                            nameof(NHibernateEntities.ParentAggregate.EdFi.Parent.ParentUSI)), Is.True)
                );
            }
        }
    }
}

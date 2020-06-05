// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Specifications;
using EdFi.TestFixture;
using NHibernateEntities = EdFi.Ods.Entities.NHibernate;
using ModelResources = EdFi.Ods.Api.Common.Models.Resources;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AssessmentSpecificationTests
    {
        public class When_determining_if_an_entity_is_a_member_of_assessment_metadata : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_an_assessment_item_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(NHibernateEntities.AssessmentItemAggregate.EdFi.AssessmentItem)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(NHibernateEntities.AssessmentItemAggregate.EdFi.AssessmentItem)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_assessment_item_resource()
            {
                AssertHelper.All(
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(typeof(ModelResources.AssessmentItem.EdFi.AssessmentItem)), Is.True),
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(nameof(ModelResources.AssessmentItem.EdFi.AssessmentItem)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_assessment_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(NHibernateEntities.AssessmentAggregate.EdFi.Assessment)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(NHibernateEntities.AssessmentAggregate.EdFi.Assessment)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_assessment_resource()
            {
                AssertHelper.All(
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(typeof(ModelResources.Assessment.EdFi.Assessment)), Is.True),
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(nameof(ModelResources.Assessment.EdFi.Assessment)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_objective_assessment_item_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(NHibernateEntities.ObjectiveAssessmentAggregate.EdFi.ObjectiveAssessment)),
                        Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(NHibernateEntities.ObjectiveAssessmentAggregate.EdFi.ObjectiveAssessment)),
                        Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_objective_assessment_item_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(ModelResources.ObjectiveAssessment.EdFi.ObjectiveAssessment)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(ModelResources.ObjectiveAssessment.EdFi.ObjectiveAssessment)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_student_assessment_item_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(NHibernateEntities.StudentAssessmentAggregate.EdFi.StudentAssessment)),
                        Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(NHibernateEntities.StudentAssessmentAggregate.EdFi.StudentAssessment)),
                        Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_student_assessment_item_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(ModelResources.StudentAssessment.EdFi.StudentAssessment)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(ModelResources.StudentAssessment.EdFi.StudentAssessment)), Is.True)
                );
            }
        }
    }
}

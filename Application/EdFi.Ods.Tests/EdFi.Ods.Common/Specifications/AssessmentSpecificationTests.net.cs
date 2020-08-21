// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.AssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.AssessmentItemAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.ObjectiveAssessmentAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.StudentAssessmentAggregate.EdFi;
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
                        AssessmentSpecification.IsAssessmentEntity(typeof(AssessmentItem)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(AssessmentItem)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_assessment_item_resource()
            {
                AssertHelper.All(
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(typeof(Api.Common.Models.Resources.AssessmentItem.EdFi.AssessmentItem)), Is.True),
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(nameof(Api.Common.Models.Resources.AssessmentItem.EdFi.AssessmentItem)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_assessment_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(Assessment)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(Assessment)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_assessment_resource()
            {
                AssertHelper.All(
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(typeof(Api.Common.Models.Resources.Assessment.EdFi.Assessment)), Is.True),
                    () => Assert.That(AssessmentSpecification.IsAssessmentEntity(nameof(Api.Common.Models.Resources.Assessment.EdFi.Assessment)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_objective_assessment_item_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(ObjectiveAssessment)),
                        Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(ObjectiveAssessment)),
                        Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_objective_assessment_item_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(Api.Common.Models.Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(Api.Common.Models.Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_student_assessment_item_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(StudentAssessment)),
                        Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(StudentAssessment)),
                        Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_an_student_assessment_item_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(typeof(Api.Common.Models.Resources.StudentAssessment.EdFi.StudentAssessment)), Is.True),
                    () => Assert.That(
                        AssessmentSpecification.IsAssessmentEntity(nameof(Api.Common.Models.Resources.StudentAssessment.EdFi.StudentAssessment)), Is.True)
                );
            }
        }
    }
}
#endif
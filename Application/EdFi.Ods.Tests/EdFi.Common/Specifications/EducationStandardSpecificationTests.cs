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
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EducationStandardSpecificationTests
    {
        public class When_determining_if_an_entity_or_resource_is_a_educationStandard : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_learningStandard_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(NHibernateEntities.LearningStandardAggregate.EdFi.LearningStandard)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(NHibernateEntities.LearningStandardAggregate.EdFi.LearningStandard)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_learningStandard_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(ModelResources.LearningStandard.EdFi.LearningStandard)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(ModelResources.LearningStandard.EdFi.LearningStandard)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_learningObjective_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(NHibernateEntities.LearningObjectiveAggregate.EdFi.LearningObjective)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(NHibernateEntities.LearningObjectiveAggregate.EdFi.LearningObjective)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_learningObjective_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(ModelResources.LearningObjective.EdFi.LearningObjective)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(ModelResources.LearningObjective.EdFi.LearningObjective)), Is.True)
                );
            }

            //Credential
            [Assert]
            public void Should_return_true_for_credential_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(NHibernateEntities.CredentialAggregate.EdFi.Credential)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(NHibernateEntities.CredentialAggregate.EdFi.Credential)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_credential_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(ModelResources.Credential.EdFi.Credential)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(ModelResources.Credential.EdFi.Credential)), Is.True)
                );
            }
        }
    }
}

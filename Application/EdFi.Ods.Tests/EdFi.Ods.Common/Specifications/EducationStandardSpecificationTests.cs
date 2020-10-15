// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using NHibernateEntities = EdFi.Ods.Entities.NHibernate;
using ModelResources = EdFi.Ods.Api.Common.Models.Resources;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.CredentialAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LearningObjectiveAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.LearningStandardAggregate.EdFi;
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
                            typeof(LearningStandard)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(LearningStandard)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_learningStandard_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(Api.Common.Models.Resources.LearningStandard.EdFi.LearningStandard)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(Api.Common.Models.Resources.LearningStandard.EdFi.LearningStandard)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_learningObjective_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(LearningObjective)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(LearningObjective)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_learningObjective_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(Api.Common.Models.Resources.LearningObjective.EdFi.LearningObjective)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(Api.Common.Models.Resources.LearningObjective.EdFi.LearningObjective)), Is.True)
                );
            }

            //Credential
            [Assert]
            public void Should_return_true_for_credential_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(Credential)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(Credential)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_credential_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(Api.Common.Models.Resources.Credential.EdFi.Credential)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(Api.Common.Models.Resources.Credential.EdFi.Credential)), Is.True)
                );
            }
        }
    }
}
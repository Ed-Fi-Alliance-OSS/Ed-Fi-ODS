// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
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
            // LearningStandard
            [Assert]
            public void Should_return_true_for_learningStandard_type()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(EducationStandardSpecificationTestDummyClasses.LearningStandard)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(EducationStandardSpecificationTestDummyClasses.LearningStandard)), Is.True)
                );
            }
            
            // LearningObjective
            [Assert]
            public void Should_return_true_for_learningObjective_type()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(EducationStandardSpecificationTestDummyClasses.LearningObjective)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(EducationStandardSpecificationTestDummyClasses.LearningObjective)), Is.True)
                );
            }
            

            // LearningStandardEquivalenceAssociation
            [Assert]
            public void Should_return_true_for_learningStandardEquivalenceAssociation_type()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(EducationStandardSpecificationTestDummyClasses.LearningStandardEquivalenceAssociation)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(EducationStandardSpecificationTestDummyClasses.LearningStandardEquivalenceAssociation)), Is.True)
                );
            }
            
            // Credential
            [Assert]
            public void Should_return_true_for_credential_type()
            {
                AssertHelper.All(
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            typeof(EducationStandardSpecificationTestDummyClasses.Credential)), Is.True),
                    () => Assert.That(
                        EducationStandardSpecification.IsEducationStandardEntity(
                            nameof(EducationStandardSpecificationTestDummyClasses.Credential)), Is.True)
                );
            }
        }
    }
}

namespace EducationStandardSpecificationTestDummyClasses
{
    public class LearningStandard { }
    public class LearningObjective { }
    public class LearningStandardEquivalenceAssociation { }
    public class Credential { }
}
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
    public class ManagedDescriptorSpecificationTests
    {
        public class When_determining_if_an_entity_or_resource_is_a_managed_descriptor : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_accommodation_descriptor_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(NHibernateEntities.AccommodationDescriptorAggregate.EdFi.AccommodationDescriptor)), Is.True),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(NHibernateEntities.AccommodationDescriptorAggregate.EdFi.AccommodationDescriptor)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_accommodation_descriptor_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(ModelResources.AccommodationDescriptor.EdFi.AccommodationDescriptor)), Is.True),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(ModelResources.AccommodationDescriptor.EdFi.AccommodationDescriptor)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_assessmentPeriod_descriptor_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(NHibernateEntities.AssessmentPeriodDescriptorAggregate.EdFi.AssessmentPeriodDescriptor)), Is.True),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(NHibernateEntities.AssessmentPeriodDescriptorAggregate.EdFi.AssessmentPeriodDescriptor)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_assessmentPeriod_descriptor_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(ModelResources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor)), Is.True),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(ModelResources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor)), Is.True)
                );
            }

            [Assert]
            public void Should_return_false_for_competencyLevel_descriptor_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(NHibernateEntities.CompetencyLevelDescriptorAggregate.EdFi.CompetencyLevelDescriptor)), Is.False),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(NHibernateEntities.CompetencyLevelDescriptorAggregate.EdFi.CompetencyLevelDescriptor)), Is.False)
                );
            }

            [Assert]
            public void Should_return_false_for_competencyLevel_descriptor_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(ModelResources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor)), Is.False),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(ModelResources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor)), Is.False)
                );
            }

            [Assert]
            public void Should_return_false_for_diagnosis_descriptor_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(NHibernateEntities.DiagnosisDescriptorAggregate.EdFi.DiagnosisDescriptor)), Is.False),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(NHibernateEntities.DiagnosisDescriptorAggregate.EdFi.DiagnosisDescriptor)), Is.False)
                );
            }

            [Assert]
            public void Should_return_false_for_diagnosis_descriptor_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(ModelResources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor)),
                        Is.False),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(ModelResources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor)),
                        Is.False)
                );
            }

            [Assert]
            public void Should_return_true_for_performanceLevel_descriptor_entity()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(NHibernateEntities.PerformanceLevelDescriptorAggregate.EdFi.PerformanceLevelDescriptor)), Is.True),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(NHibernateEntities.PerformanceLevelDescriptorAggregate.EdFi.PerformanceLevelDescriptor)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_performanceLevel_descriptor_resource()
            {
                AssertHelper.All(
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            typeof(ModelResources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor)), Is.True),
                    () => Assert.That(
                        ManagedDescriptorSpecification.IsEdFiManagedDescriptor(
                            nameof(ModelResources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor)), Is.True)
                );
            }
        }
    }
}

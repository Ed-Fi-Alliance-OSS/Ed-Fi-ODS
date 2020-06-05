// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Models.Resources.AbsenceEventCategoryDescriptor.EdFi;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.CountryDescriptorAggregate.EdFi;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Common.Specifications
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DescriptorEntitySpecificationTests
    {
        public class When_determining_if_an_entity_or_resource_is_a_descriptor : TestFixtureBase
        {
            [Assert]
            public void Should_return_true_for_descriptor_entity()
            {
                AssertHelper.All(
                    () => Assert.That(DescriptorEntitySpecification.IsEdFiDescriptorEntity(typeof(CountryDescriptor)), Is.True),
                    () => Assert.That(DescriptorEntitySpecification.IsEdFiDescriptorEntity(nameof(CountryDescriptor)), Is.True)
                );
            }

            [Assert]
            public void Should_return_true_for_descriptor_resource()
            {
                AssertHelper.All(
                    () => Assert.That(DescriptorEntitySpecification.IsEdFiDescriptorEntity(typeof(AbsenceEventCategoryDescriptor)), Is.True),
                    () => Assert.That(DescriptorEntitySpecification.IsEdFiDescriptorEntity(nameof(AbsenceEventCategoryDescriptor)), Is.True)
                );
            }
        }
    }
}

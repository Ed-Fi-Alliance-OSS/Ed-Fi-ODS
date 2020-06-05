// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using EdFi.Ods.Api.Common.Providers;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.AssessmentPeriodDescriptorAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CountryDescriptorAggregate.EdFi;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    public class DescriptorLookupProviderTests : BaseDatabaseTest
    {
        private const string CountryDescriptorName = "CountryDescriptor";
        private const string AssessmentPeriodDescriptorName = "AssessmentPeriodDescriptor";

        private CountryDescriptor CountryTestDescriptor1 { get; set; }

        private CountryDescriptor CountryTestDescriptor2 { get; set; }

        private CountryDescriptor CountryTestDescriptor3 { get; set; }

        private AssessmentPeriodDescriptor AssessmentPeriodTestDescriptor1 { get; set; }

        private IDescriptorLookupProvider DescriptorLookupProvider { get; set; }

        [SetUp]
        public void SetUp()
        {
            CountryTestDescriptor1 = new CountryDescriptor
            {
                Namespace = "uri://namespace1/CountryDescriptor",
                CodeValue = "Test Country Descriptor 1",
                ShortDescription = "Test Country Descriptor 1",
                Description = "Test Country Descriptor 1",
                EffectiveBeginDate = DateTime.Now
            };

            CountryTestDescriptor2 = new CountryDescriptor
            {
                Namespace = "uri://namespace1/CountryDescriptor",
                CodeValue = "Test Country Descriptor 2",
                ShortDescription = "Test Country Descriptor 2",
                Description = "Test Country Descriptor 2",
                EffectiveBeginDate = DateTime.Now
            };

            CountryTestDescriptor3 = new CountryDescriptor
            {
                Namespace = "uri://namespace2/CountryDescriptor",
                CodeValue = "Test Country Descriptor 1",
                ShortDescription = "Test Country Descriptor 1",
                Description = "Test Country Descriptor 1",
                EffectiveBeginDate = DateTime.Now
            };

            AssessmentPeriodTestDescriptor1 = new AssessmentPeriodDescriptor
            {
                Namespace = "uri://namespace1/AssessmentPeriodDescriptor",
                CodeValue = "Test Assessment Period Descriptor 1",
                ShortDescription = "Test Assessment Period Descriptor 1",
                Description = "Test Assessment Period Descriptor 1",
                EffectiveBeginDate = DateTime.Now
            };

            using (var session = SessionFactory.OpenSession())
            {
                session.Save(CountryTestDescriptor1);
                session.Save(CountryTestDescriptor2);
                session.Save(CountryTestDescriptor3);
                session.Save(AssessmentPeriodTestDescriptor1);
            }

            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddSchema(new SchemaDefinition("Ed-Fi", "edfi"));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("edfi", "AssessmentPeriodDescriptor"),
                    new FullName[] { }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "edfi",
                    "AssessmentPeriodDescriptor",
                    new EntityPropertyDefinition[] { },
                    new EntityIdentifierDefinition[] { }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("edfi", "CountryDescriptor"),
                    new FullName[] { }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "edfi",
                    "CountryDescriptor",
                    new EntityPropertyDefinition[] { },
                    new EntityIdentifierDefinition[] { }));

            var domainModelProvider = MockRepository.GenerateMock<IDomainModelProvider>();

            domainModelProvider.Stub(x => x.GetDomainModel())
                .Return(domainModelBuilder.Build());

            DescriptorLookupProvider = new DescriptorLookupProvider(
                SessionFactory, new EdFiDescriptorReflectionProvider(domainModelProvider));
        }

        [Test]
        public void When_getting_invalid_descriptor_name_by_id_should_throw_argument_exception()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    DescriptorLookupProvider.GetSingleDescriptorLookupById(
                        "Invalid",
                        CountryTestDescriptor1.CountryDescriptorId));
        }

        [Test]
        public void When_getting_valid_descriptor_by_id_should_return_lookup_data()
        {
            var testLookup = DescriptorLookupProvider.GetSingleDescriptorLookupById(
                CountryDescriptorName,
                CountryTestDescriptor1.CountryDescriptorId);

            testLookup.ShouldNotBeNull();
            testLookup.Id.ShouldBe(CountryTestDescriptor1.CountryDescriptorId);

            testLookup.DescriptorValue.ShouldBe(
                EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                    CountryTestDescriptor1.Namespace,
                    CountryTestDescriptor1.CodeValue));
        }

        [Test]
        public void When_getting_invalid_descriptor_by_id_should_return_null()
        {
            var testLookup = DescriptorLookupProvider.GetSingleDescriptorLookupById(CountryDescriptorName, 999999999);
            testLookup.ShouldBeNull();
        }

        [Test]
        public void When_getting_all_descriptor_lookups_by_descriptor_name_should_only_return_descriptors_for_that_name()
        {
            var descriptorsLookup = DescriptorLookupProvider.GetDescriptorLookupsByDescriptorName(AssessmentPeriodDescriptorName);

            descriptorsLookup.All(dl => dl.DescriptorName == AssessmentPeriodDescriptorName)
                .ShouldBeTrue();
        }

        [Test]
        public void When_getting_all_descriptor_lookups_by_invalid_descriptor_name_should_throw_argument_exception()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    DescriptorLookupProvider.GetDescriptorLookupsByDescriptorName("Invalid"));
        }

        [Test]
        public void When_getting_all_descriptor_lookups_should_return_all_entries()
        {
            var descriptorsLookup = DescriptorLookupProvider.GetAllDescriptorLookups();

            var testLookup1 =
                descriptorsLookup.Values.SelectMany(tlv => tlv)
                    .SingleOrDefault(
                        dl => dl.DescriptorName == CountryDescriptorName && dl.Id == CountryTestDescriptor1.CountryDescriptorId);

            testLookup1.ShouldNotBeNull();
            testLookup1.Id.ShouldBe(CountryTestDescriptor1.CountryDescriptorId);

            testLookup1.DescriptorValue.ShouldBe(
                EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                    CountryTestDescriptor1.Namespace,
                    CountryTestDescriptor1.CodeValue));

            var testLookup2 =
                descriptorsLookup.Values.SelectMany(tlv => tlv)
                    .SingleOrDefault(
                        dl => dl.DescriptorName == CountryDescriptorName && dl.Id == CountryTestDescriptor2.CountryDescriptorId);

            testLookup2.ShouldNotBeNull();
            testLookup2.Id.ShouldBe(CountryTestDescriptor2.CountryDescriptorId);

            testLookup2.DescriptorValue.ShouldBe(
                EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                    CountryTestDescriptor2.Namespace,
                    CountryTestDescriptor2.CodeValue));

            var testLookup3 =
                descriptorsLookup.Values.SelectMany(tlv => tlv)
                    .SingleOrDefault(
                        dl =>
                            dl.DescriptorName == CountryDescriptorName &&
                            dl.Id == CountryTestDescriptor3.CountryDescriptorId);

            testLookup3.ShouldNotBeNull();
            testLookup3.Id.ShouldBe(CountryTestDescriptor3.CountryDescriptorId);

            testLookup3.DescriptorValue.ShouldBe(
                EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                    CountryTestDescriptor3.Namespace,
                    CountryTestDescriptor3.CodeValue));

            var testLookup4 =
                descriptorsLookup.Values.SelectMany(tlv => tlv)
                    .SingleOrDefault(
                        dl =>
                            dl.DescriptorName == AssessmentPeriodDescriptorName &&
                            dl.Id == AssessmentPeriodTestDescriptor1.AssessmentPeriodDescriptorId);

            testLookup4.ShouldNotBeNull();
            testLookup4.Id.ShouldBe(AssessmentPeriodTestDescriptor1.AssessmentPeriodDescriptorId);

            testLookup4.DescriptorValue.ShouldBe(
                EdFiDescriptorReferenceSpecification.GetFullyQualifiedDescriptorReference(
                    AssessmentPeriodTestDescriptor1.Namespace,
                    AssessmentPeriodTestDescriptor1.CodeValue));
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Api.Providers;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Entities.NHibernate.AssessmentPeriodDescriptorAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.CountryDescriptorAggregate.EdFi;
using EdFi.Ods.Entities.NHibernate.DescriptorAggregate.EdFi;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Repositories.NHibernate.Tests
{
    [TestFixture]
    public class DescriptorLookupProviderTests : BaseDatabaseTest
    {
        private Descriptor[] _suppliedDescriptors;

        [OneTimeSetUp]
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

            _suppliedDescriptors = new Descriptor[]
            {
                CountryTestDescriptor1,
                CountryTestDescriptor2,
                CountryTestDescriptor3,
                AssessmentPeriodTestDescriptor1
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
                    new FullName("edfi", "Descriptor"),
                    new FullName[] { }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "edfi",
                    "Descriptor",
                    new[]
                    {
                        new EntityPropertyDefinition("DescriptorId", new PropertyType(DbType.Int32), isIdentifying: true, isServerAssigned: true)
                    },
                    new EntityIdentifierDefinition[] { },
                    isAbstract: true));

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

            domainModelBuilder.AddAssociation(
                CreateDescriptorInheritanceAssociation("AssessmentPeriodDescriptor"));

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

            domainModelBuilder.AddAssociation(
                CreateDescriptorInheritanceAssociation("CountryDescriptor"));

            var domainModel = domainModelBuilder.Build();

            var domainModelProvider = A.Fake<IDomainModelProvider>();

            A.CallTo(() => domainModelProvider.GetDomainModel())
                .Returns(domainModel);

            DescriptorDetailsProvider = new DescriptorDetailsProvider(
                SessionFactory, 
                domainModelProvider,
                new HashtableContextStorage());

            AssociationDefinition CreateDescriptorInheritanceAssociation(string descriptorName)
            {
                return new AssociationDefinition(new FullName("edfi", $"FK_Descriptor_{descriptorName}"),
                    Cardinality.OneToOneInheritance,
                    new FullName("edfi", "Descriptor"),
                    new[] { new EntityPropertyDefinition("DescriptorId", new PropertyType(DbType.Int32), isIdentifying: true, isServerAssigned: true) },
                    new FullName("edfi", descriptorName),
                    new[] { new EntityPropertyDefinition($"{descriptorName}Id", new PropertyType(DbType.Int32), isIdentifying: true, isServerAssigned: false) },
                    isIdentifying: true,
                    isRequired: true);
            }
        }

        private const string CountryDescriptorName = "CountryDescriptor";
        private const string AssessmentPeriodDescriptorName = "AssessmentPeriodDescriptor";

        private CountryDescriptor CountryTestDescriptor1 { get; set; }

        private CountryDescriptor CountryTestDescriptor2 { get; set; }

        private CountryDescriptor CountryTestDescriptor3 { get; set; }

        private AssessmentPeriodDescriptor AssessmentPeriodTestDescriptor1 { get; set; }

        private IDescriptorDetailsProvider DescriptorDetailsProvider { get; set; }

        [Test]
        public void When_getting_invalid_descriptor_name_by_id_should_throw_argument_exception()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    DescriptorDetailsProvider.GetDescriptorDetails(
                        "Invalid",
                        CountryTestDescriptor1.CountryDescriptorId));
        }

        [Test]
        public void When_getting_valid_descriptor_by_id_should_return_lookup_data()
        {
            var testLookup = DescriptorDetailsProvider.GetDescriptorDetails(
                CountryDescriptorName,
                CountryTestDescriptor1.CountryDescriptorId);

            testLookup.ShouldNotBeNull();
            testLookup.DescriptorId.ShouldBe(CountryTestDescriptor1.CountryDescriptorId);

            testLookup.Uri.ShouldBe(
                DescriptorHelper.GetUri(
                    CountryTestDescriptor1.Namespace,
                    CountryTestDescriptor1.CodeValue));
        }

        [Test]
        public void When_getting_invalid_descriptor_by_id_should_return_null()
        {
            var testLookup = DescriptorDetailsProvider.GetDescriptorDetails(CountryDescriptorName, 999999999);
            testLookup.ShouldBeNull();
        }

        [Test]
        public void When_getting_descriptor_details_by_invalid_descriptor_name_should_throw_argument_exception()
        {
            Assert.Throws<ArgumentException>(
                () =>
                    DescriptorDetailsProvider.GetDescriptorDetails("Invalid", 99));
        }

        [Test]
        public void When_getting_all_descriptor_details_should_return_all_entries()
        {
            var allDescriptorDetails = DescriptorDetailsProvider.GetAllDescriptorDetails();

            var expectedDescriptorDetails = _suppliedDescriptors.Select(
                d => new DescriptorDetails
                {
                    DescriptorId = d.DescriptorId,
                    CodeValue = d.CodeValue,
                    Namespace = d.Namespace
                });

            expectedDescriptorDetails.ShouldBeSubsetOf(allDescriptorDetails);
        }
    }
}

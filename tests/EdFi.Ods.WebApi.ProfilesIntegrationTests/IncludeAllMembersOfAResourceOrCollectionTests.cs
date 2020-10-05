// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.WebApi.ProfileSpecFlowTests.Fakes;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using Shouldly;
using SchoolResource = EdFi.Ods.Api.Common.Models.Resources.School.EdFi.School;
using SchoolEntity = EdFi.Ods.Entities.NHibernate.SchoolAggregate.EdFi.School;
using StudentSpecialEducationProgramAssociationEntity =
    EdFi.Ods.Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation;

namespace EdFi.Ods.WebApi.ProfileSpecFlowTests
{
    [TestFixture]
    public class IncludeAllMembersOfAResourceOrCollectionTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DescriptorsCache.GetCache = () => new FakeDescriptorsCache();
            _fakesGenerator = new FakeGenerator();
        }

        // NOTE: The id's for descriptors are not managed in these tests, so we are not asserting them but these properties do change.

        private FakeGenerator _fakesGenerator;

        [Test]
        public void SchoolResourceShouldMapAllPropertiesWhenUpdating()
        {
            // Scenario Outline: The Write content type includes all properties of a resource
            // Given the caller is using the "Test-Profile-Resource-IncludeAll" profile
            // When a PUT request with a completely updated resource is submitted using JSON to "schools" with a request body content type of the appropriate value for the profile in use
            // Then the persisted entity model should have unmodified primary key values
            // And every non-primary key value on the entity should be changed

            var schools = _fakesGenerator.Schools(2);
            var originalEntity = schools.FirstOrDefault();
            var modificationToEntity = schools.LastOrDefault();

            var entityToModify = ProfilesHelper.Clone<SchoolEntity, SchoolEntity>(originalEntity);

            // simulate a change of data
            modificationToEntity.Id = entityToModify.Id;

            var modificationResource = ProfilesHelper.CreateResource<SchoolEntity, SchoolResource>(modificationToEntity);

            // apply the profile to the modified resource
            var constrainedResource =
                ProfilesHelper
                    .Clone<SchoolResource,
                        School>(
                        modificationResource);

            // map the resource into an entity before saving
            var transientSchool = Activator.CreateInstance<SchoolEntity>();
            constrainedResource.MapTo(transientSchool, null);

            // apply the changes to the original entity (i.e. save the changes)
            transientSchool.SynchronizeTo(entityToModify);

            var comparer = new CompareLogic(new ComparisonConfig {MaxDifferences = 100});

            var compareResult = comparer.Compare(originalEntity, entityToModify);

            var relevantDifferences = compareResult.RelevantPropertyDifferences();

            relevantDifferences.ShouldSatisfyAllConditions(
                () => relevantDifferences.ShouldNotBeEmpty(),
                () => relevantDifferences.ShouldBe(
                    new[]
                    {
                        "SchoolCategories",
                        "SchoolGradeLevels",
                        "WebSite",
                        "EducationOrganizationAddresses",
                        "EducationOrganizationCategories",
                        "EducationOrganizationIdentificationCodes",
                        "EducationOrganizationIndicators",
                        "EducationOrganizationInstitutionTelephones",
                        "EducationOrganizationInternationalAddresses"
                    }));
        }

        [Test]
        public void SchoolResourceShouldMapAllPropertiesWhenRetrieving()
        {
            // Scenario Outline: The Read content type includes all properties of a resource
            // Given the caller is using the "Test-Profile-Resource-IncludeAll" profile
            // When a GET (by id) request is submitted using JSON to "schools" with an accept header content type of the appropriate value for the profile in use
            // Then the response model should contain all of the resource model's properties

            var schools = _fakesGenerator.Schools(1);
            var originalEntity = schools.FirstOrDefault();

            var originalResource = new SchoolResource();
            originalEntity.MapTo(originalResource, null);

            var resource =
                new Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School();

            originalEntity.MapTo(resource, null);

            var comparer = new CompareLogic(new ComparisonConfig {IgnoreObjectTypes = true});

            var compareResult = comparer.Compare(originalResource, resource);

            var relevantDifferences = compareResult.RelevantDifferences();

            relevantDifferences.ShouldBeEmpty();
            compareResult.AreEqual.ShouldBeTrue();
        }

        [Test]
        public void SchoolResourceShouldIncludeAllPropertiesInACollectionWhenRetrieving()
        {
            // Scenario Outline: The Read content type includes all properties of a child collection
            // Given the caller is using the "Test-Profile-Resource-Child-Collection-IncludeAll" profile
            // When a GET (by id) request is submitted using JSON to "schools" with an accept header content type of the appropriate value for the profile in use
            // Then the number of properties on the response model's addresses collection items should reflect the number of properties on the full EducationOrganizationAddress resource model

            var schools = _fakesGenerator.Schools(1);
            var originalEntity = schools.FirstOrDefault();

            var originalResource = new SchoolResource();
            originalEntity.MapTo(originalResource, null);

            var resource =
                new Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Readable.School();

            originalEntity.MapTo(resource, null);

            var comparer = new CompareLogic(new ComparisonConfig {IgnoreObjectTypes = true});

            var compareResult = comparer.Compare(originalResource, resource);

            var relevantDifferences = compareResult.RelevantDifferences();

            relevantDifferences.ShouldBeEmpty();
            compareResult.AreEqual.ShouldBeTrue();
        }

        [Test]
        public void SchoolResourceShouldIncludeAllPropertiesInACollectionWhenWriting()
        {
            // Scenario Outline: The Write content type includes all properties of a child collection
            // Given the caller is using the "Test-Profile-Resource-Child-Collection-IncludeAll" profile
            // When a PUT request with a completely updated resource with preserved child collections is submitted using JSON to "schools" with a request body content type of the appropriate value for the profile in use
            // Then the only values not changed on the entity model's EducationOrganizationInternationalAddresses collection items should be the contextual primary key values of [AddressTypeDescriptor, AddressTypeDescriptorId]

            var schools = _fakesGenerator.Schools(1);
            var originalEntity = schools.FirstOrDefault();

            var entityToModify = ProfilesHelper.Clone<SchoolEntity, SchoolEntity>(originalEntity);

            var modificationEntity = ProfilesHelper.Clone<SchoolEntity, SchoolEntity>(originalEntity);

            // modify only the first entity
            var addressesToModify = _fakesGenerator.EducationOrganizationAddresses(1)
                .Concat(originalEntity.EducationOrganizationAddresses.Where((x, i) => i > 0)).ToList();

            modificationEntity.EducationOrganizationAddresses = addressesToModify;

            var modificationResource = ProfilesHelper.CreateResource<SchoolEntity, SchoolResource>(modificationEntity);

            // apply the profile to the modified resource
            var constrainedResource =
                ProfilesHelper
                    .Clone<SchoolResource,
                        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Writable.School
                    >(
                        modificationResource);

            // map the resource into an entity before saving
            var transientSchool = Activator.CreateInstance<SchoolEntity>();
            constrainedResource.MapTo(transientSchool, null);

            // apply the changes to the original entity (i.e. save the changes)
            transientSchool.SynchronizeTo(modificationEntity);

            var comparer = new CompareLogic(new ComparisonConfig {MaxDifferences = 100});

            var compareResult = comparer.Compare(
                originalEntity.EducationOrganizationAddresses, entityToModify.EducationOrganizationAddresses);

            var relevantDifferences = compareResult.RelevantCollectionPropertyDifferences();

            relevantDifferences.ShouldSatisfyAllConditions(
                () => relevantDifferences.ShouldNotBeEmpty(),
                () => relevantDifferences.ShouldBe(
                    new[]
                    {
                        "Extensions",
                        "AggregateExtensions",
                        "EducationOrganizationIdentificationCodes",
                        "EducationOrganizationIndicators",
                        "EducationOrganizationInstitutionTelephones",
                        "EducationOrganizationInternationalAddresses",
                        "EducationOrganizationAddressPeriods",
                    }));
        }
    }
}

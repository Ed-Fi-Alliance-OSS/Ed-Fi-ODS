// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers.Queries;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Providers
{
    [TestFixture]
    public class ResourceIdentificationCodePropertiesProviderTests
    {
        private IResourceIdentificationCodePropertiesProvider _provider;
        private DomainModel _domainModel; 
        
        [OneTimeSetUp]
        public void Setup()
        {
            _provider = new ResourceIdentificationCodePropertiesProvider();
            _domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();
        }

        [Test]
        public void TryFindIdentificationCodes_ShouldReturnFalseAndNull_WhenResourceHasNoIdentificationCode()
        {
            // Arrange    
            Resource resourceWithoutIdentificationCode = _domainModel.ResourceModel.GetResourceByFullName("edfi.Calendar");

            // Act
            bool result = _provider.TryGetIdentificationCodeProperties(
                resourceWithoutIdentificationCode, out List<ResourceProperty> identificationCodeProperties);

            //Assert
            result.ShouldBeFalse();
            identificationCodeProperties.ShouldBeNull();
        }
        
        [Test]
        public void TryFindIdentificationCodes_ShouldReturnTrueAndCorrectIdentificationCodeProperties_WhenAResourceHasIdentificationCode()
        {
            // Arrange    
            _provider = new ResourceIdentificationCodePropertiesProvider();
            const string ResourceWithIdentificationCodeCollectionName = "edfi.Course";

            Resource resourceWithIdentificationCodeCollection = _domainModel.ResourceModel.GetAllResources()
                .First(r => r.FullName.Equals(ResourceWithIdentificationCodeCollectionName));

            // Act
            bool result = _provider.TryGetIdentificationCodeProperties(
                resourceWithIdentificationCodeCollection, out List<ResourceProperty> identificationCodeProperties);

            //Assert
            result.ShouldBeTrue();
            identificationCodeProperties.Count.ShouldBe(4);
            identificationCodeProperties.Select(p => p.PropertyName).ToList().ShouldBeEquivalentTo(new List<string> 
            {
                "CourseIdentificationSystemDescriptor",
                "AssigningOrganizationIdentificationCode",
                "CourseCatalogURL",
                "IdentificationCode"
            });
        }
        
        [Test]
        public void TryFindIdentificationCodes_ShouldReturnTrueAndCorrectIdentificationCodeProperties_WhenADerivedResourceHasInheritedIdentificationCode()
        {
            // Arrange    
            _provider = new ResourceIdentificationCodePropertiesProvider();
            const string DerivedResourceName = "edfi.School";

            var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

            Resource derivedResource = domainModel.ResourceModel.GetAllResources()
                .First(r => r.FullName.Equals(DerivedResourceName));

            // Act
            bool result = _provider.TryGetIdentificationCodeProperties(
                derivedResource, out List<ResourceProperty> identificationCodeProperties);

            //Assert
            result.ShouldBeTrue();
            identificationCodeProperties.Count.ShouldBe(2);
            identificationCodeProperties.Select(p => p.PropertyName).ToList().ShouldBeEquivalentTo(new List<string> 
            {
                "EducationOrganizationIdentificationSystemDescriptor",
                "IdentificationCode"
            });
        }
    }
}

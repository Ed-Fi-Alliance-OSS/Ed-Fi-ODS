// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void TryFindIdentificationCodes_ShouldReturnFalseAndNull_WhenResourceHasNoIdentificaionCode()
        {
            // Arrange    
            _provider = new ResourceIdentificationCodePropertiesProvider();
            const string ResourceName = "edfi.Calendar";

            var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

            Resource resource = domainModel.ResourceModel.GetAllResources()
                .First(r => r.FullName.Equals(ResourceName));

            // Act
            bool result = _provider.TryGetIdentificationCodeProperties(
                resource, out List<ResourceProperty> identificationCodeProperties);

            //Assert
            result.ShouldBeFalse();
            identificationCodeProperties.ShouldBeNull();
        }
        
        [Test]
        public void TryFindIdentificationCodes_ShouldReturnTrueAndIdCodeProperties_WhenABaseResourceHasIdentificationCode()
        {
            // Arrange    
            _provider = new ResourceIdentificationCodePropertiesProvider();
            const string ResourceName = "edfi.Course";

            var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

            Resource resource = domainModel.ResourceModel.GetAllResources()
                .First(r => r.FullName.Equals(ResourceName));

            // Act
            bool result = _provider.TryGetIdentificationCodeProperties(
                resource, out List<ResourceProperty> identificationCodeProperties);

            //Assert
            result.ShouldBeTrue();
            identificationCodeProperties.Count.ShouldBe(4);
        }
        
        [Test]
        public void TryFindIdentificationCodes_ShouldReturnTrueAndIdCodeProperties_WhenADerivedResourceHasIdentificationCode()
        {
            // Arrange    
            _provider = new ResourceIdentificationCodePropertiesProvider();
            const string ResourceName = "edfi.School";

            var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

            Resource resource = domainModel.ResourceModel.GetAllResources()
                .First(r => r.FullName.Equals(ResourceName));

            // Act
            bool result = _provider.TryGetIdentificationCodeProperties(
                resource, out List<ResourceProperty> identificationCodeProperties);

            //Assert
            result.ShouldBeTrue();
            identificationCodeProperties.Count.ShouldBe(2);
        }
    }
}

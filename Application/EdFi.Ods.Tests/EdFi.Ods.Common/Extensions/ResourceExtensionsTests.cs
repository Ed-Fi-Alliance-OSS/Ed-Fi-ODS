// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Extensions
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ResourceExtensionsTests
    {
        public class When_Determining_If_A_Collection_Is_Derived_From_A_Resource : TestFixtureBase
        {
            private ResourceClassBase _stateEducationAgency;
            private Collection _educationOrganizationAddresses;
            private bool _actualResult;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                _stateEducationAgency = resourceModel.GetAllResources()
                                                     .First(r => r.Name == "StateEducationAgency");

                _educationOrganizationAddresses = resourceModel.GetAllResources()
                                                               .SelectMany(r => r.Collections)
                                                               .First(c => c.PropertyName == "EducationOrganizationAddresses");
            }

            protected override void Act()
            {
                _actualResult = _educationOrganizationAddresses.IsDerivedFrom(_stateEducationAgency);
            }

            [Test]
            public void Should_Return_True_If_Collection_Base_Association_Other_Entity_Matches_The_Base_Entity_For_The_Provided_Resource()
            {
                Assert.That(_actualResult, Is.True);
            }
        }

        public class When_evaluating_resource_properties_with_more_than_1_incoming_association_in_the_entity_model : TestFixtureBase
        {
            private ResourceProperty _resourceProperty;
            private bool _actualIsUnified;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                _resourceProperty = resourceModel.GetAllResources()
                                                 .SelectMany(r => r.AllProperties)
                                                 .FirstOrDefault(
                                                      p =>
                                                          p.EntityProperty != null
                                                          && p.EntityProperty.IncomingAssociations.Count > 1);
            }

            protected override void Act()
            {
                _actualIsUnified = _resourceProperty.IsUnified();
            }

            [Test]
            public void Should_indicate_the_property_is_unified()
            {
                Assert.That(_actualIsUnified, Is.True);
            }
        }

        public class When_Getting_All_Request_Properties_For_A_Derived_Resource : TestFixtureBase
        {
            private Resource _derivedResource;
            private IEnumerable<ResourceProperty> _expectedResourceProperties;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                _derivedResource = resourceModel.GetAllResources()
                                                .First(r => r.IsDerived);

                _expectedResourceProperties = _derivedResource.AllProperties.Where(
                                                                   p => ModelComparers.Entity.Equals(
                                                                       _derivedResource.Entity,
                                                                       p.EntityProperty.Entity))
                                                              .Union(
                                                                   _derivedResource.IdentifyingProperties.Where(
                                                                       p => p.EntityProperty != null
                                                                            && p.EntityProperty.IncomingAssociations.Any()));
            }

            [Test]
            public void Should_Return_All_Local_Properties_In_Conjunction_With_Any_Identifying_Properties_With_Incoming_Associations()
            {
                Assert.That(_derivedResource.AllRequestProperties(), Is.EquivalentTo(_expectedResourceProperties));
            }
        }

        public class When_Getting_All_Request_Properties_For_A_Non_Derived_Resource : TestFixtureBase
        {
            private Resource _resource;
            private IEnumerable<ResourceProperty> _expectedResourceProperties;
            private IEnumerable<ResourceProperty> _actualResourceProperties;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                _resource = resourceModel.GetAllResources()
                                         .First(r => !r.IsDerived);

                _expectedResourceProperties = _resource.AllProperties;
            }

            protected override void Act()
            {
                _actualResourceProperties = _resource.AllRequestProperties();
            }

            [Test]
            public void Should_Return_All_Local_Properties_In_Conjunction_With_Any_Identifying_Properties_With_Incoming_Associations()
            {
                Assert.That(_actualResourceProperties, Is.EquivalentTo(_expectedResourceProperties));
            }
        }

        public class When_Getting_Unified_Key_All_Properties_For_Resource : TestFixtureBase
        {
            private Resource _resource;
            private IEnumerable<ResourceProperty> _expectedResourceProperties;
            private IEnumerable<ResourceProperty> _actualResourceProperties;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                _resource = resourceModel.GetAllResources()
                                         .First(r => r.Name == "Student");

                var unifiedProperties =
                    _resource.IdentifyingProperties.Where(
                                  p => p.EntityProperty != null && p.EntityProperty.IncomingAssociations.Count > 1)
                             .Union(
                                  _resource.AllProperties,
                                  ModelComparers.ResourcePropertyNameOnly);

                _expectedResourceProperties =
                    unifiedProperties.Where(
                        p => !_resource.References.SelectMany(r => r.Properties)
                                       .Contains(p));
            }

            protected override void Act()
            {
                _actualResourceProperties = _resource.UnifiedKeyAllProperties();
            }

            [Test]
            public void
                Should_Return_All_Properties_As_Well_As_Identifying_Properties_With_Greater_Than_One_Incoming_Association_Excluding_Reference_Columns()
            {
                Assert.That(_actualResourceProperties, Is.EquivalentTo(_expectedResourceProperties));
            }
        }

        public class When_Determining_If_A_Resource_Child_Item_Is_Derived_From_A_Resource : TestFixtureBase
        {
            private ResourceChildItem _resourceChildItem;
            private Resource _resource;
            private bool _actualResult = true;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                var resources = resourceModel.GetAllResources();

                _resourceChildItem = resources.SelectMany(r => r.AllContainedItemTypes)
                                              .First(i => i.Name == "AssessmentContentStandard");

                _resource = resources.First(r => r.Name == "StateEducationAgency");
            }

            protected override void Act()
            {
                _actualResult = _resourceChildItem.IsDerivedFrom(_resource);
            }

            [Test]
            public void Should_Return_True_If_Other_Entity_Of_Resource_Child_Item_Base_Entity_Association_Matches_Provided_Resource_Backing_Entity()
            {
                Assert.That(_actualResult, Is.True);
            }
        }

        public class When_Determining_If_A_Resource_Is_Derived_From_Another_Resource : TestFixtureBase
        {
            private Resource _baseResource;
            private Resource _derivedResource;
            private bool _actualResult = true;

            protected override void Arrange()
            {
                var resourceModel =
                    DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();

                var resources = resourceModel.GetAllResources();

                _baseResource = resources.First(r => r.IsBase());

                _derivedResource = resources.First(
                    r => ModelComparers.Entity.Equals(r.Entity.BaseEntity, _baseResource.Entity));
            }

            protected override void Act()
            {
                _actualResult = _derivedResource.IsDerivedFrom(_baseResource);
            }

            [Test]
            public void Should_Return_True_If_Resource_Is_Derived_From_Other_Resource()
            {
                Assert.That(_actualResult, Is.True);
            }
        }
    }
}

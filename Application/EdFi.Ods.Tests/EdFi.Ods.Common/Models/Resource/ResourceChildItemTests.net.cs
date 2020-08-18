// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ResourceChildItemTests
    {
        public class When_building_a_resource_with_aggregate_extension
            : TestFixtureBase
        {
            private ResourceModel _resourceModel;
            private global::EdFi.Ods.Common.Models.Resource.Resource _student;
            private ResourceChildItem _studentExtension;
            private ResourceChildItem _studentPet;
            private ResourceChildItem _studentPetPreference;
            private ResourceChildItem _educationOrganizationAddresses;

            protected override void Arrange()
            {
                _resourceModel = DomainModelDefinitionsProviderHelper.ResourceModelProvider.GetResourceModel();
            }

            protected override void Act()
            {
                _educationOrganizationAddresses = _resourceModel
                                                 .GetResourceByFullName(new FullName("edfi", "EducationOrganizationNetwork"))
                                                 .CollectionByName["EducationOrganizationAddresses"]
                                                 .ItemType;

                _student = _resourceModel.GetResourceByFullName(new FullName("edfi", "Student"));

                _studentExtension = _student.ExtensionByName["Sample"]
                                            .ObjectType;

                _studentPetPreference = _studentExtension.EmbeddedObjectByName["StudentPetPreference"]
                                                         .ObjectType;

                _studentPet = _studentExtension.CollectionByName["StudentPets"]
                                               .ItemType;
            }

            [Assert]
            public void Should_have_the_resource_extension_property_set_properly()
            {
                AssertHelper.All(
                    () => Assert.That(_student.IsResourceExtension, Is.False),
                    () => Assert.That(_studentExtension.IsResourceExtension, Is.True),
                    () => Assert.That(_studentPet.IsResourceExtension, Is.True),
                    () => Assert.That(_studentPetPreference.IsResourceExtension, Is.True)
                );
            }

            [Assert]
            public void Should_have_the_resource_extension_class_property_set_properly()
            {
                AssertHelper.All(
                    () => Assert.That(_student.IsResourceExtensionClass, Is.False),
                    () => Assert.That(_studentExtension.IsResourceExtensionClass, Is.True),
                    () => Assert.That(_studentPet.IsResourceExtensionClass, Is.False),
                    () => Assert.That(_studentPetPreference.IsResourceExtensionClass, Is.False)
                );
            }

            [Assert]
            public void Should_have_the_is_inherited_childitem_property_set_properly()
            {
                AssertHelper.All(
                    () => Assert.That(_educationOrganizationAddresses.IsInheritedChildItem, Is.True),
                    () => Assert.That(_studentExtension.IsInheritedChildItem, Is.False),
                    () => Assert.That(_studentPet.IsInheritedChildItem, Is.False),
                    () => Assert.That(_studentPetPreference.IsInheritedChildItem, Is.False)
                );
            }

            [Assert]
            public void Should_have_resource_root_set_properly()
            {
                AssertHelper.All(
                    () => Assert.That(_studentExtension.ResourceRoot.FullName, Is.EqualTo(_student.FullName)),
                    () => Assert.That(_studentPet.ResourceRoot.FullName, Is.EqualTo(_student.FullName)),
                    () => Assert.That(_studentPetPreference.ResourceRoot.FullName, Is.EqualTo(_student.FullName))
                );
            }

            [Assert]
            public void Should_have_the_lineage_set_properly()
            {
                AssertHelper.All(
                    () => Assert.That(
                        _studentExtension.GetLineage()
                                         .Count(),
                        Is.EqualTo(2)),
                    () => Assert.That(
                        _studentPet.GetLineage()
                                   .Count(),
                        Is.EqualTo(3)),
                    () => Assert.That(
                        _studentPetPreference.GetLineage()
                                             .Count(),
                        Is.EqualTo(3))
                );
            }
        }
    }
}

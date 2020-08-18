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
    public class CollectionTests
    {
        public class When_getting_ParentFullName_with_matching_schemas : TestFixtureBase
        {
            private Collection _collection;
            private FullName _returnedFullName;
            private readonly string _resourceName = "Staff";
            private readonly string _containedItemName = "StaffLanguage";
            private readonly string _collectionPropertyName = "StaffLanguageUses";
            private readonly FullName _correctFullName = new FullName("edfi", "StaffLanguage");

            protected override void Arrange()
            {
                var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

                var resource = domainModel.ResourceModel.GetAllResources()
                                          .First(r => r.Name.Equals(_resourceName));

                var containedItems = resource.AllContainedItemTypes.First(c => c.Name.Equals(_containedItemName));
                var collection = containedItems.Collections.First(c => c.PropertyName.Equals(_collectionPropertyName));

                _collection = collection;
            }

            protected override void Act()
            {
                _returnedFullName = _collection.ParentFullName;
            }

            [Test]
            public void Should_return_correct_FullName()
            {
                Assert.That(_returnedFullName, Is.EqualTo(_correctFullName));
            }
        }

        public class When_getting_ParentFullName_with_different_schemas : TestFixtureBase
        {
            private Collection _collection;
            private FullName _returnedFullName;
            private readonly string _resourceName = "Staff";
            private readonly string _extensionPropertyName = "Sample";
            private readonly string _collectionPropertyName = "StaffPets";
            private readonly FullName _correctFullName = new FullName("sample", "StaffExtension");

            protected override void Arrange()
            {
                var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

                var resource = domainModel.ResourceModel.GetAllResources()
                                          .First(r => r.Name.Equals(_resourceName));

                var extension = resource.Extensions.First(e => e.PropertyName.Equals(_extensionPropertyName));
                var collection = extension.ObjectType.Collections.First(c => c.PropertyName == _collectionPropertyName);

                _collection = collection;
            }

            protected override void Act()
            {
                _returnedFullName = _collection.ParentFullName;
            }

            [Test]
            public void Should_return_correct_FullName()
            {
                Assert.That(_returnedFullName, Is.EqualTo(_correctFullName));
            }
        }
    }
}

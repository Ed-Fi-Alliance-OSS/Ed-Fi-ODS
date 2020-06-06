// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Metadata;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Composites.Test;
using EdFi.Ods.Features.Composites;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EmbeddedObjectTests
    {
        public class When_getting_a_core_embedded_object_parent_full_name : TestFixtureBase
        {
            private EmbeddedObject _embeddedObject;
            private FullName _returnedParentFullName;

            protected override void Arrange()
            {
                var domainModel = DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel();

                var resource = domainModel.ResourceModel.GetAllResources()
                                          .First(r => r.Name.Equals("Assessment"));

                var embeddedObject = resource.EmbeddedObjects.First(e => e.PropertyName.Equals("AssessmentContentStandard"));

                _embeddedObject = embeddedObject;
            }

            protected override void Act()
            {
                _returnedParentFullName = _embeddedObject.ParentFullName;
            }

            [Test]
            public void Should_return_expected_parent_full_name()
            {
                var expectedParentName = new FullName("edfi", "Assessment");
                Assert.That(_returnedParentFullName, Is.EqualTo(expectedParentName));
            }
        }

        public class When_getting_a_composites_embedded_object_parent_full_name : TestFixtureBase
        {
            private EmbeddedObject _embeddedObject;
            private FullName _returnedParentFullName;

            protected override void Arrange()
            {
                AssemblyLoader.EnsureLoaded<Marker_EdFi_Ods_Composites_Test>();

                var compositeMetadataProvider = new CompositesMetadataProvider();

                var resourceModel =
                    DomainModelDefinitionsProviderHelper.DomainModelProvider.GetDomainModel()
                                                        .ResourceModel;

                var definitionProcessor =
                    new CompositeDefinitionProcessor
                        <CompositeResourceModelBuilderContext, global::EdFi.Ods.Common.Models.Resource.Resource>(
                            new CompositeResourceModelBuilder());

                // It is possible to add validation on composite names within the MetadataController logic if it's needed.
                // Get all the category names
                var categoryNames =
                    compositeMetadataProvider.GetAllCategories()
                                             .First(c => c.Name.Equals("test") && c.DisplayName.Equals("Test"));

                IReadOnlyList<XElement> compositeDefinitions;

                compositeMetadataProvider.TryGetCompositeDefinitions(categoryNames.OrganizationCode, categoryNames.Name, out compositeDefinitions);

                var compositeResources = new List<global::EdFi.Ods.Common.Models.Resource.Resource>();

                foreach (var compositeDefinition in compositeDefinitions)
                {
                    // Enable this for composite xml validation.
                    definitionProcessor.UseCompositeValidation();

                    var compositeResource = definitionProcessor.Process(
                        compositeDefinition,
                        resourceModel,
                        new CompositeResourceModelBuilderContext());

                    compositeResources.Add(compositeResource);
                }

                var compositesResource = compositeResources.First(c => c.Name.Equals("BaseAssessmentUnflattenedEmbeddedObject"));
                _embeddedObject = compositesResource.EmbeddedObjects.First(e => e.PropertyName.Equals("AssessmentContentStandard"));
            }

            protected override void Act()
            {
                _returnedParentFullName = _embeddedObject.ParentFullName;
            }

            [Test]
            public void Should_return_expected_parent_full_name()
            {
                var expectedParentName = new FullName(null, "BaseAssessmentUnflattenedEmbeddedObject");
                Assert.That(_returnedParentFullName, Is.EqualTo(expectedParentName));
            }
        }
    }
}

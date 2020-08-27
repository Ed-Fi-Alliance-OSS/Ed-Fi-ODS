// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;
using Resource_Resource = EdFi.Ods.Common.Models.Resource.Resource;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ProfileResourceMembersFilterProviderTests
    {
        private static Resource_Resource GetTestResource()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddSchema(new SchemaDefinition("schema1", "schema1"));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity",
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.String), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK",
                            new[]
                            {
                                "KeyProperty1", "KeyProperty2"
                            },
                            isPrimary: true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "TestEntity1",
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.String), null, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK",
                            new[]
                            {
                                "KeyProperty1", "KeyProperty2"
                            },
                            isPrimary: true)
                    }));

            //Setup TestEntity Reference
            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema1", "FK_TestEntity_TestEntity1"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "TestEntity1"),
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.String), null, true)
                    },
                    new FullName("schema1", "TestEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.String), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "TestEntity"),
                    new[]
                    {
                        new FullName("schema1", "TestEntity")
                    }));

            //Add aggregate for reference of TestEntity
            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "TestEntity1"),
                    new[]
                    {
                        new FullName("schema1", "TestEntity1")
                    }));

            var resourceModel = new ResourceModel(domainModelBuilder.Build());

            var resource = resourceModel.GetResourceByFullName(new FullName("schema1", "TestEntity"));

            return resource;
        }

        internal static IDomainModelDefinitionsProvider BuildCoreModelEntityDefinitionsProvider()
        {
            string schema = "edfi";

            var entityDefinitions = new[]
                                    {
                                        new EntityDefinition(
                                            schema,
                                            "CoreEntity",
                                            new[]
                                            {
                                                new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                            },
                                            new[]
                                            {
                                                new EntityIdentifierDefinition(
                                                    "PK",
                                                    new[]
                                                    {
                                                        "KeyProperty1", "KeyProperty2"
                                                    },
                                                    isPrimary: true)
                                            },
                                            true),
                                        new EntityDefinition(
                                            schema,
                                            "Collection1Item",
                                            new[]
                                            {
                                                new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true),
                                                new EntityPropertyDefinition("KeyProperty2", new PropertyType(DbType.Int32), null, true)
                                            },
                                            new[]
                                            {
                                                new EntityIdentifierDefinition(
                                                    "PK",
                                                    new[]
                                                    {
                                                        "KeyProperty1", "KeyProperty2"
                                                    },
                                                    isPrimary: true)
                                            },
                                            true),
                                        new EntityDefinition(
                                            schema,
                                            "EmbeddedObject1",
                                            new[]
                                            {
                                                new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                            },
                                            new[]
                                            {
                                                new EntityIdentifierDefinition(
                                                    "PK",
                                                    new[]
                                                    {
                                                        "KeyProperty1"
                                                    },
                                                    isPrimary: true)
                                            },
                                            true)
                                    };

            var associationDefinitions = new[]
                                         {
                                             new AssociationDefinition(
                                                 new FullName(schema, "FK_CoreEntityEmbeddedObject"),
                                                 Cardinality.OneToOne,
                                                 new FullName(schema, "CoreEntity"),
                                                 new[]
                                                 {
                                                     new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                 },
                                                 new FullName(schema, "EmbeddedObject1"),
                                                 new[]
                                                 {
                                                     new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                 },
                                                 isIdentifying: true,
                                                 isRequired: true),
                                             new AssociationDefinition(
                                                 new FullName(schema, "FK_CoreEntityCollection"),
                                                 Cardinality.OneToZeroOrMore,
                                                 new FullName(schema, "CoreEntity"),
                                                 new[]
                                                 {
                                                     new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                 },
                                                 new FullName(schema, "Collection1Item"),
                                                 new[]
                                                 {
                                                     new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                 },
                                                 isIdentifying: true,
                                                 isRequired: true)
                                         };

            var aggredateDefinitions = new[]
                                       {
                                           new AggregateDefinition(
                                               new FullName(schema, "CoreEntity"),
                                               new[]
                                               {
                                                   new FullName(schema, "Collection1Item"), new FullName(schema, "EmbeddedObject1")
                                               })
                                       };

            var schemaDefinition = new SchemaDefinition(schema, schema);

            var modelDefinitions = new DomainModelDefinitions(
                schemaDefinition,
                aggredateDefinitions,
                entityDefinitions,
                associationDefinitions);

            var domainModelDefinitionsProvider = MockRepository.GenerateStub<IDomainModelDefinitionsProvider>();

            domainModelDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                          .Return(modelDefinitions);

            return domainModelDefinitionsProvider;
        }

        internal static IDomainModelDefinitionsProvider BuildTestExtensionDefinitionsProvider()
        {
            var aggredateDefinitions2 = new[]
                                        {
                                            new AggregateDefinition(
                                                new FullName("ExtensionPhysical", "ExtensionAggregate"),
                                                new[]
                                                {
                                                    new FullName("ExtensionPhysical", "ExtensionEntity")
                                                })
                                        };

            var entityDefinitions2 = new[]
                                     {
                                         new EntityDefinition(
                                             "ExtensionPhysical",
                                             "ExtensionAggregate",
                                             new[]
                                             {
                                                 new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                             },
                                             new[]
                                             {
                                                 new EntityIdentifierDefinition(
                                                     "PK",
                                                     new[]
                                                     {
                                                         "KeyProperty1", "KeyProperty2"
                                                     },
                                                     isPrimary: true)
                                             },
                                             true),
                                         new EntityDefinition(
                                             "ExtensionPhysical",
                                             "ExtensionEntity",
                                             new[]
                                             {
                                                 new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                             },
                                             new[]
                                             {
                                                 new EntityIdentifierDefinition(
                                                     "PK",
                                                     new[]
                                                     {
                                                         "KeyProperty1", "KeyProperty2"
                                                     },
                                                     isPrimary: true)
                                             },
                                             true)
                                     };

            var associationDefinitions2 = new[]
                                          {
                                              new AssociationDefinition(
                                                  new FullName("ExtensionPhysical", "FK_ExtensionEntity"),
                                                  Cardinality.OneToOneExtension,
                                                  new FullName("edfi", "CoreEntity"),
                                                  new[]
                                                  {
                                                      new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                  },
                                                  new FullName("ExtensionPhysical", "ExtensionEntity"),
                                                  new[]
                                                  {
                                                      new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                                                  },
                                                  isIdentifying: true,
                                                  isRequired: true)
                                          };

            var schemaDefinition2 = new SchemaDefinition("Extension-Logical", "ExtensionPhysical");

            var modelDefinitions2 = new DomainModelDefinitions(
                schemaDefinition2,
                aggredateDefinitions2,
                entityDefinitions2,
                associationDefinitions2);

            var domainModelDefinitionsProvider = MockRepository.GenerateStub<IDomainModelDefinitionsProvider>();

            domainModelDefinitionsProvider.Stub(x => x.GetDomainModelDefinitions())
                                          .Return(modelDefinitions2);

            return domainModelDefinitionsProvider;
        }

        internal static Resource_Resource GetTestResourceForWithAnExtension()
        {
            IDomainModelDefinitionsProvider domainCoreDefinitionProvider = BuildCoreModelEntityDefinitionsProvider();
            IDomainModelDefinitionsProvider extensionDefinitionProvider = BuildTestExtensionDefinitionsProvider();

            List<IDomainModelDefinitionsProvider> providerList = new List<IDomainModelDefinitionsProvider>
                                                                 {
                                                                     domainCoreDefinitionProvider, extensionDefinitionProvider
                                                                 };

            DomainModelProvider ddm = new DomainModelProvider(providerList);

            var domainModel = ddm.GetDomainModel();

            var resourceModel = new ResourceModel(domainModel);
            var resource = resourceModel.GetResourceByFullName(new FullName("edfi", "CoreEntity"));

            //  force the Lazy-initialization to execute (it will be easier to debug).
            var extensions = resource.Extensions;

            return resource;
        }

        public class When_filtering_resource_members_based_on_a_profile_definition_using_IncludeAll_member_selection
            : TestFixtureBase
        {
            private IMemberFilter _actualMemberFilter;
            private Resource_Resource _suppliedResource;

            protected override void Act()
            {
                _suppliedResource = new Resource_Resource("TestResource");

                // Execute code under test
                var filterProvider = new ProfileResourceMembersFilterProvider();

                var definition = XElement.Parse(
                    @"
<ClassDefinition name='TestResource' memberSelection='IncludeAll'>
</ClassDefinition>");

                _actualMemberFilter = filterProvider.GetMemberFilter(_suppliedResource, definition);
            }

            [Assert]
            public void Should_always_include_the_supplied_identifying_properties()
            {
                Assert.That(_actualMemberFilter.ShouldInclude("PhonyName"));
            }

            [Assert]
            public void Should_include_any_property_name_tested()
            {
                for (int i = 0; i < 10; i++)
                {
                    Assert.That(_actualMemberFilter.ShouldInclude("ArbitraryProperty" + i));
                }
            }

            [Assert]
            public void Filter_type_should_be_IncludeAllMemberFilter()
            {
                Assert.That(_actualMemberFilter.GetType(), Is.EqualTo(typeof(IncludeAllMemberFilter)));
            }
        }

        public class When_filtering_resource_members_based_on_a_profile_definition_using_IncludeOnly_member_selection
            : TestFixtureBase
        {
            private Resource_Resource _suppliedResource;

            private IMemberFilter _actualMemberFilter;

            protected override void Act()
            {
                _suppliedResource = GetTestResource();

                // Execute code under test
                var filterProvider = new ProfileResourceMembersFilterProvider();

                var definition = XElement.Parse(
                    @"
<ClassDefinition name='TestResource' memberSelection='IncludeOnly'>
    <Property name='IncludedProperty1' />
    <Property name='IncludedPropertyWithExpansionOnUSI' />
    <Object name='IncludedObject1' />
    <Collection name='IncludedCollection1' />
</ClassDefinition>");

                _actualMemberFilter = filterProvider.GetMemberFilter(_suppliedResource, definition);
            }

            [Assert]
            public void Should_always_include_the_supplied_identifying_properties()
            {
                foreach (var identifyingProperty in _suppliedResource.IdentifyingProperties)
                {
                    Assert.That(_actualMemberFilter.ShouldInclude(identifyingProperty.PropertyName));
                }
            }

            [Assert]
            public void Should_always_include_the_supplied_identifying_references()
            {
                foreach (var identifyingReference in _suppliedResource.References.Where(r => r.Association.IsIdentifying))
                {
                    Assert.That(_actualMemberFilter.ShouldInclude(identifyingReference.PropertyName));
                }
            }

            [Assert]
            public void Should_not_include_any_arbitrary_property_names_tested()
            {
                for (int i = 0; i < 10; i++)
                {
                    Assert.That(_actualMemberFilter.ShouldInclude("ArbitraryProperty" + i), Is.False);
                }
            }

            [Assert]
            public void Should_include_the_explicitly_included_property_names()
            {
                Assert.That(_actualMemberFilter.ShouldInclude("IncludedProperty1"));
                Assert.That(_actualMemberFilter.ShouldInclude("IncludedObject1"));
                Assert.That(_actualMemberFilter.ShouldInclude("IncludedCollection1"));
            }

            [Assert]
            public void Should_include_UniqueId_property_based_on_USI_name_expansion()
            {
                // NOTE: GKM - Not sure why this behavior is present, but leaving it intact.
                Assert.That(_actualMemberFilter.ShouldInclude("IncludedPropertyWithExpansionOnUSI"));
                Assert.That(_actualMemberFilter.ShouldInclude("IncludedPropertyWithExpansionOnUniqueId"));
            }

            [Assert]
            public void Filter_type_should_be_IncludeOnlyMemberFilter()
            {
                Assert.That(_actualMemberFilter.GetType(), Is.EqualTo(typeof(IncludeOnlyMemberFilter)));
            }
        }

        public class When_filtering_resource_members_based_on_a_profile_definition_using_ExcludeOnly_member_selection
            : TestFixtureBase
        {
            private Resource_Resource _suppliedResource;

            private IMemberFilter _actualMemberFilter;

            protected override void Act()
            {
                // Execute code under test
                _suppliedResource = GetTestResource();

                var filterProvider = new ProfileResourceMembersFilterProvider();

                var definition = XElement.Parse(
                    @"
<ClassDefinition name='TestResource' memberSelection='ExcludeOnly'>
    <Property name='ExcludedProperty1' />
    <Property name='ExcludedPropertyWithExpansionOnUSI' />
    <Object name='ExcludedObject1' />
    <Collection name='ExcludedCollection1' />
</ClassDefinition>");

                _actualMemberFilter = filterProvider.GetMemberFilter(_suppliedResource, definition);
            }

            [Assert]
            public void Should_always_include_the_supplied_identifying_properties()
            {
                foreach (var identifyingProperty in _suppliedResource.IdentifyingProperties)
                {
                    Assert.That(_actualMemberFilter.ShouldInclude(identifyingProperty.PropertyName));
                }
            }

            [Assert]
            public void Should_always_include_the_supplied_identifying_references()
            {
                foreach (var identifyingReference in _suppliedResource.References.Where(r => r.Association.IsIdentifying))
                {
                    Assert.That(_actualMemberFilter.ShouldInclude(identifyingReference.PropertyName));
                }
            }

            [Assert]
            public void Should_include_any_arbitrary_property_names_tested()
            {
                for (int i = 0; i < 10; i++)
                {
                    Assert.That(_actualMemberFilter.ShouldInclude("ArbitraryProperty" + i));
                }
            }

            [Assert]
            public void Should_exclude_the_explicitly_excluded_property_names()
            {
                Assert.That(_actualMemberFilter.ShouldInclude("ExcludedProperty1"), Is.False);
                Assert.That(_actualMemberFilter.ShouldInclude("ExcludedObject1"), Is.False);
                Assert.That(_actualMemberFilter.ShouldInclude("ExcludedCollection1"), Is.False);
            }

            [Assert]
            public void Should_exclude_UniqueId_property_based_on_USI_name_expansion()
            {
                // NOTE: GKM - Not sure why this behavior is present, but leaving it intact.
                Assert.That(_actualMemberFilter.ShouldInclude("ExcludedPropertyWithExpansionOnUSI"), Is.False);
                Assert.That(_actualMemberFilter.ShouldInclude("ExcludedPropertyWithExpansionOnUniqueId"), Is.False);
            }

            [Assert]
            public void Filter_type_should_be_ExcludeOnlyMemberFilter()
            {
                Assert.That(_actualMemberFilter.GetType(), Is.EqualTo(typeof(ExcludeOnlyMemberFilter)));
            }
        }

        public class When_filtering_resource_members_based_on_a_profile_definition_using_IncludeOnly_member_selection_for_extensions
            : TestFixtureBase
        {
            private Resource_Resource _suppliedResource;

            private IMemberFilter _actualMemberFilter;

            protected override void Act()
            {
                _suppliedResource = GetTestResourceForWithAnExtension();

                // Execute code under test
                var filterProvider = new ProfileResourceMembersFilterProvider();

                var definition = XElement.Parse(
                    @"
<ClassDefinition name='CoreEntity' memberSelection='IncludeOnly'>
    <Object name='IncludedObject1' memberSelection='IncludeAll' />
    <Collection name='Collection1Items' memberSelection='IncludeOnly'>
        <Object name='IncludedCollectionObject1' memberSelection='IncludeAll' />
    </Collection>
    <Extension name='Extension-Logical'  memberSelection='IncludeOnly'>
        <Property name='AssessmentCategoryDescriptor'/>
    </Extension>
</ClassDefinition>");

                _actualMemberFilter = filterProvider.GetMemberFilter(_suppliedResource, definition);
            }

            [Test]
            public void Should_include_the_explicitly_included_extension_property_names()
            {
                Assert.That(_actualMemberFilter.ShouldIncludeExtension("ExtensionLogical"), Is.True);
            }

            [Test]
            public void Should_not_include_any_arbitrary_extension_property_names_tested()
            {
                for (int i = 0; i < 10; i++)
                {
                    Assert.That(_actualMemberFilter.ShouldIncludeExtension("ArbitraryProperty" + i), Is.False);
                }
            }
        }
    }
}

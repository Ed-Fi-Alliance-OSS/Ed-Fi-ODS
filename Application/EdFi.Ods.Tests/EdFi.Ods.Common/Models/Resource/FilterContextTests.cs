// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;
using Resource_Resource = EdFi.Ods.Common.Models.Resource.Resource;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Resource
{
    public class FilterContextTests
    {
        internal static IDomainModelDefinitionsProvider BuildCoreModelEntityDefinitionsProvider()
        {
            var edfiSchema = EdFiConventions.PhysicalSchemaName;
            var edfiLogicalName = EdFiConventions.LogicalName;

            var entityDefinitions = new[]
            {
                new EntityDefinition(
                    edfiSchema,
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
                    edfiSchema,
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
                    edfiSchema,
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
                    new FullName(edfiSchema, "FK_CoreEntityEmbeddedObject"),
                    Cardinality.OneToOne,
                    new FullName(edfiSchema, "CoreEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName(edfiSchema, "EmbeddedObject1"),
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                    },
                    isIdentifying: true,
                    isRequired: true),
                new AssociationDefinition(
                    new FullName(edfiSchema, "FK_CoreEntityCollection"),
                    Cardinality.OneToZeroOrMore,
                    new FullName(edfiSchema, "CoreEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("KeyProperty1", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName(edfiSchema, "Collection1Item"),
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
                    new FullName(edfiSchema, "CoreEntity"),
                    new[]
                    {
                        new FullName(edfiSchema, "Collection1Item"), new FullName(edfiSchema, "EmbeddedObject1")
                    })
            };

            var schemaDefinition = new SchemaDefinition(edfiLogicalName, edfiSchema);

            var modelDefinitions = new DomainModelDefinitions(
                schemaDefinition,
                aggredateDefinitions,
                entityDefinitions,
                associationDefinitions);

            var domainModelDefinitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
            A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions())
                .Returns(modelDefinitions);

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
                    new FullName(EdFiConventions.PhysicalSchemaName, "CoreEntity"),
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

            var domainModelDefinitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
            A.CallTo(() => domainModelDefinitionsProvider.GetDomainModelDefinitions())
                .Returns(modelDefinitions2);

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

            DomainModelProvider ddm = new DomainModelProvider(providerList,
                new IDomainModelDefinitionsTransformer[0]);

            var domainModel = ddm.GetDomainModel();

            var resourceModel = new ResourceModel(domainModel);
            var resource = resourceModel.GetResourceByFullName(new FullName(EdFiConventions.PhysicalSchemaName, "CoreEntity"));

            //  force the Lazy-initialization to execute (it will be easier to debug).
            var extensions = resource.Extensions;

            return resource;
        }

        public class When_creating_a_child_filter_context_for_a_child_collection_that_includes_only_certain_members
        : ScenarioFor<FilterContext>
        {
            private FilterContext _actualFilterContext;
            private IResourceMembersFilterProvider _resoureceMembersFilterProvider;
            private IMemberFilter memberFilter;

            protected override void Arrange()
            {
                var xelement = Given(XElement.Parse(
                                     @"
                                        <ClassDefinition name='CoreEntity' memberSelection='IncludeOnly'>
                                            <Object name='IncludedObject1' memberSelection='IncludeAll' />
                                            <Collection name='Collection1Items' memberSelection='IncludeOnly'>
                                                <Object name='IncludedCollectionObject1' memberSelection='IncludeAll' />
                                            </Collection>
                                        </ClassDefinition>"));

                var resourceclassbase = Given((ResourceClassBase)GetTestResourceForWithAnExtension());

                memberFilter = Given<IMemberFilter>();
                _resoureceMembersFilterProvider = A.Fake<IResourceMembersFilterProvider>();

                A.CallTo(() => _resoureceMembersFilterProvider.GetMemberFilter(resourceclassbase, xelement))
                    .Returns(The<IMemberFilter>());

            }

            protected override void Act()
            {
                _actualFilterContext = SystemUnderTest.GetChildContext("Collection1Items");
            }

            [Assert]
            public void FilterContext_should_have_a_reference_to_the_named_child_collection_definition_element()
            {
                Assert.That(_actualFilterContext, Is.Not.Null);
                Assert.That(_actualFilterContext.Definition.AttributeValue("name"), Is.EqualTo("Collection1Items"));
                Assert.That(_actualFilterContext.Definition.Name.LocalName, Is.EqualTo("Collection"));
            }

            [Assert]
            public void FilterContext_should_have_a_reference_to_the_named_child_collection_resource_class()
            {
                Assert.That(_actualFilterContext, Is.Not.Null);
                Assert.That(_actualFilterContext.UnfilteredResourceClass.Name, Is.EqualTo("Collection1Item"));
            }

            [Assert]
            public void Should_return_a_FilterContext_that_uses_the_member_filter_returned_by_the_supplied_filter_provider()
            {
                Assert.AreEqual(_actualFilterContext.MemberFilter.ByProperties<IMemberFilter>(), The<IMemberFilter>());
            }
        }

        public class When_creating_a_child_filter_context_for_a_child_embedded_object_that_includes_all_members
        : ScenarioFor<FilterContext>
        {
            private FilterContext _actualFilterContext;
            private IResourceMembersFilterProvider _resoureceMembersFilterProvider;
            private IMemberFilter memberFilter;

            protected override void Arrange()
            {
                // Initialize dependencies
                Given(
                    XElement.Parse(
                    @"
                        <ClassDefinition name='CoreEntity' memberSelection='IncludeOnly'>
                            <Object name='EmbeddedObject1' memberSelection='IncludeAll' />
                            <Collection name='Collection1Items' memberSelection='IncludeOnly'>
                                <Object name='IncludedCollectionObject1' memberSelection='IncludeAll' />
                            </Collection>
                        </ClassDefinition>"));

                Given((ResourceClassBase)GetTestResourceForWithAnExtension());

                Given<IMemberFilter>();

                memberFilter = The<IMemberFilter>();
                _resoureceMembersFilterProvider = A.Fake<IResourceMembersFilterProvider>();
                A.CallTo(() => _resoureceMembersFilterProvider.GetMemberFilter(A<ResourceClassBase>._, A<XElement>._))
                    .Returns(The<IMemberFilter>());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilterContext = SystemUnderTest.GetChildContext("EmbeddedObject1");
            }

            [Assert]
            public void Should_return_a_FilterContext_that_has_a_reference_to_the_named_child_collection_definition_element()
            {
                Assert.That(_actualFilterContext, Is.Not.Null);
                Assert.That(_actualFilterContext.Definition.AttributeValue("name"), Is.EqualTo("EmbeddedObject1"));
                Assert.That(_actualFilterContext.Definition.Name.LocalName, Is.EqualTo("Object"));
            }

            [Assert]
            public void Should_return_a_FilterContext_that_has_a_reference_to_the_named_child_embedded_object_resource_class()
            {
                Assert.That(_actualFilterContext, Is.Not.Null);
                Assert.That(_actualFilterContext.UnfilteredResourceClass.Name, Is.EqualTo("EmbeddedObject1"));
            }

            [Assert]
            public void Should_return_a_FilterContext_that_uses_the_member_filter_returned_by_the_supplied_filter_provider()
            {
                Assert.AreEqual(_actualFilterContext.MemberFilter.ByProperties<IMemberFilter>(), The<IMemberFilter>());
            }
        }

        [Description("Test to ensure that the Extension node (in the xml) is ignored.")]
        public class When_creating_a_child_filter_context_with_extensions
            : ScenarioFor<FilterContext>
        {
            private FilterContext _actualFilterContext;
            private IResourceMembersFilterProvider _resoureceMembersFilterProvider;
            protected override void Arrange()
            {
                // Initialize dependencies
                Given(
                    XElement.Parse(
                        @"
                            <ClassDefinition name='CoreEntity' memberSelection='IncludeOnly'>
                                <Object name='IncludedObject1' memberSelection='IncludeAll' />
                                <Collection name='Collection1Items' memberSelection='IncludeOnly'>
                                    <Object name='IncludedCollectionObject1' memberSelection='IncludeAll' />
                                </Collection>
                                <Extension name='ExtensionEntity'  memberSelection='IncludeOnly'>
                                    <Property name='AssessmentCategoryDescriptor'/>
                                </Extension>
                            </ClassDefinition>"));

                Given((ResourceClassBase)GetTestResourceForWithAnExtension());

                Given<IMemberFilter>();

                _resoureceMembersFilterProvider = A.Fake<IResourceMembersFilterProvider>();
                A.CallTo(() => _resoureceMembersFilterProvider.GetMemberFilter(A<ResourceClassBase>._, A<XElement>._))
                    .Returns(The<IMemberFilter>());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilterContext = SystemUnderTest.GetChildContext("ExtensionEntity");
            }

            [Test]
            public void Result_filter_context_should_be_null()
            {
                Assert.That(_actualFilterContext, Is.Null);
            }
        }

        [Description("Test to extract a filter-context for an entity extension")]
        public class When_creating_a_extension_filter_context_find_entity_extension
        : ScenarioFor<FilterContext>
        {
            private FilterContext _actualFilterContext;
            private IResourceMembersFilterProvider _resoureceMembersFilterProvider;
            private IMemberFilter memberFilter;

            protected override void Arrange()
            {
                // Initialize dependencies
                Given(
                    XElement.Parse(
                        @"
                            <ClassDefinition name='CoreEntity' memberSelection='IncludeOnly'>
                                <Object name='IncludedObject1' memberSelection='IncludeAll' />
                                <Collection name='Collection1Items' memberSelection='IncludeOnly'>
                                    <Object name='IncludedCollectionObject1' memberSelection='IncludeAll' />
                                </Collection>
                                <Extension name='Extension-Logical'  memberSelection='IncludeOnly'>
                                    <Property name='AssessmentCategoryDescriptor'/>
                                </Extension>
                            </ClassDefinition>"));

                Given((ResourceClassBase)GetTestResourceForWithAnExtension());

                memberFilter = Given<IMemberFilter>();
                _resoureceMembersFilterProvider = A.Fake<IResourceMembersFilterProvider>();
                A.CallTo(() => _resoureceMembersFilterProvider.GetMemberFilter(A<ResourceClassBase>._, A<XElement>._))
                    .Returns(The<IMemberFilter>());
            }

            protected override void Act()
            {
                // Execute code under test
                _actualFilterContext = SystemUnderTest.GetExtensionContext("ExtensionLogical");
            }

            [Test]
            public void ResourceClass_should_be_Extension_Entity_type()
            {
                Assert.That(_actualFilterContext.UnfilteredResourceClass.Name, Is.EqualTo("ExtensionEntity"));

                Assert.That(
                    _actualFilterContext.UnfilteredResourceClass.Entity.FullName,
                    Is.EqualTo(new FullName("ExtensionPhysical", "ExtensionEntity")));
            }

            [Test]
            public void Result_filter_context_is_not_null()
            {
                Assert.That(_actualFilterContext?.Definition, Is.Not.Null);
            }

            [Test]
            public void Result_filter_should_contain_values_from_xelement()
            {
                Assert.That(
                    _actualFilterContext.Definition.Attribute("name")
                        ?.Value,
                    Is.EqualTo("Extension-Logical"));

                Assert.That(
                    _actualFilterContext.Definition.DescendantNodes()
                        .Count(),
                    Is.EqualTo(1));
            }

            [Assert]
            public void Should_return_a_FilterContext_that_uses_the_member_filter_returned_by_the_supplied_filter_provider()
            {
                Assert.AreEqual(_actualFilterContext.MemberFilter.ByProperties<IMemberFilter>(), The<IMemberFilter>());
            }
        }

    }

    public static class MemberFilterExtension
    {
        internal static IMemberFilter ByProperties<T>(this IMemberFilter expected)
        {
            var fakeExpected = A.Fake<IMemberFilter>(o => o.Wrapping(expected));
            var properties = expected.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            A.CallTo(() => fakeExpected.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var actual = call.GetArgument<object>(0);
                    if (ReferenceEquals(null, actual))
                        return false;
                    if (ReferenceEquals(expected, actual))
                        return true;
                    if (actual.GetType() != expected.GetType())
                        return false;
                    return AreEqualByProperties(expected, actual, properties);
                });
            return fakeExpected;
        }

        internal static bool AreEqualByProperties(object expected, object actual, PropertyInfo[] properties)
        {
            foreach (var propertyInfo in properties)
            {
                var expectedValue = propertyInfo.GetValue(expected);
                var actualValue = propertyInfo.GetValue(actual);
                if (expectedValue == null || actualValue == null)
                {
                    if (expectedValue != null || actualValue != null)
                    {
                        return false;
                    }
                }
                else if (typeof(System.Collections.IList).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    if (!AssertListsEquals((IList)expectedValue, (IList)actualValue))
                    {
                        return false;
                    }
                }
                else if (!expectedValue.Equals(actualValue))
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool AssertListsEquals(IList expectedValue, IList actualValue)
        {
            if (expectedValue.Count != actualValue.Count)
            {
                return false;
            }
            for (int I = 0; I < expectedValue.Count; I++)
            {
                if (!Equals(expectedValue[I], actualValue[I]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

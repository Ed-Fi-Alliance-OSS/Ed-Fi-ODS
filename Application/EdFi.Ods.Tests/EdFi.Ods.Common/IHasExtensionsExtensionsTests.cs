// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Tests._Extensions;
using EdFi.TestFixture;
using FakeItEasy;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    // SPIKE NOTE: These unit tests deserve code coverage analysis and an attempt to bring up the coverage level of the extension methods.

    [TestFixture]
    public class Feature_Synchronizing_extensions
    {
        [TestFixture]
        public class When_synchronizing_entity_extensions_where_modifications_have_been_made : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension;
            private ISynchronizable _suppliedTargetEntityExtension;

            private bool _actualIsModified;
            private FakeExtensionsMappingContract _extensionsMappingContract;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension = Stub<ISynchronizable>();

                A.CallTo(() => _suppliedSourceEntityExtension.Synchronize(A<object>._)).Returns(true);

                // Source extension entry, mapped from the resource object, will be an ArrayList of "transient" entities
                var sourceExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new ArrayList
                        {
                            _suppliedSourceEntityExtension
                        }
                    }
                };

                _suppliedSourceEntity = new FakeEntityWithExtensions(sourceExtensions);

                // Target extension entries during synchronization are "persistent" entities loaded through NHibernate, and due to the NHibernate mapping approach for extensions, will be a list with a single "persistent" entity
                _suppliedTargetEntityExtension = Stub<ISynchronizable>();

                var targetExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new List<ISynchronizable>
                        {
                            _suppliedTargetEntityExtension
                        }
                    }
                };

                _suppliedTargetEntity = new FakeEntityWithExtensions(targetExtensions);

                _extensionsMappingContract = new FakeExtensionsMappingContract("Extension1");
            }

            protected override void Act()
            {
                _actualIsModified = _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity, _extensionsMappingContract);
            }

            [Assert]
            public void
                Should_obtain_the_target_entity_extension_from_the_list_and_use_it_as_the_synchronization_target_for_the_source_entity_extension()
            {
                A.CallTo(() => _suppliedSourceEntityExtension.Synchronize(_suppliedTargetEntityExtension)).MustHaveHappenedOnceExactly();
            }

            [Assert]
            public void Should_indicate_modifications_were_made()
            {
                Assert.That(_actualIsModified);
            }
        }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_no_modifications_have_been_made : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension;
            private ISynchronizable _suppliedTargetEntityExtension;

            private bool _actualIsModified;
            private FakeExtensionsMappingContract _extensionsMappingContract;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension = Stub<ISynchronizable>();

                // No modifications have been made
                A.CallTo(()=> _suppliedSourceEntityExtension.Synchronize(A<object>._))
                    .Returns(false);

                // Source extension entry, mapped from the resource object, will be a "transient" entity
                var sourceExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new ArrayList
                        {
                            _suppliedSourceEntityExtension
                        }
                    }
                };

                _suppliedSourceEntity = new FakeEntityWithExtensions(sourceExtensions);

                // Target extension entries during synchronization are "persistent" entities loaded through NHibernate, and due to the NHibernate mapping approach for extensions, will be a list with a single "persistent" entity
                _suppliedTargetEntityExtension = Stub<ISynchronizable>();

                var targetExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new ArrayList
                        {
                            _suppliedTargetEntityExtension
                        }
                    }
                };

                _suppliedTargetEntity = new FakeEntityWithExtensions(targetExtensions);
                _extensionsMappingContract = new FakeExtensionsMappingContract("Extension1");
            }

            protected override void Act()
            {
                _actualIsModified = _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity, _extensionsMappingContract);
            }

            [Assert]
            public void
                Should_obtain_the_target_entity_extension_from_the_list_and_use_it_as_the_synchronization_target_for_the_source_entity_extension()
            {
                A.CallTo(() => _suppliedSourceEntityExtension.Synchronize(_suppliedTargetEntityExtension))
                    .MustHaveHappenedOnceExactly();
            }

            [Assert]
            public void Should_indicate_no_modifications_were_made()
            {
                Assert.That(_actualIsModified, Is.False);
            }
        }

        [TestFixture]
        public class When_synchronizing_two_entity_extensions_where_only_the_first_extension_has_modifications : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension1;
            private ISynchronizable _suppliedSourceEntityExtension2;
            private ISynchronizable _suppliedTargetEntityExtension1;
            private ISynchronizable _suppliedTargetEntityExtension2;

            private bool _actualIsModified;
            private FakeExtensionsMappingContract _extensionsMappingContract;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();
                _suppliedSourceEntityExtension2 = Stub<ISynchronizable>();

                // First extension has modifications
                A.CallTo(() => _suppliedSourceEntityExtension1.Synchronize(A<object>._)).Returns(true);

                // Second extension has no modifications, but should not overwrite state
                A.CallTo(() => _suppliedSourceEntityExtension2.Synchronize(A<object>._)).Returns(false);

                // Source extension entry, mapped from the resource object, will be a ArrayList of "transient" entities
                var sourceExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new ArrayList
                        {
                            _suppliedSourceEntityExtension1
                        }
                    },
                    {
                        "Extension2", new ArrayList
                        {
                            _suppliedSourceEntityExtension2
                        }
                    }
                };

                _suppliedSourceEntity = new FakeEntityWithExtensions(sourceExtensions);

                // Target extension entries during synchronization are "persistent" entities loaded through NHibernate, and due to the NHibernate mapping approach for extensions, will be a list with a single "persistent" entity
                _suppliedTargetEntityExtension1 = Stub<ISynchronizable>();
                _suppliedTargetEntityExtension2 = Stub<ISynchronizable>();

                var targetExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new List<ISynchronizable>
                        {
                            _suppliedTargetEntityExtension1
                        }
                    },
                    {
                        "Extension2", new List<ISynchronizable>
                        {
                            _suppliedTargetEntityExtension2
                        }
                    }
                };

                _suppliedTargetEntity = new FakeEntityWithExtensions(targetExtensions);
                _extensionsMappingContract = new FakeExtensionsMappingContract("Extension1");
            }

            protected override void Act()
            {
                _actualIsModified = _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity, _extensionsMappingContract);
            }

            [Assert]
            public void Should_indicate_that_modifications_were_made()
            {
                Assert.That(_actualIsModified, Is.True);
            }
        }

        // SPIKE NOTE: Test is obsolete, but needs to be rewritten to cover use of the mapping contract appropriately.
        // [TestFixture]
        // public class When_synchronizing_entity_extensions_where_the_source_entity_is_not_a_synchronization_source_for_some_of_the_extensions
        //     : TestFixtureBase
        // {
        //     private FakeEntityWithExtensions _suppliedSourceEntity;
        //     private FakeEntityWithExtensions _suppliedTargetEntity;
        //
        //     private ISynchronizable _suppliedSourceEntityExtension1;
        //     private ISynchronizable _suppliedSourceEntityExtension2;
        //     private ISynchronizable _suppliedTargetEntityExtension1;
        //     private ISynchronizable _suppliedTargetEntityExtension2;
        //
        //     protected override void Arrange()
        //     {
        //         _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();
        //         _suppliedSourceEntityExtension2 = Stub<ISynchronizable>();
        //
        //         A.CallTo(() => _suppliedSourceEntityExtension1.Synchronize(A<object>._)).Returns(true);
        //
        //         // Source extension entry, mapped from the resource object, will be an ArrayList of "transient" entities
        //         var sourceExtensions = new Dictionary<string, object>
        //         {
        //             {
        //                 "Extension1", new ArrayList
        //                 {
        //                     _suppliedSourceEntityExtension1
        //                 }
        //             },
        //             {
        //                 "Extension2", new ArrayList
        //                 {
        //                     _suppliedSourceEntityExtension2
        //                 }
        //             }
        //         };
        //
        //         _suppliedSourceEntity = new FakeEntityWithExtensions(sourceExtensions);
        //
        //         // Extension2 is not supported as a synch source
        //         _suppliedSourceEntity.SetExtensionSupported("Extension2", false);
        //
        //         // Target extension entries during synchronization are "persistent" entities loaded through NHibernate, and due to the NHibernate mapping approach for extensions, will be a list with a single "persistent" entity
        //         _suppliedTargetEntityExtension1 = Stub<ISynchronizable>();
        //         _suppliedTargetEntityExtension2 = Stub<ISynchronizable>();
        //
        //         var targetExtensions = new Dictionary<string, object>
        //         {
        //             {
        //                 "Extension1", new List<ISynchronizable>
        //                 {
        //                     _suppliedTargetEntityExtension1
        //                 }
        //             },
        //             {
        //                 "Extension2", new List<ISynchronizable>
        //                 {
        //                     _suppliedTargetEntityExtension2
        //                 }
        //             }
        //         };
        //
        //         _suppliedTargetEntity = new FakeEntityWithExtensions(targetExtensions);
        //     }
        //
        //     protected override void Act()
        //     {
        //         _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
        //     }
        //
        //     [Assert]
        //     public void Should_attempt_to_synchronize_extensions_that_are_supported_as_a_synchronization_source()
        //     {
        //         A.CallTo(() => _suppliedSourceEntityExtension1.Synchronize(_suppliedTargetEntityExtension1)).MustHaveHappenedOnceExactly();
        //     }
        //
        //     [Assert]
        //     public void Should_not_attempt_to_synchronize_extensions_that_are_not_supported_as_a_synchronization_source()
        //     {
        //         A.CallTo(() => _suppliedSourceEntityExtension2.Synchronize(A<string>._)).MustNotHaveHappened();
        //     }
        // }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_the_source_entity_is_a_synchronization_source_for_the_extensions_but_it_is_not_present
            : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension1;
            private ISynchronizable _suppliedTargetEntityExtension1;
            private FakeExtensionsMappingContract _extensionsMappingContract;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();

                A.CallTo(() => _suppliedSourceEntityExtension1.Synchronize(A<object>._)).Returns(true);

                // Source extension entry, mapped from the resource object, will be a "transient" entity
                var sourceExtensions = new Dictionary<string, object>();
                _suppliedSourceEntity = new FakeEntityWithExtensions(sourceExtensions);

                // Target extension entries during synchronization are "persistent" entities loaded through NHibernate, and due to the NHibernate mapping approach for extensions, will be a list with a single "persistent" entity
                _suppliedTargetEntityExtension1 = Stub<ISynchronizable>();

                var targetExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new List<ISynchronizable>
                        {
                            _suppliedTargetEntityExtension1
                        }
                    }
                };

                _suppliedTargetEntity = new FakeEntityWithExtensions(targetExtensions);
                _extensionsMappingContract = new FakeExtensionsMappingContract("Extension1");
            }

            protected override void Act()
            {
                _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity, _extensionsMappingContract);
            }

            [Assert]
            public void Should_throw_an_exception_indicating_that_an_entity_extension_that_was_supported_by_the_source_was_not_present()
            {
                ActualException.MessageShouldContain("the extension was not provided");
            }
        }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_the_target_entity_does_not_have_the_extension_present : TestFixtureBase
        {
            // NOTE: Given current system behavior, this should never happen - the extensions factory should
            // create the new extension entity instance in the target list during entity initialization.
            // If there were not to be an extension entity present on the target, it should simply be ignored
            // as the source would be deemed to be invalid.

            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension1;
            private ISynchronizable _suppliedSourceEntityExtension2;
            private ISynchronizable _suppliedTargetEntityExtension1;
            private FakeExtensionsMappingContract _extensionsMappingContract;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();
                _suppliedSourceEntityExtension2 = Stub<ISynchronizable>();

                A.CallTo(() => _suppliedSourceEntityExtension1.Synchronize(A<object>._)).Returns(true);

                // Source extension entry, mapped from the resource object, will be an ArrayList of "transient" entities
                var sourceExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new ArrayList
                        {
                            _suppliedSourceEntityExtension1
                        }
                    },
                    {
                        "Extension2", new ArrayList
                        {
                            _suppliedSourceEntityExtension2
                        }
                    }
                };

                _suppliedSourceEntity = new FakeEntityWithExtensions(sourceExtensions);

                // Target extension entries during synchronization are "persistent" entities loaded through NHibernate, and due to the NHibernate mapping approach for extensions, will be a list with a single "persistent" entity
                _suppliedTargetEntityExtension1 = Stub<ISynchronizable>();

                var targetExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new List<ISynchronizable>
                        {
                            _suppliedTargetEntityExtension1
                        }
                    }
                };

                _suppliedTargetEntity = new FakeEntityWithExtensions(targetExtensions);
                _extensionsMappingContract = new FakeExtensionsMappingContract("Extension1");
            }

            protected override void Act()
            {
                _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity, _extensionsMappingContract);
            }

            [Assert]
            public void Should_attempt_to_synchronize_extensions_that_are_present_on_the_target()
            {
                A.CallTo(() => _suppliedSourceEntityExtension1.Synchronize(_suppliedTargetEntityExtension1)).MustHaveHappened();
            }

            [Assert]
            public void Should_not_attempt_to_synchronize_extensions_that_are_not_present_on_the_target()
            {
                A.CallTo(() => _suppliedSourceEntityExtension2.Synchronize(A<string>._)).MustNotHaveHappened();
            }
        }
    }

    // Interfaces used for mocking different types of source/target objects with behaviors of their real-world counterparts
    public interface IMappableEntity : IMappable, IHasPrimaryKeyValues { }

    public interface IMappableExtensionEntity : IMappable, IHasPrimaryKeyValues, IChildEntity { }

    public interface IMappableResource : IMappable { }

    public interface IMappableImplicitExtensionEntity : IMappableExtensionEntity, IImplicitEntityExtension { }

    [TestFixture]
    public class Feature_Mapping_extensions
    {
        [TestFixture]
        public class When_mapping_extensions_between_entities : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceObject;
            private FakeEntityWithExtensions _suppliedTargetObject;

            private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
                new ConcurrentDictionary<string, object>();

            private IMappableExtensionEntity _suppliedSourceExtension1Object;
            private IMappableExtensionEntity _suppliedSourceExtension2Object;

            protected override void Arrange()
            {
                _suppliedSourceExtension1Object = Stub<IMappableExtensionEntity>();
                _suppliedSourceExtension2Object = Stub<IMappableExtensionEntity>();

                // Entity extensions are always wrapped in a list, due to NHibernate mappings
                var sourceExtensions = new Dictionary<string, object>
                {
                    {
                        "Extension1", new List<IMappableExtensionEntity>
                        {
                            _suppliedSourceExtension1Object
                        }
                    },
                    {
                        "Extension2", new List<IMappableExtensionEntity>
                        {
                            _suppliedSourceExtension2Object
                        }
                    }
                };

                _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);

                var targetExtensions = new Dictionary<string, object>();
                _suppliedTargetObject = new FakeEntityWithExtensions(targetExtensions);

                IHasExtensionsExtensions.CreateTargetExtensionObject
                    = (t, x) =>
                    {
                        var targetExtensionObjectMock = Stub<IMappableExtensionEntity>();

                        _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);

                        return targetExtensionObjectMock;
                    };
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject, null);
            }

            [Assert]
            public void Should_map_each_source_extension_entity_to_a_newly_created_target_extension_entity()
            {
                // Get the created target extension object
                var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];

                A.CallTo(
                    () => _suppliedSourceExtension1Object.Map(A<object>.That.Equals(expectedTarget)));

                expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension2"];

                A.CallTo(
                    () => _suppliedSourceExtension2Object.Map(A<object>.That.Equals(expectedTarget)));
            }

            [Assert]
            public void Should_set_the_target_extension_entity_back_references_to_the_supplied_target_entity()
            {
                foreach (IMappableExtensionEntity targetExtensionObject in _suppliedTargetExtensionObjectByExtensionName.Values)
                {
                    A.CallTo(() => targetExtensionObject.SetParent(A<object>.That.IsSameAs(_suppliedTargetObject))).MustHaveHappened();
                }

                // Make sure something was verified
                Assert.That(_suppliedTargetExtensionObjectByExtensionName, Has.Count.GreaterThan(0), "Nothing was verified.");
            }

            [Assert]
            public void Should_wrap_the_newly_created_target_extension_objects_inside_a_collection_in_the_extensions_dictionary()
            {
                var suppliedTargetExtensions1 = _suppliedTargetObject.Extensions["Extension1"];
                var suppliedTargetExtensions2 = _suppliedTargetObject.Extensions["Extension2"];

                AssertHelper.All(

                    // Extension1
                    () => Assert.That(
                        suppliedTargetExtensions1,
                        Is.InstanceOf<ICollection>(),
                        "Extension1 was not wrapped within a collection."),
                    () => Assert.That(suppliedTargetExtensions1, Has.Count.EqualTo(1)),
                    () => Assert.That(suppliedTargetExtensions1, Has.Member(_suppliedTargetExtensionObjectByExtensionName["Extension1"])),

                    // Extension2
                    () => Assert.That(
                        _suppliedTargetObject.Extensions["Extension2"],
                        Is.InstanceOf<ICollection>(),
                        "Extension2 was not wrapped within a collection."),
                    () => Assert.That(suppliedTargetExtensions2, Has.Count.EqualTo(1)),
                    () => Assert.That(suppliedTargetExtensions2, Has.Member(_suppliedTargetExtensionObjectByExtensionName["Extension2"]))
                );
            }
        }

        [TestFixture]
        public class When_mapping_extensions_from_an_entity_to_a_resource : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceObject;
            private FakeEntityWithExtensions _suppliedTargetObject;

            private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
                new ConcurrentDictionary<string, object>();

            private IMappableExtensionEntity _suppliedSourceExtension1Object;
            private IMappableExtensionEntity _suppliedSourceExtension2Object;
            private IMappableImplicitExtensionEntity _suppliedEmptyImplicitSourceExtensionObject;
            private IMappableImplicitExtensionEntity _suppliedNonEmptyImplicitSourceExtensionObject;

            protected override void Arrange()
            {
                _suppliedSourceExtension1Object = Stub<IMappableExtensionEntity>();
                _suppliedSourceExtension2Object = Stub<IMappableExtensionEntity>();
                _suppliedEmptyImplicitSourceExtensionObject = Stub<IMappableImplicitExtensionEntity>();
                _suppliedNonEmptyImplicitSourceExtensionObject = Stub<IMappableImplicitExtensionEntity>();

                A.CallTo(() => _suppliedEmptyImplicitSourceExtensionObject.IsEmpty()).Returns(true);
                A.CallTo(() => _suppliedNonEmptyImplicitSourceExtensionObject.IsEmpty()).Returns(false);

                // Entity extensions are always wrapped in a list, due to NHibernate mappings
                var sourceExtensions = new Dictionary<string, object>
                {
                    {"Extension1", new List<IMappableExtensionEntity> {_suppliedSourceExtension1Object}},
                    {"Extension2", new List<IMappableExtensionEntity> {_suppliedSourceExtension2Object}},
                    {"EmptyImplicitExtension", new List<IMappableExtensionEntity> {_suppliedEmptyImplicitSourceExtensionObject}},
                    {"NonEmptyImplicitExtension", new List<IMappableExtensionEntity> {_suppliedNonEmptyImplicitSourceExtensionObject}},
                };

                _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);

                // Resources don't start with Extensions initialized
                _suppliedTargetObject = new FakeEntityWithExtensions(null);

                IHasExtensionsExtensions.CreateTargetExtensionObject
                    = (t, x) =>
                    {
                        var targetExtensionObjectMock = Stub<IMappableResource>();

                        _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);

                        return targetExtensionObjectMock;
                    };
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject, null);
            }

            [Assert]
            public void Should_map_each_source_extension_entity_to_a_newly_created_target_extension_resource()
            {
                AssertHelper.All(
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];

                        A.CallTo(() => _suppliedSourceExtension1Object.Map(A<object>.That
                            .IsSameAs(expectedTarget))).MustHaveHappenedOnceExactly();

                    },
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension2"];

                        A.CallTo(() => _suppliedSourceExtension2Object.Map(A<object>.That
                            .IsSameAs(expectedTarget))).MustHaveHappenedOnceExactly();
                    });
            }

            [Assert]
            public void Should_map_the_non_empty_source_implicit_extension_entity_to_a_newly_created_target_extension_resource()
            {
                // Get the created target extension object
                var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["NonEmptyImplicitExtension"];

                A.CallTo(() => _suppliedNonEmptyImplicitSourceExtensionObject.Map(A<object>.That
                    .IsSameAs(expectedTarget))).MustHaveHappenedOnceExactly();
            }

            [Assert]
            public void Should_NOT_map_the_empty_source_implicit_extension_entity_to_a_newly_created_target_extension_resource()
            {
                Assert.That(
                    _suppliedTargetExtensionObjectByExtensionName.ContainsKey("EmptyImplicitExtension"),
                    Is.False);
            }

            [Assert]
            public void Should_NOT_wrap_the_newly_created_target_extension_resources_inside_a_collection_in_the_extensions_dictionary()
            {
                var suppliedTargetExtensions1 = _suppliedTargetObject.Extensions["Extension1"];
                var suppliedTargetExtensions2 = _suppliedTargetObject.Extensions["Extension2"];

                AssertHelper.All(

                    // Extension1
                    () => Assert.That(
                        suppliedTargetExtensions1,
                        Is.Not.InstanceOf<ICollection>(),
                        "Extension1 was wrapped within a collection."),
                    () => Assert.That(suppliedTargetExtensions1, Is.SameAs(_suppliedTargetExtensionObjectByExtensionName["Extension1"])),

                    // Extension2
                    () => Assert.That(
                        _suppliedTargetObject.Extensions["Extension2"],
                        Is.Not.InstanceOf<ICollection>(),
                        "Extension2 was wrapped within a collection."),
                    () => Assert.That(suppliedTargetExtensions2, Is.SameAs(_suppliedTargetExtensionObjectByExtensionName["Extension2"]))
                );
            }
        }

        // SPIKE NOTE: Test seems to be obsolete, but needs to be rewritten to cover use of synchronization context appropriately.
        // [TestFixture]
        // public class When_mapping_extensions_from_a_resource_to_an_entity : TestFixtureBase
        // {
        //     private FakeEntityWithExtensions _suppliedSourceObject;
        //     private FakeEntityWithExtensions _suppliedTargetObject;
        //
        //     private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
        //         new ConcurrentDictionary<string, object>();
        //
        //     private IMappableResource _suppliedSourceExtension1Object;
        //     private IMappableResource _suppliedSourceExtension2Object;
        //     private IMappableResource _suppliedUnsupportedExtensionObject;
        //
        //     protected override void Arrange()
        //     {
        //         _suppliedSourceExtension1Object = Stub<IMappableResource>();
        //         _suppliedSourceExtension2Object = Stub<IMappableResource>();
        //         _suppliedUnsupportedExtensionObject = Stub<IMappableResource>();
        //
        //         var sourceExtensions = new Dictionary<string, object>
        //         {
        //             {
        //                 "Extension1", _suppliedSourceExtension1Object
        //             },
        //             {
        //                 "Extension2", _suppliedSourceExtension2Object
        //             },
        //             {
        //                 "UnsupportedExtension", _suppliedUnsupportedExtensionObject
        //             }
        //         };
        //
        //         _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);
        //         _suppliedSourceObject.SetExtensionSupported("UnsupportedExtension", false);
        //
        //         var targetExtensions = new Dictionary<string, object>();
        //         _suppliedTargetObject = new FakeEntityWithExtensions(targetExtensions);
        //
        //         IHasExtensionsExtensions.CreateTargetExtensionObject
        //             = (t, x) =>
        //             {
        //                 var targetExtensionObjectMock = Stub<IMappableExtensionEntity>();
        //
        //                 _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);
        //
        //                 return targetExtensionObjectMock;
        //             };
        //     }
        //
        //     protected override void Act()
        //     {
        //         _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject);
        //     }
        //
        //     [Assert]
        //     public void Should_map_each_supported_source_extension_resource_to_a_newly_created_target_extension_entity()
        //     {
        //         AssertHelper.All(
        //             () =>
        //             {
        //                 // Get the created target extension object
        //                 var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];
        //
        //                 A.CallTo(() => _suppliedSourceExtension1Object.Map(A<object>.That
        //                     .IsSameAs(expectedTarget))).MustHaveHappenedOnceExactly();
        //
        //             },
        //             () =>
        //             {
        //                 // Get the created target extension object
        //                 var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension2"];
        //
        //                 A.CallTo(() => _suppliedSourceExtension2Object.Map(A<object>.That
        //                     .IsSameAs(expectedTarget))).MustHaveHappenedOnceExactly();
        //             });
        //     }
        //
        //     [Assert]
        //     public void Should_NOT_map_the_unsupported_source_extension_object()
        //     {
        //         A.CallTo(() => _suppliedUnsupportedExtensionObject.Map(A<object>._));
        //     }
        //
        //     [Assert]
        //     public void Should_NOT_create_a_target_extension_entity_for_the_unsupported_extension()
        //     {
        //         // Get the created target extension object
        //         object expectedTarget;
        //
        //         Assert.That(
        //             _suppliedTargetExtensionObjectByExtensionName.TryGetValue("UnsupportedExtension", out expectedTarget),
        //             Is.False);
        //     }
        //
        //     [Assert]
        //     public void Should_indicate_on_the_target_object_that_the_extensions_are_available()
        //     {
        //         Assert.That(_suppliedTargetObject.IsExtensionAvailable("Extension1"), Is.True);
        //         Assert.That(_suppliedTargetObject.IsExtensionAvailable("Extension2"), Is.True);
        //     }
        //
        //     [Assert]
        //     public void Should_indicate_that_the_unsupported_but_present_extension_on_the_resource_is_NOT_available_on_the_target()
        //     {
        //         Assert.That(_suppliedTargetObject.IsExtensionAvailable("UnsupportedExtension"), Is.False);
        //     }
        //
        //     [Assert]
        //     public void Should_NOT_indicate_on_the_target_object_that_non_existent_extensions_are_available()
        //     {
        //         Assert.That(_suppliedTargetObject.IsExtensionAvailable("NonExistentExtension"), Is.False);
        //     }
        //
        //     [Assert]
        //     public void Should_set_the_target_extension_entity_back_references_to_the_supplied_target_entity()
        //     {
        //         foreach (IMappableExtensionEntity targetExtensionObject in _suppliedTargetExtensionObjectByExtensionName.Values)
        //         {
        //             A.CallTo(() => targetExtensionObject.SetParent(A<object>.That.IsSameAs(_suppliedTargetObject)));
        //         }
        //
        //         // Make sure something was verified
        //         Assert.That(_suppliedTargetExtensionObjectByExtensionName, Has.Count.GreaterThan(0), "Nothing was verified.");
        //     }
        //
        //     [Assert]
        //     public void Should_wrap_the_newly_created_target_extension_objects_inside_a_collection_in_the_extensions_dictionary()
        //     {
        //         var suppliedTargetExtensions1 = _suppliedTargetObject.Extensions["Extension1"];
        //         var suppliedTargetExtensions2 = _suppliedTargetObject.Extensions["Extension2"];
        //
        //         AssertHelper.All(
        //
        //             // Extension1
        //             () => Assert.That(
        //                 suppliedTargetExtensions1,
        //                 Is.InstanceOf<ICollection>(),
        //                 "Extension1 was not wrapped within a collection."),
        //             () => Assert.That(suppliedTargetExtensions1, Has.Count.EqualTo(1)),
        //             () => Assert.That(suppliedTargetExtensions1, Has.Member(_suppliedTargetExtensionObjectByExtensionName["Extension1"])),
        //
        //             // Extension2
        //             () => Assert.That(
        //                 _suppliedTargetObject.Extensions["Extension2"],
        //                 Is.InstanceOf<ICollection>(),
        //                 "Extension2 was not wrapped within a collection."),
        //             () => Assert.That(suppliedTargetExtensions2, Has.Count.EqualTo(1)),
        //             () => Assert.That(suppliedTargetExtensions2, Has.Member(_suppliedTargetExtensionObjectByExtensionName["Extension2"]))
        //         );
        //     }
        // }

        // SPIKE NOTE: Review test for updates or removal
        // [TestFixture]
        // public class When_mapping_extensions_from_a_resource_to_an_entity_where_one_extension_is_not_supported_as_a_synchronization_source
        //     : TestFixtureBase
        // {
        //     private FakeEntityWithExtensions _suppliedSourceObject;
        //     private FakeEntityWithExtensions _suppliedTargetObject;
        //
        //     private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
        //         new ConcurrentDictionary<string, object>();
        //
        //     private IMappableResource _suppliedSourceExtension1Object;
        //     private IMappableResource _suppliedSourceExtension2Object;
        //
        //     protected override void Arrange()
        //     {
        //         _suppliedSourceExtension1Object = Stub<IMappableResource>();
        //         _suppliedSourceExtension2Object = Stub<IMappableResource>();
        //
        //         var sourceExtensions = new Dictionary<string, object>
        //         {
        //             {
        //                 "Extension1", _suppliedSourceExtension1Object
        //             },
        //
        //             // Not supported
        //             {
        //                 "Extension2", _suppliedSourceExtension2Object
        //             }
        //         };
        //
        //         // Source resource doesn't support Extension2
        //         _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);
        //         _suppliedSourceObject.SetExtensionSupported("Extension2", false);
        //
        //         var targetExtensions = new Dictionary<string, object>();
        //         _suppliedTargetObject = new FakeEntityWithExtensions(targetExtensions);
        //
        //         IHasExtensionsExtensions.CreateTargetExtensionObject
        //             = (t, x) =>
        //             {
        //                 var targetExtensionObjectMock = Stub<IMappableExtensionEntity>();
        //
        //                 _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);
        //
        //                 return targetExtensionObjectMock;
        //             };
        //     }
        //
        //     protected override void Act()
        //     {
        //         _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject, null);
        //     }
        //
        //     [Assert]
        //     public void Should_map_the_SUPPORTED_source_extension_resource_to_a_newly_created_target_extension_entity()
        //     {
        //         // Get the created target extension object
        //         var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];
        //
        //         A.CallTo(() => _suppliedSourceExtension1Object.Map(A<object>.That.IsSameAs(expectedTarget))).MustHaveHappened();
        //
        //     }
        //
        //     [Assert]
        //     public void Should_not_create_a_new_entity_extension_object_for_the_unsupported_extension()
        //     {
        //         // Get the created target extension object
        //         Assert.That(
        //             _suppliedTargetExtensionObjectByExtensionName.ContainsKey("Extension2"),
        //             Is.False,
        //             "The extension object for unsupported Extension2 was created.");
        //     }
        //
        //     [Assert]
        //     public void Should_not_attempt_to_map_the_unsupported_source_extension_object()
        //     {
        //         A.CallTo(() => _suppliedSourceExtension2Object.Map(A<object>._)).MustNotHaveHappened();
        //     }
        //
        //     [Assert]
        //     public void Should_only_add_the_supported_extension_to_the_target_entitys_extensions()
        //     {
        //         Assert.That(
        //             _suppliedTargetObject.Extensions.Contains("Extension1"),
        //             Is.True,
        //             "Supported Extension1 was not added to the target entity's extensions.");
        //
        //         Assert.That(
        //             _suppliedTargetObject.Extensions.Contains("Extension2"),
        //             Is.False,
        //             "Unsupported Extension2 was added to the target entity's extensions.");
        //     }
        //
        //     [Assert]
        //     public void Should_propagate_the_lack_of_support_for_the_unsupported_extension_to_the_entity()
        //     {
        //         Assert.That(_suppliedTargetObject.SynchronizationContext.IsExtensionSupported("Extension2"), Is.False);
        //     }
        //
        //     [Assert]
        //     public void Should_propagate_the_support_for_the_supported_extension_to_the_entity()
        //     {
        //         Assert.That(_suppliedTargetObject.SynchronizationContext.IsExtensionSupported("Extension1"), Is.True);
        //     }
        // }

        [TestFixture]
        public class When_mapping_an_entity_without_extensions_to_a_resource : TestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceObject;
            private FakeEntityWithExtensions _suppliedTargetObject;

            protected override void Arrange()
            {
                // Entity extensions are always wrapped in a list, due to NHibernate mappings
                var sourceExtensions = new Dictionary<string, object>();
                _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);

                // Resources don't start with Extensions dictionary initialized
                _suppliedTargetObject = new FakeEntityWithExtensions(null);
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject, null);
            }

            [Assert]
            public void Should_not_initialize_the_extensions_dictionary_on_the_target_resource()
            {
                Assert.That(_suppliedTargetObject.Extensions, Is.Null);
            }
        }
    }

    internal class FakeEntityWithExtensions : ISynchronizable, IHasExtensions, IMappable
    {
        public FakeEntityWithExtensions()
        {
            Extensions = new Dictionary<string, object>();
        }

        public FakeEntityWithExtensions(IDictionary extensions)
        {
            Extensions = extensions;
        }

        public IDictionary Extensions { get; set; }

        public void Map(object target) { }

        public bool Synchronize(object target)
        {
            return true;
        }
        
        // SPIKE NOTE: After removing or fixing the commented out tests above, remove this if it is still not used.
        public IExtensionsMappingContract MappingContract { get; }
    }
    
    internal class FakeExtensionsMappingContract : IExtensionsMappingContract
    {
        private readonly string[] _extensions;

        public FakeExtensionsMappingContract(params string[] extensions)
        {
            _extensions = extensions;
        }
        
        public bool IsExtensionSupported(string name)
        {
            return _extensions.Contains(name);
        }
    }
}

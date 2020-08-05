// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Tests._Extensions;
using NUnit.Framework;
using Rhino.Mocks;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    [TestFixture]
    public class Feature_Synchronizing_extensions
    {
        [TestFixture]
        public class When_synchronizing_entity_extensions_where_modifications_have_been_made : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension;
            private ISynchronizable _suppliedTargetEntityExtension;

            private bool _actualIsModified;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension = Stub<ISynchronizable>();

                _suppliedSourceEntityExtension
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(true);

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
            }

            protected override void Act()
            {
                _actualIsModified = _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
            }

            [Assert]
            public void
                Should_obtain_the_target_entity_extension_from_the_list_and_use_it_as_the_synchronization_target_for_the_source_entity_extension()
            {
                _suppliedSourceEntityExtension.AssertWasCalled(
                    x => x.Synchronize(Arg<string>.Is.Equal(_suppliedTargetEntityExtension)),
                    options => options.Repeat.Times(1));
            }

            [Assert]
            public void Should_indicate_modifications_were_made()
            {
                Assert.That(_actualIsModified);
            }
        }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_no_modifications_have_been_made : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension;
            private ISynchronizable _suppliedTargetEntityExtension;

            private bool _actualIsModified;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension = Stub<ISynchronizable>();

                // No modifications have been made
                _suppliedSourceEntityExtension
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(false);

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
            }

            protected override void Act()
            {
                _actualIsModified = _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
            }

            [Assert]
            public void
                Should_obtain_the_target_entity_extension_from_the_list_and_use_it_as_the_synchronization_target_for_the_source_entity_extension()
            {
                _suppliedSourceEntityExtension.AssertWasCalled(
                    x => x.Synchronize(Arg<string>.Is.Equal(_suppliedTargetEntityExtension)),
                    options => options.Repeat.Times(1));
            }

            [Assert]
            public void Should_indicate_no_modifications_were_made()
            {
                Assert.That(_actualIsModified, Is.False);
            }
        }

        [TestFixture]
        public class When_synchronizing_two_entity_extensions_where_only_the_first_extension_has_modifications : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension1;
            private ISynchronizable _suppliedSourceEntityExtension2;
            private ISynchronizable _suppliedTargetEntityExtension1;
            private ISynchronizable _suppliedTargetEntityExtension2;

            private bool _actualIsModified;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();
                _suppliedSourceEntityExtension2 = Stub<ISynchronizable>();

                // First extension has modifications
                _suppliedSourceEntityExtension1
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(true);

                // Second extension has no modifications, but should not overwrite state
                _suppliedSourceEntityExtension2
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(false);

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
            }

            protected override void Act()
            {
                _actualIsModified = _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
            }

            [Assert]
            public void Should_indicate_that_modifications_were_made()
            {
                Assert.That(_actualIsModified, Is.True);
            }
        }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_the_source_entity_is_not_a_synchronization_source_for_some_of_the_extensions
            : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension1;
            private ISynchronizable _suppliedSourceEntityExtension2;
            private ISynchronizable _suppliedTargetEntityExtension1;
            private ISynchronizable _suppliedTargetEntityExtension2;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();
                _suppliedSourceEntityExtension2 = Stub<ISynchronizable>();

                _suppliedSourceEntityExtension1
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(true);

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

                // Extension2 is not supported as a synch source
                _suppliedSourceEntity.SetExtensionSupported("Extension2", false);

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
            }

            protected override void Act()
            {
                _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
            }

            [Assert]
            public void Should_attempt_to_synchronize_extensions_that_are_supported_as_a_synchronization_source()
            {
                _suppliedSourceEntityExtension1.AssertWasCalled(
                    x => x.Synchronize(Arg<string>.Is.Equal(_suppliedTargetEntityExtension1)),
                    options => options.Repeat.Times(1));
            }

            [Assert]
            public void Should_not_attempt_to_synchronize_extensions_that_are_not_supported_as_a_synchronization_source()
            {
                _suppliedSourceEntityExtension2.AssertWasNotCalled(x => x.Synchronize(Arg<string>.Is.Anything));
            }
        }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_the_source_entity_is_a_synchronization_source_for_the_extensions_but_it_is_not_present
            : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceEntity;
            private FakeEntityWithExtensions _suppliedTargetEntity;

            private ISynchronizable _suppliedSourceEntityExtension1;
            private ISynchronizable _suppliedTargetEntityExtension1;

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();

                _suppliedSourceEntityExtension1
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(true);

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
            }

            protected override void Act()
            {
                _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
            }

            [Assert]
            public void Should_throw_an_exception_indicating_that_an_entity_extension_that_was_supported_by_the_source_was_not_present()
            {
                ActualException.MessageShouldContain("the extension was not provided");
            }
        }

        [TestFixture]
        public class When_synchronizing_entity_extensions_where_the_target_entity_does_not_have_the_extension_present : LegacyTestFixtureBase
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

            protected override void Arrange()
            {
                _suppliedSourceEntityExtension1 = Stub<ISynchronizable>();
                _suppliedSourceEntityExtension2 = Stub<ISynchronizable>();

                _suppliedSourceEntityExtension1
                   .Expect(x => x.Synchronize(Arg<object>.Is.Anything))
                   .Return(true);

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
            }

            protected override void Act()
            {
                _suppliedSourceEntity.SynchronizeExtensionsTo(_suppliedTargetEntity);
            }

            [Assert]
            public void Should_attempt_to_synchronize_extensions_that_are_present_on_the_target()
            {
                _suppliedSourceEntityExtension1.AssertWasCalled(
                    x => x.Synchronize(Arg<string>.Is.Equal(_suppliedTargetEntityExtension1)),
                    options => options.Repeat.Times(1));
            }

            [Assert]
            public void Should_not_attempt_to_synchronize_extensions_that_are_not_present_on_the_target()
            {
                _suppliedSourceEntityExtension2.AssertWasNotCalled(x => x.Synchronize(Arg<string>.Is.Anything), options => options.Repeat.Times(1));
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
        public class When_mapping_extensions_between_entities : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceObject;
            private FakeEntityWithExtensions _suppliedTargetObject;

            private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
                new ConcurrentDictionary<string, object>();

            private IMappableExtensionEntity _suppliedSourceExtension1Object;
            private IMappableExtensionEntity _suppliedSourceExtension2Object;

            protected override void Arrange()
            {
                _suppliedSourceExtension1Object = MockRepository.GenerateStub<IMappableExtensionEntity>();
                _suppliedSourceExtension2Object = MockRepository.GenerateStub<IMappableExtensionEntity>();

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
                          var targetExtensionObjectMock = mocks.Stub<IMappableExtensionEntity>();
                          targetExtensionObjectMock.Replay();

                          _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);

                          return targetExtensionObjectMock;
                      };
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject);
            }

            [Assert]
            public void Should_map_each_source_extension_entity_to_a_newly_created_target_extension_entity()
            {
                AssertHelper.All(
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];

                        _suppliedSourceExtension1Object.AssertWasCalled(
                            x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                            options => options.Repeat.Times(1));
                    },
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension2"];

                        _suppliedSourceExtension2Object.AssertWasCalled(
                            x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                            options => options.Repeat.Times(1));
                    });
            }

            [Assert]
            public void Should_set_the_target_extension_entity_back_references_to_the_supplied_target_entity()
            {
                foreach (IMappableExtensionEntity targetExtensionObject in _suppliedTargetExtensionObjectByExtensionName.Values)
                {
                    targetExtensionObject.AssertWasCalled(x => x.SetParent(Arg<object>.Is.Same(_suppliedTargetObject)));
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
        public class When_mapping_extensions_from_an_entity_to_a_resource : LegacyTestFixtureBase
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
                _suppliedSourceExtension1Object = MockRepository.GenerateStub<IMappableExtensionEntity>();
                _suppliedSourceExtension2Object = MockRepository.GenerateStub<IMappableExtensionEntity>();
                _suppliedEmptyImplicitSourceExtensionObject = MockRepository.GenerateStub<IMappableImplicitExtensionEntity>();
                _suppliedNonEmptyImplicitSourceExtensionObject = MockRepository.GenerateStub<IMappableImplicitExtensionEntity>();

                _suppliedEmptyImplicitSourceExtensionObject.Expect(x => x.IsEmpty()).Return(true);
                _suppliedNonEmptyImplicitSourceExtensionObject.Expect(x => x.IsEmpty()).Return(false);

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
                          var targetExtensionObjectMock = mocks.Stub<IMappableResource>();
                          targetExtensionObjectMock.Replay();

                          _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);

                          return targetExtensionObjectMock;
                      };
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject);
            }

            [Assert]
            public void Should_map_each_source_extension_entity_to_a_newly_created_target_extension_resource()
            {
                AssertHelper.All(
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];

                        _suppliedSourceExtension1Object.AssertWasCalled(
                            x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                            options => options.Repeat.Times(1));
                    },
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension2"];

                        _suppliedSourceExtension2Object.AssertWasCalled(
                            x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                            options => options.Repeat.Times(1));
                    });
            }

            [Assert]
            public void Should_map_the_non_empty_source_implicit_extension_entity_to_a_newly_created_target_extension_resource()
            {
                // Get the created target extension object
                var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["NonEmptyImplicitExtension"];

                _suppliedNonEmptyImplicitSourceExtensionObject.AssertWasCalled(
                    x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                    options => options.Repeat.Times(1));
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

        [TestFixture]
        public class When_mapping_extensions_from_a_resource_to_an_entity : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceObject;
            private FakeEntityWithExtensions _suppliedTargetObject;

            private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
                new ConcurrentDictionary<string, object>();

            private IMappableResource _suppliedSourceExtension1Object;
            private IMappableResource _suppliedSourceExtension2Object;
            private IMappableResource _suppliedUnsupportedExtensionObject;

            protected override void Arrange()
            {
                _suppliedSourceExtension1Object = MockRepository.GenerateStub<IMappableResource>();
                _suppliedSourceExtension2Object = MockRepository.GenerateStub<IMappableResource>();
                _suppliedUnsupportedExtensionObject = MockRepository.GenerateStub<IMappableResource>();

                var sourceExtensions = new Dictionary<string, object>
                                       {
                                           {
                                               "Extension1", _suppliedSourceExtension1Object
                                           },
                                           {
                                               "Extension2", _suppliedSourceExtension2Object
                                           },
                                           {
                                               "UnsupportedExtension", _suppliedUnsupportedExtensionObject
                                           }
                                       };

                _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);
                _suppliedSourceObject.SetExtensionSupported("UnsupportedExtension", false);

                var targetExtensions = new Dictionary<string, object>();
                _suppliedTargetObject = new FakeEntityWithExtensions(targetExtensions);

                IHasExtensionsExtensions.CreateTargetExtensionObject
                    = (t, x) =>
                      {
                          var targetExtensionObjectMock = mocks.Stub<IMappableExtensionEntity>();
                          targetExtensionObjectMock.Replay();

                          _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);

                          return targetExtensionObjectMock;
                      };
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject);
            }

            [Assert]
            public void Should_map_each_supported_source_extension_resource_to_a_newly_created_target_extension_entity()
            {
                AssertHelper.All(
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];

                        _suppliedSourceExtension1Object.AssertWasCalled(
                            x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                            options => options.Repeat.Times(1));
                    },
                    () =>
                    {
                        // Get the created target extension object
                        var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension2"];

                        _suppliedSourceExtension2Object.AssertWasCalled(
                            x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                            options => options.Repeat.Times(1));
                    });
            }

            [Assert]
            public void Should_NOT_map_the_unsupported_source_extension_object()
            {
                _suppliedUnsupportedExtensionObject.AssertWasNotCalled(x => x.Map(Arg<object>.Is.Anything));
            }

            [Assert]
            public void Should_NOT_create_a_target_extension_entity_for_the_unsupported_extension()
            {
                // Get the created target extension object
                object expectedTarget;

                Assert.That(
                    _suppliedTargetExtensionObjectByExtensionName.TryGetValue("UnsupportedExtension", out expectedTarget),
                    Is.False);
            }

            [Assert]
            public void Should_indicate_on_the_target_object_that_the_extensions_are_available()
            {
                Assert.That(_suppliedTargetObject.IsExtensionAvailable("Extension1"), Is.True);
                Assert.That(_suppliedTargetObject.IsExtensionAvailable("Extension2"), Is.True);
            }

            [Assert]
            public void Should_indicate_that_the_unsupported_but_present_extension_on_the_resource_is_NOT_available_on_the_target()
            {
                Assert.That(_suppliedTargetObject.IsExtensionAvailable("UnsupportedExtension"), Is.False);
            }

            [Assert]
            public void Should_NOT_indicate_on_the_target_object_that_non_existent_extensions_are_available()
            {
                Assert.That(_suppliedTargetObject.IsExtensionAvailable("NonExistentExtension"), Is.False);
            }

            [Assert]
            public void Should_set_the_target_extension_entity_back_references_to_the_supplied_target_entity()
            {
                foreach (IMappableExtensionEntity targetExtensionObject in _suppliedTargetExtensionObjectByExtensionName.Values)
                {
                    targetExtensionObject.AssertWasCalled(x => x.SetParent(Arg<object>.Is.Same(_suppliedTargetObject)));
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
        public class When_mapping_extensions_from_a_resource_to_an_entity_where_one_extension_is_not_supported_as_a_synchronization_source
            : LegacyTestFixtureBase
        {
            private FakeEntityWithExtensions _suppliedSourceObject;
            private FakeEntityWithExtensions _suppliedTargetObject;

            private readonly IDictionary<string, object> _suppliedTargetExtensionObjectByExtensionName =
                new ConcurrentDictionary<string, object>();

            private IMappableResource _suppliedSourceExtension1Object;
            private IMappableResource _suppliedSourceExtension2Object;

            protected override void Arrange()
            {
                _suppliedSourceExtension1Object = MockRepository.GenerateStub<IMappableResource>();
                _suppliedSourceExtension2Object = MockRepository.GenerateStub<IMappableResource>();

                var sourceExtensions = new Dictionary<string, object>
                                       {
                                           {
                                               "Extension1", _suppliedSourceExtension1Object
                                           },
                                           {
                                               "Extension2", _suppliedSourceExtension2Object
                                           } // Not supported
                                       };

                // Source resource doesn't support Extension2
                _suppliedSourceObject = new FakeEntityWithExtensions(sourceExtensions);
                _suppliedSourceObject.SetExtensionSupported("Extension2", false);

                var targetExtensions = new Dictionary<string, object>();
                _suppliedTargetObject = new FakeEntityWithExtensions(targetExtensions);

                IHasExtensionsExtensions.CreateTargetExtensionObject
                    = (t, x) =>
                      {
                          var targetExtensionObjectMock = mocks.Stub<IMappableExtensionEntity>();
                          targetExtensionObjectMock.Replay();

                          _suppliedTargetExtensionObjectByExtensionName.Add(x, targetExtensionObjectMock);

                          return targetExtensionObjectMock;
                      };
            }

            protected override void Act()
            {
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject);
            }

            [Assert]
            public void Should_map_the_SUPPORTED_source_extension_resource_to_a_newly_created_target_extension_entity()
            {
                // Get the created target extension object
                var expectedTarget = _suppliedTargetExtensionObjectByExtensionName["Extension1"];

                _suppliedSourceExtension1Object.AssertWasCalled(
                    x => x.Map(Arg<object>.Is.Same(expectedTarget)),
                    options => options.Repeat.Times(1));
            }

            [Assert]
            public void Should_not_create_a_new_entity_extension_object_for_the_unsupported_extension()
            {
                // Get the created target extension object
                Assert.That(
                    _suppliedTargetExtensionObjectByExtensionName.ContainsKey("Extension2"),
                    Is.False,
                    "The extension object for unsupported Extension2 was created.");
            }

            [Assert]
            public void Should_not_attempt_to_map_the_unsupported_source_extension_object()
            {
                _suppliedSourceExtension2Object.AssertWasNotCalled(x => x.Map(Arg<object>.Is.Anything));
            }

            [Assert]
            public void Should_only_add_the_supported_extension_to_the_target_entitys_extensions()
            {
                Assert.That(
                    _suppliedTargetObject.Extensions.Contains("Extension1"),
                    Is.True,
                    "Supported Extension1 was not added to the target entity's extensions.");

                Assert.That(
                    _suppliedTargetObject.Extensions.Contains("Extension2"),
                    Is.False,
                    "Unsupported Extension2 was added to the target entity's extensions.");
            }

            [Assert]
            public void Should_propagate_the_lack_of_support_for_the_unsupported_extension_to_the_entity()
            {
                Assert.That(_suppliedTargetObject.IsExtensionSupported("Extension2"), Is.False);
            }

            [Assert]
            public void Should_propagate_the_support_for_the_supported_extension_to_the_entity()
            {
                Assert.That(_suppliedTargetObject.IsExtensionSupported("Extension1"), Is.True);
            }
        }

        [TestFixture]
        public class When_mapping_an_entity_without_extensions_to_a_resource : LegacyTestFixtureBase
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
                _suppliedSourceObject.MapExtensionsTo(_suppliedTargetObject);
            }

            [Assert]
            public void Should_not_initialize_the_extensions_dictionary_on_the_target_resource()
            {
                Assert.That(_suppliedTargetObject.Extensions, Is.Null);
            }
        }
    }

    internal class FakeEntityWithExtensions : ISynchronizable, IHasExtensions, IExtensionsSynchronizationSourceSupport, IMappable
    {
        private readonly IDictionary<string, bool> _supportedByExtensionName
            = new Dictionary<string, bool>();

        private readonly IDictionary<string, bool> _availableByExtensionName
            = new Dictionary<string, bool>();

        public FakeEntityWithExtensions()
        {
            Extensions = new Dictionary<string, object>();
        }

        public FakeEntityWithExtensions(IDictionary extensions)
        {
            Extensions = extensions;
        }

        public bool IsExtensionSupported(string name)
        {
            bool supported;

            // By default, indicate extension is supported.
            if (!_supportedByExtensionName.TryGetValue(name, out supported))
            {
                return true;
            }

            return supported;
        }

        public void SetExtensionSupported(string name, bool isSupported)
        {
            _supportedByExtensionName[name] = isSupported;
        }

        public bool IsExtensionAvailable(string name)
        {
            bool available;

            // By default, indicate extension is NOT available.
            if (!_availableByExtensionName.TryGetValue(name, out available))
            {
                return false;
            }

            return available;
        }

        public void SetExtensionAvailable(string name, bool isAvailable)
        {
            _availableByExtensionName[name] = isAvailable;
        }

        public IDictionary Extensions { get; set; }

        public void Map(object target) { }

        public bool Synchronize(object target)
        {
            return true;
        }
    }
}

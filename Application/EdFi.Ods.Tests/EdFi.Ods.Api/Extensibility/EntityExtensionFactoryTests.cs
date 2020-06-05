// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
// using System.Linq;
// using System.Reflection;
// using EdFi.Ods.Api.Common.Dtos;
// using EdFi.Ods.Api.Common.Infrastructure.Extensibility;
// using EdFi.Ods.Common;
// using EdFi.Ods.Common.Conventions;
// using EdFi.Ods.Common.Models.Definitions;
// using EdFi.Ods.Common.Models.Domain;
// using EdFi.Ods.Tests._Extensions;
// using EdFi.TestFixture;
// using NUnit.Framework;
// using Test.Common;
//
// namespace EdFi.Ods.Tests.EdFi.Ods.Api.Extensibility
// {
//     [TestFixture]
//     [SuppressMessage("ReSharper", "InconsistentNaming")]
//     public class EntityExtensionFactoryTests
//     {
//         private const string TestExtension = "TestExtension";
//         private const string TestExtension1 = "TestExtension1";
//
//         private class FakeClass : EntityWithCompositeKey { }
//
//         private class FakeFakeExtension1 : EntityWithCompositeKey, IChildEntity
//         {
//             public object Parent { get; set; }
//
//             void IChildEntity.SetParent(object value)
//             {
//                 Parent = value;
//             }
//         }
//
//         private class FakeFakeExtension2 : EntityWithCompositeKey, IChildEntity
//         {
//             public object Parent { get; set; }
//
//             void IChildEntity.SetParent(object value)
//             {
//                 Parent = value;
//             }
//         }
//
//         private class FakeClassWithoutCompositeKey { }
//
//         private class TestableEntityExtensionsRegistrar : EntityExtensionRegistrar
//         {
//             public TestableEntityExtensionsRegistrar() :base(new List<Assembly>(), null)
//             {
//             }
//         }
//
//         public class When_a_required_extension_entity_is_registered_with_the_extensions_factory : TestFixtureBase
//         {
//             private readonly object _suppliedParent = new object();
//
//             private IDictionary<string, object> _actualExtensionEntities;
//
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar).RegisterEntityExtensionType(
//                     typeof(FakeClass),
//                     TestExtension,
//                     typeof(FakeFakeExtension1),
//                     isRequired: true);
//
//                 _actualExtensionEntities = extensionFactory.CreateRequiredEntityExtensions<FakeClass>(_suppliedParent);
//             }
//
//             [Test]
//             public void Should_assign_the_supplied_parent_object_as_the_parent_of_the_created_extension_instance()
//             {
//                 var extensionInstance = (FakeFakeExtension1) (_actualExtensionEntities.Values.Single() as IList)[0];
//
//                 Assert.That(extensionInstance.Parent, Is.SameAs(_suppliedParent));
//             }
//
//             [Test]
//             public void Should_create_an_instance_of_the_registered_extension_type_wrapped_in_an_ArrayList()
//             {
//                 var arrayList = _actualExtensionEntities.Values.Single() as IList;
//
//                 AssertHelper.All(
//                     () => Assert.That(arrayList, Is.Not.Null),
//                     () => Assert.That(arrayList, Has.Count.EqualTo(1)),
//                     () => Assert.That(arrayList[0], Is.TypeOf<FakeFakeExtension1>())
//                 );
//             }
//
//             [Test]
//             public void Should_create_entity_extensions_dictionary_containing_a_single_entry()
//             {
//                 Assert.That(_actualExtensionEntities, Has.Count.EqualTo(1));
//             }
//
//             [Test]
//             public void Should_use_the_supplied_extension_name_as_the_key_for_the_entry()
//             {
//                 Assert.That(
//                     _actualExtensionEntities.Single()
//                                             .Key,
//                     Is.EqualTo(TestExtension));
//             }
//         }
//
//         public class When_an_optional_extension_entity_is_registered_with_the_extensions_factory : TestFixtureBase
//         {
//             private readonly object _suppliedParent = new object();
//
//             private IDictionary<string, object> _actualExtensionEntities;
//
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar).RegisterEntityExtensionType(
//                     typeof(FakeClass),
//                     TestExtension,
//                     typeof(FakeFakeExtension1),
//                     isRequired: false);
//
//                 _actualExtensionEntities = extensionFactory.CreateRequiredEntityExtensions<FakeClass>(_suppliedParent);
//             }
//
//             [Test]
//             public void Should_create_entity_extensions_dictionary()
//             {
//                 Assert.That(_actualExtensionEntities, Is.Not.Null);
//             }
//
//             [Test]
//             public void Should_NOT_create_an_instance_of_the_registered_extension_type()
//             {
//                 Assert.That(_actualExtensionEntities.ContainsKey(TestExtension), Is.False, "Optional extension instance found in initialized extensions dictionary.");
//             }
//         }
//
//         public class When_two_extensions_for_the_same_entity_type_are_registered_with_the_factory : TestFixtureBase
//         {
//             private readonly object _suppliedParent = new object();
//
//             private IDictionary<string, object> _actualExtensionEntities;
//
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar).RegisterEntityExtensionType(
//                     typeof(FakeClass),
//                     TestExtension,
//                     typeof(FakeFakeExtension1),
//                     isRequired: true);
//
//                 (extensionFactory as IEntityExtensionRegistrar).RegisterEntityExtensionType(
//                     typeof(FakeClass),
//                     TestExtension1,
//                     typeof(FakeFakeExtension2),
//                     isRequired: true);
//
//                 _actualExtensionEntities = extensionFactory.CreateRequiredEntityExtensions<FakeClass>(_suppliedParent);
//             }
//
//             [Assert]
//             public void Should_assign_the_supplied_parent_to_all_extensions_created()
//             {
//                 var assignedParents = _actualExtensionEntities.Values
//                                                               .OfType<IList>()
//                                                               .Select(
//                                                                    x =>
//                                                                    {
//                                                                        dynamic item = x[0];
//                                                                        return (object) item.Parent;
//                                                                    })
//                                                               .ToList();
//
//                 foreach (var assignedParent in assignedParents)
//                 {
//                     Assert.That(assignedParent, Is.SameAs(_suppliedParent));
//                 }
//             }
//
//             [Test]
//             public void Should_contain_an_entry_for_each_of_the_supplied_extension_names()
//             {
//                 Assert.That(
//                     _actualExtensionEntities.Keys,
//                     Is.EquivalentTo(
//                         new[]
//                         {
//                             TestExtension, TestExtension1
//                         }));
//             }
//
//             [Test]
//             public void Should_create_entity_extensions_dictionary_containing_two_entries()
//             {
//                 Assert.That(_actualExtensionEntities, Has.Count.EqualTo(2));
//             }
//
//             [Test]
//             public void Should_create_instance_of_the_first_registered_extension_type_keyed_by_the_extension_name_and_wrapped_in_an_ArrayList()
//             {
//                 var arrayList = _actualExtensionEntities[TestExtension] as IList;
//
//                 AssertHelper.All(
//                     () => Assert.That(arrayList, Is.Not.Null),
//                     () => Assert.That(arrayList, Has.Count.EqualTo(1)),
//                     () => Assert.That(arrayList[0], Is.TypeOf<FakeFakeExtension1>())
//                 );
//             }
//
//             [Test]
//             public void Should_create_instance_of_the_second_registered_extension_type_keyed_by_the_extension_name_and_wrapped_in_an_ArrayList()
//             {
//                 var arrayList = _actualExtensionEntities[TestExtension1] as IList;
//
//                 AssertHelper.All(
//                     () => Assert.That(arrayList, Is.Not.Null),
//                     () => Assert.That(arrayList, Has.Count.EqualTo(1)),
//                     () => Assert.That(arrayList[0], Is.TypeOf<FakeFakeExtension2>())
//                 );
//             }
//         }
//
//         public class When_registering_two_extensions_for_the_same_entity_type_with_the_same_extension_name : TestFixtureBase
//         {
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar).RegisterEntityExtensionType(
//                     typeof(FakeClass),
//                     TestExtension,
//                     typeof(FakeFakeExtension1),
//                     isRequired: true);
//
//                 (extensionFactory as IEntityExtensionRegistrar).RegisterEntityExtensionType(
//                     typeof(FakeClass),
//                     TestExtension,
//                     typeof(FakeFakeExtension2),
//                     isRequired: true);
//             }
//
//             [Test]
//             public void Should_throw_an_exception_that_the_extension_entry_is_already_registered()
//             {
//                 ActualException.MessageShouldContain("already registered");
//             }
//         }
//
//         public class When_registering_an_extension_entity_type_with_a_null_extension_name : TestFixtureBase
//         {
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterEntityExtensionType(typeof(FakeClass), null, typeof(FakeFakeExtension1), isRequired: true);
//             }
//
//             [Test]
//             public void Should_throw_argument_exception_for_null_extension_name()
//             {
//                 ActualException.ShouldBeExceptionType<ArgumentNullException>();
//             }
//         }
//
//         public class When_registering_an_extension_entity_type_with_a_empty_extension_name : TestFixtureBase
//         {
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterEntityExtensionType(typeof(FakeClass), string.Empty, typeof(FakeFakeExtension1), isRequired: true);
//             }
//
//             [Test]
//             public void Should_throw_argument_exception_for_empty_extension_name()
//             {
//                 ActualException.ShouldBeExceptionType<ArgumentNullException>();
//             }
//         }
//
//         public class When_registering_an_extension_entity_type_with_a_whitespace_extension_name : TestFixtureBase
//         {
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterEntityExtensionType(typeof(FakeClass), " ", typeof(FakeFakeExtension1), isRequired: true);
//             }
//
//             [Test]
//             public void Should_throw_argument_exception_for_empty_extension_name()
//             {
//                 AssertHelper.All(
//                     () => Assert.That(ActualException, Is.Not.Null),
//                     () => Assert.IsInstanceOf<ArgumentException>(ActualException));
//             }
//         }
//
//         public class When_registering_an_extension_entity_that_is_the_same_type_as_the_entity : TestFixtureBase
//         {
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterEntityExtensionType(typeof(FakeClass), TestExtension, typeof(FakeClass), isRequired: true);
//             }
//
//             [Assert]
//             public virtual void ArgumentException_should_be_thrown_when_Register_Extension_Type_Is_Called()
//             {
//                 AssertHelper.All(
//                     () => Assert.IsInstanceOf<ArgumentException>(ActualException),
//                     () => Assert.That(
//                         ActualException.Message,
//                         Is.EqualTo($"Ed-Fi type '{typeof(FakeClass).Name}' is the same as the provided extension type '{typeof(FakeClass).Name}'.")));
//             }
//         }
//
//         public class When_registering_an_extension_for_an_entity_that_is_not_a_subclass_of_EntityWithCompositeKey : TestFixtureBase
//         {
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterEntityExtensionType(
//                         typeof(FakeClassWithoutCompositeKey),
//                         TestExtension,
//                         typeof(FakeFakeExtension1),
//                         isRequired: true);
//             }
//
//             [Assert]
//             public virtual void ArgumentException_should_be_thrown_when_Register_Extension_Type_Is_Called()
//             {
//                 AssertHelper.All(
//                     () => ActualException.ShouldBeExceptionType<ArgumentException>(),
//                     () => ActualException.MessageShouldContain("is not an entity Type"));
//             }
//         }
//
//         public class When_registering_an_aggregate_extension_for_an_standard_entity_type_that_is_not_a_subclass_of_EntityWithCompositeKey
//             : TestFixtureBase
//         {
//             private Entity _entity;
//
//             protected override void Arrange()
//             {
//                 DomainModelBuilder builder = new DomainModelBuilder();
//
//                 builder.AddSchema(new SchemaDefinition("schema", "schema"));
//
//                 builder.AddAggregate(
//                     new AggregateDefinition(
//                         new FullName("schema", "Entity1"),
//                         new FullName[]
//                         { }));
//
//                 builder.AddEntity(
//                     new EntityDefinition(
//                         "schema",
//                         "Entity1",
//                         new EntityPropertyDefinition[]
//                         { },
//                         new EntityIdentifierDefinition[]
//                         { }));
//
//                 var domainModel = builder.Build();
//
//                 _entity = domainModel.Entities.First();
//             }
//
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterAggregateExtensionEntity(
//                         typeof(FakeClassWithoutCompositeKey),
//                         _entity);
//             }
//
//             [Assert]
//             public virtual void Should_throw_argument_exception_when_RegisterAggregateExtensionEntity_is_called()
//             {
//                 AssertHelper.All(
//                     () => ActualException.ShouldBeExceptionType<ArgumentException>(),
//                     () => ActualException.MessageShouldContain("edFiStandardEntityType is not an entity Type."));
//             }
//         }
//
//         public class When_registering_an_aggregate_extension_and_the_aggregateExtensionEntity_parameter_provided_is_not_an_aggregate_extension_entity
//             : TestFixtureBase
//         {
//             private Entity _nonAggregateExtensionEntity;
//
//             protected override void Arrange()
//             {
//                 DomainModelBuilder builder = new DomainModelBuilder();
//
//                 builder.AddSchema(new SchemaDefinition("schema", "schema"));
//
//                 builder.AddAggregate(
//                     new AggregateDefinition(
//                         new FullName("schema", "Entity1"),
//                         new FullName[]
//                         { }));
//
//                 builder.AddEntity(
//                     new EntityDefinition(
//                         "schema",
//                         "Entity1",
//                         new EntityPropertyDefinition[]
//                         { },
//                         new EntityIdentifierDefinition[]
//                         { }));
//
//                 var domainModel = builder.Build();
//
//                 _nonAggregateExtensionEntity = domainModel.Entities.First();
//             }
//
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterAggregateExtensionEntity(typeof(FakeClass), _nonAggregateExtensionEntity);
//             }
//
//             [Assert]
//             public virtual void Should_throw_exception_when_RegisterAggregateExtensionEntity_is_called()
//             {
//                 AssertHelper.All(
//                     () => Assert.IsInstanceOf<Exception>(ActualException),
//                     () => Assert.That(ActualException.Message, Is.EqualTo("aggregateExtensionEntity is not an aggregate extension entity.")));
//             }
//         }
//
//         public class When_registering_a_valid_aggregate_extension_to_a_valid_standard_edfi_entity : TestFixtureBase
//         {
//             private Entity _aggregateExtensionEntity;
//             private Dictionary<string, object> _aggregateExtensionInstances;
//
//             protected override void Arrange()
//             {
//                 DomainModelBuilder builder = new DomainModelBuilder();
//
//                 var edfiSchemaDefinition = new SchemaDefinition(
//                     EdFiConventions.LogicalName,
//                     EdFiConventions.PhysicalSchemaName);
//
//                 var extensionSchemaDefinition = new SchemaDefinition(
//                     "ExtensionLogicalName",
//                     "ExtensionPhysicalSchemaName");
//
//                 builder.AddSchema(edfiSchemaDefinition);
//                 builder.AddSchema(extensionSchemaDefinition);
//
//                 builder.AddAggregate(
//                     new AggregateDefinition(
//                         new FullName(edfiSchemaDefinition.PhysicalName, "EdFiEntity"),
//                         new[]
//                         {
//                             new FullName(extensionSchemaDefinition.PhysicalName, "AggregateExtensionEntity")
//                         }));
//
//                 builder.AddEntity(
//                     new EntityDefinition(
//                         edfiSchemaDefinition.PhysicalName,
//                         "EdFiEntity",
//                         new[]
//                         {
//                             new EntityPropertyDefinition(
//                                 "USI",
//                                 new PropertyType(DbType.Int32, 0, 10, 0, false),
//                                 "EdFiEntity Identity Column",
//                                 true,
//                                 true)
//                         },
//                         new EntityIdentifierDefinition[]
//                         { }));
//
//                 builder.AddEntity(
//                     new EntityDefinition(
//                         extensionSchemaDefinition.PhysicalName,
//                         "AggregateExtensionEntity",
//                         new EntityPropertyDefinition[]
//                         { },
//                         new EntityIdentifierDefinition[]
//                         { }));
//
//                 var associationDefinition =
//                     new AssociationDefinition(
//                         new FullName(extensionSchemaDefinition.PhysicalName, "FK_AggregateExtensionEntity_EdFiEntity_USI"),
//                         Cardinality.OneToZeroOrMore,
//                         new FullName(edfiSchemaDefinition.PhysicalName, "EdFiEntity"),
//                         new[]
//                         {
//                             new EntityPropertyDefinition(
//                                 "USI",
//                                 new PropertyType(DbType.Int32, 0, 10, 0, false),
//                                 "EdFiEntity Identity Column",
//                                 true,
//                                 true)
//                         },
//                         new FullName(extensionSchemaDefinition.PhysicalName, "AggregateExtensionEntity"),
//                         new[]
//                         {
//                             new EntityPropertyDefinition(
//                                 "USI",
//                                 new PropertyType(DbType.Int32, 0, 10, 0, false),
//                                 "",
//                                 true,
//                                 false)
//                         },
//                         true,
//                         true);
//
//                 builder.AddAssociation(associationDefinition);
//
//                 var domainModel = builder.Build();
//
//                 _aggregateExtensionEntity =
//                     domainModel.Entities.FirstOrDefault(e => e.Name == "AggregateExtensionEntity");
//             }
//
//             /// <summary>
//             /// Executes the code to be tested.
//             /// </summary>
//             protected override void Act()
//             {
//                 var extensionFactory = new TestableEntityExtensionsRegistrar();
//
//                 (extensionFactory as IEntityExtensionRegistrar)
//                    .RegisterAggregateExtensionEntity(typeof(FakeClass), _aggregateExtensionEntity);
//
//                 _aggregateExtensionInstances =
//                     (Dictionary<string, object>) (extensionFactory as IEntityExtensionsFactory)
//                    .CreateAggregateExtensions<FakeClass>();
//             }
//
//             [Assert]
//             public virtual void Should_return_correctly_constructed_aggregate_extension_dictionary_when_CreateAggregateExtensions_is_called()
//             {
//                 var expectedAggregateExtensionMemberName =
//                     ExtensionsConventions.GetAggregateExtensionMemberName(_aggregateExtensionEntity);
//
//                 AssertHelper.All(
//                     () =>
//                         Assert.That(
//                             _aggregateExtensionInstances.Keys.First(),
//                             Is.EqualTo(expectedAggregateExtensionMemberName),
//                             $"Aggregate extension dictionary key does not match expected value: {expectedAggregateExtensionMemberName}"),
//                     () =>
//                         Assert.That(
//                             (IList) _aggregateExtensionInstances[expectedAggregateExtensionMemberName],
//                             Is.EquivalentTo(new List<object>()),
//                             "Aggregate extension dictionary does not contain empty List<object>."));
//             }
//         }
//     }
// }

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class When_constructing_an_entity_with_a_single_PK_property_and_a_single_AK_property
        : TestFixtureBase
    {
        private Entity _entity;

        protected override void Act()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddAggregate(new AggregateDefinition(new FullName("schema", "Student"), new FullName[0]));

            // Execute code under test
            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "Student",
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("FirstName", new PropertyType(DbType.String, 50), string.Empty, false),
                        new EntityPropertyDefinition("StudentUniqueId", new PropertyType(DbType.String, 50), string.Empty, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_Student",
                            new[]
                            {
                                "StudentUSI"
                            },
                            true),
                        new EntityIdentifierDefinition(
                            "AK_Student_StudentUniqueId",
                            new[]
                            {
                                "StudentUniqueId"
                            },
                            false)
                    }));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

            var domainModel = domainModelBuilder.Build();

            _entity = domainModel.EntityByFullName[new FullName("schema", "Student")];
        }

        [Assert]
        public void Should_create_the_primary_identifier_with_the_PK_properties()
        {
            Assert.That(_entity.Identifier, Is.Not.Null);

            Assert.That(
                _entity.Identifier.Properties.Select(p => p.PropertyName),
                Is.EqualTo(
                    new[]
                    {
                        "StudentUSI"
                    }));
        }

        [Assert]
        public void Should_create_the_alternate_identifier_with_the_AK_properties()
        {
            Assert.That(_entity.AlternateIdentifiers, Has.Count.EqualTo(1));

            Assert.That(
                _entity.AlternateIdentifiers[0]
                       .Properties.Select(p => p.PropertyName),
                Is.EqualTo(
                    new[]
                    {
                        "StudentUniqueId"
                    }));
        }
    }

    public class When_constructing_an_entity_with_multiple_PK_properties_and_multiple_AKs_with_multiple_properties
        : TestFixtureBase
    {
        private Entity _entity;

        protected override void Act()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "AParent"),
                    new[]
                    {
                        new FullName("schema", "AnEntity")
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "AParent",
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_AnEntity",
                            new[]
                            {
                                "Primary1"
                            },
                            true)
                    }));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "schema"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "AParent"),
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    new FullName("schema", "AnEntity"),
                    new[]
                    {
                        new EntityPropertyDefinition("Primary1", new PropertyType(DbType.Int32), string.Empty, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "AnEntity",
                    new[]
                    {
                        // Columns are defined deliberately out of order
                        new EntityPropertyDefinition("Primary2", new PropertyType(DbType.Int32), string.Empty, true),
                        new EntityPropertyDefinition("Alternate2b", new PropertyType(DbType.String, 50), string.Empty, false),
                        new EntityPropertyDefinition("Alternate1b", new PropertyType(DbType.String, 50), string.Empty, false),
                        new EntityPropertyDefinition("Alternate1a", new PropertyType(DbType.String, 50), string.Empty, false),
                        new EntityPropertyDefinition("Alternate2a", new PropertyType(DbType.String, 50), string.Empty, false),
                        new EntityPropertyDefinition("Other", new PropertyType(DbType.String, 50), string.Empty, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_AnEntity",
                            new[]
                            {
                                "Primary1", "Primary2"
                            },
                            true),
                        new EntityIdentifierDefinition(
                            "AK_AnEntity_1",
                            new[]
                            {
                                "Alternate1a", "Alternate1b"
                            },
                            false),
                        new EntityIdentifierDefinition(
                            "AK_AnEntity_2",
                            new[]
                            {
                                "Alternate2a", "Alternate2b"
                            },
                            false)
                    }));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema", "schema"));

            var domainModel = domainModelBuilder.Build();

            _entity = domainModel.EntityByFullName[new FullName("schema", "AnEntity")];
        }

        [Assert]
        public void Should_create_the_primary_identifier_with_the_PK_properties_in_order()
        {
            Assert.That(_entity.Identifier, Is.Not.Null);

            Assert.That(
                _entity.Identifier.Properties.Select(p => p.PropertyName),
                Is.EqualTo(
                    new[]
                    {
                        "Primary1", "Primary2"
                    }));
        }

        [Assert]
        public void Should_create_the_alternate_identifiers_with_the_AK_properties_in_order()
        {
            Assert.That(_entity.AlternateIdentifiers, Has.Count.EqualTo(2));

            Assert.That(
                _entity.AlternateIdentifiers[0]
                       .Properties.Select(p => p.PropertyName),
                Is.EqualTo(
                    new[]
                    {
                        "Alternate1a", "Alternate1b"
                    }));

            Assert.That(
                _entity.AlternateIdentifiers[1]
                       .Properties.Select(p => p.PropertyName),
                Is.EqualTo(
                    new[]
                    {
                        "Alternate2a", "Alternate2b"
                    }));
        }
    }

    [TestFixture]
    public class When_a_domain_model_has_a_three_level_inheritance_hierarchy : TestFixtureBase
    {
        private DomainModel _domainModel;
        private ResourceModel _resourceModel;

        protected override void Act()
        {
            var builder = new DomainModelBuilder();

            builder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "EdOrg"),
                    new[]
                    {
                        new FullName("schema", "EdOrgAddress")
                    }));

            builder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema", "School"),
                    new[]
                    {
                        new FullName("schema", "SchoolCategory")
                    }));

            builder.AddAggregate(new AggregateDefinition(new FullName("schema", "SpecializedSchool"), new FullName[0]));

            // Top-level
            builder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "EdOrg",
                    new[]
                    {
                        new EntityPropertyDefinition("EdOrgId", new PropertyType(DbType.Int32), null, isIdentifying: true),
                        new EntityPropertyDefinition("NameOfInstitution", new PropertyType(DbType.String, 30), null)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_EdOrg",
                            new[]
                            {
                                "EdOrgId"
                            },
                            isPrimary: true)
                    },
                    isAbstract: true));

            builder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "EdOrgAddress",
                    new[]
                    {
                        new EntityPropertyDefinition("AddressTypeId", new PropertyType(DbType.Int32), null, isIdentifying: true),
                        new EntityPropertyDefinition("City", new PropertyType(DbType.String, 30), null)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_EdOrgAddress",
                            new[]
                            {
                                "EdOrgId", "AddressTypeId"
                            },
                            isPrimary: true)
                    }));

            builder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "FK_EdOrgAddress_EdOrg"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "EdOrg"),
                    new[]
                    {
                        new EntityPropertyDefinition("EdOrgId", new PropertyType(DbType.Int32), null, isIdentifying: true)
                    },
                    new FullName("schema", "EdOrgAddress"),
                    new[]
                    {
                        new EntityPropertyDefinition("EdOrgId", new PropertyType(DbType.Int32), null)
                    },
                    isIdentifying: true,
                    isRequired: true));

            // Middle-level
            builder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "School",
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolThing", new PropertyType(DbType.String, 30), null)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_School",
                            new[]
                            {
                                "SchoolId"
                            },
                            isPrimary: true)
                    },
                    isAbstract: true));

            builder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "SchoolCategory",
                    new[]
                    {
                        new EntityPropertyDefinition("CategoryTypeId", new PropertyType(DbType.Int32), null, isIdentifying: true),
                        new EntityPropertyDefinition("CategoryName", new PropertyType(DbType.String, 30), null)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_SchoolCategory",
                            new[]
                            {
                                "SchoolId", "CategoryTypeId"
                            },
                            isPrimary: true)
                    }));

            builder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "FK_SchoolCategory_School"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, isIdentifying: true)
                    },
                    new FullName("schema", "SchoolCategory"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null)
                    },
                    isIdentifying: true,
                    isRequired: true));

            builder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "FK_School_EdOrg"),
                    Cardinality.OneToOneInheritance,
                    new FullName("schema", "EdOrg"),
                    new[]
                    {
                        new EntityPropertyDefinition("EdOrgId", new PropertyType(DbType.Int32), null, isIdentifying: true)
                    },
                    new FullName("schema", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null)
                    },
                    isIdentifying: true,
                    isRequired: true));

            // Lower level
            builder.AddEntity(
                new EntityDefinition(
                    "schema",
                    "SpecializedSchool",
                    new[]
                    {
                        new EntityPropertyDefinition("SpecializedSchoolThing", new PropertyType(DbType.String, 30), null)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_School",
                            new[]
                            {
                                "SpecializedSchoolId"
                            },
                            isPrimary: true)
                    },
                    isAbstract: true));

            builder.AddAssociation(
                new AssociationDefinition(
                    new FullName("schema", "FK_SpecializedSchool_School"),
                    Cardinality.OneToOneInheritance,
                    new FullName("schema", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, isIdentifying: true)
                    },
                    new FullName("schema", "SpecializedSchool"),
                    new[]
                    {
                        new EntityPropertyDefinition("SpecializedSchoolId", new PropertyType(DbType.Int32), null)
                    },
                    isIdentifying: true,
                    isRequired: true));

            builder.AddSchema(new SchemaDefinition("schema", "schema"));

            _domainModel = builder.Build();

            _resourceModel = new ResourceModel(_domainModel);
        }

        [Assert]
        public void Should_indicate_none_of_the_base_entitys_properties_are_inherited()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];

            Assert.That(edOrg.InheritedProperties, Has.Length.EqualTo(0));
        }

        [Assert]
        public void Should_indicate_none_of_the_base_entitys_collections_are_inherited()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];

            Assert.That(edOrg.InheritedOutgoingAssociations, Has.Length.EqualTo(0));
        }

        [Assert]
        public void Should_indicate_that_the_middle_type_inherits_outgoing_associations_from_the_base_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];

            Assert.That(school.InheritedOutgoingAssociations.Count, Is.GreaterThan(0));

            Assert.That(
                school.InheritedOutgoingAssociations.Select(x => x.Name),
                Is.EquivalentTo(edOrg.OutgoingAssociations.Select(x => x.Name)));
        }

        [Assert]
        public void Should_indicate_that_the_descendant_type_inherits_outgoing_associations_from_both_the_base_type_and_the_middle_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];
            var specializedSchool = _domainModel.EntityByFullName[new FullName("schema", "SpecializedSchool")];

            Assert.That(specializedSchool.InheritedOutgoingAssociations.Count, Is.GreaterThan(0));

            Assert.That(
                specializedSchool.InheritedOutgoingAssociations.Select(x => x.Name),
                Is.EquivalentTo(
                    edOrg.OutgoingAssociations.Select(x => x.Name)
                         .Concat(school.OutgoingAssociations.Select(x => x.Name))));
        }

        [Test]
        public virtual void Should_indicate_that_the_descendant_type_does_not_inherit_concrete_type_named_identifier_properties_from_the_middle_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];
            var specializedSchool = _domainModel.EntityByFullName[new FullName("schema", "SpecializedSchool")];

            Assert.That(
                specializedSchool.InheritedProperties
                                 .Where(x => x.IsIdentifying)
                                 .Select(x => x.PropertyName),
                Is.EquivalentTo(specializedSchool.Identifier.Properties.Select(x => x.PropertyName)));
        }

        [Test]
        public virtual void Should_indicate_that_the_descendant_type_inherits_non_identifying_properties_from_both_the_middle_type_and_the_base_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];
            var specializedSchool = _domainModel.EntityByFullName[new FullName("schema", "SpecializedSchool")];

            Assert.That(specializedSchool.InheritedNonIdentifyingProperties.Count, Is.GreaterThan(0));

            Assert.That(
                specializedSchool.InheritedNonIdentifyingProperties.Select(x => x.PropertyName),
                Is.EquivalentTo(
                    edOrg.NonIdentifyingProperties
                         .Concat(school.NonIdentifyingProperties)
                         .Select(x => x.PropertyName)));
        }

        [Test]
        public virtual void Should_indicate_that_the_descendant_type_inherits_properties_from_both_the_middle_type_and_the_base_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];
            var specializedSchool = _domainModel.EntityByFullName[new FullName("schema", "SpecializedSchool")];

            Assert.That(specializedSchool.InheritedProperties.Count, Is.GreaterThan(0));

            Assert.That(
                specializedSchool.InheritedProperties.Select(x => x.PropertyName),
                Is.EquivalentTo(
                    edOrg.NonIdentifyingProperties
                         .Concat(school.NonIdentifyingProperties)
                         .Concat(specializedSchool.BaseAssociation.ThisProperties)
                         .Select(x => x.PropertyName)));
        }

        [Test]
        public virtual void Should_indicate_that_the_inherited_properties_of_the_resource_based_on_the_descendant_type_are_all_inherited()
        {
            var specializedSchoolResource = _resourceModel.GetResourceByFullName(new FullName("schema", "SpecializedSchool"));

            var inheritedProperties = specializedSchoolResource.InheritedProperties();

            Assert.That(inheritedProperties.All(p => p.IsInherited), Is.True);
        }

        [Test]
        public virtual void Should_indicate_that_the_local_properties_of_the_resource_based_on_the_descendant_type_are_not_inherited()
        {
            var specializedSchoolResource = _resourceModel.GetResourceByFullName(new FullName("schema", "SpecializedSchool"));

            var localProperties = specializedSchoolResource.Properties.Where(p => p.EntityProperty.IsLocallyDefined);

            Assert.That(localProperties.All(p => p.IsInherited), Is.False);
        }

        [Test]
        public virtual void Should_indicate_that_the_middle_type_does_not_inherit_concrete_type_named_identifier_properties_from_the_base_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];

            Assert.That(
                school.InheritedProperties
                      .Where(x => x.IsIdentifying)
                      .Select(x => x.PropertyName),
                Is.EquivalentTo(school.Identifier.Properties.Select(x => x.PropertyName)));
        }

        [Test]
        public virtual void Should_indicate_that_the_middle_type_inherits_properties_from_the_base_type()
        {
            var edOrg = _domainModel.EntityByFullName[new FullName("schema", "EdOrg")];
            var school = _domainModel.EntityByFullName[new FullName("schema", "School")];

            Assert.That(school.InheritedProperties.Count, Is.GreaterThan(0));

            Assert.That(
                school.InheritedProperties.Select(x => x.PropertyName),
                Is.EquivalentTo(
                    edOrg.NonIdentifyingProperties
                         .Concat(school.BaseAssociation.ThisProperties)
                         .Select(x => x.PropertyName)));
        }
    }

    public class When_a_domain_model_has_aggregate_extensions : TestFixtureBase
    {
        private DomainModel _domainModel;
        private ResourceModel _resourceModel;

        protected override void Act()
        {
            var builder = new DomainModelBuilder();

            builder.AddAggregate(
                new AggregateDefinition(
                    new FullName("edfi", "Student"),
                    new[]
                    {
                        new FullName("edfi", "Student")
                    }));

            // Top-level
            builder.AddEntity(
                new EntityDefinition(
                    "edfi",
                    "Student",
                    new[]
                    {
                        new EntityPropertyDefinition(
                            "StudentUSI",
                            new PropertyType(DbType.Int32, 0, 10, 0, false),
                            "A unique number or alphanumeric code assigned to a student by a state education agency.",
                            true,
                            true),
                        new EntityPropertyDefinition(
                            "FirstName",
                            new PropertyType(DbType.String, 75, 0, 0, false),
                            "A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.",
                            false,
                            false),
                        new EntityPropertyDefinition(
                            "MiddleName",
                            new PropertyType(DbType.String, 75, 0, 0, true),
                            "A secondary name given to an individual at birth, baptism, or during another naming ceremony.",
                            false,
                            false),
                        new EntityPropertyDefinition(
                            "LastSurname",
                            new PropertyType(DbType.String, 75, 0, 0, false),
                            "The name borne in common by members of a family.",
                            false,
                            false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_Student",
                            new[]
                            {
                                "StudentUSI"
                            },
                            true,
                            false)
                    },
                    isAbstract: true));

            builder.AddEntity(
                new EntityDefinition(
                    "sample",
                    "StudentPet",
                    new[]
                    {
                        new EntityPropertyDefinition("PetName", new PropertyType(DbType.String, 20, 0, 0, false), "", true, false),
                        new EntityPropertyDefinition("IsFixed", new PropertyType(DbType.Boolean, 0, 0, 0, true), "", false, false),
                        new EntityPropertyDefinition("CreateDate", new PropertyType(DbType.DateTime, 0, 0, 0, false), "", false, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentPet",
                            new[]
                            {
                                "StudentUSI", "PetName"
                            },
                            true,
                            false)
                    },
                    false,
                    "")
            );

            builder.AddEntity(
                new EntityDefinition(
                    "sample",
                    "StudentPetPreference",
                    new[]
                    {
                        new EntityPropertyDefinition("MinimumWeight", new PropertyType(DbType.Int32, 0, 10, 0, false), "", false, false),
                        new EntityPropertyDefinition("MaximumWeight", new PropertyType(DbType.Int32, 0, 10, 0, false), "", false, false),
                        new EntityPropertyDefinition("CreateDate", new PropertyType(DbType.DateTime, 0, 0, 0, false), "", false, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentPetPreference",
                            new[]
                            {
                                "StudentUSI"
                            },
                            true,
                            false)
                    },
                    false,
                    "")
            );

            builder.AddAssociation(
                new AssociationDefinition(
                    new FullName("sample", "FK_StudentPet_Student_StudentUSI"),
                    Cardinality.OneToZeroOrMore,
                    new FullName("edfi", "Student"),
                    new[]
                    {
                        new EntityPropertyDefinition(
                            "StudentUSI",
                            new PropertyType(DbType.Int32, 0, 10, 0, false),
                            "A unique number or alphanumeric code assigned to a student by a state education agency.",
                            true,
                            true)
                    },
                    new FullName("sample", "StudentPet"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32, 0, 10, 0, false), "", true, false)
                    },
                    true,
                    true)
            );

            builder.AddAssociation(
                new AssociationDefinition(
                    new FullName("sample", "FK_StudentPetPreference_Student_StudentUSI"),
                    Cardinality.OneToOne,
                    new FullName("edfi", "Student"),
                    new[]
                    {
                        new EntityPropertyDefinition(
                            "StudentUSI",
                            new PropertyType(DbType.Int32, 0, 10, 0, false),
                            "A unique number or alphanumeric code assigned to a student by a state education agency.",
                            true,
                            true)
                    },
                    new FullName("sample", "StudentPetPreference"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32, 0, 10, 0, false), "", true, true)
                    },
                    true,
                    true)
            );

            builder.AddAggregateExtension(
                new AggregateExtensionDefinition(
                    new FullName("edfi", "Student"),
                    new[]
                    {
                        new FullName("sample", "StudentPet"), new FullName("sample", "StudentPetPreference")
                    })
            );

            builder.AddSchema(new SchemaDefinition("Ed-Fi", "edfi"));
            builder.AddSchema(new SchemaDefinition("Sample", "sample"));

            _domainModel = builder.Build();

            _resourceModel = new ResourceModel(_domainModel);
        }

        [Assert]
        public void Should_have_aggregate_member_for_implicit_extension_collection()
        {
            var studentPetExists = _domainModel
                                  .EntityByFullName[new FullName("edfi", "Student")]
                                  .Aggregate
                                  .Members
                                  .Any(m => m.FullName == new FullName("sample", "StudentPet"));

            Assert.That(studentPetExists, Is.True);
        }

        [Assert]
        public void Should_have_cardinality_of_OneToZeroOrMore_for_implicit_extension_collection()
        {
            var cardinality = _domainModel
                             .EntityByFullName[new FullName("edfi", "Student")]
                             .Aggregate
                             .Members.Single(m => m.FullName == new FullName("sample", "StudentPet"))
                             .ParentAssociation.Association.Cardinality;

            Assert.That(cardinality, Is.EqualTo(Cardinality.OneToZeroOrMore));
        }

        [Assert]
        public void Should_have_aggregate_member_for_implicit_extension_embedded_object()
        {
            var studentPetPreferenceExists = _domainModel
                                            .EntityByFullName[new FullName("edfi", "Student")]
                                            .Aggregate
                                            .Members.Any(m => m.FullName == new FullName("sample", "StudentPetPreference"));

            Assert.That(studentPetPreferenceExists, Is.True);
        }

        [Assert]
        public void Should_have_cardinality_of_OneToZeroOrMore_for_implicit_extension_embedded_object()
        {
            var cardinality = _domainModel
                             .EntityByFullName[new FullName("edfi", "Student")]
                             .Aggregate
                             .Members.Single(m => m.FullName == new FullName("sample", "StudentPetPreference"))
                             .ParentAssociation.Association.Cardinality;

            Assert.That(cardinality, Is.EqualTo(Cardinality.OneToOne));
        }
    }
}

// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Collections.Generic;
using System.Data;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Features.OpenApiMetadata.Dtos;
using EdFi.Ods.Standard;
using PT = EdFi.Ods.Common.Models.Domain.PropertyType;
using EId = EdFi.Ods.Common.Models.Definitions.EntityIdentifierDefinition;
using EP = EdFi.Ods.Common.Models.Definitions.EntityPropertyDefinition;

namespace Test.Common
{
    public static class DomainModelDefinitionsProviderHelper
    {
        public static readonly IList<IDomainModelDefinitionsProvider> DefinitionProviders =
            new List<IDomainModelDefinitionsProvider>
            {
                new DomainModelDefinitionsJsonEmbeddedResourceProvider(typeof(Marker_EdFi_Ods_Standard).Assembly),
                new GrandBendDomainModelDefinitionsProvider(), new SampleDomainModelDefinitionsProvider()
            };

        public static IDomainModelProvider DomainModelProvider =
            new DomainModelProvider(DefinitionProviders);

        public static IResourceModelProvider ResourceModelProvider =
            new ResourceModelProvider(DomainModelProvider);

        public static ISchemaNameMapProvider SchemaNameMapProvider =
            DomainModelProvider.GetDomainModel()
                               .SchemaNameMapProvider;

        public static SwaggerDocumentContext DefaultSwaggerDocumentContext =
            new SwaggerDocumentContext(ResourceModelProvider.GetResourceModel());
    }

    // NOTE: this is a copy from the generated models class from the Grand Bend extensions.
    internal class GrandBendDomainModelDefinitionsProvider : IDomainModelDefinitionsProvider
    {
        public DomainModelDefinitions GetDomainModelDefinitions()
        {
            return
                new DomainModelDefinitions(
                    new SchemaDefinition("GrandBend", "gb"),
                    new[]
                    {
                        new AggregateDefinition(
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new FullName("gb", "Applicant"), new FullName("gb", "ApplicantAddress")
                            })
                    },
                    new[]
                    {
                        new EntityDefinition(
                            "gb",
                            "Applicant",
                            new[]
                            {
                                new EP("ApplicantIdentifier", new PT(DbType.String, 32, 0, 0, false), "", true, false),
                                new EP("PersonalTitlePrefix", new PT(DbType.String, 30, 0, 0, true), "", false, false),
                                new EP("FirstName", new PT(DbType.String, 75, 0, 0, false), "", false, false),
                                new EP("MiddleName", new PT(DbType.String, 75, 0, 0, true), "", false, false),
                                new EP("LastSurname", new PT(DbType.String, 75, 0, 0, false), "", false, false),
                                new EP("GenerationCodeSuffix", new PT(DbType.String, 10, 0, 0, true), "", false, false),
                                new EP("MaidenName", new PT(DbType.String, 75, 0, 0, true), "", false, false),
                                new EP("BirthDate", new PT(DbType.Date, 0, 0, 0, true), "", false, false),
                                new EP("HispanicLatinoEthnicity", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                                new EP("YearsOfPriorProfessionalExperience", new PT(DbType.Decimal, 0, 5, 2, true), "", false, false),
                                new EP("YearsOfPriorTeachingExperience", new PT(DbType.Decimal, 0, 5, 2, true), "", false, false),
                                new EP("LoginId", new PT(DbType.String, 60, 0, 0, true), "", false, false),
                                new EP("HighlyQualifiedTeacher", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                                new EP("Id", new PT(DbType.Guid, 0, 0, 0, false), "", false, false),
                                new EP("LastModifiedDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_Applicant",
                                    new[]
                                    {
                                        "EducationOrganizationId", "ApplicantIdentifier"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "gb",
                            "ApplicantAddress",
                            new[]
                            {
                                new EP("StreetNumberName", new PT(DbType.String, 150, 0, 0, false), "", false, false),
                                new EP("ApartmentRoomSuiteNumber", new PT(DbType.String, 50, 0, 0, true), "", false, false),
                                new EP("BuildingSiteNumber", new PT(DbType.String, 20, 0, 0, true), "", false, false),
                                new EP("City", new PT(DbType.String, 30, 0, 0, false), "", false, false),
                                new EP("PostalCode", new PT(DbType.String, 17, 0, 0, false), "", false, false),
                                new EP("NameOfCounty", new PT(DbType.String, 30, 0, 0, true), "", false, false),
                                new EP("CountyFIPSCode", new PT(DbType.String, 5, 0, 0, true), "", false, false),
                                new EP("Latitude", new PT(DbType.String, 20, 0, 0, true), "", false, false),
                                new EP("Longitude", new PT(DbType.String, 20, 0, 0, true), "", false, false),
                                new EP("BeginDate", new PT(DbType.Date, 0, 0, 0, true), "", false, false),
                                new EP("EndDate", new PT(DbType.Date, 0, 0, 0, true), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_ApplicantAddress",
                                    new[]
                                    {
                                        "EducationOrganizationId", "ApplicantIdentifier", "AddressTypeDescriptorId"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "gb",
                            "StaffExtension",
                            new[]
                            {
                                new EP("ProbationCompleteDate", new PT(DbType.Date, 0, 0, 0, true), "", false, false),
                                new EP("Tenured", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_StaffExtension",
                                    new[]
                                    {
                                        "StaffUSI"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            "")
                    },
                    new[]
                    {
                        new AssociationDefinition(
                            new FullName("gb", "FK_Applicant_AcademicSubjectDescriptor_AcademicSubjectDescriptorId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "AcademicSubjectDescriptor"),
                            new[]
                            {
                                new EP(
                                    "AcademicSubjectDescriptorId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                    false,
                                    false)
                            },
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new EP("HighlyQualifiedAcademicSubjectDescriptorId", new PT(DbType.Int32, 0, 10, 0, true), "", false, false)
                            },
                            false,
                            false),
                        new AssociationDefinition(
                            new FullName("gb", "FK_ApplicantAddress_AddressTypeDescriptor_AddressTypeDescriptorId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "AddressTypeDescriptor"),
                            new[]
                            {
                                new EP(
                                    "AddressTypeDescriptorId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                    true,
                                    false)
                            },
                            new FullName("gb", "ApplicantAddress"),
                            new[]
                            {
                                new EP("AddressTypeDescriptorId", new PT(DbType.Int32, 0, 10, 0, false), "", true, false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("gb", "FK_Applicant_CitizenshipStatusDescriptor_CitizenshipStatusDescriptorId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "CitizenshipStatusDescriptor"),
                            new[]
                            {
                                new EP(
                                    "CitizenshipStatusDescriptorId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                    false,
                                    false)
                            },
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new EP("CitizenshipStatusDescriptorId", new PT(DbType.Int32, 0, 10, 0, true), "", false, false)
                            },
                            false,
                            false),
                        new AssociationDefinition(
                            new FullName("gb", "FK_Applicant_EducationOrganization_EducationOrganizationId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "EducationOrganization"),
                            new[]
                            {
                                new EP(
                                    "EducationOrganizationId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "The identifier assigned to an education organization.",
                                    true,
                                    false)
                            },
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new EP("EducationOrganizationId", new PT(DbType.Int32, 0, 10, 0, false), "", true, false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("gb", "FK_Applicant_LevelOfEducationDescriptor_LevelOfEducationDescriptorId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "LevelOfEducationDescriptor"),
                            new[]
                            {
                                new EP(
                                    "LevelOfEducationDescriptorId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                    false,
                                    false)
                            },
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new EP("HighestCompletedLevelOfEducationDescriptorId", new PT(DbType.Int32, 0, 10, 0, true), "", false, false)
                            },
                            false,
                            false),
                        new AssociationDefinition(
                            new FullName("gb", "FK_Applicant_SexDescriptor_SexDescriptorId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "SexDescriptor"),
                            new[]
                            {
                                new EP(
                                    "SexDescriptorId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                    false,
                                    false)
                            },
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new EP("SexDescriptorId", new PT(DbType.Int32, 0, 10, 0, true), "", false, false)
                            },
                            false,
                            false),
                        new AssociationDefinition(
                            new FullName("gb", "FK_StaffExtension_Staff_StaffUSI"),
                            Cardinality.OneToOneExtension,
                            new FullName("edfi", "Staff"),
                            new[]
                            {
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    true)
                            },
                            new FullName("gb", "StaffExtension"),
                            new[]
                            {
                                new EP("StaffUSI", new PT(DbType.Int32, 0, 10, 0, false), "", true, false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("gb", "FK_ApplicantAddress_StateAbbreviationDescriptor_StateAbbreviationDescriptorId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "StateAbbreviationDescriptor"),
                            new[]
                            {
                                new EP(
                                    "StateAbbreviationDescriptorId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.",
                                    false,
                                    false)
                            },
                            new FullName("gb", "ApplicantAddress"),
                            new[]
                            {
                                new EP("StateAbbreviationDescriptorId", new PT(DbType.Int32, 0, 10, 0, false), "", false, false)
                            },
                            false,
                            true),
                        new AssociationDefinition(
                            new FullName("gb", "FK_ApplicantAddress_Applicant_EducationOrganizationId"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("gb", "Applicant"),
                            new[]
                            {
                                new EP("EducationOrganizationId", new PT(DbType.Int32, 0, 10, 0, false), "", true, false),
                                new EP("ApplicantIdentifier", new PT(DbType.String, 32, 0, 0, false), "", true, false)
                            },
                            new FullName("gb", "ApplicantAddress"),
                            new[]
                            {
                                new EP("EducationOrganizationId", new PT(DbType.Int32, 0, 10, 0, false), "", true, false),
                                new EP("ApplicantIdentifier", new PT(DbType.String, 32, 0, 0, false), "", true, false)
                            },
                            true,
                            true)
                    },
                    new AggregateExtensionDefinition[0]
                );
        }
    }

    // NOTE: this is a copy from the generated models class from the Sample extensions.
    internal class SampleDomainModelDefinitionsProvider : IDomainModelDefinitionsProvider
    {
        public DomainModelDefinitions GetDomainModelDefinitions()
        {
            return
                new DomainModelDefinitions(
                    new SchemaDefinition("Sample", "sample"),
                    new AggregateDefinition[]
                    { },
                    new[]
                    {
                        new EntityDefinition(
                            "sample",
                            "StaffExtension",
                            new[]
                            {
                                new EP("FirstPetOwnedDate", new PT(DbType.Date, 0, 0, 0, true), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_StaffExtension",
                                    new[]
                                    {
                                        "StaffUSI"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "sample",
                            "StaffPet",
                            new[]
                            {
                                new EP("PetName", new PT(DbType.String, 20, 0, 0, false), "", true, false),
                                new EP("IsFixed", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_StaffPet",
                                    new[]
                                    {
                                        "StaffUSI", "PetName"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "sample",
                            "StaffPetPreference",
                            new[]
                            {
                                new EP("MinimumWeight", new PT(DbType.Int32, 0, 10, 0, false), "", false, false),
                                new EP("MaximumWeight", new PT(DbType.Int32, 0, 10, 0, false), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_StaffPetPreference",
                                    new[]
                                    {
                                        "StaffUSI"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "sample",
                            "StudentPet",
                            new[]
                            {
                                new EP("PetName", new PT(DbType.String, 20, 0, 0, false), "", true, false),
                                new EP("IsFixed", new PT(DbType.Boolean, 0, 0, 0, true), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "PK_StudentPet",
                                    new[]
                                    {
                                        "StudentUSI", "PetName"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "sample",
                            "StudentPetPreference",
                            new[]
                            {
                                new EP("MinimumWeight", new PT(DbType.Int32, 0, 10, 0, false), "", false, false),
                                new EP("MaximumWeight", new PT(DbType.Int32, 0, 10, 0, false), "", false, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
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
                    },
                    new[]
                    {
                        new AssociationDefinition(
                            new FullName("sample", "FK_StaffExtension_Staff_StaffUSI"),
                            Cardinality.OneToOneExtension,
                            new FullName("edfi", "Staff"),
                            new[]
                            {
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    true)
                            },
                            new FullName("sample", "StaffExtension"),
                            new[]
                            {
                                new EP("StaffUSI", new PT(DbType.Int32, 0, 10, 0, false), "", true, false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("sample", "FK_StaffPet_Staff_StaffUSI"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "Staff"),
                            new[]
                            {
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    true)
                            },
                            new FullName("sample", "StaffPet"),
                            new[]
                            {
                                new EP("StaffUSI", new PT(DbType.Int32, 0, 10, 0, false), "", true, false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("sample", "FK_StaffPetPreference_Staff_StaffUSI"),
                            Cardinality.OneToOne,
                            new FullName("edfi", "Staff"),
                            new[]
                            {
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    true)
                            },
                            new FullName("sample", "StaffPetPreference"),
                            new[]
                            {
                                new EP("StaffUSI", new PT(DbType.Int32, 0, 10, 0, false), "", true, true)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("sample", "FK_StudentPet_Student_StudentUSI"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "Student"),
                            new[]
                            {
                                new EP(
                                    "StudentUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a student.",
                                    true,
                                    true)
                            },
                            new FullName("sample", "StudentPet"),
                            new[]
                            {
                                new EP("StudentUSI", new PT(DbType.Int32, 0, 10, 0, false), "", true, false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("sample", "FK_StudentPetPreference_Student_StudentUSI"),
                            Cardinality.OneToOne,
                            new FullName("edfi", "Student"),
                            new[]
                            {
                                new EP(
                                    "StudentUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a student.",
                                    true,
                                    true)
                            },
                            new FullName("sample", "StudentPetPreference"),
                            new[]
                            {
                                new EP("StudentUSI", new PT(DbType.Int32, 0, 10, 0, false), "", true, true)
                            },
                            true,
                            true)
                    },
                    new[]
                    {
                        new AggregateExtensionDefinition(
                            new FullName("edfi", "Staff"),
                            new[]
                            {
                                new FullName("sample", "StaffPet"), new FullName("sample", "StaffPetPreference")
                            }),
                        new AggregateExtensionDefinition(
                            new FullName("edfi", "Student"),
                            new[]
                            {
                                new FullName("sample", "StudentPet"), new FullName("sample", "StudentPetPreference")
                            })
                    }
                );
        }
    }
}

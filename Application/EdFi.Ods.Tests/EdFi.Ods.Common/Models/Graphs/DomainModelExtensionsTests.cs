// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Graphs;
using EdFi.TestFixture;
using NUnit.Framework;
using QuickGraph;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Graphs
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class DomainModelFactory
    {
        public static DomainModel GetTestDomainModel()
        {
            var domainModelBuilder = new DomainModelBuilder();

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "Student"),
                    new[]
                    {
                        new FullName("schema1", "Student"), new FullName("schema1", "StudentAddress"), new FullName("schema1", "StudentLearningStyle")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "EducationOrganization"),
                    new[]
                    {
                        new FullName("schema1", "EducationOrganizationAddress")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new FullName("schema1", "School"), new FullName("schema1", "SchoolCategory")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "SchoolCategoryType"),
                    new[]
                    {
                        new FullName("schema1", "SchoolCategoryType")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "StudentSchoolAssociation"),
                    new[]
                    {
                        new FullName("schema1", "StudentSchoolAssociation")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "SchoolType"),
                    new[]
                    {
                        new FullName("schema1", "SchoolType")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "StudentProgramAssociation"),
                    new[]
                    {
                        new FullName("schema1", "StudentProgramAssociation")
                    }));

            domainModelBuilder.AddAggregate(
                new AggregateDefinition(
                    new FullName("schema1", "StudentCTEProgramAssociation"),
                    new[]
                    {
                        new FullName("schema1", "StudentCTEProgramAssociation")
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "Student",
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("FirstName", new PropertyType(DbType.String), null, false),
                        new EntityPropertyDefinition("LastSurname", new PropertyType(DbType.String), null, false),
                        new EntityPropertyDefinition("StudentUniqueId", new PropertyType(DbType.String), null, false)
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

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "StudentAddress",
                    new[]
                    {
                        new EntityPropertyDefinition("City", new PropertyType(DbType.String), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentAddress",
                            new[]
                            {
                                "StudentUSI", "AddressTypeId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "StudentLearningStyle",
                    new[]
                    {
                        new EntityPropertyDefinition("VisualLearning", new PropertyType(DbType.Decimal), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentLearningStyle",
                            new[]
                            {
                                "StudentUSI"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "EducationOrganization",
                    new[]
                    {
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("NameOfInstitution", new PropertyType(DbType.String), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_EducationOrganization",
                            new[]
                            {
                                "EducationOrganizationId"
                            },
                            true)
                    },
                    isAbstract: true));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "EducationOrganizationAddress",
                    new[]
                    {
                        new EntityPropertyDefinition("City", new PropertyType(DbType.String), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_EducationOrganizationAddress",
                            new[]
                            {
                                "EducationOrganizationId", "AddressTypeId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "School",
                    new EntityPropertyDefinition[0],
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_School",
                            new[]
                            {
                                "SchoolId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "SchoolCategory",
                    new EntityPropertyDefinition[0],
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_SchoolCategory",
                            new[]
                            {
                                "SchoolId", "SchoolCategoryTypeId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "SchoolCategoryType",
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolCategoryTypeId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ShortDescription", new PropertyType(DbType.String), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_SchoolCategoryType",
                            new[]
                            {
                                "SchoolCategoryTypeId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "StudentSchoolAssociation",
                    new[]
                    {
                        new EntityPropertyDefinition("EntryDate", new PropertyType(DbType.DateTime), null, true),
                        new EntityPropertyDefinition("ExitWithdrawDate", new PropertyType(DbType.DateTime), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentSchoolAssociation",
                            new[]
                            {
                                "StudentUSI", "SchoolId", "EntryDate"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "SchoolType",
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolTypeId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ShortDescription", new PropertyType(DbType.String), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_SchoolType",
                            new[]
                            {
                                "SchoolTypeId"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "StudentProgramAssociation",
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ProgramTypeId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ProgramName", new PropertyType(DbType.String), null, true),
                        new EntityPropertyDefinition("ProgramEducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("BeginDate", new PropertyType(DbType.DateTime), null, true),
                        new EntityPropertyDefinition("EndDate", new PropertyType(DbType.DateTime), null, false)
                    },
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentProgramAssociation",
                            new[]
                            {
                                "StudentUSI", "EducationOrganizationId", "ProgramTypeId", "ProgramName", "ProgramEducationOrganizationId", "BeginDate"
                            },
                            true)
                    }));

            domainModelBuilder.AddEntity(
                new EntityDefinition(
                    "schema1",
                    "StudentCTEProgramAssociation",
                    new EntityPropertyDefinition[0],
                    new[]
                    {
                        new EntityIdentifierDefinition(
                            "PK_StudentCTEProgramAssociation",
                            new[]
                            {
                                "StudentUSI", "EducationOrganizationId", "ProgramTypeId", "ProgramName", "ProgramEducationOrganizationId", "BeginDate"
                            },
                            true)
                    }));

            // Add associations
            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "SchoolType"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolTypeId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolTypeId", new PropertyType(DbType.Int32), null, true)
                    },
                    false,
                    false));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToOne,
                    new FullName("schema1", "Student"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "StudentLearningStyle"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "Student"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "StudentAddress"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "EducationOrganization"),
                    new[]
                    {
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "EducationOrganizationAddress"),
                    new[]
                    {
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToOneInheritance,
                    new FullName("schema1", "EducationOrganization"),
                    new[]
                    {
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "SchoolCategory"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            // Add a fictitious self-recursive relationship
            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("ParentSchoolId", new PropertyType(DbType.Int32), null, false)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "SchoolCategoryType"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolCategoryTypeId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "SchoolCategory"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolCategoryTypeId", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "Student"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "StudentSchoolAssociation"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToZeroOrMore,
                    new FullName("schema1", "School"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, true)
                    },
                    new FullName("schema1", "StudentSchoolAssociation"),
                    new[]
                    {
                        new EntityPropertyDefinition("SchoolId", new PropertyType(DbType.Int32), null, true)
                    },
                    true,
                    true));

            domainModelBuilder.AddAssociation(
                new AssociationDefinition(
                    new FullName(
                        "schema1",
                        Guid.NewGuid()
                            .ToString()),
                    Cardinality.OneToOneInheritance,
                    new FullName("schema1", "StudentProgramAssociation"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ProgramTypeId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ProgramName", new PropertyType(DbType.String), null, true),
                        new EntityPropertyDefinition("ProgramEducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("BeginDate", new PropertyType(DbType.DateTime), null, true),
                    },
                    new FullName("schema1", "StudentCTEProgramAssociation"),
                    new[]
                    {
                        new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("EducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ProgramTypeId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("ProgramName", new PropertyType(DbType.String), null, true),
                        new EntityPropertyDefinition("ProgramEducationOrganizationId", new PropertyType(DbType.Int32), null, true),
                        new EntityPropertyDefinition("BeginDate", new PropertyType(DbType.DateTime), null, true),
                    },
                    true,
                    true));

            domainModelBuilder.AddSchema(new SchemaDefinition("schema1", "schema1"));

            return domainModelBuilder.Build();
        }
    }
}

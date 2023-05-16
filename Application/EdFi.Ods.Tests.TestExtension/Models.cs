// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Data;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using PT = EdFi.Ods.Common.Models.Domain.PropertyType;
using EId = EdFi.Ods.Common.Models.Definitions.EntityIdentifierDefinition;
using EP = EdFi.Ods.Common.Models.Definitions.EntityPropertyDefinition;

namespace EdFi.Ods.Tests.TestExtension
{
    public class DomainModelDefinitionsProvider : IDomainModelDefinitionsProvider
    {
        public DomainModelDefinitions GetDomainModelDefinitions()
        {
            return
                new DomainModelDefinitions(
                    new SchemaDefinition("TestExtension", "testextension"),
                    new AggregateDefinition[]
                    { },
                    new[]
                    {
                        new EntityDefinition(
                            "testextension",
                            "StaffLeaveExtension",
                            new[]
                            {
                                new EP("ExtensionDate", new PT(DbType.Date, 0, 0, 0, true), "Sample Extension Documentation", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "StaffLeaveExtension_PK",
                                    new[]
                                    {
                                        "BeginDate", "StaffLeaveEventCategoryTypeId", "StaffUSI"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            ""),
                        new EntityDefinition(
                            "testextension",
                            "StaffLeaveReason",
                            new[]
                            {
                                new EP("Reason", new PT(DbType.String, 40, 0, 0, false), "Sample Extension Documentation", true, false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "StaffLeaveReason_PK",
                                    new[]
                                    {
                                        "BeginDate", "Reason", "StaffLeaveEventCategoryTypeId", "StaffUSI"
                                    },
                                    true,
                                    false)
                            },
                            false,
                            "Sample Extension Documentation")
                    },
                    new[]
                    {
                        new AssociationDefinition(
                            new FullName("testextension", "FK_StaffLeaveExtension_StaffLeave"),
                            Cardinality.OneToOneExtension,
                            new FullName("edfi", "StaffLeave"),
                            new[]
                            {
                                new EP("BeginDate", new PT(DbType.Date, 0, 0, 0, false), "The begin date of the staff leave.", true, false),
                                new EP(
                                    "StaffLeaveEventCategoryTypeId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    $"The code describing the type of leave taken, for example:{Environment.NewLine}        Sick{Environment.NewLine}        Personal{Environment.NewLine}        Vacation.",
                                    true,
                                    false),
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    false)
                            },
                            new FullName("testextension", "StaffLeaveExtension"),
                            new[]
                            {
                                new EP("BeginDate", new PT(DbType.Date, 0, 0, 0, false), "The begin date of the staff leave.", true, false),
                                new EP(
                                    "StaffLeaveEventCategoryTypeId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    $"The code describing the type of leave taken, for example:{Environment.NewLine}        Sick{Environment.NewLine}        Personal{Environment.NewLine}        Vacation.",
                                    true,
                                    false),
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    false)
                            },
                            true,
                            true),
                        new AssociationDefinition(
                            new FullName("testextension", "FK_StaffLeaveReason_StaffLeave"),
                            Cardinality.OneToZeroOrMore,
                            new FullName("edfi", "StaffLeave"),
                            new[]
                            {
                                new EP("BeginDate", new PT(DbType.Date, 0, 0, 0, false), "The begin date of the staff leave.", true, false),
                                new EP(
                                    "StaffLeaveEventCategoryTypeId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    $"The code describing the type of leave taken, for example:{Environment.NewLine}        Sick{Environment.NewLine}        Personal{Environment.NewLine}        Vacation.",
                                    true,
                                    false),
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    false)
                            },
                            new FullName("testextension", "StaffLeaveReason"),
                            new[]
                            {
                                new EP("BeginDate", new PT(DbType.Date, 0, 0, 0, false), "The begin date of the staff leave.", true, false),
                                new EP(
                                    "StaffLeaveEventCategoryTypeId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    $"The code describing the type of leave taken, for example:{Environment.NewLine}        Sick{Environment.NewLine}        Personal{Environment.NewLine}        Vacation.",
                                    true,
                                    false),
                                new EP(
                                    "StaffUSI",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "A unique alphanumeric code assigned to a staff.",
                                    true,
                                    false)
                            },
                            true,
                            true)
                    },
                    new[]
                    {
                        new AggregateExtensionDefinition(
                            new FullName("edfi", "StaffLeave"),
                            new[]
                            {
                                new FullName("testextension", "StaffLeaveReason")
                            })
                    });
        }
    }

    public class EdFiDomainModelDefinitionsProvider : IDomainModelDefinitionsProvider
    {
        public DomainModelDefinitions GetDomainModelDefinitions()
        {
            return
                new DomainModelDefinitions(
                    new SchemaDefinition("Ed-Fi", "edfi"),
                    new[]
                    {
                        new AggregateDefinition(
                            new FullName("edfi", "StaffLeave"),
                            new[]
                            {
                                new FullName("edfi", "StaffLeave")
                            })
                    },
                    new[]
                    {
                        // This definition seems to break the pattern by forcing the definition of foreign key columns in the local properties collection
                        // See StaffUSI and StaffLeaveEventCategoryTypeId.  The domain model will not work without these, or with a more complete core model
                        new EntityDefinition(
                            "edfi",
                            "StaffLeave",
                            new[]
                            {
                                new EP("StaffUSI", new PT(DbType.Int32, 0, 10, 0, false), "Staff Identity Column", true, true),
                                new EP(
                                    "StaffLeaveEventCategoryTypeId",
                                    new PT(DbType.Int32, 0, 10, 0, false),
                                    "Key for StaffLeaveEventCategory",
                                    true,
                                    true),
                                new EP("BeginDate", new PT(DbType.Date, 0, 0, 0, false), "The begin date of the staff leave.", true, false),
                                new EP("EndDate", new PT(DbType.Date, 0, 0, 0, true), "The end date of the staff leave.", false, false),
                                new EP("Reason", new PT(DbType.String, 40, 0, 0, true), "Expanded reason for the staff leave.", false, false),
                                new EP(
                                    "SubstituteAssigned",
                                    new PT(DbType.Boolean, 0, 0, 0, true),
                                    "Indicator of whether a substitute was assigned during the period of staff leave.",
                                    false,
                                    false),
                                new EP("CreateDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false),
                                new EP("LastModifiedDate", new PT(DbType.DateTime, 0, 0, 0, false), "", false, false),
                                new EP("Id", new PT(DbType.Guid, 0, 0, 0, false), "", false, false)
                            },
                            new[]
                            {
                                new EId(
                                    "StaffLeave_PK",
                                    new[]
                                    {
                                        "BeginDate", "StaffLeaveEventCategoryTypeId", "StaffUSI"
                                    },
                                    true,
                                    false),
                                new EId(
                                    "UX_StaffLeave_Id",
                                    new[]
                                    {
                                        "Id"
                                    },
                                    false,
                                    false)
                            },
                            false,
                            "This entity represents the recording of the dates of staff leave (e.g., sick leave, personal time, vacation).")
                    },
                    new AssociationDefinition[]
                    { });
        }
    }
}

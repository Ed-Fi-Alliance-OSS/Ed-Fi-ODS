-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Name') AND name = N'UX_Name_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Name_Id ON [homograph].[Name]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Parent') AND name = N'UX_Parent_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Parent_Id ON [homograph].[Parent]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.School') AND name = N'UX_School_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_School_Id ON [homograph].[School]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.SchoolYearType') AND name = N'UX_SchoolYearType_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_SchoolYearType_Id ON [homograph].[SchoolYearType]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 100, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Staff') AND name = N'UX_Staff_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Staff_Id ON [homograph].[Staff]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Student') AND name = N'UX_Student_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Student_Id ON [homograph].[Student]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.StudentSchoolAssociation') AND name = N'UX_StudentSchoolAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentSchoolAssociation_Id ON [homograph].[StudentSchoolAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT


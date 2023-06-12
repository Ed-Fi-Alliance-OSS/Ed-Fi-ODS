-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Name') AND name = N'UX_Name_ChangeVersion')
    CREATE INDEX [UX_Name_ChangeVersion] ON [homograph].[Name] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Parent') AND name = N'UX_Parent_ChangeVersion')
    CREATE INDEX [UX_Parent_ChangeVersion] ON [homograph].[Parent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.School') AND name = N'UX_School_ChangeVersion')
    CREATE INDEX [UX_School_ChangeVersion] ON [homograph].[School] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.SchoolYearType') AND name = N'UX_SchoolYearType_ChangeVersion')
    CREATE INDEX [UX_SchoolYearType_ChangeVersion] ON [homograph].[SchoolYearType] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Staff') AND name = N'UX_Staff_ChangeVersion')
    CREATE INDEX [UX_Staff_ChangeVersion] ON [homograph].[Staff] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.Student') AND name = N'UX_Student_ChangeVersion')
    CREATE INDEX [UX_Student_ChangeVersion] ON [homograph].[Student] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'homograph.StudentSchoolAssociation') AND name = N'UX_StudentSchoolAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentSchoolAssociation_ChangeVersion] ON [homograph].[StudentSchoolAssociation] ([ChangeVersion] ASC)
    GO
COMMIT


-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'sample.Bus') AND name = N'UX_Bus_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_Bus_Id ON [sample].[Bus]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'sample.BusRoute') AND name = N'UX_BusRoute_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_BusRoute_Id ON [sample].[BusRoute]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'sample.StudentGraduationPlanAssociation') AND name = N'UX_StudentGraduationPlanAssociation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentGraduationPlanAssociation_Id ON [sample].[StudentGraduationPlanAssociation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT


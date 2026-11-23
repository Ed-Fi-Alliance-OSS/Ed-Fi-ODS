-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'edfi.LearningObjectiveH'))
    DROP VIEW edfi.LearningObjectiveH;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'edfi.LearningStandardH'))
    DROP VIEW edfi.LearningStandardH;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'edfi.LocalEducationAgencyH'))
    DROP VIEW edfi.LocalEducationAgencyH;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'edfi.ObjectiveAssessmentH'))
    DROP VIEW edfi.ObjectiveAssessmentH;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'edfi.StudentAssessmentStudentObjectiveAssessmentH'))
    DROP VIEW edfi.StudentAssessmentStudentObjectiveAssessmentH;
GO

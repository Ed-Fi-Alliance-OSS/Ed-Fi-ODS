-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[edfi].[LearningObjectiveH]'))
	DROP VIEW edfi.LearningObjectiveH;
GO

CREATE VIEW edfi.LearningObjectiveH AS
WITH LearningObjectiveH_CTE
AS (
  SELECT [LearningObjectiveId]
      ,[Namespace]
      ,[Objective]
      ,[Description]
      ,[Nomenclature]
      ,[SuccessCriteria]
      ,[ParentLearningObjectiveId]
      ,[ParentNamespace]
      ,[CreateDate]
      ,[LastModifiedDate]
      ,[Id]
      -- ,[AggregateHashValue]
  FROM edfi.LearningObjective
  WHERE ParentLearningObjectiveId IS NULL
        AND ParentNamespace IS NULL
  UNION ALL
  SELECT [t1].[LearningObjectiveId]
      ,[t1].[Namespace]
      ,[t1].[Objective]
      ,[t1].[Description]
      ,[t1].[Nomenclature]
      ,[t1].[SuccessCriteria]
      ,[t1].[ParentLearningObjectiveId]
      ,[t1].[ParentNamespace]
      ,[t1].[CreateDate]
      ,[t1].[LastModifiedDate]
      ,[t1].[Id]
      -- ,[t1].[AggregateHashValue]
  FROM edfi.LearningObjective t1
  INNER JOIN LearningObjectiveH_CTE
    ON t1.ParentLearningObjectiveId = LearningObjectiveH_CTE.LearningObjectiveId
        AND t1.ParentNamespace = LearningObjectiveH_CTE.Namespace
    WHERE [t1].ParentLearningObjectiveId IS NOT NULL
        AND [t1].ParentNamespace IS NOT NULL)

SELECT * FROM LearningObjectiveH_CTE
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[edfi].[LearningStandardH]'))
	DROP VIEW edfi.LearningStandardH;
GO

CREATE VIEW edfi.LearningStandardH AS
WITH LearningStandardH_CTE
AS (
  SELECT [LearningStandardId]
      ,[Description]
      ,[LearningStandardItemCode]
      ,[URI]
      ,[CourseTitle]
      ,[SuccessCriteria]
      ,[ParentLearningStandardId]
      ,[Namespace]
      ,[LearningStandardCategoryDescriptorId]
	  ,[LearningStandardScopeDescriptorId]
      ,[CreateDate]
      ,[LastModifiedDate]
      ,[Id]
      -- ,[AggregateHashValue]
  FROM edfi.LearningStandard
  WHERE ParentLearningStandardId IS NULL
  UNION ALL
  SELECT [t1].[LearningStandardId]
      ,[t1].[Description]
      ,[t1].[LearningStandardItemCode]
      ,[t1].[URI]
      ,[t1].[CourseTitle]
      ,[t1].[SuccessCriteria]
      ,[t1].[ParentLearningStandardId]
      ,[t1].[Namespace]
      ,[t1].[LearningStandardCategoryDescriptorId]
	  ,[t1].[LearningStandardScopeDescriptorId]
      ,[t1].[CreateDate]
      ,[t1].[LastModifiedDate]
      ,[t1].[Id]
      -- ,[t1].[AggregateHashValue]
  FROM edfi.LearningStandard t1
  INNER JOIN LearningStandardH_CTE
      ON t1.ParentLearningStandardId = LearningStandardH_CTE.LearningStandardId
    WHERE [t1].ParentLearningStandardId IS NOT NULL)

SELECT * FROM LearningStandardH_CTE
GO
    
IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[edfi].[LocalEducationAgencyH]'))
	DROP VIEW edfi.LocalEducationAgencyH;
GO

CREATE VIEW edfi.LocalEducationAgencyH AS
WITH LocalEducationAgencyH_CTE
AS (
  SELECT
        [LocalEducationAgencyId],
        [CharterStatusDescriptorId],
        [EducationServiceCenterId],
        [ParentLocalEducationAgencyId],
        [LocalEducationAgencyCategoryDescriptorId],
        [StateEducationAgencyId]
  FROM edfi.LocalEducationAgency
  WHERE ParentLocalEducationAgencyId IS NULL
  UNION ALL
  SELECT
        [t1].[LocalEducationAgencyId],
        [t1].[CharterStatusDescriptorId],
        [t1].[EducationServiceCenterId],
        [t1].[ParentLocalEducationAgencyId],
        [t1].[LocalEducationAgencyCategoryDescriptorId],
        [t1].[StateEducationAgencyId]
  FROM edfi.LocalEducationAgency t1
  INNER JOIN LocalEducationAgencyH_CTE
      ON t1.ParentLocalEducationAgencyId = LocalEducationAgencyH_CTE.LocalEducationAgencyId
    WHERE [t1].ParentLocalEducationAgencyId IS NOT NULL)

SELECT * FROM LocalEducationAgencyH_CTE
GO  

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[edfi].[ObjectiveAssessmentH]'))
	DROP VIEW edfi.ObjectiveAssessmentH;
GO

CREATE VIEW edfi.ObjectiveAssessmentH AS
WITH ObjectiveAssessmentH_CTE AS
    (SELECT [AssessmentIdentifier]
      ,[IdentificationCode]
      ,[Namespace]
      ,[MaxRawScore]
      ,[PercentOfAssessment]
      ,[Nomenclature]
      ,[Description]
      ,[ParentIdentificationCode]
	  ,[AcademicSubjectDescriptorId]
      ,[CreateDate]
      ,[LastModifiedDate]
      ,[Id]
      -- ,[AggregateHashValue]
    FROM edfi.ObjectiveAssessment
    WHERE ParentIdentificationCode IS NULL
    UNION ALL
    SELECT [t1].[AssessmentIdentifier]
      ,[t1].[IdentificationCode]
      ,[t1].[Namespace]
      ,[t1].[MaxRawScore]
      ,[t1].[PercentOfAssessment]
      ,[t1].[Nomenclature]
      ,[t1].[Description]
      ,[t1].[ParentIdentificationCode]
	  ,[t1].AcademicSubjectDescriptorId
      ,[t1].[CreateDate]
      ,[t1].[LastModifiedDate]
      ,[t1].[Id]
      -- ,[t1].[AggregateHashValue]
    FROM edfi.ObjectiveAssessment t1
    INNER JOIN ObjectiveAssessmentH_CTE
        ON t1.AssessmentIdentifier = ObjectiveAssessmentH_CTE.AssessmentIdentifier
            AND t1.ParentIdentificationCode = ObjectiveAssessmentH_CTE.IdentificationCode
            AND t1.Namespace = ObjectiveAssessmentH_CTE.Namespace
    WHERE [t1].AssessmentIdentifier IS NOT NULL
            AND [t1].ParentIdentificationCode IS NOT NULL
            AND [t1].Namespace IS NOT NULL)

SELECT * FROM ObjectiveAssessmentH_CTE
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[edfi].[StudentAssessmentStudentObjectiveAssessmentH]'))
    DROP VIEW edfi.StudentAssessmentStudentObjectiveAssessmentH;
GO

CREATE VIEW [edfi].[StudentAssessmentStudentObjectiveAssessmentH] AS
    WITH RecursivelyOrderedData
    AS (
    SELECT *
        FROM    edfi.ObjectiveAssessment
        WHERE   ParentIdentificationCode IS NULL
        UNION ALL
        SELECT  childSelector.*
        FROM    edfi.ObjectiveAssessment AS childSelector
                INNER JOIN RecursivelyOrderedData
                    ON  childSelector.IdentificationCode = RecursivelyOrderedData.ParentIdentificationCode
    )
    SELECT
        t.[AssessmentIdentifier],
        t.[IdentificationCode],
        t.[Namespace],
        t.[StudentAssessmentIdentifier],
        rt.[MaxRawScore],
        rt.[PercentOfAssessment],
        rt.[Nomenclature],
        rt.[Description],
        rt.[ParentIdentificationCode],
        t.[CreateDate]
    FROM edfi.StudentAssessmentStudentObjectiveAssessment t
    INNER JOIN RecursivelyOrderedData AS rt
        ON t.AssessmentIdentifier = rt.AssessmentIdentifier
            AND t.IdentificationCode = rt.IdentificationCode
            AND t.Namespace = rt.Namespace
GO
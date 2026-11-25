-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS edfi.LearningObjectiveH;

DROP VIEW IF EXISTS edfi.LearningStandardH;

CREATE VIEW edfi.LearningStandardH AS
WITH RECURSIVE LearningStandardH_CTE
AS (
  SELECT LearningStandardId
      ,Description
      ,LearningStandardItemCode
      ,URI
      ,CourseTitle
      ,SuccessCriteria
      ,ParentLearningStandardId
      ,Namespace
      ,LearningStandardCategoryDescriptorId
      ,LearningStandardScopeDescriptorId
      ,CreateDate
      ,LastModifiedDate
      ,Id
      -- ,AggregateHashValue
  FROM edfi.LearningStandard
  WHERE ParentLearningStandardId IS NULL
  UNION ALL
  SELECT t1.LearningStandardId
      ,t1.Description
      ,t1.LearningStandardItemCode
      ,t1.URI
      ,t1.CourseTitle
      ,t1.SuccessCriteria
      ,t1.ParentLearningStandardId
      ,t1.Namespace
      ,t1.LearningStandardCategoryDescriptorId
      ,t1.LearningStandardScopeDescriptorId
      ,t1.CreateDate
      ,t1.LastModifiedDate
      ,t1.Id
      -- ,t1.AggregateHashValue
  FROM edfi.LearningStandard t1
  INNER JOIN LearningStandardH_CTE
      ON t1.ParentLearningStandardId = LearningStandardH_CTE.LearningStandardId
    WHERE t1.ParentLearningStandardId IS NOT NULL)

SELECT * FROM LearningStandardH_CTE;

DROP VIEW IF EXISTS edfi.LocalEducationAgencyH;

CREATE VIEW edfi.LocalEducationAgencyH AS
WITH RECURSIVE LocalEducationAgencyH_CTE
AS (
  SELECT
        LocalEducationAgencyId,
        CharterStatusDescriptorId,
        EducationServiceCenterId,
        ParentLocalEducationAgencyId,
        LocalEducationAgencyCategoryDescriptorId,
        StateEducationAgencyId
  FROM edfi.LocalEducationAgency
  WHERE ParentLocalEducationAgencyId IS NULL
  UNION ALL
  SELECT
        t1.LocalEducationAgencyId,
        t1.CharterStatusDescriptorId,
        t1.EducationServiceCenterId,
        t1.ParentLocalEducationAgencyId,
        t1.LocalEducationAgencyCategoryDescriptorId,
        t1.StateEducationAgencyId
  FROM edfi.LocalEducationAgency t1
  INNER JOIN LocalEducationAgencyH_CTE
      ON t1.ParentLocalEducationAgencyId = LocalEducationAgencyH_CTE.LocalEducationAgencyId
    WHERE t1.ParentLocalEducationAgencyId IS NOT NULL)

SELECT * FROM LocalEducationAgencyH_CTE;

DROP VIEW IF EXISTS edfi.ObjectiveAssessmentH;

CREATE VIEW edfi.ObjectiveAssessmentH AS
WITH RECURSIVE ObjectiveAssessmentH_CTE AS (
    SELECT 
        oa.AssessmentIdentifier,
        oa.IdentificationCode,
        oa.Namespace,
        oa.MaxRawScore,
        oa.PercentOfAssessment,
        oa.Nomenclature,
        oa.Description,
        NULL::VARCHAR AS ParentIdentificationCode,
        oa.AcademicSubjectDescriptorId,
        oa.CreateDate,
        oa.LastModifiedDate,
        oa.Id
    FROM edfi.ObjectiveAssessment oa
    WHERE NOT EXISTS (
        SELECT 1
        FROM edfi.ObjectiveAssessmentParentObjectiveAssessment rel
        WHERE 
            rel.AssessmentIdentifier = oa.AssessmentIdentifier
            AND rel.Namespace = oa.Namespace
            AND rel.IdentificationCode = oa.IdentificationCode
    )

    UNION ALL

    SELECT 
        child.AssessmentIdentifier,
        child.IdentificationCode,
        child.Namespace,
        child.MaxRawScore,
        child.PercentOfAssessment,
        child.Nomenclature,
        child.Description,
        rel.ParentIdentificationCode,
        child.AcademicSubjectDescriptorId,
        child.CreateDate,
        child.LastModifiedDate,
        child.Id
    FROM edfi.ObjectiveAssessmentParentObjectiveAssessment rel
    INNER JOIN ObjectiveAssessmentH_CTE parent
        ON rel.AssessmentIdentifier = parent.AssessmentIdentifier
        AND rel.Namespace = parent.Namespace
        AND rel.ParentIdentificationCode = parent.IdentificationCode
    INNER JOIN edfi.ObjectiveAssessment child
        ON child.AssessmentIdentifier = rel.AssessmentIdentifier
        AND child.Namespace = rel.Namespace
        AND child.IdentificationCode = rel.IdentificationCode
)

SELECT * FROM ObjectiveAssessmentH_CTE;

DROP VIEW IF EXISTS edfi.StudentAssessmentStudentObjectiveAssessmentH;

CREATE VIEW edfi.StudentAssessmentStudentObjectiveAssessmentH AS
WITH RECURSIVE RecursivelyOrderedData AS (
    SELECT oa.*
    FROM edfi.ObjectiveAssessment oa
    WHERE NOT EXISTS (
        SELECT 1
        FROM edfi.ObjectiveAssessmentParentObjectiveAssessment rel
        WHERE rel.AssessmentIdentifier = oa.AssessmentIdentifier
          AND rel.Namespace = oa.Namespace
          AND rel.IdentificationCode = oa.IdentificationCode
    )

    UNION ALL

    SELECT child.*
    FROM edfi.ObjectiveAssessmentParentObjectiveAssessment rel
    INNER JOIN RecursivelyOrderedData parent
        ON rel.AssessmentIdentifier = parent.AssessmentIdentifier
        AND rel.Namespace = parent.Namespace
        AND rel.ParentIdentificationCode = parent.IdentificationCode
    INNER JOIN edfi.ObjectiveAssessment child
        ON child.AssessmentIdentifier = rel.AssessmentIdentifier
        AND child.Namespace = rel.Namespace
        AND child.IdentificationCode = rel.IdentificationCode
)


SELECT
    t.AssessmentIdentifier,
    t.IdentificationCode,
    t.Namespace,
    t.StudentAssessmentIdentifier,
    rt.MaxRawScore,
    rt.PercentOfAssessment,
    rt.Nomenclature,
    rt.Description,
    t.CreateDate
FROM edfi.StudentAssessmentStudentObjectiveAssessment t
INNER JOIN RecursivelyOrderedData AS rt
    ON t.AssessmentIdentifier = rt.AssessmentIdentifier
        AND t.IdentificationCode = rt.IdentificationCode
        AND t.Namespace = rt.Namespace;
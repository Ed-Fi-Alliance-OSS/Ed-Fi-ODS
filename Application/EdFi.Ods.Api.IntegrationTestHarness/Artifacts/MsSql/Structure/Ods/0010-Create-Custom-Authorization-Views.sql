CREATE OR ALTER VIEW auth.AssessmentWithAnACTIdentifier
AS
    SELECT a.AssessmentIdentifier ,a.Namespace
    FROM edfi.Assessment a
    WHERE   a.AssessmentIdentifier LIKE 'ACT%'
GO

CREATE OR ALTER VIEW auth.EducationOrganizationWithACategoryContainingAnSWord
AS
    SELECT DISTINCT EducationOrganizationId
    FROM edfi.EducationOrganizationCategory cat
        INNER JOIN edfi.Descriptor d ON cat.EducationOrganizationCategoryDescriptorId = d.DescriptorId
    WHERE CodeValue LIKE 'S%' OR CodeValue LIKE '% S%'
GO

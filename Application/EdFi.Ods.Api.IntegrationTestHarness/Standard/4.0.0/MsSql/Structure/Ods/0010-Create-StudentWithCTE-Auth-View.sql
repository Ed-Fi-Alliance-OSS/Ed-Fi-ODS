CREATE OR ALTER VIEW auth.StudentWithCTECourseEnrollments
AS
    SELECT DISTINCT StudentUSI
    FROM edfi.StudentSectionAssociation ssa
        INNER JOIN edfi.CourseOffering co
        ON co.LocalCourseCode = ssa.LocalCourseCode
            AND co.SchoolId = ssa.SchoolId
            AND co.SchoolYear = ssa.SchoolYear
            AND co.SessionName = ssa.SessionName
        INNER JOIN edfi.Course c ON c.CourseCode = co.CourseCode
            AND c.EducationOrganizationId = co.EducationOrganizationId
        INNER JOIN edfi.descriptor d ON c.AcademicSubjectDescriptorId = d.descriptorid
    WHERE d.CodeValue = 'Career and Technical Education'
GO

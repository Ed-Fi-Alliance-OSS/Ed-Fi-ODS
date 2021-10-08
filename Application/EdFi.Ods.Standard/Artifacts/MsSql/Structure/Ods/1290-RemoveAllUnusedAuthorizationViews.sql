-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToStudentUSI'))
    DROP VIEW auth.EducationOrganizationIdToStudentUSI;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.LocalEducationAgencyIdToStudentUSI'))
    DROP VIEW auth.LocalEducationAgencyIdToStudentUSI;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation'))
    DROP VIEW auth.LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.SchoolIdToStudentUSI'))
    DROP VIEW auth.SchoolIdToStudentUSI;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.SchoolIdToStudentUSIThroughEdOrgAssociation'))
    DROP VIEW auth.SchoolIdToStudentUSIThroughEdOrgAssociation;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.LocalEducationAgencyIdToStaffUSI'))
    DROP VIEW auth.LocalEducationAgencyIdToStaffUSI;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.SchoolIdToStaffUSI'))
    DROP VIEW auth.SchoolIdToStaffUSI;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.LocalEducationAgencyIdToParentUSI'))
    DROP VIEW auth.LocalEducationAgencyIdToParentUSI;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.ParentUSIToSchoolId'))
    DROP VIEW auth.ParentUSIToSchoolId;
GO


IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToLocalEducationAgencyId'))
    DROP VIEW auth.EducationOrganizationIdToLocalEducationAgencyId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToSchoolId'))
    DROP VIEW auth.EducationOrganizationIdToSchoolId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.LocalEducationAgencyIdToSchoolId'))
    DROP VIEW auth.LocalEducationAgencyIdToSchoolId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.LocalEducationAgencyIdToOrganizationDepartmentId'))
    DROP VIEW auth.LocalEducationAgencyIdToOrganizationDepartmentId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.OrganizationDepartmentIdToSchoolId'))
    DROP VIEW auth.OrganizationDepartmentIdToSchoolId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.CommunityOrganizationIdToEducationOrganizationId'))
    DROP VIEW auth.CommunityOrganizationIdToEducationOrganizationId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.CommunityProviderIdToEducationOrganizationId'))
    DROP VIEW auth.CommunityProviderIdToEducationOrganizationId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.CommunityOrganizationIdToCommunityProviderId'))
    DROP VIEW auth.CommunityOrganizationIdToCommunityProviderId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToPostSecondaryInstitutionId'))
    DROP VIEW auth.EducationOrganizationIdToPostSecondaryInstitutionId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToUniversityId'))
    DROP VIEW auth.EducationOrganizationIdToUniversityId;
GO

IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'auth.EducationOrganizationIdToTeacherPreparationProviderId'))
    DROP VIEW auth.EducationOrganizationIdToTeacherPreparationProviderId;
GO


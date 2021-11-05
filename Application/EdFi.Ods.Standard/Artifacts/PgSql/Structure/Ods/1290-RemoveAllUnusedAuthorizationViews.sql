-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.School;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStaffUSI CASCADE;
DROP VIEW IF EXISTS auth.CommunityProviderIdToStaffUSI;
DROP VIEW IF EXISTS auth.PostSecondaryInstitutionIdToStaffUSI;
DROP VIEW IF EXISTS auth.EducationOrganizationToStaffUSI_Employment;
DROP VIEW IF EXISTS auth.EducationOrganizationToStaffUSI_Assignment;
DROP VIEW IF EXISTS auth.LocalEducationAgency;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToStateAgencyId;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToEducationServiceCenterId;
DROP VIEW IF EXISTS auth.CommunityOrganizationIdToCommunityProviderId;
DROP VIEW IF EXISTS auth.CommunityOrganizationIdToEducationOrganizationId;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStudentUSI CASCADE;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStudentUSIThroughEdOrgAssociation;
DROP VIEW IF EXISTS auth.SchoolIdToStudentUSI;
DROP VIEW IF EXISTS auth.ParentUSIToStudentUSI;
DROP VIEW IF EXISTS auth.SchoolIdToStudentUSIThroughEdOrgAssociation;
DROP VIEW IF EXISTS auth.SchoolIdToStaffUSI;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToParentUSI;
DROP VIEW IF EXISTS auth.ParentUSIToSchoolId;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToLocalEducationAgencyId;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToSchoolId;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToSchoolId;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToOrganizationDepartmentId;
DROP VIEW IF EXISTS auth.OrganizationDepartmentIdToSchoolId;
DROP VIEW IF EXISTS auth.CommunityProviderIdToEducationOrganizationId;
DROP VIEW IF EXISTS auth.CommunityOrganizationIdToCommunityProviderId;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToPostSecondaryInstitutionId;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToUniversityId;
DROP VIEW IF EXISTS auth.EducationOrganizationIdToTeacherPreparationProviderId;
DROP VIEW IF EXISTS auth.StudentUSIToEducationOrganizationId;
DROP VIEW IF EXISTS auth.ParentUSIToEducationOrganizationId;
DROP VIEW IF EXISTS auth.StaffUSIToEducationOrganizationId;
DROP VIEW IF EXISTS auth.StudentUSIToStudentEdOrgResponsibilityAssociation;
DROP VIEW IF EXISTS auth.EducationOrganizationIdentifiers;

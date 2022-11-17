-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @applicationId INT;
DECLARE @systemDescriptorsResourceClaimId INT;
DECLARE @relationshipBasedDataResourceClaimId INT;
DECLARE @resourceClaimId INT;

SELECT @applicationId = (SELECT applicationid FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API');

SELECT @resourceClaimId = ResourceClaimId FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor';

SELECT @systemDescriptorsResourceClaimId = ResourceClaimId FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors';

	-- Creating new claim:educationOrganizationAssociationTypeDescriptor
IF @resourceClaimId IS NULL
    BEGIN
        PRINT 'Creating new claim:educationOrganizationAssociationTypeDescriptor'

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educationOrganizationAssociationTypeDescriptor', 'educationOrganizationAssociationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor', @systemDescriptorsResourceClaimId, @applicationId);

    END

SELECT @resourceClaimId = ResourceClaimId FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation';

SELECT @relationshipBasedDataResourceClaimId = ResourceClaimId FROM ResourceClaims
WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData';

	-- Creating new claim:studentAssessmentEducationOrganizationAssociation
IF @resourceClaimId IS NULL
    BEGIN
        PRINT 'Creating new claim:studentAssessmentEducationOrganizationAssociation'

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('studentAssessmentEducationOrganizationAssociation', 'studentAssessmentEducationOrganizationAssociation', 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation', @relationshipBasedDataResourceClaimId, @applicationId);

    END    

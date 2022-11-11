-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
application_Id INT;
systemDescriptorsResourceClaim_Id INT;
relationshipBasedDataResourceClaim_Id INT;
resourceClaim_Id INT;

BEGIN
   	
    SELECT applicationid INTO application_Id FROM  dbo.Applications  WHERE ApplicationName  = 'Ed-Fi ODS API';

    SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  
	WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor';

    SELECT ResourceClaimId INTO systemDescriptorsResourceClaim_Id  FROM dbo.ResourceClaims  
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/systemDescriptors';

	-- Creating new claim:educationOrganizationAssociationTypeDescriptor
	IF resourceClaim_Id IS NULL THEN
        RAISE NOTICE 'Creating new claim:educationOrganizationAssociationTypeDescriptor';

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educationOrganizationAssociationTypeDescriptor', 'educationOrganizationAssociationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor', systemDescriptorsResourceClaim_Id, application_Id);

    END IF;

    SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  
	WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation';

    SELECT ResourceClaimId INTO relationshipBasedDataResourceClaim_Id  FROM dbo.ResourceClaims  
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData';

	-- Creating new claim:studentAssessmentEducationOrganizationAssociation
	IF resourceClaim_Id IS NULL THEN
        RAISE NOTICE 'Creating new claim:studentAssessmentEducationOrganizationAssociation';

        INSERT INTO dbo.ResourceClaims(DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES ('educationOrganizationAssociationTypeDescriptor', 'educationOrganizationAssociationTypeDescriptor', 'http://ed-fi.org/ods/identity/claims/educationOrganizationAssociationTypeDescriptor', relationshipBasedDataResourceClaim_Id, application_Id);

    END IF;

END $$; 
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
parent_resource_claim_id INT;
resourceClaim_Id INT;

BEGIN
   	
    SELECT ResourceClaimId INTO resourceClaim_Id  FROM dbo.ResourceClaims  
	WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/studentAssessmentEducationOrganizationAssociation';

    SELECT ResourceClaimId INTO parent_resource_claim_id  FROM dbo.ResourceClaims  
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/relationshipBasedData';

	-- UPDATE relationshipBasedData AS parentresource for studentAssessmentEducationOrganizationAssociation
	IF resourceClaim_Id IS NOT NULL THEN
        RAISE NOTICE 'UPDATE relationshipBasedData AS parentresource for studentAssessmentEducationOrganizationAssociation';

        UPDATE dbo.ResourceClaims 
		SET ParentResourceClaimId = parent_resource_claim_id
        WHERE ResourceClaimId = resourceClaim_Id;

    END IF;

END $$; 
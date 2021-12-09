-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
    claim_set_name VARCHAR(255) := 'District Hosted SIS Vendor';
    application_name VARCHAR(200) := 'Ed-Fi ODS API';
    application_id INT;
    claim_set_id INT;
    create_action_id INT;
    read_action_id INT;
    update_action_id INT;
    delete_action_id INT;
    type_resource_claim_id INT;
    system_descriptors_resource_claim_id INT;
    managed_descriptors_resource_claim_id INT;
    relationship_based_data_resource_claim_id INT;
    assessment_metadata_resource_claim_id INT;
    education_organizations_resource_claim_id INT;
    education_standards_resource_claim_id INT;
    people_resource_claim_id INT;
    primary_relationships_resource_claim_id INT;
    education_content_resource_claim_id INT;
    school_resource_resource_claim_id INT;
    local_education_agency_resource_claim_id INT;
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Applications WHERE ApplicationName = application_name)
    THEN
        IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = claim_set_name)
		THEN
			--Create a new ClaimSet
			SELECT ApplicationId INTO application_id
			FROM dbo.Applications WHERE ApplicationName = application_name;

			INSERT INTO dbo.ClaimSets (ClaimSetName ,Application_ApplicationId) values (claim_set_name, application_id);
			
			SELECT ClaimSetId INTO claim_set_id
			FROM dbo.ClaimSets
			WHERE ClaimSetName = claim_set_name;
			
			--Actions--
			SELECT ActionId INTO create_action_id
			FROM dbo.Actions a
			WHERE a.ActionName = 'Create';
			
			SELECT ActionId INTO read_action_id
			FROM dbo.Actions a
			WHERE a.ActionName = 'Read';

			SELECT ActionId INTO update_action_id
			FROM dbo.Actions a
			WHERE a.ActionName = 'Update';

			SELECT ActionId INTO delete_action_id
			FROM dbo.Actions a
			WHERE a.ActionName = 'Delete';
			
			--ResourceClaims--
			SELECT ResourceClaimId INTO type_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'types';

			SELECT ResourceClaimId INTO system_descriptors_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'systemDescriptors';

			SELECT ResourceClaimId INTO relationship_based_data_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'relationshipBasedData';
			
			SELECT ResourceClaimId INTO managed_descriptors_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'managedDescriptors';

			SELECT ResourceClaimId INTO assessment_metadata_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'assessmentMetadata';

			SELECT ResourceClaimId INTO education_organizations_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'educationOrganizations';
			
			SELECT ResourceClaimId INTO education_standards_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'educationStandards';

			SELECT ResourceClaimId INTO people_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'people';

			SELECT ResourceClaimId INTO primary_relationships_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'primaryRelationships';
			
			SELECT ResourceClaimId INTO education_content_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'educationContent';

			SELECT ResourceClaimId INTO school_resource_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'school';

			SELECT ResourceClaimId INTO local_education_agency_resource_claim_id
			FROM dbo.ResourceClaims rc
			WHERE rc.ResourceName = 'localEducationAgency';
			
			--Add claims from SIS Vendor ClaimSet
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, type_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, system_descriptors_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, delete_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_organizations_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, people_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, people_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, people_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, people_resource_claim_id, delete_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, relationship_based_data_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, relationship_based_data_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, relationship_based_data_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, relationship_based_data_resource_claim_id, delete_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, delete_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_standards_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_standards_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_standards_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_standards_resource_claim_id, delete_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, primary_relationships_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, primary_relationships_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, primary_relationships_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, primary_relationships_resource_claim_id, delete_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_content_resource_claim_id, create_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_content_resource_claim_id, read_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_content_resource_claim_id,  update_action_id);
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId) VALUES (claim_set_id, education_content_resource_claim_id, delete_action_id);
			
			--Add District Hosted SIS Vendor Claims

			-- Create Schools
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
			VALUES (claim_set_id, school_resource_resource_claim_id, create_action_id);

			-- Read Schools
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
			VALUES (claim_set_id, school_resource_resource_claim_id, read_action_id);

			-- Update Schools
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
			VALUES (claim_set_id, school_resource_resource_claim_id,  update_action_id);

			-- Delete Schools
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
			VALUES (claim_set_id, school_resource_resource_claim_id, delete_action_id);

			-- Read localEducationAgency
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
			VALUES (claim_set_id, local_education_agency_resource_claim_id, read_action_id);

			-- Update localEducationAgency
			INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
			VALUES (claim_set_id, local_education_agency_resource_claim_id,  update_action_id);
		END IF;
    END IF;
END $$;
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
    claim_set_name VARCHAR(75) := 'Assessment Vendor';
    application_name VARCHAR(50) := 'Ed-Fi ODS API';
    application_id INT;
    claim_set_id INT;
    create_action_id INT;
    read_action_id INT;
    update_action_id INT;
    delete_action_id INT;
    academic_subject_descriptor_resource_claim_id INT;
    assessment_metadata_resource_claim_id INT;
    learning_objective_resource_claim_id INT;
    managed_descriptors_resource_claim_id INT;
    student_resource_claim_id INT;
    system_descriptors_resource_claim_id INT;
    types_resource_claim_id INT;
    learning_standard_resource_claim_id INT;
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.Applications WHERE ApplicationName = application_name)
    THEN
        RAISE NOTICE '% does not exist', application_name;
    END IF;

    IF EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = claim_set_name)
    THEN
        SELECT ClaimSetId INTO claim_set_id
        FROM dbo.ClaimSets
        WHERE ClaimSetName = claim_set_name;

        --Remove existing claimsets--
        DELETE FROM dbo.ClaimSetResourceClaims
        WHERE ClaimSet_ClaimSetId = claim_set_id;
    ElSE
        --Create a new ClaimSet--
        INSERT INTO dbo.ClaimSets (ClaimSetName, Application_ApplicationId) VALUES (claim_set_name,application_id);

        SELECT ClaimSetId INTO claim_set_id
        FROM dbo.ClaimSets
        WHERE ClaimSetName = claim_set_name;
    END IF;

    SELECT ApplicationId INTO application_id
    FROM dbo.Applications
    WHERE ApplicationName = application_name;

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
    SELECT ResourceClaimId INTO academic_subject_descriptor_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'academicSubjectDescriptor';

    SELECT ResourceClaimId INTO assessment_metadata_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'assessmentMetadata';

    SELECT ResourceClaimId INTO learning_objective_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'learningObjective';

    SELECT ResourceClaimId INTO learning_standard_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'learningStandard';

    SELECT ResourceClaimId INTO managed_descriptors_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'managedDescriptors';

    SELECT ResourceClaimId INTO student_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'student';

    SELECT ResourceClaimId INTO system_descriptors_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'systemDescriptors';

    SELECT ResourceClaimId INTO types_resource_claim_id
    FROM dbo.ResourceClaims rc
    WHERE rc.ResourceName = 'types';

    --academicSubjectDescriptor CRUD--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, academic_subject_descriptor_resource_claim_id, create_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, academic_subject_descriptor_resource_claim_id, read_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, academic_subject_descriptor_resource_claim_id, update_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, academic_subject_descriptor_resource_claim_id, delete_action_id);

    --assessmentMetadata CRUD--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, create_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, read_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, update_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, assessment_metadata_resource_claim_id, delete_action_id);

    --learningObjective CRUD--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, learning_objective_resource_claim_id, create_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, learning_objective_resource_claim_id, read_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, learning_objective_resource_claim_id, update_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, learning_objective_resource_claim_id, delete_action_id);

    --learningStandards R--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, learning_standard_resource_claim_id, read_action_id);

    --managedDescriptors CRUD--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, create_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, read_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, update_action_id);
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, managed_descriptors_resource_claim_id, delete_action_id);

    --student R--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, student_resource_claim_id, read_action_id);

    --systemDescriptors R--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, system_descriptors_resource_claim_id, read_action_id);

    --types R--
    INSERT INTO dbo.ClaimSetResourceClaims (ClaimSet_ClaimSetId, ResourceClaim_ResourceClaimId, Action_ActionId) VALUES (claim_set_id, types_resource_claim_id, read_action_id);
END $$;
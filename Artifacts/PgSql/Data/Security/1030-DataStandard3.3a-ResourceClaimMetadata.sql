-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
application_id INT;
systemDescriptorsResourceClaim_Id INT;
relationshipBasedDataResourceClaim_Id INT;
assessmentMetadataResourceClaim_Id INT;
noFurtherAuthRequiredAuthorizationStrategy_Id INT;
    
BEGIN

    IF  EXISTS (SELECT 1 FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API')
    THEN
        SELECT applicationid INTO application_id
        FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API';
    END IF;

    IF  EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = application_id)
    THEN
        SELECT ResourceClaimId INTO systemDescriptorsResourceClaim_Id
        FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = application_id;
    END IF;

    IF  EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'relationshipBasedData' AND Application_ApplicationId = application_id)
    THEN
        SELECT ResourceClaimId INTO relationshipBasedDataResourceClaim_Id
        FROM dbo.ResourceClaims WHERE ResourceName = 'relationshipBasedData' AND Application_ApplicationId = application_id;
    END IF;

    IF  EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'assessmentMetadata' AND Application_ApplicationId = application_id)
    THEN
        SELECT ResourceClaimId INTO assessmentMetadataResourceClaim_Id
        FROM dbo.ResourceClaims WHERE ResourceName = 'assessmentMetadata' AND Application_ApplicationId = application_id;
    END IF;

    IF  EXISTS (SELECT 1 FROM dbo.AuthorizationStrategies WHERE DisplayName = 'No Further Authorization Required')
    THEN
        SELECT AuthorizationStrategyId INTO noFurtherAuthRequiredAuthorizationStrategy_Id
        FROM dbo.AuthorizationStrategies WHERE DisplayName = 'No Further Authorization Required';
    END IF;

    /* new descriptors */
    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'ancestryEthnicOriginDescriptor' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'ancestryEthnicOriginDescriptor', N'ancestryEthnicOriginDescriptor', N'http://ed-fi.org/ods/identity/claims/ancestryEthnicOriginDescriptor', systemDescriptorsResourceClaim_Id, application_id);
    END IF;
    
    -- Try insert StudentDisciplineIncidentBehaviorAssociation
    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'studentDisciplineIncidentBehaviorAssociation' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'studentDisciplineIncidentBehaviorAssociation', N'studentDisciplineIncidentBehaviorAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentBehaviorAssociation', relationshipBasedDataResourceClaim_Id, application_id);
    END IF;
    
    -- Try insert StudentDisciplineIncidentNonOffenderAssociation
    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'studentDisciplineIncidentNonOffenderAssociation' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'studentDisciplineIncidentNonOffenderAssociation', N'studentDisciplineIncidentNonOffenderAssociation', N'http://ed-fi.org/ods/identity/claims/studentDisciplineIncidentNonOffenderAssociation', relationshipBasedDataResourceClaim_Id, application_id);
    END IF;

    -- Try insert AssessmentScoreRangeLearningStandard
    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'assessmentScoreRangeLearningStandard' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'assessmentScoreRangeLearningStandard', N'assessmentScoreRangeLearningStandard', N'http://ed-fi.org/ods/identity/claims/assessmentScoreRangeLearningStandard', assessmentMetadataResourceClaim_Id, application_id);
    END IF;


END $$;
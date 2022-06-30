-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO language plpgsql $$
DECLARE
application_id INT;
systemDescriptorsResourceClaim_Id INT;
    
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

    /* new descriptors */
    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'tribalAffiliationDescriptor' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'tribalAffiliationDescriptor', N'tribalAffiliationDescriptor', N'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor', systemDescriptorsResourceClaim_Id, application_id);
    END IF;
    
    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'specialEducationSettingDescriptor' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'specialEducationSettingDescriptor', N'specialEducationSettingDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor', systemDescriptorsResourceClaim_Id, application_id);
    END IF;

    IF (NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ResourceName = 'internetAccessDescriptor' AND Application_ApplicationId = application_id))
    THEN
        INSERT INTO dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'internetAccessDescriptor', N'internetAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor', systemDescriptorsResourceClaim_Id, application_id);
    END IF;


END $$;
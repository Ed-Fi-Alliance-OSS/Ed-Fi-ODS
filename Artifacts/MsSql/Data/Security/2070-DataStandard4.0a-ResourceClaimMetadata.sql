-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

    -- SPDX-License-Identifier: Apache-2.0
    -- Licensed to the Ed-Fi Alliance under one or more agreements.
    -- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
    -- See the LICENSE and NOTICES files in the project root for more information.

    DECLARE @applicationId INT;
    DECLARE @systemDescriptorsResourceClaimId INT;

    SELECT @applicationId = (SELECT applicationid FROM  dbo.Applications  WHERE  ApplicationName  = 'Ed-Fi ODS API');
    SELECT @systemDescriptorsResourceClaimId = (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'systemDescriptors' AND Application_ApplicationId = @applicationId);
    

    /* new descriptors */
    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'tribalAffiliationDescriptor' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'tribalAffiliationDescriptor', N'tribalAffiliationDescriptor', N'http://ed-fi.org/ods/identity/claims/tribalAffiliationDescriptor', @systemDescriptorsResourceClaimId, @applicationId);
    END

    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'specialEducationSettingDescriptor' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'specialEducationSettingDescriptor', N'specialEducationSettingDescriptor', N'http://ed-fi.org/ods/identity/claims/specialEducationSettingDescriptor', @systemDescriptorsResourceClaimId, @applicationId);
    END

    IF (NOT EXISTS (SELECT ResourceClaimId FROM dbo.ResourceClaims WHERE ResourceName = 'internetAccessDescriptor' AND Application_ApplicationId = @applicationId))
    BEGIN
        INSERT dbo.ResourceClaims (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
        VALUES (N'internetAccessDescriptor', N'internetAccessDescriptor', N'http://ed-fi.org/ods/identity/claims/internetAccessDescriptor', @systemDescriptorsResourceClaimId, @applicationId);
    END
    
 
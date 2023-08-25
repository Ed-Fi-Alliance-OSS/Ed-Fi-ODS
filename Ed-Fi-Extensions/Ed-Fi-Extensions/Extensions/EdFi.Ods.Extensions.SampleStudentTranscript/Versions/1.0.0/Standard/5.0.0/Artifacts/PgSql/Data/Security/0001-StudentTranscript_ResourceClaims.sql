-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
declare systemDescriptorsResourceClaimId int;
declare authStrategyId int;
declare postSecondaryOrganizationResourceClaimId int;

begin

SELECT ResourceClaimId into systemDescriptorsResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'systemDescriptors';

INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId    
    )
VALUES (
   'institutionControlDescriptor','http://ed-fi.org/ods/identity/claims/sample-student-transcript/institutionControlDescriptor'
    , systemDescriptorsResourceClaimId
    );

INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId)
VALUES (
    'institutionLevelDescriptor','http://ed-fi.org/ods/identity/claims/sample-student-transcript/institutionLevelDescriptor'
    , systemDescriptorsResourceClaimId );

INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId)
VALUES (
    'specialEducationGraduationStatusDescriptor','http://ed-fi.org/ods/identity/claims/sample-student-transcript/specialEducationGraduationStatusDescriptor'
    , systemDescriptorsResourceClaimId );

INSERT INTO dbo.ResourceClaims (
     ResourceName, ClaimName
    ,ParentResourceClaimId )
VALUES (
    'submissionCertificationDescriptor','http://ed-fi.org/ods/identity/claims/sample-student-transcript/submissionCertificationDescriptor'
    , systemDescriptorsResourceClaimId  );

INSERT INTO dbo.ResourceClaims (
     ResourceName, ClaimName
    ,ParentResourceClaimId )
VALUES (
    'postSecondaryOrganization','http://ed-fi.org/ods/identity/claims/sample-student-transcript/postSecondaryOrganization'
    , null);

--Setup Authorization Strategy
SELECT AuthorizationStrategyId INTO authStrategyId
FROM dbo.AuthorizationStrategies
WHERE AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

SELECT ResourceClaimId INTO postSecondaryOrganizationResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'postSecondaryOrganization';

INSERT INTO dbo.ResourceClaimActions (
    ResourceClaimId
    ,ActionId
    ,ValidationRuleSetName
    )
SELECT ResourceClaimId, a.ActionId, null
FROM dbo.ResourceClaims
INNER JOIN LATERAL (
    SELECT ActionId
    FROM dbo.Actions
    WHERE ActionName IN ('Create', 'Read', 'Update', 'Delete', 'ReadChanges')) AS a ON true
WHERE ResourceClaimId = postSecondaryOrganizationResourceClaimId;

INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies (
    ResourceClaimActionId
    ,AuthorizationStrategyId
    )
SELECT ResourceClaimActionId, authStrategyId
FROM dbo.ResourceClaimActions rca
INNER JOIN dbo.ResourceClaims rc
    ON rca.ResourceClaimId = rc.ResourceClaimId
INNER JOIN dbo.Actions a
    ON rca.ActionId = a.Actionid
        AND a.ActionName IN ('Create','Read','Update','Delete','ReadChanges')
WHERE rc.ResourceClaimId = postSecondaryOrganizationResourceClaimId;

--Add to SIS Vendor and Ed-Fi Sandbox claim sets
INSERT INTO dbo.ClaimSetResourceClaimActions (ClaimSetId, ResourceClaimId, ActionId)
SELECT ClaimSetId
    ,ResourceClaimId
    ,ActionId
FROM dbo.ClaimSets c
    ,dbo.ResourceClaims r
    ,dbo.Actions a
WHERE r.ResourceName = 'postSecondaryOrganization'
    AND (
        c.ClaimSetName = 'SIS Vendor'
        OR c.ClaimSetName = 'Ed-Fi Sandbox'
        )
    AND NOT EXISTS (
        SELECT 1
        FROM dbo.ClaimSetResourceClaimActions csrca
        WHERE csrca.ActionId = a.ActionId
            AND csrca.ClaimSetId = c.ClaimSetId
                 AND csrca.ResourceClaimId = r.ResourceClaimId
        );

end $$
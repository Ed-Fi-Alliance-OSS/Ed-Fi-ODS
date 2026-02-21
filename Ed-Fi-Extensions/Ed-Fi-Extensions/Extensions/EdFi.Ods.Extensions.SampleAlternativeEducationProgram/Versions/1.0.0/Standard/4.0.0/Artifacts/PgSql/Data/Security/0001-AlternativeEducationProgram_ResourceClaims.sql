-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
declare relationshipBasedDataResourceClaimId int;
declare systemDescriptorsResourceClaimId int;

begin

SELECT ResourceClaimId into systemDescriptorsResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'systemDescriptors'

INSERT INTO dbo.ResourceClaims (
    ResourceName
    ,ClaimName
    ,ParentResourceClaimId)
VALUES (
    'alternativeEducationEligibilityReasonDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample-alternative-education-program/alternativeEducationEligibilityReasonDescriptor'
    , systemDescriptorsResourceClaimId
    );


SELECT ResourceClaimId into relationshipBasedDataResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'relationshipBasedData';

INSERT INTO dbo.ResourceClaims (
    ResourceName
    ,ClaimName
    ,ParentResourceClaimId)
VALUES (
    'studentAlternativeEducationProgramAssociation'
    , 'http://ed-fi.org/ods/identity/claims/sample-alternative-education-program/studentAlternativeEducationProgramAssociation'
    , relationshipBasedDataResourceClaimId
    );

end $$
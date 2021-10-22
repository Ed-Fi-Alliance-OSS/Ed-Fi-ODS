-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
declare appId int;
declare relationshipBasedDataResourceClaimId int;

begin

SELECT ApplicationId into appId
FROM dbo.Applications
WHERE ApplicationName = 'Ed-Fi ODS API';

SELECT ResourceClaimId into relationshipBasedDataResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'relationshipBasedData';

INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'studentTransportation'
    , 'studentTransportation'
    , 'http://ed-fi.org/ods/identity/claims/sample-student-transportation/studentTransportation'
    , relationshipBasedDataResourceClaimId
    , appId
    );

end $$
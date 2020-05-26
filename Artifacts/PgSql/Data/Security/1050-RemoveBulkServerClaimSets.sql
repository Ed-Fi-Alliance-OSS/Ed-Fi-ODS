-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do $$
begin
    if exists(select count(ResourceClaimId) from dbo.ResourceClaims
    where ResourceName in ('bulk', 'bulkOperation', 'bulkOperationException', 'upload'))
    then
        delete from dbo.ResourceClaimAuthorizationMetadatas
        where ResourceClaim_ResourceClaimId in 
        (select ResourceClaimId from dbo.ResourceClaims
        where ResourceName in ('bulk', 'bulkOperation', 'bulkOperationException', 'upload'));

        delete from dbo.ClaimSetResourceClaims
        where ResourceClaim_ResourceClaimId in (
        select ResourceClaimId from dbo.ResourceClaims
        where ResourceName in ('bulk', 'bulkOperation', 'bulkOperationException', 'upload'));

        delete from dbo.ResourceClaims
        where ResourceName in ('bulk', 'bulkOperation', 'bulkOperationException', 'upload');
    end if;
end $$



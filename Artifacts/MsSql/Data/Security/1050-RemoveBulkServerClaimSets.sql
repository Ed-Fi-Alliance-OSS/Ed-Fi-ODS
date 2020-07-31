-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS(SELECT COUNT(ResourceClaimId) FROM dbo.ResourceClaims
WHERE ResourceName IN ('bulk', 'bulkOperation', 'bulkOperationException', 'upload'))
BEGIN
	DELETE FROM dbo.ResourceClaimAuthorizationMetadatas
	WHERE ResourceClaim_ResourceClaimId IN 
	(SELECT ResourceClaimId FROM dbo.ResourceClaims
	WHERE ResourceName IN ('bulk', 'bulkOperation', 'bulkOperationException', 'upload'));

	DELETE FROM dbo.ClaimSetResourceClaims
	WHERE ResourceClaim_ResourceClaimId in (
	SELECT ResourceClaimId FROM dbo.ResourceClaims
	WHERE ResourceName IN ('bulk', 'bulkOperation', 'bulkOperationException', 'upload'));

	DELETE FROM dbo.ResourceClaims
	WHERE ResourceName IN ('bulk', 'bulkOperation', 'bulkOperationException', 'upload');
END
GO

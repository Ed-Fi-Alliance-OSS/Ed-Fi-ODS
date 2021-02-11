-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DECLARE @claim_Name NVARCHAR(MAX) = 'http://ed-fi.org/ods/identity/claims/domains/educationOrganizations';
DECLARE @educationOrganizationsResourceClaimId INT;
DECLARE @claimSet_Id INT;
DECLARE @claimSet_Name NVARCHAR(MAX) = 'Bootstrap Descriptors and EdOrgs';
DECLARE @msg NVARCHAR(MAX);
IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = @claim_Name)    
BEGIN
	SET @msg = 'ClaimName does not exist';
    THROW 50000, @msg, 1
END

IF NOT EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = @claimSet_Name)    
BEGIN
   SET @msg = 'ClaimSetName does not exist';
   THROW 50000, @msg, 1
END

IF  EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = @claim_Name)    
BEGIN
	SELECT	@educationOrganizationsResourceClaimId = ResourceClaimId
	FROM	dbo.ResourceClaims rc
	WHERE	rc.ClaimName = @claim_Name
END

IF  EXISTS (SELECT 1 FROM dbo.ClaimSets WHERE ClaimSetName = @claimSet_Name)    
BEGIN
	SELECT	@claimSet_Id = claimSetId
	FROM	dbo.ClaimSets rc
	WHERE	rc.ClaimSetName = @claimSet_Name
END


DELETE FROM dbo.ClaimSetResourceClaims 
WHERE  ClaimSetResourceClaimId IN (SELECT ClaimSetResourceClaimId
FROM   dbo.ClaimSetResourceClaims csrc
WHERE  csrc.ClaimSet_ClaimSetId = @claimSet_Id
AND csrc.ResourceClaim_ResourceClaimId IN 
(SELECT  ResourceClaimId
FROM	dbo.ResourceClaims rc
WHERE	rc.ParentResourceClaimId = @educationOrganizationsResourceClaimId))
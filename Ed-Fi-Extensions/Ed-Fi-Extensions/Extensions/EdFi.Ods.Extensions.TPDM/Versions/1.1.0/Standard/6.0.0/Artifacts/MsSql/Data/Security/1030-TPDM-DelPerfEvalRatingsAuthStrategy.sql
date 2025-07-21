-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Renamed from 1030-TPDM-DeletePerformanceEvaluationRatingsAuthorizationStrategy.sql to shorten file name.

DECLARE 
	@claimId AS INT,
	@parentResourceClaimId  AS INT,
	@claimName AS nvarchar(max)	

SET @claimName = 'http://ed-fi.org/ods/identity/claims/tpdm/performanceEvaluationRating'

SELECT @claimId = ResourceClaimId,
@parentResourceClaimId = ParentResourceClaimId
FROM dbo.ResourceClaims 
WHERE ClaimName = @claimName

IF EXISTS (SELECT 1 FROM dbo.ResourceClaims rc
    INNER JOIN dbo.ResourceClaimActions rca on rca.ResourceClaimId = rc.ResourceClaimId
    INNER JOIN dbo.ResourceClaimActionAuthorizationStrategies rcaas on rcaas.ResourceClaimActionId = rca.ResourceClaimActionId
    WHERE rc.ResourceClaimId = @parentResourceClaimId)
BEGIN
	-- Setting default authorization metadata
	IF EXISTS (SELECT 1 FROM dbo.ResourceClaims rc
    INNER JOIN dbo.ResourceClaimActions rca on rca.ResourceClaimId = rc.ResourceClaimId
    INNER JOIN dbo.ResourceClaimActionAuthorizationStrategies rcaas on rcaas.ResourceClaimActionId = rca.ResourceClaimActionId
    WHERE rc.ResourceClaimId = @claimId)
	BEGIN
		PRINT 'Deleting default action authorizations for resource claim ''' + @claimName + ''' (claimId=' + CONVERT(nvarchar, @claimId) + ').'
		DELETE rcaas
		FROM dbo.ResourceClaims rc
		JOIN dbo.ResourceClaimActions rca on rca.ResourceClaimId = rc.ResourceClaimId
		JOIN dbo.ResourceClaimActionAuthorizationStrategies rcaas on rcaas.ResourceClaimActionId = rca.ResourceClaimActionId
		WHERE rc.ResourceClaimId = @claimId
	END
END
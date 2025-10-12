USE EdFi_Security
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetClaimSetResourceClaimActionAuthorizationStrategyOverrides')
	DROP FUNCTION dbo.GetClaimSetResourceClaimActionAuthorizationStrategyOverrides
GO

CREATE FUNCTION dbo.GetClaimSetResourceClaimActionAuthorizationStrategyOverrides (@ClaimSetResourceClaimActionId INT) RETURNS XML AS
BEGIN
	RETURN
		(select 
			strat.AuthorizationStrategyName AS "@name"
		from dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides strats
			inner join dbo.AuthorizationStrategies strat
				on strats.AuthorizationStrategyId = strat.AuthorizationStrategyId
		where strats.ClaimSetResourceClaimActionId = @ClaimSetResourceClaimActionId
		order by strat.AuthorizationStrategyName
		FOR XML PATH ('AuthorizationStrategy'))
END
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetClaimSetActionWithOverrides')
	DROP FUNCTION dbo.GetClaimSetActionWithOverrides
GO

CREATE FUNCTION dbo.GetClaimSetActionWithOverrides (@ClaimSetId INT, @ResourceClaimId INT) RETURNS XML AS
BEGIN
	RETURN
		(select 
			a.ActionName AS "@name", 
			csrca.ValidationRuleSetNameOverride AS "@validationRuleSetOverride",
			dbo.GetClaimSetResourceClaimActionAuthorizationStrategyOverrides(csrca.ClaimSetResourceClaimActionId) as AuthorizationStrategyOverrides
		from dbo.ClaimSetResourceClaimActions csrca
			inner join dbo.Actions a
				on csrca.ActionId = a.ActionId
		where csrca.ResourceClaimId = @ResourceClaimId
			and csrca.ClaimSetId = @ClaimSetId
		order by a.ActionId
		FOR XML PATH ('Action'))
	END
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.VIEWS v WHERE v.TABLE_SCHEMA ='dbo' AND v.TABLE_NAME = 'ClaimSetResource')
	DROP VIEW dbo.ClaimSetResource
GO

CREATE VIEW dbo.ClaimSetResource AS
	SELECT DISTINCT csrca.ResourceClaimId as ResourceClaimId, cs.ClaimSetId, cs.ClaimSetName
	FROM dbo.ClaimSetResourceClaimActions csrca
		inner join dbo.ClaimSets cs
			on csrca.ClaimSetId = cs.ClaimSetId
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetClaimSetWithActions')
	DROP FUNCTION dbo.GetClaimSetWithActions
GO

CREATE FUNCTION dbo.GetClaimSetWithActions (@ResourceClaimId INT) RETURNS XML AS
BEGIN
	RETURN
	(
		SELECT
			x.ClaimSetName as "@name",
			dbo.GetClaimSetActionWithOverrides(x.ClaimSetId, @ResourceClaimId) as Actions
		FROM ClaimSetResource x
		WHERE x.ResourceClaimId = @ResourceClaimId
		FOR XML PATH ('ClaimSet')
	)
END
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetResourceClaimActionAuthorizationStrategies')
	DROP FUNCTION dbo.GetResourceClaimActionAuthorizationStrategies
GO

CREATE FUNCTION dbo.GetResourceClaimActionAuthorizationStrategies (@ResourceClaimActionId INT) RETURNS XML AS
BEGIN
	RETURN
		(select 
			strat.AuthorizationStrategyName AS "@name"
		from dbo.ResourceClaimActionAuthorizationStrategies strats
			inner join dbo.AuthorizationStrategies strat
				on strats.AuthorizationStrategyId = strat.AuthorizationStrategyId
		where strats.ResourceClaimActionId = @ResourceClaimActionId
		order by strat.AuthorizationStrategyName
		FOR XML PATH ('AuthorizationStrategy'))
END
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetResourceClaimAction')
	DROP FUNCTION dbo.GetResourceClaimAction
GO

CREATE FUNCTION dbo.GetResourceClaimAction (@ResourceClaimId INT) RETURNS XML AS
BEGIN
	RETURN
		(select 
			a.ActionName AS "@name", 
			meta.ValidationRuleSetName AS "@validationRuleSet",
			dbo.GetResourceClaimActionAuthorizationStrategies(meta.ResourceClaimActionId) as AuthorizationStrategies
		from dbo.ResourceClaimActions meta
			inner join dbo.Actions a
				on meta.ActionId = a.ActionId
		where meta.ResourceClaimId = @ResourceClaimId
		order by a.ActionId
		FOR XML PATH ('Action'))
END
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetResourceClaim')
	DROP FUNCTION dbo.GetResourceClaim
GO

CREATE FUNCTION dbo.GetResourceClaim (@ParentResourceClaimId INT) RETURNS XML AS
BEGIN 
	RETURN
		(SELECT 
			Claim.ResourceClaimId as "@claimId", 
			Claim.ClaimName as "@name",
			dbo.GetResourceClaimAction(Claim.ResourceClaimId) as DefaultAuthorization,
			dbo.GetClaimSetWithActions(Claim.ResourceClaimId) as ClaimSets,
			dbo.GetResourceClaim(Claim.ResourceClaimId) AS Claims
		FROM dbo.ResourceClaims Claim

		WHERE Claim.ParentResourceClaimId = @ParentResourceClaimId
		FOR XML PATH ('Claim'))
END;
GO

IF EXISTS ( SELECT * FROM INFORMATION_SCHEMA.ROUTINES r WHERE r.ROUTINE_SCHEMA ='dbo' AND r.ROUTINE_NAME = 'GetAuthorizationMetadataDocument')
	DROP FUNCTION dbo.GetAuthorizationMetadataDocument
GO

CREATE FUNCTION dbo.GetAuthorizationMetadataDocument() RETURNS XML AS
BEGIN
	DECLARE @claims XML
	
    SELECT @claims = (
		SELECT
            Claim.ClaimName as "@name",
            dbo.GetResourceClaimAction(Claim.ResourceClaimId) as DefaultAuthorization,
            dbo.GetClaimSetWithActions(Claim.ResourceClaimId) as ClaimSets,
            dbo.GetResourceClaim(Claim.ResourceClaimId) AS Claims
        FROM dbo.ResourceClaims Claim
        WHERE Claim.ParentResourceClaimId IS NULL
        FOR XML PATH ('Claim')
	);
    
	RETURN (
		SELECT @claims
		FOR XML PATH ('Claims'), ROOT ('SecurityMetadata')
	);
END

GO

SELECT dbo.GetAuthorizationMetadataDocument();

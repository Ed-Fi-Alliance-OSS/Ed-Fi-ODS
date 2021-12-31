  --Client 1 should be able to full CRUD their School 1.
  --Derived Resource -Client 1 has full CRUD - School 1
  --Client 2 should be able to full CRUD School 2.
  --Derived Resource -Client 2 has full CRUD - School 2
  --Assuming Client 2 is assigned the extra ownership token, it should also be able to full CRUD School 1. 
  --But Client 1, without the assignment to Ownership Token 2, should not be able to CRUD School 2.

use EdFi_Admin_Test
GO

INSERT INTO [dbo].[OwnershipTokens] ([Description])     VALUES  ('OwnershipToken_One')
INSERT INTO [dbo].[OwnershipTokens] ([Description])     VALUES  ('OwnershipToken_Two')

DECLARE @ApiClient_ApiClientId INT;
DECLARE @OwnershipToken_OwnershipTokenId INT;
SELECT @ApiClient_ApiClientId = ApiClientId FROM [dbo].[ApiClients] where Name in ('255901001')

SELECT @OwnershipToken_OwnershipTokenId = OwnershipTokenId FROM [dbo].[OwnershipTokens] where [Description] in ('OwnershipToken_One')
INSERT INTO [dbo].[ApiClientOwnershipTokens]([ApiClient_ApiClientId],[OwnershipToken_OwnershipTokenId]) VALUES (@ApiClient_ApiClientId,@OwnershipToken_OwnershipTokenId)

UPDATE [dbo].[ApiClients]
   SET CreatorOwnershipTokenId_OwnershipTokenId = @OwnershipToken_OwnershipTokenId
 WHERE ApiClientId =@ApiClient_ApiClientId


SELECT @ApiClient_ApiClientId = ApiClientId FROM [dbo].[ApiClients] where Name in ('255901044')
INSERT INTO [dbo].[ApiClientOwnershipTokens]([ApiClient_ApiClientId],[OwnershipToken_OwnershipTokenId]) VALUES (@ApiClient_ApiClientId,@OwnershipToken_OwnershipTokenId)

SELECT @OwnershipToken_OwnershipTokenId = OwnershipTokenId FROM [dbo].[OwnershipTokens] where [Description] in ('OwnershipToken_Two')
INSERT INTO [dbo].[ApiClientOwnershipTokens]([ApiClient_ApiClientId],[OwnershipToken_OwnershipTokenId]) VALUES (@ApiClient_ApiClientId,@OwnershipToken_OwnershipTokenId)

UPDATE [dbo].[ApiClients]
   SET CreatorOwnershipTokenId_OwnershipTokenId = @OwnershipToken_OwnershipTokenId
 WHERE ApiClientId =@ApiClient_ApiClientId


SELECT CreatorOwnershipTokenId_OwnershipTokenId,*  FROM [dbo].[ApiClients]  where Name in ('255901044','255901001')
SELECT *  FROM [dbo].[ApiClientOwnershipTokens] where ApiClient_ApiClientId in ( SELECT ApiClientId  FROM [dbo].[ApiClients]  where Name in ('255901044','255901001'))
SELECT *  FROM [dbo].[OwnershipTokens] where [Description] in ('OwnershipToken_One','OwnershipToken_Two')

USE [EdFi_Security_Test]
Go

DECLARE @AuthorizationStrategyId INT;

INSERT INTO [dbo].[AuthorizationStrategies]   ([DisplayName],[AuthorizationStrategyName],[Application_ApplicationId]) VALUES ('Ownership Based','OwnershipBased', 1)

SELECT @AuthorizationStrategyId=AuthorizationStrategyId from [dbo].[AuthorizationStrategies] where [AuthorizationStrategyName]='OwnershipBased'


 --education organization resource claims for read update and delete
 INSERT INTO  [dbo].[ResourceClaimActionAuthorizationStrategies]
 ([ResourceClaimActionId],[AuthorizationStrategyId]) 
 SELECT ResourceClaimActionId,@AuthorizationStrategyId  FROM [dbo].ResourceClaimActions rca 
INNER JOIN  [dbo].ResourceClaims rc  on rca.ResourceClaimId = rc.ResourceClaimId
AND ClaimName='http://ed-fi.org/ods/identity/claims/domains/educationOrganizations'
INNER JOIN  [dbo].Actions a  on a.ActionId= rca.ActionId 
AND a.ActionName in ('Read','Update','Delete')

 --studentSectionAssociation resource claims for read update and delete
 INSERT INTO [dbo].[ResourceClaimActions]
 ([ResourceClaimId],[ActionId])
 SELECT ResourceClaimId,ActionId  FROM [dbo].ResourceClaims ,  [dbo].Actions 
WHERE ActionName in ('Read','Update','Delete')
 AND ClaimName='http://ed-fi.org/ods/identity/claims/studentSectionAssociation'
 

  INSERT INTO  [dbo].[ResourceClaimActionAuthorizationStrategies]
 ([ResourceClaimActionId],[AuthorizationStrategyId]) 
 SELECT ResourceClaimActionId,@AuthorizationStrategyId  FROM [dbo].ResourceClaimActions rca 
INNER JOIN  [dbo].ResourceClaims rc  on rca.ResourceClaimId = rc.ResourceClaimId
AND ClaimName='http://ed-fi.org/ods/identity/claims/studentSectionAssociation'
INNER JOIN  [dbo].Actions a  on a.ActionId= rca.ActionId 
AND a.ActionName in ('Read','Update','Delete')

SELECT *  FROM [dbo].ResourceClaimActionAuthorizationStrategies 
where  ResourceClaimActionId in (SELECT ResourceClaimActionId  FROM [dbo].ResourceClaimActions 
where ResourceClaimId  in (SELECT ResourceClaimId  FROM [dbo].ResourceClaims
where ClaimName in ('http://ed-fi.org/ods/identity/claims/domains/educationOrganizations','http://ed-fi.org/ods/identity/claims/studentSectionAssociation')))
AND AuthorizationStrategyId =8
order by AuthorizationStrategyId


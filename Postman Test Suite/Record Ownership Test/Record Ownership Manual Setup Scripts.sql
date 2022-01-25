   --Client 1 should be able to full CRUD their School 1.
  --Resource -Client 1 has full CRUD - School 1
  --Client 2 should be able to full CRUD School 2.
  -- Resource -Client 2 has full CRUD - School 2
  --Assuming Client 2 is assigned the extra ownership token, it should also be able to full CRUD School 1. 
  --But Client 1, without the assignment to Ownership Token 2, should not be able to CRUD School 2.

USE EdFi_Admin_Test
GO

INSERT INTO [dbo].[OwnershipTokens] ([Description])     VALUES  ('OwnershipToken_One')
INSERT INTO [dbo].[OwnershipTokens] ([Description])     VALUES  ('OwnershipToken_Two')

DECLARE @ApiClient_ApiClientId_One INT;
DECLARE @ApiClient_ApiClientId_Two INT;
DECLARE @OwnershipToken_OwnershipTokenId_One INT;
DECLARE @OwnershipToken_OwnershipTokenId_Two INT;
SELECT @ApiClient_ApiClientId_One = ApiClientId FROM [dbo].[ApiClients] where Name in ('255901-A');

SELECT @OwnershipToken_OwnershipTokenId_One = OwnershipTokenId FROM [dbo].[OwnershipTokens] where [Description] in ('OwnershipToken_One')
INSERT INTO [dbo].[ApiClientOwnershipTokens]([ApiClient_ApiClientId],[OwnershipToken_OwnershipTokenId]) VALUES (@ApiClient_ApiClientId_One,@OwnershipToken_OwnershipTokenId_One)

UPDATE [dbo].[ApiClients]
   SET CreatorOwnershipTokenId_OwnershipTokenId = @OwnershipToken_OwnershipTokenId_One
 WHERE ApiClientId =@ApiClient_ApiClientId_One


SELECT @ApiClient_ApiClientId_Two = ApiClientId FROM [dbo].[ApiClients] where Name in ('255901-B');
INSERT INTO [dbo].[ApiClientOwnershipTokens]([ApiClient_ApiClientId],[OwnershipToken_OwnershipTokenId]) VALUES (@ApiClient_ApiClientId_Two,@OwnershipToken_OwnershipTokenId_One)

SELECT @OwnershipToken_OwnershipTokenId_Two = OwnershipTokenId FROM [dbo].[OwnershipTokens] where [Description] in ('OwnershipToken_Two')
INSERT INTO [dbo].[ApiClientOwnershipTokens]([ApiClient_ApiClientId],[OwnershipToken_OwnershipTokenId]) VALUES (@ApiClient_ApiClientId_Two,@OwnershipToken_OwnershipTokenId_Two)

UPDATE [dbo].[ApiClients]
   SET CreatorOwnershipTokenId_OwnershipTokenId = @OwnershipToken_OwnershipTokenId_Two
 WHERE ApiClientId =@ApiClient_ApiClientId_Two

USE [EdFi_Security_Test]
Go

DECLARE @OwnershipBasedAuthorizationStrategyId INT;

SELECT @OwnershipBasedAuthorizationStrategyId=  AuthorizationStrategyId FROM [dbo].[AuthorizationStrategies]
WHERE [AuthorizationStrategyName]='OwnershipBased';

 --education organization resource claims for read update and delete
 INSERT INTO  [dbo].[ResourceClaimActionAuthorizationStrategies]
 ([ResourceClaimActionId],[AuthorizationStrategyId]) 
 SELECT ResourceClaimActionId,@OwnershipBasedAuthorizationStrategyId  FROM [dbo].ResourceClaimActions rca 
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
 SELECT ResourceClaimActionId,@OwnershipBasedAuthorizationStrategyId  FROM [dbo].ResourceClaimActions rca 
INNER JOIN  [dbo].ResourceClaims rc  on rca.ResourceClaimId = rc.ResourceClaimId
AND ClaimName='http://ed-fi.org/ods/identity/claims/studentSectionAssociation'
INNER JOIN  [dbo].Actions a  on a.ActionId= rca.ActionId 
AND a.ActionName in ('Read','Update','Delete')

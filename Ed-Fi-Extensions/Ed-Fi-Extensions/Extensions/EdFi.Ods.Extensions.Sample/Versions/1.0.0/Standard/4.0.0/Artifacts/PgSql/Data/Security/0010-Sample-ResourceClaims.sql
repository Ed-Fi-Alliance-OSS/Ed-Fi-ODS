do $$
declare appId int;
declare systemDescriptorsResourceClaimId int;
declare relationshipBasedDataResourceClaimId int;
declare educationOrganizationsResourceClaimId int;
declare authStrategyId int;

begin

SELECT ApplicationId into appId
FROM dbo.Applications
WHERE ApplicationName = 'Ed-Fi ODS API';

SELECT ResourceClaimId into systemDescriptorsResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'systemDescriptors';

SELECT ResourceClaimId into relationshipBasedDataResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'relationshipBasedData';

SELECT ResourceClaimId into educationOrganizationsResourceClaimId
FROM dbo.ResourceClaims
WHERE ResourceName = 'educationOrganizations';

INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'artMediumDescriptor'
    , 'artMediumDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/artMediumDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );
	
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'favoriteBookCategoryDescriptor'
    , 'favoriteBookCategoryDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/favoriteBookCategoryDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );

INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'membershipTypeDescriptor'
    , 'membershipTypeDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/membershipTypeDescriptor'
    , systemDescriptorsResourceClaimId
    , appId
    );
	
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'bus'
    , 'bus'
    , 'http://ed-fi.org/ods/identity/claims/sample/bus'
    , educationOrganizationsResourceClaimId
    , appId
    );
	
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'busRoute'
    , 'busRoute'
    , 'http://ed-fi.org/ods/identity/claims/sample/busRoute'
    , educationOrganizationsResourceClaimId
    , appId
    );
	
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'studentArtProgramAssociation'
    , 'studentArtProgramAssociation'
    , 'http://ed-fi.org/ods/identity/claims/sample/studentArtProgramAssociation'
    , relationshipBasedDataResourceClaimId
    , appId
    );
	
INSERT INTO dbo.ResourceClaims (
    DisplayName
    ,ResourceName
    ,ClaimName
    ,ParentResourceClaimId
    ,Application_ApplicationId
    )
VALUES (
    'studentGraduationPlanAssociation'
    , 'studentGraduationPlanAssociation'
    , 'http://ed-fi.org/ods/identity/claims/sample/studentGraduationPlanAssociation'
    , relationshipBasedDataResourceClaimId
    , appId
    );


select AuthorizationStrategyId into authStrategyId from dbo.AuthorizationStrategies where AuthorizationStrategyName = 'NoFurtherAuthorizationRequired';

--- These Resources need explicit metadata ---
    INSERT INTO dbo.ResourceClaimActions(ResourceClaimId, ActionId)
    SELECT   ResourceClaimId, ac.ActionId
    from dbo.ResourceClaims
    inner join lateral
        (select ActionId
        from dbo.Actions
        where ActionName in ('Create', 'Read', 'Update', 'Delete')) as ac on true
    where ResourceName in ('studentGraduationPlanAssociation', 'studentArtProgramAssociation');



    INSERT INTO dbo.ResourceClaimActionAuthorizationStrategies(ResourceClaimActionId, AuthorizationStrategyId)
    select resourceClaimActionId,authStrategyId from dbo.ResourceClaimActions RCA
    INNER JOIN dbo.ResourceClaims  RC   ON RC.ResourceClaimId = RCA.ResourceClaimId
    INNER JOIN dbo.Actions  A  ON A.ActionId = RCA.ActionId
    WHERE A.ActionName IN ('Create', 'Read', 'Update', 'Delete')
    AND  RC.ResourceName IN ('studentArtProgramAssociation', 'studentGraduationPlanAssociation');

end $$
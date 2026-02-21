do $$

declare systemDescriptorsResourceClaimId int;
declare relationshipBasedDataResourceClaimId int;
declare educationOrganizationsResourceClaimId int;
declare authStrategyId int;

begin





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
    ResourceName, ClaimName
    ,ParentResourceClaimId
    )
VALUES (
    'artMediumDescriptor','http://ed-fi.org/ods/identity/claims/sample/artMediumDescriptor'
    , systemDescriptorsResourceClaimId
    );
	
INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId
    )
VALUES (
    'favoriteBookCategoryDescriptor','http://ed-fi.org/ods/identity/claims/sample/favoriteBookCategoryDescriptor'
    , systemDescriptorsResourceClaimId
    );

INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId
    )
VALUES (
    'membershipTypeDescriptor'
    , 'http://ed-fi.org/ods/identity/claims/sample/membershipTypeDescriptor'
    , systemDescriptorsResourceClaimId
    );
	
INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId
    )
VALUES (
    'bus',
    'http://ed-fi.org/ods/identity/claims/sample/bus'
    , educationOrganizationsResourceClaimId
    );
	
INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId
    )
VALUES (
    'busRoute','http://ed-fi.org/ods/identity/claims/sample/busRoute'
    , educationOrganizationsResourceClaimId
    );
	
INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId
    )
VALUES (
    'studentArtProgramAssociation', 'http://ed-fi.org/ods/identity/claims/sample/studentArtProgramAssociation'
    , relationshipBasedDataResourceClaimId );
	
INSERT INTO dbo.ResourceClaims (
    ResourceName, ClaimName
    ,ParentResourceClaimId  )
VALUES (
    'studentGraduationPlanAssociation','http://ed-fi.org/ods/identity/claims/sample/studentGraduationPlanAssociation'
    , relationshipBasedDataResourceClaimId  );


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
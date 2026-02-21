do $$

declare systemDescriptorsResourceClaimId int;
declare relationshipBasedDataResourceClaimId int;
declare educationOrganizationsResourceClaimId int;
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

INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('name',  'http://ed-fi.org/ods/identity/claims/homograph/name', educationOrganizationsResourceClaimId);
	
INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('school', 'http://ed-fi.org/ods/identity/claims/homograph/school', educationOrganizationsResourceClaimId);
	
INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('parent', 'http://ed-fi.org/ods/identity/claims/homograph/parent', educationOrganizationsResourceClaimId);
	
INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('student', 'http://ed-fi.org/ods/identity/claims/homograph/student', educationOrganizationsResourceClaimId);	

INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('staff', 'http://ed-fi.org/ods/identity/claims/homograph/staff', educationOrganizationsResourceClaimId);	
		
INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('schoolYearType','http://ed-fi.org/ods/identity/claims/homograph/schoolYearType', educationOrganizationsResourceClaimId);
	
INSERT INTO dbo.ResourceClaims
    (ResourceName, ClaimName, ParentResourceClaimId)
VALUES
    ('studentSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/homograph/studentSchoolAssociation', educationOrganizationsResourceClaimId);	

end $$
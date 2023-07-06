do $$
declare appId int;
declare systemDescriptorsResourceClaimId int;
declare relationshipBasedDataResourceClaimId int;
declare educationOrganizationsResourceClaimId int;
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

INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('name', 'name', 'http://ed-fi.org/ods/identity/claims/homograph/name', educationOrganizationsResourceClaimId, appId);
	
INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('school', 'school', 'http://ed-fi.org/ods/identity/claims/homograph/school', educationOrganizationsResourceClaimId, appId);
	
INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('contact', 'contact', 'http://ed-fi.org/ods/identity/claims/homograph/contact', educationOrganizationsResourceClaimId, appId);
	
INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('student', 'student', 'http://ed-fi.org/ods/identity/claims/homograph/student', educationOrganizationsResourceClaimId, appId);	

INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('staff', 'staff', 'http://ed-fi.org/ods/identity/claims/homograph/staff', educationOrganizationsResourceClaimId, appId);	
		
INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('schoolYearType', 'schoolYearType', 'http://ed-fi.org/ods/identity/claims/homograph/schoolYearType', educationOrganizationsResourceClaimId, appId);
	
INSERT INTO dbo.ResourceClaims
    (DisplayName, ResourceName, ClaimName, ParentResourceClaimId, Application_ApplicationId)
VALUES
    ('studentSchoolAssociation', 'studentSchoolAssociation', 'http://ed-fi.org/ods/identity/claims/homograph/studentSchoolAssociation', educationOrganizationsResourceClaimId, appId);	

end $$
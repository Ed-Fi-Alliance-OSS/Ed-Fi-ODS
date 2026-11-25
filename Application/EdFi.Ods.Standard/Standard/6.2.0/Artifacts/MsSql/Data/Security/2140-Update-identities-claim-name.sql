-- Move identities to a separate "services" segment to delineate from data management resources

IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE  ClaimName = 'http://ed-fi.org/ods/identity/claims/services/identity')
BEGIN

update dbo.ResourceClaims
set ClaimName = 'http://ed-fi.org/ods/identity/claims/services/identity'
where ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/identity'

END
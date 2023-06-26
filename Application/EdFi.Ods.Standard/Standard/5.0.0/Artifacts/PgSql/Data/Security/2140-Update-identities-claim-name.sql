-- Move identities to a separate "services" segment to delineate from data management resources
update dbo.ResourceClaims
set ClaimName = 'http://ed-fi.org/ods/identity/claims/services/identity'
where ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/identity'

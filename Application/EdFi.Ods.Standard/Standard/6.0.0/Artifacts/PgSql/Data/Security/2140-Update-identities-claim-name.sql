-- Move identities to a separate "services" segment to delineate from data management resources
DO $$ 
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.ResourceClaims WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/services/identity') THEN
        UPDATE dbo.ResourceClaims
        SET ClaimName = 'http://ed-fi.org/ods/identity/claims/services/identity'
        WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/domains/identity';
    END IF;
END $$;

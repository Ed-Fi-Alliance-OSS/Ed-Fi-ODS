-----------------------------------------------------------------
-- Delete legacy claims that have been replaced with new format
-----------------------------------------------------------------
DELETE FROM dbo.ResourceClaims
WHERE
    LEFT(ClaimName, 37) = 'http://ed-fi.org/ods/identity/claims/'
  AND CHARINDEX('/', SUBSTRING(ClaimName, 38, LEN(ClaimName) - 37)) <= 0
  AND EXISTS (
    SELECT 1
    FROM dbo.ResourceClaims rc
    WHERE ClaimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/' + SUBSTRING(ResourceClaims.ClaimName, 38, LEN(ResourceClaims.ClaimName) - 37)
)
GO

-------------------------------------------------------------
-- Migrate existing Ed-Fi legacy claims to new format
-------------------------------------------------------------
UPDATE dbo.ResourceClaims SET ClaimName = 'http://ed-fi.org/ods/identity/claims/ed-fi/' + SUBSTRING(ClaimName, 38, LEN(ClaimName) - 37)
WHERE LEFT(ClaimName, 37) = 'http://ed-fi.org/ods/identity/claims/' AND CHARINDEX('/', SUBSTRING(ClaimName, 38, LEN(ClaimName) - 37)) <= 0
GO

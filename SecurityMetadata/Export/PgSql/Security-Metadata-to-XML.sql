WITH RECURSIVE claim_hierarchy AS (
    -- Start with top-level claims (no parent)
    SELECT
        rc.ResourceClaimId AS claim_id,
        rc.ClaimName AS claim_name,
        rc.ResourceName AS resource_name,
        rc.ParentResourceClaimId AS parent_claim_id
    FROM
        dbo.ResourceClaims rc
    WHERE
        rc.ParentResourceClaimId IS NULL

    UNION ALL

    -- Recursively join to find all descendants
    SELECT
        rc.ResourceClaimId,
        rc.ClaimName,
        rc.ResourceName,
        rc.ParentResourceClaimId
    FROM
        dbo.ResourceClaims rc
    INNER JOIN
        claim_hierarchy ch ON rc.ParentResourceClaimId = ch.claim_id
)

SELECT xmlelement(
    name "SecurityMetadata",
    xmlelement(
        name "Claims",
        xmlagg(build_claim_hierarchy_xml(claim_id, claim_name, resource_name, parent_claim_id))
    )
) AS security_metadata
FROM claim_hierarchy
WHERE parent_claim_id IS NULL;

------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Helper function to recursively build the hierarchy
CREATE OR REPLACE FUNCTION build_claim_hierarchy_xml(
    claim_id INT,
    claim_name TEXT,
    resource_name TEXT,
    parent_claim_id INT
) RETURNS XML LANGUAGE plpgsql AS $$
DECLARE
    claims XML;
    defaultAuthorization XML;
BEGIN
    -- Find children recursively
    SELECT xmlagg(build_claim_hierarchy_xml(rc.ResourceClaimId, rc.ClaimName, rc.ResourceName, rc.ParentResourceClaimId))
    INTO claims
    FROM dbo.ResourceClaims rc
    WHERE rc.ParentResourceClaimId = claim_id;

    -- Build DefaultAuthorization XML only if there are actions
    SELECT xmlagg(
        xmlelement(
            name "Action",
            xmlattributes(a.ActionName AS "name"),
            CASE
                WHEN EXISTS (
                    SELECT 1
                    FROM dbo.AuthorizationStrategies astrat
                    JOIN dbo.resourceclaimactionauthorizationstrategies ao
                    ON astrat.authorizationstrategyid = ao.authorizationstrategyid
                    WHERE ao.resourceclaimactionid = rca.resourceclaimactionid
                )
                THEN xmlelement(
                    name "AuthorizationStrategies",
                    (
                        SELECT xmlagg(
                            xmlelement(
                                name "AuthorizationStrategy",
                                xmlattributes(astrat.authorizationstrategyname AS "name")
                            )
                        )
                        FROM dbo.AuthorizationStrategies astrat
                        JOIN dbo.resourceclaimactionauthorizationstrategies ao
                            ON astrat.authorizationstrategyid = ao.authorizationstrategyid
                        WHERE ao.resourceclaimactionid = rca.resourceclaimactionid
                    )
                )
                ELSE NULL
            END
        )
    )
    INTO defaultAuthorization
    FROM dbo.Actions a
    JOIN dbo.resourceclaimactions rca ON a.actionid = rca.actionid
    WHERE rca.resourceclaimid = claim_id;

    -- Build the XML structure for this claim
    RETURN xmlelement(
        name "Claim",
        xmlattributes(claim_id AS "claimId", claim_name AS "name"),

        -- Include DefaultAuthorization if not empty
        CASE WHEN defaultAuthorization IS NOT NULL THEN
            xmlelement(name "DefaultAuthorization", defaultAuthorization)
        ELSE NULL END,

        -- Build ClaimSets only if there are claim sets associated with this claim
        CASE WHEN EXISTS (
            SELECT 1 FROM dbo.claimsetresourceclaimactions csrca WHERE csrca.resourceclaimid = claim_id
        ) THEN xmlelement(
            name "ClaimSets",
            (
                SELECT xmlagg(
                    xmlelement(
                        name "ClaimSet",
                        xmlattributes(cs.claimsetname AS "name"),
                        xmlelement(
                            name "Actions",
                            (
                                SELECT xmlagg(
                                    xmlelement(
                                        name "Action",
                                        xmlattributes(a.ActionName AS "name"),
                                        CASE
                                            WHEN EXISTS (
                                                SELECT 1
                                                FROM dbo.AuthorizationStrategies astrat
                                                JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides ao
                                                ON astrat.AuthorizationStrategyId = ao.AuthorizationStrategyId
                                                WHERE ao.ClaimSetResourceClaimActionId = ca.ClaimSetResourceClaimActionId
                                            )
                                            THEN xmlelement(
                                                name "AuthorizationStrategyOverrides",
                                                (
                                                    SELECT xmlagg(
                                                        xmlelement(
                                                            name "AuthorizationStrategy",
                                                            xmlattributes(astrat.authorizationstrategyname AS "name")
                                                        )
                                                    )
                                                    FROM dbo.AuthorizationStrategies astrat
                                                    JOIN dbo.ClaimSetResourceClaimActionAuthorizationStrategyOverrides ao
                                                        ON astrat.AuthorizationStrategyId = ao.AuthorizationStrategyId
                                                    WHERE ao.ClaimSetResourceClaimActionId = ca.ClaimSetResourceClaimActionId
                                                )
                                            )
                                            ELSE NULL
                                        END
                                    )
                                )
                                FROM dbo.Actions a
                                JOIN dbo.ClaimSetResourceClaimActions ca ON a.ActionId = ca.ActionId
                                WHERE ca.claimsetid = csrca.claimsetid
                                    and ca.resourceclaimid = claim_id --resourceclaimactionid
                            )
                        )
                    )
                )
                --FROM dbo.claimsetresourceclaimactions csrca

                FROM (SELECT DISTINCT claimsetid, resourceclaimid FROM dbo.claimsetresourceclaimactions) csrca
                INNER JOIN dbo.claimsets cs ON csrca.claimsetid = cs.claimsetid
                WHERE csrca.resourceclaimid = claim_id
            )
        ) ELSE NULL END,

        -- Include child Claims only if there are any
        CASE WHEN claims IS NOT NULL THEN
            xmlelement(name "Claims", claims)
        ELSE NULL END
    );
END;
$$;

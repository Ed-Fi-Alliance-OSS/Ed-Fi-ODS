-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- edfi.CommunityOrganization
CREATE OR ALTER TRIGGER edfi.edfi_CommunityOrganization_TR_Insert ON edfi.CommunityOrganization AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.CommunityOrganizationId AS SourceEducationOrganizationId, 
            new.CommunityOrganizationId AS TargetEducationOrganizationId
    FROM    inserted new;

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_CommunityOrganization_TR_Delete ON edfi.CommunityOrganization AFTER DELETE AS
BEGIN
    SET NOCOUNT ON


        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.CommunityOrganizationId
                    AND TargetEducationOrganizationId = old.CommunityOrganizationId

END
GO

-- edfi.CommunityProvider
CREATE OR ALTER TRIGGER edfi.edfi_CommunityProvider_TR_Insert ON edfi.CommunityProvider AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.CommunityProviderId AS SourceEducationOrganizationId, 
            new.CommunityProviderId AS TargetEducationOrganizationId
    FROM    inserted new;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the CommunityOrganizationId
        SELECT  tuples.SourceEducationOrganizationId, new.CommunityProviderId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.CommunityOrganizationId = tuples.TargetEducationOrganizationId 
        WHERE   new.CommunityOrganizationId IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  new.CommunityProviderId, tuples.TargetEducationOrganizationId
            FROM    inserted new
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                        ON new.CommunityProviderId = tuples.SourceEducationOrganizationId
        ) as targets
    WHERE sources.CommunityProviderId = targets.CommunityProviderId

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_CommunityProvider_TR_Update ON edfi.CommunityProvider AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON

    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT d1.SourceEducationOrganizationId, d2.TargetEducationOrganizationId
                FROM (
                    -- Find ancestors to be deleted by clearing or changing the CommunityOrganizationId
                    SELECT  tuples.SourceEducationOrganizationId, new.CommunityProviderId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.CommunityProviderId = new.CommunityProviderId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.CommunityOrganizationId = tuples.TargetEducationOrganizationId 
                    WHERE   old.CommunityOrganizationId IS NOT NULL 
                            AND (new.CommunityOrganizationId IS NULL OR old.CommunityOrganizationId <> new.CommunityOrganizationId)
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the CommunityOrganizationId 
                    SELECT  tuples.SourceEducationOrganizationId, new.CommunityProviderId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.CommunityOrganizationId = tuples.TargetEducationOrganizationId 
                    ) AS d1
    
                CROSS JOIN
                    -- Get all the descendants of the CommunityProvider (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.CommunityProviderId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.CommunityProviderId = tuples.SourceEducationOrganizationId
                    ) as d2
                WHERE d1.CommunityProviderId = d2.CommunityProviderId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId target
    USING (
        SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
        FROM    (
                -- Determine the source ancestors affected by this change
    
                    -- Find ancestors to be inserted by initializing or changing the CommunityOrganizationId
                    SELECT  tuples.SourceEducationOrganizationId, new.CommunityProviderId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.CommunityProviderId = old.CommunityProviderId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.CommunityOrganizationId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.CommunityOrganizationId IS NULL AND new.CommunityOrganizationId IS NOT NULL)
                            OR old.CommunityOrganizationId <> new.CommunityOrganizationId
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the CommunityProvider (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.CommunityProviderId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.CommunityProviderId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE
                    sources.CommunityProviderId = targets.CommunityProviderId
        ) AS source
        ON target.SourceEducationOrganizationId = source.SourceEducationOrganizationId 
            AND target.TargetEducationOrganizationId = source.TargetEducationOrganizationId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT(SourceEducationOrganizationId, TargetEducationOrganizationId)
        VALUES(source.SourceEducationOrganizationId, source.TargetEducationOrganizationId);

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_CommunityProvider_TR_Delete ON edfi.CommunityProvider AFTER DELETE AS
BEGIN
    SET NOCOUNT ON

    -- Remove affected tuples
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
                FROM (
                    -- Determine the source ancestors affected by this change
                    -- Find ancestors to be deleted by clearing or changing the CommunityOrganizationId
                    SELECT  tuples.SourceEducationOrganizationId, old.CommunityProviderId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.CommunityOrganizationId = tuples.TargetEducationOrganizationId 
                    WHERE   old.CommunityOrganizationId IS NOT NULL
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the CommunityProvider (to be cross joined with all the affected ancestor sources)
                    (SELECT tuples.TargetEducationOrganizationId, old.CommunityProviderId
                    FROM    deleted old
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.CommunityProviderId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE sources.CommunityProviderId = targets.CommunityProviderId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;

        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.CommunityProviderId
                    AND TargetEducationOrganizationId = old.CommunityProviderId

END
GO

-- edfi.EducationOrganizationNetwork
CREATE OR ALTER TRIGGER edfi.edfi_EducationOrganizationNetwork_TR_Insert ON edfi.EducationOrganizationNetwork AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.EducationOrganizationNetworkId AS SourceEducationOrganizationId, 
            new.EducationOrganizationNetworkId AS TargetEducationOrganizationId
    FROM    inserted new;

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_EducationOrganizationNetwork_TR_Delete ON edfi.EducationOrganizationNetwork AFTER DELETE AS
BEGIN
    SET NOCOUNT ON


        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.EducationOrganizationNetworkId
                    AND TargetEducationOrganizationId = old.EducationOrganizationNetworkId

END
GO

-- edfi.EducationServiceCenter
CREATE OR ALTER TRIGGER edfi.edfi_EducationServiceCenter_TR_Insert ON edfi.EducationServiceCenter AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.EducationServiceCenterId AS SourceEducationOrganizationId, 
            new.EducationServiceCenterId AS TargetEducationOrganizationId
    FROM    inserted new;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the StateEducationAgencyId
        SELECT  tuples.SourceEducationOrganizationId, new.EducationServiceCenterId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
        WHERE   new.StateEducationAgencyId IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  new.EducationServiceCenterId, tuples.TargetEducationOrganizationId
            FROM    inserted new
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                        ON new.EducationServiceCenterId = tuples.SourceEducationOrganizationId
        ) as targets
    WHERE sources.EducationServiceCenterId = targets.EducationServiceCenterId

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_EducationServiceCenter_TR_Update ON edfi.EducationServiceCenter AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON

    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT d1.SourceEducationOrganizationId, d2.TargetEducationOrganizationId
                FROM (
                    -- Find ancestors to be deleted by clearing or changing the StateEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.EducationServiceCenterId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.EducationServiceCenterId = new.EducationServiceCenterId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.StateEducationAgencyId IS NOT NULL 
                            AND (new.StateEducationAgencyId IS NULL OR old.StateEducationAgencyId <> new.StateEducationAgencyId)
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the StateEducationAgencyId 
                    SELECT  tuples.SourceEducationOrganizationId, new.EducationServiceCenterId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    ) AS d1
    
                CROSS JOIN
                    -- Get all the descendants of the EducationServiceCenter (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.EducationServiceCenterId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.EducationServiceCenterId = tuples.SourceEducationOrganizationId
                    ) as d2
                WHERE d1.EducationServiceCenterId = d2.EducationServiceCenterId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId target
    USING (
        SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
        FROM    (
                -- Determine the source ancestors affected by this change
    
                    -- Find ancestors to be inserted by initializing or changing the StateEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.EducationServiceCenterId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.EducationServiceCenterId = old.EducationServiceCenterId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.StateEducationAgencyId IS NULL AND new.StateEducationAgencyId IS NOT NULL)
                            OR old.StateEducationAgencyId <> new.StateEducationAgencyId
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the EducationServiceCenter (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.EducationServiceCenterId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.EducationServiceCenterId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE
                    sources.EducationServiceCenterId = targets.EducationServiceCenterId
        ) AS source
        ON target.SourceEducationOrganizationId = source.SourceEducationOrganizationId 
            AND target.TargetEducationOrganizationId = source.TargetEducationOrganizationId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT(SourceEducationOrganizationId, TargetEducationOrganizationId)
        VALUES(source.SourceEducationOrganizationId, source.TargetEducationOrganizationId);

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_EducationServiceCenter_TR_Delete ON edfi.EducationServiceCenter AFTER DELETE AS
BEGIN
    SET NOCOUNT ON

    -- Remove affected tuples
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
                FROM (
                    -- Determine the source ancestors affected by this change
                    -- Find ancestors to be deleted by clearing or changing the StateEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, old.EducationServiceCenterId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.StateEducationAgencyId IS NOT NULL
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the EducationServiceCenter (to be cross joined with all the affected ancestor sources)
                    (SELECT tuples.TargetEducationOrganizationId, old.EducationServiceCenterId
                    FROM    deleted old
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.EducationServiceCenterId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE sources.EducationServiceCenterId = targets.EducationServiceCenterId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;

        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.EducationServiceCenterId
                    AND TargetEducationOrganizationId = old.EducationServiceCenterId

END
GO

-- edfi.LocalEducationAgency
CREATE OR ALTER TRIGGER edfi.edfi_LocalEducationAgency_TR_Insert ON edfi.LocalEducationAgency AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.LocalEducationAgencyId AS SourceEducationOrganizationId, 
            new.LocalEducationAgencyId AS TargetEducationOrganizationId
    FROM    inserted new;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the ParentLocalEducationAgencyId
        SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.ParentLocalEducationAgencyId = tuples.TargetEducationOrganizationId 
        WHERE   new.ParentLocalEducationAgencyId IS NOT NULL

                        UNION

        -- Find ancestors that need to have tuples inserted due to assignment of the EducationServiceCenterId
        SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.EducationServiceCenterId = tuples.TargetEducationOrganizationId 
        WHERE   new.EducationServiceCenterId IS NOT NULL

                        UNION

        -- Find ancestors that need to have tuples inserted due to assignment of the StateEducationAgencyId
        SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
        WHERE   new.StateEducationAgencyId IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  new.LocalEducationAgencyId, tuples.TargetEducationOrganizationId
            FROM    inserted new
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                        ON new.LocalEducationAgencyId = tuples.SourceEducationOrganizationId
        ) as targets
    WHERE sources.LocalEducationAgencyId = targets.LocalEducationAgencyId

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_LocalEducationAgency_TR_Update ON edfi.LocalEducationAgency AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON

    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT d1.SourceEducationOrganizationId, d2.TargetEducationOrganizationId
                FROM (
                    -- Find ancestors to be deleted by clearing or changing the ParentLocalEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.LocalEducationAgencyId = new.LocalEducationAgencyId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.ParentLocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.ParentLocalEducationAgencyId IS NOT NULL 
                            AND (new.ParentLocalEducationAgencyId IS NULL OR old.ParentLocalEducationAgencyId <> new.ParentLocalEducationAgencyId)

                        UNION

                    -- Find ancestors to be deleted by clearing or changing the EducationServiceCenterId
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.LocalEducationAgencyId = new.LocalEducationAgencyId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.EducationServiceCenterId = tuples.TargetEducationOrganizationId 
                    WHERE   old.EducationServiceCenterId IS NOT NULL 
                            AND (new.EducationServiceCenterId IS NULL OR old.EducationServiceCenterId <> new.EducationServiceCenterId)

                        UNION

                    -- Find ancestors to be deleted by clearing or changing the StateEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.LocalEducationAgencyId = new.LocalEducationAgencyId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.StateEducationAgencyId IS NOT NULL 
                            AND (new.StateEducationAgencyId IS NULL OR old.StateEducationAgencyId <> new.StateEducationAgencyId)
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the ParentLocalEducationAgencyId 
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.ParentLocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the EducationServiceCenterId 
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.EducationServiceCenterId = tuples.TargetEducationOrganizationId 
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the StateEducationAgencyId 
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    ) AS d1
    
                CROSS JOIN
                    -- Get all the descendants of the LocalEducationAgency (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.LocalEducationAgencyId = tuples.SourceEducationOrganizationId
                    ) as d2
                WHERE d1.LocalEducationAgencyId = d2.LocalEducationAgencyId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId target
    USING (
        SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
        FROM    (
                -- Determine the source ancestors affected by this change
    
                    -- Find ancestors to be inserted by initializing or changing the ParentLocalEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.LocalEducationAgencyId = old.LocalEducationAgencyId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.ParentLocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.ParentLocalEducationAgencyId IS NULL AND new.ParentLocalEducationAgencyId IS NOT NULL)
                            OR old.ParentLocalEducationAgencyId <> new.ParentLocalEducationAgencyId
    
                    UNION

    
                    -- Find ancestors to be inserted by initializing or changing the EducationServiceCenterId
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.LocalEducationAgencyId = old.LocalEducationAgencyId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.EducationServiceCenterId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.EducationServiceCenterId IS NULL AND new.EducationServiceCenterId IS NOT NULL)
                            OR old.EducationServiceCenterId <> new.EducationServiceCenterId
    
                    UNION

    
                    -- Find ancestors to be inserted by initializing or changing the StateEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.LocalEducationAgencyId = old.LocalEducationAgencyId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.StateEducationAgencyId IS NULL AND new.StateEducationAgencyId IS NOT NULL)
                            OR old.StateEducationAgencyId <> new.StateEducationAgencyId
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the LocalEducationAgency (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.LocalEducationAgencyId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.LocalEducationAgencyId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE
                    sources.LocalEducationAgencyId = targets.LocalEducationAgencyId
        ) AS source
        ON target.SourceEducationOrganizationId = source.SourceEducationOrganizationId 
            AND target.TargetEducationOrganizationId = source.TargetEducationOrganizationId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT(SourceEducationOrganizationId, TargetEducationOrganizationId)
        VALUES(source.SourceEducationOrganizationId, source.TargetEducationOrganizationId);

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_LocalEducationAgency_TR_Delete ON edfi.LocalEducationAgency AFTER DELETE AS
BEGIN
    SET NOCOUNT ON

    -- Remove affected tuples
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
                FROM (
                    -- Determine the source ancestors affected by this change
                    -- Find ancestors to be deleted by clearing or changing the ParentLocalEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, old.LocalEducationAgencyId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.ParentLocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.ParentLocalEducationAgencyId IS NOT NULL
    
                    UNION

                    -- Find ancestors to be deleted by clearing or changing the EducationServiceCenterId
                    SELECT  tuples.SourceEducationOrganizationId, old.LocalEducationAgencyId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.EducationServiceCenterId = tuples.TargetEducationOrganizationId 
                    WHERE   old.EducationServiceCenterId IS NOT NULL
    
                    UNION

                    -- Find ancestors to be deleted by clearing or changing the StateEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, old.LocalEducationAgencyId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.StateEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.StateEducationAgencyId IS NOT NULL
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the LocalEducationAgency (to be cross joined with all the affected ancestor sources)
                    (SELECT tuples.TargetEducationOrganizationId, old.LocalEducationAgencyId
                    FROM    deleted old
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.LocalEducationAgencyId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE sources.LocalEducationAgencyId = targets.LocalEducationAgencyId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;

        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.LocalEducationAgencyId
                    AND TargetEducationOrganizationId = old.LocalEducationAgencyId

END
GO

-- edfi.OrganizationDepartment
CREATE OR ALTER TRIGGER edfi.edfi_OrganizationDepartment_TR_Insert ON edfi.OrganizationDepartment AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.OrganizationDepartmentId AS SourceEducationOrganizationId, 
            new.OrganizationDepartmentId AS TargetEducationOrganizationId
    FROM    inserted new;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the ParentEducationOrganizationId
        SELECT  tuples.SourceEducationOrganizationId, new.OrganizationDepartmentId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.ParentEducationOrganizationId = tuples.TargetEducationOrganizationId 
        WHERE   new.ParentEducationOrganizationId IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  new.OrganizationDepartmentId, tuples.TargetEducationOrganizationId
            FROM    inserted new
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                        ON new.OrganizationDepartmentId = tuples.SourceEducationOrganizationId
        ) as targets
    WHERE sources.OrganizationDepartmentId = targets.OrganizationDepartmentId

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_OrganizationDepartment_TR_Update ON edfi.OrganizationDepartment AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON

    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT d1.SourceEducationOrganizationId, d2.TargetEducationOrganizationId
                FROM (
                    -- Find ancestors to be deleted by clearing or changing the ParentEducationOrganizationId
                    SELECT  tuples.SourceEducationOrganizationId, new.OrganizationDepartmentId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.OrganizationDepartmentId = new.OrganizationDepartmentId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.ParentEducationOrganizationId = tuples.TargetEducationOrganizationId 
                    WHERE   old.ParentEducationOrganizationId IS NOT NULL 
                            AND (new.ParentEducationOrganizationId IS NULL OR old.ParentEducationOrganizationId <> new.ParentEducationOrganizationId)
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the ParentEducationOrganizationId 
                    SELECT  tuples.SourceEducationOrganizationId, new.OrganizationDepartmentId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.ParentEducationOrganizationId = tuples.TargetEducationOrganizationId 
                    ) AS d1
    
                CROSS JOIN
                    -- Get all the descendants of the OrganizationDepartment (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.OrganizationDepartmentId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.OrganizationDepartmentId = tuples.SourceEducationOrganizationId
                    ) as d2
                WHERE d1.OrganizationDepartmentId = d2.OrganizationDepartmentId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId target
    USING (
        SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
        FROM    (
                -- Determine the source ancestors affected by this change
    
                    -- Find ancestors to be inserted by initializing or changing the ParentEducationOrganizationId
                    SELECT  tuples.SourceEducationOrganizationId, new.OrganizationDepartmentId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.OrganizationDepartmentId = old.OrganizationDepartmentId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.ParentEducationOrganizationId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.ParentEducationOrganizationId IS NULL AND new.ParentEducationOrganizationId IS NOT NULL)
                            OR old.ParentEducationOrganizationId <> new.ParentEducationOrganizationId
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the OrganizationDepartment (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.OrganizationDepartmentId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.OrganizationDepartmentId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE
                    sources.OrganizationDepartmentId = targets.OrganizationDepartmentId
        ) AS source
        ON target.SourceEducationOrganizationId = source.SourceEducationOrganizationId 
            AND target.TargetEducationOrganizationId = source.TargetEducationOrganizationId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT(SourceEducationOrganizationId, TargetEducationOrganizationId)
        VALUES(source.SourceEducationOrganizationId, source.TargetEducationOrganizationId);

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_OrganizationDepartment_TR_Delete ON edfi.OrganizationDepartment AFTER DELETE AS
BEGIN
    SET NOCOUNT ON

    -- Remove affected tuples
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
                FROM (
                    -- Determine the source ancestors affected by this change
                    -- Find ancestors to be deleted by clearing or changing the ParentEducationOrganizationId
                    SELECT  tuples.SourceEducationOrganizationId, old.OrganizationDepartmentId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.ParentEducationOrganizationId = tuples.TargetEducationOrganizationId 
                    WHERE   old.ParentEducationOrganizationId IS NOT NULL
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the OrganizationDepartment (to be cross joined with all the affected ancestor sources)
                    (SELECT tuples.TargetEducationOrganizationId, old.OrganizationDepartmentId
                    FROM    deleted old
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.OrganizationDepartmentId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE sources.OrganizationDepartmentId = targets.OrganizationDepartmentId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;

        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.OrganizationDepartmentId
                    AND TargetEducationOrganizationId = old.OrganizationDepartmentId

END
GO

-- edfi.PostSecondaryInstitution
CREATE OR ALTER TRIGGER edfi.edfi_PostSecondaryInstitution_TR_Insert ON edfi.PostSecondaryInstitution AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.PostSecondaryInstitutionId AS SourceEducationOrganizationId, 
            new.PostSecondaryInstitutionId AS TargetEducationOrganizationId
    FROM    inserted new;

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_PostSecondaryInstitution_TR_Delete ON edfi.PostSecondaryInstitution AFTER DELETE AS
BEGIN
    SET NOCOUNT ON


        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.PostSecondaryInstitutionId
                    AND TargetEducationOrganizationId = old.PostSecondaryInstitutionId

END
GO

-- edfi.School
CREATE OR ALTER TRIGGER edfi.edfi_School_TR_Insert ON edfi.School AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.SchoolId AS SourceEducationOrganizationId, 
            new.SchoolId AS TargetEducationOrganizationId
    FROM    inserted new;

    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the LocalEducationAgencyId
        SELECT  tuples.SourceEducationOrganizationId, new.SchoolId
        FROM    inserted new
                INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                    ON new.LocalEducationAgencyId = tuples.TargetEducationOrganizationId 
        WHERE   new.LocalEducationAgencyId IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  new.SchoolId, tuples.TargetEducationOrganizationId
            FROM    inserted new
                    INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                        ON new.SchoolId = tuples.SourceEducationOrganizationId
        ) as targets
    WHERE sources.SchoolId = targets.SchoolId

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_School_TR_Update ON edfi.School AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON

    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT d1.SourceEducationOrganizationId, d2.TargetEducationOrganizationId
                FROM (
                    -- Find ancestors to be deleted by clearing or changing the LocalEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.SchoolId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON old.SchoolId = new.SchoolId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.LocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.LocalEducationAgencyId IS NOT NULL 
                            AND (new.LocalEducationAgencyId IS NULL OR old.LocalEducationAgencyId <> new.LocalEducationAgencyId)
                        
                        EXCEPT
                        
                    -- Find ancestors that should remain due to new value for the LocalEducationAgencyId 
                    SELECT  tuples.SourceEducationOrganizationId, new.SchoolId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.LocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    ) AS d1
    
                CROSS JOIN
                    -- Get all the descendants of the School (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.SchoolId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.SchoolId = tuples.SourceEducationOrganizationId
                    ) as d2
                WHERE d1.SchoolId = d2.SchoolId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    MERGE INTO auth.EducationOrganizationIdToEducationOrganizationId target
    USING (
        SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
        FROM    (
                -- Determine the source ancestors affected by this change
    
                    -- Find ancestors to be inserted by initializing or changing the LocalEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, new.SchoolId
                    FROM    inserted new
                            INNER JOIN deleted old 
                                ON new.SchoolId = old.SchoolId
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.LocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   (old.LocalEducationAgencyId IS NULL AND new.LocalEducationAgencyId IS NOT NULL)
                            OR old.LocalEducationAgencyId <> new.LocalEducationAgencyId
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the School (to be cross joined with all the affected ancestor sources)
                    (SELECT	tuples.TargetEducationOrganizationId, new.SchoolId
                    FROM    inserted new
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON new.SchoolId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE
                    sources.SchoolId = targets.SchoolId
        ) AS source
        ON target.SourceEducationOrganizationId = source.SourceEducationOrganizationId 
            AND target.TargetEducationOrganizationId = source.TargetEducationOrganizationId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT(SourceEducationOrganizationId, TargetEducationOrganizationId)
        VALUES(source.SourceEducationOrganizationId, source.TargetEducationOrganizationId);

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_School_TR_Delete ON edfi.School AFTER DELETE AS
BEGIN
    SET NOCOUNT ON

    -- Remove affected tuples
    DELETE  tbd
    FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tbd
            INNER JOIN (
                SELECT sources.SourceEducationOrganizationId, targets.TargetEducationOrganizationId
                FROM (
                    -- Determine the source ancestors affected by this change
                    -- Find ancestors to be deleted by clearing or changing the LocalEducationAgencyId
                    SELECT  tuples.SourceEducationOrganizationId, old.SchoolId
                    FROM    deleted old 
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.LocalEducationAgencyId = tuples.TargetEducationOrganizationId 
                    WHERE   old.LocalEducationAgencyId IS NOT NULL
                    ) AS sources
                CROSS JOIN
                    -- Get all the descendants of the School (to be cross joined with all the affected ancestor sources)
                    (SELECT tuples.TargetEducationOrganizationId, old.SchoolId
                    FROM    deleted old
                            INNER JOIN auth.EducationOrganizationIdToEducationOrganizationId tuples
                                ON old.SchoolId = tuples.SourceEducationOrganizationId
                    ) as targets
                WHERE sources.SchoolId = targets.SchoolId
                ) AS cj
                ON tbd.SourceEducationOrganizationId = cj.SourceEducationOrganizationId
                    and tbd.TargetEducationOrganizationId = cj.TargetEducationOrganizationId;

        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.SchoolId
                    AND TargetEducationOrganizationId = old.SchoolId

END
GO

-- edfi.StateEducationAgency
CREATE OR ALTER TRIGGER edfi.edfi_StateEducationAgency_TR_Insert ON edfi.StateEducationAgency AFTER INSERT AS
BEGIN
    SET NOCOUNT ON

    -- Add new tuple for current record
    INSERT INTO auth.EducationOrganizationIdToEducationOrganizationId(SourceEducationOrganizationId, TargetEducationOrganizationId)
    SELECT  new.StateEducationAgencyId AS SourceEducationOrganizationId, 
            new.StateEducationAgencyId AS TargetEducationOrganizationId
    FROM    inserted new;

END
GO

CREATE OR ALTER TRIGGER edfi.edfi_StateEducationAgency_TR_Delete ON edfi.StateEducationAgency AFTER DELETE AS
BEGIN
    SET NOCOUNT ON


        -- Delete self-referencing tuple
        DELETE  tuples
        FROM    auth.EducationOrganizationIdToEducationOrganizationId AS tuples
                INNER JOIN deleted old
                    ON SourceEducationOrganizationId = old.StateEducationAgencyId
                    AND TargetEducationOrganizationId = old.StateEducationAgencyId

END
GO


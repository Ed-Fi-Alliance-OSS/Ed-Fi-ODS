-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- edfi.communityorganization
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.communityorganization;

DROP FUNCTION IF EXISTS edfi.edfi_communityorganization_tr_insert;

CREATE FUNCTION edfi.edfi_communityorganization_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.communityorganizationid AS SourceEducationOrganizationId, 
            NEW.communityorganizationid AS targeteducationorganizationid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.communityorganization
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_communityorganization_tr_insert();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.communityorganization;

DROP FUNCTION IF EXISTS edfi.edfi_communityorganization_tr_delete;

CREATE FUNCTION edfi.edfi_communityorganization_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.communityorganizationid
            AND targeteducationorganizationid = OLD.communityorganizationid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.communityorganization
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_communityorganization_tr_delete();


-- edfi.communityprovider
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.communityprovider;

DROP FUNCTION IF EXISTS edfi.edfi_communityprovider_tr_insert;

CREATE FUNCTION edfi.edfi_communityprovider_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.communityproviderid AS SourceEducationOrganizationId, 
            NEW.communityproviderid AS targeteducationorganizationid;

    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT sources.SourceEducationOrganizationId, targets.targeteducationorganizationid
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the communityorganizationid
        SELECT  tuples.SourceEducationOrganizationId, NEW.communityproviderid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.communityorganizationid  
                AND NEW.communityorganizationid IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  NEW.communityproviderid, tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.SourceEducationOrganizationId = NEW.communityproviderid
        ) as targets
    WHERE sources.communityproviderid = targets.communityproviderid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.communityprovider
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_communityprovider_tr_insert();

DROP TRIGGER IF EXISTS UpdateAuthTuples ON edfi.communityprovider;

DROP FUNCTION IF EXISTS edfi.edfi_communityprovider_tr_update;

CREATE FUNCTION edfi.edfi_communityprovider_tr_update()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    WITH cj AS (
        SELECT d1.sourceeducationorganizationid, d2.targeteducationorganizationid
        FROM (
            -- Find ancestors to be deleted by clearing or changing the communityorganizationid
            SELECT  tuples.sourceeducationorganizationid, new.communityproviderid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.communityorganizationid  
                    AND OLD.communityorganizationid IS NOT NULL 
                    AND (NEW.communityorganizationid IS NULL OR OLD.communityorganizationid <> NEW.communityorganizationid)
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the communityorganizationid 
            SELECT  tuples.sourceeducationorganizationid, NEW.communityproviderid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.communityorganizationid 
            ) AS d1

        CROSS JOIN
            -- Get all the descendants of the communityprovider (to be cross joined with all the affected ancestor sources)
            (SELECT	tuples.targeteducationorganizationid, NEW.communityproviderid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   NEW.communityproviderid = tuples.sourceeducationorganizationid
            ) as d2
        WHERE d1.communityproviderid = d2.communityproviderid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    WITH source(sourceeducationorganizationid, targeteducationorganizationid) AS (
        SELECT  sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
        -- Determine the source ancestors affected by this change
            -- Find ancestors to be inserted by initializing or changing the communityorganizationid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.communityorganizationid
                AND ((OLD.communityorganizationid IS NULL AND NEW.communityorganizationid IS NOT NULL)
                OR OLD.communityorganizationid <> NEW.communityorganizationid)
        ) as sources
        CROSS JOIN (
            -- Get all the descendants of the communityprovider (to be cross joined with all the affected ancestor sources)
            SELECT  tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = NEW.communityproviderid
        ) AS targets
    )
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(sourceeducationorganizationid, targeteducationorganizationid)
    SELECT source.sourceeducationorganizationid, source.targeteducationorganizationid
    FROM source
    ON CONFLICT DO NOTHING;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER UpdateAuthTuples AFTER UPDATE ON edfi.communityprovider
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_communityprovider_tr_update();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.communityprovider;

DROP FUNCTION IF EXISTS edfi.edfi_communityprovider_tr_delete;

CREATE FUNCTION edfi.edfi_communityprovider_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove affected tuples
    WITH cj AS (
        SELECT sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
            -- Determine the source ancestors affected by this change
            -- Find ancestors to be deleted by clearing or changing the communityorganizationid
            SELECT  tuples.sourceeducationorganizationid, OLD.communityproviderid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.communityorganizationid 
                    AND OLD.communityorganizationid IS NOT NULL
            ) AS sources
        CROSS JOIN
            -- Get all the descendants of the communityprovider (to be cross joined with all the affected ancestor sources)
            (SELECT tuples.targeteducationorganizationid, OLD.communityproviderid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = OLD.communityproviderid
            ) as targets
        WHERE sources.communityproviderid = targets.communityproviderid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;

    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.communityproviderid
            AND targeteducationorganizationid = OLD.communityproviderid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.communityprovider
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_communityprovider_tr_delete();


-- edfi.educationorganizationnetwork
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.educationorganizationnetwork;

DROP FUNCTION IF EXISTS edfi.edfi_educationorganizationnetwork_tr_insert;

CREATE FUNCTION edfi.edfi_educationorganizationnetwork_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.educationorganizationnetworkid AS SourceEducationOrganizationId, 
            NEW.educationorganizationnetworkid AS targeteducationorganizationid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.educationorganizationnetwork
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_educationorganizationnetwork_tr_insert();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.educationorganizationnetwork;

DROP FUNCTION IF EXISTS edfi.edfi_educationorganizationnetwork_tr_delete;

CREATE FUNCTION edfi.edfi_educationorganizationnetwork_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.educationorganizationnetworkid
            AND targeteducationorganizationid = OLD.educationorganizationnetworkid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.educationorganizationnetwork
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_educationorganizationnetwork_tr_delete();


-- edfi.educationservicecenter
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.educationservicecenter;

DROP FUNCTION IF EXISTS edfi.edfi_educationservicecenter_tr_insert;

CREATE FUNCTION edfi.edfi_educationservicecenter_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.educationservicecenterid AS SourceEducationOrganizationId, 
            NEW.educationservicecenterid AS targeteducationorganizationid;

    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT sources.SourceEducationOrganizationId, targets.targeteducationorganizationid
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the stateeducationagencyid
        SELECT  tuples.SourceEducationOrganizationId, NEW.educationservicecenterid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.stateeducationagencyid  
                AND NEW.stateeducationagencyid IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  NEW.educationservicecenterid, tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.SourceEducationOrganizationId = NEW.educationservicecenterid
        ) as targets
    WHERE sources.educationservicecenterid = targets.educationservicecenterid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.educationservicecenter
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_educationservicecenter_tr_insert();

DROP TRIGGER IF EXISTS UpdateAuthTuples ON edfi.educationservicecenter;

DROP FUNCTION IF EXISTS edfi.edfi_educationservicecenter_tr_update;

CREATE FUNCTION edfi.edfi_educationservicecenter_tr_update()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    WITH cj AS (
        SELECT d1.sourceeducationorganizationid, d2.targeteducationorganizationid
        FROM (
            -- Find ancestors to be deleted by clearing or changing the stateeducationagencyid
            SELECT  tuples.sourceeducationorganizationid, new.educationservicecenterid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.stateeducationagencyid  
                    AND OLD.stateeducationagencyid IS NOT NULL 
                    AND (NEW.stateeducationagencyid IS NULL OR OLD.stateeducationagencyid <> NEW.stateeducationagencyid)
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the stateeducationagencyid 
            SELECT  tuples.sourceeducationorganizationid, NEW.educationservicecenterid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.stateeducationagencyid 
            ) AS d1

        CROSS JOIN
            -- Get all the descendants of the educationservicecenter (to be cross joined with all the affected ancestor sources)
            (SELECT	tuples.targeteducationorganizationid, NEW.educationservicecenterid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   NEW.educationservicecenterid = tuples.sourceeducationorganizationid
            ) as d2
        WHERE d1.educationservicecenterid = d2.educationservicecenterid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    WITH source(sourceeducationorganizationid, targeteducationorganizationid) AS (
        SELECT  sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
        -- Determine the source ancestors affected by this change
            -- Find ancestors to be inserted by initializing or changing the stateeducationagencyid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.stateeducationagencyid
                AND ((OLD.stateeducationagencyid IS NULL AND NEW.stateeducationagencyid IS NOT NULL)
                OR OLD.stateeducationagencyid <> NEW.stateeducationagencyid)
        ) as sources
        CROSS JOIN (
            -- Get all the descendants of the educationservicecenter (to be cross joined with all the affected ancestor sources)
            SELECT  tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = NEW.educationservicecenterid
        ) AS targets
    )
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(sourceeducationorganizationid, targeteducationorganizationid)
    SELECT source.sourceeducationorganizationid, source.targeteducationorganizationid
    FROM source
    ON CONFLICT DO NOTHING;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER UpdateAuthTuples AFTER UPDATE ON edfi.educationservicecenter
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_educationservicecenter_tr_update();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.educationservicecenter;

DROP FUNCTION IF EXISTS edfi.edfi_educationservicecenter_tr_delete;

CREATE FUNCTION edfi.edfi_educationservicecenter_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove affected tuples
    WITH cj AS (
        SELECT sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
            -- Determine the source ancestors affected by this change
            -- Find ancestors to be deleted by clearing or changing the stateeducationagencyid
            SELECT  tuples.sourceeducationorganizationid, OLD.educationservicecenterid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.stateeducationagencyid 
                    AND OLD.stateeducationagencyid IS NOT NULL
            ) AS sources
        CROSS JOIN
            -- Get all the descendants of the educationservicecenter (to be cross joined with all the affected ancestor sources)
            (SELECT tuples.targeteducationorganizationid, OLD.educationservicecenterid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = OLD.educationservicecenterid
            ) as targets
        WHERE sources.educationservicecenterid = targets.educationservicecenterid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;

    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.educationservicecenterid
            AND targeteducationorganizationid = OLD.educationservicecenterid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.educationservicecenter
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_educationservicecenter_tr_delete();


-- edfi.localeducationagency
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.localeducationagency;

DROP FUNCTION IF EXISTS edfi.edfi_localeducationagency_tr_insert;

CREATE FUNCTION edfi.edfi_localeducationagency_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.localeducationagencyid AS SourceEducationOrganizationId, 
            NEW.localeducationagencyid AS targeteducationorganizationid;

    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT sources.SourceEducationOrganizationId, targets.targeteducationorganizationid
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the parentlocaleducationagencyid
        SELECT  tuples.SourceEducationOrganizationId, NEW.localeducationagencyid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.parentlocaleducationagencyid  
                AND NEW.parentlocaleducationagencyid IS NOT NULL

                        UNION

        -- Find ancestors that need to have tuples inserted due to assignment of the educationservicecenterid
        SELECT  tuples.SourceEducationOrganizationId, NEW.localeducationagencyid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.educationservicecenterid  
                AND NEW.educationservicecenterid IS NOT NULL

                        UNION

        -- Find ancestors that need to have tuples inserted due to assignment of the stateeducationagencyid
        SELECT  tuples.SourceEducationOrganizationId, NEW.localeducationagencyid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.stateeducationagencyid  
                AND NEW.stateeducationagencyid IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  NEW.localeducationagencyid, tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.SourceEducationOrganizationId = NEW.localeducationagencyid
        ) as targets
    WHERE sources.localeducationagencyid = targets.localeducationagencyid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.localeducationagency
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_localeducationagency_tr_insert();

DROP TRIGGER IF EXISTS UpdateAuthTuples ON edfi.localeducationagency;

DROP FUNCTION IF EXISTS edfi.edfi_localeducationagency_tr_update;

CREATE FUNCTION edfi.edfi_localeducationagency_tr_update()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    WITH cj AS (
        SELECT d1.sourceeducationorganizationid, d2.targeteducationorganizationid
        FROM (
            -- Find ancestors to be deleted by clearing or changing the parentlocaleducationagencyid
            SELECT  tuples.sourceeducationorganizationid, new.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.parentlocaleducationagencyid  
                    AND OLD.parentlocaleducationagencyid IS NOT NULL 
                    AND (NEW.parentlocaleducationagencyid IS NULL OR OLD.parentlocaleducationagencyid <> NEW.parentlocaleducationagencyid)

                UNION

            -- Find ancestors to be deleted by clearing or changing the educationservicecenterid
            SELECT  tuples.sourceeducationorganizationid, new.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.educationservicecenterid  
                    AND OLD.educationservicecenterid IS NOT NULL 
                    AND (NEW.educationservicecenterid IS NULL OR OLD.educationservicecenterid <> NEW.educationservicecenterid)

                UNION

            -- Find ancestors to be deleted by clearing or changing the stateeducationagencyid
            SELECT  tuples.sourceeducationorganizationid, new.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.stateeducationagencyid  
                    AND OLD.stateeducationagencyid IS NOT NULL 
                    AND (NEW.stateeducationagencyid IS NULL OR OLD.stateeducationagencyid <> NEW.stateeducationagencyid)
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the parentlocaleducationagencyid 
            SELECT  tuples.sourceeducationorganizationid, NEW.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.parentlocaleducationagencyid 
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the educationservicecenterid 
            SELECT  tuples.sourceeducationorganizationid, NEW.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.educationservicecenterid 
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the stateeducationagencyid 
            SELECT  tuples.sourceeducationorganizationid, NEW.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.stateeducationagencyid 
            ) AS d1

        CROSS JOIN
            -- Get all the descendants of the localeducationagency (to be cross joined with all the affected ancestor sources)
            (SELECT	tuples.targeteducationorganizationid, NEW.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   NEW.localeducationagencyid = tuples.sourceeducationorganizationid
            ) as d2
        WHERE d1.localeducationagencyid = d2.localeducationagencyid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    WITH source(sourceeducationorganizationid, targeteducationorganizationid) AS (
        SELECT  sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
        -- Determine the source ancestors affected by this change
            -- Find ancestors to be inserted by initializing or changing the parentlocaleducationagencyid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.parentlocaleducationagencyid
                AND ((OLD.parentlocaleducationagencyid IS NULL AND NEW.parentlocaleducationagencyid IS NOT NULL)
                OR OLD.parentlocaleducationagencyid <> NEW.parentlocaleducationagencyid)

            UNION

            -- Find ancestors to be inserted by initializing or changing the educationservicecenterid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.educationservicecenterid
                AND ((OLD.educationservicecenterid IS NULL AND NEW.educationservicecenterid IS NOT NULL)
                OR OLD.educationservicecenterid <> NEW.educationservicecenterid)

            UNION

            -- Find ancestors to be inserted by initializing or changing the stateeducationagencyid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.stateeducationagencyid
                AND ((OLD.stateeducationagencyid IS NULL AND NEW.stateeducationagencyid IS NOT NULL)
                OR OLD.stateeducationagencyid <> NEW.stateeducationagencyid)
        ) as sources
        CROSS JOIN (
            -- Get all the descendants of the localeducationagency (to be cross joined with all the affected ancestor sources)
            SELECT  tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = NEW.localeducationagencyid
        ) AS targets
    )
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(sourceeducationorganizationid, targeteducationorganizationid)
    SELECT source.sourceeducationorganizationid, source.targeteducationorganizationid
    FROM source
    ON CONFLICT DO NOTHING;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER UpdateAuthTuples AFTER UPDATE ON edfi.localeducationagency
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_localeducationagency_tr_update();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.localeducationagency;

DROP FUNCTION IF EXISTS edfi.edfi_localeducationagency_tr_delete;

CREATE FUNCTION edfi.edfi_localeducationagency_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove affected tuples
    WITH cj AS (
        SELECT sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
            -- Determine the source ancestors affected by this change
            -- Find ancestors to be deleted by clearing or changing the parentlocaleducationagencyid
            SELECT  tuples.sourceeducationorganizationid, OLD.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.parentlocaleducationagencyid 
                    AND OLD.parentlocaleducationagencyid IS NOT NULL

            UNION

            -- Find ancestors to be deleted by clearing or changing the educationservicecenterid
            SELECT  tuples.sourceeducationorganizationid, OLD.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.educationservicecenterid 
                    AND OLD.educationservicecenterid IS NOT NULL

            UNION

            -- Find ancestors to be deleted by clearing or changing the stateeducationagencyid
            SELECT  tuples.sourceeducationorganizationid, OLD.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.stateeducationagencyid 
                    AND OLD.stateeducationagencyid IS NOT NULL
            ) AS sources
        CROSS JOIN
            -- Get all the descendants of the localeducationagency (to be cross joined with all the affected ancestor sources)
            (SELECT tuples.targeteducationorganizationid, OLD.localeducationagencyid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = OLD.localeducationagencyid
            ) as targets
        WHERE sources.localeducationagencyid = targets.localeducationagencyid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;

    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.localeducationagencyid
            AND targeteducationorganizationid = OLD.localeducationagencyid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.localeducationagency
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_localeducationagency_tr_delete();


-- edfi.organizationdepartment
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.organizationdepartment;

DROP FUNCTION IF EXISTS edfi.edfi_organizationdepartment_tr_insert;

CREATE FUNCTION edfi.edfi_organizationdepartment_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.organizationdepartmentid AS SourceEducationOrganizationId, 
            NEW.organizationdepartmentid AS targeteducationorganizationid;

    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT sources.SourceEducationOrganizationId, targets.targeteducationorganizationid
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the parenteducationorganizationid
        SELECT  tuples.SourceEducationOrganizationId, NEW.organizationdepartmentid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.parenteducationorganizationid  
                AND NEW.parenteducationorganizationid IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  NEW.organizationdepartmentid, tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.SourceEducationOrganizationId = NEW.organizationdepartmentid
        ) as targets
    WHERE sources.organizationdepartmentid = targets.organizationdepartmentid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.organizationdepartment
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_organizationdepartment_tr_insert();

DROP TRIGGER IF EXISTS UpdateAuthTuples ON edfi.organizationdepartment;

DROP FUNCTION IF EXISTS edfi.edfi_organizationdepartment_tr_update;

CREATE FUNCTION edfi.edfi_organizationdepartment_tr_update()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    WITH cj AS (
        SELECT d1.sourceeducationorganizationid, d2.targeteducationorganizationid
        FROM (
            -- Find ancestors to be deleted by clearing or changing the parenteducationorganizationid
            SELECT  tuples.sourceeducationorganizationid, new.organizationdepartmentid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.parenteducationorganizationid  
                    AND OLD.parenteducationorganizationid IS NOT NULL 
                    AND (NEW.parenteducationorganizationid IS NULL OR OLD.parenteducationorganizationid <> NEW.parenteducationorganizationid)
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the parenteducationorganizationid 
            SELECT  tuples.sourceeducationorganizationid, NEW.organizationdepartmentid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.parenteducationorganizationid 
            ) AS d1

        CROSS JOIN
            -- Get all the descendants of the organizationdepartment (to be cross joined with all the affected ancestor sources)
            (SELECT	tuples.targeteducationorganizationid, NEW.organizationdepartmentid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   NEW.organizationdepartmentid = tuples.sourceeducationorganizationid
            ) as d2
        WHERE d1.organizationdepartmentid = d2.organizationdepartmentid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    WITH source(sourceeducationorganizationid, targeteducationorganizationid) AS (
        SELECT  sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
        -- Determine the source ancestors affected by this change
            -- Find ancestors to be inserted by initializing or changing the parenteducationorganizationid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.parenteducationorganizationid
                AND ((OLD.parenteducationorganizationid IS NULL AND NEW.parenteducationorganizationid IS NOT NULL)
                OR OLD.parenteducationorganizationid <> NEW.parenteducationorganizationid)
        ) as sources
        CROSS JOIN (
            -- Get all the descendants of the organizationdepartment (to be cross joined with all the affected ancestor sources)
            SELECT  tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = NEW.organizationdepartmentid
        ) AS targets
    )
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(sourceeducationorganizationid, targeteducationorganizationid)
    SELECT source.sourceeducationorganizationid, source.targeteducationorganizationid
    FROM source
    ON CONFLICT DO NOTHING;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER UpdateAuthTuples AFTER UPDATE ON edfi.organizationdepartment
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_organizationdepartment_tr_update();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.organizationdepartment;

DROP FUNCTION IF EXISTS edfi.edfi_organizationdepartment_tr_delete;

CREATE FUNCTION edfi.edfi_organizationdepartment_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove affected tuples
    WITH cj AS (
        SELECT sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
            -- Determine the source ancestors affected by this change
            -- Find ancestors to be deleted by clearing or changing the parenteducationorganizationid
            SELECT  tuples.sourceeducationorganizationid, OLD.organizationdepartmentid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.parenteducationorganizationid 
                    AND OLD.parenteducationorganizationid IS NOT NULL
            ) AS sources
        CROSS JOIN
            -- Get all the descendants of the organizationdepartment (to be cross joined with all the affected ancestor sources)
            (SELECT tuples.targeteducationorganizationid, OLD.organizationdepartmentid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = OLD.organizationdepartmentid
            ) as targets
        WHERE sources.organizationdepartmentid = targets.organizationdepartmentid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;

    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.organizationdepartmentid
            AND targeteducationorganizationid = OLD.organizationdepartmentid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.organizationdepartment
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_organizationdepartment_tr_delete();


-- edfi.postsecondaryinstitution
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.postsecondaryinstitution;

DROP FUNCTION IF EXISTS edfi.edfi_postsecondaryinstitution_tr_insert;

CREATE FUNCTION edfi.edfi_postsecondaryinstitution_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.postsecondaryinstitutionid AS SourceEducationOrganizationId, 
            NEW.postsecondaryinstitutionid AS targeteducationorganizationid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.postsecondaryinstitution
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_postsecondaryinstitution_tr_insert();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.postsecondaryinstitution;

DROP FUNCTION IF EXISTS edfi.edfi_postsecondaryinstitution_tr_delete;

CREATE FUNCTION edfi.edfi_postsecondaryinstitution_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.postsecondaryinstitutionid
            AND targeteducationorganizationid = OLD.postsecondaryinstitutionid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.postsecondaryinstitution
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_postsecondaryinstitution_tr_delete();


-- edfi.school
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.school;

DROP FUNCTION IF EXISTS edfi.edfi_school_tr_insert;

CREATE FUNCTION edfi.edfi_school_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.schoolid AS SourceEducationOrganizationId, 
            NEW.schoolid AS targeteducationorganizationid;

    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT sources.SourceEducationOrganizationId, targets.targeteducationorganizationid
    FROM (
        -- Find ancestors that need to have tuples inserted due to assignment of the localeducationagencyid
        SELECT  tuples.SourceEducationOrganizationId, NEW.schoolid
        FROM    auth.educationorganizationidtoeducationorganizationid tuples
        WHERE   tuples.targeteducationorganizationid = NEW.localeducationagencyid  
                AND NEW.localeducationagencyid IS NOT NULL
        ) AS sources
    CROSS JOIN
        -- Get all the existing targets/descendants (to be cross joined with all the affected ancestor sources)
        (
            SELECT  NEW.schoolid, tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.SourceEducationOrganizationId = NEW.schoolid
        ) as targets
    WHERE sources.schoolid = targets.schoolid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.school
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_school_tr_insert();

DROP TRIGGER IF EXISTS UpdateAuthTuples ON edfi.school;

DROP FUNCTION IF EXISTS edfi.edfi_school_tr_update;

CREATE FUNCTION edfi.edfi_school_tr_update()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove all tuples impacted by the clearing or changing of the parent education organizations
    WITH cj AS (
        SELECT d1.sourceeducationorganizationid, d2.targeteducationorganizationid
        FROM (
            -- Find ancestors to be deleted by clearing or changing the localeducationagencyid
            SELECT  tuples.sourceeducationorganizationid, new.schoolid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.localeducationagencyid  
                    AND OLD.localeducationagencyid IS NOT NULL 
                    AND (NEW.localeducationagencyid IS NULL OR OLD.localeducationagencyid <> NEW.localeducationagencyid)
                
                EXCEPT
                
            -- Find ancestors that should remain due to new value for the localeducationagencyid 
            SELECT  tuples.sourceeducationorganizationid, NEW.schoolid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.localeducationagencyid 
            ) AS d1

        CROSS JOIN
            -- Get all the descendants of the school (to be cross joined with all the affected ancestor sources)
            (SELECT	tuples.targeteducationorganizationid, NEW.schoolid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   NEW.schoolid = tuples.sourceeducationorganizationid
            ) as d2
        WHERE d1.schoolid = d2.schoolid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;
    
    -- Add new tuples resulting from the changes/initializations of parent Education Organization ids
    WITH source(sourceeducationorganizationid, targeteducationorganizationid) AS (
        SELECT  sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
        -- Determine the source ancestors affected by this change
            -- Find ancestors to be inserted by initializing or changing the localeducationagencyid
            SELECT  tuples.sourceeducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = NEW.localeducationagencyid
                AND ((OLD.localeducationagencyid IS NULL AND NEW.localeducationagencyid IS NOT NULL)
                OR OLD.localeducationagencyid <> NEW.localeducationagencyid)
        ) as sources
        CROSS JOIN (
            -- Get all the descendants of the school (to be cross joined with all the affected ancestor sources)
            SELECT  tuples.targeteducationorganizationid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = NEW.schoolid
        ) AS targets
    )
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(sourceeducationorganizationid, targeteducationorganizationid)
    SELECT source.sourceeducationorganizationid, source.targeteducationorganizationid
    FROM source
    ON CONFLICT DO NOTHING;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER UpdateAuthTuples AFTER UPDATE ON edfi.school
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_school_tr_update();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.school;

DROP FUNCTION IF EXISTS edfi.edfi_school_tr_delete;

CREATE FUNCTION edfi.edfi_school_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Remove affected tuples
    WITH cj AS (
        SELECT sources.sourceeducationorganizationid, targets.targeteducationorganizationid
        FROM (
            -- Determine the source ancestors affected by this change
            -- Find ancestors to be deleted by clearing or changing the localeducationagencyid
            SELECT  tuples.sourceeducationorganizationid, OLD.schoolid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.targeteducationorganizationid = OLD.localeducationagencyid 
                    AND OLD.localeducationagencyid IS NOT NULL
            ) AS sources
        CROSS JOIN
            -- Get all the descendants of the school (to be cross joined with all the affected ancestor sources)
            (SELECT tuples.targeteducationorganizationid, OLD.schoolid
            FROM    auth.educationorganizationidtoeducationorganizationid tuples
            WHERE   tuples.sourceeducationorganizationid = OLD.schoolid
            ) as targets
        WHERE sources.schoolid = targets.schoolid
    )
    DELETE FROM auth.educationorganizationidtoeducationorganizationid AS tbd USING cj
    WHERE tbd.sourceeducationorganizationid = cj.sourceeducationorganizationid
        AND tbd.targeteducationorganizationid = cj.targeteducationorganizationid;

    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.schoolid
            AND targeteducationorganizationid = OLD.schoolid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.school
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_school_tr_delete();


-- edfi.stateeducationagency
DROP TRIGGER IF EXISTS InsertAuthTuples ON edfi.stateeducationagency;

DROP FUNCTION IF EXISTS edfi.edfi_stateeducationagency_tr_insert;

CREATE FUNCTION edfi.edfi_stateeducationagency_tr_insert()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Add new tuple for current record
    INSERT INTO auth.educationorganizationidtoeducationorganizationid(SourceEducationOrganizationId, targeteducationorganizationid)
    SELECT  NEW.stateeducationagencyid AS SourceEducationOrganizationId, 
            NEW.stateeducationagencyid AS targeteducationorganizationid;

    
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER InsertAuthTuples AFTER INSERT ON edfi.stateeducationagency
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_stateeducationagency_tr_insert();

DROP TRIGGER IF EXISTS DeleteAuthTuples ON edfi.stateeducationagency;

DROP FUNCTION IF EXISTS edfi.edfi_stateeducationagency_tr_delete;

CREATE FUNCTION edfi.edfi_stateeducationagency_tr_delete()
    RETURNS trigger AS
$BODY$
BEGIN
    -- Delete self-referencing tuple
    DELETE
    FROM    auth.educationorganizationidtoeducationorganizationid
    WHERE   sourceeducationorganizationid = OLD.stateeducationagencyid
            AND targeteducationorganizationid = OLD.stateeducationagencyid;

    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER DeleteAuthTuples AFTER DELETE ON edfi.stateeducationagency
    FOR EACH ROW EXECUTE PROCEDURE edfi.edfi_stateeducationagency_tr_delete();



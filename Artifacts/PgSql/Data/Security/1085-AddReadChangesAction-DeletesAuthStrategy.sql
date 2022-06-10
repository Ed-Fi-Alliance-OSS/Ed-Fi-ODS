DO $$
DECLARE
    application_id INTEGER;
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.Actions WHERE ActionUri = 'http://ed-fi.org/odsapi/actions/readChanges') THEN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('ReadChanges', 'http://ed-fi.org/odsapi/actions/readChanges');
    END IF;

    SELECT applicationid INTO application_id
    FROM dbo.applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF NOT EXISTS (SELECT 1 FROM dbo.authorizationstrategies WHERE authorizationstrategyname = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes') THEN
        INSERT INTO dbo.authorizationstrategies(displayname, authorizationstrategyname, application_applicationid)
        VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes', application_id);
    END IF;
END $$;

DO $$
DECLARE
    application_id INTEGER;
BEGIN
    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('ReadChanges', 'http://ed-fi.org/odsapi/actions/readChanges');

    SELECT applicationid INTO application_id
    FROM dbo.applications WHERE ApplicationName = 'Ed-Fi ODS API';

    INSERT INTO dbo.authorizationstrategies(displayname, authorizationstrategyname, application_applicationid)
    VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes', application_id);    
END $$;


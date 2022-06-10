DECLARE
    @applicationId AS INT
BEGIN
    IF NOT EXISTS (SELECT 1 FROM dbo.Actions WHERE ActionUri = 'http://ed-fi.org/odsapi/actions/readChanges')
    BEGIN
        INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('ReadChanges', 'http://ed-fi.org/odsapi/actions/readChanges');
    END

    SELECT @applicationId = ApplicationId
    FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF NOT EXISTS (SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName = 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes')
    BEGIN
        INSERT INTO dbo.AuthorizationStrategies(DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes', @applicationId);
    END
END

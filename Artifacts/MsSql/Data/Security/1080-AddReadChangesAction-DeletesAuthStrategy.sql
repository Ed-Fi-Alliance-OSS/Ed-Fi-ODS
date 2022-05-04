DECLARE
    @applicationId AS INT
BEGIN
    INSERT INTO dbo.Actions (ActionName, ActionUri) VALUES ('ReadChanges', 'http://ed-fi.org/odsapi/actions/readChanges');

    SELECT @applicationId = ApplicationId
    FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

    INSERT INTO dbo.AuthorizationStrategies(DisplayName, AuthorizationStrategyName, Application_ApplicationId)
    VALUES ('Relationships with Education Organizations and People (including deletes)', 'RelationshipsWithEdOrgsAndPeopleIncludingDeletes', @applicationId);    
END

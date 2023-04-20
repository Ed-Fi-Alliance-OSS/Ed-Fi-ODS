DO language plpgsql $$
DECLARE application_Id INT;

BEGIN
    SELECT applicationid INTO application_Id FROM dbo.Applications WHERE ApplicationName = 'Ed-Fi ODS API';

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithEdOrgsOnlyInverted') THEN

        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Education Organizations only (Inverted)', 'RelationshipsWithEdOrgsOnlyInverted', application_Id);
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithEdOrgsAndPeopleInverted') THEN

        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName, Application_ApplicationId)
        VALUES ('Relationships with Education Organizations and People (Inverted)', 'RelationshipsWithEdOrgsAndPeopleInverted', application_Id);
    END IF;
END $$;

DO language plpgsql $$


BEGIN


    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithEdOrgsOnlyInverted') THEN

        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Education Organizations only (Inverted)', 'RelationshipsWithEdOrgsOnlyInverted');
    END IF;

    IF NOT EXISTS(SELECT 1 FROM dbo.AuthorizationStrategies WHERE AuthorizationStrategyName ='RelationshipsWithEdOrgsAndPeopleInverted') THEN

        INSERT INTO dbo.AuthorizationStrategies (DisplayName, AuthorizationStrategyName)
        VALUES ('Relationships with Education Organizations and People (Inverted)', 'RelationshipsWithEdOrgsAndPeopleInverted');
    END IF;
END $$;

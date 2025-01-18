;



IF NOT EXISTS(SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] ='RelationshipsWithEdOrgsOnlyInverted')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Education Organizations only (Inverted)', 'RelationshipsWithEdOrgsOnlyInverted');
END

IF NOT EXISTS(SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] ='RelationshipsWithEdOrgsAndPeopleInverted')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Education Organizations and People (Inverted)', 'RelationshipsWithEdOrgsAndPeopleInverted');
END

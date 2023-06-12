DECLARE @applicationId INT;

SELECT @applicationId = (SELECT applicationid FROM [dbo].[Applications] WHERE [ApplicationName] = 'Ed-Fi ODS API');

IF NOT EXISTS(SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] ='RelationshipsWithEdOrgsOnlyInverted')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Education Organizations only (Inverted)', 'RelationshipsWithEdOrgsOnlyInverted', @applicationId);
END

IF NOT EXISTS(SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] ='RelationshipsWithEdOrgsAndPeopleInverted')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName], [Application_ApplicationId])
    VALUES ('Relationships with Education Organizations and People (Inverted)', 'RelationshipsWithEdOrgsAndPeopleInverted', @applicationId);
END

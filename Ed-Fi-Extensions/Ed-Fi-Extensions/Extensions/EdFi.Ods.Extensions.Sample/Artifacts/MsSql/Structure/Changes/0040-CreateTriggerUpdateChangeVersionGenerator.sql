CREATE TRIGGER [sample].[sample_Bus_TR_UpdateChangeVersion] ON [sample].[Bus] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [sample].[Bus]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [sample].[Bus] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [sample].[sample_BusRoute_TR_UpdateChangeVersion] ON [sample].[BusRoute] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [sample].[BusRoute]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [sample].[BusRoute] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO

CREATE TRIGGER [sample].[sample_StudentGraduationPlanAssociation_TR_UpdateChangeVersion] ON [sample].[StudentGraduationPlanAssociation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [sample].[StudentGraduationPlanAssociation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [sample].[StudentGraduationPlanAssociation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO


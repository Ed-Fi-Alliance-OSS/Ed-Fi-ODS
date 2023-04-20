CREATE TRIGGER [samplestudenttransportation].[samplestudenttransportation_StudentTransportation_TR_UpdateChangeVersion] ON [samplestudenttransportation].[StudentTransportation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [samplestudenttransportation].[StudentTransportation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [samplestudenttransportation].[StudentTransportation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO


CREATE TRIGGER [samplestudenttranscript].[samplestudenttranscript_PostSecondaryOrganization_TR_UpdateChangeVersion] ON [samplestudenttranscript].[PostSecondaryOrganization] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [samplestudenttranscript].[PostSecondaryOrganization]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [samplestudenttranscript].[PostSecondaryOrganization] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO


CREATE TRIGGER [samplestudenttransportation].[samplestudenttransportation_StudentTransportation_TR_DeleteTracking] ON [samplestudenttransportation].[StudentTransportation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_deletes_samplestudenttransportation].[StudentTransportation](AMBusNumber, PMBusNumber, SchoolId, StudentUSI, Id, ChangeVersion)
    SELECT  AMBusNumber, PMBusNumber, SchoolId, StudentUSI, Id, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
END
GO

ALTER TABLE [samplestudenttransportation].[StudentTransportation] ENABLE TRIGGER [samplestudenttransportation_StudentTransportation_TR_DeleteTracking]
GO



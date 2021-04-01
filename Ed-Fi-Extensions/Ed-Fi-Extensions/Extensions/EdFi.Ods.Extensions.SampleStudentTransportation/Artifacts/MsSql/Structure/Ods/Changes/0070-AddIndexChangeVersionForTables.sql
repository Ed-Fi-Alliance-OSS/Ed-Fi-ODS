BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'samplestudenttransportation.StudentTransportation') AND name = N'UX_StudentTransportation_ChangeVersion')
    CREATE INDEX [UX_StudentTransportation_ChangeVersion] ON [samplestudenttransportation].[StudentTransportation] ([ChangeVersion] ASC)
    GO
COMMIT


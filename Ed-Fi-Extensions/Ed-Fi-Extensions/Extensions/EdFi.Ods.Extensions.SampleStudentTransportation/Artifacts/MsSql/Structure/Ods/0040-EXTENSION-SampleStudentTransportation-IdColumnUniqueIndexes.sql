BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'samplestudenttransportation.StudentTransportation') AND name = N'UX_StudentTransportation_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_StudentTransportation_Id ON [samplestudenttransportation].[StudentTransportation]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT


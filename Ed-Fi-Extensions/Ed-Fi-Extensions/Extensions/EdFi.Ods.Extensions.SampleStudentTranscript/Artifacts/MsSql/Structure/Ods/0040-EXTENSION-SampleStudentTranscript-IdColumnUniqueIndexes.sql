BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'samplestudenttranscript.PostSecondaryOrganization') AND name = N'UX_PostSecondaryOrganization_Id')
    CREATE UNIQUE NONCLUSTERED INDEX UX_PostSecondaryOrganization_Id ON [samplestudenttranscript].[PostSecondaryOrganization]
    (Id) WITH (PAD_INDEX = ON, FILLFACTOR = 75, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
    GO
COMMIT


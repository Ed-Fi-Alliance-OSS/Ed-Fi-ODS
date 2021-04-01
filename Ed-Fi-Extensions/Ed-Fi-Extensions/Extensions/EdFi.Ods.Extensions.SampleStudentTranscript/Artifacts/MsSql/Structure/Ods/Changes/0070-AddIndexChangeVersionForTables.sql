BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'samplestudenttranscript.PostSecondaryOrganization') AND name = N'UX_PostSecondaryOrganization_ChangeVersion')
    CREATE INDEX [UX_PostSecondaryOrganization_ChangeVersion] ON [samplestudenttranscript].[PostSecondaryOrganization] ([ChangeVersion] ASC)
    GO
COMMIT


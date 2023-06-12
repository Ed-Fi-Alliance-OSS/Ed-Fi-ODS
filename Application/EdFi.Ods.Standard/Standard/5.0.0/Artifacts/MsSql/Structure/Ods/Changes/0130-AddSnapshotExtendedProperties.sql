-- Extended Properties [changes].[Snapshot] --
IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('[changes].[Snapshot]') AND [name] = N'MS_Description' AND [minor_id] = 0)
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains information about a snapshot used to create isolation from ongoing changes for API client synchronization.', @level0type=N'SCHEMA', @level0name=N'changes', @level1type=N'TABLE', @level1name=N'Snapshot'
GO

IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('[changes].[Snapshot]') AND [name] = N'MS_Description' AND [minor_id] = (SELECT [column_id] FROM sys.columns WHERE [name] = 'SnapshotIdentifier' AND [object_id] = OBJECT_ID('[changes].[Snapshot]')))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the snapshot.', @level0type=N'SCHEMA', @level0name=N'changes', @level1type=N'TABLE', @level1name=N'Snapshot', @level2type=N'COLUMN', @level2name=N'SnapshotIdentifier'
GO

IF NOT EXISTS (SELECT 1 FROM sys.extended_properties WHERE [major_id] = OBJECT_ID('[changes].[Snapshot]') AND [name] = N'MS_Description' AND [minor_id] = (SELECT [column_id] FROM sys.columns WHERE [name] = 'SnapshotDateTime' AND [object_id] = OBJECT_ID('[changes].[Snapshot]')))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time that the snapshot was initiated.', @level0type=N'SCHEMA', @level0name=N'changes', @level1type=N'TABLE', @level1name=N'Snapshot', @level2type=N'COLUMN', @level2name=N'SnapshotDateTime'
GO

-- Extended Properties [publishing].[Snapshot] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains information about a snapshot used to create isolation from ongoing changes for API client synchronization.', @level0type=N'SCHEMA', @level0name=N'publishing', @level1type=N'TABLE', @level1name=N'Snapshot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the snapshot.', @level0type=N'SCHEMA', @level0name=N'publishing', @level1type=N'TABLE', @level1name=N'Snapshot', @level2type=N'COLUMN', @level2name=N'SnapshotIdentifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time that the snapshot was initiated.', @level0type=N'SCHEMA', @level0name=N'publishing', @level1type=N'TABLE', @level1name=N'Snapshot', @level2type=N'COLUMN', @level2name=N'SnapshotDateTime'
GO


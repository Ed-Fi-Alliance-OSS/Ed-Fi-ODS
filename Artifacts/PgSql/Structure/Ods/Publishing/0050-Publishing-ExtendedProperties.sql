-- Extended Properties [publishing].[Snapshot] --
COMMENT ON TABLE publishing.Snapshot IS 'Contains information about a snapshot used to create isolation from ongoing changes for API client synchronization.';
COMMENT ON COLUMN publishing.Snapshot.SnapshotIdentifier IS 'The unique identifier of the snapshot.';
COMMENT ON COLUMN publishing.Snapshot.SnapshotDateTime IS 'The date and time that the snapshot was initiated.';


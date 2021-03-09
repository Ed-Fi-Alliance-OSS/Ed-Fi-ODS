-- Extended Properties [changes].[Snapshot] --
COMMENT ON TABLE changes.Snapshot IS 'Contains information about a snapshot used to create isolation from ongoing changes for API client synchronization.';
COMMENT ON COLUMN changes.Snapshot.SnapshotIdentifier IS 'The unique identifier of the snapshot.';
COMMENT ON COLUMN changes.Snapshot.SnapshotDateTime IS 'The date and time that the snapshot was initiated.';


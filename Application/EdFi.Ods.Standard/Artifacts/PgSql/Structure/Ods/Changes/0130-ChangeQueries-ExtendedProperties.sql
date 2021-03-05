-- Extended Properties [changeQueries].[Snapshot] --
COMMENT ON TABLE changeQueries.Snapshot IS 'Contains information about a snapshot used to create isolation from ongoing changes for API client synchronization.';
COMMENT ON COLUMN changeQueries.Snapshot.SnapshotIdentifier IS 'The unique identifier of the snapshot.';
COMMENT ON COLUMN changeQueries.Snapshot.SnapshotDateTime IS 'The date and time that the snapshot was initiated.';


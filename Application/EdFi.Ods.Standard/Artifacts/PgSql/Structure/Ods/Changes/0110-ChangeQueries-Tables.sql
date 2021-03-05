-- Table changeQueries.Snapshot --
CREATE TABLE changeQueries.Snapshot (
    SnapshotIdentifier VARCHAR(32) NOT NULL,
    SnapshotDateTime TIMESTAMP NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Snapshot_PK PRIMARY KEY (SnapshotIdentifier)
); 
ALTER TABLE changeQueries.Snapshot ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE changeQueries.Snapshot ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE changeQueries.Snapshot ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;


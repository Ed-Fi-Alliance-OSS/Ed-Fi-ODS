-- Table changes.Snapshot --
CREATE TABLE changes.Snapshot (
    SnapshotIdentifier VARCHAR(32) NOT NULL,
    SnapshotDateTime TIMESTAMP NOT NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Snapshot_PK PRIMARY KEY (SnapshotIdentifier)
); 
ALTER TABLE changes.Snapshot ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE changes.Snapshot ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE changes.Snapshot ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;


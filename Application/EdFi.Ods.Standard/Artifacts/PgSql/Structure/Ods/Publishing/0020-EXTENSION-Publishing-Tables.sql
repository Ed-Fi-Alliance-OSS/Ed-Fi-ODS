-- Table publishing.Snapshot --
CREATE TABLE publishing.Snapshot (
    SnapshotIdentifier VARCHAR(32) NOT NULL,
    SnapshotDateTime TIMESTAMP NOT NULL,
    Discriminator VARCHAR(128) NULL,
    CreateDate TIMESTAMP NOT NULL,
    LastModifiedDate TIMESTAMP NOT NULL,
    Id UUID NOT NULL,
    CONSTRAINT Snapshot_PK PRIMARY KEY (SnapshotIdentifier)
); 
ALTER TABLE publishing.Snapshot ALTER COLUMN CreateDate SET DEFAULT current_timestamp;
ALTER TABLE publishing.Snapshot ALTER COLUMN Id SET DEFAULT gen_random_uuid();
ALTER TABLE publishing.Snapshot ALTER COLUMN LastModifiedDate SET DEFAULT current_timestamp;


-- Table [changes].[Snapshot] --
CREATE TABLE [changes].[Snapshot] (
    [SnapshotIdentifier] [NVARCHAR](32) NOT NULL,
    [SnapshotDateTime] [DATETIME2](7) NOT NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [Snapshot_PK] PRIMARY KEY CLUSTERED (
        [SnapshotIdentifier] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [changes].[Snapshot] ADD CONSTRAINT [Snapshot_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [changes].[Snapshot] ADD CONSTRAINT [Snapshot_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [changes].[Snapshot] ADD CONSTRAINT [Snapshot_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO


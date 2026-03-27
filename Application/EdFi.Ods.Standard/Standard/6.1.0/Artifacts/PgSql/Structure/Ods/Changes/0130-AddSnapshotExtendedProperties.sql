-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [changes].[Snapshot] --
COMMENT ON TABLE changes.Snapshot IS 'Contains information about a snapshot used to create isolation from ongoing changes for API client synchronization.';
COMMENT ON COLUMN changes.Snapshot.SnapshotIdentifier IS 'The unique identifier of the snapshot.';
COMMENT ON COLUMN changes.Snapshot.SnapshotDateTime IS 'The date and time that the snapshot was initiated.';


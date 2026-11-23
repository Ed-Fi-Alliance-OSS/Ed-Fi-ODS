-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Adds ApiClients.InheritsApplicationEducationOrganizations, which ODS Admin API 3 uses to record whether a client
-- inherits its Application's education organizations, including ones added later (true), or is narrowed to its own
-- rows in ApiClientApplicationEducationOrganizations (false). ODS/API does not read it.
-- The definition matches Admin API's script 00010, which skips creating the column when it already exists.
-- This script only adds the column: existing clients get the default, and setting their values is left to Admin API.
-- If Admin API already added the column, nothing changes.

ALTER TABLE dbo.ApiClients
    ADD COLUMN IF NOT EXISTS InheritsApplicationEducationOrganizations BOOLEAN NOT NULL DEFAULT TRUE;

-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.ResourceClaims ALTER COLUMN ResourceName NVARCHAR(255) NOT NULL;
ALTER TABLE dbo.ResourceClaims ALTER COLUMN ClaimName NVARCHAR(850) NOT NULL;
ALTER TABLE dbo.ResourceClaims ADD CONSTRAINT UC_ResourceClaims_ClaimName UNIQUE(ClaimName);

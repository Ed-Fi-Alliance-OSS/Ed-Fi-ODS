-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [homograph].[Name] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [homograph].[Parent] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [homograph].[School] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [homograph].[SchoolYearType] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [homograph].[Staff] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [homograph].[Student] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;

ALTER TABLE [homograph].[StudentSchoolAssociation] ADD [CreatedByOwnershipTokenId] SMALLINT NULL;


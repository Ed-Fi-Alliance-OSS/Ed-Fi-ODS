-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.ApiClients ADD CreatorOwnershipTokenId_OwnershipTokenId SMALLINT NULL;

ALTER TABLE dbo.ApiClients ADD  CONSTRAINT FK_ApiClients_CreatorOwnershipTokenId_OwnershipTokenId
    FOREIGN KEY(CreatorOwnershipTokenId_OwnershipTokenId)
REFERENCES dbo.OwnershipTokens (OwnershipTokenId);

CREATE INDEX IX_CreatorOwnershipTokenId_OwnershipTokenId ON dbo.ApiClients
(
    CreatorOwnershipTokenId_OwnershipTokenId ASC
);


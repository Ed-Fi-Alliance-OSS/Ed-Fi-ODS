-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE dbo.ApiClientOwnershipTokens(
    ApiClientOwnershipTokenId SERIAL PRIMARY KEY NOT NULL,
    ApiClient_ApiClientId INT NOT NULL,
    OwnershipToken_OwnershipTokenId SMALLINT NOT NULL
);

ALTER TABLE dbo.ApiClientOwnershipTokens
    ADD  CONSTRAINT FK_ApiClientOwnershipTokens_ApiClients_ApiClient_ApiClientId FOREIGN KEY(ApiClient_ApiClientId)
REFERENCES dbo.ApiClients (ApiClientId)
ON DELETE CASCADE;

ALTER TABLE dbo.ApiClientOwnershipTokens
    ADD  CONSTRAINT FK_ApiClientOwnershipTokens_OwnershipTokens_OwnershipToken_OwnershipTokenId FOREIGN KEY(OwnershipToken_OwnershipTokenId)
REFERENCES dbo.OwnershipTokens (OwnershipTokenId)
ON DELETE CASCADE;

CREATE INDEX IX_OwnershipToken_OwnershipTokenId ON dbo.ApiClientOwnershipTokens
(
    OwnershipToken_OwnershipTokenId ASC
);


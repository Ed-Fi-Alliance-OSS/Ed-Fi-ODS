-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [dbo].[ApiClients] ADD [CreatorOwnershipTokenId_OwnershipTokenId] SMALLINT NULL;
GO

ALTER TABLE [dbo].[ApiClients]  WITH CHECK
    ADD  CONSTRAINT [FK_ApiClients_OwnershipTokens_CreatorOwnershipTokenId_OwnershipTokenId]
    FOREIGN KEY([CreatorOwnershipTokenId_OwnershipTokenId])
REFERENCES [dbo].[OwnershipTokens] ([OwnershipTokenId]);
GO

ALTER TABLE [dbo].[ApiClients] CHECK CONSTRAINT [FK_ApiClients_OwnershipTokens_CreatorOwnershipTokenId_OwnershipTokenId];
GO

CREATE NONCLUSTERED INDEX [IX_CreatorOwnershipTokenId_OwnershipTokenId] ON [dbo].[ApiClients]
(
    [CreatorOwnershipTokenId_OwnershipTokenId] ASC
);
GO


-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ApiClientOwnershipTokens](
    [ApiClientOwnershipTokenId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [ApiClient_ApiClientId] INT NOT NULL,
    [OwnershipToken_OwnershipTokenId] SMALLINT NOT NULL,
);
GO

ALTER TABLE [dbo].[ApiClientOwnershipTokens]  WITH CHECK
    ADD  CONSTRAINT [FK_ApiClientOwnershipTokens_ApiClients_ApiClient_ApiClientId] FOREIGN KEY([ApiClient_ApiClientId])
REFERENCES [dbo].[ApiClients] ([ApiClientId])
ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[ApiClientOwnershipTokens] CHECK CONSTRAINT [FK_ApiClientOwnershipTokens_ApiClients_ApiClient_ApiClientId];
GO

ALTER TABLE [dbo].[ApiClientOwnershipTokens]  WITH CHECK
    ADD  CONSTRAINT [FK_ApiClientOwnershipTokens_OwnershipTokens_OwnershipToken_OwnershipTokenId] FOREIGN KEY([OwnershipToken_OwnershipTokenId])
REFERENCES [dbo].[OwnershipTokens] ([OwnershipTokenId])
ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[ApiClientOwnershipTokens] CHECK CONSTRAINT [FK_ApiClientOwnershipTokens_OwnershipTokens_OwnershipToken_OwnershipTokenId];
GO

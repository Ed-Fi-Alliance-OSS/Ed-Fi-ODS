-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Index [AK_ApiClients] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApiClients') AND name = N'AK_ApiClients')
    CREATE UNIQUE INDEX AK_ApiClients ON dbo.ApiClients ([Key])
    GO
COMMIT

-- Index [IX_VendorNamespacePrefixes_VendorId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.VendorNamespacePrefixes') AND name = N'IX_VendorNamespacePrefixes_VendorId')
    CREATE INDEX IX_VendorNamespacePrefixes_VendorId ON dbo.VendorNamespacePrefixes	(Vendor_VendorId) INCLUDE (NamespacePrefix)
    GO
COMMIT

-- Index [IX_ApiClientOwnershipTokens_ApiClientId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApiClientOwnershipTokens') AND name = N'IX_ApiClientOwnershipTokens_ApiClientId')
    CREATE INDEX IX_ApiClientOwnershipTokens_ApiClientId ON dbo.ApiClientOwnershipTokens (ApiClient_ApiClientId) INCLUDE (OwnershipToken_OwnershipTokenId)
    GO
COMMIT
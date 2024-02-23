-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Index AK_ApiClients --
CREATE UNIQUE INDEX IF NOT EXISTS AK_ApiClients ON dbo.ApiClients
(
    ApiClientId
);

-- Index IX_VendorNamespacePrefixes_VendorId --
CREATE INDEX IF NOT EXISTS IX_VendorNamespacePrefixes_VendorId ON dbo.VendorNamespacePrefixes
(
    Vendor_VendorId
) INCLUDE (NamespacePrefix);

-- Index IX_ApiClientOwnershipTokens_ApiClientId --
CREATE INDEX IF NOT EXISTS IX_ApiClientOwnershipTokens_ApiClientId ON dbo.ApiClientOwnershipTokens
(
    ApiClient_ApiClientId
) INCLUDE (OwnershipToken_OwnershipTokenId);
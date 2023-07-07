-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS c WHERE c.TABLE_NAME = 'ApplicationEducationOrganizations' and c.COLUMN_NAME = 'EducationOrganizationId' AND DATA_TYPE = 'int')
BEGIN

-- Drop the view using the EducationOrganizationId
DROP VIEW [dbo].[ApiClientIdentityRawDetails]

ALTER TABLE dbo.ApplicationEducationOrganizations ALTER COLUMN EducationOrganizationId BIGINT NOT NULL
END

GO

CREATE  VIEW dbo.ApiClientIdentityRawDetails AS
    SELECT
        ac.[Key]
        ,ac.[UseSandbox]
        ,ac.[StudentIdentificationSystemDescriptor]
        ,aeo.[EducationOrganizationId]
        ,app.[ClaimSetName]
        ,vnp.[NamespacePrefix]
        ,p.[ProfileName]
        ,ac.[CreatorOwnershipTokenId_OwnershipTokenId] as CreatorOwnershipTokenId
        ,acot.[OwnershipToken_OwnershipTokenId] as OwnershipTokenId
        ,ac.ApiClientId
        ,ac.Secret
        ,ac.SecretIsHashed
    FROM dbo.ApiClients ac
    INNER JOIN dbo.Applications app ON
        app.[ApplicationID] = ac.[Application_ApplicationID]
    LEFT OUTER JOIN Vendors v ON
        v.[VendorId] = app.[Vendor_VendorId]
    LEFT OUTER JOIN [dbo].[VendorNamespacePrefixes] vnp ON
        v.VendorId = vnp.Vendor_VendorId
    -- Outer join so client key is always returned even if no EdOrgs have been enabled
    LEFT OUTER JOIN [dbo].[ApiClientApplicationEducationOrganizations] acaeo ON
        acaeo.[ApiClient_ApiClientId] = ac.[ApiClientId]
    LEFT OUTER JOIN [dbo].[ApplicationEducationOrganizations] aeo ON
        aeo.[ApplicationEducationOrganizationId] = acaeo.[ApplicationEducationOrganization_ApplicationEducationOrganizationId]
    LEFT OUTER JOIN [dbo].[ProfileApplications] ap on
        ap.[Application_ApplicationId] = app.[ApplicationId]
    LEFT OUTER JOIN [dbo].[Profiles] p on
        p.[ProfileId] = ap.[Profile_ProfileId]
    LEFT OUTER JOIN [dbo].[ApiClientOwnershipTokens] acot ON
        ac.ApiClientId = acot.ApiClient_ApiClientId
GO
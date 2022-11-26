-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER VIEW [dbo].[ApiClientIdentityRawDetails] AS
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
    FROM ApiClients ac
    INNER JOIN Applications app ON
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

CREATE OR ALTER FUNCTION [dbo].[GetClientForToken] (
    @AccessToken uniqueidentifier
)
RETURNS TABLE
RETURN
    SELECT  d.[Key], d.UseSandbox, d.StudentIdentificationSystemDescriptor, d.EducationOrganizationId,
            d.ClaimSetName, d.NamespacePrefix, d.ProfileName, d.CreatorOwnershipTokenId, d.OwnershipTokenId,
            cat.Expiration, cat.ApiClient_ApiClientId AS ApiClientId
    FROM    ClientAccessTokens cat
        INNER JOIN dbo.ApiClientIdentityRawDetails d ON
            cat.[ApiClient_ApiClientId] = d.[ApiClientId]
    WHERE cat.[ID] = @AccessToken
          AND (cat.Scope IS NULL OR d.EducationOrganizationId = CONVERT(int, cat.Scope))
          AND cat.Expiration > GETUTCDATE()

GO

CREATE OR ALTER FUNCTION [dbo].[GetClientForKey] (
    @Key nvarchar(50)
)
RETURNS TABLE
RETURN
    SELECT  d.[Key], d.UseSandbox, d.StudentIdentificationSystemDescriptor, d.EducationOrganizationId,
            d.ClaimSetName, d.NamespacePrefix, d.ProfileName, d.CreatorOwnershipTokenId, d.OwnershipTokenId,
            d.ApiClientId, d.Secret, d.SecretIsHashed
    FROM    dbo.ApiClientIdentityRawDetails d
    WHERE   d.[Key] = @Key

GO

-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET QUOTED_IDENTIFIER ON;
GO
SET ANSI_NULLS ON;
GO

ALTER TABLE [dbo].[OdsInstances]
    ADD [ConnectionString] NVARCHAR(MAX);

CREATE TABLE [dbo].[ApiClientOdsInstances](
    [ApiClientOdsInstanceId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [ApiClient_ApiClientId] INT NOT NULL,
    [OdsInstance_OdsInstanceId] INT NOT NULL,
);
GO

ALTER TABLE [dbo].[ApiClientOdsInstances]  WITH CHECK
    ADD  CONSTRAINT [FK_ApiClientOdsInstances_ApiClients_ApiClient_ApiClientId] FOREIGN KEY([ApiClient_ApiClientId])
REFERENCES [dbo].[ApiClients] ([ApiClientId]);
GO

ALTER TABLE [dbo].[ApiClientOdsInstances] CHECK CONSTRAINT [FK_ApiClientOdsInstances_ApiClients_ApiClient_ApiClientId];
GO

ALTER TABLE [dbo].[ApiClientOdsInstances]  WITH CHECK
    ADD  CONSTRAINT [FK_ApiClientOdsInstances_OdsInstances_OdsInstance_OdsInstanceId] FOREIGN KEY([OdsInstance_OdsInstanceId])
REFERENCES [dbo].[OdsInstances] ([OdsInstanceId]);
GO

ALTER TABLE [dbo].[ApiClientOdsInstances] CHECK CONSTRAINT [FK_ApiClientOdsInstances_OdsInstances_OdsInstance_OdsInstanceId];
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.GetClientForToken') AND OBJECTPROPERTY(id, N'IsTableFunction') = 1 )
BEGIN
    DROP FUNCTION [dbo].[GetClientForToken];
END
GO

CREATE FUNCTION [dbo].[GetClientForToken] (
    @AccessToken uniqueidentifier
)
RETURNS TABLE
RETURN
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
        ,acoi.[OdsInstance_OdsInstanceId] as OdsInstanceId
        ,cat.[ApiClient_ApiClientId] as ApiClientId
        ,cat.[Expiration]
    FROM ClientAccessTokens cat
    INNER JOIN ApiClients ac ON
        cat.[ApiClient_ApiClientId] = ac.[ApiClientId]
        AND cat.[ID] = @AccessToken
    INNER JOIN Applications app ON
        app.[ApplicationID] = ac.[Application_ApplicationID]
    LEFT OUTER JOIN Vendors v ON
        v.[VendorId] = app.[Vendor_VendorId]
    LEFT OUTER JOIN [dbo].[VendorNamespacePrefixes] vnp ON
        v.VendorId = vnp.Vendor_VendorId
    -- Outer join so client key is always returned even if no EdOrgs have been enabled
    LEFT OUTER JOIN [dbo].[ApiClientApplicationEducationOrganizations] acaeo ON
        acaeo.[ApiClient_ApiClientId] = cat.[ApiClient_ApiClientId]
    LEFT OUTER JOIN [dbo].[ApplicationEducationOrganizations] aeo ON
        aeo.[ApplicationEducationOrganizationId] = acaeo.[ApplicationEducationOrganization_ApplicationEducationOrganizationId]
		AND (cat.Scope IS NULL OR aeo.EducationOrganizationId = CONVERT(int, cat.Scope))
    LEFT OUTER JOIN [dbo].[ProfileApplications] ap on
        ap.[Application_ApplicationId] = app.[ApplicationId]
    LEFT OUTER JOIN [dbo].[Profiles] p on
        p.[ProfileId] = ap.[Profile_ProfileId]
    LEFT OUTER JOIN [dbo].[ApiClientOwnershipTokens] acot ON
        ac.[ApiClientId] = acot.[ApiClient_ApiClientId]
    LEFT OUTER JOIN [dbo].[ApiClientOdsInstances] acoi ON
        acoi.[ApiClient_ApiClientId] = ac.[ApiClientId]
    WHERE cat.Expiration > GETUTCDATE()
GO

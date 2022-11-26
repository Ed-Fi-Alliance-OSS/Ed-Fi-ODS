-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW dbo.ApiClientIdentityRawDetails
AS
    SELECT
        ac.Key
        ,ac.UseSandbox
        ,ac.StudentIdentificationSystemDescriptor
        ,aeo.EducationOrganizationId
        ,app.ClaimSetName
        ,vnp.NamespacePrefix
        ,p.ProfileName
        ,ac.CreatorOwnershipTokenId_OwnershipTokenId AS CreatorOwnershipTokenId
        ,acot.OwnershipToken_OwnershipTokenId AS OwnershipTokenId
        ,ac.ApiClientId
        ,ac.Secret
        ,ac.SecretIsHashed
    FROM dbo.ApiClients ac
    INNER JOIN dbo.Applications app 
        ON app.ApplicationID = ac.Application_ApplicationID
    LEFT OUTER JOIN dbo.Vendors v 
        ON v.VendorId = app.Vendor_VendorId
    LEFT OUTER JOIN dbo.VendorNamespacePrefixes vnp
        ON v.VendorId = vnp.Vendor_VendorId
    -- Outer join so client key is always returned even if no EdOrgs have been enabled
    LEFT OUTER JOIN dbo.ApiClientApplicationEducationOrganizations acaeo
        ON acaeo.ApiClient_ApiClientId = ac.ApiClientId
    LEFT OUTER JOIN dbo.ApplicationEducationOrganizations aeo
        ON aeo.ApplicationEducationOrganizationId = acaeo.applicationedorg_applicationedorgid
    LEFT OUTER JOIN dbo.ProfileApplications ap
        ON ap.Application_ApplicationId = app.ApplicationId
    LEFT OUTER JOIN dbo.Profiles p
        ON p.ProfileId = ap.Profile_ProfileId
    LEFT OUTER JOIN dbo.ApiClientOwnershipTokens acot
        ON ac.ApiClientId = acot.ApiClient_ApiClientId;

DROP FUNCTION IF EXISTS dbo.GetClientForToken;

CREATE FUNCTION dbo.GetClientForToken (AccessToken UUID)
RETURNS TABLE (
    Key VARCHAR(50)
    ,UseSandbox BOOLEAN
    ,StudentIdentificationSystemDescriptor VARCHAR(306)
    ,EducationOrganizationId INT
    ,ClaimSetName VARCHAR(255)
    ,NamespacePrefix VARCHAR(255)
    ,ProfileName VARCHAR
    ,CreatorOwnershipTokenId SMALLINT
    ,OwnershipTokenId SMALLINT
    ,Expiration TIMESTAMP
    ,ApiClientId INT
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT
        d.Key
        ,d.UseSandbox
        ,d.StudentIdentificationSystemDescriptor
        ,d.EducationOrganizationId
        ,d.ClaimSetName
        ,d.NamespacePrefix
        ,d.ProfileName
        ,d.CreatorOwnershipTokenId
        ,d.OwnershipTokenId
        ,cat.Expiration
        ,cat.ApiClient_ApiClientId as ApiClientId
    FROM dbo.ClientAccessTokens cat
        INNER JOIN dbo.ApiClientIdentityRawDetails d
            ON cat.ApiClient_ApiClientId = d.ApiClientId
    WHERE cat.Id = AccessToken
          AND (cat.Scope IS NULL OR d.EducationOrganizationId = CAST(cat.Scope AS INTEGER))
          AND cat.Expiration > CURRENT_TIMESTAMP;
END
$$
LANGUAGE plpgsql;

DROP FUNCTION IF EXISTS dbo.GetClientForKey;

CREATE FUNCTION dbo.GetClientForKey (ApiKey VARCHAR(50))
RETURNS TABLE (
    Key VARCHAR(50)
    , UseSandbox BOOLEAN
    , StudentIdentificationSystemDescriptor VARCHAR(306)
    , EducationOrganizationId INT
    , ClaimSetName VARCHAR(255)
    , NamespacePrefix VARCHAR(255)
    , ProfileName VARCHAR
    , CreatorOwnershipTokenId SMALLINT
    , OwnershipTokenId SMALLINT
    , ApiClientId INT
    , Secret VARCHAR(100)
    , SecretIsHashed BOOLEAN
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT
        d.Key
        , d.UseSandbox
        , d.StudentIdentificationSystemDescriptor
        , d.EducationOrganizationId
        , d.ClaimSetName
        , d.NamespacePrefix
        , d.ProfileName
        , d.CreatorOwnershipTokenId
        , d.OwnershipTokenId
        , d.ApiClientId
        , d.Secret
        , d.SecretIsHashed
    FROM    dbo.ApiClientIdentityRawDetails d
    WHERE   d.Key = ApiKey;
END
$$
LANGUAGE plpgsql;
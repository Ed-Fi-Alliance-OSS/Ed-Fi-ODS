-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

    -- Drop the view using the EducationOrganizationId
    DROP VIEW IF EXISTS dbo.apiclientidentityrawdetails;
    -- Increase the size of the EducationOrganizationId column
    ALTER TABLE dbo.applicationeducationorganizations ALTER COLUMN educationorganizationid TYPE BIGINT;

    -- Recreate the view
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

    DROP FUNCTION IF EXISTS dbo.GetClientForKey;

    CREATE FUNCTION dbo.GetClientForKey (ApiKey VARCHAR(50))
    RETURNS TABLE (
        Key VARCHAR(50)
        , UseSandbox BOOLEAN
        , StudentIdentificationSystemDescriptor VARCHAR(306)
        , EducationOrganizationId BIGINT
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
    $BODY$
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
    $BODY$ LANGUAGE plpgsql;

    DROP FUNCTION IF EXISTS dbo.GetClientForToken;

    CREATE FUNCTION dbo.GetClientForToken (AccessToken UUID)
    RETURNS TABLE (
        Key VARCHAR(50)
        ,UseSandbox BOOLEAN
        ,StudentIdentificationSystemDescriptor VARCHAR(306)
        ,EducationOrganizationId BIGINT
        ,ClaimSetName VARCHAR(255)
        ,NamespacePrefix VARCHAR(255)
        ,ProfileName VARCHAR
        ,CreatorOwnershipTokenId SMALLINT
        ,OwnershipTokenId SMALLINT
        ,OdsInstanceId INT
        ,ApiClientId INT
        ,Expiration TIMESTAMP
    )
    AS
    $BODY$
    BEGIN
        RETURN QUERY
        SELECT
            ac.Key
            ,ac.UseSandbox
            ,ac.StudentIdentificationSystemDescriptor
            ,aeo.EducationOrganizationId
            ,app.ClaimSetName
            ,vnp.NamespacePrefix
            ,p.ProfileName
            ,ac.CreatorOwnershipTokenId_OwnershipTokenId as CreatorOwnershipTokenId
            ,acot.OwnershipToken_OwnershipTokenId as OwnershipTokenId
            ,acoi.OdsInstance_OdsInstanceId as OdsInstanceId
            ,cat.ApiClient_ApiClientId as ApiClientId
            ,cat.Expiration
        FROM dbo.ClientAccessTokens cat
             INNER JOIN dbo.ApiClients ac ON
            cat.ApiClient_ApiClientId = ac.ApiClientId
            AND cat.Id = AccessToken
             INNER JOIN dbo.Applications app ON
            app.ApplicationId = ac.Application_ApplicationId
             LEFT OUTER JOIN dbo.Vendors v ON
            v.VendorId = app.Vendor_VendorId
             LEFT OUTER JOIN dbo.VendorNamespacePrefixes vnp ON
            v.VendorId = vnp.Vendor_VendorId
             -- Outer join so client key is always returned even if no EdOrgs have been enabled
             LEFT OUTER JOIN dbo.ApiClientApplicationEducationOrganizations acaeo ON
            acaeo.ApiClient_ApiClientId = cat.ApiClient_ApiClientId
             LEFT OUTER JOIN dbo.ApplicationEducationOrganizations aeo ON
            aeo.ApplicationEducationOrganizationId = acaeo.ApplicationEdOrg_ApplicationEdOrgId
                AND (cat.Scope IS NULL OR aeo.EducationOrganizationId = CAST(cat.Scope AS INTEGER))
             LEFT OUTER JOIN dbo.ProfileApplications ap ON
            ap.Application_ApplicationId = app.ApplicationId
             LEFT OUTER JOIN dbo.Profiles p ON
            p.ProfileId = ap.Profile_ProfileId
            LEFT OUTER JOIN dbo.ApiClientOwnershipTokens acot ON
            ac.ApiClientId = acot.ApiClient_ApiClientId
            LEFT OUTER JOIN dbo.ApiClientOdsInstances acoi ON
            acoi.ApiClient_ApiClientId = ac.ApiClientId
        WHERE cat.Expiration > CURRENT_TIMESTAMP;
    END
    $BODY$ LANGUAGE plpgsql;


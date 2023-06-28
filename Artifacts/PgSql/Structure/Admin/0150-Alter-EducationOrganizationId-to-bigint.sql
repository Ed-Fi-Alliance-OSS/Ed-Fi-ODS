-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

do
$do$
begin
    if exists (select * from information_schema.columns c where c.table_name = 'applicationeducationorganizations' and c.column_name = 'educationorganizationid' AND DATA_TYPE = 'integer') then
        -- Drop the view using the EducationOrganizationId
        drop view dbo.apiclientidentityrawdetails;

        -- Increase the size of the EducationOrganizationId column
        alter table applicationeducationorganizations alter column educationorganizationid TYPE bigint;

        -- Recreate the view
        create view dbo.apiclientidentityrawdetails
            (key, usesandbox, studentidentificationsystemdescriptor, educationorganizationid, claimsetname,
             namespaceprefix, profilename, creatorownershiptokenid, ownershiptokenid, apiclientid, secret,
             secretishashed)
        as
        SELECT ac.key,
               ac.usesandbox,
               ac.studentidentificationsystemdescriptor,
               aeo.educationorganizationid,
               app.claimsetname,
               vnp.namespaceprefix,
               p.profilename,
               ac.creatorownershiptokenid_ownershiptokenid AS creatorownershiptokenid,
               acot.ownershiptoken_ownershiptokenid        AS ownershiptokenid,
               ac.apiclientid,
               ac.secret,
               ac.secretishashed
        FROM dbo.apiclients ac
                 JOIN dbo.applications app ON app.applicationid = ac.application_applicationid
                 LEFT JOIN dbo.vendors v ON v.vendorid = app.vendor_vendorid
                 LEFT JOIN dbo.vendornamespaceprefixes vnp ON v.vendorid = vnp.vendor_vendorid
                 LEFT JOIN dbo.apiclientapplicationeducationorganizations acaeo ON acaeo.apiclient_apiclientid = ac.apiclientid
                 LEFT JOIN dbo.applicationeducationorganizations aeo
                           ON aeo.applicationeducationorganizationid = acaeo.applicationedorg_applicationedorgid
                 LEFT JOIN dbo.profileapplications ap ON ap.application_applicationid = app.applicationid
                 LEFT JOIN dbo.profiles p ON p.profileid = ap.profile_profileid
                 LEFT JOIN dbo.apiclientownershiptokens acot ON ac.apiclientid = acot.apiclient_apiclientid;

        alter table dbo.apiclientidentityrawdetails
            owner to postgres;
    end if;
end
$do$

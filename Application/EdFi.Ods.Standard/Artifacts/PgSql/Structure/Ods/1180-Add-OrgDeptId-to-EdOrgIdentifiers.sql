-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- ALTER VIEW auth.educationorganizationidentifiers;
-- NOTE: Multiple results for a single Education Organization are possible if they are a part of multiple Education Organization Networks
CREATE OR REPLACE VIEW auth.educationorganizationidentifiers
 AS
 SELECT edorg.educationorganizationid,
        CASE
            WHEN sea.stateeducationagencyid IS NOT NULL THEN 'StateEducationAgency'::bpchar
            WHEN esc.educationservicecenterid IS NOT NULL THEN 'EducationServiceCenter'::bpchar
            WHEN lea.localeducationagencyid IS NOT NULL THEN 'LocalEducationAgency'::bpchar
            WHEN sch.schoolid IS NOT NULL THEN 'School'::bpchar
            WHEN co.communityorganizationid IS NOT NULL THEN 'CommunityOrganization'::bpchar
            WHEN cp.communityproviderid IS NOT NULL THEN 'CommunityProvider'::bpchar
            WHEN co.communityorganizationid IS NOT NULL THEN 'CommunityOrganization'::bpchar
            WHEN psi.postsecondaryinstitutionid IS NOT NULL THEN 'PostSecondaryInstitution'::bpchar
            WHEN od.organizationdepartmentid IS NOT NULL THEN N'OrganizationDepartment'::bpchar
            ELSE NULL::bpchar
        END AS educationorganizationtype,
    COALESCE(sea.stateeducationagencyid, esc.stateeducationagencyid, lea.stateeducationagencyid, lea_sch.stateeducationagencyid) AS stateeducationagencyid,
    COALESCE(esc.educationservicecenterid, lea.educationservicecenterid, lea_sch.educationservicecenterid) AS educationservicecenterid,
    COALESCE(lea.localeducationagencyid, sch.localeducationagencyid) AS localeducationagencyid,
    COALESCE(co.communityorganizationid, cp.communityorganizationid) AS communityorganizationid,
    cp.communityproviderid,
    psi.postsecondaryinstitutionid,
	od.organizationdepartmentid,
    sch.schoolid,
    edorg.discriminator AS fulleducationorganizationtype,
    edorg.nameofinstitution
   FROM edfi.educationorganization edorg
     LEFT JOIN edfi.stateeducationagency sea ON edorg.educationorganizationid = sea.stateeducationagencyid
     LEFT JOIN edfi.educationservicecenter esc ON edorg.educationorganizationid = esc.educationservicecenterid
     LEFT JOIN edfi.localeducationagency lea ON edorg.educationorganizationid = lea.localeducationagencyid
     LEFT JOIN edfi.school sch ON edorg.educationorganizationid = sch.schoolid
     LEFT JOIN edfi.localeducationagency lea_sch ON sch.localeducationagencyid = lea_sch.localeducationagencyid
     LEFT JOIN edfi.communityorganization co ON edorg.educationorganizationid = co.communityorganizationid
     LEFT JOIN edfi.communityprovider cp ON edorg.educationorganizationid = cp.communityproviderid
     LEFT JOIN edfi.communityorganization cp_co ON cp.communityorganizationid = cp_co.communityorganizationid
     LEFT JOIN edfi.postsecondaryinstitution psi ON edorg.educationorganizationid = psi.postsecondaryinstitutionid
     LEFT JOIN edfi.organizationdepartment  od ON edorg.educationorganizationid = od.organizationdepartmentid	 
  WHERE
        CASE
            WHEN sea.stateeducationagencyid IS NOT NULL THEN 'StateEducationAgency'::bpchar
            WHEN esc.educationservicecenterid IS NOT NULL THEN 'EducationServiceCenter'::bpchar
            WHEN lea.localeducationagencyid IS NOT NULL THEN 'LocalEducationAgency'::bpchar
            WHEN sch.schoolid IS NOT NULL THEN 'School'::bpchar
            WHEN co.communityorganizationid IS NOT NULL THEN 'CommunityOrganization'::bpchar
            WHEN cp.communityproviderid IS NOT NULL THEN 'CommunityProvider'::bpchar
            WHEN psi.postsecondaryinstitutionid IS NOT NULL THEN 'PostSecondaryInstitution'::bpchar
            WHEN od.organizationdepartmentid IS NOT NULL THEN 'OrganizationDepartment'::bpchar			
            ELSE NULL::bpchar
        END IS NOT NULL;

ALTER TABLE auth.educationorganizationidentifiers
    OWNER TO postgres;


-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS auth.EducationOrganizationIdToCommunityOrganizationId;

DROP VIEW IF EXISTS auth.EducationOrganizationIdToCommunityProviderId;

CREATE VIEW auth.CommunityOrganizationIdToEducationOrganizationId
AS
    SELECT CommunityOrganizationId
         ,CommunityProviderId AS EducationOrganizationId
    FROM edfi.CommunityProvider

    UNION

    SELECT CommunityOrganizationId
         ,CommunityOrganizationId AS EducationOrganizationId
    FROM edfi.CommunityOrganization;

CREATE VIEW auth.CommunityProviderIdToEducationOrganizationId
AS
SELECT CommunityProviderId
     ,CommunityProviderId AS EducationOrganizationId
FROM edfi.CommunityProvider;

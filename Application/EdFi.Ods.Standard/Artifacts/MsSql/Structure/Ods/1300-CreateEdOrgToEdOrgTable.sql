-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE auth.EducationOrganizationIdToEducationOrganizationId (
    SourceEducationOrganizationId INT NOT NULL,
    TargetEducationOrganizationId INT NOT NULL,
    EducationOrganizationType nvarchar(128) NULL,
    NameOfInstitution [nvarchar](75) NOT NULL
    CONSTRAINT [EducationOrganizationIdToEducationOrganizationId_PK] PRIMARY KEY CLUSTERED (
        [SourceEducationOrganizationId] ASC,
        [TargetEducationOrganizationId] ASC
    )
)
GO
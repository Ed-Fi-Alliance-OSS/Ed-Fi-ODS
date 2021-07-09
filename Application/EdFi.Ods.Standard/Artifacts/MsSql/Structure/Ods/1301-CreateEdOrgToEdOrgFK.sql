-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE auth.EducationOrganizationIdToEducationOrganizationId WITH CHECK ADD CONSTRAINT FK_Source_EducationOrganization FOREIGN KEY (SourceEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
GO

ALTER TABLE auth.EducationOrganizationIdToEducationOrganizationId WITH CHECK ADD CONSTRAINT FK_Target_EducationOrganization FOREIGN KEY (TargetEducationOrganizationId)
REFERENCES edfi.EducationOrganization (EducationOrganizationId)
GO
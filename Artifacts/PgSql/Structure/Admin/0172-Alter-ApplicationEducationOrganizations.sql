
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP INDEX dbo.IX_Application_ApplicationId;

DELETE FROM dbo.ApplicationEducationOrganizations WHERE Application_ApplicationId IS NULL;

ALTER TABLE dbo.ApplicationEducationOrganizations ALTER COLUMN Application_ApplicationId SET NOT NULL;

CREATE INDEX IX_Application_ApplicationId ON dbo.ApplicationEducationOrganizations
(
	Application_ApplicationId
);

-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


DROP INDEX [dbo].[ApplicationEducationOrganizations].[IX_Application_ApplicationId];
GO

DELETE FROM [dbo].[ApplicationEducationOrganizations] WHERE Application_ApplicationId IS NULL;

ALTER TABLE [dbo].[ApplicationEducationOrganizations] ALTER COLUMN Application_ApplicationId INT NOT NULL;
GO

CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId] ON [dbo].[ApplicationEducationOrganizations]
(
	[Application_ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Index IX_ApiClient_ApiClientId --
CREATE INDEX IF NOT EXISTS IX_ApiClient_ApiClientId ON dbo.ApiClientApplicationEducationOrganizations
(
	ApiClient_ApiClientId
);

-- Index IX_ApplicationEdOrg_ApplicationEdOrgId --
CREATE INDEX IF NOT EXISTS IX_ApplicationEdOrg_ApplicationEdOrgId ON dbo.ApiClientApplicationEducationOrganizations
(
	ApplicationEdOrg_ApplicationEdOrgId
);

-- Index IX_Application_ApplicationId --
CREATE INDEX IF NOT EXISTS IX_Application_ApplicationId ON dbo.ApiClients
(
	Application_ApplicationId
);

-- Index IX_User_UserId --
CREATE INDEX IF NOT EXISTS IX_User_UserId ON dbo.ApiClients
(
	User_UserId
);

-- Index IX_Application_ApplicationId --
CREATE INDEX IF NOT EXISTS IX_Application_ApplicationId ON dbo.ApplicationEducationOrganizations
(
	Application_ApplicationId
);

-- Index IX_OdsInstance_OdsInstanceId --
CREATE INDEX IF NOT EXISTS IX_OdsInstance_OdsInstanceId ON dbo.Applications
(
	OdsInstance_OdsInstanceId
);

-- Index IX_Vendor_VendorId --
CREATE INDEX IF NOT EXISTS IX_Vendor_VendorId ON dbo.Applications
(
	Vendor_VendorId
);

-- Index IX_ApiClient_ApiClientId --
CREATE INDEX IF NOT EXISTS IX_ApiClient_ApiClientId ON dbo.ClientAccessTokens
(
	ApiClient_ApiClientId
);

-- Index IX_OdsInstance_OdsInstanceId --
CREATE INDEX IF NOT EXISTS IX_OdsInstance_OdsInstanceId ON dbo.OdsInstanceComponents
(
	OdsInstance_OdsInstanceId
);

-- Index IX_Application_ApplicationId --
CREATE INDEX IF NOT EXISTS IX_Application_ApplicationId ON dbo.ProfileApplications
(
	Application_ApplicationId
);

-- Index IX_Profile_ProfileId --
CREATE INDEX IF NOT EXISTS IX_Profile_ProfileId ON dbo.ProfileApplications
	(
		Profile_ProfileId
	);

-- Index IX_Vendor_VendorId --
CREATE INDEX IF NOT EXISTS IX_Vendor_VendorId ON dbo.Users
(
	Vendor_VendorId
);

-- Index IX_Vendor_VendorId --
CREATE INDEX IF NOT EXISTS IX_Vendor_VendorId ON dbo.VendorNamespacePrefixes
(
	Vendor_VendorId
);

-- Index UX_OdsInstance_OdsInstanceId_Name --
CREATE UNIQUE INDEX UX_OdsInstance_OdsInstanceId_Name ON dbo.OdsInstanceComponents
(
	OdsInstance_OdsInstanceId,
	Name
);

-- Index UX_Name_InstanceType --
CREATE UNIQUE INDEX UX_Name_InstanceType ON dbo.OdsInstances
(
	Name,
	InstanceType
);

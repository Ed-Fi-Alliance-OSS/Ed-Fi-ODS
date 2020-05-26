-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Index [IX_ApiClient_ApiClientId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApiClientApplicationEducationOrganizations') AND name = N'IX_ApiClient_ApiClientId')
	CREATE NONCLUSTERED INDEX [IX_ApiClient_ApiClientId] ON [dbo].[ApiClientApplicationEducationOrganizations]
	(
		[ApiClient_ApiClientId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_ApplicationEducationOrganization_ApplicationEducationOrganizationId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApiClientApplicationEducationOrganizations') AND name = N'IX_ApplicationEducationOrganization_ApplicationEducationOrganizationId')
	CREATE NONCLUSTERED INDEX [IX_ApplicationEducationOrganization_ApplicationEducationOrganizationId] ON [dbo].[ApiClientApplicationEducationOrganizations]
	(
		[ApplicationEducationOrganization_ApplicationEducationOrganizationId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Application_ApplicationId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApiClients') AND name = N'IX_Application_ApplicationId')
	CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId] ON [dbo].[ApiClients]
	(
		[Application_ApplicationId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_User_UserId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApiClients') AND name = N'IX_User_UserId')
	CREATE NONCLUSTERED INDEX [IX_User_UserId] ON [dbo].[ApiClients]
	(
		[User_UserId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Application_ApplicationId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ApplicationEducationOrganizations') AND name = N'IX_Application_ApplicationId')
	CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId] ON [dbo].[ApplicationEducationOrganizations]
	(
		[Application_ApplicationId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_OdsInstance_OdsInstanceId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Applications') AND name = N'IX_OdsInstance_OdsInstanceId')
	CREATE NONCLUSTERED INDEX [IX_OdsInstance_OdsInstanceId] ON [dbo].[Applications]
	(
		[OdsInstance_OdsInstanceId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Vendor_VendorId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Applications') AND name = N'IX_Vendor_VendorId')
	CREATE NONCLUSTERED INDEX [IX_Vendor_VendorId] ON [dbo].[Applications]
	(
		[Vendor_VendorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_ApiClient_ApiClientId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ClientAccessTokens') AND name = N'IX_ApiClient_ApiClientId')
	CREATE NONCLUSTERED INDEX [IX_ApiClient_ApiClientId] ON [dbo].[ClientAccessTokens]
	(
		[ApiClient_ApiClientId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_OdsInstance_OdsInstanceId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.OdsInstanceComponents') AND name = N'IX_OdsInstance_OdsInstanceId')
	CREATE NONCLUSTERED INDEX [IX_OdsInstance_OdsInstanceId] ON [dbo].[OdsInstanceComponents]
	(
		[OdsInstance_OdsInstanceId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Application_ApplicationId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ProfileApplications') AND name = N'IX_Application_ApplicationId')
	CREATE NONCLUSTERED INDEX [IX_Application_ApplicationId] ON [dbo].[ProfileApplications]
	(
		[Application_ApplicationId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Profile_ProfileId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.ProfileApplications') AND name = N'IX_Profile_ProfileId')
	CREATE NONCLUSTERED INDEX [IX_Profile_ProfileId] ON [dbo].[ProfileApplications]
	(
		[Profile_ProfileId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Vendor_VendorId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.Users') AND name = N'IX_Vendor_VendorId')
	CREATE NONCLUSTERED INDEX [IX_Vendor_VendorId] ON [dbo].[Users]
	(
		[Vendor_VendorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [IX_Vendor_VendorId] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.VendorNamespacePrefixes') AND name = N'IX_Vendor_VendorId')
	CREATE NONCLUSTERED INDEX [IX_Vendor_VendorId] ON [dbo].[VendorNamespacePrefixes]
	(
		[Vendor_VendorId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [UX_OdsInstance_OdsInstanceId_Name] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.OdsInstanceComponents') AND name = N'UX_OdsInstance_OdsInstanceId_Name')
	CREATE UNIQUE NONCLUSTERED INDEX [UX_OdsInstance_OdsInstanceId_Name] ON [dbo].[OdsInstanceComponents]
	(
		[OdsInstance_OdsInstanceId] ASC,
		[Name] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

-- Index [UX_Name_InstanceType] --
BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'dbo.OdsInstances') AND name = N'UX_Name_InstanceType')
	CREATE UNIQUE NONCLUSTERED INDEX [UX_Name_InstanceType] ON [dbo].[OdsInstances]
	(
		[Name] ASC,
		[InstanceType] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	GO
COMMIT

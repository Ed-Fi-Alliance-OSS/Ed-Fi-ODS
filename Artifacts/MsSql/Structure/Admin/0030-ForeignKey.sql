-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [dbo].[ApiClients]  WITH CHECK ADD CONSTRAINT [FK_ApiClients_Applications] FOREIGN KEY([Application_ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO

ALTER TABLE [dbo].[ApiClients]  WITH CHECK ADD CONSTRAINT [FK_ApiClients_Users] FOREIGN KEY([User_UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[ApplicationEducationOrganizations]  WITH CHECK ADD CONSTRAINT [FK_ApplicationEducationOrganizations_Applications] FOREIGN KEY([Application_ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO

ALTER TABLE [dbo].[Applications]  WITH CHECK ADD CONSTRAINT [FK_Applications_OdsInstances] FOREIGN KEY([OdsInstance_OdsInstanceId])
REFERENCES [dbo].[OdsInstances] ([OdsInstanceId])
GO

ALTER TABLE [dbo].[Applications]  WITH CHECK ADD CONSTRAINT [FK_Applications_Vendors] FOREIGN KEY([Vendor_VendorId])
REFERENCES [dbo].[Vendors] ([VendorId])
GO

ALTER TABLE [dbo].[ClientAccessTokens]  WITH CHECK ADD CONSTRAINT [FK_ClientAccessTokens_ApiClients] FOREIGN KEY([ApiClient_ApiClientId])
REFERENCES [dbo].[ApiClients] ([ApiClientId])
GO

ALTER TABLE [dbo].[OdsInstanceComponents]  WITH CHECK ADD CONSTRAINT [FK_OdsInstanceComponents_OdsInstances] FOREIGN KEY([OdsInstance_OdsInstanceId])
REFERENCES [dbo].[OdsInstances] ([OdsInstanceId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProfileApplications]  WITH CHECK ADD CONSTRAINT [FK_ProfileApplications_Applications] FOREIGN KEY([Application_ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ProfileApplications]  WITH CHECK ADD CONSTRAINT [FK_ProfileApplications_Profiles] FOREIGN KEY([Profile_ProfileId])
REFERENCES [dbo].[Profiles] ([ProfileId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD CONSTRAINT [FK_Users_Vendors] FOREIGN KEY([Vendor_VendorId])
REFERENCES [dbo].[Vendors] ([VendorId])
GO

ALTER TABLE [dbo].[VendorNamespacePrefixes]  WITH CHECK ADD CONSTRAINT [FK_VendorNamespacePrefixes_Vendors] FOREIGN KEY([Vendor_VendorId])
REFERENCES [dbo].[Vendors] ([VendorId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ApiClientApplicationEducationOrganizations]  WITH CHECK ADD CONSTRAINT [FK_ApiClientApplicationEducationOrganizations_ApiClients] FOREIGN KEY([ApiClient_ApiClientId])
REFERENCES [dbo].[ApiClients] ([ApiClientId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ApiClientApplicationEducationOrganizations]  WITH CHECK ADD CONSTRAINT [FK_ApiClientApplicationEducationOrganizations_ApplicationEducationOrganizations] FOREIGN KEY([ApplicationEducationOrganization_ApplicationEducationOrganizationId])
REFERENCES [dbo].[ApplicationEducationOrganizations] ([ApplicationEducationOrganizationId])
ON DELETE CASCADE
GO

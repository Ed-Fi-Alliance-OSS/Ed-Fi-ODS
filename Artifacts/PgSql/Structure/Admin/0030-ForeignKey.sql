-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.ApiClients ADD CONSTRAINT FK_ApiClients_Applications FOREIGN KEY(Application_ApplicationId)
REFERENCES dbo.Applications (ApplicationId)
;

ALTER TABLE dbo.ApiClients ADD CONSTRAINT FK_ApiClients_Users FOREIGN KEY(User_UserId)
REFERENCES dbo.Users (UserId)
;

ALTER TABLE dbo.ApplicationEducationOrganizations ADD CONSTRAINT FK_ApplicationEducationOrganizations_Applications FOREIGN KEY(Application_ApplicationId)
REFERENCES dbo.Applications (ApplicationId)
;

ALTER TABLE dbo.Applications ADD CONSTRAINT FK_Applications_OdsInstances FOREIGN KEY(OdsInstance_OdsInstanceId)
REFERENCES dbo.OdsInstances (OdsInstanceId)
;

ALTER TABLE dbo.Applications ADD CONSTRAINT FK_Applications_Vendors FOREIGN KEY(Vendor_VendorId)
REFERENCES dbo.Vendors (VendorId)
;

ALTER TABLE dbo.ClientAccessTokens ADD CONSTRAINT FK_ClientAccessTokens_ApiClients FOREIGN KEY(ApiClient_ApiClientId)
REFERENCES dbo.ApiClients (ApiClientId)
;

ALTER TABLE dbo.OdsInstanceComponents ADD CONSTRAINT FK_OdsInstanceComponents_OdsInstances FOREIGN KEY(OdsInstance_OdsInstanceId)
REFERENCES dbo.OdsInstances (OdsInstanceId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ProfileApplications ADD CONSTRAINT FK_ProfileApplications_Applications FOREIGN KEY(Application_ApplicationId)
REFERENCES dbo.Applications (ApplicationId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ProfileApplications ADD CONSTRAINT FK_ProfileApplications_Profiles FOREIGN KEY(Profile_ProfileId)
REFERENCES dbo.Profiles (ProfileId)
ON DELETE CASCADE
;

ALTER TABLE dbo.Users ADD CONSTRAINT FK_Users_Vendors FOREIGN KEY(Vendor_VendorId)
REFERENCES dbo.Vendors (VendorId)
;

ALTER TABLE dbo.VendorNamespacePrefixes ADD CONSTRAINT FK_VendorNamespacePrefixes_Vendors FOREIGN KEY(Vendor_VendorId)
REFERENCES dbo.Vendors (VendorId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ApiClientApplicationEducationOrganizations ADD CONSTRAINT FK_ApiClientApplicationEducationOrganizations_ApiClients FOREIGN KEY(ApiClient_ApiClientId)
REFERENCES dbo.ApiClients (ApiClientId)
ON DELETE CASCADE
;

ALTER TABLE dbo.ApiClientApplicationEducationOrganizations ADD CONSTRAINT FK_ApiClientApplicationEdOrg_ApplicationEdOrg FOREIGN KEY(ApplicationEdOrg_ApplicationEdOrgId)
REFERENCES dbo.ApplicationEducationOrganizations (ApplicationEducationOrganizationId)
ON DELETE CASCADE
;

-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

INSERT INTO [dbo].[OdsInstances] ([Name], [InstanceType], [ConnectionString])
SELECT 'default', 'ODS', 'Server=ed-fi-db-ods;User Id=edfi;Password=P@ssw0rd1!;Database=EdFi_Ods;Application Name=EdFi.Ods.WebApi;Encrypt=false'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[OdsInstances] WHERE [Name] = 'default');

INSERT INTO [dbo].[Vendors] ([VendorName])
SELECT 'Bootstrap Vendor'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Vendors] WHERE [VendorName] = 'Bootstrap Vendor');

INSERT INTO [dbo].[VendorNamespacePrefixes] ([NamespacePrefix], [Vendor_VendorId])
SELECT 'uri://ed-fi.org', [VendorId] FROM [dbo].[Vendors]
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[VendorNamespacePrefixes] WHERE [NamespacePrefix] = 'uri://ed-fi.org');

INSERT INTO [dbo].[Applications] ([ApplicationName], [OperationalContextUri], [Vendor_VendorId], [ClaimSetName])
SELECT 'Bootstrap Application', 'uri://ed-fi.org', [VendorId], 'Ed-Fi Sandbox' FROM [dbo].[Vendors]
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Applications] WHERE [ApplicationName] = 'Bootstrap Application');

INSERT INTO [dbo].[ApplicationEducationOrganizations] ([EducationOrganizationId], [Application_ApplicationId])
SELECT 255901001, [ApplicationId]
FROM [dbo].[Applications]
WHERE [ApplicationName] = 'Bootstrap Application'
    AND NOT EXISTS (SELECT 1 FROM [dbo].[ApplicationEducationOrganizations] WHERE [EducationOrganizationId] = 255901001);

INSERT INTO [dbo].ApiClients ([Key], [Secret], [Name], [IsApproved], [UseSandbox], [SandboxType], [SecretIsHashed], [Application_ApplicationId])
SELECT 'minimalKey', 'minimalSecret', 'Bootstrap', 1, 0, 0, 0, [ApplicationId] FROM [dbo].[Applications]
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[ApiClients] WHERE [Name] = 'Bootstrap');

INSERT INTO [dbo].[ApiClientApplicationEducationOrganizations] ([ApiClient_ApiClientId], [ApplicationEducationOrganization_ApplicationEducationOrganizationId]) 
SELECT [ApiClients].[ApiClientId], [ApplicationEducationOrganizations].[ApplicationEducationOrganizationId]
FROM [dbo].[ApiClients]
CROSS JOIN [dbo].[Applications]
INNER JOIN [dbo].[ApplicationEducationOrganizations] ON [Applications].[ApplicationId] = [ApplicationEducationOrganizations].[Application_ApplicationId]
WHERE [ApiClients].[Name] = 'Bootstrap' AND [Applications].[ApplicationName] = 'Bootstrap Application'
AND NOT EXISTS (SELECT 1 FROM [dbo].[ApiClientApplicationEducationOrganizations]
    WHERE [ApiClient_ApiClientId] = [ApiClients].[ApiClientId]
    AND [ApplicationEducationOrganization_ApplicationEducationOrganizationId] = [ApplicationEducationOrganizations].[ApplicationEducationOrganizationId]);

INSERT INTO [dbo].[ApiClientOdsInstances] ([ApiClient_ApiClientId], [OdsInstance_OdsInstanceId])
SELECT [ApiClients].[ApiClientId], [OdsInstances].[OdsInstanceId]
FROM [dbo].[ApiClients]
CROSS JOIN [dbo].[OdsInstances]
WHERE [ApiClients].[Name] = 'Bootstrap' AND [OdsInstances].[Name] = 'default'
AND NOT EXISTS (SELECT 1 FROM [dbo].[ApiClientOdsInstances]
    WHERE [ApiClient_ApiClientId] = [ApiClients].[ApiClientId] AND [OdsInstance_OdsInstanceId] = [OdsInstances].[OdsInstanceId]);

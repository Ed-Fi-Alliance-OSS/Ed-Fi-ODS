-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

UPDATE dbo.ClaimSets
SET ForApplicationUseOnly = 'TRUE'
WHERE ClaimSetName in ('Bootstrap Descriptors and EdOrgs','Ed-Fi ODS Admin App');

UPDATE dbo.ClaimSets
SET IsEdfiPreset = 'TRUE'
WHERE ClaimSetName in ('SIS Vendor','Ed-Fi Sandbox','Roster Vendor','Assessment Vendor','Assessment Read',
'Bootstrap Descriptors and EdOrgs','Ownership Based Test','District Hosted SIS Vendor','Ed-Fi ODS Admin App','AB Connect');

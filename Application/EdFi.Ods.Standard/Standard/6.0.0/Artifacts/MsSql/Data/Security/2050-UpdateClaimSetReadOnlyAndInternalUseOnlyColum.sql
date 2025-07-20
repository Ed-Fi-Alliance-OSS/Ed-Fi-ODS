-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

UPDATE [dbo].[ClaimSets]
SET [ForApplicationUseOnly] = 1 
WHERE [ClaimSetName] in ('Ed-Fi ODS Admin App')
GO

UPDATE [dbo].[ClaimSets]
SET [IsEdfiPreset] = 1 
WHERE [ClaimSetName] in ('Ed-Fi ODS Admin App','AB Connect')
GO
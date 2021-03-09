-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (SELECT * FROM sys.sequences WHERE object_id = OBJECT_ID(N'[changes].[ChangeVersionSequence]'))
BEGIN
CREATE SEQUENCE [changes].[ChangeVersionSequence] START WITH 0
END
GO

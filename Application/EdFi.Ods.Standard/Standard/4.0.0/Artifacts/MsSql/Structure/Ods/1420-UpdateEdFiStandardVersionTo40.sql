-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF object_id('util.GetEdFiStandardVersion', 'FN') IS NOT NULL
BEGIN
    DROP FUNCTION util.GetEdFiStandardVersion;
END
GO

CREATE FUNCTION util.GetEdFiStandardVersion()
RETURNS VARCHAR(60)
AS
BEGIN
    RETURN '4.0'
END
GO
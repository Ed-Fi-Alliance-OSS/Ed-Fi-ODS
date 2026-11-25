-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER FUNCTION [changes].GetMaxChangeVersion()
RETURNS bigint
AS
BEGIN
    DECLARE @Result bigint;
    SELECT @Result = CONVERT(bigint, seq.current_value) FROM sys.sequences seq
    INNER JOIN sys.schemas sch
    ON seq.schema_id = sch.schema_id
    WHERE seq.name = 'ChangeVersionSequence' AND sch.name = 'changes';
    RETURN @Result;
END
GO
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP FUNCTION IF EXISTS dbo.GetOdsInstanceConfigurationById;

CREATE FUNCTION dbo.GetOdsInstanceConfigurationById (ods_instanceId INT)
RETURNS TABLE (
    OdsInstanceId INT
    ,ConnectionString VARCHAR(500)
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT  ods.OdsInstanceId, ods.ConnectionString
    FROM    dbo.OdsInstances ods
    WHERE   ods.OdsInstanceId = ods_instanceId;
END
$$
LANGUAGE plpgsql;

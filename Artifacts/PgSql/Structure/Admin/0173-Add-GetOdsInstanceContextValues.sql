-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE FUNCTION dbo.getodsinstancecontextvalues (apikey character varying)
    RETURNS TABLE(key VARCHAR(50)
)
AS
$$
BEGIN
	RETURN QUERY
	SELECT DISTINCT
          ctx.contextvalue
    FROM dbo.odsoinstances ods
    INNER JOIN dbo.odsinstanceContexts ctx 
        ON ods.OdsInstanceId = ctx.OdsInstance_OdsInstanceId
		WHERE ctx.ContextKey = @ContextKey;
END
$$
LANGUAGE plpgsql;

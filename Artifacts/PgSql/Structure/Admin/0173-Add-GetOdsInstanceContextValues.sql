-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE FUNCTION dbo.getodsinstancecontextvalues (contextkey VARCHAR(50))
    RETURNS TABLE(contextvalue VARCHAR(50))
AS
$$
#variable_conflict use_variable
BEGIN
	RETURN QUERY
	SELECT DISTINCT
          ctx.contextvalue
    FROM dbo.odsinstances ods
    INNER JOIN dbo.odsinstancecontexts ctx 
        ON ods.odsinstanceid = ctx.odsinstance_odsinstanceid
		WHERE ctx.contextkey = contextkey;
END
$$
LANGUAGE plpgsql;

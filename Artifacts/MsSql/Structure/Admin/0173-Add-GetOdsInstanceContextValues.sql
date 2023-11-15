-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE FUNCTION [dbo].GetOdsInstanceContextValues (
	@ContextKey nvarchar(50)
)
RETURNS TABLE
RETURN
    SELECT DISTINCT
          ctx.ContextValue
    FROM dbo.OdsInstances ods
    INNER JOIN dbo.OdsInstanceContexts ctx 
        ON ods.OdsInstanceId = ctx.OdsInstance_OdsInstanceId
		WHERE ctx.ContextKey = @ContextKey

GO

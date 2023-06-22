-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER FUNCTION dbo.GetOdsInstanceConfigurationById (
    @OdsInstanceId int
)
RETURNS TABLE
RETURN
    SELECT  ods.OdsInstanceId
            ,ods.ConnectionString
            ,ctx.ContextKey
            ,ctx.ContextValue
            ,der.DerivativeType
            ,der.ConnectionString AS ConnectionStringByDerivativeType
    FROM dbo.OdsInstances ods
    LEFT JOIN dbo.OdsInstanceContext ctx 
        ON ods.OdsInstanceId = ctx.OdsInstanceId
    LEFT JOIN dbo.OdsInstanceDerivative der 
        ON ods.OdsInstanceId = der.OdsInstanceId
    WHERE   ods.OdsInstanceId = @OdsInstanceId
GO

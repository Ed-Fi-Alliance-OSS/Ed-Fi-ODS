-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [dbo].[OdsInstanceContext]
DROP CONSTRAINT [FK_OdsInstanceContext_OdsInstanceId_OdsInstanceId];

ALTER TABLE [dbo].[OdsInstanceContext]
DROP CONSTRAINT [UC_OdsInstanceDerivative_OdsInstanceId_ContextKey];
    
EXEC SP_RENAME 'dbo.OdsInstanceContext.OdsInstanceId', 'OdsInstance_OdsInstanceId', 'COLUMN';
EXEC SP_RENAME 'dbo.OdsInstanceContext', 'OdsInstanceContexts';

ALTER TABLE [dbo].[OdsInstanceContexts]  WITH CHECK
ADD
    CONSTRAINT [FK_OdsInstanceContext_OdsInstance_OdsInstanceId] FOREIGN KEY([OdsInstance_OdsInstanceId]) REFERENCES [dbo].[OdsInstances] ([OdsInstanceId]),
    CONSTRAINT [UC_OdsInstanceContext_OdsInstance_OdsInstanceId_ContextKey] UNIQUE(OdsInstance_OdsInstanceId, ContextKey);
GO

ALTER TABLE [dbo].[OdsInstanceContexts] CHECK CONSTRAINT [FK_OdsInstanceContext_OdsInstance_OdsInstanceId];
GO

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
    LEFT JOIN dbo.OdsInstanceContexts ctx 
        ON ods.OdsInstanceId = ctx.OdsInstance_OdsInstanceId
    LEFT JOIN dbo.OdsInstanceDerivative der 
        ON ods.OdsInstanceId = der.OdsInstanceId
    WHERE   ods.OdsInstanceId = @OdsInstanceId
GO
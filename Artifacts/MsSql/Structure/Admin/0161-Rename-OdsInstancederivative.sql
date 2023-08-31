-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE [dbo].[OdsInstanceDerivative]
DROP CONSTRAINT [FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId];

ALTER TABLE [dbo].[OdsInstanceDerivative]
DROP CONSTRAINT [UC_OdsInstanceDerivative_OdsInstanceId_DerivativeType];

EXEC SP_RENAME 'dbo.OdsInstanceDerivative.OdsInstanceId', 'OdsInstance_OdsInstanceId', 'COLUMN';

EXEC SP_RENAME 'dbo.OdsInstanceDerivative', 'OdsInstanceDerivatives';

ALTER TABLE [dbo].[OdsInstanceDerivatives]  WITH CHECK
ADD
    CONSTRAINT [FK_OdsInstanceDerivative_OdsInstance_OdsInstanceId] FOREIGN KEY([OdsInstance_OdsInstanceId]) REFERENCES [dbo].[OdsInstances] ([OdsInstanceId]),
    CONSTRAINT [UC_OdsInstanceDerivative_OdsInstance_OdsInstanceId_DerivativeType] UNIQUE(OdsInstance_OdsInstanceId, DerivativeType);
GO

ALTER TABLE [dbo].[OdsInstanceDerivatives] CHECK CONSTRAINT [FK_OdsInstanceDerivative_OdsInstance_OdsInstanceId];
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
    LEFT JOIN dbo.OdsInstanceDerivatives der 
        ON ods.OdsInstanceId = der.OdsInstance_OdsInstanceId
    WHERE   ods.OdsInstanceId = @OdsInstanceId
GO
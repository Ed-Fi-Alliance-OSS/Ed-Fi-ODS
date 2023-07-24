-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE [dbo].[OdsInstanceDerivative](
    [OdsInstanceDerivativeId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [OdsInstanceId] INT NOT NULL,
    [DerivativeType] NVARCHAR(50) NOT NULL,
    [ConnectionString] NVARCHAR(500) NOT NULL
);
GO

ALTER TABLE [dbo].[OdsInstanceDerivative]  WITH CHECK
    ADD
        CONSTRAINT [FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId] FOREIGN KEY([OdsInstanceId]) REFERENCES [dbo].[OdsInstances] ([OdsInstanceId]),
        CONSTRAINT [UC_OdsInstanceDerivative_OdsInstanceId_DerivativeType] UNIQUE(OdsInstanceId, DerivativeType);
GO

ALTER TABLE [dbo].[OdsInstanceDerivative] CHECK CONSTRAINT [FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId];
GO
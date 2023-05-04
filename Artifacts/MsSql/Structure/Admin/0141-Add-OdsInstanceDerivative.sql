CREATE TABLE [dbo].[OdsInstanceDerivative](
    [OdsInstanceDerivativeId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [OdsInstanceId] INT NOT NULL,
    [DerivativeType] NVARCHAR(50) NOT NULL,
    [ConnectionString] NVARCHAR(255) NOT NULL
);
GO

ALTER TABLE [dbo].[OdsInstanceDerivative]  WITH CHECK
    ADD
        CONSTRAINT [FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId] FOREIGN KEY([OdsInstanceId]) REFERENCES [dbo].[OdsInstances] ([OdsInstanceId]),
        CONSTRAINT [UC_OdsInstanceDerivative_OdsInstanceId_DerivativeType] UNIQUE(OdsInstanceId, DerivativeType);
GO

ALTER TABLE [dbo].[OdsInstanceDerivative] CHECK CONSTRAINT [FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId];
GO
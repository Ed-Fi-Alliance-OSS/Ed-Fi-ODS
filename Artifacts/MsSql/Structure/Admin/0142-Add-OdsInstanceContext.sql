CREATE TABLE [dbo].[OdsInstanceContext](
    [OdsInstanceContextId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [OdsInstanceId] INT NOT NULL,
    [ContextKey] NVARCHAR(50) NOT NULL,
    [ContextValue] NVARCHAR(50) NOT NULL
);
GO

ALTER TABLE [dbo].[OdsInstanceContext]  WITH CHECK
    ADD
        CONSTRAINT [FK_OdsInstanceContext_OdsInstanceId_OdsInstanceId] FOREIGN KEY([OdsInstanceId]) REFERENCES [dbo].[OdsInstances] ([OdsInstanceId]),
        CONSTRAINT [UC_OdsInstanceDerivative_OdsInstanceId_ContextKey] UNIQUE(OdsInstanceId, ContextKey);
GO

ALTER TABLE [dbo].[OdsInstanceContext] CHECK CONSTRAINT [FK_OdsInstanceContext_OdsInstanceId_OdsInstanceId];
GO
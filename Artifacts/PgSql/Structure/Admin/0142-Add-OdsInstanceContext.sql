CREATE TABLE dbo.OdsInstanceContext(
    OdsInstanceContextId SERIAL PRIMARY KEY NOT NULL,
    OdsInstanceId INT NOT NULL,
    ContextKey VARCHAR(50) NOT NULL,
    ContextValue VARCHAR(50) NOT NULL
);

ALTER TABLE dbo.OdsInstanceContext
    ADD CONSTRAINT FK_OdsInstanceContext_OdsInstanceId_OdsInstanceId FOREIGN KEY(OdsInstanceId) REFERENCES dbo.OdsInstances (OdsInstanceId),
    ADD CONSTRAINT UC_OdsInstanceDerivative_OdsInstanceId_ContextKey UNIQUE(OdsInstanceId, ContextKey);
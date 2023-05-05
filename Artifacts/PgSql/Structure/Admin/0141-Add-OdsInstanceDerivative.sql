CREATE TABLE dbo.OdsInstanceDerivative(
    OdsInstanceDerivativeId SERIAL PRIMARY KEY NOT NULL,
    OdsInstanceId INT NOT NULL,
    DerivativeType VARCHAR(50) NOT NULL,
    ConnectionString VARCHAR(255) NOT NULL
);

ALTER TABLE dbo.OdsInstanceDerivative
    ADD CONSTRAINT FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId FOREIGN KEY(OdsInstanceId) REFERENCES dbo.OdsInstances (OdsInstanceId),
    ADD CONSTRAINT UC_OdsInstanceDerivative_OdsInstanceId_DerivativeType UNIQUE(OdsInstanceId, DerivativeType);
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.OdsInstanceDerivative
	DROP CONSTRAINT IF EXISTS FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId;

ALTER TABLE dbo.OdsInstanceDerivative
	DROP CONSTRAINT IF EXISTS UC_OdsInstanceDerivative_OdsInstanceId_DerivativeType;

ALTER TABLE dbo.OdsInstanceDerivative
    RENAME COLUMN OdsInstanceId TO OdsInstance_OdsInstanceId;

ALTER TABLE dbo.OdsInstanceDerivative
    RENAME TO OdsInstanceDerivatives;

ALTER TABLE dbo.OdsInstanceDerivatives
    ADD CONSTRAINT FK_OdsInstanceDerivative_OdsInstance_OdsInstanceId FOREIGN KEY(OdsInstance_OdsInstanceId) REFERENCES dbo.OdsInstances (OdsInstanceId),
    ADD CONSTRAINT UC_OdsInstanceDerivative_OdsInstance_OdsInstanceId_DerivativeType UNIQUE(OdsInstance_OdsInstanceId, DerivativeType);
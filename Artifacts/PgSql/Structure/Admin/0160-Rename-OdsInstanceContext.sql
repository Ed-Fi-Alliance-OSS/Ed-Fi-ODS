-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.OdsInstanceContext
	DROP CONSTRAINT IF EXISTS FK_OdsInstanceContext_OdsInstanceId_OdsInstanceId;

ALTER TABLE dbo.OdsInstanceContext
	DROP CONSTRAINT IF EXISTS UC_OdsInstanceDerivative_OdsInstanceId_ContextKey;

ALTER TABLE dbo.OdsInstanceContext
    RENAME COLUMN OdsInstanceId TO OdsInstance_OdsInstanceId;

ALTER TABLE dbo.OdsInstanceContext
    RENAME TO OdsInstanceContexts;

ALTER TABLE dbo.OdsInstanceContexts
    ADD CONSTRAINT FK_OdsInstanceContext_OdsInstance_OdsInstanceId FOREIGN KEY(OdsInstance_OdsInstanceId) REFERENCES dbo.OdsInstances (OdsInstanceId),
    ADD CONSTRAINT UC_OdsInstanceContext_OdsInstance_OdsInstanceId_ContextKey UNIQUE(OdsInstance_OdsInstanceId, ContextKey);
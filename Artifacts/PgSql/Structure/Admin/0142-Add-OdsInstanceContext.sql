-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE dbo.OdsInstanceContext(
    OdsInstanceContextId SERIAL PRIMARY KEY NOT NULL,
    OdsInstanceId INT NOT NULL,
    ContextKey VARCHAR(50) NOT NULL,
    ContextValue VARCHAR(50) NOT NULL
);

ALTER TABLE dbo.OdsInstanceContext
    ADD CONSTRAINT FK_OdsInstanceContext_OdsInstanceId_OdsInstanceId FOREIGN KEY(OdsInstanceId) REFERENCES dbo.OdsInstances (OdsInstanceId),
    ADD CONSTRAINT UC_OdsInstanceDerivative_OdsInstanceId_ContextKey UNIQUE(OdsInstanceId, ContextKey);
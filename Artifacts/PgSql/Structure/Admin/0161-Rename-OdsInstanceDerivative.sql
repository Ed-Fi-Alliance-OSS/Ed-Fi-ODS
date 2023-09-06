-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE dbo.OdsInstanceDerivative
	DROP CONSTRAINT IF EXISTS FK_OdsInstanceDerivative_OdsInstanceId_OdsInstanceId;

ALTER TABLE dbo.OdsInstanceDerivative
	DROP CONSTRAINT IF EXISTS UC_OdsInstanceDerivative_OdsInstanceId_DerivativeType;

DO $$
BEGIN
IF EXISTS (
        SELECT column_name
        FROM information_schema.columns
        WHERE table_name = 'odsinstancederivative'
        AND column_name = 'odsinstanceid') 
THEN
    ALTER TABLE dbo.OdsInstanceDerivative
    RENAME COLUMN OdsInstanceId TO OdsInstance_OdsInstanceId;
END IF;
END $$;

DO $$
BEGIN
IF EXISTS (
        SELECT column_name
        FROM information_schema.columns
        WHERE table_name = 'odsinstancederivative') 
THEN
    ALTER TABLE dbo.OdsInstanceDerivative
    RENAME TO OdsInstanceDerivatives;
END IF;
END $$;

ALTER TABLE dbo.OdsInstanceDerivatives
    ADD CONSTRAINT FK_OdsInstanceDerivative_OdsInstance_OdsInstanceId FOREIGN KEY(OdsInstance_OdsInstanceId) REFERENCES dbo.OdsInstances (OdsInstanceId),
    ADD CONSTRAINT UC_OdsInstanceDerivative_OdsInstance_OdsInstanceId_DerivativeType UNIQUE(OdsInstance_OdsInstanceId, DerivativeType);

DROP FUNCTION IF EXISTS dbo.GetOdsInstanceConfigurationById;
CREATE FUNCTION dbo.GetOdsInstanceConfigurationById (ods_instanceId INT)
RETURNS TABLE (
    OdsInstanceId INT
    ,ConnectionString VARCHAR(500)
    ,ContextKey VARCHAR(50)
    ,ContextValue VARCHAR(50)
    ,DerivativeType VARCHAR(50)
    ,ConnectionStringByDerivativeType VARCHAR(500)
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT  ods.OdsInstanceId
            ,ods.ConnectionString
            ,ctx.ContextKey
            ,ctx.ContextValue
            ,der.DerivativeType
            ,der.ConnectionString AS ConnectionStringByDerivativeType
    FROM dbo.OdsInstances ods
    LEFT OUTER JOIN dbo.OdsInstanceContexts ctx 
        ON ods.OdsInstanceId = ctx.OdsInstance_OdsInstanceId
    LEFT JOIN dbo.OdsInstanceDerivatives der 
        ON ods.OdsInstanceId = der.OdsInstance_OdsInstanceId
    WHERE   ods.OdsInstanceId = ods_instanceId;
END
$$
LANGUAGE plpgsql;
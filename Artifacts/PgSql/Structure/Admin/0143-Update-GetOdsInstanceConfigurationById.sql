DROP FUNCTION IF EXISTS dbo.GetOdsInstanceConfigurationById;

CREATE FUNCTION dbo.GetOdsInstanceConfigurationById (ods_instanceId INT)
RETURNS TABLE (
    OdsInstanceId INT
    ,ConnectionString TEXT
    ,ContextKey VARCHAR(50)
    ,ContextValue VARCHAR(50)
    ,DerivativeType VARCHAR(50)
    ,ConnectionStringByDerivativeType VARCHAR(255)
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
    LEFT OUTER JOIN dbo.OdsInstanceContext ctx 
        ON ods.OdsInstanceId = ctx.OdsInstanceId
    LEFT JOIN dbo.OdsInstanceDerivative der 
        ON ods.OdsInstanceId = der.OdsInstanceId
    WHERE   ods.OdsInstanceId = ods_instanceId;
END
$$
LANGUAGE plpgsql;
CREATE OR ALTER FUNCTION dbo.GetOdsInstanceConfigurationById (
    @OdsInstanceId int
)
RETURNS TABLE
RETURN
    SELECT  ods.OdsInstanceId
            ,ods.ConnectionString
            ,ctx.ContextKey
            ,ctx.ContextValue
            ,der.DerivativeType
            ,der.ConnectionString AS ConnectionStringByDerivativeType
    FROM dbo.OdsInstances ods
    LEFT JOIN dbo.OdsInstanceContext ctx 
        ON ods.OdsInstanceId = ctx.OdsInstanceId
    LEFT JOIN dbo.OdsInstanceDerivative der 
        ON ods.OdsInstanceId = der.OdsInstanceId
    WHERE   ods.OdsInstanceId = @OdsInstanceId
GO

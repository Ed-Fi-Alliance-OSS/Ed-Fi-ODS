CREATE OR ALTER FUNCTION dbo.GetOdsInstanceConfigurationById (
    @OdsInstanceId int
)
RETURNS TABLE
RETURN
    SELECT  ods.OdsInstanceId, ods.ConnectionString
    FROM    dbo.OdsInstances ods
    WHERE   ods.OdsInstanceId = @OdsInstanceId
GO

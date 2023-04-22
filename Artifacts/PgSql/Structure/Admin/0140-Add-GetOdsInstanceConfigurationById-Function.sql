DROP FUNCTION IF EXISTS dbo.GetOdsInstanceConfigurationById;

CREATE FUNCTION dbo.GetOdsInstanceConfigurationById (ods_instanceId INT)
RETURNS TABLE (
    OdsInstanceId INT
    ,ConnectionString TEXT
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT  ods.OdsInstanceId, ods.ConnectionString
    FROM    dbo.OdsInstances ods
    WHERE   ods.OdsInstanceId = ods_instanceId;
END
$$
LANGUAGE plpgsql;

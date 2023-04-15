CREATE OR ALTER FUNCTION dbo.GetOdsInstanceConfigurationById (OdsInstanceId INT)
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
    WHERE   ods.OdsInstanceId = OdsInstanceId;
END
$$
LANGUAGE plpgsql;

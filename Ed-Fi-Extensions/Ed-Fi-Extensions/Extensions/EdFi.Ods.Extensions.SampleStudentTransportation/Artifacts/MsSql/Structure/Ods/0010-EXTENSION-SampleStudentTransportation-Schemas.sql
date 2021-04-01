IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'samplestudenttransportation')
EXEC sys.sp_executesql N'CREATE SCHEMA [samplestudenttransportation]'
GO

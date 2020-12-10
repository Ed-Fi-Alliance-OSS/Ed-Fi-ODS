IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tpdm')
EXEC sys.sp_executesql N'CREATE SCHEMA [tpdm]'
GO

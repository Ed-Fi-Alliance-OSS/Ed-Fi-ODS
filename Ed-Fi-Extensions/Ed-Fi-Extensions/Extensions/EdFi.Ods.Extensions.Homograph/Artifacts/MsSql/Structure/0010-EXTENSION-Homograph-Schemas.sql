IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'homograph')
EXEC sys.sp_executesql N'CREATE SCHEMA [homograph]'
GO

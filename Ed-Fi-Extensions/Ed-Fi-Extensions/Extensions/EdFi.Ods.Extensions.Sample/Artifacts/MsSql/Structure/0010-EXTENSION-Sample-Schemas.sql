IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'sample')
EXEC sys.sp_executesql N'CREATE SCHEMA [sample]'
GO

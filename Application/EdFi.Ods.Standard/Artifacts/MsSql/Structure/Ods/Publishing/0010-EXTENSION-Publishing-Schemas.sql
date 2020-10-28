IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'publishing')
EXEC sys.sp_executesql N'CREATE SCHEMA [publishing]'
GO

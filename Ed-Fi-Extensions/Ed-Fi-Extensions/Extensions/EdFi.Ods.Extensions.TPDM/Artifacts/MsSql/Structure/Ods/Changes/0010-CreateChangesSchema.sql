IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'changes')
EXEC sys.sp_executesql N'CREATE SCHEMA [changes]'
GO

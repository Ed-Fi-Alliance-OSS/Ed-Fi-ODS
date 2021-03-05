IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'changeQueries')
EXEC sys.sp_executesql N'CREATE SCHEMA [changeQueries]'
GO

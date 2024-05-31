IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'samplealternativeeducationprogram')
EXEC sys.sp_executesql N'CREATE SCHEMA [samplealternativeeducationprogram]'
GO

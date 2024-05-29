IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'tracked_changes_samplealternativeeducationprogram')
EXEC sys.sp_executesql N'CREATE SCHEMA [tracked_changes_samplealternativeeducationprogram]'
GO


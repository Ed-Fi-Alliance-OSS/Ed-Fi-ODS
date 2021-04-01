IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'samplestudenttranscript')
EXEC sys.sp_executesql N'CREATE SCHEMA [samplestudenttranscript]'
GO

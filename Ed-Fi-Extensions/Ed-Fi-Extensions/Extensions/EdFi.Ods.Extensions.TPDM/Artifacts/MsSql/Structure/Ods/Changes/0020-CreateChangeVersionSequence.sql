IF NOT EXISTS (SELECT * FROM sys.sequences WHERE object_id = OBJECT_ID(N'[changes].[ChangeVersionSequence]'))
BEGIN
CREATE SEQUENCE [changes].[ChangeVersionSequence] START WITH 0
END
GO

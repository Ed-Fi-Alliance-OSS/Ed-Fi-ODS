BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'sample.Bus') AND name = N'UX_Bus_ChangeVersion')
    CREATE INDEX [UX_Bus_ChangeVersion] ON [sample].[Bus] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'sample.BusRoute') AND name = N'UX_BusRoute_ChangeVersion')
    CREATE INDEX [UX_BusRoute_ChangeVersion] ON [sample].[BusRoute] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'sample.StudentGraduationPlanAssociation') AND name = N'UX_StudentGraduationPlanAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentGraduationPlanAssociation_ChangeVersion] ON [sample].[StudentGraduationPlanAssociation] ([ChangeVersion] ASC)
    GO
COMMIT


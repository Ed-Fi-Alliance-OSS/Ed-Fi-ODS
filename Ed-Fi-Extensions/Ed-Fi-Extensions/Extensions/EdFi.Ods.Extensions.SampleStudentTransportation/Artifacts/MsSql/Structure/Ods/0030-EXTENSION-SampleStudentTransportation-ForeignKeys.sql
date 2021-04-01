ALTER TABLE [samplestudenttransportation].[StudentTransportation] WITH CHECK ADD CONSTRAINT [FK_StudentTransportation_School] FOREIGN KEY ([SchoolId])
REFERENCES [edfi].[School] ([SchoolId])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportation_School]
ON [samplestudenttransportation].[StudentTransportation] ([SchoolId] ASC)
GO

ALTER TABLE [samplestudenttransportation].[StudentTransportation] WITH CHECK ADD CONSTRAINT [FK_StudentTransportation_Student] FOREIGN KEY ([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

CREATE NONCLUSTERED INDEX [FK_StudentTransportation_Student]
ON [samplestudenttransportation].[StudentTransportation] ([StudentUSI] ASC)
GO


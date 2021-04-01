-- Extended Properties [samplestudenttransportation].[StudentTransportation] --
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'StudentTransportation', @level0type=N'SCHEMA', @level0name=N'samplestudenttransportation', @level1type=N'TABLE', @level1name=N'StudentTransportation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The bus that delivers the student to the school in the morning.', @level0type=N'SCHEMA', @level0name=N'samplestudenttransportation', @level1type=N'TABLE', @level1name=N'StudentTransportation', @level2type=N'COLUMN', @level2name=N'AMBusNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Te bus that delivers the student home in the afternoon.', @level0type=N'SCHEMA', @level0name=N'samplestudenttransportation', @level1type=N'TABLE', @level1name=N'StudentTransportation', @level2type=N'COLUMN', @level2name=N'PMBusNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identifier assigned to a school.', @level0type=N'SCHEMA', @level0name=N'samplestudenttransportation', @level1type=N'TABLE', @level1name=N'StudentTransportation', @level2type=N'COLUMN', @level2name=N'SchoolId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A unique alphanumeric code assigned to a student.', @level0type=N'SCHEMA', @level0name=N'samplestudenttransportation', @level1type=N'TABLE', @level1name=N'StudentTransportation', @level2type=N'COLUMN', @level2name=N'StudentUSI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The estimated distance, in miles, the student lives from the school.', @level0type=N'SCHEMA', @level0name=N'samplestudenttransportation', @level1type=N'TABLE', @level1name=N'StudentTransportation', @level2type=N'COLUMN', @level2name=N'EstimatedMilesFromSchool'
GO


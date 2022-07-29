-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

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


-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [samplestudenttransportation].[samplestudenttransportation_StudentTransportation_TR_DeleteTracking]
GO

CREATE TRIGGER [samplestudenttransportation].[samplestudenttransportation_StudentTransportation_TR_DeleteTracking] ON [samplestudenttransportation].[StudentTransportation] AFTER DELETE AS
BEGIN
    IF @@rowcount = 0 
        RETURN

    SET NOCOUNT ON

    INSERT INTO [tracked_changes_samplestudenttransportation].[StudentTransportation](OldAMBusNumber, OldPMBusNumber, OldSchoolId, OldStudentUSI, OldStudentUniqueId, Id, Discriminator, ChangeVersion)
    SELECT d.AMBusNumber, d.PMBusNumber, d.SchoolId, d.StudentUSI, j0.StudentUniqueId, d.Id, d.Discriminator, (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM    deleted d
        INNER JOIN edfi.Student j0
            ON d.StudentUSI = j0.StudentUSI
END
GO

ALTER TABLE [samplestudenttransportation].[StudentTransportation] ENABLE TRIGGER [samplestudenttransportation_StudentTransportation_TR_DeleteTracking]
GO



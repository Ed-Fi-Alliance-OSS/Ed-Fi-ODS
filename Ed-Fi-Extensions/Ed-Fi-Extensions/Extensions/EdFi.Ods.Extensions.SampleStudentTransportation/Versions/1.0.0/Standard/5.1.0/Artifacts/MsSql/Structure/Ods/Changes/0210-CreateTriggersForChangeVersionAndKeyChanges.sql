-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP TRIGGER IF EXISTS [samplestudenttransportation].[samplestudenttransportation_StudentTransportation_TR_UpdateChangeVersion]
GO

CREATE TRIGGER [samplestudenttransportation].[samplestudenttransportation_StudentTransportation_TR_UpdateChangeVersion] ON [samplestudenttransportation].[StudentTransportation] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [samplestudenttransportation].[StudentTransportation]
    SET ChangeVersion = (NEXT VALUE FOR [changes].[ChangeVersionSequence])
    FROM [samplestudenttransportation].[StudentTransportation] u
    WHERE EXISTS (SELECT 1 FROM inserted i WHERE i.id = u.id);
END	
GO


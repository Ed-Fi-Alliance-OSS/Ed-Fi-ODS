-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name='IX_StudentTransportation_SchoolId' AND object_id = OBJECT_ID('samplestudenttransportation.StudentTransportation')) 
BEGIN
    CREATE INDEX IX_StudentTransportation_SchoolId ON samplestudenttransportation.StudentTransportation(SchoolId) INCLUDE (Id)
END;

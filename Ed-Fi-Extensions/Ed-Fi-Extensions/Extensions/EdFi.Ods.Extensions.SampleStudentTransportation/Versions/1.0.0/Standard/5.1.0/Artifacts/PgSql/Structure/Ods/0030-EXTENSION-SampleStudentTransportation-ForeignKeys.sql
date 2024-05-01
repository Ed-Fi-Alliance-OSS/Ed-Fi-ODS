-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

ALTER TABLE samplestudenttransportation.StudentTransportation ADD CONSTRAINT FK_68afad_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

ALTER TABLE samplestudenttransportation.StudentTransportation ADD CONSTRAINT FK_68afad_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_68afad_Student
ON samplestudenttransportation.StudentTransportation (StudentUSI ASC);


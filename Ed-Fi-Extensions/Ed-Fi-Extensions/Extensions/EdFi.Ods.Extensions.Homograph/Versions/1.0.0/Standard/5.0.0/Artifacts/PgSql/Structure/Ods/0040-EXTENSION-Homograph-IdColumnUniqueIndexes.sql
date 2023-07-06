-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE UNIQUE INDEX IF NOT EXISTS UX_2b5c3d_Id ON homograph.Contact(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_dcd1d5_Id ON homograph.Name(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_6cd2e3_Id ON homograph.School(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_464d7a_Id ON homograph.SchoolYearType(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_681927_Id ON homograph.Staff(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_2a164d_Id ON homograph.Student(Id);

CREATE UNIQUE INDEX IF NOT EXISTS UX_857b52_Id ON homograph.StudentSchoolAssociation(Id);


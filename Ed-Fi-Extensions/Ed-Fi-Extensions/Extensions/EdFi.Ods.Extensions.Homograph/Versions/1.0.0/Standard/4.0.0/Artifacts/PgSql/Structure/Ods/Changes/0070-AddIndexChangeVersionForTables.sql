-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS UX_dcd1d5_ChangeVersion ON homograph.Name(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_5f7953_ChangeVersion ON homograph.Parent(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_6cd2e3_ChangeVersion ON homograph.School(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_464d7a_ChangeVersion ON homograph.SchoolYearType(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_681927_ChangeVersion ON homograph.Staff(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_2a164d_ChangeVersion ON homograph.Student(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_857b52_ChangeVersion ON homograph.StudentSchoolAssociation(ChangeVersion);


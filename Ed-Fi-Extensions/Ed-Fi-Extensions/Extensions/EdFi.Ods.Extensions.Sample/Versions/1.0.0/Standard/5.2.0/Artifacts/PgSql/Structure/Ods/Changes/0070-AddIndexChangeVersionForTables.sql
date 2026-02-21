-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE INDEX IF NOT EXISTS UX_bb3d83_ChangeVersion ON sample.Bus(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_65385a_ChangeVersion ON sample.BusRoute(ChangeVersion);

CREATE INDEX IF NOT EXISTS UX_5fe843_ChangeVersion ON sample.StudentGraduationPlanAssociation(ChangeVersion);


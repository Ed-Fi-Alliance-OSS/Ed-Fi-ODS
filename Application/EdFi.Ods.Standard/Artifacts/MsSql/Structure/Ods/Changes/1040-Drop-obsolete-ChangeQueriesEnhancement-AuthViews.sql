-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

--------------------------------------------------------------------------------
-- Drop views supporting enhanced Change Queries before v5.4 API
--------------------------------------------------------------------------------
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStudentUSIIncludingDeletes;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToStaffUSIIncludingDeletes;
DROP VIEW IF EXISTS auth.LocalEducationAgencyIdToParentUSIIncludingDeletes;

DROP VIEW IF EXISTS auth.SchoolIdToStudentUSIIncludingDeletes;
DROP VIEW IF EXISTS auth.SchoolIdToStaffUSIIncludingDeletes;
DROP VIEW IF EXISTS auth.ParentUSIToSchoolIdIncludingDeletes;

GO
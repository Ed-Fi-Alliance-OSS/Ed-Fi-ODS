-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS(SELECT 1 
              FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
              WHERE CONSTRAINT_NAME = 'UK_Student_Person'
              AND TABLE_NAME='Student'
              AND TABLE_SCHEMA='edfi')
BEGIN
    ALTER TABLE [edfi].[Student]
    ADD CONSTRAINT UK_Student_Person UNIQUE (PersonId, SourceSystemDescriptorId);
END
GO

IF NOT EXISTS(SELECT 1 
              FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
              WHERE CONSTRAINT_NAME = 'UK_Parent_Person'
              AND TABLE_NAME='Parent'
              AND TABLE_SCHEMA='edfi')
BEGIN
    ALTER TABLE [edfi].[Person]
     ADD CONSTRAINT UK_Parent_Person UNIQUE (PersonId, SourceSystemDescriptorId);
END
GO

IF NOT EXISTS(SELECT 1 
              FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
              WHERE CONSTRAINT_NAME = 'UK_Staff_Person'
              AND TABLE_NAME='Staff'
              AND TABLE_SCHEMA='edfi')
BEGIN
    ALTER TABLE [edfi].[Staff]
     ADD CONSTRAINT UK_Staff_Person UNIQUE (PersonId, SourceSystemDescriptorId);
END
GO
-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Define a new authorization strategy for reading changes when authorizing access to student data through the responsiblity association
IF NOT EXISTS(SELECT 1 FROM [dbo].[AuthorizationStrategies] WHERE [AuthorizationStrategyName] ='RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes')
BEGIN
    INSERT INTO [dbo].[AuthorizationStrategies] ([DisplayName], [AuthorizationStrategyName])
    VALUES ('Relationships with Students only (through StudentEducationOrganizationResponsibilityAssociation, including deletes)', 'RelationshipsWithStudentsOnlyThroughResponsibilityIncludingDeletes');
END

GO

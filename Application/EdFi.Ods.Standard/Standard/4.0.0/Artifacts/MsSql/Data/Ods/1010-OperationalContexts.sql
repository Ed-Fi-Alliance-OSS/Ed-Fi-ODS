-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF NOT EXISTS (
        SELECT *
        FROM [interop].[OperationalContext]
        WHERE DisplayName = 'Default'
        )
BEGIN
    INSERT INTO [interop].[OperationalContext] (
        [OperationalContextUri]
        ,[DisplayName]
        ,[OrganizationName]
        )
    VALUES (
        'uri://ed-fi-api-host.org'
        ,'Default'
        ,'Ed-Fi'
        );
END
GO

MERGE [interop].[OperationalContextDescriptorUsage] AS [TARGET]
USING (
    SELECT [d].*
    FROM [edfi].[Descriptor] [d]
    WHERE [d].[DescriptorId] NOT IN (
            SELECT AccommodationDescriptorId
            FROM [edfi].[AccommodationDescriptor]
            
            UNION
            
            SELECT AssessmentPeriodDescriptorId
            FROM [edfi].[AssessmentPeriodDescriptor]
            
            UNION

            SELECT [AssessmentReportingMethodDescriptorId]
            FROM [edfi].[AssessmentReportingMethodDescriptor]

            UNION

            SELECT PerformanceLevelDescriptorId
            FROM [edfi].[PerformanceLevelDescriptor]
            )
    ) AS [SOURCE]
    ON ([TARGET].[DescriptorId] = [SOURCE].[DescriptorId])
WHEN NOT MATCHED BY TARGET
    THEN
        INSERT (
            OperationalContextUri
            ,DescriptorId
            )
        VALUES (
            'uri://ed-fi-api-host.org'
            ,[SOURCE].[DescriptorId]
            );
GO



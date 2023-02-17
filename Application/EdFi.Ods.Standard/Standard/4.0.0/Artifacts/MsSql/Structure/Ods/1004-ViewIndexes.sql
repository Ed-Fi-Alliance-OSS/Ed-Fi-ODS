-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET NUMERIC_ROUNDABORT OFF;
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_EducationOrganizationToStaffUSI_Assignment] ON [auth].[EducationOrganizationToStaffUSI_Assignment] (
    [StaffUSI] ASC
    ,[EducationOrganizationId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_EducationOrganizationToStaffUSI_Employment] ON [auth].[EducationOrganizationToStaffUSI_Employment] (
    [StaffUSI] ASC
    ,[EducationOrganizationId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_LocalEducationAgencyToStudentUSI] ON [auth].[LocalEducationAgencyIdToStudentUSI] (
    [StudentUSI] ASC
    ,[LocalEducationAgencyId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_SchoolIdToStudentUSI] ON [auth].[SchoolIdToStudentUSI] (
    [StudentUSI] ASC
    ,[SchoolId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_LocalEducationAgency] ON [auth].[LocalEducationAgency] (
    [Id] ASC
    ,[LocalEducationAgencyId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_LocalEducationAgencyIdToParentUSI] ON [auth].[LocalEducationAgencyIdToParentUSI] (
    [ParentUSI] ASC
    ,[LocalEducationAgencyId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
    ,DROP_EXISTING = OFF

            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_ParentUSIToStudentUSI] ON [auth].[ParentUSIToStudentUSI] (
    [StudentUSI] ASC
    ,[ParentUSI] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY]
GO
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_ParentUSIToSchoolId] ON [auth].[ParentUSIToSchoolId] (
    [ParentUSI] ASC
    ,[SchoolId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE UNIQUE CLUSTERED INDEX [UCIX_School] ON [auth].[School] (
    [Id] ASC
    ,[SchoolId] ASC
    ,[LocalEducationAgencyId] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,IGNORE_DUP_KEY = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IX_LocalEducationAgency_LocalEducationAgencyId] ON [auth].[LocalEducationAgency] (
    [LocalEducationAgencyId] ASC
    ,[Id] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IX_ParentUSIToStudentUSI] ON [auth].[ParentUSIToStudentUSI] (
    [ParentUSI] ASC
    ,[StudentUSI] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IX_School_LocalEducationAgencyId] ON [auth].[School] (
    [LocalEducationAgencyId] ASC
    ,[SchoolId] ASC
    ,[Id] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO

CREATE NONCLUSTERED INDEX [IX_School_SchoolId] ON [auth].[School] (
    [SchoolId] ASC
    ,[LocalEducationAgencyId] ASC
    ,[Id] ASC
    )
    WITH (
            PAD_INDEX = OFF
            ,STATISTICS_NORECOMPUTE = OFF
            ,SORT_IN_TEMPDB = OFF
            ,DROP_EXISTING = OFF
            ,ONLINE = OFF
            ,ALLOW_ROW_LOCKS = ON
            ,ALLOW_PAGE_LOCKS = ON
            ) ON [PRIMARY];
GO



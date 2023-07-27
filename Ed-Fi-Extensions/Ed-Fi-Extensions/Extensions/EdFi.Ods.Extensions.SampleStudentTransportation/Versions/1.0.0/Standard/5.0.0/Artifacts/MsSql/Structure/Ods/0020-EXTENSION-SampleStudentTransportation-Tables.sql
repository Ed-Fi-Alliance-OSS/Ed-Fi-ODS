-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Table [samplestudenttransportation].[StudentTransportation] --
CREATE TABLE [samplestudenttransportation].[StudentTransportation] (
    [AMBusNumber] [NVARCHAR](6) NOT NULL,
    [PMBusNumber] [NVARCHAR](6) NOT NULL,
    [SchoolId] [BIGINT] NOT NULL,
    [StudentUSI] [INT] NOT NULL,
    [EstimatedMilesFromSchool] [DECIMAL](5, 2) NOT NULL,
    [Discriminator] [NVARCHAR](128) NULL,
    [CreateDate] [DATETIME2] NOT NULL,
    [LastModifiedDate] [DATETIME2] NOT NULL,
    [Id] [UNIQUEIDENTIFIER] NOT NULL,
    CONSTRAINT [StudentTransportation_PK] PRIMARY KEY CLUSTERED (
        [AMBusNumber] ASC,
        [PMBusNumber] ASC,
        [SchoolId] ASC,
        [StudentUSI] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [samplestudenttransportation].[StudentTransportation] ADD CONSTRAINT [StudentTransportation_DF_CreateDate] DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [samplestudenttransportation].[StudentTransportation] ADD CONSTRAINT [StudentTransportation_DF_Id] DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [samplestudenttransportation].[StudentTransportation] ADD CONSTRAINT [StudentTransportation_DF_LastModifiedDate] DEFAULT (getdate()) FOR [LastModifiedDate]
GO


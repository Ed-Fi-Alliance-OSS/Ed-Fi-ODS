-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[interop].[OperationalContextSupport]'))
	DROP VIEW interop.OperationalContextSupport;
GO
CREATE VIEW interop.OperationalContextSupport
AS
SELECT  (sd.Namespace + '#' + sd.CodeValue) AS SourceDescriptorUri, 
        tocd.OperationalContextUri AS TargetOperationalContextUri, 
        (td.Namespace + '#' + td.CodeValue) AS TargetDescriptorUri,
        IsGeneralized = 0
FROM    edfi.Descriptor sd 
        INNER JOIN interop.DescriptorEquivalenceGroupAssignment sdega 
           ON sd.DescriptorId = sdega.DescriptorId
        INNER JOIN interop.DescriptorEquivalenceGroup deg 
           ON sdega.DescriptorEquivalenceGroupId = deg.DescriptorEquivalenceGroupId
        INNER JOIN interop.DescriptorEquivalenceGroupAssignment tdega 
           ON deg.DescriptorEquivalenceGroupId = tdega.DescriptorEquivalenceGroupId
        INNER JOIN edfi.Descriptor td 
           ON tdega.DescriptorId = td.DescriptorId
        INNER JOIN interop.OperationalContextDescriptorUsage tocd 
           ON td.DescriptorId = tocd.DescriptorId
        
UNION
SELECT  (sd.Namespace + '#' + sd.CodeValue) AS SourceDescriptorUri, 
        tocd.OperationalContextUri AS TargetOperationalContextUri, 
        (td.Namespace + '#' + td.CodeValue) AS TargetDescriptorUri,
        IsGeneralized = 1
FROM    edfi.Descriptor sd 
        INNER JOIN interop.DescriptorEquivalenceGroupAssignment sdega 
            ON sd.DescriptorId = sdega.DescriptorId
        INNER JOIN interop.DescriptorEquivalenceGroup sdeg 
            ON sdega.DescriptorEquivalenceGroupId = sdeg.DescriptorEquivalenceGroupId
        INNER JOIN interop.DescriptorEquivalenceGroupGeneralization degg 
            ON sdeg.DescriptorEquivalenceGroupId = degg.DescriptorEquivalenceGroupId
        INNER JOIN interop.DescriptorEquivalenceGroup tdeg 
            ON degg.GeneralizationDescriptorEquivalenceGroupId = tdeg.DescriptorEquivalenceGroupId
        INNER JOIN interop.DescriptorEquivalenceGroupAssignment tdega 
            ON tdeg.DescriptorEquivalenceGroupId = tdega.DescriptorEquivalenceGroupId
        INNER JOIN edfi.Descriptor td 
            ON tdega.DescriptorId = td.DescriptorId
        INNER JOIN interop.OperationalContextDescriptorUsage tocd 
            ON td.DescriptorId = tocd.DescriptorId			
UNION
SELECT  (sd.Namespace + '#' + sd.CodeValue) AS SourceDescriptorUri,
        tocd.OperationalContextUri AS TargetOperationalContextUri,
        (sd.Namespace + '#' + sd.CodeValue) AS TargetDescriptorUri,
        IsGeneralized = 0
FROM    edfi.Descriptor sd       
        INNER JOIN interop.OperationalContextDescriptorUsage tocd
           ON sd.DescriptorId = tocd.DescriptorId
GO
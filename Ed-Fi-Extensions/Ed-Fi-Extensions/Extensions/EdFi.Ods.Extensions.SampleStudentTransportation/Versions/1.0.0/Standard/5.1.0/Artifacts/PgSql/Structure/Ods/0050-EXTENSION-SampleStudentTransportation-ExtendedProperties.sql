-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- Extended Properties [samplestudenttransportation].[StudentTransportation] --
COMMENT ON TABLE samplestudenttransportation.StudentTransportation IS 'StudentTransportation';
COMMENT ON COLUMN samplestudenttransportation.StudentTransportation.AMBusNumber IS 'The bus that delivers the student to the school in the morning.';
COMMENT ON COLUMN samplestudenttransportation.StudentTransportation.PMBusNumber IS 'Te bus that delivers the student home in the afternoon.';
COMMENT ON COLUMN samplestudenttransportation.StudentTransportation.SchoolId IS 'The identifier assigned to a school. It must be distinct from any other identifier assigned to educational organizations, such as a LocalEducationAgencyId, to prevent duplication.';
COMMENT ON COLUMN samplestudenttransportation.StudentTransportation.StudentUSI IS 'A unique alphanumeric code assigned to a student.';
COMMENT ON COLUMN samplestudenttransportation.StudentTransportation.EstimatedMilesFromSchool IS 'The estimated distance, in miles, the student lives from the school.';


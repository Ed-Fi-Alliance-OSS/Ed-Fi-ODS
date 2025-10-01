-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
CREATE OR REPLACE FUNCTION edfi.Assessment_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.LocalCourseCode IS DISTINCT FROM OLD.LocalCourseCode
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       OR NEW.SchoolYear IS DISTINCT FROM OLD.SchoolYear
       OR NEW.SectionIdentifier IS DISTINCT FROM OLD.SectionIdentifier
       OR NEW.SessionName IS DISTINCT FROM OLD.SessionName
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.Assessment rt
       SET LastModifiedDate = NOW()
       WHERE rt.AssessmentIdentifier = NEW.AssessmentIdentifier
         AND rt.Namespace = NEW.Namespace;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'assessmentsection') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.assessmentsection
  FOR EACH ROW
  EXECUTE FUNCTION edfi.Assessment_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.BellSchedule_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.ClassPeriodName IS DISTINCT FROM OLD.ClassPeriodName
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.BellSchedule rt
       SET LastModifiedDate = NOW()
       WHERE rt.BellScheduleName = NEW.BellScheduleName
         AND rt.SchoolId = NEW.SchoolId;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'bellscheduleclassperiod') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.bellscheduleclassperiod
  FOR EACH ROW
  EXECUTE FUNCTION edfi.BellSchedule_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.CourseTranscript_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.LocalCourseCode IS DISTINCT FROM OLD.LocalCourseCode
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       OR NEW.SchoolYear IS DISTINCT FROM OLD.SchoolYear
       OR NEW.SectionIdentifier IS DISTINCT FROM OLD.SectionIdentifier
       OR NEW.SessionName IS DISTINCT FROM OLD.SessionName
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.CourseTranscript rt
       SET LastModifiedDate = NOW()
       WHERE rt.CourseAttemptResultDescriptorId = NEW.CourseAttemptResultDescriptorId
         AND rt.CourseCode = NEW.CourseCode
         AND rt.CourseEducationOrganizationId = NEW.CourseEducationOrganizationId
         AND rt.EducationOrganizationId = NEW.EducationOrganizationId
         AND rt.SchoolYear = NEW.SchoolYear
         AND rt.StudentUSI = NEW.StudentUSI
         AND rt.TermDescriptorId = NEW.TermDescriptorId;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'coursetranscriptsection') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.coursetranscriptsection
  FOR EACH ROW
  EXECUTE FUNCTION edfi.CourseTranscript_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.ReportCard_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.BeginDate IS DISTINCT FROM OLD.BeginDate
       OR NEW.GradeTypeDescriptorId IS DISTINCT FROM OLD.GradeTypeDescriptorId
       OR NEW.GradingPeriodDescriptorId IS DISTINCT FROM OLD.GradingPeriodDescriptorId
       OR NEW.GradingPeriodName IS DISTINCT FROM OLD.GradingPeriodName
       OR NEW.GradingPeriodSchoolYear IS DISTINCT FROM OLD.GradingPeriodSchoolYear
       OR NEW.LocalCourseCode IS DISTINCT FROM OLD.LocalCourseCode
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       OR NEW.SchoolYear IS DISTINCT FROM OLD.SchoolYear
       OR NEW.SectionIdentifier IS DISTINCT FROM OLD.SectionIdentifier
       OR NEW.SessionName IS DISTINCT FROM OLD.SessionName
       OR NEW.StudentUSI IS DISTINCT FROM OLD.StudentUSI
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.ReportCard rt
       SET LastModifiedDate = NOW()
       WHERE rt.EducationOrganizationId = NEW.EducationOrganizationId
         AND rt.GradingPeriodDescriptorId = NEW.GradingPeriodDescriptorId
         AND rt.GradingPeriodName = NEW.GradingPeriodName
         AND rt.GradingPeriodSchoolId = NEW.GradingPeriodSchoolId
         AND rt.GradingPeriodSchoolYear = NEW.GradingPeriodSchoolYear
         AND rt.StudentUSI = NEW.StudentUSI;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'reportcardgrade') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.reportcardgrade
  FOR EACH ROW
  EXECUTE FUNCTION edfi.ReportCard_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.Section_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.ClassPeriodName IS DISTINCT FROM OLD.ClassPeriodName
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.Section rt
       SET LastModifiedDate = NOW()
       WHERE rt.LocalCourseCode = NEW.LocalCourseCode
         AND rt.SchoolId = NEW.SchoolId
         AND rt.SchoolYear = NEW.SchoolYear
         AND rt.SectionIdentifier = NEW.SectionIdentifier
         AND rt.SessionName = NEW.SessionName;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'sectionclassperiod') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.sectionclassperiod
  FOR EACH ROW
  EXECUTE FUNCTION edfi.Section_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.StudentCohortAssociation_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.LocalCourseCode IS DISTINCT FROM OLD.LocalCourseCode
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       OR NEW.SchoolYear IS DISTINCT FROM OLD.SchoolYear
       OR NEW.SectionIdentifier IS DISTINCT FROM OLD.SectionIdentifier
       OR NEW.SessionName IS DISTINCT FROM OLD.SessionName
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.StudentCohortAssociation rt
       SET LastModifiedDate = NOW()
       WHERE rt.BeginDate = NEW.BeginDate
         AND rt.CohortIdentifier = NEW.CohortIdentifier
         AND rt.EducationOrganizationId = NEW.EducationOrganizationId
         AND rt.StudentUSI = NEW.StudentUSI;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'studentcohortassociationsection') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.studentcohortassociationsection
  FOR EACH ROW
  EXECUTE FUNCTION edfi.StudentCohortAssociation_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.StudentCompetencyObjective_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.BeginDate IS DISTINCT FROM OLD.BeginDate
       OR NEW.LocalCourseCode IS DISTINCT FROM OLD.LocalCourseCode
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       OR NEW.SchoolYear IS DISTINCT FROM OLD.SchoolYear
       OR NEW.SectionIdentifier IS DISTINCT FROM OLD.SectionIdentifier
       OR NEW.SessionName IS DISTINCT FROM OLD.SessionName
       OR NEW.StudentUSI IS DISTINCT FROM OLD.StudentUSI
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.StudentCompetencyObjective rt
       SET LastModifiedDate = NOW()
       WHERE rt.GradingPeriodDescriptorId = NEW.GradingPeriodDescriptorId
         AND rt.GradingPeriodName = NEW.GradingPeriodName
         AND rt.GradingPeriodSchoolId = NEW.GradingPeriodSchoolId
         AND rt.GradingPeriodSchoolYear = NEW.GradingPeriodSchoolYear
         AND rt.ObjectiveEducationOrganizationId = NEW.ObjectiveEducationOrganizationId
         AND rt.Objective = NEW.Objective
         AND rt.ObjectiveGradeLevelDescriptorId = NEW.ObjectiveGradeLevelDescriptorId
         AND rt.StudentUSI = NEW.StudentUSI;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'studentcompetencyobjectivestudentsectionassociation') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.studentcompetencyobjectivestudentsectionassociation
  FOR EACH ROW
  EXECUTE FUNCTION edfi.StudentCompetencyObjective_UpdLastModDate();
END IF;

CREATE OR REPLACE FUNCTION edfi.StudentSectionAttendanceEvent_UpdLastModDate()
RETURNS trigger AS
$BODY$
BEGIN
    -- Check if any volatile foreign key values have changed
    IF NEW.ClassPeriodName IS DISTINCT FROM OLD.ClassPeriodName
       OR NEW.SchoolId IS DISTINCT FROM OLD.SchoolId
       THEN
       -- Update the LastModifiedDate in the root table to the current UTC time
       UPDATE edfi.StudentSectionAttendanceEvent rt
       SET LastModifiedDate = NOW()
       WHERE rt.AttendanceEventCategoryDescriptorId = NEW.AttendanceEventCategoryDescriptorId
         AND rt.EventDate = NEW.EventDate
         AND rt.LocalCourseCode = NEW.LocalCourseCode
         AND rt.SchoolId = NEW.SchoolId
         AND rt.SchoolYear = NEW.SchoolYear
         AND rt.SectionIdentifier = NEW.SectionIdentifier
         AND rt.SessionName = NEW.SessionName
         AND rt.StudentUSI = NEW.StudentUSI;
    END IF;
    RETURN NEW;
END;
$BODY$ LANGUAGE plpgsql;

IF NOT EXISTS(SELECT 1 FROM information_schema.triggers WHERE trigger_name = 'updaterootlastmodifieddate' AND event_object_schema = 'edfi' AND event_object_table = 'studentsectionattendanceeventclassperiod') THEN
CREATE TRIGGER updaterootlastmodifieddate
  AFTER UPDATE ON edfi.studentsectionattendanceeventclassperiod
  FOR EACH ROW
  EXECUTE FUNCTION edfi.StudentSectionAttendanceEvent_UpdLastModDate();
END IF;

END
$$;

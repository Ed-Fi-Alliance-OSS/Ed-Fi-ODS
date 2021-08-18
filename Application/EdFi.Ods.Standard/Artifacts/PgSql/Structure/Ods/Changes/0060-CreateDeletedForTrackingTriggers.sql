CREATE FUNCTION tracked_deletes_edfi.AbsenceEventCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AbsenceEventCategoryDescriptor(AbsenceEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.AbsenceEventCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AbsenceEventCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AbsenceEventCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AbsenceEventCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AcademicHonorCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AcademicHonorCategoryDescriptor(AcademicHonorCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.AcademicHonorCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AcademicHonorCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AcademicHonorCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AcademicHonorCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AcademicSubjectDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AcademicSubjectDescriptor(AcademicSubjectDescriptorId, Id, ChangeVersion)
    SELECT OLD.AcademicSubjectDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AcademicSubjectDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AcademicSubjectDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AcademicSubjectDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AcademicWeek_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AcademicWeek(SchoolId, WeekIdentifier, Id, ChangeVersion)
    VALUES (OLD.SchoolId, OLD.WeekIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AcademicWeek 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AcademicWeek_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AccommodationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AccommodationDescriptor(AccommodationDescriptorId, Id, ChangeVersion)
    SELECT OLD.AccommodationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AccommodationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AccommodationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AccommodationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AccountClassificationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AccountClassificationDescriptor(AccountClassificationDescriptorId, Id, ChangeVersion)
    SELECT OLD.AccountClassificationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AccountClassificationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AccountClassificationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AccountClassificationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AccountCode_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AccountCode(AccountClassificationDescriptorId, AccountCodeNumber, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    VALUES (OLD.AccountClassificationDescriptorId, OLD.AccountCodeNumber, OLD.EducationOrganizationId, OLD.FiscalYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AccountCode 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AccountCode_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Account_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Account(AccountIdentifier, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    VALUES (OLD.AccountIdentifier, OLD.EducationOrganizationId, OLD.FiscalYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Account 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Account_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AccountabilityRating_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AccountabilityRating(EducationOrganizationId, RatingTitle, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.RatingTitle, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AccountabilityRating 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AccountabilityRating_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AchievementCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AchievementCategoryDescriptor(AchievementCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.AchievementCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AchievementCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AchievementCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AchievementCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Actual_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Actual(AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    VALUES (OLD.AccountIdentifier, OLD.AsOfDate, OLD.EducationOrganizationId, OLD.FiscalYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Actual 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Actual_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AdditionalCreditTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AdditionalCreditTypeDescriptor(AdditionalCreditTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.AdditionalCreditTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AdditionalCreditTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AdditionalCreditTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AdditionalCreditTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AddressTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AddressTypeDescriptor(AddressTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.AddressTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AddressTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AddressTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AddressTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AdministrationEnvironmentDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AdministrationEnvironmentDescriptor(AdministrationEnvironmentDescriptorId, Id, ChangeVersion)
    SELECT OLD.AdministrationEnvironmentDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AdministrationEnvironmentDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AdministrationEnvironmentDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AdministrationEnvironmentDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AdministrativeFundingControlDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AdministrativeFundingControlDescriptor(AdministrativeFundingControlDescriptorId, Id, ChangeVersion)
    SELECT OLD.AdministrativeFundingControlDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AdministrativeFundingControlDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AdministrativeFundingControlDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AdministrativeFundingControlDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AncestryEthnicOriginDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AncestryEthnicOriginDescriptor(AncestryEthnicOriginDescriptorId, Id, ChangeVersion)
    SELECT OLD.AncestryEthnicOriginDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AncestryEthnicOriginDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AncestryEthnicOriginDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AncestryEthnicOriginDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentCategoryDescriptor(AssessmentCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.AssessmentCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AssessmentCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentIdentificationSystemDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentIdentificationSystemDescriptor(AssessmentIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT OLD.AssessmentIdentificationSystemDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AssessmentIdentificationSystemDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentIdentificationSystemDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentIdentificationSystemDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentItemCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentItemCategoryDescriptor(AssessmentItemCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.AssessmentItemCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AssessmentItemCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentItemCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentItemCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentItemResultDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentItemResultDescriptor(AssessmentItemResultDescriptorId, Id, ChangeVersion)
    SELECT OLD.AssessmentItemResultDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AssessmentItemResultDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentItemResultDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentItemResultDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentItem_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentItem(AssessmentIdentifier, IdentificationCode, Namespace, Id, ChangeVersion)
    VALUES (OLD.AssessmentIdentifier, OLD.IdentificationCode, OLD.Namespace, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentItem 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentItem_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentPeriodDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentPeriodDescriptor(AssessmentPeriodDescriptorId, Id, ChangeVersion)
    SELECT OLD.AssessmentPeriodDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AssessmentPeriodDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentPeriodDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentPeriodDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentReportingMethodDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentReportingMethodDescriptor(AssessmentReportingMethodDescriptorId, Id, ChangeVersion)
    SELECT OLD.AssessmentReportingMethodDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AssessmentReportingMethodDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentReportingMethodDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentReportingMethodDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AssessmentScoreRangeLearningStandard_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AssessmentScoreRangeLearningStandard(AssessmentIdentifier, Namespace, ScoreRangeId, Id, ChangeVersion)
    VALUES (OLD.AssessmentIdentifier, OLD.Namespace, OLD.ScoreRangeId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AssessmentScoreRangeLearningStandard 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AssessmentScoreRangeLearningStandard_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Assessment_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Assessment(AssessmentIdentifier, Namespace, Id, ChangeVersion)
    VALUES (OLD.AssessmentIdentifier, OLD.Namespace, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Assessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Assessment_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AttemptStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AttemptStatusDescriptor(AttemptStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.AttemptStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AttemptStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AttemptStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AttemptStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.AttendanceEventCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.AttendanceEventCategoryDescriptor(AttendanceEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.AttendanceEventCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.AttendanceEventCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.AttendanceEventCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.AttendanceEventCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.BarrierToInternetAccessInResidenceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.BarrierToInternetAccessInResidenceDescriptor(BarrierToInternetAccessInResidenceDescriptorId, Id, ChangeVersion)
    SELECT OLD.BarrierToInternetAccessInResidenceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.BarrierToInternetAccessInResidenceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.BarrierToInternetAccessInResidenceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.BarrierToInternetAccessInResidenceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.BehaviorDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.BehaviorDescriptor(BehaviorDescriptorId, Id, ChangeVersion)
    SELECT OLD.BehaviorDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.BehaviorDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.BehaviorDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.BehaviorDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.BellSchedule_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.BellSchedule(BellScheduleName, SchoolId, Id, ChangeVersion)
    VALUES (OLD.BellScheduleName, OLD.SchoolId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.BellSchedule 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.BellSchedule_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Budget_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Budget(AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, Id, ChangeVersion)
    VALUES (OLD.AccountIdentifier, OLD.AsOfDate, OLD.EducationOrganizationId, OLD.FiscalYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Budget 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Budget_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CTEProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CTEProgramServiceDescriptor(CTEProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.CTEProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CTEProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CTEProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CTEProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CalendarDate_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CalendarDate(CalendarCode, Date, SchoolId, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.CalendarCode, OLD.Date, OLD.SchoolId, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CalendarDate 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CalendarDate_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CalendarEventDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CalendarEventDescriptor(CalendarEventDescriptorId, Id, ChangeVersion)
    SELECT OLD.CalendarEventDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CalendarEventDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CalendarEventDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CalendarEventDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CalendarTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CalendarTypeDescriptor(CalendarTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CalendarTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CalendarTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CalendarTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CalendarTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Calendar_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Calendar(CalendarCode, SchoolId, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.CalendarCode, OLD.SchoolId, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Calendar 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Calendar_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CareerPathwayDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CareerPathwayDescriptor(CareerPathwayDescriptorId, Id, ChangeVersion)
    SELECT OLD.CareerPathwayDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CareerPathwayDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CareerPathwayDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CareerPathwayDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CharterApprovalAgencyTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CharterApprovalAgencyTypeDescriptor(CharterApprovalAgencyTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CharterApprovalAgencyTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CharterApprovalAgencyTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CharterApprovalAgencyTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CharterApprovalAgencyTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CharterStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CharterStatusDescriptor(CharterStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.CharterStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CharterStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CharterStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CharterStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CitizenshipStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CitizenshipStatusDescriptor(CitizenshipStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.CitizenshipStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CitizenshipStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CitizenshipStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CitizenshipStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ClassPeriod_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ClassPeriod(ClassPeriodName, SchoolId, Id, ChangeVersion)
    VALUES (OLD.ClassPeriodName, OLD.SchoolId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ClassPeriod 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ClassPeriod_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ClassroomPositionDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ClassroomPositionDescriptor(ClassroomPositionDescriptorId, Id, ChangeVersion)
    SELECT OLD.ClassroomPositionDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ClassroomPositionDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ClassroomPositionDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ClassroomPositionDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CohortScopeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CohortScopeDescriptor(CohortScopeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CohortScopeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CohortScopeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CohortScopeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CohortScopeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CohortTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CohortTypeDescriptor(CohortTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CohortTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CohortTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CohortTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CohortTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CohortYearTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CohortYearTypeDescriptor(CohortYearTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CohortYearTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CohortYearTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CohortYearTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CohortYearTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Cohort_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Cohort(CohortIdentifier, EducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.CohortIdentifier, OLD.EducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Cohort 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Cohort_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CommunityOrganization_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CommunityOrganization(CommunityOrganizationId, Id, ChangeVersion)
    SELECT OLD.CommunityOrganizationId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.CommunityOrganizationId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CommunityOrganization 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CommunityOrganization_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CommunityProviderLicense_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CommunityProviderLicense(CommunityProviderId, LicenseIdentifier, LicensingOrganization, Id, ChangeVersion)
    VALUES (OLD.CommunityProviderId, OLD.LicenseIdentifier, OLD.LicensingOrganization, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CommunityProviderLicense 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CommunityProviderLicense_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CommunityProvider_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CommunityProvider(CommunityProviderId, Id, ChangeVersion)
    SELECT OLD.CommunityProviderId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.CommunityProviderId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CommunityProvider 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CommunityProvider_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CompetencyLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CompetencyLevelDescriptor(CompetencyLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.CompetencyLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CompetencyLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CompetencyLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CompetencyLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CompetencyObjective_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CompetencyObjective(EducationOrganizationId, Objective, ObjectiveGradeLevelDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.Objective, OLD.ObjectiveGradeLevelDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CompetencyObjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CompetencyObjective_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ContactTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ContactTypeDescriptor(ContactTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ContactTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ContactTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ContactTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ContactTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ContentClassDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ContentClassDescriptor(ContentClassDescriptorId, Id, ChangeVersion)
    SELECT OLD.ContentClassDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ContentClassDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ContentClassDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ContentClassDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ContinuationOfServicesReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ContinuationOfServicesReasonDescriptor(ContinuationOfServicesReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.ContinuationOfServicesReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ContinuationOfServicesReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ContinuationOfServicesReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ContinuationOfServicesReasonDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ContractedStaff_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ContractedStaff(AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.AccountIdentifier, OLD.AsOfDate, OLD.EducationOrganizationId, OLD.FiscalYear, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ContractedStaff 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ContractedStaff_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CostRateDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CostRateDescriptor(CostRateDescriptorId, Id, ChangeVersion)
    SELECT OLD.CostRateDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CostRateDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CostRateDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CostRateDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CountryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CountryDescriptor(CountryDescriptorId, Id, ChangeVersion)
    SELECT OLD.CountryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CountryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CountryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CountryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseAttemptResultDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseAttemptResultDescriptor(CourseAttemptResultDescriptorId, Id, ChangeVersion)
    SELECT OLD.CourseAttemptResultDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CourseAttemptResultDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseAttemptResultDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseAttemptResultDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseDefinedByDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseDefinedByDescriptor(CourseDefinedByDescriptorId, Id, ChangeVersion)
    SELECT OLD.CourseDefinedByDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CourseDefinedByDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseDefinedByDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseDefinedByDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseGPAApplicabilityDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseGPAApplicabilityDescriptor(CourseGPAApplicabilityDescriptorId, Id, ChangeVersion)
    SELECT OLD.CourseGPAApplicabilityDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CourseGPAApplicabilityDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseGPAApplicabilityDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseGPAApplicabilityDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseIdentificationSystemDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseIdentificationSystemDescriptor(CourseIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT OLD.CourseIdentificationSystemDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CourseIdentificationSystemDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseIdentificationSystemDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseIdentificationSystemDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseLevelCharacteristicDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseLevelCharacteristicDescriptor(CourseLevelCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT OLD.CourseLevelCharacteristicDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CourseLevelCharacteristicDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseLevelCharacteristicDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseLevelCharacteristicDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseOffering_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseOffering(LocalCourseCode, SchoolId, SchoolYear, SessionName, Id, ChangeVersion)
    VALUES (OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SessionName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseOffering 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseOffering_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseRepeatCodeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseRepeatCodeDescriptor(CourseRepeatCodeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CourseRepeatCodeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CourseRepeatCodeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseRepeatCodeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseRepeatCodeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CourseTranscript_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CourseTranscript(CourseAttemptResultDescriptorId, CourseCode, CourseEducationOrganizationId, EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.CourseAttemptResultDescriptorId, OLD.CourseCode, OLD.CourseEducationOrganizationId, OLD.EducationOrganizationId, OLD.SchoolYear, OLD.StudentUSI, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CourseTranscript 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CourseTranscript_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Course_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Course(CourseCode, EducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.CourseCode, OLD.EducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Course 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Course_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CredentialFieldDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CredentialFieldDescriptor(CredentialFieldDescriptorId, Id, ChangeVersion)
    SELECT OLD.CredentialFieldDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CredentialFieldDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CredentialFieldDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CredentialFieldDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CredentialTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CredentialTypeDescriptor(CredentialTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CredentialTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CredentialTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CredentialTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CredentialTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Credential_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Credential(CredentialIdentifier, StateOfIssueStateAbbreviationDescriptorId, Id, ChangeVersion)
    VALUES (OLD.CredentialIdentifier, OLD.StateOfIssueStateAbbreviationDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Credential 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Credential_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CreditCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CreditCategoryDescriptor(CreditCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.CreditCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CreditCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CreditCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CreditCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CreditTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CreditTypeDescriptor(CreditTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.CreditTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CreditTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CreditTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CreditTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.CurriculumUsedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.CurriculumUsedDescriptor(CurriculumUsedDescriptorId, Id, ChangeVersion)
    SELECT OLD.CurriculumUsedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.CurriculumUsedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.CurriculumUsedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.CurriculumUsedDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DeliveryMethodDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DeliveryMethodDescriptor(DeliveryMethodDescriptorId, Id, ChangeVersion)
    SELECT OLD.DeliveryMethodDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DeliveryMethodDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DeliveryMethodDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DeliveryMethodDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Descriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Descriptor(DescriptorId, Id, ChangeVersion)
    VALUES (OLD.DescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Descriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Descriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DiagnosisDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DiagnosisDescriptor(DiagnosisDescriptorId, Id, ChangeVersion)
    SELECT OLD.DiagnosisDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DiagnosisDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DiagnosisDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DiagnosisDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DiplomaLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DiplomaLevelDescriptor(DiplomaLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.DiplomaLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DiplomaLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DiplomaLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DiplomaLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DiplomaTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DiplomaTypeDescriptor(DiplomaTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.DiplomaTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DiplomaTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DiplomaTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DiplomaTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisabilityDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisabilityDescriptor(DisabilityDescriptorId, Id, ChangeVersion)
    SELECT OLD.DisabilityDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DisabilityDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisabilityDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisabilityDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisabilityDesignationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisabilityDesignationDescriptor(DisabilityDesignationDescriptorId, Id, ChangeVersion)
    SELECT OLD.DisabilityDesignationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DisabilityDesignationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisabilityDesignationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisabilityDesignationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisabilityDeterminationSourceTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisabilityDeterminationSourceTypeDescriptor(DisabilityDeterminationSourceTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.DisabilityDeterminationSourceTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DisabilityDeterminationSourceTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisabilityDeterminationSourceTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisabilityDeterminationSourceTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisciplineActionLengthDifferenceReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisciplineActionLengthDifferenceReasonDescriptor(DisciplineActionLengthDifferenceReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.DisciplineActionLengthDifferenceReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DisciplineActionLengthDifferenceReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisciplineActionLengthDifferenceReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisciplineActionLengthDifferenceReasonDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisciplineAction_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisciplineAction(DisciplineActionIdentifier, DisciplineDate, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.DisciplineActionIdentifier, OLD.DisciplineDate, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisciplineAction 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisciplineAction_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisciplineDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisciplineDescriptor(DisciplineDescriptorId, Id, ChangeVersion)
    SELECT OLD.DisciplineDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DisciplineDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisciplineDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisciplineDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisciplineIncidentParticipationCodeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisciplineIncidentParticipationCodeDescriptor(DisciplineIncidentParticipationCodeDescriptorId, Id, ChangeVersion)
    SELECT OLD.DisciplineIncidentParticipationCodeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.DisciplineIncidentParticipationCodeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisciplineIncidentParticipationCodeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisciplineIncidentParticipationCodeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.DisciplineIncident_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.DisciplineIncident(IncidentIdentifier, SchoolId, Id, ChangeVersion)
    VALUES (OLD.IncidentIdentifier, OLD.SchoolId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.DisciplineIncident 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.DisciplineIncident_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationContent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationContent(ContentIdentifier, Id, ChangeVersion)
    VALUES (OLD.ContentIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationContent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationContent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganizationCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganizationCategoryDescriptor(EducationOrganizationCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.EducationOrganizationCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EducationOrganizationCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganizationCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganizationCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganizationIdentificationSystemDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganizationIdentificationSystemDescriptor(EducationOrganizationIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT OLD.EducationOrganizationIdentificationSystemDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EducationOrganizationIdentificationSystemDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganizationIdentificationSystemDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganizationIdentificationSystemDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganizationInterventionPrescription_e670ae_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganizationInterventionPrescriptionAssociation(EducationOrganizationId, InterventionPrescriptionEducationOrganizationId, InterventionPrescriptionIdentificationCode, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.InterventionPrescriptionEducationOrganizationId, OLD.InterventionPrescriptionIdentificationCode, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganizationInterventionPrescriptionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganizationInterventionPrescription_e670ae_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganizationNetworkAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganizationNetworkAssociation(EducationOrganizationNetworkId, MemberEducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationNetworkId, OLD.MemberEducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganizationNetworkAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganizationNetworkAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganizationNetwork_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganizationNetwork(EducationOrganizationNetworkId, Id, ChangeVersion)
    SELECT OLD.EducationOrganizationNetworkId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.EducationOrganizationNetworkId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganizationNetwork 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganizationNetwork_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganizationPeerAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganizationPeerAssociation(EducationOrganizationId, PeerEducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.PeerEducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganizationPeerAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganizationPeerAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationOrganization_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationOrganization(EducationOrganizationId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationOrganization 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationOrganization_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationPlanDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationPlanDescriptor(EducationPlanDescriptorId, Id, ChangeVersion)
    SELECT OLD.EducationPlanDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EducationPlanDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationPlanDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationPlanDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationServiceCenter_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationServiceCenter(EducationServiceCenterId, Id, ChangeVersion)
    SELECT OLD.EducationServiceCenterId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.EducationServiceCenterId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationServiceCenter 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationServiceCenter_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EducationalEnvironmentDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EducationalEnvironmentDescriptor(EducationalEnvironmentDescriptorId, Id, ChangeVersion)
    SELECT OLD.EducationalEnvironmentDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EducationalEnvironmentDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EducationalEnvironmentDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EducationalEnvironmentDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ElectronicMailTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ElectronicMailTypeDescriptor(ElectronicMailTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ElectronicMailTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ElectronicMailTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ElectronicMailTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ElectronicMailTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EmploymentStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EmploymentStatusDescriptor(EmploymentStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.EmploymentStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EmploymentStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EmploymentStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EmploymentStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EntryGradeLevelReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EntryGradeLevelReasonDescriptor(EntryGradeLevelReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.EntryGradeLevelReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EntryGradeLevelReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EntryGradeLevelReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EntryGradeLevelReasonDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EntryTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EntryTypeDescriptor(EntryTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.EntryTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EntryTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EntryTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EntryTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.EventCircumstanceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.EventCircumstanceDescriptor(EventCircumstanceDescriptorId, Id, ChangeVersion)
    SELECT OLD.EventCircumstanceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.EventCircumstanceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.EventCircumstanceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.EventCircumstanceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ExitWithdrawTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ExitWithdrawTypeDescriptor(ExitWithdrawTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ExitWithdrawTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ExitWithdrawTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ExitWithdrawTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ExitWithdrawTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.FeederSchoolAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.FeederSchoolAssociation(BeginDate, FeederSchoolId, SchoolId, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.FeederSchoolId, OLD.SchoolId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.FeederSchoolAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.FeederSchoolAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GeneralStudentProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GeneralStudentProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GeneralStudentProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GeneralStudentProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradeLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradeLevelDescriptor(GradeLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.GradeLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GradeLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradeLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradeLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradePointAverageTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradePointAverageTypeDescriptor(GradePointAverageTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.GradePointAverageTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GradePointAverageTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradePointAverageTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradePointAverageTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradeTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradeTypeDescriptor(GradeTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.GradeTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GradeTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradeTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradeTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Grade_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Grade(BeginDate, GradeTypeDescriptorId, GradingPeriodDescriptorId, GradingPeriodSchoolYear, GradingPeriodSequence, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.GradeTypeDescriptorId, OLD.GradingPeriodDescriptorId, OLD.GradingPeriodSchoolYear, OLD.GradingPeriodSequence, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Grade 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Grade_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradebookEntryTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradebookEntryTypeDescriptor(GradebookEntryTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.GradebookEntryTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GradebookEntryTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradebookEntryTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradebookEntryTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradebookEntry_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradebookEntry(DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    VALUES (OLD.DateAssigned, OLD.GradebookEntryTitle, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradebookEntry 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradebookEntry_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradingPeriodDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradingPeriodDescriptor(GradingPeriodDescriptorId, Id, ChangeVersion)
    SELECT OLD.GradingPeriodDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GradingPeriodDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradingPeriodDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradingPeriodDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GradingPeriod_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GradingPeriod(GradingPeriodDescriptorId, PeriodSequence, SchoolId, SchoolYear, Id, ChangeVersion)
    VALUES (OLD.GradingPeriodDescriptorId, OLD.PeriodSequence, OLD.SchoolId, OLD.SchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GradingPeriod 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GradingPeriod_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GraduationPlanTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GraduationPlanTypeDescriptor(GraduationPlanTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.GraduationPlanTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GraduationPlanTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GraduationPlanTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GraduationPlanTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GraduationPlan_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GraduationPlan(EducationOrganizationId, GraduationPlanTypeDescriptorId, GraduationSchoolYear, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.GraduationPlanTypeDescriptorId, OLD.GraduationSchoolYear, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GraduationPlan 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GraduationPlan_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.GunFreeSchoolsActReportingStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.GunFreeSchoolsActReportingStatusDescriptor(GunFreeSchoolsActReportingStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.GunFreeSchoolsActReportingStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.GunFreeSchoolsActReportingStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.GunFreeSchoolsActReportingStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.GunFreeSchoolsActReportingStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.HomelessPrimaryNighttimeResidenceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.HomelessPrimaryNighttimeResidenceDescriptor(HomelessPrimaryNighttimeResidenceDescriptorId, Id, ChangeVersion)
    SELECT OLD.HomelessPrimaryNighttimeResidenceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.HomelessPrimaryNighttimeResidenceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.HomelessPrimaryNighttimeResidenceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.HomelessPrimaryNighttimeResidenceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.HomelessProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.HomelessProgramServiceDescriptor(HomelessProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.HomelessProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.HomelessProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.HomelessProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.HomelessProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.IdentificationDocumentUseDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.IdentificationDocumentUseDescriptor(IdentificationDocumentUseDescriptorId, Id, ChangeVersion)
    SELECT OLD.IdentificationDocumentUseDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.IdentificationDocumentUseDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.IdentificationDocumentUseDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.IdentificationDocumentUseDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.IncidentLocationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.IncidentLocationDescriptor(IncidentLocationDescriptorId, Id, ChangeVersion)
    SELECT OLD.IncidentLocationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.IncidentLocationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.IncidentLocationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.IncidentLocationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.IndicatorDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.IndicatorDescriptor(IndicatorDescriptorId, Id, ChangeVersion)
    SELECT OLD.IndicatorDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.IndicatorDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.IndicatorDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.IndicatorDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.IndicatorGroupDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.IndicatorGroupDescriptor(IndicatorGroupDescriptorId, Id, ChangeVersion)
    SELECT OLD.IndicatorGroupDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.IndicatorGroupDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.IndicatorGroupDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.IndicatorGroupDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.IndicatorLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.IndicatorLevelDescriptor(IndicatorLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.IndicatorLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.IndicatorLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.IndicatorLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.IndicatorLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InstitutionTelephoneNumberTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InstitutionTelephoneNumberTypeDescriptor(InstitutionTelephoneNumberTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.InstitutionTelephoneNumberTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InstitutionTelephoneNumberTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InstitutionTelephoneNumberTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InstitutionTelephoneNumberTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InteractivityStyleDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InteractivityStyleDescriptor(InteractivityStyleDescriptorId, Id, ChangeVersion)
    SELECT OLD.InteractivityStyleDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InteractivityStyleDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InteractivityStyleDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InteractivityStyleDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InternetAccessDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InternetAccessDescriptor(InternetAccessDescriptorId, Id, ChangeVersion)
    SELECT OLD.InternetAccessDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InternetAccessDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InternetAccessDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InternetAccessDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InternetAccessTypeInResidenceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InternetAccessTypeInResidenceDescriptor(InternetAccessTypeInResidenceDescriptorId, Id, ChangeVersion)
    SELECT OLD.InternetAccessTypeInResidenceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InternetAccessTypeInResidenceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InternetAccessTypeInResidenceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InternetAccessTypeInResidenceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InternetPerformanceInResidenceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InternetPerformanceInResidenceDescriptor(InternetPerformanceInResidenceDescriptorId, Id, ChangeVersion)
    SELECT OLD.InternetPerformanceInResidenceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InternetPerformanceInResidenceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InternetPerformanceInResidenceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InternetPerformanceInResidenceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InterventionClassDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InterventionClassDescriptor(InterventionClassDescriptorId, Id, ChangeVersion)
    SELECT OLD.InterventionClassDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InterventionClassDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InterventionClassDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InterventionClassDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InterventionEffectivenessRatingDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InterventionEffectivenessRatingDescriptor(InterventionEffectivenessRatingDescriptorId, Id, ChangeVersion)
    SELECT OLD.InterventionEffectivenessRatingDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.InterventionEffectivenessRatingDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InterventionEffectivenessRatingDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InterventionEffectivenessRatingDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InterventionPrescription_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InterventionPrescription(EducationOrganizationId, InterventionPrescriptionIdentificationCode, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.InterventionPrescriptionIdentificationCode, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InterventionPrescription 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InterventionPrescription_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.InterventionStudy_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.InterventionStudy(EducationOrganizationId, InterventionStudyIdentificationCode, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.InterventionStudyIdentificationCode, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.InterventionStudy 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.InterventionStudy_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Intervention_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Intervention(EducationOrganizationId, InterventionIdentificationCode, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.InterventionIdentificationCode, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Intervention 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Intervention_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LanguageDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LanguageDescriptor(LanguageDescriptorId, Id, ChangeVersion)
    SELECT OLD.LanguageDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LanguageDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LanguageDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LanguageDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LanguageInstructionProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LanguageInstructionProgramServiceDescriptor(LanguageInstructionProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.LanguageInstructionProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LanguageInstructionProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LanguageInstructionProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LanguageInstructionProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LanguageUseDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LanguageUseDescriptor(LanguageUseDescriptorId, Id, ChangeVersion)
    SELECT OLD.LanguageUseDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LanguageUseDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LanguageUseDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LanguageUseDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LearningObjective_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LearningObjective(LearningObjectiveId, Namespace, Id, ChangeVersion)
    VALUES (OLD.LearningObjectiveId, OLD.Namespace, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LearningObjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LearningObjective_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LearningStandardCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LearningStandardCategoryDescriptor(LearningStandardCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.LearningStandardCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LearningStandardCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LearningStandardCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LearningStandardCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LearningStandardEquivalenceAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LearningStandardEquivalenceAssociation(Namespace, SourceLearningStandardId, TargetLearningStandardId, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SourceLearningStandardId, OLD.TargetLearningStandardId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LearningStandardEquivalenceAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LearningStandardEquivalenceAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LearningStandardEquivalenceStrengthDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LearningStandardEquivalenceStrengthDescriptor(LearningStandardEquivalenceStrengthDescriptorId, Id, ChangeVersion)
    SELECT OLD.LearningStandardEquivalenceStrengthDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LearningStandardEquivalenceStrengthDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LearningStandardEquivalenceStrengthDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LearningStandardEquivalenceStrengthDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LearningStandardScopeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LearningStandardScopeDescriptor(LearningStandardScopeDescriptorId, Id, ChangeVersion)
    SELECT OLD.LearningStandardScopeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LearningStandardScopeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LearningStandardScopeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LearningStandardScopeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LearningStandard_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LearningStandard(LearningStandardId, Id, ChangeVersion)
    VALUES (OLD.LearningStandardId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LearningStandard 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LearningStandard_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LevelOfEducationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LevelOfEducationDescriptor(LevelOfEducationDescriptorId, Id, ChangeVersion)
    SELECT OLD.LevelOfEducationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LevelOfEducationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LevelOfEducationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LevelOfEducationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LicenseStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LicenseStatusDescriptor(LicenseStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.LicenseStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LicenseStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LicenseStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LicenseStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LicenseTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LicenseTypeDescriptor(LicenseTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.LicenseTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LicenseTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LicenseTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LicenseTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LimitedEnglishProficiencyDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LimitedEnglishProficiencyDescriptor(LimitedEnglishProficiencyDescriptorId, Id, ChangeVersion)
    SELECT OLD.LimitedEnglishProficiencyDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LimitedEnglishProficiencyDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LimitedEnglishProficiencyDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LimitedEnglishProficiencyDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LocalEducationAgencyCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LocalEducationAgencyCategoryDescriptor(LocalEducationAgencyCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.LocalEducationAgencyCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LocalEducationAgencyCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LocalEducationAgencyCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LocalEducationAgencyCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LocalEducationAgency_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LocalEducationAgency(LocalEducationAgencyId, Id, ChangeVersion)
    SELECT OLD.LocalEducationAgencyId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.LocalEducationAgencyId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LocalEducationAgency 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LocalEducationAgency_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.LocaleDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.LocaleDescriptor(LocaleDescriptorId, Id, ChangeVersion)
    SELECT OLD.LocaleDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.LocaleDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.LocaleDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.LocaleDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Location_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Location(ClassroomIdentificationCode, SchoolId, Id, ChangeVersion)
    VALUES (OLD.ClassroomIdentificationCode, OLD.SchoolId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Location 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Location_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.MagnetSpecialProgramEmphasisSchoolDescriptor(MagnetSpecialProgramEmphasisSchoolDescriptorId, Id, ChangeVersion)
    SELECT OLD.MagnetSpecialProgramEmphasisSchoolDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.MagnetSpecialProgramEmphasisSchoolDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.MagnetSpecialProgramEmphasisSchoolDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.MagnetSpecialProgramEmphasisSchoolDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.MediumOfInstructionDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.MediumOfInstructionDescriptor(MediumOfInstructionDescriptorId, Id, ChangeVersion)
    SELECT OLD.MediumOfInstructionDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.MediumOfInstructionDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.MediumOfInstructionDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.MediumOfInstructionDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.MethodCreditEarnedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.MethodCreditEarnedDescriptor(MethodCreditEarnedDescriptorId, Id, ChangeVersion)
    SELECT OLD.MethodCreditEarnedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.MethodCreditEarnedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.MethodCreditEarnedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.MethodCreditEarnedDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.MigrantEducationProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.MigrantEducationProgramServiceDescriptor(MigrantEducationProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.MigrantEducationProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.MigrantEducationProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.MigrantEducationProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.MigrantEducationProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.MonitoredDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.MonitoredDescriptor(MonitoredDescriptorId, Id, ChangeVersion)
    SELECT OLD.MonitoredDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.MonitoredDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.MonitoredDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.MonitoredDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.NeglectedOrDelinquentProgramDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.NeglectedOrDelinquentProgramDescriptor(NeglectedOrDelinquentProgramDescriptorId, Id, ChangeVersion)
    SELECT OLD.NeglectedOrDelinquentProgramDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.NeglectedOrDelinquentProgramDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.NeglectedOrDelinquentProgramDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.NeglectedOrDelinquentProgramDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.NeglectedOrDelinquentProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.NeglectedOrDelinquentProgramServiceDescriptor(NeglectedOrDelinquentProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.NeglectedOrDelinquentProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.NeglectedOrDelinquentProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.NeglectedOrDelinquentProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.NeglectedOrDelinquentProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.NetworkPurposeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.NetworkPurposeDescriptor(NetworkPurposeDescriptorId, Id, ChangeVersion)
    SELECT OLD.NetworkPurposeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.NetworkPurposeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.NetworkPurposeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.NetworkPurposeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ObjectiveAssessment_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ObjectiveAssessment(AssessmentIdentifier, IdentificationCode, Namespace, Id, ChangeVersion)
    VALUES (OLD.AssessmentIdentifier, OLD.IdentificationCode, OLD.Namespace, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ObjectiveAssessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ObjectiveAssessment_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.OldEthnicityDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.OldEthnicityDescriptor(OldEthnicityDescriptorId, Id, ChangeVersion)
    SELECT OLD.OldEthnicityDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.OldEthnicityDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.OldEthnicityDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.OldEthnicityDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.OpenStaffPosition_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.OpenStaffPosition(EducationOrganizationId, RequisitionNumber, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.RequisitionNumber, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.OpenStaffPosition 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.OpenStaffPosition_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.OperationalStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.OperationalStatusDescriptor(OperationalStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.OperationalStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.OperationalStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.OperationalStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.OperationalStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.OrganizationDepartment_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.OrganizationDepartment(OrganizationDepartmentId, Id, ChangeVersion)
    SELECT OLD.OrganizationDepartmentId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.OrganizationDepartmentId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.OrganizationDepartment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.OrganizationDepartment_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.OtherNameTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.OtherNameTypeDescriptor(OtherNameTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.OtherNameTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.OtherNameTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.OtherNameTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.OtherNameTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Parent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Parent(ParentUSI, Id, ChangeVersion)
    VALUES (OLD.ParentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Parent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Parent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ParticipationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ParticipationDescriptor(ParticipationDescriptorId, Id, ChangeVersion)
    SELECT OLD.ParticipationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ParticipationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ParticipationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ParticipationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ParticipationStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ParticipationStatusDescriptor(ParticipationStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.ParticipationStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ParticipationStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ParticipationStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ParticipationStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Payroll_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Payroll(AccountIdentifier, AsOfDate, EducationOrganizationId, FiscalYear, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.AccountIdentifier, OLD.AsOfDate, OLD.EducationOrganizationId, OLD.FiscalYear, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Payroll 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Payroll_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PerformanceBaseConversionDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PerformanceBaseConversionDescriptor(PerformanceBaseConversionDescriptorId, Id, ChangeVersion)
    SELECT OLD.PerformanceBaseConversionDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PerformanceBaseConversionDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PerformanceBaseConversionDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PerformanceBaseConversionDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PerformanceLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PerformanceLevelDescriptor(PerformanceLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.PerformanceLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PerformanceLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PerformanceLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PerformanceLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Person_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Person(PersonId, SourceSystemDescriptorId, Id, ChangeVersion)
    VALUES (OLD.PersonId, OLD.SourceSystemDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Person 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Person_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PersonalInformationVerificationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PersonalInformationVerificationDescriptor(PersonalInformationVerificationDescriptorId, Id, ChangeVersion)
    SELECT OLD.PersonalInformationVerificationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PersonalInformationVerificationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PersonalInformationVerificationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PersonalInformationVerificationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PlatformTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PlatformTypeDescriptor(PlatformTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.PlatformTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PlatformTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PlatformTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PlatformTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PopulationServedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PopulationServedDescriptor(PopulationServedDescriptorId, Id, ChangeVersion)
    SELECT OLD.PopulationServedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PopulationServedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PopulationServedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PopulationServedDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PostSecondaryEventCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PostSecondaryEventCategoryDescriptor(PostSecondaryEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.PostSecondaryEventCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PostSecondaryEventCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PostSecondaryEventCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PostSecondaryEventCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PostSecondaryEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PostSecondaryEvent(EventDate, PostSecondaryEventCategoryDescriptorId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.EventDate, OLD.PostSecondaryEventCategoryDescriptorId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PostSecondaryEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PostSecondaryEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PostSecondaryInstitutionLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PostSecondaryInstitutionLevelDescriptor(PostSecondaryInstitutionLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.PostSecondaryInstitutionLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PostSecondaryInstitutionLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PostSecondaryInstitutionLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PostSecondaryInstitutionLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PostSecondaryInstitution_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PostSecondaryInstitution(PostSecondaryInstitutionId, Id, ChangeVersion)
    SELECT OLD.PostSecondaryInstitutionId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.PostSecondaryInstitutionId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PostSecondaryInstitution 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PostSecondaryInstitution_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PostingResultDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PostingResultDescriptor(PostingResultDescriptorId, Id, ChangeVersion)
    SELECT OLD.PostingResultDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PostingResultDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PostingResultDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PostingResultDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PrimaryLearningDeviceAccessDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PrimaryLearningDeviceAccessDescriptor(PrimaryLearningDeviceAccessDescriptorId, Id, ChangeVersion)
    SELECT OLD.PrimaryLearningDeviceAccessDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PrimaryLearningDeviceAccessDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PrimaryLearningDeviceAccessDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PrimaryLearningDeviceAccessDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor(PrimaryLearningDeviceAwayFromSchoolDescriptorId, Id, ChangeVersion)
    SELECT OLD.PrimaryLearningDeviceAwayFromSchoolDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PrimaryLearningDeviceAwayFromSchoolDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PrimaryLearningDeviceAwayFromSchoolDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PrimaryLearningDeviceProviderDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PrimaryLearningDeviceProviderDescriptor(PrimaryLearningDeviceProviderDescriptorId, Id, ChangeVersion)
    SELECT OLD.PrimaryLearningDeviceProviderDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PrimaryLearningDeviceProviderDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PrimaryLearningDeviceProviderDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PrimaryLearningDeviceProviderDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProficiencyDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProficiencyDescriptor(ProficiencyDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProficiencyDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProficiencyDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProficiencyDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProficiencyDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProgramAssignmentDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProgramAssignmentDescriptor(ProgramAssignmentDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgramAssignmentDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgramAssignmentDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProgramAssignmentDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProgramAssignmentDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProgramCharacteristicDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProgramCharacteristicDescriptor(ProgramCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgramCharacteristicDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgramCharacteristicDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProgramCharacteristicDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProgramCharacteristicDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProgramSponsorDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProgramSponsorDescriptor(ProgramSponsorDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgramSponsorDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgramSponsorDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProgramSponsorDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProgramSponsorDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProgramTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProgramTypeDescriptor(ProgramTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgramTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgramTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProgramTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProgramTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Program_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Program(EducationOrganizationId, ProgramName, ProgramTypeDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Program 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Program_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProgressDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProgressDescriptor(ProgressDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgressDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgressDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProgressDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProgressDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProgressLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProgressLevelDescriptor(ProgressLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProgressLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProgressLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProgressLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProgressLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProviderCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProviderCategoryDescriptor(ProviderCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProviderCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProviderCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProviderCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProviderCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProviderProfitabilityDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProviderProfitabilityDescriptor(ProviderProfitabilityDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProviderProfitabilityDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProviderProfitabilityDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProviderProfitabilityDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProviderProfitabilityDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ProviderStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ProviderStatusDescriptor(ProviderStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.ProviderStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ProviderStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ProviderStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ProviderStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.PublicationStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.PublicationStatusDescriptor(PublicationStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.PublicationStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.PublicationStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.PublicationStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.PublicationStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.QuestionFormDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.QuestionFormDescriptor(QuestionFormDescriptorId, Id, ChangeVersion)
    SELECT OLD.QuestionFormDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.QuestionFormDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.QuestionFormDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.QuestionFormDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RaceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RaceDescriptor(RaceDescriptorId, Id, ChangeVersion)
    SELECT OLD.RaceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RaceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RaceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RaceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ReasonExitedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ReasonExitedDescriptor(ReasonExitedDescriptorId, Id, ChangeVersion)
    SELECT OLD.ReasonExitedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ReasonExitedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ReasonExitedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ReasonExitedDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ReasonNotTestedDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ReasonNotTestedDescriptor(ReasonNotTestedDescriptorId, Id, ChangeVersion)
    SELECT OLD.ReasonNotTestedDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ReasonNotTestedDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ReasonNotTestedDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ReasonNotTestedDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RecognitionTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RecognitionTypeDescriptor(RecognitionTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.RecognitionTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RecognitionTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RecognitionTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RecognitionTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RelationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RelationDescriptor(RelationDescriptorId, Id, ChangeVersion)
    SELECT OLD.RelationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RelationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RelationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RelationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RepeatIdentifierDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RepeatIdentifierDescriptor(RepeatIdentifierDescriptorId, Id, ChangeVersion)
    SELECT OLD.RepeatIdentifierDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RepeatIdentifierDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RepeatIdentifierDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RepeatIdentifierDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ReportCard_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ReportCard(EducationOrganizationId, GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.GradingPeriodDescriptorId, OLD.GradingPeriodSchoolId, OLD.GradingPeriodSchoolYear, OLD.GradingPeriodSequence, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ReportCard 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ReportCard_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ReporterDescriptionDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ReporterDescriptionDescriptor(ReporterDescriptionDescriptorId, Id, ChangeVersion)
    SELECT OLD.ReporterDescriptionDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ReporterDescriptionDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ReporterDescriptionDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ReporterDescriptionDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ResidencyStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ResidencyStatusDescriptor(ResidencyStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.ResidencyStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ResidencyStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ResidencyStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ResidencyStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ResponseIndicatorDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ResponseIndicatorDescriptor(ResponseIndicatorDescriptorId, Id, ChangeVersion)
    SELECT OLD.ResponseIndicatorDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ResponseIndicatorDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ResponseIndicatorDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ResponseIndicatorDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ResponsibilityDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ResponsibilityDescriptor(ResponsibilityDescriptorId, Id, ChangeVersion)
    SELECT OLD.ResponsibilityDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ResponsibilityDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ResponsibilityDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ResponsibilityDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RestraintEventReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RestraintEventReasonDescriptor(RestraintEventReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.RestraintEventReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RestraintEventReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RestraintEventReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RestraintEventReasonDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RestraintEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RestraintEvent(RestraintEventIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.RestraintEventIdentifier, OLD.SchoolId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RestraintEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RestraintEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ResultDatatypeTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ResultDatatypeTypeDescriptor(ResultDatatypeTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.ResultDatatypeTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ResultDatatypeTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ResultDatatypeTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ResultDatatypeTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.RetestIndicatorDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.RetestIndicatorDescriptor(RetestIndicatorDescriptorId, Id, ChangeVersion)
    SELECT OLD.RetestIndicatorDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.RetestIndicatorDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.RetestIndicatorDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.RetestIndicatorDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SchoolCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SchoolCategoryDescriptor(SchoolCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.SchoolCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SchoolCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SchoolCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SchoolCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SchoolChoiceImplementStatusDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SchoolChoiceImplementStatusDescriptor(SchoolChoiceImplementStatusDescriptorId, Id, ChangeVersion)
    SELECT OLD.SchoolChoiceImplementStatusDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SchoolChoiceImplementStatusDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SchoolChoiceImplementStatusDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SchoolChoiceImplementStatusDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SchoolFoodServiceProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SchoolFoodServiceProgramServiceDescriptor(SchoolFoodServiceProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.SchoolFoodServiceProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SchoolFoodServiceProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SchoolFoodServiceProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SchoolFoodServiceProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SchoolTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SchoolTypeDescriptor(SchoolTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.SchoolTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SchoolTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SchoolTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SchoolTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.School_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.School(SchoolId, Id, ChangeVersion)
    SELECT OLD.SchoolId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.SchoolId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.School 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.School_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SectionAttendanceTakenEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SectionAttendanceTakenEvent(CalendarCode, Date, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    VALUES (OLD.CalendarCode, OLD.Date, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SectionAttendanceTakenEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SectionAttendanceTakenEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SectionCharacteristicDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SectionCharacteristicDescriptor(SectionCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT OLD.SectionCharacteristicDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SectionCharacteristicDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SectionCharacteristicDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SectionCharacteristicDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Section_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Section(LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, Id, ChangeVersion)
    VALUES (OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Section 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Section_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SeparationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SeparationDescriptor(SeparationDescriptorId, Id, ChangeVersion)
    SELECT OLD.SeparationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SeparationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SeparationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SeparationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SeparationReasonDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SeparationReasonDescriptor(SeparationReasonDescriptorId, Id, ChangeVersion)
    SELECT OLD.SeparationReasonDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SeparationReasonDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SeparationReasonDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SeparationReasonDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.ServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.ServiceDescriptor(ServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.ServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.ServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.ServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.ServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Session_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Session(SchoolId, SchoolYear, SessionName, Id, ChangeVersion)
    VALUES (OLD.SchoolId, OLD.SchoolYear, OLD.SessionName, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Session 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Session_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SexDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SexDescriptor(SexDescriptorId, Id, ChangeVersion)
    SELECT OLD.SexDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SexDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SexDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SexDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SourceSystemDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SourceSystemDescriptor(SourceSystemDescriptorId, Id, ChangeVersion)
    SELECT OLD.SourceSystemDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SourceSystemDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SourceSystemDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SourceSystemDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SpecialEducationProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SpecialEducationProgramServiceDescriptor(SpecialEducationProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.SpecialEducationProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SpecialEducationProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SpecialEducationProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SpecialEducationProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SpecialEducationSettingDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SpecialEducationSettingDescriptor(SpecialEducationSettingDescriptorId, Id, ChangeVersion)
    SELECT OLD.SpecialEducationSettingDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SpecialEducationSettingDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SpecialEducationSettingDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SpecialEducationSettingDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffAbsenceEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffAbsenceEvent(AbsenceEventCategoryDescriptorId, EventDate, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.AbsenceEventCategoryDescriptorId, OLD.EventDate, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffAbsenceEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffAbsenceEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffClassificationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffClassificationDescriptor(StaffClassificationDescriptorId, Id, ChangeVersion)
    SELECT OLD.StaffClassificationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StaffClassificationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffClassificationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffClassificationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffCohortAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffCohortAssociation(BeginDate, CohortIdentifier, EducationOrganizationId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.CohortIdentifier, OLD.EducationOrganizationId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffCohortAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffCohortAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffDisciplineIncidentAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffDisciplineIncidentAssociation(IncidentIdentifier, SchoolId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.IncidentIdentifier, OLD.SchoolId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffDisciplineIncidentAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffDisciplineIncidentAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffEducationOrganizationAssignmentAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffEducationOrganizationAssignmentAssociation(BeginDate, EducationOrganizationId, StaffClassificationDescriptorId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.EducationOrganizationId, OLD.StaffClassificationDescriptorId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffEducationOrganizationAssignmentAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffEducationOrganizationAssignmentAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffEducationOrganizationContactAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffEducationOrganizationContactAssociation(ContactTitle, EducationOrganizationId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.ContactTitle, OLD.EducationOrganizationId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffEducationOrganizationContactAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffEducationOrganizationContactAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffEducationOrganizationEmploymentAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffEducationOrganizationEmploymentAssociation(EducationOrganizationId, EmploymentStatusDescriptorId, HireDate, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.EmploymentStatusDescriptorId, OLD.HireDate, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffEducationOrganizationEmploymentAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffEducationOrganizationEmploymentAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffIdentificationSystemDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffIdentificationSystemDescriptor(StaffIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT OLD.StaffIdentificationSystemDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StaffIdentificationSystemDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffIdentificationSystemDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffIdentificationSystemDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffLeaveEventCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffLeaveEventCategoryDescriptor(StaffLeaveEventCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.StaffLeaveEventCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StaffLeaveEventCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffLeaveEventCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffLeaveEventCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffLeave_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffLeave(BeginDate, StaffLeaveEventCategoryDescriptorId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.StaffLeaveEventCategoryDescriptorId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffLeave 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffLeave_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffProgramAssociation(BeginDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffSchoolAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffSchoolAssociation(ProgramAssignmentDescriptorId, SchoolId, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.ProgramAssignmentDescriptorId, OLD.SchoolId, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffSchoolAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffSchoolAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StaffSectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StaffSectionAssociation(LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StaffUSI, Id, ChangeVersion)
    VALUES (OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StaffSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StaffSectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Staff_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Staff(StaffUSI, Id, ChangeVersion)
    VALUES (OLD.StaffUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Staff 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Staff_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StateAbbreviationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StateAbbreviationDescriptor(StateAbbreviationDescriptorId, Id, ChangeVersion)
    SELECT OLD.StateAbbreviationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StateAbbreviationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StateAbbreviationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StateAbbreviationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StateEducationAgency_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StateEducationAgency(StateEducationAgencyId, Id, ChangeVersion)
    SELECT OLD.StateEducationAgencyId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.EducationOrganization WHERE EducationOrganizationId = OLD.StateEducationAgencyId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StateEducationAgency 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StateEducationAgency_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentAcademicRecord_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentAcademicRecord(EducationOrganizationId, SchoolYear, StudentUSI, TermDescriptorId, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.SchoolYear, OLD.StudentUSI, OLD.TermDescriptorId, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentAcademicRecord 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentAcademicRecord_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentAssessment_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentAssessment(AssessmentIdentifier, Namespace, StudentAssessmentIdentifier, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.AssessmentIdentifier, OLD.Namespace, OLD.StudentAssessmentIdentifier, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentAssessment 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentAssessment_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentCTEProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentCTEProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentCTEProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentCTEProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentCharacteristicDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentCharacteristicDescriptor(StudentCharacteristicDescriptorId, Id, ChangeVersion)
    SELECT OLD.StudentCharacteristicDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StudentCharacteristicDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentCharacteristicDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentCharacteristicDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentCohortAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentCohortAssociation(BeginDate, CohortIdentifier, EducationOrganizationId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.CohortIdentifier, OLD.EducationOrganizationId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentCohortAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentCohortAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentCompetencyObjective_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentCompetencyObjective(GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, Objective, ObjectiveEducationOrganizationId, ObjectiveGradeLevelDescriptorId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.GradingPeriodDescriptorId, OLD.GradingPeriodSchoolId, OLD.GradingPeriodSchoolYear, OLD.GradingPeriodSequence, OLD.Objective, OLD.ObjectiveEducationOrganizationId, OLD.ObjectiveGradeLevelDescriptorId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentCompetencyObjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentCompetencyObjective_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentDisciplineIncidentAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentDisciplineIncidentAssociation(IncidentIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.IncidentIdentifier, OLD.SchoolId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentDisciplineIncidentAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentDisciplineIncidentAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentDisciplineIncidentBehaviorAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentDisciplineIncidentBehaviorAssociation(BehaviorDescriptorId, IncidentIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BehaviorDescriptorId, OLD.IncidentIdentifier, OLD.SchoolId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentDisciplineIncidentBehaviorAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentDisciplineIncidentBehaviorAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentDisciplineIncidentNonOffenderAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentDisciplineIncidentNonOffenderAssociation(IncidentIdentifier, SchoolId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.IncidentIdentifier, OLD.SchoolId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentDisciplineIncidentNonOffenderAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentDisciplineIncidentNonOffenderAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentEducationOrganizationAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentEducationOrganizationAssociation(EducationOrganizationId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentEducationOrganizationAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentEducationOrganizationAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentEducationOrganizationResponsibilityAss_42aa64_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentEducationOrganizationResponsibilityAssociation(BeginDate, EducationOrganizationId, ResponsibilityDescriptorId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.EducationOrganizationId, OLD.ResponsibilityDescriptorId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentEducationOrganizationResponsibilityAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentEducationOrganizationResponsibilityAss_42aa64_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentGradebookEntry_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentGradebookEntry(BeginDate, DateAssigned, GradebookEntryTitle, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.DateAssigned, OLD.GradebookEntryTitle, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentGradebookEntry 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentGradebookEntry_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentHomelessProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentHomelessProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentHomelessProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentHomelessProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentIdentificationSystemDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentIdentificationSystemDescriptor(StudentIdentificationSystemDescriptorId, Id, ChangeVersion)
    SELECT OLD.StudentIdentificationSystemDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StudentIdentificationSystemDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentIdentificationSystemDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentIdentificationSystemDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentInterventionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentInterventionAssociation(EducationOrganizationId, InterventionIdentificationCode, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.InterventionIdentificationCode, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentInterventionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentInterventionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentInterventionAttendanceEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentInterventionAttendanceEvent(AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, InterventionIdentificationCode, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.AttendanceEventCategoryDescriptorId, OLD.EducationOrganizationId, OLD.EventDate, OLD.InterventionIdentificationCode, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentInterventionAttendanceEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentInterventionAttendanceEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentLanguageInstructionProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentLanguageInstructionProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentLanguageInstructionProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentLanguageInstructionProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentLearningObjective_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentLearningObjective(GradingPeriodDescriptorId, GradingPeriodSchoolId, GradingPeriodSchoolYear, GradingPeriodSequence, LearningObjectiveId, Namespace, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.GradingPeriodDescriptorId, OLD.GradingPeriodSchoolId, OLD.GradingPeriodSchoolYear, OLD.GradingPeriodSequence, OLD.LearningObjectiveId, OLD.Namespace, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentLearningObjective 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentLearningObjective_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentMigrantEducationProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentMigrantEducationProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentMigrantEducationProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentMigrantEducationProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentNeglectedOrDelinquentProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentNeglectedOrDelinquentProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentNeglectedOrDelinquentProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentNeglectedOrDelinquentProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentParentAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentParentAssociation(ParentUSI, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.ParentUSI, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentParentAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentParentAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentParticipationCodeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentParticipationCodeDescriptor(StudentParticipationCodeDescriptorId, Id, ChangeVersion)
    SELECT OLD.StudentParticipationCodeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.StudentParticipationCodeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentParticipationCodeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentParticipationCodeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentProgramAttendanceEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentProgramAttendanceEvent(AttendanceEventCategoryDescriptorId, EducationOrganizationId, EventDate, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.AttendanceEventCategoryDescriptorId, OLD.EducationOrganizationId, OLD.EventDate, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentProgramAttendanceEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentProgramAttendanceEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentSchoolAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentSchoolAssociation(EntryDate, SchoolId, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.EntryDate, OLD.SchoolId, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentSchoolAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentSchoolAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentSchoolAttendanceEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentSchoolAttendanceEvent(AttendanceEventCategoryDescriptorId, EventDate, SchoolId, SchoolYear, SessionName, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.AttendanceEventCategoryDescriptorId, OLD.EventDate, OLD.SchoolId, OLD.SchoolYear, OLD.SessionName, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentSchoolAttendanceEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentSchoolAttendanceEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentSchoolFoodServiceProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentSchoolFoodServiceProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentSchoolFoodServiceProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentSchoolFoodServiceProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentSectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentSectionAssociation(BeginDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.BeginDate, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentSectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentSectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentSectionAttendanceEvent_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentSectionAttendanceEvent(AttendanceEventCategoryDescriptorId, EventDate, LocalCourseCode, SchoolId, SchoolYear, SectionIdentifier, SessionName, StudentUSI, Id, ChangeVersion)
    VALUES (OLD.AttendanceEventCategoryDescriptorId, OLD.EventDate, OLD.LocalCourseCode, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentSectionAttendanceEvent 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentSectionAttendanceEvent_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentSpecialEducationProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentSpecialEducationProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentSpecialEducationProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentSpecialEducationProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.StudentTitleIPartAProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.StudentTitleIPartAProgramAssociation(BeginDate, EducationOrganizationId, ProgramEducationOrganizationId, ProgramName, ProgramTypeDescriptorId, StudentUSI, Id, ChangeVersion)
    SELECT OLD.BeginDate, OLD.EducationOrganizationId, OLD.ProgramEducationOrganizationId, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.StudentUSI, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.GeneralStudentProgramAssociation WHERE BeginDate = OLD.BeginDate AND EducationOrganizationId = OLD.EducationOrganizationId AND ProgramEducationOrganizationId = OLD.ProgramEducationOrganizationId AND ProgramName = OLD.ProgramName AND ProgramTypeDescriptorId = OLD.ProgramTypeDescriptorId AND StudentUSI = OLD.StudentUSI;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.StudentTitleIPartAProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.StudentTitleIPartAProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Student_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Student(StudentUSI, Id, ChangeVersion)
    VALUES (OLD.StudentUSI, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Student 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Student_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyCategoryDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyCategoryDescriptor(SurveyCategoryDescriptorId, Id, ChangeVersion)
    SELECT OLD.SurveyCategoryDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SurveyCategoryDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyCategoryDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyCategoryDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyCourseAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyCourseAssociation(CourseCode, EducationOrganizationId, Namespace, SurveyIdentifier, Id, ChangeVersion)
    VALUES (OLD.CourseCode, OLD.EducationOrganizationId, OLD.Namespace, OLD.SurveyIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyCourseAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyCourseAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyLevelDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyLevelDescriptor(SurveyLevelDescriptorId, Id, ChangeVersion)
    SELECT OLD.SurveyLevelDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.SurveyLevelDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyLevelDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyLevelDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyProgramAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyProgramAssociation(EducationOrganizationId, Namespace, ProgramName, ProgramTypeDescriptorId, SurveyIdentifier, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.Namespace, OLD.ProgramName, OLD.ProgramTypeDescriptorId, OLD.SurveyIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyProgramAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyProgramAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyQuestionResponse_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyQuestionResponse(Namespace, QuestionCode, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.QuestionCode, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyQuestionResponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyQuestionResponse_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyQuestion_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyQuestion(Namespace, QuestionCode, SurveyIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.QuestionCode, OLD.SurveyIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyQuestion 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyQuestion_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyResponseEducationOrganizationTargetAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyResponseEducationOrganizationTargetAssociation(EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyResponseEducationOrganizationTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyResponseEducationOrganizationTargetAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyResponseStaffTargetAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyResponseStaffTargetAssociation(Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.StaffUSI, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyResponseStaffTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyResponseStaffTargetAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveyResponse_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveyResponse(Namespace, SurveyIdentifier, SurveyResponseIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveyResponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveyResponse_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveySectionAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveySectionAssociation(LocalCourseCode, Namespace, SchoolId, SchoolYear, SectionIdentifier, SessionName, SurveyIdentifier, Id, ChangeVersion)
    VALUES (OLD.LocalCourseCode, OLD.Namespace, OLD.SchoolId, OLD.SchoolYear, OLD.SectionIdentifier, OLD.SessionName, OLD.SurveyIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveySectionAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveySectionAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveySectionResponseEducationOrganizationTar_730be1_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveySectionResponseEducationOrganizationTargetAssociation(EducationOrganizationId, Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    VALUES (OLD.EducationOrganizationId, OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.SurveySectionTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveySectionResponseEducationOrganizationTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveySectionResponseEducationOrganizationTar_730be1_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveySectionResponseStaffTargetAssociation_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveySectionResponseStaffTargetAssociation(Namespace, StaffUSI, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.StaffUSI, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.SurveySectionTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveySectionResponseStaffTargetAssociation 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveySectionResponseStaffTargetAssociation_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveySectionResponse_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveySectionResponse(Namespace, SurveyIdentifier, SurveyResponseIdentifier, SurveySectionTitle, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveyResponseIdentifier, OLD.SurveySectionTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveySectionResponse 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveySectionResponse_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.SurveySection_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.SurveySection(Namespace, SurveyIdentifier, SurveySectionTitle, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SurveyIdentifier, OLD.SurveySectionTitle, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.SurveySection 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.SurveySection_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.Survey_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.Survey(Namespace, SurveyIdentifier, Id, ChangeVersion)
    VALUES (OLD.Namespace, OLD.SurveyIdentifier, OLD.Id, nextval('changes.ChangeVersionSequence'));
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.Survey 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.Survey_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TeachingCredentialBasisDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TeachingCredentialBasisDescriptor(TeachingCredentialBasisDescriptorId, Id, ChangeVersion)
    SELECT OLD.TeachingCredentialBasisDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TeachingCredentialBasisDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TeachingCredentialBasisDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TeachingCredentialBasisDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TeachingCredentialDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TeachingCredentialDescriptor(TeachingCredentialDescriptorId, Id, ChangeVersion)
    SELECT OLD.TeachingCredentialDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TeachingCredentialDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TeachingCredentialDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TeachingCredentialDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TechnicalSkillsAssessmentDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TechnicalSkillsAssessmentDescriptor(TechnicalSkillsAssessmentDescriptorId, Id, ChangeVersion)
    SELECT OLD.TechnicalSkillsAssessmentDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TechnicalSkillsAssessmentDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TechnicalSkillsAssessmentDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TechnicalSkillsAssessmentDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TelephoneNumberTypeDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TelephoneNumberTypeDescriptor(TelephoneNumberTypeDescriptorId, Id, ChangeVersion)
    SELECT OLD.TelephoneNumberTypeDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TelephoneNumberTypeDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TelephoneNumberTypeDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TelephoneNumberTypeDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TermDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TermDescriptor(TermDescriptorId, Id, ChangeVersion)
    SELECT OLD.TermDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TermDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TermDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TermDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TitleIPartAParticipantDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TitleIPartAParticipantDescriptor(TitleIPartAParticipantDescriptorId, Id, ChangeVersion)
    SELECT OLD.TitleIPartAParticipantDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TitleIPartAParticipantDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TitleIPartAParticipantDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TitleIPartAParticipantDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TitleIPartAProgramServiceDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TitleIPartAProgramServiceDescriptor(TitleIPartAProgramServiceDescriptorId, Id, ChangeVersion)
    SELECT OLD.TitleIPartAProgramServiceDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TitleIPartAProgramServiceDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TitleIPartAProgramServiceDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TitleIPartAProgramServiceDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TitleIPartASchoolDesignationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TitleIPartASchoolDesignationDescriptor(TitleIPartASchoolDesignationDescriptorId, Id, ChangeVersion)
    SELECT OLD.TitleIPartASchoolDesignationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TitleIPartASchoolDesignationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TitleIPartASchoolDesignationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TitleIPartASchoolDesignationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.TribalAffiliationDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.TribalAffiliationDescriptor(TribalAffiliationDescriptorId, Id, ChangeVersion)
    SELECT OLD.TribalAffiliationDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.TribalAffiliationDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.TribalAffiliationDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.TribalAffiliationDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.VisaDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.VisaDescriptor(VisaDescriptorId, Id, ChangeVersion)
    SELECT OLD.VisaDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.VisaDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.VisaDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.VisaDescriptor_TR_DelTrkg();

CREATE FUNCTION tracked_deletes_edfi.WeaponDescriptor_TR_DelTrkg()
    RETURNS trigger AS
$BODY$
BEGIN
    INSERT INTO tracked_deletes_edfi.WeaponDescriptor(WeaponDescriptorId, Id, ChangeVersion)
    SELECT OLD.WeaponDescriptorId, Id, nextval('changes.ChangeVersionSequence')
    FROM edfi.Descriptor WHERE DescriptorId = OLD.WeaponDescriptorId;
    RETURN NULL;
END;
$BODY$ LANGUAGE plpgsql;

CREATE TRIGGER TrackDeletes AFTER DELETE ON edfi.WeaponDescriptor 
    FOR EACH ROW EXECUTE PROCEDURE tracked_deletes_edfi.WeaponDescriptor_TR_DelTrkg();


BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AcademicWeek') AND name = N'UX_AcademicWeek_ChangeVersion')
    CREATE INDEX [UX_AcademicWeek_ChangeVersion] ON [edfi].[AcademicWeek] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Account') AND name = N'UX_Account_ChangeVersion')
    CREATE INDEX [UX_Account_ChangeVersion] ON [edfi].[Account] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AccountCode') AND name = N'UX_AccountCode_ChangeVersion')
    CREATE INDEX [UX_AccountCode_ChangeVersion] ON [edfi].[AccountCode] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AccountabilityRating') AND name = N'UX_AccountabilityRating_ChangeVersion')
    CREATE INDEX [UX_AccountabilityRating_ChangeVersion] ON [edfi].[AccountabilityRating] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Actual') AND name = N'UX_Actual_ChangeVersion')
    CREATE INDEX [UX_Actual_ChangeVersion] ON [edfi].[Actual] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Assessment') AND name = N'UX_Assessment_ChangeVersion')
    CREATE INDEX [UX_Assessment_ChangeVersion] ON [edfi].[Assessment] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentItem') AND name = N'UX_AssessmentItem_ChangeVersion')
    CREATE INDEX [UX_AssessmentItem_ChangeVersion] ON [edfi].[AssessmentItem] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.AssessmentScoreRangeLearningStandard') AND name = N'UX_AssessmentScoreRangeLearningStandard_ChangeVersion')
    CREATE INDEX [UX_AssessmentScoreRangeLearningStandard_ChangeVersion] ON [edfi].[AssessmentScoreRangeLearningStandard] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.BellSchedule') AND name = N'UX_BellSchedule_ChangeVersion')
    CREATE INDEX [UX_BellSchedule_ChangeVersion] ON [edfi].[BellSchedule] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Budget') AND name = N'UX_Budget_ChangeVersion')
    CREATE INDEX [UX_Budget_ChangeVersion] ON [edfi].[Budget] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Calendar') AND name = N'UX_Calendar_ChangeVersion')
    CREATE INDEX [UX_Calendar_ChangeVersion] ON [edfi].[Calendar] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CalendarDate') AND name = N'UX_CalendarDate_ChangeVersion')
    CREATE INDEX [UX_CalendarDate_ChangeVersion] ON [edfi].[CalendarDate] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ClassPeriod') AND name = N'UX_ClassPeriod_ChangeVersion')
    CREATE INDEX [UX_ClassPeriod_ChangeVersion] ON [edfi].[ClassPeriod] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Cohort') AND name = N'UX_Cohort_ChangeVersion')
    CREATE INDEX [UX_Cohort_ChangeVersion] ON [edfi].[Cohort] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CommunityProviderLicense') AND name = N'UX_CommunityProviderLicense_ChangeVersion')
    CREATE INDEX [UX_CommunityProviderLicense_ChangeVersion] ON [edfi].[CommunityProviderLicense] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CompetencyObjective') AND name = N'UX_CompetencyObjective_ChangeVersion')
    CREATE INDEX [UX_CompetencyObjective_ChangeVersion] ON [edfi].[CompetencyObjective] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ContractedStaff') AND name = N'UX_ContractedStaff_ChangeVersion')
    CREATE INDEX [UX_ContractedStaff_ChangeVersion] ON [edfi].[ContractedStaff] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Course') AND name = N'UX_Course_ChangeVersion')
    CREATE INDEX [UX_Course_ChangeVersion] ON [edfi].[Course] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CourseOffering') AND name = N'UX_CourseOffering_ChangeVersion')
    CREATE INDEX [UX_CourseOffering_ChangeVersion] ON [edfi].[CourseOffering] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.CourseTranscript') AND name = N'UX_CourseTranscript_ChangeVersion')
    CREATE INDEX [UX_CourseTranscript_ChangeVersion] ON [edfi].[CourseTranscript] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Credential') AND name = N'UX_Credential_ChangeVersion')
    CREATE INDEX [UX_Credential_ChangeVersion] ON [edfi].[Credential] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Descriptor') AND name = N'UX_Descriptor_ChangeVersion')
    CREATE INDEX [UX_Descriptor_ChangeVersion] ON [edfi].[Descriptor] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.DisciplineAction') AND name = N'UX_DisciplineAction_ChangeVersion')
    CREATE INDEX [UX_DisciplineAction_ChangeVersion] ON [edfi].[DisciplineAction] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.DisciplineIncident') AND name = N'UX_DisciplineIncident_ChangeVersion')
    CREATE INDEX [UX_DisciplineIncident_ChangeVersion] ON [edfi].[DisciplineIncident] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationContent') AND name = N'UX_EducationContent_ChangeVersion')
    CREATE INDEX [UX_EducationContent_ChangeVersion] ON [edfi].[EducationContent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganization') AND name = N'UX_EducationOrganization_ChangeVersion')
    CREATE INDEX [UX_EducationOrganization_ChangeVersion] ON [edfi].[EducationOrganization] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationInterventionPrescriptionAssociation') AND name = N'UX_EducationOrganizationInterventionPrescriptionAssociation_ChangeVersion')
    CREATE INDEX [UX_EducationOrganizationInterventionPrescriptionAssociation_ChangeVersion] ON [edfi].[EducationOrganizationInterventionPrescriptionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationNetworkAssociation') AND name = N'UX_EducationOrganizationNetworkAssociation_ChangeVersion')
    CREATE INDEX [UX_EducationOrganizationNetworkAssociation_ChangeVersion] ON [edfi].[EducationOrganizationNetworkAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.EducationOrganizationPeerAssociation') AND name = N'UX_EducationOrganizationPeerAssociation_ChangeVersion')
    CREATE INDEX [UX_EducationOrganizationPeerAssociation_ChangeVersion] ON [edfi].[EducationOrganizationPeerAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.FeederSchoolAssociation') AND name = N'UX_FeederSchoolAssociation_ChangeVersion')
    CREATE INDEX [UX_FeederSchoolAssociation_ChangeVersion] ON [edfi].[FeederSchoolAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GeneralStudentProgramAssociation') AND name = N'UX_GeneralStudentProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_GeneralStudentProgramAssociation_ChangeVersion] ON [edfi].[GeneralStudentProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Grade') AND name = N'UX_Grade_ChangeVersion')
    CREATE INDEX [UX_Grade_ChangeVersion] ON [edfi].[Grade] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GradebookEntry') AND name = N'UX_GradebookEntry_ChangeVersion')
    CREATE INDEX [UX_GradebookEntry_ChangeVersion] ON [edfi].[GradebookEntry] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GradingPeriod') AND name = N'UX_GradingPeriod_ChangeVersion')
    CREATE INDEX [UX_GradingPeriod_ChangeVersion] ON [edfi].[GradingPeriod] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.GraduationPlan') AND name = N'UX_GraduationPlan_ChangeVersion')
    CREATE INDEX [UX_GraduationPlan_ChangeVersion] ON [edfi].[GraduationPlan] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Intervention') AND name = N'UX_Intervention_ChangeVersion')
    CREATE INDEX [UX_Intervention_ChangeVersion] ON [edfi].[Intervention] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.InterventionPrescription') AND name = N'UX_InterventionPrescription_ChangeVersion')
    CREATE INDEX [UX_InterventionPrescription_ChangeVersion] ON [edfi].[InterventionPrescription] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.InterventionStudy') AND name = N'UX_InterventionStudy_ChangeVersion')
    CREATE INDEX [UX_InterventionStudy_ChangeVersion] ON [edfi].[InterventionStudy] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LearningObjective') AND name = N'UX_LearningObjective_ChangeVersion')
    CREATE INDEX [UX_LearningObjective_ChangeVersion] ON [edfi].[LearningObjective] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LearningStandard') AND name = N'UX_LearningStandard_ChangeVersion')
    CREATE INDEX [UX_LearningStandard_ChangeVersion] ON [edfi].[LearningStandard] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.LearningStandardEquivalenceAssociation') AND name = N'UX_LearningStandardEquivalenceAssociation_ChangeVersion')
    CREATE INDEX [UX_LearningStandardEquivalenceAssociation_ChangeVersion] ON [edfi].[LearningStandardEquivalenceAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Location') AND name = N'UX_Location_ChangeVersion')
    CREATE INDEX [UX_Location_ChangeVersion] ON [edfi].[Location] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ObjectiveAssessment') AND name = N'UX_ObjectiveAssessment_ChangeVersion')
    CREATE INDEX [UX_ObjectiveAssessment_ChangeVersion] ON [edfi].[ObjectiveAssessment] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.OpenStaffPosition') AND name = N'UX_OpenStaffPosition_ChangeVersion')
    CREATE INDEX [UX_OpenStaffPosition_ChangeVersion] ON [edfi].[OpenStaffPosition] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Parent') AND name = N'UX_Parent_ChangeVersion')
    CREATE INDEX [UX_Parent_ChangeVersion] ON [edfi].[Parent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Payroll') AND name = N'UX_Payroll_ChangeVersion')
    CREATE INDEX [UX_Payroll_ChangeVersion] ON [edfi].[Payroll] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Person') AND name = N'UX_Person_ChangeVersion')
    CREATE INDEX [UX_Person_ChangeVersion] ON [edfi].[Person] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.PostSecondaryEvent') AND name = N'UX_PostSecondaryEvent_ChangeVersion')
    CREATE INDEX [UX_PostSecondaryEvent_ChangeVersion] ON [edfi].[PostSecondaryEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Program') AND name = N'UX_Program_ChangeVersion')
    CREATE INDEX [UX_Program_ChangeVersion] ON [edfi].[Program] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.ReportCard') AND name = N'UX_ReportCard_ChangeVersion')
    CREATE INDEX [UX_ReportCard_ChangeVersion] ON [edfi].[ReportCard] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.RestraintEvent') AND name = N'UX_RestraintEvent_ChangeVersion')
    CREATE INDEX [UX_RestraintEvent_ChangeVersion] ON [edfi].[RestraintEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SchoolYearType') AND name = N'UX_SchoolYearType_ChangeVersion')
    CREATE INDEX [UX_SchoolYearType_ChangeVersion] ON [edfi].[SchoolYearType] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Section') AND name = N'UX_Section_ChangeVersion')
    CREATE INDEX [UX_Section_ChangeVersion] ON [edfi].[Section] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SectionAttendanceTakenEvent') AND name = N'UX_SectionAttendanceTakenEvent_ChangeVersion')
    CREATE INDEX [UX_SectionAttendanceTakenEvent_ChangeVersion] ON [edfi].[SectionAttendanceTakenEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Session') AND name = N'UX_Session_ChangeVersion')
    CREATE INDEX [UX_Session_ChangeVersion] ON [edfi].[Session] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Staff') AND name = N'UX_Staff_ChangeVersion')
    CREATE INDEX [UX_Staff_ChangeVersion] ON [edfi].[Staff] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffAbsenceEvent') AND name = N'UX_StaffAbsenceEvent_ChangeVersion')
    CREATE INDEX [UX_StaffAbsenceEvent_ChangeVersion] ON [edfi].[StaffAbsenceEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffCohortAssociation') AND name = N'UX_StaffCohortAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffCohortAssociation_ChangeVersion] ON [edfi].[StaffCohortAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffDisciplineIncidentAssociation') AND name = N'UX_StaffDisciplineIncidentAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffDisciplineIncidentAssociation_ChangeVersion] ON [edfi].[StaffDisciplineIncidentAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffEducationOrganizationAssignmentAssociation') AND name = N'UX_StaffEducationOrganizationAssignmentAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffEducationOrganizationAssignmentAssociation_ChangeVersion] ON [edfi].[StaffEducationOrganizationAssignmentAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffEducationOrganizationContactAssociation') AND name = N'UX_StaffEducationOrganizationContactAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffEducationOrganizationContactAssociation_ChangeVersion] ON [edfi].[StaffEducationOrganizationContactAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffEducationOrganizationEmploymentAssociation') AND name = N'UX_StaffEducationOrganizationEmploymentAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffEducationOrganizationEmploymentAssociation_ChangeVersion] ON [edfi].[StaffEducationOrganizationEmploymentAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffLeave') AND name = N'UX_StaffLeave_ChangeVersion')
    CREATE INDEX [UX_StaffLeave_ChangeVersion] ON [edfi].[StaffLeave] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffProgramAssociation') AND name = N'UX_StaffProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffProgramAssociation_ChangeVersion] ON [edfi].[StaffProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffSchoolAssociation') AND name = N'UX_StaffSchoolAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffSchoolAssociation_ChangeVersion] ON [edfi].[StaffSchoolAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StaffSectionAssociation') AND name = N'UX_StaffSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_StaffSectionAssociation_ChangeVersion] ON [edfi].[StaffSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Student') AND name = N'UX_Student_ChangeVersion')
    CREATE INDEX [UX_Student_ChangeVersion] ON [edfi].[Student] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAcademicRecord') AND name = N'UX_StudentAcademicRecord_ChangeVersion')
    CREATE INDEX [UX_StudentAcademicRecord_ChangeVersion] ON [edfi].[StudentAcademicRecord] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentAssessment') AND name = N'UX_StudentAssessment_ChangeVersion')
    CREATE INDEX [UX_StudentAssessment_ChangeVersion] ON [edfi].[StudentAssessment] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentCohortAssociation') AND name = N'UX_StudentCohortAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentCohortAssociation_ChangeVersion] ON [edfi].[StudentCohortAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentCompetencyObjective') AND name = N'UX_StudentCompetencyObjective_ChangeVersion')
    CREATE INDEX [UX_StudentCompetencyObjective_ChangeVersion] ON [edfi].[StudentCompetencyObjective] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDisciplineIncidentAssociation') AND name = N'UX_StudentDisciplineIncidentAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentDisciplineIncidentAssociation_ChangeVersion] ON [edfi].[StudentDisciplineIncidentAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDisciplineIncidentBehaviorAssociation') AND name = N'UX_StudentDisciplineIncidentBehaviorAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentDisciplineIncidentBehaviorAssociation_ChangeVersion] ON [edfi].[StudentDisciplineIncidentBehaviorAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentDisciplineIncidentNonOffenderAssociation') AND name = N'UX_StudentDisciplineIncidentNonOffenderAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentDisciplineIncidentNonOffenderAssociation_ChangeVersion] ON [edfi].[StudentDisciplineIncidentNonOffenderAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentEducationOrganizationAssociation') AND name = N'UX_StudentEducationOrganizationAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentEducationOrganizationAssociation_ChangeVersion] ON [edfi].[StudentEducationOrganizationAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentEducationOrganizationResponsibilityAssociation') AND name = N'UX_StudentEducationOrganizationResponsibilityAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentEducationOrganizationResponsibilityAssociation_ChangeVersion] ON [edfi].[StudentEducationOrganizationResponsibilityAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentGradebookEntry') AND name = N'UX_StudentGradebookEntry_ChangeVersion')
    CREATE INDEX [UX_StudentGradebookEntry_ChangeVersion] ON [edfi].[StudentGradebookEntry] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentInterventionAssociation') AND name = N'UX_StudentInterventionAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentInterventionAssociation_ChangeVersion] ON [edfi].[StudentInterventionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentInterventionAttendanceEvent') AND name = N'UX_StudentInterventionAttendanceEvent_ChangeVersion')
    CREATE INDEX [UX_StudentInterventionAttendanceEvent_ChangeVersion] ON [edfi].[StudentInterventionAttendanceEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentLearningObjective') AND name = N'UX_StudentLearningObjective_ChangeVersion')
    CREATE INDEX [UX_StudentLearningObjective_ChangeVersion] ON [edfi].[StudentLearningObjective] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentParentAssociation') AND name = N'UX_StudentParentAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentParentAssociation_ChangeVersion] ON [edfi].[StudentParentAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentProgramAttendanceEvent') AND name = N'UX_StudentProgramAttendanceEvent_ChangeVersion')
    CREATE INDEX [UX_StudentProgramAttendanceEvent_ChangeVersion] ON [edfi].[StudentProgramAttendanceEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSchoolAssociation') AND name = N'UX_StudentSchoolAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentSchoolAssociation_ChangeVersion] ON [edfi].[StudentSchoolAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSchoolAttendanceEvent') AND name = N'UX_StudentSchoolAttendanceEvent_ChangeVersion')
    CREATE INDEX [UX_StudentSchoolAttendanceEvent_ChangeVersion] ON [edfi].[StudentSchoolAttendanceEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSectionAssociation') AND name = N'UX_StudentSectionAssociation_ChangeVersion')
    CREATE INDEX [UX_StudentSectionAssociation_ChangeVersion] ON [edfi].[StudentSectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.StudentSectionAttendanceEvent') AND name = N'UX_StudentSectionAttendanceEvent_ChangeVersion')
    CREATE INDEX [UX_StudentSectionAttendanceEvent_ChangeVersion] ON [edfi].[StudentSectionAttendanceEvent] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.Survey') AND name = N'UX_Survey_ChangeVersion')
    CREATE INDEX [UX_Survey_ChangeVersion] ON [edfi].[Survey] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyCourseAssociation') AND name = N'UX_SurveyCourseAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyCourseAssociation_ChangeVersion] ON [edfi].[SurveyCourseAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyProgramAssociation') AND name = N'UX_SurveyProgramAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyProgramAssociation_ChangeVersion] ON [edfi].[SurveyProgramAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyQuestion') AND name = N'UX_SurveyQuestion_ChangeVersion')
    CREATE INDEX [UX_SurveyQuestion_ChangeVersion] ON [edfi].[SurveyQuestion] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyQuestionResponse') AND name = N'UX_SurveyQuestionResponse_ChangeVersion')
    CREATE INDEX [UX_SurveyQuestionResponse_ChangeVersion] ON [edfi].[SurveyQuestionResponse] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponse') AND name = N'UX_SurveyResponse_ChangeVersion')
    CREATE INDEX [UX_SurveyResponse_ChangeVersion] ON [edfi].[SurveyResponse] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponseEducationOrganizationTargetAssociation') AND name = N'UX_SurveyResponseEducationOrganizationTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyResponseEducationOrganizationTargetAssociation_ChangeVersion] ON [edfi].[SurveyResponseEducationOrganizationTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveyResponseStaffTargetAssociation') AND name = N'UX_SurveyResponseStaffTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveyResponseStaffTargetAssociation_ChangeVersion] ON [edfi].[SurveyResponseStaffTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySection') AND name = N'UX_SurveySection_ChangeVersion')
    CREATE INDEX [UX_SurveySection_ChangeVersion] ON [edfi].[SurveySection] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionAssociation') AND name = N'UX_SurveySectionAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveySectionAssociation_ChangeVersion] ON [edfi].[SurveySectionAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponse') AND name = N'UX_SurveySectionResponse_ChangeVersion')
    CREATE INDEX [UX_SurveySectionResponse_ChangeVersion] ON [edfi].[SurveySectionResponse] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponseEducationOrganizationTargetAssociation') AND name = N'UX_SurveySectionResponseEducationOrganizationTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveySectionResponseEducationOrganizationTargetAssociation_ChangeVersion] ON [edfi].[SurveySectionResponseEducationOrganizationTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT

BEGIN TRANSACTION
    IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'edfi.SurveySectionResponseStaffTargetAssociation') AND name = N'UX_SurveySectionResponseStaffTargetAssociation_ChangeVersion')
    CREATE INDEX [UX_SurveySectionResponseStaffTargetAssociation_ChangeVersion] ON [edfi].[SurveySectionResponseStaffTargetAssociation] ([ChangeVersion] ASC)
    GO
COMMIT


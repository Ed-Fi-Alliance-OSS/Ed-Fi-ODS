using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Entities.Common.TPDM;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Api.Services.Requests;

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AidTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AidTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor,
        Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor,
        Entities.Common.TPDM.IAidTypeDescriptor,
        Entities.NHibernate.AidTypeDescriptorAggregate.TPDM.AidTypeDescriptor,
        Api.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorPut,
        Api.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorPost,
        Api.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorDelete,
        Api.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorGetByExample>
    {
        public AidTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorGetByExample request, Entities.Common.TPDM.IAidTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AidTypeDescriptorId = request.AidTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "aidTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudent.TPDM.AnonymizedStudent,
        Models.Resources.AnonymizedStudent.TPDM.AnonymizedStudent,
        Entities.Common.TPDM.IAnonymizedStudent,
        Entities.NHibernate.AnonymizedStudentAggregate.TPDM.AnonymizedStudent,
        Api.Models.Requests.TPDM.AnonymizedStudents.AnonymizedStudentPut,
        Api.Models.Requests.TPDM.AnonymizedStudents.AnonymizedStudentPost,
        Api.Models.Requests.TPDM.AnonymizedStudents.AnonymizedStudentDelete,
        Api.Models.Requests.TPDM.AnonymizedStudents.AnonymizedStudentGetByExample>
    {
        public AnonymizedStudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudents.AnonymizedStudentGetByExample request, Entities.Common.TPDM.IAnonymizedStudent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.AtriskIndicator = request.AtriskIndicator;
            specification.ELLEnrollment = request.ELLEnrollment;
            specification.ESLEnrollment = request.ESLEnrollment;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.GenderDescriptor = request.GenderDescriptor;
            specification.GradeLevelDescriptor = request.GradeLevelDescriptor;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.Mobility = request.Mobility;
            specification.SchoolYear = request.SchoolYear;
            specification.Section504Enrollment = request.Section504Enrollment;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SPEDEnrollment = request.SPEDEnrollment;
            specification.TitleIEnrollment = request.TitleIEnrollment;
            specification.ValueTypeDescriptor = request.ValueTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentAcademicRecords
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentAcademicRecordsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentAcademicRecord.TPDM.AnonymizedStudentAcademicRecord,
        Models.Resources.AnonymizedStudentAcademicRecord.TPDM.AnonymizedStudentAcademicRecord,
        Entities.Common.TPDM.IAnonymizedStudentAcademicRecord,
        Entities.NHibernate.AnonymizedStudentAcademicRecordAggregate.TPDM.AnonymizedStudentAcademicRecord,
        Api.Models.Requests.TPDM.AnonymizedStudentAcademicRecords.AnonymizedStudentAcademicRecordPut,
        Api.Models.Requests.TPDM.AnonymizedStudentAcademicRecords.AnonymizedStudentAcademicRecordPost,
        Api.Models.Requests.TPDM.AnonymizedStudentAcademicRecords.AnonymizedStudentAcademicRecordDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentAcademicRecords.AnonymizedStudentAcademicRecordGetByExample>
    {
        public AnonymizedStudentAcademicRecordsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentAcademicRecords.AnonymizedStudentAcademicRecordGetByExample request, Entities.Common.TPDM.IAnonymizedStudentAcademicRecord specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.CumulativeGradePointAverage = request.CumulativeGradePointAverage;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.GPAMax = request.GPAMax;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionGradePointAverage = request.SessionGradePointAverage;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentAcademicRecords";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentAssessments
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentAssessmentsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentAssessment.TPDM.AnonymizedStudentAssessment,
        Models.Resources.AnonymizedStudentAssessment.TPDM.AnonymizedStudentAssessment,
        Entities.Common.TPDM.IAnonymizedStudentAssessment,
        Entities.NHibernate.AnonymizedStudentAssessmentAggregate.TPDM.AnonymizedStudentAssessment,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessments.AnonymizedStudentAssessmentPut,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessments.AnonymizedStudentAssessmentPost,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessments.AnonymizedStudentAssessmentDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessments.AnonymizedStudentAssessmentGetByExample>
    {
        public AnonymizedStudentAssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentAssessments.AnonymizedStudentAssessmentGetByExample request, Entities.Common.TPDM.IAnonymizedStudentAssessment specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AdministrationDate = request.AdministrationDate;
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.GradeLevelDescriptor = request.GradeLevelDescriptor;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TakenSchoolYear = request.TakenSchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentAssessments";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentAssessmentCourseAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentAssessmentCourseAssociationsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentAssessmentCourseAssociation.TPDM.AnonymizedStudentAssessmentCourseAssociation,
        Models.Resources.AnonymizedStudentAssessmentCourseAssociation.TPDM.AnonymizedStudentAssessmentCourseAssociation,
        Entities.Common.TPDM.IAnonymizedStudentAssessmentCourseAssociation,
        Entities.NHibernate.AnonymizedStudentAssessmentCourseAssociationAggregate.TPDM.AnonymizedStudentAssessmentCourseAssociation,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations.AnonymizedStudentAssessmentCourseAssociationPut,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations.AnonymizedStudentAssessmentCourseAssociationPost,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations.AnonymizedStudentAssessmentCourseAssociationDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations.AnonymizedStudentAssessmentCourseAssociationGetByExample>
    {
        public AnonymizedStudentAssessmentCourseAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentAssessmentCourseAssociations.AnonymizedStudentAssessmentCourseAssociationGetByExample request, Entities.Common.TPDM.IAnonymizedStudentAssessmentCourseAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationDate = request.AdministrationDate;
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TakenSchoolYear = request.TakenSchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentAssessmentCourseAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentAssessmentSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentAssessmentSectionAssociationsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentAssessmentSectionAssociation.TPDM.AnonymizedStudentAssessmentSectionAssociation,
        Models.Resources.AnonymizedStudentAssessmentSectionAssociation.TPDM.AnonymizedStudentAssessmentSectionAssociation,
        Entities.Common.TPDM.IAnonymizedStudentAssessmentSectionAssociation,
        Entities.NHibernate.AnonymizedStudentAssessmentSectionAssociationAggregate.TPDM.AnonymizedStudentAssessmentSectionAssociation,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations.AnonymizedStudentAssessmentSectionAssociationPut,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations.AnonymizedStudentAssessmentSectionAssociationPost,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations.AnonymizedStudentAssessmentSectionAssociationDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations.AnonymizedStudentAssessmentSectionAssociationGetByExample>
    {
        public AnonymizedStudentAssessmentSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentAssessmentSectionAssociations.AnonymizedStudentAssessmentSectionAssociationGetByExample request, Entities.Common.TPDM.IAnonymizedStudentAssessmentSectionAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationDate = request.AdministrationDate;
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.TakenSchoolYear = request.TakenSchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentAssessmentSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentCourseAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentCourseAssociationsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentCourseAssociation.TPDM.AnonymizedStudentCourseAssociation,
        Models.Resources.AnonymizedStudentCourseAssociation.TPDM.AnonymizedStudentCourseAssociation,
        Entities.Common.TPDM.IAnonymizedStudentCourseAssociation,
        Entities.NHibernate.AnonymizedStudentCourseAssociationAggregate.TPDM.AnonymizedStudentCourseAssociation,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseAssociations.AnonymizedStudentCourseAssociationPut,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseAssociations.AnonymizedStudentCourseAssociationPost,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseAssociations.AnonymizedStudentCourseAssociationDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseAssociations.AnonymizedStudentCourseAssociationGetByExample>
    {
        public AnonymizedStudentCourseAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentCourseAssociations.AnonymizedStudentCourseAssociationGetByExample request, Entities.Common.TPDM.IAnonymizedStudentCourseAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.BeginDate = request.BeginDate;
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentCourseAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentCourseTranscripts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentCourseTranscriptsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentCourseTranscript.TPDM.AnonymizedStudentCourseTranscript,
        Models.Resources.AnonymizedStudentCourseTranscript.TPDM.AnonymizedStudentCourseTranscript,
        Entities.Common.TPDM.IAnonymizedStudentCourseTranscript,
        Entities.NHibernate.AnonymizedStudentCourseTranscriptAggregate.TPDM.AnonymizedStudentCourseTranscript,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts.AnonymizedStudentCourseTranscriptPut,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts.AnonymizedStudentCourseTranscriptPost,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts.AnonymizedStudentCourseTranscriptDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts.AnonymizedStudentCourseTranscriptGetByExample>
    {
        public AnonymizedStudentCourseTranscriptsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentCourseTranscripts.AnonymizedStudentCourseTranscriptGetByExample request, Entities.Common.TPDM.IAnonymizedStudentCourseTranscript specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.CourseCode = request.CourseCode;
            specification.CourseRepeatCodeDescriptor = request.CourseRepeatCodeDescriptor;
            specification.CourseTitle = request.CourseTitle;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.FinalLetterGradeEarned = request.FinalLetterGradeEarned;
            specification.FinalNumericGradeEarned = request.FinalNumericGradeEarned;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentCourseTranscripts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentEducationOrganizationAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentEducationOrganizationAssociationsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentEducationOrganizationAssociation.TPDM.AnonymizedStudentEducationOrganizationAssociation,
        Models.Resources.AnonymizedStudentEducationOrganizationAssociation.TPDM.AnonymizedStudentEducationOrganizationAssociation,
        Entities.Common.TPDM.IAnonymizedStudentEducationOrganizationAssociation,
        Entities.NHibernate.AnonymizedStudentEducationOrganizationAssociationAggregate.TPDM.AnonymizedStudentEducationOrganizationAssociation,
        Api.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations.AnonymizedStudentEducationOrganizationAssociationPut,
        Api.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations.AnonymizedStudentEducationOrganizationAssociationPost,
        Api.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations.AnonymizedStudentEducationOrganizationAssociationDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations.AnonymizedStudentEducationOrganizationAssociationGetByExample>
    {
        public AnonymizedStudentEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentEducationOrganizationAssociations.AnonymizedStudentEducationOrganizationAssociationGetByExample request, Entities.Common.TPDM.IAnonymizedStudentEducationOrganizationAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentEducationOrganizationAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AnonymizedStudentSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AnonymizedStudentSectionAssociationsController : EdFiControllerBase<
        Models.Resources.AnonymizedStudentSectionAssociation.TPDM.AnonymizedStudentSectionAssociation,
        Models.Resources.AnonymizedStudentSectionAssociation.TPDM.AnonymizedStudentSectionAssociation,
        Entities.Common.TPDM.IAnonymizedStudentSectionAssociation,
        Entities.NHibernate.AnonymizedStudentSectionAssociationAggregate.TPDM.AnonymizedStudentSectionAssociation,
        Api.Models.Requests.TPDM.AnonymizedStudentSectionAssociations.AnonymizedStudentSectionAssociationPut,
        Api.Models.Requests.TPDM.AnonymizedStudentSectionAssociations.AnonymizedStudentSectionAssociationPost,
        Api.Models.Requests.TPDM.AnonymizedStudentSectionAssociations.AnonymizedStudentSectionAssociationDelete,
        Api.Models.Requests.TPDM.AnonymizedStudentSectionAssociations.AnonymizedStudentSectionAssociationGetByExample>
    {
        public AnonymizedStudentSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AnonymizedStudentSectionAssociations.AnonymizedStudentSectionAssociationGetByExample request, Entities.Common.TPDM.IAnonymizedStudentSectionAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AnonymizedStudentIdentifier = request.AnonymizedStudentIdentifier;
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
                    }

        protected override string GetResourceCollectionName()
        {
            return "anonymizedStudentSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Applicants
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantsController : EdFiControllerBase<
        Models.Resources.Applicant.TPDM.Applicant,
        Models.Resources.Applicant.TPDM.Applicant,
        Entities.Common.TPDM.IApplicant,
        Entities.NHibernate.ApplicantAggregate.TPDM.Applicant,
        Api.Models.Requests.TPDM.Applicants.ApplicantPut,
        Api.Models.Requests.TPDM.Applicants.ApplicantPost,
        Api.Models.Requests.TPDM.Applicants.ApplicantDelete,
        Api.Models.Requests.TPDM.Applicants.ApplicantGetByExample>
    {
        public ApplicantsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Applicants.ApplicantGetByExample request, Entities.Common.TPDM.IApplicant specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EconomicDisadvantaged = request.EconomicDisadvantaged;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstGenerationStudent = request.FirstGenerationStudent;
            specification.FirstName = request.FirstName;
            specification.GenderDescriptor = request.GenderDescriptor;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicants";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicantProspectAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicantProspectAssociationsController : EdFiControllerBase<
        Models.Resources.ApplicantProspectAssociation.TPDM.ApplicantProspectAssociation,
        Models.Resources.ApplicantProspectAssociation.TPDM.ApplicantProspectAssociation,
        Entities.Common.TPDM.IApplicantProspectAssociation,
        Entities.NHibernate.ApplicantProspectAssociationAggregate.TPDM.ApplicantProspectAssociation,
        Api.Models.Requests.TPDM.ApplicantProspectAssociations.ApplicantProspectAssociationPut,
        Api.Models.Requests.TPDM.ApplicantProspectAssociations.ApplicantProspectAssociationPost,
        Api.Models.Requests.TPDM.ApplicantProspectAssociations.ApplicantProspectAssociationDelete,
        Api.Models.Requests.TPDM.ApplicantProspectAssociations.ApplicantProspectAssociationGetByExample>
    {
        public ApplicantProspectAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ApplicantProspectAssociations.ApplicantProspectAssociationGetByExample request, Entities.Common.TPDM.IApplicantProspectAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProspectIdentifier = request.ProspectIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicantProspectAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Applications
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicationsController : EdFiControllerBase<
        Models.Resources.Application.TPDM.Application,
        Models.Resources.Application.TPDM.Application,
        Entities.Common.TPDM.IApplication,
        Entities.NHibernate.ApplicationAggregate.TPDM.Application,
        Api.Models.Requests.TPDM.Applications.ApplicationPut,
        Api.Models.Requests.TPDM.Applications.ApplicationPost,
        Api.Models.Requests.TPDM.Applications.ApplicationDelete,
        Api.Models.Requests.TPDM.Applications.ApplicationGetByExample>
    {
        public ApplicationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Applications.ApplicationGetByExample request, Entities.Common.TPDM.IApplication specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AcceptedDate = request.AcceptedDate;
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.ApplicationDate = request.ApplicationDate;
            specification.ApplicationIdentifier = request.ApplicationIdentifier;
            specification.ApplicationSourceDescriptor = request.ApplicationSourceDescriptor;
            specification.ApplicationStatusDescriptor = request.ApplicationStatusDescriptor;
            specification.CurrentEmployee = request.CurrentEmployee;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FirstContactDate = request.FirstContactDate;
            specification.HighNeedsAcademicSubjectDescriptor = request.HighNeedsAcademicSubjectDescriptor;
            specification.HireStatusDescriptor = request.HireStatusDescriptor;
            specification.HiringSourceDescriptor = request.HiringSourceDescriptor;
            specification.Id = request.Id;
            specification.WithdrawDate = request.WithdrawDate;
            specification.WithdrawReasonDescriptor = request.WithdrawReasonDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applications";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicationEventsController : EdFiControllerBase<
        Models.Resources.ApplicationEvent.TPDM.ApplicationEvent,
        Models.Resources.ApplicationEvent.TPDM.ApplicationEvent,
        Entities.Common.TPDM.IApplicationEvent,
        Entities.NHibernate.ApplicationEventAggregate.TPDM.ApplicationEvent,
        Api.Models.Requests.TPDM.ApplicationEvents.ApplicationEventPut,
        Api.Models.Requests.TPDM.ApplicationEvents.ApplicationEventPost,
        Api.Models.Requests.TPDM.ApplicationEvents.ApplicationEventDelete,
        Api.Models.Requests.TPDM.ApplicationEvents.ApplicationEventGetByExample>
    {
        public ApplicationEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ApplicationEvents.ApplicationEventGetByExample request, Entities.Common.TPDM.IApplicationEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.ApplicationEvaluationScore = request.ApplicationEvaluationScore;
            specification.ApplicationEventResultDescriptor = request.ApplicationEventResultDescriptor;
            specification.ApplicationEventTypeDescriptor = request.ApplicationEventTypeDescriptor;
            specification.ApplicationIdentifier = request.ApplicationIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EventDate = request.EventDate;
            specification.EventEndDate = request.EventEndDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.SequenceNumber = request.SequenceNumber;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicationEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationEventResultDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicationEventResultDescriptorsController : EdFiControllerBase<
        Models.Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor,
        Models.Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor,
        Entities.Common.TPDM.IApplicationEventResultDescriptor,
        Entities.NHibernate.ApplicationEventResultDescriptorAggregate.TPDM.ApplicationEventResultDescriptor,
        Api.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorPut,
        Api.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorPost,
        Api.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorDelete,
        Api.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorGetByExample>
    {
        public ApplicationEventResultDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorGetByExample request, Entities.Common.TPDM.IApplicationEventResultDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationEventResultDescriptorId = request.ApplicationEventResultDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicationEventResultDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicationEventTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor,
        Models.Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor,
        Entities.Common.TPDM.IApplicationEventTypeDescriptor,
        Entities.NHibernate.ApplicationEventTypeDescriptorAggregate.TPDM.ApplicationEventTypeDescriptor,
        Api.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorPut,
        Api.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorPost,
        Api.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorDelete,
        Api.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorGetByExample>
    {
        public ApplicationEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IApplicationEventTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationEventTypeDescriptorId = request.ApplicationEventTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicationEventTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationSourceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicationSourceDescriptorsController : EdFiControllerBase<
        Models.Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor,
        Models.Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor,
        Entities.Common.TPDM.IApplicationSourceDescriptor,
        Entities.NHibernate.ApplicationSourceDescriptorAggregate.TPDM.ApplicationSourceDescriptor,
        Api.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorPut,
        Api.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorPost,
        Api.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorDelete,
        Api.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorGetByExample>
    {
        public ApplicationSourceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorGetByExample request, Entities.Common.TPDM.IApplicationSourceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationSourceDescriptorId = request.ApplicationSourceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicationSourceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ApplicationStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor,
        Models.Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor,
        Entities.Common.TPDM.IApplicationStatusDescriptor,
        Entities.NHibernate.ApplicationStatusDescriptorAggregate.TPDM.ApplicationStatusDescriptor,
        Api.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorPut,
        Api.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorPost,
        Api.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorDelete,
        Api.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorGetByExample>
    {
        public ApplicationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorGetByExample request, Entities.Common.TPDM.IApplicationStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationStatusDescriptorId = request.ApplicationStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "applicationStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.BackgroundCheckStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BackgroundCheckStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor,
        Models.Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor,
        Entities.Common.TPDM.IBackgroundCheckStatusDescriptor,
        Entities.NHibernate.BackgroundCheckStatusDescriptorAggregate.TPDM.BackgroundCheckStatusDescriptor,
        Api.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorPut,
        Api.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorPost,
        Api.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorDelete,
        Api.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorGetByExample>
    {
        public BackgroundCheckStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorGetByExample request, Entities.Common.TPDM.IBackgroundCheckStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BackgroundCheckStatusDescriptorId = request.BackgroundCheckStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "backgroundCheckStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.BackgroundCheckTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BackgroundCheckTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor,
        Models.Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor,
        Entities.Common.TPDM.IBackgroundCheckTypeDescriptor,
        Entities.NHibernate.BackgroundCheckTypeDescriptorAggregate.TPDM.BackgroundCheckTypeDescriptor,
        Api.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorPut,
        Api.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorPost,
        Api.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorDelete,
        Api.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorGetByExample>
    {
        public BackgroundCheckTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorGetByExample request, Entities.Common.TPDM.IBackgroundCheckTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BackgroundCheckTypeDescriptorId = request.BackgroundCheckTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "backgroundCheckTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.BoardCertificationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BoardCertificationTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.BoardCertificationTypeDescriptor.TPDM.BoardCertificationTypeDescriptor,
        Models.Resources.BoardCertificationTypeDescriptor.TPDM.BoardCertificationTypeDescriptor,
        Entities.Common.TPDM.IBoardCertificationTypeDescriptor,
        Entities.NHibernate.BoardCertificationTypeDescriptorAggregate.TPDM.BoardCertificationTypeDescriptor,
        Api.Models.Requests.TPDM.BoardCertificationTypeDescriptors.BoardCertificationTypeDescriptorPut,
        Api.Models.Requests.TPDM.BoardCertificationTypeDescriptors.BoardCertificationTypeDescriptorPost,
        Api.Models.Requests.TPDM.BoardCertificationTypeDescriptors.BoardCertificationTypeDescriptorDelete,
        Api.Models.Requests.TPDM.BoardCertificationTypeDescriptors.BoardCertificationTypeDescriptorGetByExample>
    {
        public BoardCertificationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.BoardCertificationTypeDescriptors.BoardCertificationTypeDescriptorGetByExample request, Entities.Common.TPDM.IBoardCertificationTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BoardCertificationTypeDescriptorId = request.BoardCertificationTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "boardCertificationTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExamStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationExamStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor,
        Models.Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor,
        Entities.Common.TPDM.ICertificationExamStatusDescriptor,
        Entities.NHibernate.CertificationExamStatusDescriptorAggregate.TPDM.CertificationExamStatusDescriptor,
        Api.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorPut,
        Api.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorPost,
        Api.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorDelete,
        Api.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorGetByExample>
    {
        public CertificationExamStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorGetByExample request, Entities.Common.TPDM.ICertificationExamStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationExamStatusDescriptorId = request.CertificationExamStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationExamStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExamTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationExamTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor,
        Models.Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor,
        Entities.Common.TPDM.ICertificationExamTypeDescriptor,
        Entities.NHibernate.CertificationExamTypeDescriptorAggregate.TPDM.CertificationExamTypeDescriptor,
        Api.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorPut,
        Api.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorPost,
        Api.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorDelete,
        Api.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorGetByExample>
    {
        public CertificationExamTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorGetByExample request, Entities.Common.TPDM.ICertificationExamTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationExamTypeDescriptorId = request.CertificationExamTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationExamTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CompleterAsStaffAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CompleterAsStaffAssociationsController : EdFiControllerBase<
        Models.Resources.CompleterAsStaffAssociation.TPDM.CompleterAsStaffAssociation,
        Models.Resources.CompleterAsStaffAssociation.TPDM.CompleterAsStaffAssociation,
        Entities.Common.TPDM.ICompleterAsStaffAssociation,
        Entities.NHibernate.CompleterAsStaffAssociationAggregate.TPDM.CompleterAsStaffAssociation,
        Api.Models.Requests.TPDM.CompleterAsStaffAssociations.CompleterAsStaffAssociationPut,
        Api.Models.Requests.TPDM.CompleterAsStaffAssociations.CompleterAsStaffAssociationPost,
        Api.Models.Requests.TPDM.CompleterAsStaffAssociations.CompleterAsStaffAssociationDelete,
        Api.Models.Requests.TPDM.CompleterAsStaffAssociations.CompleterAsStaffAssociationGetByExample>
    {
        public CompleterAsStaffAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CompleterAsStaffAssociations.CompleterAsStaffAssociationGetByExample request, Entities.Common.TPDM.ICompleterAsStaffAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "completerAsStaffAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CoteachingStyleObservedDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CoteachingStyleObservedDescriptorsController : EdFiControllerBase<
        Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor,
        Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor,
        Entities.Common.TPDM.ICoteachingStyleObservedDescriptor,
        Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.TPDM.CoteachingStyleObservedDescriptor,
        Api.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPut,
        Api.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPost,
        Api.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorDelete,
        Api.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample>
    {
        public CoteachingStyleObservedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample request, Entities.Common.TPDM.ICoteachingStyleObservedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CoteachingStyleObservedDescriptorId = request.CoteachingStyleObservedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "coteachingStyleObservedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CourseCourseTranscriptFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseCourseTranscriptFactsController : EdFiControllerBase<
        Models.Resources.CourseCourseTranscriptFacts.TPDM.CourseCourseTranscriptFacts,
        Models.Resources.CourseCourseTranscriptFacts.TPDM.CourseCourseTranscriptFacts,
        Entities.Common.TPDM.ICourseCourseTranscriptFacts,
        Entities.NHibernate.CourseCourseTranscriptFactsAggregate.TPDM.CourseCourseTranscriptFacts,
        Api.Models.Requests.TPDM.CourseCourseTranscriptFacts.CourseCourseTranscriptFactsPut,
        Api.Models.Requests.TPDM.CourseCourseTranscriptFacts.CourseCourseTranscriptFactsPost,
        Api.Models.Requests.TPDM.CourseCourseTranscriptFacts.CourseCourseTranscriptFactsDelete,
        Api.Models.Requests.TPDM.CourseCourseTranscriptFacts.CourseCourseTranscriptFactsGetByExample>
    {
        public CourseCourseTranscriptFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CourseCourseTranscriptFacts.CourseCourseTranscriptFactsGetByExample request, Entities.Common.TPDM.ICourseCourseTranscriptFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseCode = request.CourseCode;
            specification.CourseTitle = request.CourseTitle;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseCourseTranscriptFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CourseStudentAcademicRecordFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseStudentAcademicRecordFactsController : EdFiControllerBase<
        Models.Resources.CourseStudentAcademicRecordFacts.TPDM.CourseStudentAcademicRecordFacts,
        Models.Resources.CourseStudentAcademicRecordFacts.TPDM.CourseStudentAcademicRecordFacts,
        Entities.Common.TPDM.ICourseStudentAcademicRecordFacts,
        Entities.NHibernate.CourseStudentAcademicRecordFactsAggregate.TPDM.CourseStudentAcademicRecordFacts,
        Api.Models.Requests.TPDM.CourseStudentAcademicRecordFacts.CourseStudentAcademicRecordFactsPut,
        Api.Models.Requests.TPDM.CourseStudentAcademicRecordFacts.CourseStudentAcademicRecordFactsPost,
        Api.Models.Requests.TPDM.CourseStudentAcademicRecordFacts.CourseStudentAcademicRecordFactsDelete,
        Api.Models.Requests.TPDM.CourseStudentAcademicRecordFacts.CourseStudentAcademicRecordFactsGetByExample>
    {
        public CourseStudentAcademicRecordFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CourseStudentAcademicRecordFacts.CourseStudentAcademicRecordFactsGetByExample request, Entities.Common.TPDM.ICourseStudentAcademicRecordFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AggregatedGPAMax = request.AggregatedGPAMax;
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseStudentAcademicRecordFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CourseStudentAssessmentFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseStudentAssessmentFactsController : EdFiControllerBase<
        Models.Resources.CourseStudentAssessmentFacts.TPDM.CourseStudentAssessmentFacts,
        Models.Resources.CourseStudentAssessmentFacts.TPDM.CourseStudentAssessmentFacts,
        Entities.Common.TPDM.ICourseStudentAssessmentFacts,
        Entities.NHibernate.CourseStudentAssessmentFactsAggregate.TPDM.CourseStudentAssessmentFacts,
        Api.Models.Requests.TPDM.CourseStudentAssessmentFacts.CourseStudentAssessmentFactsPut,
        Api.Models.Requests.TPDM.CourseStudentAssessmentFacts.CourseStudentAssessmentFactsPost,
        Api.Models.Requests.TPDM.CourseStudentAssessmentFacts.CourseStudentAssessmentFactsDelete,
        Api.Models.Requests.TPDM.CourseStudentAssessmentFacts.CourseStudentAssessmentFactsGetByExample>
    {
        public CourseStudentAssessmentFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CourseStudentAssessmentFacts.CourseStudentAssessmentFactsGetByExample request, Entities.Common.TPDM.ICourseStudentAssessmentFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AdministrationDate = request.AdministrationDate;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.GradeLevelDescriptor = request.GradeLevelDescriptor;
            specification.Id = request.Id;
            specification.TakenSchoolYear = request.TakenSchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseStudentAssessmentFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CourseStudentFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseStudentFactsController : EdFiControllerBase<
        Models.Resources.CourseStudentFacts.TPDM.CourseStudentFacts,
        Models.Resources.CourseStudentFacts.TPDM.CourseStudentFacts,
        Entities.Common.TPDM.ICourseStudentFacts,
        Entities.NHibernate.CourseStudentFactsAggregate.TPDM.CourseStudentFacts,
        Api.Models.Requests.TPDM.CourseStudentFacts.CourseStudentFactsPut,
        Api.Models.Requests.TPDM.CourseStudentFacts.CourseStudentFactsPost,
        Api.Models.Requests.TPDM.CourseStudentFacts.CourseStudentFactsDelete,
        Api.Models.Requests.TPDM.CourseStudentFacts.CourseStudentFactsGetByExample>
    {
        public CourseStudentFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CourseStudentFacts.CourseStudentFactsGetByExample request, Entities.Common.TPDM.ICourseStudentFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseStudentFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducationOrganizationCourseTranscriptFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationCourseTranscriptFactsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationCourseTranscriptFacts.TPDM.EducationOrganizationCourseTranscriptFacts,
        Models.Resources.EducationOrganizationCourseTranscriptFacts.TPDM.EducationOrganizationCourseTranscriptFacts,
        Entities.Common.TPDM.IEducationOrganizationCourseTranscriptFacts,
        Entities.NHibernate.EducationOrganizationCourseTranscriptFactsAggregate.TPDM.EducationOrganizationCourseTranscriptFacts,
        Api.Models.Requests.TPDM.EducationOrganizationCourseTranscriptFacts.EducationOrganizationCourseTranscriptFactsPut,
        Api.Models.Requests.TPDM.EducationOrganizationCourseTranscriptFacts.EducationOrganizationCourseTranscriptFactsPost,
        Api.Models.Requests.TPDM.EducationOrganizationCourseTranscriptFacts.EducationOrganizationCourseTranscriptFactsDelete,
        Api.Models.Requests.TPDM.EducationOrganizationCourseTranscriptFacts.EducationOrganizationCourseTranscriptFactsGetByExample>
    {
        public EducationOrganizationCourseTranscriptFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EducationOrganizationCourseTranscriptFacts.EducationOrganizationCourseTranscriptFactsGetByExample request, Entities.Common.TPDM.IEducationOrganizationCourseTranscriptFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseTitle = request.CourseTitle;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationCourseTranscriptFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducationOrganizationFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationFactsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationFacts.TPDM.EducationOrganizationFacts,
        Models.Resources.EducationOrganizationFacts.TPDM.EducationOrganizationFacts,
        Entities.Common.TPDM.IEducationOrganizationFacts,
        Entities.NHibernate.EducationOrganizationFactsAggregate.TPDM.EducationOrganizationFacts,
        Api.Models.Requests.TPDM.EducationOrganizationFacts.EducationOrganizationFactsPut,
        Api.Models.Requests.TPDM.EducationOrganizationFacts.EducationOrganizationFactsPost,
        Api.Models.Requests.TPDM.EducationOrganizationFacts.EducationOrganizationFactsDelete,
        Api.Models.Requests.TPDM.EducationOrganizationFacts.EducationOrganizationFactsGetByExample>
    {
        public EducationOrganizationFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EducationOrganizationFacts.EducationOrganizationFactsGetByExample request, Entities.Common.TPDM.IEducationOrganizationFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AverageYearsInDistrictEmployed = request.AverageYearsInDistrictEmployed;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.HiringRate = request.HiringRate;
            specification.Id = request.Id;
            specification.NumberAdministratorsEmployed = request.NumberAdministratorsEmployed;
            specification.NumberStudentsEnrolled = request.NumberStudentsEnrolled;
            specification.NumberTeachersEmployed = request.NumberTeachersEmployed;
            specification.PercentStudentsFreeReducedLunch = request.PercentStudentsFreeReducedLunch;
            specification.PercentStudentsLimitedEnglishProficiency = request.PercentStudentsLimitedEnglishProficiency;
            specification.PercentStudentsSpecialEducation = request.PercentStudentsSpecialEducation;
            specification.RetentionRate = request.RetentionRate;
            specification.RetirementRate = request.RetirementRate;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducationOrganizationStudentAcademicRecordFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationStudentAcademicRecordFactsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationStudentAcademicRecordFacts.TPDM.EducationOrganizationStudentAcademicRecordFacts,
        Models.Resources.EducationOrganizationStudentAcademicRecordFacts.TPDM.EducationOrganizationStudentAcademicRecordFacts,
        Entities.Common.TPDM.IEducationOrganizationStudentAcademicRecordFacts,
        Entities.NHibernate.EducationOrganizationStudentAcademicRecordFactsAggregate.TPDM.EducationOrganizationStudentAcademicRecordFacts,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAcademicRecordFacts.EducationOrganizationStudentAcademicRecordFactsPut,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAcademicRecordFacts.EducationOrganizationStudentAcademicRecordFactsPost,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAcademicRecordFacts.EducationOrganizationStudentAcademicRecordFactsDelete,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAcademicRecordFacts.EducationOrganizationStudentAcademicRecordFactsGetByExample>
    {
        public EducationOrganizationStudentAcademicRecordFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EducationOrganizationStudentAcademicRecordFacts.EducationOrganizationStudentAcademicRecordFactsGetByExample request, Entities.Common.TPDM.IEducationOrganizationStudentAcademicRecordFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AggregatedGPAMax = request.AggregatedGPAMax;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationStudentAcademicRecordFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducationOrganizationStudentAssessmentFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationStudentAssessmentFactsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationStudentAssessmentFacts.TPDM.EducationOrganizationStudentAssessmentFacts,
        Models.Resources.EducationOrganizationStudentAssessmentFacts.TPDM.EducationOrganizationStudentAssessmentFacts,
        Entities.Common.TPDM.IEducationOrganizationStudentAssessmentFacts,
        Entities.NHibernate.EducationOrganizationStudentAssessmentFactsAggregate.TPDM.EducationOrganizationStudentAssessmentFacts,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAssessmentFacts.EducationOrganizationStudentAssessmentFactsPut,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAssessmentFacts.EducationOrganizationStudentAssessmentFactsPost,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAssessmentFacts.EducationOrganizationStudentAssessmentFactsDelete,
        Api.Models.Requests.TPDM.EducationOrganizationStudentAssessmentFacts.EducationOrganizationStudentAssessmentFactsGetByExample>
    {
        public EducationOrganizationStudentAssessmentFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EducationOrganizationStudentAssessmentFacts.EducationOrganizationStudentAssessmentFactsGetByExample request, Entities.Common.TPDM.IEducationOrganizationStudentAssessmentFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AdministrationDate = request.AdministrationDate;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.GradeLevelDescriptor = request.GradeLevelDescriptor;
            specification.Id = request.Id;
            specification.TakenSchoolYear = request.TakenSchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationStudentAssessmentFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducationOrganizationStudentFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationStudentFactsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationStudentFacts.TPDM.EducationOrganizationStudentFacts,
        Models.Resources.EducationOrganizationStudentFacts.TPDM.EducationOrganizationStudentFacts,
        Entities.Common.TPDM.IEducationOrganizationStudentFacts,
        Entities.NHibernate.EducationOrganizationStudentFactsAggregate.TPDM.EducationOrganizationStudentFacts,
        Api.Models.Requests.TPDM.EducationOrganizationStudentFacts.EducationOrganizationStudentFactsPut,
        Api.Models.Requests.TPDM.EducationOrganizationStudentFacts.EducationOrganizationStudentFactsPost,
        Api.Models.Requests.TPDM.EducationOrganizationStudentFacts.EducationOrganizationStudentFactsDelete,
        Api.Models.Requests.TPDM.EducationOrganizationStudentFacts.EducationOrganizationStudentFactsGetByExample>
    {
        public EducationOrganizationStudentFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EducationOrganizationStudentFacts.EducationOrganizationStudentFactsGetByExample request, Entities.Common.TPDM.IEducationOrganizationStudentFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationStudentFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EmploymentEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EmploymentEventsController : EdFiControllerBase<
        Models.Resources.EmploymentEvent.TPDM.EmploymentEvent,
        Models.Resources.EmploymentEvent.TPDM.EmploymentEvent,
        Entities.Common.TPDM.IEmploymentEvent,
        Entities.NHibernate.EmploymentEventAggregate.TPDM.EmploymentEvent,
        Api.Models.Requests.TPDM.EmploymentEvents.EmploymentEventPut,
        Api.Models.Requests.TPDM.EmploymentEvents.EmploymentEventPost,
        Api.Models.Requests.TPDM.EmploymentEvents.EmploymentEventDelete,
        Api.Models.Requests.TPDM.EmploymentEvents.EmploymentEventGetByExample>
    {
        public EmploymentEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EmploymentEvents.EmploymentEventGetByExample request, Entities.Common.TPDM.IEmploymentEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EarlyHire = request.EarlyHire;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmploymentEventTypeDescriptor = request.EmploymentEventTypeDescriptor;
            specification.HireDate = request.HireDate;
            specification.Id = request.Id;
            specification.InternalExternalHireDescriptor = request.InternalExternalHireDescriptor;
            specification.MutualConsent = request.MutualConsent;
            specification.RequisitionNumber = request.RequisitionNumber;
            specification.RestrictedChoice = request.RestrictedChoice;
                    }

        protected override string GetResourceCollectionName()
        {
            return "employmentEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EmploymentEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EmploymentEventTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.EmploymentEventTypeDescriptor.TPDM.EmploymentEventTypeDescriptor,
        Models.Resources.EmploymentEventTypeDescriptor.TPDM.EmploymentEventTypeDescriptor,
        Entities.Common.TPDM.IEmploymentEventTypeDescriptor,
        Entities.NHibernate.EmploymentEventTypeDescriptorAggregate.TPDM.EmploymentEventTypeDescriptor,
        Api.Models.Requests.TPDM.EmploymentEventTypeDescriptors.EmploymentEventTypeDescriptorPut,
        Api.Models.Requests.TPDM.EmploymentEventTypeDescriptors.EmploymentEventTypeDescriptorPost,
        Api.Models.Requests.TPDM.EmploymentEventTypeDescriptors.EmploymentEventTypeDescriptorDelete,
        Api.Models.Requests.TPDM.EmploymentEventTypeDescriptors.EmploymentEventTypeDescriptorGetByExample>
    {
        public EmploymentEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EmploymentEventTypeDescriptors.EmploymentEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IEmploymentEventTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EmploymentEventTypeDescriptorId = request.EmploymentEventTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "employmentEventTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EmploymentSeparationEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EmploymentSeparationEventsController : EdFiControllerBase<
        Models.Resources.EmploymentSeparationEvent.TPDM.EmploymentSeparationEvent,
        Models.Resources.EmploymentSeparationEvent.TPDM.EmploymentSeparationEvent,
        Entities.Common.TPDM.IEmploymentSeparationEvent,
        Entities.NHibernate.EmploymentSeparationEventAggregate.TPDM.EmploymentSeparationEvent,
        Api.Models.Requests.TPDM.EmploymentSeparationEvents.EmploymentSeparationEventPut,
        Api.Models.Requests.TPDM.EmploymentSeparationEvents.EmploymentSeparationEventPost,
        Api.Models.Requests.TPDM.EmploymentSeparationEvents.EmploymentSeparationEventDelete,
        Api.Models.Requests.TPDM.EmploymentSeparationEvents.EmploymentSeparationEventGetByExample>
    {
        public EmploymentSeparationEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EmploymentSeparationEvents.EmploymentSeparationEventGetByExample request, Entities.Common.TPDM.IEmploymentSeparationEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmploymentSeparationDate = request.EmploymentSeparationDate;
            specification.EmploymentSeparationEnteredDate = request.EmploymentSeparationEnteredDate;
            specification.EmploymentSeparationReasonDescriptor = request.EmploymentSeparationReasonDescriptor;
            specification.EmploymentSeparationTypeDescriptor = request.EmploymentSeparationTypeDescriptor;
            specification.Id = request.Id;
            specification.RemainingInDistrict = request.RemainingInDistrict;
            specification.RequisitionNumber = request.RequisitionNumber;
                    }

        protected override string GetResourceCollectionName()
        {
            return "employmentSeparationEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EmploymentSeparationReasonDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EmploymentSeparationReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.EmploymentSeparationReasonDescriptor.TPDM.EmploymentSeparationReasonDescriptor,
        Models.Resources.EmploymentSeparationReasonDescriptor.TPDM.EmploymentSeparationReasonDescriptor,
        Entities.Common.TPDM.IEmploymentSeparationReasonDescriptor,
        Entities.NHibernate.EmploymentSeparationReasonDescriptorAggregate.TPDM.EmploymentSeparationReasonDescriptor,
        Api.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors.EmploymentSeparationReasonDescriptorPut,
        Api.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors.EmploymentSeparationReasonDescriptorPost,
        Api.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors.EmploymentSeparationReasonDescriptorDelete,
        Api.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors.EmploymentSeparationReasonDescriptorGetByExample>
    {
        public EmploymentSeparationReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EmploymentSeparationReasonDescriptors.EmploymentSeparationReasonDescriptorGetByExample request, Entities.Common.TPDM.IEmploymentSeparationReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EmploymentSeparationReasonDescriptorId = request.EmploymentSeparationReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "employmentSeparationReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EmploymentSeparationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EmploymentSeparationTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.EmploymentSeparationTypeDescriptor.TPDM.EmploymentSeparationTypeDescriptor,
        Models.Resources.EmploymentSeparationTypeDescriptor.TPDM.EmploymentSeparationTypeDescriptor,
        Entities.Common.TPDM.IEmploymentSeparationTypeDescriptor,
        Entities.NHibernate.EmploymentSeparationTypeDescriptorAggregate.TPDM.EmploymentSeparationTypeDescriptor,
        Api.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors.EmploymentSeparationTypeDescriptorPut,
        Api.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors.EmploymentSeparationTypeDescriptorPost,
        Api.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors.EmploymentSeparationTypeDescriptorDelete,
        Api.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors.EmploymentSeparationTypeDescriptorGetByExample>
    {
        public EmploymentSeparationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EmploymentSeparationTypeDescriptors.EmploymentSeparationTypeDescriptorGetByExample request, Entities.Common.TPDM.IEmploymentSeparationTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EmploymentSeparationTypeDescriptorId = request.EmploymentSeparationTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "employmentSeparationTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EnglishLanguageExamDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EnglishLanguageExamDescriptorsController : EdFiControllerBase<
        Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor,
        Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor,
        Entities.Common.TPDM.IEnglishLanguageExamDescriptor,
        Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.TPDM.EnglishLanguageExamDescriptor,
        Api.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPut,
        Api.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPost,
        Api.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorDelete,
        Api.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample>
    {
        public EnglishLanguageExamDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample request, Entities.Common.TPDM.IEnglishLanguageExamDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EnglishLanguageExamDescriptorId = request.EnglishLanguageExamDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "englishLanguageExamDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FederalLocaleCodeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FederalLocaleCodeDescriptorsController : EdFiControllerBase<
        Models.Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor,
        Models.Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor,
        Entities.Common.TPDM.IFederalLocaleCodeDescriptor,
        Entities.NHibernate.FederalLocaleCodeDescriptorAggregate.TPDM.FederalLocaleCodeDescriptor,
        Api.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorPut,
        Api.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorPost,
        Api.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorDelete,
        Api.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorGetByExample>
    {
        public FederalLocaleCodeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorGetByExample request, Entities.Common.TPDM.IFederalLocaleCodeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FederalLocaleCodeDescriptorId = request.FederalLocaleCodeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "federalLocaleCodeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FieldworkTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FieldworkTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor,
        Models.Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor,
        Entities.Common.TPDM.IFieldworkTypeDescriptor,
        Entities.NHibernate.FieldworkTypeDescriptorAggregate.TPDM.FieldworkTypeDescriptor,
        Api.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorPut,
        Api.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorPost,
        Api.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorDelete,
        Api.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorGetByExample>
    {
        public FieldworkTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorGetByExample request, Entities.Common.TPDM.IFieldworkTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FieldworkTypeDescriptorId = request.FieldworkTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "fieldworkTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FundingSourceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FundingSourceDescriptorsController : EdFiControllerBase<
        Models.Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor,
        Models.Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor,
        Entities.Common.TPDM.IFundingSourceDescriptor,
        Entities.NHibernate.FundingSourceDescriptorAggregate.TPDM.FundingSourceDescriptor,
        Api.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorPut,
        Api.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorPost,
        Api.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorDelete,
        Api.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorGetByExample>
    {
        public FundingSourceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorGetByExample request, Entities.Common.TPDM.IFundingSourceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FundingSourceDescriptorId = request.FundingSourceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "fundingSourceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.GenderDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GenderDescriptorsController : EdFiControllerBase<
        Models.Resources.GenderDescriptor.TPDM.GenderDescriptor,
        Models.Resources.GenderDescriptor.TPDM.GenderDescriptor,
        Entities.Common.TPDM.IGenderDescriptor,
        Entities.NHibernate.GenderDescriptorAggregate.TPDM.GenderDescriptor,
        Api.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorPut,
        Api.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorPost,
        Api.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorDelete,
        Api.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorGetByExample>
    {
        public GenderDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorGetByExample request, Entities.Common.TPDM.IGenderDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GenderDescriptorId = request.GenderDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "genderDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.HireStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class HireStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor,
        Models.Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor,
        Entities.Common.TPDM.IHireStatusDescriptor,
        Entities.NHibernate.HireStatusDescriptorAggregate.TPDM.HireStatusDescriptor,
        Api.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorPut,
        Api.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorPost,
        Api.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorDelete,
        Api.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorGetByExample>
    {
        public HireStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorGetByExample request, Entities.Common.TPDM.IHireStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HireStatusDescriptorId = request.HireStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "hireStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.HiringSourceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class HiringSourceDescriptorsController : EdFiControllerBase<
        Models.Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor,
        Models.Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor,
        Entities.Common.TPDM.IHiringSourceDescriptor,
        Entities.NHibernate.HiringSourceDescriptorAggregate.TPDM.HiringSourceDescriptor,
        Api.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorPut,
        Api.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorPost,
        Api.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorDelete,
        Api.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorGetByExample>
    {
        public HiringSourceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorGetByExample request, Entities.Common.TPDM.IHiringSourceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HiringSourceDescriptorId = request.HiringSourceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "hiringSourceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.InternalExternalHireDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InternalExternalHireDescriptorsController : EdFiControllerBase<
        Models.Resources.InternalExternalHireDescriptor.TPDM.InternalExternalHireDescriptor,
        Models.Resources.InternalExternalHireDescriptor.TPDM.InternalExternalHireDescriptor,
        Entities.Common.TPDM.IInternalExternalHireDescriptor,
        Entities.NHibernate.InternalExternalHireDescriptorAggregate.TPDM.InternalExternalHireDescriptor,
        Api.Models.Requests.TPDM.InternalExternalHireDescriptors.InternalExternalHireDescriptorPut,
        Api.Models.Requests.TPDM.InternalExternalHireDescriptors.InternalExternalHireDescriptorPost,
        Api.Models.Requests.TPDM.InternalExternalHireDescriptors.InternalExternalHireDescriptorDelete,
        Api.Models.Requests.TPDM.InternalExternalHireDescriptors.InternalExternalHireDescriptorGetByExample>
    {
        public InternalExternalHireDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.InternalExternalHireDescriptors.InternalExternalHireDescriptorGetByExample request, Entities.Common.TPDM.IInternalExternalHireDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InternalExternalHireDescriptorId = request.InternalExternalHireDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "internalExternalHireDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.LevelOfDegreeAwardedDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LevelOfDegreeAwardedDescriptorsController : EdFiControllerBase<
        Models.Resources.LevelOfDegreeAwardedDescriptor.TPDM.LevelOfDegreeAwardedDescriptor,
        Models.Resources.LevelOfDegreeAwardedDescriptor.TPDM.LevelOfDegreeAwardedDescriptor,
        Entities.Common.TPDM.ILevelOfDegreeAwardedDescriptor,
        Entities.NHibernate.LevelOfDegreeAwardedDescriptorAggregate.TPDM.LevelOfDegreeAwardedDescriptor,
        Api.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors.LevelOfDegreeAwardedDescriptorPut,
        Api.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors.LevelOfDegreeAwardedDescriptorPost,
        Api.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors.LevelOfDegreeAwardedDescriptorDelete,
        Api.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors.LevelOfDegreeAwardedDescriptorGetByExample>
    {
        public LevelOfDegreeAwardedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.LevelOfDegreeAwardedDescriptors.LevelOfDegreeAwardedDescriptorGetByExample request, Entities.Common.TPDM.ILevelOfDegreeAwardedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LevelOfDegreeAwardedDescriptorId = request.LevelOfDegreeAwardedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "levelOfDegreeAwardedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.LevelTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LevelTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.LevelTypeDescriptor.TPDM.LevelTypeDescriptor,
        Models.Resources.LevelTypeDescriptor.TPDM.LevelTypeDescriptor,
        Entities.Common.TPDM.ILevelTypeDescriptor,
        Entities.NHibernate.LevelTypeDescriptorAggregate.TPDM.LevelTypeDescriptor,
        Api.Models.Requests.TPDM.LevelTypeDescriptors.LevelTypeDescriptorPut,
        Api.Models.Requests.TPDM.LevelTypeDescriptors.LevelTypeDescriptorPost,
        Api.Models.Requests.TPDM.LevelTypeDescriptors.LevelTypeDescriptorDelete,
        Api.Models.Requests.TPDM.LevelTypeDescriptors.LevelTypeDescriptorGetByExample>
    {
        public LevelTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.LevelTypeDescriptors.LevelTypeDescriptorGetByExample request, Entities.Common.TPDM.ILevelTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LevelTypeDescriptorId = request.LevelTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "levelTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OpenStaffPositionEventsController : EdFiControllerBase<
        Models.Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent,
        Models.Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent,
        Entities.Common.TPDM.IOpenStaffPositionEvent,
        Entities.NHibernate.OpenStaffPositionEventAggregate.TPDM.OpenStaffPositionEvent,
        Api.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventPut,
        Api.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventPost,
        Api.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventDelete,
        Api.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventGetByExample>
    {
        public OpenStaffPositionEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventGetByExample request, Entities.Common.TPDM.IOpenStaffPositionEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EventDate = request.EventDate;
            specification.Id = request.Id;
            specification.OpenStaffPositionEventStatusDescriptor = request.OpenStaffPositionEventStatusDescriptor;
            specification.OpenStaffPositionEventTypeDescriptor = request.OpenStaffPositionEventTypeDescriptor;
            specification.RequisitionNumber = request.RequisitionNumber;
                    }

        protected override string GetResourceCollectionName()
        {
            return "openStaffPositionEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionEventStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OpenStaffPositionEventStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor,
        Models.Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor,
        Entities.Common.TPDM.IOpenStaffPositionEventStatusDescriptor,
        Entities.NHibernate.OpenStaffPositionEventStatusDescriptorAggregate.TPDM.OpenStaffPositionEventStatusDescriptor,
        Api.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorPut,
        Api.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorPost,
        Api.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorDelete,
        Api.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorGetByExample>
    {
        public OpenStaffPositionEventStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorGetByExample request, Entities.Common.TPDM.IOpenStaffPositionEventStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OpenStaffPositionEventStatusDescriptorId = request.OpenStaffPositionEventStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "openStaffPositionEventStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OpenStaffPositionEventTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor,
        Models.Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor,
        Entities.Common.TPDM.IOpenStaffPositionEventTypeDescriptor,
        Entities.NHibernate.OpenStaffPositionEventTypeDescriptorAggregate.TPDM.OpenStaffPositionEventTypeDescriptor,
        Api.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorPut,
        Api.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorPost,
        Api.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorDelete,
        Api.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorGetByExample>
    {
        public OpenStaffPositionEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IOpenStaffPositionEventTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OpenStaffPositionEventTypeDescriptorId = request.OpenStaffPositionEventTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "openStaffPositionEventTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionReasonDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OpenStaffPositionReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor,
        Models.Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor,
        Entities.Common.TPDM.IOpenStaffPositionReasonDescriptor,
        Entities.NHibernate.OpenStaffPositionReasonDescriptorAggregate.TPDM.OpenStaffPositionReasonDescriptor,
        Api.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorPut,
        Api.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorPost,
        Api.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorDelete,
        Api.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorGetByExample>
    {
        public OpenStaffPositionReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorGetByExample request, Entities.Common.TPDM.IOpenStaffPositionReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OpenStaffPositionReasonDescriptorId = request.OpenStaffPositionReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "openStaffPositionReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceMeasures
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceMeasuresController : EdFiControllerBase<
        Models.Resources.PerformanceMeasure.TPDM.PerformanceMeasure,
        Models.Resources.PerformanceMeasure.TPDM.PerformanceMeasure,
        Entities.Common.TPDM.IPerformanceMeasure,
        Entities.NHibernate.PerformanceMeasureAggregate.TPDM.PerformanceMeasure,
        Api.Models.Requests.TPDM.PerformanceMeasures.PerformanceMeasurePut,
        Api.Models.Requests.TPDM.PerformanceMeasures.PerformanceMeasurePost,
        Api.Models.Requests.TPDM.PerformanceMeasures.PerformanceMeasureDelete,
        Api.Models.Requests.TPDM.PerformanceMeasures.PerformanceMeasureGetByExample>
    {
        public PerformanceMeasuresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceMeasures.PerformanceMeasureGetByExample request, Entities.Common.TPDM.IPerformanceMeasure specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.ActualDateOfPerformanceMeasure = request.ActualDateOfPerformanceMeasure;
            specification.Announced = request.Announced;
            specification.Comments = request.Comments;
            specification.CoteachingStyleObservedDescriptor = request.CoteachingStyleObservedDescriptor;
            specification.DurationOfPerformanceMeasure = request.DurationOfPerformanceMeasure;
            specification.Id = request.Id;
            specification.PerformanceMeasureIdentifier = request.PerformanceMeasureIdentifier;
            specification.PerformanceMeasureInstanceDescriptor = request.PerformanceMeasureInstanceDescriptor;
            specification.PerformanceMeasureTypeDescriptor = request.PerformanceMeasureTypeDescriptor;
            specification.ScheduleDateOfPerformanceMeasure = request.ScheduleDateOfPerformanceMeasure;
            specification.TermDescriptor = request.TermDescriptor;
            specification.TimeOfPerformanceMeasure = request.TimeOfPerformanceMeasure;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceMeasures";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceMeasureCourseAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceMeasureCourseAssociationsController : EdFiControllerBase<
        Models.Resources.PerformanceMeasureCourseAssociation.TPDM.PerformanceMeasureCourseAssociation,
        Models.Resources.PerformanceMeasureCourseAssociation.TPDM.PerformanceMeasureCourseAssociation,
        Entities.Common.TPDM.IPerformanceMeasureCourseAssociation,
        Entities.NHibernate.PerformanceMeasureCourseAssociationAggregate.TPDM.PerformanceMeasureCourseAssociation,
        Api.Models.Requests.TPDM.PerformanceMeasureCourseAssociations.PerformanceMeasureCourseAssociationPut,
        Api.Models.Requests.TPDM.PerformanceMeasureCourseAssociations.PerformanceMeasureCourseAssociationPost,
        Api.Models.Requests.TPDM.PerformanceMeasureCourseAssociations.PerformanceMeasureCourseAssociationDelete,
        Api.Models.Requests.TPDM.PerformanceMeasureCourseAssociations.PerformanceMeasureCourseAssociationGetByExample>
    {
        public PerformanceMeasureCourseAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceMeasureCourseAssociations.PerformanceMeasureCourseAssociationGetByExample request, Entities.Common.TPDM.IPerformanceMeasureCourseAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.PerformanceMeasureIdentifier = request.PerformanceMeasureIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceMeasureCourseAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceMeasureFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceMeasureFactsController : EdFiControllerBase<
        Models.Resources.PerformanceMeasureFacts.TPDM.PerformanceMeasureFacts,
        Models.Resources.PerformanceMeasureFacts.TPDM.PerformanceMeasureFacts,
        Entities.Common.TPDM.IPerformanceMeasureFacts,
        Entities.NHibernate.PerformanceMeasureFactsAggregate.TPDM.PerformanceMeasureFacts,
        Api.Models.Requests.TPDM.PerformanceMeasureFacts.PerformanceMeasureFactsPut,
        Api.Models.Requests.TPDM.PerformanceMeasureFacts.PerformanceMeasureFactsPost,
        Api.Models.Requests.TPDM.PerformanceMeasureFacts.PerformanceMeasureFactsDelete,
        Api.Models.Requests.TPDM.PerformanceMeasureFacts.PerformanceMeasureFactsGetByExample>
    {
        public PerformanceMeasureFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceMeasureFacts.PerformanceMeasureFactsGetByExample request, Entities.Common.TPDM.IPerformanceMeasureFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.PerformanceMeasureTypeDescriptor = request.PerformanceMeasureTypeDescriptor;
            specification.RubricTitle = request.RubricTitle;
            specification.RubricTypeDescriptor = request.RubricTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceMeasureFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceMeasureInstanceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceMeasureInstanceDescriptorsController : EdFiControllerBase<
        Models.Resources.PerformanceMeasureInstanceDescriptor.TPDM.PerformanceMeasureInstanceDescriptor,
        Models.Resources.PerformanceMeasureInstanceDescriptor.TPDM.PerformanceMeasureInstanceDescriptor,
        Entities.Common.TPDM.IPerformanceMeasureInstanceDescriptor,
        Entities.NHibernate.PerformanceMeasureInstanceDescriptorAggregate.TPDM.PerformanceMeasureInstanceDescriptor,
        Api.Models.Requests.TPDM.PerformanceMeasureInstanceDescriptors.PerformanceMeasureInstanceDescriptorPut,
        Api.Models.Requests.TPDM.PerformanceMeasureInstanceDescriptors.PerformanceMeasureInstanceDescriptorPost,
        Api.Models.Requests.TPDM.PerformanceMeasureInstanceDescriptors.PerformanceMeasureInstanceDescriptorDelete,
        Api.Models.Requests.TPDM.PerformanceMeasureInstanceDescriptors.PerformanceMeasureInstanceDescriptorGetByExample>
    {
        public PerformanceMeasureInstanceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceMeasureInstanceDescriptors.PerformanceMeasureInstanceDescriptorGetByExample request, Entities.Common.TPDM.IPerformanceMeasureInstanceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceMeasureInstanceDescriptorId = request.PerformanceMeasureInstanceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceMeasureInstanceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceMeasureTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceMeasureTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.PerformanceMeasureTypeDescriptor.TPDM.PerformanceMeasureTypeDescriptor,
        Models.Resources.PerformanceMeasureTypeDescriptor.TPDM.PerformanceMeasureTypeDescriptor,
        Entities.Common.TPDM.IPerformanceMeasureTypeDescriptor,
        Entities.NHibernate.PerformanceMeasureTypeDescriptorAggregate.TPDM.PerformanceMeasureTypeDescriptor,
        Api.Models.Requests.TPDM.PerformanceMeasureTypeDescriptors.PerformanceMeasureTypeDescriptorPut,
        Api.Models.Requests.TPDM.PerformanceMeasureTypeDescriptors.PerformanceMeasureTypeDescriptorPost,
        Api.Models.Requests.TPDM.PerformanceMeasureTypeDescriptors.PerformanceMeasureTypeDescriptorDelete,
        Api.Models.Requests.TPDM.PerformanceMeasureTypeDescriptors.PerformanceMeasureTypeDescriptorGetByExample>
    {
        public PerformanceMeasureTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceMeasureTypeDescriptors.PerformanceMeasureTypeDescriptorGetByExample request, Entities.Common.TPDM.IPerformanceMeasureTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceMeasureTypeDescriptorId = request.PerformanceMeasureTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceMeasureTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PreviousCareerDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PreviousCareerDescriptorsController : EdFiControllerBase<
        Models.Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor,
        Models.Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor,
        Entities.Common.TPDM.IPreviousCareerDescriptor,
        Entities.NHibernate.PreviousCareerDescriptorAggregate.TPDM.PreviousCareerDescriptor,
        Api.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorPut,
        Api.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorPost,
        Api.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorDelete,
        Api.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorGetByExample>
    {
        public PreviousCareerDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorGetByExample request, Entities.Common.TPDM.IPreviousCareerDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PreviousCareerDescriptorId = request.PreviousCareerDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "previousCareerDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProfessionalDevelopmentEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProfessionalDevelopmentEventsController : EdFiControllerBase<
        Models.Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent,
        Models.Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent,
        Entities.Common.TPDM.IProfessionalDevelopmentEvent,
        Entities.NHibernate.ProfessionalDevelopmentEventAggregate.TPDM.ProfessionalDevelopmentEvent,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventPut,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventPost,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventDelete,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventGetByExample>
    {
        public ProfessionalDevelopmentEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventGetByExample request, Entities.Common.TPDM.IProfessionalDevelopmentEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.MultipleSession = request.MultipleSession;
            specification.ProfessionalDevelopmentOfferedByDescriptor = request.ProfessionalDevelopmentOfferedByDescriptor;
            specification.ProfessionalDevelopmentReason = request.ProfessionalDevelopmentReason;
            specification.ProfessionalDevelopmentTitle = request.ProfessionalDevelopmentTitle;
            specification.Required = request.Required;
            specification.TotalHours = request.TotalHours;
                    }

        protected override string GetResourceCollectionName()
        {
            return "professionalDevelopmentEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProfessionalDevelopmentOfferedByDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProfessionalDevelopmentOfferedByDescriptorsController : EdFiControllerBase<
        Models.Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor,
        Models.Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor,
        Entities.Common.TPDM.IProfessionalDevelopmentOfferedByDescriptor,
        Entities.NHibernate.ProfessionalDevelopmentOfferedByDescriptorAggregate.TPDM.ProfessionalDevelopmentOfferedByDescriptor,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorPut,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorPost,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorDelete,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorGetByExample>
    {
        public ProfessionalDevelopmentOfferedByDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorGetByExample request, Entities.Common.TPDM.IProfessionalDevelopmentOfferedByDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProfessionalDevelopmentOfferedByDescriptorId = request.ProfessionalDevelopmentOfferedByDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "professionalDevelopmentOfferedByDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProgramGatewayDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgramGatewayDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor,
        Models.Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor,
        Entities.Common.TPDM.IProgramGatewayDescriptor,
        Entities.NHibernate.ProgramGatewayDescriptorAggregate.TPDM.ProgramGatewayDescriptor,
        Api.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorPut,
        Api.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorPost,
        Api.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorDelete,
        Api.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorGetByExample>
    {
        public ProgramGatewayDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorGetByExample request, Entities.Common.TPDM.IProgramGatewayDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramGatewayDescriptorId = request.ProgramGatewayDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "programGatewayDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Prospects
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProspectsController : EdFiControllerBase<
        Models.Resources.Prospect.TPDM.Prospect,
        Models.Resources.Prospect.TPDM.Prospect,
        Entities.Common.TPDM.IProspect,
        Entities.NHibernate.ProspectAggregate.TPDM.Prospect,
        Api.Models.Requests.TPDM.Prospects.ProspectPut,
        Api.Models.Requests.TPDM.Prospects.ProspectPost,
        Api.Models.Requests.TPDM.Prospects.ProspectDelete,
        Api.Models.Requests.TPDM.Prospects.ProspectGetByExample>
    {
        public ProspectsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Prospects.ProspectGetByExample request, Entities.Common.TPDM.IProspect specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Applied = request.Applied;
            specification.EconomicDisadvantaged = request.EconomicDisadvantaged;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ElectronicMailAddress = request.ElectronicMailAddress;
            specification.FirstGenerationStudent = request.FirstGenerationStudent;
            specification.FirstName = request.FirstName;
            specification.GenderDescriptor = request.GenderDescriptor;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.Met = request.Met;
            specification.MiddleName = request.MiddleName;
            specification.Notes = request.Notes;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PreScreeningRating = request.PreScreeningRating;
            specification.ProspectIdentifier = request.ProspectIdentifier;
            specification.ProspectTypeDescriptor = request.ProspectTypeDescriptor;
            specification.Referral = request.Referral;
            specification.ReferredBy = request.ReferredBy;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SocialMediaNetworkName = request.SocialMediaNetworkName;
            specification.SocialMediaUserName = request.SocialMediaUserName;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "prospects";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProspectProfessionalDevelopmentEventAttendances
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProspectProfessionalDevelopmentEventAttendancesController : EdFiControllerBase<
        Models.Resources.ProspectProfessionalDevelopmentEventAttendance.TPDM.ProspectProfessionalDevelopmentEventAttendance,
        Models.Resources.ProspectProfessionalDevelopmentEventAttendance.TPDM.ProspectProfessionalDevelopmentEventAttendance,
        Entities.Common.TPDM.IProspectProfessionalDevelopmentEventAttendance,
        Entities.NHibernate.ProspectProfessionalDevelopmentEventAttendanceAggregate.TPDM.ProspectProfessionalDevelopmentEventAttendance,
        Api.Models.Requests.TPDM.ProspectProfessionalDevelopmentEventAttendances.ProspectProfessionalDevelopmentEventAttendancePut,
        Api.Models.Requests.TPDM.ProspectProfessionalDevelopmentEventAttendances.ProspectProfessionalDevelopmentEventAttendancePost,
        Api.Models.Requests.TPDM.ProspectProfessionalDevelopmentEventAttendances.ProspectProfessionalDevelopmentEventAttendanceDelete,
        Api.Models.Requests.TPDM.ProspectProfessionalDevelopmentEventAttendances.ProspectProfessionalDevelopmentEventAttendanceGetByExample>
    {
        public ProspectProfessionalDevelopmentEventAttendancesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ProspectProfessionalDevelopmentEventAttendances.ProspectProfessionalDevelopmentEventAttendanceGetByExample request, Entities.Common.TPDM.IProspectProfessionalDevelopmentEventAttendance specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceDate = request.AttendanceDate;
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProfessionalDevelopmentTitle = request.ProfessionalDevelopmentTitle;
            specification.ProspectIdentifier = request.ProspectIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "prospectProfessionalDevelopmentEventAttendances";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProspectTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProspectTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ProspectTypeDescriptor.TPDM.ProspectTypeDescriptor,
        Models.Resources.ProspectTypeDescriptor.TPDM.ProspectTypeDescriptor,
        Entities.Common.TPDM.IProspectTypeDescriptor,
        Entities.NHibernate.ProspectTypeDescriptorAggregate.TPDM.ProspectTypeDescriptor,
        Api.Models.Requests.TPDM.ProspectTypeDescriptors.ProspectTypeDescriptorPut,
        Api.Models.Requests.TPDM.ProspectTypeDescriptors.ProspectTypeDescriptorPost,
        Api.Models.Requests.TPDM.ProspectTypeDescriptors.ProspectTypeDescriptorDelete,
        Api.Models.Requests.TPDM.ProspectTypeDescriptors.ProspectTypeDescriptorGetByExample>
    {
        public ProspectTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ProspectTypeDescriptors.ProspectTypeDescriptorGetByExample request, Entities.Common.TPDM.IProspectTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProspectTypeDescriptorId = request.ProspectTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "prospectTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RecruitmentEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RecruitmentEventsController : EdFiControllerBase<
        Models.Resources.RecruitmentEvent.TPDM.RecruitmentEvent,
        Models.Resources.RecruitmentEvent.TPDM.RecruitmentEvent,
        Entities.Common.TPDM.IRecruitmentEvent,
        Entities.NHibernate.RecruitmentEventAggregate.TPDM.RecruitmentEvent,
        Api.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventPut,
        Api.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventPost,
        Api.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventDelete,
        Api.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventGetByExample>
    {
        public RecruitmentEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventGetByExample request, Entities.Common.TPDM.IRecruitmentEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EventDate = request.EventDate;
            specification.EventDescription = request.EventDescription;
            specification.EventLocation = request.EventLocation;
            specification.EventTitle = request.EventTitle;
            specification.Id = request.Id;
            specification.RecruitmentEventTypeDescriptor = request.RecruitmentEventTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "recruitmentEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RecruitmentEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RecruitmentEventTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor,
        Models.Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor,
        Entities.Common.TPDM.IRecruitmentEventTypeDescriptor,
        Entities.NHibernate.RecruitmentEventTypeDescriptorAggregate.TPDM.RecruitmentEventTypeDescriptor,
        Api.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorPut,
        Api.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorPost,
        Api.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorDelete,
        Api.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorGetByExample>
    {
        public RecruitmentEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IRecruitmentEventTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RecruitmentEventTypeDescriptorId = request.RecruitmentEventTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "recruitmentEventTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Rubrics
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricsController : EdFiControllerBase<
        Models.Resources.Rubric.TPDM.Rubric,
        Models.Resources.Rubric.TPDM.Rubric,
        Entities.Common.TPDM.IRubric,
        Entities.NHibernate.RubricAggregate.TPDM.Rubric,
        Api.Models.Requests.TPDM.Rubrics.RubricPut,
        Api.Models.Requests.TPDM.Rubrics.RubricPost,
        Api.Models.Requests.TPDM.Rubrics.RubricDelete,
        Api.Models.Requests.TPDM.Rubrics.RubricGetByExample>
    {
        public RubricsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Rubrics.RubricGetByExample request, Entities.Common.TPDM.IRubric specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.InterRaterReliabilityScore = request.InterRaterReliabilityScore;
            specification.RubricDescription = request.RubricDescription;
            specification.RubricTitle = request.RubricTitle;
            specification.RubricTypeDescriptor = request.RubricTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubrics";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricLevels
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricLevelsController : EdFiControllerBase<
        Models.Resources.RubricLevel.TPDM.RubricLevel,
        Models.Resources.RubricLevel.TPDM.RubricLevel,
        Entities.Common.TPDM.IRubricLevel,
        Entities.NHibernate.RubricLevelAggregate.TPDM.RubricLevel,
        Api.Models.Requests.TPDM.RubricLevels.RubricLevelPut,
        Api.Models.Requests.TPDM.RubricLevels.RubricLevelPost,
        Api.Models.Requests.TPDM.RubricLevels.RubricLevelDelete,
        Api.Models.Requests.TPDM.RubricLevels.RubricLevelGetByExample>
    {
        public RubricLevelsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RubricLevels.RubricLevelGetByExample request, Entities.Common.TPDM.IRubricLevel specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.RubricLevelCode = request.RubricLevelCode;
            specification.RubricTitle = request.RubricTitle;
            specification.RubricTypeDescriptor = request.RubricTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubricLevels";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricLevelResponses
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricLevelResponsesController : EdFiControllerBase<
        Models.Resources.RubricLevelResponse.TPDM.RubricLevelResponse,
        Models.Resources.RubricLevelResponse.TPDM.RubricLevelResponse,
        Entities.Common.TPDM.IRubricLevelResponse,
        Entities.NHibernate.RubricLevelResponseAggregate.TPDM.RubricLevelResponse,
        Api.Models.Requests.TPDM.RubricLevelResponses.RubricLevelResponsePut,
        Api.Models.Requests.TPDM.RubricLevelResponses.RubricLevelResponsePost,
        Api.Models.Requests.TPDM.RubricLevelResponses.RubricLevelResponseDelete,
        Api.Models.Requests.TPDM.RubricLevelResponses.RubricLevelResponseGetByExample>
    {
        public RubricLevelResponsesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RubricLevelResponses.RubricLevelResponseGetByExample request, Entities.Common.TPDM.IRubricLevelResponse specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AreaOfRefinement = request.AreaOfRefinement;
            specification.AreaOfReinforcement = request.AreaOfReinforcement;
            specification.Comments = request.Comments;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.NumericResponse = request.NumericResponse;
            specification.PerformanceMeasureIdentifier = request.PerformanceMeasureIdentifier;
            specification.RubricLevelCode = request.RubricLevelCode;
            specification.RubricTitle = request.RubricTitle;
            specification.RubricTypeDescriptor = request.RubricTypeDescriptor;
            specification.TextResponse = request.TextResponse;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubricLevelResponses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricLevelResponseFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricLevelResponseFactsController : EdFiControllerBase<
        Models.Resources.RubricLevelResponseFacts.TPDM.RubricLevelResponseFacts,
        Models.Resources.RubricLevelResponseFacts.TPDM.RubricLevelResponseFacts,
        Entities.Common.TPDM.IRubricLevelResponseFacts,
        Entities.NHibernate.RubricLevelResponseFactsAggregate.TPDM.RubricLevelResponseFacts,
        Api.Models.Requests.TPDM.RubricLevelResponseFacts.RubricLevelResponseFactsPut,
        Api.Models.Requests.TPDM.RubricLevelResponseFacts.RubricLevelResponseFactsPost,
        Api.Models.Requests.TPDM.RubricLevelResponseFacts.RubricLevelResponseFactsDelete,
        Api.Models.Requests.TPDM.RubricLevelResponseFacts.RubricLevelResponseFactsGetByExample>
    {
        public RubricLevelResponseFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RubricLevelResponseFacts.RubricLevelResponseFactsGetByExample request, Entities.Common.TPDM.IRubricLevelResponseFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.RubricLevelCode = request.RubricLevelCode;
            specification.RubricTitle = request.RubricTitle;
            specification.RubricTypeDescriptor = request.RubricTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubricLevelResponseFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.RubricTypeDescriptor.TPDM.RubricTypeDescriptor,
        Models.Resources.RubricTypeDescriptor.TPDM.RubricTypeDescriptor,
        Entities.Common.TPDM.IRubricTypeDescriptor,
        Entities.NHibernate.RubricTypeDescriptorAggregate.TPDM.RubricTypeDescriptor,
        Api.Models.Requests.TPDM.RubricTypeDescriptors.RubricTypeDescriptorPut,
        Api.Models.Requests.TPDM.RubricTypeDescriptors.RubricTypeDescriptorPost,
        Api.Models.Requests.TPDM.RubricTypeDescriptors.RubricTypeDescriptorDelete,
        Api.Models.Requests.TPDM.RubricTypeDescriptors.RubricTypeDescriptorGetByExample>
    {
        public RubricTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RubricTypeDescriptors.RubricTypeDescriptorGetByExample request, Entities.Common.TPDM.IRubricTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RubricTypeDescriptorId = request.RubricTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubricTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SalaryTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SalaryTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor,
        Models.Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor,
        Entities.Common.TPDM.ISalaryTypeDescriptor,
        Entities.NHibernate.SalaryTypeDescriptorAggregate.TPDM.SalaryTypeDescriptor,
        Api.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorPut,
        Api.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorPost,
        Api.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorDelete,
        Api.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorGetByExample>
    {
        public SalaryTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorGetByExample request, Entities.Common.TPDM.ISalaryTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SalaryTypeDescriptorId = request.SalaryTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "salaryTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SchoolStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.SchoolStatusDescriptor.TPDM.SchoolStatusDescriptor,
        Models.Resources.SchoolStatusDescriptor.TPDM.SchoolStatusDescriptor,
        Entities.Common.TPDM.ISchoolStatusDescriptor,
        Entities.NHibernate.SchoolStatusDescriptorAggregate.TPDM.SchoolStatusDescriptor,
        Api.Models.Requests.TPDM.SchoolStatusDescriptors.SchoolStatusDescriptorPut,
        Api.Models.Requests.TPDM.SchoolStatusDescriptors.SchoolStatusDescriptorPost,
        Api.Models.Requests.TPDM.SchoolStatusDescriptors.SchoolStatusDescriptorDelete,
        Api.Models.Requests.TPDM.SchoolStatusDescriptors.SchoolStatusDescriptorGetByExample>
    {
        public SchoolStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SchoolStatusDescriptors.SchoolStatusDescriptorGetByExample request, Entities.Common.TPDM.ISchoolStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolStatusDescriptorId = request.SchoolStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schoolStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SectionCourseTranscriptFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionCourseTranscriptFactsController : EdFiControllerBase<
        Models.Resources.SectionCourseTranscriptFacts.TPDM.SectionCourseTranscriptFacts,
        Models.Resources.SectionCourseTranscriptFacts.TPDM.SectionCourseTranscriptFacts,
        Entities.Common.TPDM.ISectionCourseTranscriptFacts,
        Entities.NHibernate.SectionCourseTranscriptFactsAggregate.TPDM.SectionCourseTranscriptFacts,
        Api.Models.Requests.TPDM.SectionCourseTranscriptFacts.SectionCourseTranscriptFactsPut,
        Api.Models.Requests.TPDM.SectionCourseTranscriptFacts.SectionCourseTranscriptFactsPost,
        Api.Models.Requests.TPDM.SectionCourseTranscriptFacts.SectionCourseTranscriptFactsDelete,
        Api.Models.Requests.TPDM.SectionCourseTranscriptFacts.SectionCourseTranscriptFactsGetByExample>
    {
        public SectionCourseTranscriptFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SectionCourseTranscriptFacts.SectionCourseTranscriptFactsGetByExample request, Entities.Common.TPDM.ISectionCourseTranscriptFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseTitle = request.CourseTitle;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.FactsAsOfDate = request.FactsAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sectionCourseTranscriptFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SectionStudentAcademicRecordFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionStudentAcademicRecordFactsController : EdFiControllerBase<
        Models.Resources.SectionStudentAcademicRecordFacts.TPDM.SectionStudentAcademicRecordFacts,
        Models.Resources.SectionStudentAcademicRecordFacts.TPDM.SectionStudentAcademicRecordFacts,
        Entities.Common.TPDM.ISectionStudentAcademicRecordFacts,
        Entities.NHibernate.SectionStudentAcademicRecordFactsAggregate.TPDM.SectionStudentAcademicRecordFacts,
        Api.Models.Requests.TPDM.SectionStudentAcademicRecordFacts.SectionStudentAcademicRecordFactsPut,
        Api.Models.Requests.TPDM.SectionStudentAcademicRecordFacts.SectionStudentAcademicRecordFactsPost,
        Api.Models.Requests.TPDM.SectionStudentAcademicRecordFacts.SectionStudentAcademicRecordFactsDelete,
        Api.Models.Requests.TPDM.SectionStudentAcademicRecordFacts.SectionStudentAcademicRecordFactsGetByExample>
    {
        public SectionStudentAcademicRecordFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SectionStudentAcademicRecordFacts.SectionStudentAcademicRecordFactsGetByExample request, Entities.Common.TPDM.ISectionStudentAcademicRecordFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AggregatedGPAMax = request.AggregatedGPAMax;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sectionStudentAcademicRecordFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SectionStudentAssessmentFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionStudentAssessmentFactsController : EdFiControllerBase<
        Models.Resources.SectionStudentAssessmentFacts.TPDM.SectionStudentAssessmentFacts,
        Models.Resources.SectionStudentAssessmentFacts.TPDM.SectionStudentAssessmentFacts,
        Entities.Common.TPDM.ISectionStudentAssessmentFacts,
        Entities.NHibernate.SectionStudentAssessmentFactsAggregate.TPDM.SectionStudentAssessmentFacts,
        Api.Models.Requests.TPDM.SectionStudentAssessmentFacts.SectionStudentAssessmentFactsPut,
        Api.Models.Requests.TPDM.SectionStudentAssessmentFacts.SectionStudentAssessmentFactsPost,
        Api.Models.Requests.TPDM.SectionStudentAssessmentFacts.SectionStudentAssessmentFactsDelete,
        Api.Models.Requests.TPDM.SectionStudentAssessmentFacts.SectionStudentAssessmentFactsGetByExample>
    {
        public SectionStudentAssessmentFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SectionStudentAssessmentFacts.SectionStudentAssessmentFactsGetByExample request, Entities.Common.TPDM.ISectionStudentAssessmentFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AdministrationDate = request.AdministrationDate;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.GradeLevelDescriptor = request.GradeLevelDescriptor;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.TakenSchoolYear = request.TakenSchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sectionStudentAssessmentFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SectionStudentFacts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionStudentFactsController : EdFiControllerBase<
        Models.Resources.SectionStudentFacts.TPDM.SectionStudentFacts,
        Models.Resources.SectionStudentFacts.TPDM.SectionStudentFacts,
        Entities.Common.TPDM.ISectionStudentFacts,
        Entities.NHibernate.SectionStudentFactsAggregate.TPDM.SectionStudentFacts,
        Api.Models.Requests.TPDM.SectionStudentFacts.SectionStudentFactsPut,
        Api.Models.Requests.TPDM.SectionStudentFacts.SectionStudentFactsPost,
        Api.Models.Requests.TPDM.SectionStudentFacts.SectionStudentFactsDelete,
        Api.Models.Requests.TPDM.SectionStudentFacts.SectionStudentFactsGetByExample>
    {
        public SectionStudentFactsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SectionStudentFacts.SectionStudentFactsGetByExample request, Entities.Common.TPDM.ISectionStudentFacts specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sectionStudentFacts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffApplicantAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffApplicantAssociationsController : EdFiControllerBase<
        Models.Resources.StaffApplicantAssociation.TPDM.StaffApplicantAssociation,
        Models.Resources.StaffApplicantAssociation.TPDM.StaffApplicantAssociation,
        Entities.Common.TPDM.IStaffApplicantAssociation,
        Entities.NHibernate.StaffApplicantAssociationAggregate.TPDM.StaffApplicantAssociation,
        Api.Models.Requests.TPDM.StaffApplicantAssociations.StaffApplicantAssociationPut,
        Api.Models.Requests.TPDM.StaffApplicantAssociations.StaffApplicantAssociationPost,
        Api.Models.Requests.TPDM.StaffApplicantAssociations.StaffApplicantAssociationDelete,
        Api.Models.Requests.TPDM.StaffApplicantAssociations.StaffApplicantAssociationGetByExample>
    {
        public StaffApplicantAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffApplicantAssociations.StaffApplicantAssociationGetByExample request, Entities.Common.TPDM.IStaffApplicantAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantIdentifier = request.ApplicantIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffApplicantAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationsController : EdFiControllerBase<
        Models.Resources.StaffEvaluation.TPDM.StaffEvaluation,
        Models.Resources.StaffEvaluation.TPDM.StaffEvaluation,
        Entities.Common.TPDM.IStaffEvaluation,
        Entities.NHibernate.StaffEvaluationAggregate.TPDM.StaffEvaluation,
        Api.Models.Requests.TPDM.StaffEvaluations.StaffEvaluationPut,
        Api.Models.Requests.TPDM.StaffEvaluations.StaffEvaluationPost,
        Api.Models.Requests.TPDM.StaffEvaluations.StaffEvaluationDelete,
        Api.Models.Requests.TPDM.StaffEvaluations.StaffEvaluationGetByExample>
    {
        public StaffEvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluations.StaffEvaluationGetByExample request, Entities.Common.TPDM.IStaffEvaluation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.MaxRating = request.MaxRating;
            specification.MinRating = request.MinRating;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffEvaluationPeriodDescriptor = request.StaffEvaluationPeriodDescriptor;
            specification.StaffEvaluationTitle = request.StaffEvaluationTitle;
            specification.StaffEvaluationTypeDescriptor = request.StaffEvaluationTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationComponents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationComponentsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationComponent.TPDM.StaffEvaluationComponent,
        Models.Resources.StaffEvaluationComponent.TPDM.StaffEvaluationComponent,
        Entities.Common.TPDM.IStaffEvaluationComponent,
        Entities.NHibernate.StaffEvaluationComponentAggregate.TPDM.StaffEvaluationComponent,
        Api.Models.Requests.TPDM.StaffEvaluationComponents.StaffEvaluationComponentPut,
        Api.Models.Requests.TPDM.StaffEvaluationComponents.StaffEvaluationComponentPost,
        Api.Models.Requests.TPDM.StaffEvaluationComponents.StaffEvaluationComponentDelete,
        Api.Models.Requests.TPDM.StaffEvaluationComponents.StaffEvaluationComponentGetByExample>
    {
        public StaffEvaluationComponentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationComponents.StaffEvaluationComponentGetByExample request, Entities.Common.TPDM.IStaffEvaluationComponent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationComponent = request.EvaluationComponent;
            specification.Id = request.Id;
            specification.MaxRating = request.MaxRating;
            specification.MinRating = request.MinRating;
            specification.RubricReference = request.RubricReference;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffEvaluationTitle = request.StaffEvaluationTitle;
            specification.StaffEvaluationTypeDescriptor = request.StaffEvaluationTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationComponents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationComponentRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationComponentRatingsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationComponentRating.TPDM.StaffEvaluationComponentRating,
        Models.Resources.StaffEvaluationComponentRating.TPDM.StaffEvaluationComponentRating,
        Entities.Common.TPDM.IStaffEvaluationComponentRating,
        Entities.NHibernate.StaffEvaluationComponentRatingAggregate.TPDM.StaffEvaluationComponentRating,
        Api.Models.Requests.TPDM.StaffEvaluationComponentRatings.StaffEvaluationComponentRatingPut,
        Api.Models.Requests.TPDM.StaffEvaluationComponentRatings.StaffEvaluationComponentRatingPost,
        Api.Models.Requests.TPDM.StaffEvaluationComponentRatings.StaffEvaluationComponentRatingDelete,
        Api.Models.Requests.TPDM.StaffEvaluationComponentRatings.StaffEvaluationComponentRatingGetByExample>
    {
        public StaffEvaluationComponentRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationComponentRatings.StaffEvaluationComponentRatingGetByExample request, Entities.Common.TPDM.IStaffEvaluationComponentRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ComponentRating = request.ComponentRating;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationComponent = request.EvaluationComponent;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffEvaluationDate = request.StaffEvaluationDate;
            specification.StaffEvaluationRatingLevelDescriptor = request.StaffEvaluationRatingLevelDescriptor;
            specification.StaffEvaluationTitle = request.StaffEvaluationTitle;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationComponentRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationElements
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationElementsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationElement.TPDM.StaffEvaluationElement,
        Models.Resources.StaffEvaluationElement.TPDM.StaffEvaluationElement,
        Entities.Common.TPDM.IStaffEvaluationElement,
        Entities.NHibernate.StaffEvaluationElementAggregate.TPDM.StaffEvaluationElement,
        Api.Models.Requests.TPDM.StaffEvaluationElements.StaffEvaluationElementPut,
        Api.Models.Requests.TPDM.StaffEvaluationElements.StaffEvaluationElementPost,
        Api.Models.Requests.TPDM.StaffEvaluationElements.StaffEvaluationElementDelete,
        Api.Models.Requests.TPDM.StaffEvaluationElements.StaffEvaluationElementGetByExample>
    {
        public StaffEvaluationElementsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationElements.StaffEvaluationElementGetByExample request, Entities.Common.TPDM.IStaffEvaluationElement specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationComponent = request.EvaluationComponent;
            specification.EvaluationElement = request.EvaluationElement;
            specification.Id = request.Id;
            specification.MaxRating = request.MaxRating;
            specification.MinRating = request.MinRating;
            specification.RubricReference = request.RubricReference;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffEvaluationTitle = request.StaffEvaluationTitle;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationElements";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationElementRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationElementRatingsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationElementRating.TPDM.StaffEvaluationElementRating,
        Models.Resources.StaffEvaluationElementRating.TPDM.StaffEvaluationElementRating,
        Entities.Common.TPDM.IStaffEvaluationElementRating,
        Entities.NHibernate.StaffEvaluationElementRatingAggregate.TPDM.StaffEvaluationElementRating,
        Api.Models.Requests.TPDM.StaffEvaluationElementRatings.StaffEvaluationElementRatingPut,
        Api.Models.Requests.TPDM.StaffEvaluationElementRatings.StaffEvaluationElementRatingPost,
        Api.Models.Requests.TPDM.StaffEvaluationElementRatings.StaffEvaluationElementRatingDelete,
        Api.Models.Requests.TPDM.StaffEvaluationElementRatings.StaffEvaluationElementRatingGetByExample>
    {
        public StaffEvaluationElementRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationElementRatings.StaffEvaluationElementRatingGetByExample request, Entities.Common.TPDM.IStaffEvaluationElementRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ElementRating = request.ElementRating;
            specification.EvaluationComponent = request.EvaluationComponent;
            specification.EvaluationElement = request.EvaluationElement;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffEvaluationDate = request.StaffEvaluationDate;
            specification.StaffEvaluationRatingLevelDescriptor = request.StaffEvaluationRatingLevelDescriptor;
            specification.StaffEvaluationTitle = request.StaffEvaluationTitle;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationElementRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationPeriodDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationPeriodDescriptorsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationPeriodDescriptor.TPDM.StaffEvaluationPeriodDescriptor,
        Models.Resources.StaffEvaluationPeriodDescriptor.TPDM.StaffEvaluationPeriodDescriptor,
        Entities.Common.TPDM.IStaffEvaluationPeriodDescriptor,
        Entities.NHibernate.StaffEvaluationPeriodDescriptorAggregate.TPDM.StaffEvaluationPeriodDescriptor,
        Api.Models.Requests.TPDM.StaffEvaluationPeriodDescriptors.StaffEvaluationPeriodDescriptorPut,
        Api.Models.Requests.TPDM.StaffEvaluationPeriodDescriptors.StaffEvaluationPeriodDescriptorPost,
        Api.Models.Requests.TPDM.StaffEvaluationPeriodDescriptors.StaffEvaluationPeriodDescriptorDelete,
        Api.Models.Requests.TPDM.StaffEvaluationPeriodDescriptors.StaffEvaluationPeriodDescriptorGetByExample>
    {
        public StaffEvaluationPeriodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationPeriodDescriptors.StaffEvaluationPeriodDescriptorGetByExample request, Entities.Common.TPDM.IStaffEvaluationPeriodDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffEvaluationPeriodDescriptorId = request.StaffEvaluationPeriodDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationPeriodDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationRatingsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationRating.TPDM.StaffEvaluationRating,
        Models.Resources.StaffEvaluationRating.TPDM.StaffEvaluationRating,
        Entities.Common.TPDM.IStaffEvaluationRating,
        Entities.NHibernate.StaffEvaluationRatingAggregate.TPDM.StaffEvaluationRating,
        Api.Models.Requests.TPDM.StaffEvaluationRatings.StaffEvaluationRatingPut,
        Api.Models.Requests.TPDM.StaffEvaluationRatings.StaffEvaluationRatingPost,
        Api.Models.Requests.TPDM.StaffEvaluationRatings.StaffEvaluationRatingDelete,
        Api.Models.Requests.TPDM.StaffEvaluationRatings.StaffEvaluationRatingGetByExample>
    {
        public StaffEvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationRatings.StaffEvaluationRatingGetByExample request, Entities.Common.TPDM.IStaffEvaluationRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluatedByStaffUniqueId = request.EvaluatedByStaffUniqueId;
            specification.Id = request.Id;
            specification.Rating = request.Rating;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffEvaluationDate = request.StaffEvaluationDate;
            specification.StaffEvaluationRatingLevelDescriptor = request.StaffEvaluationRatingLevelDescriptor;
            specification.StaffEvaluationTitle = request.StaffEvaluationTitle;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationRatingLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationRatingLevelDescriptor.TPDM.StaffEvaluationRatingLevelDescriptor,
        Models.Resources.StaffEvaluationRatingLevelDescriptor.TPDM.StaffEvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IStaffEvaluationRatingLevelDescriptor,
        Entities.NHibernate.StaffEvaluationRatingLevelDescriptorAggregate.TPDM.StaffEvaluationRatingLevelDescriptor,
        Api.Models.Requests.TPDM.StaffEvaluationRatingLevelDescriptors.StaffEvaluationRatingLevelDescriptorPut,
        Api.Models.Requests.TPDM.StaffEvaluationRatingLevelDescriptors.StaffEvaluationRatingLevelDescriptorPost,
        Api.Models.Requests.TPDM.StaffEvaluationRatingLevelDescriptors.StaffEvaluationRatingLevelDescriptorDelete,
        Api.Models.Requests.TPDM.StaffEvaluationRatingLevelDescriptors.StaffEvaluationRatingLevelDescriptorGetByExample>
    {
        public StaffEvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationRatingLevelDescriptors.StaffEvaluationRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IStaffEvaluationRatingLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffEvaluationRatingLevelDescriptorId = request.StaffEvaluationRatingLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationRatingLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEvaluationTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.StaffEvaluationTypeDescriptor.TPDM.StaffEvaluationTypeDescriptor,
        Models.Resources.StaffEvaluationTypeDescriptor.TPDM.StaffEvaluationTypeDescriptor,
        Entities.Common.TPDM.IStaffEvaluationTypeDescriptor,
        Entities.NHibernate.StaffEvaluationTypeDescriptorAggregate.TPDM.StaffEvaluationTypeDescriptor,
        Api.Models.Requests.TPDM.StaffEvaluationTypeDescriptors.StaffEvaluationTypeDescriptorPut,
        Api.Models.Requests.TPDM.StaffEvaluationTypeDescriptors.StaffEvaluationTypeDescriptorPost,
        Api.Models.Requests.TPDM.StaffEvaluationTypeDescriptors.StaffEvaluationTypeDescriptorDelete,
        Api.Models.Requests.TPDM.StaffEvaluationTypeDescriptors.StaffEvaluationTypeDescriptorGetByExample>
    {
        public StaffEvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffEvaluationTypeDescriptors.StaffEvaluationTypeDescriptorGetByExample request, Entities.Common.TPDM.IStaffEvaluationTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffEvaluationTypeDescriptorId = request.StaffEvaluationTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEvaluationTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffFieldworkAbsenceEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffFieldworkAbsenceEventsController : EdFiControllerBase<
        Models.Resources.StaffFieldworkAbsenceEvent.TPDM.StaffFieldworkAbsenceEvent,
        Models.Resources.StaffFieldworkAbsenceEvent.TPDM.StaffFieldworkAbsenceEvent,
        Entities.Common.TPDM.IStaffFieldworkAbsenceEvent,
        Entities.NHibernate.StaffFieldworkAbsenceEventAggregate.TPDM.StaffFieldworkAbsenceEvent,
        Api.Models.Requests.TPDM.StaffFieldworkAbsenceEvents.StaffFieldworkAbsenceEventPut,
        Api.Models.Requests.TPDM.StaffFieldworkAbsenceEvents.StaffFieldworkAbsenceEventPost,
        Api.Models.Requests.TPDM.StaffFieldworkAbsenceEvents.StaffFieldworkAbsenceEventDelete,
        Api.Models.Requests.TPDM.StaffFieldworkAbsenceEvents.StaffFieldworkAbsenceEventGetByExample>
    {
        public StaffFieldworkAbsenceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffFieldworkAbsenceEvents.StaffFieldworkAbsenceEventGetByExample request, Entities.Common.TPDM.IStaffFieldworkAbsenceEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AbsenceEventCategoryDescriptor = request.AbsenceEventCategoryDescriptor;
            specification.AbsenceEventReason = request.AbsenceEventReason;
            specification.EventDate = request.EventDate;
            specification.HoursAbsent = request.HoursAbsent;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffFieldworkAbsenceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffFieldworkExperiences
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffFieldworkExperiencesController : EdFiControllerBase<
        Models.Resources.StaffFieldworkExperience.TPDM.StaffFieldworkExperience,
        Models.Resources.StaffFieldworkExperience.TPDM.StaffFieldworkExperience,
        Entities.Common.TPDM.IStaffFieldworkExperience,
        Entities.NHibernate.StaffFieldworkExperienceAggregate.TPDM.StaffFieldworkExperience,
        Api.Models.Requests.TPDM.StaffFieldworkExperiences.StaffFieldworkExperiencePut,
        Api.Models.Requests.TPDM.StaffFieldworkExperiences.StaffFieldworkExperiencePost,
        Api.Models.Requests.TPDM.StaffFieldworkExperiences.StaffFieldworkExperienceDelete,
        Api.Models.Requests.TPDM.StaffFieldworkExperiences.StaffFieldworkExperienceGetByExample>
    {
        public StaffFieldworkExperiencesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffFieldworkExperiences.StaffFieldworkExperienceGetByExample request, Entities.Common.TPDM.IStaffFieldworkExperience specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.FieldworkIdentifier = request.FieldworkIdentifier;
            specification.FieldworkTypeDescriptor = request.FieldworkTypeDescriptor;
            specification.HoursCompleted = request.HoursCompleted;
            specification.Id = request.Id;
            specification.ProgramGatewayDescriptor = request.ProgramGatewayDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffFieldworkExperiences";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffFieldworkExperienceSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffFieldworkExperienceSectionAssociationsController : EdFiControllerBase<
        Models.Resources.StaffFieldworkExperienceSectionAssociation.TPDM.StaffFieldworkExperienceSectionAssociation,
        Models.Resources.StaffFieldworkExperienceSectionAssociation.TPDM.StaffFieldworkExperienceSectionAssociation,
        Entities.Common.TPDM.IStaffFieldworkExperienceSectionAssociation,
        Entities.NHibernate.StaffFieldworkExperienceSectionAssociationAggregate.TPDM.StaffFieldworkExperienceSectionAssociation,
        Api.Models.Requests.TPDM.StaffFieldworkExperienceSectionAssociations.StaffFieldworkExperienceSectionAssociationPut,
        Api.Models.Requests.TPDM.StaffFieldworkExperienceSectionAssociations.StaffFieldworkExperienceSectionAssociationPost,
        Api.Models.Requests.TPDM.StaffFieldworkExperienceSectionAssociations.StaffFieldworkExperienceSectionAssociationDelete,
        Api.Models.Requests.TPDM.StaffFieldworkExperienceSectionAssociations.StaffFieldworkExperienceSectionAssociationGetByExample>
    {
        public StaffFieldworkExperienceSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffFieldworkExperienceSectionAssociations.StaffFieldworkExperienceSectionAssociationGetByExample request, Entities.Common.TPDM.IStaffFieldworkExperienceSectionAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.FieldworkIdentifier = request.FieldworkIdentifier;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffFieldworkExperienceSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffProfessionalDevelopmentEventAttendances
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffProfessionalDevelopmentEventAttendancesController : EdFiControllerBase<
        Models.Resources.StaffProfessionalDevelopmentEventAttendance.TPDM.StaffProfessionalDevelopmentEventAttendance,
        Models.Resources.StaffProfessionalDevelopmentEventAttendance.TPDM.StaffProfessionalDevelopmentEventAttendance,
        Entities.Common.TPDM.IStaffProfessionalDevelopmentEventAttendance,
        Entities.NHibernate.StaffProfessionalDevelopmentEventAttendanceAggregate.TPDM.StaffProfessionalDevelopmentEventAttendance,
        Api.Models.Requests.TPDM.StaffProfessionalDevelopmentEventAttendances.StaffProfessionalDevelopmentEventAttendancePut,
        Api.Models.Requests.TPDM.StaffProfessionalDevelopmentEventAttendances.StaffProfessionalDevelopmentEventAttendancePost,
        Api.Models.Requests.TPDM.StaffProfessionalDevelopmentEventAttendances.StaffProfessionalDevelopmentEventAttendanceDelete,
        Api.Models.Requests.TPDM.StaffProfessionalDevelopmentEventAttendances.StaffProfessionalDevelopmentEventAttendanceGetByExample>
    {
        public StaffProfessionalDevelopmentEventAttendancesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffProfessionalDevelopmentEventAttendances.StaffProfessionalDevelopmentEventAttendanceGetByExample request, Entities.Common.TPDM.IStaffProfessionalDevelopmentEventAttendance specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceDate = request.AttendanceDate;
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.Id = request.Id;
            specification.ProfessionalDevelopmentTitle = request.ProfessionalDevelopmentTitle;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffProfessionalDevelopmentEventAttendances";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffProspectAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffProspectAssociationsController : EdFiControllerBase<
        Models.Resources.StaffProspectAssociation.TPDM.StaffProspectAssociation,
        Models.Resources.StaffProspectAssociation.TPDM.StaffProspectAssociation,
        Entities.Common.TPDM.IStaffProspectAssociation,
        Entities.NHibernate.StaffProspectAssociationAggregate.TPDM.StaffProspectAssociation,
        Api.Models.Requests.TPDM.StaffProspectAssociations.StaffProspectAssociationPut,
        Api.Models.Requests.TPDM.StaffProspectAssociations.StaffProspectAssociationPost,
        Api.Models.Requests.TPDM.StaffProspectAssociations.StaffProspectAssociationDelete,
        Api.Models.Requests.TPDM.StaffProspectAssociations.StaffProspectAssociationGetByExample>
    {
        public StaffProspectAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffProspectAssociations.StaffProspectAssociationGetByExample request, Entities.Common.TPDM.IStaffProspectAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProspectIdentifier = request.ProspectIdentifier;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffProspectAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffStudentGrowthMeasures
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffStudentGrowthMeasuresController : EdFiControllerBase<
        Models.Resources.StaffStudentGrowthMeasure.TPDM.StaffStudentGrowthMeasure,
        Models.Resources.StaffStudentGrowthMeasure.TPDM.StaffStudentGrowthMeasure,
        Entities.Common.TPDM.IStaffStudentGrowthMeasure,
        Entities.NHibernate.StaffStudentGrowthMeasureAggregate.TPDM.StaffStudentGrowthMeasure,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasures.StaffStudentGrowthMeasurePut,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasures.StaffStudentGrowthMeasurePost,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasures.StaffStudentGrowthMeasureDelete,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasures.StaffStudentGrowthMeasureGetByExample>
    {
        public StaffStudentGrowthMeasuresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffStudentGrowthMeasures.StaffStudentGrowthMeasureGetByExample request, Entities.Common.TPDM.IStaffStudentGrowthMeasure specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.ResultDatatypeTypeDescriptor = request.ResultDatatypeTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffStudentGrowthMeasureIdentifier = request.StaffStudentGrowthMeasureIdentifier;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StandardError = request.StandardError;
            specification.StudentGrowthActualScore = request.StudentGrowthActualScore;
            specification.StudentGrowthMeasureDate = request.StudentGrowthMeasureDate;
            specification.StudentGrowthMet = request.StudentGrowthMet;
            specification.StudentGrowthNCount = request.StudentGrowthNCount;
            specification.StudentGrowthTargetScore = request.StudentGrowthTargetScore;
            specification.StudentGrowthTypeDescriptor = request.StudentGrowthTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffStudentGrowthMeasures";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffStudentGrowthMeasureCourseAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffStudentGrowthMeasureCourseAssociationsController : EdFiControllerBase<
        Models.Resources.StaffStudentGrowthMeasureCourseAssociation.TPDM.StaffStudentGrowthMeasureCourseAssociation,
        Models.Resources.StaffStudentGrowthMeasureCourseAssociation.TPDM.StaffStudentGrowthMeasureCourseAssociation,
        Entities.Common.TPDM.IStaffStudentGrowthMeasureCourseAssociation,
        Entities.NHibernate.StaffStudentGrowthMeasureCourseAssociationAggregate.TPDM.StaffStudentGrowthMeasureCourseAssociation,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations.StaffStudentGrowthMeasureCourseAssociationPut,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations.StaffStudentGrowthMeasureCourseAssociationPost,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations.StaffStudentGrowthMeasureCourseAssociationDelete,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations.StaffStudentGrowthMeasureCourseAssociationGetByExample>
    {
        public StaffStudentGrowthMeasureCourseAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffStudentGrowthMeasureCourseAssociations.StaffStudentGrowthMeasureCourseAssociationGetByExample request, Entities.Common.TPDM.IStaffStudentGrowthMeasureCourseAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffStudentGrowthMeasureIdentifier = request.StaffStudentGrowthMeasureIdentifier;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffStudentGrowthMeasureCourseAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffStudentGrowthMeasureEducationOrganizationAssociationsController : EdFiControllerBase<
        Models.Resources.StaffStudentGrowthMeasureEducationOrganizationAssociation.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation,
        Models.Resources.StaffStudentGrowthMeasureEducationOrganizationAssociation.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation,
        Entities.Common.TPDM.IStaffStudentGrowthMeasureEducationOrganizationAssociation,
        Entities.NHibernate.StaffStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociation,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations.StaffStudentGrowthMeasureEducationOrganizationAssociationPut,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations.StaffStudentGrowthMeasureEducationOrganizationAssociationPost,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations.StaffStudentGrowthMeasureEducationOrganizationAssociationDelete,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations.StaffStudentGrowthMeasureEducationOrganizationAssociationGetByExample>
    {
        public StaffStudentGrowthMeasureEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffStudentGrowthMeasureEducationOrganizationAssociations.StaffStudentGrowthMeasureEducationOrganizationAssociationGetByExample request, Entities.Common.TPDM.IStaffStudentGrowthMeasureEducationOrganizationAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffStudentGrowthMeasureIdentifier = request.StaffStudentGrowthMeasureIdentifier;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffStudentGrowthMeasureEducationOrganizationAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffStudentGrowthMeasureSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffStudentGrowthMeasureSectionAssociationsController : EdFiControllerBase<
        Models.Resources.StaffStudentGrowthMeasureSectionAssociation.TPDM.StaffStudentGrowthMeasureSectionAssociation,
        Models.Resources.StaffStudentGrowthMeasureSectionAssociation.TPDM.StaffStudentGrowthMeasureSectionAssociation,
        Entities.Common.TPDM.IStaffStudentGrowthMeasureSectionAssociation,
        Entities.NHibernate.StaffStudentGrowthMeasureSectionAssociationAggregate.TPDM.StaffStudentGrowthMeasureSectionAssociation,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations.StaffStudentGrowthMeasureSectionAssociationPut,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations.StaffStudentGrowthMeasureSectionAssociationPost,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations.StaffStudentGrowthMeasureSectionAssociationDelete,
        Api.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations.StaffStudentGrowthMeasureSectionAssociationGetByExample>
    {
        public StaffStudentGrowthMeasureSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffStudentGrowthMeasureSectionAssociations.StaffStudentGrowthMeasureSectionAssociationGetByExample request, Entities.Common.TPDM.IStaffStudentGrowthMeasureSectionAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StaffStudentGrowthMeasureIdentifier = request.StaffStudentGrowthMeasureIdentifier;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffStudentGrowthMeasureSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffTeacherPreparationProviderAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffTeacherPreparationProviderAssociationsController : EdFiControllerBase<
        Models.Resources.StaffTeacherPreparationProviderAssociation.TPDM.StaffTeacherPreparationProviderAssociation,
        Models.Resources.StaffTeacherPreparationProviderAssociation.TPDM.StaffTeacherPreparationProviderAssociation,
        Entities.Common.TPDM.IStaffTeacherPreparationProviderAssociation,
        Entities.NHibernate.StaffTeacherPreparationProviderAssociationAggregate.TPDM.StaffTeacherPreparationProviderAssociation,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations.StaffTeacherPreparationProviderAssociationPut,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations.StaffTeacherPreparationProviderAssociationPost,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations.StaffTeacherPreparationProviderAssociationDelete,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations.StaffTeacherPreparationProviderAssociationGetByExample>
    {
        public StaffTeacherPreparationProviderAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffTeacherPreparationProviderAssociations.StaffTeacherPreparationProviderAssociationGetByExample request, Entities.Common.TPDM.IStaffTeacherPreparationProviderAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.ProgramAssignmentDescriptor = request.ProgramAssignmentDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.TeacherPreparationProviderId = request.TeacherPreparationProviderId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffTeacherPreparationProviderAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffTeacherPreparationProviderProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffTeacherPreparationProviderProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StaffTeacherPreparationProviderProgramAssociation.TPDM.StaffTeacherPreparationProviderProgramAssociation,
        Models.Resources.StaffTeacherPreparationProviderProgramAssociation.TPDM.StaffTeacherPreparationProviderProgramAssociation,
        Entities.Common.TPDM.IStaffTeacherPreparationProviderProgramAssociation,
        Entities.NHibernate.StaffTeacherPreparationProviderProgramAssociationAggregate.TPDM.StaffTeacherPreparationProviderProgramAssociation,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations.StaffTeacherPreparationProviderProgramAssociationPut,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations.StaffTeacherPreparationProviderProgramAssociationPost,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations.StaffTeacherPreparationProviderProgramAssociationDelete,
        Api.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations.StaffTeacherPreparationProviderProgramAssociationGetByExample>
    {
        public StaffTeacherPreparationProviderProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StaffTeacherPreparationProviderProgramAssociations.StaffTeacherPreparationProviderProgramAssociationGetByExample request, Entities.Common.TPDM.IStaffTeacherPreparationProviderProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StudentRecordAccess = request.StudentRecordAccess;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffTeacherPreparationProviderProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StudentGrowthTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentGrowthTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.StudentGrowthTypeDescriptor.TPDM.StudentGrowthTypeDescriptor,
        Models.Resources.StudentGrowthTypeDescriptor.TPDM.StudentGrowthTypeDescriptor,
        Entities.Common.TPDM.IStudentGrowthTypeDescriptor,
        Entities.NHibernate.StudentGrowthTypeDescriptorAggregate.TPDM.StudentGrowthTypeDescriptor,
        Api.Models.Requests.TPDM.StudentGrowthTypeDescriptors.StudentGrowthTypeDescriptorPut,
        Api.Models.Requests.TPDM.StudentGrowthTypeDescriptors.StudentGrowthTypeDescriptorPost,
        Api.Models.Requests.TPDM.StudentGrowthTypeDescriptors.StudentGrowthTypeDescriptorDelete,
        Api.Models.Requests.TPDM.StudentGrowthTypeDescriptors.StudentGrowthTypeDescriptorGetByExample>
    {
        public StudentGrowthTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.StudentGrowthTypeDescriptors.StudentGrowthTypeDescriptorGetByExample request, Entities.Common.TPDM.IStudentGrowthTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentGrowthTypeDescriptorId = request.StudentGrowthTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentGrowthTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TalentManagementGoals
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TalentManagementGoalsController : EdFiControllerBase<
        Models.Resources.TalentManagementGoal.TPDM.TalentManagementGoal,
        Models.Resources.TalentManagementGoal.TPDM.TalentManagementGoal,
        Entities.Common.TPDM.ITalentManagementGoal,
        Entities.NHibernate.TalentManagementGoalAggregate.TPDM.TalentManagementGoal,
        Api.Models.Requests.TPDM.TalentManagementGoals.TalentManagementGoalPut,
        Api.Models.Requests.TPDM.TalentManagementGoals.TalentManagementGoalPost,
        Api.Models.Requests.TPDM.TalentManagementGoals.TalentManagementGoalDelete,
        Api.Models.Requests.TPDM.TalentManagementGoals.TalentManagementGoalGetByExample>
    {
        public TalentManagementGoalsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TalentManagementGoals.TalentManagementGoalGetByExample request, Entities.Common.TPDM.ITalentManagementGoal specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GoalTitle = request.GoalTitle;
            specification.GoalValue = request.GoalValue;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "talentManagementGoals";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidates
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidatesController : EdFiControllerBase<
        Models.Resources.TeacherCandidate.TPDM.TeacherCandidate,
        Models.Resources.TeacherCandidate.TPDM.TeacherCandidate,
        Entities.Common.TPDM.ITeacherCandidate,
        Entities.NHibernate.TeacherCandidateAggregate.TPDM.TeacherCandidate,
        Api.Models.Requests.TPDM.TeacherCandidates.TeacherCandidatePut,
        Api.Models.Requests.TPDM.TeacherCandidates.TeacherCandidatePost,
        Api.Models.Requests.TPDM.TeacherCandidates.TeacherCandidateDelete,
        Api.Models.Requests.TPDM.TeacherCandidates.TeacherCandidateGetByExample>
    {
        public TeacherCandidatesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidates.TeacherCandidateGetByExample request, Entities.Common.TPDM.ITeacherCandidate specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthCity = request.BirthCity;
            specification.BirthCountryDescriptor = request.BirthCountryDescriptor;
            specification.BirthDate = request.BirthDate;
            specification.BirthInternationalProvince = request.BirthInternationalProvince;
            specification.BirthSexDescriptor = request.BirthSexDescriptor;
            specification.BirthStateAbbreviationDescriptor = request.BirthStateAbbreviationDescriptor;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.DateEnteredUS = request.DateEnteredUS;
            specification.DisplacementStatus = request.DisplacementStatus;
            specification.EconomicDisadvantaged = request.EconomicDisadvantaged;
            specification.EnglishLanguageExamDescriptor = request.EnglishLanguageExamDescriptor;
            specification.FirstGenerationStudent = request.FirstGenerationStudent;
            specification.FirstName = request.FirstName;
            specification.GenderDescriptor = request.GenderDescriptor;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LimitedEnglishProficiencyDescriptor = request.LimitedEnglishProficiencyDescriptor;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PreviousCareerDescriptor = request.PreviousCareerDescriptor;
            specification.ProfileThumbnail = request.ProfileThumbnail;
            specification.ProgramComplete = request.ProgramComplete;
            specification.SexDescriptor = request.SexDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TuitionCost = request.TuitionCost;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidates";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateAcademicRecords
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateAcademicRecordsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateAcademicRecord.TPDM.TeacherCandidateAcademicRecord,
        Models.Resources.TeacherCandidateAcademicRecord.TPDM.TeacherCandidateAcademicRecord,
        Entities.Common.TPDM.ITeacherCandidateAcademicRecord,
        Entities.NHibernate.TeacherCandidateAcademicRecordAggregate.TPDM.TeacherCandidateAcademicRecord,
        Api.Models.Requests.TPDM.TeacherCandidateAcademicRecords.TeacherCandidateAcademicRecordPut,
        Api.Models.Requests.TPDM.TeacherCandidateAcademicRecords.TeacherCandidateAcademicRecordPost,
        Api.Models.Requests.TPDM.TeacherCandidateAcademicRecords.TeacherCandidateAcademicRecordDelete,
        Api.Models.Requests.TPDM.TeacherCandidateAcademicRecords.TeacherCandidateAcademicRecordGetByExample>
    {
        public TeacherCandidateAcademicRecordsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateAcademicRecords.TeacherCandidateAcademicRecordGetByExample request, Entities.Common.TPDM.ITeacherCandidateAcademicRecord specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContentGradePointAverage = request.ContentGradePointAverage;
            specification.ContentGradePointEarned = request.ContentGradePointEarned;
            specification.CumulativeAttemptedCreditConversion = request.CumulativeAttemptedCreditConversion;
            specification.CumulativeAttemptedCredits = request.CumulativeAttemptedCredits;
            specification.CumulativeAttemptedCreditTypeDescriptor = request.CumulativeAttemptedCreditTypeDescriptor;
            specification.CumulativeEarnedCreditConversion = request.CumulativeEarnedCreditConversion;
            specification.CumulativeEarnedCredits = request.CumulativeEarnedCredits;
            specification.CumulativeEarnedCreditTypeDescriptor = request.CumulativeEarnedCreditTypeDescriptor;
            specification.CumulativeGradePointAverage = request.CumulativeGradePointAverage;
            specification.CumulativeGradePointsEarned = request.CumulativeGradePointsEarned;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.GradeValueQualifier = request.GradeValueQualifier;
            specification.Id = request.Id;
            specification.ProgramGatewayDescriptor = request.ProgramGatewayDescriptor;
            specification.ProjectedGraduationDate = request.ProjectedGraduationDate;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionAttemptedCreditConversion = request.SessionAttemptedCreditConversion;
            specification.SessionAttemptedCredits = request.SessionAttemptedCredits;
            specification.SessionAttemptedCreditTypeDescriptor = request.SessionAttemptedCreditTypeDescriptor;
            specification.SessionEarnedCreditConversion = request.SessionEarnedCreditConversion;
            specification.SessionEarnedCredits = request.SessionEarnedCredits;
            specification.SessionEarnedCreditTypeDescriptor = request.SessionEarnedCreditTypeDescriptor;
            specification.SessionGradePointAverage = request.SessionGradePointAverage;
            specification.SessionGradePointsEarned = request.SessionGradePointsEarned;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TermDescriptor = request.TermDescriptor;
            specification.TPPDegreeTypeDescriptor = request.TPPDegreeTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateAcademicRecords";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateCharacteristicDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateCharacteristicDescriptorsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateCharacteristicDescriptor.TPDM.TeacherCandidateCharacteristicDescriptor,
        Models.Resources.TeacherCandidateCharacteristicDescriptor.TPDM.TeacherCandidateCharacteristicDescriptor,
        Entities.Common.TPDM.ITeacherCandidateCharacteristicDescriptor,
        Entities.NHibernate.TeacherCandidateCharacteristicDescriptorAggregate.TPDM.TeacherCandidateCharacteristicDescriptor,
        Api.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors.TeacherCandidateCharacteristicDescriptorPut,
        Api.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors.TeacherCandidateCharacteristicDescriptorPost,
        Api.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors.TeacherCandidateCharacteristicDescriptorDelete,
        Api.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors.TeacherCandidateCharacteristicDescriptorGetByExample>
    {
        public TeacherCandidateCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateCharacteristicDescriptors.TeacherCandidateCharacteristicDescriptorGetByExample request, Entities.Common.TPDM.ITeacherCandidateCharacteristicDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TeacherCandidateCharacteristicDescriptorId = request.TeacherCandidateCharacteristicDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateCharacteristicDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateCourseTranscripts
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateCourseTranscriptsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateCourseTranscript.TPDM.TeacherCandidateCourseTranscript,
        Models.Resources.TeacherCandidateCourseTranscript.TPDM.TeacherCandidateCourseTranscript,
        Entities.Common.TPDM.ITeacherCandidateCourseTranscript,
        Entities.NHibernate.TeacherCandidateCourseTranscriptAggregate.TPDM.TeacherCandidateCourseTranscript,
        Api.Models.Requests.TPDM.TeacherCandidateCourseTranscripts.TeacherCandidateCourseTranscriptPut,
        Api.Models.Requests.TPDM.TeacherCandidateCourseTranscripts.TeacherCandidateCourseTranscriptPost,
        Api.Models.Requests.TPDM.TeacherCandidateCourseTranscripts.TeacherCandidateCourseTranscriptDelete,
        Api.Models.Requests.TPDM.TeacherCandidateCourseTranscripts.TeacherCandidateCourseTranscriptGetByExample>
    {
        public TeacherCandidateCourseTranscriptsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateCourseTranscripts.TeacherCandidateCourseTranscriptGetByExample request, Entities.Common.TPDM.ITeacherCandidateCourseTranscript specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AlternativeCourseCode = request.AlternativeCourseCode;
            specification.AlternativeCourseTitle = request.AlternativeCourseTitle;
            specification.AttemptedCreditConversion = request.AttemptedCreditConversion;
            specification.AttemptedCredits = request.AttemptedCredits;
            specification.AttemptedCreditTypeDescriptor = request.AttemptedCreditTypeDescriptor;
            specification.CourseAttemptResultDescriptor = request.CourseAttemptResultDescriptor;
            specification.CourseCode = request.CourseCode;
            specification.CourseEducationOrganizationId = request.CourseEducationOrganizationId;
            specification.CourseRepeatCodeDescriptor = request.CourseRepeatCodeDescriptor;
            specification.CourseTitle = request.CourseTitle;
            specification.EarnedCreditConversion = request.EarnedCreditConversion;
            specification.EarnedCredits = request.EarnedCredits;
            specification.EarnedCreditTypeDescriptor = request.EarnedCreditTypeDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FinalLetterGradeEarned = request.FinalLetterGradeEarned;
            specification.FinalNumericGradeEarned = request.FinalNumericGradeEarned;
            specification.Id = request.Id;
            specification.MethodCreditEarnedDescriptor = request.MethodCreditEarnedDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TermDescriptor = request.TermDescriptor;
            specification.WhenTakenGradeLevelDescriptor = request.WhenTakenGradeLevelDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateCourseTranscripts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateFieldworkAbsenceEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateFieldworkAbsenceEventsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateFieldworkAbsenceEvent.TPDM.TeacherCandidateFieldworkAbsenceEvent,
        Models.Resources.TeacherCandidateFieldworkAbsenceEvent.TPDM.TeacherCandidateFieldworkAbsenceEvent,
        Entities.Common.TPDM.ITeacherCandidateFieldworkAbsenceEvent,
        Entities.NHibernate.TeacherCandidateFieldworkAbsenceEventAggregate.TPDM.TeacherCandidateFieldworkAbsenceEvent,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkAbsenceEvents.TeacherCandidateFieldworkAbsenceEventPut,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkAbsenceEvents.TeacherCandidateFieldworkAbsenceEventPost,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkAbsenceEvents.TeacherCandidateFieldworkAbsenceEventDelete,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkAbsenceEvents.TeacherCandidateFieldworkAbsenceEventGetByExample>
    {
        public TeacherCandidateFieldworkAbsenceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateFieldworkAbsenceEvents.TeacherCandidateFieldworkAbsenceEventGetByExample request, Entities.Common.TPDM.ITeacherCandidateFieldworkAbsenceEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AbsenceEventCategoryDescriptor = request.AbsenceEventCategoryDescriptor;
            specification.AbsenceEventReason = request.AbsenceEventReason;
            specification.EventDate = request.EventDate;
            specification.HoursAbsent = request.HoursAbsent;
            specification.Id = request.Id;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateFieldworkAbsenceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateFieldworkExperiences
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateFieldworkExperiencesController : EdFiControllerBase<
        Models.Resources.TeacherCandidateFieldworkExperience.TPDM.TeacherCandidateFieldworkExperience,
        Models.Resources.TeacherCandidateFieldworkExperience.TPDM.TeacherCandidateFieldworkExperience,
        Entities.Common.TPDM.ITeacherCandidateFieldworkExperience,
        Entities.NHibernate.TeacherCandidateFieldworkExperienceAggregate.TPDM.TeacherCandidateFieldworkExperience,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperiences.TeacherCandidateFieldworkExperiencePut,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperiences.TeacherCandidateFieldworkExperiencePost,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperiences.TeacherCandidateFieldworkExperienceDelete,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperiences.TeacherCandidateFieldworkExperienceGetByExample>
    {
        public TeacherCandidateFieldworkExperiencesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperiences.TeacherCandidateFieldworkExperienceGetByExample request, Entities.Common.TPDM.ITeacherCandidateFieldworkExperience specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.FieldworkIdentifier = request.FieldworkIdentifier;
            specification.FieldworkTypeDescriptor = request.FieldworkTypeDescriptor;
            specification.HoursCompleted = request.HoursCompleted;
            specification.Id = request.Id;
            specification.ProgramGatewayDescriptor = request.ProgramGatewayDescriptor;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateFieldworkExperiences";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateFieldworkExperienceSectionAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateFieldworkExperienceSectionAssociation.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation,
        Models.Resources.TeacherCandidateFieldworkExperienceSectionAssociation.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation,
        Entities.Common.TPDM.ITeacherCandidateFieldworkExperienceSectionAssociation,
        Entities.NHibernate.TeacherCandidateFieldworkExperienceSectionAssociationAggregate.TPDM.TeacherCandidateFieldworkExperienceSectionAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations.TeacherCandidateFieldworkExperienceSectionAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations.TeacherCandidateFieldworkExperienceSectionAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations.TeacherCandidateFieldworkExperienceSectionAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations.TeacherCandidateFieldworkExperienceSectionAssociationGetByExample>
    {
        public TeacherCandidateFieldworkExperienceSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateFieldworkExperienceSectionAssociations.TeacherCandidateFieldworkExperienceSectionAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateFieldworkExperienceSectionAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.FieldworkIdentifier = request.FieldworkIdentifier;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateFieldworkExperienceSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateProfessionalDevelopmentEventAttendancesController : EdFiControllerBase<
        Models.Resources.TeacherCandidateProfessionalDevelopmentEventAttendance.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance,
        Models.Resources.TeacherCandidateProfessionalDevelopmentEventAttendance.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance,
        Entities.Common.TPDM.ITeacherCandidateProfessionalDevelopmentEventAttendance,
        Entities.NHibernate.TeacherCandidateProfessionalDevelopmentEventAttendanceAggregate.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendance,
        Api.Models.Requests.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances.TeacherCandidateProfessionalDevelopmentEventAttendancePut,
        Api.Models.Requests.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances.TeacherCandidateProfessionalDevelopmentEventAttendancePost,
        Api.Models.Requests.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances.TeacherCandidateProfessionalDevelopmentEventAttendanceDelete,
        Api.Models.Requests.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances.TeacherCandidateProfessionalDevelopmentEventAttendanceGetByExample>
    {
        public TeacherCandidateProfessionalDevelopmentEventAttendancesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateProfessionalDevelopmentEventAttendances.TeacherCandidateProfessionalDevelopmentEventAttendanceGetByExample request, Entities.Common.TPDM.ITeacherCandidateProfessionalDevelopmentEventAttendance specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceDate = request.AttendanceDate;
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.Id = request.Id;
            specification.ProfessionalDevelopmentTitle = request.ProfessionalDevelopmentTitle;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateProfessionalDevelopmentEventAttendances";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateStaffAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateStaffAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateStaffAssociation.TPDM.TeacherCandidateStaffAssociation,
        Models.Resources.TeacherCandidateStaffAssociation.TPDM.TeacherCandidateStaffAssociation,
        Entities.Common.TPDM.ITeacherCandidateStaffAssociation,
        Entities.NHibernate.TeacherCandidateStaffAssociationAggregate.TPDM.TeacherCandidateStaffAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateStaffAssociations.TeacherCandidateStaffAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateStaffAssociations.TeacherCandidateStaffAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateStaffAssociations.TeacherCandidateStaffAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateStaffAssociations.TeacherCandidateStaffAssociationGetByExample>
    {
        public TeacherCandidateStaffAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateStaffAssociations.TeacherCandidateStaffAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateStaffAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateStaffAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateStudentGrowthMeasures
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateStudentGrowthMeasuresController : EdFiControllerBase<
        Models.Resources.TeacherCandidateStudentGrowthMeasure.TPDM.TeacherCandidateStudentGrowthMeasure,
        Models.Resources.TeacherCandidateStudentGrowthMeasure.TPDM.TeacherCandidateStudentGrowthMeasure,
        Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasure,
        Entities.NHibernate.TeacherCandidateStudentGrowthMeasureAggregate.TPDM.TeacherCandidateStudentGrowthMeasure,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures.TeacherCandidateStudentGrowthMeasurePut,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures.TeacherCandidateStudentGrowthMeasurePost,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures.TeacherCandidateStudentGrowthMeasureDelete,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures.TeacherCandidateStudentGrowthMeasureGetByExample>
    {
        public TeacherCandidateStudentGrowthMeasuresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasures.TeacherCandidateStudentGrowthMeasureGetByExample request, Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasure specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.ResultDatatypeTypeDescriptor = request.ResultDatatypeTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.StandardError = request.StandardError;
            specification.StudentGrowthActualScore = request.StudentGrowthActualScore;
            specification.StudentGrowthMeasureDate = request.StudentGrowthMeasureDate;
            specification.StudentGrowthMet = request.StudentGrowthMet;
            specification.StudentGrowthNCount = request.StudentGrowthNCount;
            specification.StudentGrowthTargetScore = request.StudentGrowthTargetScore;
            specification.StudentGrowthTypeDescriptor = request.StudentGrowthTypeDescriptor;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TeacherCandidateStudentGrowthMeasureIdentifier = request.TeacherCandidateStudentGrowthMeasureIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateStudentGrowthMeasures";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateStudentGrowthMeasureCourseAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateStudentGrowthMeasureCourseAssociation.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation,
        Models.Resources.TeacherCandidateStudentGrowthMeasureCourseAssociation.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation,
        Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasureCourseAssociation,
        Entities.NHibernate.TeacherCandidateStudentGrowthMeasureCourseAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations.TeacherCandidateStudentGrowthMeasureCourseAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations.TeacherCandidateStudentGrowthMeasureCourseAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations.TeacherCandidateStudentGrowthMeasureCourseAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations.TeacherCandidateStudentGrowthMeasureCourseAssociationGetByExample>
    {
        public TeacherCandidateStudentGrowthMeasureCourseAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureCourseAssociations.TeacherCandidateStudentGrowthMeasureCourseAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasureCourseAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TeacherCandidateStudentGrowthMeasureIdentifier = request.TeacherCandidateStudentGrowthMeasureIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateStudentGrowthMeasureCourseAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation,
        Models.Resources.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation,
        Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation,
        Entities.NHibernate.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationGetByExample>
    {
        public TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociations.TeacherCandidateStudentGrowthMeasureEducationOrganizationAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasureEducationOrganizationAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TeacherCandidateStudentGrowthMeasureIdentifier = request.TeacherCandidateStudentGrowthMeasureIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateStudentGrowthMeasureEducationOrganizationAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateStudentGrowthMeasureSectionAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateStudentGrowthMeasureSectionAssociation.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation,
        Models.Resources.TeacherCandidateStudentGrowthMeasureSectionAssociation.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation,
        Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasureSectionAssociation,
        Entities.NHibernate.TeacherCandidateStudentGrowthMeasureSectionAssociationAggregate.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations.TeacherCandidateStudentGrowthMeasureSectionAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations.TeacherCandidateStudentGrowthMeasureSectionAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations.TeacherCandidateStudentGrowthMeasureSectionAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations.TeacherCandidateStudentGrowthMeasureSectionAssociationGetByExample>
    {
        public TeacherCandidateStudentGrowthMeasureSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateStudentGrowthMeasureSectionAssociations.TeacherCandidateStudentGrowthMeasureSectionAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateStudentGrowthMeasureSectionAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.FactAsOfDate = request.FactAsOfDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TeacherCandidateStudentGrowthMeasureIdentifier = request.TeacherCandidateStudentGrowthMeasureIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateStudentGrowthMeasureSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateTeacherPreparationProviderAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateTeacherPreparationProviderAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateTeacherPreparationProviderAssociation.TPDM.TeacherCandidateTeacherPreparationProviderAssociation,
        Models.Resources.TeacherCandidateTeacherPreparationProviderAssociation.TPDM.TeacherCandidateTeacherPreparationProviderAssociation,
        Entities.Common.TPDM.ITeacherCandidateTeacherPreparationProviderAssociation,
        Entities.NHibernate.TeacherCandidateTeacherPreparationProviderAssociationAggregate.TPDM.TeacherCandidateTeacherPreparationProviderAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations.TeacherCandidateTeacherPreparationProviderAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations.TeacherCandidateTeacherPreparationProviderAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations.TeacherCandidateTeacherPreparationProviderAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations.TeacherCandidateTeacherPreparationProviderAssociationGetByExample>
    {
        public TeacherCandidateTeacherPreparationProviderAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderAssociations.TeacherCandidateTeacherPreparationProviderAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateTeacherPreparationProviderAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassOfSchoolYear = request.ClassOfSchoolYear;
            specification.EntryDate = request.EntryDate;
            specification.EntryTypeDescriptor = request.EntryTypeDescriptor;
            specification.ExitWithdrawDate = request.ExitWithdrawDate;
            specification.ExitWithdrawTypeDescriptor = request.ExitWithdrawTypeDescriptor;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
            specification.TeacherPreparationProviderId = request.TeacherPreparationProviderId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateTeacherPreparationProviderAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherCandidateTeacherPreparationProviderProgramAssociationsController : EdFiControllerBase<
        Models.Resources.TeacherCandidateTeacherPreparationProviderProgramAssociation.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation,
        Models.Resources.TeacherCandidateTeacherPreparationProviderProgramAssociation.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation,
        Entities.Common.TPDM.ITeacherCandidateTeacherPreparationProviderProgramAssociation,
        Entities.NHibernate.TeacherCandidateTeacherPreparationProviderProgramAssociationAggregate.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociation,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations.TeacherCandidateTeacherPreparationProviderProgramAssociationPut,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations.TeacherCandidateTeacherPreparationProviderProgramAssociationPost,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations.TeacherCandidateTeacherPreparationProviderProgramAssociationDelete,
        Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations.TeacherCandidateTeacherPreparationProviderProgramAssociationGetByExample>
    {
        public TeacherCandidateTeacherPreparationProviderProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherCandidateTeacherPreparationProviderProgramAssociations.TeacherCandidateTeacherPreparationProviderProgramAssociationGetByExample request, Entities.Common.TPDM.ITeacherCandidateTeacherPreparationProviderProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.ReasonExitedDescriptor = request.ReasonExitedDescriptor;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherCandidateTeacherPreparationProviderProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherPreparationProgramTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherPreparationProgramTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.TeacherPreparationProgramTypeDescriptor.TPDM.TeacherPreparationProgramTypeDescriptor,
        Models.Resources.TeacherPreparationProgramTypeDescriptor.TPDM.TeacherPreparationProgramTypeDescriptor,
        Entities.Common.TPDM.ITeacherPreparationProgramTypeDescriptor,
        Entities.NHibernate.TeacherPreparationProgramTypeDescriptorAggregate.TPDM.TeacherPreparationProgramTypeDescriptor,
        Api.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors.TeacherPreparationProgramTypeDescriptorPut,
        Api.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors.TeacherPreparationProgramTypeDescriptorPost,
        Api.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors.TeacherPreparationProgramTypeDescriptorDelete,
        Api.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors.TeacherPreparationProgramTypeDescriptorGetByExample>
    {
        public TeacherPreparationProgramTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherPreparationProgramTypeDescriptors.TeacherPreparationProgramTypeDescriptorGetByExample request, Entities.Common.TPDM.ITeacherPreparationProgramTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TeacherPreparationProgramTypeDescriptorId = request.TeacherPreparationProgramTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherPreparationProgramTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherPreparationProviders
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherPreparationProvidersController : EdFiControllerBase<
        Models.Resources.TeacherPreparationProvider.TPDM.TeacherPreparationProvider,
        Models.Resources.TeacherPreparationProvider.TPDM.TeacherPreparationProvider,
        Entities.Common.TPDM.ITeacherPreparationProvider,
        Entities.NHibernate.TeacherPreparationProviderAggregate.TPDM.TeacherPreparationProvider,
        Api.Models.Requests.TPDM.TeacherPreparationProviders.TeacherPreparationProviderPut,
        Api.Models.Requests.TPDM.TeacherPreparationProviders.TeacherPreparationProviderPost,
        Api.Models.Requests.TPDM.TeacherPreparationProviders.TeacherPreparationProviderDelete,
        Api.Models.Requests.TPDM.TeacherPreparationProviders.TeacherPreparationProviderGetByExample>
    {
        public TeacherPreparationProvidersController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherPreparationProviders.TeacherPreparationProviderGetByExample request, Entities.Common.TPDM.ITeacherPreparationProvider specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FederalLocaleCodeDescriptor = request.FederalLocaleCodeDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.TeacherPreparationProviderId = request.TeacherPreparationProviderId;
            specification.UniversityId = request.UniversityId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherPreparationProviders";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TeacherPreparationProviderPrograms
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeacherPreparationProviderProgramsController : EdFiControllerBase<
        Models.Resources.TeacherPreparationProviderProgram.TPDM.TeacherPreparationProviderProgram,
        Models.Resources.TeacherPreparationProviderProgram.TPDM.TeacherPreparationProviderProgram,
        Entities.Common.TPDM.ITeacherPreparationProviderProgram,
        Entities.NHibernate.TeacherPreparationProviderProgramAggregate.TPDM.TeacherPreparationProviderProgram,
        Api.Models.Requests.TPDM.TeacherPreparationProviderPrograms.TeacherPreparationProviderProgramPut,
        Api.Models.Requests.TPDM.TeacherPreparationProviderPrograms.TeacherPreparationProviderProgramPost,
        Api.Models.Requests.TPDM.TeacherPreparationProviderPrograms.TeacherPreparationProviderProgramDelete,
        Api.Models.Requests.TPDM.TeacherPreparationProviderPrograms.TeacherPreparationProviderProgramGetByExample>
    {
        public TeacherPreparationProviderProgramsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TeacherPreparationProviderPrograms.TeacherPreparationProviderProgramGetByExample request, Entities.Common.TPDM.ITeacherPreparationProviderProgram specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.MajorSpecialization = request.MajorSpecialization;
            specification.MinorSpecialization = request.MinorSpecialization;
            specification.ProgramId = request.ProgramId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.TeacherPreparationProgramTypeDescriptor = request.TeacherPreparationProgramTypeDescriptor;
            specification.TPPProgramPathwayDescriptor = request.TPPProgramPathwayDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teacherPreparationProviderPrograms";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ThemeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ThemeDescriptorsController : EdFiControllerBase<
        Models.Resources.ThemeDescriptor.TPDM.ThemeDescriptor,
        Models.Resources.ThemeDescriptor.TPDM.ThemeDescriptor,
        Entities.Common.TPDM.IThemeDescriptor,
        Entities.NHibernate.ThemeDescriptorAggregate.TPDM.ThemeDescriptor,
        Api.Models.Requests.TPDM.ThemeDescriptors.ThemeDescriptorPut,
        Api.Models.Requests.TPDM.ThemeDescriptors.ThemeDescriptorPost,
        Api.Models.Requests.TPDM.ThemeDescriptors.ThemeDescriptorDelete,
        Api.Models.Requests.TPDM.ThemeDescriptors.ThemeDescriptorGetByExample>
    {
        public ThemeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ThemeDescriptors.ThemeDescriptorGetByExample request, Entities.Common.TPDM.IThemeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ThemeDescriptorId = request.ThemeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "themeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TPPDegreeTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TPPDegreeTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.TPPDegreeTypeDescriptor.TPDM.TPPDegreeTypeDescriptor,
        Models.Resources.TPPDegreeTypeDescriptor.TPDM.TPPDegreeTypeDescriptor,
        Entities.Common.TPDM.ITPPDegreeTypeDescriptor,
        Entities.NHibernate.TPPDegreeTypeDescriptorAggregate.TPDM.TPPDegreeTypeDescriptor,
        Api.Models.Requests.TPDM.TPPDegreeTypeDescriptors.TPPDegreeTypeDescriptorPut,
        Api.Models.Requests.TPDM.TPPDegreeTypeDescriptors.TPPDegreeTypeDescriptorPost,
        Api.Models.Requests.TPDM.TPPDegreeTypeDescriptors.TPPDegreeTypeDescriptorDelete,
        Api.Models.Requests.TPDM.TPPDegreeTypeDescriptors.TPPDegreeTypeDescriptorGetByExample>
    {
        public TPPDegreeTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TPPDegreeTypeDescriptors.TPPDegreeTypeDescriptorGetByExample request, Entities.Common.TPDM.ITPPDegreeTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TPPDegreeTypeDescriptorId = request.TPPDegreeTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "tppDegreeTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.TPPProgramPathwayDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TPPProgramPathwayDescriptorsController : EdFiControllerBase<
        Models.Resources.TPPProgramPathwayDescriptor.TPDM.TPPProgramPathwayDescriptor,
        Models.Resources.TPPProgramPathwayDescriptor.TPDM.TPPProgramPathwayDescriptor,
        Entities.Common.TPDM.ITPPProgramPathwayDescriptor,
        Entities.NHibernate.TPPProgramPathwayDescriptorAggregate.TPDM.TPPProgramPathwayDescriptor,
        Api.Models.Requests.TPDM.TPPProgramPathwayDescriptors.TPPProgramPathwayDescriptorPut,
        Api.Models.Requests.TPDM.TPPProgramPathwayDescriptors.TPPProgramPathwayDescriptorPost,
        Api.Models.Requests.TPDM.TPPProgramPathwayDescriptors.TPPProgramPathwayDescriptorDelete,
        Api.Models.Requests.TPDM.TPPProgramPathwayDescriptors.TPPProgramPathwayDescriptorGetByExample>
    {
        public TPPProgramPathwayDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.TPPProgramPathwayDescriptors.TPPProgramPathwayDescriptorGetByExample request, Entities.Common.TPDM.ITPPProgramPathwayDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TPPProgramPathwayDescriptorId = request.TPPProgramPathwayDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "tppProgramPathwayDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Universities
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class UniversitiesController : EdFiControllerBase<
        Models.Resources.University.TPDM.University,
        Models.Resources.University.TPDM.University,
        Entities.Common.TPDM.IUniversity,
        Entities.NHibernate.UniversityAggregate.TPDM.University,
        Api.Models.Requests.TPDM.Universities.UniversityPut,
        Api.Models.Requests.TPDM.Universities.UniversityPost,
        Api.Models.Requests.TPDM.Universities.UniversityDelete,
        Api.Models.Requests.TPDM.Universities.UniversityGetByExample>
    {
        public UniversitiesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Universities.UniversityGetByExample request, Entities.Common.TPDM.IUniversity specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FederalLocaleCodeDescriptor = request.FederalLocaleCodeDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.UniversityId = request.UniversityId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "universities";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ValueTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ValueTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ValueTypeDescriptor.TPDM.ValueTypeDescriptor,
        Models.Resources.ValueTypeDescriptor.TPDM.ValueTypeDescriptor,
        Entities.Common.TPDM.IValueTypeDescriptor,
        Entities.NHibernate.ValueTypeDescriptorAggregate.TPDM.ValueTypeDescriptor,
        Api.Models.Requests.TPDM.ValueTypeDescriptors.ValueTypeDescriptorPut,
        Api.Models.Requests.TPDM.ValueTypeDescriptors.ValueTypeDescriptorPost,
        Api.Models.Requests.TPDM.ValueTypeDescriptors.ValueTypeDescriptorDelete,
        Api.Models.Requests.TPDM.ValueTypeDescriptors.ValueTypeDescriptorGetByExample>
    {
        public ValueTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ValueTypeDescriptors.ValueTypeDescriptorGetByExample request, Entities.Common.TPDM.IValueTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ValueTypeDescriptorId = request.ValueTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "valueTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.WithdrawReasonDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class WithdrawReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor,
        Models.Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor,
        Entities.Common.TPDM.IWithdrawReasonDescriptor,
        Entities.NHibernate.WithdrawReasonDescriptorAggregate.TPDM.WithdrawReasonDescriptor,
        Api.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorPut,
        Api.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorPost,
        Api.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorDelete,
        Api.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorGetByExample>
    {
        public WithdrawReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorGetByExample request, Entities.Common.TPDM.IWithdrawReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.WithdrawReasonDescriptorId = request.WithdrawReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "withdrawReasonDescriptors";
        }
    }
}

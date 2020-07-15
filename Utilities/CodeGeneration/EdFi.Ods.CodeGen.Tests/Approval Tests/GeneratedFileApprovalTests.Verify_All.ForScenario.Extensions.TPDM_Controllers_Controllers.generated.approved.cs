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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AccreditationStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AccreditationStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor,
        Models.Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor,
        Entities.Common.TPDM.IAccreditationStatusDescriptor,
        Entities.NHibernate.AccreditationStatusDescriptorAggregate.TPDM.AccreditationStatusDescriptor,
        Api.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorPut,
        Api.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorPost,
        Api.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorDelete,
        Api.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample>
    {
        public AccreditationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample request, Entities.Common.TPDM.IAccreditationStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccreditationStatusDescriptorId = request.AccreditationStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "accreditationStatusDescriptors";
        }
    }
}

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
            specification.FirstGenerationStudent = request.FirstGenerationStudent;
            specification.FirstName = request.FirstName;
            specification.GenderDescriptor = request.GenderDescriptor;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
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
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedAcademicSubjectDescriptor = request.HighlyQualifiedAcademicSubjectDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HighNeedsAcademicSubjectDescriptor = request.HighNeedsAcademicSubjectDescriptor;
            specification.HireStatusDescriptor = request.HireStatusDescriptor;
            specification.HiringSourceDescriptor = request.HiringSourceDescriptor;
            specification.Id = request.Id;
            specification.WithdrawDate = request.WithdrawDate;
            specification.WithdrawReasonDescriptor = request.WithdrawReasonDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Certifications
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationsController : EdFiControllerBase<
        Models.Resources.Certification.TPDM.Certification,
        Models.Resources.Certification.TPDM.Certification,
        Entities.Common.TPDM.ICertification,
        Entities.NHibernate.CertificationAggregate.TPDM.Certification,
        Api.Models.Requests.TPDM.Certifications.CertificationPut,
        Api.Models.Requests.TPDM.Certifications.CertificationPost,
        Api.Models.Requests.TPDM.Certifications.CertificationDelete,
        Api.Models.Requests.TPDM.Certifications.CertificationGetByExample>
    {
        public CertificationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Certifications.CertificationGetByExample request, Entities.Common.TPDM.ICertification specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationFieldDescriptor = request.CertificationFieldDescriptor;
            specification.CertificationIdentifier = request.CertificationIdentifier;
            specification.CertificationLevelDescriptor = request.CertificationLevelDescriptor;
            specification.CertificationStandardDescriptor = request.CertificationStandardDescriptor;
            specification.CertificationTitle = request.CertificationTitle;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EducatorRoleDescriptor = request.EducatorRoleDescriptor;
            specification.EffectiveDate = request.EffectiveDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.InstructionalSettingDescriptor = request.InstructionalSettingDescriptor;
            specification.MinimumDegreeDescriptor = request.MinimumDegreeDescriptor;
            specification.Namespace = request.Namespace;
            specification.PopulationServedDescriptor = request.PopulationServedDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certifications";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExams
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationExamsController : EdFiControllerBase<
        Models.Resources.CertificationExam.TPDM.CertificationExam,
        Models.Resources.CertificationExam.TPDM.CertificationExam,
        Entities.Common.TPDM.ICertificationExam,
        Entities.NHibernate.CertificationExamAggregate.TPDM.CertificationExam,
        Api.Models.Requests.TPDM.CertificationExams.CertificationExamPut,
        Api.Models.Requests.TPDM.CertificationExams.CertificationExamPost,
        Api.Models.Requests.TPDM.CertificationExams.CertificationExamDelete,
        Api.Models.Requests.TPDM.CertificationExams.CertificationExamGetByExample>
    {
        public CertificationExamsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationExams.CertificationExamGetByExample request, Entities.Common.TPDM.ICertificationExam specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationExamIdentifier = request.CertificationExamIdentifier;
            specification.CertificationExamTitle = request.CertificationExamTitle;
            specification.CertificationExamTypeDescriptor = request.CertificationExamTypeDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EffectiveDate = request.EffectiveDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationExams";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExamResults
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationExamResultsController : EdFiControllerBase<
        Models.Resources.CertificationExamResult.TPDM.CertificationExamResult,
        Models.Resources.CertificationExamResult.TPDM.CertificationExamResult,
        Entities.Common.TPDM.ICertificationExamResult,
        Entities.NHibernate.CertificationExamResultAggregate.TPDM.CertificationExamResult,
        Api.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultPut,
        Api.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultPost,
        Api.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultDelete,
        Api.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultGetByExample>
    {
        public CertificationExamResultsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultGetByExample request, Entities.Common.TPDM.ICertificationExamResult specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttemptNumber = request.AttemptNumber;
            specification.CertificationExamDate = request.CertificationExamDate;
            specification.CertificationExamIdentifier = request.CertificationExamIdentifier;
            specification.CertificationExamPassIndicator = request.CertificationExamPassIndicator;
            specification.CertificationExamScore = request.CertificationExamScore;
            specification.CertificationExamStatusDescriptor = request.CertificationExamStatusDescriptor;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationExamResults";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationFieldDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationFieldDescriptorsController : EdFiControllerBase<
        Models.Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor,
        Models.Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor,
        Entities.Common.TPDM.ICertificationFieldDescriptor,
        Entities.NHibernate.CertificationFieldDescriptorAggregate.TPDM.CertificationFieldDescriptor,
        Api.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorPut,
        Api.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorPost,
        Api.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorDelete,
        Api.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorGetByExample>
    {
        public CertificationFieldDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorGetByExample request, Entities.Common.TPDM.ICertificationFieldDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationFieldDescriptorId = request.CertificationFieldDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationFieldDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor,
        Models.Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor,
        Entities.Common.TPDM.ICertificationLevelDescriptor,
        Entities.NHibernate.CertificationLevelDescriptorAggregate.TPDM.CertificationLevelDescriptor,
        Api.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorPut,
        Api.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorPost,
        Api.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorDelete,
        Api.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorGetByExample>
    {
        public CertificationLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorGetByExample request, Entities.Common.TPDM.ICertificationLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationLevelDescriptorId = request.CertificationLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationRouteDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationRouteDescriptorsController : EdFiControllerBase<
        Models.Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor,
        Models.Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor,
        Entities.Common.TPDM.ICertificationRouteDescriptor,
        Entities.NHibernate.CertificationRouteDescriptorAggregate.TPDM.CertificationRouteDescriptor,
        Api.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorPut,
        Api.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorPost,
        Api.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorDelete,
        Api.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample>
    {
        public CertificationRouteDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample request, Entities.Common.TPDM.ICertificationRouteDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationRouteDescriptorId = request.CertificationRouteDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationRouteDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationStandardDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CertificationStandardDescriptorsController : EdFiControllerBase<
        Models.Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor,
        Models.Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor,
        Entities.Common.TPDM.ICertificationStandardDescriptor,
        Entities.NHibernate.CertificationStandardDescriptorAggregate.TPDM.CertificationStandardDescriptor,
        Api.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorPut,
        Api.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorPost,
        Api.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorDelete,
        Api.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorGetByExample>
    {
        public CertificationStandardDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorGetByExample request, Entities.Common.TPDM.ICertificationStandardDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationStandardDescriptorId = request.CertificationStandardDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "certificationStandardDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CredentialEventsController : EdFiControllerBase<
        Models.Resources.CredentialEvent.TPDM.CredentialEvent,
        Models.Resources.CredentialEvent.TPDM.CredentialEvent,
        Entities.Common.TPDM.ICredentialEvent,
        Entities.NHibernate.CredentialEventAggregate.TPDM.CredentialEvent,
        Api.Models.Requests.TPDM.CredentialEvents.CredentialEventPut,
        Api.Models.Requests.TPDM.CredentialEvents.CredentialEventPost,
        Api.Models.Requests.TPDM.CredentialEvents.CredentialEventDelete,
        Api.Models.Requests.TPDM.CredentialEvents.CredentialEventGetByExample>
    {
        public CredentialEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CredentialEvents.CredentialEventGetByExample request, Entities.Common.TPDM.ICredentialEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialEventDate = request.CredentialEventDate;
            specification.CredentialEventReason = request.CredentialEventReason;
            specification.CredentialEventTypeDescriptor = request.CredentialEventTypeDescriptor;
            specification.CredentialIdentifier = request.CredentialIdentifier;
            specification.Id = request.Id;
            specification.StateOfIssueStateAbbreviationDescriptor = request.StateOfIssueStateAbbreviationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "credentialEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CredentialEventTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor,
        Models.Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor,
        Entities.Common.TPDM.ICredentialEventTypeDescriptor,
        Entities.NHibernate.CredentialEventTypeDescriptorAggregate.TPDM.CredentialEventTypeDescriptor,
        Api.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorPut,
        Api.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorPost,
        Api.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorDelete,
        Api.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorGetByExample>
    {
        public CredentialEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorGetByExample request, Entities.Common.TPDM.ICredentialEventTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialEventTypeDescriptorId = request.CredentialEventTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "credentialEventTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CredentialStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor,
        Models.Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor,
        Entities.Common.TPDM.ICredentialStatusDescriptor,
        Entities.NHibernate.CredentialStatusDescriptorAggregate.TPDM.CredentialStatusDescriptor,
        Api.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorPut,
        Api.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorPost,
        Api.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorDelete,
        Api.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample>
    {
        public CredentialStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample request, Entities.Common.TPDM.ICredentialStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialStatusDescriptorId = request.CredentialStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "credentialStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.DegreeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DegreeDescriptorsController : EdFiControllerBase<
        Models.Resources.DegreeDescriptor.TPDM.DegreeDescriptor,
        Models.Resources.DegreeDescriptor.TPDM.DegreeDescriptor,
        Entities.Common.TPDM.IDegreeDescriptor,
        Entities.NHibernate.DegreeDescriptorAggregate.TPDM.DegreeDescriptor,
        Api.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorPut,
        Api.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorPost,
        Api.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorDelete,
        Api.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorGetByExample>
    {
        public DegreeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorGetByExample request, Entities.Common.TPDM.IDegreeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DegreeDescriptorId = request.DegreeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "degreeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducatorRoleDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducatorRoleDescriptorsController : EdFiControllerBase<
        Models.Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor,
        Models.Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor,
        Entities.Common.TPDM.IEducatorRoleDescriptor,
        Entities.NHibernate.EducatorRoleDescriptorAggregate.TPDM.EducatorRoleDescriptor,
        Api.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorPut,
        Api.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorPost,
        Api.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorDelete,
        Api.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample>
    {
        public EducatorRoleDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample request, Entities.Common.TPDM.IEducatorRoleDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducatorRoleDescriptorId = request.EducatorRoleDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educatorRoleDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Evaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationsController : EdFiControllerBase<
        Models.Resources.Evaluation.TPDM.Evaluation,
        Models.Resources.Evaluation.TPDM.Evaluation,
        Entities.Common.TPDM.IEvaluation,
        Entities.NHibernate.EvaluationAggregate.TPDM.Evaluation,
        Api.Models.Requests.TPDM.Evaluations.EvaluationPut,
        Api.Models.Requests.TPDM.Evaluations.EvaluationPost,
        Api.Models.Requests.TPDM.Evaluations.EvaluationDelete,
        Api.Models.Requests.TPDM.Evaluations.EvaluationGetByExample>
    {
        public EvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Evaluations.EvaluationGetByExample request, Entities.Common.TPDM.IEvaluation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.EvaluationTypeDescriptor = request.EvaluationTypeDescriptor;
            specification.Id = request.Id;
            specification.InterRaterReliabilityScore = request.InterRaterReliabilityScore;
            specification.MaxRating = request.MaxRating;
            specification.MinRating = request.MinRating;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElements
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationElementsController : EdFiControllerBase<
        Models.Resources.EvaluationElement.TPDM.EvaluationElement,
        Models.Resources.EvaluationElement.TPDM.EvaluationElement,
        Entities.Common.TPDM.IEvaluationElement,
        Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElement,
        Api.Models.Requests.TPDM.EvaluationElements.EvaluationElementPut,
        Api.Models.Requests.TPDM.EvaluationElements.EvaluationElementPost,
        Api.Models.Requests.TPDM.EvaluationElements.EvaluationElementDelete,
        Api.Models.Requests.TPDM.EvaluationElements.EvaluationElementGetByExample>
    {
        public EvaluationElementsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationElements.EvaluationElementGetByExample request, Entities.Common.TPDM.IEvaluationElement specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.EvaluationTypeDescriptor = request.EvaluationTypeDescriptor;
            specification.Id = request.Id;
            specification.MaxRating = request.MaxRating;
            specification.MinRating = request.MinRating;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.SortOrder = request.SortOrder;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationElements";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElementRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationElementRatingsController : EdFiControllerBase<
        Models.Resources.EvaluationElementRating.TPDM.EvaluationElementRating,
        Models.Resources.EvaluationElementRating.TPDM.EvaluationElementRating,
        Entities.Common.TPDM.IEvaluationElementRating,
        Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRating,
        Api.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingPut,
        Api.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingPost,
        Api.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingDelete,
        Api.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingGetByExample>
    {
        public EvaluationElementRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingGetByExample request, Entities.Common.TPDM.IEvaluationElementRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AreaOfRefinement = request.AreaOfRefinement;
            specification.AreaOfReinforcement = request.AreaOfReinforcement;
            specification.Comments = request.Comments;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDate = request.EvaluationDate;
            specification.EvaluationElementRatingLevelDescriptor = request.EvaluationElementRatingLevelDescriptor;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Feedback = request.Feedback;
            specification.Id = request.Id;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.SchoolYear = request.SchoolYear;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationElementRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElementRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationElementRatingLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor,
        Models.Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor,
        Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor,
        Entities.NHibernate.EvaluationElementRatingLevelDescriptorAggregate.TPDM.EvaluationElementRatingLevelDescriptor,
        Api.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPut,
        Api.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPost,
        Api.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorDelete,
        Api.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample>
    {
        public EvaluationElementRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationElementRatingLevelDescriptorId = request.EvaluationElementRatingLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationElementRatingLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationObjectives
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationObjectivesController : EdFiControllerBase<
        Models.Resources.EvaluationObjective.TPDM.EvaluationObjective,
        Models.Resources.EvaluationObjective.TPDM.EvaluationObjective,
        Entities.Common.TPDM.IEvaluationObjective,
        Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjective,
        Api.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectivePut,
        Api.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectivePost,
        Api.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveDelete,
        Api.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveGetByExample>
    {
        public EvaluationObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveGetByExample request, Entities.Common.TPDM.IEvaluationObjective specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.EvaluationTypeDescriptor = request.EvaluationTypeDescriptor;
            specification.Id = request.Id;
            specification.MaxRating = request.MaxRating;
            specification.MinRating = request.MinRating;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.SortOrder = request.SortOrder;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationObjectives";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationObjectiveRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationObjectiveRatingsController : EdFiControllerBase<
        Models.Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating,
        Models.Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating,
        Entities.Common.TPDM.IEvaluationObjectiveRating,
        Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRating,
        Api.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingPut,
        Api.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingPost,
        Api.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingDelete,
        Api.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample>
    {
        public EvaluationObjectiveRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample request, Entities.Common.TPDM.IEvaluationObjectiveRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Comments = request.Comments;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDate = request.EvaluationDate;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Id = request.Id;
            specification.ObjectiveRatingLevelDescriptor = request.ObjectiveRatingLevelDescriptor;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.SchoolYear = request.SchoolYear;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationObjectiveRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationPeriodDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationPeriodDescriptorsController : EdFiControllerBase<
        Models.Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor,
        Models.Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor,
        Entities.Common.TPDM.IEvaluationPeriodDescriptor,
        Entities.NHibernate.EvaluationPeriodDescriptorAggregate.TPDM.EvaluationPeriodDescriptor,
        Api.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPut,
        Api.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPost,
        Api.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorDelete,
        Api.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample>
    {
        public EvaluationPeriodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationPeriodDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationPeriodDescriptorId = request.EvaluationPeriodDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationPeriodDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationRatingsController : EdFiControllerBase<
        Models.Resources.EvaluationRating.TPDM.EvaluationRating,
        Models.Resources.EvaluationRating.TPDM.EvaluationRating,
        Entities.Common.TPDM.IEvaluationRating,
        Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRating,
        Api.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingPut,
        Api.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingPost,
        Api.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingDelete,
        Api.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingGetByExample>
    {
        public EvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingGetByExample request, Entities.Common.TPDM.IEvaluationRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDate = request.EvaluationDate;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationRatingLevelDescriptor = request.EvaluationRatingLevelDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationRatingLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor,
        Models.Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IEvaluationRatingLevelDescriptor,
        Entities.NHibernate.EvaluationRatingLevelDescriptorAggregate.TPDM.EvaluationRatingLevelDescriptor,
        Api.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPut,
        Api.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPost,
        Api.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorDelete,
        Api.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample>
    {
        public EvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationRatingLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationRatingLevelDescriptorId = request.EvaluationRatingLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationRatingLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EvaluationTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor,
        Models.Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor,
        Entities.Common.TPDM.IEvaluationTypeDescriptor,
        Entities.NHibernate.EvaluationTypeDescriptorAggregate.TPDM.EvaluationTypeDescriptor,
        Api.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorPut,
        Api.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorPost,
        Api.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorDelete,
        Api.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample>
    {
        public EvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationTypeDescriptorId = request.EvaluationTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "evaluationTypeDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FieldworkExperiences
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FieldworkExperiencesController : EdFiControllerBase<
        Models.Resources.FieldworkExperience.TPDM.FieldworkExperience,
        Models.Resources.FieldworkExperience.TPDM.FieldworkExperience,
        Entities.Common.TPDM.IFieldworkExperience,
        Entities.NHibernate.FieldworkExperienceAggregate.TPDM.FieldworkExperience,
        Api.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperiencePut,
        Api.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperiencePost,
        Api.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperienceDelete,
        Api.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperienceGetByExample>
    {
        public FieldworkExperiencesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperienceGetByExample request, Entities.Common.TPDM.IFieldworkExperience specification)
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
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "fieldworkExperiences";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FieldworkExperienceSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FieldworkExperienceSectionAssociationsController : EdFiControllerBase<
        Models.Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation,
        Models.Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation,
        Entities.Common.TPDM.IFieldworkExperienceSectionAssociation,
        Entities.NHibernate.FieldworkExperienceSectionAssociationAggregate.TPDM.FieldworkExperienceSectionAssociation,
        Api.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationPut,
        Api.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationPost,
        Api.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationDelete,
        Api.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationGetByExample>
    {
        public FieldworkExperienceSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationGetByExample request, Entities.Common.TPDM.IFieldworkExperienceSectionAssociation specification)
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
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "fieldworkExperienceSectionAssociations";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Goals
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GoalsController : EdFiControllerBase<
        Models.Resources.Goal.TPDM.Goal,
        Models.Resources.Goal.TPDM.Goal,
        Entities.Common.TPDM.IGoal,
        Entities.NHibernate.GoalAggregate.TPDM.Goal,
        Api.Models.Requests.TPDM.Goals.GoalPut,
        Api.Models.Requests.TPDM.Goals.GoalPost,
        Api.Models.Requests.TPDM.Goals.GoalDelete,
        Api.Models.Requests.TPDM.Goals.GoalGetByExample>
    {
        public GoalsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.Goals.GoalGetByExample request, Entities.Common.TPDM.IGoal specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssignmentDate = request.AssignmentDate;
            specification.Comments = request.Comments;
            specification.CompletedDate = request.CompletedDate;
            specification.CompletedIndicator = request.CompletedIndicator;
            specification.DueDate = request.DueDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.GoalDescription = request.GoalDescription;
            specification.GoalTitle = request.GoalTitle;
            specification.GoalTypeDescriptor = request.GoalTypeDescriptor;
            specification.Id = request.Id;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.SchoolYear = request.SchoolYear;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "goals";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.GoalTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GoalTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor,
        Models.Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor,
        Entities.Common.TPDM.IGoalTypeDescriptor,
        Entities.NHibernate.GoalTypeDescriptorAggregate.TPDM.GoalTypeDescriptor,
        Api.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorPut,
        Api.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorPost,
        Api.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorDelete,
        Api.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorGetByExample>
    {
        public GoalTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorGetByExample request, Entities.Common.TPDM.IGoalTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GoalTypeDescriptorId = request.GoalTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "goalTypeDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.InstructionalSettingDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InstructionalSettingDescriptorsController : EdFiControllerBase<
        Models.Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor,
        Models.Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor,
        Entities.Common.TPDM.IInstructionalSettingDescriptor,
        Entities.NHibernate.InstructionalSettingDescriptorAggregate.TPDM.InstructionalSettingDescriptor,
        Api.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorPut,
        Api.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorPost,
        Api.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorDelete,
        Api.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorGetByExample>
    {
        public InstructionalSettingDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorGetByExample request, Entities.Common.TPDM.IInstructionalSettingDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InstructionalSettingDescriptorId = request.InstructionalSettingDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "instructionalSettingDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ObjectiveRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ObjectiveRatingLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor,
        Models.Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor,
        Entities.Common.TPDM.IObjectiveRatingLevelDescriptor,
        Entities.NHibernate.ObjectiveRatingLevelDescriptorAggregate.TPDM.ObjectiveRatingLevelDescriptor,
        Api.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPut,
        Api.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPost,
        Api.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorDelete,
        Api.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample>
    {
        public ObjectiveRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IObjectiveRatingLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ObjectiveRatingLevelDescriptorId = request.ObjectiveRatingLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "objectiveRatingLevelDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceEvaluationsController : EdFiControllerBase<
        Models.Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation,
        Models.Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation,
        Entities.Common.TPDM.IPerformanceEvaluation,
        Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluation,
        Api.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationPut,
        Api.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationPost,
        Api.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationDelete,
        Api.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationGetByExample>
    {
        public PerformanceEvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationGetByExample request, Entities.Common.TPDM.IPerformanceEvaluation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.Id = request.Id;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceEvaluations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceEvaluationRatingsController : EdFiControllerBase<
        Models.Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating,
        Models.Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating,
        Entities.Common.TPDM.IPerformanceEvaluationRating,
        Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRating,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingPut,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingPost,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingDelete,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample>
    {
        public PerformanceEvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample request, Entities.Common.TPDM.IPerformanceEvaluationRating specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ActualDate = request.ActualDate;
            specification.ActualDuration = request.ActualDuration;
            specification.ActualTime = request.ActualTime;
            specification.Announced = request.Announced;
            specification.Comments = request.Comments;
            specification.CoteachingStyleObservedDescriptor = request.CoteachingStyleObservedDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.Id = request.Id;
            specification.PerformanceEvaluationRatingLevelDescriptor = request.PerformanceEvaluationRatingLevelDescriptor;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.ScheduleDate = request.ScheduleDate;
            specification.SchoolYear = request.SchoolYear;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceEvaluationRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceEvaluationRatingLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Models.Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor,
        Entities.NHibernate.PerformanceEvaluationRatingLevelDescriptorAggregate.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPut,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPost,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorDelete,
        Api.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample>
    {
        public PerformanceEvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceEvaluationRatingLevelDescriptorId = request.PerformanceEvaluationRatingLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceEvaluationRatingLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceEvaluationTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor,
        Models.Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor,
        Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor,
        Entities.NHibernate.PerformanceEvaluationTypeDescriptorAggregate.TPDM.PerformanceEvaluationTypeDescriptor,
        Api.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPut,
        Api.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPost,
        Api.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorDelete,
        Api.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample>
    {
        public PerformanceEvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample request, Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceEvaluationTypeDescriptorId = request.PerformanceEvaluationTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceEvaluationTypeDescriptors";
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
            specification.Namespace = request.Namespace;
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProfessionalDevelopmentEventAttendances
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProfessionalDevelopmentEventAttendancesController : EdFiControllerBase<
        Models.Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance,
        Models.Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance,
        Entities.Common.TPDM.IProfessionalDevelopmentEventAttendance,
        Entities.NHibernate.ProfessionalDevelopmentEventAttendanceAggregate.TPDM.ProfessionalDevelopmentEventAttendance,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendancePut,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendancePost,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendanceDelete,
        Api.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendanceGetByExample>
    {
        public ProfessionalDevelopmentEventAttendancesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendanceGetByExample request, Entities.Common.TPDM.IProfessionalDevelopmentEventAttendance specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceDate = request.AttendanceDate;
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PersonId = request.PersonId;
            specification.ProfessionalDevelopmentTitle = request.ProfessionalDevelopmentTitle;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "professionalDevelopmentEventAttendances";
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
            specification.PersonId = request.PersonId;
            specification.PreScreeningRating = request.PreScreeningRating;
            specification.ProspectIdentifier = request.ProspectIdentifier;
            specification.ProspectTypeDescriptor = request.ProspectTypeDescriptor;
            specification.Referral = request.Referral;
            specification.ReferredBy = request.ReferredBy;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SocialMediaNetworkName = request.SocialMediaNetworkName;
            specification.SocialMediaUserName = request.SocialMediaUserName;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "prospects";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasures
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class QuantitativeMeasuresController : EdFiControllerBase<
        Models.Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure,
        Models.Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure,
        Entities.Common.TPDM.IQuantitativeMeasure,
        Entities.NHibernate.QuantitativeMeasureAggregate.TPDM.QuantitativeMeasure,
        Api.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasurePut,
        Api.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasurePost,
        Api.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasureDelete,
        Api.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasureGetByExample>
    {
        public QuantitativeMeasuresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasureGetByExample request, Entities.Common.TPDM.IQuantitativeMeasure specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Id = request.Id;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.QuantitativeMeasureDatatypeDescriptor = request.QuantitativeMeasureDatatypeDescriptor;
            specification.QuantitativeMeasureIdentifier = request.QuantitativeMeasureIdentifier;
            specification.QuantitativeMeasureTypeDescriptor = request.QuantitativeMeasureTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "quantitativeMeasures";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasureDatatypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class QuantitativeMeasureDatatypeDescriptorsController : EdFiControllerBase<
        Models.Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor,
        Models.Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor,
        Entities.Common.TPDM.IQuantitativeMeasureDatatypeDescriptor,
        Entities.NHibernate.QuantitativeMeasureDatatypeDescriptorAggregate.TPDM.QuantitativeMeasureDatatypeDescriptor,
        Api.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorPut,
        Api.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorPost,
        Api.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorDelete,
        Api.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorGetByExample>
    {
        public QuantitativeMeasureDatatypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorGetByExample request, Entities.Common.TPDM.IQuantitativeMeasureDatatypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.QuantitativeMeasureDatatypeDescriptorId = request.QuantitativeMeasureDatatypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "quantitativeMeasureDatatypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasureScores
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class QuantitativeMeasureScoresController : EdFiControllerBase<
        Models.Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore,
        Models.Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore,
        Entities.Common.TPDM.IQuantitativeMeasureScore,
        Entities.NHibernate.QuantitativeMeasureScoreAggregate.TPDM.QuantitativeMeasureScore,
        Api.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScorePut,
        Api.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScorePost,
        Api.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScoreDelete,
        Api.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScoreGetByExample>
    {
        public QuantitativeMeasureScoresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScoreGetByExample request, Entities.Common.TPDM.IQuantitativeMeasureScore specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDate = request.EvaluationDate;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Id = request.Id;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.QuantitativeMeasureIdentifier = request.QuantitativeMeasureIdentifier;
            specification.SchoolYear = request.SchoolYear;
            specification.ScoreValue = request.ScoreValue;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StandardError = request.StandardError;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "quantitativeMeasureScores";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasureTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class QuantitativeMeasureTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor,
        Models.Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor,
        Entities.Common.TPDM.IQuantitativeMeasureTypeDescriptor,
        Entities.NHibernate.QuantitativeMeasureTypeDescriptorAggregate.TPDM.QuantitativeMeasureTypeDescriptor,
        Api.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorPut,
        Api.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorPost,
        Api.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorDelete,
        Api.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorGetByExample>
    {
        public QuantitativeMeasureTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorGetByExample request, Entities.Common.TPDM.IQuantitativeMeasureTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.QuantitativeMeasureTypeDescriptorId = request.QuantitativeMeasureTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "quantitativeMeasureTypeDescriptors";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricDimensions
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricDimensionsController : EdFiControllerBase<
        Models.Resources.RubricDimension.TPDM.RubricDimension,
        Models.Resources.RubricDimension.TPDM.RubricDimension,
        Entities.Common.TPDM.IRubricDimension,
        Entities.NHibernate.RubricDimensionAggregate.TPDM.RubricDimension,
        Api.Models.Requests.TPDM.RubricDimensions.RubricDimensionPut,
        Api.Models.Requests.TPDM.RubricDimensions.RubricDimensionPost,
        Api.Models.Requests.TPDM.RubricDimensions.RubricDimensionDelete,
        Api.Models.Requests.TPDM.RubricDimensions.RubricDimensionGetByExample>
    {
        public RubricDimensionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RubricDimensions.RubricDimensionGetByExample request, Entities.Common.TPDM.IRubricDimension specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CriterionDescription = request.CriterionDescription;
            specification.DimensionOrder = request.DimensionOrder;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Id = request.Id;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.RubricRating = request.RubricRating;
            specification.RubricRatingLevelDescriptor = request.RubricRatingLevelDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubricDimensions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RubricRatingLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor,
        Models.Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor,
        Entities.Common.TPDM.IRubricRatingLevelDescriptor,
        Entities.NHibernate.RubricRatingLevelDescriptorAggregate.TPDM.RubricRatingLevelDescriptor,
        Api.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPut,
        Api.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPost,
        Api.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorDelete,
        Api.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample>
    {
        public RubricRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IRubricRatingLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RubricRatingLevelDescriptorId = request.RubricRatingLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "rubricRatingLevelDescriptors";
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
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffApplicantAssociations";
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveyResponseTeacherCandidateTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyResponseTeacherCandidateTargetAssociationsController : EdFiControllerBase<
        Models.Resources.SurveyResponseTeacherCandidateTargetAssociation.TPDM.SurveyResponseTeacherCandidateTargetAssociation,
        Models.Resources.SurveyResponseTeacherCandidateTargetAssociation.TPDM.SurveyResponseTeacherCandidateTargetAssociation,
        Entities.Common.TPDM.ISurveyResponseTeacherCandidateTargetAssociation,
        Entities.NHibernate.SurveyResponseTeacherCandidateTargetAssociationAggregate.TPDM.SurveyResponseTeacherCandidateTargetAssociation,
        Api.Models.Requests.TPDM.SurveyResponseTeacherCandidateTargetAssociations.SurveyResponseTeacherCandidateTargetAssociationPut,
        Api.Models.Requests.TPDM.SurveyResponseTeacherCandidateTargetAssociations.SurveyResponseTeacherCandidateTargetAssociationPost,
        Api.Models.Requests.TPDM.SurveyResponseTeacherCandidateTargetAssociations.SurveyResponseTeacherCandidateTargetAssociationDelete,
        Api.Models.Requests.TPDM.SurveyResponseTeacherCandidateTargetAssociations.SurveyResponseTeacherCandidateTargetAssociationGetByExample>
    {
        public SurveyResponseTeacherCandidateTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SurveyResponseTeacherCandidateTargetAssociations.SurveyResponseTeacherCandidateTargetAssociationGetByExample request, Entities.Common.TPDM.ISurveyResponseTeacherCandidateTargetAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveyResponseTeacherCandidateTargetAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveySectionAggregateResponses
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionAggregateResponsesController : EdFiControllerBase<
        Models.Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse,
        Models.Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse,
        Entities.Common.TPDM.ISurveySectionAggregateResponse,
        Entities.NHibernate.SurveySectionAggregateResponseAggregate.TPDM.SurveySectionAggregateResponse,
        Api.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponsePut,
        Api.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponsePost,
        Api.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponseDelete,
        Api.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponseGetByExample>
    {
        public SurveySectionAggregateResponsesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponseGetByExample request, Entities.Common.TPDM.ISurveySectionAggregateResponse specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDate = request.EvaluationDate;
            specification.EvaluationElementTitle = request.EvaluationElementTitle;
            specification.EvaluationObjectiveTitle = request.EvaluationObjectiveTitle;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationTitle = request.EvaluationTitle;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.PersonId = request.PersonId;
            specification.SchoolYear = request.SchoolYear;
            specification.ScoreValue = request.ScoreValue;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
            specification.TermDescriptor = request.TermDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveySectionAggregateResponses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionResponseTeacherCandidateTargetAssociationsController : EdFiControllerBase<
        Models.Resources.SurveySectionResponseTeacherCandidateTargetAssociation.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation,
        Models.Resources.SurveySectionResponseTeacherCandidateTargetAssociation.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation,
        Entities.Common.TPDM.ISurveySectionResponseTeacherCandidateTargetAssociation,
        Entities.NHibernate.SurveySectionResponseTeacherCandidateTargetAssociationAggregate.TPDM.SurveySectionResponseTeacherCandidateTargetAssociation,
        Api.Models.Requests.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations.SurveySectionResponseTeacherCandidateTargetAssociationPut,
        Api.Models.Requests.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations.SurveySectionResponseTeacherCandidateTargetAssociationPost,
        Api.Models.Requests.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations.SurveySectionResponseTeacherCandidateTargetAssociationDelete,
        Api.Models.Requests.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations.SurveySectionResponseTeacherCandidateTargetAssociationGetByExample>
    {
        public SurveySectionResponseTeacherCandidateTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TPDM.SurveySectionResponseTeacherCandidateTargetAssociations.SurveySectionResponseTeacherCandidateTargetAssociationGetByExample request, Entities.Common.TPDM.ISurveySectionResponseTeacherCandidateTargetAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
            specification.TeacherCandidateIdentifier = request.TeacherCandidateIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveySectionResponseTeacherCandidateTargetAssociations";
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
            specification.PersonId = request.PersonId;
            specification.PreviousCareerDescriptor = request.PreviousCareerDescriptor;
            specification.ProfileThumbnail = request.ProfileThumbnail;
            specification.ProgramComplete = request.ProgramComplete;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
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
            specification.AccreditationStatusDescriptor = request.AccreditationStatusDescriptor;
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

#if NETFRAMEWORK
using System;
using System.Web.Http.Description;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Common.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Api.Common.Models.Requests;
using EdFi.Ods.Api.Common.Models.Queries;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Services.Controllers.AcademicWeeks.EdFi.Academic_Week_Readable_Excludes_Optional_References
{
    [ProfileContentType("application/vnd.ed-fi.academicweek.academic-week-readable-excludes-optional-references.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AcademicWeeksNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AcademicWeeksController : EdFiControllerBase<
        Api.Common.Models.Resources.AcademicWeek.EdFi.Academic_Week_Readable_Excludes_Optional_References_Readable.AcademicWeek,
        AcademicWeeksNullWriteRequest,
        Entities.Common.EdFi.IAcademicWeek,
        Entities.NHibernate.AcademicWeekAggregate.EdFi.AcademicWeek,
        AcademicWeeksNullWriteRequest,
        AcademicWeeksNullWriteRequest,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Readable_Excludes_Optional_References.AcademicWeekDelete,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Readable_Excludes_Optional_References.AcademicWeekGetByExample>
    {
        public AcademicWeeksController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Readable_Excludes_Optional_References.AcademicWeekGetByExample request, IAcademicWeek specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.TotalInstructionalDays = request.TotalInstructionalDays;
            specification.WeekIdentifier = request.WeekIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "academicWeeks";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.academicweek.academic-week-readable-excludes-optional-references.readable+json";
        }

        public override Task<IHttpActionResult> Post(AcademicWeeksNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Academic-Week-Readable-Excludes-Optional-References' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(AcademicWeeksNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Academic-Week-Readable-Excludes-Optional-References' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicWeeks.EdFi.Academic_Week_Writable_Excludes_Optional_References
{
    [ProfileContentType("application/vnd.ed-fi.academicweek.academic-week-writable-excludes-optional-references.readable+json")]
    [ExcludeFromCodeCoverage]
    public class AcademicWeeksNullReadRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AcademicWeeksController : EdFiControllerBase<
        AcademicWeeksNullReadRequest,
        Api.Common.Models.Resources.AcademicWeek.EdFi.Academic_Week_Writable_Excludes_Optional_References_Writable.AcademicWeek,
        Entities.Common.EdFi.IAcademicWeek,
        Entities.NHibernate.AcademicWeekAggregate.EdFi.AcademicWeek,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Writable_Excludes_Optional_References.AcademicWeekPut,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Writable_Excludes_Optional_References.AcademicWeekPost,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.Academic_Week_Writable_Excludes_Optional_References.AcademicWeekDelete,
        AcademicWeeksNullReadRequest>
    {
        public AcademicWeeksController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(AcademicWeeksNullReadRequest request, IAcademicWeek specification)
        {
            throw new NotSupportedException("Profile only has a Write Content Type defined for this resource, and so the controller does not support read operations.");
                    }

        protected override string GetResourceCollectionName()
        {
            return "academicWeeks";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.academicweek.academic-week-writable-excludes-optional-references.readable+json";
        }

        public override Task<IHttpActionResult> Get(Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Academic-Week-Writable-Excludes-Optional-References' profile are PUT, POST, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> GetAll(UrlQueryParametersRequest urlQueryParametersRequest, AcademicWeeksNullReadRequest specification = null)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Academic-Week-Writable-Excludes-Optional-References' profile are PUT, POST, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Assessments.EdFi.Assessment_Readable_Excludes_Embedded_Object
{
    [ProfileContentType("application/vnd.ed-fi.assessment.assessment-readable-excludes-embedded-object.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentsController : EdFiControllerBase<
        Api.Common.Models.Resources.Assessment.EdFi.Assessment_Readable_Excludes_Embedded_Object_Readable.Assessment,
        AssessmentsNullWriteRequest,
        Entities.Common.EdFi.IAssessment,
        Entities.NHibernate.AssessmentAggregate.EdFi.Assessment,
        AssessmentsNullWriteRequest,
        AssessmentsNullWriteRequest,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Excludes_Embedded_Object.AssessmentDelete,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Excludes_Embedded_Object.AssessmentGetByExample>
    {
        public AssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Excludes_Embedded_Object.AssessmentGetByExample request, IAssessment specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdaptiveAssessment = request.AdaptiveAssessment;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentFamily = request.AssessmentFamily;
            specification.AssessmentForm = request.AssessmentForm;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.AssessmentVersion = request.AssessmentVersion;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.MaxRawScore = request.MaxRawScore;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
            specification.RevisionDate = request.RevisionDate;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessments";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.assessment.assessment-readable-excludes-embedded-object.readable+json";
        }

        public override Task<IHttpActionResult> Post(AssessmentsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Readable-Excludes-Embedded-Object' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(AssessmentsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Readable-Excludes-Embedded-Object' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Assessments.EdFi.Assessment_Readable_Includes_Embedded_Object
{
    [ProfileContentType("application/vnd.ed-fi.assessment.assessment-readable-includes-embedded-object.writable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentsController : EdFiControllerBase<
        Api.Common.Models.Resources.Assessment.EdFi.Assessment_Readable_Includes_Embedded_Object_Readable.Assessment,
        AssessmentsNullWriteRequest,
        Entities.Common.EdFi.IAssessment,
        Entities.NHibernate.AssessmentAggregate.EdFi.Assessment,
        AssessmentsNullWriteRequest,
        AssessmentsNullWriteRequest,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Includes_Embedded_Object.AssessmentDelete,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Includes_Embedded_Object.AssessmentGetByExample>
    {
        public AssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Assessments.EdFi.Assessment_Readable_Includes_Embedded_Object.AssessmentGetByExample request, IAssessment specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdaptiveAssessment = request.AdaptiveAssessment;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentFamily = request.AssessmentFamily;
            specification.AssessmentForm = request.AssessmentForm;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.AssessmentVersion = request.AssessmentVersion;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.MaxRawScore = request.MaxRawScore;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
            specification.RevisionDate = request.RevisionDate;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessments";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.assessment.assessment-readable-includes-embedded-object.readable+json";
        }

        public override Task<IHttpActionResult> Post(AssessmentsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Readable-Includes-Embedded-Object' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(AssessmentsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Readable-Includes-Embedded-Object' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Assessments.EdFi.Assessment_Writable_Excludes_Embedded_Object
{
    [ProfileContentType("application/vnd.ed-fi.assessment.assessment-writable-excludes-embedded-object.readable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentsNullReadRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentsController : EdFiControllerBase<
        AssessmentsNullReadRequest,
        Api.Common.Models.Resources.Assessment.EdFi.Assessment_Writable_Excludes_Embedded_Object_Writable.Assessment,
        Entities.Common.EdFi.IAssessment,
        Entities.NHibernate.AssessmentAggregate.EdFi.Assessment,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Excludes_Embedded_Object.AssessmentPut,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Excludes_Embedded_Object.AssessmentPost,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Excludes_Embedded_Object.AssessmentDelete,
        AssessmentsNullReadRequest>
    {
        public AssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(AssessmentsNullReadRequest request, IAssessment specification)
        {
            throw new NotSupportedException("Profile only has a Write Content Type defined for this resource, and so the controller does not support read operations.");
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessments";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.assessment.assessment-writable-excludes-embedded-object.readable+json";
        }

        public override Task<IHttpActionResult> Get(Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Writable-Excludes-Embedded-Object' profile are PUT, POST, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> GetAll(UrlQueryParametersRequest urlQueryParametersRequest, AssessmentsNullReadRequest specification = null)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Writable-Excludes-Embedded-Object' profile are PUT, POST, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Assessments.EdFi.Assessment_Writable_Includes_Embedded_Object
{
    [ProfileContentType("application/vnd.ed-fi.assessment.assessment-writable-includes-embedded-object.readable+json")]
    [ExcludeFromCodeCoverage]
    public class AssessmentsNullReadRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentsController : EdFiControllerBase<
        AssessmentsNullReadRequest,
        Api.Common.Models.Resources.Assessment.EdFi.Assessment_Writable_Includes_Embedded_Object_Writable.Assessment,
        Entities.Common.EdFi.IAssessment,
        Entities.NHibernate.AssessmentAggregate.EdFi.Assessment,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Includes_Embedded_Object.AssessmentPut,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Includes_Embedded_Object.AssessmentPost,
        Api.Common.Models.Requests.Assessments.EdFi.Assessment_Writable_Includes_Embedded_Object.AssessmentDelete,
        AssessmentsNullReadRequest>
    {
        public AssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(AssessmentsNullReadRequest request, IAssessment specification)
        {
            throw new NotSupportedException("Profile only has a Write Content Type defined for this resource, and so the controller does not support read operations.");
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessments";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.assessment.assessment-writable-includes-embedded-object.readable+json";
        }

        public override Task<IHttpActionResult> Get(Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Writable-Includes-Embedded-Object' profile are PUT, POST, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> GetAll(UrlQueryParametersRequest urlQueryParametersRequest, AssessmentsNullReadRequest specification = null)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Assessment-Writable-Includes-Embedded-Object' profile are PUT, POST, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_ExcludeOnly
{
    [ProfileContentType("application/vnd.ed-fi.studentschoolassociation.minimalstudentschoolassociation-excludeonly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSchoolAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.MinimalStudentSchoolAssociation_ExcludeOnly_Readable.StudentSchoolAssociation,
        StudentSchoolAssociationsNullWriteRequest,
        Entities.Common.EdFi.IStudentSchoolAssociation,
        Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi.StudentSchoolAssociation,
        StudentSchoolAssociationsNullWriteRequest,
        StudentSchoolAssociationsNullWriteRequest,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_ExcludeOnly.StudentSchoolAssociationDelete,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_ExcludeOnly.StudentSchoolAssociationGetByExample>
    {
        public StudentSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_ExcludeOnly.StudentSchoolAssociationGetByExample request, IStudentSchoolAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.ClassOfSchoolYear = request.ClassOfSchoolYear;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmployedWhileEnrolled = request.EmployedWhileEnrolled;
            specification.EntryDate = request.EntryDate;
            specification.EntryGradeLevelDescriptor = request.EntryGradeLevelDescriptor;
            specification.EntryGradeLevelReasonDescriptor = request.EntryGradeLevelReasonDescriptor;
            specification.EntryTypeDescriptor = request.EntryTypeDescriptor;
            specification.ExitWithdrawDate = request.ExitWithdrawDate;
            specification.ExitWithdrawTypeDescriptor = request.ExitWithdrawTypeDescriptor;
            specification.FullTimeEquivalency = request.FullTimeEquivalency;
            specification.GraduationPlanTypeDescriptor = request.GraduationPlanTypeDescriptor;
            specification.GraduationSchoolYear = request.GraduationSchoolYear;
            specification.Id = request.Id;
            specification.PrimarySchool = request.PrimarySchool;
            specification.RepeatGradeIndicator = request.RepeatGradeIndicator;
            specification.ResidencyStatusDescriptor = request.ResidencyStatusDescriptor;
            specification.SchoolChoiceTransfer = request.SchoolChoiceTransfer;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TermCompletionIndicator = request.TermCompletionIndicator;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSchoolAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentschoolassociation.minimalstudentschoolassociation-excludeonly.readable+json";
        }

        public override Task<IHttpActionResult> Post(StudentSchoolAssociationsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'MinimalStudentSchoolAssociation-ExcludeOnly' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(StudentSchoolAssociationsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'MinimalStudentSchoolAssociation-ExcludeOnly' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_IncludeOnly
{
    [ProfileContentType("application/vnd.ed-fi.studentschoolassociation.minimalstudentschoolassociation-includeonly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSchoolAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.MinimalStudentSchoolAssociation_IncludeOnly_Readable.StudentSchoolAssociation,
        StudentSchoolAssociationsNullWriteRequest,
        Entities.Common.EdFi.IStudentSchoolAssociation,
        Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi.StudentSchoolAssociation,
        StudentSchoolAssociationsNullWriteRequest,
        StudentSchoolAssociationsNullWriteRequest,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_IncludeOnly.StudentSchoolAssociationDelete,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_IncludeOnly.StudentSchoolAssociationGetByExample>
    {
        public StudentSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.MinimalStudentSchoolAssociation_IncludeOnly.StudentSchoolAssociationGetByExample request, IStudentSchoolAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.ClassOfSchoolYear = request.ClassOfSchoolYear;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmployedWhileEnrolled = request.EmployedWhileEnrolled;
            specification.EntryDate = request.EntryDate;
            specification.EntryGradeLevelDescriptor = request.EntryGradeLevelDescriptor;
            specification.EntryGradeLevelReasonDescriptor = request.EntryGradeLevelReasonDescriptor;
            specification.EntryTypeDescriptor = request.EntryTypeDescriptor;
            specification.ExitWithdrawDate = request.ExitWithdrawDate;
            specification.ExitWithdrawTypeDescriptor = request.ExitWithdrawTypeDescriptor;
            specification.FullTimeEquivalency = request.FullTimeEquivalency;
            specification.GraduationPlanTypeDescriptor = request.GraduationPlanTypeDescriptor;
            specification.GraduationSchoolYear = request.GraduationSchoolYear;
            specification.Id = request.Id;
            specification.PrimarySchool = request.PrimarySchool;
            specification.RepeatGradeIndicator = request.RepeatGradeIndicator;
            specification.ResidencyStatusDescriptor = request.ResidencyStatusDescriptor;
            specification.SchoolChoiceTransfer = request.SchoolChoiceTransfer;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TermCompletionIndicator = request.TermCompletionIndicator;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSchoolAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentschoolassociation.minimalstudentschoolassociation-includeonly.readable+json";
        }

        public override Task<IHttpActionResult> Post(StudentSchoolAssociationsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'MinimalStudentSchoolAssociation-IncludeOnly' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(StudentSchoolAssociationsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'MinimalStudentSchoolAssociation-IncludeOnly' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi.Student_Readable_Restricted
{
    [ProfileContentType("application/vnd.ed-fi.student.student-readable-restricted.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Api.Common.Models.Resources.Student.EdFi.Student_Readable_Restricted_Readable.Student,
        StudentsNullWriteRequest,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        StudentsNullWriteRequest,
        StudentsNullWriteRequest,
        Api.Common.Models.Requests.Students.EdFi.Student_Readable_Restricted.StudentDelete,
        Api.Common.Models.Requests.Students.EdFi.Student_Readable_Restricted.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Students.EdFi.Student_Readable_Restricted.StudentGetByExample request, IStudent specification)
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
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.student.student-readable-restricted.readable+json";
        }

        public override Task<IHttpActionResult> Post(StudentsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Student-Readable-Restricted' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(StudentsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Student-Readable-Restricted' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSpecialEducationProgramAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly_Readable.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly.StudentSpecialEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly.StudentSpecialEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly.StudentSpecialEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_ExcludeOnly.StudentSpecialEducationProgramAssociationGetByExample request, IStudentSpecialEducationProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.IdeaEligibility = request.IdeaEligibility;
            specification.IEPBeginDate = request.IEPBeginDate;
            specification.IEPEndDate = request.IEPEndDate;
            specification.IEPReviewDate = request.IEPReviewDate;
            specification.LastEvaluationDate = request.LastEvaluationDate;
            specification.MedicallyFragile = request.MedicallyFragile;
            specification.MultiplyDisabled = request.MultiplyDisabled;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolHoursPerWeek = request.SchoolHoursPerWeek;
            specification.SpecialEducationHoursPerWeek = request.SpecialEducationHoursPerWeek;
            specification.SpecialEducationSettingDescriptor = request.SpecialEducationSettingDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSpecialEducationProgramAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentspecialeducationprogramassociation.studentspecialeducationprogramassociation-derived-association-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSpecialEducationProgramAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll_Readable.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll_Writable.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll.StudentSpecialEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll.StudentSpecialEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll.StudentSpecialEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeAll.StudentSpecialEducationProgramAssociationGetByExample request, IStudentSpecialEducationProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.IdeaEligibility = request.IdeaEligibility;
            specification.IEPBeginDate = request.IEPBeginDate;
            specification.IEPEndDate = request.IEPEndDate;
            specification.IEPReviewDate = request.IEPReviewDate;
            specification.LastEvaluationDate = request.LastEvaluationDate;
            specification.MedicallyFragile = request.MedicallyFragile;
            specification.MultiplyDisabled = request.MultiplyDisabled;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolHoursPerWeek = request.SchoolHoursPerWeek;
            specification.SpecialEducationHoursPerWeek = request.SpecialEducationHoursPerWeek;
            specification.SpecialEducationSettingDescriptor = request.SpecialEducationSettingDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSpecialEducationProgramAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentspecialeducationprogramassociation.studentspecialeducationprogramassociation-derived-association-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSpecialEducationProgramAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly_Readable.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly_Writable.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly.StudentSpecialEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly.StudentSpecialEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly.StudentSpecialEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociation_Derived_Association_IncludeOnly.StudentSpecialEducationProgramAssociationGetByExample request, IStudentSpecialEducationProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.IdeaEligibility = request.IdeaEligibility;
            specification.IEPBeginDate = request.IEPBeginDate;
            specification.IEPEndDate = request.IEPEndDate;
            specification.IEPReviewDate = request.IEPReviewDate;
            specification.LastEvaluationDate = request.LastEvaluationDate;
            specification.MedicallyFragile = request.MedicallyFragile;
            specification.MultiplyDisabled = request.MultiplyDisabled;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolHoursPerWeek = request.SchoolHoursPerWeek;
            specification.SpecialEducationHoursPerWeek = request.SpecialEducationHoursPerWeek;
            specification.SpecialEducationSettingDescriptor = request.SpecialEducationSettingDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSpecialEducationProgramAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentspecialeducationprogramassociation.studentspecialeducationprogramassociation-derived-association-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSpecialEducationProgramAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly_Readable.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly_Writable.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly.StudentSpecialEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly.StudentSpecialEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly.StudentSpecialEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_ExcludeOnly.StudentSpecialEducationProgramAssociationGetByExample request, IStudentSpecialEducationProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.IdeaEligibility = request.IdeaEligibility;
            specification.IEPBeginDate = request.IEPBeginDate;
            specification.IEPEndDate = request.IEPEndDate;
            specification.IEPReviewDate = request.IEPReviewDate;
            specification.LastEvaluationDate = request.LastEvaluationDate;
            specification.MedicallyFragile = request.MedicallyFragile;
            specification.MultiplyDisabled = request.MultiplyDisabled;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolHoursPerWeek = request.SchoolHoursPerWeek;
            specification.SpecialEducationHoursPerWeek = request.SpecialEducationHoursPerWeek;
            specification.SpecialEducationSettingDescriptor = request.SpecialEducationSettingDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSpecialEducationProgramAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentspecialeducationprogramassociation.test-parentnonabstractbaseclass-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSpecialEducationProgramAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll_Readable.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll_Writable.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll.StudentSpecialEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll.StudentSpecialEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll.StudentSpecialEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.Test_ParentNonAbstractBaseClass_IncludeAll.StudentSpecialEducationProgramAssociationGetByExample request, IStudentSpecialEducationProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.IdeaEligibility = request.IdeaEligibility;
            specification.IEPBeginDate = request.IEPBeginDate;
            specification.IEPEndDate = request.IEPEndDate;
            specification.IEPReviewDate = request.IEPReviewDate;
            specification.LastEvaluationDate = request.LastEvaluationDate;
            specification.MedicallyFragile = request.MedicallyFragile;
            specification.MultiplyDisabled = request.MultiplyDisabled;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolHoursPerWeek = request.SchoolHoursPerWeek;
            specification.SpecialEducationHoursPerWeek = request.SpecialEducationHoursPerWeek;
            specification.SpecialEducationSettingDescriptor = request.SpecialEducationSettingDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentSpecialEducationProgramAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentspecialeducationprogramassociation.test-parentnonabstractbaseclass-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LocalEducationAgenciesController : EdFiControllerBase<
        Api.Common.Models.Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Readable.LocalEducationAgency,
        Api.Common.Models.Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.LocalEducationAgency,
        Entities.Common.EdFi.ILocalEducationAgency,
        Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.LocalEducationAgencyPut,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.LocalEducationAgencyPost,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.LocalEducationAgencyDelete,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.LocalEducationAgencyGetByExample>
    {
        public LocalEducationAgenciesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.LocalEducationAgencyGetByExample request, ILocalEducationAgency specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.EducationServiceCenterId = request.EducationServiceCenterId;
            specification.LocalEducationAgencyCategoryDescriptor = request.LocalEducationAgencyCategoryDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.ParentLocalEducationAgencyId = request.ParentLocalEducationAgencyId;
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "localEducationAgencies";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.localeducationagency.test-profile-edorgs-resources-child-collection-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_ExcludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-edorgs-resources-child-collection-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LocalEducationAgenciesController : EdFiControllerBase<
        Api.Common.Models.Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Readable.LocalEducationAgency,
        Api.Common.Models.Resources.LocalEducationAgency.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.LocalEducationAgency,
        Entities.Common.EdFi.ILocalEducationAgency,
        Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.LocalEducationAgencyPut,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.LocalEducationAgencyPost,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.LocalEducationAgencyDelete,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.LocalEducationAgencyGetByExample>
    {
        public LocalEducationAgenciesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalEducationAgencies.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.LocalEducationAgencyGetByExample request, ILocalEducationAgency specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.EducationServiceCenterId = request.EducationServiceCenterId;
            specification.LocalEducationAgencyCategoryDescriptor = request.LocalEducationAgencyCategoryDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.ParentLocalEducationAgencyId = request.ParentLocalEducationAgencyId;
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "localEducationAgencies";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.localeducationagency.test-profile-edorgs-resources-child-collection-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_EdOrgs_Resources_Child_Collection_IncludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-edorgs-resources-child-collection-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Test_Profile_For_Composites_With_Multiple_Resources
{
    [ProfileContentType("application/vnd.ed-fi.staff.test-profile-for-composites-with-multiple-resources.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Api.Common.Models.Resources.Staff.EdFi.Test_Profile_For_Composites_With_Multiple_Resources_Readable.Staff,
        StaffsNullWriteRequest,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        StaffsNullWriteRequest,
        StaffsNullWriteRequest,
        Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_For_Composites_With_Multiple_Resources.StaffDelete,
        Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_For_Composites_With_Multiple_Resources.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_For_Composites_With_Multiple_Resources.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.test-profile-for-composites-with-multiple-resources.readable+json";
        }

        public override Task<IHttpActionResult> Post(StaffsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-For-Composites-With-Multiple-Resources' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(StaffsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-For-Composites-With-Multiple-Resources' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentEducationOrganizationAssociations.EdFi.Test_Profile_For_Composites_With_Multiple_Resources
{
    [ProfileContentType("application/vnd.ed-fi.studenteducationorganizationassociation.test-profile-for-composites-with-multiple-resources.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentEducationOrganizationAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentEducationOrganizationAssociation.EdFi.Test_Profile_For_Composites_With_Multiple_Resources_Readable.StudentEducationOrganizationAssociation,
        StudentEducationOrganizationAssociationsNullWriteRequest,
        Entities.Common.EdFi.IStudentEducationOrganizationAssociation,
        Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi.StudentEducationOrganizationAssociation,
        StudentEducationOrganizationAssociationsNullWriteRequest,
        StudentEducationOrganizationAssociationsNullWriteRequest,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_Profile_For_Composites_With_Multiple_Resources.StudentEducationOrganizationAssociationDelete,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_Profile_For_Composites_With_Multiple_Resources.StudentEducationOrganizationAssociationGetByExample>
    {
        public StudentEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_Profile_For_Composites_With_Multiple_Resources.StudentEducationOrganizationAssociationGetByExample request, IStudentEducationOrganizationAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LimitedEnglishProficiencyDescriptor = request.LimitedEnglishProficiencyDescriptor;
            specification.LoginId = request.LoginId;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.ProfileThumbnail = request.ProfileThumbnail;
            specification.SexDescriptor = request.SexDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentEducationOrganizationAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studenteducationorganizationassociation.test-profile-for-composites-with-multiple-resources.readable+json";
        }

        public override Task<IHttpActionResult> Post(StudentEducationOrganizationAssociationsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-For-Composites-With-Multiple-Resources' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(StudentEducationOrganizationAssociationsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-For-Composites-With-Multiple-Resources' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-baseclass-child-collection-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2
{
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-baseclass-child-collection-excludeonly-2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2_Readable.School,
        SchoolsNullWriteRequest,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        SchoolsNullWriteRequest,
        SchoolsNullWriteRequest,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_ExcludeOnly_2.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-baseclass-child-collection-excludeonly-2.readable+json";
        }

        public override Task<IHttpActionResult> Post(SchoolsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-Resource-BaseClass-Child-Collection-ExcludeOnly-2' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(SchoolsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-Resource-BaseClass-Child-Collection-ExcludeOnly-2' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_BaseClass_Child_Collection_IncludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-baseclass-child-collection-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_ExcludeOnly_Specific_Descriptors.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-child-collection-filtered-to-excludeonly-specific-descriptors.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_Filtered_To_IncludeOnly_Specific_Descriptors.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-child-collection-filtered-to-includeonly-specific-descriptors.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_Child_Collection_IncludeAll.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-child-collection-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeAll_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeAll_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeAll.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeAll.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeAll.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeAll.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeAll.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentAssessmentsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors_Readable.StudentAssessment,
        Api.Common.Models.Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment,
        Entities.Common.EdFi.IStudentAssessment,
        Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors.StudentAssessmentPut,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors.StudentAssessmentPost,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors.StudentAssessmentDelete,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors.StudentAssessmentGetByExample>
    {
        public StudentAssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_ExcludeOnly_Specific_Types_and_Descriptors.StudentAssessmentGetByExample request, IStudentAssessment specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationDate = request.AdministrationDate;
            specification.AdministrationEndDate = request.AdministrationEndDate;
            specification.AdministrationEnvironmentDescriptor = request.AdministrationEnvironmentDescriptor;
            specification.AdministrationLanguageDescriptor = request.AdministrationLanguageDescriptor;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.EventCircumstanceDescriptor = request.EventCircumstanceDescriptor;
            specification.EventDescription = request.EventDescription;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PlatformTypeDescriptor = request.PlatformTypeDescriptor;
            specification.ReasonNotTestedDescriptor = request.ReasonNotTestedDescriptor;
            specification.RetestIndicatorDescriptor = request.RetestIndicatorDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.SerialNumber = request.SerialNumber;
            specification.StudentAssessmentIdentifier = request.StudentAssessmentIdentifier;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.WhenAssessedGradeLevelDescriptor = request.WhenAssessedGradeLevelDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentAssessments";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentassessment.test-profile-resource-nested-child-collection-filtered-to-excludeonly-specific-types-and-descriptors.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentAssessmentsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors_Readable.StudentAssessment,
        Api.Common.Models.Resources.StudentAssessment.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors_Writable.StudentAssessment,
        Entities.Common.EdFi.IStudentAssessment,
        Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors.StudentAssessmentPut,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors.StudentAssessmentPost,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors.StudentAssessmentDelete,
        Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors.StudentAssessmentGetByExample>
    {
        public StudentAssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentAssessments.EdFi.Test_Profile_Resource_Nested_Child_Collection_Filtered_To_IncludeOnly_Specific_Types_and_Descriptors.StudentAssessmentGetByExample request, IStudentAssessment specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationDate = request.AdministrationDate;
            specification.AdministrationEndDate = request.AdministrationEndDate;
            specification.AdministrationEnvironmentDescriptor = request.AdministrationEnvironmentDescriptor;
            specification.AdministrationLanguageDescriptor = request.AdministrationLanguageDescriptor;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.EventCircumstanceDescriptor = request.EventCircumstanceDescriptor;
            specification.EventDescription = request.EventDescription;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PlatformTypeDescriptor = request.PlatformTypeDescriptor;
            specification.ReasonNotTestedDescriptor = request.ReasonNotTestedDescriptor;
            specification.RetestIndicatorDescriptor = request.RetestIndicatorDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.SerialNumber = request.SerialNumber;
            specification.StudentAssessmentIdentifier = request.StudentAssessmentIdentifier;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.WhenAssessedGradeLevelDescriptor = request.WhenAssessedGradeLevelDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentAssessments";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studentassessment.test-profile-resource-nested-child-collection-filtered-to-includeonly-specific-types-and-descriptors.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_ReadOnly
{
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-readonly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_ReadOnly_Readable.School,
        SchoolsNullWriteRequest,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        SchoolsNullWriteRequest,
        SchoolsNullWriteRequest,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-readonly.readable+json";
        }

        public override Task<IHttpActionResult> Post(SchoolsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-Resource-ReadOnly' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(SchoolsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-Resource-ReadOnly' profile are GET, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_References_ExcludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_References_ExcludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_ExcludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-references-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_References_IncludeOnly_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_References_IncludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_References_IncludeOnly.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-references-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_WriteOnly
{
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-writeonly.readable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolsNullReadRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        SchoolsNullReadRequest,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly.SchoolDelete,
        SchoolsNullReadRequest>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(SchoolsNullReadRequest request, ISchool specification)
        {
            throw new NotSupportedException("Profile only has a Write Content Type defined for this resource, and so the controller does not support read operations.");
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-resource-writeonly.readable+json";
        }

        public override Task<IHttpActionResult> Get(Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-Resource-WriteOnly' profile are PUT, POST, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> GetAll(UrlQueryParametersRequest urlQueryParametersRequest, SchoolsNullReadRequest specification = null)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-Profile-Resource-WriteOnly' profile are PUT, POST, DELETE and OPTIONS."));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Api.Common.Models.Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Readable.Staff,
        Api.Common.Models.Resources.Staff.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll.StaffPut,
        Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll.StaffPost,
        Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll.StaffDelete,
        Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Staffs.EdFi.Test_Profile_StaffOnly_Resource_IncludeAll.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.test-profile-staffonly-resource-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Student_and_School_Include_All
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Student_and_School_Include_All_Readable.School,
        Api.Common.Models.Resources.School.EdFi.Test_Profile_Student_and_School_Include_All_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Student_and_School_Include_All.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Student_and_School_Include_All.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Student_and_School_Include_All.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Student_and_School_Include_All.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Student_and_School_Include_All.SchoolGetByExample request, ISchool specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.CharterApprovalAgencyTypeDescriptor = request.CharterApprovalAgencyTypeDescriptor;
            specification.CharterApprovalSchoolYear = request.CharterApprovalSchoolYear;
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.InternetAccessDescriptor = request.InternetAccessDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.MagnetSpecialProgramEmphasisSchoolDescriptor = request.MagnetSpecialProgramEmphasisSchoolDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolTypeDescriptor = request.SchoolTypeDescriptor;
            specification.TitleIPartASchoolDesignationDescriptor = request.TitleIPartASchoolDesignationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.school.test-profile-student-and-school-include-all.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi.Test_Profile_Student_and_School_Include_All
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Api.Common.Models.Resources.Student.EdFi.Test_Profile_Student_and_School_Include_All_Readable.Student,
        Api.Common.Models.Resources.Student.EdFi.Test_Profile_Student_and_School_Include_All_Writable.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_Student_and_School_Include_All.StudentPut,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_Student_and_School_Include_All.StudentPost,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_Student_and_School_Include_All.StudentDelete,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_Student_and_School_Include_All.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Students.EdFi.Test_Profile_Student_and_School_Include_All.StudentGetByExample request, IStudent specification)
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
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.student.test-profile-student-and-school-include-all.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Api.Common.Models.Resources.Student.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll_Readable.Student,
        Api.Common.Models.Resources.Student.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll_Writable.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll.StudentPut,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll.StudentPost,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll.StudentDelete,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly2_Resource_IncludeAll.StudentGetByExample request, IStudent specification)
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
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.student.test-profile-studentonly2-resource-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Api.Common.Models.Resources.Student.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll_Readable.Student,
        Api.Common.Models.Resources.Student.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll_Writable.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll.StudentPut,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll.StudentPost,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll.StudentDelete,
        Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Students.EdFi.Test_Profile_StudentOnly_Resource_IncludeAll.StudentGetByExample request, IStudent specification)
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
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.student.test-profile-studentonly-resource-includeall.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentEducationOrganizationAssociations.EdFi.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical
{
    [ProfileContentType("application/vnd.ed-fi.studenteducationorganizationassociation.test-studenteducationorganizationassociation-exclude-all-addrs-except-physical.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentEducationOrganizationAssociationsController : EdFiControllerBase<
        Api.Common.Models.Resources.StudentEducationOrganizationAssociation.EdFi.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical_Readable.StudentEducationOrganizationAssociation,
        StudentEducationOrganizationAssociationsNullWriteRequest,
        Entities.Common.EdFi.IStudentEducationOrganizationAssociation,
        Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi.StudentEducationOrganizationAssociation,
        StudentEducationOrganizationAssociationsNullWriteRequest,
        StudentEducationOrganizationAssociationsNullWriteRequest,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical.StudentEducationOrganizationAssociationDelete,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical.StudentEducationOrganizationAssociationGetByExample>
    {
        public StudentEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.Test_StudentEducationOrganizationAssociation_Exclude_All_Addrs_Except_Physical.StudentEducationOrganizationAssociationGetByExample request, IStudentEducationOrganizationAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LimitedEnglishProficiencyDescriptor = request.LimitedEnglishProficiencyDescriptor;
            specification.LoginId = request.LoginId;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.ProfileThumbnail = request.ProfileThumbnail;
            specification.SexDescriptor = request.SexDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentEducationOrganizationAssociations";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.studenteducationorganizationassociation.test-studenteducationorganizationassociation-exclude-all-addrs-except-physical.readable+json";
        }

        public override Task<IHttpActionResult> Post(StudentEducationOrganizationAssociationsNullWriteRequest request)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-StudentEducationOrganizationAssociation-Exclude-All-Addrs-Except-Physical' profile are GET, DELETE and OPTIONS."));
        }

        public override Task<IHttpActionResult> Put(StudentEducationOrganizationAssociationsNullWriteRequest request, Guid id)
        {
            return Task.FromResult(new StatusCodeResult(HttpStatusCode.MethodNotAllowed, this)
                .WithError("The allowed methods for this resource with the 'Test-StudentEducationOrganizationAssociation-Exclude-All-Addrs-Except-Physical' profile are GET, DELETE and OPTIONS."));
        }
    }
}
#endif
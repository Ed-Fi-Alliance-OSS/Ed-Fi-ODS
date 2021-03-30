using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Models.Requests;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Entities.Common.TPDM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AccreditationStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/accreditationStatusDescriptors")]
    public partial class AccreditationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor,
        Api.Common.Models.Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor,
        Entities.Common.TPDM.IAccreditationStatusDescriptor,
        Entities.NHibernate.AccreditationStatusDescriptorAggregate.TPDM.AccreditationStatusDescriptor,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample>
    {
        public AccreditationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample request, Entities.Common.TPDM.IAccreditationStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccreditationStatusDescriptorId = request.AccreditationStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.AidTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/aidTypeDescriptors")]
    public partial class AidTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor,
        Api.Common.Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor,
        Entities.Common.TPDM.IAidTypeDescriptor,
        Entities.NHibernate.AidTypeDescriptorAggregate.TPDM.AidTypeDescriptor,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorGetByExample>
    {
        public AidTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorGetByExample request, Entities.Common.TPDM.IAidTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AidTypeDescriptorId = request.AidTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicantProfiles
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applicantProfiles")]
    public partial class ApplicantProfilesController : DataManagementControllerBase<
        Api.Common.Models.Resources.ApplicantProfile.TPDM.ApplicantProfile,
        Api.Common.Models.Resources.ApplicantProfile.TPDM.ApplicantProfile,
        Entities.Common.TPDM.IApplicantProfile,
        Entities.NHibernate.ApplicantProfileAggregate.TPDM.ApplicantProfile,
        Api.Common.Models.Requests.TPDM.ApplicantProfiles.ApplicantProfilePut,
        Api.Common.Models.Requests.TPDM.ApplicantProfiles.ApplicantProfilePost,
        Api.Common.Models.Requests.TPDM.ApplicantProfiles.ApplicantProfileDelete,
        Api.Common.Models.Requests.TPDM.ApplicantProfiles.ApplicantProfileGetByExample>
    {
        public ApplicantProfilesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ApplicantProfiles.ApplicantProfileGetByExample request, Entities.Common.TPDM.IApplicantProfile specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantProfileIdentifier = request.ApplicantProfileIdentifier;
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.EconomicDisadvantaged = request.EconomicDisadvantaged;
            specification.FirstGenerationStudent = request.FirstGenerationStudent;
            specification.FirstName = request.FirstName;
            specification.GenderDescriptor = request.GenderDescriptor;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.SexDescriptor = request.SexDescriptor;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Applications
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applications")]
    public partial class ApplicationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Application.TPDM.Application,
        Api.Common.Models.Resources.Application.TPDM.Application,
        Entities.Common.TPDM.IApplication,
        Entities.NHibernate.ApplicationAggregate.TPDM.Application,
        Api.Common.Models.Requests.TPDM.Applications.ApplicationPut,
        Api.Common.Models.Requests.TPDM.Applications.ApplicationPost,
        Api.Common.Models.Requests.TPDM.Applications.ApplicationDelete,
        Api.Common.Models.Requests.TPDM.Applications.ApplicationGetByExample>
    {
        public ApplicationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Applications.ApplicationGetByExample request, Entities.Common.TPDM.IApplication specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AcceptedDate = request.AcceptedDate;
            specification.ApplicantProfileIdentifier = request.ApplicantProfileIdentifier;
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
            specification.RequisitionNumber = request.RequisitionNumber;
            specification.WithdrawDate = request.WithdrawDate;
            specification.WithdrawReasonDescriptor = request.WithdrawReasonDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applicationEvents")]
    public partial class ApplicationEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ApplicationEvent.TPDM.ApplicationEvent,
        Api.Common.Models.Resources.ApplicationEvent.TPDM.ApplicationEvent,
        Entities.Common.TPDM.IApplicationEvent,
        Entities.NHibernate.ApplicationEventAggregate.TPDM.ApplicationEvent,
        Api.Common.Models.Requests.TPDM.ApplicationEvents.ApplicationEventPut,
        Api.Common.Models.Requests.TPDM.ApplicationEvents.ApplicationEventPost,
        Api.Common.Models.Requests.TPDM.ApplicationEvents.ApplicationEventDelete,
        Api.Common.Models.Requests.TPDM.ApplicationEvents.ApplicationEventGetByExample>
    {
        public ApplicationEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ApplicationEvents.ApplicationEventGetByExample request, Entities.Common.TPDM.IApplicationEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantProfileIdentifier = request.ApplicantProfileIdentifier;
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationEventResultDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applicationEventResultDescriptors")]
    public partial class ApplicationEventResultDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor,
        Api.Common.Models.Resources.ApplicationEventResultDescriptor.TPDM.ApplicationEventResultDescriptor,
        Entities.Common.TPDM.IApplicationEventResultDescriptor,
        Entities.NHibernate.ApplicationEventResultDescriptorAggregate.TPDM.ApplicationEventResultDescriptor,
        Api.Common.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorPut,
        Api.Common.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorPost,
        Api.Common.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorGetByExample>
    {
        public ApplicationEventResultDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ApplicationEventResultDescriptors.ApplicationEventResultDescriptorGetByExample request, Entities.Common.TPDM.IApplicationEventResultDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationEventResultDescriptorId = request.ApplicationEventResultDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applicationEventTypeDescriptors")]
    public partial class ApplicationEventTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor,
        Api.Common.Models.Resources.ApplicationEventTypeDescriptor.TPDM.ApplicationEventTypeDescriptor,
        Entities.Common.TPDM.IApplicationEventTypeDescriptor,
        Entities.NHibernate.ApplicationEventTypeDescriptorAggregate.TPDM.ApplicationEventTypeDescriptor,
        Api.Common.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorGetByExample>
    {
        public ApplicationEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ApplicationEventTypeDescriptors.ApplicationEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IApplicationEventTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationEventTypeDescriptorId = request.ApplicationEventTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationSourceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applicationSourceDescriptors")]
    public partial class ApplicationSourceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor,
        Api.Common.Models.Resources.ApplicationSourceDescriptor.TPDM.ApplicationSourceDescriptor,
        Entities.Common.TPDM.IApplicationSourceDescriptor,
        Entities.NHibernate.ApplicationSourceDescriptorAggregate.TPDM.ApplicationSourceDescriptor,
        Api.Common.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorPut,
        Api.Common.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorPost,
        Api.Common.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorGetByExample>
    {
        public ApplicationSourceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ApplicationSourceDescriptors.ApplicationSourceDescriptorGetByExample request, Entities.Common.TPDM.IApplicationSourceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationSourceDescriptorId = request.ApplicationSourceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ApplicationStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/applicationStatusDescriptors")]
    public partial class ApplicationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor,
        Api.Common.Models.Resources.ApplicationStatusDescriptor.TPDM.ApplicationStatusDescriptor,
        Entities.Common.TPDM.IApplicationStatusDescriptor,
        Entities.NHibernate.ApplicationStatusDescriptorAggregate.TPDM.ApplicationStatusDescriptor,
        Api.Common.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorGetByExample>
    {
        public ApplicationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ApplicationStatusDescriptors.ApplicationStatusDescriptorGetByExample request, Entities.Common.TPDM.IApplicationStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicationStatusDescriptorId = request.ApplicationStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.BackgroundCheckStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/backgroundCheckStatusDescriptors")]
    public partial class BackgroundCheckStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor,
        Api.Common.Models.Resources.BackgroundCheckStatusDescriptor.TPDM.BackgroundCheckStatusDescriptor,
        Entities.Common.TPDM.IBackgroundCheckStatusDescriptor,
        Entities.NHibernate.BackgroundCheckStatusDescriptorAggregate.TPDM.BackgroundCheckStatusDescriptor,
        Api.Common.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorGetByExample>
    {
        public BackgroundCheckStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.BackgroundCheckStatusDescriptors.BackgroundCheckStatusDescriptorGetByExample request, Entities.Common.TPDM.IBackgroundCheckStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BackgroundCheckStatusDescriptorId = request.BackgroundCheckStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.BackgroundCheckTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/backgroundCheckTypeDescriptors")]
    public partial class BackgroundCheckTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor,
        Api.Common.Models.Resources.BackgroundCheckTypeDescriptor.TPDM.BackgroundCheckTypeDescriptor,
        Entities.Common.TPDM.IBackgroundCheckTypeDescriptor,
        Entities.NHibernate.BackgroundCheckTypeDescriptorAggregate.TPDM.BackgroundCheckTypeDescriptor,
        Api.Common.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorGetByExample>
    {
        public BackgroundCheckTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.BackgroundCheckTypeDescriptors.BackgroundCheckTypeDescriptorGetByExample request, Entities.Common.TPDM.IBackgroundCheckTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BackgroundCheckTypeDescriptorId = request.BackgroundCheckTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Candidates
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/candidates")]
    public partial class CandidatesController : DataManagementControllerBase<
        Api.Common.Models.Resources.Candidate.TPDM.Candidate,
        Api.Common.Models.Resources.Candidate.TPDM.Candidate,
        Entities.Common.TPDM.ICandidate,
        Entities.NHibernate.CandidateAggregate.TPDM.Candidate,
        Api.Common.Models.Requests.TPDM.Candidates.CandidatePut,
        Api.Common.Models.Requests.TPDM.Candidates.CandidatePost,
        Api.Common.Models.Requests.TPDM.Candidates.CandidateDelete,
        Api.Common.Models.Requests.TPDM.Candidates.CandidateGetByExample>
    {
        public CandidatesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Candidates.CandidateGetByExample request, Entities.Common.TPDM.ICandidate specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ApplicantProfileIdentifier = request.ApplicantProfileIdentifier;
            specification.ApplicationIdentifier = request.ApplicationIdentifier;
            specification.BirthCity = request.BirthCity;
            specification.BirthCountryDescriptor = request.BirthCountryDescriptor;
            specification.BirthDate = request.BirthDate;
            specification.BirthInternationalProvince = request.BirthInternationalProvince;
            specification.BirthSexDescriptor = request.BirthSexDescriptor;
            specification.BirthStateAbbreviationDescriptor = request.BirthStateAbbreviationDescriptor;
            specification.CandidateIdentifier = request.CandidateIdentifier;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.DateEnteredUS = request.DateEnteredUS;
            specification.DisplacementStatus = request.DisplacementStatus;
            specification.EconomicDisadvantaged = request.EconomicDisadvantaged;
            specification.EducationOrganizationId = request.EducationOrganizationId;
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
            specification.TuitionCost = request.TuitionCost;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CandidateCharacteristicDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/candidateCharacteristicDescriptors")]
    public partial class CandidateCharacteristicDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CandidateCharacteristicDescriptor.TPDM.CandidateCharacteristicDescriptor,
        Api.Common.Models.Resources.CandidateCharacteristicDescriptor.TPDM.CandidateCharacteristicDescriptor,
        Entities.Common.TPDM.ICandidateCharacteristicDescriptor,
        Entities.NHibernate.CandidateCharacteristicDescriptorAggregate.TPDM.CandidateCharacteristicDescriptor,
        Api.Common.Models.Requests.TPDM.CandidateCharacteristicDescriptors.CandidateCharacteristicDescriptorPut,
        Api.Common.Models.Requests.TPDM.CandidateCharacteristicDescriptors.CandidateCharacteristicDescriptorPost,
        Api.Common.Models.Requests.TPDM.CandidateCharacteristicDescriptors.CandidateCharacteristicDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CandidateCharacteristicDescriptors.CandidateCharacteristicDescriptorGetByExample>
    {
        public CandidateCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CandidateCharacteristicDescriptors.CandidateCharacteristicDescriptorGetByExample request, Entities.Common.TPDM.ICandidateCharacteristicDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CandidateCharacteristicDescriptorId = request.CandidateCharacteristicDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CandidateEducatorPreparationProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/candidateEducatorPreparationProgramAssociations")]
    public partial class CandidateEducatorPreparationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CandidateEducatorPreparationProgramAssociation.TPDM.CandidateEducatorPreparationProgramAssociation,
        Api.Common.Models.Resources.CandidateEducatorPreparationProgramAssociation.TPDM.CandidateEducatorPreparationProgramAssociation,
        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation,
        Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociation,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationPut,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationPost,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationDelete,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationGetByExample>
    {
        public CandidateEducatorPreparationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationGetByExample request, Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CandidateIdentifier = request.CandidateIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.EPPProgramPathwayDescriptor = request.EPPProgramPathwayDescriptor;
            specification.Id = request.Id;
            specification.MajorSpecialization = request.MajorSpecialization;
            specification.MinorSpecialization = request.MinorSpecialization;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.ReasonExitedDescriptor = request.ReasonExitedDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CandidateRelationshipToStaffAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/candidateRelationshipToStaffAssociations")]
    public partial class CandidateRelationshipToStaffAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CandidateRelationshipToStaffAssociation.TPDM.CandidateRelationshipToStaffAssociation,
        Api.Common.Models.Resources.CandidateRelationshipToStaffAssociation.TPDM.CandidateRelationshipToStaffAssociation,
        Entities.Common.TPDM.ICandidateRelationshipToStaffAssociation,
        Entities.NHibernate.CandidateRelationshipToStaffAssociationAggregate.TPDM.CandidateRelationshipToStaffAssociation,
        Api.Common.Models.Requests.TPDM.CandidateRelationshipToStaffAssociations.CandidateRelationshipToStaffAssociationPut,
        Api.Common.Models.Requests.TPDM.CandidateRelationshipToStaffAssociations.CandidateRelationshipToStaffAssociationPost,
        Api.Common.Models.Requests.TPDM.CandidateRelationshipToStaffAssociations.CandidateRelationshipToStaffAssociationDelete,
        Api.Common.Models.Requests.TPDM.CandidateRelationshipToStaffAssociations.CandidateRelationshipToStaffAssociationGetByExample>
    {
        public CandidateRelationshipToStaffAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CandidateRelationshipToStaffAssociations.CandidateRelationshipToStaffAssociationGetByExample request, Entities.Common.TPDM.ICandidateRelationshipToStaffAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CandidateIdentifier = request.CandidateIdentifier;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.StaffToCandidateRelationshipDescriptor = request.StaffToCandidateRelationshipDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Certifications
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certifications")]
    public partial class CertificationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Certification.TPDM.Certification,
        Api.Common.Models.Resources.Certification.TPDM.Certification,
        Entities.Common.TPDM.ICertification,
        Entities.NHibernate.CertificationAggregate.TPDM.Certification,
        Api.Common.Models.Requests.TPDM.Certifications.CertificationPut,
        Api.Common.Models.Requests.TPDM.Certifications.CertificationPost,
        Api.Common.Models.Requests.TPDM.Certifications.CertificationDelete,
        Api.Common.Models.Requests.TPDM.Certifications.CertificationGetByExample>
    {
        public CertificationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Certifications.CertificationGetByExample request, Entities.Common.TPDM.ICertification specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExams
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationExams")]
    public partial class CertificationExamsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationExam.TPDM.CertificationExam,
        Api.Common.Models.Resources.CertificationExam.TPDM.CertificationExam,
        Entities.Common.TPDM.ICertificationExam,
        Entities.NHibernate.CertificationExamAggregate.TPDM.CertificationExam,
        Api.Common.Models.Requests.TPDM.CertificationExams.CertificationExamPut,
        Api.Common.Models.Requests.TPDM.CertificationExams.CertificationExamPost,
        Api.Common.Models.Requests.TPDM.CertificationExams.CertificationExamDelete,
        Api.Common.Models.Requests.TPDM.CertificationExams.CertificationExamGetByExample>
    {
        public CertificationExamsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationExams.CertificationExamGetByExample request, Entities.Common.TPDM.ICertificationExam specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExamResults
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationExamResults")]
    public partial class CertificationExamResultsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationExamResult.TPDM.CertificationExamResult,
        Api.Common.Models.Resources.CertificationExamResult.TPDM.CertificationExamResult,
        Entities.Common.TPDM.ICertificationExamResult,
        Entities.NHibernate.CertificationExamResultAggregate.TPDM.CertificationExamResult,
        Api.Common.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultPut,
        Api.Common.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultPost,
        Api.Common.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultDelete,
        Api.Common.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultGetByExample>
    {
        public CertificationExamResultsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationExamResults.CertificationExamResultGetByExample request, Entities.Common.TPDM.ICertificationExamResult specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExamStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationExamStatusDescriptors")]
    public partial class CertificationExamStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor,
        Api.Common.Models.Resources.CertificationExamStatusDescriptor.TPDM.CertificationExamStatusDescriptor,
        Entities.Common.TPDM.ICertificationExamStatusDescriptor,
        Entities.NHibernate.CertificationExamStatusDescriptorAggregate.TPDM.CertificationExamStatusDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorGetByExample>
    {
        public CertificationExamStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationExamStatusDescriptors.CertificationExamStatusDescriptorGetByExample request, Entities.Common.TPDM.ICertificationExamStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationExamStatusDescriptorId = request.CertificationExamStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationExamTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationExamTypeDescriptors")]
    public partial class CertificationExamTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor,
        Api.Common.Models.Resources.CertificationExamTypeDescriptor.TPDM.CertificationExamTypeDescriptor,
        Entities.Common.TPDM.ICertificationExamTypeDescriptor,
        Entities.NHibernate.CertificationExamTypeDescriptorAggregate.TPDM.CertificationExamTypeDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorGetByExample>
    {
        public CertificationExamTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationExamTypeDescriptors.CertificationExamTypeDescriptorGetByExample request, Entities.Common.TPDM.ICertificationExamTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationExamTypeDescriptorId = request.CertificationExamTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationFieldDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationFieldDescriptors")]
    public partial class CertificationFieldDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor,
        Api.Common.Models.Resources.CertificationFieldDescriptor.TPDM.CertificationFieldDescriptor,
        Entities.Common.TPDM.ICertificationFieldDescriptor,
        Entities.NHibernate.CertificationFieldDescriptorAggregate.TPDM.CertificationFieldDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorGetByExample>
    {
        public CertificationFieldDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationFieldDescriptors.CertificationFieldDescriptorGetByExample request, Entities.Common.TPDM.ICertificationFieldDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationFieldDescriptorId = request.CertificationFieldDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationLevelDescriptors")]
    public partial class CertificationLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor,
        Api.Common.Models.Resources.CertificationLevelDescriptor.TPDM.CertificationLevelDescriptor,
        Entities.Common.TPDM.ICertificationLevelDescriptor,
        Entities.NHibernate.CertificationLevelDescriptorAggregate.TPDM.CertificationLevelDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorGetByExample>
    {
        public CertificationLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationLevelDescriptors.CertificationLevelDescriptorGetByExample request, Entities.Common.TPDM.ICertificationLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationLevelDescriptorId = request.CertificationLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationRouteDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationRouteDescriptors")]
    public partial class CertificationRouteDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor,
        Api.Common.Models.Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor,
        Entities.Common.TPDM.ICertificationRouteDescriptor,
        Entities.NHibernate.CertificationRouteDescriptorAggregate.TPDM.CertificationRouteDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample>
    {
        public CertificationRouteDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample request, Entities.Common.TPDM.ICertificationRouteDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationRouteDescriptorId = request.CertificationRouteDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationStandardDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationStandardDescriptors")]
    public partial class CertificationStandardDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor,
        Api.Common.Models.Resources.CertificationStandardDescriptor.TPDM.CertificationStandardDescriptor,
        Entities.Common.TPDM.ICertificationStandardDescriptor,
        Entities.NHibernate.CertificationStandardDescriptorAggregate.TPDM.CertificationStandardDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorGetByExample>
    {
        public CertificationStandardDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CertificationStandardDescriptors.CertificationStandardDescriptorGetByExample request, Entities.Common.TPDM.ICertificationStandardDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationStandardDescriptorId = request.CertificationStandardDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CoteachingStyleObservedDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/coteachingStyleObservedDescriptors")]
    public partial class CoteachingStyleObservedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor,
        Api.Common.Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor,
        Entities.Common.TPDM.ICoteachingStyleObservedDescriptor,
        Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.TPDM.CoteachingStyleObservedDescriptor,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPut,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPost,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample>
    {
        public CoteachingStyleObservedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample request, Entities.Common.TPDM.ICoteachingStyleObservedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CoteachingStyleObservedDescriptorId = request.CoteachingStyleObservedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/credentialEvents")]
    public partial class CredentialEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialEvent.TPDM.CredentialEvent,
        Api.Common.Models.Resources.CredentialEvent.TPDM.CredentialEvent,
        Entities.Common.TPDM.ICredentialEvent,
        Entities.NHibernate.CredentialEventAggregate.TPDM.CredentialEvent,
        Api.Common.Models.Requests.TPDM.CredentialEvents.CredentialEventPut,
        Api.Common.Models.Requests.TPDM.CredentialEvents.CredentialEventPost,
        Api.Common.Models.Requests.TPDM.CredentialEvents.CredentialEventDelete,
        Api.Common.Models.Requests.TPDM.CredentialEvents.CredentialEventGetByExample>
    {
        public CredentialEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CredentialEvents.CredentialEventGetByExample request, Entities.Common.TPDM.ICredentialEvent specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/credentialEventTypeDescriptors")]
    public partial class CredentialEventTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor,
        Api.Common.Models.Resources.CredentialEventTypeDescriptor.TPDM.CredentialEventTypeDescriptor,
        Entities.Common.TPDM.ICredentialEventTypeDescriptor,
        Entities.NHibernate.CredentialEventTypeDescriptorAggregate.TPDM.CredentialEventTypeDescriptor,
        Api.Common.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorGetByExample>
    {
        public CredentialEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CredentialEventTypeDescriptors.CredentialEventTypeDescriptorGetByExample request, Entities.Common.TPDM.ICredentialEventTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialEventTypeDescriptorId = request.CredentialEventTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/credentialStatusDescriptors")]
    public partial class CredentialStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor,
        Api.Common.Models.Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor,
        Entities.Common.TPDM.ICredentialStatusDescriptor,
        Entities.NHibernate.CredentialStatusDescriptorAggregate.TPDM.CredentialStatusDescriptor,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample>
    {
        public CredentialStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample request, Entities.Common.TPDM.ICredentialStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialStatusDescriptorId = request.CredentialStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.DegreeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/degreeDescriptors")]
    public partial class DegreeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DegreeDescriptor.TPDM.DegreeDescriptor,
        Api.Common.Models.Resources.DegreeDescriptor.TPDM.DegreeDescriptor,
        Entities.Common.TPDM.IDegreeDescriptor,
        Entities.NHibernate.DegreeDescriptorAggregate.TPDM.DegreeDescriptor,
        Api.Common.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorPut,
        Api.Common.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorPost,
        Api.Common.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorGetByExample>
    {
        public DegreeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.DegreeDescriptors.DegreeDescriptorGetByExample request, Entities.Common.TPDM.IDegreeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DegreeDescriptorId = request.DegreeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducatorPreparationPrograms
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/educatorPreparationPrograms")]
    public partial class EducatorPreparationProgramsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorPreparationProgram.TPDM.EducatorPreparationProgram,
        Api.Common.Models.Resources.EducatorPreparationProgram.TPDM.EducatorPreparationProgram,
        Entities.Common.TPDM.IEducatorPreparationProgram,
        Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgram,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramPut,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramPost,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramDelete,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramGetByExample>
    {
        public EducatorPreparationProgramsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramGetByExample request, Entities.Common.TPDM.IEducatorPreparationProgram specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccreditationStatusDescriptor = request.AccreditationStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EducatorPreparationProgramTypeDescriptor = request.EducatorPreparationProgramTypeDescriptor;
            specification.Id = request.Id;
            specification.ProgramId = request.ProgramId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducatorPreparationProgramTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/educatorPreparationProgramTypeDescriptors")]
    public partial class EducatorPreparationProgramTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorPreparationProgramTypeDescriptor.TPDM.EducatorPreparationProgramTypeDescriptor,
        Api.Common.Models.Resources.EducatorPreparationProgramTypeDescriptor.TPDM.EducatorPreparationProgramTypeDescriptor,
        Entities.Common.TPDM.IEducatorPreparationProgramTypeDescriptor,
        Entities.NHibernate.EducatorPreparationProgramTypeDescriptorAggregate.TPDM.EducatorPreparationProgramTypeDescriptor,
        Api.Common.Models.Requests.TPDM.EducatorPreparationProgramTypeDescriptors.EducatorPreparationProgramTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.EducatorPreparationProgramTypeDescriptors.EducatorPreparationProgramTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.EducatorPreparationProgramTypeDescriptors.EducatorPreparationProgramTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EducatorPreparationProgramTypeDescriptors.EducatorPreparationProgramTypeDescriptorGetByExample>
    {
        public EducatorPreparationProgramTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EducatorPreparationProgramTypeDescriptors.EducatorPreparationProgramTypeDescriptorGetByExample request, Entities.Common.TPDM.IEducatorPreparationProgramTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducatorPreparationProgramTypeDescriptorId = request.EducatorPreparationProgramTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducatorRoleDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/educatorRoleDescriptors")]
    public partial class EducatorRoleDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor,
        Api.Common.Models.Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor,
        Entities.Common.TPDM.IEducatorRoleDescriptor,
        Entities.NHibernate.EducatorRoleDescriptorAggregate.TPDM.EducatorRoleDescriptor,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorPut,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorPost,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample>
    {
        public EducatorRoleDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample request, Entities.Common.TPDM.IEducatorRoleDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducatorRoleDescriptorId = request.EducatorRoleDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EnglishLanguageExamDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/englishLanguageExamDescriptors")]
    public partial class EnglishLanguageExamDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor,
        Api.Common.Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor,
        Entities.Common.TPDM.IEnglishLanguageExamDescriptor,
        Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.TPDM.EnglishLanguageExamDescriptor,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPut,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPost,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample>
    {
        public EnglishLanguageExamDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample request, Entities.Common.TPDM.IEnglishLanguageExamDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EnglishLanguageExamDescriptorId = request.EnglishLanguageExamDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EPPDegreeTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/eppDegreeTypeDescriptors")]
    public partial class EPPDegreeTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EPPDegreeTypeDescriptor.TPDM.EPPDegreeTypeDescriptor,
        Api.Common.Models.Resources.EPPDegreeTypeDescriptor.TPDM.EPPDegreeTypeDescriptor,
        Entities.Common.TPDM.IEPPDegreeTypeDescriptor,
        Entities.NHibernate.EPPDegreeTypeDescriptorAggregate.TPDM.EPPDegreeTypeDescriptor,
        Api.Common.Models.Requests.TPDM.EPPDegreeTypeDescriptors.EPPDegreeTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.EPPDegreeTypeDescriptors.EPPDegreeTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.EPPDegreeTypeDescriptors.EPPDegreeTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EPPDegreeTypeDescriptors.EPPDegreeTypeDescriptorGetByExample>
    {
        public EPPDegreeTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EPPDegreeTypeDescriptors.EPPDegreeTypeDescriptorGetByExample request, Entities.Common.TPDM.IEPPDegreeTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EPPDegreeTypeDescriptorId = request.EPPDegreeTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EPPProgramPathwayDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/eppProgramPathwayDescriptors")]
    public partial class EPPProgramPathwayDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EPPProgramPathwayDescriptor.TPDM.EPPProgramPathwayDescriptor,
        Api.Common.Models.Resources.EPPProgramPathwayDescriptor.TPDM.EPPProgramPathwayDescriptor,
        Entities.Common.TPDM.IEPPProgramPathwayDescriptor,
        Entities.NHibernate.EPPProgramPathwayDescriptorAggregate.TPDM.EPPProgramPathwayDescriptor,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorPut,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorPost,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorGetByExample>
    {
        public EPPProgramPathwayDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorGetByExample request, Entities.Common.TPDM.IEPPProgramPathwayDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EPPProgramPathwayDescriptorId = request.EPPProgramPathwayDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Evaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluations")]
    public partial class EvaluationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Evaluation.TPDM.Evaluation,
        Api.Common.Models.Resources.Evaluation.TPDM.Evaluation,
        Entities.Common.TPDM.IEvaluation,
        Entities.NHibernate.EvaluationAggregate.TPDM.Evaluation,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationPut,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationPost,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationDelete,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationGetByExample>
    {
        public EvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Evaluations.EvaluationGetByExample request, Entities.Common.TPDM.IEvaluation specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElements
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationElements")]
    public partial class EvaluationElementsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElement.TPDM.EvaluationElement,
        Api.Common.Models.Resources.EvaluationElement.TPDM.EvaluationElement,
        Entities.Common.TPDM.IEvaluationElement,
        Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElement,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementPut,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementPost,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementDelete,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementGetByExample>
    {
        public EvaluationElementsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementGetByExample request, Entities.Common.TPDM.IEvaluationElement specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElementRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationElementRatings")]
    public partial class EvaluationElementRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElementRating.TPDM.EvaluationElementRating,
        Api.Common.Models.Resources.EvaluationElementRating.TPDM.EvaluationElementRating,
        Entities.Common.TPDM.IEvaluationElementRating,
        Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRating,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingPut,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingPost,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingDelete,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingGetByExample>
    {
        public EvaluationElementRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingGetByExample request, Entities.Common.TPDM.IEvaluationElementRating specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElementRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationElementRatingLevelDescriptors")]
    public partial class EvaluationElementRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor,
        Api.Common.Models.Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor,
        Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor,
        Entities.NHibernate.EvaluationElementRatingLevelDescriptorAggregate.TPDM.EvaluationElementRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample>
    {
        public EvaluationElementRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationElementRatingLevelDescriptorId = request.EvaluationElementRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationObjectives
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationObjectives")]
    public partial class EvaluationObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationObjective.TPDM.EvaluationObjective,
        Api.Common.Models.Resources.EvaluationObjective.TPDM.EvaluationObjective,
        Entities.Common.TPDM.IEvaluationObjective,
        Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjective,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectivePut,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectivePost,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveDelete,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveGetByExample>
    {
        public EvaluationObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveGetByExample request, Entities.Common.TPDM.IEvaluationObjective specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationObjectiveRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationObjectiveRatings")]
    public partial class EvaluationObjectiveRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating,
        Api.Common.Models.Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating,
        Entities.Common.TPDM.IEvaluationObjectiveRating,
        Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRating,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingPut,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingPost,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingDelete,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample>
    {
        public EvaluationObjectiveRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample request, Entities.Common.TPDM.IEvaluationObjectiveRating specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationPeriodDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationPeriodDescriptors")]
    public partial class EvaluationPeriodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor,
        Api.Common.Models.Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor,
        Entities.Common.TPDM.IEvaluationPeriodDescriptor,
        Entities.NHibernate.EvaluationPeriodDescriptorAggregate.TPDM.EvaluationPeriodDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample>
    {
        public EvaluationPeriodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationPeriodDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationPeriodDescriptorId = request.EvaluationPeriodDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationRatings")]
    public partial class EvaluationRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRating.TPDM.EvaluationRating,
        Api.Common.Models.Resources.EvaluationRating.TPDM.EvaluationRating,
        Entities.Common.TPDM.IEvaluationRating,
        Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRating,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingPut,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingPost,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingDelete,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingGetByExample>
    {
        public EvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingGetByExample request, Entities.Common.TPDM.IEvaluationRating specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationRatingLevelDescriptors")]
    public partial class EvaluationRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor,
        Api.Common.Models.Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IEvaluationRatingLevelDescriptor,
        Entities.NHibernate.EvaluationRatingLevelDescriptorAggregate.TPDM.EvaluationRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample>
    {
        public EvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationRatingLevelDescriptorId = request.EvaluationRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationTypeDescriptors")]
    public partial class EvaluationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor,
        Api.Common.Models.Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor,
        Entities.Common.TPDM.IEvaluationTypeDescriptor,
        Entities.NHibernate.EvaluationTypeDescriptorAggregate.TPDM.EvaluationTypeDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample>
    {
        public EvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationTypeDescriptorId = request.EvaluationTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FederalLocaleCodeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/federalLocaleCodeDescriptors")]
    public partial class FederalLocaleCodeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor,
        Api.Common.Models.Resources.FederalLocaleCodeDescriptor.TPDM.FederalLocaleCodeDescriptor,
        Entities.Common.TPDM.IFederalLocaleCodeDescriptor,
        Entities.NHibernate.FederalLocaleCodeDescriptorAggregate.TPDM.FederalLocaleCodeDescriptor,
        Api.Common.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorPut,
        Api.Common.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorPost,
        Api.Common.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorGetByExample>
    {
        public FederalLocaleCodeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.FederalLocaleCodeDescriptors.FederalLocaleCodeDescriptorGetByExample request, Entities.Common.TPDM.IFederalLocaleCodeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FederalLocaleCodeDescriptorId = request.FederalLocaleCodeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FieldworkExperiences
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/fieldworkExperiences")]
    public partial class FieldworkExperiencesController : DataManagementControllerBase<
        Api.Common.Models.Resources.FieldworkExperience.TPDM.FieldworkExperience,
        Api.Common.Models.Resources.FieldworkExperience.TPDM.FieldworkExperience,
        Entities.Common.TPDM.IFieldworkExperience,
        Entities.NHibernate.FieldworkExperienceAggregate.TPDM.FieldworkExperience,
        Api.Common.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperiencePut,
        Api.Common.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperiencePost,
        Api.Common.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperienceDelete,
        Api.Common.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperienceGetByExample>
    {
        public FieldworkExperiencesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.FieldworkExperiences.FieldworkExperienceGetByExample request, Entities.Common.TPDM.IFieldworkExperience specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.FieldworkIdentifier = request.FieldworkIdentifier;
            specification.FieldworkTypeDescriptor = request.FieldworkTypeDescriptor;
            specification.HoursCompleted = request.HoursCompleted;
            specification.Id = request.Id;
            specification.ProgramGatewayDescriptor = request.ProgramGatewayDescriptor;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FieldworkExperienceSectionAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/fieldworkExperienceSectionAssociations")]
    public partial class FieldworkExperienceSectionAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation,
        Api.Common.Models.Resources.FieldworkExperienceSectionAssociation.TPDM.FieldworkExperienceSectionAssociation,
        Entities.Common.TPDM.IFieldworkExperienceSectionAssociation,
        Entities.NHibernate.FieldworkExperienceSectionAssociationAggregate.TPDM.FieldworkExperienceSectionAssociation,
        Api.Common.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationPut,
        Api.Common.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationPost,
        Api.Common.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationDelete,
        Api.Common.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationGetByExample>
    {
        public FieldworkExperienceSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.FieldworkExperienceSectionAssociations.FieldworkExperienceSectionAssociationGetByExample request, Entities.Common.TPDM.IFieldworkExperienceSectionAssociation specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FieldworkTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/fieldworkTypeDescriptors")]
    public partial class FieldworkTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor,
        Api.Common.Models.Resources.FieldworkTypeDescriptor.TPDM.FieldworkTypeDescriptor,
        Entities.Common.TPDM.IFieldworkTypeDescriptor,
        Entities.NHibernate.FieldworkTypeDescriptorAggregate.TPDM.FieldworkTypeDescriptor,
        Api.Common.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorGetByExample>
    {
        public FieldworkTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.FieldworkTypeDescriptors.FieldworkTypeDescriptorGetByExample request, Entities.Common.TPDM.IFieldworkTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FieldworkTypeDescriptorId = request.FieldworkTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FundingSourceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/fundingSourceDescriptors")]
    public partial class FundingSourceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor,
        Api.Common.Models.Resources.FundingSourceDescriptor.TPDM.FundingSourceDescriptor,
        Entities.Common.TPDM.IFundingSourceDescriptor,
        Entities.NHibernate.FundingSourceDescriptorAggregate.TPDM.FundingSourceDescriptor,
        Api.Common.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorPut,
        Api.Common.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorPost,
        Api.Common.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorDelete,
        Api.Common.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorGetByExample>
    {
        public FundingSourceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.FundingSourceDescriptors.FundingSourceDescriptorGetByExample request, Entities.Common.TPDM.IFundingSourceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FundingSourceDescriptorId = request.FundingSourceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.GenderDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/genderDescriptors")]
    public partial class GenderDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GenderDescriptor.TPDM.GenderDescriptor,
        Api.Common.Models.Resources.GenderDescriptor.TPDM.GenderDescriptor,
        Entities.Common.TPDM.IGenderDescriptor,
        Entities.NHibernate.GenderDescriptorAggregate.TPDM.GenderDescriptor,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorPut,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorPost,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorDelete,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorGetByExample>
    {
        public GenderDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorGetByExample request, Entities.Common.TPDM.IGenderDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GenderDescriptorId = request.GenderDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Goals
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/goals")]
    public partial class GoalsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Goal.TPDM.Goal,
        Api.Common.Models.Resources.Goal.TPDM.Goal,
        Entities.Common.TPDM.IGoal,
        Entities.NHibernate.GoalAggregate.TPDM.Goal,
        Api.Common.Models.Requests.TPDM.Goals.GoalPut,
        Api.Common.Models.Requests.TPDM.Goals.GoalPost,
        Api.Common.Models.Requests.TPDM.Goals.GoalDelete,
        Api.Common.Models.Requests.TPDM.Goals.GoalGetByExample>
    {
        public GoalsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Goals.GoalGetByExample request, Entities.Common.TPDM.IGoal specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.GoalTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/goalTypeDescriptors")]
    public partial class GoalTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor,
        Api.Common.Models.Resources.GoalTypeDescriptor.TPDM.GoalTypeDescriptor,
        Entities.Common.TPDM.IGoalTypeDescriptor,
        Entities.NHibernate.GoalTypeDescriptorAggregate.TPDM.GoalTypeDescriptor,
        Api.Common.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorGetByExample>
    {
        public GoalTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.GoalTypeDescriptors.GoalTypeDescriptorGetByExample request, Entities.Common.TPDM.IGoalTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GoalTypeDescriptorId = request.GoalTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.HireStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/hireStatusDescriptors")]
    public partial class HireStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor,
        Api.Common.Models.Resources.HireStatusDescriptor.TPDM.HireStatusDescriptor,
        Entities.Common.TPDM.IHireStatusDescriptor,
        Entities.NHibernate.HireStatusDescriptorAggregate.TPDM.HireStatusDescriptor,
        Api.Common.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorGetByExample>
    {
        public HireStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.HireStatusDescriptors.HireStatusDescriptorGetByExample request, Entities.Common.TPDM.IHireStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HireStatusDescriptorId = request.HireStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.HiringSourceDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/hiringSourceDescriptors")]
    public partial class HiringSourceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor,
        Api.Common.Models.Resources.HiringSourceDescriptor.TPDM.HiringSourceDescriptor,
        Entities.Common.TPDM.IHiringSourceDescriptor,
        Entities.NHibernate.HiringSourceDescriptorAggregate.TPDM.HiringSourceDescriptor,
        Api.Common.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorPut,
        Api.Common.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorPost,
        Api.Common.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorDelete,
        Api.Common.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorGetByExample>
    {
        public HiringSourceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.HiringSourceDescriptors.HiringSourceDescriptorGetByExample request, Entities.Common.TPDM.IHiringSourceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HiringSourceDescriptorId = request.HiringSourceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.InstructionalSettingDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/instructionalSettingDescriptors")]
    public partial class InstructionalSettingDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor,
        Api.Common.Models.Resources.InstructionalSettingDescriptor.TPDM.InstructionalSettingDescriptor,
        Entities.Common.TPDM.IInstructionalSettingDescriptor,
        Entities.NHibernate.InstructionalSettingDescriptorAggregate.TPDM.InstructionalSettingDescriptor,
        Api.Common.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorPut,
        Api.Common.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorPost,
        Api.Common.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorDelete,
        Api.Common.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorGetByExample>
    {
        public InstructionalSettingDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.InstructionalSettingDescriptors.InstructionalSettingDescriptorGetByExample request, Entities.Common.TPDM.IInstructionalSettingDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InstructionalSettingDescriptorId = request.InstructionalSettingDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.LengthOfContractDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/lengthOfContractDescriptors")]
    public partial class LengthOfContractDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LengthOfContractDescriptor.TPDM.LengthOfContractDescriptor,
        Api.Common.Models.Resources.LengthOfContractDescriptor.TPDM.LengthOfContractDescriptor,
        Entities.Common.TPDM.ILengthOfContractDescriptor,
        Entities.NHibernate.LengthOfContractDescriptorAggregate.TPDM.LengthOfContractDescriptor,
        Api.Common.Models.Requests.TPDM.LengthOfContractDescriptors.LengthOfContractDescriptorPut,
        Api.Common.Models.Requests.TPDM.LengthOfContractDescriptors.LengthOfContractDescriptorPost,
        Api.Common.Models.Requests.TPDM.LengthOfContractDescriptors.LengthOfContractDescriptorDelete,
        Api.Common.Models.Requests.TPDM.LengthOfContractDescriptors.LengthOfContractDescriptorGetByExample>
    {
        public LengthOfContractDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.LengthOfContractDescriptors.LengthOfContractDescriptorGetByExample request, Entities.Common.TPDM.ILengthOfContractDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LengthOfContractDescriptorId = request.LengthOfContractDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ObjectiveRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/objectiveRatingLevelDescriptors")]
    public partial class ObjectiveRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor,
        Api.Common.Models.Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor,
        Entities.Common.TPDM.IObjectiveRatingLevelDescriptor,
        Entities.NHibernate.ObjectiveRatingLevelDescriptorAggregate.TPDM.ObjectiveRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample>
    {
        public ObjectiveRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IObjectiveRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ObjectiveRatingLevelDescriptorId = request.ObjectiveRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/openStaffPositionEvents")]
    public partial class OpenStaffPositionEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent,
        Api.Common.Models.Resources.OpenStaffPositionEvent.TPDM.OpenStaffPositionEvent,
        Entities.Common.TPDM.IOpenStaffPositionEvent,
        Entities.NHibernate.OpenStaffPositionEventAggregate.TPDM.OpenStaffPositionEvent,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventPut,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventPost,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventDelete,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventGetByExample>
    {
        public OpenStaffPositionEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.OpenStaffPositionEvents.OpenStaffPositionEventGetByExample request, Entities.Common.TPDM.IOpenStaffPositionEvent specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionEventStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/openStaffPositionEventStatusDescriptors")]
    public partial class OpenStaffPositionEventStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor,
        Api.Common.Models.Resources.OpenStaffPositionEventStatusDescriptor.TPDM.OpenStaffPositionEventStatusDescriptor,
        Entities.Common.TPDM.IOpenStaffPositionEventStatusDescriptor,
        Entities.NHibernate.OpenStaffPositionEventStatusDescriptorAggregate.TPDM.OpenStaffPositionEventStatusDescriptor,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorGetByExample>
    {
        public OpenStaffPositionEventStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.OpenStaffPositionEventStatusDescriptors.OpenStaffPositionEventStatusDescriptorGetByExample request, Entities.Common.TPDM.IOpenStaffPositionEventStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OpenStaffPositionEventStatusDescriptorId = request.OpenStaffPositionEventStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/openStaffPositionEventTypeDescriptors")]
    public partial class OpenStaffPositionEventTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor,
        Api.Common.Models.Resources.OpenStaffPositionEventTypeDescriptor.TPDM.OpenStaffPositionEventTypeDescriptor,
        Entities.Common.TPDM.IOpenStaffPositionEventTypeDescriptor,
        Entities.NHibernate.OpenStaffPositionEventTypeDescriptorAggregate.TPDM.OpenStaffPositionEventTypeDescriptor,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorGetByExample>
    {
        public OpenStaffPositionEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.OpenStaffPositionEventTypeDescriptors.OpenStaffPositionEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IOpenStaffPositionEventTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OpenStaffPositionEventTypeDescriptorId = request.OpenStaffPositionEventTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.OpenStaffPositionReasonDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/openStaffPositionReasonDescriptors")]
    public partial class OpenStaffPositionReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor,
        Api.Common.Models.Resources.OpenStaffPositionReasonDescriptor.TPDM.OpenStaffPositionReasonDescriptor,
        Entities.Common.TPDM.IOpenStaffPositionReasonDescriptor,
        Entities.NHibernate.OpenStaffPositionReasonDescriptorAggregate.TPDM.OpenStaffPositionReasonDescriptor,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorPut,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorPost,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorDelete,
        Api.Common.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorGetByExample>
    {
        public OpenStaffPositionReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.OpenStaffPositionReasonDescriptors.OpenStaffPositionReasonDescriptorGetByExample request, Entities.Common.TPDM.IOpenStaffPositionReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OpenStaffPositionReasonDescriptorId = request.OpenStaffPositionReasonDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluations")]
    public partial class PerformanceEvaluationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation,
        Api.Common.Models.Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation,
        Entities.Common.TPDM.IPerformanceEvaluation,
        Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluation,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationGetByExample>
    {
        public PerformanceEvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationGetByExample request, Entities.Common.TPDM.IPerformanceEvaluation specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluationRatings")]
    public partial class PerformanceEvaluationRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating,
        Api.Common.Models.Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating,
        Entities.Common.TPDM.IPerformanceEvaluationRating,
        Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRating,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample>
    {
        public PerformanceEvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample request, Entities.Common.TPDM.IPerformanceEvaluationRating specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluationRatingLevelDescriptors")]
    public partial class PerformanceEvaluationRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Api.Common.Models.Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor,
        Entities.NHibernate.PerformanceEvaluationRatingLevelDescriptorAggregate.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample>
    {
        public PerformanceEvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceEvaluationRatingLevelDescriptorId = request.PerformanceEvaluationRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluationTypeDescriptors")]
    public partial class PerformanceEvaluationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor,
        Api.Common.Models.Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor,
        Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor,
        Entities.NHibernate.PerformanceEvaluationTypeDescriptorAggregate.TPDM.PerformanceEvaluationTypeDescriptor,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample>
    {
        public PerformanceEvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample request, Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceEvaluationTypeDescriptorId = request.PerformanceEvaluationTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PreviousCareerDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/previousCareerDescriptors")]
    public partial class PreviousCareerDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor,
        Api.Common.Models.Resources.PreviousCareerDescriptor.TPDM.PreviousCareerDescriptor,
        Entities.Common.TPDM.IPreviousCareerDescriptor,
        Entities.NHibernate.PreviousCareerDescriptorAggregate.TPDM.PreviousCareerDescriptor,
        Api.Common.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorPut,
        Api.Common.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorPost,
        Api.Common.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorDelete,
        Api.Common.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorGetByExample>
    {
        public PreviousCareerDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.PreviousCareerDescriptors.PreviousCareerDescriptorGetByExample request, Entities.Common.TPDM.IPreviousCareerDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PreviousCareerDescriptorId = request.PreviousCareerDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProfessionalDevelopmentEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/professionalDevelopmentEvents")]
    public partial class ProfessionalDevelopmentEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent,
        Api.Common.Models.Resources.ProfessionalDevelopmentEvent.TPDM.ProfessionalDevelopmentEvent,
        Entities.Common.TPDM.IProfessionalDevelopmentEvent,
        Entities.NHibernate.ProfessionalDevelopmentEventAggregate.TPDM.ProfessionalDevelopmentEvent,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventPut,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventPost,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventDelete,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventGetByExample>
    {
        public ProfessionalDevelopmentEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEvents.ProfessionalDevelopmentEventGetByExample request, Entities.Common.TPDM.IProfessionalDevelopmentEvent specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProfessionalDevelopmentEventAttendances
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/professionalDevelopmentEventAttendances")]
    public partial class ProfessionalDevelopmentEventAttendancesController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance,
        Api.Common.Models.Resources.ProfessionalDevelopmentEventAttendance.TPDM.ProfessionalDevelopmentEventAttendance,
        Entities.Common.TPDM.IProfessionalDevelopmentEventAttendance,
        Entities.NHibernate.ProfessionalDevelopmentEventAttendanceAggregate.TPDM.ProfessionalDevelopmentEventAttendance,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendancePut,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendancePost,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendanceDelete,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendanceGetByExample>
    {
        public ProfessionalDevelopmentEventAttendancesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentEventAttendances.ProfessionalDevelopmentEventAttendanceGetByExample request, Entities.Common.TPDM.IProfessionalDevelopmentEventAttendance specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProfessionalDevelopmentOfferedByDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/professionalDevelopmentOfferedByDescriptors")]
    public partial class ProfessionalDevelopmentOfferedByDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor,
        Api.Common.Models.Resources.ProfessionalDevelopmentOfferedByDescriptor.TPDM.ProfessionalDevelopmentOfferedByDescriptor,
        Entities.Common.TPDM.IProfessionalDevelopmentOfferedByDescriptor,
        Entities.NHibernate.ProfessionalDevelopmentOfferedByDescriptorAggregate.TPDM.ProfessionalDevelopmentOfferedByDescriptor,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorPut,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorPost,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorGetByExample>
    {
        public ProfessionalDevelopmentOfferedByDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ProfessionalDevelopmentOfferedByDescriptors.ProfessionalDevelopmentOfferedByDescriptorGetByExample request, Entities.Common.TPDM.IProfessionalDevelopmentOfferedByDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProfessionalDevelopmentOfferedByDescriptorId = request.ProfessionalDevelopmentOfferedByDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ProgramGatewayDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/programGatewayDescriptors")]
    public partial class ProgramGatewayDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor,
        Api.Common.Models.Resources.ProgramGatewayDescriptor.TPDM.ProgramGatewayDescriptor,
        Entities.Common.TPDM.IProgramGatewayDescriptor,
        Entities.NHibernate.ProgramGatewayDescriptorAggregate.TPDM.ProgramGatewayDescriptor,
        Api.Common.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorPut,
        Api.Common.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorPost,
        Api.Common.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorGetByExample>
    {
        public ProgramGatewayDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.ProgramGatewayDescriptors.ProgramGatewayDescriptorGetByExample request, Entities.Common.TPDM.IProgramGatewayDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramGatewayDescriptorId = request.ProgramGatewayDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasures
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/quantitativeMeasures")]
    public partial class QuantitativeMeasuresController : DataManagementControllerBase<
        Api.Common.Models.Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure,
        Api.Common.Models.Resources.QuantitativeMeasure.TPDM.QuantitativeMeasure,
        Entities.Common.TPDM.IQuantitativeMeasure,
        Entities.NHibernate.QuantitativeMeasureAggregate.TPDM.QuantitativeMeasure,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasurePut,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasurePost,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasureDelete,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasureGetByExample>
    {
        public QuantitativeMeasuresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.QuantitativeMeasures.QuantitativeMeasureGetByExample request, Entities.Common.TPDM.IQuantitativeMeasure specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasureDatatypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/quantitativeMeasureDatatypeDescriptors")]
    public partial class QuantitativeMeasureDatatypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor,
        Api.Common.Models.Resources.QuantitativeMeasureDatatypeDescriptor.TPDM.QuantitativeMeasureDatatypeDescriptor,
        Entities.Common.TPDM.IQuantitativeMeasureDatatypeDescriptor,
        Entities.NHibernate.QuantitativeMeasureDatatypeDescriptorAggregate.TPDM.QuantitativeMeasureDatatypeDescriptor,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorGetByExample>
    {
        public QuantitativeMeasureDatatypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.QuantitativeMeasureDatatypeDescriptors.QuantitativeMeasureDatatypeDescriptorGetByExample request, Entities.Common.TPDM.IQuantitativeMeasureDatatypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.QuantitativeMeasureDatatypeDescriptorId = request.QuantitativeMeasureDatatypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasureScores
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/quantitativeMeasureScores")]
    public partial class QuantitativeMeasureScoresController : DataManagementControllerBase<
        Api.Common.Models.Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore,
        Api.Common.Models.Resources.QuantitativeMeasureScore.TPDM.QuantitativeMeasureScore,
        Entities.Common.TPDM.IQuantitativeMeasureScore,
        Entities.NHibernate.QuantitativeMeasureScoreAggregate.TPDM.QuantitativeMeasureScore,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScorePut,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScorePost,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScoreDelete,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScoreGetByExample>
    {
        public QuantitativeMeasureScoresController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.QuantitativeMeasureScores.QuantitativeMeasureScoreGetByExample request, Entities.Common.TPDM.IQuantitativeMeasureScore specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.QuantitativeMeasureTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/quantitativeMeasureTypeDescriptors")]
    public partial class QuantitativeMeasureTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor,
        Api.Common.Models.Resources.QuantitativeMeasureTypeDescriptor.TPDM.QuantitativeMeasureTypeDescriptor,
        Entities.Common.TPDM.IQuantitativeMeasureTypeDescriptor,
        Entities.NHibernate.QuantitativeMeasureTypeDescriptorAggregate.TPDM.QuantitativeMeasureTypeDescriptor,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorGetByExample>
    {
        public QuantitativeMeasureTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.QuantitativeMeasureTypeDescriptors.QuantitativeMeasureTypeDescriptorGetByExample request, Entities.Common.TPDM.IQuantitativeMeasureTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.QuantitativeMeasureTypeDescriptorId = request.QuantitativeMeasureTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RecruitmentEvents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/recruitmentEvents")]
    public partial class RecruitmentEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RecruitmentEvent.TPDM.RecruitmentEvent,
        Api.Common.Models.Resources.RecruitmentEvent.TPDM.RecruitmentEvent,
        Entities.Common.TPDM.IRecruitmentEvent,
        Entities.NHibernate.RecruitmentEventAggregate.TPDM.RecruitmentEvent,
        Api.Common.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventPut,
        Api.Common.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventPost,
        Api.Common.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventDelete,
        Api.Common.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventGetByExample>
    {
        public RecruitmentEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.RecruitmentEvents.RecruitmentEventGetByExample request, Entities.Common.TPDM.IRecruitmentEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EventDate = request.EventDate;
            specification.EventDescription = request.EventDescription;
            specification.EventLocation = request.EventLocation;
            specification.EventTitle = request.EventTitle;
            specification.Id = request.Id;
            specification.RecruitmentEventTypeDescriptor = request.RecruitmentEventTypeDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RecruitmentEventAttendances
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/recruitmentEventAttendances")]
    public partial class RecruitmentEventAttendancesController : DataManagementControllerBase<
        Api.Common.Models.Resources.RecruitmentEventAttendance.TPDM.RecruitmentEventAttendance,
        Api.Common.Models.Resources.RecruitmentEventAttendance.TPDM.RecruitmentEventAttendance,
        Entities.Common.TPDM.IRecruitmentEventAttendance,
        Entities.NHibernate.RecruitmentEventAttendanceAggregate.TPDM.RecruitmentEventAttendance,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendances.RecruitmentEventAttendancePut,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendances.RecruitmentEventAttendancePost,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendances.RecruitmentEventAttendanceDelete,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendances.RecruitmentEventAttendanceGetByExample>
    {
        public RecruitmentEventAttendancesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.RecruitmentEventAttendances.RecruitmentEventAttendanceGetByExample request, Entities.Common.TPDM.IRecruitmentEventAttendance specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Applied = request.Applied;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ElectronicMailAddress = request.ElectronicMailAddress;
            specification.EventDate = request.EventDate;
            specification.EventTitle = request.EventTitle;
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
            specification.RecruitmentEventAttendeeIdentifier = request.RecruitmentEventAttendeeIdentifier;
            specification.RecruitmentEventAttendeeTypeDescriptor = request.RecruitmentEventAttendeeTypeDescriptor;
            specification.Referral = request.Referral;
            specification.ReferredBy = request.ReferredBy;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SocialMediaNetworkName = request.SocialMediaNetworkName;
            specification.SocialMediaUserName = request.SocialMediaUserName;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RecruitmentEventAttendeeTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/recruitmentEventAttendeeTypeDescriptors")]
    public partial class RecruitmentEventAttendeeTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RecruitmentEventAttendeeTypeDescriptor.TPDM.RecruitmentEventAttendeeTypeDescriptor,
        Api.Common.Models.Resources.RecruitmentEventAttendeeTypeDescriptor.TPDM.RecruitmentEventAttendeeTypeDescriptor,
        Entities.Common.TPDM.IRecruitmentEventAttendeeTypeDescriptor,
        Entities.NHibernate.RecruitmentEventAttendeeTypeDescriptorAggregate.TPDM.RecruitmentEventAttendeeTypeDescriptor,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendeeTypeDescriptors.RecruitmentEventAttendeeTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendeeTypeDescriptors.RecruitmentEventAttendeeTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendeeTypeDescriptors.RecruitmentEventAttendeeTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.RecruitmentEventAttendeeTypeDescriptors.RecruitmentEventAttendeeTypeDescriptorGetByExample>
    {
        public RecruitmentEventAttendeeTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.RecruitmentEventAttendeeTypeDescriptors.RecruitmentEventAttendeeTypeDescriptorGetByExample request, Entities.Common.TPDM.IRecruitmentEventAttendeeTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RecruitmentEventAttendeeTypeDescriptorId = request.RecruitmentEventAttendeeTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RecruitmentEventTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/recruitmentEventTypeDescriptors")]
    public partial class RecruitmentEventTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor,
        Api.Common.Models.Resources.RecruitmentEventTypeDescriptor.TPDM.RecruitmentEventTypeDescriptor,
        Entities.Common.TPDM.IRecruitmentEventTypeDescriptor,
        Entities.NHibernate.RecruitmentEventTypeDescriptorAggregate.TPDM.RecruitmentEventTypeDescriptor,
        Api.Common.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorGetByExample>
    {
        public RecruitmentEventTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.RecruitmentEventTypeDescriptors.RecruitmentEventTypeDescriptorGetByExample request, Entities.Common.TPDM.IRecruitmentEventTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RecruitmentEventTypeDescriptorId = request.RecruitmentEventTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricDimensions
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/rubricDimensions")]
    public partial class RubricDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RubricDimension.TPDM.RubricDimension,
        Api.Common.Models.Resources.RubricDimension.TPDM.RubricDimension,
        Entities.Common.TPDM.IRubricDimension,
        Entities.NHibernate.RubricDimensionAggregate.TPDM.RubricDimension,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionPut,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionPost,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionDelete,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionGetByExample>
    {
        public RubricDimensionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionGetByExample request, Entities.Common.TPDM.IRubricDimension specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/rubricRatingLevelDescriptors")]
    public partial class RubricRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor,
        Api.Common.Models.Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor,
        Entities.Common.TPDM.IRubricRatingLevelDescriptor,
        Entities.NHibernate.RubricRatingLevelDescriptorAggregate.TPDM.RubricRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample>
    {
        public RubricRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample request, Entities.Common.TPDM.IRubricRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RubricRatingLevelDescriptorId = request.RubricRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SalaryTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/salaryTypeDescriptors")]
    public partial class SalaryTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor,
        Api.Common.Models.Resources.SalaryTypeDescriptor.TPDM.SalaryTypeDescriptor,
        Entities.Common.TPDM.ISalaryTypeDescriptor,
        Entities.NHibernate.SalaryTypeDescriptorAggregate.TPDM.SalaryTypeDescriptor,
        Api.Common.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorGetByExample>
    {
        public SalaryTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.SalaryTypeDescriptors.SalaryTypeDescriptorGetByExample request, Entities.Common.TPDM.ISalaryTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SalaryTypeDescriptorId = request.SalaryTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffEducatorPreparationProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/staffEducatorPreparationProgramAssociations")]
    public partial class StaffEducatorPreparationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffEducatorPreparationProgramAssociation.TPDM.StaffEducatorPreparationProgramAssociation,
        Api.Common.Models.Resources.StaffEducatorPreparationProgramAssociation.TPDM.StaffEducatorPreparationProgramAssociation,
        Entities.Common.TPDM.IStaffEducatorPreparationProgramAssociation,
        Entities.NHibernate.StaffEducatorPreparationProgramAssociationAggregate.TPDM.StaffEducatorPreparationProgramAssociation,
        Api.Common.Models.Requests.TPDM.StaffEducatorPreparationProgramAssociations.StaffEducatorPreparationProgramAssociationPut,
        Api.Common.Models.Requests.TPDM.StaffEducatorPreparationProgramAssociations.StaffEducatorPreparationProgramAssociationPost,
        Api.Common.Models.Requests.TPDM.StaffEducatorPreparationProgramAssociations.StaffEducatorPreparationProgramAssociationDelete,
        Api.Common.Models.Requests.TPDM.StaffEducatorPreparationProgramAssociations.StaffEducatorPreparationProgramAssociationGetByExample>
    {
        public StaffEducatorPreparationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.StaffEducatorPreparationProgramAssociations.StaffEducatorPreparationProgramAssociationGetByExample request, Entities.Common.TPDM.IStaffEducatorPreparationProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.Completer = request.Completer;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.StaffToCandidateRelationshipDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/staffToCandidateRelationshipDescriptors")]
    public partial class StaffToCandidateRelationshipDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffToCandidateRelationshipDescriptor.TPDM.StaffToCandidateRelationshipDescriptor,
        Api.Common.Models.Resources.StaffToCandidateRelationshipDescriptor.TPDM.StaffToCandidateRelationshipDescriptor,
        Entities.Common.TPDM.IStaffToCandidateRelationshipDescriptor,
        Entities.NHibernate.StaffToCandidateRelationshipDescriptorAggregate.TPDM.StaffToCandidateRelationshipDescriptor,
        Api.Common.Models.Requests.TPDM.StaffToCandidateRelationshipDescriptors.StaffToCandidateRelationshipDescriptorPut,
        Api.Common.Models.Requests.TPDM.StaffToCandidateRelationshipDescriptors.StaffToCandidateRelationshipDescriptorPost,
        Api.Common.Models.Requests.TPDM.StaffToCandidateRelationshipDescriptors.StaffToCandidateRelationshipDescriptorDelete,
        Api.Common.Models.Requests.TPDM.StaffToCandidateRelationshipDescriptors.StaffToCandidateRelationshipDescriptorGetByExample>
    {
        public StaffToCandidateRelationshipDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.StaffToCandidateRelationshipDescriptors.StaffToCandidateRelationshipDescriptorGetByExample request, Entities.Common.TPDM.IStaffToCandidateRelationshipDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffToCandidateRelationshipDescriptorId = request.StaffToCandidateRelationshipDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveyResponsePersonTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/surveyResponsePersonTargetAssociations")]
    public partial class SurveyResponsePersonTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyResponsePersonTargetAssociation.TPDM.SurveyResponsePersonTargetAssociation,
        Api.Common.Models.Resources.SurveyResponsePersonTargetAssociation.TPDM.SurveyResponsePersonTargetAssociation,
        Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation,
        Entities.NHibernate.SurveyResponsePersonTargetAssociationAggregate.TPDM.SurveyResponsePersonTargetAssociation,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationPut,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationPost,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationDelete,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationGetByExample>
    {
        public SurveyResponsePersonTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationGetByExample request, Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveySectionAggregateResponses
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/surveySectionAggregateResponses")]
    public partial class SurveySectionAggregateResponsesController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse,
        Api.Common.Models.Resources.SurveySectionAggregateResponse.TPDM.SurveySectionAggregateResponse,
        Entities.Common.TPDM.ISurveySectionAggregateResponse,
        Entities.NHibernate.SurveySectionAggregateResponseAggregate.TPDM.SurveySectionAggregateResponse,
        Api.Common.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponsePut,
        Api.Common.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponsePost,
        Api.Common.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponseDelete,
        Api.Common.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponseGetByExample>
    {
        public SurveySectionAggregateResponsesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.SurveySectionAggregateResponses.SurveySectionAggregateResponseGetByExample request, Entities.Common.TPDM.ISurveySectionAggregateResponse specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveySectionResponsePersonTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/surveySectionResponsePersonTargetAssociations")]
    public partial class SurveySectionResponsePersonTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionResponsePersonTargetAssociation.TPDM.SurveySectionResponsePersonTargetAssociation,
        Api.Common.Models.Resources.SurveySectionResponsePersonTargetAssociation.TPDM.SurveySectionResponsePersonTargetAssociation,
        Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation,
        Entities.NHibernate.SurveySectionResponsePersonTargetAssociationAggregate.TPDM.SurveySectionResponsePersonTargetAssociation,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationPut,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationPost,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationDelete,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationGetByExample>
    {
        public SurveySectionResponsePersonTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationGetByExample request, Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.WithdrawReasonDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/withdrawReasonDescriptors")]
    public partial class WithdrawReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor,
        Api.Common.Models.Resources.WithdrawReasonDescriptor.TPDM.WithdrawReasonDescriptor,
        Entities.Common.TPDM.IWithdrawReasonDescriptor,
        Entities.NHibernate.WithdrawReasonDescriptorAggregate.TPDM.WithdrawReasonDescriptor,
        Api.Common.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorPut,
        Api.Common.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorPost,
        Api.Common.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorDelete,
        Api.Common.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorGetByExample>
    {
        public WithdrawReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.WithdrawReasonDescriptors.WithdrawReasonDescriptorGetByExample request, Entities.Common.TPDM.IWithdrawReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.WithdrawReasonDescriptorId = request.WithdrawReasonDescriptorId;
        }
    }
}

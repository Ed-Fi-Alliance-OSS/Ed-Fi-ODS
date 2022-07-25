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
using EdFi.Ods.Entities.Common.Tpdm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.AccreditationStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/accreditationStatusDescriptors")]
    public partial class AccreditationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AccreditationStatusDescriptor.Tpdm.AccreditationStatusDescriptor,
        Api.Common.Models.Resources.AccreditationStatusDescriptor.Tpdm.AccreditationStatusDescriptor,
        Entities.Common.Tpdm.IAccreditationStatusDescriptor,
        Entities.NHibernate.AccreditationStatusDescriptorAggregate.Tpdm.AccreditationStatusDescriptor,
        Api.Common.Models.Requests.Tpdm.AccreditationStatusDescriptors.AccreditationStatusDescriptorPut,
        Api.Common.Models.Requests.Tpdm.AccreditationStatusDescriptors.AccreditationStatusDescriptorPost,
        Api.Common.Models.Requests.Tpdm.AccreditationStatusDescriptors.AccreditationStatusDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample>
    {
        public AccreditationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample request, Entities.Common.Tpdm.IAccreditationStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccreditationStatusDescriptorId = request.AccreditationStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.AidTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/aidTypeDescriptors")]
    public partial class AidTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AidTypeDescriptor.Tpdm.AidTypeDescriptor,
        Api.Common.Models.Resources.AidTypeDescriptor.Tpdm.AidTypeDescriptor,
        Entities.Common.Tpdm.IAidTypeDescriptor,
        Entities.NHibernate.AidTypeDescriptorAggregate.Tpdm.AidTypeDescriptor,
        Api.Common.Models.Requests.Tpdm.AidTypeDescriptors.AidTypeDescriptorPut,
        Api.Common.Models.Requests.Tpdm.AidTypeDescriptors.AidTypeDescriptorPost,
        Api.Common.Models.Requests.Tpdm.AidTypeDescriptors.AidTypeDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.AidTypeDescriptors.AidTypeDescriptorGetByExample>
    {
        public AidTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.AidTypeDescriptors.AidTypeDescriptorGetByExample request, Entities.Common.Tpdm.IAidTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AidTypeDescriptorId = request.AidTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.Candidates
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/candidates")]
    public partial class CandidatesController : DataManagementControllerBase<
        Api.Common.Models.Resources.Candidate.Tpdm.Candidate,
        Api.Common.Models.Resources.Candidate.Tpdm.Candidate,
        Entities.Common.Tpdm.ICandidate,
        Entities.NHibernate.CandidateAggregate.Tpdm.Candidate,
        Api.Common.Models.Requests.Tpdm.Candidates.CandidatePut,
        Api.Common.Models.Requests.Tpdm.Candidates.CandidatePost,
        Api.Common.Models.Requests.Tpdm.Candidates.CandidateDelete,
        Api.Common.Models.Requests.Tpdm.Candidates.CandidateGetByExample>
    {
        public CandidatesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.Candidates.CandidateGetByExample request, Entities.Common.Tpdm.ICandidate specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthCity = request.BirthCity;
            specification.BirthCountryDescriptor = request.BirthCountryDescriptor;
            specification.BirthDate = request.BirthDate;
            specification.BirthInternationalProvince = request.BirthInternationalProvince;
            specification.BirthSexDescriptor = request.BirthSexDescriptor;
            specification.BirthStateAbbreviationDescriptor = request.BirthStateAbbreviationDescriptor;
            specification.CandidateIdentifier = request.CandidateIdentifier;
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
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.CandidateEducatorPreparationProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/candidateEducatorPreparationProgramAssociations")]
    public partial class CandidateEducatorPreparationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CandidateEducatorPreparationProgramAssociation.Tpdm.CandidateEducatorPreparationProgramAssociation,
        Api.Common.Models.Resources.CandidateEducatorPreparationProgramAssociation.Tpdm.CandidateEducatorPreparationProgramAssociation,
        Entities.Common.Tpdm.ICandidateEducatorPreparationProgramAssociation,
        Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.Tpdm.CandidateEducatorPreparationProgramAssociation,
        Api.Common.Models.Requests.Tpdm.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationPut,
        Api.Common.Models.Requests.Tpdm.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationPost,
        Api.Common.Models.Requests.Tpdm.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationDelete,
        Api.Common.Models.Requests.Tpdm.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationGetByExample>
    {
        public CandidateEducatorPreparationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationGetByExample request, Entities.Common.Tpdm.ICandidateEducatorPreparationProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CandidateIdentifier = request.CandidateIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.EPPProgramPathwayDescriptor = request.EPPProgramPathwayDescriptor;
            specification.Id = request.Id;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.ReasonExitedDescriptor = request.ReasonExitedDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.CertificationRouteDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/certificationRouteDescriptors")]
    public partial class CertificationRouteDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationRouteDescriptor.Tpdm.CertificationRouteDescriptor,
        Api.Common.Models.Resources.CertificationRouteDescriptor.Tpdm.CertificationRouteDescriptor,
        Entities.Common.Tpdm.ICertificationRouteDescriptor,
        Entities.NHibernate.CertificationRouteDescriptorAggregate.Tpdm.CertificationRouteDescriptor,
        Api.Common.Models.Requests.Tpdm.CertificationRouteDescriptors.CertificationRouteDescriptorPut,
        Api.Common.Models.Requests.Tpdm.CertificationRouteDescriptors.CertificationRouteDescriptorPost,
        Api.Common.Models.Requests.Tpdm.CertificationRouteDescriptors.CertificationRouteDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample>
    {
        public CertificationRouteDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample request, Entities.Common.Tpdm.ICertificationRouteDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CertificationRouteDescriptorId = request.CertificationRouteDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.CoteachingStyleObservedDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/coteachingStyleObservedDescriptors")]
    public partial class CoteachingStyleObservedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CoteachingStyleObservedDescriptor.Tpdm.CoteachingStyleObservedDescriptor,
        Api.Common.Models.Resources.CoteachingStyleObservedDescriptor.Tpdm.CoteachingStyleObservedDescriptor,
        Entities.Common.Tpdm.ICoteachingStyleObservedDescriptor,
        Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.Tpdm.CoteachingStyleObservedDescriptor,
        Api.Common.Models.Requests.Tpdm.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPut,
        Api.Common.Models.Requests.Tpdm.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPost,
        Api.Common.Models.Requests.Tpdm.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample>
    {
        public CoteachingStyleObservedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample request, Entities.Common.Tpdm.ICoteachingStyleObservedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CoteachingStyleObservedDescriptorId = request.CoteachingStyleObservedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.CredentialStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/credentialStatusDescriptors")]
    public partial class CredentialStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialStatusDescriptor.Tpdm.CredentialStatusDescriptor,
        Api.Common.Models.Resources.CredentialStatusDescriptor.Tpdm.CredentialStatusDescriptor,
        Entities.Common.Tpdm.ICredentialStatusDescriptor,
        Entities.NHibernate.CredentialStatusDescriptorAggregate.Tpdm.CredentialStatusDescriptor,
        Api.Common.Models.Requests.Tpdm.CredentialStatusDescriptors.CredentialStatusDescriptorPut,
        Api.Common.Models.Requests.Tpdm.CredentialStatusDescriptors.CredentialStatusDescriptorPost,
        Api.Common.Models.Requests.Tpdm.CredentialStatusDescriptors.CredentialStatusDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample>
    {
        public CredentialStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample request, Entities.Common.Tpdm.ICredentialStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialStatusDescriptorId = request.CredentialStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EducatorPreparationPrograms
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/educatorPreparationPrograms")]
    public partial class EducatorPreparationProgramsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorPreparationProgram.Tpdm.EducatorPreparationProgram,
        Api.Common.Models.Resources.EducatorPreparationProgram.Tpdm.EducatorPreparationProgram,
        Entities.Common.Tpdm.IEducatorPreparationProgram,
        Entities.NHibernate.EducatorPreparationProgramAggregate.Tpdm.EducatorPreparationProgram,
        Api.Common.Models.Requests.Tpdm.EducatorPreparationPrograms.EducatorPreparationProgramPut,
        Api.Common.Models.Requests.Tpdm.EducatorPreparationPrograms.EducatorPreparationProgramPost,
        Api.Common.Models.Requests.Tpdm.EducatorPreparationPrograms.EducatorPreparationProgramDelete,
        Api.Common.Models.Requests.Tpdm.EducatorPreparationPrograms.EducatorPreparationProgramGetByExample>
    {
        public EducatorPreparationProgramsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EducatorPreparationPrograms.EducatorPreparationProgramGetByExample request, Entities.Common.Tpdm.IEducatorPreparationProgram specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccreditationStatusDescriptor = request.AccreditationStatusDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProgramId = request.ProgramId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EducatorRoleDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/educatorRoleDescriptors")]
    public partial class EducatorRoleDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorRoleDescriptor.Tpdm.EducatorRoleDescriptor,
        Api.Common.Models.Resources.EducatorRoleDescriptor.Tpdm.EducatorRoleDescriptor,
        Entities.Common.Tpdm.IEducatorRoleDescriptor,
        Entities.NHibernate.EducatorRoleDescriptorAggregate.Tpdm.EducatorRoleDescriptor,
        Api.Common.Models.Requests.Tpdm.EducatorRoleDescriptors.EducatorRoleDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EducatorRoleDescriptors.EducatorRoleDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EducatorRoleDescriptors.EducatorRoleDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample>
    {
        public EducatorRoleDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample request, Entities.Common.Tpdm.IEducatorRoleDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducatorRoleDescriptorId = request.EducatorRoleDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EnglishLanguageExamDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/englishLanguageExamDescriptors")]
    public partial class EnglishLanguageExamDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EnglishLanguageExamDescriptor.Tpdm.EnglishLanguageExamDescriptor,
        Api.Common.Models.Resources.EnglishLanguageExamDescriptor.Tpdm.EnglishLanguageExamDescriptor,
        Entities.Common.Tpdm.IEnglishLanguageExamDescriptor,
        Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.Tpdm.EnglishLanguageExamDescriptor,
        Api.Common.Models.Requests.Tpdm.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample>
    {
        public EnglishLanguageExamDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample request, Entities.Common.Tpdm.IEnglishLanguageExamDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EnglishLanguageExamDescriptorId = request.EnglishLanguageExamDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EPPProgramPathwayDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/eppProgramPathwayDescriptors")]
    public partial class EPPProgramPathwayDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EPPProgramPathwayDescriptor.Tpdm.EPPProgramPathwayDescriptor,
        Api.Common.Models.Resources.EPPProgramPathwayDescriptor.Tpdm.EPPProgramPathwayDescriptor,
        Entities.Common.Tpdm.IEPPProgramPathwayDescriptor,
        Entities.NHibernate.EPPProgramPathwayDescriptorAggregate.Tpdm.EPPProgramPathwayDescriptor,
        Api.Common.Models.Requests.Tpdm.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorGetByExample>
    {
        public EPPProgramPathwayDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorGetByExample request, Entities.Common.Tpdm.IEPPProgramPathwayDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EPPProgramPathwayDescriptorId = request.EPPProgramPathwayDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.Evaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluations")]
    public partial class EvaluationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Evaluation.Tpdm.Evaluation,
        Api.Common.Models.Resources.Evaluation.Tpdm.Evaluation,
        Entities.Common.Tpdm.IEvaluation,
        Entities.NHibernate.EvaluationAggregate.Tpdm.Evaluation,
        Api.Common.Models.Requests.Tpdm.Evaluations.EvaluationPut,
        Api.Common.Models.Requests.Tpdm.Evaluations.EvaluationPost,
        Api.Common.Models.Requests.Tpdm.Evaluations.EvaluationDelete,
        Api.Common.Models.Requests.Tpdm.Evaluations.EvaluationGetByExample>
    {
        public EvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.Evaluations.EvaluationGetByExample request, Entities.Common.Tpdm.IEvaluation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDescription = request.EvaluationDescription;
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationElements
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationElements")]
    public partial class EvaluationElementsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElement.Tpdm.EvaluationElement,
        Api.Common.Models.Resources.EvaluationElement.Tpdm.EvaluationElement,
        Entities.Common.Tpdm.IEvaluationElement,
        Entities.NHibernate.EvaluationElementAggregate.Tpdm.EvaluationElement,
        Api.Common.Models.Requests.Tpdm.EvaluationElements.EvaluationElementPut,
        Api.Common.Models.Requests.Tpdm.EvaluationElements.EvaluationElementPost,
        Api.Common.Models.Requests.Tpdm.EvaluationElements.EvaluationElementDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationElements.EvaluationElementGetByExample>
    {
        public EvaluationElementsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationElements.EvaluationElementGetByExample request, Entities.Common.Tpdm.IEvaluationElement specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationElementRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationElementRatings")]
    public partial class EvaluationElementRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElementRating.Tpdm.EvaluationElementRating,
        Api.Common.Models.Resources.EvaluationElementRating.Tpdm.EvaluationElementRating,
        Entities.Common.Tpdm.IEvaluationElementRating,
        Entities.NHibernate.EvaluationElementRatingAggregate.Tpdm.EvaluationElementRating,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatings.EvaluationElementRatingPut,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatings.EvaluationElementRatingPost,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatings.EvaluationElementRatingDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatings.EvaluationElementRatingGetByExample>
    {
        public EvaluationElementRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationElementRatings.EvaluationElementRatingGetByExample request, Entities.Common.Tpdm.IEvaluationElementRating specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationElementRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationElementRatingLevelDescriptors")]
    public partial class EvaluationElementRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElementRatingLevelDescriptor.Tpdm.EvaluationElementRatingLevelDescriptor,
        Api.Common.Models.Resources.EvaluationElementRatingLevelDescriptor.Tpdm.EvaluationElementRatingLevelDescriptor,
        Entities.Common.Tpdm.IEvaluationElementRatingLevelDescriptor,
        Entities.NHibernate.EvaluationElementRatingLevelDescriptorAggregate.Tpdm.EvaluationElementRatingLevelDescriptor,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample>
    {
        public EvaluationElementRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample request, Entities.Common.Tpdm.IEvaluationElementRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationElementRatingLevelDescriptorId = request.EvaluationElementRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationObjectives
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationObjectives")]
    public partial class EvaluationObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationObjective.Tpdm.EvaluationObjective,
        Api.Common.Models.Resources.EvaluationObjective.Tpdm.EvaluationObjective,
        Entities.Common.Tpdm.IEvaluationObjective,
        Entities.NHibernate.EvaluationObjectiveAggregate.Tpdm.EvaluationObjective,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectives.EvaluationObjectivePut,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectives.EvaluationObjectivePost,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectives.EvaluationObjectiveDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectives.EvaluationObjectiveGetByExample>
    {
        public EvaluationObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationObjectives.EvaluationObjectiveGetByExample request, Entities.Common.Tpdm.IEvaluationObjective specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationObjectiveDescription = request.EvaluationObjectiveDescription;
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationObjectiveRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationObjectiveRatings")]
    public partial class EvaluationObjectiveRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationObjectiveRating.Tpdm.EvaluationObjectiveRating,
        Api.Common.Models.Resources.EvaluationObjectiveRating.Tpdm.EvaluationObjectiveRating,
        Entities.Common.Tpdm.IEvaluationObjectiveRating,
        Entities.NHibernate.EvaluationObjectiveRatingAggregate.Tpdm.EvaluationObjectiveRating,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectiveRatings.EvaluationObjectiveRatingPut,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectiveRatings.EvaluationObjectiveRatingPost,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectiveRatings.EvaluationObjectiveRatingDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample>
    {
        public EvaluationObjectiveRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample request, Entities.Common.Tpdm.IEvaluationObjectiveRating specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationPeriodDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationPeriodDescriptors")]
    public partial class EvaluationPeriodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationPeriodDescriptor.Tpdm.EvaluationPeriodDescriptor,
        Api.Common.Models.Resources.EvaluationPeriodDescriptor.Tpdm.EvaluationPeriodDescriptor,
        Entities.Common.Tpdm.IEvaluationPeriodDescriptor,
        Entities.NHibernate.EvaluationPeriodDescriptorAggregate.Tpdm.EvaluationPeriodDescriptor,
        Api.Common.Models.Requests.Tpdm.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample>
    {
        public EvaluationPeriodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample request, Entities.Common.Tpdm.IEvaluationPeriodDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationPeriodDescriptorId = request.EvaluationPeriodDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationRatings")]
    public partial class EvaluationRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRating.Tpdm.EvaluationRating,
        Api.Common.Models.Resources.EvaluationRating.Tpdm.EvaluationRating,
        Entities.Common.Tpdm.IEvaluationRating,
        Entities.NHibernate.EvaluationRatingAggregate.Tpdm.EvaluationRating,
        Api.Common.Models.Requests.Tpdm.EvaluationRatings.EvaluationRatingPut,
        Api.Common.Models.Requests.Tpdm.EvaluationRatings.EvaluationRatingPost,
        Api.Common.Models.Requests.Tpdm.EvaluationRatings.EvaluationRatingDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationRatings.EvaluationRatingGetByExample>
    {
        public EvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationRatings.EvaluationRatingGetByExample request, Entities.Common.Tpdm.IEvaluationRating specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationDate = request.EvaluationDate;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.EvaluationRatingLevelDescriptor = request.EvaluationRatingLevelDescriptor;
            specification.EvaluationRatingStatusDescriptor = request.EvaluationRatingStatusDescriptor;
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationRatingLevelDescriptors")]
    public partial class EvaluationRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRatingLevelDescriptor.Tpdm.EvaluationRatingLevelDescriptor,
        Api.Common.Models.Resources.EvaluationRatingLevelDescriptor.Tpdm.EvaluationRatingLevelDescriptor,
        Entities.Common.Tpdm.IEvaluationRatingLevelDescriptor,
        Entities.NHibernate.EvaluationRatingLevelDescriptorAggregate.Tpdm.EvaluationRatingLevelDescriptor,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample>
    {
        public EvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample request, Entities.Common.Tpdm.IEvaluationRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationRatingLevelDescriptorId = request.EvaluationRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationRatingStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationRatingStatusDescriptors")]
    public partial class EvaluationRatingStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRatingStatusDescriptor.Tpdm.EvaluationRatingStatusDescriptor,
        Api.Common.Models.Resources.EvaluationRatingStatusDescriptor.Tpdm.EvaluationRatingStatusDescriptor,
        Entities.Common.Tpdm.IEvaluationRatingStatusDescriptor,
        Entities.NHibernate.EvaluationRatingStatusDescriptorAggregate.Tpdm.EvaluationRatingStatusDescriptor,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorGetByExample>
    {
        public EvaluationRatingStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorGetByExample request, Entities.Common.Tpdm.IEvaluationRatingStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationRatingStatusDescriptorId = request.EvaluationRatingStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.EvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/evaluationTypeDescriptors")]
    public partial class EvaluationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationTypeDescriptor.Tpdm.EvaluationTypeDescriptor,
        Api.Common.Models.Resources.EvaluationTypeDescriptor.Tpdm.EvaluationTypeDescriptor,
        Entities.Common.Tpdm.IEvaluationTypeDescriptor,
        Entities.NHibernate.EvaluationTypeDescriptorAggregate.Tpdm.EvaluationTypeDescriptor,
        Api.Common.Models.Requests.Tpdm.EvaluationTypeDescriptors.EvaluationTypeDescriptorPut,
        Api.Common.Models.Requests.Tpdm.EvaluationTypeDescriptors.EvaluationTypeDescriptorPost,
        Api.Common.Models.Requests.Tpdm.EvaluationTypeDescriptors.EvaluationTypeDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample>
    {
        public EvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample request, Entities.Common.Tpdm.IEvaluationTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationTypeDescriptorId = request.EvaluationTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.FinancialAids
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/financialAids")]
    public partial class FinancialAidsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FinancialAid.Tpdm.FinancialAid,
        Api.Common.Models.Resources.FinancialAid.Tpdm.FinancialAid,
        Entities.Common.Tpdm.IFinancialAid,
        Entities.NHibernate.FinancialAidAggregate.Tpdm.FinancialAid,
        Api.Common.Models.Requests.Tpdm.FinancialAids.FinancialAidPut,
        Api.Common.Models.Requests.Tpdm.FinancialAids.FinancialAidPost,
        Api.Common.Models.Requests.Tpdm.FinancialAids.FinancialAidDelete,
        Api.Common.Models.Requests.Tpdm.FinancialAids.FinancialAidGetByExample>
    {
        public FinancialAidsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.FinancialAids.FinancialAidGetByExample request, Entities.Common.Tpdm.IFinancialAid specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AidAmount = request.AidAmount;
            specification.AidConditionDescription = request.AidConditionDescription;
            specification.AidTypeDescriptor = request.AidTypeDescriptor;
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.PellGrantRecipient = request.PellGrantRecipient;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.GenderDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/genderDescriptors")]
    public partial class GenderDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GenderDescriptor.Tpdm.GenderDescriptor,
        Api.Common.Models.Resources.GenderDescriptor.Tpdm.GenderDescriptor,
        Entities.Common.Tpdm.IGenderDescriptor,
        Entities.NHibernate.GenderDescriptorAggregate.Tpdm.GenderDescriptor,
        Api.Common.Models.Requests.Tpdm.GenderDescriptors.GenderDescriptorPut,
        Api.Common.Models.Requests.Tpdm.GenderDescriptors.GenderDescriptorPost,
        Api.Common.Models.Requests.Tpdm.GenderDescriptors.GenderDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.GenderDescriptors.GenderDescriptorGetByExample>
    {
        public GenderDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.GenderDescriptors.GenderDescriptorGetByExample request, Entities.Common.Tpdm.IGenderDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GenderDescriptorId = request.GenderDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.ObjectiveRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/objectiveRatingLevelDescriptors")]
    public partial class ObjectiveRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ObjectiveRatingLevelDescriptor.Tpdm.ObjectiveRatingLevelDescriptor,
        Api.Common.Models.Resources.ObjectiveRatingLevelDescriptor.Tpdm.ObjectiveRatingLevelDescriptor,
        Entities.Common.Tpdm.IObjectiveRatingLevelDescriptor,
        Entities.NHibernate.ObjectiveRatingLevelDescriptorAggregate.Tpdm.ObjectiveRatingLevelDescriptor,
        Api.Common.Models.Requests.Tpdm.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPut,
        Api.Common.Models.Requests.Tpdm.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPost,
        Api.Common.Models.Requests.Tpdm.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample>
    {
        public ObjectiveRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample request, Entities.Common.Tpdm.IObjectiveRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ObjectiveRatingLevelDescriptorId = request.ObjectiveRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.PerformanceEvaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluations")]
    public partial class PerformanceEvaluationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluation.Tpdm.PerformanceEvaluation,
        Api.Common.Models.Resources.PerformanceEvaluation.Tpdm.PerformanceEvaluation,
        Entities.Common.Tpdm.IPerformanceEvaluation,
        Entities.NHibernate.PerformanceEvaluationAggregate.Tpdm.PerformanceEvaluation,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluations.PerformanceEvaluationPut,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluations.PerformanceEvaluationPost,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluations.PerformanceEvaluationDelete,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluations.PerformanceEvaluationGetByExample>
    {
        public PerformanceEvaluationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.PerformanceEvaluations.PerformanceEvaluationGetByExample request, Entities.Common.Tpdm.IPerformanceEvaluation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EvaluationPeriodDescriptor = request.EvaluationPeriodDescriptor;
            specification.Id = request.Id;
            specification.PerformanceEvaluationDescription = request.PerformanceEvaluationDescription;
            specification.PerformanceEvaluationTitle = request.PerformanceEvaluationTitle;
            specification.PerformanceEvaluationTypeDescriptor = request.PerformanceEvaluationTypeDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.TermDescriptor = request.TermDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.PerformanceEvaluationRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluationRatings")]
    public partial class PerformanceEvaluationRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationRating.Tpdm.PerformanceEvaluationRating,
        Api.Common.Models.Resources.PerformanceEvaluationRating.Tpdm.PerformanceEvaluationRating,
        Entities.Common.Tpdm.IPerformanceEvaluationRating,
        Entities.NHibernate.PerformanceEvaluationRatingAggregate.Tpdm.PerformanceEvaluationRating,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatings.PerformanceEvaluationRatingPut,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatings.PerformanceEvaluationRatingPost,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatings.PerformanceEvaluationRatingDelete,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample>
    {
        public PerformanceEvaluationRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample request, Entities.Common.Tpdm.IPerformanceEvaluationRating specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.PerformanceEvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluationRatingLevelDescriptors")]
    public partial class PerformanceEvaluationRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationRatingLevelDescriptor.Tpdm.PerformanceEvaluationRatingLevelDescriptor,
        Api.Common.Models.Resources.PerformanceEvaluationRatingLevelDescriptor.Tpdm.PerformanceEvaluationRatingLevelDescriptor,
        Entities.Common.Tpdm.IPerformanceEvaluationRatingLevelDescriptor,
        Entities.NHibernate.PerformanceEvaluationRatingLevelDescriptorAggregate.Tpdm.PerformanceEvaluationRatingLevelDescriptor,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPut,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPost,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample>
    {
        public PerformanceEvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample request, Entities.Common.Tpdm.IPerformanceEvaluationRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceEvaluationRatingLevelDescriptorId = request.PerformanceEvaluationRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.PerformanceEvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/performanceEvaluationTypeDescriptors")]
    public partial class PerformanceEvaluationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationTypeDescriptor.Tpdm.PerformanceEvaluationTypeDescriptor,
        Api.Common.Models.Resources.PerformanceEvaluationTypeDescriptor.Tpdm.PerformanceEvaluationTypeDescriptor,
        Entities.Common.Tpdm.IPerformanceEvaluationTypeDescriptor,
        Entities.NHibernate.PerformanceEvaluationTypeDescriptorAggregate.Tpdm.PerformanceEvaluationTypeDescriptor,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPut,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPost,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample>
    {
        public PerformanceEvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample request, Entities.Common.Tpdm.IPerformanceEvaluationTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceEvaluationTypeDescriptorId = request.PerformanceEvaluationTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.RubricDimensions
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/rubricDimensions")]
    public partial class RubricDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RubricDimension.Tpdm.RubricDimension,
        Api.Common.Models.Resources.RubricDimension.Tpdm.RubricDimension,
        Entities.Common.Tpdm.IRubricDimension,
        Entities.NHibernate.RubricDimensionAggregate.Tpdm.RubricDimension,
        Api.Common.Models.Requests.Tpdm.RubricDimensions.RubricDimensionPut,
        Api.Common.Models.Requests.Tpdm.RubricDimensions.RubricDimensionPost,
        Api.Common.Models.Requests.Tpdm.RubricDimensions.RubricDimensionDelete,
        Api.Common.Models.Requests.Tpdm.RubricDimensions.RubricDimensionGetByExample>
    {
        public RubricDimensionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.RubricDimensions.RubricDimensionGetByExample request, Entities.Common.Tpdm.IRubricDimension specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.RubricRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/rubricRatingLevelDescriptors")]
    public partial class RubricRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RubricRatingLevelDescriptor.Tpdm.RubricRatingLevelDescriptor,
        Api.Common.Models.Resources.RubricRatingLevelDescriptor.Tpdm.RubricRatingLevelDescriptor,
        Entities.Common.Tpdm.IRubricRatingLevelDescriptor,
        Entities.NHibernate.RubricRatingLevelDescriptorAggregate.Tpdm.RubricRatingLevelDescriptor,
        Api.Common.Models.Requests.Tpdm.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPut,
        Api.Common.Models.Requests.Tpdm.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPost,
        Api.Common.Models.Requests.Tpdm.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.Tpdm.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample>
    {
        public RubricRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample request, Entities.Common.Tpdm.IRubricRatingLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RubricRatingLevelDescriptorId = request.RubricRatingLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.SurveyResponsePersonTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/surveyResponsePersonTargetAssociations")]
    public partial class SurveyResponsePersonTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyResponsePersonTargetAssociation.Tpdm.SurveyResponsePersonTargetAssociation,
        Api.Common.Models.Resources.SurveyResponsePersonTargetAssociation.Tpdm.SurveyResponsePersonTargetAssociation,
        Entities.Common.Tpdm.ISurveyResponsePersonTargetAssociation,
        Entities.NHibernate.SurveyResponsePersonTargetAssociationAggregate.Tpdm.SurveyResponsePersonTargetAssociation,
        Api.Common.Models.Requests.Tpdm.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationPut,
        Api.Common.Models.Requests.Tpdm.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationPost,
        Api.Common.Models.Requests.Tpdm.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationDelete,
        Api.Common.Models.Requests.Tpdm.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationGetByExample>
    {
        public SurveyResponsePersonTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationGetByExample request, Entities.Common.Tpdm.ISurveyResponsePersonTargetAssociation specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Tpdm.SurveySectionResponsePersonTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("tpdm/surveySectionResponsePersonTargetAssociations")]
    public partial class SurveySectionResponsePersonTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionResponsePersonTargetAssociation.Tpdm.SurveySectionResponsePersonTargetAssociation,
        Api.Common.Models.Resources.SurveySectionResponsePersonTargetAssociation.Tpdm.SurveySectionResponsePersonTargetAssociation,
        Entities.Common.Tpdm.ISurveySectionResponsePersonTargetAssociation,
        Entities.NHibernate.SurveySectionResponsePersonTargetAssociationAggregate.Tpdm.SurveySectionResponsePersonTargetAssociation,
        Api.Common.Models.Requests.Tpdm.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationPut,
        Api.Common.Models.Requests.Tpdm.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationPost,
        Api.Common.Models.Requests.Tpdm.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationDelete,
        Api.Common.Models.Requests.Tpdm.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationGetByExample>
    {
        public SurveySectionResponsePersonTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider, apiSettings)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Tpdm.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationGetByExample request, Entities.Common.Tpdm.ISurveySectionResponsePersonTargetAssociation specification)
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

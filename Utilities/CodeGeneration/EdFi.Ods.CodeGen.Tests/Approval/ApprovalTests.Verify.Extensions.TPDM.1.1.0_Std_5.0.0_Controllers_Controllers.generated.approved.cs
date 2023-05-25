using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Api.Constants;
using EdFi.Ods.Api.Controllers;
using EdFi.Ods.Api.ExceptionHandling;
using EdFi.Ods.Api.Infrastructure.Pipelines.Factories;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Models.Requests;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Profiles;
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/accreditationStatusDescriptors")]
    public partial class AccreditationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AccreditationStatusDescriptor.TPDM.AccreditationStatusDescriptor,
        Entities.Common.TPDM.IAccreditationStatusDescriptor,
        Entities.NHibernate.AccreditationStatusDescriptorAggregate.TPDM.AccreditationStatusDescriptor,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.AccreditationStatusDescriptors.AccreditationStatusDescriptorGetByExample>
    {
        public AccreditationStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/aidTypeDescriptors")]
    public partial class AidTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AidTypeDescriptor.TPDM.AidTypeDescriptor,
        Entities.Common.TPDM.IAidTypeDescriptor,
        Entities.NHibernate.AidTypeDescriptorAggregate.TPDM.AidTypeDescriptor,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.AidTypeDescriptors.AidTypeDescriptorGetByExample>
    {
        public AidTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.Candidates
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/candidates")]
    public partial class CandidatesController : DataManagementControllerBase<
        Api.Common.Models.Resources.Candidate.TPDM.Candidate,
        Entities.Common.TPDM.ICandidate,
        Entities.NHibernate.CandidateAggregate.TPDM.Candidate,
        Api.Common.Models.Requests.TPDM.Candidates.CandidatePut,
        Api.Common.Models.Requests.TPDM.Candidates.CandidatePost,
        Api.Common.Models.Requests.TPDM.Candidates.CandidateDelete,
        Api.Common.Models.Requests.TPDM.Candidates.CandidateGetByExample>
    {
        public CandidatesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Candidates.CandidateGetByExample request, Entities.Common.TPDM.ICandidate specification)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CandidateEducatorPreparationProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/candidateEducatorPreparationProgramAssociations")]
    public partial class CandidateEducatorPreparationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CandidateEducatorPreparationProgramAssociation.TPDM.CandidateEducatorPreparationProgramAssociation,
        Entities.Common.TPDM.ICandidateEducatorPreparationProgramAssociation,
        Entities.NHibernate.CandidateEducatorPreparationProgramAssociationAggregate.TPDM.CandidateEducatorPreparationProgramAssociation,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationPut,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationPost,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationDelete,
        Api.Common.Models.Requests.TPDM.CandidateEducatorPreparationProgramAssociations.CandidateEducatorPreparationProgramAssociationGetByExample>
    {
        public CandidateEducatorPreparationProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.ReasonExitedDescriptor = request.ReasonExitedDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CertificationRouteDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/certificationRouteDescriptors")]
    public partial class CertificationRouteDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CertificationRouteDescriptor.TPDM.CertificationRouteDescriptor,
        Entities.Common.TPDM.ICertificationRouteDescriptor,
        Entities.NHibernate.CertificationRouteDescriptorAggregate.TPDM.CertificationRouteDescriptor,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorPut,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorPost,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CertificationRouteDescriptors.CertificationRouteDescriptorGetByExample>
    {
        public CertificationRouteDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CoteachingStyleObservedDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/coteachingStyleObservedDescriptors")]
    public partial class CoteachingStyleObservedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CoteachingStyleObservedDescriptor.TPDM.CoteachingStyleObservedDescriptor,
        Entities.Common.TPDM.ICoteachingStyleObservedDescriptor,
        Entities.NHibernate.CoteachingStyleObservedDescriptorAggregate.TPDM.CoteachingStyleObservedDescriptor,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPut,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorPost,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CoteachingStyleObservedDescriptors.CoteachingStyleObservedDescriptorGetByExample>
    {
        public CoteachingStyleObservedDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.CredentialStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/credentialStatusDescriptors")]
    public partial class CredentialStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialStatusDescriptor.TPDM.CredentialStatusDescriptor,
        Entities.Common.TPDM.ICredentialStatusDescriptor,
        Entities.NHibernate.CredentialStatusDescriptorAggregate.TPDM.CredentialStatusDescriptor,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.CredentialStatusDescriptors.CredentialStatusDescriptorGetByExample>
    {
        public CredentialStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducatorPreparationPrograms
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/educatorPreparationPrograms")]
    public partial class EducatorPreparationProgramsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorPreparationProgram.TPDM.EducatorPreparationProgram,
        Entities.Common.TPDM.IEducatorPreparationProgram,
        Entities.NHibernate.EducatorPreparationProgramAggregate.TPDM.EducatorPreparationProgram,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramPut,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramPost,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramDelete,
        Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramGetByExample>
    {
        public EducatorPreparationProgramsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EducatorPreparationPrograms.EducatorPreparationProgramGetByExample request, Entities.Common.TPDM.IEducatorPreparationProgram specification)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EducatorRoleDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/educatorRoleDescriptors")]
    public partial class EducatorRoleDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducatorRoleDescriptor.TPDM.EducatorRoleDescriptor,
        Entities.Common.TPDM.IEducatorRoleDescriptor,
        Entities.NHibernate.EducatorRoleDescriptorAggregate.TPDM.EducatorRoleDescriptor,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorPut,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorPost,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EducatorRoleDescriptors.EducatorRoleDescriptorGetByExample>
    {
        public EducatorRoleDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/englishLanguageExamDescriptors")]
    public partial class EnglishLanguageExamDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EnglishLanguageExamDescriptor.TPDM.EnglishLanguageExamDescriptor,
        Entities.Common.TPDM.IEnglishLanguageExamDescriptor,
        Entities.NHibernate.EnglishLanguageExamDescriptorAggregate.TPDM.EnglishLanguageExamDescriptor,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPut,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorPost,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EnglishLanguageExamDescriptors.EnglishLanguageExamDescriptorGetByExample>
    {
        public EnglishLanguageExamDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EPPProgramPathwayDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/eppProgramPathwayDescriptors")]
    public partial class EPPProgramPathwayDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EPPProgramPathwayDescriptor.TPDM.EPPProgramPathwayDescriptor,
        Entities.Common.TPDM.IEPPProgramPathwayDescriptor,
        Entities.NHibernate.EPPProgramPathwayDescriptorAggregate.TPDM.EPPProgramPathwayDescriptor,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorPut,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorPost,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EPPProgramPathwayDescriptors.EPPProgramPathwayDescriptorGetByExample>
    {
        public EPPProgramPathwayDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluations")]
    public partial class EvaluationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Evaluation.TPDM.Evaluation,
        Entities.Common.TPDM.IEvaluation,
        Entities.NHibernate.EvaluationAggregate.TPDM.Evaluation,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationPut,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationPost,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationDelete,
        Api.Common.Models.Requests.TPDM.Evaluations.EvaluationGetByExample>
    {
        public EvaluationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.Evaluations.EvaluationGetByExample request, Entities.Common.TPDM.IEvaluation specification)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationElements
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationElements")]
    public partial class EvaluationElementsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElement.TPDM.EvaluationElement,
        Entities.Common.TPDM.IEvaluationElement,
        Entities.NHibernate.EvaluationElementAggregate.TPDM.EvaluationElement,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementPut,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementPost,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementDelete,
        Api.Common.Models.Requests.TPDM.EvaluationElements.EvaluationElementGetByExample>
    {
        public EvaluationElementsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationElementRatings")]
    public partial class EvaluationElementRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElementRating.TPDM.EvaluationElementRating,
        Entities.Common.TPDM.IEvaluationElementRating,
        Entities.NHibernate.EvaluationElementRatingAggregate.TPDM.EvaluationElementRating,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingPut,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingPost,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingDelete,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatings.EvaluationElementRatingGetByExample>
    {
        public EvaluationElementRatingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationElementRatingLevelDescriptors")]
    public partial class EvaluationElementRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationElementRatingLevelDescriptor.TPDM.EvaluationElementRatingLevelDescriptor,
        Entities.Common.TPDM.IEvaluationElementRatingLevelDescriptor,
        Entities.NHibernate.EvaluationElementRatingLevelDescriptorAggregate.TPDM.EvaluationElementRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationElementRatingLevelDescriptors.EvaluationElementRatingLevelDescriptorGetByExample>
    {
        public EvaluationElementRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationObjectives")]
    public partial class EvaluationObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationObjective.TPDM.EvaluationObjective,
        Entities.Common.TPDM.IEvaluationObjective,
        Entities.NHibernate.EvaluationObjectiveAggregate.TPDM.EvaluationObjective,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectivePut,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectivePost,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveDelete,
        Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveGetByExample>
    {
        public EvaluationObjectivesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationObjectives.EvaluationObjectiveGetByExample request, Entities.Common.TPDM.IEvaluationObjective specification)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationObjectiveRatings
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationObjectiveRatings")]
    public partial class EvaluationObjectiveRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationObjectiveRating.TPDM.EvaluationObjectiveRating,
        Entities.Common.TPDM.IEvaluationObjectiveRating,
        Entities.NHibernate.EvaluationObjectiveRatingAggregate.TPDM.EvaluationObjectiveRating,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingPut,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingPost,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingDelete,
        Api.Common.Models.Requests.TPDM.EvaluationObjectiveRatings.EvaluationObjectiveRatingGetByExample>
    {
        public EvaluationObjectiveRatingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationPeriodDescriptors")]
    public partial class EvaluationPeriodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationPeriodDescriptor.TPDM.EvaluationPeriodDescriptor,
        Entities.Common.TPDM.IEvaluationPeriodDescriptor,
        Entities.NHibernate.EvaluationPeriodDescriptorAggregate.TPDM.EvaluationPeriodDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationPeriodDescriptors.EvaluationPeriodDescriptorGetByExample>
    {
        public EvaluationPeriodDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationRatings")]
    public partial class EvaluationRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRating.TPDM.EvaluationRating,
        Entities.Common.TPDM.IEvaluationRating,
        Entities.NHibernate.EvaluationRatingAggregate.TPDM.EvaluationRating,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingPut,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingPost,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingDelete,
        Api.Common.Models.Requests.TPDM.EvaluationRatings.EvaluationRatingGetByExample>
    {
        public EvaluationRatingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationRatingLevelDescriptors")]
    public partial class EvaluationRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRatingLevelDescriptor.TPDM.EvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IEvaluationRatingLevelDescriptor,
        Entities.NHibernate.EvaluationRatingLevelDescriptorAggregate.TPDM.EvaluationRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationRatingLevelDescriptors.EvaluationRatingLevelDescriptorGetByExample>
    {
        public EvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationRatingStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationRatingStatusDescriptors")]
    public partial class EvaluationRatingStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationRatingStatusDescriptor.TPDM.EvaluationRatingStatusDescriptor,
        Entities.Common.TPDM.IEvaluationRatingStatusDescriptor,
        Entities.NHibernate.EvaluationRatingStatusDescriptorAggregate.TPDM.EvaluationRatingStatusDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorGetByExample>
    {
        public EvaluationRatingStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.EvaluationRatingStatusDescriptors.EvaluationRatingStatusDescriptorGetByExample request, Entities.Common.TPDM.IEvaluationRatingStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EvaluationRatingStatusDescriptorId = request.EvaluationRatingStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TPDM.EvaluationTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/evaluationTypeDescriptors")]
    public partial class EvaluationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EvaluationTypeDescriptor.TPDM.EvaluationTypeDescriptor,
        Entities.Common.TPDM.IEvaluationTypeDescriptor,
        Entities.NHibernate.EvaluationTypeDescriptorAggregate.TPDM.EvaluationTypeDescriptor,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.EvaluationTypeDescriptors.EvaluationTypeDescriptorGetByExample>
    {
        public EvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.FinancialAids
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/financialAids")]
    public partial class FinancialAidsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FinancialAid.TPDM.FinancialAid,
        Entities.Common.TPDM.IFinancialAid,
        Entities.NHibernate.FinancialAidAggregate.TPDM.FinancialAid,
        Api.Common.Models.Requests.TPDM.FinancialAids.FinancialAidPut,
        Api.Common.Models.Requests.TPDM.FinancialAids.FinancialAidPost,
        Api.Common.Models.Requests.TPDM.FinancialAids.FinancialAidDelete,
        Api.Common.Models.Requests.TPDM.FinancialAids.FinancialAidGetByExample>
    {
        public FinancialAidsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TPDM.FinancialAids.FinancialAidGetByExample request, Entities.Common.TPDM.IFinancialAid specification)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.GenderDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/genderDescriptors")]
    public partial class GenderDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GenderDescriptor.TPDM.GenderDescriptor,
        Entities.Common.TPDM.IGenderDescriptor,
        Entities.NHibernate.GenderDescriptorAggregate.TPDM.GenderDescriptor,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorPut,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorPost,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorDelete,
        Api.Common.Models.Requests.TPDM.GenderDescriptors.GenderDescriptorGetByExample>
    {
        public GenderDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.ObjectiveRatingLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/objectiveRatingLevelDescriptors")]
    public partial class ObjectiveRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ObjectiveRatingLevelDescriptor.TPDM.ObjectiveRatingLevelDescriptor,
        Entities.Common.TPDM.IObjectiveRatingLevelDescriptor,
        Entities.NHibernate.ObjectiveRatingLevelDescriptorAggregate.TPDM.ObjectiveRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.ObjectiveRatingLevelDescriptors.ObjectiveRatingLevelDescriptorGetByExample>
    {
        public ObjectiveRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.PerformanceEvaluations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/performanceEvaluations")]
    public partial class PerformanceEvaluationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluation.TPDM.PerformanceEvaluation,
        Entities.Common.TPDM.IPerformanceEvaluation,
        Entities.NHibernate.PerformanceEvaluationAggregate.TPDM.PerformanceEvaluation,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluations.PerformanceEvaluationGetByExample>
    {
        public PerformanceEvaluationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
            specification.PerformanceEvaluationDescription = request.PerformanceEvaluationDescription;
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/performanceEvaluationRatings")]
    public partial class PerformanceEvaluationRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationRating.TPDM.PerformanceEvaluationRating,
        Entities.Common.TPDM.IPerformanceEvaluationRating,
        Entities.NHibernate.PerformanceEvaluationRatingAggregate.TPDM.PerformanceEvaluationRating,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatings.PerformanceEvaluationRatingGetByExample>
    {
        public PerformanceEvaluationRatingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/performanceEvaluationRatingLevelDescriptors")]
    public partial class PerformanceEvaluationRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationRatingLevelDescriptor.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Entities.Common.TPDM.IPerformanceEvaluationRatingLevelDescriptor,
        Entities.NHibernate.PerformanceEvaluationRatingLevelDescriptorAggregate.TPDM.PerformanceEvaluationRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationRatingLevelDescriptors.PerformanceEvaluationRatingLevelDescriptorGetByExample>
    {
        public PerformanceEvaluationRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/performanceEvaluationTypeDescriptors")]
    public partial class PerformanceEvaluationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceEvaluationTypeDescriptor.TPDM.PerformanceEvaluationTypeDescriptor,
        Entities.Common.TPDM.IPerformanceEvaluationTypeDescriptor,
        Entities.NHibernate.PerformanceEvaluationTypeDescriptorAggregate.TPDM.PerformanceEvaluationTypeDescriptor,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPut,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorPost,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorDelete,
        Api.Common.Models.Requests.TPDM.PerformanceEvaluationTypeDescriptors.PerformanceEvaluationTypeDescriptorGetByExample>
    {
        public PerformanceEvaluationTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.RubricDimensions
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/rubricDimensions")]
    public partial class RubricDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RubricDimension.TPDM.RubricDimension,
        Entities.Common.TPDM.IRubricDimension,
        Entities.NHibernate.RubricDimensionAggregate.TPDM.RubricDimension,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionPut,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionPost,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionDelete,
        Api.Common.Models.Requests.TPDM.RubricDimensions.RubricDimensionGetByExample>
    {
        public RubricDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/rubricRatingLevelDescriptors")]
    public partial class RubricRatingLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RubricRatingLevelDescriptor.TPDM.RubricRatingLevelDescriptor,
        Entities.Common.TPDM.IRubricRatingLevelDescriptor,
        Entities.NHibernate.RubricRatingLevelDescriptorAggregate.TPDM.RubricRatingLevelDescriptor,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPut,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorPost,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorDelete,
        Api.Common.Models.Requests.TPDM.RubricRatingLevelDescriptors.RubricRatingLevelDescriptorGetByExample>
    {
        public RubricRatingLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveyResponsePersonTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/surveyResponsePersonTargetAssociations")]
    public partial class SurveyResponsePersonTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyResponsePersonTargetAssociation.TPDM.SurveyResponsePersonTargetAssociation,
        Entities.Common.TPDM.ISurveyResponsePersonTargetAssociation,
        Entities.NHibernate.SurveyResponsePersonTargetAssociationAggregate.TPDM.SurveyResponsePersonTargetAssociation,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationPut,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationPost,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationDelete,
        Api.Common.Models.Requests.TPDM.SurveyResponsePersonTargetAssociations.SurveyResponsePersonTargetAssociationGetByExample>
    {
        public SurveyResponsePersonTargetAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

namespace EdFi.Ods.Api.Services.Controllers.TPDM.SurveySectionResponsePersonTargetAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/tpdm/surveySectionResponsePersonTargetAssociations")]
    public partial class SurveySectionResponsePersonTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionResponsePersonTargetAssociation.TPDM.SurveySectionResponsePersonTargetAssociation,
        Entities.Common.TPDM.ISurveySectionResponsePersonTargetAssociation,
        Entities.NHibernate.SurveySectionResponsePersonTargetAssociationAggregate.TPDM.SurveySectionResponsePersonTargetAssociation,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationPut,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationPost,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationDelete,
        Api.Common.Models.Requests.TPDM.SurveySectionResponsePersonTargetAssociations.SurveySectionResponsePersonTargetAssociationGetByExample>
    {
        public SurveySectionResponsePersonTargetAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
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

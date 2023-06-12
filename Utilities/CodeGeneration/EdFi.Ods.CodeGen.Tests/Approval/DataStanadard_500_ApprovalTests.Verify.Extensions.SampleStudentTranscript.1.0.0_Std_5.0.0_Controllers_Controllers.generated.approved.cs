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
using EdFi.Ods.Entities.Common.SampleStudentTranscript;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.SampleStudentTranscript.InstitutionControlDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/sample-student-transcript/institutionControlDescriptors")]
    public partial class InstitutionControlDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InstitutionControlDescriptor.SampleStudentTranscript.InstitutionControlDescriptor,
        Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor,
        Entities.NHibernate.InstitutionControlDescriptorAggregate.SampleStudentTranscript.InstitutionControlDescriptor,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionControlDescriptors.InstitutionControlDescriptorPut,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionControlDescriptors.InstitutionControlDescriptorPost,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionControlDescriptors.InstitutionControlDescriptorDelete,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionControlDescriptors.InstitutionControlDescriptorGetByExample>
    {
        public InstitutionControlDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleStudentTranscript.InstitutionControlDescriptors.InstitutionControlDescriptorGetByExample request, Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InstitutionControlDescriptorId = request.InstitutionControlDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SampleStudentTranscript.InstitutionLevelDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/sample-student-transcript/institutionLevelDescriptors")]
    public partial class InstitutionLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InstitutionLevelDescriptor.SampleStudentTranscript.InstitutionLevelDescriptor,
        Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor,
        Entities.NHibernate.InstitutionLevelDescriptorAggregate.SampleStudentTranscript.InstitutionLevelDescriptor,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionLevelDescriptors.InstitutionLevelDescriptorPut,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionLevelDescriptors.InstitutionLevelDescriptorPost,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionLevelDescriptors.InstitutionLevelDescriptorDelete,
        Api.Common.Models.Requests.SampleStudentTranscript.InstitutionLevelDescriptors.InstitutionLevelDescriptorGetByExample>
    {
        public InstitutionLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleStudentTranscript.InstitutionLevelDescriptors.InstitutionLevelDescriptorGetByExample request, Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InstitutionLevelDescriptorId = request.InstitutionLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SampleStudentTranscript.PostSecondaryOrganizations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/sample-student-transcript/postSecondaryOrganizations")]
    public partial class PostSecondaryOrganizationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganization,
        Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization,
        Entities.NHibernate.PostSecondaryOrganizationAggregate.SampleStudentTranscript.PostSecondaryOrganization,
        Api.Common.Models.Requests.SampleStudentTranscript.PostSecondaryOrganizations.PostSecondaryOrganizationPut,
        Api.Common.Models.Requests.SampleStudentTranscript.PostSecondaryOrganizations.PostSecondaryOrganizationPost,
        Api.Common.Models.Requests.SampleStudentTranscript.PostSecondaryOrganizations.PostSecondaryOrganizationDelete,
        Api.Common.Models.Requests.SampleStudentTranscript.PostSecondaryOrganizations.PostSecondaryOrganizationGetByExample>
    {
        public PostSecondaryOrganizationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleStudentTranscript.PostSecondaryOrganizations.PostSecondaryOrganizationGetByExample request, Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcceptanceIndicator = request.AcceptanceIndicator;
            specification.Id = request.Id;
            specification.InstitutionControlDescriptor = request.InstitutionControlDescriptor;
            specification.InstitutionLevelDescriptor = request.InstitutionLevelDescriptor;
            specification.NameOfInstitution = request.NameOfInstitution;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/sample-student-transcript/specialEducationGraduationStatusDescriptors")]
    public partial class SpecialEducationGraduationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SpecialEducationGraduationStatusDescriptor.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptor,
        Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor,
        Entities.NHibernate.SpecialEducationGraduationStatusDescriptorAggregate.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptor,
        Api.Common.Models.Requests.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors.SpecialEducationGraduationStatusDescriptorPut,
        Api.Common.Models.Requests.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors.SpecialEducationGraduationStatusDescriptorPost,
        Api.Common.Models.Requests.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors.SpecialEducationGraduationStatusDescriptorDelete,
        Api.Common.Models.Requests.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors.SpecialEducationGraduationStatusDescriptorGetByExample>
    {
        public SpecialEducationGraduationStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptors.SpecialEducationGraduationStatusDescriptorGetByExample request, Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SpecialEducationGraduationStatusDescriptorId = request.SpecialEducationGraduationStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SampleStudentTranscript.SubmissionCertificationDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/sample-student-transcript/submissionCertificationDescriptors")]
    public partial class SubmissionCertificationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SubmissionCertificationDescriptor.SampleStudentTranscript.SubmissionCertificationDescriptor,
        Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor,
        Entities.NHibernate.SubmissionCertificationDescriptorAggregate.SampleStudentTranscript.SubmissionCertificationDescriptor,
        Api.Common.Models.Requests.SampleStudentTranscript.SubmissionCertificationDescriptors.SubmissionCertificationDescriptorPut,
        Api.Common.Models.Requests.SampleStudentTranscript.SubmissionCertificationDescriptors.SubmissionCertificationDescriptorPost,
        Api.Common.Models.Requests.SampleStudentTranscript.SubmissionCertificationDescriptors.SubmissionCertificationDescriptorDelete,
        Api.Common.Models.Requests.SampleStudentTranscript.SubmissionCertificationDescriptors.SubmissionCertificationDescriptorGetByExample>
    {
        public SubmissionCertificationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleStudentTranscript.SubmissionCertificationDescriptors.SubmissionCertificationDescriptorGetByExample request, Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SubmissionCertificationDescriptorId = request.SubmissionCertificationDescriptorId;
        }
    }
}

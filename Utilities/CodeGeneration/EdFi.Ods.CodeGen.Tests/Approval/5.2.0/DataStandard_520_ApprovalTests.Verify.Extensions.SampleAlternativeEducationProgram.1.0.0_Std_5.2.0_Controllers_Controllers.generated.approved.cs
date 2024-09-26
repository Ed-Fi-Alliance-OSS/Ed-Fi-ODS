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
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Requests;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.ProblemDetails;
using EdFi.Ods.Common.Profiles;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [ApplyOdsRouteRootTemplate, Route($"{RouteConstants.DataManagementRoutePrefix}/sample-alternative-education-program/alternativeEducationEligibilityReasonDescriptors")]
    public partial class AlternativeEducationEligibilityReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AlternativeEducationEligibilityReasonDescriptor.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptor,
        Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor,
        Entities.NHibernate.AlternativeEducationEligibilityReasonDescriptorAggregate.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptor,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors.AlternativeEducationEligibilityReasonDescriptorPut,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors.AlternativeEducationEligibilityReasonDescriptorPost,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors.AlternativeEducationEligibilityReasonDescriptorDelete,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors.AlternativeEducationEligibilityReasonDescriptorGetByExample>
    {
        public AlternativeEducationEligibilityReasonDescriptorsController(IPipelineFactory pipelineFactory, IEdFiProblemDetailsProvider problemDetailsProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider, IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider, ILogContextAccessor logContextAccessor)
            : base(pipelineFactory, problemDetailsProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider, dataManagementResourceContextProvider, logContextAccessor)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptors.AlternativeEducationEligibilityReasonDescriptorGetByExample request, Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AlternativeEducationEligibilityReasonDescriptorId = request.AlternativeEducationEligibilityReasonDescriptorId;
            specification.CodeValue = request.CodeValue;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [ApplyOdsRouteRootTemplate, Route($"{RouteConstants.DataManagementRoutePrefix}/sample-alternative-education-program/studentAlternativeEducationProgramAssociations")]
    public partial class StudentAlternativeEducationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentAlternativeEducationProgramAssociation.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociation,
        Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation,
        Entities.NHibernate.StudentAlternativeEducationProgramAssociationAggregate.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociation,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations.StudentAlternativeEducationProgramAssociationPut,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations.StudentAlternativeEducationProgramAssociationPost,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations.StudentAlternativeEducationProgramAssociationDelete,
        Api.Common.Models.Requests.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations.StudentAlternativeEducationProgramAssociationGetByExample>
    {
        public StudentAlternativeEducationProgramAssociationsController(IPipelineFactory pipelineFactory, IEdFiProblemDetailsProvider problemDetailsProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider, IContextProvider<DataManagementResourceContext> dataManagementResourceContextProvider, ILogContextAccessor logContextAccessor)
            : base(pipelineFactory, problemDetailsProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider, dataManagementResourceContextProvider, logContextAccessor)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociations.StudentAlternativeEducationProgramAssociationGetByExample request, Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AlternativeEducationEligibilityReasonDescriptor = request.AlternativeEducationEligibilityReasonDescriptor;
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

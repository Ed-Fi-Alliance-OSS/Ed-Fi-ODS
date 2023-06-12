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
using EdFi.Ods.Entities.Common.SampleStudentTransportation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.SampleStudentTransportation.StudentTransportations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/sample-student-transportation/studentTransportations")]
    public partial class StudentTransportationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentTransportation.SampleStudentTransportation.StudentTransportation,
        Entities.Common.SampleStudentTransportation.IStudentTransportation,
        Entities.NHibernate.StudentTransportationAggregate.SampleStudentTransportation.StudentTransportation,
        Api.Common.Models.Requests.SampleStudentTransportation.StudentTransportations.StudentTransportationPut,
        Api.Common.Models.Requests.SampleStudentTransportation.StudentTransportations.StudentTransportationPost,
        Api.Common.Models.Requests.SampleStudentTransportation.StudentTransportations.StudentTransportationDelete,
        Api.Common.Models.Requests.SampleStudentTransportation.StudentTransportations.StudentTransportationGetByExample>
    {
        public StudentTransportationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SampleStudentTransportation.StudentTransportations.StudentTransportationGetByExample request, Entities.Common.SampleStudentTransportation.IStudentTransportation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AMBusNumber = request.AMBusNumber;
            specification.EstimatedMilesFromSchool = request.EstimatedMilesFromSchool;
            specification.Id = request.Id;
            specification.PMBusNumber = request.PMBusNumber;
            specification.SchoolId = request.SchoolId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

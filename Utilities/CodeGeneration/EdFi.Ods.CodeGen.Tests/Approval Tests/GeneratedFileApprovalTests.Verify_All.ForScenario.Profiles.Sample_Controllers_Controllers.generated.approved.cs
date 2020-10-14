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
using EdFi.Ods.Entities.Common.EdFi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-excludeonly")]
    [Route("ed-fi/schools")]
    public partial class SchoolsController : DataManagementControllerBase<
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

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolGetByExample request, Entities.Common.EdFi.ISchool specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-includeonly")]
    [Route("ed-fi/schools")]
    public partial class SchoolsController : DataManagementControllerBase<
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

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolGetByExample request, Entities.Common.EdFi.ISchool specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_ReadOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-readonly")]
    [Route("ed-fi/schools")]
    public partial class SchoolsController : DataManagementControllerBase<
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

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolGetByExample request, Entities.Common.EdFi.ISchool specification)
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

        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public override Task<IActionResult> Post(SchoolsNullWriteRequest request)
        {
            return Task.FromResult<IActionResult>(
                StatusCode(StatusCodes.Status405MethodNotAllowed,
                ErrorTranslator
                    .GetErrorMessage("The allowed methods for this resource with the 'Test-Profile-Resource-ReadOnly' profile are GET, DELETE and OPTIONS.")));
        }

        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public override Task<IActionResult> Put(SchoolsNullWriteRequest request, Guid id)
        {
            return Task.FromResult<IActionResult>(
                StatusCode(StatusCodes.Status405MethodNotAllowed,
                ErrorTranslator
                    .GetErrorMessage("The allowed methods for this resource with the 'Test-Profile-Resource-ReadOnly' profile are GET, DELETE and OPTIONS.")));
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_WriteOnly
{
    [ExcludeFromCodeCoverage]
    public class SchoolsNullReadRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-writeonly")]
    [Route("ed-fi/schools")]
    public partial class SchoolsController : DataManagementControllerBase<
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

        protected override void MapAll(SchoolsNullReadRequest request, Entities.Common.EdFi.ISchool specification)
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

        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public override Task<IActionResult> Get(Guid id)
        {
            return Task.FromResult<IActionResult>(
                StatusCode(StatusCodes.Status405MethodNotAllowed,
                ErrorTranslator
                    .GetErrorMessage("The allowed methods for this resource with the 'Test-Profile-Resource-WriteOnly' profile are PUT, POST, DELETE and OPTIONS.")));
        }

        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public override Task<IActionResult> GetAll(UrlQueryParametersRequest urlQueryParametersRequest, SchoolsNullReadRequest specification = null)
        {
            return Task.FromResult<IActionResult>(
                StatusCode(StatusCodes.Status405MethodNotAllowed,
                ErrorTranslator
                    .GetErrorMessage("The allowed methods for this resource with the 'Test-Profile-Resource-WriteOnly' profile are PUT, POST, DELETE and OPTIONS.")));
        }
    }
}

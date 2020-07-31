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
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Api.Services.Requests;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School,
        Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolPut,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolPost,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolDelete,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ExcludeOnly.SchoolGetByExample request, ISchool specification)
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
    public partial class SchoolsController : EdFiControllerBase<
        Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School,
        Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolPut,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolPost,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolDelete,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_IncludeOnly.SchoolGetByExample request, ISchool specification)
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
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-readonly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolsNullWriteRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Models.Resources.School.EdFi.Test_Profile_Resource_ReadOnly_Readable.School,
        SchoolsNullWriteRequest,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        SchoolsNullWriteRequest,
        SchoolsNullWriteRequest,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolDelete,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_ReadOnly.SchoolGetByExample request, ISchool specification)
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

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi.Test_Profile_Resource_WriteOnly
{
    [ProfileContentType("application/vnd.ed-fi.school.test-profile-resource-writeonly.readable+json")]
    [ExcludeFromCodeCoverage]
    public class SchoolsNullReadRequest : NullRequestBase { }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        SchoolsNullReadRequest,
        Models.Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly.SchoolPut,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly.SchoolPost,
        Api.Models.Requests.Schools.EdFi.Test_Profile_Resource_WriteOnly.SchoolDelete,
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

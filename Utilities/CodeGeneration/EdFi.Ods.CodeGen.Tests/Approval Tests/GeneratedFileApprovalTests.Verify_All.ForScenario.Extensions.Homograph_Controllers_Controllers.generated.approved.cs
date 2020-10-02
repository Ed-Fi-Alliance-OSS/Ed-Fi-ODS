#if NETCOREAPP
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
using EdFi.Ods.Entities.Common.Homograph;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.Homograph.Names
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/names")]
    public partial class NamesController : DataManagementControllerBase<
        Api.Common.Models.Resources.Name.Homograph.Name,
        Api.Common.Models.Resources.Name.Homograph.Name,
        Entities.Common.Homograph.IName,
        Entities.NHibernate.NameAggregate.Homograph.Name,
        Api.Common.Models.Requests.Homograph.Names.NamePut,
        Api.Common.Models.Requests.Homograph.Names.NamePost,
        Api.Common.Models.Requests.Homograph.Names.NameDelete,
        Api.Common.Models.Requests.Homograph.Names.NameGetByExample>
    {
        public NamesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.Names.NameGetByExample request, Entities.Common.Homograph.IName specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FirstName = request.FirstName;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
        }

        protected override string GetResourceCollectionName()
        {
            return "names";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Homograph.Parents
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/parents")]
    public partial class ParentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Parent.Homograph.Parent,
        Api.Common.Models.Resources.Parent.Homograph.Parent,
        Entities.Common.Homograph.IParent,
        Entities.NHibernate.ParentAggregate.Homograph.Parent,
        Api.Common.Models.Requests.Homograph.Parents.ParentPut,
        Api.Common.Models.Requests.Homograph.Parents.ParentPost,
        Api.Common.Models.Requests.Homograph.Parents.ParentDelete,
        Api.Common.Models.Requests.Homograph.Parents.ParentGetByExample>
    {
        public ParentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.Parents.ParentGetByExample request, Entities.Common.Homograph.IParent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.ParentFirstName = request.ParentFirstName;
            specification.ParentLastSurname = request.ParentLastSurname;
        }

        protected override string GetResourceCollectionName()
        {
            return "parents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Homograph.Schools
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/schools")]
    public partial class SchoolsController : DataManagementControllerBase<
        Api.Common.Models.Resources.School.Homograph.School,
        Api.Common.Models.Resources.School.Homograph.School,
        Entities.Common.Homograph.ISchool,
        Entities.NHibernate.SchoolAggregate.Homograph.School,
        Api.Common.Models.Requests.Homograph.Schools.SchoolPut,
        Api.Common.Models.Requests.Homograph.Schools.SchoolPost,
        Api.Common.Models.Requests.Homograph.Schools.SchoolDelete,
        Api.Common.Models.Requests.Homograph.Schools.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.Schools.SchoolGetByExample request, Entities.Common.Homograph.ISchool specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.SchoolName = request.SchoolName;
            specification.SchoolYear = request.SchoolYear;
        }

        protected override string GetResourceCollectionName()
        {
            return "schools";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Homograph.SchoolYearTypes
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/schoolYearTypes")]
    public partial class SchoolYearTypesController : DataManagementControllerBase<
        Api.Common.Models.Resources.SchoolYearType.Homograph.SchoolYearType,
        Api.Common.Models.Resources.SchoolYearType.Homograph.SchoolYearType,
        Entities.Common.Homograph.ISchoolYearType,
        Entities.NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearType,
        Api.Common.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypePut,
        Api.Common.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypePost,
        Api.Common.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypeDelete,
        Api.Common.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypeGetByExample>
    {
        public SchoolYearTypesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypeGetByExample request, Entities.Common.Homograph.ISchoolYearType specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
        }

        protected override string GetResourceCollectionName()
        {
            return "schoolYearTypes";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Homograph.Staffs
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/staffs")]
    public partial class StaffsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Staff.Homograph.Staff,
        Api.Common.Models.Resources.Staff.Homograph.Staff,
        Entities.Common.Homograph.IStaff,
        Entities.NHibernate.StaffAggregate.Homograph.Staff,
        Api.Common.Models.Requests.Homograph.Staffs.StaffPut,
        Api.Common.Models.Requests.Homograph.Staffs.StaffPost,
        Api.Common.Models.Requests.Homograph.Staffs.StaffDelete,
        Api.Common.Models.Requests.Homograph.Staffs.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.Staffs.StaffGetByExample request, Entities.Common.Homograph.IStaff specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.StaffFirstName = request.StaffFirstName;
            specification.StaffLastSurname = request.StaffLastSurname;
        }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Homograph.Students
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/students")]
    public partial class StudentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Student.Homograph.Student,
        Api.Common.Models.Resources.Student.Homograph.Student,
        Entities.Common.Homograph.IStudent,
        Entities.NHibernate.StudentAggregate.Homograph.Student,
        Api.Common.Models.Requests.Homograph.Students.StudentPut,
        Api.Common.Models.Requests.Homograph.Students.StudentPost,
        Api.Common.Models.Requests.Homograph.Students.StudentDelete,
        Api.Common.Models.Requests.Homograph.Students.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.Students.StudentGetByExample request, Entities.Common.Homograph.IStudent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentFirstName = request.StudentFirstName;
            specification.StudentLastSurname = request.StudentLastSurname;
        }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Homograph.StudentSchoolAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("homograph/studentSchoolAssociations")]
    public partial class StudentSchoolAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation,
        Api.Common.Models.Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation,
        Entities.Common.Homograph.IStudentSchoolAssociation,
        Entities.NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociation,
        Api.Common.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationPut,
        Api.Common.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationPost,
        Api.Common.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationDelete,
        Api.Common.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationGetByExample>
    {
        public StudentSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationGetByExample request, Entities.Common.Homograph.IStudentSchoolAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.SchoolName = request.SchoolName;
            specification.StudentFirstName = request.StudentFirstName;
            specification.StudentLastSurname = request.StudentLastSurname;
        }

        protected override string GetResourceCollectionName()
        {
            return "studentSchoolAssociations";
        }
    }
}
#endif
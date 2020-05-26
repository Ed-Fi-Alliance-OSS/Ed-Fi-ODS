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
using EdFi.Ods.Entities.Common.Homograph;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Api.Services.Requests;

namespace EdFi.Ods.Api.Services.Controllers.Homograph.Names
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class NamesController : EdFiControllerBase<
        Models.Resources.Name.Homograph.Name,
        Models.Resources.Name.Homograph.Name,
        Entities.Common.Homograph.IName,
        Entities.NHibernate.NameAggregate.Homograph.Name,
        Api.Models.Requests.Homograph.Names.NamePut,
        Api.Models.Requests.Homograph.Names.NamePost,
        Api.Models.Requests.Homograph.Names.NameDelete,
        Api.Models.Requests.Homograph.Names.NameGetByExample>
    {
        public NamesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.Names.NameGetByExample request, Entities.Common.Homograph.IName specification)
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
    public partial class ParentsController : EdFiControllerBase<
        Models.Resources.Parent.Homograph.Parent,
        Models.Resources.Parent.Homograph.Parent,
        Entities.Common.Homograph.IParent,
        Entities.NHibernate.ParentAggregate.Homograph.Parent,
        Api.Models.Requests.Homograph.Parents.ParentPut,
        Api.Models.Requests.Homograph.Parents.ParentPost,
        Api.Models.Requests.Homograph.Parents.ParentDelete,
        Api.Models.Requests.Homograph.Parents.ParentGetByExample>
    {
        public ParentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.Parents.ParentGetByExample request, Entities.Common.Homograph.IParent specification)
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
    public partial class SchoolsController : EdFiControllerBase<
        Models.Resources.School.Homograph.School,
        Models.Resources.School.Homograph.School,
        Entities.Common.Homograph.ISchool,
        Entities.NHibernate.SchoolAggregate.Homograph.School,
        Api.Models.Requests.Homograph.Schools.SchoolPut,
        Api.Models.Requests.Homograph.Schools.SchoolPost,
        Api.Models.Requests.Homograph.Schools.SchoolDelete,
        Api.Models.Requests.Homograph.Schools.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.Schools.SchoolGetByExample request, Entities.Common.Homograph.ISchool specification)
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
    public partial class SchoolYearTypesController : EdFiControllerBase<
        Models.Resources.SchoolYearType.Homograph.SchoolYearType,
        Models.Resources.SchoolYearType.Homograph.SchoolYearType,
        Entities.Common.Homograph.ISchoolYearType,
        Entities.NHibernate.SchoolYearTypeAggregate.Homograph.SchoolYearType,
        Api.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypePut,
        Api.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypePost,
        Api.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypeDelete,
        Api.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypeGetByExample>
    {
        public SchoolYearTypesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.SchoolYearTypes.SchoolYearTypeGetByExample request, Entities.Common.Homograph.ISchoolYearType specification)
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
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.Homograph.Staff,
        Models.Resources.Staff.Homograph.Staff,
        Entities.Common.Homograph.IStaff,
        Entities.NHibernate.StaffAggregate.Homograph.Staff,
        Api.Models.Requests.Homograph.Staffs.StaffPut,
        Api.Models.Requests.Homograph.Staffs.StaffPost,
        Api.Models.Requests.Homograph.Staffs.StaffDelete,
        Api.Models.Requests.Homograph.Staffs.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.Staffs.StaffGetByExample request, Entities.Common.Homograph.IStaff specification)
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
    public partial class StudentsController : EdFiControllerBase<
        Models.Resources.Student.Homograph.Student,
        Models.Resources.Student.Homograph.Student,
        Entities.Common.Homograph.IStudent,
        Entities.NHibernate.StudentAggregate.Homograph.Student,
        Api.Models.Requests.Homograph.Students.StudentPut,
        Api.Models.Requests.Homograph.Students.StudentPost,
        Api.Models.Requests.Homograph.Students.StudentDelete,
        Api.Models.Requests.Homograph.Students.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.Students.StudentGetByExample request, Entities.Common.Homograph.IStudent specification)
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
    public partial class StudentSchoolAssociationsController : EdFiControllerBase<
        Models.Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation,
        Models.Resources.StudentSchoolAssociation.Homograph.StudentSchoolAssociation,
        Entities.Common.Homograph.IStudentSchoolAssociation,
        Entities.NHibernate.StudentSchoolAssociationAggregate.Homograph.StudentSchoolAssociation,
        Api.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationPut,
        Api.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationPost,
        Api.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationDelete,
        Api.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationGetByExample>
    {
        public StudentSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Homograph.StudentSchoolAssociations.StudentSchoolAssociationGetByExample request, Entities.Common.Homograph.IStudentSchoolAssociation specification)
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

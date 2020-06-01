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

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes.BusRoute_MixedInclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.BusRoute_MixedInclude_Readable.BusRoute,
        Models.Resources.BusRoute.Sample.BusRoute_MixedInclude_Writable.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.BusId = request.BusId;
            specification.BusRouteDirection = request.BusRouteDirection;
            specification.BusRouteDuration = request.BusRouteDuration;
            specification.BusRouteNumber = request.BusRouteNumber;
            specification.Daily = request.Daily;
            specification.DisabilityDescriptor = request.DisabilityDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExpectedTransitTime = request.ExpectedTransitTime;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.OperatingCost = request.OperatingCost;
            specification.OptimalCapacity = request.OptimalCapacity;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StartDate = request.StartDate;
            specification.WeeklyMileage = request.WeeklyMileage;
                    }

        protected override string GetResourceCollectionName()
        {
            return "busRoutes";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.busroute.busroute-mixedinclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes.BusRoute_MixedInclude1
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.BusRoute_MixedInclude1_Readable.BusRoute,
        Models.Resources.BusRoute.Sample.BusRoute_MixedInclude1_Writable.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude1.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude1.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude1.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude1.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude1.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.BusId = request.BusId;
            specification.BusRouteDirection = request.BusRouteDirection;
            specification.BusRouteDuration = request.BusRouteDuration;
            specification.BusRouteNumber = request.BusRouteNumber;
            specification.Daily = request.Daily;
            specification.DisabilityDescriptor = request.DisabilityDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExpectedTransitTime = request.ExpectedTransitTime;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.OperatingCost = request.OperatingCost;
            specification.OptimalCapacity = request.OptimalCapacity;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StartDate = request.StartDate;
            specification.WeeklyMileage = request.WeeklyMileage;
                    }

        protected override string GetResourceCollectionName()
        {
            return "busRoutes";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.busroute.busroute-mixedinclude1.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes.BusRoute_MixedInclude2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.BusRoute_MixedInclude2_Readable.BusRoute,
        Models.Resources.BusRoute.Sample.BusRoute_MixedInclude2_Writable.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude2.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude2.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude2.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude2.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude2.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.BusId = request.BusId;
            specification.BusRouteDirection = request.BusRouteDirection;
            specification.BusRouteDuration = request.BusRouteDuration;
            specification.BusRouteNumber = request.BusRouteNumber;
            specification.Daily = request.Daily;
            specification.DisabilityDescriptor = request.DisabilityDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExpectedTransitTime = request.ExpectedTransitTime;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.OperatingCost = request.OperatingCost;
            specification.OptimalCapacity = request.OptimalCapacity;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StartDate = request.StartDate;
            specification.WeeklyMileage = request.WeeklyMileage;
                    }

        protected override string GetResourceCollectionName()
        {
            return "busRoutes";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.busroute.busroute-mixedinclude2.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes.Staff_and_Prospect_MixedExclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude_Readable.BusRoute,
        Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude_Writable.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.BusId = request.BusId;
            specification.BusRouteDirection = request.BusRouteDirection;
            specification.BusRouteDuration = request.BusRouteDuration;
            specification.BusRouteNumber = request.BusRouteNumber;
            specification.Daily = request.Daily;
            specification.DisabilityDescriptor = request.DisabilityDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExpectedTransitTime = request.ExpectedTransitTime;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.OperatingCost = request.OperatingCost;
            specification.OptimalCapacity = request.OptimalCapacity;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StartDate = request.StartDate;
            specification.WeeklyMileage = request.WeeklyMileage;
                    }

        protected override string GetResourceCollectionName()
        {
            return "busRoutes";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.busroute.staff-and-prospect-mixedexclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_and_Prospect_MixedExclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-and-prospect-mixedexclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude2_Readable.BusRoute,
        Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude2_Writable.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.BusId = request.BusId;
            specification.BusRouteDirection = request.BusRouteDirection;
            specification.BusRouteDuration = request.BusRouteDuration;
            specification.BusRouteNumber = request.BusRouteNumber;
            specification.Daily = request.Daily;
            specification.DisabilityDescriptor = request.DisabilityDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExpectedTransitTime = request.ExpectedTransitTime;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.OperatingCost = request.OperatingCost;
            specification.OptimalCapacity = request.OptimalCapacity;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StartDate = request.StartDate;
            specification.WeeklyMileage = request.WeeklyMileage;
                    }

        protected override string GetResourceCollectionName()
        {
            return "busRoutes";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.busroute.staff-and-prospect-mixedexclude2.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_and_Prospect_MixedExclude2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-and-prospect-mixedexclude2.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes.Staff_and_Prospect_MixedInclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedInclude_Readable.BusRoute,
        Models.Resources.BusRoute.Sample.Staff_and_Prospect_MixedInclude_Writable.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedInclude.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedInclude.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedInclude.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedInclude.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedInclude.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.BusId = request.BusId;
            specification.BusRouteDirection = request.BusRouteDirection;
            specification.BusRouteDuration = request.BusRouteDuration;
            specification.BusRouteNumber = request.BusRouteNumber;
            specification.Daily = request.Daily;
            specification.DisabilityDescriptor = request.DisabilityDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExpectedTransitTime = request.ExpectedTransitTime;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.OperatingCost = request.OperatingCost;
            specification.OptimalCapacity = request.OptimalCapacity;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StartDate = request.StartDate;
            specification.WeeklyMileage = request.WeeklyMileage;
                    }

        protected override string GetResourceCollectionName()
        {
            return "busRoutes";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.busroute.staff-and-prospect-mixedinclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_and_Prospect_MixedInclude
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-and-prospect-mixedinclude.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-entity-extension-excludeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-entity-extension-includeonly.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi.Staff_Include_All
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff_Include_All_Readable.Staff,
        Models.Resources.Staff.EdFi.Staff_Include_All_Writable.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffPut,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffPost,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.Staff_Include_All.StaffGetByExample request, IStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthDate = request.BirthDate;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.YearsOfPriorProfessionalExperience = request.YearsOfPriorProfessionalExperience;
            specification.YearsOfPriorTeachingExperience = request.YearsOfPriorTeachingExperience;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffs";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.staff.staff-include-all.readable+json";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi.Student_Include_All
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Models.Resources.Student.EdFi.Student_Include_All_Readable.Student,
        Models.Resources.Student.EdFi.Student_Include_All_Writable.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentPut,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentPost,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentDelete,
        Api.Models.Requests.Students.EdFi.Student_Include_All.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Students.EdFi.Student_Include_All.StudentGetByExample request, IStudent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BirthCity = request.BirthCity;
            specification.BirthCountryDescriptor = request.BirthCountryDescriptor;
            specification.BirthDate = request.BirthDate;
            specification.BirthInternationalProvince = request.BirthInternationalProvince;
            specification.BirthSexDescriptor = request.BirthSexDescriptor;
            specification.BirthStateAbbreviationDescriptor = request.BirthStateAbbreviationDescriptor;
            specification.CitizenshipStatusDescriptor = request.CitizenshipStatusDescriptor;
            specification.DateEnteredUS = request.DateEnteredUS;
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.MultipleBirthStatus = request.MultipleBirthStatus;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "students";
        }

        protected override string GetReadContentType()
        {
            return "application/vnd.ed-fi.student.student-include-all.readable+json";
        }
    }
}

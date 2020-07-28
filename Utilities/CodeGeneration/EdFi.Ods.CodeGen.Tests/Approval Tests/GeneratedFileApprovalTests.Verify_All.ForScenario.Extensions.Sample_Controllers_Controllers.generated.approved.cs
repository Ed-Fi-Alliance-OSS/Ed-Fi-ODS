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
using EdFi.Ods.Entities.Common.Sample;
using EdFi.Ods.Pipelines.Factories;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Api.Services.Queries;
using EdFi.Ods.Api.Services.Requests;
using EdFi.Ods.Common.Configuration;

namespace EdFi.Ods.Api.Services.Controllers.Sample.ArtMediumDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ArtMediumDescriptorsController : EdFiControllerBase<
        Models.Resources.ArtMediumDescriptor.Sample.ArtMediumDescriptor,
        Models.Resources.ArtMediumDescriptor.Sample.ArtMediumDescriptor,
        Entities.Common.Sample.IArtMediumDescriptor,
        Entities.NHibernate.ArtMediumDescriptorAggregate.Sample.ArtMediumDescriptor,
        Api.Models.Requests.Sample.ArtMediumDescriptors.ArtMediumDescriptorPut,
        Api.Models.Requests.Sample.ArtMediumDescriptors.ArtMediumDescriptorPost,
        Api.Models.Requests.Sample.ArtMediumDescriptors.ArtMediumDescriptorDelete,
        Api.Models.Requests.Sample.ArtMediumDescriptors.ArtMediumDescriptorGetByExample>
    {
        public ArtMediumDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.ArtMediumDescriptors.ArtMediumDescriptorGetByExample request, Entities.Common.Sample.IArtMediumDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ArtMediumDescriptorId = request.ArtMediumDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "artMediumDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.Buses
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusesController : EdFiControllerBase<
        Models.Resources.Bus.Sample.Bus,
        Models.Resources.Bus.Sample.Bus,
        Entities.Common.Sample.IBus,
        Entities.NHibernate.BusAggregate.Sample.Bus,
        Api.Models.Requests.Sample.Buses.BusPut,
        Api.Models.Requests.Sample.Buses.BusPost,
        Api.Models.Requests.Sample.Buses.BusDelete,
        Api.Models.Requests.Sample.Buses.BusGetByExample>
    {
        public BusesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.Buses.BusGetByExample request, Entities.Common.Sample.IBus specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BusId = request.BusId;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "buses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.BusRoutes
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BusRoutesController : EdFiControllerBase<
        Models.Resources.BusRoute.Sample.BusRoute,
        Models.Resources.BusRoute.Sample.BusRoute,
        Entities.Common.Sample.IBusRoute,
        Entities.NHibernate.BusRouteAggregate.Sample.BusRoute,
        Api.Models.Requests.Sample.BusRoutes.BusRoutePut,
        Api.Models.Requests.Sample.BusRoutes.BusRoutePost,
        Api.Models.Requests.Sample.BusRoutes.BusRouteDelete,
        Api.Models.Requests.Sample.BusRoutes.BusRouteGetByExample>
    {
        public BusRoutesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.BusRoutes.BusRouteGetByExample request, Entities.Common.Sample.IBusRoute specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.FavoriteBookCategoryDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FavoriteBookCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.FavoriteBookCategoryDescriptor.Sample.FavoriteBookCategoryDescriptor,
        Models.Resources.FavoriteBookCategoryDescriptor.Sample.FavoriteBookCategoryDescriptor,
        Entities.Common.Sample.IFavoriteBookCategoryDescriptor,
        Entities.NHibernate.FavoriteBookCategoryDescriptorAggregate.Sample.FavoriteBookCategoryDescriptor,
        Api.Models.Requests.Sample.FavoriteBookCategoryDescriptors.FavoriteBookCategoryDescriptorPut,
        Api.Models.Requests.Sample.FavoriteBookCategoryDescriptors.FavoriteBookCategoryDescriptorPost,
        Api.Models.Requests.Sample.FavoriteBookCategoryDescriptors.FavoriteBookCategoryDescriptorDelete,
        Api.Models.Requests.Sample.FavoriteBookCategoryDescriptors.FavoriteBookCategoryDescriptorGetByExample>
    {
        public FavoriteBookCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.FavoriteBookCategoryDescriptors.FavoriteBookCategoryDescriptorGetByExample request, Entities.Common.Sample.IFavoriteBookCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FavoriteBookCategoryDescriptorId = request.FavoriteBookCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "favoriteBookCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.MembershipTypeDescriptors
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class MembershipTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.MembershipTypeDescriptor.Sample.MembershipTypeDescriptor,
        Models.Resources.MembershipTypeDescriptor.Sample.MembershipTypeDescriptor,
        Entities.Common.Sample.IMembershipTypeDescriptor,
        Entities.NHibernate.MembershipTypeDescriptorAggregate.Sample.MembershipTypeDescriptor,
        Api.Models.Requests.Sample.MembershipTypeDescriptors.MembershipTypeDescriptorPut,
        Api.Models.Requests.Sample.MembershipTypeDescriptors.MembershipTypeDescriptorPost,
        Api.Models.Requests.Sample.MembershipTypeDescriptors.MembershipTypeDescriptorDelete,
        Api.Models.Requests.Sample.MembershipTypeDescriptors.MembershipTypeDescriptorGetByExample>
    {
        public MembershipTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.MembershipTypeDescriptors.MembershipTypeDescriptorGetByExample request, Entities.Common.Sample.IMembershipTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MembershipTypeDescriptorId = request.MembershipTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "membershipTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.StudentArtProgramAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentArtProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentArtProgramAssociation.Sample.StudentArtProgramAssociation,
        Models.Resources.StudentArtProgramAssociation.Sample.StudentArtProgramAssociation,
        Entities.Common.Sample.IStudentArtProgramAssociation,
        Entities.NHibernate.StudentArtProgramAssociationAggregate.Sample.StudentArtProgramAssociation,
        Api.Models.Requests.Sample.StudentArtProgramAssociations.StudentArtProgramAssociationPut,
        Api.Models.Requests.Sample.StudentArtProgramAssociations.StudentArtProgramAssociationPost,
        Api.Models.Requests.Sample.StudentArtProgramAssociations.StudentArtProgramAssociationDelete,
        Api.Models.Requests.Sample.StudentArtProgramAssociations.StudentArtProgramAssociationGetByExample>
    {
        public StudentArtProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.StudentArtProgramAssociations.StudentArtProgramAssociationGetByExample request, Entities.Common.Sample.IStudentArtProgramAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ArtPieces = request.ArtPieces;
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExhibitDate = request.ExhibitDate;
            specification.HoursPerDay = request.HoursPerDay;
            specification.IdentificationCode = request.IdentificationCode;
            specification.KilnReservation = request.KilnReservation;
            specification.KilnReservationLength = request.KilnReservationLength;
            specification.MasteredMediums = request.MasteredMediums;
            specification.NumberOfDaysInAttendance = request.NumberOfDaysInAttendance;
            specification.PortfolioPieces = request.PortfolioPieces;
            specification.PrivateArtProgram = request.PrivateArtProgram;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramFees = request.ProgramFees;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentArtProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sample.StudentGraduationPlanAssociations
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentGraduationPlanAssociationsController : EdFiControllerBase<
        Models.Resources.StudentGraduationPlanAssociation.Sample.StudentGraduationPlanAssociation,
        Models.Resources.StudentGraduationPlanAssociation.Sample.StudentGraduationPlanAssociation,
        Entities.Common.Sample.IStudentGraduationPlanAssociation,
        Entities.NHibernate.StudentGraduationPlanAssociationAggregate.Sample.StudentGraduationPlanAssociation,
        Api.Models.Requests.Sample.StudentGraduationPlanAssociations.StudentGraduationPlanAssociationPut,
        Api.Models.Requests.Sample.StudentGraduationPlanAssociations.StudentGraduationPlanAssociationPost,
        Api.Models.Requests.Sample.StudentGraduationPlanAssociations.StudentGraduationPlanAssociationDelete,
        Api.Models.Requests.Sample.StudentGraduationPlanAssociations.StudentGraduationPlanAssociationGetByExample>
    {
        public StudentGraduationPlanAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider, defaultPageSizeLimitProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sample.StudentGraduationPlanAssociations.StudentGraduationPlanAssociationGetByExample request, Entities.Common.Sample.IStudentGraduationPlanAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CommencementTime = request.CommencementTime;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EffectiveDate = request.EffectiveDate;
            specification.GraduationFee = request.GraduationFee;
            specification.GraduationPlanTypeDescriptor = request.GraduationPlanTypeDescriptor;
            specification.GraduationSchoolYear = request.GraduationSchoolYear;
            specification.HighSchoolDuration = request.HighSchoolDuration;
            specification.HoursPerWeek = request.HoursPerWeek;
            specification.Id = request.Id;
            specification.IsActivePlan = request.IsActivePlan;
            specification.RequiredAttendance = request.RequiredAttendance;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TargetGPA = request.TargetGPA;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentGraduationPlanAssociations";
        }
    }
}

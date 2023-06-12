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
using EdFi.Ods.Entities.Common.EdFi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Api.Services.Controllers.AbsenceEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/absenceEventCategoryDescriptors")]
    public partial class AbsenceEventCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AbsenceEventCategoryDescriptor.EdFi.AbsenceEventCategoryDescriptor,
        Entities.Common.EdFi.IAbsenceEventCategoryDescriptor,
        Entities.NHibernate.AbsenceEventCategoryDescriptorAggregate.EdFi.AbsenceEventCategoryDescriptor,
        Api.Common.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorPut,
        Api.Common.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorPost,
        Api.Common.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorDelete,
        Api.Common.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorGetByExample>
    {
        public AbsenceEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorGetByExample request, Entities.Common.EdFi.IAbsenceEventCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AbsenceEventCategoryDescriptorId = request.AbsenceEventCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicHonorCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/academicHonorCategoryDescriptors")]
    public partial class AcademicHonorCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AcademicHonorCategoryDescriptor.EdFi.AcademicHonorCategoryDescriptor,
        Entities.Common.EdFi.IAcademicHonorCategoryDescriptor,
        Entities.NHibernate.AcademicHonorCategoryDescriptorAggregate.EdFi.AcademicHonorCategoryDescriptor,
        Api.Common.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorPut,
        Api.Common.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorPost,
        Api.Common.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorDelete,
        Api.Common.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorGetByExample>
    {
        public AcademicHonorCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorGetByExample request, Entities.Common.EdFi.IAcademicHonorCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicHonorCategoryDescriptorId = request.AcademicHonorCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicSubjectDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/academicSubjectDescriptors")]
    public partial class AcademicSubjectDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AcademicSubjectDescriptor.EdFi.AcademicSubjectDescriptor,
        Entities.Common.EdFi.IAcademicSubjectDescriptor,
        Entities.NHibernate.AcademicSubjectDescriptorAggregate.EdFi.AcademicSubjectDescriptor,
        Api.Common.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorPut,
        Api.Common.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorPost,
        Api.Common.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorDelete,
        Api.Common.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorGetByExample>
    {
        public AcademicSubjectDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorGetByExample request, Entities.Common.EdFi.IAcademicSubjectDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptorId = request.AcademicSubjectDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicWeeks.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/academicWeeks")]
    public partial class AcademicWeeksController : DataManagementControllerBase<
        Api.Common.Models.Resources.AcademicWeek.EdFi.AcademicWeek,
        Entities.Common.EdFi.IAcademicWeek,
        Entities.NHibernate.AcademicWeekAggregate.EdFi.AcademicWeek,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.AcademicWeekPut,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.AcademicWeekPost,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.AcademicWeekDelete,
        Api.Common.Models.Requests.AcademicWeeks.EdFi.AcademicWeekGetByExample>
    {
        public AcademicWeeksController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AcademicWeeks.EdFi.AcademicWeekGetByExample request, Entities.Common.EdFi.IAcademicWeek specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.TotalInstructionalDays = request.TotalInstructionalDays;
            specification.WeekIdentifier = request.WeekIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccommodationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/accommodationDescriptors")]
    public partial class AccommodationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AccommodationDescriptor.EdFi.AccommodationDescriptor,
        Entities.Common.EdFi.IAccommodationDescriptor,
        Entities.NHibernate.AccommodationDescriptorAggregate.EdFi.AccommodationDescriptor,
        Api.Common.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorPut,
        Api.Common.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorPost,
        Api.Common.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorDelete,
        Api.Common.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorGetByExample>
    {
        public AccommodationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorGetByExample request, Entities.Common.EdFi.IAccommodationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccommodationDescriptorId = request.AccommodationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccountabilityRatings.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/accountabilityRatings")]
    public partial class AccountabilityRatingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AccountabilityRating.EdFi.AccountabilityRating,
        Entities.Common.EdFi.IAccountabilityRating,
        Entities.NHibernate.AccountabilityRatingAggregate.EdFi.AccountabilityRating,
        Api.Common.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingPut,
        Api.Common.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingPost,
        Api.Common.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingDelete,
        Api.Common.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingGetByExample>
    {
        public AccountabilityRatingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingGetByExample request, Entities.Common.EdFi.IAccountabilityRating specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Rating = request.Rating;
            specification.RatingDate = request.RatingDate;
            specification.RatingOrganization = request.RatingOrganization;
            specification.RatingProgram = request.RatingProgram;
            specification.RatingTitle = request.RatingTitle;
            specification.SchoolYear = request.SchoolYear;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccountTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/accountTypeDescriptors")]
    public partial class AccountTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AccountTypeDescriptor.EdFi.AccountTypeDescriptor,
        Entities.Common.EdFi.IAccountTypeDescriptor,
        Entities.NHibernate.AccountTypeDescriptorAggregate.EdFi.AccountTypeDescriptor,
        Api.Common.Models.Requests.AccountTypeDescriptors.EdFi.AccountTypeDescriptorPut,
        Api.Common.Models.Requests.AccountTypeDescriptors.EdFi.AccountTypeDescriptorPost,
        Api.Common.Models.Requests.AccountTypeDescriptors.EdFi.AccountTypeDescriptorDelete,
        Api.Common.Models.Requests.AccountTypeDescriptors.EdFi.AccountTypeDescriptorGetByExample>
    {
        public AccountTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AccountTypeDescriptors.EdFi.AccountTypeDescriptorGetByExample request, Entities.Common.EdFi.IAccountTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountTypeDescriptorId = request.AccountTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AchievementCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/achievementCategoryDescriptors")]
    public partial class AchievementCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AchievementCategoryDescriptor.EdFi.AchievementCategoryDescriptor,
        Entities.Common.EdFi.IAchievementCategoryDescriptor,
        Entities.NHibernate.AchievementCategoryDescriptorAggregate.EdFi.AchievementCategoryDescriptor,
        Api.Common.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorPut,
        Api.Common.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorPost,
        Api.Common.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorDelete,
        Api.Common.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorGetByExample>
    {
        public AchievementCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorGetByExample request, Entities.Common.EdFi.IAchievementCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AchievementCategoryDescriptorId = request.AchievementCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AdditionalCreditTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/additionalCreditTypeDescriptors")]
    public partial class AdditionalCreditTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AdditionalCreditTypeDescriptor.EdFi.AdditionalCreditTypeDescriptor,
        Entities.Common.EdFi.IAdditionalCreditTypeDescriptor,
        Entities.NHibernate.AdditionalCreditTypeDescriptorAggregate.EdFi.AdditionalCreditTypeDescriptor,
        Api.Common.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorPut,
        Api.Common.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorPost,
        Api.Common.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorDelete,
        Api.Common.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorGetByExample>
    {
        public AdditionalCreditTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorGetByExample request, Entities.Common.EdFi.IAdditionalCreditTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdditionalCreditTypeDescriptorId = request.AdditionalCreditTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AddressTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/addressTypeDescriptors")]
    public partial class AddressTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AddressTypeDescriptor.EdFi.AddressTypeDescriptor,
        Entities.Common.EdFi.IAddressTypeDescriptor,
        Entities.NHibernate.AddressTypeDescriptorAggregate.EdFi.AddressTypeDescriptor,
        Api.Common.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorPut,
        Api.Common.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorPost,
        Api.Common.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorDelete,
        Api.Common.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorGetByExample>
    {
        public AddressTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorGetByExample request, Entities.Common.EdFi.IAddressTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AddressTypeDescriptorId = request.AddressTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AdministrationEnvironmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/administrationEnvironmentDescriptors")]
    public partial class AdministrationEnvironmentDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AdministrationEnvironmentDescriptor.EdFi.AdministrationEnvironmentDescriptor,
        Entities.Common.EdFi.IAdministrationEnvironmentDescriptor,
        Entities.NHibernate.AdministrationEnvironmentDescriptorAggregate.EdFi.AdministrationEnvironmentDescriptor,
        Api.Common.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorPut,
        Api.Common.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorPost,
        Api.Common.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorDelete,
        Api.Common.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorGetByExample>
    {
        public AdministrationEnvironmentDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorGetByExample request, Entities.Common.EdFi.IAdministrationEnvironmentDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationEnvironmentDescriptorId = request.AdministrationEnvironmentDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AdministrativeFundingControlDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/administrativeFundingControlDescriptors")]
    public partial class AdministrativeFundingControlDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AdministrativeFundingControlDescriptor.EdFi.AdministrativeFundingControlDescriptor,
        Entities.Common.EdFi.IAdministrativeFundingControlDescriptor,
        Entities.NHibernate.AdministrativeFundingControlDescriptorAggregate.EdFi.AdministrativeFundingControlDescriptor,
        Api.Common.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorPut,
        Api.Common.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorPost,
        Api.Common.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorDelete,
        Api.Common.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorGetByExample>
    {
        public AdministrativeFundingControlDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorGetByExample request, Entities.Common.EdFi.IAdministrativeFundingControlDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptorId = request.AdministrativeFundingControlDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AncestryEthnicOriginDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/ancestryEthnicOriginDescriptors")]
    public partial class AncestryEthnicOriginDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AncestryEthnicOriginDescriptor.EdFi.AncestryEthnicOriginDescriptor,
        Entities.Common.EdFi.IAncestryEthnicOriginDescriptor,
        Entities.NHibernate.AncestryEthnicOriginDescriptorAggregate.EdFi.AncestryEthnicOriginDescriptor,
        Api.Common.Models.Requests.AncestryEthnicOriginDescriptors.EdFi.AncestryEthnicOriginDescriptorPut,
        Api.Common.Models.Requests.AncestryEthnicOriginDescriptors.EdFi.AncestryEthnicOriginDescriptorPost,
        Api.Common.Models.Requests.AncestryEthnicOriginDescriptors.EdFi.AncestryEthnicOriginDescriptorDelete,
        Api.Common.Models.Requests.AncestryEthnicOriginDescriptors.EdFi.AncestryEthnicOriginDescriptorGetByExample>
    {
        public AncestryEthnicOriginDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AncestryEthnicOriginDescriptors.EdFi.AncestryEthnicOriginDescriptorGetByExample request, Entities.Common.EdFi.IAncestryEthnicOriginDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AncestryEthnicOriginDescriptorId = request.AncestryEthnicOriginDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Assessments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessments")]
    public partial class AssessmentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Assessment.EdFi.Assessment,
        Entities.Common.EdFi.IAssessment,
        Entities.NHibernate.AssessmentAggregate.EdFi.Assessment,
        Api.Common.Models.Requests.Assessments.EdFi.AssessmentPut,
        Api.Common.Models.Requests.Assessments.EdFi.AssessmentPost,
        Api.Common.Models.Requests.Assessments.EdFi.AssessmentDelete,
        Api.Common.Models.Requests.Assessments.EdFi.AssessmentGetByExample>
    {
        public AssessmentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Assessments.EdFi.AssessmentGetByExample request, Entities.Common.EdFi.IAssessment specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdaptiveAssessment = request.AdaptiveAssessment;
            specification.AssessmentCategoryDescriptor = request.AssessmentCategoryDescriptor;
            specification.AssessmentFamily = request.AssessmentFamily;
            specification.AssessmentForm = request.AssessmentForm;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentTitle = request.AssessmentTitle;
            specification.AssessmentVersion = request.AssessmentVersion;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.MaxRawScore = request.MaxRawScore;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
            specification.RevisionDate = request.RevisionDate;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentCategoryDescriptors")]
    public partial class AssessmentCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentCategoryDescriptor.EdFi.AssessmentCategoryDescriptor,
        Entities.Common.EdFi.IAssessmentCategoryDescriptor,
        Entities.NHibernate.AssessmentCategoryDescriptorAggregate.EdFi.AssessmentCategoryDescriptor,
        Api.Common.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorPut,
        Api.Common.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorPost,
        Api.Common.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorDelete,
        Api.Common.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorGetByExample>
    {
        public AssessmentCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorGetByExample request, Entities.Common.EdFi.IAssessmentCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentCategoryDescriptorId = request.AssessmentCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentIdentificationSystemDescriptors")]
    public partial class AssessmentIdentificationSystemDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentIdentificationSystemDescriptor.EdFi.AssessmentIdentificationSystemDescriptor,
        Entities.Common.EdFi.IAssessmentIdentificationSystemDescriptor,
        Entities.NHibernate.AssessmentIdentificationSystemDescriptorAggregate.EdFi.AssessmentIdentificationSystemDescriptor,
        Api.Common.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorPut,
        Api.Common.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorPost,
        Api.Common.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorDelete,
        Api.Common.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorGetByExample>
    {
        public AssessmentIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorGetByExample request, Entities.Common.EdFi.IAssessmentIdentificationSystemDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentIdentificationSystemDescriptorId = request.AssessmentIdentificationSystemDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentItems.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentItems")]
    public partial class AssessmentItemsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentItem.EdFi.AssessmentItem,
        Entities.Common.EdFi.IAssessmentItem,
        Entities.NHibernate.AssessmentItemAggregate.EdFi.AssessmentItem,
        Api.Common.Models.Requests.AssessmentItems.EdFi.AssessmentItemPut,
        Api.Common.Models.Requests.AssessmentItems.EdFi.AssessmentItemPost,
        Api.Common.Models.Requests.AssessmentItems.EdFi.AssessmentItemDelete,
        Api.Common.Models.Requests.AssessmentItems.EdFi.AssessmentItemGetByExample>
    {
        public AssessmentItemsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentItems.EdFi.AssessmentItemGetByExample request, Entities.Common.EdFi.IAssessmentItem specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentItemCategoryDescriptor = request.AssessmentItemCategoryDescriptor;
            specification.AssessmentItemURI = request.AssessmentItemURI;
            specification.ExpectedTimeAssessed = request.ExpectedTimeAssessed;
            specification.Id = request.Id;
            specification.IdentificationCode = request.IdentificationCode;
            specification.ItemText = request.ItemText;
            specification.MaxRawScore = request.MaxRawScore;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentItemCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentItemCategoryDescriptors")]
    public partial class AssessmentItemCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentItemCategoryDescriptor.EdFi.AssessmentItemCategoryDescriptor,
        Entities.Common.EdFi.IAssessmentItemCategoryDescriptor,
        Entities.NHibernate.AssessmentItemCategoryDescriptorAggregate.EdFi.AssessmentItemCategoryDescriptor,
        Api.Common.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorPut,
        Api.Common.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorPost,
        Api.Common.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorDelete,
        Api.Common.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorGetByExample>
    {
        public AssessmentItemCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorGetByExample request, Entities.Common.EdFi.IAssessmentItemCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentItemCategoryDescriptorId = request.AssessmentItemCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentItemResultDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentItemResultDescriptors")]
    public partial class AssessmentItemResultDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentItemResultDescriptor.EdFi.AssessmentItemResultDescriptor,
        Entities.Common.EdFi.IAssessmentItemResultDescriptor,
        Entities.NHibernate.AssessmentItemResultDescriptorAggregate.EdFi.AssessmentItemResultDescriptor,
        Api.Common.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorPut,
        Api.Common.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorPost,
        Api.Common.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorDelete,
        Api.Common.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorGetByExample>
    {
        public AssessmentItemResultDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorGetByExample request, Entities.Common.EdFi.IAssessmentItemResultDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentItemResultDescriptorId = request.AssessmentItemResultDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentPeriodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentPeriodDescriptors")]
    public partial class AssessmentPeriodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor,
        Entities.Common.EdFi.IAssessmentPeriodDescriptor,
        Entities.NHibernate.AssessmentPeriodDescriptorAggregate.EdFi.AssessmentPeriodDescriptor,
        Api.Common.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorPut,
        Api.Common.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorPost,
        Api.Common.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorDelete,
        Api.Common.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorGetByExample>
    {
        public AssessmentPeriodDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorGetByExample request, Entities.Common.EdFi.IAssessmentPeriodDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentPeriodDescriptorId = request.AssessmentPeriodDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentReportingMethodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentReportingMethodDescriptors")]
    public partial class AssessmentReportingMethodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentReportingMethodDescriptor.EdFi.AssessmentReportingMethodDescriptor,
        Entities.Common.EdFi.IAssessmentReportingMethodDescriptor,
        Entities.NHibernate.AssessmentReportingMethodDescriptorAggregate.EdFi.AssessmentReportingMethodDescriptor,
        Api.Common.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorPut,
        Api.Common.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorPost,
        Api.Common.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorDelete,
        Api.Common.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorGetByExample>
    {
        public AssessmentReportingMethodDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorGetByExample request, Entities.Common.EdFi.IAssessmentReportingMethodDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentReportingMethodDescriptorId = request.AssessmentReportingMethodDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentScoreRangeLearningStandards.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assessmentScoreRangeLearningStandards")]
    public partial class AssessmentScoreRangeLearningStandardsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssessmentScoreRangeLearningStandard.EdFi.AssessmentScoreRangeLearningStandard,
        Entities.Common.EdFi.IAssessmentScoreRangeLearningStandard,
        Entities.NHibernate.AssessmentScoreRangeLearningStandardAggregate.EdFi.AssessmentScoreRangeLearningStandard,
        Api.Common.Models.Requests.AssessmentScoreRangeLearningStandards.EdFi.AssessmentScoreRangeLearningStandardPut,
        Api.Common.Models.Requests.AssessmentScoreRangeLearningStandards.EdFi.AssessmentScoreRangeLearningStandardPost,
        Api.Common.Models.Requests.AssessmentScoreRangeLearningStandards.EdFi.AssessmentScoreRangeLearningStandardDelete,
        Api.Common.Models.Requests.AssessmentScoreRangeLearningStandards.EdFi.AssessmentScoreRangeLearningStandardGetByExample>
    {
        public AssessmentScoreRangeLearningStandardsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssessmentScoreRangeLearningStandards.EdFi.AssessmentScoreRangeLearningStandardGetByExample request, Entities.Common.EdFi.IAssessmentScoreRangeLearningStandard specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentReportingMethodDescriptor = request.AssessmentReportingMethodDescriptor;
            specification.Id = request.Id;
            specification.IdentificationCode = request.IdentificationCode;
            specification.MaximumScore = request.MaximumScore;
            specification.MinimumScore = request.MinimumScore;
            specification.Namespace = request.Namespace;
            specification.ScoreRangeId = request.ScoreRangeId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssignmentLateStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/assignmentLateStatusDescriptors")]
    public partial class AssignmentLateStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AssignmentLateStatusDescriptor.EdFi.AssignmentLateStatusDescriptor,
        Entities.Common.EdFi.IAssignmentLateStatusDescriptor,
        Entities.NHibernate.AssignmentLateStatusDescriptorAggregate.EdFi.AssignmentLateStatusDescriptor,
        Api.Common.Models.Requests.AssignmentLateStatusDescriptors.EdFi.AssignmentLateStatusDescriptorPut,
        Api.Common.Models.Requests.AssignmentLateStatusDescriptors.EdFi.AssignmentLateStatusDescriptorPost,
        Api.Common.Models.Requests.AssignmentLateStatusDescriptors.EdFi.AssignmentLateStatusDescriptorDelete,
        Api.Common.Models.Requests.AssignmentLateStatusDescriptors.EdFi.AssignmentLateStatusDescriptorGetByExample>
    {
        public AssignmentLateStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AssignmentLateStatusDescriptors.EdFi.AssignmentLateStatusDescriptorGetByExample request, Entities.Common.EdFi.IAssignmentLateStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssignmentLateStatusDescriptorId = request.AssignmentLateStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AttemptStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/attemptStatusDescriptors")]
    public partial class AttemptStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AttemptStatusDescriptor.EdFi.AttemptStatusDescriptor,
        Entities.Common.EdFi.IAttemptStatusDescriptor,
        Entities.NHibernate.AttemptStatusDescriptorAggregate.EdFi.AttemptStatusDescriptor,
        Api.Common.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorPut,
        Api.Common.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorPost,
        Api.Common.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorDelete,
        Api.Common.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorGetByExample>
    {
        public AttemptStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorGetByExample request, Entities.Common.EdFi.IAttemptStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttemptStatusDescriptorId = request.AttemptStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AttendanceEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/attendanceEventCategoryDescriptors")]
    public partial class AttendanceEventCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.AttendanceEventCategoryDescriptor.EdFi.AttendanceEventCategoryDescriptor,
        Entities.Common.EdFi.IAttendanceEventCategoryDescriptor,
        Entities.NHibernate.AttendanceEventCategoryDescriptorAggregate.EdFi.AttendanceEventCategoryDescriptor,
        Api.Common.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorPut,
        Api.Common.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorPost,
        Api.Common.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorDelete,
        Api.Common.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorGetByExample>
    {
        public AttendanceEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorGetByExample request, Entities.Common.EdFi.IAttendanceEventCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceEventCategoryDescriptorId = request.AttendanceEventCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.BalanceSheetDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/balanceSheetDimensions")]
    public partial class BalanceSheetDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.BalanceSheetDimension.EdFi.BalanceSheetDimension,
        Entities.Common.EdFi.IBalanceSheetDimension,
        Entities.NHibernate.BalanceSheetDimensionAggregate.EdFi.BalanceSheetDimension,
        Api.Common.Models.Requests.BalanceSheetDimensions.EdFi.BalanceSheetDimensionPut,
        Api.Common.Models.Requests.BalanceSheetDimensions.EdFi.BalanceSheetDimensionPost,
        Api.Common.Models.Requests.BalanceSheetDimensions.EdFi.BalanceSheetDimensionDelete,
        Api.Common.Models.Requests.BalanceSheetDimensions.EdFi.BalanceSheetDimensionGetByExample>
    {
        public BalanceSheetDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.BalanceSheetDimensions.EdFi.BalanceSheetDimensionGetByExample request, Entities.Common.EdFi.IBalanceSheetDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.BarrierToInternetAccessInResidenceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/barrierToInternetAccessInResidenceDescriptors")]
    public partial class BarrierToInternetAccessInResidenceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.BarrierToInternetAccessInResidenceDescriptor.EdFi.BarrierToInternetAccessInResidenceDescriptor,
        Entities.Common.EdFi.IBarrierToInternetAccessInResidenceDescriptor,
        Entities.NHibernate.BarrierToInternetAccessInResidenceDescriptorAggregate.EdFi.BarrierToInternetAccessInResidenceDescriptor,
        Api.Common.Models.Requests.BarrierToInternetAccessInResidenceDescriptors.EdFi.BarrierToInternetAccessInResidenceDescriptorPut,
        Api.Common.Models.Requests.BarrierToInternetAccessInResidenceDescriptors.EdFi.BarrierToInternetAccessInResidenceDescriptorPost,
        Api.Common.Models.Requests.BarrierToInternetAccessInResidenceDescriptors.EdFi.BarrierToInternetAccessInResidenceDescriptorDelete,
        Api.Common.Models.Requests.BarrierToInternetAccessInResidenceDescriptors.EdFi.BarrierToInternetAccessInResidenceDescriptorGetByExample>
    {
        public BarrierToInternetAccessInResidenceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.BarrierToInternetAccessInResidenceDescriptors.EdFi.BarrierToInternetAccessInResidenceDescriptorGetByExample request, Entities.Common.EdFi.IBarrierToInternetAccessInResidenceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BarrierToInternetAccessInResidenceDescriptorId = request.BarrierToInternetAccessInResidenceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.BehaviorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/behaviorDescriptors")]
    public partial class BehaviorDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.BehaviorDescriptor.EdFi.BehaviorDescriptor,
        Entities.Common.EdFi.IBehaviorDescriptor,
        Entities.NHibernate.BehaviorDescriptorAggregate.EdFi.BehaviorDescriptor,
        Api.Common.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorPut,
        Api.Common.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorPost,
        Api.Common.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorDelete,
        Api.Common.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorGetByExample>
    {
        public BehaviorDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorGetByExample request, Entities.Common.EdFi.IBehaviorDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BehaviorDescriptorId = request.BehaviorDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.BellSchedules.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/bellSchedules")]
    public partial class BellSchedulesController : DataManagementControllerBase<
        Api.Common.Models.Resources.BellSchedule.EdFi.BellSchedule,
        Entities.Common.EdFi.IBellSchedule,
        Entities.NHibernate.BellScheduleAggregate.EdFi.BellSchedule,
        Api.Common.Models.Requests.BellSchedules.EdFi.BellSchedulePut,
        Api.Common.Models.Requests.BellSchedules.EdFi.BellSchedulePost,
        Api.Common.Models.Requests.BellSchedules.EdFi.BellScheduleDelete,
        Api.Common.Models.Requests.BellSchedules.EdFi.BellScheduleGetByExample>
    {
        public BellSchedulesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.BellSchedules.EdFi.BellScheduleGetByExample request, Entities.Common.EdFi.IBellSchedule specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AlternateDayName = request.AlternateDayName;
            specification.BellScheduleName = request.BellScheduleName;
            specification.EndTime = request.EndTime;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.StartTime = request.StartTime;
            specification.TotalInstructionalTime = request.TotalInstructionalTime;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Calendars.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/calendars")]
    public partial class CalendarsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Calendar.EdFi.Calendar,
        Entities.Common.EdFi.ICalendar,
        Entities.NHibernate.CalendarAggregate.EdFi.Calendar,
        Api.Common.Models.Requests.Calendars.EdFi.CalendarPut,
        Api.Common.Models.Requests.Calendars.EdFi.CalendarPost,
        Api.Common.Models.Requests.Calendars.EdFi.CalendarDelete,
        Api.Common.Models.Requests.Calendars.EdFi.CalendarGetByExample>
    {
        public CalendarsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Calendars.EdFi.CalendarGetByExample request, Entities.Common.EdFi.ICalendar specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.CalendarTypeDescriptor = request.CalendarTypeDescriptor;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CalendarDates.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/calendarDates")]
    public partial class CalendarDatesController : DataManagementControllerBase<
        Api.Common.Models.Resources.CalendarDate.EdFi.CalendarDate,
        Entities.Common.EdFi.ICalendarDate,
        Entities.NHibernate.CalendarDateAggregate.EdFi.CalendarDate,
        Api.Common.Models.Requests.CalendarDates.EdFi.CalendarDatePut,
        Api.Common.Models.Requests.CalendarDates.EdFi.CalendarDatePost,
        Api.Common.Models.Requests.CalendarDates.EdFi.CalendarDateDelete,
        Api.Common.Models.Requests.CalendarDates.EdFi.CalendarDateGetByExample>
    {
        public CalendarDatesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CalendarDates.EdFi.CalendarDateGetByExample request, Entities.Common.EdFi.ICalendarDate specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.Date = request.Date;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CalendarEventDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/calendarEventDescriptors")]
    public partial class CalendarEventDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CalendarEventDescriptor.EdFi.CalendarEventDescriptor,
        Entities.Common.EdFi.ICalendarEventDescriptor,
        Entities.NHibernate.CalendarEventDescriptorAggregate.EdFi.CalendarEventDescriptor,
        Api.Common.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorPut,
        Api.Common.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorPost,
        Api.Common.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorDelete,
        Api.Common.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorGetByExample>
    {
        public CalendarEventDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorGetByExample request, Entities.Common.EdFi.ICalendarEventDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarEventDescriptorId = request.CalendarEventDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CalendarTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/calendarTypeDescriptors")]
    public partial class CalendarTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CalendarTypeDescriptor.EdFi.CalendarTypeDescriptor,
        Entities.Common.EdFi.ICalendarTypeDescriptor,
        Entities.NHibernate.CalendarTypeDescriptorAggregate.EdFi.CalendarTypeDescriptor,
        Api.Common.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorPut,
        Api.Common.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorPost,
        Api.Common.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorDelete,
        Api.Common.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorGetByExample>
    {
        public CalendarTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorGetByExample request, Entities.Common.EdFi.ICalendarTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarTypeDescriptorId = request.CalendarTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CareerPathwayDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/careerPathwayDescriptors")]
    public partial class CareerPathwayDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CareerPathwayDescriptor.EdFi.CareerPathwayDescriptor,
        Entities.Common.EdFi.ICareerPathwayDescriptor,
        Entities.NHibernate.CareerPathwayDescriptorAggregate.EdFi.CareerPathwayDescriptor,
        Api.Common.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorPut,
        Api.Common.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorPost,
        Api.Common.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorDelete,
        Api.Common.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorGetByExample>
    {
        public CareerPathwayDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorGetByExample request, Entities.Common.EdFi.ICareerPathwayDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CareerPathwayDescriptorId = request.CareerPathwayDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CharterApprovalAgencyTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/charterApprovalAgencyTypeDescriptors")]
    public partial class CharterApprovalAgencyTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CharterApprovalAgencyTypeDescriptor.EdFi.CharterApprovalAgencyTypeDescriptor,
        Entities.Common.EdFi.ICharterApprovalAgencyTypeDescriptor,
        Entities.NHibernate.CharterApprovalAgencyTypeDescriptorAggregate.EdFi.CharterApprovalAgencyTypeDescriptor,
        Api.Common.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorPut,
        Api.Common.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorPost,
        Api.Common.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorDelete,
        Api.Common.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorGetByExample>
    {
        public CharterApprovalAgencyTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorGetByExample request, Entities.Common.EdFi.ICharterApprovalAgencyTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterApprovalAgencyTypeDescriptorId = request.CharterApprovalAgencyTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CharterStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/charterStatusDescriptors")]
    public partial class CharterStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CharterStatusDescriptor.EdFi.CharterStatusDescriptor,
        Entities.Common.EdFi.ICharterStatusDescriptor,
        Entities.NHibernate.CharterStatusDescriptorAggregate.EdFi.CharterStatusDescriptor,
        Api.Common.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorPut,
        Api.Common.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorPost,
        Api.Common.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorDelete,
        Api.Common.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorGetByExample>
    {
        public CharterStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorGetByExample request, Entities.Common.EdFi.ICharterStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterStatusDescriptorId = request.CharterStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ChartOfAccounts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/chartOfAccounts")]
    public partial class ChartOfAccountsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ChartOfAccount.EdFi.ChartOfAccount,
        Entities.Common.EdFi.IChartOfAccount,
        Entities.NHibernate.ChartOfAccountAggregate.EdFi.ChartOfAccount,
        Api.Common.Models.Requests.ChartOfAccounts.EdFi.ChartOfAccountPut,
        Api.Common.Models.Requests.ChartOfAccounts.EdFi.ChartOfAccountPost,
        Api.Common.Models.Requests.ChartOfAccounts.EdFi.ChartOfAccountDelete,
        Api.Common.Models.Requests.ChartOfAccounts.EdFi.ChartOfAccountGetByExample>
    {
        public ChartOfAccountsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ChartOfAccounts.EdFi.ChartOfAccountGetByExample request, Entities.Common.EdFi.IChartOfAccount specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.AccountName = request.AccountName;
            specification.AccountTypeDescriptor = request.AccountTypeDescriptor;
            specification.BalanceSheetCode = request.BalanceSheetCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.FunctionCode = request.FunctionCode;
            specification.FundCode = request.FundCode;
            specification.Id = request.Id;
            specification.ObjectCode = request.ObjectCode;
            specification.OperationalUnitCode = request.OperationalUnitCode;
            specification.ProgramCode = request.ProgramCode;
            specification.ProjectCode = request.ProjectCode;
            specification.SourceCode = request.SourceCode;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CitizenshipStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/citizenshipStatusDescriptors")]
    public partial class CitizenshipStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CitizenshipStatusDescriptor.EdFi.CitizenshipStatusDescriptor,
        Entities.Common.EdFi.ICitizenshipStatusDescriptor,
        Entities.NHibernate.CitizenshipStatusDescriptorAggregate.EdFi.CitizenshipStatusDescriptor,
        Api.Common.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorPut,
        Api.Common.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorPost,
        Api.Common.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorDelete,
        Api.Common.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorGetByExample>
    {
        public CitizenshipStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorGetByExample request, Entities.Common.EdFi.ICitizenshipStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CitizenshipStatusDescriptorId = request.CitizenshipStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ClassPeriods.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/classPeriods")]
    public partial class ClassPeriodsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ClassPeriod.EdFi.ClassPeriod,
        Entities.Common.EdFi.IClassPeriod,
        Entities.NHibernate.ClassPeriodAggregate.EdFi.ClassPeriod,
        Api.Common.Models.Requests.ClassPeriods.EdFi.ClassPeriodPut,
        Api.Common.Models.Requests.ClassPeriods.EdFi.ClassPeriodPost,
        Api.Common.Models.Requests.ClassPeriods.EdFi.ClassPeriodDelete,
        Api.Common.Models.Requests.ClassPeriods.EdFi.ClassPeriodGetByExample>
    {
        public ClassPeriodsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ClassPeriods.EdFi.ClassPeriodGetByExample request, Entities.Common.EdFi.IClassPeriod specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassPeriodName = request.ClassPeriodName;
            specification.Id = request.Id;
            specification.OfficialAttendancePeriod = request.OfficialAttendancePeriod;
            specification.SchoolId = request.SchoolId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ClassroomPositionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/classroomPositionDescriptors")]
    public partial class ClassroomPositionDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ClassroomPositionDescriptor.EdFi.ClassroomPositionDescriptor,
        Entities.Common.EdFi.IClassroomPositionDescriptor,
        Entities.NHibernate.ClassroomPositionDescriptorAggregate.EdFi.ClassroomPositionDescriptor,
        Api.Common.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorPut,
        Api.Common.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorPost,
        Api.Common.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorDelete,
        Api.Common.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorGetByExample>
    {
        public ClassroomPositionDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorGetByExample request, Entities.Common.EdFi.IClassroomPositionDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassroomPositionDescriptorId = request.ClassroomPositionDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Cohorts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/cohorts")]
    public partial class CohortsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Cohort.EdFi.Cohort,
        Entities.Common.EdFi.ICohort,
        Entities.NHibernate.CohortAggregate.EdFi.Cohort,
        Api.Common.Models.Requests.Cohorts.EdFi.CohortPut,
        Api.Common.Models.Requests.Cohorts.EdFi.CohortPost,
        Api.Common.Models.Requests.Cohorts.EdFi.CohortDelete,
        Api.Common.Models.Requests.Cohorts.EdFi.CohortGetByExample>
    {
        public CohortsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Cohorts.EdFi.CohortGetByExample request, Entities.Common.EdFi.ICohort specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.CohortDescription = request.CohortDescription;
            specification.CohortIdentifier = request.CohortIdentifier;
            specification.CohortScopeDescriptor = request.CohortScopeDescriptor;
            specification.CohortTypeDescriptor = request.CohortTypeDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CohortScopeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/cohortScopeDescriptors")]
    public partial class CohortScopeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CohortScopeDescriptor.EdFi.CohortScopeDescriptor,
        Entities.Common.EdFi.ICohortScopeDescriptor,
        Entities.NHibernate.CohortScopeDescriptorAggregate.EdFi.CohortScopeDescriptor,
        Api.Common.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorPut,
        Api.Common.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorPost,
        Api.Common.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorDelete,
        Api.Common.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorGetByExample>
    {
        public CohortScopeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorGetByExample request, Entities.Common.EdFi.ICohortScopeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortScopeDescriptorId = request.CohortScopeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CohortTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/cohortTypeDescriptors")]
    public partial class CohortTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CohortTypeDescriptor.EdFi.CohortTypeDescriptor,
        Entities.Common.EdFi.ICohortTypeDescriptor,
        Entities.NHibernate.CohortTypeDescriptorAggregate.EdFi.CohortTypeDescriptor,
        Api.Common.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorPut,
        Api.Common.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorPost,
        Api.Common.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorDelete,
        Api.Common.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorGetByExample>
    {
        public CohortTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorGetByExample request, Entities.Common.EdFi.ICohortTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortTypeDescriptorId = request.CohortTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CohortYearTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/cohortYearTypeDescriptors")]
    public partial class CohortYearTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CohortYearTypeDescriptor.EdFi.CohortYearTypeDescriptor,
        Entities.Common.EdFi.ICohortYearTypeDescriptor,
        Entities.NHibernate.CohortYearTypeDescriptorAggregate.EdFi.CohortYearTypeDescriptor,
        Api.Common.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorPut,
        Api.Common.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorPost,
        Api.Common.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorDelete,
        Api.Common.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorGetByExample>
    {
        public CohortYearTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorGetByExample request, Entities.Common.EdFi.ICohortYearTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortYearTypeDescriptorId = request.CohortYearTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CommunityOrganizations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/communityOrganizations")]
    public partial class CommunityOrganizationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CommunityOrganization.EdFi.CommunityOrganization,
        Entities.Common.EdFi.ICommunityOrganization,
        Entities.NHibernate.CommunityOrganizationAggregate.EdFi.CommunityOrganization,
        Api.Common.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationPut,
        Api.Common.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationPost,
        Api.Common.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationDelete,
        Api.Common.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationGetByExample>
    {
        public CommunityOrganizationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationGetByExample request, Entities.Common.EdFi.ICommunityOrganization specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CommunityOrganizationId = request.CommunityOrganizationId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CommunityProviders.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/communityProviders")]
    public partial class CommunityProvidersController : DataManagementControllerBase<
        Api.Common.Models.Resources.CommunityProvider.EdFi.CommunityProvider,
        Entities.Common.EdFi.ICommunityProvider,
        Entities.NHibernate.CommunityProviderAggregate.EdFi.CommunityProvider,
        Api.Common.Models.Requests.CommunityProviders.EdFi.CommunityProviderPut,
        Api.Common.Models.Requests.CommunityProviders.EdFi.CommunityProviderPost,
        Api.Common.Models.Requests.CommunityProviders.EdFi.CommunityProviderDelete,
        Api.Common.Models.Requests.CommunityProviders.EdFi.CommunityProviderGetByExample>
    {
        public CommunityProvidersController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CommunityProviders.EdFi.CommunityProviderGetByExample request, Entities.Common.EdFi.ICommunityProvider specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CommunityOrganizationId = request.CommunityOrganizationId;
            specification.CommunityProviderId = request.CommunityProviderId;
            specification.LicenseExemptIndicator = request.LicenseExemptIndicator;
            specification.ProviderCategoryDescriptor = request.ProviderCategoryDescriptor;
            specification.ProviderProfitabilityDescriptor = request.ProviderProfitabilityDescriptor;
            specification.ProviderStatusDescriptor = request.ProviderStatusDescriptor;
            specification.SchoolIndicator = request.SchoolIndicator;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CommunityProviderLicenses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/communityProviderLicenses")]
    public partial class CommunityProviderLicensesController : DataManagementControllerBase<
        Api.Common.Models.Resources.CommunityProviderLicense.EdFi.CommunityProviderLicense,
        Entities.Common.EdFi.ICommunityProviderLicense,
        Entities.NHibernate.CommunityProviderLicenseAggregate.EdFi.CommunityProviderLicense,
        Api.Common.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicensePut,
        Api.Common.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicensePost,
        Api.Common.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicenseDelete,
        Api.Common.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicenseGetByExample>
    {
        public CommunityProviderLicensesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicenseGetByExample request, Entities.Common.EdFi.ICommunityProviderLicense specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AuthorizedFacilityCapacity = request.AuthorizedFacilityCapacity;
            specification.CommunityProviderId = request.CommunityProviderId;
            specification.Id = request.Id;
            specification.LicenseEffectiveDate = request.LicenseEffectiveDate;
            specification.LicenseExpirationDate = request.LicenseExpirationDate;
            specification.LicenseIdentifier = request.LicenseIdentifier;
            specification.LicenseIssueDate = request.LicenseIssueDate;
            specification.LicenseStatusDescriptor = request.LicenseStatusDescriptor;
            specification.LicenseTypeDescriptor = request.LicenseTypeDescriptor;
            specification.LicensingOrganization = request.LicensingOrganization;
            specification.OldestAgeAuthorizedToServe = request.OldestAgeAuthorizedToServe;
            specification.YoungestAgeAuthorizedToServe = request.YoungestAgeAuthorizedToServe;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CompetencyLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/competencyLevelDescriptors")]
    public partial class CompetencyLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor,
        Entities.Common.EdFi.ICompetencyLevelDescriptor,
        Entities.NHibernate.CompetencyLevelDescriptorAggregate.EdFi.CompetencyLevelDescriptor,
        Api.Common.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorPut,
        Api.Common.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorPost,
        Api.Common.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorDelete,
        Api.Common.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorGetByExample>
    {
        public CompetencyLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorGetByExample request, Entities.Common.EdFi.ICompetencyLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CompetencyLevelDescriptorId = request.CompetencyLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CompetencyObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/competencyObjectives")]
    public partial class CompetencyObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.CompetencyObjective.EdFi.CompetencyObjective,
        Entities.Common.EdFi.ICompetencyObjective,
        Entities.NHibernate.CompetencyObjectiveAggregate.EdFi.CompetencyObjective,
        Api.Common.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectivePut,
        Api.Common.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectivePost,
        Api.Common.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectiveDelete,
        Api.Common.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectiveGetByExample>
    {
        public CompetencyObjectivesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectiveGetByExample request, Entities.Common.EdFi.ICompetencyObjective specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CompetencyObjectiveId = request.CompetencyObjectiveId;
            specification.Description = request.Description;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Objective = request.Objective;
            specification.ObjectiveGradeLevelDescriptor = request.ObjectiveGradeLevelDescriptor;
            specification.SuccessCriteria = request.SuccessCriteria;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContactTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/contactTypeDescriptors")]
    public partial class ContactTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ContactTypeDescriptor.EdFi.ContactTypeDescriptor,
        Entities.Common.EdFi.IContactTypeDescriptor,
        Entities.NHibernate.ContactTypeDescriptorAggregate.EdFi.ContactTypeDescriptor,
        Api.Common.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorPut,
        Api.Common.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorPost,
        Api.Common.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorDelete,
        Api.Common.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorGetByExample>
    {
        public ContactTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorGetByExample request, Entities.Common.EdFi.IContactTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContactTypeDescriptorId = request.ContactTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContentClassDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/contentClassDescriptors")]
    public partial class ContentClassDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ContentClassDescriptor.EdFi.ContentClassDescriptor,
        Entities.Common.EdFi.IContentClassDescriptor,
        Entities.NHibernate.ContentClassDescriptorAggregate.EdFi.ContentClassDescriptor,
        Api.Common.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorPut,
        Api.Common.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorPost,
        Api.Common.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorDelete,
        Api.Common.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorGetByExample>
    {
        public ContentClassDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorGetByExample request, Entities.Common.EdFi.IContentClassDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContentClassDescriptorId = request.ContentClassDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContinuationOfServicesReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/continuationOfServicesReasonDescriptors")]
    public partial class ContinuationOfServicesReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ContinuationOfServicesReasonDescriptor.EdFi.ContinuationOfServicesReasonDescriptor,
        Entities.Common.EdFi.IContinuationOfServicesReasonDescriptor,
        Entities.NHibernate.ContinuationOfServicesReasonDescriptorAggregate.EdFi.ContinuationOfServicesReasonDescriptor,
        Api.Common.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorPut,
        Api.Common.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorPost,
        Api.Common.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorDelete,
        Api.Common.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorGetByExample>
    {
        public ContinuationOfServicesReasonDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorGetByExample request, Entities.Common.EdFi.IContinuationOfServicesReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContinuationOfServicesReasonDescriptorId = request.ContinuationOfServicesReasonDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CostRateDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/costRateDescriptors")]
    public partial class CostRateDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CostRateDescriptor.EdFi.CostRateDescriptor,
        Entities.Common.EdFi.ICostRateDescriptor,
        Entities.NHibernate.CostRateDescriptorAggregate.EdFi.CostRateDescriptor,
        Api.Common.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorPut,
        Api.Common.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorPost,
        Api.Common.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorDelete,
        Api.Common.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorGetByExample>
    {
        public CostRateDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorGetByExample request, Entities.Common.EdFi.ICostRateDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CostRateDescriptorId = request.CostRateDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CountryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/countryDescriptors")]
    public partial class CountryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CountryDescriptor.EdFi.CountryDescriptor,
        Entities.Common.EdFi.ICountryDescriptor,
        Entities.NHibernate.CountryDescriptorAggregate.EdFi.CountryDescriptor,
        Api.Common.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorPut,
        Api.Common.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorPost,
        Api.Common.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorDelete,
        Api.Common.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorGetByExample>
    {
        public CountryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorGetByExample request, Entities.Common.EdFi.ICountryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CountryDescriptorId = request.CountryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Courses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courses")]
    public partial class CoursesController : DataManagementControllerBase<
        Api.Common.Models.Resources.Course.EdFi.Course,
        Entities.Common.EdFi.ICourse,
        Entities.NHibernate.CourseAggregate.EdFi.Course,
        Api.Common.Models.Requests.Courses.EdFi.CoursePut,
        Api.Common.Models.Requests.Courses.EdFi.CoursePost,
        Api.Common.Models.Requests.Courses.EdFi.CourseDelete,
        Api.Common.Models.Requests.Courses.EdFi.CourseGetByExample>
    {
        public CoursesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Courses.EdFi.CourseGetByExample request, Entities.Common.EdFi.ICourse specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.CareerPathwayDescriptor = request.CareerPathwayDescriptor;
            specification.CourseCode = request.CourseCode;
            specification.CourseDefinedByDescriptor = request.CourseDefinedByDescriptor;
            specification.CourseDescription = request.CourseDescription;
            specification.CourseGPAApplicabilityDescriptor = request.CourseGPAApplicabilityDescriptor;
            specification.CourseTitle = request.CourseTitle;
            specification.DateCourseAdopted = request.DateCourseAdopted;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.HighSchoolCourseRequirement = request.HighSchoolCourseRequirement;
            specification.Id = request.Id;
            specification.MaxCompletionsForCredit = request.MaxCompletionsForCredit;
            specification.MaximumAvailableCreditConversion = request.MaximumAvailableCreditConversion;
            specification.MaximumAvailableCredits = request.MaximumAvailableCredits;
            specification.MaximumAvailableCreditTypeDescriptor = request.MaximumAvailableCreditTypeDescriptor;
            specification.MinimumAvailableCreditConversion = request.MinimumAvailableCreditConversion;
            specification.MinimumAvailableCredits = request.MinimumAvailableCredits;
            specification.MinimumAvailableCreditTypeDescriptor = request.MinimumAvailableCreditTypeDescriptor;
            specification.NumberOfParts = request.NumberOfParts;
            specification.TimeRequiredForCompletion = request.TimeRequiredForCompletion;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseAttemptResultDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseAttemptResultDescriptors")]
    public partial class CourseAttemptResultDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseAttemptResultDescriptor.EdFi.CourseAttemptResultDescriptor,
        Entities.Common.EdFi.ICourseAttemptResultDescriptor,
        Entities.NHibernate.CourseAttemptResultDescriptorAggregate.EdFi.CourseAttemptResultDescriptor,
        Api.Common.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorPut,
        Api.Common.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorPost,
        Api.Common.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorDelete,
        Api.Common.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorGetByExample>
    {
        public CourseAttemptResultDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorGetByExample request, Entities.Common.EdFi.ICourseAttemptResultDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseAttemptResultDescriptorId = request.CourseAttemptResultDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseDefinedByDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseDefinedByDescriptors")]
    public partial class CourseDefinedByDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseDefinedByDescriptor.EdFi.CourseDefinedByDescriptor,
        Entities.Common.EdFi.ICourseDefinedByDescriptor,
        Entities.NHibernate.CourseDefinedByDescriptorAggregate.EdFi.CourseDefinedByDescriptor,
        Api.Common.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorPut,
        Api.Common.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorPost,
        Api.Common.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorDelete,
        Api.Common.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorGetByExample>
    {
        public CourseDefinedByDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorGetByExample request, Entities.Common.EdFi.ICourseDefinedByDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseDefinedByDescriptorId = request.CourseDefinedByDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseGPAApplicabilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseGPAApplicabilityDescriptors")]
    public partial class CourseGPAApplicabilityDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseGPAApplicabilityDescriptor.EdFi.CourseGPAApplicabilityDescriptor,
        Entities.Common.EdFi.ICourseGPAApplicabilityDescriptor,
        Entities.NHibernate.CourseGPAApplicabilityDescriptorAggregate.EdFi.CourseGPAApplicabilityDescriptor,
        Api.Common.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorPut,
        Api.Common.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorPost,
        Api.Common.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorDelete,
        Api.Common.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorGetByExample>
    {
        public CourseGPAApplicabilityDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorGetByExample request, Entities.Common.EdFi.ICourseGPAApplicabilityDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseGPAApplicabilityDescriptorId = request.CourseGPAApplicabilityDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseIdentificationSystemDescriptors")]
    public partial class CourseIdentificationSystemDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseIdentificationSystemDescriptor.EdFi.CourseIdentificationSystemDescriptor,
        Entities.Common.EdFi.ICourseIdentificationSystemDescriptor,
        Entities.NHibernate.CourseIdentificationSystemDescriptorAggregate.EdFi.CourseIdentificationSystemDescriptor,
        Api.Common.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorPut,
        Api.Common.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorPost,
        Api.Common.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorDelete,
        Api.Common.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorGetByExample>
    {
        public CourseIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorGetByExample request, Entities.Common.EdFi.ICourseIdentificationSystemDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseIdentificationSystemDescriptorId = request.CourseIdentificationSystemDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseLevelCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseLevelCharacteristicDescriptors")]
    public partial class CourseLevelCharacteristicDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseLevelCharacteristicDescriptor.EdFi.CourseLevelCharacteristicDescriptor,
        Entities.Common.EdFi.ICourseLevelCharacteristicDescriptor,
        Entities.NHibernate.CourseLevelCharacteristicDescriptorAggregate.EdFi.CourseLevelCharacteristicDescriptor,
        Api.Common.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorPut,
        Api.Common.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorPost,
        Api.Common.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorDelete,
        Api.Common.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorGetByExample>
    {
        public CourseLevelCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorGetByExample request, Entities.Common.EdFi.ICourseLevelCharacteristicDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseLevelCharacteristicDescriptorId = request.CourseLevelCharacteristicDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseOfferings.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseOfferings")]
    public partial class CourseOfferingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseOffering.EdFi.CourseOffering,
        Entities.Common.EdFi.ICourseOffering,
        Entities.NHibernate.CourseOfferingAggregate.EdFi.CourseOffering,
        Api.Common.Models.Requests.CourseOfferings.EdFi.CourseOfferingPut,
        Api.Common.Models.Requests.CourseOfferings.EdFi.CourseOfferingPost,
        Api.Common.Models.Requests.CourseOfferings.EdFi.CourseOfferingDelete,
        Api.Common.Models.Requests.CourseOfferings.EdFi.CourseOfferingGetByExample>
    {
        public CourseOfferingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseOfferings.EdFi.CourseOfferingGetByExample request, Entities.Common.EdFi.ICourseOffering specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.InstructionalTimePlanned = request.InstructionalTimePlanned;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.LocalCourseTitle = request.LocalCourseTitle;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionName = request.SessionName;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseRepeatCodeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseRepeatCodeDescriptors")]
    public partial class CourseRepeatCodeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseRepeatCodeDescriptor.EdFi.CourseRepeatCodeDescriptor,
        Entities.Common.EdFi.ICourseRepeatCodeDescriptor,
        Entities.NHibernate.CourseRepeatCodeDescriptorAggregate.EdFi.CourseRepeatCodeDescriptor,
        Api.Common.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorPut,
        Api.Common.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorPost,
        Api.Common.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorDelete,
        Api.Common.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorGetByExample>
    {
        public CourseRepeatCodeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorGetByExample request, Entities.Common.EdFi.ICourseRepeatCodeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseRepeatCodeDescriptorId = request.CourseRepeatCodeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseTranscripts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/courseTranscripts")]
    public partial class CourseTranscriptsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CourseTranscript.EdFi.CourseTranscript,
        Entities.Common.EdFi.ICourseTranscript,
        Entities.NHibernate.CourseTranscriptAggregate.EdFi.CourseTranscript,
        Api.Common.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptPut,
        Api.Common.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptPost,
        Api.Common.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptDelete,
        Api.Common.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptGetByExample>
    {
        public CourseTranscriptsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptGetByExample request, Entities.Common.EdFi.ICourseTranscript specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AlternativeCourseCode = request.AlternativeCourseCode;
            specification.AlternativeCourseTitle = request.AlternativeCourseTitle;
            specification.AssigningOrganizationIdentificationCode = request.AssigningOrganizationIdentificationCode;
            specification.AttemptedCreditConversion = request.AttemptedCreditConversion;
            specification.AttemptedCredits = request.AttemptedCredits;
            specification.AttemptedCreditTypeDescriptor = request.AttemptedCreditTypeDescriptor;
            specification.CourseAttemptResultDescriptor = request.CourseAttemptResultDescriptor;
            specification.CourseCatalogURL = request.CourseCatalogURL;
            specification.CourseCode = request.CourseCode;
            specification.CourseEducationOrganizationId = request.CourseEducationOrganizationId;
            specification.CourseRepeatCodeDescriptor = request.CourseRepeatCodeDescriptor;
            specification.CourseTitle = request.CourseTitle;
            specification.EarnedCreditConversion = request.EarnedCreditConversion;
            specification.EarnedCredits = request.EarnedCredits;
            specification.EarnedCreditTypeDescriptor = request.EarnedCreditTypeDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ExternalEducationOrganizationId = request.ExternalEducationOrganizationId;
            specification.ExternalEducationOrganizationNameOfInstitution = request.ExternalEducationOrganizationNameOfInstitution;
            specification.FinalLetterGradeEarned = request.FinalLetterGradeEarned;
            specification.FinalNumericGradeEarned = request.FinalNumericGradeEarned;
            specification.Id = request.Id;
            specification.MethodCreditEarnedDescriptor = request.MethodCreditEarnedDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TermDescriptor = request.TermDescriptor;
            specification.WhenTakenGradeLevelDescriptor = request.WhenTakenGradeLevelDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Credentials.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/credentials")]
    public partial class CredentialsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Credential.EdFi.Credential,
        Entities.Common.EdFi.ICredential,
        Entities.NHibernate.CredentialAggregate.EdFi.Credential,
        Api.Common.Models.Requests.Credentials.EdFi.CredentialPut,
        Api.Common.Models.Requests.Credentials.EdFi.CredentialPost,
        Api.Common.Models.Requests.Credentials.EdFi.CredentialDelete,
        Api.Common.Models.Requests.Credentials.EdFi.CredentialGetByExample>
    {
        public CredentialsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Credentials.EdFi.CredentialGetByExample request, Entities.Common.EdFi.ICredential specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialFieldDescriptor = request.CredentialFieldDescriptor;
            specification.CredentialIdentifier = request.CredentialIdentifier;
            specification.CredentialTypeDescriptor = request.CredentialTypeDescriptor;
            specification.EffectiveDate = request.EffectiveDate;
            specification.ExpirationDate = request.ExpirationDate;
            specification.Id = request.Id;
            specification.IssuanceDate = request.IssuanceDate;
            specification.Namespace = request.Namespace;
            specification.StateOfIssueStateAbbreviationDescriptor = request.StateOfIssueStateAbbreviationDescriptor;
            specification.TeachingCredentialBasisDescriptor = request.TeachingCredentialBasisDescriptor;
            specification.TeachingCredentialDescriptor = request.TeachingCredentialDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CredentialFieldDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/credentialFieldDescriptors")]
    public partial class CredentialFieldDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialFieldDescriptor.EdFi.CredentialFieldDescriptor,
        Entities.Common.EdFi.ICredentialFieldDescriptor,
        Entities.NHibernate.CredentialFieldDescriptorAggregate.EdFi.CredentialFieldDescriptor,
        Api.Common.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorPut,
        Api.Common.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorPost,
        Api.Common.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorDelete,
        Api.Common.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorGetByExample>
    {
        public CredentialFieldDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorGetByExample request, Entities.Common.EdFi.ICredentialFieldDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialFieldDescriptorId = request.CredentialFieldDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CredentialTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/credentialTypeDescriptors")]
    public partial class CredentialTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CredentialTypeDescriptor.EdFi.CredentialTypeDescriptor,
        Entities.Common.EdFi.ICredentialTypeDescriptor,
        Entities.NHibernate.CredentialTypeDescriptorAggregate.EdFi.CredentialTypeDescriptor,
        Api.Common.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorPut,
        Api.Common.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorPost,
        Api.Common.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorDelete,
        Api.Common.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorGetByExample>
    {
        public CredentialTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorGetByExample request, Entities.Common.EdFi.ICredentialTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialTypeDescriptorId = request.CredentialTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CreditCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/creditCategoryDescriptors")]
    public partial class CreditCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CreditCategoryDescriptor.EdFi.CreditCategoryDescriptor,
        Entities.Common.EdFi.ICreditCategoryDescriptor,
        Entities.NHibernate.CreditCategoryDescriptorAggregate.EdFi.CreditCategoryDescriptor,
        Api.Common.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorPut,
        Api.Common.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorPost,
        Api.Common.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorDelete,
        Api.Common.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorGetByExample>
    {
        public CreditCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorGetByExample request, Entities.Common.EdFi.ICreditCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CreditCategoryDescriptorId = request.CreditCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CreditTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/creditTypeDescriptors")]
    public partial class CreditTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CreditTypeDescriptor.EdFi.CreditTypeDescriptor,
        Entities.Common.EdFi.ICreditTypeDescriptor,
        Entities.NHibernate.CreditTypeDescriptorAggregate.EdFi.CreditTypeDescriptor,
        Api.Common.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorPut,
        Api.Common.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorPost,
        Api.Common.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorDelete,
        Api.Common.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorGetByExample>
    {
        public CreditTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorGetByExample request, Entities.Common.EdFi.ICreditTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CreditTypeDescriptorId = request.CreditTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CTEProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/cteProgramServiceDescriptors")]
    public partial class CTEProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CTEProgramServiceDescriptor.EdFi.CTEProgramServiceDescriptor,
        Entities.Common.EdFi.ICTEProgramServiceDescriptor,
        Entities.NHibernate.CTEProgramServiceDescriptorAggregate.EdFi.CTEProgramServiceDescriptor,
        Api.Common.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorPut,
        Api.Common.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorPost,
        Api.Common.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorGetByExample>
    {
        public CTEProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.ICTEProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CTEProgramServiceDescriptorId = request.CTEProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CurriculumUsedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/curriculumUsedDescriptors")]
    public partial class CurriculumUsedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.CurriculumUsedDescriptor.EdFi.CurriculumUsedDescriptor,
        Entities.Common.EdFi.ICurriculumUsedDescriptor,
        Entities.NHibernate.CurriculumUsedDescriptorAggregate.EdFi.CurriculumUsedDescriptor,
        Api.Common.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorPut,
        Api.Common.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorPost,
        Api.Common.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorDelete,
        Api.Common.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorGetByExample>
    {
        public CurriculumUsedDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorGetByExample request, Entities.Common.EdFi.ICurriculumUsedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CurriculumUsedDescriptorId = request.CurriculumUsedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DeliveryMethodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/deliveryMethodDescriptors")]
    public partial class DeliveryMethodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DeliveryMethodDescriptor.EdFi.DeliveryMethodDescriptor,
        Entities.Common.EdFi.IDeliveryMethodDescriptor,
        Entities.NHibernate.DeliveryMethodDescriptorAggregate.EdFi.DeliveryMethodDescriptor,
        Api.Common.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorPut,
        Api.Common.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorPost,
        Api.Common.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorDelete,
        Api.Common.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorGetByExample>
    {
        public DeliveryMethodDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorGetByExample request, Entities.Common.EdFi.IDeliveryMethodDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DeliveryMethodDescriptorId = request.DeliveryMethodDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DescriptorMappings.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/descriptorMappings")]
    public partial class DescriptorMappingsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DescriptorMapping.EdFi.DescriptorMapping,
        Entities.Common.EdFi.IDescriptorMapping,
        Entities.NHibernate.DescriptorMappingAggregate.EdFi.DescriptorMapping,
        Api.Common.Models.Requests.DescriptorMappings.EdFi.DescriptorMappingPut,
        Api.Common.Models.Requests.DescriptorMappings.EdFi.DescriptorMappingPost,
        Api.Common.Models.Requests.DescriptorMappings.EdFi.DescriptorMappingDelete,
        Api.Common.Models.Requests.DescriptorMappings.EdFi.DescriptorMappingGetByExample>
    {
        public DescriptorMappingsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DescriptorMappings.EdFi.DescriptorMappingGetByExample request, Entities.Common.EdFi.IDescriptorMapping specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.MappedNamespace = request.MappedNamespace;
            specification.MappedValue = request.MappedValue;
            specification.Namespace = request.Namespace;
            specification.Value = request.Value;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DiagnosisDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/diagnosisDescriptors")]
    public partial class DiagnosisDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor,
        Entities.Common.EdFi.IDiagnosisDescriptor,
        Entities.NHibernate.DiagnosisDescriptorAggregate.EdFi.DiagnosisDescriptor,
        Api.Common.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorPut,
        Api.Common.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorPost,
        Api.Common.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorDelete,
        Api.Common.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorGetByExample>
    {
        public DiagnosisDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorGetByExample request, Entities.Common.EdFi.IDiagnosisDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DiagnosisDescriptorId = request.DiagnosisDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DiplomaLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/diplomaLevelDescriptors")]
    public partial class DiplomaLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DiplomaLevelDescriptor.EdFi.DiplomaLevelDescriptor,
        Entities.Common.EdFi.IDiplomaLevelDescriptor,
        Entities.NHibernate.DiplomaLevelDescriptorAggregate.EdFi.DiplomaLevelDescriptor,
        Api.Common.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorPut,
        Api.Common.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorPost,
        Api.Common.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorDelete,
        Api.Common.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorGetByExample>
    {
        public DiplomaLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorGetByExample request, Entities.Common.EdFi.IDiplomaLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DiplomaLevelDescriptorId = request.DiplomaLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DiplomaTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/diplomaTypeDescriptors")]
    public partial class DiplomaTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DiplomaTypeDescriptor.EdFi.DiplomaTypeDescriptor,
        Entities.Common.EdFi.IDiplomaTypeDescriptor,
        Entities.NHibernate.DiplomaTypeDescriptorAggregate.EdFi.DiplomaTypeDescriptor,
        Api.Common.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorPut,
        Api.Common.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorPost,
        Api.Common.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorDelete,
        Api.Common.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorGetByExample>
    {
        public DiplomaTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorGetByExample request, Entities.Common.EdFi.IDiplomaTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DiplomaTypeDescriptorId = request.DiplomaTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisabilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disabilityDescriptors")]
    public partial class DisabilityDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisabilityDescriptor.EdFi.DisabilityDescriptor,
        Entities.Common.EdFi.IDisabilityDescriptor,
        Entities.NHibernate.DisabilityDescriptorAggregate.EdFi.DisabilityDescriptor,
        Api.Common.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorPut,
        Api.Common.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorPost,
        Api.Common.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorDelete,
        Api.Common.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorGetByExample>
    {
        public DisabilityDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorGetByExample request, Entities.Common.EdFi.IDisabilityDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisabilityDescriptorId = request.DisabilityDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisabilityDesignationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disabilityDesignationDescriptors")]
    public partial class DisabilityDesignationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisabilityDesignationDescriptor.EdFi.DisabilityDesignationDescriptor,
        Entities.Common.EdFi.IDisabilityDesignationDescriptor,
        Entities.NHibernate.DisabilityDesignationDescriptorAggregate.EdFi.DisabilityDesignationDescriptor,
        Api.Common.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorPut,
        Api.Common.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorPost,
        Api.Common.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorDelete,
        Api.Common.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorGetByExample>
    {
        public DisabilityDesignationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorGetByExample request, Entities.Common.EdFi.IDisabilityDesignationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisabilityDesignationDescriptorId = request.DisabilityDesignationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisabilityDeterminationSourceTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disabilityDeterminationSourceTypeDescriptors")]
    public partial class DisabilityDeterminationSourceTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisabilityDeterminationSourceTypeDescriptor.EdFi.DisabilityDeterminationSourceTypeDescriptor,
        Entities.Common.EdFi.IDisabilityDeterminationSourceTypeDescriptor,
        Entities.NHibernate.DisabilityDeterminationSourceTypeDescriptorAggregate.EdFi.DisabilityDeterminationSourceTypeDescriptor,
        Api.Common.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorPut,
        Api.Common.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorPost,
        Api.Common.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorDelete,
        Api.Common.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorGetByExample>
    {
        public DisabilityDeterminationSourceTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorGetByExample request, Entities.Common.EdFi.IDisabilityDeterminationSourceTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisabilityDeterminationSourceTypeDescriptorId = request.DisabilityDeterminationSourceTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineActions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disciplineActions")]
    public partial class DisciplineActionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisciplineAction.EdFi.DisciplineAction,
        Entities.Common.EdFi.IDisciplineAction,
        Entities.NHibernate.DisciplineActionAggregate.EdFi.DisciplineAction,
        Api.Common.Models.Requests.DisciplineActions.EdFi.DisciplineActionPut,
        Api.Common.Models.Requests.DisciplineActions.EdFi.DisciplineActionPost,
        Api.Common.Models.Requests.DisciplineActions.EdFi.DisciplineActionDelete,
        Api.Common.Models.Requests.DisciplineActions.EdFi.DisciplineActionGetByExample>
    {
        public DisciplineActionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisciplineActions.EdFi.DisciplineActionGetByExample request, Entities.Common.EdFi.IDisciplineAction specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ActualDisciplineActionLength = request.ActualDisciplineActionLength;
            specification.AssignmentSchoolId = request.AssignmentSchoolId;
            specification.DisciplineActionIdentifier = request.DisciplineActionIdentifier;
            specification.DisciplineActionLength = request.DisciplineActionLength;
            specification.DisciplineActionLengthDifferenceReasonDescriptor = request.DisciplineActionLengthDifferenceReasonDescriptor;
            specification.DisciplineDate = request.DisciplineDate;
            specification.Id = request.Id;
            specification.IEPPlacementMeetingIndicator = request.IEPPlacementMeetingIndicator;
            specification.ReceivedEducationServicesDuringExpulsion = request.ReceivedEducationServicesDuringExpulsion;
            specification.RelatedToZeroTolerancePolicy = request.RelatedToZeroTolerancePolicy;
            specification.ResponsibilitySchoolId = request.ResponsibilitySchoolId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineActionLengthDifferenceReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disciplineActionLengthDifferenceReasonDescriptors")]
    public partial class DisciplineActionLengthDifferenceReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisciplineActionLengthDifferenceReasonDescriptor.EdFi.DisciplineActionLengthDifferenceReasonDescriptor,
        Entities.Common.EdFi.IDisciplineActionLengthDifferenceReasonDescriptor,
        Entities.NHibernate.DisciplineActionLengthDifferenceReasonDescriptorAggregate.EdFi.DisciplineActionLengthDifferenceReasonDescriptor,
        Api.Common.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorPut,
        Api.Common.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorPost,
        Api.Common.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorDelete,
        Api.Common.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorGetByExample>
    {
        public DisciplineActionLengthDifferenceReasonDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorGetByExample request, Entities.Common.EdFi.IDisciplineActionLengthDifferenceReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisciplineActionLengthDifferenceReasonDescriptorId = request.DisciplineActionLengthDifferenceReasonDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disciplineDescriptors")]
    public partial class DisciplineDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisciplineDescriptor.EdFi.DisciplineDescriptor,
        Entities.Common.EdFi.IDisciplineDescriptor,
        Entities.NHibernate.DisciplineDescriptorAggregate.EdFi.DisciplineDescriptor,
        Api.Common.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorPut,
        Api.Common.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorPost,
        Api.Common.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorDelete,
        Api.Common.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorGetByExample>
    {
        public DisciplineDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorGetByExample request, Entities.Common.EdFi.IDisciplineDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisciplineDescriptorId = request.DisciplineDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineIncidents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disciplineIncidents")]
    public partial class DisciplineIncidentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisciplineIncident.EdFi.DisciplineIncident,
        Entities.Common.EdFi.IDisciplineIncident,
        Entities.NHibernate.DisciplineIncidentAggregate.EdFi.DisciplineIncident,
        Api.Common.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentPut,
        Api.Common.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentPost,
        Api.Common.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentDelete,
        Api.Common.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentGetByExample>
    {
        public DisciplineIncidentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentGetByExample request, Entities.Common.EdFi.IDisciplineIncident specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CaseNumber = request.CaseNumber;
            specification.Id = request.Id;
            specification.IncidentCost = request.IncidentCost;
            specification.IncidentDate = request.IncidentDate;
            specification.IncidentDescription = request.IncidentDescription;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.IncidentLocationDescriptor = request.IncidentLocationDescriptor;
            specification.IncidentTime = request.IncidentTime;
            specification.ReportedToLawEnforcement = request.ReportedToLawEnforcement;
            specification.ReporterDescriptionDescriptor = request.ReporterDescriptionDescriptor;
            specification.ReporterName = request.ReporterName;
            specification.SchoolId = request.SchoolId;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineIncidentParticipationCodeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/disciplineIncidentParticipationCodeDescriptors")]
    public partial class DisciplineIncidentParticipationCodeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.DisciplineIncidentParticipationCodeDescriptor.EdFi.DisciplineIncidentParticipationCodeDescriptor,
        Entities.Common.EdFi.IDisciplineIncidentParticipationCodeDescriptor,
        Entities.NHibernate.DisciplineIncidentParticipationCodeDescriptorAggregate.EdFi.DisciplineIncidentParticipationCodeDescriptor,
        Api.Common.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorPut,
        Api.Common.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorPost,
        Api.Common.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorDelete,
        Api.Common.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorGetByExample>
    {
        public DisciplineIncidentParticipationCodeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorGetByExample request, Entities.Common.EdFi.IDisciplineIncidentParticipationCodeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisciplineIncidentParticipationCodeDescriptorId = request.DisciplineIncidentParticipationCodeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationalEnvironmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationalEnvironmentDescriptors")]
    public partial class EducationalEnvironmentDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationalEnvironmentDescriptor.EdFi.EducationalEnvironmentDescriptor,
        Entities.Common.EdFi.IEducationalEnvironmentDescriptor,
        Entities.NHibernate.EducationalEnvironmentDescriptorAggregate.EdFi.EducationalEnvironmentDescriptor,
        Api.Common.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorPut,
        Api.Common.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorPost,
        Api.Common.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorDelete,
        Api.Common.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorGetByExample>
    {
        public EducationalEnvironmentDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorGetByExample request, Entities.Common.EdFi.IEducationalEnvironmentDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationalEnvironmentDescriptorId = request.EducationalEnvironmentDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationContents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationContents")]
    public partial class EducationContentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationContent.EdFi.EducationContent,
        Entities.Common.EdFi.IEducationContent,
        Entities.NHibernate.EducationContentAggregate.EdFi.EducationContent,
        Api.Common.Models.Requests.EducationContents.EdFi.EducationContentPut,
        Api.Common.Models.Requests.EducationContents.EdFi.EducationContentPost,
        Api.Common.Models.Requests.EducationContents.EdFi.EducationContentDelete,
        Api.Common.Models.Requests.EducationContents.EdFi.EducationContentGetByExample>
    {
        public EducationContentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationContents.EdFi.EducationContentGetByExample request, Entities.Common.EdFi.IEducationContent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdditionalAuthorsIndicator = request.AdditionalAuthorsIndicator;
            specification.ContentClassDescriptor = request.ContentClassDescriptor;
            specification.ContentIdentifier = request.ContentIdentifier;
            specification.Cost = request.Cost;
            specification.CostRateDescriptor = request.CostRateDescriptor;
            specification.Description = request.Description;
            specification.Id = request.Id;
            specification.InteractivityStyleDescriptor = request.InteractivityStyleDescriptor;
            specification.LearningResourceMetadataURI = request.LearningResourceMetadataURI;
            specification.LearningStandardId = request.LearningStandardId;
            specification.Namespace = request.Namespace;
            specification.PublicationDate = request.PublicationDate;
            specification.PublicationYear = request.PublicationYear;
            specification.Publisher = request.Publisher;
            specification.ShortDescription = request.ShortDescription;
            specification.TimeRequired = request.TimeRequired;
            specification.UseRightsURL = request.UseRightsURL;
            specification.Version = request.Version;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationAssociationTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationAssociationTypeDescriptors")]
    public partial class EducationOrganizationAssociationTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationAssociationTypeDescriptor.EdFi.EducationOrganizationAssociationTypeDescriptor,
        Entities.Common.EdFi.IEducationOrganizationAssociationTypeDescriptor,
        Entities.NHibernate.EducationOrganizationAssociationTypeDescriptorAggregate.EdFi.EducationOrganizationAssociationTypeDescriptor,
        Api.Common.Models.Requests.EducationOrganizationAssociationTypeDescriptors.EdFi.EducationOrganizationAssociationTypeDescriptorPut,
        Api.Common.Models.Requests.EducationOrganizationAssociationTypeDescriptors.EdFi.EducationOrganizationAssociationTypeDescriptorPost,
        Api.Common.Models.Requests.EducationOrganizationAssociationTypeDescriptors.EdFi.EducationOrganizationAssociationTypeDescriptorDelete,
        Api.Common.Models.Requests.EducationOrganizationAssociationTypeDescriptors.EdFi.EducationOrganizationAssociationTypeDescriptorGetByExample>
    {
        public EducationOrganizationAssociationTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationAssociationTypeDescriptors.EdFi.EducationOrganizationAssociationTypeDescriptorGetByExample request, Entities.Common.EdFi.IEducationOrganizationAssociationTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationAssociationTypeDescriptorId = request.EducationOrganizationAssociationTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationCategoryDescriptors")]
    public partial class EducationOrganizationCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationCategoryDescriptor.EdFi.EducationOrganizationCategoryDescriptor,
        Entities.Common.EdFi.IEducationOrganizationCategoryDescriptor,
        Entities.NHibernate.EducationOrganizationCategoryDescriptorAggregate.EdFi.EducationOrganizationCategoryDescriptor,
        Api.Common.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorPut,
        Api.Common.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorPost,
        Api.Common.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorDelete,
        Api.Common.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorGetByExample>
    {
        public EducationOrganizationCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorGetByExample request, Entities.Common.EdFi.IEducationOrganizationCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationCategoryDescriptorId = request.EducationOrganizationCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationIdentificationSystemDescriptors")]
    public partial class EducationOrganizationIdentificationSystemDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationIdentificationSystemDescriptor.EdFi.EducationOrganizationIdentificationSystemDescriptor,
        Entities.Common.EdFi.IEducationOrganizationIdentificationSystemDescriptor,
        Entities.NHibernate.EducationOrganizationIdentificationSystemDescriptorAggregate.EdFi.EducationOrganizationIdentificationSystemDescriptor,
        Api.Common.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorPut,
        Api.Common.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorPost,
        Api.Common.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorDelete,
        Api.Common.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorGetByExample>
    {
        public EducationOrganizationIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorGetByExample request, Entities.Common.EdFi.IEducationOrganizationIdentificationSystemDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationIdentificationSystemDescriptorId = request.EducationOrganizationIdentificationSystemDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationInterventionPrescriptionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationInterventionPrescriptionAssociations")]
    public partial class EducationOrganizationInterventionPrescriptionAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationInterventionPrescriptionAssociation.EdFi.EducationOrganizationInterventionPrescriptionAssociation,
        Entities.Common.EdFi.IEducationOrganizationInterventionPrescriptionAssociation,
        Entities.NHibernate.EducationOrganizationInterventionPrescriptionAssociationAggregate.EdFi.EducationOrganizationInterventionPrescriptionAssociation,
        Api.Common.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationPut,
        Api.Common.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationPost,
        Api.Common.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationDelete,
        Api.Common.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationGetByExample>
    {
        public EducationOrganizationInterventionPrescriptionAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationGetByExample request, Entities.Common.EdFi.IEducationOrganizationInterventionPrescriptionAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.InterventionPrescriptionEducationOrganizationId = request.InterventionPrescriptionEducationOrganizationId;
            specification.InterventionPrescriptionIdentificationCode = request.InterventionPrescriptionIdentificationCode;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationNetworks.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationNetworks")]
    public partial class EducationOrganizationNetworksController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork,
        Entities.Common.EdFi.IEducationOrganizationNetwork,
        Entities.NHibernate.EducationOrganizationNetworkAggregate.EdFi.EducationOrganizationNetwork,
        Api.Common.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkPut,
        Api.Common.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkPost,
        Api.Common.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkDelete,
        Api.Common.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkGetByExample>
    {
        public EducationOrganizationNetworksController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkGetByExample request, Entities.Common.EdFi.IEducationOrganizationNetwork specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationNetworkId = request.EducationOrganizationNetworkId;
            specification.NetworkPurposeDescriptor = request.NetworkPurposeDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationNetworkAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationNetworkAssociations")]
    public partial class EducationOrganizationNetworkAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation,
        Entities.Common.EdFi.IEducationOrganizationNetworkAssociation,
        Entities.NHibernate.EducationOrganizationNetworkAssociationAggregate.EdFi.EducationOrganizationNetworkAssociation,
        Api.Common.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationPut,
        Api.Common.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationPost,
        Api.Common.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationDelete,
        Api.Common.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationGetByExample>
    {
        public EducationOrganizationNetworkAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationGetByExample request, Entities.Common.EdFi.IEducationOrganizationNetworkAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationNetworkId = request.EducationOrganizationNetworkId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.MemberEducationOrganizationId = request.MemberEducationOrganizationId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationPeerAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationOrganizationPeerAssociations")]
    public partial class EducationOrganizationPeerAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationOrganizationPeerAssociation.EdFi.EducationOrganizationPeerAssociation,
        Entities.Common.EdFi.IEducationOrganizationPeerAssociation,
        Entities.NHibernate.EducationOrganizationPeerAssociationAggregate.EdFi.EducationOrganizationPeerAssociation,
        Api.Common.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationPut,
        Api.Common.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationPost,
        Api.Common.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationDelete,
        Api.Common.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationGetByExample>
    {
        public EducationOrganizationPeerAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationGetByExample request, Entities.Common.EdFi.IEducationOrganizationPeerAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.PeerEducationOrganizationId = request.PeerEducationOrganizationId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationPlanDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationPlanDescriptors")]
    public partial class EducationPlanDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationPlanDescriptor.EdFi.EducationPlanDescriptor,
        Entities.Common.EdFi.IEducationPlanDescriptor,
        Entities.NHibernate.EducationPlanDescriptorAggregate.EdFi.EducationPlanDescriptor,
        Api.Common.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorPut,
        Api.Common.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorPost,
        Api.Common.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorDelete,
        Api.Common.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorGetByExample>
    {
        public EducationPlanDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorGetByExample request, Entities.Common.EdFi.IEducationPlanDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationPlanDescriptorId = request.EducationPlanDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationServiceCenters.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/educationServiceCenters")]
    public partial class EducationServiceCentersController : DataManagementControllerBase<
        Api.Common.Models.Resources.EducationServiceCenter.EdFi.EducationServiceCenter,
        Entities.Common.EdFi.IEducationServiceCenter,
        Entities.NHibernate.EducationServiceCenterAggregate.EdFi.EducationServiceCenter,
        Api.Common.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterPut,
        Api.Common.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterPost,
        Api.Common.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterDelete,
        Api.Common.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterGetByExample>
    {
        public EducationServiceCentersController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterGetByExample request, Entities.Common.EdFi.IEducationServiceCenter specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationServiceCenterId = request.EducationServiceCenterId;
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ElectronicMailTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/electronicMailTypeDescriptors")]
    public partial class ElectronicMailTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ElectronicMailTypeDescriptor.EdFi.ElectronicMailTypeDescriptor,
        Entities.Common.EdFi.IElectronicMailTypeDescriptor,
        Entities.NHibernate.ElectronicMailTypeDescriptorAggregate.EdFi.ElectronicMailTypeDescriptor,
        Api.Common.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorPut,
        Api.Common.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorPost,
        Api.Common.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorDelete,
        Api.Common.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorGetByExample>
    {
        public ElectronicMailTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorGetByExample request, Entities.Common.EdFi.IElectronicMailTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ElectronicMailTypeDescriptorId = request.ElectronicMailTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EmploymentStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/employmentStatusDescriptors")]
    public partial class EmploymentStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EmploymentStatusDescriptor.EdFi.EmploymentStatusDescriptor,
        Entities.Common.EdFi.IEmploymentStatusDescriptor,
        Entities.NHibernate.EmploymentStatusDescriptorAggregate.EdFi.EmploymentStatusDescriptor,
        Api.Common.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorPut,
        Api.Common.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorPost,
        Api.Common.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorDelete,
        Api.Common.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorGetByExample>
    {
        public EmploymentStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorGetByExample request, Entities.Common.EdFi.IEmploymentStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EmploymentStatusDescriptorId = request.EmploymentStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EntryGradeLevelReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/entryGradeLevelReasonDescriptors")]
    public partial class EntryGradeLevelReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EntryGradeLevelReasonDescriptor.EdFi.EntryGradeLevelReasonDescriptor,
        Entities.Common.EdFi.IEntryGradeLevelReasonDescriptor,
        Entities.NHibernate.EntryGradeLevelReasonDescriptorAggregate.EdFi.EntryGradeLevelReasonDescriptor,
        Api.Common.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorPut,
        Api.Common.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorPost,
        Api.Common.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorDelete,
        Api.Common.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorGetByExample>
    {
        public EntryGradeLevelReasonDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorGetByExample request, Entities.Common.EdFi.IEntryGradeLevelReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EntryGradeLevelReasonDescriptorId = request.EntryGradeLevelReasonDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EntryTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/entryTypeDescriptors")]
    public partial class EntryTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EntryTypeDescriptor.EdFi.EntryTypeDescriptor,
        Entities.Common.EdFi.IEntryTypeDescriptor,
        Entities.NHibernate.EntryTypeDescriptorAggregate.EdFi.EntryTypeDescriptor,
        Api.Common.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorPut,
        Api.Common.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorPost,
        Api.Common.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorDelete,
        Api.Common.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorGetByExample>
    {
        public EntryTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorGetByExample request, Entities.Common.EdFi.IEntryTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EntryTypeDescriptorId = request.EntryTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EventCircumstanceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/eventCircumstanceDescriptors")]
    public partial class EventCircumstanceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.EventCircumstanceDescriptor.EdFi.EventCircumstanceDescriptor,
        Entities.Common.EdFi.IEventCircumstanceDescriptor,
        Entities.NHibernate.EventCircumstanceDescriptorAggregate.EdFi.EventCircumstanceDescriptor,
        Api.Common.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorPut,
        Api.Common.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorPost,
        Api.Common.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorDelete,
        Api.Common.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorGetByExample>
    {
        public EventCircumstanceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorGetByExample request, Entities.Common.EdFi.IEventCircumstanceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EventCircumstanceDescriptorId = request.EventCircumstanceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ExitWithdrawTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/exitWithdrawTypeDescriptors")]
    public partial class ExitWithdrawTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ExitWithdrawTypeDescriptor.EdFi.ExitWithdrawTypeDescriptor,
        Entities.Common.EdFi.IExitWithdrawTypeDescriptor,
        Entities.NHibernate.ExitWithdrawTypeDescriptorAggregate.EdFi.ExitWithdrawTypeDescriptor,
        Api.Common.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorPut,
        Api.Common.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorPost,
        Api.Common.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorDelete,
        Api.Common.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorGetByExample>
    {
        public ExitWithdrawTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorGetByExample request, Entities.Common.EdFi.IExitWithdrawTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ExitWithdrawTypeDescriptorId = request.ExitWithdrawTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.FeederSchoolAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/feederSchoolAssociations")]
    public partial class FeederSchoolAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FeederSchoolAssociation.EdFi.FeederSchoolAssociation,
        Entities.Common.EdFi.IFeederSchoolAssociation,
        Entities.NHibernate.FeederSchoolAssociationAggregate.EdFi.FeederSchoolAssociation,
        Api.Common.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationPut,
        Api.Common.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationPost,
        Api.Common.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationDelete,
        Api.Common.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationGetByExample>
    {
        public FeederSchoolAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationGetByExample request, Entities.Common.EdFi.IFeederSchoolAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.FeederRelationshipDescription = request.FeederRelationshipDescription;
            specification.FeederSchoolId = request.FeederSchoolId;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.FinancialCollectionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/financialCollectionDescriptors")]
    public partial class FinancialCollectionDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FinancialCollectionDescriptor.EdFi.FinancialCollectionDescriptor,
        Entities.Common.EdFi.IFinancialCollectionDescriptor,
        Entities.NHibernate.FinancialCollectionDescriptorAggregate.EdFi.FinancialCollectionDescriptor,
        Api.Common.Models.Requests.FinancialCollectionDescriptors.EdFi.FinancialCollectionDescriptorPut,
        Api.Common.Models.Requests.FinancialCollectionDescriptors.EdFi.FinancialCollectionDescriptorPost,
        Api.Common.Models.Requests.FinancialCollectionDescriptors.EdFi.FinancialCollectionDescriptorDelete,
        Api.Common.Models.Requests.FinancialCollectionDescriptors.EdFi.FinancialCollectionDescriptorGetByExample>
    {
        public FinancialCollectionDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.FinancialCollectionDescriptors.EdFi.FinancialCollectionDescriptorGetByExample request, Entities.Common.EdFi.IFinancialCollectionDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FinancialCollectionDescriptorId = request.FinancialCollectionDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.FunctionDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/functionDimensions")]
    public partial class FunctionDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FunctionDimension.EdFi.FunctionDimension,
        Entities.Common.EdFi.IFunctionDimension,
        Entities.NHibernate.FunctionDimensionAggregate.EdFi.FunctionDimension,
        Api.Common.Models.Requests.FunctionDimensions.EdFi.FunctionDimensionPut,
        Api.Common.Models.Requests.FunctionDimensions.EdFi.FunctionDimensionPost,
        Api.Common.Models.Requests.FunctionDimensions.EdFi.FunctionDimensionDelete,
        Api.Common.Models.Requests.FunctionDimensions.EdFi.FunctionDimensionGetByExample>
    {
        public FunctionDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.FunctionDimensions.EdFi.FunctionDimensionGetByExample request, Entities.Common.EdFi.IFunctionDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.FundDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/fundDimensions")]
    public partial class FundDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.FundDimension.EdFi.FundDimension,
        Entities.Common.EdFi.IFundDimension,
        Entities.NHibernate.FundDimensionAggregate.EdFi.FundDimension,
        Api.Common.Models.Requests.FundDimensions.EdFi.FundDimensionPut,
        Api.Common.Models.Requests.FundDimensions.EdFi.FundDimensionPost,
        Api.Common.Models.Requests.FundDimensions.EdFi.FundDimensionDelete,
        Api.Common.Models.Requests.FundDimensions.EdFi.FundDimensionGetByExample>
    {
        public FundDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.FundDimensions.EdFi.FundDimensionGetByExample request, Entities.Common.EdFi.IFundDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Grades.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/grades")]
    public partial class GradesController : DataManagementControllerBase<
        Api.Common.Models.Resources.Grade.EdFi.Grade,
        Entities.Common.EdFi.IGrade,
        Entities.NHibernate.GradeAggregate.EdFi.Grade,
        Api.Common.Models.Requests.Grades.EdFi.GradePut,
        Api.Common.Models.Requests.Grades.EdFi.GradePost,
        Api.Common.Models.Requests.Grades.EdFi.GradeDelete,
        Api.Common.Models.Requests.Grades.EdFi.GradeGetByExample>
    {
        public GradesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Grades.EdFi.GradeGetByExample request, Entities.Common.EdFi.IGrade specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CurrentGradeAsOfDate = request.CurrentGradeAsOfDate;
            specification.CurrentGradeIndicator = request.CurrentGradeIndicator;
            specification.DiagnosticStatement = request.DiagnosticStatement;
            specification.GradeTypeDescriptor = request.GradeTypeDescriptor;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.GradingPeriodSchoolYear = request.GradingPeriodSchoolYear;
            specification.GradingPeriodSequence = request.GradingPeriodSequence;
            specification.Id = request.Id;
            specification.LetterGradeEarned = request.LetterGradeEarned;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.NumericGradeEarned = request.NumericGradeEarned;
            specification.PerformanceBaseConversionDescriptor = request.PerformanceBaseConversionDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradebookEntries.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradebookEntries")]
    public partial class GradebookEntriesController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradebookEntry.EdFi.GradebookEntry,
        Entities.Common.EdFi.IGradebookEntry,
        Entities.NHibernate.GradebookEntryAggregate.EdFi.GradebookEntry,
        Api.Common.Models.Requests.GradebookEntries.EdFi.GradebookEntryPut,
        Api.Common.Models.Requests.GradebookEntries.EdFi.GradebookEntryPost,
        Api.Common.Models.Requests.GradebookEntries.EdFi.GradebookEntryDelete,
        Api.Common.Models.Requests.GradebookEntries.EdFi.GradebookEntryGetByExample>
    {
        public GradebookEntriesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradebookEntries.EdFi.GradebookEntryGetByExample request, Entities.Common.EdFi.IGradebookEntry specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DateAssigned = request.DateAssigned;
            specification.Description = request.Description;
            specification.DueDate = request.DueDate;
            specification.DueTime = request.DueTime;
            specification.GradebookEntryIdentifier = request.GradebookEntryIdentifier;
            specification.GradebookEntryTypeDescriptor = request.GradebookEntryTypeDescriptor;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.MaxPoints = request.MaxPoints;
            specification.Namespace = request.Namespace;
            specification.PeriodSequence = request.PeriodSequence;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.SourceSectionIdentifier = request.SourceSectionIdentifier;
            specification.Title = request.Title;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradebookEntryTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradebookEntryTypeDescriptors")]
    public partial class GradebookEntryTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradebookEntryTypeDescriptor.EdFi.GradebookEntryTypeDescriptor,
        Entities.Common.EdFi.IGradebookEntryTypeDescriptor,
        Entities.NHibernate.GradebookEntryTypeDescriptorAggregate.EdFi.GradebookEntryTypeDescriptor,
        Api.Common.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorPut,
        Api.Common.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorPost,
        Api.Common.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorDelete,
        Api.Common.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorGetByExample>
    {
        public GradebookEntryTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorGetByExample request, Entities.Common.EdFi.IGradebookEntryTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradebookEntryTypeDescriptorId = request.GradebookEntryTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradeLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradeLevelDescriptors")]
    public partial class GradeLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradeLevelDescriptor.EdFi.GradeLevelDescriptor,
        Entities.Common.EdFi.IGradeLevelDescriptor,
        Entities.NHibernate.GradeLevelDescriptorAggregate.EdFi.GradeLevelDescriptor,
        Api.Common.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorPut,
        Api.Common.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorPost,
        Api.Common.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorDelete,
        Api.Common.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorGetByExample>
    {
        public GradeLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorGetByExample request, Entities.Common.EdFi.IGradeLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradeLevelDescriptorId = request.GradeLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradePointAverageTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradePointAverageTypeDescriptors")]
    public partial class GradePointAverageTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradePointAverageTypeDescriptor.EdFi.GradePointAverageTypeDescriptor,
        Entities.Common.EdFi.IGradePointAverageTypeDescriptor,
        Entities.NHibernate.GradePointAverageTypeDescriptorAggregate.EdFi.GradePointAverageTypeDescriptor,
        Api.Common.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorPut,
        Api.Common.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorPost,
        Api.Common.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorDelete,
        Api.Common.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorGetByExample>
    {
        public GradePointAverageTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorGetByExample request, Entities.Common.EdFi.IGradePointAverageTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradePointAverageTypeDescriptorId = request.GradePointAverageTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradeTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradeTypeDescriptors")]
    public partial class GradeTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradeTypeDescriptor.EdFi.GradeTypeDescriptor,
        Entities.Common.EdFi.IGradeTypeDescriptor,
        Entities.NHibernate.GradeTypeDescriptorAggregate.EdFi.GradeTypeDescriptor,
        Api.Common.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorPut,
        Api.Common.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorPost,
        Api.Common.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorDelete,
        Api.Common.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorGetByExample>
    {
        public GradeTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorGetByExample request, Entities.Common.EdFi.IGradeTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradeTypeDescriptorId = request.GradeTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradingPeriods.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradingPeriods")]
    public partial class GradingPeriodsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradingPeriod.EdFi.GradingPeriod,
        Entities.Common.EdFi.IGradingPeriod,
        Entities.NHibernate.GradingPeriodAggregate.EdFi.GradingPeriod,
        Api.Common.Models.Requests.GradingPeriods.EdFi.GradingPeriodPut,
        Api.Common.Models.Requests.GradingPeriods.EdFi.GradingPeriodPost,
        Api.Common.Models.Requests.GradingPeriods.EdFi.GradingPeriodDelete,
        Api.Common.Models.Requests.GradingPeriods.EdFi.GradingPeriodGetByExample>
    {
        public GradingPeriodsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradingPeriods.EdFi.GradingPeriodGetByExample request, Entities.Common.EdFi.IGradingPeriod specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.Id = request.Id;
            specification.PeriodSequence = request.PeriodSequence;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.TotalInstructionalDays = request.TotalInstructionalDays;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradingPeriodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gradingPeriodDescriptors")]
    public partial class GradingPeriodDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GradingPeriodDescriptor.EdFi.GradingPeriodDescriptor,
        Entities.Common.EdFi.IGradingPeriodDescriptor,
        Entities.NHibernate.GradingPeriodDescriptorAggregate.EdFi.GradingPeriodDescriptor,
        Api.Common.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorPut,
        Api.Common.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorPost,
        Api.Common.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorDelete,
        Api.Common.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorGetByExample>
    {
        public GradingPeriodDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorGetByExample request, Entities.Common.EdFi.IGradingPeriodDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradingPeriodDescriptorId = request.GradingPeriodDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GraduationPlans.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/graduationPlans")]
    public partial class GraduationPlansController : DataManagementControllerBase<
        Api.Common.Models.Resources.GraduationPlan.EdFi.GraduationPlan,
        Entities.Common.EdFi.IGraduationPlan,
        Entities.NHibernate.GraduationPlanAggregate.EdFi.GraduationPlan,
        Api.Common.Models.Requests.GraduationPlans.EdFi.GraduationPlanPut,
        Api.Common.Models.Requests.GraduationPlans.EdFi.GraduationPlanPost,
        Api.Common.Models.Requests.GraduationPlans.EdFi.GraduationPlanDelete,
        Api.Common.Models.Requests.GraduationPlans.EdFi.GraduationPlanGetByExample>
    {
        public GraduationPlansController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GraduationPlans.EdFi.GraduationPlanGetByExample request, Entities.Common.EdFi.IGraduationPlan specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.GraduationPlanTypeDescriptor = request.GraduationPlanTypeDescriptor;
            specification.GraduationSchoolYear = request.GraduationSchoolYear;
            specification.Id = request.Id;
            specification.IndividualPlan = request.IndividualPlan;
            specification.TotalRequiredCreditConversion = request.TotalRequiredCreditConversion;
            specification.TotalRequiredCredits = request.TotalRequiredCredits;
            specification.TotalRequiredCreditTypeDescriptor = request.TotalRequiredCreditTypeDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GraduationPlanTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/graduationPlanTypeDescriptors")]
    public partial class GraduationPlanTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GraduationPlanTypeDescriptor.EdFi.GraduationPlanTypeDescriptor,
        Entities.Common.EdFi.IGraduationPlanTypeDescriptor,
        Entities.NHibernate.GraduationPlanTypeDescriptorAggregate.EdFi.GraduationPlanTypeDescriptor,
        Api.Common.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorPut,
        Api.Common.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorPost,
        Api.Common.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorDelete,
        Api.Common.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorGetByExample>
    {
        public GraduationPlanTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorGetByExample request, Entities.Common.EdFi.IGraduationPlanTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GraduationPlanTypeDescriptorId = request.GraduationPlanTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GunFreeSchoolsActReportingStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/gunFreeSchoolsActReportingStatusDescriptors")]
    public partial class GunFreeSchoolsActReportingStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.GunFreeSchoolsActReportingStatusDescriptor.EdFi.GunFreeSchoolsActReportingStatusDescriptor,
        Entities.Common.EdFi.IGunFreeSchoolsActReportingStatusDescriptor,
        Entities.NHibernate.GunFreeSchoolsActReportingStatusDescriptorAggregate.EdFi.GunFreeSchoolsActReportingStatusDescriptor,
        Api.Common.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorPut,
        Api.Common.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorPost,
        Api.Common.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorDelete,
        Api.Common.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorGetByExample>
    {
        public GunFreeSchoolsActReportingStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorGetByExample request, Entities.Common.EdFi.IGunFreeSchoolsActReportingStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GunFreeSchoolsActReportingStatusDescriptorId = request.GunFreeSchoolsActReportingStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.HomelessPrimaryNighttimeResidenceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/homelessPrimaryNighttimeResidenceDescriptors")]
    public partial class HomelessPrimaryNighttimeResidenceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.HomelessPrimaryNighttimeResidenceDescriptor.EdFi.HomelessPrimaryNighttimeResidenceDescriptor,
        Entities.Common.EdFi.IHomelessPrimaryNighttimeResidenceDescriptor,
        Entities.NHibernate.HomelessPrimaryNighttimeResidenceDescriptorAggregate.EdFi.HomelessPrimaryNighttimeResidenceDescriptor,
        Api.Common.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorPut,
        Api.Common.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorPost,
        Api.Common.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorDelete,
        Api.Common.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorGetByExample>
    {
        public HomelessPrimaryNighttimeResidenceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorGetByExample request, Entities.Common.EdFi.IHomelessPrimaryNighttimeResidenceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HomelessPrimaryNighttimeResidenceDescriptorId = request.HomelessPrimaryNighttimeResidenceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.HomelessProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/homelessProgramServiceDescriptors")]
    public partial class HomelessProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.HomelessProgramServiceDescriptor.EdFi.HomelessProgramServiceDescriptor,
        Entities.Common.EdFi.IHomelessProgramServiceDescriptor,
        Entities.NHibernate.HomelessProgramServiceDescriptorAggregate.EdFi.HomelessProgramServiceDescriptor,
        Api.Common.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorPut,
        Api.Common.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorPost,
        Api.Common.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorGetByExample>
    {
        public HomelessProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.IHomelessProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HomelessProgramServiceDescriptorId = request.HomelessProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IdentificationDocumentUseDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/identificationDocumentUseDescriptors")]
    public partial class IdentificationDocumentUseDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.IdentificationDocumentUseDescriptor.EdFi.IdentificationDocumentUseDescriptor,
        Entities.Common.EdFi.IIdentificationDocumentUseDescriptor,
        Entities.NHibernate.IdentificationDocumentUseDescriptorAggregate.EdFi.IdentificationDocumentUseDescriptor,
        Api.Common.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorPut,
        Api.Common.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorPost,
        Api.Common.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorDelete,
        Api.Common.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorGetByExample>
    {
        public IdentificationDocumentUseDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorGetByExample request, Entities.Common.EdFi.IIdentificationDocumentUseDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IdentificationDocumentUseDescriptorId = request.IdentificationDocumentUseDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IncidentLocationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/incidentLocationDescriptors")]
    public partial class IncidentLocationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.IncidentLocationDescriptor.EdFi.IncidentLocationDescriptor,
        Entities.Common.EdFi.IIncidentLocationDescriptor,
        Entities.NHibernate.IncidentLocationDescriptorAggregate.EdFi.IncidentLocationDescriptor,
        Api.Common.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorPut,
        Api.Common.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorPost,
        Api.Common.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorDelete,
        Api.Common.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorGetByExample>
    {
        public IncidentLocationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorGetByExample request, Entities.Common.EdFi.IIncidentLocationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IncidentLocationDescriptorId = request.IncidentLocationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IndicatorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/indicatorDescriptors")]
    public partial class IndicatorDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.IndicatorDescriptor.EdFi.IndicatorDescriptor,
        Entities.Common.EdFi.IIndicatorDescriptor,
        Entities.NHibernate.IndicatorDescriptorAggregate.EdFi.IndicatorDescriptor,
        Api.Common.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorPut,
        Api.Common.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorPost,
        Api.Common.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorDelete,
        Api.Common.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorGetByExample>
    {
        public IndicatorDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorGetByExample request, Entities.Common.EdFi.IIndicatorDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IndicatorDescriptorId = request.IndicatorDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IndicatorGroupDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/indicatorGroupDescriptors")]
    public partial class IndicatorGroupDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.IndicatorGroupDescriptor.EdFi.IndicatorGroupDescriptor,
        Entities.Common.EdFi.IIndicatorGroupDescriptor,
        Entities.NHibernate.IndicatorGroupDescriptorAggregate.EdFi.IndicatorGroupDescriptor,
        Api.Common.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorPut,
        Api.Common.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorPost,
        Api.Common.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorDelete,
        Api.Common.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorGetByExample>
    {
        public IndicatorGroupDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorGetByExample request, Entities.Common.EdFi.IIndicatorGroupDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IndicatorGroupDescriptorId = request.IndicatorGroupDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IndicatorLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/indicatorLevelDescriptors")]
    public partial class IndicatorLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.IndicatorLevelDescriptor.EdFi.IndicatorLevelDescriptor,
        Entities.Common.EdFi.IIndicatorLevelDescriptor,
        Entities.NHibernate.IndicatorLevelDescriptorAggregate.EdFi.IndicatorLevelDescriptor,
        Api.Common.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorPut,
        Api.Common.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorPost,
        Api.Common.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorDelete,
        Api.Common.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorGetByExample>
    {
        public IndicatorLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorGetByExample request, Entities.Common.EdFi.IIndicatorLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IndicatorLevelDescriptorId = request.IndicatorLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InstitutionTelephoneNumberTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/institutionTelephoneNumberTypeDescriptors")]
    public partial class InstitutionTelephoneNumberTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InstitutionTelephoneNumberTypeDescriptor.EdFi.InstitutionTelephoneNumberTypeDescriptor,
        Entities.Common.EdFi.IInstitutionTelephoneNumberTypeDescriptor,
        Entities.NHibernate.InstitutionTelephoneNumberTypeDescriptorAggregate.EdFi.InstitutionTelephoneNumberTypeDescriptor,
        Api.Common.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorPut,
        Api.Common.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorPost,
        Api.Common.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorDelete,
        Api.Common.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorGetByExample>
    {
        public InstitutionTelephoneNumberTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorGetByExample request, Entities.Common.EdFi.IInstitutionTelephoneNumberTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InstitutionTelephoneNumberTypeDescriptorId = request.InstitutionTelephoneNumberTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InteractivityStyleDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/interactivityStyleDescriptors")]
    public partial class InteractivityStyleDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InteractivityStyleDescriptor.EdFi.InteractivityStyleDescriptor,
        Entities.Common.EdFi.IInteractivityStyleDescriptor,
        Entities.NHibernate.InteractivityStyleDescriptorAggregate.EdFi.InteractivityStyleDescriptor,
        Api.Common.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorPut,
        Api.Common.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorPost,
        Api.Common.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorDelete,
        Api.Common.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorGetByExample>
    {
        public InteractivityStyleDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorGetByExample request, Entities.Common.EdFi.IInteractivityStyleDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InteractivityStyleDescriptorId = request.InteractivityStyleDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InternetAccessDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/internetAccessDescriptors")]
    public partial class InternetAccessDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InternetAccessDescriptor.EdFi.InternetAccessDescriptor,
        Entities.Common.EdFi.IInternetAccessDescriptor,
        Entities.NHibernate.InternetAccessDescriptorAggregate.EdFi.InternetAccessDescriptor,
        Api.Common.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorPut,
        Api.Common.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorPost,
        Api.Common.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorDelete,
        Api.Common.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorGetByExample>
    {
        public InternetAccessDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorGetByExample request, Entities.Common.EdFi.IInternetAccessDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InternetAccessDescriptorId = request.InternetAccessDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InternetAccessTypeInResidenceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/internetAccessTypeInResidenceDescriptors")]
    public partial class InternetAccessTypeInResidenceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InternetAccessTypeInResidenceDescriptor.EdFi.InternetAccessTypeInResidenceDescriptor,
        Entities.Common.EdFi.IInternetAccessTypeInResidenceDescriptor,
        Entities.NHibernate.InternetAccessTypeInResidenceDescriptorAggregate.EdFi.InternetAccessTypeInResidenceDescriptor,
        Api.Common.Models.Requests.InternetAccessTypeInResidenceDescriptors.EdFi.InternetAccessTypeInResidenceDescriptorPut,
        Api.Common.Models.Requests.InternetAccessTypeInResidenceDescriptors.EdFi.InternetAccessTypeInResidenceDescriptorPost,
        Api.Common.Models.Requests.InternetAccessTypeInResidenceDescriptors.EdFi.InternetAccessTypeInResidenceDescriptorDelete,
        Api.Common.Models.Requests.InternetAccessTypeInResidenceDescriptors.EdFi.InternetAccessTypeInResidenceDescriptorGetByExample>
    {
        public InternetAccessTypeInResidenceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InternetAccessTypeInResidenceDescriptors.EdFi.InternetAccessTypeInResidenceDescriptorGetByExample request, Entities.Common.EdFi.IInternetAccessTypeInResidenceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InternetAccessTypeInResidenceDescriptorId = request.InternetAccessTypeInResidenceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InternetPerformanceInResidenceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/internetPerformanceInResidenceDescriptors")]
    public partial class InternetPerformanceInResidenceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InternetPerformanceInResidenceDescriptor.EdFi.InternetPerformanceInResidenceDescriptor,
        Entities.Common.EdFi.IInternetPerformanceInResidenceDescriptor,
        Entities.NHibernate.InternetPerformanceInResidenceDescriptorAggregate.EdFi.InternetPerformanceInResidenceDescriptor,
        Api.Common.Models.Requests.InternetPerformanceInResidenceDescriptors.EdFi.InternetPerformanceInResidenceDescriptorPut,
        Api.Common.Models.Requests.InternetPerformanceInResidenceDescriptors.EdFi.InternetPerformanceInResidenceDescriptorPost,
        Api.Common.Models.Requests.InternetPerformanceInResidenceDescriptors.EdFi.InternetPerformanceInResidenceDescriptorDelete,
        Api.Common.Models.Requests.InternetPerformanceInResidenceDescriptors.EdFi.InternetPerformanceInResidenceDescriptorGetByExample>
    {
        public InternetPerformanceInResidenceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InternetPerformanceInResidenceDescriptors.EdFi.InternetPerformanceInResidenceDescriptorGetByExample request, Entities.Common.EdFi.IInternetPerformanceInResidenceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InternetPerformanceInResidenceDescriptorId = request.InternetPerformanceInResidenceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Interventions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/interventions")]
    public partial class InterventionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Intervention.EdFi.Intervention,
        Entities.Common.EdFi.IIntervention,
        Entities.NHibernate.InterventionAggregate.EdFi.Intervention,
        Api.Common.Models.Requests.Interventions.EdFi.InterventionPut,
        Api.Common.Models.Requests.Interventions.EdFi.InterventionPost,
        Api.Common.Models.Requests.Interventions.EdFi.InterventionDelete,
        Api.Common.Models.Requests.Interventions.EdFi.InterventionGetByExample>
    {
        public InterventionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Interventions.EdFi.InterventionGetByExample request, Entities.Common.EdFi.IIntervention specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.DeliveryMethodDescriptor = request.DeliveryMethodDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.InterventionClassDescriptor = request.InterventionClassDescriptor;
            specification.InterventionIdentificationCode = request.InterventionIdentificationCode;
            specification.MaxDosage = request.MaxDosage;
            specification.MinDosage = request.MinDosage;
            specification.Namespace = request.Namespace;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionClassDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/interventionClassDescriptors")]
    public partial class InterventionClassDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InterventionClassDescriptor.EdFi.InterventionClassDescriptor,
        Entities.Common.EdFi.IInterventionClassDescriptor,
        Entities.NHibernate.InterventionClassDescriptorAggregate.EdFi.InterventionClassDescriptor,
        Api.Common.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorPut,
        Api.Common.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorPost,
        Api.Common.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorDelete,
        Api.Common.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorGetByExample>
    {
        public InterventionClassDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorGetByExample request, Entities.Common.EdFi.IInterventionClassDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InterventionClassDescriptorId = request.InterventionClassDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionEffectivenessRatingDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/interventionEffectivenessRatingDescriptors")]
    public partial class InterventionEffectivenessRatingDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InterventionEffectivenessRatingDescriptor.EdFi.InterventionEffectivenessRatingDescriptor,
        Entities.Common.EdFi.IInterventionEffectivenessRatingDescriptor,
        Entities.NHibernate.InterventionEffectivenessRatingDescriptorAggregate.EdFi.InterventionEffectivenessRatingDescriptor,
        Api.Common.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorPut,
        Api.Common.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorPost,
        Api.Common.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorDelete,
        Api.Common.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorGetByExample>
    {
        public InterventionEffectivenessRatingDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorGetByExample request, Entities.Common.EdFi.IInterventionEffectivenessRatingDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InterventionEffectivenessRatingDescriptorId = request.InterventionEffectivenessRatingDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionPrescriptions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/interventionPrescriptions")]
    public partial class InterventionPrescriptionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.InterventionPrescription.EdFi.InterventionPrescription,
        Entities.Common.EdFi.IInterventionPrescription,
        Entities.NHibernate.InterventionPrescriptionAggregate.EdFi.InterventionPrescription,
        Api.Common.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionPut,
        Api.Common.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionPost,
        Api.Common.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionDelete,
        Api.Common.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionGetByExample>
    {
        public InterventionPrescriptionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionGetByExample request, Entities.Common.EdFi.IInterventionPrescription specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DeliveryMethodDescriptor = request.DeliveryMethodDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.InterventionClassDescriptor = request.InterventionClassDescriptor;
            specification.InterventionPrescriptionIdentificationCode = request.InterventionPrescriptionIdentificationCode;
            specification.MaxDosage = request.MaxDosage;
            specification.MinDosage = request.MinDosage;
            specification.Namespace = request.Namespace;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionStudies.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/interventionStudies")]
    public partial class InterventionStudiesController : DataManagementControllerBase<
        Api.Common.Models.Resources.InterventionStudy.EdFi.InterventionStudy,
        Entities.Common.EdFi.IInterventionStudy,
        Entities.NHibernate.InterventionStudyAggregate.EdFi.InterventionStudy,
        Api.Common.Models.Requests.InterventionStudies.EdFi.InterventionStudyPut,
        Api.Common.Models.Requests.InterventionStudies.EdFi.InterventionStudyPost,
        Api.Common.Models.Requests.InterventionStudies.EdFi.InterventionStudyDelete,
        Api.Common.Models.Requests.InterventionStudies.EdFi.InterventionStudyGetByExample>
    {
        public InterventionStudiesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.InterventionStudies.EdFi.InterventionStudyGetByExample request, Entities.Common.EdFi.IInterventionStudy specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DeliveryMethodDescriptor = request.DeliveryMethodDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.InterventionClassDescriptor = request.InterventionClassDescriptor;
            specification.InterventionPrescriptionEducationOrganizationId = request.InterventionPrescriptionEducationOrganizationId;
            specification.InterventionPrescriptionIdentificationCode = request.InterventionPrescriptionIdentificationCode;
            specification.InterventionStudyIdentificationCode = request.InterventionStudyIdentificationCode;
            specification.Participants = request.Participants;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LanguageDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/languageDescriptors")]
    public partial class LanguageDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LanguageDescriptor.EdFi.LanguageDescriptor,
        Entities.Common.EdFi.ILanguageDescriptor,
        Entities.NHibernate.LanguageDescriptorAggregate.EdFi.LanguageDescriptor,
        Api.Common.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorPut,
        Api.Common.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorPost,
        Api.Common.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorDelete,
        Api.Common.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorGetByExample>
    {
        public LanguageDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorGetByExample request, Entities.Common.EdFi.ILanguageDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LanguageDescriptorId = request.LanguageDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LanguageInstructionProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/languageInstructionProgramServiceDescriptors")]
    public partial class LanguageInstructionProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LanguageInstructionProgramServiceDescriptor.EdFi.LanguageInstructionProgramServiceDescriptor,
        Entities.Common.EdFi.ILanguageInstructionProgramServiceDescriptor,
        Entities.NHibernate.LanguageInstructionProgramServiceDescriptorAggregate.EdFi.LanguageInstructionProgramServiceDescriptor,
        Api.Common.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorPut,
        Api.Common.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorPost,
        Api.Common.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorGetByExample>
    {
        public LanguageInstructionProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.ILanguageInstructionProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LanguageInstructionProgramServiceDescriptorId = request.LanguageInstructionProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LanguageUseDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/languageUseDescriptors")]
    public partial class LanguageUseDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LanguageUseDescriptor.EdFi.LanguageUseDescriptor,
        Entities.Common.EdFi.ILanguageUseDescriptor,
        Entities.NHibernate.LanguageUseDescriptorAggregate.EdFi.LanguageUseDescriptor,
        Api.Common.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorPut,
        Api.Common.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorPost,
        Api.Common.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorDelete,
        Api.Common.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorGetByExample>
    {
        public LanguageUseDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorGetByExample request, Entities.Common.EdFi.ILanguageUseDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LanguageUseDescriptorId = request.LanguageUseDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/learningObjectives")]
    public partial class LearningObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.LearningObjective.EdFi.LearningObjective,
        Entities.Common.EdFi.ILearningObjective,
        Entities.NHibernate.LearningObjectiveAggregate.EdFi.LearningObjective,
        Api.Common.Models.Requests.LearningObjectives.EdFi.LearningObjectivePut,
        Api.Common.Models.Requests.LearningObjectives.EdFi.LearningObjectivePost,
        Api.Common.Models.Requests.LearningObjectives.EdFi.LearningObjectiveDelete,
        Api.Common.Models.Requests.LearningObjectives.EdFi.LearningObjectiveGetByExample>
    {
        public LearningObjectivesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LearningObjectives.EdFi.LearningObjectiveGetByExample request, Entities.Common.EdFi.ILearningObjective specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Description = request.Description;
            specification.Id = request.Id;
            specification.LearningObjectiveId = request.LearningObjectiveId;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
            specification.Objective = request.Objective;
            specification.ParentLearningObjectiveId = request.ParentLearningObjectiveId;
            specification.ParentNamespace = request.ParentNamespace;
            specification.SuccessCriteria = request.SuccessCriteria;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandards.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/learningStandards")]
    public partial class LearningStandardsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LearningStandard.EdFi.LearningStandard,
        Entities.Common.EdFi.ILearningStandard,
        Entities.NHibernate.LearningStandardAggregate.EdFi.LearningStandard,
        Api.Common.Models.Requests.LearningStandards.EdFi.LearningStandardPut,
        Api.Common.Models.Requests.LearningStandards.EdFi.LearningStandardPost,
        Api.Common.Models.Requests.LearningStandards.EdFi.LearningStandardDelete,
        Api.Common.Models.Requests.LearningStandards.EdFi.LearningStandardGetByExample>
    {
        public LearningStandardsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LearningStandards.EdFi.LearningStandardGetByExample request, Entities.Common.EdFi.ILearningStandard specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseTitle = request.CourseTitle;
            specification.Description = request.Description;
            specification.Id = request.Id;
            specification.LearningStandardCategoryDescriptor = request.LearningStandardCategoryDescriptor;
            specification.LearningStandardId = request.LearningStandardId;
            specification.LearningStandardItemCode = request.LearningStandardItemCode;
            specification.LearningStandardScopeDescriptor = request.LearningStandardScopeDescriptor;
            specification.Namespace = request.Namespace;
            specification.ParentLearningStandardId = request.ParentLearningStandardId;
            specification.SuccessCriteria = request.SuccessCriteria;
            specification.URI = request.URI;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/learningStandardCategoryDescriptors")]
    public partial class LearningStandardCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LearningStandardCategoryDescriptor.EdFi.LearningStandardCategoryDescriptor,
        Entities.Common.EdFi.ILearningStandardCategoryDescriptor,
        Entities.NHibernate.LearningStandardCategoryDescriptorAggregate.EdFi.LearningStandardCategoryDescriptor,
        Api.Common.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorPut,
        Api.Common.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorPost,
        Api.Common.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorDelete,
        Api.Common.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorGetByExample>
    {
        public LearningStandardCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorGetByExample request, Entities.Common.EdFi.ILearningStandardCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LearningStandardCategoryDescriptorId = request.LearningStandardCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardEquivalenceAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/learningStandardEquivalenceAssociations")]
    public partial class LearningStandardEquivalenceAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LearningStandardEquivalenceAssociation.EdFi.LearningStandardEquivalenceAssociation,
        Entities.Common.EdFi.ILearningStandardEquivalenceAssociation,
        Entities.NHibernate.LearningStandardEquivalenceAssociationAggregate.EdFi.LearningStandardEquivalenceAssociation,
        Api.Common.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationPut,
        Api.Common.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationPost,
        Api.Common.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationDelete,
        Api.Common.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationGetByExample>
    {
        public LearningStandardEquivalenceAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationGetByExample request, Entities.Common.EdFi.ILearningStandardEquivalenceAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EffectiveDate = request.EffectiveDate;
            specification.Id = request.Id;
            specification.LearningStandardEquivalenceStrengthDescription = request.LearningStandardEquivalenceStrengthDescription;
            specification.LearningStandardEquivalenceStrengthDescriptor = request.LearningStandardEquivalenceStrengthDescriptor;
            specification.Namespace = request.Namespace;
            specification.SourceLearningStandardId = request.SourceLearningStandardId;
            specification.TargetLearningStandardId = request.TargetLearningStandardId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardEquivalenceStrengthDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/learningStandardEquivalenceStrengthDescriptors")]
    public partial class LearningStandardEquivalenceStrengthDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LearningStandardEquivalenceStrengthDescriptor.EdFi.LearningStandardEquivalenceStrengthDescriptor,
        Entities.Common.EdFi.ILearningStandardEquivalenceStrengthDescriptor,
        Entities.NHibernate.LearningStandardEquivalenceStrengthDescriptorAggregate.EdFi.LearningStandardEquivalenceStrengthDescriptor,
        Api.Common.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorPut,
        Api.Common.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorPost,
        Api.Common.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorDelete,
        Api.Common.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorGetByExample>
    {
        public LearningStandardEquivalenceStrengthDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorGetByExample request, Entities.Common.EdFi.ILearningStandardEquivalenceStrengthDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LearningStandardEquivalenceStrengthDescriptorId = request.LearningStandardEquivalenceStrengthDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardScopeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/learningStandardScopeDescriptors")]
    public partial class LearningStandardScopeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LearningStandardScopeDescriptor.EdFi.LearningStandardScopeDescriptor,
        Entities.Common.EdFi.ILearningStandardScopeDescriptor,
        Entities.NHibernate.LearningStandardScopeDescriptorAggregate.EdFi.LearningStandardScopeDescriptor,
        Api.Common.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorPut,
        Api.Common.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorPost,
        Api.Common.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorDelete,
        Api.Common.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorGetByExample>
    {
        public LearningStandardScopeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorGetByExample request, Entities.Common.EdFi.ILearningStandardScopeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LearningStandardScopeDescriptorId = request.LearningStandardScopeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LevelOfEducationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/levelOfEducationDescriptors")]
    public partial class LevelOfEducationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LevelOfEducationDescriptor.EdFi.LevelOfEducationDescriptor,
        Entities.Common.EdFi.ILevelOfEducationDescriptor,
        Entities.NHibernate.LevelOfEducationDescriptorAggregate.EdFi.LevelOfEducationDescriptor,
        Api.Common.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorPut,
        Api.Common.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorPost,
        Api.Common.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorDelete,
        Api.Common.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorGetByExample>
    {
        public LevelOfEducationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorGetByExample request, Entities.Common.EdFi.ILevelOfEducationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LevelOfEducationDescriptorId = request.LevelOfEducationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LicenseStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/licenseStatusDescriptors")]
    public partial class LicenseStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LicenseStatusDescriptor.EdFi.LicenseStatusDescriptor,
        Entities.Common.EdFi.ILicenseStatusDescriptor,
        Entities.NHibernate.LicenseStatusDescriptorAggregate.EdFi.LicenseStatusDescriptor,
        Api.Common.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorPut,
        Api.Common.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorPost,
        Api.Common.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorDelete,
        Api.Common.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorGetByExample>
    {
        public LicenseStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorGetByExample request, Entities.Common.EdFi.ILicenseStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LicenseStatusDescriptorId = request.LicenseStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LicenseTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/licenseTypeDescriptors")]
    public partial class LicenseTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LicenseTypeDescriptor.EdFi.LicenseTypeDescriptor,
        Entities.Common.EdFi.ILicenseTypeDescriptor,
        Entities.NHibernate.LicenseTypeDescriptorAggregate.EdFi.LicenseTypeDescriptor,
        Api.Common.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorPut,
        Api.Common.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorPost,
        Api.Common.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorDelete,
        Api.Common.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorGetByExample>
    {
        public LicenseTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorGetByExample request, Entities.Common.EdFi.ILicenseTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LicenseTypeDescriptorId = request.LicenseTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LimitedEnglishProficiencyDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/limitedEnglishProficiencyDescriptors")]
    public partial class LimitedEnglishProficiencyDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LimitedEnglishProficiencyDescriptor.EdFi.LimitedEnglishProficiencyDescriptor,
        Entities.Common.EdFi.ILimitedEnglishProficiencyDescriptor,
        Entities.NHibernate.LimitedEnglishProficiencyDescriptorAggregate.EdFi.LimitedEnglishProficiencyDescriptor,
        Api.Common.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorPut,
        Api.Common.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorPost,
        Api.Common.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorDelete,
        Api.Common.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorGetByExample>
    {
        public LimitedEnglishProficiencyDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorGetByExample request, Entities.Common.EdFi.ILimitedEnglishProficiencyDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LimitedEnglishProficiencyDescriptorId = request.LimitedEnglishProficiencyDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalAccounts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localAccounts")]
    public partial class LocalAccountsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalAccount.EdFi.LocalAccount,
        Entities.Common.EdFi.ILocalAccount,
        Entities.NHibernate.LocalAccountAggregate.EdFi.LocalAccount,
        Api.Common.Models.Requests.LocalAccounts.EdFi.LocalAccountPut,
        Api.Common.Models.Requests.LocalAccounts.EdFi.LocalAccountPost,
        Api.Common.Models.Requests.LocalAccounts.EdFi.LocalAccountDelete,
        Api.Common.Models.Requests.LocalAccounts.EdFi.LocalAccountGetByExample>
    {
        public LocalAccountsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalAccounts.EdFi.LocalAccountGetByExample request, Entities.Common.EdFi.ILocalAccount specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.AccountName = request.AccountName;
            specification.ChartOfAccountEducationOrganizationId = request.ChartOfAccountEducationOrganizationId;
            specification.ChartOfAccountIdentifier = request.ChartOfAccountIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalActuals.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localActuals")]
    public partial class LocalActualsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalActual.EdFi.LocalActual,
        Entities.Common.EdFi.ILocalActual,
        Entities.NHibernate.LocalActualAggregate.EdFi.LocalActual,
        Api.Common.Models.Requests.LocalActuals.EdFi.LocalActualPut,
        Api.Common.Models.Requests.LocalActuals.EdFi.LocalActualPost,
        Api.Common.Models.Requests.LocalActuals.EdFi.LocalActualDelete,
        Api.Common.Models.Requests.LocalActuals.EdFi.LocalActualGetByExample>
    {
        public LocalActualsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalActuals.EdFi.LocalActualGetByExample request, Entities.Common.EdFi.ILocalActual specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.Amount = request.Amount;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FinancialCollectionDescriptor = request.FinancialCollectionDescriptor;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalBudgets.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localBudgets")]
    public partial class LocalBudgetsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalBudget.EdFi.LocalBudget,
        Entities.Common.EdFi.ILocalBudget,
        Entities.NHibernate.LocalBudgetAggregate.EdFi.LocalBudget,
        Api.Common.Models.Requests.LocalBudgets.EdFi.LocalBudgetPut,
        Api.Common.Models.Requests.LocalBudgets.EdFi.LocalBudgetPost,
        Api.Common.Models.Requests.LocalBudgets.EdFi.LocalBudgetDelete,
        Api.Common.Models.Requests.LocalBudgets.EdFi.LocalBudgetGetByExample>
    {
        public LocalBudgetsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalBudgets.EdFi.LocalBudgetGetByExample request, Entities.Common.EdFi.ILocalBudget specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.Amount = request.Amount;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FinancialCollectionDescriptor = request.FinancialCollectionDescriptor;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalContractedStaffs.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localContractedStaffs")]
    public partial class LocalContractedStaffsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalContractedStaff.EdFi.LocalContractedStaff,
        Entities.Common.EdFi.ILocalContractedStaff,
        Entities.NHibernate.LocalContractedStaffAggregate.EdFi.LocalContractedStaff,
        Api.Common.Models.Requests.LocalContractedStaffs.EdFi.LocalContractedStaffPut,
        Api.Common.Models.Requests.LocalContractedStaffs.EdFi.LocalContractedStaffPost,
        Api.Common.Models.Requests.LocalContractedStaffs.EdFi.LocalContractedStaffDelete,
        Api.Common.Models.Requests.LocalContractedStaffs.EdFi.LocalContractedStaffGetByExample>
    {
        public LocalContractedStaffsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalContractedStaffs.EdFi.LocalContractedStaffGetByExample request, Entities.Common.EdFi.ILocalContractedStaff specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.Amount = request.Amount;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FinancialCollectionDescriptor = request.FinancialCollectionDescriptor;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocaleDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localeDescriptors")]
    public partial class LocaleDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocaleDescriptor.EdFi.LocaleDescriptor,
        Entities.Common.EdFi.ILocaleDescriptor,
        Entities.NHibernate.LocaleDescriptorAggregate.EdFi.LocaleDescriptor,
        Api.Common.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorPut,
        Api.Common.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorPost,
        Api.Common.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorDelete,
        Api.Common.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorGetByExample>
    {
        public LocaleDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorGetByExample request, Entities.Common.EdFi.ILocaleDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LocaleDescriptorId = request.LocaleDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEducationAgencies.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localEducationAgencies")]
    public partial class LocalEducationAgenciesController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalEducationAgency.EdFi.LocalEducationAgency,
        Entities.Common.EdFi.ILocalEducationAgency,
        Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyPut,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyPost,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyDelete,
        Api.Common.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyGetByExample>
    {
        public LocalEducationAgenciesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyGetByExample request, Entities.Common.EdFi.ILocalEducationAgency specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterStatusDescriptor = request.CharterStatusDescriptor;
            specification.EducationServiceCenterId = request.EducationServiceCenterId;
            specification.LocalEducationAgencyCategoryDescriptor = request.LocalEducationAgencyCategoryDescriptor;
            specification.LocalEducationAgencyId = request.LocalEducationAgencyId;
            specification.ParentLocalEducationAgencyId = request.ParentLocalEducationAgencyId;
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEducationAgencyCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localEducationAgencyCategoryDescriptors")]
    public partial class LocalEducationAgencyCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalEducationAgencyCategoryDescriptor.EdFi.LocalEducationAgencyCategoryDescriptor,
        Entities.Common.EdFi.ILocalEducationAgencyCategoryDescriptor,
        Entities.NHibernate.LocalEducationAgencyCategoryDescriptorAggregate.EdFi.LocalEducationAgencyCategoryDescriptor,
        Api.Common.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorPut,
        Api.Common.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorPost,
        Api.Common.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorDelete,
        Api.Common.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorGetByExample>
    {
        public LocalEducationAgencyCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorGetByExample request, Entities.Common.EdFi.ILocalEducationAgencyCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LocalEducationAgencyCategoryDescriptorId = request.LocalEducationAgencyCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEncumbrances.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localEncumbrances")]
    public partial class LocalEncumbrancesController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalEncumbrance.EdFi.LocalEncumbrance,
        Entities.Common.EdFi.ILocalEncumbrance,
        Entities.NHibernate.LocalEncumbranceAggregate.EdFi.LocalEncumbrance,
        Api.Common.Models.Requests.LocalEncumbrances.EdFi.LocalEncumbrancePut,
        Api.Common.Models.Requests.LocalEncumbrances.EdFi.LocalEncumbrancePost,
        Api.Common.Models.Requests.LocalEncumbrances.EdFi.LocalEncumbranceDelete,
        Api.Common.Models.Requests.LocalEncumbrances.EdFi.LocalEncumbranceGetByExample>
    {
        public LocalEncumbrancesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalEncumbrances.EdFi.LocalEncumbranceGetByExample request, Entities.Common.EdFi.ILocalEncumbrance specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.Amount = request.Amount;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FinancialCollectionDescriptor = request.FinancialCollectionDescriptor;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalPayrolls.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/localPayrolls")]
    public partial class LocalPayrollsController : DataManagementControllerBase<
        Api.Common.Models.Resources.LocalPayroll.EdFi.LocalPayroll,
        Entities.Common.EdFi.ILocalPayroll,
        Entities.NHibernate.LocalPayrollAggregate.EdFi.LocalPayroll,
        Api.Common.Models.Requests.LocalPayrolls.EdFi.LocalPayrollPut,
        Api.Common.Models.Requests.LocalPayrolls.EdFi.LocalPayrollPost,
        Api.Common.Models.Requests.LocalPayrolls.EdFi.LocalPayrollDelete,
        Api.Common.Models.Requests.LocalPayrolls.EdFi.LocalPayrollGetByExample>
    {
        public LocalPayrollsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.LocalPayrolls.EdFi.LocalPayrollGetByExample request, Entities.Common.EdFi.ILocalPayroll specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.Amount = request.Amount;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FinancialCollectionDescriptor = request.FinancialCollectionDescriptor;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Locations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/locations")]
    public partial class LocationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Location.EdFi.Location,
        Entities.Common.EdFi.ILocation,
        Entities.NHibernate.LocationAggregate.EdFi.Location,
        Api.Common.Models.Requests.Locations.EdFi.LocationPut,
        Api.Common.Models.Requests.Locations.EdFi.LocationPost,
        Api.Common.Models.Requests.Locations.EdFi.LocationDelete,
        Api.Common.Models.Requests.Locations.EdFi.LocationGetByExample>
    {
        public LocationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Locations.EdFi.LocationGetByExample request, Entities.Common.EdFi.ILocation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassroomIdentificationCode = request.ClassroomIdentificationCode;
            specification.Id = request.Id;
            specification.MaximumNumberOfSeats = request.MaximumNumberOfSeats;
            specification.OptimalNumberOfSeats = request.OptimalNumberOfSeats;
            specification.SchoolId = request.SchoolId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/magnetSpecialProgramEmphasisSchoolDescriptors")]
    public partial class MagnetSpecialProgramEmphasisSchoolDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.MagnetSpecialProgramEmphasisSchoolDescriptor.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor,
        Entities.Common.EdFi.IMagnetSpecialProgramEmphasisSchoolDescriptor,
        Entities.NHibernate.MagnetSpecialProgramEmphasisSchoolDescriptorAggregate.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor,
        Api.Common.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorPut,
        Api.Common.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorPost,
        Api.Common.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorDelete,
        Api.Common.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorGetByExample>
    {
        public MagnetSpecialProgramEmphasisSchoolDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorGetByExample request, Entities.Common.EdFi.IMagnetSpecialProgramEmphasisSchoolDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MagnetSpecialProgramEmphasisSchoolDescriptorId = request.MagnetSpecialProgramEmphasisSchoolDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MediumOfInstructionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/mediumOfInstructionDescriptors")]
    public partial class MediumOfInstructionDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.MediumOfInstructionDescriptor.EdFi.MediumOfInstructionDescriptor,
        Entities.Common.EdFi.IMediumOfInstructionDescriptor,
        Entities.NHibernate.MediumOfInstructionDescriptorAggregate.EdFi.MediumOfInstructionDescriptor,
        Api.Common.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorPut,
        Api.Common.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorPost,
        Api.Common.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorDelete,
        Api.Common.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorGetByExample>
    {
        public MediumOfInstructionDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorGetByExample request, Entities.Common.EdFi.IMediumOfInstructionDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MediumOfInstructionDescriptorId = request.MediumOfInstructionDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MethodCreditEarnedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/methodCreditEarnedDescriptors")]
    public partial class MethodCreditEarnedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.MethodCreditEarnedDescriptor.EdFi.MethodCreditEarnedDescriptor,
        Entities.Common.EdFi.IMethodCreditEarnedDescriptor,
        Entities.NHibernate.MethodCreditEarnedDescriptorAggregate.EdFi.MethodCreditEarnedDescriptor,
        Api.Common.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorPut,
        Api.Common.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorPost,
        Api.Common.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorDelete,
        Api.Common.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorGetByExample>
    {
        public MethodCreditEarnedDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorGetByExample request, Entities.Common.EdFi.IMethodCreditEarnedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MethodCreditEarnedDescriptorId = request.MethodCreditEarnedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MigrantEducationProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/migrantEducationProgramServiceDescriptors")]
    public partial class MigrantEducationProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.MigrantEducationProgramServiceDescriptor.EdFi.MigrantEducationProgramServiceDescriptor,
        Entities.Common.EdFi.IMigrantEducationProgramServiceDescriptor,
        Entities.NHibernate.MigrantEducationProgramServiceDescriptorAggregate.EdFi.MigrantEducationProgramServiceDescriptor,
        Api.Common.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorPut,
        Api.Common.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorPost,
        Api.Common.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorGetByExample>
    {
        public MigrantEducationProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.IMigrantEducationProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MigrantEducationProgramServiceDescriptorId = request.MigrantEducationProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ModelEntityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/modelEntityDescriptors")]
    public partial class ModelEntityDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ModelEntityDescriptor.EdFi.ModelEntityDescriptor,
        Entities.Common.EdFi.IModelEntityDescriptor,
        Entities.NHibernate.ModelEntityDescriptorAggregate.EdFi.ModelEntityDescriptor,
        Api.Common.Models.Requests.ModelEntityDescriptors.EdFi.ModelEntityDescriptorPut,
        Api.Common.Models.Requests.ModelEntityDescriptors.EdFi.ModelEntityDescriptorPost,
        Api.Common.Models.Requests.ModelEntityDescriptors.EdFi.ModelEntityDescriptorDelete,
        Api.Common.Models.Requests.ModelEntityDescriptors.EdFi.ModelEntityDescriptorGetByExample>
    {
        public ModelEntityDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ModelEntityDescriptors.EdFi.ModelEntityDescriptorGetByExample request, Entities.Common.EdFi.IModelEntityDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ModelEntityDescriptorId = request.ModelEntityDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MonitoredDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/monitoredDescriptors")]
    public partial class MonitoredDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.MonitoredDescriptor.EdFi.MonitoredDescriptor,
        Entities.Common.EdFi.IMonitoredDescriptor,
        Entities.NHibernate.MonitoredDescriptorAggregate.EdFi.MonitoredDescriptor,
        Api.Common.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorPut,
        Api.Common.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorPost,
        Api.Common.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorDelete,
        Api.Common.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorGetByExample>
    {
        public MonitoredDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorGetByExample request, Entities.Common.EdFi.IMonitoredDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MonitoredDescriptorId = request.MonitoredDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.NeglectedOrDelinquentProgramDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/neglectedOrDelinquentProgramDescriptors")]
    public partial class NeglectedOrDelinquentProgramDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.NeglectedOrDelinquentProgramDescriptor.EdFi.NeglectedOrDelinquentProgramDescriptor,
        Entities.Common.EdFi.INeglectedOrDelinquentProgramDescriptor,
        Entities.NHibernate.NeglectedOrDelinquentProgramDescriptorAggregate.EdFi.NeglectedOrDelinquentProgramDescriptor,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorPut,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorPost,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorDelete,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorGetByExample>
    {
        public NeglectedOrDelinquentProgramDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorGetByExample request, Entities.Common.EdFi.INeglectedOrDelinquentProgramDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.NeglectedOrDelinquentProgramDescriptorId = request.NeglectedOrDelinquentProgramDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.NeglectedOrDelinquentProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/neglectedOrDelinquentProgramServiceDescriptors")]
    public partial class NeglectedOrDelinquentProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.NeglectedOrDelinquentProgramServiceDescriptor.EdFi.NeglectedOrDelinquentProgramServiceDescriptor,
        Entities.Common.EdFi.INeglectedOrDelinquentProgramServiceDescriptor,
        Entities.NHibernate.NeglectedOrDelinquentProgramServiceDescriptorAggregate.EdFi.NeglectedOrDelinquentProgramServiceDescriptor,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorPut,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorPost,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorGetByExample>
    {
        public NeglectedOrDelinquentProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.INeglectedOrDelinquentProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.NeglectedOrDelinquentProgramServiceDescriptorId = request.NeglectedOrDelinquentProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.NetworkPurposeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/networkPurposeDescriptors")]
    public partial class NetworkPurposeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.NetworkPurposeDescriptor.EdFi.NetworkPurposeDescriptor,
        Entities.Common.EdFi.INetworkPurposeDescriptor,
        Entities.NHibernate.NetworkPurposeDescriptorAggregate.EdFi.NetworkPurposeDescriptor,
        Api.Common.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorPut,
        Api.Common.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorPost,
        Api.Common.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorDelete,
        Api.Common.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorGetByExample>
    {
        public NetworkPurposeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorGetByExample request, Entities.Common.EdFi.INetworkPurposeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.NetworkPurposeDescriptorId = request.NetworkPurposeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ObjectDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/objectDimensions")]
    public partial class ObjectDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ObjectDimension.EdFi.ObjectDimension,
        Entities.Common.EdFi.IObjectDimension,
        Entities.NHibernate.ObjectDimensionAggregate.EdFi.ObjectDimension,
        Api.Common.Models.Requests.ObjectDimensions.EdFi.ObjectDimensionPut,
        Api.Common.Models.Requests.ObjectDimensions.EdFi.ObjectDimensionPost,
        Api.Common.Models.Requests.ObjectDimensions.EdFi.ObjectDimensionDelete,
        Api.Common.Models.Requests.ObjectDimensions.EdFi.ObjectDimensionGetByExample>
    {
        public ObjectDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ObjectDimensions.EdFi.ObjectDimensionGetByExample request, Entities.Common.EdFi.IObjectDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ObjectiveAssessments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/objectiveAssessments")]
    public partial class ObjectiveAssessmentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment,
        Entities.Common.EdFi.IObjectiveAssessment,
        Entities.NHibernate.ObjectiveAssessmentAggregate.EdFi.ObjectiveAssessment,
        Api.Common.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentPut,
        Api.Common.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentPost,
        Api.Common.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentDelete,
        Api.Common.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentGetByExample>
    {
        public ObjectiveAssessmentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentGetByExample request, Entities.Common.EdFi.IObjectiveAssessment specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.Description = request.Description;
            specification.Id = request.Id;
            specification.IdentificationCode = request.IdentificationCode;
            specification.MaxRawScore = request.MaxRawScore;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
            specification.ParentIdentificationCode = request.ParentIdentificationCode;
            specification.PercentOfAssessment = request.PercentOfAssessment;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OldEthnicityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/oldEthnicityDescriptors")]
    public partial class OldEthnicityDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OldEthnicityDescriptor.EdFi.OldEthnicityDescriptor,
        Entities.Common.EdFi.IOldEthnicityDescriptor,
        Entities.NHibernate.OldEthnicityDescriptorAggregate.EdFi.OldEthnicityDescriptor,
        Api.Common.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorPut,
        Api.Common.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorPost,
        Api.Common.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorDelete,
        Api.Common.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorGetByExample>
    {
        public OldEthnicityDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorGetByExample request, Entities.Common.EdFi.IOldEthnicityDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OldEthnicityDescriptorId = request.OldEthnicityDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OpenStaffPositions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/openStaffPositions")]
    public partial class OpenStaffPositionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OpenStaffPosition.EdFi.OpenStaffPosition,
        Entities.Common.EdFi.IOpenStaffPosition,
        Entities.NHibernate.OpenStaffPositionAggregate.EdFi.OpenStaffPosition,
        Api.Common.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionPut,
        Api.Common.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionPost,
        Api.Common.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionDelete,
        Api.Common.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionGetByExample>
    {
        public OpenStaffPositionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionGetByExample request, Entities.Common.EdFi.IOpenStaffPosition specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DatePosted = request.DatePosted;
            specification.DatePostingRemoved = request.DatePostingRemoved;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmploymentStatusDescriptor = request.EmploymentStatusDescriptor;
            specification.Id = request.Id;
            specification.PositionTitle = request.PositionTitle;
            specification.PostingResultDescriptor = request.PostingResultDescriptor;
            specification.ProgramAssignmentDescriptor = request.ProgramAssignmentDescriptor;
            specification.RequisitionNumber = request.RequisitionNumber;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OperationalStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/operationalStatusDescriptors")]
    public partial class OperationalStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OperationalStatusDescriptor.EdFi.OperationalStatusDescriptor,
        Entities.Common.EdFi.IOperationalStatusDescriptor,
        Entities.NHibernate.OperationalStatusDescriptorAggregate.EdFi.OperationalStatusDescriptor,
        Api.Common.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorPut,
        Api.Common.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorPost,
        Api.Common.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorDelete,
        Api.Common.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorGetByExample>
    {
        public OperationalStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorGetByExample request, Entities.Common.EdFi.IOperationalStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OperationalStatusDescriptorId = request.OperationalStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OperationalUnitDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/operationalUnitDimensions")]
    public partial class OperationalUnitDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OperationalUnitDimension.EdFi.OperationalUnitDimension,
        Entities.Common.EdFi.IOperationalUnitDimension,
        Entities.NHibernate.OperationalUnitDimensionAggregate.EdFi.OperationalUnitDimension,
        Api.Common.Models.Requests.OperationalUnitDimensions.EdFi.OperationalUnitDimensionPut,
        Api.Common.Models.Requests.OperationalUnitDimensions.EdFi.OperationalUnitDimensionPost,
        Api.Common.Models.Requests.OperationalUnitDimensions.EdFi.OperationalUnitDimensionDelete,
        Api.Common.Models.Requests.OperationalUnitDimensions.EdFi.OperationalUnitDimensionGetByExample>
    {
        public OperationalUnitDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.OperationalUnitDimensions.EdFi.OperationalUnitDimensionGetByExample request, Entities.Common.EdFi.IOperationalUnitDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OrganizationDepartments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/organizationDepartments")]
    public partial class OrganizationDepartmentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OrganizationDepartment.EdFi.OrganizationDepartment,
        Entities.Common.EdFi.IOrganizationDepartment,
        Entities.NHibernate.OrganizationDepartmentAggregate.EdFi.OrganizationDepartment,
        Api.Common.Models.Requests.OrganizationDepartments.EdFi.OrganizationDepartmentPut,
        Api.Common.Models.Requests.OrganizationDepartments.EdFi.OrganizationDepartmentPost,
        Api.Common.Models.Requests.OrganizationDepartments.EdFi.OrganizationDepartmentDelete,
        Api.Common.Models.Requests.OrganizationDepartments.EdFi.OrganizationDepartmentGetByExample>
    {
        public OrganizationDepartmentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.OrganizationDepartments.EdFi.OrganizationDepartmentGetByExample request, Entities.Common.EdFi.IOrganizationDepartment specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptor = request.AcademicSubjectDescriptor;
            specification.OrganizationDepartmentId = request.OrganizationDepartmentId;
            specification.ParentEducationOrganizationId = request.ParentEducationOrganizationId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OtherNameTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/otherNameTypeDescriptors")]
    public partial class OtherNameTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.OtherNameTypeDescriptor.EdFi.OtherNameTypeDescriptor,
        Entities.Common.EdFi.IOtherNameTypeDescriptor,
        Entities.NHibernate.OtherNameTypeDescriptorAggregate.EdFi.OtherNameTypeDescriptor,
        Api.Common.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorPut,
        Api.Common.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorPost,
        Api.Common.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorDelete,
        Api.Common.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorGetByExample>
    {
        public OtherNameTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorGetByExample request, Entities.Common.EdFi.IOtherNameTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OtherNameTypeDescriptorId = request.OtherNameTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Parents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/parents")]
    public partial class ParentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Parent.EdFi.Parent,
        Entities.Common.EdFi.IParent,
        Entities.NHibernate.ParentAggregate.EdFi.Parent,
        Api.Common.Models.Requests.Parents.EdFi.ParentPut,
        Api.Common.Models.Requests.Parents.EdFi.ParentPost,
        Api.Common.Models.Requests.Parents.EdFi.ParentDelete,
        Api.Common.Models.Requests.Parents.EdFi.ParentGetByExample>
    {
        public ParentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Parents.EdFi.ParentGetByExample request, Entities.Common.EdFi.IParent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
            specification.HighestCompletedLevelOfEducationDescriptor = request.HighestCompletedLevelOfEducationDescriptor;
            specification.Id = request.Id;
            specification.LastSurname = request.LastSurname;
            specification.LoginId = request.LoginId;
            specification.MaidenName = request.MaidenName;
            specification.MiddleName = request.MiddleName;
            specification.ParentUniqueId = request.ParentUniqueId;
            specification.PersonalTitlePrefix = request.PersonalTitlePrefix;
            specification.PersonId = request.PersonId;
            specification.SexDescriptor = request.SexDescriptor;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ParticipationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/participationDescriptors")]
    public partial class ParticipationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ParticipationDescriptor.EdFi.ParticipationDescriptor,
        Entities.Common.EdFi.IParticipationDescriptor,
        Entities.NHibernate.ParticipationDescriptorAggregate.EdFi.ParticipationDescriptor,
        Api.Common.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorPut,
        Api.Common.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorPost,
        Api.Common.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorDelete,
        Api.Common.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorGetByExample>
    {
        public ParticipationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorGetByExample request, Entities.Common.EdFi.IParticipationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ParticipationDescriptorId = request.ParticipationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ParticipationStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/participationStatusDescriptors")]
    public partial class ParticipationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ParticipationStatusDescriptor.EdFi.ParticipationStatusDescriptor,
        Entities.Common.EdFi.IParticipationStatusDescriptor,
        Entities.NHibernate.ParticipationStatusDescriptorAggregate.EdFi.ParticipationStatusDescriptor,
        Api.Common.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorPut,
        Api.Common.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorPost,
        Api.Common.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorDelete,
        Api.Common.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorGetByExample>
    {
        public ParticipationStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorGetByExample request, Entities.Common.EdFi.IParticipationStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ParticipationStatusDescriptorId = request.ParticipationStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PerformanceBaseConversionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/performanceBaseConversionDescriptors")]
    public partial class PerformanceBaseConversionDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceBaseConversionDescriptor.EdFi.PerformanceBaseConversionDescriptor,
        Entities.Common.EdFi.IPerformanceBaseConversionDescriptor,
        Entities.NHibernate.PerformanceBaseConversionDescriptorAggregate.EdFi.PerformanceBaseConversionDescriptor,
        Api.Common.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorPut,
        Api.Common.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorPost,
        Api.Common.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorDelete,
        Api.Common.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorGetByExample>
    {
        public PerformanceBaseConversionDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorGetByExample request, Entities.Common.EdFi.IPerformanceBaseConversionDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceBaseConversionDescriptorId = request.PerformanceBaseConversionDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PerformanceLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/performanceLevelDescriptors")]
    public partial class PerformanceLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor,
        Entities.Common.EdFi.IPerformanceLevelDescriptor,
        Entities.NHibernate.PerformanceLevelDescriptorAggregate.EdFi.PerformanceLevelDescriptor,
        Api.Common.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorPut,
        Api.Common.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorPost,
        Api.Common.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorDelete,
        Api.Common.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorGetByExample>
    {
        public PerformanceLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorGetByExample request, Entities.Common.EdFi.IPerformanceLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceLevelDescriptorId = request.PerformanceLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.People.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/people")]
    public partial class PeopleController : DataManagementControllerBase<
        Api.Common.Models.Resources.Person.EdFi.Person,
        Entities.Common.EdFi.IPerson,
        Entities.NHibernate.PersonAggregate.EdFi.Person,
        Api.Common.Models.Requests.People.EdFi.PersonPut,
        Api.Common.Models.Requests.People.EdFi.PersonPost,
        Api.Common.Models.Requests.People.EdFi.PersonDelete,
        Api.Common.Models.Requests.People.EdFi.PersonGetByExample>
    {
        public PeopleController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.People.EdFi.PersonGetByExample request, Entities.Common.EdFi.IPerson specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PersonalInformationVerificationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/personalInformationVerificationDescriptors")]
    public partial class PersonalInformationVerificationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PersonalInformationVerificationDescriptor.EdFi.PersonalInformationVerificationDescriptor,
        Entities.Common.EdFi.IPersonalInformationVerificationDescriptor,
        Entities.NHibernate.PersonalInformationVerificationDescriptorAggregate.EdFi.PersonalInformationVerificationDescriptor,
        Api.Common.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorPut,
        Api.Common.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorPost,
        Api.Common.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorDelete,
        Api.Common.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorGetByExample>
    {
        public PersonalInformationVerificationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorGetByExample request, Entities.Common.EdFi.IPersonalInformationVerificationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PersonalInformationVerificationDescriptorId = request.PersonalInformationVerificationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PlatformTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/platformTypeDescriptors")]
    public partial class PlatformTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PlatformTypeDescriptor.EdFi.PlatformTypeDescriptor,
        Entities.Common.EdFi.IPlatformTypeDescriptor,
        Entities.NHibernate.PlatformTypeDescriptorAggregate.EdFi.PlatformTypeDescriptor,
        Api.Common.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorPut,
        Api.Common.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorPost,
        Api.Common.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorDelete,
        Api.Common.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorGetByExample>
    {
        public PlatformTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorGetByExample request, Entities.Common.EdFi.IPlatformTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PlatformTypeDescriptorId = request.PlatformTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PopulationServedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/populationServedDescriptors")]
    public partial class PopulationServedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PopulationServedDescriptor.EdFi.PopulationServedDescriptor,
        Entities.Common.EdFi.IPopulationServedDescriptor,
        Entities.NHibernate.PopulationServedDescriptorAggregate.EdFi.PopulationServedDescriptor,
        Api.Common.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorPut,
        Api.Common.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorPost,
        Api.Common.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorDelete,
        Api.Common.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorGetByExample>
    {
        public PopulationServedDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorGetByExample request, Entities.Common.EdFi.IPopulationServedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PopulationServedDescriptorId = request.PopulationServedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostingResultDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/postingResultDescriptors")]
    public partial class PostingResultDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PostingResultDescriptor.EdFi.PostingResultDescriptor,
        Entities.Common.EdFi.IPostingResultDescriptor,
        Entities.NHibernate.PostingResultDescriptorAggregate.EdFi.PostingResultDescriptor,
        Api.Common.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorPut,
        Api.Common.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorPost,
        Api.Common.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorDelete,
        Api.Common.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorGetByExample>
    {
        public PostingResultDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorGetByExample request, Entities.Common.EdFi.IPostingResultDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PostingResultDescriptorId = request.PostingResultDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/postSecondaryEvents")]
    public partial class PostSecondaryEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PostSecondaryEvent.EdFi.PostSecondaryEvent,
        Entities.Common.EdFi.IPostSecondaryEvent,
        Entities.NHibernate.PostSecondaryEventAggregate.EdFi.PostSecondaryEvent,
        Api.Common.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventPut,
        Api.Common.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventPost,
        Api.Common.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventDelete,
        Api.Common.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventGetByExample>
    {
        public PostSecondaryEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventGetByExample request, Entities.Common.EdFi.IPostSecondaryEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EventDate = request.EventDate;
            specification.Id = request.Id;
            specification.PostSecondaryEventCategoryDescriptor = request.PostSecondaryEventCategoryDescriptor;
            specification.PostSecondaryInstitutionId = request.PostSecondaryInstitutionId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/postSecondaryEventCategoryDescriptors")]
    public partial class PostSecondaryEventCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PostSecondaryEventCategoryDescriptor.EdFi.PostSecondaryEventCategoryDescriptor,
        Entities.Common.EdFi.IPostSecondaryEventCategoryDescriptor,
        Entities.NHibernate.PostSecondaryEventCategoryDescriptorAggregate.EdFi.PostSecondaryEventCategoryDescriptor,
        Api.Common.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorPut,
        Api.Common.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorPost,
        Api.Common.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorDelete,
        Api.Common.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorGetByExample>
    {
        public PostSecondaryEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorGetByExample request, Entities.Common.EdFi.IPostSecondaryEventCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PostSecondaryEventCategoryDescriptorId = request.PostSecondaryEventCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryInstitutions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/postSecondaryInstitutions")]
    public partial class PostSecondaryInstitutionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution,
        Entities.Common.EdFi.IPostSecondaryInstitution,
        Entities.NHibernate.PostSecondaryInstitutionAggregate.EdFi.PostSecondaryInstitution,
        Api.Common.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionPut,
        Api.Common.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionPost,
        Api.Common.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionDelete,
        Api.Common.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionGetByExample>
    {
        public PostSecondaryInstitutionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionGetByExample request, Entities.Common.EdFi.IPostSecondaryInstitution specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.PostSecondaryInstitutionId = request.PostSecondaryInstitutionId;
            specification.PostSecondaryInstitutionLevelDescriptor = request.PostSecondaryInstitutionLevelDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryInstitutionLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/postSecondaryInstitutionLevelDescriptors")]
    public partial class PostSecondaryInstitutionLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PostSecondaryInstitutionLevelDescriptor.EdFi.PostSecondaryInstitutionLevelDescriptor,
        Entities.Common.EdFi.IPostSecondaryInstitutionLevelDescriptor,
        Entities.NHibernate.PostSecondaryInstitutionLevelDescriptorAggregate.EdFi.PostSecondaryInstitutionLevelDescriptor,
        Api.Common.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorPut,
        Api.Common.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorPost,
        Api.Common.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorDelete,
        Api.Common.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorGetByExample>
    {
        public PostSecondaryInstitutionLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorGetByExample request, Entities.Common.EdFi.IPostSecondaryInstitutionLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PostSecondaryInstitutionLevelDescriptorId = request.PostSecondaryInstitutionLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PrimaryLearningDeviceAccessDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/primaryLearningDeviceAccessDescriptors")]
    public partial class PrimaryLearningDeviceAccessDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PrimaryLearningDeviceAccessDescriptor.EdFi.PrimaryLearningDeviceAccessDescriptor,
        Entities.Common.EdFi.IPrimaryLearningDeviceAccessDescriptor,
        Entities.NHibernate.PrimaryLearningDeviceAccessDescriptorAggregate.EdFi.PrimaryLearningDeviceAccessDescriptor,
        Api.Common.Models.Requests.PrimaryLearningDeviceAccessDescriptors.EdFi.PrimaryLearningDeviceAccessDescriptorPut,
        Api.Common.Models.Requests.PrimaryLearningDeviceAccessDescriptors.EdFi.PrimaryLearningDeviceAccessDescriptorPost,
        Api.Common.Models.Requests.PrimaryLearningDeviceAccessDescriptors.EdFi.PrimaryLearningDeviceAccessDescriptorDelete,
        Api.Common.Models.Requests.PrimaryLearningDeviceAccessDescriptors.EdFi.PrimaryLearningDeviceAccessDescriptorGetByExample>
    {
        public PrimaryLearningDeviceAccessDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PrimaryLearningDeviceAccessDescriptors.EdFi.PrimaryLearningDeviceAccessDescriptorGetByExample request, Entities.Common.EdFi.IPrimaryLearningDeviceAccessDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PrimaryLearningDeviceAccessDescriptorId = request.PrimaryLearningDeviceAccessDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/primaryLearningDeviceAwayFromSchoolDescriptors")]
    public partial class PrimaryLearningDeviceAwayFromSchoolDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PrimaryLearningDeviceAwayFromSchoolDescriptor.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptor,
        Entities.Common.EdFi.IPrimaryLearningDeviceAwayFromSchoolDescriptor,
        Entities.NHibernate.PrimaryLearningDeviceAwayFromSchoolDescriptorAggregate.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptor,
        Api.Common.Models.Requests.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptorPut,
        Api.Common.Models.Requests.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptorPost,
        Api.Common.Models.Requests.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptorDelete,
        Api.Common.Models.Requests.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptorGetByExample>
    {
        public PrimaryLearningDeviceAwayFromSchoolDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptorGetByExample request, Entities.Common.EdFi.IPrimaryLearningDeviceAwayFromSchoolDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PrimaryLearningDeviceAwayFromSchoolDescriptorId = request.PrimaryLearningDeviceAwayFromSchoolDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PrimaryLearningDeviceProviderDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/primaryLearningDeviceProviderDescriptors")]
    public partial class PrimaryLearningDeviceProviderDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PrimaryLearningDeviceProviderDescriptor.EdFi.PrimaryLearningDeviceProviderDescriptor,
        Entities.Common.EdFi.IPrimaryLearningDeviceProviderDescriptor,
        Entities.NHibernate.PrimaryLearningDeviceProviderDescriptorAggregate.EdFi.PrimaryLearningDeviceProviderDescriptor,
        Api.Common.Models.Requests.PrimaryLearningDeviceProviderDescriptors.EdFi.PrimaryLearningDeviceProviderDescriptorPut,
        Api.Common.Models.Requests.PrimaryLearningDeviceProviderDescriptors.EdFi.PrimaryLearningDeviceProviderDescriptorPost,
        Api.Common.Models.Requests.PrimaryLearningDeviceProviderDescriptors.EdFi.PrimaryLearningDeviceProviderDescriptorDelete,
        Api.Common.Models.Requests.PrimaryLearningDeviceProviderDescriptors.EdFi.PrimaryLearningDeviceProviderDescriptorGetByExample>
    {
        public PrimaryLearningDeviceProviderDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PrimaryLearningDeviceProviderDescriptors.EdFi.PrimaryLearningDeviceProviderDescriptorGetByExample request, Entities.Common.EdFi.IPrimaryLearningDeviceProviderDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PrimaryLearningDeviceProviderDescriptorId = request.PrimaryLearningDeviceProviderDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProficiencyDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/proficiencyDescriptors")]
    public partial class ProficiencyDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProficiencyDescriptor.EdFi.ProficiencyDescriptor,
        Entities.Common.EdFi.IProficiencyDescriptor,
        Entities.NHibernate.ProficiencyDescriptorAggregate.EdFi.ProficiencyDescriptor,
        Api.Common.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorPut,
        Api.Common.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorPost,
        Api.Common.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorDelete,
        Api.Common.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorGetByExample>
    {
        public ProficiencyDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorGetByExample request, Entities.Common.EdFi.IProficiencyDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProficiencyDescriptorId = request.ProficiencyDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Programs.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/programs")]
    public partial class ProgramsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Program.EdFi.Program,
        Entities.Common.EdFi.IProgram,
        Entities.NHibernate.ProgramAggregate.EdFi.Program,
        Api.Common.Models.Requests.Programs.EdFi.ProgramPut,
        Api.Common.Models.Requests.Programs.EdFi.ProgramPost,
        Api.Common.Models.Requests.Programs.EdFi.ProgramDelete,
        Api.Common.Models.Requests.Programs.EdFi.ProgramGetByExample>
    {
        public ProgramsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Programs.EdFi.ProgramGetByExample request, Entities.Common.EdFi.IProgram specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProgramId = request.ProgramId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramAssignmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/programAssignmentDescriptors")]
    public partial class ProgramAssignmentDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgramAssignmentDescriptor.EdFi.ProgramAssignmentDescriptor,
        Entities.Common.EdFi.IProgramAssignmentDescriptor,
        Entities.NHibernate.ProgramAssignmentDescriptorAggregate.EdFi.ProgramAssignmentDescriptor,
        Api.Common.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorPut,
        Api.Common.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorPost,
        Api.Common.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorDelete,
        Api.Common.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorGetByExample>
    {
        public ProgramAssignmentDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorGetByExample request, Entities.Common.EdFi.IProgramAssignmentDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramAssignmentDescriptorId = request.ProgramAssignmentDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/programCharacteristicDescriptors")]
    public partial class ProgramCharacteristicDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgramCharacteristicDescriptor.EdFi.ProgramCharacteristicDescriptor,
        Entities.Common.EdFi.IProgramCharacteristicDescriptor,
        Entities.NHibernate.ProgramCharacteristicDescriptorAggregate.EdFi.ProgramCharacteristicDescriptor,
        Api.Common.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorPut,
        Api.Common.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorPost,
        Api.Common.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorDelete,
        Api.Common.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorGetByExample>
    {
        public ProgramCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorGetByExample request, Entities.Common.EdFi.IProgramCharacteristicDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramCharacteristicDescriptorId = request.ProgramCharacteristicDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/programDimensions")]
    public partial class ProgramDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgramDimension.EdFi.ProgramDimension,
        Entities.Common.EdFi.IProgramDimension,
        Entities.NHibernate.ProgramDimensionAggregate.EdFi.ProgramDimension,
        Api.Common.Models.Requests.ProgramDimensions.EdFi.ProgramDimensionPut,
        Api.Common.Models.Requests.ProgramDimensions.EdFi.ProgramDimensionPost,
        Api.Common.Models.Requests.ProgramDimensions.EdFi.ProgramDimensionDelete,
        Api.Common.Models.Requests.ProgramDimensions.EdFi.ProgramDimensionGetByExample>
    {
        public ProgramDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgramDimensions.EdFi.ProgramDimensionGetByExample request, Entities.Common.EdFi.IProgramDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramSponsorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/programSponsorDescriptors")]
    public partial class ProgramSponsorDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgramSponsorDescriptor.EdFi.ProgramSponsorDescriptor,
        Entities.Common.EdFi.IProgramSponsorDescriptor,
        Entities.NHibernate.ProgramSponsorDescriptorAggregate.EdFi.ProgramSponsorDescriptor,
        Api.Common.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorPut,
        Api.Common.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorPost,
        Api.Common.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorDelete,
        Api.Common.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorGetByExample>
    {
        public ProgramSponsorDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorGetByExample request, Entities.Common.EdFi.IProgramSponsorDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramSponsorDescriptorId = request.ProgramSponsorDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/programTypeDescriptors")]
    public partial class ProgramTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgramTypeDescriptor.EdFi.ProgramTypeDescriptor,
        Entities.Common.EdFi.IProgramTypeDescriptor,
        Entities.NHibernate.ProgramTypeDescriptorAggregate.EdFi.ProgramTypeDescriptor,
        Api.Common.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorPut,
        Api.Common.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorPost,
        Api.Common.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorDelete,
        Api.Common.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorGetByExample>
    {
        public ProgramTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorGetByExample request, Entities.Common.EdFi.IProgramTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramTypeDescriptorId = request.ProgramTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgressDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/progressDescriptors")]
    public partial class ProgressDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgressDescriptor.EdFi.ProgressDescriptor,
        Entities.Common.EdFi.IProgressDescriptor,
        Entities.NHibernate.ProgressDescriptorAggregate.EdFi.ProgressDescriptor,
        Api.Common.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorPut,
        Api.Common.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorPost,
        Api.Common.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorDelete,
        Api.Common.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorGetByExample>
    {
        public ProgressDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorGetByExample request, Entities.Common.EdFi.IProgressDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgressDescriptorId = request.ProgressDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgressLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/progressLevelDescriptors")]
    public partial class ProgressLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProgressLevelDescriptor.EdFi.ProgressLevelDescriptor,
        Entities.Common.EdFi.IProgressLevelDescriptor,
        Entities.NHibernate.ProgressLevelDescriptorAggregate.EdFi.ProgressLevelDescriptor,
        Api.Common.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorPut,
        Api.Common.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorPost,
        Api.Common.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorDelete,
        Api.Common.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorGetByExample>
    {
        public ProgressLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorGetByExample request, Entities.Common.EdFi.IProgressLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgressLevelDescriptorId = request.ProgressLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProjectDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/projectDimensions")]
    public partial class ProjectDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProjectDimension.EdFi.ProjectDimension,
        Entities.Common.EdFi.IProjectDimension,
        Entities.NHibernate.ProjectDimensionAggregate.EdFi.ProjectDimension,
        Api.Common.Models.Requests.ProjectDimensions.EdFi.ProjectDimensionPut,
        Api.Common.Models.Requests.ProjectDimensions.EdFi.ProjectDimensionPost,
        Api.Common.Models.Requests.ProjectDimensions.EdFi.ProjectDimensionDelete,
        Api.Common.Models.Requests.ProjectDimensions.EdFi.ProjectDimensionGetByExample>
    {
        public ProjectDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProjectDimensions.EdFi.ProjectDimensionGetByExample request, Entities.Common.EdFi.IProjectDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProviderCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/providerCategoryDescriptors")]
    public partial class ProviderCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProviderCategoryDescriptor.EdFi.ProviderCategoryDescriptor,
        Entities.Common.EdFi.IProviderCategoryDescriptor,
        Entities.NHibernate.ProviderCategoryDescriptorAggregate.EdFi.ProviderCategoryDescriptor,
        Api.Common.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorPut,
        Api.Common.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorPost,
        Api.Common.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorDelete,
        Api.Common.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorGetByExample>
    {
        public ProviderCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorGetByExample request, Entities.Common.EdFi.IProviderCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProviderCategoryDescriptorId = request.ProviderCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProviderProfitabilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/providerProfitabilityDescriptors")]
    public partial class ProviderProfitabilityDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProviderProfitabilityDescriptor.EdFi.ProviderProfitabilityDescriptor,
        Entities.Common.EdFi.IProviderProfitabilityDescriptor,
        Entities.NHibernate.ProviderProfitabilityDescriptorAggregate.EdFi.ProviderProfitabilityDescriptor,
        Api.Common.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorPut,
        Api.Common.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorPost,
        Api.Common.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorDelete,
        Api.Common.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorGetByExample>
    {
        public ProviderProfitabilityDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorGetByExample request, Entities.Common.EdFi.IProviderProfitabilityDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProviderProfitabilityDescriptorId = request.ProviderProfitabilityDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProviderStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/providerStatusDescriptors")]
    public partial class ProviderStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ProviderStatusDescriptor.EdFi.ProviderStatusDescriptor,
        Entities.Common.EdFi.IProviderStatusDescriptor,
        Entities.NHibernate.ProviderStatusDescriptorAggregate.EdFi.ProviderStatusDescriptor,
        Api.Common.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorPut,
        Api.Common.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorPost,
        Api.Common.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorDelete,
        Api.Common.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorGetByExample>
    {
        public ProviderStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorGetByExample request, Entities.Common.EdFi.IProviderStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProviderStatusDescriptorId = request.ProviderStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PublicationStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/publicationStatusDescriptors")]
    public partial class PublicationStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.PublicationStatusDescriptor.EdFi.PublicationStatusDescriptor,
        Entities.Common.EdFi.IPublicationStatusDescriptor,
        Entities.NHibernate.PublicationStatusDescriptorAggregate.EdFi.PublicationStatusDescriptor,
        Api.Common.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorPut,
        Api.Common.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorPost,
        Api.Common.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorDelete,
        Api.Common.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorGetByExample>
    {
        public PublicationStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorGetByExample request, Entities.Common.EdFi.IPublicationStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PublicationStatusDescriptorId = request.PublicationStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.QuestionFormDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/questionFormDescriptors")]
    public partial class QuestionFormDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.QuestionFormDescriptor.EdFi.QuestionFormDescriptor,
        Entities.Common.EdFi.IQuestionFormDescriptor,
        Entities.NHibernate.QuestionFormDescriptorAggregate.EdFi.QuestionFormDescriptor,
        Api.Common.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorPut,
        Api.Common.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorPost,
        Api.Common.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorDelete,
        Api.Common.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorGetByExample>
    {
        public QuestionFormDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorGetByExample request, Entities.Common.EdFi.IQuestionFormDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.QuestionFormDescriptorId = request.QuestionFormDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RaceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/raceDescriptors")]
    public partial class RaceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RaceDescriptor.EdFi.RaceDescriptor,
        Entities.Common.EdFi.IRaceDescriptor,
        Entities.NHibernate.RaceDescriptorAggregate.EdFi.RaceDescriptor,
        Api.Common.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorPut,
        Api.Common.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorPost,
        Api.Common.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorDelete,
        Api.Common.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorGetByExample>
    {
        public RaceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorGetByExample request, Entities.Common.EdFi.IRaceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RaceDescriptorId = request.RaceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReasonExitedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/reasonExitedDescriptors")]
    public partial class ReasonExitedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ReasonExitedDescriptor.EdFi.ReasonExitedDescriptor,
        Entities.Common.EdFi.IReasonExitedDescriptor,
        Entities.NHibernate.ReasonExitedDescriptorAggregate.EdFi.ReasonExitedDescriptor,
        Api.Common.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorPut,
        Api.Common.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorPost,
        Api.Common.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorDelete,
        Api.Common.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorGetByExample>
    {
        public ReasonExitedDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorGetByExample request, Entities.Common.EdFi.IReasonExitedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReasonExitedDescriptorId = request.ReasonExitedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReasonNotTestedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/reasonNotTestedDescriptors")]
    public partial class ReasonNotTestedDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ReasonNotTestedDescriptor.EdFi.ReasonNotTestedDescriptor,
        Entities.Common.EdFi.IReasonNotTestedDescriptor,
        Entities.NHibernate.ReasonNotTestedDescriptorAggregate.EdFi.ReasonNotTestedDescriptor,
        Api.Common.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorPut,
        Api.Common.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorPost,
        Api.Common.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorDelete,
        Api.Common.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorGetByExample>
    {
        public ReasonNotTestedDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorGetByExample request, Entities.Common.EdFi.IReasonNotTestedDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReasonNotTestedDescriptorId = request.ReasonNotTestedDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RecognitionTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/recognitionTypeDescriptors")]
    public partial class RecognitionTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RecognitionTypeDescriptor.EdFi.RecognitionTypeDescriptor,
        Entities.Common.EdFi.IRecognitionTypeDescriptor,
        Entities.NHibernate.RecognitionTypeDescriptorAggregate.EdFi.RecognitionTypeDescriptor,
        Api.Common.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorPut,
        Api.Common.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorPost,
        Api.Common.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorDelete,
        Api.Common.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorGetByExample>
    {
        public RecognitionTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorGetByExample request, Entities.Common.EdFi.IRecognitionTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RecognitionTypeDescriptorId = request.RecognitionTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RelationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/relationDescriptors")]
    public partial class RelationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RelationDescriptor.EdFi.RelationDescriptor,
        Entities.Common.EdFi.IRelationDescriptor,
        Entities.NHibernate.RelationDescriptorAggregate.EdFi.RelationDescriptor,
        Api.Common.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorPut,
        Api.Common.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorPost,
        Api.Common.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorDelete,
        Api.Common.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorGetByExample>
    {
        public RelationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorGetByExample request, Entities.Common.EdFi.IRelationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RelationDescriptorId = request.RelationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RepeatIdentifierDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/repeatIdentifierDescriptors")]
    public partial class RepeatIdentifierDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RepeatIdentifierDescriptor.EdFi.RepeatIdentifierDescriptor,
        Entities.Common.EdFi.IRepeatIdentifierDescriptor,
        Entities.NHibernate.RepeatIdentifierDescriptorAggregate.EdFi.RepeatIdentifierDescriptor,
        Api.Common.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorPut,
        Api.Common.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorPost,
        Api.Common.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorDelete,
        Api.Common.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorGetByExample>
    {
        public RepeatIdentifierDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorGetByExample request, Entities.Common.EdFi.IRepeatIdentifierDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RepeatIdentifierDescriptorId = request.RepeatIdentifierDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReportCards.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/reportCards")]
    public partial class ReportCardsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ReportCard.EdFi.ReportCard,
        Entities.Common.EdFi.IReportCard,
        Entities.NHibernate.ReportCardAggregate.EdFi.ReportCard,
        Api.Common.Models.Requests.ReportCards.EdFi.ReportCardPut,
        Api.Common.Models.Requests.ReportCards.EdFi.ReportCardPost,
        Api.Common.Models.Requests.ReportCards.EdFi.ReportCardDelete,
        Api.Common.Models.Requests.ReportCards.EdFi.ReportCardGetByExample>
    {
        public ReportCardsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ReportCards.EdFi.ReportCardGetByExample request, Entities.Common.EdFi.IReportCard specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.GPACumulative = request.GPACumulative;
            specification.GPAGivenGradingPeriod = request.GPAGivenGradingPeriod;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.GradingPeriodSchoolId = request.GradingPeriodSchoolId;
            specification.GradingPeriodSchoolYear = request.GradingPeriodSchoolYear;
            specification.GradingPeriodSequence = request.GradingPeriodSequence;
            specification.Id = request.Id;
            specification.NumberOfDaysAbsent = request.NumberOfDaysAbsent;
            specification.NumberOfDaysInAttendance = request.NumberOfDaysInAttendance;
            specification.NumberOfDaysTardy = request.NumberOfDaysTardy;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReporterDescriptionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/reporterDescriptionDescriptors")]
    public partial class ReporterDescriptionDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ReporterDescriptionDescriptor.EdFi.ReporterDescriptionDescriptor,
        Entities.Common.EdFi.IReporterDescriptionDescriptor,
        Entities.NHibernate.ReporterDescriptionDescriptorAggregate.EdFi.ReporterDescriptionDescriptor,
        Api.Common.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorPut,
        Api.Common.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorPost,
        Api.Common.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorDelete,
        Api.Common.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorGetByExample>
    {
        public ReporterDescriptionDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorGetByExample request, Entities.Common.EdFi.IReporterDescriptionDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReporterDescriptionDescriptorId = request.ReporterDescriptionDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReportingTagDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/reportingTagDescriptors")]
    public partial class ReportingTagDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ReportingTagDescriptor.EdFi.ReportingTagDescriptor,
        Entities.Common.EdFi.IReportingTagDescriptor,
        Entities.NHibernate.ReportingTagDescriptorAggregate.EdFi.ReportingTagDescriptor,
        Api.Common.Models.Requests.ReportingTagDescriptors.EdFi.ReportingTagDescriptorPut,
        Api.Common.Models.Requests.ReportingTagDescriptors.EdFi.ReportingTagDescriptorPost,
        Api.Common.Models.Requests.ReportingTagDescriptors.EdFi.ReportingTagDescriptorDelete,
        Api.Common.Models.Requests.ReportingTagDescriptors.EdFi.ReportingTagDescriptorGetByExample>
    {
        public ReportingTagDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ReportingTagDescriptors.EdFi.ReportingTagDescriptorGetByExample request, Entities.Common.EdFi.IReportingTagDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReportingTagDescriptorId = request.ReportingTagDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResidencyStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/residencyStatusDescriptors")]
    public partial class ResidencyStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ResidencyStatusDescriptor.EdFi.ResidencyStatusDescriptor,
        Entities.Common.EdFi.IResidencyStatusDescriptor,
        Entities.NHibernate.ResidencyStatusDescriptorAggregate.EdFi.ResidencyStatusDescriptor,
        Api.Common.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorPut,
        Api.Common.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorPost,
        Api.Common.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorDelete,
        Api.Common.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorGetByExample>
    {
        public ResidencyStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorGetByExample request, Entities.Common.EdFi.IResidencyStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResidencyStatusDescriptorId = request.ResidencyStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResponseIndicatorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/responseIndicatorDescriptors")]
    public partial class ResponseIndicatorDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ResponseIndicatorDescriptor.EdFi.ResponseIndicatorDescriptor,
        Entities.Common.EdFi.IResponseIndicatorDescriptor,
        Entities.NHibernate.ResponseIndicatorDescriptorAggregate.EdFi.ResponseIndicatorDescriptor,
        Api.Common.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorPut,
        Api.Common.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorPost,
        Api.Common.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorDelete,
        Api.Common.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorGetByExample>
    {
        public ResponseIndicatorDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorGetByExample request, Entities.Common.EdFi.IResponseIndicatorDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResponseIndicatorDescriptorId = request.ResponseIndicatorDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResponsibilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/responsibilityDescriptors")]
    public partial class ResponsibilityDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ResponsibilityDescriptor.EdFi.ResponsibilityDescriptor,
        Entities.Common.EdFi.IResponsibilityDescriptor,
        Entities.NHibernate.ResponsibilityDescriptorAggregate.EdFi.ResponsibilityDescriptor,
        Api.Common.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorPut,
        Api.Common.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorPost,
        Api.Common.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorDelete,
        Api.Common.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorGetByExample>
    {
        public ResponsibilityDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorGetByExample request, Entities.Common.EdFi.IResponsibilityDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResponsibilityDescriptorId = request.ResponsibilityDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RestraintEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/restraintEvents")]
    public partial class RestraintEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RestraintEvent.EdFi.RestraintEvent,
        Entities.Common.EdFi.IRestraintEvent,
        Entities.NHibernate.RestraintEventAggregate.EdFi.RestraintEvent,
        Api.Common.Models.Requests.RestraintEvents.EdFi.RestraintEventPut,
        Api.Common.Models.Requests.RestraintEvents.EdFi.RestraintEventPost,
        Api.Common.Models.Requests.RestraintEvents.EdFi.RestraintEventDelete,
        Api.Common.Models.Requests.RestraintEvents.EdFi.RestraintEventGetByExample>
    {
        public RestraintEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RestraintEvents.EdFi.RestraintEventGetByExample request, Entities.Common.EdFi.IRestraintEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationalEnvironmentDescriptor = request.EducationalEnvironmentDescriptor;
            specification.EventDate = request.EventDate;
            specification.Id = request.Id;
            specification.RestraintEventIdentifier = request.RestraintEventIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RestraintEventReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/restraintEventReasonDescriptors")]
    public partial class RestraintEventReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RestraintEventReasonDescriptor.EdFi.RestraintEventReasonDescriptor,
        Entities.Common.EdFi.IRestraintEventReasonDescriptor,
        Entities.NHibernate.RestraintEventReasonDescriptorAggregate.EdFi.RestraintEventReasonDescriptor,
        Api.Common.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorPut,
        Api.Common.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorPost,
        Api.Common.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorDelete,
        Api.Common.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorGetByExample>
    {
        public RestraintEventReasonDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorGetByExample request, Entities.Common.EdFi.IRestraintEventReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RestraintEventReasonDescriptorId = request.RestraintEventReasonDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResultDatatypeTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/resultDatatypeTypeDescriptors")]
    public partial class ResultDatatypeTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ResultDatatypeTypeDescriptor.EdFi.ResultDatatypeTypeDescriptor,
        Entities.Common.EdFi.IResultDatatypeTypeDescriptor,
        Entities.NHibernate.ResultDatatypeTypeDescriptorAggregate.EdFi.ResultDatatypeTypeDescriptor,
        Api.Common.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorPut,
        Api.Common.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorPost,
        Api.Common.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorDelete,
        Api.Common.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorGetByExample>
    {
        public ResultDatatypeTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorGetByExample request, Entities.Common.EdFi.IResultDatatypeTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResultDatatypeTypeDescriptorId = request.ResultDatatypeTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RetestIndicatorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/retestIndicatorDescriptors")]
    public partial class RetestIndicatorDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.RetestIndicatorDescriptor.EdFi.RetestIndicatorDescriptor,
        Entities.Common.EdFi.IRetestIndicatorDescriptor,
        Entities.NHibernate.RetestIndicatorDescriptorAggregate.EdFi.RetestIndicatorDescriptor,
        Api.Common.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorPut,
        Api.Common.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorPost,
        Api.Common.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorDelete,
        Api.Common.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorGetByExample>
    {
        public RetestIndicatorDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorGetByExample request, Entities.Common.EdFi.IRetestIndicatorDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RetestIndicatorDescriptorId = request.RetestIndicatorDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/schools")]
    public partial class SchoolsController : DataManagementControllerBase<
        Api.Common.Models.Resources.School.EdFi.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Common.Models.Requests.Schools.EdFi.SchoolPut,
        Api.Common.Models.Requests.Schools.EdFi.SchoolPost,
        Api.Common.Models.Requests.Schools.EdFi.SchoolDelete,
        Api.Common.Models.Requests.Schools.EdFi.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Schools.EdFi.SchoolGetByExample request, Entities.Common.EdFi.ISchool specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/schoolCategoryDescriptors")]
    public partial class SchoolCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SchoolCategoryDescriptor.EdFi.SchoolCategoryDescriptor,
        Entities.Common.EdFi.ISchoolCategoryDescriptor,
        Entities.NHibernate.SchoolCategoryDescriptorAggregate.EdFi.SchoolCategoryDescriptor,
        Api.Common.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorPut,
        Api.Common.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorPost,
        Api.Common.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorDelete,
        Api.Common.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorGetByExample>
    {
        public SchoolCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorGetByExample request, Entities.Common.EdFi.ISchoolCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolCategoryDescriptorId = request.SchoolCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolChoiceImplementStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/schoolChoiceImplementStatusDescriptors")]
    public partial class SchoolChoiceImplementStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SchoolChoiceImplementStatusDescriptor.EdFi.SchoolChoiceImplementStatusDescriptor,
        Entities.Common.EdFi.ISchoolChoiceImplementStatusDescriptor,
        Entities.NHibernate.SchoolChoiceImplementStatusDescriptorAggregate.EdFi.SchoolChoiceImplementStatusDescriptor,
        Api.Common.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorPut,
        Api.Common.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorPost,
        Api.Common.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorDelete,
        Api.Common.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorGetByExample>
    {
        public SchoolChoiceImplementStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorGetByExample request, Entities.Common.EdFi.ISchoolChoiceImplementStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolChoiceImplementStatusDescriptorId = request.SchoolChoiceImplementStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolFoodServiceProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/schoolFoodServiceProgramServiceDescriptors")]
    public partial class SchoolFoodServiceProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SchoolFoodServiceProgramServiceDescriptor.EdFi.SchoolFoodServiceProgramServiceDescriptor,
        Entities.Common.EdFi.ISchoolFoodServiceProgramServiceDescriptor,
        Entities.NHibernate.SchoolFoodServiceProgramServiceDescriptorAggregate.EdFi.SchoolFoodServiceProgramServiceDescriptor,
        Api.Common.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorPut,
        Api.Common.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorPost,
        Api.Common.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorGetByExample>
    {
        public SchoolFoodServiceProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.ISchoolFoodServiceProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolFoodServiceProgramServiceDescriptorId = request.SchoolFoodServiceProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/schoolTypeDescriptors")]
    public partial class SchoolTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SchoolTypeDescriptor.EdFi.SchoolTypeDescriptor,
        Entities.Common.EdFi.ISchoolTypeDescriptor,
        Entities.NHibernate.SchoolTypeDescriptorAggregate.EdFi.SchoolTypeDescriptor,
        Api.Common.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorPut,
        Api.Common.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorPost,
        Api.Common.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorDelete,
        Api.Common.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorGetByExample>
    {
        public SchoolTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorGetByExample request, Entities.Common.EdFi.ISchoolTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolTypeDescriptorId = request.SchoolTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolYearTypes.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/schoolYearTypes")]
    public partial class SchoolYearTypesController : DataManagementControllerBase<
        Api.Common.Models.Resources.SchoolYearType.EdFi.SchoolYearType,
        Entities.Common.EdFi.ISchoolYearType,
        Entities.NHibernate.SchoolYearTypeAggregate.EdFi.SchoolYearType,
        Api.Common.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypePut,
        Api.Common.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypePost,
        Api.Common.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypeDelete,
        Api.Common.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypeGetByExample>
    {
        public SchoolYearTypesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypeGetByExample request, Entities.Common.EdFi.ISchoolYearType specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CurrentSchoolYear = request.CurrentSchoolYear;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.SchoolYearDescription = request.SchoolYearDescription;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sections.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sections")]
    public partial class SectionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Section.EdFi.Section,
        Entities.Common.EdFi.ISection,
        Entities.NHibernate.SectionAggregate.EdFi.Section,
        Api.Common.Models.Requests.Sections.EdFi.SectionPut,
        Api.Common.Models.Requests.Sections.EdFi.SectionPost,
        Api.Common.Models.Requests.Sections.EdFi.SectionDelete,
        Api.Common.Models.Requests.Sections.EdFi.SectionGetByExample>
    {
        public SectionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Sections.EdFi.SectionGetByExample request, Entities.Common.EdFi.ISection specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AvailableCreditConversion = request.AvailableCreditConversion;
            specification.AvailableCredits = request.AvailableCredits;
            specification.AvailableCreditTypeDescriptor = request.AvailableCreditTypeDescriptor;
            specification.EducationalEnvironmentDescriptor = request.EducationalEnvironmentDescriptor;
            specification.Id = request.Id;
            specification.InstructionLanguageDescriptor = request.InstructionLanguageDescriptor;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.LocationClassroomIdentificationCode = request.LocationClassroomIdentificationCode;
            specification.LocationSchoolId = request.LocationSchoolId;
            specification.MediumOfInstructionDescriptor = request.MediumOfInstructionDescriptor;
            specification.OfficialAttendancePeriod = request.OfficialAttendancePeriod;
            specification.PopulationServedDescriptor = request.PopulationServedDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SectionName = request.SectionName;
            specification.SequenceOfCourse = request.SequenceOfCourse;
            specification.SessionName = request.SessionName;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SectionAttendanceTakenEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sectionAttendanceTakenEvents")]
    public partial class SectionAttendanceTakenEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SectionAttendanceTakenEvent.EdFi.SectionAttendanceTakenEvent,
        Entities.Common.EdFi.ISectionAttendanceTakenEvent,
        Entities.NHibernate.SectionAttendanceTakenEventAggregate.EdFi.SectionAttendanceTakenEvent,
        Api.Common.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventPut,
        Api.Common.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventPost,
        Api.Common.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventDelete,
        Api.Common.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventGetByExample>
    {
        public SectionAttendanceTakenEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventGetByExample request, Entities.Common.EdFi.ISectionAttendanceTakenEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.Date = request.Date;
            specification.EventDate = request.EventDate;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SectionCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sectionCharacteristicDescriptors")]
    public partial class SectionCharacteristicDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SectionCharacteristicDescriptor.EdFi.SectionCharacteristicDescriptor,
        Entities.Common.EdFi.ISectionCharacteristicDescriptor,
        Entities.NHibernate.SectionCharacteristicDescriptorAggregate.EdFi.SectionCharacteristicDescriptor,
        Api.Common.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorPut,
        Api.Common.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorPost,
        Api.Common.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorDelete,
        Api.Common.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorGetByExample>
    {
        public SectionCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorGetByExample request, Entities.Common.EdFi.ISectionCharacteristicDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SectionCharacteristicDescriptorId = request.SectionCharacteristicDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SeparationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/separationDescriptors")]
    public partial class SeparationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SeparationDescriptor.EdFi.SeparationDescriptor,
        Entities.Common.EdFi.ISeparationDescriptor,
        Entities.NHibernate.SeparationDescriptorAggregate.EdFi.SeparationDescriptor,
        Api.Common.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorPut,
        Api.Common.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorPost,
        Api.Common.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorDelete,
        Api.Common.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorGetByExample>
    {
        public SeparationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorGetByExample request, Entities.Common.EdFi.ISeparationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SeparationDescriptorId = request.SeparationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SeparationReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/separationReasonDescriptors")]
    public partial class SeparationReasonDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SeparationReasonDescriptor.EdFi.SeparationReasonDescriptor,
        Entities.Common.EdFi.ISeparationReasonDescriptor,
        Entities.NHibernate.SeparationReasonDescriptorAggregate.EdFi.SeparationReasonDescriptor,
        Api.Common.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorPut,
        Api.Common.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorPost,
        Api.Common.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorDelete,
        Api.Common.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorGetByExample>
    {
        public SeparationReasonDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorGetByExample request, Entities.Common.EdFi.ISeparationReasonDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SeparationReasonDescriptorId = request.SeparationReasonDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/serviceDescriptors")]
    public partial class ServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.ServiceDescriptor.EdFi.ServiceDescriptor,
        Entities.Common.EdFi.IServiceDescriptor,
        Entities.NHibernate.ServiceDescriptorAggregate.EdFi.ServiceDescriptor,
        Api.Common.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorPut,
        Api.Common.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorPost,
        Api.Common.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorDelete,
        Api.Common.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorGetByExample>
    {
        public ServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorGetByExample request, Entities.Common.EdFi.IServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ServiceDescriptorId = request.ServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sessions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sessions")]
    public partial class SessionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Session.EdFi.Session,
        Entities.Common.EdFi.ISession,
        Entities.NHibernate.SessionAggregate.EdFi.Session,
        Api.Common.Models.Requests.Sessions.EdFi.SessionPut,
        Api.Common.Models.Requests.Sessions.EdFi.SessionPost,
        Api.Common.Models.Requests.Sessions.EdFi.SessionDelete,
        Api.Common.Models.Requests.Sessions.EdFi.SessionGetByExample>
    {
        public SessionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Sessions.EdFi.SessionGetByExample request, Entities.Common.EdFi.ISession specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionName = request.SessionName;
            specification.TermDescriptor = request.TermDescriptor;
            specification.TotalInstructionalDays = request.TotalInstructionalDays;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SexDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sexDescriptors")]
    public partial class SexDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SexDescriptor.EdFi.SexDescriptor,
        Entities.Common.EdFi.ISexDescriptor,
        Entities.NHibernate.SexDescriptorAggregate.EdFi.SexDescriptor,
        Api.Common.Models.Requests.SexDescriptors.EdFi.SexDescriptorPut,
        Api.Common.Models.Requests.SexDescriptors.EdFi.SexDescriptorPost,
        Api.Common.Models.Requests.SexDescriptors.EdFi.SexDescriptorDelete,
        Api.Common.Models.Requests.SexDescriptors.EdFi.SexDescriptorGetByExample>
    {
        public SexDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SexDescriptors.EdFi.SexDescriptorGetByExample request, Entities.Common.EdFi.ISexDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SexDescriptorId = request.SexDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SourceDimensions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sourceDimensions")]
    public partial class SourceDimensionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SourceDimension.EdFi.SourceDimension,
        Entities.Common.EdFi.ISourceDimension,
        Entities.NHibernate.SourceDimensionAggregate.EdFi.SourceDimension,
        Api.Common.Models.Requests.SourceDimensions.EdFi.SourceDimensionPut,
        Api.Common.Models.Requests.SourceDimensions.EdFi.SourceDimensionPost,
        Api.Common.Models.Requests.SourceDimensions.EdFi.SourceDimensionDelete,
        Api.Common.Models.Requests.SourceDimensions.EdFi.SourceDimensionGetByExample>
    {
        public SourceDimensionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SourceDimensions.EdFi.SourceDimensionGetByExample request, Entities.Common.EdFi.ISourceDimension specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Code = request.Code;
            specification.CodeName = request.CodeName;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SourceSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/sourceSystemDescriptors")]
    public partial class SourceSystemDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SourceSystemDescriptor.EdFi.SourceSystemDescriptor,
        Entities.Common.EdFi.ISourceSystemDescriptor,
        Entities.NHibernate.SourceSystemDescriptorAggregate.EdFi.SourceSystemDescriptor,
        Api.Common.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorPut,
        Api.Common.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorPost,
        Api.Common.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorDelete,
        Api.Common.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorGetByExample>
    {
        public SourceSystemDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorGetByExample request, Entities.Common.EdFi.ISourceSystemDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SourceSystemDescriptorId = request.SourceSystemDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SpecialEducationProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/specialEducationProgramServiceDescriptors")]
    public partial class SpecialEducationProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SpecialEducationProgramServiceDescriptor.EdFi.SpecialEducationProgramServiceDescriptor,
        Entities.Common.EdFi.ISpecialEducationProgramServiceDescriptor,
        Entities.NHibernate.SpecialEducationProgramServiceDescriptorAggregate.EdFi.SpecialEducationProgramServiceDescriptor,
        Api.Common.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorPut,
        Api.Common.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorPost,
        Api.Common.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorGetByExample>
    {
        public SpecialEducationProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.ISpecialEducationProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SpecialEducationProgramServiceDescriptorId = request.SpecialEducationProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SpecialEducationSettingDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/specialEducationSettingDescriptors")]
    public partial class SpecialEducationSettingDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SpecialEducationSettingDescriptor.EdFi.SpecialEducationSettingDescriptor,
        Entities.Common.EdFi.ISpecialEducationSettingDescriptor,
        Entities.NHibernate.SpecialEducationSettingDescriptorAggregate.EdFi.SpecialEducationSettingDescriptor,
        Api.Common.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorPut,
        Api.Common.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorPost,
        Api.Common.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorDelete,
        Api.Common.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorGetByExample>
    {
        public SpecialEducationSettingDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorGetByExample request, Entities.Common.EdFi.ISpecialEducationSettingDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SpecialEducationSettingDescriptorId = request.SpecialEducationSettingDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffs")]
    public partial class StaffsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Staff.EdFi.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Common.Models.Requests.Staffs.EdFi.StaffPut,
        Api.Common.Models.Requests.Staffs.EdFi.StaffPost,
        Api.Common.Models.Requests.Staffs.EdFi.StaffDelete,
        Api.Common.Models.Requests.Staffs.EdFi.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Staffs.EdFi.StaffGetByExample request, Entities.Common.EdFi.IStaff specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffAbsenceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffAbsenceEvents")]
    public partial class StaffAbsenceEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffAbsenceEvent.EdFi.StaffAbsenceEvent,
        Entities.Common.EdFi.IStaffAbsenceEvent,
        Entities.NHibernate.StaffAbsenceEventAggregate.EdFi.StaffAbsenceEvent,
        Api.Common.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventPut,
        Api.Common.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventPost,
        Api.Common.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventDelete,
        Api.Common.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventGetByExample>
    {
        public StaffAbsenceEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventGetByExample request, Entities.Common.EdFi.IStaffAbsenceEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AbsenceEventCategoryDescriptor = request.AbsenceEventCategoryDescriptor;
            specification.AbsenceEventReason = request.AbsenceEventReason;
            specification.EventDate = request.EventDate;
            specification.HoursAbsent = request.HoursAbsent;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffClassificationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffClassificationDescriptors")]
    public partial class StaffClassificationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffClassificationDescriptor.EdFi.StaffClassificationDescriptor,
        Entities.Common.EdFi.IStaffClassificationDescriptor,
        Entities.NHibernate.StaffClassificationDescriptorAggregate.EdFi.StaffClassificationDescriptor,
        Api.Common.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorPut,
        Api.Common.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorPost,
        Api.Common.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorDelete,
        Api.Common.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorGetByExample>
    {
        public StaffClassificationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorGetByExample request, Entities.Common.EdFi.IStaffClassificationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffClassificationDescriptorId = request.StaffClassificationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffCohortAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffCohortAssociations")]
    public partial class StaffCohortAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffCohortAssociation.EdFi.StaffCohortAssociation,
        Entities.Common.EdFi.IStaffCohortAssociation,
        Entities.NHibernate.StaffCohortAssociationAggregate.EdFi.StaffCohortAssociation,
        Api.Common.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationPut,
        Api.Common.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationPost,
        Api.Common.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationDelete,
        Api.Common.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationGetByExample>
    {
        public StaffCohortAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationGetByExample request, Entities.Common.EdFi.IStaffCohortAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CohortIdentifier = request.CohortIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StudentRecordAccess = request.StudentRecordAccess;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffDisciplineIncidentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffDisciplineIncidentAssociations")]
    public partial class StaffDisciplineIncidentAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffDisciplineIncidentAssociation.EdFi.StaffDisciplineIncidentAssociation,
        Entities.Common.EdFi.IStaffDisciplineIncidentAssociation,
        Entities.NHibernate.StaffDisciplineIncidentAssociationAggregate.EdFi.StaffDisciplineIncidentAssociation,
        Api.Common.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationPut,
        Api.Common.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationPost,
        Api.Common.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationDelete,
        Api.Common.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationGetByExample>
    {
        public StaffDisciplineIncidentAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationGetByExample request, Entities.Common.EdFi.IStaffDisciplineIncidentAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffEducationOrganizationAssignmentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffEducationOrganizationAssignmentAssociations")]
    public partial class StaffEducationOrganizationAssignmentAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation,
        Entities.Common.EdFi.IStaffEducationOrganizationAssignmentAssociation,
        Entities.NHibernate.StaffEducationOrganizationAssignmentAssociationAggregate.EdFi.StaffEducationOrganizationAssignmentAssociation,
        Api.Common.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationPut,
        Api.Common.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationPost,
        Api.Common.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationDelete,
        Api.Common.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationGetByExample>
    {
        public StaffEducationOrganizationAssignmentAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationGetByExample request, Entities.Common.EdFi.IStaffEducationOrganizationAssignmentAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CredentialIdentifier = request.CredentialIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmploymentEducationOrganizationId = request.EmploymentEducationOrganizationId;
            specification.EmploymentHireDate = request.EmploymentHireDate;
            specification.EmploymentStatusDescriptor = request.EmploymentStatusDescriptor;
            specification.EndDate = request.EndDate;
            specification.FullTimeEquivalency = request.FullTimeEquivalency;
            specification.Id = request.Id;
            specification.OrderOfAssignment = request.OrderOfAssignment;
            specification.PositionTitle = request.PositionTitle;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StateOfIssueStateAbbreviationDescriptor = request.StateOfIssueStateAbbreviationDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffEducationOrganizationContactAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffEducationOrganizationContactAssociations")]
    public partial class StaffEducationOrganizationContactAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffEducationOrganizationContactAssociation.EdFi.StaffEducationOrganizationContactAssociation,
        Entities.Common.EdFi.IStaffEducationOrganizationContactAssociation,
        Entities.NHibernate.StaffEducationOrganizationContactAssociationAggregate.EdFi.StaffEducationOrganizationContactAssociation,
        Api.Common.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationPut,
        Api.Common.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationPost,
        Api.Common.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationDelete,
        Api.Common.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationGetByExample>
    {
        public StaffEducationOrganizationContactAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationGetByExample request, Entities.Common.EdFi.IStaffEducationOrganizationContactAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContactTitle = request.ContactTitle;
            specification.ContactTypeDescriptor = request.ContactTypeDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ElectronicMailAddress = request.ElectronicMailAddress;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffEducationOrganizationEmploymentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffEducationOrganizationEmploymentAssociations")]
    public partial class StaffEducationOrganizationEmploymentAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation,
        Entities.Common.EdFi.IStaffEducationOrganizationEmploymentAssociation,
        Entities.NHibernate.StaffEducationOrganizationEmploymentAssociationAggregate.EdFi.StaffEducationOrganizationEmploymentAssociation,
        Api.Common.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationPut,
        Api.Common.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationPost,
        Api.Common.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationDelete,
        Api.Common.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationGetByExample>
    {
        public StaffEducationOrganizationEmploymentAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationGetByExample request, Entities.Common.EdFi.IStaffEducationOrganizationEmploymentAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialIdentifier = request.CredentialIdentifier;
            specification.Department = request.Department;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmploymentStatusDescriptor = request.EmploymentStatusDescriptor;
            specification.EndDate = request.EndDate;
            specification.FullTimeEquivalency = request.FullTimeEquivalency;
            specification.HireDate = request.HireDate;
            specification.HourlyWage = request.HourlyWage;
            specification.Id = request.Id;
            specification.OfferDate = request.OfferDate;
            specification.SeparationDescriptor = request.SeparationDescriptor;
            specification.SeparationReasonDescriptor = request.SeparationReasonDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StateOfIssueStateAbbreviationDescriptor = request.StateOfIssueStateAbbreviationDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffIdentificationSystemDescriptors")]
    public partial class StaffIdentificationSystemDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffIdentificationSystemDescriptor.EdFi.StaffIdentificationSystemDescriptor,
        Entities.Common.EdFi.IStaffIdentificationSystemDescriptor,
        Entities.NHibernate.StaffIdentificationSystemDescriptorAggregate.EdFi.StaffIdentificationSystemDescriptor,
        Api.Common.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorPut,
        Api.Common.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorPost,
        Api.Common.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorDelete,
        Api.Common.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorGetByExample>
    {
        public StaffIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorGetByExample request, Entities.Common.EdFi.IStaffIdentificationSystemDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffIdentificationSystemDescriptorId = request.StaffIdentificationSystemDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffLeaves.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffLeaves")]
    public partial class StaffLeavesController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffLeave.EdFi.StaffLeave,
        Entities.Common.EdFi.IStaffLeave,
        Entities.NHibernate.StaffLeaveAggregate.EdFi.StaffLeave,
        Api.Common.Models.Requests.StaffLeaves.EdFi.StaffLeavePut,
        Api.Common.Models.Requests.StaffLeaves.EdFi.StaffLeavePost,
        Api.Common.Models.Requests.StaffLeaves.EdFi.StaffLeaveDelete,
        Api.Common.Models.Requests.StaffLeaves.EdFi.StaffLeaveGetByExample>
    {
        public StaffLeavesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffLeaves.EdFi.StaffLeaveGetByExample request, Entities.Common.EdFi.IStaffLeave specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.Reason = request.Reason;
            specification.StaffLeaveEventCategoryDescriptor = request.StaffLeaveEventCategoryDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.SubstituteAssigned = request.SubstituteAssigned;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffLeaveEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffLeaveEventCategoryDescriptors")]
    public partial class StaffLeaveEventCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffLeaveEventCategoryDescriptor.EdFi.StaffLeaveEventCategoryDescriptor,
        Entities.Common.EdFi.IStaffLeaveEventCategoryDescriptor,
        Entities.NHibernate.StaffLeaveEventCategoryDescriptorAggregate.EdFi.StaffLeaveEventCategoryDescriptor,
        Api.Common.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorPut,
        Api.Common.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorPost,
        Api.Common.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorDelete,
        Api.Common.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorGetByExample>
    {
        public StaffLeaveEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorGetByExample request, Entities.Common.EdFi.IStaffLeaveEventCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffLeaveEventCategoryDescriptorId = request.StaffLeaveEventCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffProgramAssociations")]
    public partial class StaffProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffProgramAssociation.EdFi.StaffProgramAssociation,
        Entities.Common.EdFi.IStaffProgramAssociation,
        Entities.NHibernate.StaffProgramAssociationAggregate.EdFi.StaffProgramAssociation,
        Api.Common.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationPut,
        Api.Common.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationPost,
        Api.Common.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationDelete,
        Api.Common.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationGetByExample>
    {
        public StaffProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationGetByExample request, Entities.Common.EdFi.IStaffProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StudentRecordAccess = request.StudentRecordAccess;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffSchoolAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffSchoolAssociations")]
    public partial class StaffSchoolAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffSchoolAssociation.EdFi.StaffSchoolAssociation,
        Entities.Common.EdFi.IStaffSchoolAssociation,
        Entities.NHibernate.StaffSchoolAssociationAggregate.EdFi.StaffSchoolAssociation,
        Api.Common.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationPut,
        Api.Common.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationPost,
        Api.Common.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationDelete,
        Api.Common.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationGetByExample>
    {
        public StaffSchoolAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationGetByExample request, Entities.Common.EdFi.IStaffSchoolAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.Id = request.Id;
            specification.ProgramAssignmentDescriptor = request.ProgramAssignmentDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.StaffUniqueId = request.StaffUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffSectionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/staffSectionAssociations")]
    public partial class StaffSectionAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StaffSectionAssociation.EdFi.StaffSectionAssociation,
        Entities.Common.EdFi.IStaffSectionAssociation,
        Entities.NHibernate.StaffSectionAssociationAggregate.EdFi.StaffSectionAssociation,
        Api.Common.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationPut,
        Api.Common.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationPost,
        Api.Common.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationDelete,
        Api.Common.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationGetByExample>
    {
        public StaffSectionAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationGetByExample request, Entities.Common.EdFi.IStaffSectionAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.ClassroomPositionDescriptor = request.ClassroomPositionDescriptor;
            specification.EndDate = request.EndDate;
            specification.HighlyQualifiedTeacher = request.HighlyQualifiedTeacher;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.PercentageContribution = request.PercentageContribution;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.TeacherStudentDataLinkExclusion = request.TeacherStudentDataLinkExclusion;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StateAbbreviationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/stateAbbreviationDescriptors")]
    public partial class StateAbbreviationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StateAbbreviationDescriptor.EdFi.StateAbbreviationDescriptor,
        Entities.Common.EdFi.IStateAbbreviationDescriptor,
        Entities.NHibernate.StateAbbreviationDescriptorAggregate.EdFi.StateAbbreviationDescriptor,
        Api.Common.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorPut,
        Api.Common.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorPost,
        Api.Common.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorDelete,
        Api.Common.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorGetByExample>
    {
        public StateAbbreviationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorGetByExample request, Entities.Common.EdFi.IStateAbbreviationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StateAbbreviationDescriptorId = request.StateAbbreviationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StateEducationAgencies.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/stateEducationAgencies")]
    public partial class StateEducationAgenciesController : DataManagementControllerBase<
        Api.Common.Models.Resources.StateEducationAgency.EdFi.StateEducationAgency,
        Entities.Common.EdFi.IStateEducationAgency,
        Entities.NHibernate.StateEducationAgencyAggregate.EdFi.StateEducationAgency,
        Api.Common.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyPut,
        Api.Common.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyPost,
        Api.Common.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyDelete,
        Api.Common.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyGetByExample>
    {
        public StateEducationAgenciesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyGetByExample request, Entities.Common.EdFi.IStateEducationAgency specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/students")]
    public partial class StudentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.Student.EdFi.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Common.Models.Requests.Students.EdFi.StudentPut,
        Api.Common.Models.Requests.Students.EdFi.StudentPost,
        Api.Common.Models.Requests.Students.EdFi.StudentDelete,
        Api.Common.Models.Requests.Students.EdFi.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Students.EdFi.StudentGetByExample request, Entities.Common.EdFi.IStudent specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAcademicRecords.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentAcademicRecords")]
    public partial class StudentAcademicRecordsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentAcademicRecord.EdFi.StudentAcademicRecord,
        Entities.Common.EdFi.IStudentAcademicRecord,
        Entities.NHibernate.StudentAcademicRecordAggregate.EdFi.StudentAcademicRecord,
        Api.Common.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordPut,
        Api.Common.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordPost,
        Api.Common.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordDelete,
        Api.Common.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordGetByExample>
    {
        public StudentAcademicRecordsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordGetByExample request, Entities.Common.EdFi.IStudentAcademicRecord specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CumulativeAttemptedCreditConversion = request.CumulativeAttemptedCreditConversion;
            specification.CumulativeAttemptedCredits = request.CumulativeAttemptedCredits;
            specification.CumulativeAttemptedCreditTypeDescriptor = request.CumulativeAttemptedCreditTypeDescriptor;
            specification.CumulativeEarnedCreditConversion = request.CumulativeEarnedCreditConversion;
            specification.CumulativeEarnedCredits = request.CumulativeEarnedCredits;
            specification.CumulativeEarnedCreditTypeDescriptor = request.CumulativeEarnedCreditTypeDescriptor;
            specification.CumulativeGradePointAverage = request.CumulativeGradePointAverage;
            specification.CumulativeGradePointsEarned = request.CumulativeGradePointsEarned;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.GradeValueQualifier = request.GradeValueQualifier;
            specification.Id = request.Id;
            specification.ProjectedGraduationDate = request.ProjectedGraduationDate;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionAttemptedCreditConversion = request.SessionAttemptedCreditConversion;
            specification.SessionAttemptedCredits = request.SessionAttemptedCredits;
            specification.SessionAttemptedCreditTypeDescriptor = request.SessionAttemptedCreditTypeDescriptor;
            specification.SessionEarnedCreditConversion = request.SessionEarnedCreditConversion;
            specification.SessionEarnedCredits = request.SessionEarnedCredits;
            specification.SessionEarnedCreditTypeDescriptor = request.SessionEarnedCreditTypeDescriptor;
            specification.SessionGradePointAverage = request.SessionGradePointAverage;
            specification.SessionGradePointsEarned = request.SessionGradePointsEarned;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TermDescriptor = request.TermDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAssessments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentAssessments")]
    public partial class StudentAssessmentsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentAssessment.EdFi.StudentAssessment,
        Entities.Common.EdFi.IStudentAssessment,
        Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment,
        Api.Common.Models.Requests.StudentAssessments.EdFi.StudentAssessmentPut,
        Api.Common.Models.Requests.StudentAssessments.EdFi.StudentAssessmentPost,
        Api.Common.Models.Requests.StudentAssessments.EdFi.StudentAssessmentDelete,
        Api.Common.Models.Requests.StudentAssessments.EdFi.StudentAssessmentGetByExample>
    {
        public StudentAssessmentsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentAssessments.EdFi.StudentAssessmentGetByExample request, Entities.Common.EdFi.IStudentAssessment specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationDate = request.AdministrationDate;
            specification.AdministrationEndDate = request.AdministrationEndDate;
            specification.AdministrationEnvironmentDescriptor = request.AdministrationEnvironmentDescriptor;
            specification.AdministrationLanguageDescriptor = request.AdministrationLanguageDescriptor;
            specification.AssessedMinutes = request.AssessedMinutes;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.EventCircumstanceDescriptor = request.EventCircumstanceDescriptor;
            specification.EventDescription = request.EventDescription;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PlatformTypeDescriptor = request.PlatformTypeDescriptor;
            specification.ReasonNotTestedDescriptor = request.ReasonNotTestedDescriptor;
            specification.ReportedSchoolId = request.ReportedSchoolId;
            specification.ReportedSchoolIdentifier = request.ReportedSchoolIdentifier;
            specification.RetestIndicatorDescriptor = request.RetestIndicatorDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.SerialNumber = request.SerialNumber;
            specification.StudentAssessmentIdentifier = request.StudentAssessmentIdentifier;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.WhenAssessedGradeLevelDescriptor = request.WhenAssessedGradeLevelDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAssessmentEducationOrganizationAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentAssessmentEducationOrganizationAssociations")]
    public partial class StudentAssessmentEducationOrganizationAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentAssessmentEducationOrganizationAssociation.EdFi.StudentAssessmentEducationOrganizationAssociation,
        Entities.Common.EdFi.IStudentAssessmentEducationOrganizationAssociation,
        Entities.NHibernate.StudentAssessmentEducationOrganizationAssociationAggregate.EdFi.StudentAssessmentEducationOrganizationAssociation,
        Api.Common.Models.Requests.StudentAssessmentEducationOrganizationAssociations.EdFi.StudentAssessmentEducationOrganizationAssociationPut,
        Api.Common.Models.Requests.StudentAssessmentEducationOrganizationAssociations.EdFi.StudentAssessmentEducationOrganizationAssociationPost,
        Api.Common.Models.Requests.StudentAssessmentEducationOrganizationAssociations.EdFi.StudentAssessmentEducationOrganizationAssociationDelete,
        Api.Common.Models.Requests.StudentAssessmentEducationOrganizationAssociations.EdFi.StudentAssessmentEducationOrganizationAssociationGetByExample>
    {
        public StudentAssessmentEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentAssessmentEducationOrganizationAssociations.EdFi.StudentAssessmentEducationOrganizationAssociationGetByExample request, Entities.Common.EdFi.IStudentAssessmentEducationOrganizationAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.EducationOrganizationAssociationTypeDescriptor = request.EducationOrganizationAssociationTypeDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentAssessmentIdentifier = request.StudentAssessmentIdentifier;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentCharacteristicDescriptors")]
    public partial class StudentCharacteristicDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentCharacteristicDescriptor.EdFi.StudentCharacteristicDescriptor,
        Entities.Common.EdFi.IStudentCharacteristicDescriptor,
        Entities.NHibernate.StudentCharacteristicDescriptorAggregate.EdFi.StudentCharacteristicDescriptor,
        Api.Common.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorPut,
        Api.Common.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorPost,
        Api.Common.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorDelete,
        Api.Common.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorGetByExample>
    {
        public StudentCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorGetByExample request, Entities.Common.EdFi.IStudentCharacteristicDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentCharacteristicDescriptorId = request.StudentCharacteristicDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCohortAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentCohortAssociations")]
    public partial class StudentCohortAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentCohortAssociation.EdFi.StudentCohortAssociation,
        Entities.Common.EdFi.IStudentCohortAssociation,
        Entities.NHibernate.StudentCohortAssociationAggregate.EdFi.StudentCohortAssociation,
        Api.Common.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationPut,
        Api.Common.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationPost,
        Api.Common.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationDelete,
        Api.Common.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationGetByExample>
    {
        public StudentCohortAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationGetByExample request, Entities.Common.EdFi.IStudentCohortAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CohortIdentifier = request.CohortIdentifier;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCompetencyObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentCompetencyObjectives")]
    public partial class StudentCompetencyObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentCompetencyObjective.EdFi.StudentCompetencyObjective,
        Entities.Common.EdFi.IStudentCompetencyObjective,
        Entities.NHibernate.StudentCompetencyObjectiveAggregate.EdFi.StudentCompetencyObjective,
        Api.Common.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectivePut,
        Api.Common.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectivePost,
        Api.Common.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectiveDelete,
        Api.Common.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectiveGetByExample>
    {
        public StudentCompetencyObjectivesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectiveGetByExample request, Entities.Common.EdFi.IStudentCompetencyObjective specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CompetencyLevelDescriptor = request.CompetencyLevelDescriptor;
            specification.DiagnosticStatement = request.DiagnosticStatement;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.GradingPeriodSchoolId = request.GradingPeriodSchoolId;
            specification.GradingPeriodSchoolYear = request.GradingPeriodSchoolYear;
            specification.GradingPeriodSequence = request.GradingPeriodSequence;
            specification.Id = request.Id;
            specification.Objective = request.Objective;
            specification.ObjectiveEducationOrganizationId = request.ObjectiveEducationOrganizationId;
            specification.ObjectiveGradeLevelDescriptor = request.ObjectiveGradeLevelDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCTEProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentCTEProgramAssociations")]
    public partial class StudentCTEProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentCTEProgramAssociation.EdFi.StudentCTEProgramAssociation,
        Entities.Common.EdFi.IStudentCTEProgramAssociation,
        Entities.NHibernate.StudentCTEProgramAssociationAggregate.EdFi.StudentCTEProgramAssociation,
        Api.Common.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationPut,
        Api.Common.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationPost,
        Api.Common.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationDelete,
        Api.Common.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationGetByExample>
    {
        public StudentCTEProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentCTEProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.NonTraditionalGenderStatus = request.NonTraditionalGenderStatus;
            specification.PrivateCTEProgram = request.PrivateCTEProgram;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TechnicalSkillsAssessmentDescriptor = request.TechnicalSkillsAssessmentDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentDisciplineIncidentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentDisciplineIncidentAssociations")]
    public partial class StudentDisciplineIncidentAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentDisciplineIncidentAssociation.EdFi.StudentDisciplineIncidentAssociation,
        Entities.Common.EdFi.IStudentDisciplineIncidentAssociation,
        Entities.NHibernate.StudentDisciplineIncidentAssociationAggregate.EdFi.StudentDisciplineIncidentAssociation,
        Api.Common.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationPut,
        Api.Common.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationPost,
        Api.Common.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationDelete,
        Api.Common.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationGetByExample>
    {
        public StudentDisciplineIncidentAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationGetByExample request, Entities.Common.EdFi.IStudentDisciplineIncidentAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StudentParticipationCodeDescriptor = request.StudentParticipationCodeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentDisciplineIncidentBehaviorAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentDisciplineIncidentBehaviorAssociations")]
    public partial class StudentDisciplineIncidentBehaviorAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentDisciplineIncidentBehaviorAssociation.EdFi.StudentDisciplineIncidentBehaviorAssociation,
        Entities.Common.EdFi.IStudentDisciplineIncidentBehaviorAssociation,
        Entities.NHibernate.StudentDisciplineIncidentBehaviorAssociationAggregate.EdFi.StudentDisciplineIncidentBehaviorAssociation,
        Api.Common.Models.Requests.StudentDisciplineIncidentBehaviorAssociations.EdFi.StudentDisciplineIncidentBehaviorAssociationPut,
        Api.Common.Models.Requests.StudentDisciplineIncidentBehaviorAssociations.EdFi.StudentDisciplineIncidentBehaviorAssociationPost,
        Api.Common.Models.Requests.StudentDisciplineIncidentBehaviorAssociations.EdFi.StudentDisciplineIncidentBehaviorAssociationDelete,
        Api.Common.Models.Requests.StudentDisciplineIncidentBehaviorAssociations.EdFi.StudentDisciplineIncidentBehaviorAssociationGetByExample>
    {
        public StudentDisciplineIncidentBehaviorAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentDisciplineIncidentBehaviorAssociations.EdFi.StudentDisciplineIncidentBehaviorAssociationGetByExample request, Entities.Common.EdFi.IStudentDisciplineIncidentBehaviorAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BehaviorDescriptor = request.BehaviorDescriptor;
            specification.BehaviorDetailedDescription = request.BehaviorDetailedDescription;
            specification.Id = request.Id;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentDisciplineIncidentNonOffenderAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentDisciplineIncidentNonOffenderAssociations")]
    public partial class StudentDisciplineIncidentNonOffenderAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentDisciplineIncidentNonOffenderAssociation.EdFi.StudentDisciplineIncidentNonOffenderAssociation,
        Entities.Common.EdFi.IStudentDisciplineIncidentNonOffenderAssociation,
        Entities.NHibernate.StudentDisciplineIncidentNonOffenderAssociationAggregate.EdFi.StudentDisciplineIncidentNonOffenderAssociation,
        Api.Common.Models.Requests.StudentDisciplineIncidentNonOffenderAssociations.EdFi.StudentDisciplineIncidentNonOffenderAssociationPut,
        Api.Common.Models.Requests.StudentDisciplineIncidentNonOffenderAssociations.EdFi.StudentDisciplineIncidentNonOffenderAssociationPost,
        Api.Common.Models.Requests.StudentDisciplineIncidentNonOffenderAssociations.EdFi.StudentDisciplineIncidentNonOffenderAssociationDelete,
        Api.Common.Models.Requests.StudentDisciplineIncidentNonOffenderAssociations.EdFi.StudentDisciplineIncidentNonOffenderAssociationGetByExample>
    {
        public StudentDisciplineIncidentNonOffenderAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentDisciplineIncidentNonOffenderAssociations.EdFi.StudentDisciplineIncidentNonOffenderAssociationGetByExample request, Entities.Common.EdFi.IStudentDisciplineIncidentNonOffenderAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentEducationOrganizationAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentEducationOrganizationAssociations")]
    public partial class StudentEducationOrganizationAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentEducationOrganizationAssociation.EdFi.StudentEducationOrganizationAssociation,
        Entities.Common.EdFi.IStudentEducationOrganizationAssociation,
        Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi.StudentEducationOrganizationAssociation,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationPut,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationPost,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationDelete,
        Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationGetByExample>
    {
        public StudentEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationGetByExample request, Entities.Common.EdFi.IStudentEducationOrganizationAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BarrierToInternetAccessInResidenceDescriptor = request.BarrierToInternetAccessInResidenceDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.InternetAccessInResidence = request.InternetAccessInResidence;
            specification.InternetAccessTypeInResidenceDescriptor = request.InternetAccessTypeInResidenceDescriptor;
            specification.InternetPerformanceInResidenceDescriptor = request.InternetPerformanceInResidenceDescriptor;
            specification.LimitedEnglishProficiencyDescriptor = request.LimitedEnglishProficiencyDescriptor;
            specification.LoginId = request.LoginId;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.PrimaryLearningDeviceAccessDescriptor = request.PrimaryLearningDeviceAccessDescriptor;
            specification.PrimaryLearningDeviceAwayFromSchoolDescriptor = request.PrimaryLearningDeviceAwayFromSchoolDescriptor;
            specification.PrimaryLearningDeviceProviderDescriptor = request.PrimaryLearningDeviceProviderDescriptor;
            specification.ProfileThumbnail = request.ProfileThumbnail;
            specification.SexDescriptor = request.SexDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentEducationOrganizationResponsibilityAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentEducationOrganizationResponsibilityAssociations")]
    public partial class StudentEducationOrganizationResponsibilityAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentEducationOrganizationResponsibilityAssociation.EdFi.StudentEducationOrganizationResponsibilityAssociation,
        Entities.Common.EdFi.IStudentEducationOrganizationResponsibilityAssociation,
        Entities.NHibernate.StudentEducationOrganizationResponsibilityAssociationAggregate.EdFi.StudentEducationOrganizationResponsibilityAssociation,
        Api.Common.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationPut,
        Api.Common.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationPost,
        Api.Common.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationDelete,
        Api.Common.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationGetByExample>
    {
        public StudentEducationOrganizationResponsibilityAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationGetByExample request, Entities.Common.EdFi.IStudentEducationOrganizationResponsibilityAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.ResponsibilityDescriptor = request.ResponsibilityDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentGradebookEntries.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentGradebookEntries")]
    public partial class StudentGradebookEntriesController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentGradebookEntry.EdFi.StudentGradebookEntry,
        Entities.Common.EdFi.IStudentGradebookEntry,
        Entities.NHibernate.StudentGradebookEntryAggregate.EdFi.StudentGradebookEntry,
        Api.Common.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryPut,
        Api.Common.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryPost,
        Api.Common.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryDelete,
        Api.Common.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryGetByExample>
    {
        public StudentGradebookEntriesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryGetByExample request, Entities.Common.EdFi.IStudentGradebookEntry specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssignmentLateStatusDescriptor = request.AssignmentLateStatusDescriptor;
            specification.CompetencyLevelDescriptor = request.CompetencyLevelDescriptor;
            specification.DateFulfilled = request.DateFulfilled;
            specification.DiagnosticStatement = request.DiagnosticStatement;
            specification.GradebookEntryIdentifier = request.GradebookEntryIdentifier;
            specification.Id = request.Id;
            specification.LetterGradeEarned = request.LetterGradeEarned;
            specification.Namespace = request.Namespace;
            specification.NumericGradeEarned = request.NumericGradeEarned;
            specification.PointsEarned = request.PointsEarned;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.SubmissionStatusDescriptor = request.SubmissionStatusDescriptor;
            specification.TimeFulfilled = request.TimeFulfilled;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentHomelessProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentHomelessProgramAssociations")]
    public partial class StudentHomelessProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentHomelessProgramAssociation.EdFi.StudentHomelessProgramAssociation,
        Entities.Common.EdFi.IStudentHomelessProgramAssociation,
        Entities.NHibernate.StudentHomelessProgramAssociationAggregate.EdFi.StudentHomelessProgramAssociation,
        Api.Common.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationPut,
        Api.Common.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationPost,
        Api.Common.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationDelete,
        Api.Common.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationGetByExample>
    {
        public StudentHomelessProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentHomelessProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AwaitingFosterCare = request.AwaitingFosterCare;
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.HomelessPrimaryNighttimeResidenceDescriptor = request.HomelessPrimaryNighttimeResidenceDescriptor;
            specification.HomelessUnaccompaniedYouth = request.HomelessUnaccompaniedYouth;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentIdentificationSystemDescriptors")]
    public partial class StudentIdentificationSystemDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentIdentificationSystemDescriptor.EdFi.StudentIdentificationSystemDescriptor,
        Entities.Common.EdFi.IStudentIdentificationSystemDescriptor,
        Entities.NHibernate.StudentIdentificationSystemDescriptorAggregate.EdFi.StudentIdentificationSystemDescriptor,
        Api.Common.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorPut,
        Api.Common.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorPost,
        Api.Common.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorDelete,
        Api.Common.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorGetByExample>
    {
        public StudentIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorGetByExample request, Entities.Common.EdFi.IStudentIdentificationSystemDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentIdentificationSystemDescriptorId = request.StudentIdentificationSystemDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentInterventionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentInterventionAssociations")]
    public partial class StudentInterventionAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentInterventionAssociation.EdFi.StudentInterventionAssociation,
        Entities.Common.EdFi.IStudentInterventionAssociation,
        Entities.NHibernate.StudentInterventionAssociationAggregate.EdFi.StudentInterventionAssociation,
        Api.Common.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationPut,
        Api.Common.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationPost,
        Api.Common.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationDelete,
        Api.Common.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationGetByExample>
    {
        public StudentInterventionAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationGetByExample request, Entities.Common.EdFi.IStudentInterventionAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortEducationOrganizationId = request.CohortEducationOrganizationId;
            specification.CohortIdentifier = request.CohortIdentifier;
            specification.DiagnosticStatement = request.DiagnosticStatement;
            specification.Dosage = request.Dosage;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.InterventionIdentificationCode = request.InterventionIdentificationCode;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentInterventionAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentInterventionAttendanceEvents")]
    public partial class StudentInterventionAttendanceEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentInterventionAttendanceEvent.EdFi.StudentInterventionAttendanceEvent,
        Entities.Common.EdFi.IStudentInterventionAttendanceEvent,
        Entities.NHibernate.StudentInterventionAttendanceEventAggregate.EdFi.StudentInterventionAttendanceEvent,
        Api.Common.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventPut,
        Api.Common.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventPost,
        Api.Common.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventDelete,
        Api.Common.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventGetByExample>
    {
        public StudentInterventionAttendanceEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventGetByExample request, Entities.Common.EdFi.IStudentInterventionAttendanceEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.EducationalEnvironmentDescriptor = request.EducationalEnvironmentDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EventDate = request.EventDate;
            specification.EventDuration = request.EventDuration;
            specification.Id = request.Id;
            specification.InterventionDuration = request.InterventionDuration;
            specification.InterventionIdentificationCode = request.InterventionIdentificationCode;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentLanguageInstructionProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentLanguageInstructionProgramAssociations")]
    public partial class StudentLanguageInstructionProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentLanguageInstructionProgramAssociation.EdFi.StudentLanguageInstructionProgramAssociation,
        Entities.Common.EdFi.IStudentLanguageInstructionProgramAssociation,
        Entities.NHibernate.StudentLanguageInstructionProgramAssociationAggregate.EdFi.StudentLanguageInstructionProgramAssociation,
        Api.Common.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationPut,
        Api.Common.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationPost,
        Api.Common.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationDelete,
        Api.Common.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationGetByExample>
    {
        public StudentLanguageInstructionProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentLanguageInstructionProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.Dosage = request.Dosage;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EnglishLearnerParticipation = request.EnglishLearnerParticipation;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentLearningObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentLearningObjectives")]
    public partial class StudentLearningObjectivesController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentLearningObjective.EdFi.StudentLearningObjective,
        Entities.Common.EdFi.IStudentLearningObjective,
        Entities.NHibernate.StudentLearningObjectiveAggregate.EdFi.StudentLearningObjective,
        Api.Common.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectivePut,
        Api.Common.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectivePost,
        Api.Common.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectiveDelete,
        Api.Common.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectiveGetByExample>
    {
        public StudentLearningObjectivesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectiveGetByExample request, Entities.Common.EdFi.IStudentLearningObjective specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CompetencyLevelDescriptor = request.CompetencyLevelDescriptor;
            specification.DiagnosticStatement = request.DiagnosticStatement;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.GradingPeriodSchoolId = request.GradingPeriodSchoolId;
            specification.GradingPeriodSchoolYear = request.GradingPeriodSchoolYear;
            specification.GradingPeriodSequence = request.GradingPeriodSequence;
            specification.Id = request.Id;
            specification.LearningObjectiveId = request.LearningObjectiveId;
            specification.Namespace = request.Namespace;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentMigrantEducationProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentMigrantEducationProgramAssociations")]
    public partial class StudentMigrantEducationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentMigrantEducationProgramAssociation.EdFi.StudentMigrantEducationProgramAssociation,
        Entities.Common.EdFi.IStudentMigrantEducationProgramAssociation,
        Entities.NHibernate.StudentMigrantEducationProgramAssociationAggregate.EdFi.StudentMigrantEducationProgramAssociation,
        Api.Common.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationGetByExample>
    {
        public StudentMigrantEducationProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentMigrantEducationProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.ContinuationOfServicesReasonDescriptor = request.ContinuationOfServicesReasonDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EligibilityExpirationDate = request.EligibilityExpirationDate;
            specification.LastQualifyingMove = request.LastQualifyingMove;
            specification.PriorityForServices = request.PriorityForServices;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.QualifyingArrivalDate = request.QualifyingArrivalDate;
            specification.StateResidencyDate = request.StateResidencyDate;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.USInitialEntry = request.USInitialEntry;
            specification.USInitialSchoolEntry = request.USInitialSchoolEntry;
            specification.USMostRecentEntry = request.USMostRecentEntry;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentNeglectedOrDelinquentProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentNeglectedOrDelinquentProgramAssociations")]
    public partial class StudentNeglectedOrDelinquentProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentNeglectedOrDelinquentProgramAssociation.EdFi.StudentNeglectedOrDelinquentProgramAssociation,
        Entities.Common.EdFi.IStudentNeglectedOrDelinquentProgramAssociation,
        Entities.NHibernate.StudentNeglectedOrDelinquentProgramAssociationAggregate.EdFi.StudentNeglectedOrDelinquentProgramAssociation,
        Api.Common.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationPut,
        Api.Common.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationPost,
        Api.Common.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationDelete,
        Api.Common.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationGetByExample>
    {
        public StudentNeglectedOrDelinquentProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentNeglectedOrDelinquentProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ELAProgressLevelDescriptor = request.ELAProgressLevelDescriptor;
            specification.MathematicsProgressLevelDescriptor = request.MathematicsProgressLevelDescriptor;
            specification.NeglectedOrDelinquentProgramDescriptor = request.NeglectedOrDelinquentProgramDescriptor;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentParentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentParentAssociations")]
    public partial class StudentParentAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentParentAssociation.EdFi.StudentParentAssociation,
        Entities.Common.EdFi.IStudentParentAssociation,
        Entities.NHibernate.StudentParentAssociationAggregate.EdFi.StudentParentAssociation,
        Api.Common.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationPut,
        Api.Common.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationPost,
        Api.Common.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationDelete,
        Api.Common.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationGetByExample>
    {
        public StudentParentAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationGetByExample request, Entities.Common.EdFi.IStudentParentAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContactPriority = request.ContactPriority;
            specification.ContactRestrictions = request.ContactRestrictions;
            specification.EmergencyContactStatus = request.EmergencyContactStatus;
            specification.Id = request.Id;
            specification.LegalGuardian = request.LegalGuardian;
            specification.LivesWith = request.LivesWith;
            specification.ParentUniqueId = request.ParentUniqueId;
            specification.PrimaryContactStatus = request.PrimaryContactStatus;
            specification.RelationDescriptor = request.RelationDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentParticipationCodeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentParticipationCodeDescriptors")]
    public partial class StudentParticipationCodeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentParticipationCodeDescriptor.EdFi.StudentParticipationCodeDescriptor,
        Entities.Common.EdFi.IStudentParticipationCodeDescriptor,
        Entities.NHibernate.StudentParticipationCodeDescriptorAggregate.EdFi.StudentParticipationCodeDescriptor,
        Api.Common.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorPut,
        Api.Common.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorPost,
        Api.Common.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorDelete,
        Api.Common.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorGetByExample>
    {
        public StudentParticipationCodeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorGetByExample request, Entities.Common.EdFi.IStudentParticipationCodeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentParticipationCodeDescriptorId = request.StudentParticipationCodeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentProgramAssociations")]
    public partial class StudentProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentProgramAssociation.EdFi.StudentProgramAssociation,
        Entities.Common.EdFi.IStudentProgramAssociation,
        Entities.NHibernate.StudentProgramAssociationAggregate.EdFi.StudentProgramAssociation,
        Api.Common.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationPut,
        Api.Common.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationPost,
        Api.Common.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationDelete,
        Api.Common.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationGetByExample>
    {
        public StudentProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentProgramAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentProgramAttendanceEvents")]
    public partial class StudentProgramAttendanceEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentProgramAttendanceEvent.EdFi.StudentProgramAttendanceEvent,
        Entities.Common.EdFi.IStudentProgramAttendanceEvent,
        Entities.NHibernate.StudentProgramAttendanceEventAggregate.EdFi.StudentProgramAttendanceEvent,
        Api.Common.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventPut,
        Api.Common.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventPost,
        Api.Common.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventDelete,
        Api.Common.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventGetByExample>
    {
        public StudentProgramAttendanceEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventGetByExample request, Entities.Common.EdFi.IStudentProgramAttendanceEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.EducationalEnvironmentDescriptor = request.EducationalEnvironmentDescriptor;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EventDate = request.EventDate;
            specification.EventDuration = request.EventDuration;
            specification.Id = request.Id;
            specification.ProgramAttendanceDuration = request.ProgramAttendanceDuration;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentSchoolAssociations")]
    public partial class StudentSchoolAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation,
        Entities.Common.EdFi.IStudentSchoolAssociation,
        Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi.StudentSchoolAssociation,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationPut,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationPost,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationDelete,
        Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationGetByExample>
    {
        public StudentSchoolAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationGetByExample request, Entities.Common.EdFi.IStudentSchoolAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.ClassOfSchoolYear = request.ClassOfSchoolYear;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.EmployedWhileEnrolled = request.EmployedWhileEnrolled;
            specification.EntryDate = request.EntryDate;
            specification.EntryGradeLevelDescriptor = request.EntryGradeLevelDescriptor;
            specification.EntryGradeLevelReasonDescriptor = request.EntryGradeLevelReasonDescriptor;
            specification.EntryTypeDescriptor = request.EntryTypeDescriptor;
            specification.ExitWithdrawDate = request.ExitWithdrawDate;
            specification.ExitWithdrawTypeDescriptor = request.ExitWithdrawTypeDescriptor;
            specification.FullTimeEquivalency = request.FullTimeEquivalency;
            specification.GraduationPlanTypeDescriptor = request.GraduationPlanTypeDescriptor;
            specification.GraduationSchoolYear = request.GraduationSchoolYear;
            specification.Id = request.Id;
            specification.PrimarySchool = request.PrimarySchool;
            specification.RepeatGradeIndicator = request.RepeatGradeIndicator;
            specification.ResidencyStatusDescriptor = request.ResidencyStatusDescriptor;
            specification.SchoolChoiceTransfer = request.SchoolChoiceTransfer;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TermCompletionIndicator = request.TermCompletionIndicator;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentSchoolAttendanceEvents")]
    public partial class StudentSchoolAttendanceEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSchoolAttendanceEvent.EdFi.StudentSchoolAttendanceEvent,
        Entities.Common.EdFi.IStudentSchoolAttendanceEvent,
        Entities.NHibernate.StudentSchoolAttendanceEventAggregate.EdFi.StudentSchoolAttendanceEvent,
        Api.Common.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventPut,
        Api.Common.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventPost,
        Api.Common.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventDelete,
        Api.Common.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventGetByExample>
    {
        public StudentSchoolAttendanceEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventGetByExample request, Entities.Common.EdFi.IStudentSchoolAttendanceEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ArrivalTime = request.ArrivalTime;
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.DepartureTime = request.DepartureTime;
            specification.EducationalEnvironmentDescriptor = request.EducationalEnvironmentDescriptor;
            specification.EventDate = request.EventDate;
            specification.EventDuration = request.EventDuration;
            specification.Id = request.Id;
            specification.SchoolAttendanceDuration = request.SchoolAttendanceDuration;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionName = request.SessionName;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolFoodServiceProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentSchoolFoodServiceProgramAssociations")]
    public partial class StudentSchoolFoodServiceProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSchoolFoodServiceProgramAssociation.EdFi.StudentSchoolFoodServiceProgramAssociation,
        Entities.Common.EdFi.IStudentSchoolFoodServiceProgramAssociation,
        Entities.NHibernate.StudentSchoolFoodServiceProgramAssociationAggregate.EdFi.StudentSchoolFoodServiceProgramAssociation,
        Api.Common.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationPut,
        Api.Common.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationPost,
        Api.Common.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationGetByExample>
    {
        public StudentSchoolFoodServiceProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentSchoolFoodServiceProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.DirectCertification = request.DirectCertification;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSectionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentSectionAssociations")]
    public partial class StudentSectionAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSectionAssociation.EdFi.StudentSectionAssociation,
        Entities.Common.EdFi.IStudentSectionAssociation,
        Entities.NHibernate.StudentSectionAssociationAggregate.EdFi.StudentSectionAssociation,
        Api.Common.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationPut,
        Api.Common.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationPost,
        Api.Common.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationDelete,
        Api.Common.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationGetByExample>
    {
        public StudentSectionAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationGetByExample request, Entities.Common.EdFi.IStudentSectionAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttemptStatusDescriptor = request.AttemptStatusDescriptor;
            specification.BeginDate = request.BeginDate;
            specification.EndDate = request.EndDate;
            specification.HomeroomIndicator = request.HomeroomIndicator;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.RepeatIdentifierDescriptor = request.RepeatIdentifierDescriptor;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TeacherStudentDataLinkExclusion = request.TeacherStudentDataLinkExclusion;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSectionAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentSectionAttendanceEvents")]
    public partial class StudentSectionAttendanceEventsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSectionAttendanceEvent.EdFi.StudentSectionAttendanceEvent,
        Entities.Common.EdFi.IStudentSectionAttendanceEvent,
        Entities.NHibernate.StudentSectionAttendanceEventAggregate.EdFi.StudentSectionAttendanceEvent,
        Api.Common.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventPut,
        Api.Common.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventPost,
        Api.Common.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventDelete,
        Api.Common.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventGetByExample>
    {
        public StudentSectionAttendanceEventsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventGetByExample request, Entities.Common.EdFi.IStudentSectionAttendanceEvent specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ArrivalTime = request.ArrivalTime;
            specification.AttendanceEventCategoryDescriptor = request.AttendanceEventCategoryDescriptor;
            specification.AttendanceEventReason = request.AttendanceEventReason;
            specification.DepartureTime = request.DepartureTime;
            specification.EducationalEnvironmentDescriptor = request.EducationalEnvironmentDescriptor;
            specification.EventDate = request.EventDate;
            specification.EventDuration = request.EventDuration;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionAttendanceDuration = request.SectionAttendanceDuration;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentSpecialEducationProgramAssociations")]
    public partial class StudentSpecialEducationProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationPut,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationPost,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationDelete,
        Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.IdeaEligibility = request.IdeaEligibility;
            specification.IEPBeginDate = request.IEPBeginDate;
            specification.IEPEndDate = request.IEPEndDate;
            specification.IEPReviewDate = request.IEPReviewDate;
            specification.LastEvaluationDate = request.LastEvaluationDate;
            specification.MedicallyFragile = request.MedicallyFragile;
            specification.MultiplyDisabled = request.MultiplyDisabled;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SchoolHoursPerWeek = request.SchoolHoursPerWeek;
            specification.SpecialEducationHoursPerWeek = request.SpecialEducationHoursPerWeek;
            specification.SpecialEducationSettingDescriptor = request.SpecialEducationSettingDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentTitleIPartAProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/studentTitleIPartAProgramAssociations")]
    public partial class StudentTitleIPartAProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.StudentTitleIPartAProgramAssociation.EdFi.StudentTitleIPartAProgramAssociation,
        Entities.Common.EdFi.IStudentTitleIPartAProgramAssociation,
        Entities.NHibernate.StudentTitleIPartAProgramAssociationAggregate.EdFi.StudentTitleIPartAProgramAssociation,
        Api.Common.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationPut,
        Api.Common.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationPost,
        Api.Common.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationDelete,
        Api.Common.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationGetByExample>
    {
        public StudentTitleIPartAProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationGetByExample request, Entities.Common.EdFi.IStudentTitleIPartAProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.ProgramEducationOrganizationId = request.ProgramEducationOrganizationId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TitleIPartAParticipantDescriptor = request.TitleIPartAParticipantDescriptor;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SubmissionStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/submissionStatusDescriptors")]
    public partial class SubmissionStatusDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SubmissionStatusDescriptor.EdFi.SubmissionStatusDescriptor,
        Entities.Common.EdFi.ISubmissionStatusDescriptor,
        Entities.NHibernate.SubmissionStatusDescriptorAggregate.EdFi.SubmissionStatusDescriptor,
        Api.Common.Models.Requests.SubmissionStatusDescriptors.EdFi.SubmissionStatusDescriptorPut,
        Api.Common.Models.Requests.SubmissionStatusDescriptors.EdFi.SubmissionStatusDescriptorPost,
        Api.Common.Models.Requests.SubmissionStatusDescriptors.EdFi.SubmissionStatusDescriptorDelete,
        Api.Common.Models.Requests.SubmissionStatusDescriptors.EdFi.SubmissionStatusDescriptorGetByExample>
    {
        public SubmissionStatusDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SubmissionStatusDescriptors.EdFi.SubmissionStatusDescriptorGetByExample request, Entities.Common.EdFi.ISubmissionStatusDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SubmissionStatusDescriptorId = request.SubmissionStatusDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Surveys.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveys")]
    public partial class SurveysController : DataManagementControllerBase<
        Api.Common.Models.Resources.Survey.EdFi.Survey,
        Entities.Common.EdFi.ISurvey,
        Entities.NHibernate.SurveyAggregate.EdFi.Survey,
        Api.Common.Models.Requests.Surveys.EdFi.SurveyPut,
        Api.Common.Models.Requests.Surveys.EdFi.SurveyPost,
        Api.Common.Models.Requests.Surveys.EdFi.SurveyDelete,
        Api.Common.Models.Requests.Surveys.EdFi.SurveyGetByExample>
    {
        public SurveysController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.Surveys.EdFi.SurveyGetByExample request, Entities.Common.EdFi.ISurvey specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.NumberAdministered = request.NumberAdministered;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SessionName = request.SessionName;
            specification.SurveyCategoryDescriptor = request.SurveyCategoryDescriptor;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyTitle = request.SurveyTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyCategoryDescriptors")]
    public partial class SurveyCategoryDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyCategoryDescriptor.EdFi.SurveyCategoryDescriptor,
        Entities.Common.EdFi.ISurveyCategoryDescriptor,
        Entities.NHibernate.SurveyCategoryDescriptorAggregate.EdFi.SurveyCategoryDescriptor,
        Api.Common.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorPut,
        Api.Common.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorPost,
        Api.Common.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorDelete,
        Api.Common.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorGetByExample>
    {
        public SurveyCategoryDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorGetByExample request, Entities.Common.EdFi.ISurveyCategoryDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SurveyCategoryDescriptorId = request.SurveyCategoryDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyCourseAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyCourseAssociations")]
    public partial class SurveyCourseAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyCourseAssociation.EdFi.SurveyCourseAssociation,
        Entities.Common.EdFi.ISurveyCourseAssociation,
        Entities.NHibernate.SurveyCourseAssociationAggregate.EdFi.SurveyCourseAssociation,
        Api.Common.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationPut,
        Api.Common.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationPost,
        Api.Common.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationDelete,
        Api.Common.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationGetByExample>
    {
        public SurveyCourseAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationGetByExample request, Entities.Common.EdFi.ISurveyCourseAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyLevelDescriptors")]
    public partial class SurveyLevelDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyLevelDescriptor.EdFi.SurveyLevelDescriptor,
        Entities.Common.EdFi.ISurveyLevelDescriptor,
        Entities.NHibernate.SurveyLevelDescriptorAggregate.EdFi.SurveyLevelDescriptor,
        Api.Common.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorPut,
        Api.Common.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorPost,
        Api.Common.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorDelete,
        Api.Common.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorGetByExample>
    {
        public SurveyLevelDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorGetByExample request, Entities.Common.EdFi.ISurveyLevelDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SurveyLevelDescriptorId = request.SurveyLevelDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyProgramAssociations")]
    public partial class SurveyProgramAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyProgramAssociation.EdFi.SurveyProgramAssociation,
        Entities.Common.EdFi.ISurveyProgramAssociation,
        Entities.NHibernate.SurveyProgramAssociationAggregate.EdFi.SurveyProgramAssociation,
        Api.Common.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationPut,
        Api.Common.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationPost,
        Api.Common.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationDelete,
        Api.Common.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationGetByExample>
    {
        public SurveyProgramAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationGetByExample request, Entities.Common.EdFi.ISurveyProgramAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
            specification.SurveyIdentifier = request.SurveyIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyQuestions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyQuestions")]
    public partial class SurveyQuestionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyQuestion.EdFi.SurveyQuestion,
        Entities.Common.EdFi.ISurveyQuestion,
        Entities.NHibernate.SurveyQuestionAggregate.EdFi.SurveyQuestion,
        Api.Common.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionPut,
        Api.Common.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionPost,
        Api.Common.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionDelete,
        Api.Common.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionGetByExample>
    {
        public SurveyQuestionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionGetByExample request, Entities.Common.EdFi.ISurveyQuestion specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.QuestionCode = request.QuestionCode;
            specification.QuestionFormDescriptor = request.QuestionFormDescriptor;
            specification.QuestionText = request.QuestionText;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyQuestionResponses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyQuestionResponses")]
    public partial class SurveyQuestionResponsesController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyQuestionResponse.EdFi.SurveyQuestionResponse,
        Entities.Common.EdFi.ISurveyQuestionResponse,
        Entities.NHibernate.SurveyQuestionResponseAggregate.EdFi.SurveyQuestionResponse,
        Api.Common.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponsePut,
        Api.Common.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponsePost,
        Api.Common.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponseDelete,
        Api.Common.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponseGetByExample>
    {
        public SurveyQuestionResponsesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponseGetByExample request, Entities.Common.EdFi.ISurveyQuestionResponse specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Comment = request.Comment;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.NoResponse = request.NoResponse;
            specification.QuestionCode = request.QuestionCode;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyResponses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyResponses")]
    public partial class SurveyResponsesController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyResponse.EdFi.SurveyResponse,
        Entities.Common.EdFi.ISurveyResponse,
        Entities.NHibernate.SurveyResponseAggregate.EdFi.SurveyResponse,
        Api.Common.Models.Requests.SurveyResponses.EdFi.SurveyResponsePut,
        Api.Common.Models.Requests.SurveyResponses.EdFi.SurveyResponsePost,
        Api.Common.Models.Requests.SurveyResponses.EdFi.SurveyResponseDelete,
        Api.Common.Models.Requests.SurveyResponses.EdFi.SurveyResponseGetByExample>
    {
        public SurveyResponsesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyResponses.EdFi.SurveyResponseGetByExample request, Entities.Common.EdFi.ISurveyResponse specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ElectronicMailAddress = request.ElectronicMailAddress;
            specification.FullName = request.FullName;
            specification.Id = request.Id;
            specification.Location = request.Location;
            specification.Namespace = request.Namespace;
            specification.ParentUniqueId = request.ParentUniqueId;
            specification.ResponseDate = request.ResponseDate;
            specification.ResponseTime = request.ResponseTime;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyResponseEducationOrganizationTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyResponseEducationOrganizationTargetAssociations")]
    public partial class SurveyResponseEducationOrganizationTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyResponseEducationOrganizationTargetAssociation.EdFi.SurveyResponseEducationOrganizationTargetAssociation,
        Entities.Common.EdFi.ISurveyResponseEducationOrganizationTargetAssociation,
        Entities.NHibernate.SurveyResponseEducationOrganizationTargetAssociationAggregate.EdFi.SurveyResponseEducationOrganizationTargetAssociation,
        Api.Common.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationPut,
        Api.Common.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationPost,
        Api.Common.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationDelete,
        Api.Common.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationGetByExample>
    {
        public SurveyResponseEducationOrganizationTargetAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationGetByExample request, Entities.Common.EdFi.ISurveyResponseEducationOrganizationTargetAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyResponseStaffTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveyResponseStaffTargetAssociations")]
    public partial class SurveyResponseStaffTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveyResponseStaffTargetAssociation.EdFi.SurveyResponseStaffTargetAssociation,
        Entities.Common.EdFi.ISurveyResponseStaffTargetAssociation,
        Entities.NHibernate.SurveyResponseStaffTargetAssociationAggregate.EdFi.SurveyResponseStaffTargetAssociation,
        Api.Common.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationPut,
        Api.Common.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationPost,
        Api.Common.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationDelete,
        Api.Common.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationGetByExample>
    {
        public SurveyResponseStaffTargetAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationGetByExample request, Entities.Common.EdFi.ISurveyResponseStaffTargetAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySections.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveySections")]
    public partial class SurveySectionsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySection.EdFi.SurveySection,
        Entities.Common.EdFi.ISurveySection,
        Entities.NHibernate.SurveySectionAggregate.EdFi.SurveySection,
        Api.Common.Models.Requests.SurveySections.EdFi.SurveySectionPut,
        Api.Common.Models.Requests.SurveySections.EdFi.SurveySectionPost,
        Api.Common.Models.Requests.SurveySections.EdFi.SurveySectionDelete,
        Api.Common.Models.Requests.SurveySections.EdFi.SurveySectionGetByExample>
    {
        public SurveySectionsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveySections.EdFi.SurveySectionGetByExample request, Entities.Common.EdFi.ISurveySection specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveySectionAssociations")]
    public partial class SurveySectionAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionAssociation.EdFi.SurveySectionAssociation,
        Entities.Common.EdFi.ISurveySectionAssociation,
        Entities.NHibernate.SurveySectionAssociationAggregate.EdFi.SurveySectionAssociation,
        Api.Common.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationPut,
        Api.Common.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationPost,
        Api.Common.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationDelete,
        Api.Common.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationGetByExample>
    {
        public SurveySectionAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationGetByExample request, Entities.Common.EdFi.ISurveySectionAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.Namespace = request.Namespace;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.SurveyIdentifier = request.SurveyIdentifier;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionResponses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveySectionResponses")]
    public partial class SurveySectionResponsesController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionResponse.EdFi.SurveySectionResponse,
        Entities.Common.EdFi.ISurveySectionResponse,
        Entities.NHibernate.SurveySectionResponseAggregate.EdFi.SurveySectionResponse,
        Api.Common.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponsePut,
        Api.Common.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponsePost,
        Api.Common.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponseDelete,
        Api.Common.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponseGetByExample>
    {
        public SurveySectionResponsesController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponseGetByExample request, Entities.Common.EdFi.ISurveySectionResponse specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SectionRating = request.SectionRating;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveySectionResponseEducationOrganizationTargetAssociations")]
    public partial class SurveySectionResponseEducationOrganizationTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionResponseEducationOrganizationTargetAssociation.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation,
        Entities.Common.EdFi.ISurveySectionResponseEducationOrganizationTargetAssociation,
        Entities.NHibernate.SurveySectionResponseEducationOrganizationTargetAssociationAggregate.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation,
        Api.Common.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationPut,
        Api.Common.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationPost,
        Api.Common.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationDelete,
        Api.Common.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationGetByExample>
    {
        public SurveySectionResponseEducationOrganizationTargetAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationGetByExample request, Entities.Common.EdFi.ISurveySectionResponseEducationOrganizationTargetAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionResponseStaffTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/surveySectionResponseStaffTargetAssociations")]
    public partial class SurveySectionResponseStaffTargetAssociationsController : DataManagementControllerBase<
        Api.Common.Models.Resources.SurveySectionResponseStaffTargetAssociation.EdFi.SurveySectionResponseStaffTargetAssociation,
        Entities.Common.EdFi.ISurveySectionResponseStaffTargetAssociation,
        Entities.NHibernate.SurveySectionResponseStaffTargetAssociationAggregate.EdFi.SurveySectionResponseStaffTargetAssociation,
        Api.Common.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationPut,
        Api.Common.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationPost,
        Api.Common.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationDelete,
        Api.Common.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationGetByExample>
    {
        public SurveySectionResponseStaffTargetAssociationsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationGetByExample request, Entities.Common.EdFi.ISurveySectionResponseStaffTargetAssociation specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TeachingCredentialBasisDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/teachingCredentialBasisDescriptors")]
    public partial class TeachingCredentialBasisDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TeachingCredentialBasisDescriptor.EdFi.TeachingCredentialBasisDescriptor,
        Entities.Common.EdFi.ITeachingCredentialBasisDescriptor,
        Entities.NHibernate.TeachingCredentialBasisDescriptorAggregate.EdFi.TeachingCredentialBasisDescriptor,
        Api.Common.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorPut,
        Api.Common.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorPost,
        Api.Common.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorDelete,
        Api.Common.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorGetByExample>
    {
        public TeachingCredentialBasisDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorGetByExample request, Entities.Common.EdFi.ITeachingCredentialBasisDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TeachingCredentialBasisDescriptorId = request.TeachingCredentialBasisDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TeachingCredentialDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/teachingCredentialDescriptors")]
    public partial class TeachingCredentialDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TeachingCredentialDescriptor.EdFi.TeachingCredentialDescriptor,
        Entities.Common.EdFi.ITeachingCredentialDescriptor,
        Entities.NHibernate.TeachingCredentialDescriptorAggregate.EdFi.TeachingCredentialDescriptor,
        Api.Common.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorPut,
        Api.Common.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorPost,
        Api.Common.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorDelete,
        Api.Common.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorGetByExample>
    {
        public TeachingCredentialDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorGetByExample request, Entities.Common.EdFi.ITeachingCredentialDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TeachingCredentialDescriptorId = request.TeachingCredentialDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TechnicalSkillsAssessmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/technicalSkillsAssessmentDescriptors")]
    public partial class TechnicalSkillsAssessmentDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TechnicalSkillsAssessmentDescriptor.EdFi.TechnicalSkillsAssessmentDescriptor,
        Entities.Common.EdFi.ITechnicalSkillsAssessmentDescriptor,
        Entities.NHibernate.TechnicalSkillsAssessmentDescriptorAggregate.EdFi.TechnicalSkillsAssessmentDescriptor,
        Api.Common.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorPut,
        Api.Common.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorPost,
        Api.Common.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorDelete,
        Api.Common.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorGetByExample>
    {
        public TechnicalSkillsAssessmentDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorGetByExample request, Entities.Common.EdFi.ITechnicalSkillsAssessmentDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TechnicalSkillsAssessmentDescriptorId = request.TechnicalSkillsAssessmentDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TelephoneNumberTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/telephoneNumberTypeDescriptors")]
    public partial class TelephoneNumberTypeDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TelephoneNumberTypeDescriptor.EdFi.TelephoneNumberTypeDescriptor,
        Entities.Common.EdFi.ITelephoneNumberTypeDescriptor,
        Entities.NHibernate.TelephoneNumberTypeDescriptorAggregate.EdFi.TelephoneNumberTypeDescriptor,
        Api.Common.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorPut,
        Api.Common.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorPost,
        Api.Common.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorDelete,
        Api.Common.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorGetByExample>
    {
        public TelephoneNumberTypeDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorGetByExample request, Entities.Common.EdFi.ITelephoneNumberTypeDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TelephoneNumberTypeDescriptorId = request.TelephoneNumberTypeDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TermDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/termDescriptors")]
    public partial class TermDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TermDescriptor.EdFi.TermDescriptor,
        Entities.Common.EdFi.ITermDescriptor,
        Entities.NHibernate.TermDescriptorAggregate.EdFi.TermDescriptor,
        Api.Common.Models.Requests.TermDescriptors.EdFi.TermDescriptorPut,
        Api.Common.Models.Requests.TermDescriptors.EdFi.TermDescriptorPost,
        Api.Common.Models.Requests.TermDescriptors.EdFi.TermDescriptorDelete,
        Api.Common.Models.Requests.TermDescriptors.EdFi.TermDescriptorGetByExample>
    {
        public TermDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TermDescriptors.EdFi.TermDescriptorGetByExample request, Entities.Common.EdFi.ITermDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TermDescriptorId = request.TermDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TitleIPartAParticipantDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/titleIPartAParticipantDescriptors")]
    public partial class TitleIPartAParticipantDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TitleIPartAParticipantDescriptor.EdFi.TitleIPartAParticipantDescriptor,
        Entities.Common.EdFi.ITitleIPartAParticipantDescriptor,
        Entities.NHibernate.TitleIPartAParticipantDescriptorAggregate.EdFi.TitleIPartAParticipantDescriptor,
        Api.Common.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorPut,
        Api.Common.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorPost,
        Api.Common.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorDelete,
        Api.Common.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorGetByExample>
    {
        public TitleIPartAParticipantDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorGetByExample request, Entities.Common.EdFi.ITitleIPartAParticipantDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TitleIPartAParticipantDescriptorId = request.TitleIPartAParticipantDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TitleIPartAProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/titleIPartAProgramServiceDescriptors")]
    public partial class TitleIPartAProgramServiceDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TitleIPartAProgramServiceDescriptor.EdFi.TitleIPartAProgramServiceDescriptor,
        Entities.Common.EdFi.ITitleIPartAProgramServiceDescriptor,
        Entities.NHibernate.TitleIPartAProgramServiceDescriptorAggregate.EdFi.TitleIPartAProgramServiceDescriptor,
        Api.Common.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorPut,
        Api.Common.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorPost,
        Api.Common.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorDelete,
        Api.Common.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorGetByExample>
    {
        public TitleIPartAProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorGetByExample request, Entities.Common.EdFi.ITitleIPartAProgramServiceDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TitleIPartAProgramServiceDescriptorId = request.TitleIPartAProgramServiceDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TitleIPartASchoolDesignationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/titleIPartASchoolDesignationDescriptors")]
    public partial class TitleIPartASchoolDesignationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TitleIPartASchoolDesignationDescriptor.EdFi.TitleIPartASchoolDesignationDescriptor,
        Entities.Common.EdFi.ITitleIPartASchoolDesignationDescriptor,
        Entities.NHibernate.TitleIPartASchoolDesignationDescriptorAggregate.EdFi.TitleIPartASchoolDesignationDescriptor,
        Api.Common.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorPut,
        Api.Common.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorPost,
        Api.Common.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorDelete,
        Api.Common.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorGetByExample>
    {
        public TitleIPartASchoolDesignationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorGetByExample request, Entities.Common.EdFi.ITitleIPartASchoolDesignationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TitleIPartASchoolDesignationDescriptorId = request.TitleIPartASchoolDesignationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TribalAffiliationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/tribalAffiliationDescriptors")]
    public partial class TribalAffiliationDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.TribalAffiliationDescriptor.EdFi.TribalAffiliationDescriptor,
        Entities.Common.EdFi.ITribalAffiliationDescriptor,
        Entities.NHibernate.TribalAffiliationDescriptorAggregate.EdFi.TribalAffiliationDescriptor,
        Api.Common.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorPut,
        Api.Common.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorPost,
        Api.Common.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorDelete,
        Api.Common.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorGetByExample>
    {
        public TribalAffiliationDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorGetByExample request, Entities.Common.EdFi.ITribalAffiliationDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TribalAffiliationDescriptorId = request.TribalAffiliationDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.VisaDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/visaDescriptors")]
    public partial class VisaDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.VisaDescriptor.EdFi.VisaDescriptor,
        Entities.Common.EdFi.IVisaDescriptor,
        Entities.NHibernate.VisaDescriptorAggregate.EdFi.VisaDescriptor,
        Api.Common.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorPut,
        Api.Common.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorPost,
        Api.Common.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorDelete,
        Api.Common.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorGetByExample>
    {
        public VisaDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorGetByExample request, Entities.Common.EdFi.IVisaDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.VisaDescriptorId = request.VisaDescriptorId;
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.WeaponDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [RouteRootContext(RouteContextType.Ods), Route($"{RouteConstants.DataManagementRoutePrefix}/ed-fi/weaponDescriptors")]
    public partial class WeaponDescriptorsController : DataManagementControllerBase<
        Api.Common.Models.Resources.WeaponDescriptor.EdFi.WeaponDescriptor,
        Entities.Common.EdFi.IWeaponDescriptor,
        Entities.NHibernate.WeaponDescriptorAggregate.EdFi.WeaponDescriptor,
        Api.Common.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorPut,
        Api.Common.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorPost,
        Api.Common.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorDelete,
        Api.Common.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorGetByExample>
    {
        public WeaponDescriptorsController(IPipelineFactory pipelineFactory, IRESTErrorProvider restErrorProvider, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider, ApiSettings apiSettings, IContextProvider<ProfileContentTypeContext> profileContentTypeContextProvider)
            : base(pipelineFactory, restErrorProvider, defaultPageSizeLimitProvider, apiSettings, profileContentTypeContextProvider)
        {
        }

        protected override void MapAll(Api.Common.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorGetByExample request, Entities.Common.EdFi.IWeaponDescriptor specification)
        {
            // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.WeaponDescriptorId = request.WeaponDescriptorId;
        }
    }
}

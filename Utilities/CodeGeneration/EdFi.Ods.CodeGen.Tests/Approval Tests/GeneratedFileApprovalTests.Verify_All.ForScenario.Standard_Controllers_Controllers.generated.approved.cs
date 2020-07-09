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

namespace EdFi.Ods.Api.Services.Controllers.AbsenceEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AbsenceEventCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.AbsenceEventCategoryDescriptor.EdFi.AbsenceEventCategoryDescriptor,
        Models.Resources.AbsenceEventCategoryDescriptor.EdFi.AbsenceEventCategoryDescriptor,
        Entities.Common.EdFi.IAbsenceEventCategoryDescriptor,
        Entities.NHibernate.AbsenceEventCategoryDescriptorAggregate.EdFi.AbsenceEventCategoryDescriptor,
        Api.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorPut,
        Api.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorPost,
        Api.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorDelete,
        Api.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorGetByExample>
    {
        public AbsenceEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AbsenceEventCategoryDescriptors.EdFi.AbsenceEventCategoryDescriptorGetByExample request, IAbsenceEventCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AbsenceEventCategoryDescriptorId = request.AbsenceEventCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "absenceEventCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicHonorCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AcademicHonorCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.AcademicHonorCategoryDescriptor.EdFi.AcademicHonorCategoryDescriptor,
        Models.Resources.AcademicHonorCategoryDescriptor.EdFi.AcademicHonorCategoryDescriptor,
        Entities.Common.EdFi.IAcademicHonorCategoryDescriptor,
        Entities.NHibernate.AcademicHonorCategoryDescriptorAggregate.EdFi.AcademicHonorCategoryDescriptor,
        Api.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorPut,
        Api.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorPost,
        Api.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorDelete,
        Api.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorGetByExample>
    {
        public AcademicHonorCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AcademicHonorCategoryDescriptors.EdFi.AcademicHonorCategoryDescriptorGetByExample request, IAcademicHonorCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicHonorCategoryDescriptorId = request.AcademicHonorCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "academicHonorCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicSubjectDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AcademicSubjectDescriptorsController : EdFiControllerBase<
        Models.Resources.AcademicSubjectDescriptor.EdFi.AcademicSubjectDescriptor,
        Models.Resources.AcademicSubjectDescriptor.EdFi.AcademicSubjectDescriptor,
        Entities.Common.EdFi.IAcademicSubjectDescriptor,
        Entities.NHibernate.AcademicSubjectDescriptorAggregate.EdFi.AcademicSubjectDescriptor,
        Api.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorPut,
        Api.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorPost,
        Api.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorDelete,
        Api.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorGetByExample>
    {
        public AcademicSubjectDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AcademicSubjectDescriptors.EdFi.AcademicSubjectDescriptorGetByExample request, IAcademicSubjectDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AcademicSubjectDescriptorId = request.AcademicSubjectDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "academicSubjectDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AcademicWeeks.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AcademicWeeksController : EdFiControllerBase<
        Models.Resources.AcademicWeek.EdFi.AcademicWeek,
        Models.Resources.AcademicWeek.EdFi.AcademicWeek,
        Entities.Common.EdFi.IAcademicWeek,
        Entities.NHibernate.AcademicWeekAggregate.EdFi.AcademicWeek,
        Api.Models.Requests.AcademicWeeks.EdFi.AcademicWeekPut,
        Api.Models.Requests.AcademicWeeks.EdFi.AcademicWeekPost,
        Api.Models.Requests.AcademicWeeks.EdFi.AcademicWeekDelete,
        Api.Models.Requests.AcademicWeeks.EdFi.AcademicWeekGetByExample>
    {
        public AcademicWeeksController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AcademicWeeks.EdFi.AcademicWeekGetByExample request, IAcademicWeek specification)
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

        protected override string GetResourceCollectionName()
        {
            return "academicWeeks";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccommodationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AccommodationDescriptorsController : EdFiControllerBase<
        Models.Resources.AccommodationDescriptor.EdFi.AccommodationDescriptor,
        Models.Resources.AccommodationDescriptor.EdFi.AccommodationDescriptor,
        Entities.Common.EdFi.IAccommodationDescriptor,
        Entities.NHibernate.AccommodationDescriptorAggregate.EdFi.AccommodationDescriptor,
        Api.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorPut,
        Api.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorPost,
        Api.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorDelete,
        Api.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorGetByExample>
    {
        public AccommodationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AccommodationDescriptors.EdFi.AccommodationDescriptorGetByExample request, IAccommodationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccommodationDescriptorId = request.AccommodationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "accommodationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Accounts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AccountsController : EdFiControllerBase<
        Models.Resources.Account.EdFi.Account,
        Models.Resources.Account.EdFi.Account,
        Entities.Common.EdFi.IAccount,
        Entities.NHibernate.AccountAggregate.EdFi.Account,
        Api.Models.Requests.Accounts.EdFi.AccountPut,
        Api.Models.Requests.Accounts.EdFi.AccountPost,
        Api.Models.Requests.Accounts.EdFi.AccountDelete,
        Api.Models.Requests.Accounts.EdFi.AccountGetByExample>
    {
        public AccountsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Accounts.EdFi.AccountGetByExample request, IAccount specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.AccountName = request.AccountName;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "accounts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccountabilityRatings.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AccountabilityRatingsController : EdFiControllerBase<
        Models.Resources.AccountabilityRating.EdFi.AccountabilityRating,
        Models.Resources.AccountabilityRating.EdFi.AccountabilityRating,
        Entities.Common.EdFi.IAccountabilityRating,
        Entities.NHibernate.AccountabilityRatingAggregate.EdFi.AccountabilityRating,
        Api.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingPut,
        Api.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingPost,
        Api.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingDelete,
        Api.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingGetByExample>
    {
        public AccountabilityRatingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AccountabilityRatings.EdFi.AccountabilityRatingGetByExample request, IAccountabilityRating specification)
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

        protected override string GetResourceCollectionName()
        {
            return "accountabilityRatings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccountClassificationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AccountClassificationDescriptorsController : EdFiControllerBase<
        Models.Resources.AccountClassificationDescriptor.EdFi.AccountClassificationDescriptor,
        Models.Resources.AccountClassificationDescriptor.EdFi.AccountClassificationDescriptor,
        Entities.Common.EdFi.IAccountClassificationDescriptor,
        Entities.NHibernate.AccountClassificationDescriptorAggregate.EdFi.AccountClassificationDescriptor,
        Api.Models.Requests.AccountClassificationDescriptors.EdFi.AccountClassificationDescriptorPut,
        Api.Models.Requests.AccountClassificationDescriptors.EdFi.AccountClassificationDescriptorPost,
        Api.Models.Requests.AccountClassificationDescriptors.EdFi.AccountClassificationDescriptorDelete,
        Api.Models.Requests.AccountClassificationDescriptors.EdFi.AccountClassificationDescriptorGetByExample>
    {
        public AccountClassificationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AccountClassificationDescriptors.EdFi.AccountClassificationDescriptorGetByExample request, IAccountClassificationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountClassificationDescriptorId = request.AccountClassificationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "accountClassificationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AccountCodes.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AccountCodesController : EdFiControllerBase<
        Models.Resources.AccountCode.EdFi.AccountCode,
        Models.Resources.AccountCode.EdFi.AccountCode,
        Entities.Common.EdFi.IAccountCode,
        Entities.NHibernate.AccountCodeAggregate.EdFi.AccountCode,
        Api.Models.Requests.AccountCodes.EdFi.AccountCodePut,
        Api.Models.Requests.AccountCodes.EdFi.AccountCodePost,
        Api.Models.Requests.AccountCodes.EdFi.AccountCodeDelete,
        Api.Models.Requests.AccountCodes.EdFi.AccountCodeGetByExample>
    {
        public AccountCodesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AccountCodes.EdFi.AccountCodeGetByExample request, IAccountCode specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountClassificationDescriptor = request.AccountClassificationDescriptor;
            specification.AccountCodeDescription = request.AccountCodeDescription;
            specification.AccountCodeNumber = request.AccountCodeNumber;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "accountCodes";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AchievementCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AchievementCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.AchievementCategoryDescriptor.EdFi.AchievementCategoryDescriptor,
        Models.Resources.AchievementCategoryDescriptor.EdFi.AchievementCategoryDescriptor,
        Entities.Common.EdFi.IAchievementCategoryDescriptor,
        Entities.NHibernate.AchievementCategoryDescriptorAggregate.EdFi.AchievementCategoryDescriptor,
        Api.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorPut,
        Api.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorPost,
        Api.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorDelete,
        Api.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorGetByExample>
    {
        public AchievementCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AchievementCategoryDescriptors.EdFi.AchievementCategoryDescriptorGetByExample request, IAchievementCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AchievementCategoryDescriptorId = request.AchievementCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "achievementCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Actuals.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ActualsController : EdFiControllerBase<
        Models.Resources.Actual.EdFi.Actual,
        Models.Resources.Actual.EdFi.Actual,
        Entities.Common.EdFi.IActual,
        Entities.NHibernate.ActualAggregate.EdFi.Actual,
        Api.Models.Requests.Actuals.EdFi.ActualPut,
        Api.Models.Requests.Actuals.EdFi.ActualPost,
        Api.Models.Requests.Actuals.EdFi.ActualDelete,
        Api.Models.Requests.Actuals.EdFi.ActualGetByExample>
    {
        public ActualsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Actuals.EdFi.ActualGetByExample request, IActual specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.AmountToDate = request.AmountToDate;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "actuals";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AdditionalCreditTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AdditionalCreditTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.AdditionalCreditTypeDescriptor.EdFi.AdditionalCreditTypeDescriptor,
        Models.Resources.AdditionalCreditTypeDescriptor.EdFi.AdditionalCreditTypeDescriptor,
        Entities.Common.EdFi.IAdditionalCreditTypeDescriptor,
        Entities.NHibernate.AdditionalCreditTypeDescriptorAggregate.EdFi.AdditionalCreditTypeDescriptor,
        Api.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorPut,
        Api.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorPost,
        Api.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorDelete,
        Api.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorGetByExample>
    {
        public AdditionalCreditTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AdditionalCreditTypeDescriptors.EdFi.AdditionalCreditTypeDescriptorGetByExample request, IAdditionalCreditTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdditionalCreditTypeDescriptorId = request.AdditionalCreditTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "additionalCreditTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AddressTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AddressTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.AddressTypeDescriptor.EdFi.AddressTypeDescriptor,
        Models.Resources.AddressTypeDescriptor.EdFi.AddressTypeDescriptor,
        Entities.Common.EdFi.IAddressTypeDescriptor,
        Entities.NHibernate.AddressTypeDescriptorAggregate.EdFi.AddressTypeDescriptor,
        Api.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorPut,
        Api.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorPost,
        Api.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorDelete,
        Api.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorGetByExample>
    {
        public AddressTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AddressTypeDescriptors.EdFi.AddressTypeDescriptorGetByExample request, IAddressTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AddressTypeDescriptorId = request.AddressTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "addressTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AdministrationEnvironmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AdministrationEnvironmentDescriptorsController : EdFiControllerBase<
        Models.Resources.AdministrationEnvironmentDescriptor.EdFi.AdministrationEnvironmentDescriptor,
        Models.Resources.AdministrationEnvironmentDescriptor.EdFi.AdministrationEnvironmentDescriptor,
        Entities.Common.EdFi.IAdministrationEnvironmentDescriptor,
        Entities.NHibernate.AdministrationEnvironmentDescriptorAggregate.EdFi.AdministrationEnvironmentDescriptor,
        Api.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorPut,
        Api.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorPost,
        Api.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorDelete,
        Api.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorGetByExample>
    {
        public AdministrationEnvironmentDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AdministrationEnvironmentDescriptors.EdFi.AdministrationEnvironmentDescriptorGetByExample request, IAdministrationEnvironmentDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationEnvironmentDescriptorId = request.AdministrationEnvironmentDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "administrationEnvironmentDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AdministrativeFundingControlDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AdministrativeFundingControlDescriptorsController : EdFiControllerBase<
        Models.Resources.AdministrativeFundingControlDescriptor.EdFi.AdministrativeFundingControlDescriptor,
        Models.Resources.AdministrativeFundingControlDescriptor.EdFi.AdministrativeFundingControlDescriptor,
        Entities.Common.EdFi.IAdministrativeFundingControlDescriptor,
        Entities.NHibernate.AdministrativeFundingControlDescriptorAggregate.EdFi.AdministrativeFundingControlDescriptor,
        Api.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorPut,
        Api.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorPost,
        Api.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorDelete,
        Api.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorGetByExample>
    {
        public AdministrativeFundingControlDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AdministrativeFundingControlDescriptors.EdFi.AdministrativeFundingControlDescriptorGetByExample request, IAdministrativeFundingControlDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptorId = request.AdministrativeFundingControlDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "administrativeFundingControlDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Assessments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentsController : EdFiControllerBase<
        Models.Resources.Assessment.EdFi.Assessment,
        Models.Resources.Assessment.EdFi.Assessment,
        Entities.Common.EdFi.IAssessment,
        Entities.NHibernate.AssessmentAggregate.EdFi.Assessment,
        Api.Models.Requests.Assessments.EdFi.AssessmentPut,
        Api.Models.Requests.Assessments.EdFi.AssessmentPost,
        Api.Models.Requests.Assessments.EdFi.AssessmentDelete,
        Api.Models.Requests.Assessments.EdFi.AssessmentGetByExample>
    {
        public AssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Assessments.EdFi.AssessmentGetByExample request, IAssessment specification)
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

        protected override string GetResourceCollectionName()
        {
            return "assessments";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.AssessmentCategoryDescriptor.EdFi.AssessmentCategoryDescriptor,
        Models.Resources.AssessmentCategoryDescriptor.EdFi.AssessmentCategoryDescriptor,
        Entities.Common.EdFi.IAssessmentCategoryDescriptor,
        Entities.NHibernate.AssessmentCategoryDescriptorAggregate.EdFi.AssessmentCategoryDescriptor,
        Api.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorPut,
        Api.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorPost,
        Api.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorDelete,
        Api.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorGetByExample>
    {
        public AssessmentCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentCategoryDescriptors.EdFi.AssessmentCategoryDescriptorGetByExample request, IAssessmentCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentCategoryDescriptorId = request.AssessmentCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentIdentificationSystemDescriptorsController : EdFiControllerBase<
        Models.Resources.AssessmentIdentificationSystemDescriptor.EdFi.AssessmentIdentificationSystemDescriptor,
        Models.Resources.AssessmentIdentificationSystemDescriptor.EdFi.AssessmentIdentificationSystemDescriptor,
        Entities.Common.EdFi.IAssessmentIdentificationSystemDescriptor,
        Entities.NHibernate.AssessmentIdentificationSystemDescriptorAggregate.EdFi.AssessmentIdentificationSystemDescriptor,
        Api.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorPut,
        Api.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorPost,
        Api.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorDelete,
        Api.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorGetByExample>
    {
        public AssessmentIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi.AssessmentIdentificationSystemDescriptorGetByExample request, IAssessmentIdentificationSystemDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentIdentificationSystemDescriptorId = request.AssessmentIdentificationSystemDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentIdentificationSystemDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentItems.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentItemsController : EdFiControllerBase<
        Models.Resources.AssessmentItem.EdFi.AssessmentItem,
        Models.Resources.AssessmentItem.EdFi.AssessmentItem,
        Entities.Common.EdFi.IAssessmentItem,
        Entities.NHibernate.AssessmentItemAggregate.EdFi.AssessmentItem,
        Api.Models.Requests.AssessmentItems.EdFi.AssessmentItemPut,
        Api.Models.Requests.AssessmentItems.EdFi.AssessmentItemPost,
        Api.Models.Requests.AssessmentItems.EdFi.AssessmentItemDelete,
        Api.Models.Requests.AssessmentItems.EdFi.AssessmentItemGetByExample>
    {
        public AssessmentItemsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentItems.EdFi.AssessmentItemGetByExample request, IAssessmentItem specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.AssessmentItemCategoryDescriptor = request.AssessmentItemCategoryDescriptor;
            specification.AssessmentItemURI = request.AssessmentItemURI;
            specification.CorrectResponse = request.CorrectResponse;
            specification.ExpectedTimeAssessed = request.ExpectedTimeAssessed;
            specification.Id = request.Id;
            specification.IdentificationCode = request.IdentificationCode;
            specification.ItemText = request.ItemText;
            specification.MaxRawScore = request.MaxRawScore;
            specification.Namespace = request.Namespace;
            specification.Nomenclature = request.Nomenclature;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentItems";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentItemCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentItemCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.AssessmentItemCategoryDescriptor.EdFi.AssessmentItemCategoryDescriptor,
        Models.Resources.AssessmentItemCategoryDescriptor.EdFi.AssessmentItemCategoryDescriptor,
        Entities.Common.EdFi.IAssessmentItemCategoryDescriptor,
        Entities.NHibernate.AssessmentItemCategoryDescriptorAggregate.EdFi.AssessmentItemCategoryDescriptor,
        Api.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorPut,
        Api.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorPost,
        Api.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorDelete,
        Api.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorGetByExample>
    {
        public AssessmentItemCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentItemCategoryDescriptors.EdFi.AssessmentItemCategoryDescriptorGetByExample request, IAssessmentItemCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentItemCategoryDescriptorId = request.AssessmentItemCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentItemCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentItemResultDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentItemResultDescriptorsController : EdFiControllerBase<
        Models.Resources.AssessmentItemResultDescriptor.EdFi.AssessmentItemResultDescriptor,
        Models.Resources.AssessmentItemResultDescriptor.EdFi.AssessmentItemResultDescriptor,
        Entities.Common.EdFi.IAssessmentItemResultDescriptor,
        Entities.NHibernate.AssessmentItemResultDescriptorAggregate.EdFi.AssessmentItemResultDescriptor,
        Api.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorPut,
        Api.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorPost,
        Api.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorDelete,
        Api.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorGetByExample>
    {
        public AssessmentItemResultDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentItemResultDescriptors.EdFi.AssessmentItemResultDescriptorGetByExample request, IAssessmentItemResultDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentItemResultDescriptorId = request.AssessmentItemResultDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentItemResultDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentPeriodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentPeriodDescriptorsController : EdFiControllerBase<
        Models.Resources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor,
        Models.Resources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor,
        Entities.Common.EdFi.IAssessmentPeriodDescriptor,
        Entities.NHibernate.AssessmentPeriodDescriptorAggregate.EdFi.AssessmentPeriodDescriptor,
        Api.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorPut,
        Api.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorPost,
        Api.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorDelete,
        Api.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorGetByExample>
    {
        public AssessmentPeriodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentPeriodDescriptors.EdFi.AssessmentPeriodDescriptorGetByExample request, IAssessmentPeriodDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentPeriodDescriptorId = request.AssessmentPeriodDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentPeriodDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AssessmentReportingMethodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AssessmentReportingMethodDescriptorsController : EdFiControllerBase<
        Models.Resources.AssessmentReportingMethodDescriptor.EdFi.AssessmentReportingMethodDescriptor,
        Models.Resources.AssessmentReportingMethodDescriptor.EdFi.AssessmentReportingMethodDescriptor,
        Entities.Common.EdFi.IAssessmentReportingMethodDescriptor,
        Entities.NHibernate.AssessmentReportingMethodDescriptorAggregate.EdFi.AssessmentReportingMethodDescriptor,
        Api.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorPut,
        Api.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorPost,
        Api.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorDelete,
        Api.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorGetByExample>
    {
        public AssessmentReportingMethodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AssessmentReportingMethodDescriptors.EdFi.AssessmentReportingMethodDescriptorGetByExample request, IAssessmentReportingMethodDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AssessmentReportingMethodDescriptorId = request.AssessmentReportingMethodDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "assessmentReportingMethodDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AttemptStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AttemptStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.AttemptStatusDescriptor.EdFi.AttemptStatusDescriptor,
        Models.Resources.AttemptStatusDescriptor.EdFi.AttemptStatusDescriptor,
        Entities.Common.EdFi.IAttemptStatusDescriptor,
        Entities.NHibernate.AttemptStatusDescriptorAggregate.EdFi.AttemptStatusDescriptor,
        Api.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorPut,
        Api.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorPost,
        Api.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorDelete,
        Api.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorGetByExample>
    {
        public AttemptStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AttemptStatusDescriptors.EdFi.AttemptStatusDescriptorGetByExample request, IAttemptStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttemptStatusDescriptorId = request.AttemptStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "attemptStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.AttendanceEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class AttendanceEventCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.AttendanceEventCategoryDescriptor.EdFi.AttendanceEventCategoryDescriptor,
        Models.Resources.AttendanceEventCategoryDescriptor.EdFi.AttendanceEventCategoryDescriptor,
        Entities.Common.EdFi.IAttendanceEventCategoryDescriptor,
        Entities.NHibernate.AttendanceEventCategoryDescriptorAggregate.EdFi.AttendanceEventCategoryDescriptor,
        Api.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorPut,
        Api.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorPost,
        Api.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorDelete,
        Api.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorGetByExample>
    {
        public AttendanceEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.AttendanceEventCategoryDescriptors.EdFi.AttendanceEventCategoryDescriptorGetByExample request, IAttendanceEventCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AttendanceEventCategoryDescriptorId = request.AttendanceEventCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "attendanceEventCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.BehaviorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BehaviorDescriptorsController : EdFiControllerBase<
        Models.Resources.BehaviorDescriptor.EdFi.BehaviorDescriptor,
        Models.Resources.BehaviorDescriptor.EdFi.BehaviorDescriptor,
        Entities.Common.EdFi.IBehaviorDescriptor,
        Entities.NHibernate.BehaviorDescriptorAggregate.EdFi.BehaviorDescriptor,
        Api.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorPut,
        Api.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorPost,
        Api.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorDelete,
        Api.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorGetByExample>
    {
        public BehaviorDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.BehaviorDescriptors.EdFi.BehaviorDescriptorGetByExample request, IBehaviorDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BehaviorDescriptorId = request.BehaviorDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "behaviorDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.BellSchedules.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BellSchedulesController : EdFiControllerBase<
        Models.Resources.BellSchedule.EdFi.BellSchedule,
        Models.Resources.BellSchedule.EdFi.BellSchedule,
        Entities.Common.EdFi.IBellSchedule,
        Entities.NHibernate.BellScheduleAggregate.EdFi.BellSchedule,
        Api.Models.Requests.BellSchedules.EdFi.BellSchedulePut,
        Api.Models.Requests.BellSchedules.EdFi.BellSchedulePost,
        Api.Models.Requests.BellSchedules.EdFi.BellScheduleDelete,
        Api.Models.Requests.BellSchedules.EdFi.BellScheduleGetByExample>
    {
        public BellSchedulesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.BellSchedules.EdFi.BellScheduleGetByExample request, IBellSchedule specification)
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

        protected override string GetResourceCollectionName()
        {
            return "bellSchedules";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Budgets.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class BudgetsController : EdFiControllerBase<
        Models.Resources.Budget.EdFi.Budget,
        Models.Resources.Budget.EdFi.Budget,
        Entities.Common.EdFi.IBudget,
        Entities.NHibernate.BudgetAggregate.EdFi.Budget,
        Api.Models.Requests.Budgets.EdFi.BudgetPut,
        Api.Models.Requests.Budgets.EdFi.BudgetPost,
        Api.Models.Requests.Budgets.EdFi.BudgetDelete,
        Api.Models.Requests.Budgets.EdFi.BudgetGetByExample>
    {
        public BudgetsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Budgets.EdFi.BudgetGetByExample request, IBudget specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.Amount = request.Amount;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
                    }

        protected override string GetResourceCollectionName()
        {
            return "budgets";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Calendars.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CalendarsController : EdFiControllerBase<
        Models.Resources.Calendar.EdFi.Calendar,
        Models.Resources.Calendar.EdFi.Calendar,
        Entities.Common.EdFi.ICalendar,
        Entities.NHibernate.CalendarAggregate.EdFi.Calendar,
        Api.Models.Requests.Calendars.EdFi.CalendarPut,
        Api.Models.Requests.Calendars.EdFi.CalendarPost,
        Api.Models.Requests.Calendars.EdFi.CalendarDelete,
        Api.Models.Requests.Calendars.EdFi.CalendarGetByExample>
    {
        public CalendarsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Calendars.EdFi.CalendarGetByExample request, ICalendar specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.CalendarTypeDescriptor = request.CalendarTypeDescriptor;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "calendars";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CalendarDates.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CalendarDatesController : EdFiControllerBase<
        Models.Resources.CalendarDate.EdFi.CalendarDate,
        Models.Resources.CalendarDate.EdFi.CalendarDate,
        Entities.Common.EdFi.ICalendarDate,
        Entities.NHibernate.CalendarDateAggregate.EdFi.CalendarDate,
        Api.Models.Requests.CalendarDates.EdFi.CalendarDatePut,
        Api.Models.Requests.CalendarDates.EdFi.CalendarDatePost,
        Api.Models.Requests.CalendarDates.EdFi.CalendarDateDelete,
        Api.Models.Requests.CalendarDates.EdFi.CalendarDateGetByExample>
    {
        public CalendarDatesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CalendarDates.EdFi.CalendarDateGetByExample request, ICalendarDate specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarCode = request.CalendarCode;
            specification.Date = request.Date;
            specification.Id = request.Id;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
                    }

        protected override string GetResourceCollectionName()
        {
            return "calendarDates";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CalendarEventDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CalendarEventDescriptorsController : EdFiControllerBase<
        Models.Resources.CalendarEventDescriptor.EdFi.CalendarEventDescriptor,
        Models.Resources.CalendarEventDescriptor.EdFi.CalendarEventDescriptor,
        Entities.Common.EdFi.ICalendarEventDescriptor,
        Entities.NHibernate.CalendarEventDescriptorAggregate.EdFi.CalendarEventDescriptor,
        Api.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorPut,
        Api.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorPost,
        Api.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorDelete,
        Api.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorGetByExample>
    {
        public CalendarEventDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CalendarEventDescriptors.EdFi.CalendarEventDescriptorGetByExample request, ICalendarEventDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarEventDescriptorId = request.CalendarEventDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "calendarEventDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CalendarTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CalendarTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CalendarTypeDescriptor.EdFi.CalendarTypeDescriptor,
        Models.Resources.CalendarTypeDescriptor.EdFi.CalendarTypeDescriptor,
        Entities.Common.EdFi.ICalendarTypeDescriptor,
        Entities.NHibernate.CalendarTypeDescriptorAggregate.EdFi.CalendarTypeDescriptor,
        Api.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorPut,
        Api.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorPost,
        Api.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorDelete,
        Api.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorGetByExample>
    {
        public CalendarTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CalendarTypeDescriptors.EdFi.CalendarTypeDescriptorGetByExample request, ICalendarTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CalendarTypeDescriptorId = request.CalendarTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "calendarTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CareerPathwayDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CareerPathwayDescriptorsController : EdFiControllerBase<
        Models.Resources.CareerPathwayDescriptor.EdFi.CareerPathwayDescriptor,
        Models.Resources.CareerPathwayDescriptor.EdFi.CareerPathwayDescriptor,
        Entities.Common.EdFi.ICareerPathwayDescriptor,
        Entities.NHibernate.CareerPathwayDescriptorAggregate.EdFi.CareerPathwayDescriptor,
        Api.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorPut,
        Api.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorPost,
        Api.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorDelete,
        Api.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorGetByExample>
    {
        public CareerPathwayDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CareerPathwayDescriptors.EdFi.CareerPathwayDescriptorGetByExample request, ICareerPathwayDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CareerPathwayDescriptorId = request.CareerPathwayDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "careerPathwayDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CharterApprovalAgencyTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CharterApprovalAgencyTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CharterApprovalAgencyTypeDescriptor.EdFi.CharterApprovalAgencyTypeDescriptor,
        Models.Resources.CharterApprovalAgencyTypeDescriptor.EdFi.CharterApprovalAgencyTypeDescriptor,
        Entities.Common.EdFi.ICharterApprovalAgencyTypeDescriptor,
        Entities.NHibernate.CharterApprovalAgencyTypeDescriptorAggregate.EdFi.CharterApprovalAgencyTypeDescriptor,
        Api.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorPut,
        Api.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorPost,
        Api.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorDelete,
        Api.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorGetByExample>
    {
        public CharterApprovalAgencyTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi.CharterApprovalAgencyTypeDescriptorGetByExample request, ICharterApprovalAgencyTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterApprovalAgencyTypeDescriptorId = request.CharterApprovalAgencyTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "charterApprovalAgencyTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CharterStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CharterStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.CharterStatusDescriptor.EdFi.CharterStatusDescriptor,
        Models.Resources.CharterStatusDescriptor.EdFi.CharterStatusDescriptor,
        Entities.Common.EdFi.ICharterStatusDescriptor,
        Entities.NHibernate.CharterStatusDescriptorAggregate.EdFi.CharterStatusDescriptor,
        Api.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorPut,
        Api.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorPost,
        Api.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorDelete,
        Api.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorGetByExample>
    {
        public CharterStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CharterStatusDescriptors.EdFi.CharterStatusDescriptorGetByExample request, ICharterStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CharterStatusDescriptorId = request.CharterStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "charterStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CitizenshipStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CitizenshipStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.CitizenshipStatusDescriptor.EdFi.CitizenshipStatusDescriptor,
        Models.Resources.CitizenshipStatusDescriptor.EdFi.CitizenshipStatusDescriptor,
        Entities.Common.EdFi.ICitizenshipStatusDescriptor,
        Entities.NHibernate.CitizenshipStatusDescriptorAggregate.EdFi.CitizenshipStatusDescriptor,
        Api.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorPut,
        Api.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorPost,
        Api.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorDelete,
        Api.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorGetByExample>
    {
        public CitizenshipStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CitizenshipStatusDescriptors.EdFi.CitizenshipStatusDescriptorGetByExample request, ICitizenshipStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CitizenshipStatusDescriptorId = request.CitizenshipStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "citizenshipStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ClassPeriods.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ClassPeriodsController : EdFiControllerBase<
        Models.Resources.ClassPeriod.EdFi.ClassPeriod,
        Models.Resources.ClassPeriod.EdFi.ClassPeriod,
        Entities.Common.EdFi.IClassPeriod,
        Entities.NHibernate.ClassPeriodAggregate.EdFi.ClassPeriod,
        Api.Models.Requests.ClassPeriods.EdFi.ClassPeriodPut,
        Api.Models.Requests.ClassPeriods.EdFi.ClassPeriodPost,
        Api.Models.Requests.ClassPeriods.EdFi.ClassPeriodDelete,
        Api.Models.Requests.ClassPeriods.EdFi.ClassPeriodGetByExample>
    {
        public ClassPeriodsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ClassPeriods.EdFi.ClassPeriodGetByExample request, IClassPeriod specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassPeriodName = request.ClassPeriodName;
            specification.Id = request.Id;
            specification.OfficialAttendancePeriod = request.OfficialAttendancePeriod;
            specification.SchoolId = request.SchoolId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "classPeriods";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ClassroomPositionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ClassroomPositionDescriptorsController : EdFiControllerBase<
        Models.Resources.ClassroomPositionDescriptor.EdFi.ClassroomPositionDescriptor,
        Models.Resources.ClassroomPositionDescriptor.EdFi.ClassroomPositionDescriptor,
        Entities.Common.EdFi.IClassroomPositionDescriptor,
        Entities.NHibernate.ClassroomPositionDescriptorAggregate.EdFi.ClassroomPositionDescriptor,
        Api.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorPut,
        Api.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorPost,
        Api.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorDelete,
        Api.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorGetByExample>
    {
        public ClassroomPositionDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ClassroomPositionDescriptors.EdFi.ClassroomPositionDescriptorGetByExample request, IClassroomPositionDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassroomPositionDescriptorId = request.ClassroomPositionDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "classroomPositionDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Cohorts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CohortsController : EdFiControllerBase<
        Models.Resources.Cohort.EdFi.Cohort,
        Models.Resources.Cohort.EdFi.Cohort,
        Entities.Common.EdFi.ICohort,
        Entities.NHibernate.CohortAggregate.EdFi.Cohort,
        Api.Models.Requests.Cohorts.EdFi.CohortPut,
        Api.Models.Requests.Cohorts.EdFi.CohortPost,
        Api.Models.Requests.Cohorts.EdFi.CohortDelete,
        Api.Models.Requests.Cohorts.EdFi.CohortGetByExample>
    {
        public CohortsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Cohorts.EdFi.CohortGetByExample request, ICohort specification)
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

        protected override string GetResourceCollectionName()
        {
            return "cohorts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CohortScopeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CohortScopeDescriptorsController : EdFiControllerBase<
        Models.Resources.CohortScopeDescriptor.EdFi.CohortScopeDescriptor,
        Models.Resources.CohortScopeDescriptor.EdFi.CohortScopeDescriptor,
        Entities.Common.EdFi.ICohortScopeDescriptor,
        Entities.NHibernate.CohortScopeDescriptorAggregate.EdFi.CohortScopeDescriptor,
        Api.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorPut,
        Api.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorPost,
        Api.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorDelete,
        Api.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorGetByExample>
    {
        public CohortScopeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CohortScopeDescriptors.EdFi.CohortScopeDescriptorGetByExample request, ICohortScopeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortScopeDescriptorId = request.CohortScopeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "cohortScopeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CohortTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CohortTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CohortTypeDescriptor.EdFi.CohortTypeDescriptor,
        Models.Resources.CohortTypeDescriptor.EdFi.CohortTypeDescriptor,
        Entities.Common.EdFi.ICohortTypeDescriptor,
        Entities.NHibernate.CohortTypeDescriptorAggregate.EdFi.CohortTypeDescriptor,
        Api.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorPut,
        Api.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorPost,
        Api.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorDelete,
        Api.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorGetByExample>
    {
        public CohortTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CohortTypeDescriptors.EdFi.CohortTypeDescriptorGetByExample request, ICohortTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortTypeDescriptorId = request.CohortTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "cohortTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CohortYearTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CohortYearTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CohortYearTypeDescriptor.EdFi.CohortYearTypeDescriptor,
        Models.Resources.CohortYearTypeDescriptor.EdFi.CohortYearTypeDescriptor,
        Entities.Common.EdFi.ICohortYearTypeDescriptor,
        Entities.NHibernate.CohortYearTypeDescriptorAggregate.EdFi.CohortYearTypeDescriptor,
        Api.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorPut,
        Api.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorPost,
        Api.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorDelete,
        Api.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorGetByExample>
    {
        public CohortYearTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CohortYearTypeDescriptors.EdFi.CohortYearTypeDescriptorGetByExample request, ICohortYearTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CohortYearTypeDescriptorId = request.CohortYearTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "cohortYearTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CommunityOrganizations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CommunityOrganizationsController : EdFiControllerBase<
        Models.Resources.CommunityOrganization.EdFi.CommunityOrganization,
        Models.Resources.CommunityOrganization.EdFi.CommunityOrganization,
        Entities.Common.EdFi.ICommunityOrganization,
        Entities.NHibernate.CommunityOrganizationAggregate.EdFi.CommunityOrganization,
        Api.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationPut,
        Api.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationPost,
        Api.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationDelete,
        Api.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationGetByExample>
    {
        public CommunityOrganizationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CommunityOrganizations.EdFi.CommunityOrganizationGetByExample request, ICommunityOrganization specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CommunityOrganizationId = request.CommunityOrganizationId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "communityOrganizations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CommunityProviders.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CommunityProvidersController : EdFiControllerBase<
        Models.Resources.CommunityProvider.EdFi.CommunityProvider,
        Models.Resources.CommunityProvider.EdFi.CommunityProvider,
        Entities.Common.EdFi.ICommunityProvider,
        Entities.NHibernate.CommunityProviderAggregate.EdFi.CommunityProvider,
        Api.Models.Requests.CommunityProviders.EdFi.CommunityProviderPut,
        Api.Models.Requests.CommunityProviders.EdFi.CommunityProviderPost,
        Api.Models.Requests.CommunityProviders.EdFi.CommunityProviderDelete,
        Api.Models.Requests.CommunityProviders.EdFi.CommunityProviderGetByExample>
    {
        public CommunityProvidersController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CommunityProviders.EdFi.CommunityProviderGetByExample request, ICommunityProvider specification)
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

        protected override string GetResourceCollectionName()
        {
            return "communityProviders";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CommunityProviderLicenses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CommunityProviderLicensesController : EdFiControllerBase<
        Models.Resources.CommunityProviderLicense.EdFi.CommunityProviderLicense,
        Models.Resources.CommunityProviderLicense.EdFi.CommunityProviderLicense,
        Entities.Common.EdFi.ICommunityProviderLicense,
        Entities.NHibernate.CommunityProviderLicenseAggregate.EdFi.CommunityProviderLicense,
        Api.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicensePut,
        Api.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicensePost,
        Api.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicenseDelete,
        Api.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicenseGetByExample>
    {
        public CommunityProviderLicensesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CommunityProviderLicenses.EdFi.CommunityProviderLicenseGetByExample request, ICommunityProviderLicense specification)
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

        protected override string GetResourceCollectionName()
        {
            return "communityProviderLicenses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CompetencyLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CompetencyLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor,
        Models.Resources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor,
        Entities.Common.EdFi.ICompetencyLevelDescriptor,
        Entities.NHibernate.CompetencyLevelDescriptorAggregate.EdFi.CompetencyLevelDescriptor,
        Api.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorPut,
        Api.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorPost,
        Api.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorDelete,
        Api.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorGetByExample>
    {
        public CompetencyLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CompetencyLevelDescriptors.EdFi.CompetencyLevelDescriptorGetByExample request, ICompetencyLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CompetencyLevelDescriptorId = request.CompetencyLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "competencyLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CompetencyObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CompetencyObjectivesController : EdFiControllerBase<
        Models.Resources.CompetencyObjective.EdFi.CompetencyObjective,
        Models.Resources.CompetencyObjective.EdFi.CompetencyObjective,
        Entities.Common.EdFi.ICompetencyObjective,
        Entities.NHibernate.CompetencyObjectiveAggregate.EdFi.CompetencyObjective,
        Api.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectivePut,
        Api.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectivePost,
        Api.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectiveDelete,
        Api.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectiveGetByExample>
    {
        public CompetencyObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CompetencyObjectives.EdFi.CompetencyObjectiveGetByExample request, ICompetencyObjective specification)
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

        protected override string GetResourceCollectionName()
        {
            return "competencyObjectives";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContactTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ContactTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ContactTypeDescriptor.EdFi.ContactTypeDescriptor,
        Models.Resources.ContactTypeDescriptor.EdFi.ContactTypeDescriptor,
        Entities.Common.EdFi.IContactTypeDescriptor,
        Entities.NHibernate.ContactTypeDescriptorAggregate.EdFi.ContactTypeDescriptor,
        Api.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorPut,
        Api.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorPost,
        Api.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorDelete,
        Api.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorGetByExample>
    {
        public ContactTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ContactTypeDescriptors.EdFi.ContactTypeDescriptorGetByExample request, IContactTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContactTypeDescriptorId = request.ContactTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "contactTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContentClassDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ContentClassDescriptorsController : EdFiControllerBase<
        Models.Resources.ContentClassDescriptor.EdFi.ContentClassDescriptor,
        Models.Resources.ContentClassDescriptor.EdFi.ContentClassDescriptor,
        Entities.Common.EdFi.IContentClassDescriptor,
        Entities.NHibernate.ContentClassDescriptorAggregate.EdFi.ContentClassDescriptor,
        Api.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorPut,
        Api.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorPost,
        Api.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorDelete,
        Api.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorGetByExample>
    {
        public ContentClassDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ContentClassDescriptors.EdFi.ContentClassDescriptorGetByExample request, IContentClassDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContentClassDescriptorId = request.ContentClassDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "contentClassDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContinuationOfServicesReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ContinuationOfServicesReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.ContinuationOfServicesReasonDescriptor.EdFi.ContinuationOfServicesReasonDescriptor,
        Models.Resources.ContinuationOfServicesReasonDescriptor.EdFi.ContinuationOfServicesReasonDescriptor,
        Entities.Common.EdFi.IContinuationOfServicesReasonDescriptor,
        Entities.NHibernate.ContinuationOfServicesReasonDescriptorAggregate.EdFi.ContinuationOfServicesReasonDescriptor,
        Api.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorPut,
        Api.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorPost,
        Api.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorDelete,
        Api.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorGetByExample>
    {
        public ContinuationOfServicesReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi.ContinuationOfServicesReasonDescriptorGetByExample request, IContinuationOfServicesReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContinuationOfServicesReasonDescriptorId = request.ContinuationOfServicesReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "continuationOfServicesReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ContractedStaffs.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ContractedStaffsController : EdFiControllerBase<
        Models.Resources.ContractedStaff.EdFi.ContractedStaff,
        Models.Resources.ContractedStaff.EdFi.ContractedStaff,
        Entities.Common.EdFi.IContractedStaff,
        Entities.NHibernate.ContractedStaffAggregate.EdFi.ContractedStaff,
        Api.Models.Requests.ContractedStaffs.EdFi.ContractedStaffPut,
        Api.Models.Requests.ContractedStaffs.EdFi.ContractedStaffPost,
        Api.Models.Requests.ContractedStaffs.EdFi.ContractedStaffDelete,
        Api.Models.Requests.ContractedStaffs.EdFi.ContractedStaffGetByExample>
    {
        public ContractedStaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ContractedStaffs.EdFi.ContractedStaffGetByExample request, IContractedStaff specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.AmountToDate = request.AmountToDate;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "contractedStaffs";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CostRateDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CostRateDescriptorsController : EdFiControllerBase<
        Models.Resources.CostRateDescriptor.EdFi.CostRateDescriptor,
        Models.Resources.CostRateDescriptor.EdFi.CostRateDescriptor,
        Entities.Common.EdFi.ICostRateDescriptor,
        Entities.NHibernate.CostRateDescriptorAggregate.EdFi.CostRateDescriptor,
        Api.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorPut,
        Api.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorPost,
        Api.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorDelete,
        Api.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorGetByExample>
    {
        public CostRateDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CostRateDescriptors.EdFi.CostRateDescriptorGetByExample request, ICostRateDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CostRateDescriptorId = request.CostRateDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "costRateDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CountryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CountryDescriptorsController : EdFiControllerBase<
        Models.Resources.CountryDescriptor.EdFi.CountryDescriptor,
        Models.Resources.CountryDescriptor.EdFi.CountryDescriptor,
        Entities.Common.EdFi.ICountryDescriptor,
        Entities.NHibernate.CountryDescriptorAggregate.EdFi.CountryDescriptor,
        Api.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorPut,
        Api.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorPost,
        Api.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorDelete,
        Api.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorGetByExample>
    {
        public CountryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CountryDescriptors.EdFi.CountryDescriptorGetByExample request, ICountryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CountryDescriptorId = request.CountryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "countryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Courses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CoursesController : EdFiControllerBase<
        Models.Resources.Course.EdFi.Course,
        Models.Resources.Course.EdFi.Course,
        Entities.Common.EdFi.ICourse,
        Entities.NHibernate.CourseAggregate.EdFi.Course,
        Api.Models.Requests.Courses.EdFi.CoursePut,
        Api.Models.Requests.Courses.EdFi.CoursePost,
        Api.Models.Requests.Courses.EdFi.CourseDelete,
        Api.Models.Requests.Courses.EdFi.CourseGetByExample>
    {
        public CoursesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Courses.EdFi.CourseGetByExample request, ICourse specification)
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

        protected override string GetResourceCollectionName()
        {
            return "courses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseAttemptResultDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseAttemptResultDescriptorsController : EdFiControllerBase<
        Models.Resources.CourseAttemptResultDescriptor.EdFi.CourseAttemptResultDescriptor,
        Models.Resources.CourseAttemptResultDescriptor.EdFi.CourseAttemptResultDescriptor,
        Entities.Common.EdFi.ICourseAttemptResultDescriptor,
        Entities.NHibernate.CourseAttemptResultDescriptorAggregate.EdFi.CourseAttemptResultDescriptor,
        Api.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorPut,
        Api.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorPost,
        Api.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorDelete,
        Api.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorGetByExample>
    {
        public CourseAttemptResultDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseAttemptResultDescriptors.EdFi.CourseAttemptResultDescriptorGetByExample request, ICourseAttemptResultDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseAttemptResultDescriptorId = request.CourseAttemptResultDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseAttemptResultDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseDefinedByDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseDefinedByDescriptorsController : EdFiControllerBase<
        Models.Resources.CourseDefinedByDescriptor.EdFi.CourseDefinedByDescriptor,
        Models.Resources.CourseDefinedByDescriptor.EdFi.CourseDefinedByDescriptor,
        Entities.Common.EdFi.ICourseDefinedByDescriptor,
        Entities.NHibernate.CourseDefinedByDescriptorAggregate.EdFi.CourseDefinedByDescriptor,
        Api.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorPut,
        Api.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorPost,
        Api.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorDelete,
        Api.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorGetByExample>
    {
        public CourseDefinedByDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseDefinedByDescriptors.EdFi.CourseDefinedByDescriptorGetByExample request, ICourseDefinedByDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseDefinedByDescriptorId = request.CourseDefinedByDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseDefinedByDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseGPAApplicabilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseGPAApplicabilityDescriptorsController : EdFiControllerBase<
        Models.Resources.CourseGPAApplicabilityDescriptor.EdFi.CourseGPAApplicabilityDescriptor,
        Models.Resources.CourseGPAApplicabilityDescriptor.EdFi.CourseGPAApplicabilityDescriptor,
        Entities.Common.EdFi.ICourseGPAApplicabilityDescriptor,
        Entities.NHibernate.CourseGPAApplicabilityDescriptorAggregate.EdFi.CourseGPAApplicabilityDescriptor,
        Api.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorPut,
        Api.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorPost,
        Api.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorDelete,
        Api.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorGetByExample>
    {
        public CourseGPAApplicabilityDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi.CourseGPAApplicabilityDescriptorGetByExample request, ICourseGPAApplicabilityDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseGPAApplicabilityDescriptorId = request.CourseGPAApplicabilityDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseGPAApplicabilityDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseIdentificationSystemDescriptorsController : EdFiControllerBase<
        Models.Resources.CourseIdentificationSystemDescriptor.EdFi.CourseIdentificationSystemDescriptor,
        Models.Resources.CourseIdentificationSystemDescriptor.EdFi.CourseIdentificationSystemDescriptor,
        Entities.Common.EdFi.ICourseIdentificationSystemDescriptor,
        Entities.NHibernate.CourseIdentificationSystemDescriptorAggregate.EdFi.CourseIdentificationSystemDescriptor,
        Api.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorPut,
        Api.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorPost,
        Api.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorDelete,
        Api.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorGetByExample>
    {
        public CourseIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseIdentificationSystemDescriptors.EdFi.CourseIdentificationSystemDescriptorGetByExample request, ICourseIdentificationSystemDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseIdentificationSystemDescriptorId = request.CourseIdentificationSystemDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseIdentificationSystemDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseLevelCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseLevelCharacteristicDescriptorsController : EdFiControllerBase<
        Models.Resources.CourseLevelCharacteristicDescriptor.EdFi.CourseLevelCharacteristicDescriptor,
        Models.Resources.CourseLevelCharacteristicDescriptor.EdFi.CourseLevelCharacteristicDescriptor,
        Entities.Common.EdFi.ICourseLevelCharacteristicDescriptor,
        Entities.NHibernate.CourseLevelCharacteristicDescriptorAggregate.EdFi.CourseLevelCharacteristicDescriptor,
        Api.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorPut,
        Api.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorPost,
        Api.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorDelete,
        Api.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorGetByExample>
    {
        public CourseLevelCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi.CourseLevelCharacteristicDescriptorGetByExample request, ICourseLevelCharacteristicDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseLevelCharacteristicDescriptorId = request.CourseLevelCharacteristicDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseLevelCharacteristicDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseOfferings.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseOfferingsController : EdFiControllerBase<
        Models.Resources.CourseOffering.EdFi.CourseOffering,
        Models.Resources.CourseOffering.EdFi.CourseOffering,
        Entities.Common.EdFi.ICourseOffering,
        Entities.NHibernate.CourseOfferingAggregate.EdFi.CourseOffering,
        Api.Models.Requests.CourseOfferings.EdFi.CourseOfferingPut,
        Api.Models.Requests.CourseOfferings.EdFi.CourseOfferingPost,
        Api.Models.Requests.CourseOfferings.EdFi.CourseOfferingDelete,
        Api.Models.Requests.CourseOfferings.EdFi.CourseOfferingGetByExample>
    {
        public CourseOfferingsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseOfferings.EdFi.CourseOfferingGetByExample request, ICourseOffering specification)
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

        protected override string GetResourceCollectionName()
        {
            return "courseOfferings";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseRepeatCodeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseRepeatCodeDescriptorsController : EdFiControllerBase<
        Models.Resources.CourseRepeatCodeDescriptor.EdFi.CourseRepeatCodeDescriptor,
        Models.Resources.CourseRepeatCodeDescriptor.EdFi.CourseRepeatCodeDescriptor,
        Entities.Common.EdFi.ICourseRepeatCodeDescriptor,
        Entities.NHibernate.CourseRepeatCodeDescriptorAggregate.EdFi.CourseRepeatCodeDescriptor,
        Api.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorPut,
        Api.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorPost,
        Api.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorDelete,
        Api.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorGetByExample>
    {
        public CourseRepeatCodeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseRepeatCodeDescriptors.EdFi.CourseRepeatCodeDescriptorGetByExample request, ICourseRepeatCodeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseRepeatCodeDescriptorId = request.CourseRepeatCodeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseRepeatCodeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CourseTranscripts.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CourseTranscriptsController : EdFiControllerBase<
        Models.Resources.CourseTranscript.EdFi.CourseTranscript,
        Models.Resources.CourseTranscript.EdFi.CourseTranscript,
        Entities.Common.EdFi.ICourseTranscript,
        Entities.NHibernate.CourseTranscriptAggregate.EdFi.CourseTranscript,
        Api.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptPut,
        Api.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptPost,
        Api.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptDelete,
        Api.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptGetByExample>
    {
        public CourseTranscriptsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CourseTranscripts.EdFi.CourseTranscriptGetByExample request, ICourseTranscript specification)
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
            specification.FinalLetterGradeEarned = request.FinalLetterGradeEarned;
            specification.FinalNumericGradeEarned = request.FinalNumericGradeEarned;
            specification.Id = request.Id;
            specification.MethodCreditEarnedDescriptor = request.MethodCreditEarnedDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.TermDescriptor = request.TermDescriptor;
            specification.WhenTakenGradeLevelDescriptor = request.WhenTakenGradeLevelDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "courseTranscripts";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Credentials.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CredentialsController : EdFiControllerBase<
        Models.Resources.Credential.EdFi.Credential,
        Models.Resources.Credential.EdFi.Credential,
        Entities.Common.EdFi.ICredential,
        Entities.NHibernate.CredentialAggregate.EdFi.Credential,
        Api.Models.Requests.Credentials.EdFi.CredentialPut,
        Api.Models.Requests.Credentials.EdFi.CredentialPost,
        Api.Models.Requests.Credentials.EdFi.CredentialDelete,
        Api.Models.Requests.Credentials.EdFi.CredentialGetByExample>
    {
        public CredentialsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Credentials.EdFi.CredentialGetByExample request, ICredential specification)
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

        protected override string GetResourceCollectionName()
        {
            return "credentials";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CredentialFieldDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CredentialFieldDescriptorsController : EdFiControllerBase<
        Models.Resources.CredentialFieldDescriptor.EdFi.CredentialFieldDescriptor,
        Models.Resources.CredentialFieldDescriptor.EdFi.CredentialFieldDescriptor,
        Entities.Common.EdFi.ICredentialFieldDescriptor,
        Entities.NHibernate.CredentialFieldDescriptorAggregate.EdFi.CredentialFieldDescriptor,
        Api.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorPut,
        Api.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorPost,
        Api.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorDelete,
        Api.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorGetByExample>
    {
        public CredentialFieldDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CredentialFieldDescriptors.EdFi.CredentialFieldDescriptorGetByExample request, ICredentialFieldDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialFieldDescriptorId = request.CredentialFieldDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "credentialFieldDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CredentialTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CredentialTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CredentialTypeDescriptor.EdFi.CredentialTypeDescriptor,
        Models.Resources.CredentialTypeDescriptor.EdFi.CredentialTypeDescriptor,
        Entities.Common.EdFi.ICredentialTypeDescriptor,
        Entities.NHibernate.CredentialTypeDescriptorAggregate.EdFi.CredentialTypeDescriptor,
        Api.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorPut,
        Api.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorPost,
        Api.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorDelete,
        Api.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorGetByExample>
    {
        public CredentialTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CredentialTypeDescriptors.EdFi.CredentialTypeDescriptorGetByExample request, ICredentialTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CredentialTypeDescriptorId = request.CredentialTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "credentialTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CreditCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CreditCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.CreditCategoryDescriptor.EdFi.CreditCategoryDescriptor,
        Models.Resources.CreditCategoryDescriptor.EdFi.CreditCategoryDescriptor,
        Entities.Common.EdFi.ICreditCategoryDescriptor,
        Entities.NHibernate.CreditCategoryDescriptorAggregate.EdFi.CreditCategoryDescriptor,
        Api.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorPut,
        Api.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorPost,
        Api.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorDelete,
        Api.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorGetByExample>
    {
        public CreditCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CreditCategoryDescriptors.EdFi.CreditCategoryDescriptorGetByExample request, ICreditCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CreditCategoryDescriptorId = request.CreditCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "creditCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CreditTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CreditTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.CreditTypeDescriptor.EdFi.CreditTypeDescriptor,
        Models.Resources.CreditTypeDescriptor.EdFi.CreditTypeDescriptor,
        Entities.Common.EdFi.ICreditTypeDescriptor,
        Entities.NHibernate.CreditTypeDescriptorAggregate.EdFi.CreditTypeDescriptor,
        Api.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorPut,
        Api.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorPost,
        Api.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorDelete,
        Api.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorGetByExample>
    {
        public CreditTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CreditTypeDescriptors.EdFi.CreditTypeDescriptorGetByExample request, ICreditTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CreditTypeDescriptorId = request.CreditTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "creditTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CTEProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CTEProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.CTEProgramServiceDescriptor.EdFi.CTEProgramServiceDescriptor,
        Models.Resources.CTEProgramServiceDescriptor.EdFi.CTEProgramServiceDescriptor,
        Entities.Common.EdFi.ICTEProgramServiceDescriptor,
        Entities.NHibernate.CTEProgramServiceDescriptorAggregate.EdFi.CTEProgramServiceDescriptor,
        Api.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorPut,
        Api.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorPost,
        Api.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorDelete,
        Api.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorGetByExample>
    {
        public CTEProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CTEProgramServiceDescriptors.EdFi.CTEProgramServiceDescriptorGetByExample request, ICTEProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CTEProgramServiceDescriptorId = request.CTEProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "cteProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.CurriculumUsedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class CurriculumUsedDescriptorsController : EdFiControllerBase<
        Models.Resources.CurriculumUsedDescriptor.EdFi.CurriculumUsedDescriptor,
        Models.Resources.CurriculumUsedDescriptor.EdFi.CurriculumUsedDescriptor,
        Entities.Common.EdFi.ICurriculumUsedDescriptor,
        Entities.NHibernate.CurriculumUsedDescriptorAggregate.EdFi.CurriculumUsedDescriptor,
        Api.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorPut,
        Api.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorPost,
        Api.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorDelete,
        Api.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorGetByExample>
    {
        public CurriculumUsedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.CurriculumUsedDescriptors.EdFi.CurriculumUsedDescriptorGetByExample request, ICurriculumUsedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CurriculumUsedDescriptorId = request.CurriculumUsedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "curriculumUsedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DeliveryMethodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DeliveryMethodDescriptorsController : EdFiControllerBase<
        Models.Resources.DeliveryMethodDescriptor.EdFi.DeliveryMethodDescriptor,
        Models.Resources.DeliveryMethodDescriptor.EdFi.DeliveryMethodDescriptor,
        Entities.Common.EdFi.IDeliveryMethodDescriptor,
        Entities.NHibernate.DeliveryMethodDescriptorAggregate.EdFi.DeliveryMethodDescriptor,
        Api.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorPut,
        Api.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorPost,
        Api.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorDelete,
        Api.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorGetByExample>
    {
        public DeliveryMethodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DeliveryMethodDescriptors.EdFi.DeliveryMethodDescriptorGetByExample request, IDeliveryMethodDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DeliveryMethodDescriptorId = request.DeliveryMethodDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "deliveryMethodDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DiagnosisDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DiagnosisDescriptorsController : EdFiControllerBase<
        Models.Resources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor,
        Models.Resources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor,
        Entities.Common.EdFi.IDiagnosisDescriptor,
        Entities.NHibernate.DiagnosisDescriptorAggregate.EdFi.DiagnosisDescriptor,
        Api.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorPut,
        Api.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorPost,
        Api.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorDelete,
        Api.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorGetByExample>
    {
        public DiagnosisDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DiagnosisDescriptors.EdFi.DiagnosisDescriptorGetByExample request, IDiagnosisDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DiagnosisDescriptorId = request.DiagnosisDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "diagnosisDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DiplomaLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DiplomaLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.DiplomaLevelDescriptor.EdFi.DiplomaLevelDescriptor,
        Models.Resources.DiplomaLevelDescriptor.EdFi.DiplomaLevelDescriptor,
        Entities.Common.EdFi.IDiplomaLevelDescriptor,
        Entities.NHibernate.DiplomaLevelDescriptorAggregate.EdFi.DiplomaLevelDescriptor,
        Api.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorPut,
        Api.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorPost,
        Api.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorDelete,
        Api.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorGetByExample>
    {
        public DiplomaLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DiplomaLevelDescriptors.EdFi.DiplomaLevelDescriptorGetByExample request, IDiplomaLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DiplomaLevelDescriptorId = request.DiplomaLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "diplomaLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DiplomaTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DiplomaTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.DiplomaTypeDescriptor.EdFi.DiplomaTypeDescriptor,
        Models.Resources.DiplomaTypeDescriptor.EdFi.DiplomaTypeDescriptor,
        Entities.Common.EdFi.IDiplomaTypeDescriptor,
        Entities.NHibernate.DiplomaTypeDescriptorAggregate.EdFi.DiplomaTypeDescriptor,
        Api.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorPut,
        Api.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorPost,
        Api.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorDelete,
        Api.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorGetByExample>
    {
        public DiplomaTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DiplomaTypeDescriptors.EdFi.DiplomaTypeDescriptorGetByExample request, IDiplomaTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DiplomaTypeDescriptorId = request.DiplomaTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "diplomaTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisabilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisabilityDescriptorsController : EdFiControllerBase<
        Models.Resources.DisabilityDescriptor.EdFi.DisabilityDescriptor,
        Models.Resources.DisabilityDescriptor.EdFi.DisabilityDescriptor,
        Entities.Common.EdFi.IDisabilityDescriptor,
        Entities.NHibernate.DisabilityDescriptorAggregate.EdFi.DisabilityDescriptor,
        Api.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorPut,
        Api.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorPost,
        Api.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorDelete,
        Api.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorGetByExample>
    {
        public DisabilityDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisabilityDescriptors.EdFi.DisabilityDescriptorGetByExample request, IDisabilityDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisabilityDescriptorId = request.DisabilityDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "disabilityDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisabilityDesignationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisabilityDesignationDescriptorsController : EdFiControllerBase<
        Models.Resources.DisabilityDesignationDescriptor.EdFi.DisabilityDesignationDescriptor,
        Models.Resources.DisabilityDesignationDescriptor.EdFi.DisabilityDesignationDescriptor,
        Entities.Common.EdFi.IDisabilityDesignationDescriptor,
        Entities.NHibernate.DisabilityDesignationDescriptorAggregate.EdFi.DisabilityDesignationDescriptor,
        Api.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorPut,
        Api.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorPost,
        Api.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorDelete,
        Api.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorGetByExample>
    {
        public DisabilityDesignationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisabilityDesignationDescriptors.EdFi.DisabilityDesignationDescriptorGetByExample request, IDisabilityDesignationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisabilityDesignationDescriptorId = request.DisabilityDesignationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "disabilityDesignationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisabilityDeterminationSourceTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisabilityDeterminationSourceTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.DisabilityDeterminationSourceTypeDescriptor.EdFi.DisabilityDeterminationSourceTypeDescriptor,
        Models.Resources.DisabilityDeterminationSourceTypeDescriptor.EdFi.DisabilityDeterminationSourceTypeDescriptor,
        Entities.Common.EdFi.IDisabilityDeterminationSourceTypeDescriptor,
        Entities.NHibernate.DisabilityDeterminationSourceTypeDescriptorAggregate.EdFi.DisabilityDeterminationSourceTypeDescriptor,
        Api.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorPut,
        Api.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorPost,
        Api.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorDelete,
        Api.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorGetByExample>
    {
        public DisabilityDeterminationSourceTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi.DisabilityDeterminationSourceTypeDescriptorGetByExample request, IDisabilityDeterminationSourceTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisabilityDeterminationSourceTypeDescriptorId = request.DisabilityDeterminationSourceTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "disabilityDeterminationSourceTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineActions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisciplineActionsController : EdFiControllerBase<
        Models.Resources.DisciplineAction.EdFi.DisciplineAction,
        Models.Resources.DisciplineAction.EdFi.DisciplineAction,
        Entities.Common.EdFi.IDisciplineAction,
        Entities.NHibernate.DisciplineActionAggregate.EdFi.DisciplineAction,
        Api.Models.Requests.DisciplineActions.EdFi.DisciplineActionPut,
        Api.Models.Requests.DisciplineActions.EdFi.DisciplineActionPost,
        Api.Models.Requests.DisciplineActions.EdFi.DisciplineActionDelete,
        Api.Models.Requests.DisciplineActions.EdFi.DisciplineActionGetByExample>
    {
        public DisciplineActionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisciplineActions.EdFi.DisciplineActionGetByExample request, IDisciplineAction specification)
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

        protected override string GetResourceCollectionName()
        {
            return "disciplineActions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineActionLengthDifferenceReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisciplineActionLengthDifferenceReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.DisciplineActionLengthDifferenceReasonDescriptor.EdFi.DisciplineActionLengthDifferenceReasonDescriptor,
        Models.Resources.DisciplineActionLengthDifferenceReasonDescriptor.EdFi.DisciplineActionLengthDifferenceReasonDescriptor,
        Entities.Common.EdFi.IDisciplineActionLengthDifferenceReasonDescriptor,
        Entities.NHibernate.DisciplineActionLengthDifferenceReasonDescriptorAggregate.EdFi.DisciplineActionLengthDifferenceReasonDescriptor,
        Api.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorPut,
        Api.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorPost,
        Api.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorDelete,
        Api.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorGetByExample>
    {
        public DisciplineActionLengthDifferenceReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi.DisciplineActionLengthDifferenceReasonDescriptorGetByExample request, IDisciplineActionLengthDifferenceReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisciplineActionLengthDifferenceReasonDescriptorId = request.DisciplineActionLengthDifferenceReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "disciplineActionLengthDifferenceReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisciplineDescriptorsController : EdFiControllerBase<
        Models.Resources.DisciplineDescriptor.EdFi.DisciplineDescriptor,
        Models.Resources.DisciplineDescriptor.EdFi.DisciplineDescriptor,
        Entities.Common.EdFi.IDisciplineDescriptor,
        Entities.NHibernate.DisciplineDescriptorAggregate.EdFi.DisciplineDescriptor,
        Api.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorPut,
        Api.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorPost,
        Api.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorDelete,
        Api.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorGetByExample>
    {
        public DisciplineDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisciplineDescriptors.EdFi.DisciplineDescriptorGetByExample request, IDisciplineDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisciplineDescriptorId = request.DisciplineDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "disciplineDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineIncidents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisciplineIncidentsController : EdFiControllerBase<
        Models.Resources.DisciplineIncident.EdFi.DisciplineIncident,
        Models.Resources.DisciplineIncident.EdFi.DisciplineIncident,
        Entities.Common.EdFi.IDisciplineIncident,
        Entities.NHibernate.DisciplineIncidentAggregate.EdFi.DisciplineIncident,
        Api.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentPut,
        Api.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentPost,
        Api.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentDelete,
        Api.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentGetByExample>
    {
        public DisciplineIncidentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisciplineIncidents.EdFi.DisciplineIncidentGetByExample request, IDisciplineIncident specification)
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

        protected override string GetResourceCollectionName()
        {
            return "disciplineIncidents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.DisciplineIncidentParticipationCodeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class DisciplineIncidentParticipationCodeDescriptorsController : EdFiControllerBase<
        Models.Resources.DisciplineIncidentParticipationCodeDescriptor.EdFi.DisciplineIncidentParticipationCodeDescriptor,
        Models.Resources.DisciplineIncidentParticipationCodeDescriptor.EdFi.DisciplineIncidentParticipationCodeDescriptor,
        Entities.Common.EdFi.IDisciplineIncidentParticipationCodeDescriptor,
        Entities.NHibernate.DisciplineIncidentParticipationCodeDescriptorAggregate.EdFi.DisciplineIncidentParticipationCodeDescriptor,
        Api.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorPut,
        Api.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorPost,
        Api.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorDelete,
        Api.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorGetByExample>
    {
        public DisciplineIncidentParticipationCodeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi.DisciplineIncidentParticipationCodeDescriptorGetByExample request, IDisciplineIncidentParticipationCodeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DisciplineIncidentParticipationCodeDescriptorId = request.DisciplineIncidentParticipationCodeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "disciplineIncidentParticipationCodeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationalEnvironmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationalEnvironmentDescriptorsController : EdFiControllerBase<
        Models.Resources.EducationalEnvironmentDescriptor.EdFi.EducationalEnvironmentDescriptor,
        Models.Resources.EducationalEnvironmentDescriptor.EdFi.EducationalEnvironmentDescriptor,
        Entities.Common.EdFi.IEducationalEnvironmentDescriptor,
        Entities.NHibernate.EducationalEnvironmentDescriptorAggregate.EdFi.EducationalEnvironmentDescriptor,
        Api.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorPut,
        Api.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorPost,
        Api.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorDelete,
        Api.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorGetByExample>
    {
        public EducationalEnvironmentDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationalEnvironmentDescriptors.EdFi.EducationalEnvironmentDescriptorGetByExample request, IEducationalEnvironmentDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationalEnvironmentDescriptorId = request.EducationalEnvironmentDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationalEnvironmentDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationContents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationContentsController : EdFiControllerBase<
        Models.Resources.EducationContent.EdFi.EducationContent,
        Models.Resources.EducationContent.EdFi.EducationContent,
        Entities.Common.EdFi.IEducationContent,
        Entities.NHibernate.EducationContentAggregate.EdFi.EducationContent,
        Api.Models.Requests.EducationContents.EdFi.EducationContentPut,
        Api.Models.Requests.EducationContents.EdFi.EducationContentPost,
        Api.Models.Requests.EducationContents.EdFi.EducationContentDelete,
        Api.Models.Requests.EducationContents.EdFi.EducationContentGetByExample>
    {
        public EducationContentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationContents.EdFi.EducationContentGetByExample request, IEducationContent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "educationContents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationCategoryDescriptor.EdFi.EducationOrganizationCategoryDescriptor,
        Models.Resources.EducationOrganizationCategoryDescriptor.EdFi.EducationOrganizationCategoryDescriptor,
        Entities.Common.EdFi.IEducationOrganizationCategoryDescriptor,
        Entities.NHibernate.EducationOrganizationCategoryDescriptorAggregate.EdFi.EducationOrganizationCategoryDescriptor,
        Api.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorPut,
        Api.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorPost,
        Api.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorDelete,
        Api.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorGetByExample>
    {
        public EducationOrganizationCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi.EducationOrganizationCategoryDescriptorGetByExample request, IEducationOrganizationCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationCategoryDescriptorId = request.EducationOrganizationCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationIdentificationSystemDescriptorsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationIdentificationSystemDescriptor.EdFi.EducationOrganizationIdentificationSystemDescriptor,
        Models.Resources.EducationOrganizationIdentificationSystemDescriptor.EdFi.EducationOrganizationIdentificationSystemDescriptor,
        Entities.Common.EdFi.IEducationOrganizationIdentificationSystemDescriptor,
        Entities.NHibernate.EducationOrganizationIdentificationSystemDescriptorAggregate.EdFi.EducationOrganizationIdentificationSystemDescriptor,
        Api.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorPut,
        Api.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorPost,
        Api.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorDelete,
        Api.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorGetByExample>
    {
        public EducationOrganizationIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi.EducationOrganizationIdentificationSystemDescriptorGetByExample request, IEducationOrganizationIdentificationSystemDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationIdentificationSystemDescriptorId = request.EducationOrganizationIdentificationSystemDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationIdentificationSystemDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationInterventionPrescriptionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationInterventionPrescriptionAssociationsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationInterventionPrescriptionAssociation.EdFi.EducationOrganizationInterventionPrescriptionAssociation,
        Models.Resources.EducationOrganizationInterventionPrescriptionAssociation.EdFi.EducationOrganizationInterventionPrescriptionAssociation,
        Entities.Common.EdFi.IEducationOrganizationInterventionPrescriptionAssociation,
        Entities.NHibernate.EducationOrganizationInterventionPrescriptionAssociationAggregate.EdFi.EducationOrganizationInterventionPrescriptionAssociation,
        Api.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationPut,
        Api.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationPost,
        Api.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationDelete,
        Api.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationGetByExample>
    {
        public EducationOrganizationInterventionPrescriptionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi.EducationOrganizationInterventionPrescriptionAssociationGetByExample request, IEducationOrganizationInterventionPrescriptionAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationInterventionPrescriptionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationNetworks.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationNetworksController : EdFiControllerBase<
        Models.Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork,
        Models.Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork,
        Entities.Common.EdFi.IEducationOrganizationNetwork,
        Entities.NHibernate.EducationOrganizationNetworkAggregate.EdFi.EducationOrganizationNetwork,
        Api.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkPut,
        Api.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkPost,
        Api.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkDelete,
        Api.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkGetByExample>
    {
        public EducationOrganizationNetworksController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationOrganizationNetworks.EdFi.EducationOrganizationNetworkGetByExample request, IEducationOrganizationNetwork specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationNetworkId = request.EducationOrganizationNetworkId;
            specification.NetworkPurposeDescriptor = request.NetworkPurposeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationNetworks";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationNetworkAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationNetworkAssociationsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation,
        Models.Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation,
        Entities.Common.EdFi.IEducationOrganizationNetworkAssociation,
        Entities.NHibernate.EducationOrganizationNetworkAssociationAggregate.EdFi.EducationOrganizationNetworkAssociation,
        Api.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationPut,
        Api.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationPost,
        Api.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationDelete,
        Api.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationGetByExample>
    {
        public EducationOrganizationNetworkAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationOrganizationNetworkAssociations.EdFi.EducationOrganizationNetworkAssociationGetByExample request, IEducationOrganizationNetworkAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.EducationOrganizationNetworkId = request.EducationOrganizationNetworkId;
            specification.EndDate = request.EndDate;
            specification.Id = request.Id;
            specification.MemberEducationOrganizationId = request.MemberEducationOrganizationId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationNetworkAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationOrganizationPeerAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationOrganizationPeerAssociationsController : EdFiControllerBase<
        Models.Resources.EducationOrganizationPeerAssociation.EdFi.EducationOrganizationPeerAssociation,
        Models.Resources.EducationOrganizationPeerAssociation.EdFi.EducationOrganizationPeerAssociation,
        Entities.Common.EdFi.IEducationOrganizationPeerAssociation,
        Entities.NHibernate.EducationOrganizationPeerAssociationAggregate.EdFi.EducationOrganizationPeerAssociation,
        Api.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationPut,
        Api.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationPost,
        Api.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationDelete,
        Api.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationGetByExample>
    {
        public EducationOrganizationPeerAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationOrganizationPeerAssociations.EdFi.EducationOrganizationPeerAssociationGetByExample request, IEducationOrganizationPeerAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.PeerEducationOrganizationId = request.PeerEducationOrganizationId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationOrganizationPeerAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationPlanDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationPlanDescriptorsController : EdFiControllerBase<
        Models.Resources.EducationPlanDescriptor.EdFi.EducationPlanDescriptor,
        Models.Resources.EducationPlanDescriptor.EdFi.EducationPlanDescriptor,
        Entities.Common.EdFi.IEducationPlanDescriptor,
        Entities.NHibernate.EducationPlanDescriptorAggregate.EdFi.EducationPlanDescriptor,
        Api.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorPut,
        Api.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorPost,
        Api.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorDelete,
        Api.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorGetByExample>
    {
        public EducationPlanDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationPlanDescriptors.EdFi.EducationPlanDescriptorGetByExample request, IEducationPlanDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationPlanDescriptorId = request.EducationPlanDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationPlanDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EducationServiceCenters.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EducationServiceCentersController : EdFiControllerBase<
        Models.Resources.EducationServiceCenter.EdFi.EducationServiceCenter,
        Models.Resources.EducationServiceCenter.EdFi.EducationServiceCenter,
        Entities.Common.EdFi.IEducationServiceCenter,
        Entities.NHibernate.EducationServiceCenterAggregate.EdFi.EducationServiceCenter,
        Api.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterPut,
        Api.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterPost,
        Api.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterDelete,
        Api.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterGetByExample>
    {
        public EducationServiceCentersController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EducationServiceCenters.EdFi.EducationServiceCenterGetByExample request, IEducationServiceCenter specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationServiceCenterId = request.EducationServiceCenterId;
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "educationServiceCenters";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ElectronicMailTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ElectronicMailTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ElectronicMailTypeDescriptor.EdFi.ElectronicMailTypeDescriptor,
        Models.Resources.ElectronicMailTypeDescriptor.EdFi.ElectronicMailTypeDescriptor,
        Entities.Common.EdFi.IElectronicMailTypeDescriptor,
        Entities.NHibernate.ElectronicMailTypeDescriptorAggregate.EdFi.ElectronicMailTypeDescriptor,
        Api.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorPut,
        Api.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorPost,
        Api.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorDelete,
        Api.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorGetByExample>
    {
        public ElectronicMailTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ElectronicMailTypeDescriptors.EdFi.ElectronicMailTypeDescriptorGetByExample request, IElectronicMailTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ElectronicMailTypeDescriptorId = request.ElectronicMailTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "electronicMailTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EmploymentStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EmploymentStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.EmploymentStatusDescriptor.EdFi.EmploymentStatusDescriptor,
        Models.Resources.EmploymentStatusDescriptor.EdFi.EmploymentStatusDescriptor,
        Entities.Common.EdFi.IEmploymentStatusDescriptor,
        Entities.NHibernate.EmploymentStatusDescriptorAggregate.EdFi.EmploymentStatusDescriptor,
        Api.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorPut,
        Api.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorPost,
        Api.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorDelete,
        Api.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorGetByExample>
    {
        public EmploymentStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EmploymentStatusDescriptors.EdFi.EmploymentStatusDescriptorGetByExample request, IEmploymentStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EmploymentStatusDescriptorId = request.EmploymentStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "employmentStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EntryGradeLevelReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EntryGradeLevelReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.EntryGradeLevelReasonDescriptor.EdFi.EntryGradeLevelReasonDescriptor,
        Models.Resources.EntryGradeLevelReasonDescriptor.EdFi.EntryGradeLevelReasonDescriptor,
        Entities.Common.EdFi.IEntryGradeLevelReasonDescriptor,
        Entities.NHibernate.EntryGradeLevelReasonDescriptorAggregate.EdFi.EntryGradeLevelReasonDescriptor,
        Api.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorPut,
        Api.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorPost,
        Api.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorDelete,
        Api.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorGetByExample>
    {
        public EntryGradeLevelReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi.EntryGradeLevelReasonDescriptorGetByExample request, IEntryGradeLevelReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EntryGradeLevelReasonDescriptorId = request.EntryGradeLevelReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "entryGradeLevelReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EntryTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EntryTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.EntryTypeDescriptor.EdFi.EntryTypeDescriptor,
        Models.Resources.EntryTypeDescriptor.EdFi.EntryTypeDescriptor,
        Entities.Common.EdFi.IEntryTypeDescriptor,
        Entities.NHibernate.EntryTypeDescriptorAggregate.EdFi.EntryTypeDescriptor,
        Api.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorPut,
        Api.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorPost,
        Api.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorDelete,
        Api.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorGetByExample>
    {
        public EntryTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EntryTypeDescriptors.EdFi.EntryTypeDescriptorGetByExample request, IEntryTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EntryTypeDescriptorId = request.EntryTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "entryTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.EventCircumstanceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class EventCircumstanceDescriptorsController : EdFiControllerBase<
        Models.Resources.EventCircumstanceDescriptor.EdFi.EventCircumstanceDescriptor,
        Models.Resources.EventCircumstanceDescriptor.EdFi.EventCircumstanceDescriptor,
        Entities.Common.EdFi.IEventCircumstanceDescriptor,
        Entities.NHibernate.EventCircumstanceDescriptorAggregate.EdFi.EventCircumstanceDescriptor,
        Api.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorPut,
        Api.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorPost,
        Api.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorDelete,
        Api.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorGetByExample>
    {
        public EventCircumstanceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.EventCircumstanceDescriptors.EdFi.EventCircumstanceDescriptorGetByExample request, IEventCircumstanceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EventCircumstanceDescriptorId = request.EventCircumstanceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "eventCircumstanceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ExitWithdrawTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ExitWithdrawTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ExitWithdrawTypeDescriptor.EdFi.ExitWithdrawTypeDescriptor,
        Models.Resources.ExitWithdrawTypeDescriptor.EdFi.ExitWithdrawTypeDescriptor,
        Entities.Common.EdFi.IExitWithdrawTypeDescriptor,
        Entities.NHibernate.ExitWithdrawTypeDescriptorAggregate.EdFi.ExitWithdrawTypeDescriptor,
        Api.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorPut,
        Api.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorPost,
        Api.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorDelete,
        Api.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorGetByExample>
    {
        public ExitWithdrawTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ExitWithdrawTypeDescriptors.EdFi.ExitWithdrawTypeDescriptorGetByExample request, IExitWithdrawTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ExitWithdrawTypeDescriptorId = request.ExitWithdrawTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "exitWithdrawTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.FeederSchoolAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class FeederSchoolAssociationsController : EdFiControllerBase<
        Models.Resources.FeederSchoolAssociation.EdFi.FeederSchoolAssociation,
        Models.Resources.FeederSchoolAssociation.EdFi.FeederSchoolAssociation,
        Entities.Common.EdFi.IFeederSchoolAssociation,
        Entities.NHibernate.FeederSchoolAssociationAggregate.EdFi.FeederSchoolAssociation,
        Api.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationPut,
        Api.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationPost,
        Api.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationDelete,
        Api.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationGetByExample>
    {
        public FeederSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.FeederSchoolAssociations.EdFi.FeederSchoolAssociationGetByExample request, IFeederSchoolAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "feederSchoolAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Grades.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradesController : EdFiControllerBase<
        Models.Resources.Grade.EdFi.Grade,
        Models.Resources.Grade.EdFi.Grade,
        Entities.Common.EdFi.IGrade,
        Entities.NHibernate.GradeAggregate.EdFi.Grade,
        Api.Models.Requests.Grades.EdFi.GradePut,
        Api.Models.Requests.Grades.EdFi.GradePost,
        Api.Models.Requests.Grades.EdFi.GradeDelete,
        Api.Models.Requests.Grades.EdFi.GradeGetByExample>
    {
        public GradesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Grades.EdFi.GradeGetByExample request, IGrade specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
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

        protected override string GetResourceCollectionName()
        {
            return "grades";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradebookEntries.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradebookEntriesController : EdFiControllerBase<
        Models.Resources.GradebookEntry.EdFi.GradebookEntry,
        Models.Resources.GradebookEntry.EdFi.GradebookEntry,
        Entities.Common.EdFi.IGradebookEntry,
        Entities.NHibernate.GradebookEntryAggregate.EdFi.GradebookEntry,
        Api.Models.Requests.GradebookEntries.EdFi.GradebookEntryPut,
        Api.Models.Requests.GradebookEntries.EdFi.GradebookEntryPost,
        Api.Models.Requests.GradebookEntries.EdFi.GradebookEntryDelete,
        Api.Models.Requests.GradebookEntries.EdFi.GradebookEntryGetByExample>
    {
        public GradebookEntriesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradebookEntries.EdFi.GradebookEntryGetByExample request, IGradebookEntry specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.DateAssigned = request.DateAssigned;
            specification.Description = request.Description;
            specification.DueDate = request.DueDate;
            specification.GradebookEntryTitle = request.GradebookEntryTitle;
            specification.GradebookEntryTypeDescriptor = request.GradebookEntryTypeDescriptor;
            specification.GradingPeriodDescriptor = request.GradingPeriodDescriptor;
            specification.Id = request.Id;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.PeriodSequence = request.PeriodSequence;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gradebookEntries";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradebookEntryTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradebookEntryTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.GradebookEntryTypeDescriptor.EdFi.GradebookEntryTypeDescriptor,
        Models.Resources.GradebookEntryTypeDescriptor.EdFi.GradebookEntryTypeDescriptor,
        Entities.Common.EdFi.IGradebookEntryTypeDescriptor,
        Entities.NHibernate.GradebookEntryTypeDescriptorAggregate.EdFi.GradebookEntryTypeDescriptor,
        Api.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorPut,
        Api.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorPost,
        Api.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorDelete,
        Api.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorGetByExample>
    {
        public GradebookEntryTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradebookEntryTypeDescriptors.EdFi.GradebookEntryTypeDescriptorGetByExample request, IGradebookEntryTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradebookEntryTypeDescriptorId = request.GradebookEntryTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gradebookEntryTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradeLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradeLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.GradeLevelDescriptor.EdFi.GradeLevelDescriptor,
        Models.Resources.GradeLevelDescriptor.EdFi.GradeLevelDescriptor,
        Entities.Common.EdFi.IGradeLevelDescriptor,
        Entities.NHibernate.GradeLevelDescriptorAggregate.EdFi.GradeLevelDescriptor,
        Api.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorPut,
        Api.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorPost,
        Api.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorDelete,
        Api.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorGetByExample>
    {
        public GradeLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradeLevelDescriptors.EdFi.GradeLevelDescriptorGetByExample request, IGradeLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradeLevelDescriptorId = request.GradeLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gradeLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradePointAverageTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradePointAverageTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.GradePointAverageTypeDescriptor.EdFi.GradePointAverageTypeDescriptor,
        Models.Resources.GradePointAverageTypeDescriptor.EdFi.GradePointAverageTypeDescriptor,
        Entities.Common.EdFi.IGradePointAverageTypeDescriptor,
        Entities.NHibernate.GradePointAverageTypeDescriptorAggregate.EdFi.GradePointAverageTypeDescriptor,
        Api.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorPut,
        Api.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorPost,
        Api.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorDelete,
        Api.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorGetByExample>
    {
        public GradePointAverageTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradePointAverageTypeDescriptors.EdFi.GradePointAverageTypeDescriptorGetByExample request, IGradePointAverageTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradePointAverageTypeDescriptorId = request.GradePointAverageTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gradePointAverageTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradeTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradeTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.GradeTypeDescriptor.EdFi.GradeTypeDescriptor,
        Models.Resources.GradeTypeDescriptor.EdFi.GradeTypeDescriptor,
        Entities.Common.EdFi.IGradeTypeDescriptor,
        Entities.NHibernate.GradeTypeDescriptorAggregate.EdFi.GradeTypeDescriptor,
        Api.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorPut,
        Api.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorPost,
        Api.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorDelete,
        Api.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorGetByExample>
    {
        public GradeTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradeTypeDescriptors.EdFi.GradeTypeDescriptorGetByExample request, IGradeTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradeTypeDescriptorId = request.GradeTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gradeTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradingPeriods.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradingPeriodsController : EdFiControllerBase<
        Models.Resources.GradingPeriod.EdFi.GradingPeriod,
        Models.Resources.GradingPeriod.EdFi.GradingPeriod,
        Entities.Common.EdFi.IGradingPeriod,
        Entities.NHibernate.GradingPeriodAggregate.EdFi.GradingPeriod,
        Api.Models.Requests.GradingPeriods.EdFi.GradingPeriodPut,
        Api.Models.Requests.GradingPeriods.EdFi.GradingPeriodPost,
        Api.Models.Requests.GradingPeriods.EdFi.GradingPeriodDelete,
        Api.Models.Requests.GradingPeriods.EdFi.GradingPeriodGetByExample>
    {
        public GradingPeriodsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradingPeriods.EdFi.GradingPeriodGetByExample request, IGradingPeriod specification)
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

        protected override string GetResourceCollectionName()
        {
            return "gradingPeriods";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GradingPeriodDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GradingPeriodDescriptorsController : EdFiControllerBase<
        Models.Resources.GradingPeriodDescriptor.EdFi.GradingPeriodDescriptor,
        Models.Resources.GradingPeriodDescriptor.EdFi.GradingPeriodDescriptor,
        Entities.Common.EdFi.IGradingPeriodDescriptor,
        Entities.NHibernate.GradingPeriodDescriptorAggregate.EdFi.GradingPeriodDescriptor,
        Api.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorPut,
        Api.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorPost,
        Api.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorDelete,
        Api.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorGetByExample>
    {
        public GradingPeriodDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GradingPeriodDescriptors.EdFi.GradingPeriodDescriptorGetByExample request, IGradingPeriodDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GradingPeriodDescriptorId = request.GradingPeriodDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gradingPeriodDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GraduationPlans.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GraduationPlansController : EdFiControllerBase<
        Models.Resources.GraduationPlan.EdFi.GraduationPlan,
        Models.Resources.GraduationPlan.EdFi.GraduationPlan,
        Entities.Common.EdFi.IGraduationPlan,
        Entities.NHibernate.GraduationPlanAggregate.EdFi.GraduationPlan,
        Api.Models.Requests.GraduationPlans.EdFi.GraduationPlanPut,
        Api.Models.Requests.GraduationPlans.EdFi.GraduationPlanPost,
        Api.Models.Requests.GraduationPlans.EdFi.GraduationPlanDelete,
        Api.Models.Requests.GraduationPlans.EdFi.GraduationPlanGetByExample>
    {
        public GraduationPlansController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GraduationPlans.EdFi.GraduationPlanGetByExample request, IGraduationPlan specification)
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

        protected override string GetResourceCollectionName()
        {
            return "graduationPlans";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GraduationPlanTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GraduationPlanTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.GraduationPlanTypeDescriptor.EdFi.GraduationPlanTypeDescriptor,
        Models.Resources.GraduationPlanTypeDescriptor.EdFi.GraduationPlanTypeDescriptor,
        Entities.Common.EdFi.IGraduationPlanTypeDescriptor,
        Entities.NHibernate.GraduationPlanTypeDescriptorAggregate.EdFi.GraduationPlanTypeDescriptor,
        Api.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorPut,
        Api.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorPost,
        Api.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorDelete,
        Api.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorGetByExample>
    {
        public GraduationPlanTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GraduationPlanTypeDescriptors.EdFi.GraduationPlanTypeDescriptorGetByExample request, IGraduationPlanTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GraduationPlanTypeDescriptorId = request.GraduationPlanTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "graduationPlanTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.GunFreeSchoolsActReportingStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class GunFreeSchoolsActReportingStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.GunFreeSchoolsActReportingStatusDescriptor.EdFi.GunFreeSchoolsActReportingStatusDescriptor,
        Models.Resources.GunFreeSchoolsActReportingStatusDescriptor.EdFi.GunFreeSchoolsActReportingStatusDescriptor,
        Entities.Common.EdFi.IGunFreeSchoolsActReportingStatusDescriptor,
        Entities.NHibernate.GunFreeSchoolsActReportingStatusDescriptorAggregate.EdFi.GunFreeSchoolsActReportingStatusDescriptor,
        Api.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorPut,
        Api.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorPost,
        Api.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorDelete,
        Api.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorGetByExample>
    {
        public GunFreeSchoolsActReportingStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi.GunFreeSchoolsActReportingStatusDescriptorGetByExample request, IGunFreeSchoolsActReportingStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.GunFreeSchoolsActReportingStatusDescriptorId = request.GunFreeSchoolsActReportingStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "gunFreeSchoolsActReportingStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.HomelessPrimaryNighttimeResidenceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class HomelessPrimaryNighttimeResidenceDescriptorsController : EdFiControllerBase<
        Models.Resources.HomelessPrimaryNighttimeResidenceDescriptor.EdFi.HomelessPrimaryNighttimeResidenceDescriptor,
        Models.Resources.HomelessPrimaryNighttimeResidenceDescriptor.EdFi.HomelessPrimaryNighttimeResidenceDescriptor,
        Entities.Common.EdFi.IHomelessPrimaryNighttimeResidenceDescriptor,
        Entities.NHibernate.HomelessPrimaryNighttimeResidenceDescriptorAggregate.EdFi.HomelessPrimaryNighttimeResidenceDescriptor,
        Api.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorPut,
        Api.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorPost,
        Api.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorDelete,
        Api.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorGetByExample>
    {
        public HomelessPrimaryNighttimeResidenceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi.HomelessPrimaryNighttimeResidenceDescriptorGetByExample request, IHomelessPrimaryNighttimeResidenceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HomelessPrimaryNighttimeResidenceDescriptorId = request.HomelessPrimaryNighttimeResidenceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "homelessPrimaryNighttimeResidenceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.HomelessProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class HomelessProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.HomelessProgramServiceDescriptor.EdFi.HomelessProgramServiceDescriptor,
        Models.Resources.HomelessProgramServiceDescriptor.EdFi.HomelessProgramServiceDescriptor,
        Entities.Common.EdFi.IHomelessProgramServiceDescriptor,
        Entities.NHibernate.HomelessProgramServiceDescriptorAggregate.EdFi.HomelessProgramServiceDescriptor,
        Api.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorPut,
        Api.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorPost,
        Api.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorDelete,
        Api.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorGetByExample>
    {
        public HomelessProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.HomelessProgramServiceDescriptors.EdFi.HomelessProgramServiceDescriptorGetByExample request, IHomelessProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.HomelessProgramServiceDescriptorId = request.HomelessProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "homelessProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IdentificationDocumentUseDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class IdentificationDocumentUseDescriptorsController : EdFiControllerBase<
        Models.Resources.IdentificationDocumentUseDescriptor.EdFi.IdentificationDocumentUseDescriptor,
        Models.Resources.IdentificationDocumentUseDescriptor.EdFi.IdentificationDocumentUseDescriptor,
        Entities.Common.EdFi.IIdentificationDocumentUseDescriptor,
        Entities.NHibernate.IdentificationDocumentUseDescriptorAggregate.EdFi.IdentificationDocumentUseDescriptor,
        Api.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorPut,
        Api.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorPost,
        Api.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorDelete,
        Api.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorGetByExample>
    {
        public IdentificationDocumentUseDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.IdentificationDocumentUseDescriptors.EdFi.IdentificationDocumentUseDescriptorGetByExample request, IIdentificationDocumentUseDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IdentificationDocumentUseDescriptorId = request.IdentificationDocumentUseDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "identificationDocumentUseDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IncidentLocationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class IncidentLocationDescriptorsController : EdFiControllerBase<
        Models.Resources.IncidentLocationDescriptor.EdFi.IncidentLocationDescriptor,
        Models.Resources.IncidentLocationDescriptor.EdFi.IncidentLocationDescriptor,
        Entities.Common.EdFi.IIncidentLocationDescriptor,
        Entities.NHibernate.IncidentLocationDescriptorAggregate.EdFi.IncidentLocationDescriptor,
        Api.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorPut,
        Api.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorPost,
        Api.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorDelete,
        Api.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorGetByExample>
    {
        public IncidentLocationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.IncidentLocationDescriptors.EdFi.IncidentLocationDescriptorGetByExample request, IIncidentLocationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IncidentLocationDescriptorId = request.IncidentLocationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "incidentLocationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IndicatorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class IndicatorDescriptorsController : EdFiControllerBase<
        Models.Resources.IndicatorDescriptor.EdFi.IndicatorDescriptor,
        Models.Resources.IndicatorDescriptor.EdFi.IndicatorDescriptor,
        Entities.Common.EdFi.IIndicatorDescriptor,
        Entities.NHibernate.IndicatorDescriptorAggregate.EdFi.IndicatorDescriptor,
        Api.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorPut,
        Api.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorPost,
        Api.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorDelete,
        Api.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorGetByExample>
    {
        public IndicatorDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.IndicatorDescriptors.EdFi.IndicatorDescriptorGetByExample request, IIndicatorDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IndicatorDescriptorId = request.IndicatorDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "indicatorDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IndicatorGroupDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class IndicatorGroupDescriptorsController : EdFiControllerBase<
        Models.Resources.IndicatorGroupDescriptor.EdFi.IndicatorGroupDescriptor,
        Models.Resources.IndicatorGroupDescriptor.EdFi.IndicatorGroupDescriptor,
        Entities.Common.EdFi.IIndicatorGroupDescriptor,
        Entities.NHibernate.IndicatorGroupDescriptorAggregate.EdFi.IndicatorGroupDescriptor,
        Api.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorPut,
        Api.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorPost,
        Api.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorDelete,
        Api.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorGetByExample>
    {
        public IndicatorGroupDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.IndicatorGroupDescriptors.EdFi.IndicatorGroupDescriptorGetByExample request, IIndicatorGroupDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IndicatorGroupDescriptorId = request.IndicatorGroupDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "indicatorGroupDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.IndicatorLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class IndicatorLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.IndicatorLevelDescriptor.EdFi.IndicatorLevelDescriptor,
        Models.Resources.IndicatorLevelDescriptor.EdFi.IndicatorLevelDescriptor,
        Entities.Common.EdFi.IIndicatorLevelDescriptor,
        Entities.NHibernate.IndicatorLevelDescriptorAggregate.EdFi.IndicatorLevelDescriptor,
        Api.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorPut,
        Api.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorPost,
        Api.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorDelete,
        Api.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorGetByExample>
    {
        public IndicatorLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.IndicatorLevelDescriptors.EdFi.IndicatorLevelDescriptorGetByExample request, IIndicatorLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.IndicatorLevelDescriptorId = request.IndicatorLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "indicatorLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InstitutionTelephoneNumberTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InstitutionTelephoneNumberTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.InstitutionTelephoneNumberTypeDescriptor.EdFi.InstitutionTelephoneNumberTypeDescriptor,
        Models.Resources.InstitutionTelephoneNumberTypeDescriptor.EdFi.InstitutionTelephoneNumberTypeDescriptor,
        Entities.Common.EdFi.IInstitutionTelephoneNumberTypeDescriptor,
        Entities.NHibernate.InstitutionTelephoneNumberTypeDescriptorAggregate.EdFi.InstitutionTelephoneNumberTypeDescriptor,
        Api.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorPut,
        Api.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorPost,
        Api.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorDelete,
        Api.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorGetByExample>
    {
        public InstitutionTelephoneNumberTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi.InstitutionTelephoneNumberTypeDescriptorGetByExample request, IInstitutionTelephoneNumberTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InstitutionTelephoneNumberTypeDescriptorId = request.InstitutionTelephoneNumberTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "institutionTelephoneNumberTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InteractivityStyleDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InteractivityStyleDescriptorsController : EdFiControllerBase<
        Models.Resources.InteractivityStyleDescriptor.EdFi.InteractivityStyleDescriptor,
        Models.Resources.InteractivityStyleDescriptor.EdFi.InteractivityStyleDescriptor,
        Entities.Common.EdFi.IInteractivityStyleDescriptor,
        Entities.NHibernate.InteractivityStyleDescriptorAggregate.EdFi.InteractivityStyleDescriptor,
        Api.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorPut,
        Api.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorPost,
        Api.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorDelete,
        Api.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorGetByExample>
    {
        public InteractivityStyleDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InteractivityStyleDescriptors.EdFi.InteractivityStyleDescriptorGetByExample request, IInteractivityStyleDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InteractivityStyleDescriptorId = request.InteractivityStyleDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "interactivityStyleDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InternetAccessDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InternetAccessDescriptorsController : EdFiControllerBase<
        Models.Resources.InternetAccessDescriptor.EdFi.InternetAccessDescriptor,
        Models.Resources.InternetAccessDescriptor.EdFi.InternetAccessDescriptor,
        Entities.Common.EdFi.IInternetAccessDescriptor,
        Entities.NHibernate.InternetAccessDescriptorAggregate.EdFi.InternetAccessDescriptor,
        Api.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorPut,
        Api.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorPost,
        Api.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorDelete,
        Api.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorGetByExample>
    {
        public InternetAccessDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InternetAccessDescriptors.EdFi.InternetAccessDescriptorGetByExample request, IInternetAccessDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InternetAccessDescriptorId = request.InternetAccessDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "internetAccessDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Interventions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InterventionsController : EdFiControllerBase<
        Models.Resources.Intervention.EdFi.Intervention,
        Models.Resources.Intervention.EdFi.Intervention,
        Entities.Common.EdFi.IIntervention,
        Entities.NHibernate.InterventionAggregate.EdFi.Intervention,
        Api.Models.Requests.Interventions.EdFi.InterventionPut,
        Api.Models.Requests.Interventions.EdFi.InterventionPost,
        Api.Models.Requests.Interventions.EdFi.InterventionDelete,
        Api.Models.Requests.Interventions.EdFi.InterventionGetByExample>
    {
        public InterventionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Interventions.EdFi.InterventionGetByExample request, IIntervention specification)
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
                    }

        protected override string GetResourceCollectionName()
        {
            return "interventions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionClassDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InterventionClassDescriptorsController : EdFiControllerBase<
        Models.Resources.InterventionClassDescriptor.EdFi.InterventionClassDescriptor,
        Models.Resources.InterventionClassDescriptor.EdFi.InterventionClassDescriptor,
        Entities.Common.EdFi.IInterventionClassDescriptor,
        Entities.NHibernate.InterventionClassDescriptorAggregate.EdFi.InterventionClassDescriptor,
        Api.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorPut,
        Api.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorPost,
        Api.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorDelete,
        Api.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorGetByExample>
    {
        public InterventionClassDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InterventionClassDescriptors.EdFi.InterventionClassDescriptorGetByExample request, IInterventionClassDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InterventionClassDescriptorId = request.InterventionClassDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "interventionClassDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionEffectivenessRatingDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InterventionEffectivenessRatingDescriptorsController : EdFiControllerBase<
        Models.Resources.InterventionEffectivenessRatingDescriptor.EdFi.InterventionEffectivenessRatingDescriptor,
        Models.Resources.InterventionEffectivenessRatingDescriptor.EdFi.InterventionEffectivenessRatingDescriptor,
        Entities.Common.EdFi.IInterventionEffectivenessRatingDescriptor,
        Entities.NHibernate.InterventionEffectivenessRatingDescriptorAggregate.EdFi.InterventionEffectivenessRatingDescriptor,
        Api.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorPut,
        Api.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorPost,
        Api.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorDelete,
        Api.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorGetByExample>
    {
        public InterventionEffectivenessRatingDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi.InterventionEffectivenessRatingDescriptorGetByExample request, IInterventionEffectivenessRatingDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.InterventionEffectivenessRatingDescriptorId = request.InterventionEffectivenessRatingDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "interventionEffectivenessRatingDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionPrescriptions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InterventionPrescriptionsController : EdFiControllerBase<
        Models.Resources.InterventionPrescription.EdFi.InterventionPrescription,
        Models.Resources.InterventionPrescription.EdFi.InterventionPrescription,
        Entities.Common.EdFi.IInterventionPrescription,
        Entities.NHibernate.InterventionPrescriptionAggregate.EdFi.InterventionPrescription,
        Api.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionPut,
        Api.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionPost,
        Api.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionDelete,
        Api.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionGetByExample>
    {
        public InterventionPrescriptionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InterventionPrescriptions.EdFi.InterventionPrescriptionGetByExample request, IInterventionPrescription specification)
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
                    }

        protected override string GetResourceCollectionName()
        {
            return "interventionPrescriptions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.InterventionStudies.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class InterventionStudiesController : EdFiControllerBase<
        Models.Resources.InterventionStudy.EdFi.InterventionStudy,
        Models.Resources.InterventionStudy.EdFi.InterventionStudy,
        Entities.Common.EdFi.IInterventionStudy,
        Entities.NHibernate.InterventionStudyAggregate.EdFi.InterventionStudy,
        Api.Models.Requests.InterventionStudies.EdFi.InterventionStudyPut,
        Api.Models.Requests.InterventionStudies.EdFi.InterventionStudyPost,
        Api.Models.Requests.InterventionStudies.EdFi.InterventionStudyDelete,
        Api.Models.Requests.InterventionStudies.EdFi.InterventionStudyGetByExample>
    {
        public InterventionStudiesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.InterventionStudies.EdFi.InterventionStudyGetByExample request, IInterventionStudy specification)
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

        protected override string GetResourceCollectionName()
        {
            return "interventionStudies";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LanguageDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LanguageDescriptorsController : EdFiControllerBase<
        Models.Resources.LanguageDescriptor.EdFi.LanguageDescriptor,
        Models.Resources.LanguageDescriptor.EdFi.LanguageDescriptor,
        Entities.Common.EdFi.ILanguageDescriptor,
        Entities.NHibernate.LanguageDescriptorAggregate.EdFi.LanguageDescriptor,
        Api.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorPut,
        Api.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorPost,
        Api.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorDelete,
        Api.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorGetByExample>
    {
        public LanguageDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LanguageDescriptors.EdFi.LanguageDescriptorGetByExample request, ILanguageDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LanguageDescriptorId = request.LanguageDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "languageDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LanguageInstructionProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LanguageInstructionProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.LanguageInstructionProgramServiceDescriptor.EdFi.LanguageInstructionProgramServiceDescriptor,
        Models.Resources.LanguageInstructionProgramServiceDescriptor.EdFi.LanguageInstructionProgramServiceDescriptor,
        Entities.Common.EdFi.ILanguageInstructionProgramServiceDescriptor,
        Entities.NHibernate.LanguageInstructionProgramServiceDescriptorAggregate.EdFi.LanguageInstructionProgramServiceDescriptor,
        Api.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorPut,
        Api.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorPost,
        Api.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorDelete,
        Api.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorGetByExample>
    {
        public LanguageInstructionProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi.LanguageInstructionProgramServiceDescriptorGetByExample request, ILanguageInstructionProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LanguageInstructionProgramServiceDescriptorId = request.LanguageInstructionProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "languageInstructionProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LanguageUseDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LanguageUseDescriptorsController : EdFiControllerBase<
        Models.Resources.LanguageUseDescriptor.EdFi.LanguageUseDescriptor,
        Models.Resources.LanguageUseDescriptor.EdFi.LanguageUseDescriptor,
        Entities.Common.EdFi.ILanguageUseDescriptor,
        Entities.NHibernate.LanguageUseDescriptorAggregate.EdFi.LanguageUseDescriptor,
        Api.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorPut,
        Api.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorPost,
        Api.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorDelete,
        Api.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorGetByExample>
    {
        public LanguageUseDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LanguageUseDescriptors.EdFi.LanguageUseDescriptorGetByExample request, ILanguageUseDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LanguageUseDescriptorId = request.LanguageUseDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "languageUseDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LearningObjectivesController : EdFiControllerBase<
        Models.Resources.LearningObjective.EdFi.LearningObjective,
        Models.Resources.LearningObjective.EdFi.LearningObjective,
        Entities.Common.EdFi.ILearningObjective,
        Entities.NHibernate.LearningObjectiveAggregate.EdFi.LearningObjective,
        Api.Models.Requests.LearningObjectives.EdFi.LearningObjectivePut,
        Api.Models.Requests.LearningObjectives.EdFi.LearningObjectivePost,
        Api.Models.Requests.LearningObjectives.EdFi.LearningObjectiveDelete,
        Api.Models.Requests.LearningObjectives.EdFi.LearningObjectiveGetByExample>
    {
        public LearningObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LearningObjectives.EdFi.LearningObjectiveGetByExample request, ILearningObjective specification)
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

        protected override string GetResourceCollectionName()
        {
            return "learningObjectives";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandards.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LearningStandardsController : EdFiControllerBase<
        Models.Resources.LearningStandard.EdFi.LearningStandard,
        Models.Resources.LearningStandard.EdFi.LearningStandard,
        Entities.Common.EdFi.ILearningStandard,
        Entities.NHibernate.LearningStandardAggregate.EdFi.LearningStandard,
        Api.Models.Requests.LearningStandards.EdFi.LearningStandardPut,
        Api.Models.Requests.LearningStandards.EdFi.LearningStandardPost,
        Api.Models.Requests.LearningStandards.EdFi.LearningStandardDelete,
        Api.Models.Requests.LearningStandards.EdFi.LearningStandardGetByExample>
    {
        public LearningStandardsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LearningStandards.EdFi.LearningStandardGetByExample request, ILearningStandard specification)
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

        protected override string GetResourceCollectionName()
        {
            return "learningStandards";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LearningStandardCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.LearningStandardCategoryDescriptor.EdFi.LearningStandardCategoryDescriptor,
        Models.Resources.LearningStandardCategoryDescriptor.EdFi.LearningStandardCategoryDescriptor,
        Entities.Common.EdFi.ILearningStandardCategoryDescriptor,
        Entities.NHibernate.LearningStandardCategoryDescriptorAggregate.EdFi.LearningStandardCategoryDescriptor,
        Api.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorPut,
        Api.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorPost,
        Api.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorDelete,
        Api.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorGetByExample>
    {
        public LearningStandardCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LearningStandardCategoryDescriptors.EdFi.LearningStandardCategoryDescriptorGetByExample request, ILearningStandardCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LearningStandardCategoryDescriptorId = request.LearningStandardCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "learningStandardCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardEquivalenceAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LearningStandardEquivalenceAssociationsController : EdFiControllerBase<
        Models.Resources.LearningStandardEquivalenceAssociation.EdFi.LearningStandardEquivalenceAssociation,
        Models.Resources.LearningStandardEquivalenceAssociation.EdFi.LearningStandardEquivalenceAssociation,
        Entities.Common.EdFi.ILearningStandardEquivalenceAssociation,
        Entities.NHibernate.LearningStandardEquivalenceAssociationAggregate.EdFi.LearningStandardEquivalenceAssociation,
        Api.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationPut,
        Api.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationPost,
        Api.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationDelete,
        Api.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationGetByExample>
    {
        public LearningStandardEquivalenceAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LearningStandardEquivalenceAssociations.EdFi.LearningStandardEquivalenceAssociationGetByExample request, ILearningStandardEquivalenceAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "learningStandardEquivalenceAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardEquivalenceStrengthDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LearningStandardEquivalenceStrengthDescriptorsController : EdFiControllerBase<
        Models.Resources.LearningStandardEquivalenceStrengthDescriptor.EdFi.LearningStandardEquivalenceStrengthDescriptor,
        Models.Resources.LearningStandardEquivalenceStrengthDescriptor.EdFi.LearningStandardEquivalenceStrengthDescriptor,
        Entities.Common.EdFi.ILearningStandardEquivalenceStrengthDescriptor,
        Entities.NHibernate.LearningStandardEquivalenceStrengthDescriptorAggregate.EdFi.LearningStandardEquivalenceStrengthDescriptor,
        Api.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorPut,
        Api.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorPost,
        Api.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorDelete,
        Api.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorGetByExample>
    {
        public LearningStandardEquivalenceStrengthDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi.LearningStandardEquivalenceStrengthDescriptorGetByExample request, ILearningStandardEquivalenceStrengthDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LearningStandardEquivalenceStrengthDescriptorId = request.LearningStandardEquivalenceStrengthDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "learningStandardEquivalenceStrengthDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LearningStandardScopeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LearningStandardScopeDescriptorsController : EdFiControllerBase<
        Models.Resources.LearningStandardScopeDescriptor.EdFi.LearningStandardScopeDescriptor,
        Models.Resources.LearningStandardScopeDescriptor.EdFi.LearningStandardScopeDescriptor,
        Entities.Common.EdFi.ILearningStandardScopeDescriptor,
        Entities.NHibernate.LearningStandardScopeDescriptorAggregate.EdFi.LearningStandardScopeDescriptor,
        Api.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorPut,
        Api.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorPost,
        Api.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorDelete,
        Api.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorGetByExample>
    {
        public LearningStandardScopeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LearningStandardScopeDescriptors.EdFi.LearningStandardScopeDescriptorGetByExample request, ILearningStandardScopeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LearningStandardScopeDescriptorId = request.LearningStandardScopeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "learningStandardScopeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LevelOfEducationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LevelOfEducationDescriptorsController : EdFiControllerBase<
        Models.Resources.LevelOfEducationDescriptor.EdFi.LevelOfEducationDescriptor,
        Models.Resources.LevelOfEducationDescriptor.EdFi.LevelOfEducationDescriptor,
        Entities.Common.EdFi.ILevelOfEducationDescriptor,
        Entities.NHibernate.LevelOfEducationDescriptorAggregate.EdFi.LevelOfEducationDescriptor,
        Api.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorPut,
        Api.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorPost,
        Api.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorDelete,
        Api.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorGetByExample>
    {
        public LevelOfEducationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LevelOfEducationDescriptors.EdFi.LevelOfEducationDescriptorGetByExample request, ILevelOfEducationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LevelOfEducationDescriptorId = request.LevelOfEducationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "levelOfEducationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LicenseStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LicenseStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.LicenseStatusDescriptor.EdFi.LicenseStatusDescriptor,
        Models.Resources.LicenseStatusDescriptor.EdFi.LicenseStatusDescriptor,
        Entities.Common.EdFi.ILicenseStatusDescriptor,
        Entities.NHibernate.LicenseStatusDescriptorAggregate.EdFi.LicenseStatusDescriptor,
        Api.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorPut,
        Api.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorPost,
        Api.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorDelete,
        Api.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorGetByExample>
    {
        public LicenseStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LicenseStatusDescriptors.EdFi.LicenseStatusDescriptorGetByExample request, ILicenseStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LicenseStatusDescriptorId = request.LicenseStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "licenseStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LicenseTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LicenseTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.LicenseTypeDescriptor.EdFi.LicenseTypeDescriptor,
        Models.Resources.LicenseTypeDescriptor.EdFi.LicenseTypeDescriptor,
        Entities.Common.EdFi.ILicenseTypeDescriptor,
        Entities.NHibernate.LicenseTypeDescriptorAggregate.EdFi.LicenseTypeDescriptor,
        Api.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorPut,
        Api.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorPost,
        Api.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorDelete,
        Api.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorGetByExample>
    {
        public LicenseTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LicenseTypeDescriptors.EdFi.LicenseTypeDescriptorGetByExample request, ILicenseTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LicenseTypeDescriptorId = request.LicenseTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "licenseTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LimitedEnglishProficiencyDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LimitedEnglishProficiencyDescriptorsController : EdFiControllerBase<
        Models.Resources.LimitedEnglishProficiencyDescriptor.EdFi.LimitedEnglishProficiencyDescriptor,
        Models.Resources.LimitedEnglishProficiencyDescriptor.EdFi.LimitedEnglishProficiencyDescriptor,
        Entities.Common.EdFi.ILimitedEnglishProficiencyDescriptor,
        Entities.NHibernate.LimitedEnglishProficiencyDescriptorAggregate.EdFi.LimitedEnglishProficiencyDescriptor,
        Api.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorPut,
        Api.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorPost,
        Api.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorDelete,
        Api.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorGetByExample>
    {
        public LimitedEnglishProficiencyDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi.LimitedEnglishProficiencyDescriptorGetByExample request, ILimitedEnglishProficiencyDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LimitedEnglishProficiencyDescriptorId = request.LimitedEnglishProficiencyDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "limitedEnglishProficiencyDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocaleDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LocaleDescriptorsController : EdFiControllerBase<
        Models.Resources.LocaleDescriptor.EdFi.LocaleDescriptor,
        Models.Resources.LocaleDescriptor.EdFi.LocaleDescriptor,
        Entities.Common.EdFi.ILocaleDescriptor,
        Entities.NHibernate.LocaleDescriptorAggregate.EdFi.LocaleDescriptor,
        Api.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorPut,
        Api.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorPost,
        Api.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorDelete,
        Api.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorGetByExample>
    {
        public LocaleDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LocaleDescriptors.EdFi.LocaleDescriptorGetByExample request, ILocaleDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LocaleDescriptorId = request.LocaleDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "localeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEducationAgencies.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LocalEducationAgenciesController : EdFiControllerBase<
        Models.Resources.LocalEducationAgency.EdFi.LocalEducationAgency,
        Models.Resources.LocalEducationAgency.EdFi.LocalEducationAgency,
        Entities.Common.EdFi.ILocalEducationAgency,
        Entities.NHibernate.LocalEducationAgencyAggregate.EdFi.LocalEducationAgency,
        Api.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyPut,
        Api.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyPost,
        Api.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyDelete,
        Api.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyGetByExample>
    {
        public LocalEducationAgenciesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LocalEducationAgencies.EdFi.LocalEducationAgencyGetByExample request, ILocalEducationAgency specification)
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

        protected override string GetResourceCollectionName()
        {
            return "localEducationAgencies";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.LocalEducationAgencyCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LocalEducationAgencyCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.LocalEducationAgencyCategoryDescriptor.EdFi.LocalEducationAgencyCategoryDescriptor,
        Models.Resources.LocalEducationAgencyCategoryDescriptor.EdFi.LocalEducationAgencyCategoryDescriptor,
        Entities.Common.EdFi.ILocalEducationAgencyCategoryDescriptor,
        Entities.NHibernate.LocalEducationAgencyCategoryDescriptorAggregate.EdFi.LocalEducationAgencyCategoryDescriptor,
        Api.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorPut,
        Api.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorPost,
        Api.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorDelete,
        Api.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorGetByExample>
    {
        public LocalEducationAgencyCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi.LocalEducationAgencyCategoryDescriptorGetByExample request, ILocalEducationAgencyCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.LocalEducationAgencyCategoryDescriptorId = request.LocalEducationAgencyCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "localEducationAgencyCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Locations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class LocationsController : EdFiControllerBase<
        Models.Resources.Location.EdFi.Location,
        Models.Resources.Location.EdFi.Location,
        Entities.Common.EdFi.ILocation,
        Entities.NHibernate.LocationAggregate.EdFi.Location,
        Api.Models.Requests.Locations.EdFi.LocationPut,
        Api.Models.Requests.Locations.EdFi.LocationPost,
        Api.Models.Requests.Locations.EdFi.LocationDelete,
        Api.Models.Requests.Locations.EdFi.LocationGetByExample>
    {
        public LocationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Locations.EdFi.LocationGetByExample request, ILocation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ClassroomIdentificationCode = request.ClassroomIdentificationCode;
            specification.Id = request.Id;
            specification.MaximumNumberOfSeats = request.MaximumNumberOfSeats;
            specification.OptimalNumberOfSeats = request.OptimalNumberOfSeats;
            specification.SchoolId = request.SchoolId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "locations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class MagnetSpecialProgramEmphasisSchoolDescriptorsController : EdFiControllerBase<
        Models.Resources.MagnetSpecialProgramEmphasisSchoolDescriptor.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor,
        Models.Resources.MagnetSpecialProgramEmphasisSchoolDescriptor.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor,
        Entities.Common.EdFi.IMagnetSpecialProgramEmphasisSchoolDescriptor,
        Entities.NHibernate.MagnetSpecialProgramEmphasisSchoolDescriptorAggregate.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor,
        Api.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorPut,
        Api.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorPost,
        Api.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorDelete,
        Api.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorGetByExample>
    {
        public MagnetSpecialProgramEmphasisSchoolDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptorGetByExample request, IMagnetSpecialProgramEmphasisSchoolDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MagnetSpecialProgramEmphasisSchoolDescriptorId = request.MagnetSpecialProgramEmphasisSchoolDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "magnetSpecialProgramEmphasisSchoolDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MediumOfInstructionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class MediumOfInstructionDescriptorsController : EdFiControllerBase<
        Models.Resources.MediumOfInstructionDescriptor.EdFi.MediumOfInstructionDescriptor,
        Models.Resources.MediumOfInstructionDescriptor.EdFi.MediumOfInstructionDescriptor,
        Entities.Common.EdFi.IMediumOfInstructionDescriptor,
        Entities.NHibernate.MediumOfInstructionDescriptorAggregate.EdFi.MediumOfInstructionDescriptor,
        Api.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorPut,
        Api.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorPost,
        Api.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorDelete,
        Api.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorGetByExample>
    {
        public MediumOfInstructionDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.MediumOfInstructionDescriptors.EdFi.MediumOfInstructionDescriptorGetByExample request, IMediumOfInstructionDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MediumOfInstructionDescriptorId = request.MediumOfInstructionDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "mediumOfInstructionDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MethodCreditEarnedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class MethodCreditEarnedDescriptorsController : EdFiControllerBase<
        Models.Resources.MethodCreditEarnedDescriptor.EdFi.MethodCreditEarnedDescriptor,
        Models.Resources.MethodCreditEarnedDescriptor.EdFi.MethodCreditEarnedDescriptor,
        Entities.Common.EdFi.IMethodCreditEarnedDescriptor,
        Entities.NHibernate.MethodCreditEarnedDescriptorAggregate.EdFi.MethodCreditEarnedDescriptor,
        Api.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorPut,
        Api.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorPost,
        Api.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorDelete,
        Api.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorGetByExample>
    {
        public MethodCreditEarnedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.MethodCreditEarnedDescriptors.EdFi.MethodCreditEarnedDescriptorGetByExample request, IMethodCreditEarnedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MethodCreditEarnedDescriptorId = request.MethodCreditEarnedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "methodCreditEarnedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MigrantEducationProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class MigrantEducationProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.MigrantEducationProgramServiceDescriptor.EdFi.MigrantEducationProgramServiceDescriptor,
        Models.Resources.MigrantEducationProgramServiceDescriptor.EdFi.MigrantEducationProgramServiceDescriptor,
        Entities.Common.EdFi.IMigrantEducationProgramServiceDescriptor,
        Entities.NHibernate.MigrantEducationProgramServiceDescriptorAggregate.EdFi.MigrantEducationProgramServiceDescriptor,
        Api.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorPut,
        Api.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorPost,
        Api.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorDelete,
        Api.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorGetByExample>
    {
        public MigrantEducationProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi.MigrantEducationProgramServiceDescriptorGetByExample request, IMigrantEducationProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MigrantEducationProgramServiceDescriptorId = request.MigrantEducationProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "migrantEducationProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.MonitoredDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class MonitoredDescriptorsController : EdFiControllerBase<
        Models.Resources.MonitoredDescriptor.EdFi.MonitoredDescriptor,
        Models.Resources.MonitoredDescriptor.EdFi.MonitoredDescriptor,
        Entities.Common.EdFi.IMonitoredDescriptor,
        Entities.NHibernate.MonitoredDescriptorAggregate.EdFi.MonitoredDescriptor,
        Api.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorPut,
        Api.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorPost,
        Api.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorDelete,
        Api.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorGetByExample>
    {
        public MonitoredDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.MonitoredDescriptors.EdFi.MonitoredDescriptorGetByExample request, IMonitoredDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.MonitoredDescriptorId = request.MonitoredDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "monitoredDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.NeglectedOrDelinquentProgramDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class NeglectedOrDelinquentProgramDescriptorsController : EdFiControllerBase<
        Models.Resources.NeglectedOrDelinquentProgramDescriptor.EdFi.NeglectedOrDelinquentProgramDescriptor,
        Models.Resources.NeglectedOrDelinquentProgramDescriptor.EdFi.NeglectedOrDelinquentProgramDescriptor,
        Entities.Common.EdFi.INeglectedOrDelinquentProgramDescriptor,
        Entities.NHibernate.NeglectedOrDelinquentProgramDescriptorAggregate.EdFi.NeglectedOrDelinquentProgramDescriptor,
        Api.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorPut,
        Api.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorPost,
        Api.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorDelete,
        Api.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorGetByExample>
    {
        public NeglectedOrDelinquentProgramDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi.NeglectedOrDelinquentProgramDescriptorGetByExample request, INeglectedOrDelinquentProgramDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.NeglectedOrDelinquentProgramDescriptorId = request.NeglectedOrDelinquentProgramDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "neglectedOrDelinquentProgramDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.NeglectedOrDelinquentProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class NeglectedOrDelinquentProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.NeglectedOrDelinquentProgramServiceDescriptor.EdFi.NeglectedOrDelinquentProgramServiceDescriptor,
        Models.Resources.NeglectedOrDelinquentProgramServiceDescriptor.EdFi.NeglectedOrDelinquentProgramServiceDescriptor,
        Entities.Common.EdFi.INeglectedOrDelinquentProgramServiceDescriptor,
        Entities.NHibernate.NeglectedOrDelinquentProgramServiceDescriptorAggregate.EdFi.NeglectedOrDelinquentProgramServiceDescriptor,
        Api.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorPut,
        Api.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorPost,
        Api.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorDelete,
        Api.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorGetByExample>
    {
        public NeglectedOrDelinquentProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi.NeglectedOrDelinquentProgramServiceDescriptorGetByExample request, INeglectedOrDelinquentProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.NeglectedOrDelinquentProgramServiceDescriptorId = request.NeglectedOrDelinquentProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "neglectedOrDelinquentProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.NetworkPurposeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class NetworkPurposeDescriptorsController : EdFiControllerBase<
        Models.Resources.NetworkPurposeDescriptor.EdFi.NetworkPurposeDescriptor,
        Models.Resources.NetworkPurposeDescriptor.EdFi.NetworkPurposeDescriptor,
        Entities.Common.EdFi.INetworkPurposeDescriptor,
        Entities.NHibernate.NetworkPurposeDescriptorAggregate.EdFi.NetworkPurposeDescriptor,
        Api.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorPut,
        Api.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorPost,
        Api.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorDelete,
        Api.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorGetByExample>
    {
        public NetworkPurposeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.NetworkPurposeDescriptors.EdFi.NetworkPurposeDescriptorGetByExample request, INetworkPurposeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.NetworkPurposeDescriptorId = request.NetworkPurposeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "networkPurposeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ObjectiveAssessments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ObjectiveAssessmentsController : EdFiControllerBase<
        Models.Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment,
        Models.Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment,
        Entities.Common.EdFi.IObjectiveAssessment,
        Entities.NHibernate.ObjectiveAssessmentAggregate.EdFi.ObjectiveAssessment,
        Api.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentPut,
        Api.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentPost,
        Api.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentDelete,
        Api.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentGetByExample>
    {
        public ObjectiveAssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ObjectiveAssessments.EdFi.ObjectiveAssessmentGetByExample request, IObjectiveAssessment specification)
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

        protected override string GetResourceCollectionName()
        {
            return "objectiveAssessments";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OldEthnicityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OldEthnicityDescriptorsController : EdFiControllerBase<
        Models.Resources.OldEthnicityDescriptor.EdFi.OldEthnicityDescriptor,
        Models.Resources.OldEthnicityDescriptor.EdFi.OldEthnicityDescriptor,
        Entities.Common.EdFi.IOldEthnicityDescriptor,
        Entities.NHibernate.OldEthnicityDescriptorAggregate.EdFi.OldEthnicityDescriptor,
        Api.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorPut,
        Api.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorPost,
        Api.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorDelete,
        Api.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorGetByExample>
    {
        public OldEthnicityDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.OldEthnicityDescriptors.EdFi.OldEthnicityDescriptorGetByExample request, IOldEthnicityDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OldEthnicityDescriptorId = request.OldEthnicityDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "oldEthnicityDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OpenStaffPositions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OpenStaffPositionsController : EdFiControllerBase<
        Models.Resources.OpenStaffPosition.EdFi.OpenStaffPosition,
        Models.Resources.OpenStaffPosition.EdFi.OpenStaffPosition,
        Entities.Common.EdFi.IOpenStaffPosition,
        Entities.NHibernate.OpenStaffPositionAggregate.EdFi.OpenStaffPosition,
        Api.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionPut,
        Api.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionPost,
        Api.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionDelete,
        Api.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionGetByExample>
    {
        public OpenStaffPositionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.OpenStaffPositions.EdFi.OpenStaffPositionGetByExample request, IOpenStaffPosition specification)
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

        protected override string GetResourceCollectionName()
        {
            return "openStaffPositions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OperationalStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OperationalStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.OperationalStatusDescriptor.EdFi.OperationalStatusDescriptor,
        Models.Resources.OperationalStatusDescriptor.EdFi.OperationalStatusDescriptor,
        Entities.Common.EdFi.IOperationalStatusDescriptor,
        Entities.NHibernate.OperationalStatusDescriptorAggregate.EdFi.OperationalStatusDescriptor,
        Api.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorPut,
        Api.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorPost,
        Api.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorDelete,
        Api.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorGetByExample>
    {
        public OperationalStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.OperationalStatusDescriptors.EdFi.OperationalStatusDescriptorGetByExample request, IOperationalStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OperationalStatusDescriptorId = request.OperationalStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "operationalStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.OtherNameTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class OtherNameTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.OtherNameTypeDescriptor.EdFi.OtherNameTypeDescriptor,
        Models.Resources.OtherNameTypeDescriptor.EdFi.OtherNameTypeDescriptor,
        Entities.Common.EdFi.IOtherNameTypeDescriptor,
        Entities.NHibernate.OtherNameTypeDescriptorAggregate.EdFi.OtherNameTypeDescriptor,
        Api.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorPut,
        Api.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorPost,
        Api.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorDelete,
        Api.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorGetByExample>
    {
        public OtherNameTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.OtherNameTypeDescriptors.EdFi.OtherNameTypeDescriptorGetByExample request, IOtherNameTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.OtherNameTypeDescriptorId = request.OtherNameTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "otherNameTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Parents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ParentsController : EdFiControllerBase<
        Models.Resources.Parent.EdFi.Parent,
        Models.Resources.Parent.EdFi.Parent,
        Entities.Common.EdFi.IParent,
        Entities.NHibernate.ParentAggregate.EdFi.Parent,
        Api.Models.Requests.Parents.EdFi.ParentPut,
        Api.Models.Requests.Parents.EdFi.ParentPost,
        Api.Models.Requests.Parents.EdFi.ParentDelete,
        Api.Models.Requests.Parents.EdFi.ParentGetByExample>
    {
        public ParentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Parents.EdFi.ParentGetByExample request, IParent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.FirstName = request.FirstName;
            specification.GenerationCodeSuffix = request.GenerationCodeSuffix;
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

        protected override string GetResourceCollectionName()
        {
            return "parents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ParticipationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ParticipationDescriptorsController : EdFiControllerBase<
        Models.Resources.ParticipationDescriptor.EdFi.ParticipationDescriptor,
        Models.Resources.ParticipationDescriptor.EdFi.ParticipationDescriptor,
        Entities.Common.EdFi.IParticipationDescriptor,
        Entities.NHibernate.ParticipationDescriptorAggregate.EdFi.ParticipationDescriptor,
        Api.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorPut,
        Api.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorPost,
        Api.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorDelete,
        Api.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorGetByExample>
    {
        public ParticipationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ParticipationDescriptors.EdFi.ParticipationDescriptorGetByExample request, IParticipationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ParticipationDescriptorId = request.ParticipationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "participationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ParticipationStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ParticipationStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.ParticipationStatusDescriptor.EdFi.ParticipationStatusDescriptor,
        Models.Resources.ParticipationStatusDescriptor.EdFi.ParticipationStatusDescriptor,
        Entities.Common.EdFi.IParticipationStatusDescriptor,
        Entities.NHibernate.ParticipationStatusDescriptorAggregate.EdFi.ParticipationStatusDescriptor,
        Api.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorPut,
        Api.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorPost,
        Api.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorDelete,
        Api.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorGetByExample>
    {
        public ParticipationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ParticipationStatusDescriptors.EdFi.ParticipationStatusDescriptorGetByExample request, IParticipationStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ParticipationStatusDescriptorId = request.ParticipationStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "participationStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Payrolls.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PayrollsController : EdFiControllerBase<
        Models.Resources.Payroll.EdFi.Payroll,
        Models.Resources.Payroll.EdFi.Payroll,
        Entities.Common.EdFi.IPayroll,
        Entities.NHibernate.PayrollAggregate.EdFi.Payroll,
        Api.Models.Requests.Payrolls.EdFi.PayrollPut,
        Api.Models.Requests.Payrolls.EdFi.PayrollPost,
        Api.Models.Requests.Payrolls.EdFi.PayrollDelete,
        Api.Models.Requests.Payrolls.EdFi.PayrollGetByExample>
    {
        public PayrollsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Payrolls.EdFi.PayrollGetByExample request, IPayroll specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AccountIdentifier = request.AccountIdentifier;
            specification.AmountToDate = request.AmountToDate;
            specification.AsOfDate = request.AsOfDate;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.FiscalYear = request.FiscalYear;
            specification.Id = request.Id;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "payrolls";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PerformanceBaseConversionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceBaseConversionDescriptorsController : EdFiControllerBase<
        Models.Resources.PerformanceBaseConversionDescriptor.EdFi.PerformanceBaseConversionDescriptor,
        Models.Resources.PerformanceBaseConversionDescriptor.EdFi.PerformanceBaseConversionDescriptor,
        Entities.Common.EdFi.IPerformanceBaseConversionDescriptor,
        Entities.NHibernate.PerformanceBaseConversionDescriptorAggregate.EdFi.PerformanceBaseConversionDescriptor,
        Api.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorPut,
        Api.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorPost,
        Api.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorDelete,
        Api.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorGetByExample>
    {
        public PerformanceBaseConversionDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PerformanceBaseConversionDescriptors.EdFi.PerformanceBaseConversionDescriptorGetByExample request, IPerformanceBaseConversionDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceBaseConversionDescriptorId = request.PerformanceBaseConversionDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceBaseConversionDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PerformanceLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PerformanceLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor,
        Models.Resources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor,
        Entities.Common.EdFi.IPerformanceLevelDescriptor,
        Entities.NHibernate.PerformanceLevelDescriptorAggregate.EdFi.PerformanceLevelDescriptor,
        Api.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorPut,
        Api.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorPost,
        Api.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorDelete,
        Api.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorGetByExample>
    {
        public PerformanceLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PerformanceLevelDescriptors.EdFi.PerformanceLevelDescriptorGetByExample request, IPerformanceLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PerformanceLevelDescriptorId = request.PerformanceLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "performanceLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.People.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PeopleController : EdFiControllerBase<
        Models.Resources.Person.EdFi.Person,
        Models.Resources.Person.EdFi.Person,
        Entities.Common.EdFi.IPerson,
        Entities.NHibernate.PersonAggregate.EdFi.Person,
        Api.Models.Requests.People.EdFi.PersonPut,
        Api.Models.Requests.People.EdFi.PersonPost,
        Api.Models.Requests.People.EdFi.PersonDelete,
        Api.Models.Requests.People.EdFi.PersonGetByExample>
    {
        public PeopleController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.People.EdFi.PersonGetByExample request, IPerson specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.PersonId = request.PersonId;
            specification.SourceSystemDescriptor = request.SourceSystemDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "people";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PersonalInformationVerificationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PersonalInformationVerificationDescriptorsController : EdFiControllerBase<
        Models.Resources.PersonalInformationVerificationDescriptor.EdFi.PersonalInformationVerificationDescriptor,
        Models.Resources.PersonalInformationVerificationDescriptor.EdFi.PersonalInformationVerificationDescriptor,
        Entities.Common.EdFi.IPersonalInformationVerificationDescriptor,
        Entities.NHibernate.PersonalInformationVerificationDescriptorAggregate.EdFi.PersonalInformationVerificationDescriptor,
        Api.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorPut,
        Api.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorPost,
        Api.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorDelete,
        Api.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorGetByExample>
    {
        public PersonalInformationVerificationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PersonalInformationVerificationDescriptors.EdFi.PersonalInformationVerificationDescriptorGetByExample request, IPersonalInformationVerificationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PersonalInformationVerificationDescriptorId = request.PersonalInformationVerificationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "personalInformationVerificationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PlatformTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PlatformTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.PlatformTypeDescriptor.EdFi.PlatformTypeDescriptor,
        Models.Resources.PlatformTypeDescriptor.EdFi.PlatformTypeDescriptor,
        Entities.Common.EdFi.IPlatformTypeDescriptor,
        Entities.NHibernate.PlatformTypeDescriptorAggregate.EdFi.PlatformTypeDescriptor,
        Api.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorPut,
        Api.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorPost,
        Api.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorDelete,
        Api.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorGetByExample>
    {
        public PlatformTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PlatformTypeDescriptors.EdFi.PlatformTypeDescriptorGetByExample request, IPlatformTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PlatformTypeDescriptorId = request.PlatformTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "platformTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PopulationServedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PopulationServedDescriptorsController : EdFiControllerBase<
        Models.Resources.PopulationServedDescriptor.EdFi.PopulationServedDescriptor,
        Models.Resources.PopulationServedDescriptor.EdFi.PopulationServedDescriptor,
        Entities.Common.EdFi.IPopulationServedDescriptor,
        Entities.NHibernate.PopulationServedDescriptorAggregate.EdFi.PopulationServedDescriptor,
        Api.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorPut,
        Api.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorPost,
        Api.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorDelete,
        Api.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorGetByExample>
    {
        public PopulationServedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PopulationServedDescriptors.EdFi.PopulationServedDescriptorGetByExample request, IPopulationServedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PopulationServedDescriptorId = request.PopulationServedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "populationServedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostingResultDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PostingResultDescriptorsController : EdFiControllerBase<
        Models.Resources.PostingResultDescriptor.EdFi.PostingResultDescriptor,
        Models.Resources.PostingResultDescriptor.EdFi.PostingResultDescriptor,
        Entities.Common.EdFi.IPostingResultDescriptor,
        Entities.NHibernate.PostingResultDescriptorAggregate.EdFi.PostingResultDescriptor,
        Api.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorPut,
        Api.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorPost,
        Api.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorDelete,
        Api.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorGetByExample>
    {
        public PostingResultDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PostingResultDescriptors.EdFi.PostingResultDescriptorGetByExample request, IPostingResultDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PostingResultDescriptorId = request.PostingResultDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "postingResultDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PostSecondaryEventsController : EdFiControllerBase<
        Models.Resources.PostSecondaryEvent.EdFi.PostSecondaryEvent,
        Models.Resources.PostSecondaryEvent.EdFi.PostSecondaryEvent,
        Entities.Common.EdFi.IPostSecondaryEvent,
        Entities.NHibernate.PostSecondaryEventAggregate.EdFi.PostSecondaryEvent,
        Api.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventPut,
        Api.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventPost,
        Api.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventDelete,
        Api.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventGetByExample>
    {
        public PostSecondaryEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PostSecondaryEvents.EdFi.PostSecondaryEventGetByExample request, IPostSecondaryEvent specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EventDate = request.EventDate;
            specification.Id = request.Id;
            specification.PostSecondaryEventCategoryDescriptor = request.PostSecondaryEventCategoryDescriptor;
            specification.PostSecondaryInstitutionId = request.PostSecondaryInstitutionId;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "postSecondaryEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PostSecondaryEventCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.PostSecondaryEventCategoryDescriptor.EdFi.PostSecondaryEventCategoryDescriptor,
        Models.Resources.PostSecondaryEventCategoryDescriptor.EdFi.PostSecondaryEventCategoryDescriptor,
        Entities.Common.EdFi.IPostSecondaryEventCategoryDescriptor,
        Entities.NHibernate.PostSecondaryEventCategoryDescriptorAggregate.EdFi.PostSecondaryEventCategoryDescriptor,
        Api.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorPut,
        Api.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorPost,
        Api.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorDelete,
        Api.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorGetByExample>
    {
        public PostSecondaryEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi.PostSecondaryEventCategoryDescriptorGetByExample request, IPostSecondaryEventCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PostSecondaryEventCategoryDescriptorId = request.PostSecondaryEventCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "postSecondaryEventCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryInstitutions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PostSecondaryInstitutionsController : EdFiControllerBase<
        Models.Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution,
        Models.Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution,
        Entities.Common.EdFi.IPostSecondaryInstitution,
        Entities.NHibernate.PostSecondaryInstitutionAggregate.EdFi.PostSecondaryInstitution,
        Api.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionPut,
        Api.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionPost,
        Api.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionDelete,
        Api.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionGetByExample>
    {
        public PostSecondaryInstitutionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PostSecondaryInstitutions.EdFi.PostSecondaryInstitutionGetByExample request, IPostSecondaryInstitution specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrativeFundingControlDescriptor = request.AdministrativeFundingControlDescriptor;
            specification.PostSecondaryInstitutionId = request.PostSecondaryInstitutionId;
            specification.PostSecondaryInstitutionLevelDescriptor = request.PostSecondaryInstitutionLevelDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "postSecondaryInstitutions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PostSecondaryInstitutionLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PostSecondaryInstitutionLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.PostSecondaryInstitutionLevelDescriptor.EdFi.PostSecondaryInstitutionLevelDescriptor,
        Models.Resources.PostSecondaryInstitutionLevelDescriptor.EdFi.PostSecondaryInstitutionLevelDescriptor,
        Entities.Common.EdFi.IPostSecondaryInstitutionLevelDescriptor,
        Entities.NHibernate.PostSecondaryInstitutionLevelDescriptorAggregate.EdFi.PostSecondaryInstitutionLevelDescriptor,
        Api.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorPut,
        Api.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorPost,
        Api.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorDelete,
        Api.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorGetByExample>
    {
        public PostSecondaryInstitutionLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi.PostSecondaryInstitutionLevelDescriptorGetByExample request, IPostSecondaryInstitutionLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PostSecondaryInstitutionLevelDescriptorId = request.PostSecondaryInstitutionLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "postSecondaryInstitutionLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProficiencyDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProficiencyDescriptorsController : EdFiControllerBase<
        Models.Resources.ProficiencyDescriptor.EdFi.ProficiencyDescriptor,
        Models.Resources.ProficiencyDescriptor.EdFi.ProficiencyDescriptor,
        Entities.Common.EdFi.IProficiencyDescriptor,
        Entities.NHibernate.ProficiencyDescriptorAggregate.EdFi.ProficiencyDescriptor,
        Api.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorPut,
        Api.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorPost,
        Api.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorDelete,
        Api.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorGetByExample>
    {
        public ProficiencyDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProficiencyDescriptors.EdFi.ProficiencyDescriptorGetByExample request, IProficiencyDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProficiencyDescriptorId = request.ProficiencyDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "proficiencyDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Programs.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgramsController : EdFiControllerBase<
        Models.Resources.Program.EdFi.Program,
        Models.Resources.Program.EdFi.Program,
        Entities.Common.EdFi.IProgram,
        Entities.NHibernate.ProgramAggregate.EdFi.Program,
        Api.Models.Requests.Programs.EdFi.ProgramPut,
        Api.Models.Requests.Programs.EdFi.ProgramPost,
        Api.Models.Requests.Programs.EdFi.ProgramDelete,
        Api.Models.Requests.Programs.EdFi.ProgramGetByExample>
    {
        public ProgramsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Programs.EdFi.ProgramGetByExample request, IProgram specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.ProgramId = request.ProgramId;
            specification.ProgramName = request.ProgramName;
            specification.ProgramTypeDescriptor = request.ProgramTypeDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "programs";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramAssignmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgramAssignmentDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgramAssignmentDescriptor.EdFi.ProgramAssignmentDescriptor,
        Models.Resources.ProgramAssignmentDescriptor.EdFi.ProgramAssignmentDescriptor,
        Entities.Common.EdFi.IProgramAssignmentDescriptor,
        Entities.NHibernate.ProgramAssignmentDescriptorAggregate.EdFi.ProgramAssignmentDescriptor,
        Api.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorPut,
        Api.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorPost,
        Api.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorDelete,
        Api.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorGetByExample>
    {
        public ProgramAssignmentDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProgramAssignmentDescriptors.EdFi.ProgramAssignmentDescriptorGetByExample request, IProgramAssignmentDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramAssignmentDescriptorId = request.ProgramAssignmentDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "programAssignmentDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgramCharacteristicDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgramCharacteristicDescriptor.EdFi.ProgramCharacteristicDescriptor,
        Models.Resources.ProgramCharacteristicDescriptor.EdFi.ProgramCharacteristicDescriptor,
        Entities.Common.EdFi.IProgramCharacteristicDescriptor,
        Entities.NHibernate.ProgramCharacteristicDescriptorAggregate.EdFi.ProgramCharacteristicDescriptor,
        Api.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorPut,
        Api.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorPost,
        Api.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorDelete,
        Api.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorGetByExample>
    {
        public ProgramCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProgramCharacteristicDescriptors.EdFi.ProgramCharacteristicDescriptorGetByExample request, IProgramCharacteristicDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramCharacteristicDescriptorId = request.ProgramCharacteristicDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "programCharacteristicDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramSponsorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgramSponsorDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgramSponsorDescriptor.EdFi.ProgramSponsorDescriptor,
        Models.Resources.ProgramSponsorDescriptor.EdFi.ProgramSponsorDescriptor,
        Entities.Common.EdFi.IProgramSponsorDescriptor,
        Entities.NHibernate.ProgramSponsorDescriptorAggregate.EdFi.ProgramSponsorDescriptor,
        Api.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorPut,
        Api.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorPost,
        Api.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorDelete,
        Api.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorGetByExample>
    {
        public ProgramSponsorDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProgramSponsorDescriptors.EdFi.ProgramSponsorDescriptorGetByExample request, IProgramSponsorDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramSponsorDescriptorId = request.ProgramSponsorDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "programSponsorDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgramTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgramTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgramTypeDescriptor.EdFi.ProgramTypeDescriptor,
        Models.Resources.ProgramTypeDescriptor.EdFi.ProgramTypeDescriptor,
        Entities.Common.EdFi.IProgramTypeDescriptor,
        Entities.NHibernate.ProgramTypeDescriptorAggregate.EdFi.ProgramTypeDescriptor,
        Api.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorPut,
        Api.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorPost,
        Api.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorDelete,
        Api.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorGetByExample>
    {
        public ProgramTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProgramTypeDescriptors.EdFi.ProgramTypeDescriptorGetByExample request, IProgramTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgramTypeDescriptorId = request.ProgramTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "programTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgressDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgressDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgressDescriptor.EdFi.ProgressDescriptor,
        Models.Resources.ProgressDescriptor.EdFi.ProgressDescriptor,
        Entities.Common.EdFi.IProgressDescriptor,
        Entities.NHibernate.ProgressDescriptorAggregate.EdFi.ProgressDescriptor,
        Api.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorPut,
        Api.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorPost,
        Api.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorDelete,
        Api.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorGetByExample>
    {
        public ProgressDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProgressDescriptors.EdFi.ProgressDescriptorGetByExample request, IProgressDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgressDescriptorId = request.ProgressDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "progressDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProgressLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProgressLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.ProgressLevelDescriptor.EdFi.ProgressLevelDescriptor,
        Models.Resources.ProgressLevelDescriptor.EdFi.ProgressLevelDescriptor,
        Entities.Common.EdFi.IProgressLevelDescriptor,
        Entities.NHibernate.ProgressLevelDescriptorAggregate.EdFi.ProgressLevelDescriptor,
        Api.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorPut,
        Api.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorPost,
        Api.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorDelete,
        Api.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorGetByExample>
    {
        public ProgressLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProgressLevelDescriptors.EdFi.ProgressLevelDescriptorGetByExample request, IProgressLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProgressLevelDescriptorId = request.ProgressLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "progressLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProviderCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProviderCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.ProviderCategoryDescriptor.EdFi.ProviderCategoryDescriptor,
        Models.Resources.ProviderCategoryDescriptor.EdFi.ProviderCategoryDescriptor,
        Entities.Common.EdFi.IProviderCategoryDescriptor,
        Entities.NHibernate.ProviderCategoryDescriptorAggregate.EdFi.ProviderCategoryDescriptor,
        Api.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorPut,
        Api.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorPost,
        Api.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorDelete,
        Api.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorGetByExample>
    {
        public ProviderCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProviderCategoryDescriptors.EdFi.ProviderCategoryDescriptorGetByExample request, IProviderCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProviderCategoryDescriptorId = request.ProviderCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "providerCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProviderProfitabilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProviderProfitabilityDescriptorsController : EdFiControllerBase<
        Models.Resources.ProviderProfitabilityDescriptor.EdFi.ProviderProfitabilityDescriptor,
        Models.Resources.ProviderProfitabilityDescriptor.EdFi.ProviderProfitabilityDescriptor,
        Entities.Common.EdFi.IProviderProfitabilityDescriptor,
        Entities.NHibernate.ProviderProfitabilityDescriptorAggregate.EdFi.ProviderProfitabilityDescriptor,
        Api.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorPut,
        Api.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorPost,
        Api.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorDelete,
        Api.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorGetByExample>
    {
        public ProviderProfitabilityDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProviderProfitabilityDescriptors.EdFi.ProviderProfitabilityDescriptorGetByExample request, IProviderProfitabilityDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProviderProfitabilityDescriptorId = request.ProviderProfitabilityDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "providerProfitabilityDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ProviderStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ProviderStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.ProviderStatusDescriptor.EdFi.ProviderStatusDescriptor,
        Models.Resources.ProviderStatusDescriptor.EdFi.ProviderStatusDescriptor,
        Entities.Common.EdFi.IProviderStatusDescriptor,
        Entities.NHibernate.ProviderStatusDescriptorAggregate.EdFi.ProviderStatusDescriptor,
        Api.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorPut,
        Api.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorPost,
        Api.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorDelete,
        Api.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorGetByExample>
    {
        public ProviderStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ProviderStatusDescriptors.EdFi.ProviderStatusDescriptorGetByExample request, IProviderStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ProviderStatusDescriptorId = request.ProviderStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "providerStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.PublicationStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class PublicationStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.PublicationStatusDescriptor.EdFi.PublicationStatusDescriptor,
        Models.Resources.PublicationStatusDescriptor.EdFi.PublicationStatusDescriptor,
        Entities.Common.EdFi.IPublicationStatusDescriptor,
        Entities.NHibernate.PublicationStatusDescriptorAggregate.EdFi.PublicationStatusDescriptor,
        Api.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorPut,
        Api.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorPost,
        Api.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorDelete,
        Api.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorGetByExample>
    {
        public PublicationStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.PublicationStatusDescriptors.EdFi.PublicationStatusDescriptorGetByExample request, IPublicationStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.PublicationStatusDescriptorId = request.PublicationStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "publicationStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.QuestionFormDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class QuestionFormDescriptorsController : EdFiControllerBase<
        Models.Resources.QuestionFormDescriptor.EdFi.QuestionFormDescriptor,
        Models.Resources.QuestionFormDescriptor.EdFi.QuestionFormDescriptor,
        Entities.Common.EdFi.IQuestionFormDescriptor,
        Entities.NHibernate.QuestionFormDescriptorAggregate.EdFi.QuestionFormDescriptor,
        Api.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorPut,
        Api.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorPost,
        Api.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorDelete,
        Api.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorGetByExample>
    {
        public QuestionFormDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.QuestionFormDescriptors.EdFi.QuestionFormDescriptorGetByExample request, IQuestionFormDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.QuestionFormDescriptorId = request.QuestionFormDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "questionFormDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RaceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RaceDescriptorsController : EdFiControllerBase<
        Models.Resources.RaceDescriptor.EdFi.RaceDescriptor,
        Models.Resources.RaceDescriptor.EdFi.RaceDescriptor,
        Entities.Common.EdFi.IRaceDescriptor,
        Entities.NHibernate.RaceDescriptorAggregate.EdFi.RaceDescriptor,
        Api.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorPut,
        Api.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorPost,
        Api.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorDelete,
        Api.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorGetByExample>
    {
        public RaceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RaceDescriptors.EdFi.RaceDescriptorGetByExample request, IRaceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RaceDescriptorId = request.RaceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "raceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReasonExitedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ReasonExitedDescriptorsController : EdFiControllerBase<
        Models.Resources.ReasonExitedDescriptor.EdFi.ReasonExitedDescriptor,
        Models.Resources.ReasonExitedDescriptor.EdFi.ReasonExitedDescriptor,
        Entities.Common.EdFi.IReasonExitedDescriptor,
        Entities.NHibernate.ReasonExitedDescriptorAggregate.EdFi.ReasonExitedDescriptor,
        Api.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorPut,
        Api.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorPost,
        Api.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorDelete,
        Api.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorGetByExample>
    {
        public ReasonExitedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ReasonExitedDescriptors.EdFi.ReasonExitedDescriptorGetByExample request, IReasonExitedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReasonExitedDescriptorId = request.ReasonExitedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "reasonExitedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReasonNotTestedDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ReasonNotTestedDescriptorsController : EdFiControllerBase<
        Models.Resources.ReasonNotTestedDescriptor.EdFi.ReasonNotTestedDescriptor,
        Models.Resources.ReasonNotTestedDescriptor.EdFi.ReasonNotTestedDescriptor,
        Entities.Common.EdFi.IReasonNotTestedDescriptor,
        Entities.NHibernate.ReasonNotTestedDescriptorAggregate.EdFi.ReasonNotTestedDescriptor,
        Api.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorPut,
        Api.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorPost,
        Api.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorDelete,
        Api.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorGetByExample>
    {
        public ReasonNotTestedDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ReasonNotTestedDescriptors.EdFi.ReasonNotTestedDescriptorGetByExample request, IReasonNotTestedDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReasonNotTestedDescriptorId = request.ReasonNotTestedDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "reasonNotTestedDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RecognitionTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RecognitionTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.RecognitionTypeDescriptor.EdFi.RecognitionTypeDescriptor,
        Models.Resources.RecognitionTypeDescriptor.EdFi.RecognitionTypeDescriptor,
        Entities.Common.EdFi.IRecognitionTypeDescriptor,
        Entities.NHibernate.RecognitionTypeDescriptorAggregate.EdFi.RecognitionTypeDescriptor,
        Api.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorPut,
        Api.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorPost,
        Api.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorDelete,
        Api.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorGetByExample>
    {
        public RecognitionTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RecognitionTypeDescriptors.EdFi.RecognitionTypeDescriptorGetByExample request, IRecognitionTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RecognitionTypeDescriptorId = request.RecognitionTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "recognitionTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RelationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RelationDescriptorsController : EdFiControllerBase<
        Models.Resources.RelationDescriptor.EdFi.RelationDescriptor,
        Models.Resources.RelationDescriptor.EdFi.RelationDescriptor,
        Entities.Common.EdFi.IRelationDescriptor,
        Entities.NHibernate.RelationDescriptorAggregate.EdFi.RelationDescriptor,
        Api.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorPut,
        Api.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorPost,
        Api.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorDelete,
        Api.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorGetByExample>
    {
        public RelationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RelationDescriptors.EdFi.RelationDescriptorGetByExample request, IRelationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RelationDescriptorId = request.RelationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "relationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RepeatIdentifierDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RepeatIdentifierDescriptorsController : EdFiControllerBase<
        Models.Resources.RepeatIdentifierDescriptor.EdFi.RepeatIdentifierDescriptor,
        Models.Resources.RepeatIdentifierDescriptor.EdFi.RepeatIdentifierDescriptor,
        Entities.Common.EdFi.IRepeatIdentifierDescriptor,
        Entities.NHibernate.RepeatIdentifierDescriptorAggregate.EdFi.RepeatIdentifierDescriptor,
        Api.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorPut,
        Api.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorPost,
        Api.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorDelete,
        Api.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorGetByExample>
    {
        public RepeatIdentifierDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RepeatIdentifierDescriptors.EdFi.RepeatIdentifierDescriptorGetByExample request, IRepeatIdentifierDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RepeatIdentifierDescriptorId = request.RepeatIdentifierDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "repeatIdentifierDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReportCards.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ReportCardsController : EdFiControllerBase<
        Models.Resources.ReportCard.EdFi.ReportCard,
        Models.Resources.ReportCard.EdFi.ReportCard,
        Entities.Common.EdFi.IReportCard,
        Entities.NHibernate.ReportCardAggregate.EdFi.ReportCard,
        Api.Models.Requests.ReportCards.EdFi.ReportCardPut,
        Api.Models.Requests.ReportCards.EdFi.ReportCardPost,
        Api.Models.Requests.ReportCards.EdFi.ReportCardDelete,
        Api.Models.Requests.ReportCards.EdFi.ReportCardGetByExample>
    {
        public ReportCardsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ReportCards.EdFi.ReportCardGetByExample request, IReportCard specification)
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

        protected override string GetResourceCollectionName()
        {
            return "reportCards";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ReporterDescriptionDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ReporterDescriptionDescriptorsController : EdFiControllerBase<
        Models.Resources.ReporterDescriptionDescriptor.EdFi.ReporterDescriptionDescriptor,
        Models.Resources.ReporterDescriptionDescriptor.EdFi.ReporterDescriptionDescriptor,
        Entities.Common.EdFi.IReporterDescriptionDescriptor,
        Entities.NHibernate.ReporterDescriptionDescriptorAggregate.EdFi.ReporterDescriptionDescriptor,
        Api.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorPut,
        Api.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorPost,
        Api.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorDelete,
        Api.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorGetByExample>
    {
        public ReporterDescriptionDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ReporterDescriptionDescriptors.EdFi.ReporterDescriptionDescriptorGetByExample request, IReporterDescriptionDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ReporterDescriptionDescriptorId = request.ReporterDescriptionDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "reporterDescriptionDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResidencyStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ResidencyStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.ResidencyStatusDescriptor.EdFi.ResidencyStatusDescriptor,
        Models.Resources.ResidencyStatusDescriptor.EdFi.ResidencyStatusDescriptor,
        Entities.Common.EdFi.IResidencyStatusDescriptor,
        Entities.NHibernate.ResidencyStatusDescriptorAggregate.EdFi.ResidencyStatusDescriptor,
        Api.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorPut,
        Api.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorPost,
        Api.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorDelete,
        Api.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorGetByExample>
    {
        public ResidencyStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ResidencyStatusDescriptors.EdFi.ResidencyStatusDescriptorGetByExample request, IResidencyStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResidencyStatusDescriptorId = request.ResidencyStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "residencyStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResponseIndicatorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ResponseIndicatorDescriptorsController : EdFiControllerBase<
        Models.Resources.ResponseIndicatorDescriptor.EdFi.ResponseIndicatorDescriptor,
        Models.Resources.ResponseIndicatorDescriptor.EdFi.ResponseIndicatorDescriptor,
        Entities.Common.EdFi.IResponseIndicatorDescriptor,
        Entities.NHibernate.ResponseIndicatorDescriptorAggregate.EdFi.ResponseIndicatorDescriptor,
        Api.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorPut,
        Api.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorPost,
        Api.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorDelete,
        Api.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorGetByExample>
    {
        public ResponseIndicatorDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ResponseIndicatorDescriptors.EdFi.ResponseIndicatorDescriptorGetByExample request, IResponseIndicatorDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResponseIndicatorDescriptorId = request.ResponseIndicatorDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "responseIndicatorDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResponsibilityDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ResponsibilityDescriptorsController : EdFiControllerBase<
        Models.Resources.ResponsibilityDescriptor.EdFi.ResponsibilityDescriptor,
        Models.Resources.ResponsibilityDescriptor.EdFi.ResponsibilityDescriptor,
        Entities.Common.EdFi.IResponsibilityDescriptor,
        Entities.NHibernate.ResponsibilityDescriptorAggregate.EdFi.ResponsibilityDescriptor,
        Api.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorPut,
        Api.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorPost,
        Api.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorDelete,
        Api.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorGetByExample>
    {
        public ResponsibilityDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ResponsibilityDescriptors.EdFi.ResponsibilityDescriptorGetByExample request, IResponsibilityDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResponsibilityDescriptorId = request.ResponsibilityDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "responsibilityDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RestraintEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RestraintEventsController : EdFiControllerBase<
        Models.Resources.RestraintEvent.EdFi.RestraintEvent,
        Models.Resources.RestraintEvent.EdFi.RestraintEvent,
        Entities.Common.EdFi.IRestraintEvent,
        Entities.NHibernate.RestraintEventAggregate.EdFi.RestraintEvent,
        Api.Models.Requests.RestraintEvents.EdFi.RestraintEventPut,
        Api.Models.Requests.RestraintEvents.EdFi.RestraintEventPost,
        Api.Models.Requests.RestraintEvents.EdFi.RestraintEventDelete,
        Api.Models.Requests.RestraintEvents.EdFi.RestraintEventGetByExample>
    {
        public RestraintEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RestraintEvents.EdFi.RestraintEventGetByExample request, IRestraintEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "restraintEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RestraintEventReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RestraintEventReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.RestraintEventReasonDescriptor.EdFi.RestraintEventReasonDescriptor,
        Models.Resources.RestraintEventReasonDescriptor.EdFi.RestraintEventReasonDescriptor,
        Entities.Common.EdFi.IRestraintEventReasonDescriptor,
        Entities.NHibernate.RestraintEventReasonDescriptorAggregate.EdFi.RestraintEventReasonDescriptor,
        Api.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorPut,
        Api.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorPost,
        Api.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorDelete,
        Api.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorGetByExample>
    {
        public RestraintEventReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RestraintEventReasonDescriptors.EdFi.RestraintEventReasonDescriptorGetByExample request, IRestraintEventReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RestraintEventReasonDescriptorId = request.RestraintEventReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "restraintEventReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ResultDatatypeTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ResultDatatypeTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.ResultDatatypeTypeDescriptor.EdFi.ResultDatatypeTypeDescriptor,
        Models.Resources.ResultDatatypeTypeDescriptor.EdFi.ResultDatatypeTypeDescriptor,
        Entities.Common.EdFi.IResultDatatypeTypeDescriptor,
        Entities.NHibernate.ResultDatatypeTypeDescriptorAggregate.EdFi.ResultDatatypeTypeDescriptor,
        Api.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorPut,
        Api.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorPost,
        Api.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorDelete,
        Api.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorGetByExample>
    {
        public ResultDatatypeTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ResultDatatypeTypeDescriptors.EdFi.ResultDatatypeTypeDescriptorGetByExample request, IResultDatatypeTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ResultDatatypeTypeDescriptorId = request.ResultDatatypeTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "resultDatatypeTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.RetestIndicatorDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class RetestIndicatorDescriptorsController : EdFiControllerBase<
        Models.Resources.RetestIndicatorDescriptor.EdFi.RetestIndicatorDescriptor,
        Models.Resources.RetestIndicatorDescriptor.EdFi.RetestIndicatorDescriptor,
        Entities.Common.EdFi.IRetestIndicatorDescriptor,
        Entities.NHibernate.RetestIndicatorDescriptorAggregate.EdFi.RetestIndicatorDescriptor,
        Api.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorPut,
        Api.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorPost,
        Api.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorDelete,
        Api.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorGetByExample>
    {
        public RetestIndicatorDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.RetestIndicatorDescriptors.EdFi.RetestIndicatorDescriptorGetByExample request, IRetestIndicatorDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.RetestIndicatorDescriptorId = request.RetestIndicatorDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "retestIndicatorDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Schools.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolsController : EdFiControllerBase<
        Models.Resources.School.EdFi.School,
        Models.Resources.School.EdFi.School,
        Entities.Common.EdFi.ISchool,
        Entities.NHibernate.SchoolAggregate.EdFi.School,
        Api.Models.Requests.Schools.EdFi.SchoolPut,
        Api.Models.Requests.Schools.EdFi.SchoolPost,
        Api.Models.Requests.Schools.EdFi.SchoolDelete,
        Api.Models.Requests.Schools.EdFi.SchoolGetByExample>
    {
        public SchoolsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Schools.EdFi.SchoolGetByExample request, ISchool specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.SchoolCategoryDescriptor.EdFi.SchoolCategoryDescriptor,
        Models.Resources.SchoolCategoryDescriptor.EdFi.SchoolCategoryDescriptor,
        Entities.Common.EdFi.ISchoolCategoryDescriptor,
        Entities.NHibernate.SchoolCategoryDescriptorAggregate.EdFi.SchoolCategoryDescriptor,
        Api.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorPut,
        Api.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorPost,
        Api.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorDelete,
        Api.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorGetByExample>
    {
        public SchoolCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SchoolCategoryDescriptors.EdFi.SchoolCategoryDescriptorGetByExample request, ISchoolCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolCategoryDescriptorId = request.SchoolCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schoolCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolChoiceImplementStatusDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolChoiceImplementStatusDescriptorsController : EdFiControllerBase<
        Models.Resources.SchoolChoiceImplementStatusDescriptor.EdFi.SchoolChoiceImplementStatusDescriptor,
        Models.Resources.SchoolChoiceImplementStatusDescriptor.EdFi.SchoolChoiceImplementStatusDescriptor,
        Entities.Common.EdFi.ISchoolChoiceImplementStatusDescriptor,
        Entities.NHibernate.SchoolChoiceImplementStatusDescriptorAggregate.EdFi.SchoolChoiceImplementStatusDescriptor,
        Api.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorPut,
        Api.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorPost,
        Api.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorDelete,
        Api.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorGetByExample>
    {
        public SchoolChoiceImplementStatusDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi.SchoolChoiceImplementStatusDescriptorGetByExample request, ISchoolChoiceImplementStatusDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolChoiceImplementStatusDescriptorId = request.SchoolChoiceImplementStatusDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schoolChoiceImplementStatusDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolFoodServiceProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolFoodServiceProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.SchoolFoodServiceProgramServiceDescriptor.EdFi.SchoolFoodServiceProgramServiceDescriptor,
        Models.Resources.SchoolFoodServiceProgramServiceDescriptor.EdFi.SchoolFoodServiceProgramServiceDescriptor,
        Entities.Common.EdFi.ISchoolFoodServiceProgramServiceDescriptor,
        Entities.NHibernate.SchoolFoodServiceProgramServiceDescriptorAggregate.EdFi.SchoolFoodServiceProgramServiceDescriptor,
        Api.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorPut,
        Api.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorPost,
        Api.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorDelete,
        Api.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorGetByExample>
    {
        public SchoolFoodServiceProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi.SchoolFoodServiceProgramServiceDescriptorGetByExample request, ISchoolFoodServiceProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolFoodServiceProgramServiceDescriptorId = request.SchoolFoodServiceProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schoolFoodServiceProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.SchoolTypeDescriptor.EdFi.SchoolTypeDescriptor,
        Models.Resources.SchoolTypeDescriptor.EdFi.SchoolTypeDescriptor,
        Entities.Common.EdFi.ISchoolTypeDescriptor,
        Entities.NHibernate.SchoolTypeDescriptorAggregate.EdFi.SchoolTypeDescriptor,
        Api.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorPut,
        Api.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorPost,
        Api.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorDelete,
        Api.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorGetByExample>
    {
        public SchoolTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SchoolTypeDescriptors.EdFi.SchoolTypeDescriptorGetByExample request, ISchoolTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SchoolTypeDescriptorId = request.SchoolTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schoolTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SchoolYearTypes.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SchoolYearTypesController : EdFiControllerBase<
        Models.Resources.SchoolYearType.EdFi.SchoolYearType,
        Models.Resources.SchoolYearType.EdFi.SchoolYearType,
        Entities.Common.EdFi.ISchoolYearType,
        Entities.NHibernate.SchoolYearTypeAggregate.EdFi.SchoolYearType,
        Api.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypePut,
        Api.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypePost,
        Api.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypeDelete,
        Api.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypeGetByExample>
    {
        public SchoolYearTypesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SchoolYearTypes.EdFi.SchoolYearTypeGetByExample request, ISchoolYearType specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CurrentSchoolYear = request.CurrentSchoolYear;
            specification.Id = request.Id;
            specification.SchoolYear = request.SchoolYear;
            specification.SchoolYearDescription = request.SchoolYearDescription;
                    }

        protected override string GetResourceCollectionName()
        {
            return "schoolYearTypes";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sections.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionsController : EdFiControllerBase<
        Models.Resources.Section.EdFi.Section,
        Models.Resources.Section.EdFi.Section,
        Entities.Common.EdFi.ISection,
        Entities.NHibernate.SectionAggregate.EdFi.Section,
        Api.Models.Requests.Sections.EdFi.SectionPut,
        Api.Models.Requests.Sections.EdFi.SectionPost,
        Api.Models.Requests.Sections.EdFi.SectionDelete,
        Api.Models.Requests.Sections.EdFi.SectionGetByExample>
    {
        public SectionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sections.EdFi.SectionGetByExample request, ISection specification)
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

        protected override string GetResourceCollectionName()
        {
            return "sections";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SectionAttendanceTakenEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionAttendanceTakenEventsController : EdFiControllerBase<
        Models.Resources.SectionAttendanceTakenEvent.EdFi.SectionAttendanceTakenEvent,
        Models.Resources.SectionAttendanceTakenEvent.EdFi.SectionAttendanceTakenEvent,
        Entities.Common.EdFi.ISectionAttendanceTakenEvent,
        Entities.NHibernate.SectionAttendanceTakenEventAggregate.EdFi.SectionAttendanceTakenEvent,
        Api.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventPut,
        Api.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventPost,
        Api.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventDelete,
        Api.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventGetByExample>
    {
        public SectionAttendanceTakenEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SectionAttendanceTakenEvents.EdFi.SectionAttendanceTakenEventGetByExample request, ISectionAttendanceTakenEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "sectionAttendanceTakenEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SectionCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SectionCharacteristicDescriptorsController : EdFiControllerBase<
        Models.Resources.SectionCharacteristicDescriptor.EdFi.SectionCharacteristicDescriptor,
        Models.Resources.SectionCharacteristicDescriptor.EdFi.SectionCharacteristicDescriptor,
        Entities.Common.EdFi.ISectionCharacteristicDescriptor,
        Entities.NHibernate.SectionCharacteristicDescriptorAggregate.EdFi.SectionCharacteristicDescriptor,
        Api.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorPut,
        Api.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorPost,
        Api.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorDelete,
        Api.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorGetByExample>
    {
        public SectionCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SectionCharacteristicDescriptors.EdFi.SectionCharacteristicDescriptorGetByExample request, ISectionCharacteristicDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SectionCharacteristicDescriptorId = request.SectionCharacteristicDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sectionCharacteristicDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SeparationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SeparationDescriptorsController : EdFiControllerBase<
        Models.Resources.SeparationDescriptor.EdFi.SeparationDescriptor,
        Models.Resources.SeparationDescriptor.EdFi.SeparationDescriptor,
        Entities.Common.EdFi.ISeparationDescriptor,
        Entities.NHibernate.SeparationDescriptorAggregate.EdFi.SeparationDescriptor,
        Api.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorPut,
        Api.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorPost,
        Api.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorDelete,
        Api.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorGetByExample>
    {
        public SeparationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SeparationDescriptors.EdFi.SeparationDescriptorGetByExample request, ISeparationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SeparationDescriptorId = request.SeparationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "separationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SeparationReasonDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SeparationReasonDescriptorsController : EdFiControllerBase<
        Models.Resources.SeparationReasonDescriptor.EdFi.SeparationReasonDescriptor,
        Models.Resources.SeparationReasonDescriptor.EdFi.SeparationReasonDescriptor,
        Entities.Common.EdFi.ISeparationReasonDescriptor,
        Entities.NHibernate.SeparationReasonDescriptorAggregate.EdFi.SeparationReasonDescriptor,
        Api.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorPut,
        Api.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorPost,
        Api.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorDelete,
        Api.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorGetByExample>
    {
        public SeparationReasonDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SeparationReasonDescriptors.EdFi.SeparationReasonDescriptorGetByExample request, ISeparationReasonDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SeparationReasonDescriptorId = request.SeparationReasonDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "separationReasonDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.ServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class ServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.ServiceDescriptor.EdFi.ServiceDescriptor,
        Models.Resources.ServiceDescriptor.EdFi.ServiceDescriptor,
        Entities.Common.EdFi.IServiceDescriptor,
        Entities.NHibernate.ServiceDescriptorAggregate.EdFi.ServiceDescriptor,
        Api.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorPut,
        Api.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorPost,
        Api.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorDelete,
        Api.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorGetByExample>
    {
        public ServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.ServiceDescriptors.EdFi.ServiceDescriptorGetByExample request, IServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ServiceDescriptorId = request.ServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "serviceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Sessions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SessionsController : EdFiControllerBase<
        Models.Resources.Session.EdFi.Session,
        Models.Resources.Session.EdFi.Session,
        Entities.Common.EdFi.ISession,
        Entities.NHibernate.SessionAggregate.EdFi.Session,
        Api.Models.Requests.Sessions.EdFi.SessionPut,
        Api.Models.Requests.Sessions.EdFi.SessionPost,
        Api.Models.Requests.Sessions.EdFi.SessionDelete,
        Api.Models.Requests.Sessions.EdFi.SessionGetByExample>
    {
        public SessionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Sessions.EdFi.SessionGetByExample request, ISession specification)
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

        protected override string GetResourceCollectionName()
        {
            return "sessions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SexDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SexDescriptorsController : EdFiControllerBase<
        Models.Resources.SexDescriptor.EdFi.SexDescriptor,
        Models.Resources.SexDescriptor.EdFi.SexDescriptor,
        Entities.Common.EdFi.ISexDescriptor,
        Entities.NHibernate.SexDescriptorAggregate.EdFi.SexDescriptor,
        Api.Models.Requests.SexDescriptors.EdFi.SexDescriptorPut,
        Api.Models.Requests.SexDescriptors.EdFi.SexDescriptorPost,
        Api.Models.Requests.SexDescriptors.EdFi.SexDescriptorDelete,
        Api.Models.Requests.SexDescriptors.EdFi.SexDescriptorGetByExample>
    {
        public SexDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SexDescriptors.EdFi.SexDescriptorGetByExample request, ISexDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SexDescriptorId = request.SexDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sexDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SourceSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SourceSystemDescriptorsController : EdFiControllerBase<
        Models.Resources.SourceSystemDescriptor.EdFi.SourceSystemDescriptor,
        Models.Resources.SourceSystemDescriptor.EdFi.SourceSystemDescriptor,
        Entities.Common.EdFi.ISourceSystemDescriptor,
        Entities.NHibernate.SourceSystemDescriptorAggregate.EdFi.SourceSystemDescriptor,
        Api.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorPut,
        Api.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorPost,
        Api.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorDelete,
        Api.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorGetByExample>
    {
        public SourceSystemDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SourceSystemDescriptors.EdFi.SourceSystemDescriptorGetByExample request, ISourceSystemDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SourceSystemDescriptorId = request.SourceSystemDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "sourceSystemDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SpecialEducationProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SpecialEducationProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.SpecialEducationProgramServiceDescriptor.EdFi.SpecialEducationProgramServiceDescriptor,
        Models.Resources.SpecialEducationProgramServiceDescriptor.EdFi.SpecialEducationProgramServiceDescriptor,
        Entities.Common.EdFi.ISpecialEducationProgramServiceDescriptor,
        Entities.NHibernate.SpecialEducationProgramServiceDescriptorAggregate.EdFi.SpecialEducationProgramServiceDescriptor,
        Api.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorPut,
        Api.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorPost,
        Api.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorDelete,
        Api.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorGetByExample>
    {
        public SpecialEducationProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi.SpecialEducationProgramServiceDescriptorGetByExample request, ISpecialEducationProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SpecialEducationProgramServiceDescriptorId = request.SpecialEducationProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "specialEducationProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SpecialEducationSettingDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SpecialEducationSettingDescriptorsController : EdFiControllerBase<
        Models.Resources.SpecialEducationSettingDescriptor.EdFi.SpecialEducationSettingDescriptor,
        Models.Resources.SpecialEducationSettingDescriptor.EdFi.SpecialEducationSettingDescriptor,
        Entities.Common.EdFi.ISpecialEducationSettingDescriptor,
        Entities.NHibernate.SpecialEducationSettingDescriptorAggregate.EdFi.SpecialEducationSettingDescriptor,
        Api.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorPut,
        Api.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorPost,
        Api.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorDelete,
        Api.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorGetByExample>
    {
        public SpecialEducationSettingDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SpecialEducationSettingDescriptors.EdFi.SpecialEducationSettingDescriptorGetByExample request, ISpecialEducationSettingDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SpecialEducationSettingDescriptorId = request.SpecialEducationSettingDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "specialEducationSettingDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Staffs.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffsController : EdFiControllerBase<
        Models.Resources.Staff.EdFi.Staff,
        Models.Resources.Staff.EdFi.Staff,
        Entities.Common.EdFi.IStaff,
        Entities.NHibernate.StaffAggregate.EdFi.Staff,
        Api.Models.Requests.Staffs.EdFi.StaffPut,
        Api.Models.Requests.Staffs.EdFi.StaffPost,
        Api.Models.Requests.Staffs.EdFi.StaffDelete,
        Api.Models.Requests.Staffs.EdFi.StaffGetByExample>
    {
        public StaffsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Staffs.EdFi.StaffGetByExample request, IStaff specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffAbsenceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffAbsenceEventsController : EdFiControllerBase<
        Models.Resources.StaffAbsenceEvent.EdFi.StaffAbsenceEvent,
        Models.Resources.StaffAbsenceEvent.EdFi.StaffAbsenceEvent,
        Entities.Common.EdFi.IStaffAbsenceEvent,
        Entities.NHibernate.StaffAbsenceEventAggregate.EdFi.StaffAbsenceEvent,
        Api.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventPut,
        Api.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventPost,
        Api.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventDelete,
        Api.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventGetByExample>
    {
        public StaffAbsenceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffAbsenceEvents.EdFi.StaffAbsenceEventGetByExample request, IStaffAbsenceEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffAbsenceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffClassificationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffClassificationDescriptorsController : EdFiControllerBase<
        Models.Resources.StaffClassificationDescriptor.EdFi.StaffClassificationDescriptor,
        Models.Resources.StaffClassificationDescriptor.EdFi.StaffClassificationDescriptor,
        Entities.Common.EdFi.IStaffClassificationDescriptor,
        Entities.NHibernate.StaffClassificationDescriptorAggregate.EdFi.StaffClassificationDescriptor,
        Api.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorPut,
        Api.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorPost,
        Api.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorDelete,
        Api.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorGetByExample>
    {
        public StaffClassificationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffClassificationDescriptors.EdFi.StaffClassificationDescriptorGetByExample request, IStaffClassificationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffClassificationDescriptorId = request.StaffClassificationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffClassificationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffCohortAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffCohortAssociationsController : EdFiControllerBase<
        Models.Resources.StaffCohortAssociation.EdFi.StaffCohortAssociation,
        Models.Resources.StaffCohortAssociation.EdFi.StaffCohortAssociation,
        Entities.Common.EdFi.IStaffCohortAssociation,
        Entities.NHibernate.StaffCohortAssociationAggregate.EdFi.StaffCohortAssociation,
        Api.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationPut,
        Api.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationPost,
        Api.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationDelete,
        Api.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationGetByExample>
    {
        public StaffCohortAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffCohortAssociations.EdFi.StaffCohortAssociationGetByExample request, IStaffCohortAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffCohortAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffDisciplineIncidentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffDisciplineIncidentAssociationsController : EdFiControllerBase<
        Models.Resources.StaffDisciplineIncidentAssociation.EdFi.StaffDisciplineIncidentAssociation,
        Models.Resources.StaffDisciplineIncidentAssociation.EdFi.StaffDisciplineIncidentAssociation,
        Entities.Common.EdFi.IStaffDisciplineIncidentAssociation,
        Entities.NHibernate.StaffDisciplineIncidentAssociationAggregate.EdFi.StaffDisciplineIncidentAssociation,
        Api.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationPut,
        Api.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationPost,
        Api.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationDelete,
        Api.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationGetByExample>
    {
        public StaffDisciplineIncidentAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffDisciplineIncidentAssociations.EdFi.StaffDisciplineIncidentAssociationGetByExample request, IStaffDisciplineIncidentAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StaffUniqueId = request.StaffUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffDisciplineIncidentAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffEducationOrganizationAssignmentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEducationOrganizationAssignmentAssociationsController : EdFiControllerBase<
        Models.Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation,
        Models.Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation,
        Entities.Common.EdFi.IStaffEducationOrganizationAssignmentAssociation,
        Entities.NHibernate.StaffEducationOrganizationAssignmentAssociationAggregate.EdFi.StaffEducationOrganizationAssignmentAssociation,
        Api.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationPut,
        Api.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationPost,
        Api.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationDelete,
        Api.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationGetByExample>
    {
        public StaffEducationOrganizationAssignmentAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi.StaffEducationOrganizationAssignmentAssociationGetByExample request, IStaffEducationOrganizationAssignmentAssociation specification)
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
            specification.Id = request.Id;
            specification.OrderOfAssignment = request.OrderOfAssignment;
            specification.PositionTitle = request.PositionTitle;
            specification.StaffClassificationDescriptor = request.StaffClassificationDescriptor;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.StateOfIssueStateAbbreviationDescriptor = request.StateOfIssueStateAbbreviationDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffEducationOrganizationAssignmentAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffEducationOrganizationContactAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEducationOrganizationContactAssociationsController : EdFiControllerBase<
        Models.Resources.StaffEducationOrganizationContactAssociation.EdFi.StaffEducationOrganizationContactAssociation,
        Models.Resources.StaffEducationOrganizationContactAssociation.EdFi.StaffEducationOrganizationContactAssociation,
        Entities.Common.EdFi.IStaffEducationOrganizationContactAssociation,
        Entities.NHibernate.StaffEducationOrganizationContactAssociationAggregate.EdFi.StaffEducationOrganizationContactAssociation,
        Api.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationPut,
        Api.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationPost,
        Api.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationDelete,
        Api.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationGetByExample>
    {
        public StaffEducationOrganizationContactAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi.StaffEducationOrganizationContactAssociationGetByExample request, IStaffEducationOrganizationContactAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffEducationOrganizationContactAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffEducationOrganizationEmploymentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffEducationOrganizationEmploymentAssociationsController : EdFiControllerBase<
        Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation,
        Models.Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation,
        Entities.Common.EdFi.IStaffEducationOrganizationEmploymentAssociation,
        Entities.NHibernate.StaffEducationOrganizationEmploymentAssociationAggregate.EdFi.StaffEducationOrganizationEmploymentAssociation,
        Api.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationPut,
        Api.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationPost,
        Api.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationDelete,
        Api.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationGetByExample>
    {
        public StaffEducationOrganizationEmploymentAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi.StaffEducationOrganizationEmploymentAssociationGetByExample request, IStaffEducationOrganizationEmploymentAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffEducationOrganizationEmploymentAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffIdentificationSystemDescriptorsController : EdFiControllerBase<
        Models.Resources.StaffIdentificationSystemDescriptor.EdFi.StaffIdentificationSystemDescriptor,
        Models.Resources.StaffIdentificationSystemDescriptor.EdFi.StaffIdentificationSystemDescriptor,
        Entities.Common.EdFi.IStaffIdentificationSystemDescriptor,
        Entities.NHibernate.StaffIdentificationSystemDescriptorAggregate.EdFi.StaffIdentificationSystemDescriptor,
        Api.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorPut,
        Api.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorPost,
        Api.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorDelete,
        Api.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorGetByExample>
    {
        public StaffIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffIdentificationSystemDescriptors.EdFi.StaffIdentificationSystemDescriptorGetByExample request, IStaffIdentificationSystemDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffIdentificationSystemDescriptorId = request.StaffIdentificationSystemDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffIdentificationSystemDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffLeaves.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffLeavesController : EdFiControllerBase<
        Models.Resources.StaffLeave.EdFi.StaffLeave,
        Models.Resources.StaffLeave.EdFi.StaffLeave,
        Entities.Common.EdFi.IStaffLeave,
        Entities.NHibernate.StaffLeaveAggregate.EdFi.StaffLeave,
        Api.Models.Requests.StaffLeaves.EdFi.StaffLeavePut,
        Api.Models.Requests.StaffLeaves.EdFi.StaffLeavePost,
        Api.Models.Requests.StaffLeaves.EdFi.StaffLeaveDelete,
        Api.Models.Requests.StaffLeaves.EdFi.StaffLeaveGetByExample>
    {
        public StaffLeavesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffLeaves.EdFi.StaffLeaveGetByExample request, IStaffLeave specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffLeaves";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffLeaveEventCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffLeaveEventCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.StaffLeaveEventCategoryDescriptor.EdFi.StaffLeaveEventCategoryDescriptor,
        Models.Resources.StaffLeaveEventCategoryDescriptor.EdFi.StaffLeaveEventCategoryDescriptor,
        Entities.Common.EdFi.IStaffLeaveEventCategoryDescriptor,
        Entities.NHibernate.StaffLeaveEventCategoryDescriptorAggregate.EdFi.StaffLeaveEventCategoryDescriptor,
        Api.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorPut,
        Api.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorPost,
        Api.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorDelete,
        Api.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorGetByExample>
    {
        public StaffLeaveEventCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi.StaffLeaveEventCategoryDescriptorGetByExample request, IStaffLeaveEventCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StaffLeaveEventCategoryDescriptorId = request.StaffLeaveEventCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "staffLeaveEventCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StaffProgramAssociation.EdFi.StaffProgramAssociation,
        Models.Resources.StaffProgramAssociation.EdFi.StaffProgramAssociation,
        Entities.Common.EdFi.IStaffProgramAssociation,
        Entities.NHibernate.StaffProgramAssociationAggregate.EdFi.StaffProgramAssociation,
        Api.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationPut,
        Api.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationPost,
        Api.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationDelete,
        Api.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationGetByExample>
    {
        public StaffProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffProgramAssociations.EdFi.StaffProgramAssociationGetByExample request, IStaffProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffSchoolAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffSchoolAssociationsController : EdFiControllerBase<
        Models.Resources.StaffSchoolAssociation.EdFi.StaffSchoolAssociation,
        Models.Resources.StaffSchoolAssociation.EdFi.StaffSchoolAssociation,
        Entities.Common.EdFi.IStaffSchoolAssociation,
        Entities.NHibernate.StaffSchoolAssociationAggregate.EdFi.StaffSchoolAssociation,
        Api.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationPut,
        Api.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationPost,
        Api.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationDelete,
        Api.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationGetByExample>
    {
        public StaffSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffSchoolAssociations.EdFi.StaffSchoolAssociationGetByExample request, IStaffSchoolAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffSchoolAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StaffSectionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StaffSectionAssociationsController : EdFiControllerBase<
        Models.Resources.StaffSectionAssociation.EdFi.StaffSectionAssociation,
        Models.Resources.StaffSectionAssociation.EdFi.StaffSectionAssociation,
        Entities.Common.EdFi.IStaffSectionAssociation,
        Entities.NHibernate.StaffSectionAssociationAggregate.EdFi.StaffSectionAssociation,
        Api.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationPut,
        Api.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationPost,
        Api.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationDelete,
        Api.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationGetByExample>
    {
        public StaffSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StaffSectionAssociations.EdFi.StaffSectionAssociationGetByExample request, IStaffSectionAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "staffSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StateAbbreviationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StateAbbreviationDescriptorsController : EdFiControllerBase<
        Models.Resources.StateAbbreviationDescriptor.EdFi.StateAbbreviationDescriptor,
        Models.Resources.StateAbbreviationDescriptor.EdFi.StateAbbreviationDescriptor,
        Entities.Common.EdFi.IStateAbbreviationDescriptor,
        Entities.NHibernate.StateAbbreviationDescriptorAggregate.EdFi.StateAbbreviationDescriptor,
        Api.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorPut,
        Api.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorPost,
        Api.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorDelete,
        Api.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorGetByExample>
    {
        public StateAbbreviationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StateAbbreviationDescriptors.EdFi.StateAbbreviationDescriptorGetByExample request, IStateAbbreviationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StateAbbreviationDescriptorId = request.StateAbbreviationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "stateAbbreviationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StateEducationAgencies.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StateEducationAgenciesController : EdFiControllerBase<
        Models.Resources.StateEducationAgency.EdFi.StateEducationAgency,
        Models.Resources.StateEducationAgency.EdFi.StateEducationAgency,
        Entities.Common.EdFi.IStateEducationAgency,
        Entities.NHibernate.StateEducationAgencyAggregate.EdFi.StateEducationAgency,
        Api.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyPut,
        Api.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyPost,
        Api.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyDelete,
        Api.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyGetByExample>
    {
        public StateEducationAgenciesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StateEducationAgencies.EdFi.StateEducationAgencyGetByExample request, IStateEducationAgency specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StateEducationAgencyId = request.StateEducationAgencyId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "stateEducationAgencies";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Students.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentsController : EdFiControllerBase<
        Models.Resources.Student.EdFi.Student,
        Models.Resources.Student.EdFi.Student,
        Entities.Common.EdFi.IStudent,
        Entities.NHibernate.StudentAggregate.EdFi.Student,
        Api.Models.Requests.Students.EdFi.StudentPut,
        Api.Models.Requests.Students.EdFi.StudentPost,
        Api.Models.Requests.Students.EdFi.StudentDelete,
        Api.Models.Requests.Students.EdFi.StudentGetByExample>
    {
        public StudentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Students.EdFi.StudentGetByExample request, IStudent specification)
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
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAcademicRecords.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentAcademicRecordsController : EdFiControllerBase<
        Models.Resources.StudentAcademicRecord.EdFi.StudentAcademicRecord,
        Models.Resources.StudentAcademicRecord.EdFi.StudentAcademicRecord,
        Entities.Common.EdFi.IStudentAcademicRecord,
        Entities.NHibernate.StudentAcademicRecordAggregate.EdFi.StudentAcademicRecord,
        Api.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordPut,
        Api.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordPost,
        Api.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordDelete,
        Api.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordGetByExample>
    {
        public StudentAcademicRecordsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentAcademicRecords.EdFi.StudentAcademicRecordGetByExample request, IStudentAcademicRecord specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentAcademicRecords";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentAssessments.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentAssessmentsController : EdFiControllerBase<
        Models.Resources.StudentAssessment.EdFi.StudentAssessment,
        Models.Resources.StudentAssessment.EdFi.StudentAssessment,
        Entities.Common.EdFi.IStudentAssessment,
        Entities.NHibernate.StudentAssessmentAggregate.EdFi.StudentAssessment,
        Api.Models.Requests.StudentAssessments.EdFi.StudentAssessmentPut,
        Api.Models.Requests.StudentAssessments.EdFi.StudentAssessmentPost,
        Api.Models.Requests.StudentAssessments.EdFi.StudentAssessmentDelete,
        Api.Models.Requests.StudentAssessments.EdFi.StudentAssessmentGetByExample>
    {
        public StudentAssessmentsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentAssessments.EdFi.StudentAssessmentGetByExample request, IStudentAssessment specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.AdministrationDate = request.AdministrationDate;
            specification.AdministrationEndDate = request.AdministrationEndDate;
            specification.AdministrationEnvironmentDescriptor = request.AdministrationEnvironmentDescriptor;
            specification.AdministrationLanguageDescriptor = request.AdministrationLanguageDescriptor;
            specification.AssessmentIdentifier = request.AssessmentIdentifier;
            specification.EventCircumstanceDescriptor = request.EventCircumstanceDescriptor;
            specification.EventDescription = request.EventDescription;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.PlatformTypeDescriptor = request.PlatformTypeDescriptor;
            specification.ReasonNotTestedDescriptor = request.ReasonNotTestedDescriptor;
            specification.RetestIndicatorDescriptor = request.RetestIndicatorDescriptor;
            specification.SchoolYear = request.SchoolYear;
            specification.SerialNumber = request.SerialNumber;
            specification.StudentAssessmentIdentifier = request.StudentAssessmentIdentifier;
            specification.StudentUniqueId = request.StudentUniqueId;
            specification.WhenAssessedGradeLevelDescriptor = request.WhenAssessedGradeLevelDescriptor;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentAssessments";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCharacteristicDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentCharacteristicDescriptorsController : EdFiControllerBase<
        Models.Resources.StudentCharacteristicDescriptor.EdFi.StudentCharacteristicDescriptor,
        Models.Resources.StudentCharacteristicDescriptor.EdFi.StudentCharacteristicDescriptor,
        Entities.Common.EdFi.IStudentCharacteristicDescriptor,
        Entities.NHibernate.StudentCharacteristicDescriptorAggregate.EdFi.StudentCharacteristicDescriptor,
        Api.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorPut,
        Api.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorPost,
        Api.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorDelete,
        Api.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorGetByExample>
    {
        public StudentCharacteristicDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentCharacteristicDescriptors.EdFi.StudentCharacteristicDescriptorGetByExample request, IStudentCharacteristicDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentCharacteristicDescriptorId = request.StudentCharacteristicDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentCharacteristicDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCohortAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentCohortAssociationsController : EdFiControllerBase<
        Models.Resources.StudentCohortAssociation.EdFi.StudentCohortAssociation,
        Models.Resources.StudentCohortAssociation.EdFi.StudentCohortAssociation,
        Entities.Common.EdFi.IStudentCohortAssociation,
        Entities.NHibernate.StudentCohortAssociationAggregate.EdFi.StudentCohortAssociation,
        Api.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationPut,
        Api.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationPost,
        Api.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationDelete,
        Api.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationGetByExample>
    {
        public StudentCohortAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentCohortAssociations.EdFi.StudentCohortAssociationGetByExample request, IStudentCohortAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentCohortAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCompetencyObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentCompetencyObjectivesController : EdFiControllerBase<
        Models.Resources.StudentCompetencyObjective.EdFi.StudentCompetencyObjective,
        Models.Resources.StudentCompetencyObjective.EdFi.StudentCompetencyObjective,
        Entities.Common.EdFi.IStudentCompetencyObjective,
        Entities.NHibernate.StudentCompetencyObjectiveAggregate.EdFi.StudentCompetencyObjective,
        Api.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectivePut,
        Api.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectivePost,
        Api.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectiveDelete,
        Api.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectiveGetByExample>
    {
        public StudentCompetencyObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentCompetencyObjectives.EdFi.StudentCompetencyObjectiveGetByExample request, IStudentCompetencyObjective specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentCompetencyObjectives";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentCTEProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentCTEProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentCTEProgramAssociation.EdFi.StudentCTEProgramAssociation,
        Models.Resources.StudentCTEProgramAssociation.EdFi.StudentCTEProgramAssociation,
        Entities.Common.EdFi.IStudentCTEProgramAssociation,
        Entities.NHibernate.StudentCTEProgramAssociationAggregate.EdFi.StudentCTEProgramAssociation,
        Api.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationPut,
        Api.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationPost,
        Api.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationDelete,
        Api.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationGetByExample>
    {
        public StudentCTEProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentCTEProgramAssociations.EdFi.StudentCTEProgramAssociationGetByExample request, IStudentCTEProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentCTEProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentDisciplineIncidentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentDisciplineIncidentAssociationsController : EdFiControllerBase<
        Models.Resources.StudentDisciplineIncidentAssociation.EdFi.StudentDisciplineIncidentAssociation,
        Models.Resources.StudentDisciplineIncidentAssociation.EdFi.StudentDisciplineIncidentAssociation,
        Entities.Common.EdFi.IStudentDisciplineIncidentAssociation,
        Entities.NHibernate.StudentDisciplineIncidentAssociationAggregate.EdFi.StudentDisciplineIncidentAssociation,
        Api.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationPut,
        Api.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationPost,
        Api.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationDelete,
        Api.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationGetByExample>
    {
        public StudentDisciplineIncidentAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentDisciplineIncidentAssociations.EdFi.StudentDisciplineIncidentAssociationGetByExample request, IStudentDisciplineIncidentAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.IncidentIdentifier = request.IncidentIdentifier;
            specification.SchoolId = request.SchoolId;
            specification.StudentParticipationCodeDescriptor = request.StudentParticipationCodeDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentDisciplineIncidentAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentEducationOrganizationAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentEducationOrganizationAssociationsController : EdFiControllerBase<
        Models.Resources.StudentEducationOrganizationAssociation.EdFi.StudentEducationOrganizationAssociation,
        Models.Resources.StudentEducationOrganizationAssociation.EdFi.StudentEducationOrganizationAssociation,
        Entities.Common.EdFi.IStudentEducationOrganizationAssociation,
        Entities.NHibernate.StudentEducationOrganizationAssociationAggregate.EdFi.StudentEducationOrganizationAssociation,
        Api.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationPut,
        Api.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationPost,
        Api.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationDelete,
        Api.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationGetByExample>
    {
        public StudentEducationOrganizationAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentEducationOrganizationAssociations.EdFi.StudentEducationOrganizationAssociationGetByExample request, IStudentEducationOrganizationAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.HispanicLatinoEthnicity = request.HispanicLatinoEthnicity;
            specification.Id = request.Id;
            specification.LimitedEnglishProficiencyDescriptor = request.LimitedEnglishProficiencyDescriptor;
            specification.LoginId = request.LoginId;
            specification.OldEthnicityDescriptor = request.OldEthnicityDescriptor;
            specification.ProfileThumbnail = request.ProfileThumbnail;
            specification.SexDescriptor = request.SexDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentEducationOrganizationAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentEducationOrganizationResponsibilityAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentEducationOrganizationResponsibilityAssociationsController : EdFiControllerBase<
        Models.Resources.StudentEducationOrganizationResponsibilityAssociation.EdFi.StudentEducationOrganizationResponsibilityAssociation,
        Models.Resources.StudentEducationOrganizationResponsibilityAssociation.EdFi.StudentEducationOrganizationResponsibilityAssociation,
        Entities.Common.EdFi.IStudentEducationOrganizationResponsibilityAssociation,
        Entities.NHibernate.StudentEducationOrganizationResponsibilityAssociationAggregate.EdFi.StudentEducationOrganizationResponsibilityAssociation,
        Api.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationPut,
        Api.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationPost,
        Api.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationDelete,
        Api.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationGetByExample>
    {
        public StudentEducationOrganizationResponsibilityAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi.StudentEducationOrganizationResponsibilityAssociationGetByExample request, IStudentEducationOrganizationResponsibilityAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentEducationOrganizationResponsibilityAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentGradebookEntries.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentGradebookEntriesController : EdFiControllerBase<
        Models.Resources.StudentGradebookEntry.EdFi.StudentGradebookEntry,
        Models.Resources.StudentGradebookEntry.EdFi.StudentGradebookEntry,
        Entities.Common.EdFi.IStudentGradebookEntry,
        Entities.NHibernate.StudentGradebookEntryAggregate.EdFi.StudentGradebookEntry,
        Api.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryPut,
        Api.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryPost,
        Api.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryDelete,
        Api.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryGetByExample>
    {
        public StudentGradebookEntriesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentGradebookEntries.EdFi.StudentGradebookEntryGetByExample request, IStudentGradebookEntry specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.BeginDate = request.BeginDate;
            specification.CompetencyLevelDescriptor = request.CompetencyLevelDescriptor;
            specification.DateAssigned = request.DateAssigned;
            specification.DateFulfilled = request.DateFulfilled;
            specification.DiagnosticStatement = request.DiagnosticStatement;
            specification.GradebookEntryTitle = request.GradebookEntryTitle;
            specification.Id = request.Id;
            specification.LetterGradeEarned = request.LetterGradeEarned;
            specification.LocalCourseCode = request.LocalCourseCode;
            specification.NumericGradeEarned = request.NumericGradeEarned;
            specification.SchoolId = request.SchoolId;
            specification.SchoolYear = request.SchoolYear;
            specification.SectionIdentifier = request.SectionIdentifier;
            specification.SessionName = request.SessionName;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentGradebookEntries";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentHomelessProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentHomelessProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentHomelessProgramAssociation.EdFi.StudentHomelessProgramAssociation,
        Models.Resources.StudentHomelessProgramAssociation.EdFi.StudentHomelessProgramAssociation,
        Entities.Common.EdFi.IStudentHomelessProgramAssociation,
        Entities.NHibernate.StudentHomelessProgramAssociationAggregate.EdFi.StudentHomelessProgramAssociation,
        Api.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationPut,
        Api.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationPost,
        Api.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationDelete,
        Api.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationGetByExample>
    {
        public StudentHomelessProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentHomelessProgramAssociations.EdFi.StudentHomelessProgramAssociationGetByExample request, IStudentHomelessProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentHomelessProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentIdentificationSystemDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentIdentificationSystemDescriptorsController : EdFiControllerBase<
        Models.Resources.StudentIdentificationSystemDescriptor.EdFi.StudentIdentificationSystemDescriptor,
        Models.Resources.StudentIdentificationSystemDescriptor.EdFi.StudentIdentificationSystemDescriptor,
        Entities.Common.EdFi.IStudentIdentificationSystemDescriptor,
        Entities.NHibernate.StudentIdentificationSystemDescriptorAggregate.EdFi.StudentIdentificationSystemDescriptor,
        Api.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorPut,
        Api.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorPost,
        Api.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorDelete,
        Api.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorGetByExample>
    {
        public StudentIdentificationSystemDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentIdentificationSystemDescriptors.EdFi.StudentIdentificationSystemDescriptorGetByExample request, IStudentIdentificationSystemDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentIdentificationSystemDescriptorId = request.StudentIdentificationSystemDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentIdentificationSystemDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentInterventionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentInterventionAssociationsController : EdFiControllerBase<
        Models.Resources.StudentInterventionAssociation.EdFi.StudentInterventionAssociation,
        Models.Resources.StudentInterventionAssociation.EdFi.StudentInterventionAssociation,
        Entities.Common.EdFi.IStudentInterventionAssociation,
        Entities.NHibernate.StudentInterventionAssociationAggregate.EdFi.StudentInterventionAssociation,
        Api.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationPut,
        Api.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationPost,
        Api.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationDelete,
        Api.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationGetByExample>
    {
        public StudentInterventionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentInterventionAssociations.EdFi.StudentInterventionAssociationGetByExample request, IStudentInterventionAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentInterventionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentInterventionAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentInterventionAttendanceEventsController : EdFiControllerBase<
        Models.Resources.StudentInterventionAttendanceEvent.EdFi.StudentInterventionAttendanceEvent,
        Models.Resources.StudentInterventionAttendanceEvent.EdFi.StudentInterventionAttendanceEvent,
        Entities.Common.EdFi.IStudentInterventionAttendanceEvent,
        Entities.NHibernate.StudentInterventionAttendanceEventAggregate.EdFi.StudentInterventionAttendanceEvent,
        Api.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventPut,
        Api.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventPost,
        Api.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventDelete,
        Api.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventGetByExample>
    {
        public StudentInterventionAttendanceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentInterventionAttendanceEvents.EdFi.StudentInterventionAttendanceEventGetByExample request, IStudentInterventionAttendanceEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentInterventionAttendanceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentLanguageInstructionProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentLanguageInstructionProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentLanguageInstructionProgramAssociation.EdFi.StudentLanguageInstructionProgramAssociation,
        Models.Resources.StudentLanguageInstructionProgramAssociation.EdFi.StudentLanguageInstructionProgramAssociation,
        Entities.Common.EdFi.IStudentLanguageInstructionProgramAssociation,
        Entities.NHibernate.StudentLanguageInstructionProgramAssociationAggregate.EdFi.StudentLanguageInstructionProgramAssociation,
        Api.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationPut,
        Api.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationPost,
        Api.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationDelete,
        Api.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationGetByExample>
    {
        public StudentLanguageInstructionProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi.StudentLanguageInstructionProgramAssociationGetByExample request, IStudentLanguageInstructionProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentLanguageInstructionProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentLearningObjectives.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentLearningObjectivesController : EdFiControllerBase<
        Models.Resources.StudentLearningObjective.EdFi.StudentLearningObjective,
        Models.Resources.StudentLearningObjective.EdFi.StudentLearningObjective,
        Entities.Common.EdFi.IStudentLearningObjective,
        Entities.NHibernate.StudentLearningObjectiveAggregate.EdFi.StudentLearningObjective,
        Api.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectivePut,
        Api.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectivePost,
        Api.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectiveDelete,
        Api.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectiveGetByExample>
    {
        public StudentLearningObjectivesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentLearningObjectives.EdFi.StudentLearningObjectiveGetByExample request, IStudentLearningObjective specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentLearningObjectives";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentMigrantEducationProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentMigrantEducationProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentMigrantEducationProgramAssociation.EdFi.StudentMigrantEducationProgramAssociation,
        Models.Resources.StudentMigrantEducationProgramAssociation.EdFi.StudentMigrantEducationProgramAssociation,
        Entities.Common.EdFi.IStudentMigrantEducationProgramAssociation,
        Entities.NHibernate.StudentMigrantEducationProgramAssociationAggregate.EdFi.StudentMigrantEducationProgramAssociation,
        Api.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationPut,
        Api.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationPost,
        Api.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationDelete,
        Api.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationGetByExample>
    {
        public StudentMigrantEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi.StudentMigrantEducationProgramAssociationGetByExample request, IStudentMigrantEducationProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentMigrantEducationProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentNeglectedOrDelinquentProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentNeglectedOrDelinquentProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentNeglectedOrDelinquentProgramAssociation.EdFi.StudentNeglectedOrDelinquentProgramAssociation,
        Models.Resources.StudentNeglectedOrDelinquentProgramAssociation.EdFi.StudentNeglectedOrDelinquentProgramAssociation,
        Entities.Common.EdFi.IStudentNeglectedOrDelinquentProgramAssociation,
        Entities.NHibernate.StudentNeglectedOrDelinquentProgramAssociationAggregate.EdFi.StudentNeglectedOrDelinquentProgramAssociation,
        Api.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationPut,
        Api.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationPost,
        Api.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationDelete,
        Api.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationGetByExample>
    {
        public StudentNeglectedOrDelinquentProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi.StudentNeglectedOrDelinquentProgramAssociationGetByExample request, IStudentNeglectedOrDelinquentProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentNeglectedOrDelinquentProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentParentAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentParentAssociationsController : EdFiControllerBase<
        Models.Resources.StudentParentAssociation.EdFi.StudentParentAssociation,
        Models.Resources.StudentParentAssociation.EdFi.StudentParentAssociation,
        Entities.Common.EdFi.IStudentParentAssociation,
        Entities.NHibernate.StudentParentAssociationAggregate.EdFi.StudentParentAssociation,
        Api.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationPut,
        Api.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationPost,
        Api.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationDelete,
        Api.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationGetByExample>
    {
        public StudentParentAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentParentAssociations.EdFi.StudentParentAssociationGetByExample request, IStudentParentAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.ContactPriority = request.ContactPriority;
            specification.ContactRestrictions = request.ContactRestrictions;
            specification.EmergencyContactStatus = request.EmergencyContactStatus;
            specification.Id = request.Id;
            specification.LivesWith = request.LivesWith;
            specification.ParentUniqueId = request.ParentUniqueId;
            specification.PrimaryContactStatus = request.PrimaryContactStatus;
            specification.RelationDescriptor = request.RelationDescriptor;
            specification.StudentUniqueId = request.StudentUniqueId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentParentAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentParticipationCodeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentParticipationCodeDescriptorsController : EdFiControllerBase<
        Models.Resources.StudentParticipationCodeDescriptor.EdFi.StudentParticipationCodeDescriptor,
        Models.Resources.StudentParticipationCodeDescriptor.EdFi.StudentParticipationCodeDescriptor,
        Entities.Common.EdFi.IStudentParticipationCodeDescriptor,
        Entities.NHibernate.StudentParticipationCodeDescriptorAggregate.EdFi.StudentParticipationCodeDescriptor,
        Api.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorPut,
        Api.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorPost,
        Api.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorDelete,
        Api.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorGetByExample>
    {
        public StudentParticipationCodeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentParticipationCodeDescriptors.EdFi.StudentParticipationCodeDescriptorGetByExample request, IStudentParticipationCodeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.StudentParticipationCodeDescriptorId = request.StudentParticipationCodeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "studentParticipationCodeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentProgramAssociation.EdFi.StudentProgramAssociation,
        Models.Resources.StudentProgramAssociation.EdFi.StudentProgramAssociation,
        Entities.Common.EdFi.IStudentProgramAssociation,
        Entities.NHibernate.StudentProgramAssociationAggregate.EdFi.StudentProgramAssociation,
        Api.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationPut,
        Api.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationPost,
        Api.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationDelete,
        Api.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationGetByExample>
    {
        public StudentProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentProgramAssociations.EdFi.StudentProgramAssociationGetByExample request, IStudentProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentProgramAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentProgramAttendanceEventsController : EdFiControllerBase<
        Models.Resources.StudentProgramAttendanceEvent.EdFi.StudentProgramAttendanceEvent,
        Models.Resources.StudentProgramAttendanceEvent.EdFi.StudentProgramAttendanceEvent,
        Entities.Common.EdFi.IStudentProgramAttendanceEvent,
        Entities.NHibernate.StudentProgramAttendanceEventAggregate.EdFi.StudentProgramAttendanceEvent,
        Api.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventPut,
        Api.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventPost,
        Api.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventDelete,
        Api.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventGetByExample>
    {
        public StudentProgramAttendanceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentProgramAttendanceEvents.EdFi.StudentProgramAttendanceEventGetByExample request, IStudentProgramAttendanceEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentProgramAttendanceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSchoolAssociationsController : EdFiControllerBase<
        Models.Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation,
        Models.Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation,
        Entities.Common.EdFi.IStudentSchoolAssociation,
        Entities.NHibernate.StudentSchoolAssociationAggregate.EdFi.StudentSchoolAssociation,
        Api.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationPut,
        Api.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationPost,
        Api.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationDelete,
        Api.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationGetByExample>
    {
        public StudentSchoolAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentSchoolAssociations.EdFi.StudentSchoolAssociationGetByExample request, IStudentSchoolAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentSchoolAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSchoolAttendanceEventsController : EdFiControllerBase<
        Models.Resources.StudentSchoolAttendanceEvent.EdFi.StudentSchoolAttendanceEvent,
        Models.Resources.StudentSchoolAttendanceEvent.EdFi.StudentSchoolAttendanceEvent,
        Entities.Common.EdFi.IStudentSchoolAttendanceEvent,
        Entities.NHibernate.StudentSchoolAttendanceEventAggregate.EdFi.StudentSchoolAttendanceEvent,
        Api.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventPut,
        Api.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventPost,
        Api.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventDelete,
        Api.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventGetByExample>
    {
        public StudentSchoolAttendanceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentSchoolAttendanceEvents.EdFi.StudentSchoolAttendanceEventGetByExample request, IStudentSchoolAttendanceEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentSchoolAttendanceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSchoolFoodServiceProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSchoolFoodServiceProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentSchoolFoodServiceProgramAssociation.EdFi.StudentSchoolFoodServiceProgramAssociation,
        Models.Resources.StudentSchoolFoodServiceProgramAssociation.EdFi.StudentSchoolFoodServiceProgramAssociation,
        Entities.Common.EdFi.IStudentSchoolFoodServiceProgramAssociation,
        Entities.NHibernate.StudentSchoolFoodServiceProgramAssociationAggregate.EdFi.StudentSchoolFoodServiceProgramAssociation,
        Api.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationPut,
        Api.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationPost,
        Api.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationDelete,
        Api.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationGetByExample>
    {
        public StudentSchoolFoodServiceProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi.StudentSchoolFoodServiceProgramAssociationGetByExample request, IStudentSchoolFoodServiceProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentSchoolFoodServiceProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSectionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSectionAssociationsController : EdFiControllerBase<
        Models.Resources.StudentSectionAssociation.EdFi.StudentSectionAssociation,
        Models.Resources.StudentSectionAssociation.EdFi.StudentSectionAssociation,
        Entities.Common.EdFi.IStudentSectionAssociation,
        Entities.NHibernate.StudentSectionAssociationAggregate.EdFi.StudentSectionAssociation,
        Api.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationPut,
        Api.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationPost,
        Api.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationDelete,
        Api.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationGetByExample>
    {
        public StudentSectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentSectionAssociations.EdFi.StudentSectionAssociationGetByExample request, IStudentSectionAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentSectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSectionAttendanceEvents.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSectionAttendanceEventsController : EdFiControllerBase<
        Models.Resources.StudentSectionAttendanceEvent.EdFi.StudentSectionAttendanceEvent,
        Models.Resources.StudentSectionAttendanceEvent.EdFi.StudentSectionAttendanceEvent,
        Entities.Common.EdFi.IStudentSectionAttendanceEvent,
        Entities.NHibernate.StudentSectionAttendanceEventAggregate.EdFi.StudentSectionAttendanceEvent,
        Api.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventPut,
        Api.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventPost,
        Api.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventDelete,
        Api.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventGetByExample>
    {
        public StudentSectionAttendanceEventsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentSectionAttendanceEvents.EdFi.StudentSectionAttendanceEventGetByExample request, IStudentSectionAttendanceEvent specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentSectionAttendanceEvents";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentSpecialEducationProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentSpecialEducationProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation,
        Models.Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation,
        Entities.Common.EdFi.IStudentSpecialEducationProgramAssociation,
        Entities.NHibernate.StudentSpecialEducationProgramAssociationAggregate.EdFi.StudentSpecialEducationProgramAssociation,
        Api.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationPut,
        Api.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationPost,
        Api.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationDelete,
        Api.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationGetByExample>
    {
        public StudentSpecialEducationProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi.StudentSpecialEducationProgramAssociationGetByExample request, IStudentSpecialEducationProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentSpecialEducationProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.StudentTitleIPartAProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class StudentTitleIPartAProgramAssociationsController : EdFiControllerBase<
        Models.Resources.StudentTitleIPartAProgramAssociation.EdFi.StudentTitleIPartAProgramAssociation,
        Models.Resources.StudentTitleIPartAProgramAssociation.EdFi.StudentTitleIPartAProgramAssociation,
        Entities.Common.EdFi.IStudentTitleIPartAProgramAssociation,
        Entities.NHibernate.StudentTitleIPartAProgramAssociationAggregate.EdFi.StudentTitleIPartAProgramAssociation,
        Api.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationPut,
        Api.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationPost,
        Api.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationDelete,
        Api.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationGetByExample>
    {
        public StudentTitleIPartAProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi.StudentTitleIPartAProgramAssociationGetByExample request, IStudentTitleIPartAProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "studentTitleIPartAProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.Surveys.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveysController : EdFiControllerBase<
        Models.Resources.Survey.EdFi.Survey,
        Models.Resources.Survey.EdFi.Survey,
        Entities.Common.EdFi.ISurvey,
        Entities.NHibernate.SurveyAggregate.EdFi.Survey,
        Api.Models.Requests.Surveys.EdFi.SurveyPut,
        Api.Models.Requests.Surveys.EdFi.SurveyPost,
        Api.Models.Requests.Surveys.EdFi.SurveyDelete,
        Api.Models.Requests.Surveys.EdFi.SurveyGetByExample>
    {
        public SurveysController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.Surveys.EdFi.SurveyGetByExample request, ISurvey specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveys";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyCategoryDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyCategoryDescriptorsController : EdFiControllerBase<
        Models.Resources.SurveyCategoryDescriptor.EdFi.SurveyCategoryDescriptor,
        Models.Resources.SurveyCategoryDescriptor.EdFi.SurveyCategoryDescriptor,
        Entities.Common.EdFi.ISurveyCategoryDescriptor,
        Entities.NHibernate.SurveyCategoryDescriptorAggregate.EdFi.SurveyCategoryDescriptor,
        Api.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorPut,
        Api.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorPost,
        Api.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorDelete,
        Api.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorGetByExample>
    {
        public SurveyCategoryDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyCategoryDescriptors.EdFi.SurveyCategoryDescriptorGetByExample request, ISurveyCategoryDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SurveyCategoryDescriptorId = request.SurveyCategoryDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveyCategoryDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyCourseAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyCourseAssociationsController : EdFiControllerBase<
        Models.Resources.SurveyCourseAssociation.EdFi.SurveyCourseAssociation,
        Models.Resources.SurveyCourseAssociation.EdFi.SurveyCourseAssociation,
        Entities.Common.EdFi.ISurveyCourseAssociation,
        Entities.NHibernate.SurveyCourseAssociationAggregate.EdFi.SurveyCourseAssociation,
        Api.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationPut,
        Api.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationPost,
        Api.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationDelete,
        Api.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationGetByExample>
    {
        public SurveyCourseAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyCourseAssociations.EdFi.SurveyCourseAssociationGetByExample request, ISurveyCourseAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.CourseCode = request.CourseCode;
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveyCourseAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyLevelDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyLevelDescriptorsController : EdFiControllerBase<
        Models.Resources.SurveyLevelDescriptor.EdFi.SurveyLevelDescriptor,
        Models.Resources.SurveyLevelDescriptor.EdFi.SurveyLevelDescriptor,
        Entities.Common.EdFi.ISurveyLevelDescriptor,
        Entities.NHibernate.SurveyLevelDescriptorAggregate.EdFi.SurveyLevelDescriptor,
        Api.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorPut,
        Api.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorPost,
        Api.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorDelete,
        Api.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorGetByExample>
    {
        public SurveyLevelDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyLevelDescriptors.EdFi.SurveyLevelDescriptorGetByExample request, ISurveyLevelDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.SurveyLevelDescriptorId = request.SurveyLevelDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveyLevelDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyProgramAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyProgramAssociationsController : EdFiControllerBase<
        Models.Resources.SurveyProgramAssociation.EdFi.SurveyProgramAssociation,
        Models.Resources.SurveyProgramAssociation.EdFi.SurveyProgramAssociation,
        Entities.Common.EdFi.ISurveyProgramAssociation,
        Entities.NHibernate.SurveyProgramAssociationAggregate.EdFi.SurveyProgramAssociation,
        Api.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationPut,
        Api.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationPost,
        Api.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationDelete,
        Api.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationGetByExample>
    {
        public SurveyProgramAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyProgramAssociations.EdFi.SurveyProgramAssociationGetByExample request, ISurveyProgramAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveyProgramAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyQuestions.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyQuestionsController : EdFiControllerBase<
        Models.Resources.SurveyQuestion.EdFi.SurveyQuestion,
        Models.Resources.SurveyQuestion.EdFi.SurveyQuestion,
        Entities.Common.EdFi.ISurveyQuestion,
        Entities.NHibernate.SurveyQuestionAggregate.EdFi.SurveyQuestion,
        Api.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionPut,
        Api.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionPost,
        Api.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionDelete,
        Api.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionGetByExample>
    {
        public SurveyQuestionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyQuestions.EdFi.SurveyQuestionGetByExample request, ISurveyQuestion specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveyQuestions";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyQuestionResponses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyQuestionResponsesController : EdFiControllerBase<
        Models.Resources.SurveyQuestionResponse.EdFi.SurveyQuestionResponse,
        Models.Resources.SurveyQuestionResponse.EdFi.SurveyQuestionResponse,
        Entities.Common.EdFi.ISurveyQuestionResponse,
        Entities.NHibernate.SurveyQuestionResponseAggregate.EdFi.SurveyQuestionResponse,
        Api.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponsePut,
        Api.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponsePost,
        Api.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponseDelete,
        Api.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponseGetByExample>
    {
        public SurveyQuestionResponsesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyQuestionResponses.EdFi.SurveyQuestionResponseGetByExample request, ISurveyQuestionResponse specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveyQuestionResponses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyResponses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyResponsesController : EdFiControllerBase<
        Models.Resources.SurveyResponse.EdFi.SurveyResponse,
        Models.Resources.SurveyResponse.EdFi.SurveyResponse,
        Entities.Common.EdFi.ISurveyResponse,
        Entities.NHibernate.SurveyResponseAggregate.EdFi.SurveyResponse,
        Api.Models.Requests.SurveyResponses.EdFi.SurveyResponsePut,
        Api.Models.Requests.SurveyResponses.EdFi.SurveyResponsePost,
        Api.Models.Requests.SurveyResponses.EdFi.SurveyResponseDelete,
        Api.Models.Requests.SurveyResponses.EdFi.SurveyResponseGetByExample>
    {
        public SurveyResponsesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyResponses.EdFi.SurveyResponseGetByExample request, ISurveyResponse specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveyResponses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyResponseEducationOrganizationTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyResponseEducationOrganizationTargetAssociationsController : EdFiControllerBase<
        Models.Resources.SurveyResponseEducationOrganizationTargetAssociation.EdFi.SurveyResponseEducationOrganizationTargetAssociation,
        Models.Resources.SurveyResponseEducationOrganizationTargetAssociation.EdFi.SurveyResponseEducationOrganizationTargetAssociation,
        Entities.Common.EdFi.ISurveyResponseEducationOrganizationTargetAssociation,
        Entities.NHibernate.SurveyResponseEducationOrganizationTargetAssociationAggregate.EdFi.SurveyResponseEducationOrganizationTargetAssociation,
        Api.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationPut,
        Api.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationPost,
        Api.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationDelete,
        Api.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationGetByExample>
    {
        public SurveyResponseEducationOrganizationTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi.SurveyResponseEducationOrganizationTargetAssociationGetByExample request, ISurveyResponseEducationOrganizationTargetAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.EducationOrganizationId = request.EducationOrganizationId;
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveyResponseEducationOrganizationTargetAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveyResponseStaffTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveyResponseStaffTargetAssociationsController : EdFiControllerBase<
        Models.Resources.SurveyResponseStaffTargetAssociation.EdFi.SurveyResponseStaffTargetAssociation,
        Models.Resources.SurveyResponseStaffTargetAssociation.EdFi.SurveyResponseStaffTargetAssociation,
        Entities.Common.EdFi.ISurveyResponseStaffTargetAssociation,
        Entities.NHibernate.SurveyResponseStaffTargetAssociationAggregate.EdFi.SurveyResponseStaffTargetAssociation,
        Api.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationPut,
        Api.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationPost,
        Api.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationDelete,
        Api.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationGetByExample>
    {
        public SurveyResponseStaffTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi.SurveyResponseStaffTargetAssociationGetByExample request, ISurveyResponseStaffTargetAssociation specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.StaffUniqueId = request.StaffUniqueId;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveyResponseIdentifier = request.SurveyResponseIdentifier;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveyResponseStaffTargetAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySections.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionsController : EdFiControllerBase<
        Models.Resources.SurveySection.EdFi.SurveySection,
        Models.Resources.SurveySection.EdFi.SurveySection,
        Entities.Common.EdFi.ISurveySection,
        Entities.NHibernate.SurveySectionAggregate.EdFi.SurveySection,
        Api.Models.Requests.SurveySections.EdFi.SurveySectionPut,
        Api.Models.Requests.SurveySections.EdFi.SurveySectionPost,
        Api.Models.Requests.SurveySections.EdFi.SurveySectionDelete,
        Api.Models.Requests.SurveySections.EdFi.SurveySectionGetByExample>
    {
        public SurveySectionsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveySections.EdFi.SurveySectionGetByExample request, ISurveySection specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.Id = request.Id;
            specification.Namespace = request.Namespace;
            specification.SurveyIdentifier = request.SurveyIdentifier;
            specification.SurveySectionTitle = request.SurveySectionTitle;
                    }

        protected override string GetResourceCollectionName()
        {
            return "surveySections";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionAssociationsController : EdFiControllerBase<
        Models.Resources.SurveySectionAssociation.EdFi.SurveySectionAssociation,
        Models.Resources.SurveySectionAssociation.EdFi.SurveySectionAssociation,
        Entities.Common.EdFi.ISurveySectionAssociation,
        Entities.NHibernate.SurveySectionAssociationAggregate.EdFi.SurveySectionAssociation,
        Api.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationPut,
        Api.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationPost,
        Api.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationDelete,
        Api.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationGetByExample>
    {
        public SurveySectionAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveySectionAssociations.EdFi.SurveySectionAssociationGetByExample request, ISurveySectionAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveySectionAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionResponses.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionResponsesController : EdFiControllerBase<
        Models.Resources.SurveySectionResponse.EdFi.SurveySectionResponse,
        Models.Resources.SurveySectionResponse.EdFi.SurveySectionResponse,
        Entities.Common.EdFi.ISurveySectionResponse,
        Entities.NHibernate.SurveySectionResponseAggregate.EdFi.SurveySectionResponse,
        Api.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponsePut,
        Api.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponsePost,
        Api.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponseDelete,
        Api.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponseGetByExample>
    {
        public SurveySectionResponsesController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveySectionResponses.EdFi.SurveySectionResponseGetByExample request, ISurveySectionResponse specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveySectionResponses";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionResponseEducationOrganizationTargetAssociationsController : EdFiControllerBase<
        Models.Resources.SurveySectionResponseEducationOrganizationTargetAssociation.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation,
        Models.Resources.SurveySectionResponseEducationOrganizationTargetAssociation.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation,
        Entities.Common.EdFi.ISurveySectionResponseEducationOrganizationTargetAssociation,
        Entities.NHibernate.SurveySectionResponseEducationOrganizationTargetAssociationAggregate.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation,
        Api.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationPut,
        Api.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationPost,
        Api.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationDelete,
        Api.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationGetByExample>
    {
        public SurveySectionResponseEducationOrganizationTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi.SurveySectionResponseEducationOrganizationTargetAssociationGetByExample request, ISurveySectionResponseEducationOrganizationTargetAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveySectionResponseEducationOrganizationTargetAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.SurveySectionResponseStaffTargetAssociations.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class SurveySectionResponseStaffTargetAssociationsController : EdFiControllerBase<
        Models.Resources.SurveySectionResponseStaffTargetAssociation.EdFi.SurveySectionResponseStaffTargetAssociation,
        Models.Resources.SurveySectionResponseStaffTargetAssociation.EdFi.SurveySectionResponseStaffTargetAssociation,
        Entities.Common.EdFi.ISurveySectionResponseStaffTargetAssociation,
        Entities.NHibernate.SurveySectionResponseStaffTargetAssociationAggregate.EdFi.SurveySectionResponseStaffTargetAssociation,
        Api.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationPut,
        Api.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationPost,
        Api.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationDelete,
        Api.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationGetByExample>
    {
        public SurveySectionResponseStaffTargetAssociationsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi.SurveySectionResponseStaffTargetAssociationGetByExample request, ISurveySectionResponseStaffTargetAssociation specification)
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

        protected override string GetResourceCollectionName()
        {
            return "surveySectionResponseStaffTargetAssociations";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TeachingCredentialBasisDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeachingCredentialBasisDescriptorsController : EdFiControllerBase<
        Models.Resources.TeachingCredentialBasisDescriptor.EdFi.TeachingCredentialBasisDescriptor,
        Models.Resources.TeachingCredentialBasisDescriptor.EdFi.TeachingCredentialBasisDescriptor,
        Entities.Common.EdFi.ITeachingCredentialBasisDescriptor,
        Entities.NHibernate.TeachingCredentialBasisDescriptorAggregate.EdFi.TeachingCredentialBasisDescriptor,
        Api.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorPut,
        Api.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorPost,
        Api.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorDelete,
        Api.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorGetByExample>
    {
        public TeachingCredentialBasisDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TeachingCredentialBasisDescriptors.EdFi.TeachingCredentialBasisDescriptorGetByExample request, ITeachingCredentialBasisDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TeachingCredentialBasisDescriptorId = request.TeachingCredentialBasisDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teachingCredentialBasisDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TeachingCredentialDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TeachingCredentialDescriptorsController : EdFiControllerBase<
        Models.Resources.TeachingCredentialDescriptor.EdFi.TeachingCredentialDescriptor,
        Models.Resources.TeachingCredentialDescriptor.EdFi.TeachingCredentialDescriptor,
        Entities.Common.EdFi.ITeachingCredentialDescriptor,
        Entities.NHibernate.TeachingCredentialDescriptorAggregate.EdFi.TeachingCredentialDescriptor,
        Api.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorPut,
        Api.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorPost,
        Api.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorDelete,
        Api.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorGetByExample>
    {
        public TeachingCredentialDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TeachingCredentialDescriptors.EdFi.TeachingCredentialDescriptorGetByExample request, ITeachingCredentialDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TeachingCredentialDescriptorId = request.TeachingCredentialDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "teachingCredentialDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TechnicalSkillsAssessmentDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TechnicalSkillsAssessmentDescriptorsController : EdFiControllerBase<
        Models.Resources.TechnicalSkillsAssessmentDescriptor.EdFi.TechnicalSkillsAssessmentDescriptor,
        Models.Resources.TechnicalSkillsAssessmentDescriptor.EdFi.TechnicalSkillsAssessmentDescriptor,
        Entities.Common.EdFi.ITechnicalSkillsAssessmentDescriptor,
        Entities.NHibernate.TechnicalSkillsAssessmentDescriptorAggregate.EdFi.TechnicalSkillsAssessmentDescriptor,
        Api.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorPut,
        Api.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorPost,
        Api.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorDelete,
        Api.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorGetByExample>
    {
        public TechnicalSkillsAssessmentDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi.TechnicalSkillsAssessmentDescriptorGetByExample request, ITechnicalSkillsAssessmentDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TechnicalSkillsAssessmentDescriptorId = request.TechnicalSkillsAssessmentDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "technicalSkillsAssessmentDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TelephoneNumberTypeDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TelephoneNumberTypeDescriptorsController : EdFiControllerBase<
        Models.Resources.TelephoneNumberTypeDescriptor.EdFi.TelephoneNumberTypeDescriptor,
        Models.Resources.TelephoneNumberTypeDescriptor.EdFi.TelephoneNumberTypeDescriptor,
        Entities.Common.EdFi.ITelephoneNumberTypeDescriptor,
        Entities.NHibernate.TelephoneNumberTypeDescriptorAggregate.EdFi.TelephoneNumberTypeDescriptor,
        Api.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorPut,
        Api.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorPost,
        Api.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorDelete,
        Api.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorGetByExample>
    {
        public TelephoneNumberTypeDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TelephoneNumberTypeDescriptors.EdFi.TelephoneNumberTypeDescriptorGetByExample request, ITelephoneNumberTypeDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TelephoneNumberTypeDescriptorId = request.TelephoneNumberTypeDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "telephoneNumberTypeDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TermDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TermDescriptorsController : EdFiControllerBase<
        Models.Resources.TermDescriptor.EdFi.TermDescriptor,
        Models.Resources.TermDescriptor.EdFi.TermDescriptor,
        Entities.Common.EdFi.ITermDescriptor,
        Entities.NHibernate.TermDescriptorAggregate.EdFi.TermDescriptor,
        Api.Models.Requests.TermDescriptors.EdFi.TermDescriptorPut,
        Api.Models.Requests.TermDescriptors.EdFi.TermDescriptorPost,
        Api.Models.Requests.TermDescriptors.EdFi.TermDescriptorDelete,
        Api.Models.Requests.TermDescriptors.EdFi.TermDescriptorGetByExample>
    {
        public TermDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TermDescriptors.EdFi.TermDescriptorGetByExample request, ITermDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TermDescriptorId = request.TermDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "termDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TitleIPartAParticipantDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TitleIPartAParticipantDescriptorsController : EdFiControllerBase<
        Models.Resources.TitleIPartAParticipantDescriptor.EdFi.TitleIPartAParticipantDescriptor,
        Models.Resources.TitleIPartAParticipantDescriptor.EdFi.TitleIPartAParticipantDescriptor,
        Entities.Common.EdFi.ITitleIPartAParticipantDescriptor,
        Entities.NHibernate.TitleIPartAParticipantDescriptorAggregate.EdFi.TitleIPartAParticipantDescriptor,
        Api.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorPut,
        Api.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorPost,
        Api.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorDelete,
        Api.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorGetByExample>
    {
        public TitleIPartAParticipantDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TitleIPartAParticipantDescriptors.EdFi.TitleIPartAParticipantDescriptorGetByExample request, ITitleIPartAParticipantDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TitleIPartAParticipantDescriptorId = request.TitleIPartAParticipantDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "titleIPartAParticipantDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TitleIPartAProgramServiceDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TitleIPartAProgramServiceDescriptorsController : EdFiControllerBase<
        Models.Resources.TitleIPartAProgramServiceDescriptor.EdFi.TitleIPartAProgramServiceDescriptor,
        Models.Resources.TitleIPartAProgramServiceDescriptor.EdFi.TitleIPartAProgramServiceDescriptor,
        Entities.Common.EdFi.ITitleIPartAProgramServiceDescriptor,
        Entities.NHibernate.TitleIPartAProgramServiceDescriptorAggregate.EdFi.TitleIPartAProgramServiceDescriptor,
        Api.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorPut,
        Api.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorPost,
        Api.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorDelete,
        Api.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorGetByExample>
    {
        public TitleIPartAProgramServiceDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi.TitleIPartAProgramServiceDescriptorGetByExample request, ITitleIPartAProgramServiceDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TitleIPartAProgramServiceDescriptorId = request.TitleIPartAProgramServiceDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "titleIPartAProgramServiceDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TitleIPartASchoolDesignationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TitleIPartASchoolDesignationDescriptorsController : EdFiControllerBase<
        Models.Resources.TitleIPartASchoolDesignationDescriptor.EdFi.TitleIPartASchoolDesignationDescriptor,
        Models.Resources.TitleIPartASchoolDesignationDescriptor.EdFi.TitleIPartASchoolDesignationDescriptor,
        Entities.Common.EdFi.ITitleIPartASchoolDesignationDescriptor,
        Entities.NHibernate.TitleIPartASchoolDesignationDescriptorAggregate.EdFi.TitleIPartASchoolDesignationDescriptor,
        Api.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorPut,
        Api.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorPost,
        Api.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorDelete,
        Api.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorGetByExample>
    {
        public TitleIPartASchoolDesignationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi.TitleIPartASchoolDesignationDescriptorGetByExample request, ITitleIPartASchoolDesignationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TitleIPartASchoolDesignationDescriptorId = request.TitleIPartASchoolDesignationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "titleIPartASchoolDesignationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.TribalAffiliationDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class TribalAffiliationDescriptorsController : EdFiControllerBase<
        Models.Resources.TribalAffiliationDescriptor.EdFi.TribalAffiliationDescriptor,
        Models.Resources.TribalAffiliationDescriptor.EdFi.TribalAffiliationDescriptor,
        Entities.Common.EdFi.ITribalAffiliationDescriptor,
        Entities.NHibernate.TribalAffiliationDescriptorAggregate.EdFi.TribalAffiliationDescriptor,
        Api.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorPut,
        Api.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorPost,
        Api.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorDelete,
        Api.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorGetByExample>
    {
        public TribalAffiliationDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.TribalAffiliationDescriptors.EdFi.TribalAffiliationDescriptorGetByExample request, ITribalAffiliationDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.TribalAffiliationDescriptorId = request.TribalAffiliationDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "tribalAffiliationDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.VisaDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class VisaDescriptorsController : EdFiControllerBase<
        Models.Resources.VisaDescriptor.EdFi.VisaDescriptor,
        Models.Resources.VisaDescriptor.EdFi.VisaDescriptor,
        Entities.Common.EdFi.IVisaDescriptor,
        Entities.NHibernate.VisaDescriptorAggregate.EdFi.VisaDescriptor,
        Api.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorPut,
        Api.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorPost,
        Api.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorDelete,
        Api.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorGetByExample>
    {
        public VisaDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.VisaDescriptors.EdFi.VisaDescriptorGetByExample request, IVisaDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.VisaDescriptorId = request.VisaDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "visaDescriptors";
        }
    }
}

namespace EdFi.Ods.Api.Services.Controllers.WeaponDescriptors.EdFi
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    public partial class WeaponDescriptorsController : EdFiControllerBase<
        Models.Resources.WeaponDescriptor.EdFi.WeaponDescriptor,
        Models.Resources.WeaponDescriptor.EdFi.WeaponDescriptor,
        Entities.Common.EdFi.IWeaponDescriptor,
        Entities.NHibernate.WeaponDescriptorAggregate.EdFi.WeaponDescriptor,
        Api.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorPut,
        Api.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorPost,
        Api.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorDelete,
        Api.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorGetByExample>
    {
        public WeaponDescriptorsController(IPipelineFactory pipelineFactory, ISchoolYearContextProvider schoolYearContextProvider, IRESTErrorProvider restErrorProvider)
            : base(pipelineFactory, schoolYearContextProvider, restErrorProvider)
        {
        }

        protected override void MapAll(Api.Models.Requests.WeaponDescriptors.EdFi.WeaponDescriptorGetByExample request, IWeaponDescriptor specification)
        {
                        // Copy all existing values
            specification.SuspendReferenceAssignmentCheck();
            specification.WeaponDescriptorId = request.WeaponDescriptorId;
                    }

        protected override string GetResourceCollectionName()
        {
            return "weaponDescriptors";
        }
    }
}

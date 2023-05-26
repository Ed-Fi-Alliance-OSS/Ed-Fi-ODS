using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.AbsenceEventCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AbsenceEventCategoryDescriptorGetByExample
    {
        public int AbsenceEventCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AbsenceEventCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AbsenceEventCategoryDescriptorGetByIds() { }

        public AbsenceEventCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AbsenceEventCategoryDescriptorPost : Resources.AbsenceEventCategoryDescriptor.EdFi.AbsenceEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AbsenceEventCategoryDescriptorPut : Resources.AbsenceEventCategoryDescriptor.EdFi.AbsenceEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AbsenceEventCategoryDescriptorDelete : IHasIdentifier
    {
        public AbsenceEventCategoryDescriptorDelete() { }

        public AbsenceEventCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AcademicHonorCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AcademicHonorCategoryDescriptorGetByExample
    {
        public int AcademicHonorCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicHonorCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AcademicHonorCategoryDescriptorGetByIds() { }

        public AcademicHonorCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicHonorCategoryDescriptorPost : Resources.AcademicHonorCategoryDescriptor.EdFi.AcademicHonorCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicHonorCategoryDescriptorPut : Resources.AcademicHonorCategoryDescriptor.EdFi.AcademicHonorCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicHonorCategoryDescriptorDelete : IHasIdentifier
    {
        public AcademicHonorCategoryDescriptorDelete() { }

        public AcademicHonorCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AcademicSubjectDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AcademicSubjectDescriptorGetByExample
    {
        public int AcademicSubjectDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicSubjectDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AcademicSubjectDescriptorGetByIds() { }

        public AcademicSubjectDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicSubjectDescriptorPost : Resources.AcademicSubjectDescriptor.EdFi.AcademicSubjectDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicSubjectDescriptorPut : Resources.AcademicSubjectDescriptor.EdFi.AcademicSubjectDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicSubjectDescriptorDelete : IHasIdentifier
    {
        public AcademicSubjectDescriptorDelete() { }

        public AcademicSubjectDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AcademicWeeks.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AcademicWeekGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public int TotalInstructionalDays { get; set; }
        public string WeekIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekGetByIds : IHasIdentifiers<Guid>
    {
        public AcademicWeekGetByIds() { }

        public AcademicWeekGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekPost : Resources.AcademicWeek.EdFi.AcademicWeek
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekPut : Resources.AcademicWeek.EdFi.AcademicWeek
    {
    }

    [ExcludeFromCodeCoverage]
    public class AcademicWeekDelete : IHasIdentifier
    {
        public AcademicWeekDelete() { }

        public AcademicWeekDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AccommodationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AccommodationDescriptorGetByExample
    {
        public int AccommodationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccommodationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AccommodationDescriptorGetByIds() { }

        public AccommodationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccommodationDescriptorPost : Resources.AccommodationDescriptor.EdFi.AccommodationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccommodationDescriptorPut : Resources.AccommodationDescriptor.EdFi.AccommodationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccommodationDescriptorDelete : IHasIdentifier
    {
        public AccommodationDescriptorDelete() { }

        public AccommodationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AccountabilityRatings.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Rating { get; set; }
        public DateTime RatingDate { get; set; }
        public string RatingOrganization { get; set; }
        public string RatingProgram { get; set; }
        public string RatingTitle { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingGetByIds : IHasIdentifiers<Guid>
    {
        public AccountabilityRatingGetByIds() { }

        public AccountabilityRatingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingPost : Resources.AccountabilityRating.EdFi.AccountabilityRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingPut : Resources.AccountabilityRating.EdFi.AccountabilityRating
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccountabilityRatingDelete : IHasIdentifier
    {
        public AccountabilityRatingDelete() { }

        public AccountabilityRatingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AccountTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AccountTypeDescriptorGetByExample
    {
        public int AccountTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccountTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AccountTypeDescriptorGetByIds() { }

        public AccountTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AccountTypeDescriptorPost : Resources.AccountTypeDescriptor.EdFi.AccountTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccountTypeDescriptorPut : Resources.AccountTypeDescriptor.EdFi.AccountTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AccountTypeDescriptorDelete : IHasIdentifier
    {
        public AccountTypeDescriptorDelete() { }

        public AccountTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AchievementCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AchievementCategoryDescriptorGetByExample
    {
        public int AchievementCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AchievementCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AchievementCategoryDescriptorGetByIds() { }

        public AchievementCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AchievementCategoryDescriptorPost : Resources.AchievementCategoryDescriptor.EdFi.AchievementCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AchievementCategoryDescriptorPut : Resources.AchievementCategoryDescriptor.EdFi.AchievementCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AchievementCategoryDescriptorDelete : IHasIdentifier
    {
        public AchievementCategoryDescriptorDelete() { }

        public AchievementCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AdditionalCreditTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AdditionalCreditTypeDescriptorGetByExample
    {
        public int AdditionalCreditTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AdditionalCreditTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AdditionalCreditTypeDescriptorGetByIds() { }

        public AdditionalCreditTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AdditionalCreditTypeDescriptorPost : Resources.AdditionalCreditTypeDescriptor.EdFi.AdditionalCreditTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AdditionalCreditTypeDescriptorPut : Resources.AdditionalCreditTypeDescriptor.EdFi.AdditionalCreditTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AdditionalCreditTypeDescriptorDelete : IHasIdentifier
    {
        public AdditionalCreditTypeDescriptorDelete() { }

        public AdditionalCreditTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AddressTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AddressTypeDescriptorGetByExample
    {
        public int AddressTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AddressTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AddressTypeDescriptorGetByIds() { }

        public AddressTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AddressTypeDescriptorPost : Resources.AddressTypeDescriptor.EdFi.AddressTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AddressTypeDescriptorPut : Resources.AddressTypeDescriptor.EdFi.AddressTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AddressTypeDescriptorDelete : IHasIdentifier
    {
        public AddressTypeDescriptorDelete() { }

        public AddressTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AdministrationEnvironmentDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AdministrationEnvironmentDescriptorGetByExample
    {
        public int AdministrationEnvironmentDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AdministrationEnvironmentDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AdministrationEnvironmentDescriptorGetByIds() { }

        public AdministrationEnvironmentDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AdministrationEnvironmentDescriptorPost : Resources.AdministrationEnvironmentDescriptor.EdFi.AdministrationEnvironmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AdministrationEnvironmentDescriptorPut : Resources.AdministrationEnvironmentDescriptor.EdFi.AdministrationEnvironmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AdministrationEnvironmentDescriptorDelete : IHasIdentifier
    {
        public AdministrationEnvironmentDescriptorDelete() { }

        public AdministrationEnvironmentDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AdministrativeFundingControlDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AdministrativeFundingControlDescriptorGetByExample
    {
        public int AdministrativeFundingControlDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AdministrativeFundingControlDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AdministrativeFundingControlDescriptorGetByIds() { }

        public AdministrativeFundingControlDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AdministrativeFundingControlDescriptorPost : Resources.AdministrativeFundingControlDescriptor.EdFi.AdministrativeFundingControlDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AdministrativeFundingControlDescriptorPut : Resources.AdministrativeFundingControlDescriptor.EdFi.AdministrativeFundingControlDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AdministrativeFundingControlDescriptorDelete : IHasIdentifier
    {
        public AdministrativeFundingControlDescriptorDelete() { }

        public AdministrativeFundingControlDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AncestryEthnicOriginDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AncestryEthnicOriginDescriptorGetByExample
    {
        public int AncestryEthnicOriginDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AncestryEthnicOriginDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AncestryEthnicOriginDescriptorGetByIds() { }

        public AncestryEthnicOriginDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AncestryEthnicOriginDescriptorPost : Resources.AncestryEthnicOriginDescriptor.EdFi.AncestryEthnicOriginDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AncestryEthnicOriginDescriptorPut : Resources.AncestryEthnicOriginDescriptor.EdFi.AncestryEthnicOriginDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AncestryEthnicOriginDescriptorDelete : IHasIdentifier
    {
        public AncestryEthnicOriginDescriptorDelete() { }

        public AncestryEthnicOriginDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Assessments.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentGetByExample
    {
        public bool AdaptiveAssessment { get; set; }
        public string AssessmentCategoryDescriptor { get; set; }
        public string AssessmentFamily { get; set; }
        public string AssessmentForm { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string AssessmentTitle { get; set; }
        public int AssessmentVersion { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public decimal MaxRawScore { get; set; }
        public string Namespace { get; set; }
        public string Nomenclature { get; set; }
        public DateTime RevisionDate { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentGetByIds() { }

        public AssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentPost : Resources.Assessment.EdFi.Assessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentPut : Resources.Assessment.EdFi.Assessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentDelete : IHasIdentifier
    {
        public AssessmentDelete() { }

        public AssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentCategoryDescriptorGetByExample
    {
        public int AssessmentCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentCategoryDescriptorGetByIds() { }

        public AssessmentCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentCategoryDescriptorPost : Resources.AssessmentCategoryDescriptor.EdFi.AssessmentCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentCategoryDescriptorPut : Resources.AssessmentCategoryDescriptor.EdFi.AssessmentCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentCategoryDescriptorDelete : IHasIdentifier
    {
        public AssessmentCategoryDescriptorDelete() { }

        public AssessmentCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentIdentificationSystemDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentIdentificationSystemDescriptorGetByExample
    {
        public int AssessmentIdentificationSystemDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentIdentificationSystemDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentIdentificationSystemDescriptorGetByIds() { }

        public AssessmentIdentificationSystemDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentIdentificationSystemDescriptorPost : Resources.AssessmentIdentificationSystemDescriptor.EdFi.AssessmentIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentIdentificationSystemDescriptorPut : Resources.AssessmentIdentificationSystemDescriptor.EdFi.AssessmentIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentIdentificationSystemDescriptorDelete : IHasIdentifier
    {
        public AssessmentIdentificationSystemDescriptorDelete() { }

        public AssessmentIdentificationSystemDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentItems.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentItemGetByExample
    {
        public string AssessmentIdentifier { get; set; }
        public string AssessmentItemCategoryDescriptor { get; set; }
        public string AssessmentItemURI { get; set; }
        public string ExpectedTimeAssessed { get; set; }
        public Guid Id { get; set; }
        public string IdentificationCode { get; set; }
        public string ItemText { get; set; }
        public decimal MaxRawScore { get; set; }
        public string Namespace { get; set; }
        public string Nomenclature { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentItemGetByIds() { }

        public AssessmentItemGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemPost : Resources.AssessmentItem.EdFi.AssessmentItem
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemPut : Resources.AssessmentItem.EdFi.AssessmentItem
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemDelete : IHasIdentifier
    {
        public AssessmentItemDelete() { }

        public AssessmentItemDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentItemCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentItemCategoryDescriptorGetByExample
    {
        public int AssessmentItemCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentItemCategoryDescriptorGetByIds() { }

        public AssessmentItemCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemCategoryDescriptorPost : Resources.AssessmentItemCategoryDescriptor.EdFi.AssessmentItemCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemCategoryDescriptorPut : Resources.AssessmentItemCategoryDescriptor.EdFi.AssessmentItemCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemCategoryDescriptorDelete : IHasIdentifier
    {
        public AssessmentItemCategoryDescriptorDelete() { }

        public AssessmentItemCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentItemResultDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentItemResultDescriptorGetByExample
    {
        public int AssessmentItemResultDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemResultDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentItemResultDescriptorGetByIds() { }

        public AssessmentItemResultDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemResultDescriptorPost : Resources.AssessmentItemResultDescriptor.EdFi.AssessmentItemResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemResultDescriptorPut : Resources.AssessmentItemResultDescriptor.EdFi.AssessmentItemResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentItemResultDescriptorDelete : IHasIdentifier
    {
        public AssessmentItemResultDescriptorDelete() { }

        public AssessmentItemResultDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentPeriodDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentPeriodDescriptorGetByExample
    {
        public int AssessmentPeriodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentPeriodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentPeriodDescriptorGetByIds() { }

        public AssessmentPeriodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentPeriodDescriptorPost : Resources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentPeriodDescriptorPut : Resources.AssessmentPeriodDescriptor.EdFi.AssessmentPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentPeriodDescriptorDelete : IHasIdentifier
    {
        public AssessmentPeriodDescriptorDelete() { }

        public AssessmentPeriodDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentReportingMethodDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentReportingMethodDescriptorGetByExample
    {
        public int AssessmentReportingMethodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentReportingMethodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentReportingMethodDescriptorGetByIds() { }

        public AssessmentReportingMethodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentReportingMethodDescriptorPost : Resources.AssessmentReportingMethodDescriptor.EdFi.AssessmentReportingMethodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentReportingMethodDescriptorPut : Resources.AssessmentReportingMethodDescriptor.EdFi.AssessmentReportingMethodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentReportingMethodDescriptorDelete : IHasIdentifier
    {
        public AssessmentReportingMethodDescriptorDelete() { }

        public AssessmentReportingMethodDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssessmentScoreRangeLearningStandards.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssessmentScoreRangeLearningStandardGetByExample
    {
        public string AssessmentIdentifier { get; set; }
        public string AssessmentReportingMethodDescriptor { get; set; }
        public Guid Id { get; set; }
        public string IdentificationCode { get; set; }
        public string MaximumScore { get; set; }
        public string MinimumScore { get; set; }
        public string Namespace { get; set; }
        public string ScoreRangeId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentScoreRangeLearningStandardGetByIds : IHasIdentifiers<Guid>
    {
        public AssessmentScoreRangeLearningStandardGetByIds() { }

        public AssessmentScoreRangeLearningStandardGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentScoreRangeLearningStandardPost : Resources.AssessmentScoreRangeLearningStandard.EdFi.AssessmentScoreRangeLearningStandard
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentScoreRangeLearningStandardPut : Resources.AssessmentScoreRangeLearningStandard.EdFi.AssessmentScoreRangeLearningStandard
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssessmentScoreRangeLearningStandardDelete : IHasIdentifier
    {
        public AssessmentScoreRangeLearningStandardDelete() { }

        public AssessmentScoreRangeLearningStandardDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AssignmentLateStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AssignmentLateStatusDescriptorGetByExample
    {
        public int AssignmentLateStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssignmentLateStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AssignmentLateStatusDescriptorGetByIds() { }

        public AssignmentLateStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AssignmentLateStatusDescriptorPost : Resources.AssignmentLateStatusDescriptor.EdFi.AssignmentLateStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssignmentLateStatusDescriptorPut : Resources.AssignmentLateStatusDescriptor.EdFi.AssignmentLateStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AssignmentLateStatusDescriptorDelete : IHasIdentifier
    {
        public AssignmentLateStatusDescriptorDelete() { }

        public AssignmentLateStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AttemptStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AttemptStatusDescriptorGetByExample
    {
        public int AttemptStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AttemptStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AttemptStatusDescriptorGetByIds() { }

        public AttemptStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AttemptStatusDescriptorPost : Resources.AttemptStatusDescriptor.EdFi.AttemptStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AttemptStatusDescriptorPut : Resources.AttemptStatusDescriptor.EdFi.AttemptStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AttemptStatusDescriptorDelete : IHasIdentifier
    {
        public AttemptStatusDescriptorDelete() { }

        public AttemptStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.AttendanceEventCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class AttendanceEventCategoryDescriptorGetByExample
    {
        public int AttendanceEventCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AttendanceEventCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public AttendanceEventCategoryDescriptorGetByIds() { }

        public AttendanceEventCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AttendanceEventCategoryDescriptorPost : Resources.AttendanceEventCategoryDescriptor.EdFi.AttendanceEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AttendanceEventCategoryDescriptorPut : Resources.AttendanceEventCategoryDescriptor.EdFi.AttendanceEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class AttendanceEventCategoryDescriptorDelete : IHasIdentifier
    {
        public AttendanceEventCategoryDescriptorDelete() { }

        public AttendanceEventCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.BalanceSheetDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class BalanceSheetDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BalanceSheetDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public BalanceSheetDimensionGetByIds() { }

        public BalanceSheetDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BalanceSheetDimensionPost : Resources.BalanceSheetDimension.EdFi.BalanceSheetDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class BalanceSheetDimensionPut : Resources.BalanceSheetDimension.EdFi.BalanceSheetDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class BalanceSheetDimensionDelete : IHasIdentifier
    {
        public BalanceSheetDimensionDelete() { }

        public BalanceSheetDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.BarrierToInternetAccessInResidenceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class BarrierToInternetAccessInResidenceDescriptorGetByExample
    {
        public int BarrierToInternetAccessInResidenceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BarrierToInternetAccessInResidenceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public BarrierToInternetAccessInResidenceDescriptorGetByIds() { }

        public BarrierToInternetAccessInResidenceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BarrierToInternetAccessInResidenceDescriptorPost : Resources.BarrierToInternetAccessInResidenceDescriptor.EdFi.BarrierToInternetAccessInResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BarrierToInternetAccessInResidenceDescriptorPut : Resources.BarrierToInternetAccessInResidenceDescriptor.EdFi.BarrierToInternetAccessInResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BarrierToInternetAccessInResidenceDescriptorDelete : IHasIdentifier
    {
        public BarrierToInternetAccessInResidenceDescriptorDelete() { }

        public BarrierToInternetAccessInResidenceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.BehaviorDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class BehaviorDescriptorGetByExample
    {
        public int BehaviorDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BehaviorDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public BehaviorDescriptorGetByIds() { }

        public BehaviorDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BehaviorDescriptorPost : Resources.BehaviorDescriptor.EdFi.BehaviorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BehaviorDescriptorPut : Resources.BehaviorDescriptor.EdFi.BehaviorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class BehaviorDescriptorDelete : IHasIdentifier
    {
        public BehaviorDescriptorDelete() { }

        public BehaviorDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.BellSchedules.EdFi
{

    [ExcludeFromCodeCoverage]
    public class BellScheduleGetByExample
    {
        public string AlternateDayName { get; set; }
        public string BellScheduleName { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public TimeSpan StartTime { get; set; }
        public int TotalInstructionalTime { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BellScheduleGetByIds : IHasIdentifiers<Guid>
    {
        public BellScheduleGetByIds() { }

        public BellScheduleGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BellSchedulePost : Resources.BellSchedule.EdFi.BellSchedule
    {
    }

    [ExcludeFromCodeCoverage]
    public class BellSchedulePut : Resources.BellSchedule.EdFi.BellSchedule
    {
    }

    [ExcludeFromCodeCoverage]
    public class BellScheduleDelete : IHasIdentifier
    {
        public BellScheduleDelete() { }

        public BellScheduleDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Calendars.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CalendarGetByExample
    {
        public string CalendarCode { get; set; }
        public string CalendarTypeDescriptor { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarGetByIds : IHasIdentifiers<Guid>
    {
        public CalendarGetByIds() { }

        public CalendarGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarPost : Resources.Calendar.EdFi.Calendar
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarPut : Resources.Calendar.EdFi.Calendar
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarDelete : IHasIdentifier
    {
        public CalendarDelete() { }

        public CalendarDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CalendarDates.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CalendarDateGetByExample
    {
        public string CalendarCode { get; set; }
        public DateTime Date { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarDateGetByIds : IHasIdentifiers<Guid>
    {
        public CalendarDateGetByIds() { }

        public CalendarDateGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarDatePost : Resources.CalendarDate.EdFi.CalendarDate
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarDatePut : Resources.CalendarDate.EdFi.CalendarDate
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarDateDelete : IHasIdentifier
    {
        public CalendarDateDelete() { }

        public CalendarDateDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CalendarEventDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CalendarEventDescriptorGetByExample
    {
        public int CalendarEventDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarEventDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CalendarEventDescriptorGetByIds() { }

        public CalendarEventDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarEventDescriptorPost : Resources.CalendarEventDescriptor.EdFi.CalendarEventDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarEventDescriptorPut : Resources.CalendarEventDescriptor.EdFi.CalendarEventDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarEventDescriptorDelete : IHasIdentifier
    {
        public CalendarEventDescriptorDelete() { }

        public CalendarEventDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CalendarTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CalendarTypeDescriptorGetByExample
    {
        public int CalendarTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CalendarTypeDescriptorGetByIds() { }

        public CalendarTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CalendarTypeDescriptorPost : Resources.CalendarTypeDescriptor.EdFi.CalendarTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarTypeDescriptorPut : Resources.CalendarTypeDescriptor.EdFi.CalendarTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CalendarTypeDescriptorDelete : IHasIdentifier
    {
        public CalendarTypeDescriptorDelete() { }

        public CalendarTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CareerPathwayDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CareerPathwayDescriptorGetByExample
    {
        public int CareerPathwayDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CareerPathwayDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CareerPathwayDescriptorGetByIds() { }

        public CareerPathwayDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CareerPathwayDescriptorPost : Resources.CareerPathwayDescriptor.EdFi.CareerPathwayDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CareerPathwayDescriptorPut : Resources.CareerPathwayDescriptor.EdFi.CareerPathwayDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CareerPathwayDescriptorDelete : IHasIdentifier
    {
        public CareerPathwayDescriptorDelete() { }

        public CareerPathwayDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CharterApprovalAgencyTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CharterApprovalAgencyTypeDescriptorGetByExample
    {
        public int CharterApprovalAgencyTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CharterApprovalAgencyTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CharterApprovalAgencyTypeDescriptorGetByIds() { }

        public CharterApprovalAgencyTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CharterApprovalAgencyTypeDescriptorPost : Resources.CharterApprovalAgencyTypeDescriptor.EdFi.CharterApprovalAgencyTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CharterApprovalAgencyTypeDescriptorPut : Resources.CharterApprovalAgencyTypeDescriptor.EdFi.CharterApprovalAgencyTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CharterApprovalAgencyTypeDescriptorDelete : IHasIdentifier
    {
        public CharterApprovalAgencyTypeDescriptorDelete() { }

        public CharterApprovalAgencyTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CharterStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CharterStatusDescriptorGetByExample
    {
        public int CharterStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CharterStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CharterStatusDescriptorGetByIds() { }

        public CharterStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CharterStatusDescriptorPost : Resources.CharterStatusDescriptor.EdFi.CharterStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CharterStatusDescriptorPut : Resources.CharterStatusDescriptor.EdFi.CharterStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CharterStatusDescriptorDelete : IHasIdentifier
    {
        public CharterStatusDescriptorDelete() { }

        public CharterStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ChartOfAccounts.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ChartOfAccountGetByExample
    {
        public string AccountIdentifier { get; set; }
        public string AccountName { get; set; }
        public string AccountTypeDescriptor { get; set; }
        public string BalanceSheetCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public int FiscalYear { get; set; }
        public string FunctionCode { get; set; }
        public string FundCode { get; set; }
        public Guid Id { get; set; }
        public string ObjectCode { get; set; }
        public string OperationalUnitCode { get; set; }
        public string ProgramCode { get; set; }
        public string ProjectCode { get; set; }
        public string SourceCode { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ChartOfAccountGetByIds : IHasIdentifiers<Guid>
    {
        public ChartOfAccountGetByIds() { }

        public ChartOfAccountGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ChartOfAccountPost : Resources.ChartOfAccount.EdFi.ChartOfAccount
    {
    }

    [ExcludeFromCodeCoverage]
    public class ChartOfAccountPut : Resources.ChartOfAccount.EdFi.ChartOfAccount
    {
    }

    [ExcludeFromCodeCoverage]
    public class ChartOfAccountDelete : IHasIdentifier
    {
        public ChartOfAccountDelete() { }

        public ChartOfAccountDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CitizenshipStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CitizenshipStatusDescriptorGetByExample
    {
        public int CitizenshipStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CitizenshipStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CitizenshipStatusDescriptorGetByIds() { }

        public CitizenshipStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CitizenshipStatusDescriptorPost : Resources.CitizenshipStatusDescriptor.EdFi.CitizenshipStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CitizenshipStatusDescriptorPut : Resources.CitizenshipStatusDescriptor.EdFi.CitizenshipStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CitizenshipStatusDescriptorDelete : IHasIdentifier
    {
        public CitizenshipStatusDescriptorDelete() { }

        public CitizenshipStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ClassPeriods.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ClassPeriodGetByExample
    {
        public string ClassPeriodName { get; set; }
        public Guid Id { get; set; }
        public bool OfficialAttendancePeriod { get; set; }
        public int SchoolId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ClassPeriodGetByIds : IHasIdentifiers<Guid>
    {
        public ClassPeriodGetByIds() { }

        public ClassPeriodGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ClassPeriodPost : Resources.ClassPeriod.EdFi.ClassPeriod
    {
    }

    [ExcludeFromCodeCoverage]
    public class ClassPeriodPut : Resources.ClassPeriod.EdFi.ClassPeriod
    {
    }

    [ExcludeFromCodeCoverage]
    public class ClassPeriodDelete : IHasIdentifier
    {
        public ClassPeriodDelete() { }

        public ClassPeriodDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ClassroomPositionDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ClassroomPositionDescriptorGetByExample
    {
        public int ClassroomPositionDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ClassroomPositionDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ClassroomPositionDescriptorGetByIds() { }

        public ClassroomPositionDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ClassroomPositionDescriptorPost : Resources.ClassroomPositionDescriptor.EdFi.ClassroomPositionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ClassroomPositionDescriptorPut : Resources.ClassroomPositionDescriptor.EdFi.ClassroomPositionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ClassroomPositionDescriptorDelete : IHasIdentifier
    {
        public ClassroomPositionDescriptorDelete() { }

        public ClassroomPositionDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Cohorts.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CohortGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public string CohortDescription { get; set; }
        public string CohortIdentifier { get; set; }
        public string CohortScopeDescriptor { get; set; }
        public string CohortTypeDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortGetByIds : IHasIdentifiers<Guid>
    {
        public CohortGetByIds() { }

        public CohortGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortPost : Resources.Cohort.EdFi.Cohort
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortPut : Resources.Cohort.EdFi.Cohort
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortDelete : IHasIdentifier
    {
        public CohortDelete() { }

        public CohortDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CohortScopeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CohortScopeDescriptorGetByExample
    {
        public int CohortScopeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortScopeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CohortScopeDescriptorGetByIds() { }

        public CohortScopeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortScopeDescriptorPost : Resources.CohortScopeDescriptor.EdFi.CohortScopeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortScopeDescriptorPut : Resources.CohortScopeDescriptor.EdFi.CohortScopeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortScopeDescriptorDelete : IHasIdentifier
    {
        public CohortScopeDescriptorDelete() { }

        public CohortScopeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CohortTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CohortTypeDescriptorGetByExample
    {
        public int CohortTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CohortTypeDescriptorGetByIds() { }

        public CohortTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortTypeDescriptorPost : Resources.CohortTypeDescriptor.EdFi.CohortTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortTypeDescriptorPut : Resources.CohortTypeDescriptor.EdFi.CohortTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortTypeDescriptorDelete : IHasIdentifier
    {
        public CohortTypeDescriptorDelete() { }

        public CohortTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CohortYearTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CohortYearTypeDescriptorGetByExample
    {
        public int CohortYearTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortYearTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CohortYearTypeDescriptorGetByIds() { }

        public CohortYearTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CohortYearTypeDescriptorPost : Resources.CohortYearTypeDescriptor.EdFi.CohortYearTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortYearTypeDescriptorPut : Resources.CohortYearTypeDescriptor.EdFi.CohortYearTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CohortYearTypeDescriptorDelete : IHasIdentifier
    {
        public CohortYearTypeDescriptorDelete() { }

        public CohortYearTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CommunityOrganizations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationGetByExample
    {
        public int CommunityOrganizationId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationGetByIds : IHasIdentifiers<Guid>
    {
        public CommunityOrganizationGetByIds() { }

        public CommunityOrganizationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationPost : Resources.CommunityOrganization.EdFi.CommunityOrganization
    {
    }

    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationPut : Resources.CommunityOrganization.EdFi.CommunityOrganization
    {
    }

    [ExcludeFromCodeCoverage]
    public class CommunityOrganizationDelete : IHasIdentifier
    {
        public CommunityOrganizationDelete() { }

        public CommunityOrganizationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CommunityProviders.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CommunityProviderGetByExample
    {
        public int CommunityOrganizationId { get; set; }
        public int CommunityProviderId { get; set; }
        public bool LicenseExemptIndicator { get; set; }
        public string ProviderCategoryDescriptor { get; set; }
        public string ProviderProfitabilityDescriptor { get; set; }
        public string ProviderStatusDescriptor { get; set; }
        public bool SchoolIndicator { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderGetByIds : IHasIdentifiers<Guid>
    {
        public CommunityProviderGetByIds() { }

        public CommunityProviderGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderPost : Resources.CommunityProvider.EdFi.CommunityProvider
    {
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderPut : Resources.CommunityProvider.EdFi.CommunityProvider
    {
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderDelete : IHasIdentifier
    {
        public CommunityProviderDelete() { }

        public CommunityProviderDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CommunityProviderLicenses.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicenseGetByExample
    {
        public int AuthorizedFacilityCapacity { get; set; }
        public int CommunityProviderId { get; set; }
        public Guid Id { get; set; }
        public DateTime LicenseEffectiveDate { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public string LicenseIdentifier { get; set; }
        public DateTime LicenseIssueDate { get; set; }
        public string LicenseStatusDescriptor { get; set; }
        public string LicenseTypeDescriptor { get; set; }
        public string LicensingOrganization { get; set; }
        public int OldestAgeAuthorizedToServe { get; set; }
        public int YoungestAgeAuthorizedToServe { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicenseGetByIds : IHasIdentifiers<Guid>
    {
        public CommunityProviderLicenseGetByIds() { }

        public CommunityProviderLicenseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicensePost : Resources.CommunityProviderLicense.EdFi.CommunityProviderLicense
    {
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicensePut : Resources.CommunityProviderLicense.EdFi.CommunityProviderLicense
    {
    }

    [ExcludeFromCodeCoverage]
    public class CommunityProviderLicenseDelete : IHasIdentifier
    {
        public CommunityProviderLicenseDelete() { }

        public CommunityProviderLicenseDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CompetencyLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CompetencyLevelDescriptorGetByExample
    {
        public int CompetencyLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CompetencyLevelDescriptorGetByIds() { }

        public CompetencyLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyLevelDescriptorPost : Resources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyLevelDescriptorPut : Resources.CompetencyLevelDescriptor.EdFi.CompetencyLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyLevelDescriptorDelete : IHasIdentifier
    {
        public CompetencyLevelDescriptorDelete() { }

        public CompetencyLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CompetencyObjectives.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CompetencyObjectiveGetByExample
    {
        public string CompetencyObjectiveId { get; set; }
        public string Description { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Objective { get; set; }
        public string ObjectiveGradeLevelDescriptor { get; set; }
        public string SuccessCriteria { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyObjectiveGetByIds : IHasIdentifiers<Guid>
    {
        public CompetencyObjectiveGetByIds() { }

        public CompetencyObjectiveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyObjectivePost : Resources.CompetencyObjective.EdFi.CompetencyObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyObjectivePut : Resources.CompetencyObjective.EdFi.CompetencyObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class CompetencyObjectiveDelete : IHasIdentifier
    {
        public CompetencyObjectiveDelete() { }

        public CompetencyObjectiveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ContactTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ContactTypeDescriptorGetByExample
    {
        public int ContactTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ContactTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ContactTypeDescriptorGetByIds() { }

        public ContactTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ContactTypeDescriptorPost : Resources.ContactTypeDescriptor.EdFi.ContactTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ContactTypeDescriptorPut : Resources.ContactTypeDescriptor.EdFi.ContactTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ContactTypeDescriptorDelete : IHasIdentifier
    {
        public ContactTypeDescriptorDelete() { }

        public ContactTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ContentClassDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ContentClassDescriptorGetByExample
    {
        public int ContentClassDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ContentClassDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ContentClassDescriptorGetByIds() { }

        public ContentClassDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ContentClassDescriptorPost : Resources.ContentClassDescriptor.EdFi.ContentClassDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ContentClassDescriptorPut : Resources.ContentClassDescriptor.EdFi.ContentClassDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ContentClassDescriptorDelete : IHasIdentifier
    {
        public ContentClassDescriptorDelete() { }

        public ContentClassDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ContinuationOfServicesReasonDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ContinuationOfServicesReasonDescriptorGetByExample
    {
        public int ContinuationOfServicesReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ContinuationOfServicesReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ContinuationOfServicesReasonDescriptorGetByIds() { }

        public ContinuationOfServicesReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ContinuationOfServicesReasonDescriptorPost : Resources.ContinuationOfServicesReasonDescriptor.EdFi.ContinuationOfServicesReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ContinuationOfServicesReasonDescriptorPut : Resources.ContinuationOfServicesReasonDescriptor.EdFi.ContinuationOfServicesReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ContinuationOfServicesReasonDescriptorDelete : IHasIdentifier
    {
        public ContinuationOfServicesReasonDescriptorDelete() { }

        public ContinuationOfServicesReasonDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CostRateDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CostRateDescriptorGetByExample
    {
        public int CostRateDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CostRateDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CostRateDescriptorGetByIds() { }

        public CostRateDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CostRateDescriptorPost : Resources.CostRateDescriptor.EdFi.CostRateDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CostRateDescriptorPut : Resources.CostRateDescriptor.EdFi.CostRateDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CostRateDescriptorDelete : IHasIdentifier
    {
        public CostRateDescriptorDelete() { }

        public CostRateDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CountryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CountryDescriptorGetByExample
    {
        public int CountryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CountryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CountryDescriptorGetByIds() { }

        public CountryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CountryDescriptorPost : Resources.CountryDescriptor.EdFi.CountryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CountryDescriptorPut : Resources.CountryDescriptor.EdFi.CountryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CountryDescriptorDelete : IHasIdentifier
    {
        public CountryDescriptorDelete() { }

        public CountryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Courses.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public string CareerPathwayDescriptor { get; set; }
        public string CourseCode { get; set; }
        public string CourseDefinedByDescriptor { get; set; }
        public string CourseDescription { get; set; }
        public string CourseGPAApplicabilityDescriptor { get; set; }
        public string CourseTitle { get; set; }
        public DateTime DateCourseAdopted { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool HighSchoolCourseRequirement { get; set; }
        public Guid Id { get; set; }
        public int MaxCompletionsForCredit { get; set; }
        public decimal MaximumAvailableCreditConversion { get; set; }
        public decimal MaximumAvailableCredits { get; set; }
        public string MaximumAvailableCreditTypeDescriptor { get; set; }
        public decimal MinimumAvailableCreditConversion { get; set; }
        public decimal MinimumAvailableCredits { get; set; }
        public string MinimumAvailableCreditTypeDescriptor { get; set; }
        public int NumberOfParts { get; set; }
        public int TimeRequiredForCompletion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseGetByIds : IHasIdentifiers<Guid>
    {
        public CourseGetByIds() { }

        public CourseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CoursePost : Resources.Course.EdFi.Course
    {
    }

    [ExcludeFromCodeCoverage]
    public class CoursePut : Resources.Course.EdFi.Course
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseDelete : IHasIdentifier
    {
        public CourseDelete() { }

        public CourseDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseAttemptResultDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseAttemptResultDescriptorGetByExample
    {
        public int CourseAttemptResultDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseAttemptResultDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CourseAttemptResultDescriptorGetByIds() { }

        public CourseAttemptResultDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseAttemptResultDescriptorPost : Resources.CourseAttemptResultDescriptor.EdFi.CourseAttemptResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseAttemptResultDescriptorPut : Resources.CourseAttemptResultDescriptor.EdFi.CourseAttemptResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseAttemptResultDescriptorDelete : IHasIdentifier
    {
        public CourseAttemptResultDescriptorDelete() { }

        public CourseAttemptResultDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseDefinedByDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseDefinedByDescriptorGetByExample
    {
        public int CourseDefinedByDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseDefinedByDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CourseDefinedByDescriptorGetByIds() { }

        public CourseDefinedByDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseDefinedByDescriptorPost : Resources.CourseDefinedByDescriptor.EdFi.CourseDefinedByDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseDefinedByDescriptorPut : Resources.CourseDefinedByDescriptor.EdFi.CourseDefinedByDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseDefinedByDescriptorDelete : IHasIdentifier
    {
        public CourseDefinedByDescriptorDelete() { }

        public CourseDefinedByDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseGPAApplicabilityDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseGPAApplicabilityDescriptorGetByExample
    {
        public int CourseGPAApplicabilityDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseGPAApplicabilityDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CourseGPAApplicabilityDescriptorGetByIds() { }

        public CourseGPAApplicabilityDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseGPAApplicabilityDescriptorPost : Resources.CourseGPAApplicabilityDescriptor.EdFi.CourseGPAApplicabilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseGPAApplicabilityDescriptorPut : Resources.CourseGPAApplicabilityDescriptor.EdFi.CourseGPAApplicabilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseGPAApplicabilityDescriptorDelete : IHasIdentifier
    {
        public CourseGPAApplicabilityDescriptorDelete() { }

        public CourseGPAApplicabilityDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseIdentificationSystemDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseIdentificationSystemDescriptorGetByExample
    {
        public int CourseIdentificationSystemDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseIdentificationSystemDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CourseIdentificationSystemDescriptorGetByIds() { }

        public CourseIdentificationSystemDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseIdentificationSystemDescriptorPost : Resources.CourseIdentificationSystemDescriptor.EdFi.CourseIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseIdentificationSystemDescriptorPut : Resources.CourseIdentificationSystemDescriptor.EdFi.CourseIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseIdentificationSystemDescriptorDelete : IHasIdentifier
    {
        public CourseIdentificationSystemDescriptorDelete() { }

        public CourseIdentificationSystemDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseLevelCharacteristicDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseLevelCharacteristicDescriptorGetByExample
    {
        public int CourseLevelCharacteristicDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseLevelCharacteristicDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CourseLevelCharacteristicDescriptorGetByIds() { }

        public CourseLevelCharacteristicDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseLevelCharacteristicDescriptorPost : Resources.CourseLevelCharacteristicDescriptor.EdFi.CourseLevelCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseLevelCharacteristicDescriptorPut : Resources.CourseLevelCharacteristicDescriptor.EdFi.CourseLevelCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseLevelCharacteristicDescriptorDelete : IHasIdentifier
    {
        public CourseLevelCharacteristicDescriptorDelete() { }

        public CourseLevelCharacteristicDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseOfferings.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseOfferingGetByExample
    {
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public int InstructionalTimePlanned { get; set; }
        public string LocalCourseCode { get; set; }
        public string LocalCourseTitle { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SessionName { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseOfferingGetByIds : IHasIdentifiers<Guid>
    {
        public CourseOfferingGetByIds() { }

        public CourseOfferingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseOfferingPost : Resources.CourseOffering.EdFi.CourseOffering
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseOfferingPut : Resources.CourseOffering.EdFi.CourseOffering
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseOfferingDelete : IHasIdentifier
    {
        public CourseOfferingDelete() { }

        public CourseOfferingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseRepeatCodeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseRepeatCodeDescriptorGetByExample
    {
        public int CourseRepeatCodeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseRepeatCodeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CourseRepeatCodeDescriptorGetByIds() { }

        public CourseRepeatCodeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseRepeatCodeDescriptorPost : Resources.CourseRepeatCodeDescriptor.EdFi.CourseRepeatCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseRepeatCodeDescriptorPut : Resources.CourseRepeatCodeDescriptor.EdFi.CourseRepeatCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseRepeatCodeDescriptorDelete : IHasIdentifier
    {
        public CourseRepeatCodeDescriptorDelete() { }

        public CourseRepeatCodeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CourseTranscripts.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CourseTranscriptGetByExample
    {
        public string AlternativeCourseCode { get; set; }
        public string AlternativeCourseTitle { get; set; }
        public string AssigningOrganizationIdentificationCode { get; set; }
        public decimal AttemptedCreditConversion { get; set; }
        public decimal AttemptedCredits { get; set; }
        public string AttemptedCreditTypeDescriptor { get; set; }
        public string CourseAttemptResultDescriptor { get; set; }
        public string CourseCatalogURL { get; set; }
        public string CourseCode { get; set; }
        public int CourseEducationOrganizationId { get; set; }
        public string CourseRepeatCodeDescriptor { get; set; }
        public string CourseTitle { get; set; }
        public decimal EarnedCreditConversion { get; set; }
        public decimal EarnedCredits { get; set; }
        public string EarnedCreditTypeDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public int ExternalEducationOrganizationId { get; set; }
        public string ExternalEducationOrganizationNameOfInstitution { get; set; }
        public string FinalLetterGradeEarned { get; set; }
        public decimal FinalNumericGradeEarned { get; set; }
        public Guid Id { get; set; }
        public string MethodCreditEarnedDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string StudentUniqueId { get; set; }
        public string TermDescriptor { get; set; }
        public string WhenTakenGradeLevelDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseTranscriptGetByIds : IHasIdentifiers<Guid>
    {
        public CourseTranscriptGetByIds() { }

        public CourseTranscriptGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CourseTranscriptPost : Resources.CourseTranscript.EdFi.CourseTranscript
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseTranscriptPut : Resources.CourseTranscript.EdFi.CourseTranscript
    {
    }

    [ExcludeFromCodeCoverage]
    public class CourseTranscriptDelete : IHasIdentifier
    {
        public CourseTranscriptDelete() { }

        public CourseTranscriptDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Credentials.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CredentialGetByExample
    {
        public string CredentialFieldDescriptor { get; set; }
        public string CredentialIdentifier { get; set; }
        public string CredentialTypeDescriptor { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid Id { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string Namespace { get; set; }
        public string StateOfIssueStateAbbreviationDescriptor { get; set; }
        public string TeachingCredentialBasisDescriptor { get; set; }
        public string TeachingCredentialDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialGetByIds() { }

        public CredentialGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialPost : Resources.Credential.EdFi.Credential
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialPut : Resources.Credential.EdFi.Credential
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialDelete : IHasIdentifier
    {
        public CredentialDelete() { }

        public CredentialDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CredentialFieldDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CredentialFieldDescriptorGetByExample
    {
        public int CredentialFieldDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialFieldDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialFieldDescriptorGetByIds() { }

        public CredentialFieldDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialFieldDescriptorPost : Resources.CredentialFieldDescriptor.EdFi.CredentialFieldDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialFieldDescriptorPut : Resources.CredentialFieldDescriptor.EdFi.CredentialFieldDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialFieldDescriptorDelete : IHasIdentifier
    {
        public CredentialFieldDescriptorDelete() { }

        public CredentialFieldDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CredentialTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CredentialTypeDescriptorGetByExample
    {
        public int CredentialTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CredentialTypeDescriptorGetByIds() { }

        public CredentialTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CredentialTypeDescriptorPost : Resources.CredentialTypeDescriptor.EdFi.CredentialTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialTypeDescriptorPut : Resources.CredentialTypeDescriptor.EdFi.CredentialTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CredentialTypeDescriptorDelete : IHasIdentifier
    {
        public CredentialTypeDescriptorDelete() { }

        public CredentialTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CreditCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CreditCategoryDescriptorGetByExample
    {
        public int CreditCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CreditCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CreditCategoryDescriptorGetByIds() { }

        public CreditCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CreditCategoryDescriptorPost : Resources.CreditCategoryDescriptor.EdFi.CreditCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CreditCategoryDescriptorPut : Resources.CreditCategoryDescriptor.EdFi.CreditCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CreditCategoryDescriptorDelete : IHasIdentifier
    {
        public CreditCategoryDescriptorDelete() { }

        public CreditCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CreditTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CreditTypeDescriptorGetByExample
    {
        public int CreditTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CreditTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CreditTypeDescriptorGetByIds() { }

        public CreditTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CreditTypeDescriptorPost : Resources.CreditTypeDescriptor.EdFi.CreditTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CreditTypeDescriptorPut : Resources.CreditTypeDescriptor.EdFi.CreditTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CreditTypeDescriptorDelete : IHasIdentifier
    {
        public CreditTypeDescriptorDelete() { }

        public CreditTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CTEProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CTEProgramServiceDescriptorGetByExample
    {
        public int CTEProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CTEProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CTEProgramServiceDescriptorGetByIds() { }

        public CTEProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CTEProgramServiceDescriptorPost : Resources.CTEProgramServiceDescriptor.EdFi.CTEProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CTEProgramServiceDescriptorPut : Resources.CTEProgramServiceDescriptor.EdFi.CTEProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CTEProgramServiceDescriptorDelete : IHasIdentifier
    {
        public CTEProgramServiceDescriptorDelete() { }

        public CTEProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.CurriculumUsedDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class CurriculumUsedDescriptorGetByExample
    {
        public int CurriculumUsedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CurriculumUsedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public CurriculumUsedDescriptorGetByIds() { }

        public CurriculumUsedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CurriculumUsedDescriptorPost : Resources.CurriculumUsedDescriptor.EdFi.CurriculumUsedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CurriculumUsedDescriptorPut : Resources.CurriculumUsedDescriptor.EdFi.CurriculumUsedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class CurriculumUsedDescriptorDelete : IHasIdentifier
    {
        public CurriculumUsedDescriptorDelete() { }

        public CurriculumUsedDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DeliveryMethodDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DeliveryMethodDescriptorGetByExample
    {
        public int DeliveryMethodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DeliveryMethodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DeliveryMethodDescriptorGetByIds() { }

        public DeliveryMethodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DeliveryMethodDescriptorPost : Resources.DeliveryMethodDescriptor.EdFi.DeliveryMethodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DeliveryMethodDescriptorPut : Resources.DeliveryMethodDescriptor.EdFi.DeliveryMethodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DeliveryMethodDescriptorDelete : IHasIdentifier
    {
        public DeliveryMethodDescriptorDelete() { }

        public DeliveryMethodDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DescriptorMappings.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DescriptorMappingGetByExample
    {
        public Guid Id { get; set; }
        public string MappedNamespace { get; set; }
        public string MappedValue { get; set; }
        public string Namespace { get; set; }
        public string Value { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DescriptorMappingGetByIds : IHasIdentifiers<Guid>
    {
        public DescriptorMappingGetByIds() { }

        public DescriptorMappingGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DescriptorMappingPost : Resources.DescriptorMapping.EdFi.DescriptorMapping
    {
    }

    [ExcludeFromCodeCoverage]
    public class DescriptorMappingPut : Resources.DescriptorMapping.EdFi.DescriptorMapping
    {
    }

    [ExcludeFromCodeCoverage]
    public class DescriptorMappingDelete : IHasIdentifier
    {
        public DescriptorMappingDelete() { }

        public DescriptorMappingDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DiagnosisDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DiagnosisDescriptorGetByExample
    {
        public int DiagnosisDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiagnosisDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DiagnosisDescriptorGetByIds() { }

        public DiagnosisDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiagnosisDescriptorPost : Resources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DiagnosisDescriptorPut : Resources.DiagnosisDescriptor.EdFi.DiagnosisDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DiagnosisDescriptorDelete : IHasIdentifier
    {
        public DiagnosisDescriptorDelete() { }

        public DiagnosisDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DiplomaLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DiplomaLevelDescriptorGetByExample
    {
        public int DiplomaLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DiplomaLevelDescriptorGetByIds() { }

        public DiplomaLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaLevelDescriptorPost : Resources.DiplomaLevelDescriptor.EdFi.DiplomaLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaLevelDescriptorPut : Resources.DiplomaLevelDescriptor.EdFi.DiplomaLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaLevelDescriptorDelete : IHasIdentifier
    {
        public DiplomaLevelDescriptorDelete() { }

        public DiplomaLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DiplomaTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DiplomaTypeDescriptorGetByExample
    {
        public int DiplomaTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DiplomaTypeDescriptorGetByIds() { }

        public DiplomaTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaTypeDescriptorPost : Resources.DiplomaTypeDescriptor.EdFi.DiplomaTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaTypeDescriptorPut : Resources.DiplomaTypeDescriptor.EdFi.DiplomaTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DiplomaTypeDescriptorDelete : IHasIdentifier
    {
        public DiplomaTypeDescriptorDelete() { }

        public DiplomaTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisabilityDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisabilityDescriptorGetByExample
    {
        public int DisabilityDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DisabilityDescriptorGetByIds() { }

        public DisabilityDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDescriptorPost : Resources.DisabilityDescriptor.EdFi.DisabilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDescriptorPut : Resources.DisabilityDescriptor.EdFi.DisabilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDescriptorDelete : IHasIdentifier
    {
        public DisabilityDescriptorDelete() { }

        public DisabilityDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisabilityDesignationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisabilityDesignationDescriptorGetByExample
    {
        public int DisabilityDesignationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDesignationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DisabilityDesignationDescriptorGetByIds() { }

        public DisabilityDesignationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDesignationDescriptorPost : Resources.DisabilityDesignationDescriptor.EdFi.DisabilityDesignationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDesignationDescriptorPut : Resources.DisabilityDesignationDescriptor.EdFi.DisabilityDesignationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDesignationDescriptorDelete : IHasIdentifier
    {
        public DisabilityDesignationDescriptorDelete() { }

        public DisabilityDesignationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisabilityDeterminationSourceTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisabilityDeterminationSourceTypeDescriptorGetByExample
    {
        public int DisabilityDeterminationSourceTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDeterminationSourceTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DisabilityDeterminationSourceTypeDescriptorGetByIds() { }

        public DisabilityDeterminationSourceTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDeterminationSourceTypeDescriptorPost : Resources.DisabilityDeterminationSourceTypeDescriptor.EdFi.DisabilityDeterminationSourceTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDeterminationSourceTypeDescriptorPut : Resources.DisabilityDeterminationSourceTypeDescriptor.EdFi.DisabilityDeterminationSourceTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisabilityDeterminationSourceTypeDescriptorDelete : IHasIdentifier
    {
        public DisabilityDeterminationSourceTypeDescriptorDelete() { }

        public DisabilityDeterminationSourceTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisciplineActions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisciplineActionGetByExample
    {
        public decimal ActualDisciplineActionLength { get; set; }
        public int AssignmentSchoolId { get; set; }
        public string DisciplineActionIdentifier { get; set; }
        public decimal DisciplineActionLength { get; set; }
        public string DisciplineActionLengthDifferenceReasonDescriptor { get; set; }
        public DateTime DisciplineDate { get; set; }
        public Guid Id { get; set; }
        public bool IEPPlacementMeetingIndicator { get; set; }
        public bool ReceivedEducationServicesDuringExpulsion { get; set; }
        public bool RelatedToZeroTolerancePolicy { get; set; }
        public int ResponsibilitySchoolId { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionGetByIds : IHasIdentifiers<Guid>
    {
        public DisciplineActionGetByIds() { }

        public DisciplineActionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionPost : Resources.DisciplineAction.EdFi.DisciplineAction
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionPut : Resources.DisciplineAction.EdFi.DisciplineAction
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionDelete : IHasIdentifier
    {
        public DisciplineActionDelete() { }

        public DisciplineActionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisciplineActionLengthDifferenceReasonDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisciplineActionLengthDifferenceReasonDescriptorGetByExample
    {
        public int DisciplineActionLengthDifferenceReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionLengthDifferenceReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DisciplineActionLengthDifferenceReasonDescriptorGetByIds() { }

        public DisciplineActionLengthDifferenceReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionLengthDifferenceReasonDescriptorPost : Resources.DisciplineActionLengthDifferenceReasonDescriptor.EdFi.DisciplineActionLengthDifferenceReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionLengthDifferenceReasonDescriptorPut : Resources.DisciplineActionLengthDifferenceReasonDescriptor.EdFi.DisciplineActionLengthDifferenceReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineActionLengthDifferenceReasonDescriptorDelete : IHasIdentifier
    {
        public DisciplineActionLengthDifferenceReasonDescriptorDelete() { }

        public DisciplineActionLengthDifferenceReasonDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisciplineDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisciplineDescriptorGetByExample
    {
        public int DisciplineDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DisciplineDescriptorGetByIds() { }

        public DisciplineDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineDescriptorPost : Resources.DisciplineDescriptor.EdFi.DisciplineDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineDescriptorPut : Resources.DisciplineDescriptor.EdFi.DisciplineDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineDescriptorDelete : IHasIdentifier
    {
        public DisciplineDescriptorDelete() { }

        public DisciplineDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisciplineIncidents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentGetByExample
    {
        public string CaseNumber { get; set; }
        public Guid Id { get; set; }
        public decimal IncidentCost { get; set; }
        public DateTime IncidentDate { get; set; }
        public string IncidentDescription { get; set; }
        public string IncidentIdentifier { get; set; }
        public string IncidentLocationDescriptor { get; set; }
        public TimeSpan IncidentTime { get; set; }
        public bool ReportedToLawEnforcement { get; set; }
        public string ReporterDescriptionDescriptor { get; set; }
        public string ReporterName { get; set; }
        public int SchoolId { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentGetByIds : IHasIdentifiers<Guid>
    {
        public DisciplineIncidentGetByIds() { }

        public DisciplineIncidentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentPost : Resources.DisciplineIncident.EdFi.DisciplineIncident
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentPut : Resources.DisciplineIncident.EdFi.DisciplineIncident
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentDelete : IHasIdentifier
    {
        public DisciplineIncidentDelete() { }

        public DisciplineIncidentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.DisciplineIncidentParticipationCodeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentParticipationCodeDescriptorGetByExample
    {
        public int DisciplineIncidentParticipationCodeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentParticipationCodeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public DisciplineIncidentParticipationCodeDescriptorGetByIds() { }

        public DisciplineIncidentParticipationCodeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentParticipationCodeDescriptorPost : Resources.DisciplineIncidentParticipationCodeDescriptor.EdFi.DisciplineIncidentParticipationCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentParticipationCodeDescriptorPut : Resources.DisciplineIncidentParticipationCodeDescriptor.EdFi.DisciplineIncidentParticipationCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class DisciplineIncidentParticipationCodeDescriptorDelete : IHasIdentifier
    {
        public DisciplineIncidentParticipationCodeDescriptorDelete() { }

        public DisciplineIncidentParticipationCodeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationalEnvironmentDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationalEnvironmentDescriptorGetByExample
    {
        public int EducationalEnvironmentDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationalEnvironmentDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducationalEnvironmentDescriptorGetByIds() { }

        public EducationalEnvironmentDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationalEnvironmentDescriptorPost : Resources.EducationalEnvironmentDescriptor.EdFi.EducationalEnvironmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationalEnvironmentDescriptorPut : Resources.EducationalEnvironmentDescriptor.EdFi.EducationalEnvironmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationalEnvironmentDescriptorDelete : IHasIdentifier
    {
        public EducationalEnvironmentDescriptorDelete() { }

        public EducationalEnvironmentDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationContents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationContentGetByExample
    {
        public bool AdditionalAuthorsIndicator { get; set; }
        public string ContentClassDescriptor { get; set; }
        public string ContentIdentifier { get; set; }
        public decimal Cost { get; set; }
        public string CostRateDescriptor { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string InteractivityStyleDescriptor { get; set; }
        public string LearningResourceMetadataURI { get; set; }
        public string LearningStandardId { get; set; }
        public string Namespace { get; set; }
        public DateTime PublicationDate { get; set; }
        public short PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string ShortDescription { get; set; }
        public string TimeRequired { get; set; }
        public string UseRightsURL { get; set; }
        public string Version { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationContentGetByIds : IHasIdentifiers<Guid>
    {
        public EducationContentGetByIds() { }

        public EducationContentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationContentPost : Resources.EducationContent.EdFi.EducationContent
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationContentPut : Resources.EducationContent.EdFi.EducationContent
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationContentDelete : IHasIdentifier
    {
        public EducationContentDelete() { }

        public EducationContentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationAssociationTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAssociationTypeDescriptorGetByExample
    {
        public int EducationOrganizationAssociationTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAssociationTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationAssociationTypeDescriptorGetByIds() { }

        public EducationOrganizationAssociationTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAssociationTypeDescriptorPost : Resources.EducationOrganizationAssociationTypeDescriptor.EdFi.EducationOrganizationAssociationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAssociationTypeDescriptorPut : Resources.EducationOrganizationAssociationTypeDescriptor.EdFi.EducationOrganizationAssociationTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAssociationTypeDescriptorDelete : IHasIdentifier
    {
        public EducationOrganizationAssociationTypeDescriptorDelete() { }

        public EducationOrganizationAssociationTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryDescriptorGetByExample
    {
        public int EducationOrganizationCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationCategoryDescriptorGetByIds() { }

        public EducationOrganizationCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryDescriptorPost : Resources.EducationOrganizationCategoryDescriptor.EdFi.EducationOrganizationCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryDescriptorPut : Resources.EducationOrganizationCategoryDescriptor.EdFi.EducationOrganizationCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryDescriptorDelete : IHasIdentifier
    {
        public EducationOrganizationCategoryDescriptorDelete() { }

        public EducationOrganizationCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationIdentificationSystemDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationSystemDescriptorGetByExample
    {
        public int EducationOrganizationIdentificationSystemDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationSystemDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationIdentificationSystemDescriptorGetByIds() { }

        public EducationOrganizationIdentificationSystemDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationSystemDescriptorPost : Resources.EducationOrganizationIdentificationSystemDescriptor.EdFi.EducationOrganizationIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationSystemDescriptorPut : Resources.EducationOrganizationIdentificationSystemDescriptor.EdFi.EducationOrganizationIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationSystemDescriptorDelete : IHasIdentifier
    {
        public EducationOrganizationIdentificationSystemDescriptorDelete() { }

        public EducationOrganizationIdentificationSystemDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationInterventionPrescriptionAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public int InterventionPrescriptionEducationOrganizationId { get; set; }
        public string InterventionPrescriptionIdentificationCode { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationInterventionPrescriptionAssociationGetByIds() { }

        public EducationOrganizationInterventionPrescriptionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationPost : Resources.EducationOrganizationInterventionPrescriptionAssociation.EdFi.EducationOrganizationInterventionPrescriptionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationPut : Resources.EducationOrganizationInterventionPrescriptionAssociation.EdFi.EducationOrganizationInterventionPrescriptionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInterventionPrescriptionAssociationDelete : IHasIdentifier
    {
        public EducationOrganizationInterventionPrescriptionAssociationDelete() { }

        public EducationOrganizationInterventionPrescriptionAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationNetworks.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkGetByExample
    {
        public int EducationOrganizationNetworkId { get; set; }
        public string NetworkPurposeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationNetworkGetByIds() { }

        public EducationOrganizationNetworkGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkPost : Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkPut : Resources.EducationOrganizationNetwork.EdFi.EducationOrganizationNetwork
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkDelete : IHasIdentifier
    {
        public EducationOrganizationNetworkDelete() { }

        public EducationOrganizationNetworkDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationNetworkAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationNetworkId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public int MemberEducationOrganizationId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationNetworkAssociationGetByIds() { }

        public EducationOrganizationNetworkAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationPost : Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationPut : Resources.EducationOrganizationNetworkAssociation.EdFi.EducationOrganizationNetworkAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationNetworkAssociationDelete : IHasIdentifier
    {
        public EducationOrganizationNetworkAssociationDelete() { }

        public EducationOrganizationNetworkAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationOrganizationPeerAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public int PeerEducationOrganizationId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public EducationOrganizationPeerAssociationGetByIds() { }

        public EducationOrganizationPeerAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationPost : Resources.EducationOrganizationPeerAssociation.EdFi.EducationOrganizationPeerAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationPut : Resources.EducationOrganizationPeerAssociation.EdFi.EducationOrganizationPeerAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationPeerAssociationDelete : IHasIdentifier
    {
        public EducationOrganizationPeerAssociationDelete() { }

        public EducationOrganizationPeerAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationPlanDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationPlanDescriptorGetByExample
    {
        public int EducationPlanDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationPlanDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EducationPlanDescriptorGetByIds() { }

        public EducationPlanDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationPlanDescriptorPost : Resources.EducationPlanDescriptor.EdFi.EducationPlanDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationPlanDescriptorPut : Resources.EducationPlanDescriptor.EdFi.EducationPlanDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationPlanDescriptorDelete : IHasIdentifier
    {
        public EducationPlanDescriptorDelete() { }

        public EducationPlanDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EducationServiceCenters.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterGetByExample
    {
        public int EducationServiceCenterId { get; set; }
        public int StateEducationAgencyId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterGetByIds : IHasIdentifiers<Guid>
    {
        public EducationServiceCenterGetByIds() { }

        public EducationServiceCenterGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterPost : Resources.EducationServiceCenter.EdFi.EducationServiceCenter
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterPut : Resources.EducationServiceCenter.EdFi.EducationServiceCenter
    {
    }

    [ExcludeFromCodeCoverage]
    public class EducationServiceCenterDelete : IHasIdentifier
    {
        public EducationServiceCenterDelete() { }

        public EducationServiceCenterDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ElectronicMailTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ElectronicMailTypeDescriptorGetByExample
    {
        public int ElectronicMailTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ElectronicMailTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ElectronicMailTypeDescriptorGetByIds() { }

        public ElectronicMailTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ElectronicMailTypeDescriptorPost : Resources.ElectronicMailTypeDescriptor.EdFi.ElectronicMailTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ElectronicMailTypeDescriptorPut : Resources.ElectronicMailTypeDescriptor.EdFi.ElectronicMailTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ElectronicMailTypeDescriptorDelete : IHasIdentifier
    {
        public ElectronicMailTypeDescriptorDelete() { }

        public ElectronicMailTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EmploymentStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EmploymentStatusDescriptorGetByExample
    {
        public int EmploymentStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EmploymentStatusDescriptorGetByIds() { }

        public EmploymentStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentStatusDescriptorPost : Resources.EmploymentStatusDescriptor.EdFi.EmploymentStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentStatusDescriptorPut : Resources.EmploymentStatusDescriptor.EdFi.EmploymentStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EmploymentStatusDescriptorDelete : IHasIdentifier
    {
        public EmploymentStatusDescriptorDelete() { }

        public EmploymentStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EntryGradeLevelReasonDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EntryGradeLevelReasonDescriptorGetByExample
    {
        public int EntryGradeLevelReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EntryGradeLevelReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EntryGradeLevelReasonDescriptorGetByIds() { }

        public EntryGradeLevelReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EntryGradeLevelReasonDescriptorPost : Resources.EntryGradeLevelReasonDescriptor.EdFi.EntryGradeLevelReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EntryGradeLevelReasonDescriptorPut : Resources.EntryGradeLevelReasonDescriptor.EdFi.EntryGradeLevelReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EntryGradeLevelReasonDescriptorDelete : IHasIdentifier
    {
        public EntryGradeLevelReasonDescriptorDelete() { }

        public EntryGradeLevelReasonDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EntryTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EntryTypeDescriptorGetByExample
    {
        public int EntryTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EntryTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EntryTypeDescriptorGetByIds() { }

        public EntryTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EntryTypeDescriptorPost : Resources.EntryTypeDescriptor.EdFi.EntryTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EntryTypeDescriptorPut : Resources.EntryTypeDescriptor.EdFi.EntryTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EntryTypeDescriptorDelete : IHasIdentifier
    {
        public EntryTypeDescriptorDelete() { }

        public EntryTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.EventCircumstanceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class EventCircumstanceDescriptorGetByExample
    {
        public int EventCircumstanceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EventCircumstanceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public EventCircumstanceDescriptorGetByIds() { }

        public EventCircumstanceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EventCircumstanceDescriptorPost : Resources.EventCircumstanceDescriptor.EdFi.EventCircumstanceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EventCircumstanceDescriptorPut : Resources.EventCircumstanceDescriptor.EdFi.EventCircumstanceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class EventCircumstanceDescriptorDelete : IHasIdentifier
    {
        public EventCircumstanceDescriptorDelete() { }

        public EventCircumstanceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ExitWithdrawTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ExitWithdrawTypeDescriptorGetByExample
    {
        public int ExitWithdrawTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ExitWithdrawTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ExitWithdrawTypeDescriptorGetByIds() { }

        public ExitWithdrawTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ExitWithdrawTypeDescriptorPost : Resources.ExitWithdrawTypeDescriptor.EdFi.ExitWithdrawTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ExitWithdrawTypeDescriptorPut : Resources.ExitWithdrawTypeDescriptor.EdFi.ExitWithdrawTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ExitWithdrawTypeDescriptorDelete : IHasIdentifier
    {
        public ExitWithdrawTypeDescriptorDelete() { }

        public ExitWithdrawTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.FeederSchoolAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FeederRelationshipDescription { get; set; }
        public int FeederSchoolId { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public FeederSchoolAssociationGetByIds() { }

        public FeederSchoolAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationPost : Resources.FeederSchoolAssociation.EdFi.FeederSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationPut : Resources.FeederSchoolAssociation.EdFi.FeederSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class FeederSchoolAssociationDelete : IHasIdentifier
    {
        public FeederSchoolAssociationDelete() { }

        public FeederSchoolAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.FinancialCollectionDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class FinancialCollectionDescriptorGetByExample
    {
        public int FinancialCollectionDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FinancialCollectionDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public FinancialCollectionDescriptorGetByIds() { }

        public FinancialCollectionDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FinancialCollectionDescriptorPost : Resources.FinancialCollectionDescriptor.EdFi.FinancialCollectionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FinancialCollectionDescriptorPut : Resources.FinancialCollectionDescriptor.EdFi.FinancialCollectionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FinancialCollectionDescriptorDelete : IHasIdentifier
    {
        public FinancialCollectionDescriptorDelete() { }

        public FinancialCollectionDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.FunctionDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class FunctionDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FunctionDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public FunctionDimensionGetByIds() { }

        public FunctionDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FunctionDimensionPost : Resources.FunctionDimension.EdFi.FunctionDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class FunctionDimensionPut : Resources.FunctionDimension.EdFi.FunctionDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class FunctionDimensionDelete : IHasIdentifier
    {
        public FunctionDimensionDelete() { }

        public FunctionDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.FundDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class FundDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FundDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public FundDimensionGetByIds() { }

        public FundDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FundDimensionPost : Resources.FundDimension.EdFi.FundDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class FundDimensionPut : Resources.FundDimension.EdFi.FundDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class FundDimensionDelete : IHasIdentifier
    {
        public FundDimensionDelete() { }

        public FundDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Grades.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradeGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime CurrentGradeAsOfDate { get; set; }
        public bool CurrentGradeIndicator { get; set; }
        public string DiagnosticStatement { get; set; }
        public string GradeTypeDescriptor { get; set; }
        public string GradingPeriodDescriptor { get; set; }
        public short GradingPeriodSchoolYear { get; set; }
        public int GradingPeriodSequence { get; set; }
        public Guid Id { get; set; }
        public string LetterGradeEarned { get; set; }
        public string LocalCourseCode { get; set; }
        public decimal NumericGradeEarned { get; set; }
        public string PerformanceBaseConversionDescriptor { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradeGetByIds : IHasIdentifiers<Guid>
    {
        public GradeGetByIds() { }

        public GradeGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradePost : Resources.Grade.EdFi.Grade
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradePut : Resources.Grade.EdFi.Grade
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradeDelete : IHasIdentifier
    {
        public GradeDelete() { }

        public GradeDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradebookEntries.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradebookEntryGetByExample
    {
        public DateTime DateAssigned { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TimeSpan DueTime { get; set; }
        public string GradebookEntryIdentifier { get; set; }
        public string GradebookEntryTypeDescriptor { get; set; }
        public string GradingPeriodDescriptor { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public decimal MaxPoints { get; set; }
        public string Namespace { get; set; }
        public int PeriodSequence { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string SourceSectionIdentifier { get; set; }
        public string Title { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryGetByIds : IHasIdentifiers<Guid>
    {
        public GradebookEntryGetByIds() { }

        public GradebookEntryGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryPost : Resources.GradebookEntry.EdFi.GradebookEntry
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryPut : Resources.GradebookEntry.EdFi.GradebookEntry
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryDelete : IHasIdentifier
    {
        public GradebookEntryDelete() { }

        public GradebookEntryDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradebookEntryTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradebookEntryTypeDescriptorGetByExample
    {
        public int GradebookEntryTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GradebookEntryTypeDescriptorGetByIds() { }

        public GradebookEntryTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryTypeDescriptorPost : Resources.GradebookEntryTypeDescriptor.EdFi.GradebookEntryTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryTypeDescriptorPut : Resources.GradebookEntryTypeDescriptor.EdFi.GradebookEntryTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradebookEntryTypeDescriptorDelete : IHasIdentifier
    {
        public GradebookEntryTypeDescriptorDelete() { }

        public GradebookEntryTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradeLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradeLevelDescriptorGetByExample
    {
        public int GradeLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradeLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GradeLevelDescriptorGetByIds() { }

        public GradeLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradeLevelDescriptorPost : Resources.GradeLevelDescriptor.EdFi.GradeLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradeLevelDescriptorPut : Resources.GradeLevelDescriptor.EdFi.GradeLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradeLevelDescriptorDelete : IHasIdentifier
    {
        public GradeLevelDescriptorDelete() { }

        public GradeLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradePointAverageTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradePointAverageTypeDescriptorGetByExample
    {
        public int GradePointAverageTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradePointAverageTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GradePointAverageTypeDescriptorGetByIds() { }

        public GradePointAverageTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradePointAverageTypeDescriptorPost : Resources.GradePointAverageTypeDescriptor.EdFi.GradePointAverageTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradePointAverageTypeDescriptorPut : Resources.GradePointAverageTypeDescriptor.EdFi.GradePointAverageTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradePointAverageTypeDescriptorDelete : IHasIdentifier
    {
        public GradePointAverageTypeDescriptorDelete() { }

        public GradePointAverageTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradeTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradeTypeDescriptorGetByExample
    {
        public int GradeTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradeTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GradeTypeDescriptorGetByIds() { }

        public GradeTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradeTypeDescriptorPost : Resources.GradeTypeDescriptor.EdFi.GradeTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradeTypeDescriptorPut : Resources.GradeTypeDescriptor.EdFi.GradeTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradeTypeDescriptorDelete : IHasIdentifier
    {
        public GradeTypeDescriptorDelete() { }

        public GradeTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradingPeriods.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradingPeriodGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GradingPeriodDescriptor { get; set; }
        public Guid Id { get; set; }
        public int PeriodSequence { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public int TotalInstructionalDays { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodGetByIds : IHasIdentifiers<Guid>
    {
        public GradingPeriodGetByIds() { }

        public GradingPeriodGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodPost : Resources.GradingPeriod.EdFi.GradingPeriod
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodPut : Resources.GradingPeriod.EdFi.GradingPeriod
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodDelete : IHasIdentifier
    {
        public GradingPeriodDelete() { }

        public GradingPeriodDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GradingPeriodDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GradingPeriodDescriptorGetByExample
    {
        public int GradingPeriodDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GradingPeriodDescriptorGetByIds() { }

        public GradingPeriodDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodDescriptorPost : Resources.GradingPeriodDescriptor.EdFi.GradingPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodDescriptorPut : Resources.GradingPeriodDescriptor.EdFi.GradingPeriodDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GradingPeriodDescriptorDelete : IHasIdentifier
    {
        public GradingPeriodDescriptorDelete() { }

        public GradingPeriodDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GraduationPlans.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GraduationPlanGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public string GraduationPlanTypeDescriptor { get; set; }
        public short GraduationSchoolYear { get; set; }
        public Guid Id { get; set; }
        public bool IndividualPlan { get; set; }
        public decimal TotalRequiredCreditConversion { get; set; }
        public decimal TotalRequiredCredits { get; set; }
        public string TotalRequiredCreditTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanGetByIds : IHasIdentifiers<Guid>
    {
        public GraduationPlanGetByIds() { }

        public GraduationPlanGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanPost : Resources.GraduationPlan.EdFi.GraduationPlan
    {
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanPut : Resources.GraduationPlan.EdFi.GraduationPlan
    {
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanDelete : IHasIdentifier
    {
        public GraduationPlanDelete() { }

        public GraduationPlanDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GraduationPlanTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GraduationPlanTypeDescriptorGetByExample
    {
        public int GraduationPlanTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GraduationPlanTypeDescriptorGetByIds() { }

        public GraduationPlanTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanTypeDescriptorPost : Resources.GraduationPlanTypeDescriptor.EdFi.GraduationPlanTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanTypeDescriptorPut : Resources.GraduationPlanTypeDescriptor.EdFi.GraduationPlanTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GraduationPlanTypeDescriptorDelete : IHasIdentifier
    {
        public GraduationPlanTypeDescriptorDelete() { }

        public GraduationPlanTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.GunFreeSchoolsActReportingStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class GunFreeSchoolsActReportingStatusDescriptorGetByExample
    {
        public int GunFreeSchoolsActReportingStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GunFreeSchoolsActReportingStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public GunFreeSchoolsActReportingStatusDescriptorGetByIds() { }

        public GunFreeSchoolsActReportingStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class GunFreeSchoolsActReportingStatusDescriptorPost : Resources.GunFreeSchoolsActReportingStatusDescriptor.EdFi.GunFreeSchoolsActReportingStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GunFreeSchoolsActReportingStatusDescriptorPut : Resources.GunFreeSchoolsActReportingStatusDescriptor.EdFi.GunFreeSchoolsActReportingStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class GunFreeSchoolsActReportingStatusDescriptorDelete : IHasIdentifier
    {
        public GunFreeSchoolsActReportingStatusDescriptorDelete() { }

        public GunFreeSchoolsActReportingStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.HomelessPrimaryNighttimeResidenceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class HomelessPrimaryNighttimeResidenceDescriptorGetByExample
    {
        public int HomelessPrimaryNighttimeResidenceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HomelessPrimaryNighttimeResidenceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public HomelessPrimaryNighttimeResidenceDescriptorGetByIds() { }

        public HomelessPrimaryNighttimeResidenceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HomelessPrimaryNighttimeResidenceDescriptorPost : Resources.HomelessPrimaryNighttimeResidenceDescriptor.EdFi.HomelessPrimaryNighttimeResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class HomelessPrimaryNighttimeResidenceDescriptorPut : Resources.HomelessPrimaryNighttimeResidenceDescriptor.EdFi.HomelessPrimaryNighttimeResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class HomelessPrimaryNighttimeResidenceDescriptorDelete : IHasIdentifier
    {
        public HomelessPrimaryNighttimeResidenceDescriptorDelete() { }

        public HomelessPrimaryNighttimeResidenceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.HomelessProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class HomelessProgramServiceDescriptorGetByExample
    {
        public int HomelessProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HomelessProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public HomelessProgramServiceDescriptorGetByIds() { }

        public HomelessProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class HomelessProgramServiceDescriptorPost : Resources.HomelessProgramServiceDescriptor.EdFi.HomelessProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class HomelessProgramServiceDescriptorPut : Resources.HomelessProgramServiceDescriptor.EdFi.HomelessProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class HomelessProgramServiceDescriptorDelete : IHasIdentifier
    {
        public HomelessProgramServiceDescriptorDelete() { }

        public HomelessProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.IdentificationDocumentUseDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class IdentificationDocumentUseDescriptorGetByExample
    {
        public int IdentificationDocumentUseDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IdentificationDocumentUseDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public IdentificationDocumentUseDescriptorGetByIds() { }

        public IdentificationDocumentUseDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IdentificationDocumentUseDescriptorPost : Resources.IdentificationDocumentUseDescriptor.EdFi.IdentificationDocumentUseDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IdentificationDocumentUseDescriptorPut : Resources.IdentificationDocumentUseDescriptor.EdFi.IdentificationDocumentUseDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IdentificationDocumentUseDescriptorDelete : IHasIdentifier
    {
        public IdentificationDocumentUseDescriptorDelete() { }

        public IdentificationDocumentUseDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.IncidentLocationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class IncidentLocationDescriptorGetByExample
    {
        public int IncidentLocationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IncidentLocationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public IncidentLocationDescriptorGetByIds() { }

        public IncidentLocationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IncidentLocationDescriptorPost : Resources.IncidentLocationDescriptor.EdFi.IncidentLocationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IncidentLocationDescriptorPut : Resources.IncidentLocationDescriptor.EdFi.IncidentLocationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IncidentLocationDescriptorDelete : IHasIdentifier
    {
        public IncidentLocationDescriptorDelete() { }

        public IncidentLocationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.IndicatorDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class IndicatorDescriptorGetByExample
    {
        public int IndicatorDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public IndicatorDescriptorGetByIds() { }

        public IndicatorDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorDescriptorPost : Resources.IndicatorDescriptor.EdFi.IndicatorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorDescriptorPut : Resources.IndicatorDescriptor.EdFi.IndicatorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorDescriptorDelete : IHasIdentifier
    {
        public IndicatorDescriptorDelete() { }

        public IndicatorDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.IndicatorGroupDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class IndicatorGroupDescriptorGetByExample
    {
        public int IndicatorGroupDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorGroupDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public IndicatorGroupDescriptorGetByIds() { }

        public IndicatorGroupDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorGroupDescriptorPost : Resources.IndicatorGroupDescriptor.EdFi.IndicatorGroupDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorGroupDescriptorPut : Resources.IndicatorGroupDescriptor.EdFi.IndicatorGroupDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorGroupDescriptorDelete : IHasIdentifier
    {
        public IndicatorGroupDescriptorDelete() { }

        public IndicatorGroupDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.IndicatorLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class IndicatorLevelDescriptorGetByExample
    {
        public int IndicatorLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public IndicatorLevelDescriptorGetByIds() { }

        public IndicatorLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorLevelDescriptorPost : Resources.IndicatorLevelDescriptor.EdFi.IndicatorLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorLevelDescriptorPut : Resources.IndicatorLevelDescriptor.EdFi.IndicatorLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class IndicatorLevelDescriptorDelete : IHasIdentifier
    {
        public IndicatorLevelDescriptorDelete() { }

        public IndicatorLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InstitutionTelephoneNumberTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InstitutionTelephoneNumberTypeDescriptorGetByExample
    {
        public int InstitutionTelephoneNumberTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionTelephoneNumberTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InstitutionTelephoneNumberTypeDescriptorGetByIds() { }

        public InstitutionTelephoneNumberTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionTelephoneNumberTypeDescriptorPost : Resources.InstitutionTelephoneNumberTypeDescriptor.EdFi.InstitutionTelephoneNumberTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionTelephoneNumberTypeDescriptorPut : Resources.InstitutionTelephoneNumberTypeDescriptor.EdFi.InstitutionTelephoneNumberTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InstitutionTelephoneNumberTypeDescriptorDelete : IHasIdentifier
    {
        public InstitutionTelephoneNumberTypeDescriptorDelete() { }

        public InstitutionTelephoneNumberTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InteractivityStyleDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InteractivityStyleDescriptorGetByExample
    {
        public int InteractivityStyleDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InteractivityStyleDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InteractivityStyleDescriptorGetByIds() { }

        public InteractivityStyleDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InteractivityStyleDescriptorPost : Resources.InteractivityStyleDescriptor.EdFi.InteractivityStyleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InteractivityStyleDescriptorPut : Resources.InteractivityStyleDescriptor.EdFi.InteractivityStyleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InteractivityStyleDescriptorDelete : IHasIdentifier
    {
        public InteractivityStyleDescriptorDelete() { }

        public InteractivityStyleDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InternetAccessDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InternetAccessDescriptorGetByExample
    {
        public int InternetAccessDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InternetAccessDescriptorGetByIds() { }

        public InternetAccessDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessDescriptorPost : Resources.InternetAccessDescriptor.EdFi.InternetAccessDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessDescriptorPut : Resources.InternetAccessDescriptor.EdFi.InternetAccessDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessDescriptorDelete : IHasIdentifier
    {
        public InternetAccessDescriptorDelete() { }

        public InternetAccessDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InternetAccessTypeInResidenceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InternetAccessTypeInResidenceDescriptorGetByExample
    {
        public int InternetAccessTypeInResidenceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessTypeInResidenceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InternetAccessTypeInResidenceDescriptorGetByIds() { }

        public InternetAccessTypeInResidenceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessTypeInResidenceDescriptorPost : Resources.InternetAccessTypeInResidenceDescriptor.EdFi.InternetAccessTypeInResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessTypeInResidenceDescriptorPut : Resources.InternetAccessTypeInResidenceDescriptor.EdFi.InternetAccessTypeInResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternetAccessTypeInResidenceDescriptorDelete : IHasIdentifier
    {
        public InternetAccessTypeInResidenceDescriptorDelete() { }

        public InternetAccessTypeInResidenceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InternetPerformanceInResidenceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InternetPerformanceInResidenceDescriptorGetByExample
    {
        public int InternetPerformanceInResidenceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternetPerformanceInResidenceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InternetPerformanceInResidenceDescriptorGetByIds() { }

        public InternetPerformanceInResidenceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InternetPerformanceInResidenceDescriptorPost : Resources.InternetPerformanceInResidenceDescriptor.EdFi.InternetPerformanceInResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternetPerformanceInResidenceDescriptorPut : Resources.InternetPerformanceInResidenceDescriptor.EdFi.InternetPerformanceInResidenceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InternetPerformanceInResidenceDescriptorDelete : IHasIdentifier
    {
        public InternetPerformanceInResidenceDescriptorDelete() { }

        public InternetPerformanceInResidenceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Interventions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InterventionGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string DeliveryMethodDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string InterventionClassDescriptor { get; set; }
        public string InterventionIdentificationCode { get; set; }
        public int MaxDosage { get; set; }
        public int MinDosage { get; set; }
        public string Namespace { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionGetByIds : IHasIdentifiers<Guid>
    {
        public InterventionGetByIds() { }

        public InterventionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionPost : Resources.Intervention.EdFi.Intervention
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionPut : Resources.Intervention.EdFi.Intervention
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionDelete : IHasIdentifier
    {
        public InterventionDelete() { }

        public InterventionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InterventionClassDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InterventionClassDescriptorGetByExample
    {
        public int InterventionClassDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionClassDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InterventionClassDescriptorGetByIds() { }

        public InterventionClassDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionClassDescriptorPost : Resources.InterventionClassDescriptor.EdFi.InterventionClassDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionClassDescriptorPut : Resources.InterventionClassDescriptor.EdFi.InterventionClassDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionClassDescriptorDelete : IHasIdentifier
    {
        public InterventionClassDescriptorDelete() { }

        public InterventionClassDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InterventionEffectivenessRatingDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InterventionEffectivenessRatingDescriptorGetByExample
    {
        public int InterventionEffectivenessRatingDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionEffectivenessRatingDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public InterventionEffectivenessRatingDescriptorGetByIds() { }

        public InterventionEffectivenessRatingDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionEffectivenessRatingDescriptorPost : Resources.InterventionEffectivenessRatingDescriptor.EdFi.InterventionEffectivenessRatingDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionEffectivenessRatingDescriptorPut : Resources.InterventionEffectivenessRatingDescriptor.EdFi.InterventionEffectivenessRatingDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionEffectivenessRatingDescriptorDelete : IHasIdentifier
    {
        public InterventionEffectivenessRatingDescriptorDelete() { }

        public InterventionEffectivenessRatingDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InterventionPrescriptions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionGetByExample
    {
        public string DeliveryMethodDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string InterventionClassDescriptor { get; set; }
        public string InterventionPrescriptionIdentificationCode { get; set; }
        public int MaxDosage { get; set; }
        public int MinDosage { get; set; }
        public string Namespace { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionGetByIds : IHasIdentifiers<Guid>
    {
        public InterventionPrescriptionGetByIds() { }

        public InterventionPrescriptionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionPost : Resources.InterventionPrescription.EdFi.InterventionPrescription
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionPut : Resources.InterventionPrescription.EdFi.InterventionPrescription
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionPrescriptionDelete : IHasIdentifier
    {
        public InterventionPrescriptionDelete() { }

        public InterventionPrescriptionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.InterventionStudies.EdFi
{

    [ExcludeFromCodeCoverage]
    public class InterventionStudyGetByExample
    {
        public string DeliveryMethodDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string InterventionClassDescriptor { get; set; }
        public int InterventionPrescriptionEducationOrganizationId { get; set; }
        public string InterventionPrescriptionIdentificationCode { get; set; }
        public string InterventionStudyIdentificationCode { get; set; }
        public int Participants { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionStudyGetByIds : IHasIdentifiers<Guid>
    {
        public InterventionStudyGetByIds() { }

        public InterventionStudyGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InterventionStudyPost : Resources.InterventionStudy.EdFi.InterventionStudy
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionStudyPut : Resources.InterventionStudy.EdFi.InterventionStudy
    {
    }

    [ExcludeFromCodeCoverage]
    public class InterventionStudyDelete : IHasIdentifier
    {
        public InterventionStudyDelete() { }

        public InterventionStudyDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LanguageDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LanguageDescriptorGetByExample
    {
        public int LanguageDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LanguageDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LanguageDescriptorGetByIds() { }

        public LanguageDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LanguageDescriptorPost : Resources.LanguageDescriptor.EdFi.LanguageDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LanguageDescriptorPut : Resources.LanguageDescriptor.EdFi.LanguageDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LanguageDescriptorDelete : IHasIdentifier
    {
        public LanguageDescriptorDelete() { }

        public LanguageDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LanguageInstructionProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LanguageInstructionProgramServiceDescriptorGetByExample
    {
        public int LanguageInstructionProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LanguageInstructionProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LanguageInstructionProgramServiceDescriptorGetByIds() { }

        public LanguageInstructionProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LanguageInstructionProgramServiceDescriptorPost : Resources.LanguageInstructionProgramServiceDescriptor.EdFi.LanguageInstructionProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LanguageInstructionProgramServiceDescriptorPut : Resources.LanguageInstructionProgramServiceDescriptor.EdFi.LanguageInstructionProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LanguageInstructionProgramServiceDescriptorDelete : IHasIdentifier
    {
        public LanguageInstructionProgramServiceDescriptorDelete() { }

        public LanguageInstructionProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LanguageUseDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LanguageUseDescriptorGetByExample
    {
        public int LanguageUseDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LanguageUseDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LanguageUseDescriptorGetByIds() { }

        public LanguageUseDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LanguageUseDescriptorPost : Resources.LanguageUseDescriptor.EdFi.LanguageUseDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LanguageUseDescriptorPut : Resources.LanguageUseDescriptor.EdFi.LanguageUseDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LanguageUseDescriptorDelete : IHasIdentifier
    {
        public LanguageUseDescriptorDelete() { }

        public LanguageUseDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LearningObjectives.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LearningObjectiveGetByExample
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string LearningObjectiveId { get; set; }
        public string Namespace { get; set; }
        public string Nomenclature { get; set; }
        public string Objective { get; set; }
        public string ParentLearningObjectiveId { get; set; }
        public string ParentNamespace { get; set; }
        public string SuccessCriteria { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningObjectiveGetByIds : IHasIdentifiers<Guid>
    {
        public LearningObjectiveGetByIds() { }

        public LearningObjectiveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningObjectivePost : Resources.LearningObjective.EdFi.LearningObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningObjectivePut : Resources.LearningObjective.EdFi.LearningObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningObjectiveDelete : IHasIdentifier
    {
        public LearningObjectiveDelete() { }

        public LearningObjectiveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LearningStandards.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LearningStandardGetByExample
    {
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string LearningStandardCategoryDescriptor { get; set; }
        public string LearningStandardId { get; set; }
        public string LearningStandardItemCode { get; set; }
        public string LearningStandardScopeDescriptor { get; set; }
        public string Namespace { get; set; }
        public string ParentLearningStandardId { get; set; }
        public string SuccessCriteria { get; set; }
        public string URI { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardGetByIds : IHasIdentifiers<Guid>
    {
        public LearningStandardGetByIds() { }

        public LearningStandardGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardPost : Resources.LearningStandard.EdFi.LearningStandard
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardPut : Resources.LearningStandard.EdFi.LearningStandard
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardDelete : IHasIdentifier
    {
        public LearningStandardDelete() { }

        public LearningStandardDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LearningStandardCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LearningStandardCategoryDescriptorGetByExample
    {
        public int LearningStandardCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LearningStandardCategoryDescriptorGetByIds() { }

        public LearningStandardCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardCategoryDescriptorPost : Resources.LearningStandardCategoryDescriptor.EdFi.LearningStandardCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardCategoryDescriptorPut : Resources.LearningStandardCategoryDescriptor.EdFi.LearningStandardCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardCategoryDescriptorDelete : IHasIdentifier
    {
        public LearningStandardCategoryDescriptorDelete() { }

        public LearningStandardCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LearningStandardEquivalenceAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceAssociationGetByExample
    {
        public DateTime EffectiveDate { get; set; }
        public Guid Id { get; set; }
        public string LearningStandardEquivalenceStrengthDescription { get; set; }
        public string LearningStandardEquivalenceStrengthDescriptor { get; set; }
        public string Namespace { get; set; }
        public string SourceLearningStandardId { get; set; }
        public string TargetLearningStandardId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public LearningStandardEquivalenceAssociationGetByIds() { }

        public LearningStandardEquivalenceAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceAssociationPost : Resources.LearningStandardEquivalenceAssociation.EdFi.LearningStandardEquivalenceAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceAssociationPut : Resources.LearningStandardEquivalenceAssociation.EdFi.LearningStandardEquivalenceAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceAssociationDelete : IHasIdentifier
    {
        public LearningStandardEquivalenceAssociationDelete() { }

        public LearningStandardEquivalenceAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LearningStandardEquivalenceStrengthDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceStrengthDescriptorGetByExample
    {
        public int LearningStandardEquivalenceStrengthDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceStrengthDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LearningStandardEquivalenceStrengthDescriptorGetByIds() { }

        public LearningStandardEquivalenceStrengthDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceStrengthDescriptorPost : Resources.LearningStandardEquivalenceStrengthDescriptor.EdFi.LearningStandardEquivalenceStrengthDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceStrengthDescriptorPut : Resources.LearningStandardEquivalenceStrengthDescriptor.EdFi.LearningStandardEquivalenceStrengthDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardEquivalenceStrengthDescriptorDelete : IHasIdentifier
    {
        public LearningStandardEquivalenceStrengthDescriptorDelete() { }

        public LearningStandardEquivalenceStrengthDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LearningStandardScopeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LearningStandardScopeDescriptorGetByExample
    {
        public int LearningStandardScopeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardScopeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LearningStandardScopeDescriptorGetByIds() { }

        public LearningStandardScopeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardScopeDescriptorPost : Resources.LearningStandardScopeDescriptor.EdFi.LearningStandardScopeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardScopeDescriptorPut : Resources.LearningStandardScopeDescriptor.EdFi.LearningStandardScopeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LearningStandardScopeDescriptorDelete : IHasIdentifier
    {
        public LearningStandardScopeDescriptorDelete() { }

        public LearningStandardScopeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LevelOfEducationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LevelOfEducationDescriptorGetByExample
    {
        public int LevelOfEducationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfEducationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LevelOfEducationDescriptorGetByIds() { }

        public LevelOfEducationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfEducationDescriptorPost : Resources.LevelOfEducationDescriptor.EdFi.LevelOfEducationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfEducationDescriptorPut : Resources.LevelOfEducationDescriptor.EdFi.LevelOfEducationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LevelOfEducationDescriptorDelete : IHasIdentifier
    {
        public LevelOfEducationDescriptorDelete() { }

        public LevelOfEducationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LicenseStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LicenseStatusDescriptorGetByExample
    {
        public int LicenseStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LicenseStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LicenseStatusDescriptorGetByIds() { }

        public LicenseStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LicenseStatusDescriptorPost : Resources.LicenseStatusDescriptor.EdFi.LicenseStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LicenseStatusDescriptorPut : Resources.LicenseStatusDescriptor.EdFi.LicenseStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LicenseStatusDescriptorDelete : IHasIdentifier
    {
        public LicenseStatusDescriptorDelete() { }

        public LicenseStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LicenseTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LicenseTypeDescriptorGetByExample
    {
        public int LicenseTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LicenseTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LicenseTypeDescriptorGetByIds() { }

        public LicenseTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LicenseTypeDescriptorPost : Resources.LicenseTypeDescriptor.EdFi.LicenseTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LicenseTypeDescriptorPut : Resources.LicenseTypeDescriptor.EdFi.LicenseTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LicenseTypeDescriptorDelete : IHasIdentifier
    {
        public LicenseTypeDescriptorDelete() { }

        public LicenseTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LimitedEnglishProficiencyDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LimitedEnglishProficiencyDescriptorGetByExample
    {
        public int LimitedEnglishProficiencyDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LimitedEnglishProficiencyDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LimitedEnglishProficiencyDescriptorGetByIds() { }

        public LimitedEnglishProficiencyDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LimitedEnglishProficiencyDescriptorPost : Resources.LimitedEnglishProficiencyDescriptor.EdFi.LimitedEnglishProficiencyDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LimitedEnglishProficiencyDescriptorPut : Resources.LimitedEnglishProficiencyDescriptor.EdFi.LimitedEnglishProficiencyDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LimitedEnglishProficiencyDescriptorDelete : IHasIdentifier
    {
        public LimitedEnglishProficiencyDescriptorDelete() { }

        public LimitedEnglishProficiencyDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalAccounts.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalAccountGetByExample
    {
        public string AccountIdentifier { get; set; }
        public string AccountName { get; set; }
        public int ChartOfAccountEducationOrganizationId { get; set; }
        public string ChartOfAccountIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalAccountGetByIds : IHasIdentifiers<Guid>
    {
        public LocalAccountGetByIds() { }

        public LocalAccountGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalAccountPost : Resources.LocalAccount.EdFi.LocalAccount
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalAccountPut : Resources.LocalAccount.EdFi.LocalAccount
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalAccountDelete : IHasIdentifier
    {
        public LocalAccountDelete() { }

        public LocalAccountDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalActuals.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalActualGetByExample
    {
        public string AccountIdentifier { get; set; }
        public decimal Amount { get; set; }
        public DateTime AsOfDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FinancialCollectionDescriptor { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalActualGetByIds : IHasIdentifiers<Guid>
    {
        public LocalActualGetByIds() { }

        public LocalActualGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalActualPost : Resources.LocalActual.EdFi.LocalActual
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalActualPut : Resources.LocalActual.EdFi.LocalActual
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalActualDelete : IHasIdentifier
    {
        public LocalActualDelete() { }

        public LocalActualDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalBudgets.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalBudgetGetByExample
    {
        public string AccountIdentifier { get; set; }
        public decimal Amount { get; set; }
        public DateTime AsOfDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FinancialCollectionDescriptor { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalBudgetGetByIds : IHasIdentifiers<Guid>
    {
        public LocalBudgetGetByIds() { }

        public LocalBudgetGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalBudgetPost : Resources.LocalBudget.EdFi.LocalBudget
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalBudgetPut : Resources.LocalBudget.EdFi.LocalBudget
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalBudgetDelete : IHasIdentifier
    {
        public LocalBudgetDelete() { }

        public LocalBudgetDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalContractedStaffs.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffGetByExample
    {
        public string AccountIdentifier { get; set; }
        public decimal Amount { get; set; }
        public DateTime AsOfDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FinancialCollectionDescriptor { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffGetByIds : IHasIdentifiers<Guid>
    {
        public LocalContractedStaffGetByIds() { }

        public LocalContractedStaffGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffPost : Resources.LocalContractedStaff.EdFi.LocalContractedStaff
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffPut : Resources.LocalContractedStaff.EdFi.LocalContractedStaff
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalContractedStaffDelete : IHasIdentifier
    {
        public LocalContractedStaffDelete() { }

        public LocalContractedStaffDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocaleDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocaleDescriptorGetByExample
    {
        public int LocaleDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocaleDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LocaleDescriptorGetByIds() { }

        public LocaleDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocaleDescriptorPost : Resources.LocaleDescriptor.EdFi.LocaleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocaleDescriptorPut : Resources.LocaleDescriptor.EdFi.LocaleDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocaleDescriptorDelete : IHasIdentifier
    {
        public LocaleDescriptorDelete() { }

        public LocaleDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalEducationAgencies.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyGetByExample
    {
        public string CharterStatusDescriptor { get; set; }
        public int EducationServiceCenterId { get; set; }
        public string LocalEducationAgencyCategoryDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public int ParentLocalEducationAgencyId { get; set; }
        public int StateEducationAgencyId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyGetByIds : IHasIdentifiers<Guid>
    {
        public LocalEducationAgencyGetByIds() { }

        public LocalEducationAgencyGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyPost : Resources.LocalEducationAgency.EdFi.LocalEducationAgency
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyPut : Resources.LocalEducationAgency.EdFi.LocalEducationAgency
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyDelete : IHasIdentifier
    {
        public LocalEducationAgencyDelete() { }

        public LocalEducationAgencyDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalEducationAgencyCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCategoryDescriptorGetByExample
    {
        public int LocalEducationAgencyCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public LocalEducationAgencyCategoryDescriptorGetByIds() { }

        public LocalEducationAgencyCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCategoryDescriptorPost : Resources.LocalEducationAgencyCategoryDescriptor.EdFi.LocalEducationAgencyCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCategoryDescriptorPut : Resources.LocalEducationAgencyCategoryDescriptor.EdFi.LocalEducationAgencyCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEducationAgencyCategoryDescriptorDelete : IHasIdentifier
    {
        public LocalEducationAgencyCategoryDescriptorDelete() { }

        public LocalEducationAgencyCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalEncumbrances.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalEncumbranceGetByExample
    {
        public string AccountIdentifier { get; set; }
        public decimal Amount { get; set; }
        public DateTime AsOfDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FinancialCollectionDescriptor { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEncumbranceGetByIds : IHasIdentifiers<Guid>
    {
        public LocalEncumbranceGetByIds() { }

        public LocalEncumbranceGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalEncumbrancePost : Resources.LocalEncumbrance.EdFi.LocalEncumbrance
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEncumbrancePut : Resources.LocalEncumbrance.EdFi.LocalEncumbrance
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalEncumbranceDelete : IHasIdentifier
    {
        public LocalEncumbranceDelete() { }

        public LocalEncumbranceDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.LocalPayrolls.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocalPayrollGetByExample
    {
        public string AccountIdentifier { get; set; }
        public decimal Amount { get; set; }
        public DateTime AsOfDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string FinancialCollectionDescriptor { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalPayrollGetByIds : IHasIdentifiers<Guid>
    {
        public LocalPayrollGetByIds() { }

        public LocalPayrollGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocalPayrollPost : Resources.LocalPayroll.EdFi.LocalPayroll
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalPayrollPut : Resources.LocalPayroll.EdFi.LocalPayroll
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocalPayrollDelete : IHasIdentifier
    {
        public LocalPayrollDelete() { }

        public LocalPayrollDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Locations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class LocationGetByExample
    {
        public string ClassroomIdentificationCode { get; set; }
        public Guid Id { get; set; }
        public int MaximumNumberOfSeats { get; set; }
        public int OptimalNumberOfSeats { get; set; }
        public int SchoolId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocationGetByIds : IHasIdentifiers<Guid>
    {
        public LocationGetByIds() { }

        public LocationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class LocationPost : Resources.Location.EdFi.Location
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocationPut : Resources.Location.EdFi.Location
    {
    }

    [ExcludeFromCodeCoverage]
    public class LocationDelete : IHasIdentifier
    {
        public LocationDelete() { }

        public LocationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.MagnetSpecialProgramEmphasisSchoolDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class MagnetSpecialProgramEmphasisSchoolDescriptorGetByExample
    {
        public int MagnetSpecialProgramEmphasisSchoolDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MagnetSpecialProgramEmphasisSchoolDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public MagnetSpecialProgramEmphasisSchoolDescriptorGetByIds() { }

        public MagnetSpecialProgramEmphasisSchoolDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MagnetSpecialProgramEmphasisSchoolDescriptorPost : Resources.MagnetSpecialProgramEmphasisSchoolDescriptor.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MagnetSpecialProgramEmphasisSchoolDescriptorPut : Resources.MagnetSpecialProgramEmphasisSchoolDescriptor.EdFi.MagnetSpecialProgramEmphasisSchoolDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MagnetSpecialProgramEmphasisSchoolDescriptorDelete : IHasIdentifier
    {
        public MagnetSpecialProgramEmphasisSchoolDescriptorDelete() { }

        public MagnetSpecialProgramEmphasisSchoolDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.MediumOfInstructionDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class MediumOfInstructionDescriptorGetByExample
    {
        public int MediumOfInstructionDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MediumOfInstructionDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public MediumOfInstructionDescriptorGetByIds() { }

        public MediumOfInstructionDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MediumOfInstructionDescriptorPost : Resources.MediumOfInstructionDescriptor.EdFi.MediumOfInstructionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MediumOfInstructionDescriptorPut : Resources.MediumOfInstructionDescriptor.EdFi.MediumOfInstructionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MediumOfInstructionDescriptorDelete : IHasIdentifier
    {
        public MediumOfInstructionDescriptorDelete() { }

        public MediumOfInstructionDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.MethodCreditEarnedDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class MethodCreditEarnedDescriptorGetByExample
    {
        public int MethodCreditEarnedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MethodCreditEarnedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public MethodCreditEarnedDescriptorGetByIds() { }

        public MethodCreditEarnedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MethodCreditEarnedDescriptorPost : Resources.MethodCreditEarnedDescriptor.EdFi.MethodCreditEarnedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MethodCreditEarnedDescriptorPut : Resources.MethodCreditEarnedDescriptor.EdFi.MethodCreditEarnedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MethodCreditEarnedDescriptorDelete : IHasIdentifier
    {
        public MethodCreditEarnedDescriptorDelete() { }

        public MethodCreditEarnedDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.MigrantEducationProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class MigrantEducationProgramServiceDescriptorGetByExample
    {
        public int MigrantEducationProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MigrantEducationProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public MigrantEducationProgramServiceDescriptorGetByIds() { }

        public MigrantEducationProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MigrantEducationProgramServiceDescriptorPost : Resources.MigrantEducationProgramServiceDescriptor.EdFi.MigrantEducationProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MigrantEducationProgramServiceDescriptorPut : Resources.MigrantEducationProgramServiceDescriptor.EdFi.MigrantEducationProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MigrantEducationProgramServiceDescriptorDelete : IHasIdentifier
    {
        public MigrantEducationProgramServiceDescriptorDelete() { }

        public MigrantEducationProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ModelEntityDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ModelEntityDescriptorGetByExample
    {
        public int ModelEntityDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ModelEntityDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ModelEntityDescriptorGetByIds() { }

        public ModelEntityDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ModelEntityDescriptorPost : Resources.ModelEntityDescriptor.EdFi.ModelEntityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ModelEntityDescriptorPut : Resources.ModelEntityDescriptor.EdFi.ModelEntityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ModelEntityDescriptorDelete : IHasIdentifier
    {
        public ModelEntityDescriptorDelete() { }

        public ModelEntityDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.MonitoredDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class MonitoredDescriptorGetByExample
    {
        public int MonitoredDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MonitoredDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public MonitoredDescriptorGetByIds() { }

        public MonitoredDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MonitoredDescriptorPost : Resources.MonitoredDescriptor.EdFi.MonitoredDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MonitoredDescriptorPut : Resources.MonitoredDescriptor.EdFi.MonitoredDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MonitoredDescriptorDelete : IHasIdentifier
    {
        public MonitoredDescriptorDelete() { }

        public MonitoredDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.NeglectedOrDelinquentProgramDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramDescriptorGetByExample
    {
        public int NeglectedOrDelinquentProgramDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public NeglectedOrDelinquentProgramDescriptorGetByIds() { }

        public NeglectedOrDelinquentProgramDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramDescriptorPost : Resources.NeglectedOrDelinquentProgramDescriptor.EdFi.NeglectedOrDelinquentProgramDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramDescriptorPut : Resources.NeglectedOrDelinquentProgramDescriptor.EdFi.NeglectedOrDelinquentProgramDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramDescriptorDelete : IHasIdentifier
    {
        public NeglectedOrDelinquentProgramDescriptorDelete() { }

        public NeglectedOrDelinquentProgramDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.NeglectedOrDelinquentProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramServiceDescriptorGetByExample
    {
        public int NeglectedOrDelinquentProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public NeglectedOrDelinquentProgramServiceDescriptorGetByIds() { }

        public NeglectedOrDelinquentProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramServiceDescriptorPost : Resources.NeglectedOrDelinquentProgramServiceDescriptor.EdFi.NeglectedOrDelinquentProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramServiceDescriptorPut : Resources.NeglectedOrDelinquentProgramServiceDescriptor.EdFi.NeglectedOrDelinquentProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class NeglectedOrDelinquentProgramServiceDescriptorDelete : IHasIdentifier
    {
        public NeglectedOrDelinquentProgramServiceDescriptorDelete() { }

        public NeglectedOrDelinquentProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.NetworkPurposeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class NetworkPurposeDescriptorGetByExample
    {
        public int NetworkPurposeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NetworkPurposeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public NetworkPurposeDescriptorGetByIds() { }

        public NetworkPurposeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class NetworkPurposeDescriptorPost : Resources.NetworkPurposeDescriptor.EdFi.NetworkPurposeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class NetworkPurposeDescriptorPut : Resources.NetworkPurposeDescriptor.EdFi.NetworkPurposeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class NetworkPurposeDescriptorDelete : IHasIdentifier
    {
        public NetworkPurposeDescriptorDelete() { }

        public NetworkPurposeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ObjectDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ObjectDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public ObjectDimensionGetByIds() { }

        public ObjectDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectDimensionPost : Resources.ObjectDimension.EdFi.ObjectDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectDimensionPut : Resources.ObjectDimension.EdFi.ObjectDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectDimensionDelete : IHasIdentifier
    {
        public ObjectDimensionDelete() { }

        public ObjectDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ObjectiveAssessments.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ObjectiveAssessmentGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string IdentificationCode { get; set; }
        public decimal MaxRawScore { get; set; }
        public string Namespace { get; set; }
        public string Nomenclature { get; set; }
        public string ParentIdentificationCode { get; set; }
        public decimal PercentOfAssessment { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveAssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public ObjectiveAssessmentGetByIds() { }

        public ObjectiveAssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveAssessmentPost : Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveAssessmentPut : Resources.ObjectiveAssessment.EdFi.ObjectiveAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class ObjectiveAssessmentDelete : IHasIdentifier
    {
        public ObjectiveAssessmentDelete() { }

        public ObjectiveAssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.OldEthnicityDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class OldEthnicityDescriptorGetByExample
    {
        public int OldEthnicityDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OldEthnicityDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public OldEthnicityDescriptorGetByIds() { }

        public OldEthnicityDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OldEthnicityDescriptorPost : Resources.OldEthnicityDescriptor.EdFi.OldEthnicityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OldEthnicityDescriptorPut : Resources.OldEthnicityDescriptor.EdFi.OldEthnicityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OldEthnicityDescriptorDelete : IHasIdentifier
    {
        public OldEthnicityDescriptorDelete() { }

        public OldEthnicityDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.OpenStaffPositions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionGetByExample
    {
        public DateTime DatePosted { get; set; }
        public DateTime DatePostingRemoved { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EmploymentStatusDescriptor { get; set; }
        public Guid Id { get; set; }
        public string PositionTitle { get; set; }
        public string PostingResultDescriptor { get; set; }
        public string ProgramAssignmentDescriptor { get; set; }
        public string RequisitionNumber { get; set; }
        public string StaffClassificationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionGetByIds : IHasIdentifiers<Guid>
    {
        public OpenStaffPositionGetByIds() { }

        public OpenStaffPositionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionPost : Resources.OpenStaffPosition.EdFi.OpenStaffPosition
    {
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionPut : Resources.OpenStaffPosition.EdFi.OpenStaffPosition
    {
    }

    [ExcludeFromCodeCoverage]
    public class OpenStaffPositionDelete : IHasIdentifier
    {
        public OpenStaffPositionDelete() { }

        public OpenStaffPositionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.OperationalStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class OperationalStatusDescriptorGetByExample
    {
        public int OperationalStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OperationalStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public OperationalStatusDescriptorGetByIds() { }

        public OperationalStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OperationalStatusDescriptorPost : Resources.OperationalStatusDescriptor.EdFi.OperationalStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OperationalStatusDescriptorPut : Resources.OperationalStatusDescriptor.EdFi.OperationalStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OperationalStatusDescriptorDelete : IHasIdentifier
    {
        public OperationalStatusDescriptorDelete() { }

        public OperationalStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.OperationalUnitDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class OperationalUnitDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OperationalUnitDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public OperationalUnitDimensionGetByIds() { }

        public OperationalUnitDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OperationalUnitDimensionPost : Resources.OperationalUnitDimension.EdFi.OperationalUnitDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class OperationalUnitDimensionPut : Resources.OperationalUnitDimension.EdFi.OperationalUnitDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class OperationalUnitDimensionDelete : IHasIdentifier
    {
        public OperationalUnitDimensionDelete() { }

        public OperationalUnitDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.OrganizationDepartments.EdFi
{

    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentGetByExample
    {
        public string AcademicSubjectDescriptor { get; set; }
        public int OrganizationDepartmentId { get; set; }
        public int ParentEducationOrganizationId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentGetByIds : IHasIdentifiers<Guid>
    {
        public OrganizationDepartmentGetByIds() { }

        public OrganizationDepartmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentPost : Resources.OrganizationDepartment.EdFi.OrganizationDepartment
    {
    }

    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentPut : Resources.OrganizationDepartment.EdFi.OrganizationDepartment
    {
    }

    [ExcludeFromCodeCoverage]
    public class OrganizationDepartmentDelete : IHasIdentifier
    {
        public OrganizationDepartmentDelete() { }

        public OrganizationDepartmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.OtherNameTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class OtherNameTypeDescriptorGetByExample
    {
        public int OtherNameTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OtherNameTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public OtherNameTypeDescriptorGetByIds() { }

        public OtherNameTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class OtherNameTypeDescriptorPost : Resources.OtherNameTypeDescriptor.EdFi.OtherNameTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OtherNameTypeDescriptorPut : Resources.OtherNameTypeDescriptor.EdFi.OtherNameTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class OtherNameTypeDescriptorDelete : IHasIdentifier
    {
        public OtherNameTypeDescriptorDelete() { }

        public OtherNameTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Parents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ParentGetByExample
    {
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string ParentUniqueId { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParentGetByIds : IHasIdentifiers<Guid>
    {
        public ParentGetByIds() { }

        public ParentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParentPost : Resources.Parent.EdFi.Parent
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParentPut : Resources.Parent.EdFi.Parent
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParentDelete : IHasIdentifier
    {
        public ParentDelete() { }

        public ParentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ParticipationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ParticipationDescriptorGetByExample
    {
        public int ParticipationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ParticipationDescriptorGetByIds() { }

        public ParticipationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationDescriptorPost : Resources.ParticipationDescriptor.EdFi.ParticipationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationDescriptorPut : Resources.ParticipationDescriptor.EdFi.ParticipationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationDescriptorDelete : IHasIdentifier
    {
        public ParticipationDescriptorDelete() { }

        public ParticipationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ParticipationStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ParticipationStatusDescriptorGetByExample
    {
        public int ParticipationStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ParticipationStatusDescriptorGetByIds() { }

        public ParticipationStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationStatusDescriptorPost : Resources.ParticipationStatusDescriptor.EdFi.ParticipationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationStatusDescriptorPut : Resources.ParticipationStatusDescriptor.EdFi.ParticipationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ParticipationStatusDescriptorDelete : IHasIdentifier
    {
        public ParticipationStatusDescriptorDelete() { }

        public ParticipationStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PerformanceBaseConversionDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PerformanceBaseConversionDescriptorGetByExample
    {
        public int PerformanceBaseConversionDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceBaseConversionDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceBaseConversionDescriptorGetByIds() { }

        public PerformanceBaseConversionDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceBaseConversionDescriptorPost : Resources.PerformanceBaseConversionDescriptor.EdFi.PerformanceBaseConversionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceBaseConversionDescriptorPut : Resources.PerformanceBaseConversionDescriptor.EdFi.PerformanceBaseConversionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceBaseConversionDescriptorDelete : IHasIdentifier
    {
        public PerformanceBaseConversionDescriptorDelete() { }

        public PerformanceBaseConversionDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PerformanceLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PerformanceLevelDescriptorGetByExample
    {
        public int PerformanceLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PerformanceLevelDescriptorGetByIds() { }

        public PerformanceLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceLevelDescriptorPost : Resources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceLevelDescriptorPut : Resources.PerformanceLevelDescriptor.EdFi.PerformanceLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PerformanceLevelDescriptorDelete : IHasIdentifier
    {
        public PerformanceLevelDescriptorDelete() { }

        public PerformanceLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.People.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PersonGetByExample
    {
        public Guid Id { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PersonGetByIds : IHasIdentifiers<Guid>
    {
        public PersonGetByIds() { }

        public PersonGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PersonPost : Resources.Person.EdFi.Person
    {
    }

    [ExcludeFromCodeCoverage]
    public class PersonPut : Resources.Person.EdFi.Person
    {
    }

    [ExcludeFromCodeCoverage]
    public class PersonDelete : IHasIdentifier
    {
        public PersonDelete() { }

        public PersonDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PersonalInformationVerificationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PersonalInformationVerificationDescriptorGetByExample
    {
        public int PersonalInformationVerificationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PersonalInformationVerificationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PersonalInformationVerificationDescriptorGetByIds() { }

        public PersonalInformationVerificationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PersonalInformationVerificationDescriptorPost : Resources.PersonalInformationVerificationDescriptor.EdFi.PersonalInformationVerificationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PersonalInformationVerificationDescriptorPut : Resources.PersonalInformationVerificationDescriptor.EdFi.PersonalInformationVerificationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PersonalInformationVerificationDescriptorDelete : IHasIdentifier
    {
        public PersonalInformationVerificationDescriptorDelete() { }

        public PersonalInformationVerificationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PlatformTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PlatformTypeDescriptorGetByExample
    {
        public int PlatformTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PlatformTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PlatformTypeDescriptorGetByIds() { }

        public PlatformTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PlatformTypeDescriptorPost : Resources.PlatformTypeDescriptor.EdFi.PlatformTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PlatformTypeDescriptorPut : Resources.PlatformTypeDescriptor.EdFi.PlatformTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PlatformTypeDescriptorDelete : IHasIdentifier
    {
        public PlatformTypeDescriptorDelete() { }

        public PlatformTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PopulationServedDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PopulationServedDescriptorGetByExample
    {
        public int PopulationServedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PopulationServedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PopulationServedDescriptorGetByIds() { }

        public PopulationServedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PopulationServedDescriptorPost : Resources.PopulationServedDescriptor.EdFi.PopulationServedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PopulationServedDescriptorPut : Resources.PopulationServedDescriptor.EdFi.PopulationServedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PopulationServedDescriptorDelete : IHasIdentifier
    {
        public PopulationServedDescriptorDelete() { }

        public PopulationServedDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PostingResultDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PostingResultDescriptorGetByExample
    {
        public int PostingResultDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostingResultDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PostingResultDescriptorGetByIds() { }

        public PostingResultDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostingResultDescriptorPost : Resources.PostingResultDescriptor.EdFi.PostingResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostingResultDescriptorPut : Resources.PostingResultDescriptor.EdFi.PostingResultDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostingResultDescriptorDelete : IHasIdentifier
    {
        public PostingResultDescriptorDelete() { }

        public PostingResultDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PostSecondaryEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventGetByExample
    {
        public DateTime EventDate { get; set; }
        public Guid Id { get; set; }
        public string PostSecondaryEventCategoryDescriptor { get; set; }
        public int PostSecondaryInstitutionId { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventGetByIds : IHasIdentifiers<Guid>
    {
        public PostSecondaryEventGetByIds() { }

        public PostSecondaryEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventPost : Resources.PostSecondaryEvent.EdFi.PostSecondaryEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventPut : Resources.PostSecondaryEvent.EdFi.PostSecondaryEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventDelete : IHasIdentifier
    {
        public PostSecondaryEventDelete() { }

        public PostSecondaryEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PostSecondaryEventCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventCategoryDescriptorGetByExample
    {
        public int PostSecondaryEventCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PostSecondaryEventCategoryDescriptorGetByIds() { }

        public PostSecondaryEventCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventCategoryDescriptorPost : Resources.PostSecondaryEventCategoryDescriptor.EdFi.PostSecondaryEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventCategoryDescriptorPut : Resources.PostSecondaryEventCategoryDescriptor.EdFi.PostSecondaryEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryEventCategoryDescriptorDelete : IHasIdentifier
    {
        public PostSecondaryEventCategoryDescriptorDelete() { }

        public PostSecondaryEventCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PostSecondaryInstitutions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public int PostSecondaryInstitutionId { get; set; }
        public string PostSecondaryInstitutionLevelDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionGetByIds : IHasIdentifiers<Guid>
    {
        public PostSecondaryInstitutionGetByIds() { }

        public PostSecondaryInstitutionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionPost : Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionPut : Resources.PostSecondaryInstitution.EdFi.PostSecondaryInstitution
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionDelete : IHasIdentifier
    {
        public PostSecondaryInstitutionDelete() { }

        public PostSecondaryInstitutionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PostSecondaryInstitutionLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionLevelDescriptorGetByExample
    {
        public int PostSecondaryInstitutionLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PostSecondaryInstitutionLevelDescriptorGetByIds() { }

        public PostSecondaryInstitutionLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionLevelDescriptorPost : Resources.PostSecondaryInstitutionLevelDescriptor.EdFi.PostSecondaryInstitutionLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionLevelDescriptorPut : Resources.PostSecondaryInstitutionLevelDescriptor.EdFi.PostSecondaryInstitutionLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PostSecondaryInstitutionLevelDescriptorDelete : IHasIdentifier
    {
        public PostSecondaryInstitutionLevelDescriptorDelete() { }

        public PostSecondaryInstitutionLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PrimaryLearningDeviceAccessDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAccessDescriptorGetByExample
    {
        public int PrimaryLearningDeviceAccessDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAccessDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PrimaryLearningDeviceAccessDescriptorGetByIds() { }

        public PrimaryLearningDeviceAccessDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAccessDescriptorPost : Resources.PrimaryLearningDeviceAccessDescriptor.EdFi.PrimaryLearningDeviceAccessDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAccessDescriptorPut : Resources.PrimaryLearningDeviceAccessDescriptor.EdFi.PrimaryLearningDeviceAccessDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAccessDescriptorDelete : IHasIdentifier
    {
        public PrimaryLearningDeviceAccessDescriptorDelete() { }

        public PrimaryLearningDeviceAccessDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PrimaryLearningDeviceAwayFromSchoolDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAwayFromSchoolDescriptorGetByExample
    {
        public int PrimaryLearningDeviceAwayFromSchoolDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAwayFromSchoolDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PrimaryLearningDeviceAwayFromSchoolDescriptorGetByIds() { }

        public PrimaryLearningDeviceAwayFromSchoolDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAwayFromSchoolDescriptorPost : Resources.PrimaryLearningDeviceAwayFromSchoolDescriptor.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAwayFromSchoolDescriptorPut : Resources.PrimaryLearningDeviceAwayFromSchoolDescriptor.EdFi.PrimaryLearningDeviceAwayFromSchoolDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceAwayFromSchoolDescriptorDelete : IHasIdentifier
    {
        public PrimaryLearningDeviceAwayFromSchoolDescriptorDelete() { }

        public PrimaryLearningDeviceAwayFromSchoolDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PrimaryLearningDeviceProviderDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceProviderDescriptorGetByExample
    {
        public int PrimaryLearningDeviceProviderDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceProviderDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PrimaryLearningDeviceProviderDescriptorGetByIds() { }

        public PrimaryLearningDeviceProviderDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceProviderDescriptorPost : Resources.PrimaryLearningDeviceProviderDescriptor.EdFi.PrimaryLearningDeviceProviderDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceProviderDescriptorPut : Resources.PrimaryLearningDeviceProviderDescriptor.EdFi.PrimaryLearningDeviceProviderDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PrimaryLearningDeviceProviderDescriptorDelete : IHasIdentifier
    {
        public PrimaryLearningDeviceProviderDescriptorDelete() { }

        public PrimaryLearningDeviceProviderDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProficiencyDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProficiencyDescriptorGetByExample
    {
        public int ProficiencyDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProficiencyDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProficiencyDescriptorGetByIds() { }

        public ProficiencyDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProficiencyDescriptorPost : Resources.ProficiencyDescriptor.EdFi.ProficiencyDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProficiencyDescriptorPut : Resources.ProficiencyDescriptor.EdFi.ProficiencyDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProficiencyDescriptorDelete : IHasIdentifier
    {
        public ProficiencyDescriptorDelete() { }

        public ProficiencyDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Programs.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgramGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramGetByIds() { }

        public ProgramGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramPost : Resources.Program.EdFi.Program
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramPut : Resources.Program.EdFi.Program
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramDelete : IHasIdentifier
    {
        public ProgramDelete() { }

        public ProgramDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgramAssignmentDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgramAssignmentDescriptorGetByExample
    {
        public int ProgramAssignmentDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramAssignmentDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramAssignmentDescriptorGetByIds() { }

        public ProgramAssignmentDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramAssignmentDescriptorPost : Resources.ProgramAssignmentDescriptor.EdFi.ProgramAssignmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramAssignmentDescriptorPut : Resources.ProgramAssignmentDescriptor.EdFi.ProgramAssignmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramAssignmentDescriptorDelete : IHasIdentifier
    {
        public ProgramAssignmentDescriptorDelete() { }

        public ProgramAssignmentDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgramCharacteristicDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgramCharacteristicDescriptorGetByExample
    {
        public int ProgramCharacteristicDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramCharacteristicDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramCharacteristicDescriptorGetByIds() { }

        public ProgramCharacteristicDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramCharacteristicDescriptorPost : Resources.ProgramCharacteristicDescriptor.EdFi.ProgramCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramCharacteristicDescriptorPut : Resources.ProgramCharacteristicDescriptor.EdFi.ProgramCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramCharacteristicDescriptorDelete : IHasIdentifier
    {
        public ProgramCharacteristicDescriptorDelete() { }

        public ProgramCharacteristicDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgramDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgramDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramDimensionGetByIds() { }

        public ProgramDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramDimensionPost : Resources.ProgramDimension.EdFi.ProgramDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramDimensionPut : Resources.ProgramDimension.EdFi.ProgramDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramDimensionDelete : IHasIdentifier
    {
        public ProgramDimensionDelete() { }

        public ProgramDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgramSponsorDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgramSponsorDescriptorGetByExample
    {
        public int ProgramSponsorDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramSponsorDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramSponsorDescriptorGetByIds() { }

        public ProgramSponsorDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramSponsorDescriptorPost : Resources.ProgramSponsorDescriptor.EdFi.ProgramSponsorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramSponsorDescriptorPut : Resources.ProgramSponsorDescriptor.EdFi.ProgramSponsorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramSponsorDescriptorDelete : IHasIdentifier
    {
        public ProgramSponsorDescriptorDelete() { }

        public ProgramSponsorDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgramTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgramTypeDescriptorGetByExample
    {
        public int ProgramTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgramTypeDescriptorGetByIds() { }

        public ProgramTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgramTypeDescriptorPost : Resources.ProgramTypeDescriptor.EdFi.ProgramTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramTypeDescriptorPut : Resources.ProgramTypeDescriptor.EdFi.ProgramTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgramTypeDescriptorDelete : IHasIdentifier
    {
        public ProgramTypeDescriptorDelete() { }

        public ProgramTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgressDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgressDescriptorGetByExample
    {
        public int ProgressDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgressDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgressDescriptorGetByIds() { }

        public ProgressDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgressDescriptorPost : Resources.ProgressDescriptor.EdFi.ProgressDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgressDescriptorPut : Resources.ProgressDescriptor.EdFi.ProgressDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgressDescriptorDelete : IHasIdentifier
    {
        public ProgressDescriptorDelete() { }

        public ProgressDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProgressLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProgressLevelDescriptorGetByExample
    {
        public int ProgressLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgressLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProgressLevelDescriptorGetByIds() { }

        public ProgressLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProgressLevelDescriptorPost : Resources.ProgressLevelDescriptor.EdFi.ProgressLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgressLevelDescriptorPut : Resources.ProgressLevelDescriptor.EdFi.ProgressLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProgressLevelDescriptorDelete : IHasIdentifier
    {
        public ProgressLevelDescriptorDelete() { }

        public ProgressLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProjectDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProjectDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProjectDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public ProjectDimensionGetByIds() { }

        public ProjectDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProjectDimensionPost : Resources.ProjectDimension.EdFi.ProjectDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProjectDimensionPut : Resources.ProjectDimension.EdFi.ProjectDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProjectDimensionDelete : IHasIdentifier
    {
        public ProjectDimensionDelete() { }

        public ProjectDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProviderCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProviderCategoryDescriptorGetByExample
    {
        public int ProviderCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProviderCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProviderCategoryDescriptorGetByIds() { }

        public ProviderCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProviderCategoryDescriptorPost : Resources.ProviderCategoryDescriptor.EdFi.ProviderCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProviderCategoryDescriptorPut : Resources.ProviderCategoryDescriptor.EdFi.ProviderCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProviderCategoryDescriptorDelete : IHasIdentifier
    {
        public ProviderCategoryDescriptorDelete() { }

        public ProviderCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProviderProfitabilityDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProviderProfitabilityDescriptorGetByExample
    {
        public int ProviderProfitabilityDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProviderProfitabilityDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProviderProfitabilityDescriptorGetByIds() { }

        public ProviderProfitabilityDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProviderProfitabilityDescriptorPost : Resources.ProviderProfitabilityDescriptor.EdFi.ProviderProfitabilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProviderProfitabilityDescriptorPut : Resources.ProviderProfitabilityDescriptor.EdFi.ProviderProfitabilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProviderProfitabilityDescriptorDelete : IHasIdentifier
    {
        public ProviderProfitabilityDescriptorDelete() { }

        public ProviderProfitabilityDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ProviderStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ProviderStatusDescriptorGetByExample
    {
        public int ProviderStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProviderStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ProviderStatusDescriptorGetByIds() { }

        public ProviderStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProviderStatusDescriptorPost : Resources.ProviderStatusDescriptor.EdFi.ProviderStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProviderStatusDescriptorPut : Resources.ProviderStatusDescriptor.EdFi.ProviderStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ProviderStatusDescriptorDelete : IHasIdentifier
    {
        public ProviderStatusDescriptorDelete() { }

        public ProviderStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.PublicationStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class PublicationStatusDescriptorGetByExample
    {
        public int PublicationStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PublicationStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public PublicationStatusDescriptorGetByIds() { }

        public PublicationStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class PublicationStatusDescriptorPost : Resources.PublicationStatusDescriptor.EdFi.PublicationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PublicationStatusDescriptorPut : Resources.PublicationStatusDescriptor.EdFi.PublicationStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class PublicationStatusDescriptorDelete : IHasIdentifier
    {
        public PublicationStatusDescriptorDelete() { }

        public PublicationStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.QuestionFormDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class QuestionFormDescriptorGetByExample
    {
        public int QuestionFormDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuestionFormDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public QuestionFormDescriptorGetByIds() { }

        public QuestionFormDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class QuestionFormDescriptorPost : Resources.QuestionFormDescriptor.EdFi.QuestionFormDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuestionFormDescriptorPut : Resources.QuestionFormDescriptor.EdFi.QuestionFormDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class QuestionFormDescriptorDelete : IHasIdentifier
    {
        public QuestionFormDescriptorDelete() { }

        public QuestionFormDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RaceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RaceDescriptorGetByExample
    {
        public int RaceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RaceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RaceDescriptorGetByIds() { }

        public RaceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RaceDescriptorPost : Resources.RaceDescriptor.EdFi.RaceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RaceDescriptorPut : Resources.RaceDescriptor.EdFi.RaceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RaceDescriptorDelete : IHasIdentifier
    {
        public RaceDescriptorDelete() { }

        public RaceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ReasonExitedDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ReasonExitedDescriptorGetByExample
    {
        public int ReasonExitedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReasonExitedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ReasonExitedDescriptorGetByIds() { }

        public ReasonExitedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReasonExitedDescriptorPost : Resources.ReasonExitedDescriptor.EdFi.ReasonExitedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReasonExitedDescriptorPut : Resources.ReasonExitedDescriptor.EdFi.ReasonExitedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReasonExitedDescriptorDelete : IHasIdentifier
    {
        public ReasonExitedDescriptorDelete() { }

        public ReasonExitedDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ReasonNotTestedDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ReasonNotTestedDescriptorGetByExample
    {
        public int ReasonNotTestedDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReasonNotTestedDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ReasonNotTestedDescriptorGetByIds() { }

        public ReasonNotTestedDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReasonNotTestedDescriptorPost : Resources.ReasonNotTestedDescriptor.EdFi.ReasonNotTestedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReasonNotTestedDescriptorPut : Resources.ReasonNotTestedDescriptor.EdFi.ReasonNotTestedDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReasonNotTestedDescriptorDelete : IHasIdentifier
    {
        public ReasonNotTestedDescriptorDelete() { }

        public ReasonNotTestedDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RecognitionTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RecognitionTypeDescriptorGetByExample
    {
        public int RecognitionTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecognitionTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RecognitionTypeDescriptorGetByIds() { }

        public RecognitionTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecognitionTypeDescriptorPost : Resources.RecognitionTypeDescriptor.EdFi.RecognitionTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RecognitionTypeDescriptorPut : Resources.RecognitionTypeDescriptor.EdFi.RecognitionTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RecognitionTypeDescriptorDelete : IHasIdentifier
    {
        public RecognitionTypeDescriptorDelete() { }

        public RecognitionTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RelationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RelationDescriptorGetByExample
    {
        public int RelationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RelationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RelationDescriptorGetByIds() { }

        public RelationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RelationDescriptorPost : Resources.RelationDescriptor.EdFi.RelationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RelationDescriptorPut : Resources.RelationDescriptor.EdFi.RelationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RelationDescriptorDelete : IHasIdentifier
    {
        public RelationDescriptorDelete() { }

        public RelationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RepeatIdentifierDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RepeatIdentifierDescriptorGetByExample
    {
        public int RepeatIdentifierDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RepeatIdentifierDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RepeatIdentifierDescriptorGetByIds() { }

        public RepeatIdentifierDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RepeatIdentifierDescriptorPost : Resources.RepeatIdentifierDescriptor.EdFi.RepeatIdentifierDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RepeatIdentifierDescriptorPut : Resources.RepeatIdentifierDescriptor.EdFi.RepeatIdentifierDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RepeatIdentifierDescriptorDelete : IHasIdentifier
    {
        public RepeatIdentifierDescriptorDelete() { }

        public RepeatIdentifierDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ReportCards.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ReportCardGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public decimal GPACumulative { get; set; }
        public decimal GPAGivenGradingPeriod { get; set; }
        public string GradingPeriodDescriptor { get; set; }
        public int GradingPeriodSchoolId { get; set; }
        public short GradingPeriodSchoolYear { get; set; }
        public int GradingPeriodSequence { get; set; }
        public Guid Id { get; set; }
        public decimal NumberOfDaysAbsent { get; set; }
        public decimal NumberOfDaysInAttendance { get; set; }
        public int NumberOfDaysTardy { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReportCardGetByIds : IHasIdentifiers<Guid>
    {
        public ReportCardGetByIds() { }

        public ReportCardGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReportCardPost : Resources.ReportCard.EdFi.ReportCard
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReportCardPut : Resources.ReportCard.EdFi.ReportCard
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReportCardDelete : IHasIdentifier
    {
        public ReportCardDelete() { }

        public ReportCardDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ReporterDescriptionDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ReporterDescriptionDescriptorGetByExample
    {
        public int ReporterDescriptionDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReporterDescriptionDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ReporterDescriptionDescriptorGetByIds() { }

        public ReporterDescriptionDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReporterDescriptionDescriptorPost : Resources.ReporterDescriptionDescriptor.EdFi.ReporterDescriptionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReporterDescriptionDescriptorPut : Resources.ReporterDescriptionDescriptor.EdFi.ReporterDescriptionDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReporterDescriptionDescriptorDelete : IHasIdentifier
    {
        public ReporterDescriptionDescriptorDelete() { }

        public ReporterDescriptionDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ReportingTagDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ReportingTagDescriptorGetByExample
    {
        public int ReportingTagDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReportingTagDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ReportingTagDescriptorGetByIds() { }

        public ReportingTagDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ReportingTagDescriptorPost : Resources.ReportingTagDescriptor.EdFi.ReportingTagDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReportingTagDescriptorPut : Resources.ReportingTagDescriptor.EdFi.ReportingTagDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ReportingTagDescriptorDelete : IHasIdentifier
    {
        public ReportingTagDescriptorDelete() { }

        public ReportingTagDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ResidencyStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ResidencyStatusDescriptorGetByExample
    {
        public int ResidencyStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResidencyStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ResidencyStatusDescriptorGetByIds() { }

        public ResidencyStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResidencyStatusDescriptorPost : Resources.ResidencyStatusDescriptor.EdFi.ResidencyStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResidencyStatusDescriptorPut : Resources.ResidencyStatusDescriptor.EdFi.ResidencyStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResidencyStatusDescriptorDelete : IHasIdentifier
    {
        public ResidencyStatusDescriptorDelete() { }

        public ResidencyStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ResponseIndicatorDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ResponseIndicatorDescriptorGetByExample
    {
        public int ResponseIndicatorDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResponseIndicatorDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ResponseIndicatorDescriptorGetByIds() { }

        public ResponseIndicatorDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResponseIndicatorDescriptorPost : Resources.ResponseIndicatorDescriptor.EdFi.ResponseIndicatorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResponseIndicatorDescriptorPut : Resources.ResponseIndicatorDescriptor.EdFi.ResponseIndicatorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResponseIndicatorDescriptorDelete : IHasIdentifier
    {
        public ResponseIndicatorDescriptorDelete() { }

        public ResponseIndicatorDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ResponsibilityDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ResponsibilityDescriptorGetByExample
    {
        public int ResponsibilityDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResponsibilityDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ResponsibilityDescriptorGetByIds() { }

        public ResponsibilityDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResponsibilityDescriptorPost : Resources.ResponsibilityDescriptor.EdFi.ResponsibilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResponsibilityDescriptorPut : Resources.ResponsibilityDescriptor.EdFi.ResponsibilityDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResponsibilityDescriptorDelete : IHasIdentifier
    {
        public ResponsibilityDescriptorDelete() { }

        public ResponsibilityDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RestraintEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RestraintEventGetByExample
    {
        public string EducationalEnvironmentDescriptor { get; set; }
        public DateTime EventDate { get; set; }
        public Guid Id { get; set; }
        public string RestraintEventIdentifier { get; set; }
        public int SchoolId { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventGetByIds : IHasIdentifiers<Guid>
    {
        public RestraintEventGetByIds() { }

        public RestraintEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventPost : Resources.RestraintEvent.EdFi.RestraintEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventPut : Resources.RestraintEvent.EdFi.RestraintEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventDelete : IHasIdentifier
    {
        public RestraintEventDelete() { }

        public RestraintEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RestraintEventReasonDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RestraintEventReasonDescriptorGetByExample
    {
        public int RestraintEventReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RestraintEventReasonDescriptorGetByIds() { }

        public RestraintEventReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventReasonDescriptorPost : Resources.RestraintEventReasonDescriptor.EdFi.RestraintEventReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventReasonDescriptorPut : Resources.RestraintEventReasonDescriptor.EdFi.RestraintEventReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RestraintEventReasonDescriptorDelete : IHasIdentifier
    {
        public RestraintEventReasonDescriptorDelete() { }

        public RestraintEventReasonDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ResultDatatypeTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ResultDatatypeTypeDescriptorGetByExample
    {
        public int ResultDatatypeTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResultDatatypeTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ResultDatatypeTypeDescriptorGetByIds() { }

        public ResultDatatypeTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ResultDatatypeTypeDescriptorPost : Resources.ResultDatatypeTypeDescriptor.EdFi.ResultDatatypeTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResultDatatypeTypeDescriptorPut : Resources.ResultDatatypeTypeDescriptor.EdFi.ResultDatatypeTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ResultDatatypeTypeDescriptorDelete : IHasIdentifier
    {
        public ResultDatatypeTypeDescriptorDelete() { }

        public ResultDatatypeTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.RetestIndicatorDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class RetestIndicatorDescriptorGetByExample
    {
        public int RetestIndicatorDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RetestIndicatorDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public RetestIndicatorDescriptorGetByIds() { }

        public RetestIndicatorDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RetestIndicatorDescriptorPost : Resources.RetestIndicatorDescriptor.EdFi.RetestIndicatorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RetestIndicatorDescriptorPut : Resources.RetestIndicatorDescriptor.EdFi.RetestIndicatorDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class RetestIndicatorDescriptorDelete : IHasIdentifier
    {
        public RetestIndicatorDescriptorDelete() { }

        public RetestIndicatorDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Schools.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SchoolGetByExample
    {
        public string AdministrativeFundingControlDescriptor { get; set; }
        public string CharterApprovalAgencyTypeDescriptor { get; set; }
        public short CharterApprovalSchoolYear { get; set; }
        public string CharterStatusDescriptor { get; set; }
        public string InternetAccessDescriptor { get; set; }
        public int LocalEducationAgencyId { get; set; }
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }
        public int SchoolId { get; set; }
        public string SchoolTypeDescriptor { get; set; }
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolGetByIds() { }

        public SchoolGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolPost : Resources.School.EdFi.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolPut : Resources.School.EdFi.School
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolDelete : IHasIdentifier
    {
        public SchoolDelete() { }

        public SchoolDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SchoolCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryDescriptorGetByExample
    {
        public int SchoolCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolCategoryDescriptorGetByIds() { }

        public SchoolCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryDescriptorPost : Resources.SchoolCategoryDescriptor.EdFi.SchoolCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryDescriptorPut : Resources.SchoolCategoryDescriptor.EdFi.SchoolCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryDescriptorDelete : IHasIdentifier
    {
        public SchoolCategoryDescriptorDelete() { }

        public SchoolCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SchoolChoiceImplementStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SchoolChoiceImplementStatusDescriptorGetByExample
    {
        public int SchoolChoiceImplementStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolChoiceImplementStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolChoiceImplementStatusDescriptorGetByIds() { }

        public SchoolChoiceImplementStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolChoiceImplementStatusDescriptorPost : Resources.SchoolChoiceImplementStatusDescriptor.EdFi.SchoolChoiceImplementStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolChoiceImplementStatusDescriptorPut : Resources.SchoolChoiceImplementStatusDescriptor.EdFi.SchoolChoiceImplementStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolChoiceImplementStatusDescriptorDelete : IHasIdentifier
    {
        public SchoolChoiceImplementStatusDescriptorDelete() { }

        public SchoolChoiceImplementStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SchoolFoodServiceProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SchoolFoodServiceProgramServiceDescriptorGetByExample
    {
        public int SchoolFoodServiceProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolFoodServiceProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolFoodServiceProgramServiceDescriptorGetByIds() { }

        public SchoolFoodServiceProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolFoodServiceProgramServiceDescriptorPost : Resources.SchoolFoodServiceProgramServiceDescriptor.EdFi.SchoolFoodServiceProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolFoodServiceProgramServiceDescriptorPut : Resources.SchoolFoodServiceProgramServiceDescriptor.EdFi.SchoolFoodServiceProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolFoodServiceProgramServiceDescriptorDelete : IHasIdentifier
    {
        public SchoolFoodServiceProgramServiceDescriptorDelete() { }

        public SchoolFoodServiceProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SchoolTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SchoolTypeDescriptorGetByExample
    {
        public int SchoolTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolTypeDescriptorGetByIds() { }

        public SchoolTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolTypeDescriptorPost : Resources.SchoolTypeDescriptor.EdFi.SchoolTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolTypeDescriptorPut : Resources.SchoolTypeDescriptor.EdFi.SchoolTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolTypeDescriptorDelete : IHasIdentifier
    {
        public SchoolTypeDescriptorDelete() { }

        public SchoolTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SchoolYearTypes.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeGetByExample
    {
        public bool CurrentSchoolYear { get; set; }
        public Guid Id { get; set; }
        public short SchoolYear { get; set; }
        public string SchoolYearDescription { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeGetByIds : IHasIdentifiers<Guid>
    {
        public SchoolYearTypeGetByIds() { }

        public SchoolYearTypeGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypePost : Resources.SchoolYearType.EdFi.SchoolYearType
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypePut : Resources.SchoolYearType.EdFi.SchoolYearType
    {
    }

    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeDelete : IHasIdentifier
    {
        public SchoolYearTypeDelete() { }

        public SchoolYearTypeDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sections.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SectionGetByExample
    {
        public decimal AvailableCreditConversion { get; set; }
        public decimal AvailableCredits { get; set; }
        public string AvailableCreditTypeDescriptor { get; set; }
        public string EducationalEnvironmentDescriptor { get; set; }
        public Guid Id { get; set; }
        public string InstructionLanguageDescriptor { get; set; }
        public string LocalCourseCode { get; set; }
        public string LocationClassroomIdentificationCode { get; set; }
        public int LocationSchoolId { get; set; }
        public string MediumOfInstructionDescriptor { get; set; }
        public bool OfficialAttendancePeriod { get; set; }
        public string PopulationServedDescriptor { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SectionName { get; set; }
        public int SequenceOfCourse { get; set; }
        public string SessionName { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionGetByIds : IHasIdentifiers<Guid>
    {
        public SectionGetByIds() { }

        public SectionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionPost : Resources.Section.EdFi.Section
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionPut : Resources.Section.EdFi.Section
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionDelete : IHasIdentifier
    {
        public SectionDelete() { }

        public SectionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SectionAttendanceTakenEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventGetByExample
    {
        public string CalendarCode { get; set; }
        public DateTime Date { get; set; }
        public DateTime EventDate { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventGetByIds : IHasIdentifiers<Guid>
    {
        public SectionAttendanceTakenEventGetByIds() { }

        public SectionAttendanceTakenEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventPost : Resources.SectionAttendanceTakenEvent.EdFi.SectionAttendanceTakenEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventPut : Resources.SectionAttendanceTakenEvent.EdFi.SectionAttendanceTakenEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionAttendanceTakenEventDelete : IHasIdentifier
    {
        public SectionAttendanceTakenEventDelete() { }

        public SectionAttendanceTakenEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SectionCharacteristicDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SectionCharacteristicDescriptorGetByExample
    {
        public int SectionCharacteristicDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionCharacteristicDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SectionCharacteristicDescriptorGetByIds() { }

        public SectionCharacteristicDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SectionCharacteristicDescriptorPost : Resources.SectionCharacteristicDescriptor.EdFi.SectionCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionCharacteristicDescriptorPut : Resources.SectionCharacteristicDescriptor.EdFi.SectionCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SectionCharacteristicDescriptorDelete : IHasIdentifier
    {
        public SectionCharacteristicDescriptorDelete() { }

        public SectionCharacteristicDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SeparationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SeparationDescriptorGetByExample
    {
        public int SeparationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SeparationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SeparationDescriptorGetByIds() { }

        public SeparationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SeparationDescriptorPost : Resources.SeparationDescriptor.EdFi.SeparationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SeparationDescriptorPut : Resources.SeparationDescriptor.EdFi.SeparationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SeparationDescriptorDelete : IHasIdentifier
    {
        public SeparationDescriptorDelete() { }

        public SeparationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SeparationReasonDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SeparationReasonDescriptorGetByExample
    {
        public int SeparationReasonDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SeparationReasonDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SeparationReasonDescriptorGetByIds() { }

        public SeparationReasonDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SeparationReasonDescriptorPost : Resources.SeparationReasonDescriptor.EdFi.SeparationReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SeparationReasonDescriptorPut : Resources.SeparationReasonDescriptor.EdFi.SeparationReasonDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SeparationReasonDescriptorDelete : IHasIdentifier
    {
        public SeparationReasonDescriptorDelete() { }

        public SeparationReasonDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.ServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class ServiceDescriptorGetByExample
    {
        public int ServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ServiceDescriptorGetByIds() { }

        public ServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ServiceDescriptorPost : Resources.ServiceDescriptor.EdFi.ServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ServiceDescriptorPut : Resources.ServiceDescriptor.EdFi.ServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ServiceDescriptorDelete : IHasIdentifier
    {
        public ServiceDescriptorDelete() { }

        public ServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sessions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SessionGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SessionName { get; set; }
        public string TermDescriptor { get; set; }
        public int TotalInstructionalDays { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SessionGetByIds : IHasIdentifiers<Guid>
    {
        public SessionGetByIds() { }

        public SessionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SessionPost : Resources.Session.EdFi.Session
    {
    }

    [ExcludeFromCodeCoverage]
    public class SessionPut : Resources.Session.EdFi.Session
    {
    }

    [ExcludeFromCodeCoverage]
    public class SessionDelete : IHasIdentifier
    {
        public SessionDelete() { }

        public SessionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SexDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SexDescriptorGetByExample
    {
        public int SexDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SexDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SexDescriptorGetByIds() { }

        public SexDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SexDescriptorPost : Resources.SexDescriptor.EdFi.SexDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SexDescriptorPut : Resources.SexDescriptor.EdFi.SexDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SexDescriptorDelete : IHasIdentifier
    {
        public SexDescriptorDelete() { }

        public SexDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SourceDimensions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SourceDimensionGetByExample
    {
        public string Code { get; set; }
        public string CodeName { get; set; }
        public int FiscalYear { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SourceDimensionGetByIds : IHasIdentifiers<Guid>
    {
        public SourceDimensionGetByIds() { }

        public SourceDimensionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SourceDimensionPost : Resources.SourceDimension.EdFi.SourceDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class SourceDimensionPut : Resources.SourceDimension.EdFi.SourceDimension
    {
    }

    [ExcludeFromCodeCoverage]
    public class SourceDimensionDelete : IHasIdentifier
    {
        public SourceDimensionDelete() { }

        public SourceDimensionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SourceSystemDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SourceSystemDescriptorGetByExample
    {
        public int SourceSystemDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SourceSystemDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SourceSystemDescriptorGetByIds() { }

        public SourceSystemDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SourceSystemDescriptorPost : Resources.SourceSystemDescriptor.EdFi.SourceSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SourceSystemDescriptorPut : Resources.SourceSystemDescriptor.EdFi.SourceSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SourceSystemDescriptorDelete : IHasIdentifier
    {
        public SourceSystemDescriptorDelete() { }

        public SourceSystemDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SpecialEducationProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SpecialEducationProgramServiceDescriptorGetByExample
    {
        public int SpecialEducationProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SpecialEducationProgramServiceDescriptorGetByIds() { }

        public SpecialEducationProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationProgramServiceDescriptorPost : Resources.SpecialEducationProgramServiceDescriptor.EdFi.SpecialEducationProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationProgramServiceDescriptorPut : Resources.SpecialEducationProgramServiceDescriptor.EdFi.SpecialEducationProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationProgramServiceDescriptorDelete : IHasIdentifier
    {
        public SpecialEducationProgramServiceDescriptorDelete() { }

        public SpecialEducationProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SpecialEducationSettingDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SpecialEducationSettingDescriptorGetByExample
    {
        public int SpecialEducationSettingDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationSettingDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SpecialEducationSettingDescriptorGetByIds() { }

        public SpecialEducationSettingDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationSettingDescriptorPost : Resources.SpecialEducationSettingDescriptor.EdFi.SpecialEducationSettingDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationSettingDescriptorPut : Resources.SpecialEducationSettingDescriptor.EdFi.SpecialEducationSettingDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SpecialEducationSettingDescriptorDelete : IHasIdentifier
    {
        public SpecialEducationSettingDescriptorDelete() { }

        public SpecialEducationSettingDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffGetByExample
    {
        public DateTime BirthDate { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string LoginId { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SexDescriptor { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public decimal YearsOfPriorProfessionalExperience { get; set; }
        public decimal YearsOfPriorTeachingExperience { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffGetByIds : IHasIdentifiers<Guid>
    {
        public StaffGetByIds() { }

        public StaffGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffDelete : IHasIdentifier
    {
        public StaffDelete() { }

        public StaffDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffAbsenceEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventGetByExample
    {
        public string AbsenceEventCategoryDescriptor { get; set; }
        public string AbsenceEventReason { get; set; }
        public DateTime EventDate { get; set; }
        public decimal HoursAbsent { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventGetByIds : IHasIdentifiers<Guid>
    {
        public StaffAbsenceEventGetByIds() { }

        public StaffAbsenceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventPost : Resources.StaffAbsenceEvent.EdFi.StaffAbsenceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventPut : Resources.StaffAbsenceEvent.EdFi.StaffAbsenceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffAbsenceEventDelete : IHasIdentifier
    {
        public StaffAbsenceEventDelete() { }

        public StaffAbsenceEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffClassificationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffClassificationDescriptorGetByExample
    {
        public int StaffClassificationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffClassificationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StaffClassificationDescriptorGetByIds() { }

        public StaffClassificationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffClassificationDescriptorPost : Resources.StaffClassificationDescriptor.EdFi.StaffClassificationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffClassificationDescriptorPut : Resources.StaffClassificationDescriptor.EdFi.StaffClassificationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffClassificationDescriptorDelete : IHasIdentifier
    {
        public StaffClassificationDescriptorDelete() { }

        public StaffClassificationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffCohortAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string CohortIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
        public bool StudentRecordAccess { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffCohortAssociationGetByIds() { }

        public StaffCohortAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationPost : Resources.StaffCohortAssociation.EdFi.StaffCohortAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationPut : Resources.StaffCohortAssociation.EdFi.StaffCohortAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffCohortAssociationDelete : IHasIdentifier
    {
        public StaffCohortAssociationDelete() { }

        public StaffCohortAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffDisciplineIncidentAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string IncidentIdentifier { get; set; }
        public int SchoolId { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffDisciplineIncidentAssociationGetByIds() { }

        public StaffDisciplineIncidentAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationPost : Resources.StaffDisciplineIncidentAssociation.EdFi.StaffDisciplineIncidentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationPut : Resources.StaffDisciplineIncidentAssociation.EdFi.StaffDisciplineIncidentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffDisciplineIncidentAssociationDelete : IHasIdentifier
    {
        public StaffDisciplineIncidentAssociationDelete() { }

        public StaffDisciplineIncidentAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffEducationOrganizationAssignmentAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string CredentialIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public int EmploymentEducationOrganizationId { get; set; }
        public DateTime EmploymentHireDate { get; set; }
        public string EmploymentStatusDescriptor { get; set; }
        public DateTime EndDate { get; set; }
        public decimal FullTimeEquivalency { get; set; }
        public Guid Id { get; set; }
        public int OrderOfAssignment { get; set; }
        public string PositionTitle { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public string StateOfIssueStateAbbreviationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEducationOrganizationAssignmentAssociationGetByIds() { }

        public StaffEducationOrganizationAssignmentAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationPost : Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationPut : Resources.StaffEducationOrganizationAssignmentAssociation.EdFi.StaffEducationOrganizationAssignmentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationAssignmentAssociationDelete : IHasIdentifier
    {
        public StaffEducationOrganizationAssignmentAssociationDelete() { }

        public StaffEducationOrganizationAssignmentAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffEducationOrganizationContactAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationContactAssociationGetByExample
    {
        public string ContactTitle { get; set; }
        public string ContactTypeDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ElectronicMailAddress { get; set; }
        public Guid Id { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationContactAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEducationOrganizationContactAssociationGetByIds() { }

        public StaffEducationOrganizationContactAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationContactAssociationPost : Resources.StaffEducationOrganizationContactAssociation.EdFi.StaffEducationOrganizationContactAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationContactAssociationPut : Resources.StaffEducationOrganizationContactAssociation.EdFi.StaffEducationOrganizationContactAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationContactAssociationDelete : IHasIdentifier
    {
        public StaffEducationOrganizationContactAssociationDelete() { }

        public StaffEducationOrganizationContactAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffEducationOrganizationEmploymentAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationGetByExample
    {
        public string CredentialIdentifier { get; set; }
        public string Department { get; set; }
        public int EducationOrganizationId { get; set; }
        public string EmploymentStatusDescriptor { get; set; }
        public DateTime EndDate { get; set; }
        public decimal FullTimeEquivalency { get; set; }
        public DateTime HireDate { get; set; }
        public decimal HourlyWage { get; set; }
        public Guid Id { get; set; }
        public DateTime OfferDate { get; set; }
        public string SeparationDescriptor { get; set; }
        public string SeparationReasonDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public string StateOfIssueStateAbbreviationDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffEducationOrganizationEmploymentAssociationGetByIds() { }

        public StaffEducationOrganizationEmploymentAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationPost : Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationPut : Resources.StaffEducationOrganizationEmploymentAssociation.EdFi.StaffEducationOrganizationEmploymentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffEducationOrganizationEmploymentAssociationDelete : IHasIdentifier
    {
        public StaffEducationOrganizationEmploymentAssociationDelete() { }

        public StaffEducationOrganizationEmploymentAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffIdentificationSystemDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffIdentificationSystemDescriptorGetByExample
    {
        public int StaffIdentificationSystemDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffIdentificationSystemDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StaffIdentificationSystemDescriptorGetByIds() { }

        public StaffIdentificationSystemDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffIdentificationSystemDescriptorPost : Resources.StaffIdentificationSystemDescriptor.EdFi.StaffIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffIdentificationSystemDescriptorPut : Resources.StaffIdentificationSystemDescriptor.EdFi.StaffIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffIdentificationSystemDescriptorDelete : IHasIdentifier
    {
        public StaffIdentificationSystemDescriptorDelete() { }

        public StaffIdentificationSystemDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffLeaves.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffLeaveGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public string StaffLeaveEventCategoryDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public bool SubstituteAssigned { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeaveGetByIds : IHasIdentifiers<Guid>
    {
        public StaffLeaveGetByIds() { }

        public StaffLeaveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeavePost : Resources.StaffLeave.EdFi.StaffLeave
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeavePut : Resources.StaffLeave.EdFi.StaffLeave
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeaveDelete : IHasIdentifier
    {
        public StaffLeaveDelete() { }

        public StaffLeaveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffLeaveEventCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffLeaveEventCategoryDescriptorGetByExample
    {
        public int StaffLeaveEventCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeaveEventCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StaffLeaveEventCategoryDescriptorGetByIds() { }

        public StaffLeaveEventCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeaveEventCategoryDescriptorPost : Resources.StaffLeaveEventCategoryDescriptor.EdFi.StaffLeaveEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeaveEventCategoryDescriptorPut : Resources.StaffLeaveEventCategoryDescriptor.EdFi.StaffLeaveEventCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffLeaveEventCategoryDescriptorDelete : IHasIdentifier
    {
        public StaffLeaveEventCategoryDescriptorDelete() { }

        public StaffLeaveEventCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public bool StudentRecordAccess { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffProgramAssociationGetByIds() { }

        public StaffProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationPost : Resources.StaffProgramAssociation.EdFi.StaffProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationPut : Resources.StaffProgramAssociation.EdFi.StaffProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffProgramAssociationDelete : IHasIdentifier
    {
        public StaffProgramAssociationDelete() { }

        public StaffProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffSchoolAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationGetByExample
    {
        public string CalendarCode { get; set; }
        public Guid Id { get; set; }
        public string ProgramAssignmentDescriptor { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string StaffUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffSchoolAssociationGetByIds() { }

        public StaffSchoolAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationPost : Resources.StaffSchoolAssociation.EdFi.StaffSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationPut : Resources.StaffSchoolAssociation.EdFi.StaffSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffSchoolAssociationDelete : IHasIdentifier
    {
        public StaffSchoolAssociationDelete() { }

        public StaffSchoolAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StaffSectionAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string ClassroomPositionDescriptor { get; set; }
        public DateTime EndDate { get; set; }
        public bool HighlyQualifiedTeacher { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public decimal PercentageContribution { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StaffUniqueId { get; set; }
        public bool TeacherStudentDataLinkExclusion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StaffSectionAssociationGetByIds() { }

        public StaffSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationPost : Resources.StaffSectionAssociation.EdFi.StaffSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationPut : Resources.StaffSectionAssociation.EdFi.StaffSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StaffSectionAssociationDelete : IHasIdentifier
    {
        public StaffSectionAssociationDelete() { }

        public StaffSectionAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StateAbbreviationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StateAbbreviationDescriptorGetByExample
    {
        public int StateAbbreviationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StateAbbreviationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StateAbbreviationDescriptorGetByIds() { }

        public StateAbbreviationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StateAbbreviationDescriptorPost : Resources.StateAbbreviationDescriptor.EdFi.StateAbbreviationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StateAbbreviationDescriptorPut : Resources.StateAbbreviationDescriptor.EdFi.StateAbbreviationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StateAbbreviationDescriptorDelete : IHasIdentifier
    {
        public StateAbbreviationDescriptorDelete() { }

        public StateAbbreviationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StateEducationAgencies.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyGetByExample
    {
        public int StateEducationAgencyId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyGetByIds : IHasIdentifiers<Guid>
    {
        public StateEducationAgencyGetByIds() { }

        public StateEducationAgencyGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyPost : Resources.StateEducationAgency.EdFi.StateEducationAgency
    {
    }

    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyPut : Resources.StateEducationAgency.EdFi.StateEducationAgency
    {
    }

    [ExcludeFromCodeCoverage]
    public class StateEducationAgencyDelete : IHasIdentifier
    {
        public StateEducationAgencyDelete() { }

        public StateEducationAgencyDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Students.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentGetByExample
    {
        public string BirthCity { get; set; }
        public string BirthCountryDescriptor { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthInternationalProvince { get; set; }
        public string BirthSexDescriptor { get; set; }
        public string BirthStateAbbreviationDescriptor { get; set; }
        public string CitizenshipStatusDescriptor { get; set; }
        public DateTime DateEnteredUS { get; set; }
        public string FirstName { get; set; }
        public string GenerationCodeSuffix { get; set; }
        public Guid Id { get; set; }
        public string LastSurname { get; set; }
        public string MaidenName { get; set; }
        public string MiddleName { get; set; }
        public bool MultipleBirthStatus { get; set; }
        public string PersonalTitlePrefix { get; set; }
        public string PersonId { get; set; }
        public string SourceSystemDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGetByIds() { }

        public StudentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.EdFi.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.EdFi.Student
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDelete : IHasIdentifier
    {
        public StudentDelete() { }

        public StudentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentAcademicRecords.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordGetByExample
    {
        public decimal CumulativeAttemptedCreditConversion { get; set; }
        public decimal CumulativeAttemptedCredits { get; set; }
        public string CumulativeAttemptedCreditTypeDescriptor { get; set; }
        public decimal CumulativeEarnedCreditConversion { get; set; }
        public decimal CumulativeEarnedCredits { get; set; }
        public string CumulativeEarnedCreditTypeDescriptor { get; set; }
        public decimal CumulativeGradePointAverage { get; set; }
        public decimal CumulativeGradePointsEarned { get; set; }
        public int EducationOrganizationId { get; set; }
        public string GradeValueQualifier { get; set; }
        public Guid Id { get; set; }
        public DateTime ProjectedGraduationDate { get; set; }
        public short SchoolYear { get; set; }
        public decimal SessionAttemptedCreditConversion { get; set; }
        public decimal SessionAttemptedCredits { get; set; }
        public string SessionAttemptedCreditTypeDescriptor { get; set; }
        public decimal SessionEarnedCreditConversion { get; set; }
        public decimal SessionEarnedCredits { get; set; }
        public string SessionEarnedCreditTypeDescriptor { get; set; }
        public decimal SessionGradePointAverage { get; set; }
        public decimal SessionGradePointsEarned { get; set; }
        public string StudentUniqueId { get; set; }
        public string TermDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordGetByIds : IHasIdentifiers<Guid>
    {
        public StudentAcademicRecordGetByIds() { }

        public StudentAcademicRecordGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordPost : Resources.StudentAcademicRecord.EdFi.StudentAcademicRecord
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordPut : Resources.StudentAcademicRecord.EdFi.StudentAcademicRecord
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordDelete : IHasIdentifier
    {
        public StudentAcademicRecordDelete() { }

        public StudentAcademicRecordDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentAssessments.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentGetByExample
    {
        public DateTime AdministrationDate { get; set; }
        public DateTime AdministrationEndDate { get; set; }
        public string AdministrationEnvironmentDescriptor { get; set; }
        public string AdministrationLanguageDescriptor { get; set; }
        public int AssessedMinutes { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string EventCircumstanceDescriptor { get; set; }
        public string EventDescription { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string PlatformTypeDescriptor { get; set; }
        public string ReasonNotTestedDescriptor { get; set; }
        public int ReportedSchoolId { get; set; }
        public string ReportedSchoolIdentifier { get; set; }
        public string RetestIndicatorDescriptor { get; set; }
        public short SchoolYear { get; set; }
        public string SerialNumber { get; set; }
        public string StudentAssessmentIdentifier { get; set; }
        public string StudentUniqueId { get; set; }
        public string WhenAssessedGradeLevelDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentGetByIds : IHasIdentifiers<Guid>
    {
        public StudentAssessmentGetByIds() { }

        public StudentAssessmentGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentPost : Resources.StudentAssessment.EdFi.StudentAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentPut : Resources.StudentAssessment.EdFi.StudentAssessment
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentDelete : IHasIdentifier
    {
        public StudentAssessmentDelete() { }

        public StudentAssessmentDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentAssessmentEducationOrganizationAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationGetByExample
    {
        public string AssessmentIdentifier { get; set; }
        public string EducationOrganizationAssociationTypeDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public short SchoolYear { get; set; }
        public string StudentAssessmentIdentifier { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentAssessmentEducationOrganizationAssociationGetByIds() { }

        public StudentAssessmentEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationPost : Resources.StudentAssessmentEducationOrganizationAssociation.EdFi.StudentAssessmentEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationPut : Resources.StudentAssessmentEducationOrganizationAssociation.EdFi.StudentAssessmentEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentAssessmentEducationOrganizationAssociationDelete : IHasIdentifier
    {
        public StudentAssessmentEducationOrganizationAssociationDelete() { }

        public StudentAssessmentEducationOrganizationAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentCharacteristicDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentCharacteristicDescriptorGetByExample
    {
        public int StudentCharacteristicDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCharacteristicDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StudentCharacteristicDescriptorGetByIds() { }

        public StudentCharacteristicDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCharacteristicDescriptorPost : Resources.StudentCharacteristicDescriptor.EdFi.StudentCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCharacteristicDescriptorPut : Resources.StudentCharacteristicDescriptor.EdFi.StudentCharacteristicDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCharacteristicDescriptorDelete : IHasIdentifier
    {
        public StudentCharacteristicDescriptorDelete() { }

        public StudentCharacteristicDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentCohortAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string CohortIdentifier { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentCohortAssociationGetByIds() { }

        public StudentCohortAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationPost : Resources.StudentCohortAssociation.EdFi.StudentCohortAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationPut : Resources.StudentCohortAssociation.EdFi.StudentCohortAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCohortAssociationDelete : IHasIdentifier
    {
        public StudentCohortAssociationDelete() { }

        public StudentCohortAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentCompetencyObjectives.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectiveGetByExample
    {
        public string CompetencyLevelDescriptor { get; set; }
        public string DiagnosticStatement { get; set; }
        public string GradingPeriodDescriptor { get; set; }
        public int GradingPeriodSchoolId { get; set; }
        public short GradingPeriodSchoolYear { get; set; }
        public int GradingPeriodSequence { get; set; }
        public Guid Id { get; set; }
        public string Objective { get; set; }
        public int ObjectiveEducationOrganizationId { get; set; }
        public string ObjectiveGradeLevelDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectiveGetByIds : IHasIdentifiers<Guid>
    {
        public StudentCompetencyObjectiveGetByIds() { }

        public StudentCompetencyObjectiveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectivePost : Resources.StudentCompetencyObjective.EdFi.StudentCompetencyObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectivePut : Resources.StudentCompetencyObjective.EdFi.StudentCompetencyObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCompetencyObjectiveDelete : IHasIdentifier
    {
        public StudentCompetencyObjectiveDelete() { }

        public StudentCompetencyObjectiveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentCTEProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool NonTraditionalGenderStatus { get; set; }
        public bool PrivateCTEProgram { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
        public string TechnicalSkillsAssessmentDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentCTEProgramAssociationGetByIds() { }

        public StudentCTEProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationPost : Resources.StudentCTEProgramAssociation.EdFi.StudentCTEProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationPut : Resources.StudentCTEProgramAssociation.EdFi.StudentCTEProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentCTEProgramAssociationDelete : IHasIdentifier
    {
        public StudentCTEProgramAssociationDelete() { }

        public StudentCTEProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentDisciplineIncidentAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string IncidentIdentifier { get; set; }
        public int SchoolId { get; set; }
        public string StudentParticipationCodeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentDisciplineIncidentAssociationGetByIds() { }

        public StudentDisciplineIncidentAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentAssociationPost : Resources.StudentDisciplineIncidentAssociation.EdFi.StudentDisciplineIncidentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentAssociationPut : Resources.StudentDisciplineIncidentAssociation.EdFi.StudentDisciplineIncidentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentAssociationDelete : IHasIdentifier
    {
        public StudentDisciplineIncidentAssociationDelete() { }

        public StudentDisciplineIncidentAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentDisciplineIncidentBehaviorAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationGetByExample
    {
        public string BehaviorDescriptor { get; set; }
        public string BehaviorDetailedDescription { get; set; }
        public Guid Id { get; set; }
        public string IncidentIdentifier { get; set; }
        public int SchoolId { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentDisciplineIncidentBehaviorAssociationGetByIds() { }

        public StudentDisciplineIncidentBehaviorAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationPost : Resources.StudentDisciplineIncidentBehaviorAssociation.EdFi.StudentDisciplineIncidentBehaviorAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationPut : Resources.StudentDisciplineIncidentBehaviorAssociation.EdFi.StudentDisciplineIncidentBehaviorAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentBehaviorAssociationDelete : IHasIdentifier
    {
        public StudentDisciplineIncidentBehaviorAssociationDelete() { }

        public StudentDisciplineIncidentBehaviorAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentDisciplineIncidentNonOffenderAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string IncidentIdentifier { get; set; }
        public int SchoolId { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentDisciplineIncidentNonOffenderAssociationGetByIds() { }

        public StudentDisciplineIncidentNonOffenderAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationPost : Resources.StudentDisciplineIncidentNonOffenderAssociation.EdFi.StudentDisciplineIncidentNonOffenderAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationPut : Resources.StudentDisciplineIncidentNonOffenderAssociation.EdFi.StudentDisciplineIncidentNonOffenderAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentDisciplineIncidentNonOffenderAssociationDelete : IHasIdentifier
    {
        public StudentDisciplineIncidentNonOffenderAssociationDelete() { }

        public StudentDisciplineIncidentNonOffenderAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentEducationOrganizationAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationGetByExample
    {
        public string BarrierToInternetAccessInResidenceDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool HispanicLatinoEthnicity { get; set; }
        public Guid Id { get; set; }
        public bool InternetAccessInResidence { get; set; }
        public string InternetAccessTypeInResidenceDescriptor { get; set; }
        public string InternetPerformanceInResidenceDescriptor { get; set; }
        public string LimitedEnglishProficiencyDescriptor { get; set; }
        public string LoginId { get; set; }
        public string OldEthnicityDescriptor { get; set; }
        public string PrimaryLearningDeviceAccessDescriptor { get; set; }
        public string PrimaryLearningDeviceAwayFromSchoolDescriptor { get; set; }
        public string PrimaryLearningDeviceProviderDescriptor { get; set; }
        public string ProfileThumbnail { get; set; }
        public string SexDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentEducationOrganizationAssociationGetByIds() { }

        public StudentEducationOrganizationAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationPost : Resources.StudentEducationOrganizationAssociation.EdFi.StudentEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationPut : Resources.StudentEducationOrganizationAssociation.EdFi.StudentEducationOrganizationAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationAssociationDelete : IHasIdentifier
    {
        public StudentEducationOrganizationAssociationDelete() { }

        public StudentEducationOrganizationAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentEducationOrganizationResponsibilityAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }
        public string ResponsibilityDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentEducationOrganizationResponsibilityAssociationGetByIds() { }

        public StudentEducationOrganizationResponsibilityAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationPost : Resources.StudentEducationOrganizationResponsibilityAssociation.EdFi.StudentEducationOrganizationResponsibilityAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationPut : Resources.StudentEducationOrganizationResponsibilityAssociation.EdFi.StudentEducationOrganizationResponsibilityAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentEducationOrganizationResponsibilityAssociationDelete : IHasIdentifier
    {
        public StudentEducationOrganizationResponsibilityAssociationDelete() { }

        public StudentEducationOrganizationResponsibilityAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentGradebookEntries.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryGetByExample
    {
        public string AssignmentLateStatusDescriptor { get; set; }
        public string CompetencyLevelDescriptor { get; set; }
        public DateTime DateFulfilled { get; set; }
        public string DiagnosticStatement { get; set; }
        public string GradebookEntryIdentifier { get; set; }
        public Guid Id { get; set; }
        public string LetterGradeEarned { get; set; }
        public string Namespace { get; set; }
        public decimal NumericGradeEarned { get; set; }
        public decimal PointsEarned { get; set; }
        public string StudentUniqueId { get; set; }
        public string SubmissionStatusDescriptor { get; set; }
        public TimeSpan TimeFulfilled { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGradebookEntryGetByIds() { }

        public StudentGradebookEntryGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryPost : Resources.StudentGradebookEntry.EdFi.StudentGradebookEntry
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryPut : Resources.StudentGradebookEntry.EdFi.StudentGradebookEntry
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentGradebookEntryDelete : IHasIdentifier
    {
        public StudentGradebookEntryDelete() { }

        public StudentGradebookEntryDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentHomelessProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationGetByExample
    {
        public bool AwaitingFosterCare { get; set; }
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string HomelessPrimaryNighttimeResidenceDescriptor { get; set; }
        public bool HomelessUnaccompaniedYouth { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentHomelessProgramAssociationGetByIds() { }

        public StudentHomelessProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationPost : Resources.StudentHomelessProgramAssociation.EdFi.StudentHomelessProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationPut : Resources.StudentHomelessProgramAssociation.EdFi.StudentHomelessProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentHomelessProgramAssociationDelete : IHasIdentifier
    {
        public StudentHomelessProgramAssociationDelete() { }

        public StudentHomelessProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentIdentificationSystemDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentIdentificationSystemDescriptorGetByExample
    {
        public int StudentIdentificationSystemDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentIdentificationSystemDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StudentIdentificationSystemDescriptorGetByIds() { }

        public StudentIdentificationSystemDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentIdentificationSystemDescriptorPost : Resources.StudentIdentificationSystemDescriptor.EdFi.StudentIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentIdentificationSystemDescriptorPut : Resources.StudentIdentificationSystemDescriptor.EdFi.StudentIdentificationSystemDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentIdentificationSystemDescriptorDelete : IHasIdentifier
    {
        public StudentIdentificationSystemDescriptorDelete() { }

        public StudentIdentificationSystemDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentInterventionAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationGetByExample
    {
        public int CohortEducationOrganizationId { get; set; }
        public string CohortIdentifier { get; set; }
        public string DiagnosticStatement { get; set; }
        public int Dosage { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string InterventionIdentificationCode { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentInterventionAssociationGetByIds() { }

        public StudentInterventionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationPost : Resources.StudentInterventionAssociation.EdFi.StudentInterventionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationPut : Resources.StudentInterventionAssociation.EdFi.StudentInterventionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAssociationDelete : IHasIdentifier
    {
        public StudentInterventionAssociationDelete() { }

        public StudentInterventionAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentInterventionAttendanceEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventGetByExample
    {
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public string EducationalEnvironmentDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventDuration { get; set; }
        public Guid Id { get; set; }
        public int InterventionDuration { get; set; }
        public string InterventionIdentificationCode { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventGetByIds : IHasIdentifiers<Guid>
    {
        public StudentInterventionAttendanceEventGetByIds() { }

        public StudentInterventionAttendanceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventPost : Resources.StudentInterventionAttendanceEvent.EdFi.StudentInterventionAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventPut : Resources.StudentInterventionAttendanceEvent.EdFi.StudentInterventionAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentInterventionAttendanceEventDelete : IHasIdentifier
    {
        public StudentInterventionAttendanceEventDelete() { }

        public StudentInterventionAttendanceEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentLanguageInstructionProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int Dosage { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool EnglishLearnerParticipation { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentLanguageInstructionProgramAssociationGetByIds() { }

        public StudentLanguageInstructionProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationPost : Resources.StudentLanguageInstructionProgramAssociation.EdFi.StudentLanguageInstructionProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationPut : Resources.StudentLanguageInstructionProgramAssociation.EdFi.StudentLanguageInstructionProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentLanguageInstructionProgramAssociationDelete : IHasIdentifier
    {
        public StudentLanguageInstructionProgramAssociationDelete() { }

        public StudentLanguageInstructionProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentLearningObjectives.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentLearningObjectiveGetByExample
    {
        public string CompetencyLevelDescriptor { get; set; }
        public string DiagnosticStatement { get; set; }
        public string GradingPeriodDescriptor { get; set; }
        public int GradingPeriodSchoolId { get; set; }
        public short GradingPeriodSchoolYear { get; set; }
        public int GradingPeriodSequence { get; set; }
        public Guid Id { get; set; }
        public string LearningObjectiveId { get; set; }
        public string Namespace { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentLearningObjectiveGetByIds : IHasIdentifiers<Guid>
    {
        public StudentLearningObjectiveGetByIds() { }

        public StudentLearningObjectiveGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentLearningObjectivePost : Resources.StudentLearningObjective.EdFi.StudentLearningObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentLearningObjectivePut : Resources.StudentLearningObjective.EdFi.StudentLearningObjective
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentLearningObjectiveDelete : IHasIdentifier
    {
        public StudentLearningObjectiveDelete() { }

        public StudentLearningObjectiveDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentMigrantEducationProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string ContinuationOfServicesReasonDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EligibilityExpirationDate { get; set; }
        public DateTime LastQualifyingMove { get; set; }
        public bool PriorityForServices { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public DateTime QualifyingArrivalDate { get; set; }
        public DateTime StateResidencyDate { get; set; }
        public string StudentUniqueId { get; set; }
        public DateTime USInitialEntry { get; set; }
        public DateTime USInitialSchoolEntry { get; set; }
        public DateTime USMostRecentEntry { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentMigrantEducationProgramAssociationGetByIds() { }

        public StudentMigrantEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationPost : Resources.StudentMigrantEducationProgramAssociation.EdFi.StudentMigrantEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationPut : Resources.StudentMigrantEducationProgramAssociation.EdFi.StudentMigrantEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentMigrantEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentMigrantEducationProgramAssociationDelete() { }

        public StudentMigrantEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentNeglectedOrDelinquentProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ELAProgressLevelDescriptor { get; set; }
        public string MathematicsProgressLevelDescriptor { get; set; }
        public string NeglectedOrDelinquentProgramDescriptor { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentNeglectedOrDelinquentProgramAssociationGetByIds() { }

        public StudentNeglectedOrDelinquentProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationPost : Resources.StudentNeglectedOrDelinquentProgramAssociation.EdFi.StudentNeglectedOrDelinquentProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationPut : Resources.StudentNeglectedOrDelinquentProgramAssociation.EdFi.StudentNeglectedOrDelinquentProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentNeglectedOrDelinquentProgramAssociationDelete : IHasIdentifier
    {
        public StudentNeglectedOrDelinquentProgramAssociationDelete() { }

        public StudentNeglectedOrDelinquentProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentParentAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationGetByExample
    {
        public int ContactPriority { get; set; }
        public string ContactRestrictions { get; set; }
        public bool EmergencyContactStatus { get; set; }
        public Guid Id { get; set; }
        public bool LegalGuardian { get; set; }
        public bool LivesWith { get; set; }
        public string ParentUniqueId { get; set; }
        public bool PrimaryContactStatus { get; set; }
        public string RelationDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentParentAssociationGetByIds() { }

        public StudentParentAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationPost : Resources.StudentParentAssociation.EdFi.StudentParentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationPut : Resources.StudentParentAssociation.EdFi.StudentParentAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentParentAssociationDelete : IHasIdentifier
    {
        public StudentParentAssociationDelete() { }

        public StudentParentAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentParticipationCodeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentParticipationCodeDescriptorGetByExample
    {
        public int StudentParticipationCodeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentParticipationCodeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public StudentParticipationCodeDescriptorGetByIds() { }

        public StudentParticipationCodeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentParticipationCodeDescriptorPost : Resources.StudentParticipationCodeDescriptor.EdFi.StudentParticipationCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentParticipationCodeDescriptorPut : Resources.StudentParticipationCodeDescriptor.EdFi.StudentParticipationCodeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentParticipationCodeDescriptorDelete : IHasIdentifier
    {
        public StudentParticipationCodeDescriptorDelete() { }

        public StudentParticipationCodeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentProgramAssociationGetByIds() { }

        public StudentProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationPost : Resources.StudentProgramAssociation.EdFi.StudentProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationPut : Resources.StudentProgramAssociation.EdFi.StudentProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAssociationDelete : IHasIdentifier
    {
        public StudentProgramAssociationDelete() { }

        public StudentProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentProgramAttendanceEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventGetByExample
    {
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public string EducationalEnvironmentDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventDuration { get; set; }
        public Guid Id { get; set; }
        public int ProgramAttendanceDuration { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventGetByIds : IHasIdentifiers<Guid>
    {
        public StudentProgramAttendanceEventGetByIds() { }

        public StudentProgramAttendanceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventPost : Resources.StudentProgramAttendanceEvent.EdFi.StudentProgramAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventPut : Resources.StudentProgramAttendanceEvent.EdFi.StudentProgramAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentProgramAttendanceEventDelete : IHasIdentifier
    {
        public StudentProgramAttendanceEventDelete() { }

        public StudentProgramAttendanceEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSchoolAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByExample
    {
        public string CalendarCode { get; set; }
        public short ClassOfSchoolYear { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool EmployedWhileEnrolled { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryGradeLevelDescriptor { get; set; }
        public string EntryGradeLevelReasonDescriptor { get; set; }
        public string EntryTypeDescriptor { get; set; }
        public DateTime ExitWithdrawDate { get; set; }
        public string ExitWithdrawTypeDescriptor { get; set; }
        public decimal FullTimeEquivalency { get; set; }
        public string GraduationPlanTypeDescriptor { get; set; }
        public short GraduationSchoolYear { get; set; }
        public Guid Id { get; set; }
        public bool PrimarySchool { get; set; }
        public bool RepeatGradeIndicator { get; set; }
        public string ResidencyStatusDescriptor { get; set; }
        public bool SchoolChoiceTransfer { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string StudentUniqueId { get; set; }
        public bool TermCompletionIndicator { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSchoolAssociationGetByIds() { }

        public StudentSchoolAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationPost : Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationPut : Resources.StudentSchoolAssociation.EdFi.StudentSchoolAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationDelete : IHasIdentifier
    {
        public StudentSchoolAssociationDelete() { }

        public StudentSchoolAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSchoolAttendanceEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventGetByExample
    {
        public TimeSpan ArrivalTime { get; set; }
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string EducationalEnvironmentDescriptor { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventDuration { get; set; }
        public Guid Id { get; set; }
        public int SchoolAttendanceDuration { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SessionName { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSchoolAttendanceEventGetByIds() { }

        public StudentSchoolAttendanceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventPost : Resources.StudentSchoolAttendanceEvent.EdFi.StudentSchoolAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventPut : Resources.StudentSchoolAttendanceEvent.EdFi.StudentSchoolAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAttendanceEventDelete : IHasIdentifier
    {
        public StudentSchoolAttendanceEventDelete() { }

        public StudentSchoolAttendanceEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSchoolFoodServiceProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public bool DirectCertification { get; set; }
        public int EducationOrganizationId { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSchoolFoodServiceProgramAssociationGetByIds() { }

        public StudentSchoolFoodServiceProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationPost : Resources.StudentSchoolFoodServiceProgramAssociation.EdFi.StudentSchoolFoodServiceProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationPut : Resources.StudentSchoolFoodServiceProgramAssociation.EdFi.StudentSchoolFoodServiceProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSchoolFoodServiceProgramAssociationDelete : IHasIdentifier
    {
        public StudentSchoolFoodServiceProgramAssociationDelete() { }

        public StudentSchoolFoodServiceProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSectionAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationGetByExample
    {
        public string AttemptStatusDescriptor { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool HomeroomIndicator { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public string RepeatIdentifierDescriptor { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StudentUniqueId { get; set; }
        public bool TeacherStudentDataLinkExclusion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSectionAssociationGetByIds() { }

        public StudentSectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationPost : Resources.StudentSectionAssociation.EdFi.StudentSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationPut : Resources.StudentSectionAssociation.EdFi.StudentSectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAssociationDelete : IHasIdentifier
    {
        public StudentSectionAssociationDelete() { }

        public StudentSectionAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSectionAttendanceEvents.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventGetByExample
    {
        public TimeSpan ArrivalTime { get; set; }
        public string AttendanceEventCategoryDescriptor { get; set; }
        public string AttendanceEventReason { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string EducationalEnvironmentDescriptor { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventDuration { get; set; }
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public int SectionAttendanceDuration { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSectionAttendanceEventGetByIds() { }

        public StudentSectionAttendanceEventGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventPost : Resources.StudentSectionAttendanceEvent.EdFi.StudentSectionAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventPut : Resources.StudentSectionAttendanceEvent.EdFi.StudentSectionAttendanceEvent
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSectionAttendanceEventDelete : IHasIdentifier
    {
        public StudentSectionAttendanceEventDelete() { }

        public StudentSectionAttendanceEventDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentSpecialEducationProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public bool IdeaEligibility { get; set; }
        public DateTime IEPBeginDate { get; set; }
        public DateTime IEPEndDate { get; set; }
        public DateTime IEPReviewDate { get; set; }
        public DateTime LastEvaluationDate { get; set; }
        public bool MedicallyFragile { get; set; }
        public bool MultiplyDisabled { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public decimal SchoolHoursPerWeek { get; set; }
        public decimal SpecialEducationHoursPerWeek { get; set; }
        public string SpecialEducationSettingDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentSpecialEducationProgramAssociationGetByIds() { }

        public StudentSpecialEducationProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPost : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationPut : Resources.StudentSpecialEducationProgramAssociation.EdFi.StudentSpecialEducationProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentSpecialEducationProgramAssociationDelete : IHasIdentifier
    {
        public StudentSpecialEducationProgramAssociationDelete() { }

        public StudentSpecialEducationProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.StudentTitleIPartAProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationGetByExample
    {
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
        public string TitleIPartAParticipantDescriptor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentTitleIPartAProgramAssociationGetByIds() { }

        public StudentTitleIPartAProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationPost : Resources.StudentTitleIPartAProgramAssociation.EdFi.StudentTitleIPartAProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationPut : Resources.StudentTitleIPartAProgramAssociation.EdFi.StudentTitleIPartAProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentTitleIPartAProgramAssociationDelete : IHasIdentifier
    {
        public StudentTitleIPartAProgramAssociationDelete() { }

        public StudentTitleIPartAProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SubmissionStatusDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SubmissionStatusDescriptorGetByExample
    {
        public int SubmissionStatusDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionStatusDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SubmissionStatusDescriptorGetByIds() { }

        public SubmissionStatusDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionStatusDescriptorPost : Resources.SubmissionStatusDescriptor.EdFi.SubmissionStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionStatusDescriptorPut : Resources.SubmissionStatusDescriptor.EdFi.SubmissionStatusDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SubmissionStatusDescriptorDelete : IHasIdentifier
    {
        public SubmissionStatusDescriptorDelete() { }

        public SubmissionStatusDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Surveys.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public int NumberAdministered { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SessionName { get; set; }
        public string SurveyCategoryDescriptor { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyGetByIds() { }

        public SurveyGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyPost : Resources.Survey.EdFi.Survey
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyPut : Resources.Survey.EdFi.Survey
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyDelete : IHasIdentifier
    {
        public SurveyDelete() { }

        public SurveyDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyCategoryDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyCategoryDescriptorGetByExample
    {
        public int SurveyCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyCategoryDescriptorGetByIds() { }

        public SurveyCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCategoryDescriptorPost : Resources.SurveyCategoryDescriptor.EdFi.SurveyCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCategoryDescriptorPut : Resources.SurveyCategoryDescriptor.EdFi.SurveyCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCategoryDescriptorDelete : IHasIdentifier
    {
        public SurveyCategoryDescriptorDelete() { }

        public SurveyCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyCourseAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationGetByExample
    {
        public string CourseCode { get; set; }
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string SurveyIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyCourseAssociationGetByIds() { }

        public SurveyCourseAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationPost : Resources.SurveyCourseAssociation.EdFi.SurveyCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationPut : Resources.SurveyCourseAssociation.EdFi.SurveyCourseAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyCourseAssociationDelete : IHasIdentifier
    {
        public SurveyCourseAssociationDelete() { }

        public SurveyCourseAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyLevelDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyLevelDescriptorGetByExample
    {
        public int SurveyLevelDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyLevelDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyLevelDescriptorGetByIds() { }

        public SurveyLevelDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyLevelDescriptorPost : Resources.SurveyLevelDescriptor.EdFi.SurveyLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyLevelDescriptorPut : Resources.SurveyLevelDescriptor.EdFi.SurveyLevelDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyLevelDescriptorDelete : IHasIdentifier
    {
        public SurveyLevelDescriptorDelete() { }

        public SurveyLevelDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyProgramAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string SurveyIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyProgramAssociationGetByIds() { }

        public SurveyProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationPost : Resources.SurveyProgramAssociation.EdFi.SurveyProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationPut : Resources.SurveyProgramAssociation.EdFi.SurveyProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyProgramAssociationDelete : IHasIdentifier
    {
        public SurveyProgramAssociationDelete() { }

        public SurveyProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyQuestions.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionFormDescriptor { get; set; }
        public string QuestionText { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyQuestionGetByIds() { }

        public SurveyQuestionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionPost : Resources.SurveyQuestion.EdFi.SurveyQuestion
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionPut : Resources.SurveyQuestion.EdFi.SurveyQuestion
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionDelete : IHasIdentifier
    {
        public SurveyQuestionDelete() { }

        public SurveyQuestionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyQuestionResponses.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionResponseGetByExample
    {
        public string Comment { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public bool NoResponse { get; set; }
        public string QuestionCode { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionResponseGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyQuestionResponseGetByIds() { }

        public SurveyQuestionResponseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionResponsePost : Resources.SurveyQuestionResponse.EdFi.SurveyQuestionResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionResponsePut : Resources.SurveyQuestionResponse.EdFi.SurveyQuestionResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyQuestionResponseDelete : IHasIdentifier
    {
        public SurveyQuestionResponseDelete() { }

        public SurveyQuestionResponseDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyResponses.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyResponseGetByExample
    {
        public string ElectronicMailAddress { get; set; }
        public string FullName { get; set; }
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string Namespace { get; set; }
        public string ParentUniqueId { get; set; }
        public DateTime ResponseDate { get; set; }
        public int ResponseTime { get; set; }
        public string StaffUniqueId { get; set; }
        public string StudentUniqueId { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyResponseGetByIds() { }

        public SurveyResponseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePost : Resources.SurveyResponse.EdFi.SurveyResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponsePut : Resources.SurveyResponse.EdFi.SurveyResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseDelete : IHasIdentifier
    {
        public SurveyResponseDelete() { }

        public SurveyResponseDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyResponseEducationOrganizationTargetAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyResponseEducationOrganizationTargetAssociationGetByIds() { }

        public SurveyResponseEducationOrganizationTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationPost : Resources.SurveyResponseEducationOrganizationTargetAssociation.EdFi.SurveyResponseEducationOrganizationTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationPut : Resources.SurveyResponseEducationOrganizationTargetAssociation.EdFi.SurveyResponseEducationOrganizationTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseEducationOrganizationTargetAssociationDelete : IHasIdentifier
    {
        public SurveyResponseEducationOrganizationTargetAssociationDelete() { }

        public SurveyResponseEducationOrganizationTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveyResponseStaffTargetAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string StaffUniqueId { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveyResponseStaffTargetAssociationGetByIds() { }

        public SurveyResponseStaffTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationPost : Resources.SurveyResponseStaffTargetAssociation.EdFi.SurveyResponseStaffTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationPut : Resources.SurveyResponseStaffTargetAssociation.EdFi.SurveyResponseStaffTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveyResponseStaffTargetAssociationDelete : IHasIdentifier
    {
        public SurveyResponseStaffTargetAssociationDelete() { }

        public SurveyResponseStaffTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveySections.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionGetByIds() { }

        public SurveySectionGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionPost : Resources.SurveySection.EdFi.SurveySection
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionPut : Resources.SurveySection.EdFi.SurveySection
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionDelete : IHasIdentifier
    {
        public SurveySectionDelete() { }

        public SurveySectionDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveySectionAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string LocalCourseCode { get; set; }
        public string Namespace { get; set; }
        public int SchoolId { get; set; }
        public short SchoolYear { get; set; }
        public string SectionIdentifier { get; set; }
        public string SessionName { get; set; }
        public string SurveyIdentifier { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionAssociationGetByIds() { }

        public SurveySectionAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationPost : Resources.SurveySectionAssociation.EdFi.SurveySectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationPut : Resources.SurveySectionAssociation.EdFi.SurveySectionAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionAssociationDelete : IHasIdentifier
    {
        public SurveySectionAssociationDelete() { }

        public SurveySectionAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveySectionResponses.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public decimal SectionRating { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionResponseGetByIds() { }

        public SurveySectionResponseGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePost : Resources.SurveySectionResponse.EdFi.SurveySectionResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponsePut : Resources.SurveySectionResponse.EdFi.SurveySectionResponse
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseDelete : IHasIdentifier
    {
        public SurveySectionResponseDelete() { }

        public SurveySectionResponseDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveySectionResponseEducationOrganizationTargetAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationGetByExample
    {
        public int EducationOrganizationId { get; set; }
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionResponseEducationOrganizationTargetAssociationGetByIds() { }

        public SurveySectionResponseEducationOrganizationTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationPost : Resources.SurveySectionResponseEducationOrganizationTargetAssociation.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationPut : Resources.SurveySectionResponseEducationOrganizationTargetAssociation.EdFi.SurveySectionResponseEducationOrganizationTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseEducationOrganizationTargetAssociationDelete : IHasIdentifier
    {
        public SurveySectionResponseEducationOrganizationTargetAssociationDelete() { }

        public SurveySectionResponseEducationOrganizationTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.SurveySectionResponseStaffTargetAssociations.EdFi
{

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationGetByExample
    {
        public Guid Id { get; set; }
        public string Namespace { get; set; }
        public string StaffUniqueId { get; set; }
        public string SurveyIdentifier { get; set; }
        public string SurveyResponseIdentifier { get; set; }
        public string SurveySectionTitle { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public SurveySectionResponseStaffTargetAssociationGetByIds() { }

        public SurveySectionResponseStaffTargetAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationPost : Resources.SurveySectionResponseStaffTargetAssociation.EdFi.SurveySectionResponseStaffTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationPut : Resources.SurveySectionResponseStaffTargetAssociation.EdFi.SurveySectionResponseStaffTargetAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class SurveySectionResponseStaffTargetAssociationDelete : IHasIdentifier
    {
        public SurveySectionResponseStaffTargetAssociationDelete() { }

        public SurveySectionResponseStaffTargetAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TeachingCredentialBasisDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialBasisDescriptorGetByExample
    {
        public int TeachingCredentialBasisDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialBasisDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TeachingCredentialBasisDescriptorGetByIds() { }

        public TeachingCredentialBasisDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialBasisDescriptorPost : Resources.TeachingCredentialBasisDescriptor.EdFi.TeachingCredentialBasisDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialBasisDescriptorPut : Resources.TeachingCredentialBasisDescriptor.EdFi.TeachingCredentialBasisDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialBasisDescriptorDelete : IHasIdentifier
    {
        public TeachingCredentialBasisDescriptorDelete() { }

        public TeachingCredentialBasisDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TeachingCredentialDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialDescriptorGetByExample
    {
        public int TeachingCredentialDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TeachingCredentialDescriptorGetByIds() { }

        public TeachingCredentialDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialDescriptorPost : Resources.TeachingCredentialDescriptor.EdFi.TeachingCredentialDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialDescriptorPut : Resources.TeachingCredentialDescriptor.EdFi.TeachingCredentialDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TeachingCredentialDescriptorDelete : IHasIdentifier
    {
        public TeachingCredentialDescriptorDelete() { }

        public TeachingCredentialDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TechnicalSkillsAssessmentDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TechnicalSkillsAssessmentDescriptorGetByExample
    {
        public int TechnicalSkillsAssessmentDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TechnicalSkillsAssessmentDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TechnicalSkillsAssessmentDescriptorGetByIds() { }

        public TechnicalSkillsAssessmentDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TechnicalSkillsAssessmentDescriptorPost : Resources.TechnicalSkillsAssessmentDescriptor.EdFi.TechnicalSkillsAssessmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TechnicalSkillsAssessmentDescriptorPut : Resources.TechnicalSkillsAssessmentDescriptor.EdFi.TechnicalSkillsAssessmentDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TechnicalSkillsAssessmentDescriptorDelete : IHasIdentifier
    {
        public TechnicalSkillsAssessmentDescriptorDelete() { }

        public TechnicalSkillsAssessmentDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TelephoneNumberTypeDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TelephoneNumberTypeDescriptorGetByExample
    {
        public int TelephoneNumberTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TelephoneNumberTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TelephoneNumberTypeDescriptorGetByIds() { }

        public TelephoneNumberTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TelephoneNumberTypeDescriptorPost : Resources.TelephoneNumberTypeDescriptor.EdFi.TelephoneNumberTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TelephoneNumberTypeDescriptorPut : Resources.TelephoneNumberTypeDescriptor.EdFi.TelephoneNumberTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TelephoneNumberTypeDescriptorDelete : IHasIdentifier
    {
        public TelephoneNumberTypeDescriptorDelete() { }

        public TelephoneNumberTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TermDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TermDescriptorGetByExample
    {
        public int TermDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TermDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TermDescriptorGetByIds() { }

        public TermDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TermDescriptorPost : Resources.TermDescriptor.EdFi.TermDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TermDescriptorPut : Resources.TermDescriptor.EdFi.TermDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TermDescriptorDelete : IHasIdentifier
    {
        public TermDescriptorDelete() { }

        public TermDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TitleIPartAParticipantDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TitleIPartAParticipantDescriptorGetByExample
    {
        public int TitleIPartAParticipantDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAParticipantDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TitleIPartAParticipantDescriptorGetByIds() { }

        public TitleIPartAParticipantDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAParticipantDescriptorPost : Resources.TitleIPartAParticipantDescriptor.EdFi.TitleIPartAParticipantDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAParticipantDescriptorPut : Resources.TitleIPartAParticipantDescriptor.EdFi.TitleIPartAParticipantDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAParticipantDescriptorDelete : IHasIdentifier
    {
        public TitleIPartAParticipantDescriptorDelete() { }

        public TitleIPartAParticipantDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TitleIPartAProgramServiceDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TitleIPartAProgramServiceDescriptorGetByExample
    {
        public int TitleIPartAProgramServiceDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAProgramServiceDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TitleIPartAProgramServiceDescriptorGetByIds() { }

        public TitleIPartAProgramServiceDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAProgramServiceDescriptorPost : Resources.TitleIPartAProgramServiceDescriptor.EdFi.TitleIPartAProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAProgramServiceDescriptorPut : Resources.TitleIPartAProgramServiceDescriptor.EdFi.TitleIPartAProgramServiceDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartAProgramServiceDescriptorDelete : IHasIdentifier
    {
        public TitleIPartAProgramServiceDescriptorDelete() { }

        public TitleIPartAProgramServiceDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TitleIPartASchoolDesignationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TitleIPartASchoolDesignationDescriptorGetByExample
    {
        public int TitleIPartASchoolDesignationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartASchoolDesignationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TitleIPartASchoolDesignationDescriptorGetByIds() { }

        public TitleIPartASchoolDesignationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartASchoolDesignationDescriptorPost : Resources.TitleIPartASchoolDesignationDescriptor.EdFi.TitleIPartASchoolDesignationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartASchoolDesignationDescriptorPut : Resources.TitleIPartASchoolDesignationDescriptor.EdFi.TitleIPartASchoolDesignationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TitleIPartASchoolDesignationDescriptorDelete : IHasIdentifier
    {
        public TitleIPartASchoolDesignationDescriptorDelete() { }

        public TitleIPartASchoolDesignationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.TribalAffiliationDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class TribalAffiliationDescriptorGetByExample
    {
        public int TribalAffiliationDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TribalAffiliationDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public TribalAffiliationDescriptorGetByIds() { }

        public TribalAffiliationDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TribalAffiliationDescriptorPost : Resources.TribalAffiliationDescriptor.EdFi.TribalAffiliationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TribalAffiliationDescriptorPut : Resources.TribalAffiliationDescriptor.EdFi.TribalAffiliationDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class TribalAffiliationDescriptorDelete : IHasIdentifier
    {
        public TribalAffiliationDescriptorDelete() { }

        public TribalAffiliationDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.VisaDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class VisaDescriptorGetByExample
    {
        public int VisaDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class VisaDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public VisaDescriptorGetByIds() { }

        public VisaDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class VisaDescriptorPost : Resources.VisaDescriptor.EdFi.VisaDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class VisaDescriptorPut : Resources.VisaDescriptor.EdFi.VisaDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class VisaDescriptorDelete : IHasIdentifier
    {
        public VisaDescriptorDelete() { }

        public VisaDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.WeaponDescriptors.EdFi
{

    [ExcludeFromCodeCoverage]
    public class WeaponDescriptorGetByExample
    {
        public int WeaponDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class WeaponDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public WeaponDescriptorGetByIds() { }

        public WeaponDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class WeaponDescriptorPost : Resources.WeaponDescriptor.EdFi.WeaponDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class WeaponDescriptorPut : Resources.WeaponDescriptor.EdFi.WeaponDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class WeaponDescriptorDelete : IHasIdentifier
    {
        public WeaponDescriptorDelete() { }

        public WeaponDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}


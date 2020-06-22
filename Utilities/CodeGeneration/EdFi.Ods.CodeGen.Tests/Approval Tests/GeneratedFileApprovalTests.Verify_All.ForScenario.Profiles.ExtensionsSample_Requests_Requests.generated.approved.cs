using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Api.Architecture;

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_IncludeOnly
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-IncludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_Entity_Extension_IncludeOnly_Writable.Staff
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

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Staff_Entity_Extension_ExcludeOnly
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Entity-Extension-ExcludeOnly.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_Entity_Extension_ExcludeOnly_Writable.Staff
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

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Staff_Include_All
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_Include_All_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_Include_All_Writable.Staff
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

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedInclude
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_and_Prospect_MixedInclude_Writable.Staff
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

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedInclude
{

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string BusId { get; set; }
        public string BusRouteDirection { get; set; }
        public int BusRouteDuration { get; set; }
        public int BusRouteNumber { get; set; }
        public bool Daily { get; set; }
        public string DisabilityDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ExpectedTransitTime { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public decimal OperatingCost { get; set; }
        public decimal OptimalCapacity { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal WeeklyMileage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByIds : IHasIdentifiers<Guid>
    {
        public BusRouteGetByIds() { }

        public BusRouteGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.Staff_and_Prospect_MixedInclude_Writable.BusRoute
    {
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.Staff-and-Prospect-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.Staff_and_Prospect_MixedInclude_Writable.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteDelete : IHasIdentifier
    {
        public BusRouteDelete() { }

        public BusRouteDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude
{

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string BusId { get; set; }
        public string BusRouteDirection { get; set; }
        public int BusRouteDuration { get; set; }
        public int BusRouteNumber { get; set; }
        public bool Daily { get; set; }
        public string DisabilityDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ExpectedTransitTime { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public decimal OperatingCost { get; set; }
        public decimal OptimalCapacity { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal WeeklyMileage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByIds : IHasIdentifiers<Guid>
    {
        public BusRouteGetByIds() { }

        public BusRouteGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.BusRoute-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.BusRoute_MixedInclude_Writable.BusRoute
    {
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.BusRoute-MixedInclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.BusRoute_MixedInclude_Writable.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteDelete : IHasIdentifier
    {
        public BusRouteDelete() { }

        public BusRouteDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude_Writable.Staff
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

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude
{

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string BusId { get; set; }
        public string BusRouteDirection { get; set; }
        public int BusRouteDuration { get; set; }
        public int BusRouteNumber { get; set; }
        public bool Daily { get; set; }
        public string DisabilityDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ExpectedTransitTime { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public decimal OperatingCost { get; set; }
        public decimal OptimalCapacity { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal WeeklyMileage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByIds : IHasIdentifiers<Guid>
    {
        public BusRouteGetByIds() { }

        public BusRouteGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude_Writable.BusRoute
    {
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.Staff-and-Prospect-MixedExclude.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude_Writable.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteDelete : IHasIdentifier
    {
        public BusRouteDelete() { }

        public BusRouteDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Staffs.EdFi.Staff_and_Prospect_MixedExclude2
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

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPost : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff
    {
    }

    [ProfileContentType("application/vnd.ed-fi.staff.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StaffPut : Resources.Staff.EdFi.Staff_and_Prospect_MixedExclude2_Writable.Staff
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

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes.Staff_and_Prospect_MixedExclude2
{

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string BusId { get; set; }
        public string BusRouteDirection { get; set; }
        public int BusRouteDuration { get; set; }
        public int BusRouteNumber { get; set; }
        public bool Daily { get; set; }
        public string DisabilityDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ExpectedTransitTime { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public decimal OperatingCost { get; set; }
        public decimal OptimalCapacity { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal WeeklyMileage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByIds : IHasIdentifiers<Guid>
    {
        public BusRouteGetByIds() { }

        public BusRouteGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude2_Writable.BusRoute
    {
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.Staff-and-Prospect-MixedExclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.Staff_and_Prospect_MixedExclude2_Writable.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteDelete : IHasIdentifier
    {
        public BusRouteDelete() { }

        public BusRouteDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude2
{

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string BusId { get; set; }
        public string BusRouteDirection { get; set; }
        public int BusRouteDuration { get; set; }
        public int BusRouteNumber { get; set; }
        public bool Daily { get; set; }
        public string DisabilityDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ExpectedTransitTime { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public decimal OperatingCost { get; set; }
        public decimal OptimalCapacity { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal WeeklyMileage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByIds : IHasIdentifiers<Guid>
    {
        public BusRouteGetByIds() { }

        public BusRouteGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.BusRoute-MixedInclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.BusRoute_MixedInclude2_Writable.BusRoute
    {
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.BusRoute-MixedInclude2.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.BusRoute_MixedInclude2_Writable.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteDelete : IHasIdentifier
    {
        public BusRouteDelete() { }

        public BusRouteDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes.BusRoute_MixedInclude1
{

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByExample
    {
        public DateTime BeginDate { get; set; }
        public string BusId { get; set; }
        public string BusRouteDirection { get; set; }
        public int BusRouteDuration { get; set; }
        public int BusRouteNumber { get; set; }
        public bool Daily { get; set; }
        public string DisabilityDescriptor { get; set; }
        public int EducationOrganizationId { get; set; }
        public string ExpectedTransitTime { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public decimal OperatingCost { get; set; }
        public decimal OptimalCapacity { get; set; }
        public string StaffClassificationDescriptor { get; set; }
        public string StaffUniqueId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal WeeklyMileage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteGetByIds : IHasIdentifiers<Guid>
    {
        public BusRouteGetByIds() { }

        public BusRouteGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.BusRoute-MixedInclude1.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.BusRoute_MixedInclude1_Writable.BusRoute
    {
    }

    [ProfileContentType("application/vnd.ed-fi.busRoute.BusRoute-MixedInclude1.writable+json")]
    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.BusRoute_MixedInclude1_Writable.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRouteDelete : IHasIdentifier
    {
        public BusRouteDelete() { }

        public BusRouteDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Students.EdFi.Student_Include_All
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

    [ProfileContentType("application/vnd.ed-fi.student.Student-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPost : Resources.Student.EdFi.Student_Include_All_Writable.Student
    {
    }

    [ProfileContentType("application/vnd.ed-fi.student.Student-Include-All.writable+json")]
    [ExcludeFromCodeCoverage]
    public class StudentPut : Resources.Student.EdFi.Student_Include_All_Writable.Student
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


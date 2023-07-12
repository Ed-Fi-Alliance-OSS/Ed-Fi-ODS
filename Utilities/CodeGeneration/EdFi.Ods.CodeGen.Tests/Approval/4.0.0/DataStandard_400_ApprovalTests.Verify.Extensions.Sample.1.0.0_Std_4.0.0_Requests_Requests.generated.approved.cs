using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Attributes;

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.ArtMediumDescriptors
{

    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorGetByExample
    {
        public int ArtMediumDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public ArtMediumDescriptorGetByIds() { }

        public ArtMediumDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorPost : Resources.ArtMediumDescriptor.Sample.ArtMediumDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorPut : Resources.ArtMediumDescriptor.Sample.ArtMediumDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class ArtMediumDescriptorDelete : IHasIdentifier
    {
        public ArtMediumDescriptorDelete() { }

        public ArtMediumDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.Buses
{

    [ExcludeFromCodeCoverage]
    public class BusGetByExample
    {
        public string BusId { get; set; }
        public Guid Id { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusGetByIds : IHasIdentifiers<Guid>
    {
        public BusGetByIds() { }

        public BusGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class BusPost : Resources.Bus.Sample.Bus
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusPut : Resources.Bus.Sample.Bus
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusDelete : IHasIdentifier
    {
        public BusDelete() { }

        public BusDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.BusRoutes
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

    [ExcludeFromCodeCoverage]
    public class BusRoutePost : Resources.BusRoute.Sample.BusRoute
    {
    }

    [ExcludeFromCodeCoverage]
    public class BusRoutePut : Resources.BusRoute.Sample.BusRoute
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

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.FavoriteBookCategoryDescriptors
{

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorGetByExample
    {
        public int FavoriteBookCategoryDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public FavoriteBookCategoryDescriptorGetByIds() { }

        public FavoriteBookCategoryDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorPost : Resources.FavoriteBookCategoryDescriptor.Sample.FavoriteBookCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorPut : Resources.FavoriteBookCategoryDescriptor.Sample.FavoriteBookCategoryDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class FavoriteBookCategoryDescriptorDelete : IHasIdentifier
    {
        public FavoriteBookCategoryDescriptorDelete() { }

        public FavoriteBookCategoryDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.MembershipTypeDescriptors
{

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorGetByExample
    {
        public int MembershipTypeDescriptorId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorGetByIds : IHasIdentifiers<Guid>
    {
        public MembershipTypeDescriptorGetByIds() { }

        public MembershipTypeDescriptorGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorPost : Resources.MembershipTypeDescriptor.Sample.MembershipTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorPut : Resources.MembershipTypeDescriptor.Sample.MembershipTypeDescriptor
    {
    }

    [ExcludeFromCodeCoverage]
    public class MembershipTypeDescriptorDelete : IHasIdentifier
    {
        public MembershipTypeDescriptorDelete() { }

        public MembershipTypeDescriptorDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.StudentArtProgramAssociations
{

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationGetByExample
    {
        public int ArtPieces { get; set; }
        public DateTime BeginDate { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime ExhibitDate { get; set; }
        public decimal HoursPerDay { get; set; }
        public string IdentificationCode { get; set; }
        public TimeSpan KilnReservation { get; set; }
        public string KilnReservationLength { get; set; }
        public decimal MasteredMediums { get; set; }
        public decimal NumberOfDaysInAttendance { get; set; }
        public int PortfolioPieces { get; set; }
        public bool PrivateArtProgram { get; set; }
        public int ProgramEducationOrganizationId { get; set; }
        public decimal ProgramFees { get; set; }
        public string ProgramName { get; set; }
        public string ProgramTypeDescriptor { get; set; }
        public string StudentUniqueId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentArtProgramAssociationGetByIds() { }

        public StudentArtProgramAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationPost : Resources.StudentArtProgramAssociation.Sample.StudentArtProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationPut : Resources.StudentArtProgramAssociation.Sample.StudentArtProgramAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentArtProgramAssociationDelete : IHasIdentifier
    {
        public StudentArtProgramAssociationDelete() { }

        public StudentArtProgramAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

namespace EdFi.Ods.Api.Common.Models.Requests.Sample.StudentGraduationPlanAssociations
{

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationGetByExample
    {
        public TimeSpan CommencementTime { get; set; }
        public int EducationOrganizationId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal GraduationFee { get; set; }
        public string GraduationPlanTypeDescriptor { get; set; }
        public short GraduationSchoolYear { get; set; }
        public string HighSchoolDuration { get; set; }
        public decimal HoursPerWeek { get; set; }
        public Guid Id { get; set; }
        public bool IsActivePlan { get; set; }
        public decimal RequiredAttendance { get; set; }
        public string StaffUniqueId { get; set; }
        public string StudentUniqueId { get; set; }
        public decimal TargetGPA { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationGetByIds : IHasIdentifiers<Guid>
    {
        public StudentGraduationPlanAssociationGetByIds() { }

        public StudentGraduationPlanAssociationGetByIds(params Guid[] ids)
        {
            Ids = new List<Guid>(ids);
        }

        public List<Guid> Ids { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationPost : Resources.StudentGraduationPlanAssociation.Sample.StudentGraduationPlanAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationPut : Resources.StudentGraduationPlanAssociation.Sample.StudentGraduationPlanAssociation
    {
    }

    [ExcludeFromCodeCoverage]
    public class StudentGraduationPlanAssociationDelete : IHasIdentifier
    {
        public StudentGraduationPlanAssociationDelete() { }

        public StudentGraduationPlanAssociationDelete(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}


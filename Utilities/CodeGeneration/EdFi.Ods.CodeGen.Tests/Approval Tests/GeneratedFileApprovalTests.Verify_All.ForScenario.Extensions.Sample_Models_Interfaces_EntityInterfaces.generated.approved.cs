using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;

#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.Sample
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ArtMediumDescriptor model.
    /// </summary>
    public interface IArtMediumDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int ArtMediumDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Bus model.
    /// </summary>
    public interface IBus : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string BusId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRoute model.
    /// </summary>
    public interface IBusRoute : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string BusId { get; set; }
        [NaturalKeyMember]
        int BusRouteNumber { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        string BusRouteDirection { get; set; }
        int? BusRouteDuration { get; set; }
        bool? Daily { get; set; }
        string DisabilityDescriptor { get; set; }
        int? EducationOrganizationId { get; set; }
        string ExpectedTransitTime { get; set; }
        decimal HoursPerWeek { get; set; }
        decimal OperatingCost { get; set; }
        decimal? OptimalCapacity { get; set; }
        string StaffClassificationDescriptor { get; set; }
        string StaffUniqueId { get; set; }
        DateTime? StartDate { get; set; }
        decimal? WeeklyMileage { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IBusRouteBusYear> BusRouteBusYears { get; set; }
        ICollection<IBusRouteProgram> BusRoutePrograms { get; set; }
        ICollection<IBusRouteServiceAreaPostalCode> BusRouteServiceAreaPostalCodes { get; set; }
        ICollection<IBusRouteStartTime> BusRouteStartTimes { get; set; }
        ICollection<IBusRouteTelephone> BusRouteTelephones { get; set; }

        // Resource reference data
        Guid? StaffEducationOrganizationAssignmentAssociationResourceId { get; set; }
        string StaffEducationOrganizationAssignmentAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteBusYear model.
    /// </summary>
    public interface IBusRouteBusYear : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBusRoute BusRoute { get; set; }
        [NaturalKeyMember]
        short BusYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteProgram model.
    /// </summary>
    public interface IBusRouteProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBusRoute BusRoute { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteServiceAreaPostalCode model.
    /// </summary>
    public interface IBusRouteServiceAreaPostalCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBusRoute BusRoute { get; set; }
        [NaturalKeyMember]
        string ServiceAreaPostalCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteStartTime model.
    /// </summary>
    public interface IBusRouteStartTime : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBusRoute BusRoute { get; set; }
        [NaturalKeyMember]
        TimeSpan StartTime { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteTelephone model.
    /// </summary>
    public interface IBusRouteTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IBusRoute BusRoute { get; set; }
        [NaturalKeyMember]
        string TelephoneNumber { get; set; }
        [NaturalKeyMember]
        string TelephoneNumberTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FavoriteBookCategoryDescriptor model.
    /// </summary>
    public interface IFavoriteBookCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int FavoriteBookCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MembershipTypeDescriptor model.
    /// </summary>
    public interface IMembershipTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int MembershipTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAddressExtension model.
    /// </summary>
    public interface IParentAddressExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IParentAddress ParentAddress { get; set; }

        // Non-PK properties
        string Complex { get; set; }
        bool OnBusRoute { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IParentAddressSchoolDistrict> ParentAddressSchoolDistricts { get; set; }
        ICollection<IParentAddressTerm> ParentAddressTerms { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAddressSchoolDistrict model.
    /// </summary>
    public interface IParentAddressSchoolDistrict : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentAddressExtension ParentAddressExtension { get; set; }
        [NaturalKeyMember]
        string SchoolDistrict { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAddressTerm model.
    /// </summary>
    public interface IParentAddressTerm : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentAddressExtension ParentAddressExtension { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAuthor model.
    /// </summary>
    public interface IParentAuthor : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }
        [NaturalKeyMember]
        string Author { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentCeilingHeight model.
    /// </summary>
    public interface IParentCeilingHeight : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }
        [NaturalKeyMember]
        decimal CeilingHeight { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentCTEProgram model.
    /// </summary>
    public interface IParentCTEProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }

        // Non-PK properties
        string CareerPathwayDescriptor { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentEducationContent model.
    /// </summary>
    public interface IParentEducationContent : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }
        [NaturalKeyMember]
        string ContentIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationContentResourceId { get; set; }
        string EducationContentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentExtension model.
    /// </summary>
    public interface IParentExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IParent Parent { get; set; }

        // Non-PK properties
        string AverageCarLineWait { get; set; }
        short? BecameParent { get; set; }
        decimal? CoffeeSpend { get; set; }
        string CredentialFieldDescriptor { get; set; }
        int? Duration { get; set; }
        decimal? GPA { get; set; }
        DateTime? GraduationDate { get; set; }
        bool IsSportsFan { get; set; }
        int? LuckyNumber { get; set; }
        TimeSpan? PreferredWakeUpTime { get; set; }
        decimal? RainCertainty { get; set; }

        // One-to-one relationships

        IParentCTEProgram ParentCTEProgram { get; set; }

        IParentTeacherConference ParentTeacherConference { get; set; }

        // Lists
        ICollection<IParentAuthor> ParentAuthors { get; set; }
        ICollection<IParentCeilingHeight> ParentCeilingHeights { get; set; }
        ICollection<IParentEducationContent> ParentEducationContents { get; set; }
        ICollection<IParentFavoriteBookTitle> ParentFavoriteBookTitles { get; set; }
        ICollection<IParentStudentProgramAssociation> ParentStudentProgramAssociations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentFavoriteBookTitle model.
    /// </summary>
    public interface IParentFavoriteBookTitle : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }
        [NaturalKeyMember]
        string FavoriteBookTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentStudentProgramAssociation model.
    /// </summary>
    public interface IParentStudentProgramAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        int ProgramEducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string ProgramName { get; set; }
        [NaturalKeyMember]
        string ProgramTypeDescriptor { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentProgramAssociationResourceId { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentTeacherConference model.
    /// </summary>
    public interface IParentTeacherConference : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParentExtension ParentExtension { get; set; }

        // Non-PK properties
        string DayOfWeek { get; set; }
        TimeSpan EndTime { get; set; }
        TimeSpan StartTime { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolCTEProgram model.
    /// </summary>
    public interface ISchoolCTEProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISchoolExtension SchoolExtension { get; set; }

        // Non-PK properties
        string CareerPathwayDescriptor { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolDirectlyOwnedBus model.
    /// </summary>
    public interface ISchoolDirectlyOwnedBus : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISchoolExtension SchoolExtension { get; set; }
        [NaturalKeyMember]
        string DirectlyOwnedBusId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? DirectlyOwnedBusResourceId { get; set; }
        string DirectlyOwnedBusDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolExtension model.
    /// </summary>
    public interface ISchoolExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.ISchool School { get; set; }

        // Non-PK properties
        bool? IsExemplary { get; set; }

        // One-to-one relationships

        ISchoolCTEProgram SchoolCTEProgram { get; set; }

        // Lists
        ICollection<ISchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffExtension model.
    /// </summary>
    public interface IStaffExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStaff Staff { get; set; }

        // Non-PK properties
        DateTime? FirstPetOwnedDate { get; set; }

        // One-to-one relationships

        IStaffPetPreference StaffPetPreference { get; set; }

        // Lists
        ICollection<IStaffPet> StaffPets { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffPet model.
    /// </summary>
    public interface IStaffPet : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }
        [NaturalKeyMember]
        string PetName { get; set; }

        // Non-PK properties
        bool? IsFixed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffPetPreference model.
    /// </summary>
    public interface IStaffPetPreference : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaffExtension StaffExtension { get; set; }

        // Non-PK properties
        int MaximumWeight { get; set; }
        int MinimumWeight { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAquaticPet model.
    /// </summary>
    public interface IStudentAquaticPet : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentExtension StudentExtension { get; set; }
        [NaturalKeyMember]
        int MimimumTankVolume { get; set; }
        [NaturalKeyMember]
        string PetName { get; set; }

        // Non-PK properties
        bool? IsFixed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociation model.
    /// </summary>
    public interface IStudentArtProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        int? ArtPieces { get; set; }
        DateTime? ExhibitDate { get; set; }
        decimal? HoursPerDay { get; set; }
        string IdentificationCode { get; set; }
        TimeSpan? KilnReservation { get; set; }
        string KilnReservationLength { get; set; }
        decimal? MasteredMediums { get; set; }
        decimal? NumberOfDaysInAttendance { get; set; }
        int? PortfolioPieces { get; set; }
        bool PrivateArtProgram { get; set; }
        decimal? ProgramFees { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentArtProgramAssociationArtMedium> StudentArtProgramAssociationArtMedia { get; set; }
        ICollection<IStudentArtProgramAssociationPortfolioYears> StudentArtProgramAssociationPortfolioYears { get; set; }
        ICollection<IStudentArtProgramAssociationService> StudentArtProgramAssociationServices { get; set; }
        ICollection<IStudentArtProgramAssociationStyle> StudentArtProgramAssociationStyles { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationArtMedium model.
    /// </summary>
    public interface IStudentArtProgramAssociationArtMedium : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        [NaturalKeyMember]
        string ArtMediumDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationPortfolioYears model.
    /// </summary>
    public interface IStudentArtProgramAssociationPortfolioYears : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        [NaturalKeyMember]
        short PortfolioYears { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationService model.
    /// </summary>
    public interface IStudentArtProgramAssociationService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        [NaturalKeyMember]
        string ServiceDescriptor { get; set; }

        // Non-PK properties
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationStyle model.
    /// </summary>
    public interface IStudentArtProgramAssociationStyle : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        [NaturalKeyMember]
        string Style { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCTEProgramAssociationExtension model.
    /// </summary>
    public interface IStudentCTEProgramAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }

        // Non-PK properties
        bool? AnalysisCompleted { get; set; }
        DateTime? AnalysisDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressExtension model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentEducationOrganizationAssociationAddress StudentEducationOrganizationAssociationAddress { get; set; }

        // Non-PK properties
        string Complex { get; set; }
        bool OnBusRoute { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationAddressSchoolDistrict> StudentEducationOrganizationAssociationAddressSchoolDistricts { get; set; }
        ICollection<IStudentEducationOrganizationAssociationAddressTerm> StudentEducationOrganizationAssociationAddressTerms { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressSchoolDistrict model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressSchoolDistrict : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationAddressExtension StudentEducationOrganizationAssociationAddressExtension { get; set; }
        [NaturalKeyMember]
        string SchoolDistrict { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressTerm model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressTerm : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationAddressExtension StudentEducationOrganizationAssociationAddressExtension { get; set; }
        [NaturalKeyMember]
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentCharacteristicExtension model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic StudentEducationOrganizationAssociationStudentCharacteristic { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentEducationOrganizationAssociationStudentCharacteristicExtension StudentEducationOrganizationAssociationStudentCharacteristicExtension { get; set; }
        [NaturalKeyMember]
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        bool? PrimaryStudentNeedIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentExtension model.
    /// </summary>
    public interface IStudentExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudent Student { get; set; }

        // Non-PK properties

        // One-to-one relationships

        IStudentPetPreference StudentPetPreference { get; set; }

        // Lists
        ICollection<IStudentAquaticPet> StudentAquaticPets { get; set; }
        ICollection<IStudentFavoriteBook> StudentFavoriteBooks { get; set; }
        ICollection<IStudentPet> StudentPets { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentFavoriteBook model.
    /// </summary>
    public interface IStudentFavoriteBook : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentExtension StudentExtension { get; set; }
        [NaturalKeyMember]
        string FavoriteBookCategoryDescriptor { get; set; }

        // Non-PK properties
        string BookTitle { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentFavoriteBookArtMedium> StudentFavoriteBookArtMedia { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentFavoriteBookArtMedium model.
    /// </summary>
    public interface IStudentFavoriteBookArtMedium : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentFavoriteBook StudentFavoriteBook { get; set; }
        [NaturalKeyMember]
        string ArtMediumDescriptor { get; set; }

        // Non-PK properties
        int? ArtPieces { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociation model.
    /// </summary>
    public interface IStudentGraduationPlanAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string GraduationPlanTypeDescriptor { get; set; }
        [NaturalKeyMember]
        short GraduationSchoolYear { get; set; }
        [NaturalKeyMember]
        string StudentUniqueId { get; set; }

        // Non-PK properties
        TimeSpan? CommencementTime { get; set; }
        DateTime EffectiveDate { get; set; }
        decimal? GraduationFee { get; set; }
        string HighSchoolDuration { get; set; }
        decimal HoursPerWeek { get; set; }
        bool? IsActivePlan { get; set; }
        decimal? RequiredAttendance { get; set; }
        string StaffUniqueId { get; set; }
        decimal TargetGPA { get; set; }

        // One-to-one relationships

        IStudentGraduationPlanAssociationCTEProgram StudentGraduationPlanAssociationCTEProgram { get; set; }

        // Lists
        ICollection<IStudentGraduationPlanAssociationAcademicSubject> StudentGraduationPlanAssociationAcademicSubjects { get; set; }
        ICollection<IStudentGraduationPlanAssociationCareerPathwayCode> StudentGraduationPlanAssociationCareerPathwayCodes { get; set; }
        ICollection<IStudentGraduationPlanAssociationDescription> StudentGraduationPlanAssociationDescriptions { get; set; }
        ICollection<IStudentGraduationPlanAssociationDesignatedBy> StudentGraduationPlanAssociationDesignatedBies { get; set; }
        ICollection<IStudentGraduationPlanAssociationIndustryCredential> StudentGraduationPlanAssociationIndustryCredentials { get; set; }
        ICollection<IStudentGraduationPlanAssociationStudentParentAssociation> StudentGraduationPlanAssociationStudentParentAssociations { get; set; }
        ICollection<IStudentGraduationPlanAssociationYearsAttended> StudentGraduationPlanAssociationYearsAttendeds { get; set; }

        // Resource reference data
        Guid? GraduationPlanResourceId { get; set; }
        string GraduationPlanDiscriminator { get; set; }
        Guid? StaffResourceId { get; set; }
        string StaffDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationAcademicSubject model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationCareerPathwayCode model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationCareerPathwayCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        int CareerPathwayCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationCTEProgram model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationCTEProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        // Non-PK properties
        string CareerPathwayDescriptor { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationDescription model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationDescription : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        string Description { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationDesignatedBy model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationDesignatedBy : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        string DesignatedBy { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationIndustryCredential model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationIndustryCredential : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        string IndustryCredential { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationStudentParentAssociation model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationStudentParentAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        string ParentUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentParentAssociationResourceId { get; set; }
        string StudentParentAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationYearsAttended model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationYearsAttended : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        [NaturalKeyMember]
        short YearsAttended { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationDiscipline model.
    /// </summary>
    public interface IStudentParentAssociationDiscipline : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentParentAssociationExtension StudentParentAssociationExtension { get; set; }
        [NaturalKeyMember]
        string DisciplineDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationExtension model.
    /// </summary>
    public interface IStudentParentAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentParentAssociation StudentParentAssociation { get; set; }

        // Non-PK properties
        bool BedtimeReader { get; set; }
        decimal? BedtimeReadingRate { get; set; }
        decimal? BookBudget { get; set; }
        int? BooksBorrowed { get; set; }
        int? EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int? LibraryDuration { get; set; }
        TimeSpan? LibraryTime { get; set; }
        short? LibraryVisits { get; set; }
        string PriorContactRestrictions { get; set; }
        DateTime? ReadGreenEggsAndHamDate { get; set; }
        string ReadingTimeSpent { get; set; }
        short? StudentRead { get; set; }

        // One-to-one relationships

        IStudentParentAssociationTelephone StudentParentAssociationTelephone { get; set; }

        // Lists
        ICollection<IStudentParentAssociationDiscipline> StudentParentAssociationDisciplines { get; set; }
        ICollection<IStudentParentAssociationFavoriteBookTitle> StudentParentAssociationFavoriteBookTitles { get; set; }
        ICollection<IStudentParentAssociationHoursPerWeek> StudentParentAssociationHoursPerWeeks { get; set; }
        ICollection<IStudentParentAssociationPagesRead> StudentParentAssociationPagesReads { get; set; }
        ICollection<IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation> StudentParentAssociationStaffEducationOrganizationEmploymentAssociations { get; set; }

        // Resource reference data
        Guid? InterventionStudyResourceId { get; set; }
        string InterventionStudyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationFavoriteBookTitle model.
    /// </summary>
    public interface IStudentParentAssociationFavoriteBookTitle : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentParentAssociationExtension StudentParentAssociationExtension { get; set; }
        [NaturalKeyMember]
        string FavoriteBookTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationHoursPerWeek model.
    /// </summary>
    public interface IStudentParentAssociationHoursPerWeek : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentParentAssociationExtension StudentParentAssociationExtension { get; set; }
        [NaturalKeyMember]
        decimal HoursPerWeek { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationPagesRead model.
    /// </summary>
    public interface IStudentParentAssociationPagesRead : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentParentAssociationExtension StudentParentAssociationExtension { get; set; }
        [NaturalKeyMember]
        decimal PagesRead { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationStaffEducationOrganizationEmploymentAssociation model.
    /// </summary>
    public interface IStudentParentAssociationStaffEducationOrganizationEmploymentAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentParentAssociationExtension StudentParentAssociationExtension { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }
        [NaturalKeyMember]
        string EmploymentStatusDescriptor { get; set; }
        [NaturalKeyMember]
        DateTime HireDate { get; set; }
        [NaturalKeyMember]
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffEducationOrganizationEmploymentAssociationResourceId { get; set; }
        string StaffEducationOrganizationEmploymentAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentParentAssociationTelephone model.
    /// </summary>
    public interface IStudentParentAssociationTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentParentAssociationExtension StudentParentAssociationExtension { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        string TelephoneNumber { get; set; }
        string TelephoneNumberTypeDescriptor { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentPet model.
    /// </summary>
    public interface IStudentPet : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentExtension StudentExtension { get; set; }
        [NaturalKeyMember]
        string PetName { get; set; }

        // Non-PK properties
        bool? IsFixed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentPetPreference model.
    /// </summary>
    public interface IStudentPetPreference : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudentExtension StudentExtension { get; set; }

        // Non-PK properties
        int MaximumWeight { get; set; }
        int MinimumWeight { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAssociationExtension model.
    /// </summary>
    public interface IStudentSchoolAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentSchoolAssociation StudentSchoolAssociation { get; set; }

        // Non-PK properties
        string MembershipTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }
}

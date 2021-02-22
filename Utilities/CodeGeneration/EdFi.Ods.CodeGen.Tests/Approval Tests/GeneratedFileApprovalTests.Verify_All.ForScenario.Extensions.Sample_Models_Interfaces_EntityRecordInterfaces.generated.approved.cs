using System;


namespace EdFi.Ods.Entities.Common.Records.Sample
{ 

    /// <summary>
    /// Interface for the sample.ArtMediumDescriptor table of the ArtMediumDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IArtMediumDescriptorRecord
    {     
        // Properties for all columns in physical table
        int ArtMediumDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.Bus table of the Bus aggregate in the Ods Database.
    /// </summary>
    public interface IBusRecord
    {     
        // Properties for all columns in physical table
        string BusId { get; set; }
        Guid Id { get; set; }
    }

    /// <summary>
    /// Interface for the sample.BusRoute table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    public interface IBusRouteRecord
    {     
        // Properties for all columns in physical table
        DateTime? BeginDate { get; set; }
        string BusId { get; set; }
        string BusRouteDirection { get; set; }
        int? BusRouteDuration { get; set; }
        int BusRouteNumber { get; set; }
        bool? Daily { get; set; }
        int? DisabilityDescriptorId { get; set; }
        int? EducationOrganizationId { get; set; }
        string ExpectedTransitTime { get; set; }
        decimal HoursPerWeek { get; set; }
        Guid Id { get; set; }
        decimal OperatingCost { get; set; }
        decimal? OptimalCapacity { get; set; }
        int? StaffClassificationDescriptorId { get; set; }
        int? StaffUSI { get; set; }
        DateTime? StartDate { get; set; }
        decimal? WeeklyMileage { get; set; }
    }

    /// <summary>
    /// Interface for the sample.BusRouteBusYear table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    public interface IBusRouteBusYearRecord
    {     
        // Properties for all columns in physical table
        string BusId { get; set; }
        int BusRouteNumber { get; set; }
        short BusYear { get; set; }
    }

    /// <summary>
    /// Interface for the sample.BusRouteProgram table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    public interface IBusRouteProgramRecord
    {     
        // Properties for all columns in physical table
        string BusId { get; set; }
        int BusRouteNumber { get; set; }
        int EducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.BusRouteServiceAreaPostalCode table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    public interface IBusRouteServiceAreaPostalCodeRecord
    {     
        // Properties for all columns in physical table
        string BusId { get; set; }
        int BusRouteNumber { get; set; }
        string ServiceAreaPostalCode { get; set; }
    }

    /// <summary>
    /// Interface for the sample.BusRouteStartTime table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    public interface IBusRouteStartTimeRecord
    {     
        // Properties for all columns in physical table
        string BusId { get; set; }
        int BusRouteNumber { get; set; }
        TimeSpan StartTime { get; set; }
    }

    /// <summary>
    /// Interface for the sample.BusRouteTelephone table of the BusRoute aggregate in the Ods Database.
    /// </summary>
    public interface IBusRouteTelephoneRecord
    {     
        // Properties for all columns in physical table
        string BusId { get; set; }
        int BusRouteNumber { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the sample.FavoriteBookCategoryDescriptor table of the FavoriteBookCategoryDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IFavoriteBookCategoryDescriptorRecord
    {     
        // Properties for all columns in physical table
        int FavoriteBookCategoryDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.MembershipTypeDescriptor table of the MembershipTypeDescriptor aggregate in the Ods Database.
    /// </summary>
    public interface IMembershipTypeDescriptorRecord
    {     
        // Properties for all columns in physical table
        int MembershipTypeDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentAddressExtension table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAddressExtensionRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string City { get; set; }
        string Complex { get; set; }
        bool OnBusRoute { get; set; }
        int ParentUSI { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentAddressSchoolDistrict table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAddressSchoolDistrictRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string City { get; set; }
        int ParentUSI { get; set; }
        string PostalCode { get; set; }
        string SchoolDistrict { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentAddressTerm table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAddressTermRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string City { get; set; }
        int ParentUSI { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentAuthor table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAuthorRecord
    {     
        // Properties for all columns in physical table
        string Author { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentCeilingHeight table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentCeilingHeightRecord
    {     
        // Properties for all columns in physical table
        decimal CeilingHeight { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentCTEProgram table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentCTEProgramRecord
    {     
        // Properties for all columns in physical table
        int CareerPathwayDescriptorId { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        int ParentUSI { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentEducationContent table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentEducationContentRecord
    {     
        // Properties for all columns in physical table
        string ContentIdentifier { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentExtension table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentExtensionRecord
    {     
        // Properties for all columns in physical table
        string AverageCarLineWait { get; set; }
        short? BecameParent { get; set; }
        decimal? CoffeeSpend { get; set; }
        int? CredentialFieldDescriptorId { get; set; }
        int? Duration { get; set; }
        decimal? GPA { get; set; }
        DateTime? GraduationDate { get; set; }
        bool IsSportsFan { get; set; }
        int? LuckyNumber { get; set; }
        int ParentUSI { get; set; }
        TimeSpan? PreferredWakeUpTime { get; set; }
        decimal? RainCertainty { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentFavoriteBookTitle table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentFavoriteBookTitleRecord
    {     
        // Properties for all columns in physical table
        string FavoriteBookTitle { get; set; }
        int ParentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentStudentProgramAssociation table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentStudentProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int ParentUSI { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.ParentTeacherConference table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentTeacherConferenceRecord
    {     
        // Properties for all columns in physical table
        string DayOfWeek { get; set; }
        TimeSpan EndTime { get; set; }
        int ParentUSI { get; set; }
        TimeSpan StartTime { get; set; }
    }

    /// <summary>
    /// Interface for the sample.SchoolCTEProgram table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolCTEProgramRecord
    {     
        // Properties for all columns in physical table
        int CareerPathwayDescriptorId { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.SchoolDirectlyOwnedBus table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolDirectlyOwnedBusRecord
    {     
        // Properties for all columns in physical table
        string DirectlyOwnedBusId { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.SchoolExtension table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolExtensionRecord
    {     
        // Properties for all columns in physical table
        bool? IsExemplary { get; set; }
        int SchoolId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StaffExtension table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffExtensionRecord
    {     
        // Properties for all columns in physical table
        DateTime? FirstPetOwnedDate { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StaffPet table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffPetRecord
    {     
        // Properties for all columns in physical table
        bool? IsFixed { get; set; }
        string PetName { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StaffPetPreference table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffPetPreferenceRecord
    {     
        // Properties for all columns in physical table
        int MaximumWeight { get; set; }
        int MinimumWeight { get; set; }
        int StaffUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentAquaticPet table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAquaticPetRecord
    {     
        // Properties for all columns in physical table
        bool? IsFixed { get; set; }
        int MimimumTankVolume { get; set; }
        string PetName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentArtProgramAssociation table of the StudentArtProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentArtProgramAssociationRecord
    {     
        // Properties for all columns in physical table
        int? ArtPieces { get; set; }
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? ExhibitDate { get; set; }
        decimal? HoursPerDay { get; set; }
        string IdentificationCode { get; set; }
        TimeSpan? KilnReservation { get; set; }
        string KilnReservationLength { get; set; }
        decimal? MasteredMediums { get; set; }
        decimal? NumberOfDaysInAttendance { get; set; }
        int? PortfolioPieces { get; set; }
        bool PrivateArtProgram { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        decimal? ProgramFees { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentArtProgramAssociationArtMedium table of the StudentArtProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentArtProgramAssociationArtMediumRecord
    {     
        // Properties for all columns in physical table
        int ArtMediumDescriptorId { get; set; }
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentArtProgramAssociationPortfolioYears table of the StudentArtProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentArtProgramAssociationPortfolioYearsRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        short PortfolioYears { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentArtProgramAssociationService table of the StudentArtProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentArtProgramAssociationServiceRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        bool? PrimaryIndicator { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        int ServiceDescriptorId { get; set; }
        DateTime? ServiceEndDate { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentArtProgramAssociationStyle table of the StudentArtProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentArtProgramAssociationStyleRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
        string Style { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentCTEProgramAssociationExtension table of the StudentCTEProgramAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentCTEProgramAssociationExtensionRecord
    {     
        // Properties for all columns in physical table
        bool? AnalysisCompleted { get; set; }
        DateTime? AnalysisDate { get; set; }
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        int ProgramEducationOrganizationId { get; set; }
        string ProgramName { get; set; }
        int ProgramTypeDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentEducationOrganizationAssociationAddressExtension table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressExtensionRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string City { get; set; }
        string Complex { get; set; }
        int EducationOrganizationId { get; set; }
        bool OnBusRoute { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentEducationOrganizationAssociationAddressSchoolDistrict table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressSchoolDistrictRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string City { get; set; }
        int EducationOrganizationId { get; set; }
        string PostalCode { get; set; }
        string SchoolDistrict { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentEducationOrganizationAssociationAddressTerm table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressTermRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string City { get; set; }
        int EducationOrganizationId { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
        int StudentUSI { get; set; }
        int TermDescriptorId { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed table of the StudentEducationOrganizationAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedRecord
    {     
        // Properties for all columns in physical table
        DateTime BeginDate { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        bool? PrimaryStudentNeedIndicator { get; set; }
        int StudentCharacteristicDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentFavoriteBook table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentFavoriteBookRecord
    {     
        // Properties for all columns in physical table
        string BookTitle { get; set; }
        int FavoriteBookCategoryDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentFavoriteBookArtMedium table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentFavoriteBookArtMediumRecord
    {     
        // Properties for all columns in physical table
        int ArtMediumDescriptorId { get; set; }
        int? ArtPieces { get; set; }
        int FavoriteBookCategoryDescriptorId { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociation table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationRecord
    {     
        // Properties for all columns in physical table
        TimeSpan? CommencementTime { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime EffectiveDate { get; set; }
        decimal? GraduationFee { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        string HighSchoolDuration { get; set; }
        decimal HoursPerWeek { get; set; }
        Guid Id { get; set; }
        bool? IsActivePlan { get; set; }
        decimal? RequiredAttendance { get; set; }
        int? StaffUSI { get; set; }
        int StudentUSI { get; set; }
        decimal TargetGPA { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationAcademicSubject table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationAcademicSubjectRecord
    {     
        // Properties for all columns in physical table
        int AcademicSubjectDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationCareerPathwayCode table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationCareerPathwayCodeRecord
    {     
        // Properties for all columns in physical table
        int CareerPathwayCode { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationCTEProgram table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationCTEProgramRecord
    {     
        // Properties for all columns in physical table
        int CareerPathwayDescriptorId { get; set; }
        string CIPCode { get; set; }
        bool? CTEProgramCompletionIndicator { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        bool? PrimaryCTEProgramIndicator { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationDescription table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationDescriptionRecord
    {     
        // Properties for all columns in physical table
        string Description { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationDesignatedBy table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationDesignatedByRecord
    {     
        // Properties for all columns in physical table
        string DesignatedBy { get; set; }
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationIndustryCredential table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationIndustryCredentialRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        string IndustryCredential { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationStudentParentAssociation table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationStudentParentAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int ParentUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentGraduationPlanAssociationYearsAttended table of the StudentGraduationPlanAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentGraduationPlanAssociationYearsAttendedRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int GraduationPlanTypeDescriptorId { get; set; }
        short GraduationSchoolYear { get; set; }
        int StudentUSI { get; set; }
        short YearsAttended { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationDiscipline table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationDisciplineRecord
    {     
        // Properties for all columns in physical table
        int DisciplineDescriptorId { get; set; }
        int ParentUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationExtension table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationExtensionRecord
    {     
        // Properties for all columns in physical table
        bool BedtimeReader { get; set; }
        decimal? BedtimeReadingRate { get; set; }
        decimal? BookBudget { get; set; }
        int? BooksBorrowed { get; set; }
        int? EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int? LibraryDuration { get; set; }
        TimeSpan? LibraryTime { get; set; }
        short? LibraryVisits { get; set; }
        int ParentUSI { get; set; }
        string PriorContactRestrictions { get; set; }
        DateTime? ReadGreenEggsAndHamDate { get; set; }
        string ReadingTimeSpent { get; set; }
        short? StudentRead { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationFavoriteBookTitle table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationFavoriteBookTitleRecord
    {     
        // Properties for all columns in physical table
        string FavoriteBookTitle { get; set; }
        int ParentUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationHoursPerWeek table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationHoursPerWeekRecord
    {     
        // Properties for all columns in physical table
        decimal HoursPerWeek { get; set; }
        int ParentUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationPagesRead table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationPagesReadRecord
    {     
        // Properties for all columns in physical table
        decimal PagesRead { get; set; }
        int ParentUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationStaffEducationOrganizationEmploymentAssociation table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationStaffEducationOrganizationEmploymentAssociationRecord
    {     
        // Properties for all columns in physical table
        int EducationOrganizationId { get; set; }
        int EmploymentStatusDescriptorId { get; set; }
        DateTime HireDate { get; set; }
        int ParentUSI { get; set; }
        int StaffUSI { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentParentAssociationTelephone table of the StudentParentAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentParentAssociationTelephoneRecord
    {     
        // Properties for all columns in physical table
        bool? DoNotPublishIndicator { get; set; }
        int? OrderOfPriority { get; set; }
        int ParentUSI { get; set; }
        int StudentUSI { get; set; }
        string TelephoneNumber { get; set; }
        int TelephoneNumberTypeDescriptorId { get; set; }
        bool? TextMessageCapabilityIndicator { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentPet table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentPetRecord
    {     
        // Properties for all columns in physical table
        bool? IsFixed { get; set; }
        string PetName { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentPetPreference table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentPetPreferenceRecord
    {     
        // Properties for all columns in physical table
        int MaximumWeight { get; set; }
        int MinimumWeight { get; set; }
        int StudentUSI { get; set; }
    }

    /// <summary>
    /// Interface for the sample.StudentSchoolAssociationExtension table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolAssociationExtensionRecord
    {     
        // Properties for all columns in physical table
        DateTime EntryDate { get; set; }
        int? MembershipTypeDescriptorId { get; set; }
        int SchoolId { get; set; }
        int StudentUSI { get; set; }
    }
}


using System;


namespace EdFi.Ods.Entities.Common.Records.GrandBend
{ 

    /// <summary>
    /// Interface for the grandbend.Applicant table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantRecord
    {     
        // Properties for all columns in physical table
        string ApplicantIdentifier { get; set; }
        DateTime? BirthDate { get; set; }
        int? CitizenshipStatusDescriptorId { get; set; }
        int EducationOrganizationId { get; set; }
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        int? HighestCompletedLevelOfEducationDescriptorId { get; set; }
        int? HighlyQualifiedAcademicSubjectDescriptorId { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        int? SexDescriptorId { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }
    }

    /// <summary>
    /// Interface for the grandbend.ApplicantAddress table of the Applicant aggregate in the Ods Database.
    /// </summary>
    public interface IApplicantAddressRecord
    {     
        // Properties for all columns in physical table
        int AddressTypeDescriptorId { get; set; }
        string ApartmentRoomSuiteNumber { get; set; }
        string ApplicantIdentifier { get; set; }
        DateTime? BeginDate { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CountyFIPSCode { get; set; }
        int EducationOrganizationId { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        int StateAbbreviationDescriptorId { get; set; }
        string StreetNumberName { get; set; }
    }

    /// <summary>
    /// Interface for the grandbend.StaffExtension table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffExtensionRecord
    {     
        // Properties for all columns in physical table
        DateTime? ProbationCompleteDate { get; set; }
        int StaffUSI { get; set; }
        bool? Tenured { get; set; }
    }
}


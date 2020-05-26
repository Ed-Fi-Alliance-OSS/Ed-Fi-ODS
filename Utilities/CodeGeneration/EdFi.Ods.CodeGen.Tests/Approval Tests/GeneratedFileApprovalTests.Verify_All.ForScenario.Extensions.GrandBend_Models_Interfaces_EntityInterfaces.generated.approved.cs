using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common;
#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.GrandBend
{ 

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Applicant model.
    /// </summary>
    public interface IApplicant : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ApplicantIdentifier { get; set; }
        [NaturalKeyMember]
        int EducationOrganizationId { get; set; }

        // Non-PK properties
        DateTime? BirthDate { get; set; }
        string CitizenshipStatusDescriptor { get; set; }
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string HighestCompletedLevelOfEducationDescriptor { get; set; }
        string HighlyQualifiedAcademicSubjectDescriptor { get; set; }
        bool? HighlyQualifiedTeacher { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string LoginId { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }
        string SexDescriptor { get; set; }
        decimal? YearsOfPriorProfessionalExperience { get; set; }
        decimal? YearsOfPriorTeachingExperience { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IApplicantAddress> ApplicantAddresses { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ApplicantAddress model.
    /// </summary>
    public interface IApplicantAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IApplicant Applicant { get; set; }
        [NaturalKeyMember]
        string AddressTypeDescriptor { get; set; }

        // Non-PK properties
        string ApartmentRoomSuiteNumber { get; set; }
        DateTime? BeginDate { get; set; }
        string BuildingSiteNumber { get; set; }
        string City { get; set; }
        string CountyFIPSCode { get; set; }
        DateTime? EndDate { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }
        string PostalCode { get; set; }
        string StateAbbreviationDescriptor { get; set; }
        string StreetNumberName { get; set; }

        // One-to-one relationships

        // Lists

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
        DateTime? ProbationCompleteDate { get; set; }
        bool? Tenured { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }
}
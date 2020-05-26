using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Api.Dependencies;
using EdFi.Ods.Api.ETag;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Entities.Common.EdFi;
// Aggregate: Applicant

namespace EdFi.Ods.Entities.Common.GrandBend //.ApplicantAggregate
{ 
    [ExcludeFromCodeCoverage]
    public static class ApplicantMapper 
    {
        public static bool SynchronizeTo(this IApplicant source, IApplicant target)
        {
            bool isModified = false;

            var sourceSupport = source as IApplicantSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.ApplicantIdentifier != target.ApplicantIdentifier)
            {
                source.ApplicantIdentifier = target.ApplicantIdentifier;
            }
            if (source.EducationOrganizationId != target.EducationOrganizationId)
            {
                source.EducationOrganizationId = target.EducationOrganizationId;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsBirthDateSupported)
                && target.BirthDate != source.BirthDate)
            {
                target.BirthDate = source.BirthDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCitizenshipStatusDescriptorSupported)
                && target.CitizenshipStatusDescriptor != source.CitizenshipStatusDescriptor)
            {
                target.CitizenshipStatusDescriptor = source.CitizenshipStatusDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsFirstNameSupported)
                && target.FirstName != source.FirstName)
            {
                target.FirstName = source.FirstName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsGenerationCodeSuffixSupported)
                && target.GenerationCodeSuffix != source.GenerationCodeSuffix)
            {
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHighestCompletedLevelOfEducationDescriptorSupported)
                && target.HighestCompletedLevelOfEducationDescriptor != source.HighestCompletedLevelOfEducationDescriptor)
            {
                target.HighestCompletedLevelOfEducationDescriptor = source.HighestCompletedLevelOfEducationDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHighlyQualifiedAcademicSubjectDescriptorSupported)
                && target.HighlyQualifiedAcademicSubjectDescriptor != source.HighlyQualifiedAcademicSubjectDescriptor)
            {
                target.HighlyQualifiedAcademicSubjectDescriptor = source.HighlyQualifiedAcademicSubjectDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHighlyQualifiedTeacherSupported)
                && target.HighlyQualifiedTeacher != source.HighlyQualifiedTeacher)
            {
                target.HighlyQualifiedTeacher = source.HighlyQualifiedTeacher;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsHispanicLatinoEthnicitySupported)
                && target.HispanicLatinoEthnicity != source.HispanicLatinoEthnicity)
            {
                target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLastSurnameSupported)
                && target.LastSurname != source.LastSurname)
            {
                target.LastSurname = source.LastSurname;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLoginIdSupported)
                && target.LoginId != source.LoginId)
            {
                target.LoginId = source.LoginId;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMaidenNameSupported)
                && target.MaidenName != source.MaidenName)
            {
                target.MaidenName = source.MaidenName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsMiddleNameSupported)
                && target.MiddleName != source.MiddleName)
            {
                target.MiddleName = source.MiddleName;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPersonalTitlePrefixSupported)
                && target.PersonalTitlePrefix != source.PersonalTitlePrefix)
            {
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsSexDescriptorSupported)
                && target.SexDescriptor != source.SexDescriptor)
            {
                target.SexDescriptor = source.SexDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsYearsOfPriorProfessionalExperienceSupported)
                && target.YearsOfPriorProfessionalExperience != source.YearsOfPriorProfessionalExperience)
            {
                target.YearsOfPriorProfessionalExperience = source.YearsOfPriorProfessionalExperience;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsYearsOfPriorTeachingExperienceSupported)
                && target.YearsOfPriorTeachingExperience != source.YearsOfPriorTeachingExperience)
            {
                target.YearsOfPriorTeachingExperience = source.YearsOfPriorTeachingExperience;
                isModified = true;
            }


            // Sync lists
            if (sourceSupport == null || sourceSupport.IsApplicantAddressesSupported)
            {
                isModified |= 
                    source.ApplicantAddresses.SynchronizeCollectionTo(
                        target.ApplicantAddresses, 
                        onChildAdded: child => 
                            {
                                child.Applicant = target;
                            },
                        includeItem: sourceSupport == null 
                            ? null 
                            : sourceSupport.IsApplicantAddressIncluded);
            }


            return isModified;
        }



        public static void MapTo(this IApplicant source, IApplicant target, Action<IApplicant, IApplicant> onMapped)
        {
            var sourceSynchSupport = source as IApplicantSynchronizationSourceSupport;
            var targetSynchSupport = target as IApplicantSynchronizationSourceSupport;

            // Copy resource Id
            target.Id = source.Id;

            // Copy contextual primary key values
            target.ApplicantIdentifier = source.ApplicantIdentifier;
            target.EducationOrganizationId = source.EducationOrganizationId;

            // Copy non-PK properties

            if (sourceSynchSupport.IsBirthDateSupported)
                target.BirthDate = source.BirthDate;
            else
                targetSynchSupport.IsBirthDateSupported = false;

            if (sourceSynchSupport.IsCitizenshipStatusDescriptorSupported)
                target.CitizenshipStatusDescriptor = source.CitizenshipStatusDescriptor;
            else
                targetSynchSupport.IsCitizenshipStatusDescriptorSupported = false;

            if (sourceSynchSupport.IsFirstNameSupported)
                target.FirstName = source.FirstName;
            else
                targetSynchSupport.IsFirstNameSupported = false;

            if (sourceSynchSupport.IsGenerationCodeSuffixSupported)
                target.GenerationCodeSuffix = source.GenerationCodeSuffix;
            else
                targetSynchSupport.IsGenerationCodeSuffixSupported = false;

            if (sourceSynchSupport.IsHighestCompletedLevelOfEducationDescriptorSupported)
                target.HighestCompletedLevelOfEducationDescriptor = source.HighestCompletedLevelOfEducationDescriptor;
            else
                targetSynchSupport.IsHighestCompletedLevelOfEducationDescriptorSupported = false;

            if (sourceSynchSupport.IsHighlyQualifiedAcademicSubjectDescriptorSupported)
                target.HighlyQualifiedAcademicSubjectDescriptor = source.HighlyQualifiedAcademicSubjectDescriptor;
            else
                targetSynchSupport.IsHighlyQualifiedAcademicSubjectDescriptorSupported = false;

            if (sourceSynchSupport.IsHighlyQualifiedTeacherSupported)
                target.HighlyQualifiedTeacher = source.HighlyQualifiedTeacher;
            else
                targetSynchSupport.IsHighlyQualifiedTeacherSupported = false;

            if (sourceSynchSupport.IsHispanicLatinoEthnicitySupported)
                target.HispanicLatinoEthnicity = source.HispanicLatinoEthnicity;
            else
                targetSynchSupport.IsHispanicLatinoEthnicitySupported = false;

            if (sourceSynchSupport.IsLastSurnameSupported)
                target.LastSurname = source.LastSurname;
            else
                targetSynchSupport.IsLastSurnameSupported = false;

            if (sourceSynchSupport.IsLoginIdSupported)
                target.LoginId = source.LoginId;
            else
                targetSynchSupport.IsLoginIdSupported = false;

            if (sourceSynchSupport.IsMaidenNameSupported)
                target.MaidenName = source.MaidenName;
            else
                targetSynchSupport.IsMaidenNameSupported = false;

            if (sourceSynchSupport.IsMiddleNameSupported)
                target.MiddleName = source.MiddleName;
            else
                targetSynchSupport.IsMiddleNameSupported = false;

            if (sourceSynchSupport.IsPersonalTitlePrefixSupported)
                target.PersonalTitlePrefix = source.PersonalTitlePrefix;
            else
                targetSynchSupport.IsPersonalTitlePrefixSupported = false;

            if (sourceSynchSupport.IsSexDescriptorSupported)
                target.SexDescriptor = source.SexDescriptor;
            else
                targetSynchSupport.IsSexDescriptorSupported = false;

            if (sourceSynchSupport.IsYearsOfPriorProfessionalExperienceSupported)
                target.YearsOfPriorProfessionalExperience = source.YearsOfPriorProfessionalExperience;
            else
                targetSynchSupport.IsYearsOfPriorProfessionalExperienceSupported = false;

            if (sourceSynchSupport.IsYearsOfPriorTeachingExperienceSupported)
                target.YearsOfPriorTeachingExperience = source.YearsOfPriorTeachingExperience;
            else
                targetSynchSupport.IsYearsOfPriorTeachingExperienceSupported = false;

            // Copy Aggregate Reference Data
            if (GeneratedArtifactStaticDependencies.AuthorizationContextProvider == null 
                || GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction() == RequestActions.ReadActionUri)
            {
                target.EducationOrganizationResourceId = source.EducationOrganizationResourceId;
                target.EducationOrganizationDiscriminator = source.EducationOrganizationDiscriminator;
            }



            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists

            if (sourceSynchSupport.IsApplicantAddressesSupported)
            {    
                targetSynchSupport.IsApplicantAddressIncluded = sourceSynchSupport.IsApplicantAddressIncluded;
                source.ApplicantAddresses.MapCollectionTo(target.ApplicantAddresses, target);
            }
            else
            {
                targetSynchSupport.IsApplicantAddressesSupported = false;
            }


            var eTagProvider = new ETagProvider();

            // Convert value to ETag, if appropriate
            var entityWithETag = target as IHasETag;

            if (entityWithETag != null)
                entityWithETag.ETag = eTagProvider.GetETag(source);

            // Convert value to LastModifiedDate, if appropriate
            var dateVersionedEntity = target as IDateVersionedEntity;
            var etagSource = source as IHasETag;

            if (dateVersionedEntity != null && etagSource != null)
                dateVersionedEntity.LastModifiedDate = eTagProvider.GetDateTime(etagSource.ETag);
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction 
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IApplicantSynchronizationSourceSupport 
    {
        bool IsApplicantAddressesSupported { get; set; }
        bool IsBirthDateSupported { get; set; }
        bool IsCitizenshipStatusDescriptorSupported { get; set; }
        bool IsFirstNameSupported { get; set; }
        bool IsGenerationCodeSuffixSupported { get; set; }
        bool IsHighestCompletedLevelOfEducationDescriptorSupported { get; set; }
        bool IsHighlyQualifiedAcademicSubjectDescriptorSupported { get; set; }
        bool IsHighlyQualifiedTeacherSupported { get; set; }
        bool IsHispanicLatinoEthnicitySupported { get; set; }
        bool IsLastSurnameSupported { get; set; }
        bool IsLoginIdSupported { get; set; }
        bool IsMaidenNameSupported { get; set; }
        bool IsMiddleNameSupported { get; set; }
        bool IsPersonalTitlePrefixSupported { get; set; }
        bool IsSexDescriptorSupported { get; set; }
        bool IsYearsOfPriorProfessionalExperienceSupported { get; set; }
        bool IsYearsOfPriorTeachingExperienceSupported { get; set; }
        Func<IApplicantAddress, bool> IsApplicantAddressIncluded { get; set; }
    }
 
    [ExcludeFromCodeCoverage]
    public static class ApplicantAddressMapper 
    {
        public static bool SynchronizeTo(this IApplicantAddress source, IApplicantAddress target)
        {
            bool isModified = false;

            var sourceSupport = source as IApplicantAddressSynchronizationSourceSupport;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)
            if (source.AddressTypeDescriptor != target.AddressTypeDescriptor)
            {
                source.AddressTypeDescriptor = target.AddressTypeDescriptor;
            }

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsApartmentRoomSuiteNumberSupported)
                && target.ApartmentRoomSuiteNumber != source.ApartmentRoomSuiteNumber)
            {
                target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBeginDateSupported)
                && target.BeginDate != source.BeginDate)
            {
                target.BeginDate = source.BeginDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsBuildingSiteNumberSupported)
                && target.BuildingSiteNumber != source.BuildingSiteNumber)
            {
                target.BuildingSiteNumber = source.BuildingSiteNumber;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCitySupported)
                && target.City != source.City)
            {
                target.City = source.City;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsCountyFIPSCodeSupported)
                && target.CountyFIPSCode != source.CountyFIPSCode)
            {
                target.CountyFIPSCode = source.CountyFIPSCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsEndDateSupported)
                && target.EndDate != source.EndDate)
            {
                target.EndDate = source.EndDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLatitudeSupported)
                && target.Latitude != source.Latitude)
            {
                target.Latitude = source.Latitude;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsLongitudeSupported)
                && target.Longitude != source.Longitude)
            {
                target.Longitude = source.Longitude;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsNameOfCountySupported)
                && target.NameOfCounty != source.NameOfCounty)
            {
                target.NameOfCounty = source.NameOfCounty;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsPostalCodeSupported)
                && target.PostalCode != source.PostalCode)
            {
                target.PostalCode = source.PostalCode;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStateAbbreviationDescriptorSupported)
                && target.StateAbbreviationDescriptor != source.StateAbbreviationDescriptor)
            {
                target.StateAbbreviationDescriptor = source.StateAbbreviationDescriptor;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsStreetNumberNameSupported)
                && target.StreetNumberName != source.StreetNumberName)
            {
                target.StreetNumberName = source.StreetNumberName;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IApplicantAddress source, IApplicantAddress target, Action<IApplicantAddress, IApplicantAddress> onMapped)
        {
            var sourceSynchSupport = source as IApplicantAddressSynchronizationSourceSupport;
            var targetSynchSupport = target as IApplicantAddressSynchronizationSourceSupport;

            // Copy contextual primary key values
            target.AddressTypeDescriptor = source.AddressTypeDescriptor;

            // Copy non-PK properties

            if (sourceSynchSupport.IsApartmentRoomSuiteNumberSupported)
                target.ApartmentRoomSuiteNumber = source.ApartmentRoomSuiteNumber;
            else
                targetSynchSupport.IsApartmentRoomSuiteNumberSupported = false;

            if (sourceSynchSupport.IsBeginDateSupported)
                target.BeginDate = source.BeginDate;
            else
                targetSynchSupport.IsBeginDateSupported = false;

            if (sourceSynchSupport.IsBuildingSiteNumberSupported)
                target.BuildingSiteNumber = source.BuildingSiteNumber;
            else
                targetSynchSupport.IsBuildingSiteNumberSupported = false;

            if (sourceSynchSupport.IsCitySupported)
                target.City = source.City;
            else
                targetSynchSupport.IsCitySupported = false;

            if (sourceSynchSupport.IsCountyFIPSCodeSupported)
                target.CountyFIPSCode = source.CountyFIPSCode;
            else
                targetSynchSupport.IsCountyFIPSCodeSupported = false;

            if (sourceSynchSupport.IsEndDateSupported)
                target.EndDate = source.EndDate;
            else
                targetSynchSupport.IsEndDateSupported = false;

            if (sourceSynchSupport.IsLatitudeSupported)
                target.Latitude = source.Latitude;
            else
                targetSynchSupport.IsLatitudeSupported = false;

            if (sourceSynchSupport.IsLongitudeSupported)
                target.Longitude = source.Longitude;
            else
                targetSynchSupport.IsLongitudeSupported = false;

            if (sourceSynchSupport.IsNameOfCountySupported)
                target.NameOfCounty = source.NameOfCounty;
            else
                targetSynchSupport.IsNameOfCountySupported = false;

            if (sourceSynchSupport.IsPostalCodeSupported)
                target.PostalCode = source.PostalCode;
            else
                targetSynchSupport.IsPostalCodeSupported = false;

            if (sourceSynchSupport.IsStateAbbreviationDescriptorSupported)
                target.StateAbbreviationDescriptor = source.StateAbbreviationDescriptor;
            else
                targetSynchSupport.IsStateAbbreviationDescriptorSupported = false;

            if (sourceSynchSupport.IsStreetNumberNameSupported)
                target.StreetNumberName = source.StreetNumberName;
            else
                targetSynchSupport.IsStreetNumberNameSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            var eTagProvider = new ETagProvider();

            // Convert value to ETag, if appropriate
            var entityWithETag = target as IHasETag;

            if (entityWithETag != null)
                entityWithETag.ETag = eTagProvider.GetETag(source);

            // Convert value to LastModifiedDate, if appropriate
            var dateVersionedEntity = target as IDateVersionedEntity;
            var etagSource = source as IHasETag;

            if (dateVersionedEntity != null && etagSource != null)
                dateVersionedEntity.LastModifiedDate = eTagProvider.GetDateTime(etagSource.ETag);
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction 
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IApplicantAddressSynchronizationSourceSupport 
    {
        bool IsApartmentRoomSuiteNumberSupported { get; set; }
        bool IsBeginDateSupported { get; set; }
        bool IsBuildingSiteNumberSupported { get; set; }
        bool IsCitySupported { get; set; }
        bool IsCountyFIPSCodeSupported { get; set; }
        bool IsEndDateSupported { get; set; }
        bool IsLatitudeSupported { get; set; }
        bool IsLongitudeSupported { get; set; }
        bool IsNameOfCountySupported { get; set; }
        bool IsPostalCodeSupported { get; set; }
        bool IsStateAbbreviationDescriptorSupported { get; set; }
        bool IsStreetNumberNameSupported { get; set; }
    }
 
}
// Aggregate: Staff

namespace EdFi.Ods.Entities.Common.GrandBend //.StaffAggregate
{ 
    [ExcludeFromCodeCoverage]
    public static class StaffExtensionMapper 
    {
        public static bool SynchronizeTo(this IStaffExtension source, IStaffExtension target)
        {
            bool isModified = false;

            var sourceSupport = source as IStaffExtensionSynchronizationSourceSupport;

            var sourceExtensionSupport = source.Staff as IExtensionsSynchronizationSourceSupport;

            if (!sourceExtensionSupport.IsExtensionAvailable("GrandBend"))
                return false;

            // Back synch non-reference portion of PK (PK properties cannot be changed, therefore they can be omitted in the resource payload, but we need them for proper comparisons for persistence)

            // Copy non-PK properties

            if ((sourceSupport == null || sourceSupport.IsProbationCompleteDateSupported)
                && target.ProbationCompleteDate != source.ProbationCompleteDate)
            {
                target.ProbationCompleteDate = source.ProbationCompleteDate;
                isModified = true;
            }

            if ((sourceSupport == null || sourceSupport.IsTenuredSupported)
                && target.Tenured != source.Tenured)
            {
                target.Tenured = source.Tenured;
                isModified = true;
            }


            // Sync lists

            return isModified;
        }



        public static void MapTo(this IStaffExtension source, IStaffExtension target, Action<IStaffExtension, IStaffExtension> onMapped)
        {
            var sourceSynchSupport = source as IStaffExtensionSynchronizationSourceSupport;
            var targetSynchSupport = target as IStaffExtensionSynchronizationSourceSupport;

            // Copy contextual primary key values

            // Copy non-PK properties

            if (sourceSynchSupport.IsProbationCompleteDateSupported)
                target.ProbationCompleteDate = source.ProbationCompleteDate;
            else
                targetSynchSupport.IsProbationCompleteDateSupported = false;

            if (sourceSynchSupport.IsTenuredSupported)
                target.Tenured = source.Tenured;
            else
                targetSynchSupport.IsTenuredSupported = false;

            // Copy Aggregate Reference Data


            // ----------------------------------
            //   Map One-to-one relationships
            // ----------------------------------

            // Map lists


            var eTagProvider = new ETagProvider();

            // Convert value to ETag, if appropriate
            var entityWithETag = target as IHasETag;

            if (entityWithETag != null)
                entityWithETag.ETag = eTagProvider.GetETag(source);

            // Convert value to LastModifiedDate, if appropriate
            var dateVersionedEntity = target as IDateVersionedEntity;
            var etagSource = source as IHasETag;

            if (dateVersionedEntity != null && etagSource != null)
                dateVersionedEntity.LastModifiedDate = eTagProvider.GetDateTime(etagSource.ETag);
        }
    }

    /// <summary>
    /// Defines properties that indicate whether a particular property of the model abstraction 
    /// is supported by a model implementation being used as the source in a "synchronization"
    /// operation.
    /// </summary>
    public interface IStaffExtensionSynchronizationSourceSupport 
    {
        bool IsProbationCompleteDateSupported { get; set; }
        bool IsTenuredSupported { get; set; }
    }
 
}

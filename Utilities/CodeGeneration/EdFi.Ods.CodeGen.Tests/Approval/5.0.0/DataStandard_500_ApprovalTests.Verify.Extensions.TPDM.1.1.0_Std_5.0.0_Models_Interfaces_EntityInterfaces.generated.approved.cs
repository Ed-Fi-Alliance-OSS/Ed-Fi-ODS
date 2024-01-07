using System;
using System.Linq;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Entities.Common.EdFi;

#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.TPDM
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AccreditationStatusDescriptor model.
    /// </summary>
    public interface IAccreditationStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int AccreditationStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class AccreditationStatusDescriptorMappingContract : IMappingContract
    {
        public AccreditationStatusDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "AccreditationStatusDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AidTypeDescriptor model.
    /// </summary>
    public interface IAidTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int AidTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class AidTypeDescriptorMappingContract : IMappingContract
    {
        public AidTypeDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "AidTypeDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Candidate model.
    /// </summary>
    public interface ICandidate : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string CandidateIdentifier { get; set; }

        // Non-PK properties
        string BirthCity { get; set; }
        string BirthCountryDescriptor { get; set; }
        DateTime BirthDate { get; set; }
        string BirthInternationalProvince { get; set; }
        string BirthSexDescriptor { get; set; }
        string BirthStateAbbreviationDescriptor { get; set; }
        DateTime? DateEnteredUS { get; set; }
        string DisplacementStatus { get; set; }
        bool? EconomicDisadvantaged { get; set; }
        string EnglishLanguageExamDescriptor { get; set; }
        bool? FirstGenerationStudent { get; set; }
        string FirstName { get; set; }
        string GenderDescriptor { get; set; }
        string GenerationCodeSuffix { get; set; }
        bool? HispanicLatinoEthnicity { get; set; }
        string LastSurname { get; set; }
        string LimitedEnglishProficiencyDescriptor { get; set; }
        string MaidenName { get; set; }
        string MiddleName { get; set; }
        bool? MultipleBirthStatus { get; set; }
        string PersonalTitlePrefix { get; set; }
        string PersonId { get; set; }
        string PreferredFirstName { get; set; }
        string PreferredLastSurname { get; set; }
        string SexDescriptor { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateAddress> CandidateAddresses { get; set; }
        ICollection<ICandidateDisability> CandidateDisabilities { get; set; }
        ICollection<ICandidateElectronicMail> CandidateElectronicMails { get; set; }
        ICollection<ICandidateLanguage> CandidateLanguages { get; set; }
        ICollection<ICandidateOtherName> CandidateOtherNames { get; set; }
        ICollection<ICandidatePersonalIdentificationDocument> CandidatePersonalIdentificationDocuments { get; set; }
        ICollection<ICandidateRace> CandidateRaces { get; set; }
        ICollection<ICandidateTelephone> CandidateTelephones { get; set; }

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateMappingContract : IMappingContract
    {
        public CandidateMappingContract(
            bool isBirthCitySupported,
            bool isBirthCountryDescriptorSupported,
            bool isBirthDateSupported,
            bool isBirthInternationalProvinceSupported,
            bool isBirthSexDescriptorSupported,
            bool isBirthStateAbbreviationDescriptorSupported,
            bool isCandidateAddressesSupported,
            bool isCandidateDisabilitiesSupported,
            bool isCandidateElectronicMailsSupported,
            bool isCandidateLanguagesSupported,
            bool isCandidateOtherNamesSupported,
            bool isCandidatePersonalIdentificationDocumentsSupported,
            bool isCandidateRacesSupported,
            bool isCandidateTelephonesSupported,
            bool isDateEnteredUSSupported,
            bool isDisplacementStatusSupported,
            bool isEconomicDisadvantagedSupported,
            bool isEnglishLanguageExamDescriptorSupported,
            bool isFirstGenerationStudentSupported,
            bool isFirstNameSupported,
            bool isGenderDescriptorSupported,
            bool isGenerationCodeSuffixSupported,
            bool isHispanicLatinoEthnicitySupported,
            bool isLastSurnameSupported,
            bool isLimitedEnglishProficiencyDescriptorSupported,
            bool isMaidenNameSupported,
            bool isMiddleNameSupported,
            bool isMultipleBirthStatusSupported,
            bool isPersonalTitlePrefixSupported,
            bool isPersonIdSupported,
            bool isPersonReferenceSupported,
            bool isPreferredFirstNameSupported,
            bool isPreferredLastSurnameSupported,
            bool isSexDescriptorSupported,
            bool isSourceSystemDescriptorSupported,
            Func<ICandidateAddress, bool> isCandidateAddressIncluded,
            Func<ICandidateDisability, bool> isCandidateDisabilityIncluded,
            Func<ICandidateElectronicMail, bool> isCandidateElectronicMailIncluded,
            Func<ICandidateLanguage, bool> isCandidateLanguageIncluded,
            Func<ICandidateOtherName, bool> isCandidateOtherNameIncluded,
            Func<ICandidatePersonalIdentificationDocument, bool> isCandidatePersonalIdentificationDocumentIncluded,
            Func<ICandidateRace, bool> isCandidateRaceIncluded,
            Func<ICandidateTelephone, bool> isCandidateTelephoneIncluded
            )
        {
            IsBirthCitySupported = isBirthCitySupported;
            IsBirthCountryDescriptorSupported = isBirthCountryDescriptorSupported;
            IsBirthDateSupported = isBirthDateSupported;
            IsBirthInternationalProvinceSupported = isBirthInternationalProvinceSupported;
            IsBirthSexDescriptorSupported = isBirthSexDescriptorSupported;
            IsBirthStateAbbreviationDescriptorSupported = isBirthStateAbbreviationDescriptorSupported;
            IsCandidateAddressesSupported = isCandidateAddressesSupported;
            IsCandidateDisabilitiesSupported = isCandidateDisabilitiesSupported;
            IsCandidateElectronicMailsSupported = isCandidateElectronicMailsSupported;
            IsCandidateLanguagesSupported = isCandidateLanguagesSupported;
            IsCandidateOtherNamesSupported = isCandidateOtherNamesSupported;
            IsCandidatePersonalIdentificationDocumentsSupported = isCandidatePersonalIdentificationDocumentsSupported;
            IsCandidateRacesSupported = isCandidateRacesSupported;
            IsCandidateTelephonesSupported = isCandidateTelephonesSupported;
            IsDateEnteredUSSupported = isDateEnteredUSSupported;
            IsDisplacementStatusSupported = isDisplacementStatusSupported;
            IsEconomicDisadvantagedSupported = isEconomicDisadvantagedSupported;
            IsEnglishLanguageExamDescriptorSupported = isEnglishLanguageExamDescriptorSupported;
            IsFirstGenerationStudentSupported = isFirstGenerationStudentSupported;
            IsFirstNameSupported = isFirstNameSupported;
            IsGenderDescriptorSupported = isGenderDescriptorSupported;
            IsGenerationCodeSuffixSupported = isGenerationCodeSuffixSupported;
            IsHispanicLatinoEthnicitySupported = isHispanicLatinoEthnicitySupported;
            IsLastSurnameSupported = isLastSurnameSupported;
            IsLimitedEnglishProficiencyDescriptorSupported = isLimitedEnglishProficiencyDescriptorSupported;
            IsMaidenNameSupported = isMaidenNameSupported;
            IsMiddleNameSupported = isMiddleNameSupported;
            IsMultipleBirthStatusSupported = isMultipleBirthStatusSupported;
            IsPersonalTitlePrefixSupported = isPersonalTitlePrefixSupported;
            IsPersonIdSupported = isPersonIdSupported;
            IsPersonReferenceSupported = isPersonReferenceSupported;
            IsPreferredFirstNameSupported = isPreferredFirstNameSupported;
            IsPreferredLastSurnameSupported = isPreferredLastSurnameSupported;
            IsSexDescriptorSupported = isSexDescriptorSupported;
            IsSourceSystemDescriptorSupported = isSourceSystemDescriptorSupported;
            IsCandidateAddressIncluded = isCandidateAddressIncluded;
            IsCandidateDisabilityIncluded = isCandidateDisabilityIncluded;
            IsCandidateElectronicMailIncluded = isCandidateElectronicMailIncluded;
            IsCandidateLanguageIncluded = isCandidateLanguageIncluded;
            IsCandidateOtherNameIncluded = isCandidateOtherNameIncluded;
            IsCandidatePersonalIdentificationDocumentIncluded = isCandidatePersonalIdentificationDocumentIncluded;
            IsCandidateRaceIncluded = isCandidateRaceIncluded;
            IsCandidateTelephoneIncluded = isCandidateTelephoneIncluded;
        }

        public bool IsBirthCitySupported { get; }
        public bool IsBirthCountryDescriptorSupported { get; }
        public bool IsBirthDateSupported { get; }
        public bool IsBirthInternationalProvinceSupported { get; }
        public bool IsBirthSexDescriptorSupported { get; }
        public bool IsBirthStateAbbreviationDescriptorSupported { get; }
        public bool IsCandidateAddressesSupported { get; }
        public bool IsCandidateDisabilitiesSupported { get; }
        public bool IsCandidateElectronicMailsSupported { get; }
        public bool IsCandidateLanguagesSupported { get; }
        public bool IsCandidateOtherNamesSupported { get; }
        public bool IsCandidatePersonalIdentificationDocumentsSupported { get; }
        public bool IsCandidateRacesSupported { get; }
        public bool IsCandidateTelephonesSupported { get; }
        public bool IsDateEnteredUSSupported { get; }
        public bool IsDisplacementStatusSupported { get; }
        public bool IsEconomicDisadvantagedSupported { get; }
        public bool IsEnglishLanguageExamDescriptorSupported { get; }
        public bool IsFirstGenerationStudentSupported { get; }
        public bool IsFirstNameSupported { get; }
        public bool IsGenderDescriptorSupported { get; }
        public bool IsGenerationCodeSuffixSupported { get; }
        public bool IsHispanicLatinoEthnicitySupported { get; }
        public bool IsLastSurnameSupported { get; }
        public bool IsLimitedEnglishProficiencyDescriptorSupported { get; }
        public bool IsMaidenNameSupported { get; }
        public bool IsMiddleNameSupported { get; }
        public bool IsMultipleBirthStatusSupported { get; }
        public bool IsPersonalTitlePrefixSupported { get; }
        public bool IsPersonIdSupported { get; }
        public bool IsPersonReferenceSupported { get; }
        public bool IsPreferredFirstNameSupported { get; }
        public bool IsPreferredLastSurnameSupported { get; }
        public bool IsSexDescriptorSupported { get; }
        public bool IsSourceSystemDescriptorSupported { get; }
        public Func<ICandidateAddress, bool> IsCandidateAddressIncluded { get; }
        public Func<ICandidateDisability, bool> IsCandidateDisabilityIncluded { get; }
        public Func<ICandidateElectronicMail, bool> IsCandidateElectronicMailIncluded { get; }
        public Func<ICandidateLanguage, bool> IsCandidateLanguageIncluded { get; }
        public Func<ICandidateOtherName, bool> IsCandidateOtherNameIncluded { get; }
        public Func<ICandidatePersonalIdentificationDocument, bool> IsCandidatePersonalIdentificationDocumentIncluded { get; }
        public Func<ICandidateRace, bool> IsCandidateRaceIncluded { get; }
        public Func<ICandidateTelephone, bool> IsCandidateTelephoneIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "BirthCity":
                    return IsBirthCitySupported;
                case "BirthCountryDescriptor":
                    return IsBirthCountryDescriptorSupported;
                case "BirthDate":
                    return IsBirthDateSupported;
                case "BirthInternationalProvince":
                    return IsBirthInternationalProvinceSupported;
                case "BirthSexDescriptor":
                    return IsBirthSexDescriptorSupported;
                case "BirthStateAbbreviationDescriptor":
                    return IsBirthStateAbbreviationDescriptorSupported;
                case "CandidateAddresses":
                    return IsCandidateAddressesSupported;
                case "CandidateDisabilities":
                    return IsCandidateDisabilitiesSupported;
                case "CandidateElectronicMails":
                    return IsCandidateElectronicMailsSupported;
                case "CandidateLanguages":
                    return IsCandidateLanguagesSupported;
                case "CandidateOtherNames":
                    return IsCandidateOtherNamesSupported;
                case "CandidatePersonalIdentificationDocuments":
                    return IsCandidatePersonalIdentificationDocumentsSupported;
                case "CandidateRaces":
                    return IsCandidateRacesSupported;
                case "CandidateTelephones":
                    return IsCandidateTelephonesSupported;
                case "DateEnteredUS":
                    return IsDateEnteredUSSupported;
                case "DisplacementStatus":
                    return IsDisplacementStatusSupported;
                case "EconomicDisadvantaged":
                    return IsEconomicDisadvantagedSupported;
                case "EnglishLanguageExamDescriptor":
                    return IsEnglishLanguageExamDescriptorSupported;
                case "FirstGenerationStudent":
                    return IsFirstGenerationStudentSupported;
                case "FirstName":
                    return IsFirstNameSupported;
                case "GenderDescriptor":
                    return IsGenderDescriptorSupported;
                case "GenerationCodeSuffix":
                    return IsGenerationCodeSuffixSupported;
                case "HispanicLatinoEthnicity":
                    return IsHispanicLatinoEthnicitySupported;
                case "LastSurname":
                    return IsLastSurnameSupported;
                case "LimitedEnglishProficiencyDescriptor":
                    return IsLimitedEnglishProficiencyDescriptorSupported;
                case "MaidenName":
                    return IsMaidenNameSupported;
                case "MiddleName":
                    return IsMiddleNameSupported;
                case "MultipleBirthStatus":
                    return IsMultipleBirthStatusSupported;
                case "PersonalTitlePrefix":
                    return IsPersonalTitlePrefixSupported;
                case "PersonId":
                    return IsPersonIdSupported;
                case "PersonReference":
                    return IsPersonReferenceSupported;
                case "PreferredFirstName":
                    return IsPreferredFirstNameSupported;
                case "PreferredLastSurname":
                    return IsPreferredLastSurnameSupported;
                case "SexDescriptor":
                    return IsSexDescriptorSupported;
                case "SourceSystemDescriptor":
                    return IsSourceSystemDescriptorSupported;
                case "CandidateIdentifier":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateAddress model.
    /// </summary>
    public interface ICandidateAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string AddressTypeDescriptor { get; set; }
        
        string City { get; set; }
        
        string PostalCode { get; set; }
        
        string StateAbbreviationDescriptor { get; set; }
        
        string StreetNumberName { get; set; }

        // Non-PK properties
        string ApartmentRoomSuiteNumber { get; set; }
        string BuildingSiteNumber { get; set; }
        string CongressionalDistrict { get; set; }
        string CountyFIPSCode { get; set; }
        bool? DoNotPublishIndicator { get; set; }
        string Latitude { get; set; }
        string LocaleDescriptor { get; set; }
        string Longitude { get; set; }
        string NameOfCounty { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateAddressPeriod> CandidateAddressPeriods { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateAddressMappingContract : IMappingContract
    {
        public CandidateAddressMappingContract(
            bool isApartmentRoomSuiteNumberSupported,
            bool isBuildingSiteNumberSupported,
            bool isCandidateAddressPeriodsSupported,
            bool isCongressionalDistrictSupported,
            bool isCountyFIPSCodeSupported,
            bool isDoNotPublishIndicatorSupported,
            bool isLatitudeSupported,
            bool isLocaleDescriptorSupported,
            bool isLongitudeSupported,
            bool isNameOfCountySupported,
            Func<ICandidateAddressPeriod, bool> isCandidateAddressPeriodIncluded
            )
        {
            IsApartmentRoomSuiteNumberSupported = isApartmentRoomSuiteNumberSupported;
            IsBuildingSiteNumberSupported = isBuildingSiteNumberSupported;
            IsCandidateAddressPeriodsSupported = isCandidateAddressPeriodsSupported;
            IsCongressionalDistrictSupported = isCongressionalDistrictSupported;
            IsCountyFIPSCodeSupported = isCountyFIPSCodeSupported;
            IsDoNotPublishIndicatorSupported = isDoNotPublishIndicatorSupported;
            IsLatitudeSupported = isLatitudeSupported;
            IsLocaleDescriptorSupported = isLocaleDescriptorSupported;
            IsLongitudeSupported = isLongitudeSupported;
            IsNameOfCountySupported = isNameOfCountySupported;
            IsCandidateAddressPeriodIncluded = isCandidateAddressPeriodIncluded;
        }

        public bool IsApartmentRoomSuiteNumberSupported { get; }
        public bool IsBuildingSiteNumberSupported { get; }
        public bool IsCandidateAddressPeriodsSupported { get; }
        public bool IsCongressionalDistrictSupported { get; }
        public bool IsCountyFIPSCodeSupported { get; }
        public bool IsDoNotPublishIndicatorSupported { get; }
        public bool IsLatitudeSupported { get; }
        public bool IsLocaleDescriptorSupported { get; }
        public bool IsLongitudeSupported { get; }
        public bool IsNameOfCountySupported { get; }
        public Func<ICandidateAddressPeriod, bool> IsCandidateAddressPeriodIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ApartmentRoomSuiteNumber":
                    return IsApartmentRoomSuiteNumberSupported;
                case "BuildingSiteNumber":
                    return IsBuildingSiteNumberSupported;
                case "CandidateAddressPeriods":
                    return IsCandidateAddressPeriodsSupported;
                case "CongressionalDistrict":
                    return IsCongressionalDistrictSupported;
                case "CountyFIPSCode":
                    return IsCountyFIPSCodeSupported;
                case "DoNotPublishIndicator":
                    return IsDoNotPublishIndicatorSupported;
                case "Latitude":
                    return IsLatitudeSupported;
                case "LocaleDescriptor":
                    return IsLocaleDescriptorSupported;
                case "Longitude":
                    return IsLongitudeSupported;
                case "NameOfCounty":
                    return IsNameOfCountySupported;
                case "AddressTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "City":
                    // Identifying properties are always supported
                    return true;
                case "PostalCode":
                    // Identifying properties are always supported
                    return true;
                case "StateAbbreviationDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "StreetNumberName":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateAddressPeriod model.
    /// </summary>
    public interface ICandidateAddressPeriod : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidateAddress CandidateAddress { get; set; }
        
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateAddressPeriodMappingContract : IMappingContract
    {
        public CandidateAddressPeriodMappingContract(
            bool isEndDateSupported
            )
        {
            IsEndDateSupported = isEndDateSupported;
        }

        public bool IsEndDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EndDate":
                    return IsEndDateSupported;
                case "BeginDate":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateDisability model.
    /// </summary>
    public interface ICandidateDisability : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string DisabilityDescriptor { get; set; }

        // Non-PK properties
        string DisabilityDeterminationSourceTypeDescriptor { get; set; }
        string DisabilityDiagnosis { get; set; }
        int? OrderOfDisability { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateDisabilityDesignation> CandidateDisabilityDesignations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateDisabilityMappingContract : IMappingContract
    {
        public CandidateDisabilityMappingContract(
            bool isCandidateDisabilityDesignationsSupported,
            bool isDisabilityDeterminationSourceTypeDescriptorSupported,
            bool isDisabilityDiagnosisSupported,
            bool isOrderOfDisabilitySupported,
            Func<ICandidateDisabilityDesignation, bool> isCandidateDisabilityDesignationIncluded
            )
        {
            IsCandidateDisabilityDesignationsSupported = isCandidateDisabilityDesignationsSupported;
            IsDisabilityDeterminationSourceTypeDescriptorSupported = isDisabilityDeterminationSourceTypeDescriptorSupported;
            IsDisabilityDiagnosisSupported = isDisabilityDiagnosisSupported;
            IsOrderOfDisabilitySupported = isOrderOfDisabilitySupported;
            IsCandidateDisabilityDesignationIncluded = isCandidateDisabilityDesignationIncluded;
        }

        public bool IsCandidateDisabilityDesignationsSupported { get; }
        public bool IsDisabilityDeterminationSourceTypeDescriptorSupported { get; }
        public bool IsDisabilityDiagnosisSupported { get; }
        public bool IsOrderOfDisabilitySupported { get; }
        public Func<ICandidateDisabilityDesignation, bool> IsCandidateDisabilityDesignationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CandidateDisabilityDesignations":
                    return IsCandidateDisabilityDesignationsSupported;
                case "DisabilityDeterminationSourceTypeDescriptor":
                    return IsDisabilityDeterminationSourceTypeDescriptorSupported;
                case "DisabilityDiagnosis":
                    return IsDisabilityDiagnosisSupported;
                case "OrderOfDisability":
                    return IsOrderOfDisabilitySupported;
                case "DisabilityDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateDisabilityDesignation model.
    /// </summary>
    public interface ICandidateDisabilityDesignation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidateDisability CandidateDisability { get; set; }
        
        string DisabilityDesignationDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateDisabilityDesignationMappingContract : IMappingContract
    {
        public CandidateDisabilityDesignationMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DisabilityDesignationDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEducatorPreparationProgramAssociation model.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        DateTime BeginDate { get; set; }
        
        string CandidateIdentifier { get; set; }
        
        long EducationOrganizationId { get; set; }
        
        string ProgramName { get; set; }
        
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string EPPProgramPathwayDescriptor { get; set; }
        string ReasonExitedDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICandidateEducatorPreparationProgramAssociationCohortYear> CandidateEducatorPreparationProgramAssociationCohortYears { get; set; }
        ICollection<ICandidateEducatorPreparationProgramAssociationDegreeSpecialization> CandidateEducatorPreparationProgramAssociationDegreeSpecializations { get; set; }

        // Resource reference data
        Guid? CandidateResourceId { get; set; }
        string CandidateDiscriminator { get; set; }
        Guid? EducatorPreparationProgramResourceId { get; set; }
        string EducatorPreparationProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateEducatorPreparationProgramAssociationMappingContract : IMappingContract
    {
        public CandidateEducatorPreparationProgramAssociationMappingContract(
            bool isCandidateEducatorPreparationProgramAssociationCohortYearsSupported,
            bool isCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported,
            bool isCandidateReferenceSupported,
            bool isEducatorPreparationProgramReferenceSupported,
            bool isEndDateSupported,
            bool isEPPProgramPathwayDescriptorSupported,
            bool isReasonExitedDescriptorSupported,
            Func<ICandidateEducatorPreparationProgramAssociationCohortYear, bool> isCandidateEducatorPreparationProgramAssociationCohortYearIncluded,
            Func<ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, bool> isCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded
            )
        {
            IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported = isCandidateEducatorPreparationProgramAssociationCohortYearsSupported;
            IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported = isCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported;
            IsCandidateReferenceSupported = isCandidateReferenceSupported;
            IsEducatorPreparationProgramReferenceSupported = isEducatorPreparationProgramReferenceSupported;
            IsEndDateSupported = isEndDateSupported;
            IsEPPProgramPathwayDescriptorSupported = isEPPProgramPathwayDescriptorSupported;
            IsReasonExitedDescriptorSupported = isReasonExitedDescriptorSupported;
            IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded = isCandidateEducatorPreparationProgramAssociationCohortYearIncluded;
            IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded = isCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded;
        }

        public bool IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported { get; }
        public bool IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported { get; }
        public bool IsCandidateReferenceSupported { get; }
        public bool IsEducatorPreparationProgramReferenceSupported { get; }
        public bool IsEndDateSupported { get; }
        public bool IsEPPProgramPathwayDescriptorSupported { get; }
        public bool IsReasonExitedDescriptorSupported { get; }
        public Func<ICandidateEducatorPreparationProgramAssociationCohortYear, bool> IsCandidateEducatorPreparationProgramAssociationCohortYearIncluded { get; }
        public Func<ICandidateEducatorPreparationProgramAssociationDegreeSpecialization, bool> IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CandidateEducatorPreparationProgramAssociationCohortYears":
                    return IsCandidateEducatorPreparationProgramAssociationCohortYearsSupported;
                case "CandidateEducatorPreparationProgramAssociationDegreeSpecializations":
                    return IsCandidateEducatorPreparationProgramAssociationDegreeSpecializationsSupported;
                case "CandidateReference":
                    return IsCandidateReferenceSupported;
                case "EducatorPreparationProgramReference":
                    return IsEducatorPreparationProgramReferenceSupported;
                case "EndDate":
                    return IsEndDateSupported;
                case "EPPProgramPathwayDescriptor":
                    return IsEPPProgramPathwayDescriptorSupported;
                case "ReasonExitedDescriptor":
                    return IsReasonExitedDescriptorSupported;
                case "BeginDate":
                    // Identifying properties are always supported
                    return true;
                case "CandidateIdentifier":
                    // Identifying properties are always supported
                    return true;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "ProgramName":
                    // Identifying properties are always supported
                    return true;
                case "ProgramTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEducatorPreparationProgramAssociationCohortYear model.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationCohortYear : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidateEducatorPreparationProgramAssociation CandidateEducatorPreparationProgramAssociation { get; set; }
        
        string CohortYearTypeDescriptor { get; set; }
        
        short SchoolYear { get; set; }

        // Non-PK properties
        string TermDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateEducatorPreparationProgramAssociationCohortYearMappingContract : IMappingContract
    {
        public CandidateEducatorPreparationProgramAssociationCohortYearMappingContract(
            bool isSchoolYearTypeReferenceSupported,
            bool isTermDescriptorSupported
            )
        {
            IsSchoolYearTypeReferenceSupported = isSchoolYearTypeReferenceSupported;
            IsTermDescriptorSupported = isTermDescriptorSupported;
        }

        public bool IsSchoolYearTypeReferenceSupported { get; }
        public bool IsTermDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolYearTypeReference":
                    return IsSchoolYearTypeReferenceSupported;
                case "TermDescriptor":
                    return IsTermDescriptorSupported;
                case "CohortYearTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateEducatorPreparationProgramAssociationDegreeSpecialization model.
    /// </summary>
    public interface ICandidateEducatorPreparationProgramAssociationDegreeSpecialization : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidateEducatorPreparationProgramAssociation CandidateEducatorPreparationProgramAssociation { get; set; }
        
        string MajorSpecialization { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        string MinorSpecialization { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateEducatorPreparationProgramAssociationDegreeSpecializationMappingContract : IMappingContract
    {
        public CandidateEducatorPreparationProgramAssociationDegreeSpecializationMappingContract(
            bool isEndDateSupported,
            bool isMinorSpecializationSupported
            )
        {
            IsEndDateSupported = isEndDateSupported;
            IsMinorSpecializationSupported = isMinorSpecializationSupported;
        }

        public bool IsEndDateSupported { get; }
        public bool IsMinorSpecializationSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EndDate":
                    return IsEndDateSupported;
                case "MinorSpecialization":
                    return IsMinorSpecializationSupported;
                case "MajorSpecialization":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateElectronicMail model.
    /// </summary>
    public interface ICandidateElectronicMail : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string ElectronicMailAddress { get; set; }
        
        string ElectronicMailTypeDescriptor { get; set; }

        // Non-PK properties
        bool? DoNotPublishIndicator { get; set; }
        bool? PrimaryEmailAddressIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateElectronicMailMappingContract : IMappingContract
    {
        public CandidateElectronicMailMappingContract(
            bool isDoNotPublishIndicatorSupported,
            bool isPrimaryEmailAddressIndicatorSupported
            )
        {
            IsDoNotPublishIndicatorSupported = isDoNotPublishIndicatorSupported;
            IsPrimaryEmailAddressIndicatorSupported = isPrimaryEmailAddressIndicatorSupported;
        }

        public bool IsDoNotPublishIndicatorSupported { get; }
        public bool IsPrimaryEmailAddressIndicatorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DoNotPublishIndicator":
                    return IsDoNotPublishIndicatorSupported;
                case "PrimaryEmailAddressIndicator":
                    return IsPrimaryEmailAddressIndicatorSupported;
                case "ElectronicMailAddress":
                    // Identifying properties are always supported
                    return true;
                case "ElectronicMailTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateLanguage model.
    /// </summary>
    public interface ICandidateLanguage : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string LanguageDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<ICandidateLanguageUse> CandidateLanguageUses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateLanguageMappingContract : IMappingContract
    {
        public CandidateLanguageMappingContract(
            bool isCandidateLanguageUsesSupported,
            Func<ICandidateLanguageUse, bool> isCandidateLanguageUseIncluded
            )
        {
            IsCandidateLanguageUsesSupported = isCandidateLanguageUsesSupported;
            IsCandidateLanguageUseIncluded = isCandidateLanguageUseIncluded;
        }

        public bool IsCandidateLanguageUsesSupported { get; }
        public Func<ICandidateLanguageUse, bool> IsCandidateLanguageUseIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CandidateLanguageUses":
                    return IsCandidateLanguageUsesSupported;
                case "LanguageDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateLanguageUse model.
    /// </summary>
    public interface ICandidateLanguageUse : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidateLanguage CandidateLanguage { get; set; }
        
        string LanguageUseDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateLanguageUseMappingContract : IMappingContract
    {
        public CandidateLanguageUseMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "LanguageUseDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateOtherName model.
    /// </summary>
    public interface ICandidateOtherName : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string OtherNameTypeDescriptor { get; set; }

        // Non-PK properties
        string FirstName { get; set; }
        string GenerationCodeSuffix { get; set; }
        string LastSurname { get; set; }
        string MiddleName { get; set; }
        string PersonalTitlePrefix { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateOtherNameMappingContract : IMappingContract
    {
        public CandidateOtherNameMappingContract(
            bool isFirstNameSupported,
            bool isGenerationCodeSuffixSupported,
            bool isLastSurnameSupported,
            bool isMiddleNameSupported,
            bool isPersonalTitlePrefixSupported
            )
        {
            IsFirstNameSupported = isFirstNameSupported;
            IsGenerationCodeSuffixSupported = isGenerationCodeSuffixSupported;
            IsLastSurnameSupported = isLastSurnameSupported;
            IsMiddleNameSupported = isMiddleNameSupported;
            IsPersonalTitlePrefixSupported = isPersonalTitlePrefixSupported;
        }

        public bool IsFirstNameSupported { get; }
        public bool IsGenerationCodeSuffixSupported { get; }
        public bool IsLastSurnameSupported { get; }
        public bool IsMiddleNameSupported { get; }
        public bool IsPersonalTitlePrefixSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "FirstName":
                    return IsFirstNameSupported;
                case "GenerationCodeSuffix":
                    return IsGenerationCodeSuffixSupported;
                case "LastSurname":
                    return IsLastSurnameSupported;
                case "MiddleName":
                    return IsMiddleNameSupported;
                case "PersonalTitlePrefix":
                    return IsPersonalTitlePrefixSupported;
                case "OtherNameTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidatePersonalIdentificationDocument model.
    /// </summary>
    public interface ICandidatePersonalIdentificationDocument : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string IdentificationDocumentUseDescriptor { get; set; }
        
        string PersonalInformationVerificationDescriptor { get; set; }

        // Non-PK properties
        DateTime? DocumentExpirationDate { get; set; }
        string DocumentTitle { get; set; }
        string IssuerCountryDescriptor { get; set; }
        string IssuerDocumentIdentificationCode { get; set; }
        string IssuerName { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidatePersonalIdentificationDocumentMappingContract : IMappingContract
    {
        public CandidatePersonalIdentificationDocumentMappingContract(
            bool isDocumentExpirationDateSupported,
            bool isDocumentTitleSupported,
            bool isIssuerCountryDescriptorSupported,
            bool isIssuerDocumentIdentificationCodeSupported,
            bool isIssuerNameSupported
            )
        {
            IsDocumentExpirationDateSupported = isDocumentExpirationDateSupported;
            IsDocumentTitleSupported = isDocumentTitleSupported;
            IsIssuerCountryDescriptorSupported = isIssuerCountryDescriptorSupported;
            IsIssuerDocumentIdentificationCodeSupported = isIssuerDocumentIdentificationCodeSupported;
            IsIssuerNameSupported = isIssuerNameSupported;
        }

        public bool IsDocumentExpirationDateSupported { get; }
        public bool IsDocumentTitleSupported { get; }
        public bool IsIssuerCountryDescriptorSupported { get; }
        public bool IsIssuerDocumentIdentificationCodeSupported { get; }
        public bool IsIssuerNameSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DocumentExpirationDate":
                    return IsDocumentExpirationDateSupported;
                case "DocumentTitle":
                    return IsDocumentTitleSupported;
                case "IssuerCountryDescriptor":
                    return IsIssuerCountryDescriptorSupported;
                case "IssuerDocumentIdentificationCode":
                    return IsIssuerDocumentIdentificationCodeSupported;
                case "IssuerName":
                    return IsIssuerNameSupported;
                case "IdentificationDocumentUseDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PersonalInformationVerificationDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateRace model.
    /// </summary>
    public interface ICandidateRace : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string RaceDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateRaceMappingContract : IMappingContract
    {
        public CandidateRaceMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "RaceDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CandidateTelephone model.
    /// </summary>
    public interface ICandidateTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICandidate Candidate { get; set; }
        
        string TelephoneNumber { get; set; }
        
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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CandidateTelephoneMappingContract : IMappingContract
    {
        public CandidateTelephoneMappingContract(
            bool isDoNotPublishIndicatorSupported,
            bool isOrderOfPrioritySupported,
            bool isTextMessageCapabilityIndicatorSupported
            )
        {
            IsDoNotPublishIndicatorSupported = isDoNotPublishIndicatorSupported;
            IsOrderOfPrioritySupported = isOrderOfPrioritySupported;
            IsTextMessageCapabilityIndicatorSupported = isTextMessageCapabilityIndicatorSupported;
        }

        public bool IsDoNotPublishIndicatorSupported { get; }
        public bool IsOrderOfPrioritySupported { get; }
        public bool IsTextMessageCapabilityIndicatorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DoNotPublishIndicator":
                    return IsDoNotPublishIndicatorSupported;
                case "OrderOfPriority":
                    return IsOrderOfPrioritySupported;
                case "TextMessageCapabilityIndicator":
                    return IsTextMessageCapabilityIndicatorSupported;
                case "TelephoneNumber":
                    // Identifying properties are always supported
                    return true;
                case "TelephoneNumberTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CertificationRouteDescriptor model.
    /// </summary>
    public interface ICertificationRouteDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int CertificationRouteDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CertificationRouteDescriptorMappingContract : IMappingContract
    {
        public CertificationRouteDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "CertificationRouteDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CoteachingStyleObservedDescriptor model.
    /// </summary>
    public interface ICoteachingStyleObservedDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int CoteachingStyleObservedDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CoteachingStyleObservedDescriptorMappingContract : IMappingContract
    {
        public CoteachingStyleObservedDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "CoteachingStyleObservedDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialExtension model.
    /// </summary>
    public interface ICredentialExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.ICredential Credential { get; set; }

        // Non-PK properties
        bool? BoardCertificationIndicator { get; set; }
        string CertificationRouteDescriptor { get; set; }
        string CertificationTitle { get; set; }
        DateTime? CredentialStatusDate { get; set; }
        string CredentialStatusDescriptor { get; set; }
        string EducatorRoleDescriptor { get; set; }
        string PersonId { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<ICredentialStudentAcademicRecord> CredentialStudentAcademicRecords { get; set; }

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CredentialExtensionMappingContract : IMappingContract
    {
        public CredentialExtensionMappingContract(
            bool isBoardCertificationIndicatorSupported,
            bool isCertificationRouteDescriptorSupported,
            bool isCertificationTitleSupported,
            bool isCredentialStatusDateSupported,
            bool isCredentialStatusDescriptorSupported,
            bool isCredentialStudentAcademicRecordsSupported,
            bool isEducatorRoleDescriptorSupported,
            bool isPersonIdSupported,
            bool isPersonReferenceSupported,
            bool isSourceSystemDescriptorSupported,
            Func<ICredentialStudentAcademicRecord, bool> isCredentialStudentAcademicRecordIncluded
            )
        {
            IsBoardCertificationIndicatorSupported = isBoardCertificationIndicatorSupported;
            IsCertificationRouteDescriptorSupported = isCertificationRouteDescriptorSupported;
            IsCertificationTitleSupported = isCertificationTitleSupported;
            IsCredentialStatusDateSupported = isCredentialStatusDateSupported;
            IsCredentialStatusDescriptorSupported = isCredentialStatusDescriptorSupported;
            IsCredentialStudentAcademicRecordsSupported = isCredentialStudentAcademicRecordsSupported;
            IsEducatorRoleDescriptorSupported = isEducatorRoleDescriptorSupported;
            IsPersonIdSupported = isPersonIdSupported;
            IsPersonReferenceSupported = isPersonReferenceSupported;
            IsSourceSystemDescriptorSupported = isSourceSystemDescriptorSupported;
            IsCredentialStudentAcademicRecordIncluded = isCredentialStudentAcademicRecordIncluded;
        }

        public bool IsBoardCertificationIndicatorSupported { get; }
        public bool IsCertificationRouteDescriptorSupported { get; }
        public bool IsCertificationTitleSupported { get; }
        public bool IsCredentialStatusDateSupported { get; }
        public bool IsCredentialStatusDescriptorSupported { get; }
        public bool IsCredentialStudentAcademicRecordsSupported { get; }
        public bool IsEducatorRoleDescriptorSupported { get; }
        public bool IsPersonIdSupported { get; }
        public bool IsPersonReferenceSupported { get; }
        public bool IsSourceSystemDescriptorSupported { get; }
        public Func<ICredentialStudentAcademicRecord, bool> IsCredentialStudentAcademicRecordIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "BoardCertificationIndicator":
                    return IsBoardCertificationIndicatorSupported;
                case "CertificationRouteDescriptor":
                    return IsCertificationRouteDescriptorSupported;
                case "CertificationTitle":
                    return IsCertificationTitleSupported;
                case "CredentialStatusDate":
                    return IsCredentialStatusDateSupported;
                case "CredentialStatusDescriptor":
                    return IsCredentialStatusDescriptorSupported;
                case "CredentialStudentAcademicRecords":
                    return IsCredentialStudentAcademicRecordsSupported;
                case "EducatorRoleDescriptor":
                    return IsEducatorRoleDescriptorSupported;
                case "PersonId":
                    return IsPersonIdSupported;
                case "PersonReference":
                    return IsPersonReferenceSupported;
                case "SourceSystemDescriptor":
                    return IsSourceSystemDescriptorSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialStatusDescriptor model.
    /// </summary>
    public interface ICredentialStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int CredentialStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CredentialStatusDescriptorMappingContract : IMappingContract
    {
        public CredentialStatusDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "CredentialStatusDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the CredentialStudentAcademicRecord model.
    /// </summary>
    public interface ICredentialStudentAcademicRecord : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ICredentialExtension CredentialExtension { get; set; }
        
        long EducationOrganizationId { get; set; }
        
        short SchoolYear { get; set; }
        
        string StudentUniqueId { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentAcademicRecordResourceId { get; set; }
        string StudentAcademicRecordDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class CredentialStudentAcademicRecordMappingContract : IMappingContract
    {
        public CredentialStudentAcademicRecordMappingContract(
            bool isStudentAcademicRecordReferenceSupported
            )
        {
            IsStudentAcademicRecordReferenceSupported = isStudentAcademicRecordReferenceSupported;
        }

        public bool IsStudentAcademicRecordReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentAcademicRecordReference":
                    return IsStudentAcademicRecordReferenceSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "StudentUniqueId":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorPreparationProgram model.
    /// </summary>
    public interface IEducatorPreparationProgram : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string ProgramName { get; set; }
        
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties
        string AccreditationStatusDescriptor { get; set; }
        string ProgramId { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEducatorPreparationProgramGradeLevel> EducatorPreparationProgramGradeLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EducatorPreparationProgramMappingContract : IMappingContract
    {
        public EducatorPreparationProgramMappingContract(
            bool isAccreditationStatusDescriptorSupported,
            bool isEducationOrganizationReferenceSupported,
            bool isEducatorPreparationProgramGradeLevelsSupported,
            bool isProgramIdSupported,
            Func<IEducatorPreparationProgramGradeLevel, bool> isEducatorPreparationProgramGradeLevelIncluded
            )
        {
            IsAccreditationStatusDescriptorSupported = isAccreditationStatusDescriptorSupported;
            IsEducationOrganizationReferenceSupported = isEducationOrganizationReferenceSupported;
            IsEducatorPreparationProgramGradeLevelsSupported = isEducatorPreparationProgramGradeLevelsSupported;
            IsProgramIdSupported = isProgramIdSupported;
            IsEducatorPreparationProgramGradeLevelIncluded = isEducatorPreparationProgramGradeLevelIncluded;
        }

        public bool IsAccreditationStatusDescriptorSupported { get; }
        public bool IsEducationOrganizationReferenceSupported { get; }
        public bool IsEducatorPreparationProgramGradeLevelsSupported { get; }
        public bool IsProgramIdSupported { get; }
        public Func<IEducatorPreparationProgramGradeLevel, bool> IsEducatorPreparationProgramGradeLevelIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AccreditationStatusDescriptor":
                    return IsAccreditationStatusDescriptorSupported;
                case "EducationOrganizationReference":
                    return IsEducationOrganizationReferenceSupported;
                case "EducatorPreparationProgramGradeLevels":
                    return IsEducatorPreparationProgramGradeLevelsSupported;
                case "ProgramId":
                    return IsProgramIdSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "ProgramName":
                    // Identifying properties are always supported
                    return true;
                case "ProgramTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorPreparationProgramGradeLevel model.
    /// </summary>
    public interface IEducatorPreparationProgramGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEducatorPreparationProgram EducatorPreparationProgram { get; set; }
        
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EducatorPreparationProgramGradeLevelMappingContract : IMappingContract
    {
        public EducatorPreparationProgramGradeLevelMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "GradeLevelDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EducatorRoleDescriptor model.
    /// </summary>
    public interface IEducatorRoleDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EducatorRoleDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EducatorRoleDescriptorMappingContract : IMappingContract
    {
        public EducatorRoleDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EducatorRoleDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EnglishLanguageExamDescriptor model.
    /// </summary>
    public interface IEnglishLanguageExamDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EnglishLanguageExamDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EnglishLanguageExamDescriptorMappingContract : IMappingContract
    {
        public EnglishLanguageExamDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EnglishLanguageExamDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EPPProgramPathwayDescriptor model.
    /// </summary>
    public interface IEPPProgramPathwayDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EPPProgramPathwayDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EPPProgramPathwayDescriptorMappingContract : IMappingContract
    {
        public EPPProgramPathwayDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EPPProgramPathwayDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Evaluation model.
    /// </summary>
    public interface IEvaluation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        short SchoolYear { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationDescription { get; set; }
        string EvaluationTypeDescriptor { get; set; }
        int? InterRaterReliabilityScore { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationRatingLevel> EvaluationRatingLevels { get; set; }

        // Resource reference data
        Guid? PerformanceEvaluationResourceId { get; set; }
        string PerformanceEvaluationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationMappingContract : IMappingContract
    {
        public EvaluationMappingContract(
            bool isEvaluationDescriptionSupported,
            bool isEvaluationRatingLevelsSupported,
            bool isEvaluationTypeDescriptorSupported,
            bool isInterRaterReliabilityScoreSupported,
            bool isMaxRatingSupported,
            bool isMinRatingSupported,
            bool isPerformanceEvaluationReferenceSupported,
            Func<IEvaluationRatingLevel, bool> isEvaluationRatingLevelIncluded
            )
        {
            IsEvaluationDescriptionSupported = isEvaluationDescriptionSupported;
            IsEvaluationRatingLevelsSupported = isEvaluationRatingLevelsSupported;
            IsEvaluationTypeDescriptorSupported = isEvaluationTypeDescriptorSupported;
            IsInterRaterReliabilityScoreSupported = isInterRaterReliabilityScoreSupported;
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
            IsPerformanceEvaluationReferenceSupported = isPerformanceEvaluationReferenceSupported;
            IsEvaluationRatingLevelIncluded = isEvaluationRatingLevelIncluded;
        }

        public bool IsEvaluationDescriptionSupported { get; }
        public bool IsEvaluationRatingLevelsSupported { get; }
        public bool IsEvaluationTypeDescriptorSupported { get; }
        public bool IsInterRaterReliabilityScoreSupported { get; }
        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }
        public bool IsPerformanceEvaluationReferenceSupported { get; }
        public Func<IEvaluationRatingLevel, bool> IsEvaluationRatingLevelIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EvaluationDescription":
                    return IsEvaluationDescriptionSupported;
                case "EvaluationRatingLevels":
                    return IsEvaluationRatingLevelsSupported;
                case "EvaluationTypeDescriptor":
                    return IsEvaluationTypeDescriptorSupported;
                case "InterRaterReliabilityScore":
                    return IsInterRaterReliabilityScoreSupported;
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "PerformanceEvaluationReference":
                    return IsPerformanceEvaluationReferenceSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElement model.
    /// </summary>
    public interface IEvaluationElement : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string EvaluationElementTitle { get; set; }
        
        string EvaluationObjectiveTitle { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        short SchoolYear { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationTypeDescriptor { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        int? SortOrder { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationElementRatingLevel> EvaluationElementRatingLevels { get; set; }

        // Resource reference data
        Guid? EvaluationObjectiveResourceId { get; set; }
        string EvaluationObjectiveDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationElementMappingContract : IMappingContract
    {
        public EvaluationElementMappingContract(
            bool isEvaluationElementRatingLevelsSupported,
            bool isEvaluationObjectiveReferenceSupported,
            bool isEvaluationTypeDescriptorSupported,
            bool isMaxRatingSupported,
            bool isMinRatingSupported,
            bool isSortOrderSupported,
            Func<IEvaluationElementRatingLevel, bool> isEvaluationElementRatingLevelIncluded
            )
        {
            IsEvaluationElementRatingLevelsSupported = isEvaluationElementRatingLevelsSupported;
            IsEvaluationObjectiveReferenceSupported = isEvaluationObjectiveReferenceSupported;
            IsEvaluationTypeDescriptorSupported = isEvaluationTypeDescriptorSupported;
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
            IsSortOrderSupported = isSortOrderSupported;
            IsEvaluationElementRatingLevelIncluded = isEvaluationElementRatingLevelIncluded;
        }

        public bool IsEvaluationElementRatingLevelsSupported { get; }
        public bool IsEvaluationObjectiveReferenceSupported { get; }
        public bool IsEvaluationTypeDescriptorSupported { get; }
        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }
        public bool IsSortOrderSupported { get; }
        public Func<IEvaluationElementRatingLevel, bool> IsEvaluationElementRatingLevelIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EvaluationElementRatingLevels":
                    return IsEvaluationElementRatingLevelsSupported;
                case "EvaluationObjectiveReference":
                    return IsEvaluationObjectiveReferenceSupported;
                case "EvaluationTypeDescriptor":
                    return IsEvaluationTypeDescriptorSupported;
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "SortOrder":
                    return IsSortOrderSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationElementTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationObjectiveTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRating model.
    /// </summary>
    public interface IEvaluationElementRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        DateTime EvaluationDate { get; set; }
        
        string EvaluationElementTitle { get; set; }
        
        string EvaluationObjectiveTitle { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        string PersonId { get; set; }
        
        short SchoolYear { get; set; }
        
        string SourceSystemDescriptor { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string AreaOfRefinement { get; set; }
        string AreaOfReinforcement { get; set; }
        string Comments { get; set; }
        string EvaluationElementRatingLevelDescriptor { get; set; }
        string Feedback { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationElementRatingResult> EvaluationElementRatingResults { get; set; }

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
        Guid? EvaluationObjectiveRatingResourceId { get; set; }
        string EvaluationObjectiveRatingDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationElementRatingMappingContract : IMappingContract
    {
        public EvaluationElementRatingMappingContract(
            bool isAreaOfRefinementSupported,
            bool isAreaOfReinforcementSupported,
            bool isCommentsSupported,
            bool isEvaluationElementRatingLevelDescriptorSupported,
            bool isEvaluationElementRatingResultsSupported,
            bool isEvaluationElementReferenceSupported,
            bool isEvaluationObjectiveRatingReferenceSupported,
            bool isFeedbackSupported,
            Func<IEvaluationElementRatingResult, bool> isEvaluationElementRatingResultIncluded
            )
        {
            IsAreaOfRefinementSupported = isAreaOfRefinementSupported;
            IsAreaOfReinforcementSupported = isAreaOfReinforcementSupported;
            IsCommentsSupported = isCommentsSupported;
            IsEvaluationElementRatingLevelDescriptorSupported = isEvaluationElementRatingLevelDescriptorSupported;
            IsEvaluationElementRatingResultsSupported = isEvaluationElementRatingResultsSupported;
            IsEvaluationElementReferenceSupported = isEvaluationElementReferenceSupported;
            IsEvaluationObjectiveRatingReferenceSupported = isEvaluationObjectiveRatingReferenceSupported;
            IsFeedbackSupported = isFeedbackSupported;
            IsEvaluationElementRatingResultIncluded = isEvaluationElementRatingResultIncluded;
        }

        public bool IsAreaOfRefinementSupported { get; }
        public bool IsAreaOfReinforcementSupported { get; }
        public bool IsCommentsSupported { get; }
        public bool IsEvaluationElementRatingLevelDescriptorSupported { get; }
        public bool IsEvaluationElementRatingResultsSupported { get; }
        public bool IsEvaluationElementReferenceSupported { get; }
        public bool IsEvaluationObjectiveRatingReferenceSupported { get; }
        public bool IsFeedbackSupported { get; }
        public Func<IEvaluationElementRatingResult, bool> IsEvaluationElementRatingResultIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AreaOfRefinement":
                    return IsAreaOfRefinementSupported;
                case "AreaOfReinforcement":
                    return IsAreaOfReinforcementSupported;
                case "Comments":
                    return IsCommentsSupported;
                case "EvaluationElementRatingLevelDescriptor":
                    return IsEvaluationElementRatingLevelDescriptorSupported;
                case "EvaluationElementRatingResults":
                    return IsEvaluationElementRatingResultsSupported;
                case "EvaluationElementReference":
                    return IsEvaluationElementReferenceSupported;
                case "EvaluationObjectiveRatingReference":
                    return IsEvaluationObjectiveRatingReferenceSupported;
                case "Feedback":
                    return IsFeedbackSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationDate":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationElementTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationObjectiveTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PersonId":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "SourceSystemDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRatingLevel model.
    /// </summary>
    public interface IEvaluationElementRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationElement EvaluationElement { get; set; }
        
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationElementRatingLevelMappingContract : IMappingContract
    {
        public EvaluationElementRatingLevelMappingContract(
            bool isMaxRatingSupported,
            bool isMinRatingSupported
            )
        {
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
        }

        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "EvaluationRatingLevelDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRatingLevelDescriptor model.
    /// </summary>
    public interface IEvaluationElementRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EvaluationElementRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationElementRatingLevelDescriptorMappingContract : IMappingContract
    {
        public EvaluationElementRatingLevelDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EvaluationElementRatingLevelDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationElementRatingResult model.
    /// </summary>
    public interface IEvaluationElementRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationElementRating EvaluationElementRating { get; set; }
        
        decimal Rating { get; set; }
        
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationElementRatingResultMappingContract : IMappingContract
    {
        public EvaluationElementRatingResultMappingContract(
            bool isResultDatatypeTypeDescriptorSupported
            )
        {
            IsResultDatatypeTypeDescriptorSupported = isResultDatatypeTypeDescriptorSupported;
        }

        public bool IsResultDatatypeTypeDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ResultDatatypeTypeDescriptor":
                    return IsResultDatatypeTypeDescriptorSupported;
                case "Rating":
                    // Identifying properties are always supported
                    return true;
                case "RatingResultTitle":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjective model.
    /// </summary>
    public interface IEvaluationObjective : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string EvaluationObjectiveTitle { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        short SchoolYear { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationObjectiveDescription { get; set; }
        string EvaluationTypeDescriptor { get; set; }
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }
        int? SortOrder { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationObjectiveRatingLevel> EvaluationObjectiveRatingLevels { get; set; }

        // Resource reference data
        Guid? EvaluationResourceId { get; set; }
        string EvaluationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationObjectiveMappingContract : IMappingContract
    {
        public EvaluationObjectiveMappingContract(
            bool isEvaluationObjectiveDescriptionSupported,
            bool isEvaluationObjectiveRatingLevelsSupported,
            bool isEvaluationReferenceSupported,
            bool isEvaluationTypeDescriptorSupported,
            bool isMaxRatingSupported,
            bool isMinRatingSupported,
            bool isSortOrderSupported,
            Func<IEvaluationObjectiveRatingLevel, bool> isEvaluationObjectiveRatingLevelIncluded
            )
        {
            IsEvaluationObjectiveDescriptionSupported = isEvaluationObjectiveDescriptionSupported;
            IsEvaluationObjectiveRatingLevelsSupported = isEvaluationObjectiveRatingLevelsSupported;
            IsEvaluationReferenceSupported = isEvaluationReferenceSupported;
            IsEvaluationTypeDescriptorSupported = isEvaluationTypeDescriptorSupported;
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
            IsSortOrderSupported = isSortOrderSupported;
            IsEvaluationObjectiveRatingLevelIncluded = isEvaluationObjectiveRatingLevelIncluded;
        }

        public bool IsEvaluationObjectiveDescriptionSupported { get; }
        public bool IsEvaluationObjectiveRatingLevelsSupported { get; }
        public bool IsEvaluationReferenceSupported { get; }
        public bool IsEvaluationTypeDescriptorSupported { get; }
        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }
        public bool IsSortOrderSupported { get; }
        public Func<IEvaluationObjectiveRatingLevel, bool> IsEvaluationObjectiveRatingLevelIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EvaluationObjectiveDescription":
                    return IsEvaluationObjectiveDescriptionSupported;
                case "EvaluationObjectiveRatingLevels":
                    return IsEvaluationObjectiveRatingLevelsSupported;
                case "EvaluationReference":
                    return IsEvaluationReferenceSupported;
                case "EvaluationTypeDescriptor":
                    return IsEvaluationTypeDescriptorSupported;
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "SortOrder":
                    return IsSortOrderSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationObjectiveTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjectiveRating model.
    /// </summary>
    public interface IEvaluationObjectiveRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        DateTime EvaluationDate { get; set; }
        
        string EvaluationObjectiveTitle { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        string PersonId { get; set; }
        
        short SchoolYear { get; set; }
        
        string SourceSystemDescriptor { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string Comments { get; set; }
        string ObjectiveRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationObjectiveRatingResult> EvaluationObjectiveRatingResults { get; set; }

        // Resource reference data
        Guid? EvaluationObjectiveResourceId { get; set; }
        string EvaluationObjectiveDiscriminator { get; set; }
        Guid? EvaluationRatingResourceId { get; set; }
        string EvaluationRatingDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationObjectiveRatingMappingContract : IMappingContract
    {
        public EvaluationObjectiveRatingMappingContract(
            bool isCommentsSupported,
            bool isEvaluationObjectiveRatingResultsSupported,
            bool isEvaluationObjectiveReferenceSupported,
            bool isEvaluationRatingReferenceSupported,
            bool isObjectiveRatingLevelDescriptorSupported,
            Func<IEvaluationObjectiveRatingResult, bool> isEvaluationObjectiveRatingResultIncluded
            )
        {
            IsCommentsSupported = isCommentsSupported;
            IsEvaluationObjectiveRatingResultsSupported = isEvaluationObjectiveRatingResultsSupported;
            IsEvaluationObjectiveReferenceSupported = isEvaluationObjectiveReferenceSupported;
            IsEvaluationRatingReferenceSupported = isEvaluationRatingReferenceSupported;
            IsObjectiveRatingLevelDescriptorSupported = isObjectiveRatingLevelDescriptorSupported;
            IsEvaluationObjectiveRatingResultIncluded = isEvaluationObjectiveRatingResultIncluded;
        }

        public bool IsCommentsSupported { get; }
        public bool IsEvaluationObjectiveRatingResultsSupported { get; }
        public bool IsEvaluationObjectiveReferenceSupported { get; }
        public bool IsEvaluationRatingReferenceSupported { get; }
        public bool IsObjectiveRatingLevelDescriptorSupported { get; }
        public Func<IEvaluationObjectiveRatingResult, bool> IsEvaluationObjectiveRatingResultIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "Comments":
                    return IsCommentsSupported;
                case "EvaluationObjectiveRatingResults":
                    return IsEvaluationObjectiveRatingResultsSupported;
                case "EvaluationObjectiveReference":
                    return IsEvaluationObjectiveReferenceSupported;
                case "EvaluationRatingReference":
                    return IsEvaluationRatingReferenceSupported;
                case "ObjectiveRatingLevelDescriptor":
                    return IsObjectiveRatingLevelDescriptorSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationDate":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationObjectiveTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PersonId":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "SourceSystemDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjectiveRatingLevel model.
    /// </summary>
    public interface IEvaluationObjectiveRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationObjective EvaluationObjective { get; set; }
        
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationObjectiveRatingLevelMappingContract : IMappingContract
    {
        public EvaluationObjectiveRatingLevelMappingContract(
            bool isMaxRatingSupported,
            bool isMinRatingSupported
            )
        {
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
        }

        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "EvaluationRatingLevelDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationObjectiveRatingResult model.
    /// </summary>
    public interface IEvaluationObjectiveRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationObjectiveRating EvaluationObjectiveRating { get; set; }
        
        decimal Rating { get; set; }
        
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationObjectiveRatingResultMappingContract : IMappingContract
    {
        public EvaluationObjectiveRatingResultMappingContract(
            bool isResultDatatypeTypeDescriptorSupported
            )
        {
            IsResultDatatypeTypeDescriptorSupported = isResultDatatypeTypeDescriptorSupported;
        }

        public bool IsResultDatatypeTypeDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ResultDatatypeTypeDescriptor":
                    return IsResultDatatypeTypeDescriptorSupported;
                case "Rating":
                    // Identifying properties are always supported
                    return true;
                case "RatingResultTitle":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationPeriodDescriptor model.
    /// </summary>
    public interface IEvaluationPeriodDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EvaluationPeriodDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationPeriodDescriptorMappingContract : IMappingContract
    {
        public EvaluationPeriodDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EvaluationPeriodDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRating model.
    /// </summary>
    public interface IEvaluationRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        DateTime EvaluationDate { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        string PersonId { get; set; }
        
        short SchoolYear { get; set; }
        
        string SourceSystemDescriptor { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string EvaluationRatingLevelDescriptor { get; set; }
        string EvaluationRatingStatusDescriptor { get; set; }
        string LocalCourseCode { get; set; }
        long? SchoolId { get; set; }
        string SectionIdentifier { get; set; }
        string SessionName { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IEvaluationRatingResult> EvaluationRatingResults { get; set; }
        ICollection<IEvaluationRatingReviewer> EvaluationRatingReviewers { get; set; }

        // Resource reference data
        Guid? EvaluationResourceId { get; set; }
        string EvaluationDiscriminator { get; set; }
        Guid? PerformanceEvaluationRatingResourceId { get; set; }
        string PerformanceEvaluationRatingDiscriminator { get; set; }
        Guid? SectionResourceId { get; set; }
        string SectionDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingMappingContract : IMappingContract
    {
        public EvaluationRatingMappingContract(
            bool isEvaluationRatingLevelDescriptorSupported,
            bool isEvaluationRatingResultsSupported,
            bool isEvaluationRatingReviewersSupported,
            bool isEvaluationRatingStatusDescriptorSupported,
            bool isEvaluationReferenceSupported,
            bool isLocalCourseCodeSupported,
            bool isPerformanceEvaluationRatingReferenceSupported,
            bool isSchoolIdSupported,
            bool isSectionIdentifierSupported,
            bool isSectionReferenceSupported,
            bool isSessionNameSupported,
            Func<IEvaluationRatingResult, bool> isEvaluationRatingResultIncluded,
            Func<IEvaluationRatingReviewer, bool> isEvaluationRatingReviewerIncluded
            )
        {
            IsEvaluationRatingLevelDescriptorSupported = isEvaluationRatingLevelDescriptorSupported;
            IsEvaluationRatingResultsSupported = isEvaluationRatingResultsSupported;
            IsEvaluationRatingReviewersSupported = isEvaluationRatingReviewersSupported;
            IsEvaluationRatingStatusDescriptorSupported = isEvaluationRatingStatusDescriptorSupported;
            IsEvaluationReferenceSupported = isEvaluationReferenceSupported;
            IsLocalCourseCodeSupported = isLocalCourseCodeSupported;
            IsPerformanceEvaluationRatingReferenceSupported = isPerformanceEvaluationRatingReferenceSupported;
            IsSchoolIdSupported = isSchoolIdSupported;
            IsSectionIdentifierSupported = isSectionIdentifierSupported;
            IsSectionReferenceSupported = isSectionReferenceSupported;
            IsSessionNameSupported = isSessionNameSupported;
            IsEvaluationRatingResultIncluded = isEvaluationRatingResultIncluded;
            IsEvaluationRatingReviewerIncluded = isEvaluationRatingReviewerIncluded;
        }

        public bool IsEvaluationRatingLevelDescriptorSupported { get; }
        public bool IsEvaluationRatingResultsSupported { get; }
        public bool IsEvaluationRatingReviewersSupported { get; }
        public bool IsEvaluationRatingStatusDescriptorSupported { get; }
        public bool IsEvaluationReferenceSupported { get; }
        public bool IsLocalCourseCodeSupported { get; }
        public bool IsPerformanceEvaluationRatingReferenceSupported { get; }
        public bool IsSchoolIdSupported { get; }
        public bool IsSectionIdentifierSupported { get; }
        public bool IsSectionReferenceSupported { get; }
        public bool IsSessionNameSupported { get; }
        public Func<IEvaluationRatingResult, bool> IsEvaluationRatingResultIncluded { get; }
        public Func<IEvaluationRatingReviewer, bool> IsEvaluationRatingReviewerIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EvaluationRatingLevelDescriptor":
                    return IsEvaluationRatingLevelDescriptorSupported;
                case "EvaluationRatingResults":
                    return IsEvaluationRatingResultsSupported;
                case "EvaluationRatingReviewers":
                    return IsEvaluationRatingReviewersSupported;
                case "EvaluationRatingStatusDescriptor":
                    return IsEvaluationRatingStatusDescriptorSupported;
                case "EvaluationReference":
                    return IsEvaluationReferenceSupported;
                case "LocalCourseCode":
                    return IsLocalCourseCodeSupported;
                case "PerformanceEvaluationRatingReference":
                    return IsPerformanceEvaluationRatingReferenceSupported;
                case "SchoolId":
                    return IsSchoolIdSupported;
                case "SectionIdentifier":
                    return IsSectionIdentifierSupported;
                case "SectionReference":
                    return IsSectionReferenceSupported;
                case "SessionName":
                    return IsSessionNameSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationDate":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PersonId":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "SourceSystemDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingLevel model.
    /// </summary>
    public interface IEvaluationRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluation Evaluation { get; set; }
        
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingLevelMappingContract : IMappingContract
    {
        public EvaluationRatingLevelMappingContract(
            bool isMaxRatingSupported,
            bool isMinRatingSupported
            )
        {
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
        }

        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "EvaluationRatingLevelDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingLevelDescriptor model.
    /// </summary>
    public interface IEvaluationRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EvaluationRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingLevelDescriptorMappingContract : IMappingContract
    {
        public EvaluationRatingLevelDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EvaluationRatingLevelDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingResult model.
    /// </summary>
    public interface IEvaluationRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationRating EvaluationRating { get; set; }
        
        decimal Rating { get; set; }
        
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingResultMappingContract : IMappingContract
    {
        public EvaluationRatingResultMappingContract(
            bool isResultDatatypeTypeDescriptorSupported
            )
        {
            IsResultDatatypeTypeDescriptorSupported = isResultDatatypeTypeDescriptorSupported;
        }

        public bool IsResultDatatypeTypeDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ResultDatatypeTypeDescriptor":
                    return IsResultDatatypeTypeDescriptorSupported;
                case "Rating":
                    // Identifying properties are always supported
                    return true;
                case "RatingResultTitle":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingReviewer model.
    /// </summary>
    public interface IEvaluationRatingReviewer : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationRating EvaluationRating { get; set; }
        
        string FirstName { get; set; }
        
        string LastSurname { get; set; }

        // Non-PK properties
        string ReviewerPersonId { get; set; }
        string ReviewerSourceSystemDescriptor { get; set; }

        // One-to-one relationships

        IEvaluationRatingReviewerReceivedTraining EvaluationRatingReviewerReceivedTraining { get; set; }

        // Lists

        // Resource reference data
        Guid? ReviewerPersonResourceId { get; set; }
        string ReviewerPersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingReviewerMappingContract : IMappingContract
    {
        public EvaluationRatingReviewerMappingContract(
            bool isEvaluationRatingReviewerReceivedTrainingSupported,
            bool isReviewerPersonIdSupported,
            bool isReviewerPersonReferenceSupported,
            bool isReviewerSourceSystemDescriptorSupported
            )
        {
            IsEvaluationRatingReviewerReceivedTrainingSupported = isEvaluationRatingReviewerReceivedTrainingSupported;
            IsReviewerPersonIdSupported = isReviewerPersonIdSupported;
            IsReviewerPersonReferenceSupported = isReviewerPersonReferenceSupported;
            IsReviewerSourceSystemDescriptorSupported = isReviewerSourceSystemDescriptorSupported;
        }

        public bool IsEvaluationRatingReviewerReceivedTrainingSupported { get; }
        public bool IsReviewerPersonIdSupported { get; }
        public bool IsReviewerPersonReferenceSupported { get; }
        public bool IsReviewerSourceSystemDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EvaluationRatingReviewerReceivedTraining":
                    return IsEvaluationRatingReviewerReceivedTrainingSupported;
                case "ReviewerPersonId":
                    return IsReviewerPersonIdSupported;
                case "ReviewerPersonReference":
                    return IsReviewerPersonReferenceSupported;
                case "ReviewerSourceSystemDescriptor":
                    return IsReviewerSourceSystemDescriptorSupported;
                case "FirstName":
                    // Identifying properties are always supported
                    return true;
                case "LastSurname":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingReviewerReceivedTraining model.
    /// </summary>
    public interface IEvaluationRatingReviewerReceivedTraining : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IEvaluationRatingReviewer EvaluationRatingReviewer { get; set; }

        // Non-PK properties
        int? InterRaterReliabilityScore { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingReviewerReceivedTrainingMappingContract : IMappingContract
    {
        public EvaluationRatingReviewerReceivedTrainingMappingContract(
            bool isInterRaterReliabilityScoreSupported,
            bool isReceivedTrainingDateSupported
            )
        {
            IsInterRaterReliabilityScoreSupported = isInterRaterReliabilityScoreSupported;
            IsReceivedTrainingDateSupported = isReceivedTrainingDateSupported;
        }

        public bool IsInterRaterReliabilityScoreSupported { get; }
        public bool IsReceivedTrainingDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "InterRaterReliabilityScore":
                    return IsInterRaterReliabilityScoreSupported;
                case "ReceivedTrainingDate":
                    return IsReceivedTrainingDateSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationRatingStatusDescriptor model.
    /// </summary>
    public interface IEvaluationRatingStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EvaluationRatingStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationRatingStatusDescriptorMappingContract : IMappingContract
    {
        public EvaluationRatingStatusDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EvaluationRatingStatusDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the EvaluationTypeDescriptor model.
    /// </summary>
    public interface IEvaluationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int EvaluationTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class EvaluationTypeDescriptorMappingContract : IMappingContract
    {
        public EvaluationTypeDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "EvaluationTypeDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FinancialAid model.
    /// </summary>
    public interface IFinancialAid : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string AidTypeDescriptor { get; set; }
        
        DateTime BeginDate { get; set; }
        
        string StudentUniqueId { get; set; }

        // Non-PK properties
        decimal? AidAmount { get; set; }
        string AidConditionDescription { get; set; }
        DateTime? EndDate { get; set; }
        bool? PellGrantRecipient { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class FinancialAidMappingContract : IMappingContract
    {
        public FinancialAidMappingContract(
            bool isAidAmountSupported,
            bool isAidConditionDescriptionSupported,
            bool isEndDateSupported,
            bool isPellGrantRecipientSupported,
            bool isStudentReferenceSupported
            )
        {
            IsAidAmountSupported = isAidAmountSupported;
            IsAidConditionDescriptionSupported = isAidConditionDescriptionSupported;
            IsEndDateSupported = isEndDateSupported;
            IsPellGrantRecipientSupported = isPellGrantRecipientSupported;
            IsStudentReferenceSupported = isStudentReferenceSupported;
        }

        public bool IsAidAmountSupported { get; }
        public bool IsAidConditionDescriptionSupported { get; }
        public bool IsEndDateSupported { get; }
        public bool IsPellGrantRecipientSupported { get; }
        public bool IsStudentReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AidAmount":
                    return IsAidAmountSupported;
                case "AidConditionDescription":
                    return IsAidConditionDescriptionSupported;
                case "EndDate":
                    return IsEndDateSupported;
                case "PellGrantRecipient":
                    return IsPellGrantRecipientSupported;
                case "StudentReference":
                    return IsStudentReferenceSupported;
                case "AidTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "BeginDate":
                    // Identifying properties are always supported
                    return true;
                case "StudentUniqueId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the GenderDescriptor model.
    /// </summary>
    public interface IGenderDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int GenderDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class GenderDescriptorMappingContract : IMappingContract
    {
        public GenderDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "GenderDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ObjectiveRatingLevelDescriptor model.
    /// </summary>
    public interface IObjectiveRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int ObjectiveRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ObjectiveRatingLevelDescriptorMappingContract : IMappingContract
    {
        public ObjectiveRatingLevelDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "ObjectiveRatingLevelDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluation model.
    /// </summary>
    public interface IPerformanceEvaluation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        short SchoolYear { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string AcademicSubjectDescriptor { get; set; }
        string PerformanceEvaluationDescription { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IPerformanceEvaluationGradeLevel> PerformanceEvaluationGradeLevels { get; set; }
        ICollection<IPerformanceEvaluationRatingLevel> PerformanceEvaluationRatingLevels { get; set; }

        // Resource reference data
        Guid? EducationOrganizationResourceId { get; set; }
        string EducationOrganizationDiscriminator { get; set; }
        Guid? SchoolYearTypeResourceId { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationMappingContract : IMappingContract
    {
        public PerformanceEvaluationMappingContract(
            bool isAcademicSubjectDescriptorSupported,
            bool isEducationOrganizationReferenceSupported,
            bool isPerformanceEvaluationDescriptionSupported,
            bool isPerformanceEvaluationGradeLevelsSupported,
            bool isPerformanceEvaluationRatingLevelsSupported,
            bool isSchoolYearTypeReferenceSupported,
            Func<IPerformanceEvaluationGradeLevel, bool> isPerformanceEvaluationGradeLevelIncluded,
            Func<IPerformanceEvaluationRatingLevel, bool> isPerformanceEvaluationRatingLevelIncluded
            )
        {
            IsAcademicSubjectDescriptorSupported = isAcademicSubjectDescriptorSupported;
            IsEducationOrganizationReferenceSupported = isEducationOrganizationReferenceSupported;
            IsPerformanceEvaluationDescriptionSupported = isPerformanceEvaluationDescriptionSupported;
            IsPerformanceEvaluationGradeLevelsSupported = isPerformanceEvaluationGradeLevelsSupported;
            IsPerformanceEvaluationRatingLevelsSupported = isPerformanceEvaluationRatingLevelsSupported;
            IsSchoolYearTypeReferenceSupported = isSchoolYearTypeReferenceSupported;
            IsPerformanceEvaluationGradeLevelIncluded = isPerformanceEvaluationGradeLevelIncluded;
            IsPerformanceEvaluationRatingLevelIncluded = isPerformanceEvaluationRatingLevelIncluded;
        }

        public bool IsAcademicSubjectDescriptorSupported { get; }
        public bool IsEducationOrganizationReferenceSupported { get; }
        public bool IsPerformanceEvaluationDescriptionSupported { get; }
        public bool IsPerformanceEvaluationGradeLevelsSupported { get; }
        public bool IsPerformanceEvaluationRatingLevelsSupported { get; }
        public bool IsSchoolYearTypeReferenceSupported { get; }
        public Func<IPerformanceEvaluationGradeLevel, bool> IsPerformanceEvaluationGradeLevelIncluded { get; }
        public Func<IPerformanceEvaluationRatingLevel, bool> IsPerformanceEvaluationRatingLevelIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AcademicSubjectDescriptor":
                    return IsAcademicSubjectDescriptorSupported;
                case "EducationOrganizationReference":
                    return IsEducationOrganizationReferenceSupported;
                case "PerformanceEvaluationDescription":
                    return IsPerformanceEvaluationDescriptionSupported;
                case "PerformanceEvaluationGradeLevels":
                    return IsPerformanceEvaluationGradeLevelsSupported;
                case "PerformanceEvaluationRatingLevels":
                    return IsPerformanceEvaluationRatingLevelsSupported;
                case "SchoolYearTypeReference":
                    return IsSchoolYearTypeReferenceSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationGradeLevel model.
    /// </summary>
    public interface IPerformanceEvaluationGradeLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IPerformanceEvaluation PerformanceEvaluation { get; set; }
        
        string GradeLevelDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationGradeLevelMappingContract : IMappingContract
    {
        public PerformanceEvaluationGradeLevelMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "GradeLevelDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRating model.
    /// </summary>
    public interface IPerformanceEvaluationRating : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        string PersonId { get; set; }
        
        short SchoolYear { get; set; }
        
        string SourceSystemDescriptor { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        DateTime ActualDate { get; set; }
        int? ActualDuration { get; set; }
        TimeSpan? ActualTime { get; set; }
        bool? Announced { get; set; }
        string Comments { get; set; }
        string CoteachingStyleObservedDescriptor { get; set; }
        string PerformanceEvaluationRatingLevelDescriptor { get; set; }
        DateTime? ScheduleDate { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IPerformanceEvaluationRatingResult> PerformanceEvaluationRatingResults { get; set; }
        ICollection<IPerformanceEvaluationRatingReviewer> PerformanceEvaluationRatingReviewers { get; set; }

        // Resource reference data
        Guid? PerformanceEvaluationResourceId { get; set; }
        string PerformanceEvaluationDiscriminator { get; set; }
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationRatingMappingContract : IMappingContract
    {
        public PerformanceEvaluationRatingMappingContract(
            bool isActualDateSupported,
            bool isActualDurationSupported,
            bool isActualTimeSupported,
            bool isAnnouncedSupported,
            bool isCommentsSupported,
            bool isCoteachingStyleObservedDescriptorSupported,
            bool isPerformanceEvaluationRatingLevelDescriptorSupported,
            bool isPerformanceEvaluationRatingResultsSupported,
            bool isPerformanceEvaluationRatingReviewersSupported,
            bool isPerformanceEvaluationReferenceSupported,
            bool isPersonReferenceSupported,
            bool isScheduleDateSupported,
            Func<IPerformanceEvaluationRatingResult, bool> isPerformanceEvaluationRatingResultIncluded,
            Func<IPerformanceEvaluationRatingReviewer, bool> isPerformanceEvaluationRatingReviewerIncluded
            )
        {
            IsActualDateSupported = isActualDateSupported;
            IsActualDurationSupported = isActualDurationSupported;
            IsActualTimeSupported = isActualTimeSupported;
            IsAnnouncedSupported = isAnnouncedSupported;
            IsCommentsSupported = isCommentsSupported;
            IsCoteachingStyleObservedDescriptorSupported = isCoteachingStyleObservedDescriptorSupported;
            IsPerformanceEvaluationRatingLevelDescriptorSupported = isPerformanceEvaluationRatingLevelDescriptorSupported;
            IsPerformanceEvaluationRatingResultsSupported = isPerformanceEvaluationRatingResultsSupported;
            IsPerformanceEvaluationRatingReviewersSupported = isPerformanceEvaluationRatingReviewersSupported;
            IsPerformanceEvaluationReferenceSupported = isPerformanceEvaluationReferenceSupported;
            IsPersonReferenceSupported = isPersonReferenceSupported;
            IsScheduleDateSupported = isScheduleDateSupported;
            IsPerformanceEvaluationRatingResultIncluded = isPerformanceEvaluationRatingResultIncluded;
            IsPerformanceEvaluationRatingReviewerIncluded = isPerformanceEvaluationRatingReviewerIncluded;
        }

        public bool IsActualDateSupported { get; }
        public bool IsActualDurationSupported { get; }
        public bool IsActualTimeSupported { get; }
        public bool IsAnnouncedSupported { get; }
        public bool IsCommentsSupported { get; }
        public bool IsCoteachingStyleObservedDescriptorSupported { get; }
        public bool IsPerformanceEvaluationRatingLevelDescriptorSupported { get; }
        public bool IsPerformanceEvaluationRatingResultsSupported { get; }
        public bool IsPerformanceEvaluationRatingReviewersSupported { get; }
        public bool IsPerformanceEvaluationReferenceSupported { get; }
        public bool IsPersonReferenceSupported { get; }
        public bool IsScheduleDateSupported { get; }
        public Func<IPerformanceEvaluationRatingResult, bool> IsPerformanceEvaluationRatingResultIncluded { get; }
        public Func<IPerformanceEvaluationRatingReviewer, bool> IsPerformanceEvaluationRatingReviewerIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ActualDate":
                    return IsActualDateSupported;
                case "ActualDuration":
                    return IsActualDurationSupported;
                case "ActualTime":
                    return IsActualTimeSupported;
                case "Announced":
                    return IsAnnouncedSupported;
                case "Comments":
                    return IsCommentsSupported;
                case "CoteachingStyleObservedDescriptor":
                    return IsCoteachingStyleObservedDescriptorSupported;
                case "PerformanceEvaluationRatingLevelDescriptor":
                    return IsPerformanceEvaluationRatingLevelDescriptorSupported;
                case "PerformanceEvaluationRatingResults":
                    return IsPerformanceEvaluationRatingResultsSupported;
                case "PerformanceEvaluationRatingReviewers":
                    return IsPerformanceEvaluationRatingReviewersSupported;
                case "PerformanceEvaluationReference":
                    return IsPerformanceEvaluationReferenceSupported;
                case "PersonReference":
                    return IsPersonReferenceSupported;
                case "ScheduleDate":
                    return IsScheduleDateSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "PersonId":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "SourceSystemDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingLevel model.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevel : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IPerformanceEvaluation PerformanceEvaluation { get; set; }
        
        string EvaluationRatingLevelDescriptor { get; set; }

        // Non-PK properties
        decimal? MaxRating { get; set; }
        decimal? MinRating { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationRatingLevelMappingContract : IMappingContract
    {
        public PerformanceEvaluationRatingLevelMappingContract(
            bool isMaxRatingSupported,
            bool isMinRatingSupported
            )
        {
            IsMaxRatingSupported = isMaxRatingSupported;
            IsMinRatingSupported = isMinRatingSupported;
        }

        public bool IsMaxRatingSupported { get; }
        public bool IsMinRatingSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MaxRating":
                    return IsMaxRatingSupported;
                case "MinRating":
                    return IsMinRatingSupported;
                case "EvaluationRatingLevelDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingLevelDescriptor model.
    /// </summary>
    public interface IPerformanceEvaluationRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int PerformanceEvaluationRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationRatingLevelDescriptorMappingContract : IMappingContract
    {
        public PerformanceEvaluationRatingLevelDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "PerformanceEvaluationRatingLevelDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingResult model.
    /// </summary>
    public interface IPerformanceEvaluationRatingResult : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IPerformanceEvaluationRating PerformanceEvaluationRating { get; set; }
        
        decimal Rating { get; set; }
        
        string RatingResultTitle { get; set; }

        // Non-PK properties
        string ResultDatatypeTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationRatingResultMappingContract : IMappingContract
    {
        public PerformanceEvaluationRatingResultMappingContract(
            bool isResultDatatypeTypeDescriptorSupported
            )
        {
            IsResultDatatypeTypeDescriptorSupported = isResultDatatypeTypeDescriptorSupported;
        }

        public bool IsResultDatatypeTypeDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ResultDatatypeTypeDescriptor":
                    return IsResultDatatypeTypeDescriptorSupported;
                case "Rating":
                    // Identifying properties are always supported
                    return true;
                case "RatingResultTitle":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingReviewer model.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewer : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IPerformanceEvaluationRating PerformanceEvaluationRating { get; set; }
        
        string FirstName { get; set; }
        
        string LastSurname { get; set; }

        // Non-PK properties
        string ReviewerPersonId { get; set; }
        string ReviewerSourceSystemDescriptor { get; set; }

        // One-to-one relationships

        IPerformanceEvaluationRatingReviewerReceivedTraining PerformanceEvaluationRatingReviewerReceivedTraining { get; set; }

        // Lists

        // Resource reference data
        Guid? ReviewerPersonResourceId { get; set; }
        string ReviewerPersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationRatingReviewerMappingContract : IMappingContract
    {
        public PerformanceEvaluationRatingReviewerMappingContract(
            bool isPerformanceEvaluationRatingReviewerReceivedTrainingSupported,
            bool isReviewerPersonIdSupported,
            bool isReviewerPersonReferenceSupported,
            bool isReviewerSourceSystemDescriptorSupported
            )
        {
            IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported = isPerformanceEvaluationRatingReviewerReceivedTrainingSupported;
            IsReviewerPersonIdSupported = isReviewerPersonIdSupported;
            IsReviewerPersonReferenceSupported = isReviewerPersonReferenceSupported;
            IsReviewerSourceSystemDescriptorSupported = isReviewerSourceSystemDescriptorSupported;
        }

        public bool IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported { get; }
        public bool IsReviewerPersonIdSupported { get; }
        public bool IsReviewerPersonReferenceSupported { get; }
        public bool IsReviewerSourceSystemDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "PerformanceEvaluationRatingReviewerReceivedTraining":
                    return IsPerformanceEvaluationRatingReviewerReceivedTrainingSupported;
                case "ReviewerPersonId":
                    return IsReviewerPersonIdSupported;
                case "ReviewerPersonReference":
                    return IsReviewerPersonReferenceSupported;
                case "ReviewerSourceSystemDescriptor":
                    return IsReviewerSourceSystemDescriptorSupported;
                case "FirstName":
                    // Identifying properties are always supported
                    return true;
                case "LastSurname":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationRatingReviewerReceivedTraining model.
    /// </summary>
    public interface IPerformanceEvaluationRatingReviewerReceivedTraining : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IPerformanceEvaluationRatingReviewer PerformanceEvaluationRatingReviewer { get; set; }

        // Non-PK properties
        int? InterRaterReliabilityScore { get; set; }
        DateTime? ReceivedTrainingDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationRatingReviewerReceivedTrainingMappingContract : IMappingContract
    {
        public PerformanceEvaluationRatingReviewerReceivedTrainingMappingContract(
            bool isInterRaterReliabilityScoreSupported,
            bool isReceivedTrainingDateSupported
            )
        {
            IsInterRaterReliabilityScoreSupported = isInterRaterReliabilityScoreSupported;
            IsReceivedTrainingDateSupported = isReceivedTrainingDateSupported;
        }

        public bool IsInterRaterReliabilityScoreSupported { get; }
        public bool IsReceivedTrainingDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "InterRaterReliabilityScore":
                    return IsInterRaterReliabilityScoreSupported;
                case "ReceivedTrainingDate":
                    return IsReceivedTrainingDateSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PerformanceEvaluationTypeDescriptor model.
    /// </summary>
    public interface IPerformanceEvaluationTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int PerformanceEvaluationTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PerformanceEvaluationTypeDescriptorMappingContract : IMappingContract
    {
        public PerformanceEvaluationTypeDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "PerformanceEvaluationTypeDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricDimension model.
    /// </summary>
    public interface IRubricDimension : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string EvaluationElementTitle { get; set; }
        
        string EvaluationObjectiveTitle { get; set; }
        
        string EvaluationPeriodDescriptor { get; set; }
        
        string EvaluationTitle { get; set; }
        
        string PerformanceEvaluationTitle { get; set; }
        
        string PerformanceEvaluationTypeDescriptor { get; set; }
        
        int RubricRating { get; set; }
        
        short SchoolYear { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties
        string CriterionDescription { get; set; }
        int? DimensionOrder { get; set; }
        string RubricRatingLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EvaluationElementResourceId { get; set; }
        string EvaluationElementDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class RubricDimensionMappingContract : IMappingContract
    {
        public RubricDimensionMappingContract(
            bool isCriterionDescriptionSupported,
            bool isDimensionOrderSupported,
            bool isEvaluationElementReferenceSupported,
            bool isRubricRatingLevelDescriptorSupported
            )
        {
            IsCriterionDescriptionSupported = isCriterionDescriptionSupported;
            IsDimensionOrderSupported = isDimensionOrderSupported;
            IsEvaluationElementReferenceSupported = isEvaluationElementReferenceSupported;
            IsRubricRatingLevelDescriptorSupported = isRubricRatingLevelDescriptorSupported;
        }

        public bool IsCriterionDescriptionSupported { get; }
        public bool IsDimensionOrderSupported { get; }
        public bool IsEvaluationElementReferenceSupported { get; }
        public bool IsRubricRatingLevelDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CriterionDescription":
                    return IsCriterionDescriptionSupported;
                case "DimensionOrder":
                    return IsDimensionOrderSupported;
                case "EvaluationElementReference":
                    return IsEvaluationElementReferenceSupported;
                case "RubricRatingLevelDescriptor":
                    return IsRubricRatingLevelDescriptorSupported;
                case "EducationOrganizationId":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationElementTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationObjectiveTitle":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationPeriodDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "EvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTitle":
                    // Identifying properties are always supported
                    return true;
                case "PerformanceEvaluationTypeDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "RubricRating":
                    // Identifying properties are always supported
                    return true;
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
                case "TermDescriptor":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the RubricRatingLevelDescriptor model.
    /// </summary>
    public interface IRubricRatingLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int RubricRatingLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class RubricRatingLevelDescriptorMappingContract : IMappingContract
    {
        public RubricRatingLevelDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsShortDescriptionSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CodeValue":
                    return IsCodeValueSupported;
                case "Description":
                    return IsDescriptionSupported;
                case "EffectiveBeginDate":
                    return IsEffectiveBeginDateSupported;
                case "EffectiveEndDate":
                    return IsEffectiveEndDateSupported;
                case "Namespace":
                    return IsNamespaceSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                case "RubricRatingLevelDescriptorId":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolExtension model.
    /// </summary>
    public interface ISchoolExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.ISchool School { get; set; }

        // Non-PK properties
        long? PostSecondaryInstitutionId { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PostSecondaryInstitutionResourceId { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolExtensionMappingContract : IMappingContract
    {
        public SchoolExtensionMappingContract(
            bool isPostSecondaryInstitutionIdSupported,
            bool isPostSecondaryInstitutionReferenceSupported
            )
        {
            IsPostSecondaryInstitutionIdSupported = isPostSecondaryInstitutionIdSupported;
            IsPostSecondaryInstitutionReferenceSupported = isPostSecondaryInstitutionReferenceSupported;
        }

        public bool IsPostSecondaryInstitutionIdSupported { get; }
        public bool IsPostSecondaryInstitutionReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "PostSecondaryInstitutionId":
                    return IsPostSecondaryInstitutionIdSupported;
                case "PostSecondaryInstitutionReference":
                    return IsPostSecondaryInstitutionReferenceSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponseExtension model.
    /// </summary>
    public interface ISurveyResponseExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.ISurveyResponse SurveyResponse { get; set; }

        // Non-PK properties
        string PersonId { get; set; }
        string SourceSystemDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SurveyResponseExtensionMappingContract : IMappingContract
    {
        public SurveyResponseExtensionMappingContract(
            bool isPersonIdSupported,
            bool isPersonReferenceSupported,
            bool isSourceSystemDescriptorSupported
            )
        {
            IsPersonIdSupported = isPersonIdSupported;
            IsPersonReferenceSupported = isPersonReferenceSupported;
            IsSourceSystemDescriptorSupported = isSourceSystemDescriptorSupported;
        }

        public bool IsPersonIdSupported { get; }
        public bool IsPersonReferenceSupported { get; }
        public bool IsSourceSystemDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "PersonId":
                    return IsPersonIdSupported;
                case "PersonReference":
                    return IsPersonReferenceSupported;
                case "SourceSystemDescriptor":
                    return IsSourceSystemDescriptorSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveyResponsePersonTargetAssociation model.
    /// </summary>
    public interface ISurveyResponsePersonTargetAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string Namespace { get; set; }
        
        string PersonId { get; set; }
        
        string SourceSystemDescriptor { get; set; }
        
        string SurveyIdentifier { get; set; }
        
        string SurveyResponseIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
        Guid? SurveyResponseResourceId { get; set; }
        string SurveyResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SurveyResponsePersonTargetAssociationMappingContract : IMappingContract
    {
        public SurveyResponsePersonTargetAssociationMappingContract(
            bool isPersonReferenceSupported,
            bool isSurveyResponseReferenceSupported
            )
        {
            IsPersonReferenceSupported = isPersonReferenceSupported;
            IsSurveyResponseReferenceSupported = isSurveyResponseReferenceSupported;
        }

        public bool IsPersonReferenceSupported { get; }
        public bool IsSurveyResponseReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "PersonReference":
                    return IsPersonReferenceSupported;
                case "SurveyResponseReference":
                    return IsSurveyResponseReferenceSupported;
                case "Namespace":
                    // Identifying properties are always supported
                    return true;
                case "PersonId":
                    // Identifying properties are always supported
                    return true;
                case "SourceSystemDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SurveyIdentifier":
                    // Identifying properties are always supported
                    return true;
                case "SurveyResponseIdentifier":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SurveySectionResponsePersonTargetAssociation model.
    /// </summary>
    public interface ISurveySectionResponsePersonTargetAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string Namespace { get; set; }
        
        string PersonId { get; set; }
        
        string SourceSystemDescriptor { get; set; }
        
        string SurveyIdentifier { get; set; }
        
        string SurveyResponseIdentifier { get; set; }
        
        string SurveySectionTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PersonResourceId { get; set; }
        string PersonDiscriminator { get; set; }
        Guid? SurveySectionResponseResourceId { get; set; }
        string SurveySectionResponseDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SurveySectionResponsePersonTargetAssociationMappingContract : IMappingContract
    {
        public SurveySectionResponsePersonTargetAssociationMappingContract(
            bool isPersonReferenceSupported,
            bool isSurveySectionResponseReferenceSupported
            )
        {
            IsPersonReferenceSupported = isPersonReferenceSupported;
            IsSurveySectionResponseReferenceSupported = isSurveySectionResponseReferenceSupported;
        }

        public bool IsPersonReferenceSupported { get; }
        public bool IsSurveySectionResponseReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "PersonReference":
                    return IsPersonReferenceSupported;
                case "SurveySectionResponseReference":
                    return IsSurveySectionResponseReferenceSupported;
                case "Namespace":
                    // Identifying properties are always supported
                    return true;
                case "PersonId":
                    // Identifying properties are always supported
                    return true;
                case "SourceSystemDescriptor":
                    // Identifying properties are always supported
                    return true;
                case "SurveyIdentifier":
                    // Identifying properties are always supported
                    return true;
                case "SurveyResponseIdentifier":
                    // Identifying properties are always supported
                    return true;
                case "SurveySectionTitle":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }
}

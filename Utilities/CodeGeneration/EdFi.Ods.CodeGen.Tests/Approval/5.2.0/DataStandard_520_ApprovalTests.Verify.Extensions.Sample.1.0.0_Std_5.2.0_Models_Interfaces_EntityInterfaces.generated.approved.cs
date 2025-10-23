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

namespace EdFi.Ods.Entities.Common.Sample
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ArtMediumDescriptor model.
    /// </summary>
    public interface IArtMediumDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int ArtMediumDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ArtMediumDescriptorMappingContract : IMappingContract
    {
        public ArtMediumDescriptorMappingContract(
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
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ArtMediumDescriptorId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Bus model.
    /// </summary>
    public interface IBus : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string BusId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class BusMappingContract : IMappingContract
    {
        public BusMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "BusId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRoute model.
    /// </summary>
    public interface IBusRoute : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string BusId { get; set; }
        
        int BusRouteNumber { get; set; }

        // Non-PK properties
        DateTime? BeginDate { get; set; }
        string BusRouteDirection { get; set; }
        int? BusRouteDuration { get; set; }
        bool? Daily { get; set; }
        string DisabilityDescriptor { get; set; }
        long? EducationOrganizationId { get; set; }
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
        Guid? BusResourceId { get; set; }
        string BusDiscriminator { get; set; }
        Guid? StaffEducationOrganizationAssignmentAssociationResourceId { get; set; }
        string StaffEducationOrganizationAssignmentAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class BusRouteMappingContract : IMappingContract
    {
        public BusRouteMappingContract(
            bool isBeginDateSupported,
            bool isBusReferenceSupported,
            bool isBusRouteBusYearsSupported,
            bool isBusRouteDirectionSupported,
            bool isBusRouteDurationSupported,
            bool isBusRouteProgramsSupported,
            bool isBusRouteServiceAreaPostalCodesSupported,
            bool isBusRouteStartTimesSupported,
            bool isBusRouteTelephonesSupported,
            bool isDailySupported,
            bool isDisabilityDescriptorSupported,
            bool isEducationOrganizationIdSupported,
            bool isExpectedTransitTimeSupported,
            bool isHoursPerWeekSupported,
            bool isOperatingCostSupported,
            bool isOptimalCapacitySupported,
            bool isStaffClassificationDescriptorSupported,
            bool isStaffEducationOrganizationAssignmentAssociationReferenceSupported,
            bool isStaffUniqueIdSupported,
            bool isStartDateSupported,
            bool isWeeklyMileageSupported,
            bool isBusRouteBusYearsItemCreatable,
            Func<IBusRouteBusYear, bool> isBusRouteBusYearIncluded,
            bool isBusRouteProgramsItemCreatable,
            Func<IBusRouteProgram, bool> isBusRouteProgramIncluded,
            bool isBusRouteServiceAreaPostalCodesItemCreatable,
            Func<IBusRouteServiceAreaPostalCode, bool> isBusRouteServiceAreaPostalCodeIncluded,
            bool isBusRouteStartTimesItemCreatable,
            Func<IBusRouteStartTime, bool> isBusRouteStartTimeIncluded,
            bool isBusRouteTelephonesItemCreatable,
            Func<IBusRouteTelephone, bool> isBusRouteTelephoneIncluded
            )
        {
            IsBeginDateSupported = isBeginDateSupported;
            IsBusReferenceSupported = isBusReferenceSupported;
            IsBusRouteBusYearsSupported = isBusRouteBusYearsSupported;
            IsBusRouteDirectionSupported = isBusRouteDirectionSupported;
            IsBusRouteDurationSupported = isBusRouteDurationSupported;
            IsBusRouteProgramsSupported = isBusRouteProgramsSupported;
            IsBusRouteServiceAreaPostalCodesSupported = isBusRouteServiceAreaPostalCodesSupported;
            IsBusRouteStartTimesSupported = isBusRouteStartTimesSupported;
            IsBusRouteTelephonesSupported = isBusRouteTelephonesSupported;
            IsDailySupported = isDailySupported;
            IsDisabilityDescriptorSupported = isDisabilityDescriptorSupported;
            IsEducationOrganizationIdSupported = isEducationOrganizationIdSupported;
            IsExpectedTransitTimeSupported = isExpectedTransitTimeSupported;
            IsHoursPerWeekSupported = isHoursPerWeekSupported;
            IsOperatingCostSupported = isOperatingCostSupported;
            IsOptimalCapacitySupported = isOptimalCapacitySupported;
            IsStaffClassificationDescriptorSupported = isStaffClassificationDescriptorSupported;
            IsStaffEducationOrganizationAssignmentAssociationReferenceSupported = isStaffEducationOrganizationAssignmentAssociationReferenceSupported;
            IsStaffUniqueIdSupported = isStaffUniqueIdSupported;
            IsStartDateSupported = isStartDateSupported;
            IsWeeklyMileageSupported = isWeeklyMileageSupported;
            IsBusRouteBusYearsItemCreatable = isBusRouteBusYearsItemCreatable;
            IsBusRouteBusYearIncluded = isBusRouteBusYearIncluded;
            IsBusRouteProgramsItemCreatable = isBusRouteProgramsItemCreatable;
            IsBusRouteProgramIncluded = isBusRouteProgramIncluded;
            IsBusRouteServiceAreaPostalCodesItemCreatable = isBusRouteServiceAreaPostalCodesItemCreatable;
            IsBusRouteServiceAreaPostalCodeIncluded = isBusRouteServiceAreaPostalCodeIncluded;
            IsBusRouteStartTimesItemCreatable = isBusRouteStartTimesItemCreatable;
            IsBusRouteStartTimeIncluded = isBusRouteStartTimeIncluded;
            IsBusRouteTelephonesItemCreatable = isBusRouteTelephonesItemCreatable;
            IsBusRouteTelephoneIncluded = isBusRouteTelephoneIncluded;
        }

        public bool IsBeginDateSupported { get; }
        public bool IsBusReferenceSupported { get; }
        public bool IsBusRouteBusYearsSupported { get; }
        public bool IsBusRouteDirectionSupported { get; }
        public bool IsBusRouteDurationSupported { get; }
        public bool IsBusRouteProgramsSupported { get; }
        public bool IsBusRouteServiceAreaPostalCodesSupported { get; }
        public bool IsBusRouteStartTimesSupported { get; }
        public bool IsBusRouteTelephonesSupported { get; }
        public bool IsDailySupported { get; }
        public bool IsDisabilityDescriptorSupported { get; }
        public bool IsEducationOrganizationIdSupported { get; }
        public bool IsExpectedTransitTimeSupported { get; }
        public bool IsHoursPerWeekSupported { get; }
        public bool IsOperatingCostSupported { get; }
        public bool IsOptimalCapacitySupported { get; }
        public bool IsStaffClassificationDescriptorSupported { get; }
        public bool IsStaffEducationOrganizationAssignmentAssociationReferenceSupported { get; }
        public bool IsStaffUniqueIdSupported { get; }
        public bool IsStartDateSupported { get; }
        public bool IsWeeklyMileageSupported { get; }
        public bool IsBusRouteBusYearsItemCreatable { get; }
        public Func<IBusRouteBusYear, bool> IsBusRouteBusYearIncluded { get; }
        public bool IsBusRouteProgramsItemCreatable { get; }
        public Func<IBusRouteProgram, bool> IsBusRouteProgramIncluded { get; }
        public bool IsBusRouteServiceAreaPostalCodesItemCreatable { get; }
        public Func<IBusRouteServiceAreaPostalCode, bool> IsBusRouteServiceAreaPostalCodeIncluded { get; }
        public bool IsBusRouteStartTimesItemCreatable { get; }
        public Func<IBusRouteStartTime, bool> IsBusRouteStartTimeIncluded { get; }
        public bool IsBusRouteTelephonesItemCreatable { get; }
        public Func<IBusRouteTelephone, bool> IsBusRouteTelephoneIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "BeginDate":
                    return IsBeginDateSupported;
                case "BusReference":
                    return IsBusReferenceSupported;
                case "BusRouteBusYears":
                    return IsBusRouteBusYearsSupported;
                case "BusRouteDirection":
                    return IsBusRouteDirectionSupported;
                case "BusRouteDuration":
                    return IsBusRouteDurationSupported;
                case "BusRoutePrograms":
                    return IsBusRouteProgramsSupported;
                case "BusRouteServiceAreaPostalCodes":
                    return IsBusRouteServiceAreaPostalCodesSupported;
                case "BusRouteStartTimes":
                    return IsBusRouteStartTimesSupported;
                case "BusRouteTelephones":
                    return IsBusRouteTelephonesSupported;
                case "Daily":
                    return IsDailySupported;
                case "DisabilityDescriptor":
                    return IsDisabilityDescriptorSupported;
                case "EducationOrganizationId":
                    return IsEducationOrganizationIdSupported;
                case "ExpectedTransitTime":
                    return IsExpectedTransitTimeSupported;
                case "HoursPerWeek":
                    return IsHoursPerWeekSupported;
                case "OperatingCost":
                    return IsOperatingCostSupported;
                case "OptimalCapacity":
                    return IsOptimalCapacitySupported;
                case "StaffClassificationDescriptor":
                    return IsStaffClassificationDescriptorSupported;
                case "StaffEducationOrganizationAssignmentAssociationReference":
                    return IsStaffEducationOrganizationAssignmentAssociationReferenceSupported;
                case "StaffUniqueId":
                    return IsStaffUniqueIdSupported;
                case "StartDate":
                    return IsStartDateSupported;
                case "WeeklyMileage":
                    return IsWeeklyMileageSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "BusId":
                    return true;
                case "BusRouteNumber":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "BusRouteBusYears":
                    return IsBusRouteBusYearsItemCreatable;
                case "BusRoutePrograms":
                    return IsBusRouteProgramsItemCreatable;
                case "BusRouteServiceAreaPostalCodes":
                    return IsBusRouteServiceAreaPostalCodesItemCreatable;
                case "BusRouteStartTimes":
                    return IsBusRouteStartTimesItemCreatable;
                case "BusRouteTelephones":
                    return IsBusRouteTelephonesItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteBusYear model.
    /// </summary>
    public interface IBusRouteBusYear : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IBusRoute BusRoute { get; set; }
        
        short BusYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class BusRouteBusYearMappingContract : IMappingContract
    {
        public BusRouteBusYearMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "BusYear":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteProgram model.
    /// </summary>
    public interface IBusRouteProgram : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IBusRoute BusRoute { get; set; }
        
        long EducationOrganizationId { get; set; }
        
        string ProgramName { get; set; }
        
        string ProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? ProgramResourceId { get; set; }
        string ProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class BusRouteProgramMappingContract : IMappingContract
    {
        public BusRouteProgramMappingContract(
            bool isProgramReferenceSupported
            )
        {
            IsProgramReferenceSupported = isProgramReferenceSupported;
        }

        public bool IsProgramReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ProgramReference":
                    return IsProgramReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "EducationOrganizationId":
                    return true;
                case "ProgramName":
                    return true;
                case "ProgramTypeDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteServiceAreaPostalCode model.
    /// </summary>
    public interface IBusRouteServiceAreaPostalCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IBusRoute BusRoute { get; set; }
        
        string ServiceAreaPostalCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class BusRouteServiceAreaPostalCodeMappingContract : IMappingContract
    {
        public BusRouteServiceAreaPostalCodeMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ServiceAreaPostalCode":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteStartTime model.
    /// </summary>
    public interface IBusRouteStartTime : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IBusRoute BusRoute { get; set; }
        
        TimeSpan StartTime { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class BusRouteStartTimeMappingContract : IMappingContract
    {
        public BusRouteStartTimeMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "StartTime":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the BusRouteTelephone model.
    /// </summary>
    public interface IBusRouteTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IBusRoute BusRoute { get; set; }
        
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
    public class BusRouteTelephoneMappingContract : IMappingContract
    {
        public BusRouteTelephoneMappingContract(
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
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "TelephoneNumber":
                    return true;
                case "TelephoneNumberTypeDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactAddressExtension model.
    /// </summary>
    public interface IContactAddressExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IContactAddress ContactAddress { get; set; }

        // Non-PK properties
        string Complex { get; set; }
        bool OnBusRoute { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IContactAddressSchoolDistrict> ContactAddressSchoolDistricts { get; set; }
        ICollection<IContactAddressTerm> ContactAddressTerms { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactAddressExtensionMappingContract : IMappingContract
    {
        public ContactAddressExtensionMappingContract(
            bool isComplexSupported,
            bool isContactAddressSchoolDistrictsSupported,
            bool isContactAddressTermsSupported,
            bool isOnBusRouteSupported,
            bool isContactAddressSchoolDistrictsItemCreatable,
            Func<IContactAddressSchoolDistrict, bool> isContactAddressSchoolDistrictIncluded,
            bool isContactAddressTermsItemCreatable,
            Func<IContactAddressTerm, bool> isContactAddressTermIncluded
            )
        {
            IsComplexSupported = isComplexSupported;
            IsContactAddressSchoolDistrictsSupported = isContactAddressSchoolDistrictsSupported;
            IsContactAddressTermsSupported = isContactAddressTermsSupported;
            IsOnBusRouteSupported = isOnBusRouteSupported;
            IsContactAddressSchoolDistrictsItemCreatable = isContactAddressSchoolDistrictsItemCreatable;
            IsContactAddressSchoolDistrictIncluded = isContactAddressSchoolDistrictIncluded;
            IsContactAddressTermsItemCreatable = isContactAddressTermsItemCreatable;
            IsContactAddressTermIncluded = isContactAddressTermIncluded;
        }

        public bool IsComplexSupported { get; }
        public bool IsContactAddressSchoolDistrictsSupported { get; }
        public bool IsContactAddressTermsSupported { get; }
        public bool IsOnBusRouteSupported { get; }
        public bool IsContactAddressSchoolDistrictsItemCreatable { get; }
        public Func<IContactAddressSchoolDistrict, bool> IsContactAddressSchoolDistrictIncluded { get; }
        public bool IsContactAddressTermsItemCreatable { get; }
        public Func<IContactAddressTerm, bool> IsContactAddressTermIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "Complex":
                    return IsComplexSupported;
                case "ContactAddressSchoolDistricts":
                    return IsContactAddressSchoolDistrictsSupported;
                case "ContactAddressTerms":
                    return IsContactAddressTermsSupported;
                case "OnBusRoute":
                    return IsOnBusRouteSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "ContactAddressSchoolDistricts":
                    return IsContactAddressSchoolDistrictsItemCreatable;
                case "ContactAddressTerms":
                    return IsContactAddressTermsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactAddressSchoolDistrict model.
    /// </summary>
    public interface IContactAddressSchoolDistrict : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactAddressExtension ContactAddressExtension { get; set; }
        
        string SchoolDistrict { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactAddressSchoolDistrictMappingContract : IMappingContract
    {
        public ContactAddressSchoolDistrictMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "SchoolDistrict":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactAddressTerm model.
    /// </summary>
    public interface IContactAddressTerm : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactAddressExtension ContactAddressExtension { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactAddressTermMappingContract : IMappingContract
    {
        public ContactAddressTermMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "TermDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactAuthor model.
    /// </summary>
    public interface IContactAuthor : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }
        
        string Author { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactAuthorMappingContract : IMappingContract
    {
        public ContactAuthorMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "Author":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactCeilingHeight model.
    /// </summary>
    public interface IContactCeilingHeight : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }
        
        decimal CeilingHeight { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactCeilingHeightMappingContract : IMappingContract
    {
        public ContactCeilingHeightMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "CeilingHeight":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactCTEProgramService model.
    /// </summary>
    public interface IContactCTEProgramService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }

        // Non-PK properties
        string CIPCode { get; set; }
        string CTEProgramServiceDescriptor { get; set; }
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactCTEProgramServiceMappingContract : IMappingContract
    {
        public ContactCTEProgramServiceMappingContract(
            bool isCIPCodeSupported,
            bool isCTEProgramServiceDescriptorSupported,
            bool isPrimaryIndicatorSupported,
            bool isServiceBeginDateSupported,
            bool isServiceEndDateSupported
            )
        {
            IsCIPCodeSupported = isCIPCodeSupported;
            IsCTEProgramServiceDescriptorSupported = isCTEProgramServiceDescriptorSupported;
            IsPrimaryIndicatorSupported = isPrimaryIndicatorSupported;
            IsServiceBeginDateSupported = isServiceBeginDateSupported;
            IsServiceEndDateSupported = isServiceEndDateSupported;
        }

        public bool IsCIPCodeSupported { get; }
        public bool IsCTEProgramServiceDescriptorSupported { get; }
        public bool IsPrimaryIndicatorSupported { get; }
        public bool IsServiceBeginDateSupported { get; }
        public bool IsServiceEndDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CIPCode":
                    return IsCIPCodeSupported;
                case "CTEProgramServiceDescriptor":
                    return IsCTEProgramServiceDescriptorSupported;
                case "PrimaryIndicator":
                    return IsPrimaryIndicatorSupported;
                case "ServiceBeginDate":
                    return IsServiceBeginDateSupported;
                case "ServiceEndDate":
                    return IsServiceEndDateSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactEducationContent model.
    /// </summary>
    public interface IContactEducationContent : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }
        
        string ContentIdentifier { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? EducationContentResourceId { get; set; }
        string EducationContentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactEducationContentMappingContract : IMappingContract
    {
        public ContactEducationContentMappingContract(
            bool isEducationContentReferenceSupported
            )
        {
            IsEducationContentReferenceSupported = isEducationContentReferenceSupported;
        }

        public bool IsEducationContentReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EducationContentReference":
                    return IsEducationContentReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ContentIdentifier":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactExtension model.
    /// </summary>
    public interface IContactExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IContact Contact { get; set; }

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

        IContactCTEProgramService ContactCTEProgramService { get; set; }

        IContactTeacherConference ContactTeacherConference { get; set; }

        // Lists
        ICollection<IContactAuthor> ContactAuthors { get; set; }
        ICollection<IContactCeilingHeight> ContactCeilingHeights { get; set; }
        ICollection<IContactEducationContent> ContactEducationContents { get; set; }
        ICollection<IContactFavoriteBookTitle> ContactFavoriteBookTitles { get; set; }
        ICollection<IContactStudentProgramAssociation> ContactStudentProgramAssociations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactExtensionMappingContract : IMappingContract
    {
        public ContactExtensionMappingContract(
            bool isAverageCarLineWaitSupported,
            bool isBecameParentSupported,
            bool isCoffeeSpendSupported,
            bool isContactAuthorsSupported,
            bool isContactCeilingHeightsSupported,
            bool isContactCTEProgramServiceSupported,
            bool isContactEducationContentsSupported,
            bool isContactFavoriteBookTitlesSupported,
            bool isContactStudentProgramAssociationsSupported,
            bool isContactTeacherConferenceSupported,
            bool isCredentialFieldDescriptorSupported,
            bool isDurationSupported,
            bool isGPASupported,
            bool isGraduationDateSupported,
            bool isIsSportsFanSupported,
            bool isLuckyNumberSupported,
            bool isPreferredWakeUpTimeSupported,
            bool isRainCertaintySupported,
            bool isContactCTEProgramServiceCreatable,
            bool isContactTeacherConferenceCreatable,
            bool isContactAuthorsItemCreatable,
            Func<IContactAuthor, bool> isContactAuthorIncluded,
            bool isContactCeilingHeightsItemCreatable,
            Func<IContactCeilingHeight, bool> isContactCeilingHeightIncluded,
            bool isContactEducationContentsItemCreatable,
            Func<IContactEducationContent, bool> isContactEducationContentIncluded,
            bool isContactFavoriteBookTitlesItemCreatable,
            Func<IContactFavoriteBookTitle, bool> isContactFavoriteBookTitleIncluded,
            bool isContactStudentProgramAssociationsItemCreatable,
            Func<IContactStudentProgramAssociation, bool> isContactStudentProgramAssociationIncluded
            )
        {
            IsAverageCarLineWaitSupported = isAverageCarLineWaitSupported;
            IsBecameParentSupported = isBecameParentSupported;
            IsCoffeeSpendSupported = isCoffeeSpendSupported;
            IsContactAuthorsSupported = isContactAuthorsSupported;
            IsContactCeilingHeightsSupported = isContactCeilingHeightsSupported;
            IsContactCTEProgramServiceSupported = isContactCTEProgramServiceSupported;
            IsContactEducationContentsSupported = isContactEducationContentsSupported;
            IsContactFavoriteBookTitlesSupported = isContactFavoriteBookTitlesSupported;
            IsContactStudentProgramAssociationsSupported = isContactStudentProgramAssociationsSupported;
            IsContactTeacherConferenceSupported = isContactTeacherConferenceSupported;
            IsCredentialFieldDescriptorSupported = isCredentialFieldDescriptorSupported;
            IsDurationSupported = isDurationSupported;
            IsGPASupported = isGPASupported;
            IsGraduationDateSupported = isGraduationDateSupported;
            IsIsSportsFanSupported = isIsSportsFanSupported;
            IsLuckyNumberSupported = isLuckyNumberSupported;
            IsPreferredWakeUpTimeSupported = isPreferredWakeUpTimeSupported;
            IsRainCertaintySupported = isRainCertaintySupported;
            IsContactCTEProgramServiceCreatable = isContactCTEProgramServiceCreatable;
            IsContactTeacherConferenceCreatable = isContactTeacherConferenceCreatable;
            IsContactAuthorsItemCreatable = isContactAuthorsItemCreatable;
            IsContactAuthorIncluded = isContactAuthorIncluded;
            IsContactCeilingHeightsItemCreatable = isContactCeilingHeightsItemCreatable;
            IsContactCeilingHeightIncluded = isContactCeilingHeightIncluded;
            IsContactEducationContentsItemCreatable = isContactEducationContentsItemCreatable;
            IsContactEducationContentIncluded = isContactEducationContentIncluded;
            IsContactFavoriteBookTitlesItemCreatable = isContactFavoriteBookTitlesItemCreatable;
            IsContactFavoriteBookTitleIncluded = isContactFavoriteBookTitleIncluded;
            IsContactStudentProgramAssociationsItemCreatable = isContactStudentProgramAssociationsItemCreatable;
            IsContactStudentProgramAssociationIncluded = isContactStudentProgramAssociationIncluded;
        }

        public bool IsAverageCarLineWaitSupported { get; }
        public bool IsBecameParentSupported { get; }
        public bool IsCoffeeSpendSupported { get; }
        public bool IsContactAuthorsSupported { get; }
        public bool IsContactCeilingHeightsSupported { get; }
        public bool IsContactCTEProgramServiceSupported { get; }
        public bool IsContactEducationContentsSupported { get; }
        public bool IsContactFavoriteBookTitlesSupported { get; }
        public bool IsContactStudentProgramAssociationsSupported { get; }
        public bool IsContactTeacherConferenceSupported { get; }
        public bool IsCredentialFieldDescriptorSupported { get; }
        public bool IsDurationSupported { get; }
        public bool IsGPASupported { get; }
        public bool IsGraduationDateSupported { get; }
        public bool IsIsSportsFanSupported { get; }
        public bool IsLuckyNumberSupported { get; }
        public bool IsPreferredWakeUpTimeSupported { get; }
        public bool IsRainCertaintySupported { get; }
        public bool IsContactCTEProgramServiceCreatable { get; }
        public bool IsContactTeacherConferenceCreatable { get; }
        public bool IsContactAuthorsItemCreatable { get; }
        public Func<IContactAuthor, bool> IsContactAuthorIncluded { get; }
        public bool IsContactCeilingHeightsItemCreatable { get; }
        public Func<IContactCeilingHeight, bool> IsContactCeilingHeightIncluded { get; }
        public bool IsContactEducationContentsItemCreatable { get; }
        public Func<IContactEducationContent, bool> IsContactEducationContentIncluded { get; }
        public bool IsContactFavoriteBookTitlesItemCreatable { get; }
        public Func<IContactFavoriteBookTitle, bool> IsContactFavoriteBookTitleIncluded { get; }
        public bool IsContactStudentProgramAssociationsItemCreatable { get; }
        public Func<IContactStudentProgramAssociation, bool> IsContactStudentProgramAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AverageCarLineWait":
                    return IsAverageCarLineWaitSupported;
                case "BecameParent":
                    return IsBecameParentSupported;
                case "CoffeeSpend":
                    return IsCoffeeSpendSupported;
                case "ContactAuthors":
                    return IsContactAuthorsSupported;
                case "ContactCeilingHeights":
                    return IsContactCeilingHeightsSupported;
                case "ContactCTEProgramService":
                    return IsContactCTEProgramServiceSupported;
                case "ContactEducationContents":
                    return IsContactEducationContentsSupported;
                case "ContactFavoriteBookTitles":
                    return IsContactFavoriteBookTitlesSupported;
                case "ContactStudentProgramAssociations":
                    return IsContactStudentProgramAssociationsSupported;
                case "ContactTeacherConference":
                    return IsContactTeacherConferenceSupported;
                case "CredentialFieldDescriptor":
                    return IsCredentialFieldDescriptorSupported;
                case "Duration":
                    return IsDurationSupported;
                case "GPA":
                    return IsGPASupported;
                case "GraduationDate":
                    return IsGraduationDateSupported;
                case "IsSportsFan":
                    return IsIsSportsFanSupported;
                case "LuckyNumber":
                    return IsLuckyNumberSupported;
                case "PreferredWakeUpTime":
                    return IsPreferredWakeUpTimeSupported;
                case "RainCertainty":
                    return IsRainCertaintySupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "ContactCTEProgramService":
                    return IsContactCTEProgramServiceCreatable;
                case "ContactTeacherConference":
                    return IsContactTeacherConferenceCreatable;
                case "ContactAuthors":
                    return IsContactAuthorsItemCreatable;
                case "ContactCeilingHeights":
                    return IsContactCeilingHeightsItemCreatable;
                case "ContactEducationContents":
                    return IsContactEducationContentsItemCreatable;
                case "ContactFavoriteBookTitles":
                    return IsContactFavoriteBookTitlesItemCreatable;
                case "ContactStudentProgramAssociations":
                    return IsContactStudentProgramAssociationsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactFavoriteBookTitle model.
    /// </summary>
    public interface IContactFavoriteBookTitle : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }
        
        string FavoriteBookTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactFavoriteBookTitleMappingContract : IMappingContract
    {
        public ContactFavoriteBookTitleMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "FavoriteBookTitle":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactStudentProgramAssociation model.
    /// </summary>
    public interface IContactStudentProgramAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }
        
        DateTime BeginDate { get; set; }
        
        long EducationOrganizationId { get; set; }
        
        long ProgramEducationOrganizationId { get; set; }
        
        string ProgramName { get; set; }
        
        string ProgramTypeDescriptor { get; set; }
        
        string StudentUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentProgramAssociationResourceId { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactStudentProgramAssociationMappingContract : IMappingContract
    {
        public ContactStudentProgramAssociationMappingContract(
            bool isStudentProgramAssociationReferenceSupported
            )
        {
            IsStudentProgramAssociationReferenceSupported = isStudentProgramAssociationReferenceSupported;
        }

        public bool IsStudentProgramAssociationReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentProgramAssociationReference":
                    return IsStudentProgramAssociationReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "BeginDate":
                    return true;
                case "EducationOrganizationId":
                    return true;
                case "ProgramEducationOrganizationId":
                    return true;
                case "ProgramName":
                    return true;
                case "ProgramTypeDescriptor":
                    return true;
                case "StudentUniqueId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactTeacherConference model.
    /// </summary>
    public interface IContactTeacherConference : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContactExtension ContactExtension { get; set; }

        // Non-PK properties
        string DayOfWeek { get; set; }
        TimeSpan EndTime { get; set; }
        TimeSpan StartTime { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactTeacherConferenceMappingContract : IMappingContract
    {
        public ContactTeacherConferenceMappingContract(
            bool isDayOfWeekSupported,
            bool isEndTimeSupported,
            bool isStartTimeSupported
            )
        {
            IsDayOfWeekSupported = isDayOfWeekSupported;
            IsEndTimeSupported = isEndTimeSupported;
            IsStartTimeSupported = isStartTimeSupported;
        }

        public bool IsDayOfWeekSupported { get; }
        public bool IsEndTimeSupported { get; }
        public bool IsStartTimeSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DayOfWeek":
                    return IsDayOfWeekSupported;
                case "EndTime":
                    return IsEndTimeSupported;
                case "StartTime":
                    return IsStartTimeSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the FavoriteBookCategoryDescriptor model.
    /// </summary>
    public interface IFavoriteBookCategoryDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int FavoriteBookCategoryDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class FavoriteBookCategoryDescriptorMappingContract : IMappingContract
    {
        public FavoriteBookCategoryDescriptorMappingContract(
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
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "FavoriteBookCategoryDescriptorId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the MembershipTypeDescriptor model.
    /// </summary>
    public interface IMembershipTypeDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int MembershipTypeDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class MembershipTypeDescriptorMappingContract : IMappingContract
    {
        public MembershipTypeDescriptorMappingContract(
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
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "MembershipTypeDescriptorId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolCTEProgramService model.
    /// </summary>
    public interface ISchoolCTEProgramService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ISchoolExtension SchoolExtension { get; set; }

        // Non-PK properties
        string CIPCode { get; set; }
        string CTEProgramServiceDescriptor { get; set; }
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolCTEProgramServiceMappingContract : IMappingContract
    {
        public SchoolCTEProgramServiceMappingContract(
            bool isCIPCodeSupported,
            bool isCTEProgramServiceDescriptorSupported,
            bool isPrimaryIndicatorSupported,
            bool isServiceBeginDateSupported,
            bool isServiceEndDateSupported
            )
        {
            IsCIPCodeSupported = isCIPCodeSupported;
            IsCTEProgramServiceDescriptorSupported = isCTEProgramServiceDescriptorSupported;
            IsPrimaryIndicatorSupported = isPrimaryIndicatorSupported;
            IsServiceBeginDateSupported = isServiceBeginDateSupported;
            IsServiceEndDateSupported = isServiceEndDateSupported;
        }

        public bool IsCIPCodeSupported { get; }
        public bool IsCTEProgramServiceDescriptorSupported { get; }
        public bool IsPrimaryIndicatorSupported { get; }
        public bool IsServiceBeginDateSupported { get; }
        public bool IsServiceEndDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CIPCode":
                    return IsCIPCodeSupported;
                case "CTEProgramServiceDescriptor":
                    return IsCTEProgramServiceDescriptorSupported;
                case "PrimaryIndicator":
                    return IsPrimaryIndicatorSupported;
                case "ServiceBeginDate":
                    return IsServiceBeginDateSupported;
                case "ServiceEndDate":
                    return IsServiceEndDateSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolDirectlyOwnedBus model.
    /// </summary>
    public interface ISchoolDirectlyOwnedBus : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        ISchoolExtension SchoolExtension { get; set; }
        
        string DirectlyOwnedBusId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? DirectlyOwnedBusResourceId { get; set; }
        string DirectlyOwnedBusDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolDirectlyOwnedBusMappingContract : IMappingContract
    {
        public SchoolDirectlyOwnedBusMappingContract(
            bool isDirectlyOwnedBusReferenceSupported
            )
        {
            IsDirectlyOwnedBusReferenceSupported = isDirectlyOwnedBusReferenceSupported;
        }

        public bool IsDirectlyOwnedBusReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DirectlyOwnedBusReference":
                    return IsDirectlyOwnedBusReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "DirectlyOwnedBusId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolExtension model.
    /// </summary>
    public interface ISchoolExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.ISchool School { get; set; }

        // Non-PK properties
        bool? IsExemplary { get; set; }

        // One-to-one relationships

        ISchoolCTEProgramService SchoolCTEProgramService { get; set; }

        // Lists
        ICollection<ISchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolExtensionMappingContract : IMappingContract
    {
        public SchoolExtensionMappingContract(
            bool isIsExemplarySupported,
            bool isSchoolCTEProgramServiceSupported,
            bool isSchoolDirectlyOwnedBusesSupported,
            bool isSchoolCTEProgramServiceCreatable,
            bool isSchoolDirectlyOwnedBusesItemCreatable,
            Func<ISchoolDirectlyOwnedBus, bool> isSchoolDirectlyOwnedBusIncluded
            )
        {
            IsIsExemplarySupported = isIsExemplarySupported;
            IsSchoolCTEProgramServiceSupported = isSchoolCTEProgramServiceSupported;
            IsSchoolDirectlyOwnedBusesSupported = isSchoolDirectlyOwnedBusesSupported;
            IsSchoolCTEProgramServiceCreatable = isSchoolCTEProgramServiceCreatable;
            IsSchoolDirectlyOwnedBusesItemCreatable = isSchoolDirectlyOwnedBusesItemCreatable;
            IsSchoolDirectlyOwnedBusIncluded = isSchoolDirectlyOwnedBusIncluded;
        }

        public bool IsIsExemplarySupported { get; }
        public bool IsSchoolCTEProgramServiceSupported { get; }
        public bool IsSchoolDirectlyOwnedBusesSupported { get; }
        public bool IsSchoolCTEProgramServiceCreatable { get; }
        public bool IsSchoolDirectlyOwnedBusesItemCreatable { get; }
        public Func<ISchoolDirectlyOwnedBus, bool> IsSchoolDirectlyOwnedBusIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "IsExemplary":
                    return IsIsExemplarySupported;
                case "SchoolCTEProgramService":
                    return IsSchoolCTEProgramServiceSupported;
                case "SchoolDirectlyOwnedBuses":
                    return IsSchoolDirectlyOwnedBusesSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "SchoolCTEProgramService":
                    return IsSchoolCTEProgramServiceCreatable;
                case "SchoolDirectlyOwnedBuses":
                    return IsSchoolDirectlyOwnedBusesItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffExtension model.
    /// </summary>
    public interface IStaffExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StaffExtensionMappingContract : IMappingContract
    {
        public StaffExtensionMappingContract(
            bool isFirstPetOwnedDateSupported,
            bool isStaffPetPreferenceSupported,
            bool isStaffPetsSupported,
            bool isStaffPetPreferenceCreatable,
            bool isStaffPetsItemCreatable,
            Func<IStaffPet, bool> isStaffPetIncluded
            )
        {
            IsFirstPetOwnedDateSupported = isFirstPetOwnedDateSupported;
            IsStaffPetPreferenceSupported = isStaffPetPreferenceSupported;
            IsStaffPetsSupported = isStaffPetsSupported;
            IsStaffPetPreferenceCreatable = isStaffPetPreferenceCreatable;
            IsStaffPetsItemCreatable = isStaffPetsItemCreatable;
            IsStaffPetIncluded = isStaffPetIncluded;
        }

        public bool IsFirstPetOwnedDateSupported { get; }
        public bool IsStaffPetPreferenceSupported { get; }
        public bool IsStaffPetsSupported { get; }
        public bool IsStaffPetPreferenceCreatable { get; }
        public bool IsStaffPetsItemCreatable { get; }
        public Func<IStaffPet, bool> IsStaffPetIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "FirstPetOwnedDate":
                    return IsFirstPetOwnedDateSupported;
                case "StaffPetPreference":
                    return IsStaffPetPreferenceSupported;
                case "StaffPets":
                    return IsStaffPetsSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StaffPetPreference":
                    return IsStaffPetPreferenceCreatable;
                case "StaffPets":
                    return IsStaffPetsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffPet model.
    /// </summary>
    public interface IStaffPet : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStaffExtension StaffExtension { get; set; }
        
        string PetName { get; set; }

        // Non-PK properties
        bool? IsFixed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StaffPetMappingContract : IMappingContract
    {
        public StaffPetMappingContract(
            bool isIsFixedSupported
            )
        {
            IsIsFixedSupported = isIsFixedSupported;
        }

        public bool IsIsFixedSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "IsFixed":
                    return IsIsFixedSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "PetName":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffPetPreference model.
    /// </summary>
    public interface IStaffPetPreference : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStaffExtension StaffExtension { get; set; }

        // Non-PK properties
        int MaximumWeight { get; set; }
        int MinimumWeight { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StaffPetPreferenceMappingContract : IMappingContract
    {
        public StaffPetPreferenceMappingContract(
            bool isMaximumWeightSupported,
            bool isMinimumWeightSupported
            )
        {
            IsMaximumWeightSupported = isMaximumWeightSupported;
            IsMinimumWeightSupported = isMinimumWeightSupported;
        }

        public bool IsMaximumWeightSupported { get; }
        public bool IsMinimumWeightSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MaximumWeight":
                    return IsMaximumWeightSupported;
                case "MinimumWeight":
                    return IsMinimumWeightSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordExtension model.
    /// </summary>
    public interface IStudentAcademicRecordExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentAcademicRecord StudentAcademicRecord { get; set; }

        // Non-PK properties
        string Notes { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentAcademicRecordExtensionMappingContract : IMappingContract
    {
        public StudentAcademicRecordExtensionMappingContract(
            bool isNotesSupported
            )
        {
            IsNotesSupported = isNotesSupported;
        }

        public bool IsNotesSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "Notes":
                    return IsNotesSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAquaticPet model.
    /// </summary>
    public interface IStudentAquaticPet : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentExtension StudentExtension { get; set; }
        
        int MimimumTankVolume { get; set; }
        
        string PetName { get; set; }

        // Non-PK properties
        bool? IsFixed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentAquaticPetMappingContract : IMappingContract
    {
        public StudentAquaticPetMappingContract(
            bool isIsFixedSupported
            )
        {
            IsIsFixedSupported = isIsFixedSupported;
        }

        public bool IsIsFixedSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "IsFixed":
                    return IsIsFixedSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "MimimumTankVolume":
                    return true;
                case "PetName":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

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

        IStudentArtProgramAssociationFavoriteBook StudentArtProgramAssociationFavoriteBook { get; set; }

        // Lists
        ICollection<IStudentArtProgramAssociationArtMedium> StudentArtProgramAssociationArtMedia { get; set; }
        ICollection<IStudentArtProgramAssociationPortfolioYears> StudentArtProgramAssociationPortfolioYears { get; set; }
        ICollection<IStudentArtProgramAssociationService> StudentArtProgramAssociationServices { get; set; }
        ICollection<IStudentArtProgramAssociationStyle> StudentArtProgramAssociationStyles { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationMappingContract(
            bool isArtPiecesSupported,
            bool isEducationOrganizationReferenceSupported,
            bool isEndDateSupported,
            bool isExhibitDateSupported,
            bool isGeneralStudentProgramAssociationProgramParticipationStatusesSupported,
            bool isHoursPerDaySupported,
            bool isIdentificationCodeSupported,
            bool isKilnReservationSupported,
            bool isKilnReservationLengthSupported,
            bool isMasteredMediumsSupported,
            bool isNumberOfDaysInAttendanceSupported,
            bool isPortfolioPiecesSupported,
            bool isPrivateArtProgramSupported,
            bool isProgramFeesSupported,
            bool isProgramReferenceSupported,
            bool isReasonExitedDescriptorSupported,
            bool isServedOutsideOfRegularSessionSupported,
            bool isStudentArtProgramAssociationArtMediaSupported,
            bool isStudentArtProgramAssociationFavoriteBookSupported,
            bool isStudentArtProgramAssociationPortfolioYearsSupported,
            bool isStudentArtProgramAssociationServicesSupported,
            bool isStudentArtProgramAssociationStylesSupported,
            bool isStudentReferenceSupported,
            bool isStudentArtProgramAssociationFavoriteBookCreatable,
            bool isGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable,
            Func<IGeneralStudentProgramAssociationProgramParticipationStatus, bool> isGeneralStudentProgramAssociationProgramParticipationStatusIncluded,
            bool isStudentArtProgramAssociationArtMediaItemCreatable,
            Func<IStudentArtProgramAssociationArtMedium, bool> isStudentArtProgramAssociationArtMediumIncluded,
            bool isStudentArtProgramAssociationPortfolioYearsItemCreatable,
            Func<IStudentArtProgramAssociationPortfolioYears, bool> isStudentArtProgramAssociationPortfolioYearsIncluded,
            bool isStudentArtProgramAssociationServicesItemCreatable,
            Func<IStudentArtProgramAssociationService, bool> isStudentArtProgramAssociationServiceIncluded,
            bool isStudentArtProgramAssociationStylesItemCreatable,
            Func<IStudentArtProgramAssociationStyle, bool> isStudentArtProgramAssociationStyleIncluded
            )
        {
            IsArtPiecesSupported = isArtPiecesSupported;
            IsEducationOrganizationReferenceSupported = isEducationOrganizationReferenceSupported;
            IsEndDateSupported = isEndDateSupported;
            IsExhibitDateSupported = isExhibitDateSupported;
            IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported = isGeneralStudentProgramAssociationProgramParticipationStatusesSupported;
            IsHoursPerDaySupported = isHoursPerDaySupported;
            IsIdentificationCodeSupported = isIdentificationCodeSupported;
            IsKilnReservationSupported = isKilnReservationSupported;
            IsKilnReservationLengthSupported = isKilnReservationLengthSupported;
            IsMasteredMediumsSupported = isMasteredMediumsSupported;
            IsNumberOfDaysInAttendanceSupported = isNumberOfDaysInAttendanceSupported;
            IsPortfolioPiecesSupported = isPortfolioPiecesSupported;
            IsPrivateArtProgramSupported = isPrivateArtProgramSupported;
            IsProgramFeesSupported = isProgramFeesSupported;
            IsProgramReferenceSupported = isProgramReferenceSupported;
            IsReasonExitedDescriptorSupported = isReasonExitedDescriptorSupported;
            IsServedOutsideOfRegularSessionSupported = isServedOutsideOfRegularSessionSupported;
            IsStudentArtProgramAssociationArtMediaSupported = isStudentArtProgramAssociationArtMediaSupported;
            IsStudentArtProgramAssociationFavoriteBookSupported = isStudentArtProgramAssociationFavoriteBookSupported;
            IsStudentArtProgramAssociationPortfolioYearsSupported = isStudentArtProgramAssociationPortfolioYearsSupported;
            IsStudentArtProgramAssociationServicesSupported = isStudentArtProgramAssociationServicesSupported;
            IsStudentArtProgramAssociationStylesSupported = isStudentArtProgramAssociationStylesSupported;
            IsStudentReferenceSupported = isStudentReferenceSupported;
            IsStudentArtProgramAssociationFavoriteBookCreatable = isStudentArtProgramAssociationFavoriteBookCreatable;
            IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable = isGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable;
            IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded = isGeneralStudentProgramAssociationProgramParticipationStatusIncluded;
            IsStudentArtProgramAssociationArtMediaItemCreatable = isStudentArtProgramAssociationArtMediaItemCreatable;
            IsStudentArtProgramAssociationArtMediumIncluded = isStudentArtProgramAssociationArtMediumIncluded;
            IsStudentArtProgramAssociationPortfolioYearsItemCreatable = isStudentArtProgramAssociationPortfolioYearsItemCreatable;
            IsStudentArtProgramAssociationPortfolioYearsIncluded = isStudentArtProgramAssociationPortfolioYearsIncluded;
            IsStudentArtProgramAssociationServicesItemCreatable = isStudentArtProgramAssociationServicesItemCreatable;
            IsStudentArtProgramAssociationServiceIncluded = isStudentArtProgramAssociationServiceIncluded;
            IsStudentArtProgramAssociationStylesItemCreatable = isStudentArtProgramAssociationStylesItemCreatable;
            IsStudentArtProgramAssociationStyleIncluded = isStudentArtProgramAssociationStyleIncluded;
        }

        public bool IsArtPiecesSupported { get; }
        public bool IsEducationOrganizationReferenceSupported { get; }
        public bool IsEndDateSupported { get; }
        public bool IsExhibitDateSupported { get; }
        public bool IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported { get; }
        public bool IsHoursPerDaySupported { get; }
        public bool IsIdentificationCodeSupported { get; }
        public bool IsKilnReservationSupported { get; }
        public bool IsKilnReservationLengthSupported { get; }
        public bool IsMasteredMediumsSupported { get; }
        public bool IsNumberOfDaysInAttendanceSupported { get; }
        public bool IsPortfolioPiecesSupported { get; }
        public bool IsPrivateArtProgramSupported { get; }
        public bool IsProgramFeesSupported { get; }
        public bool IsProgramReferenceSupported { get; }
        public bool IsReasonExitedDescriptorSupported { get; }
        public bool IsServedOutsideOfRegularSessionSupported { get; }
        public bool IsStudentArtProgramAssociationArtMediaSupported { get; }
        public bool IsStudentArtProgramAssociationFavoriteBookSupported { get; }
        public bool IsStudentArtProgramAssociationPortfolioYearsSupported { get; }
        public bool IsStudentArtProgramAssociationServicesSupported { get; }
        public bool IsStudentArtProgramAssociationStylesSupported { get; }
        public bool IsStudentReferenceSupported { get; }
        public bool IsStudentArtProgramAssociationFavoriteBookCreatable { get; }
        public bool IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable { get; }
        public Func<IGeneralStudentProgramAssociationProgramParticipationStatus, bool> IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded { get; }
        public bool IsStudentArtProgramAssociationArtMediaItemCreatable { get; }
        public Func<IStudentArtProgramAssociationArtMedium, bool> IsStudentArtProgramAssociationArtMediumIncluded { get; }
        public bool IsStudentArtProgramAssociationPortfolioYearsItemCreatable { get; }
        public Func<IStudentArtProgramAssociationPortfolioYears, bool> IsStudentArtProgramAssociationPortfolioYearsIncluded { get; }
        public bool IsStudentArtProgramAssociationServicesItemCreatable { get; }
        public Func<IStudentArtProgramAssociationService, bool> IsStudentArtProgramAssociationServiceIncluded { get; }
        public bool IsStudentArtProgramAssociationStylesItemCreatable { get; }
        public Func<IStudentArtProgramAssociationStyle, bool> IsStudentArtProgramAssociationStyleIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ArtPieces":
                    return IsArtPiecesSupported;
                case "EducationOrganizationReference":
                    return IsEducationOrganizationReferenceSupported;
                case "EndDate":
                    return IsEndDateSupported;
                case "ExhibitDate":
                    return IsExhibitDateSupported;
                case "GeneralStudentProgramAssociationProgramParticipationStatuses":
                    return IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported;
                case "HoursPerDay":
                    return IsHoursPerDaySupported;
                case "IdentificationCode":
                    return IsIdentificationCodeSupported;
                case "KilnReservation":
                    return IsKilnReservationSupported;
                case "KilnReservationLength":
                    return IsKilnReservationLengthSupported;
                case "MasteredMediums":
                    return IsMasteredMediumsSupported;
                case "NumberOfDaysInAttendance":
                    return IsNumberOfDaysInAttendanceSupported;
                case "PortfolioPieces":
                    return IsPortfolioPiecesSupported;
                case "PrivateArtProgram":
                    return IsPrivateArtProgramSupported;
                case "ProgramFees":
                    return IsProgramFeesSupported;
                case "ProgramReference":
                    return IsProgramReferenceSupported;
                case "ReasonExitedDescriptor":
                    return IsReasonExitedDescriptorSupported;
                case "ServedOutsideOfRegularSession":
                    return IsServedOutsideOfRegularSessionSupported;
                case "StudentArtProgramAssociationArtMedia":
                    return IsStudentArtProgramAssociationArtMediaSupported;
                case "StudentArtProgramAssociationFavoriteBook":
                    return IsStudentArtProgramAssociationFavoriteBookSupported;
                case "StudentArtProgramAssociationPortfolioYears":
                    return IsStudentArtProgramAssociationPortfolioYearsSupported;
                case "StudentArtProgramAssociationServices":
                    return IsStudentArtProgramAssociationServicesSupported;
                case "StudentArtProgramAssociationStyles":
                    return IsStudentArtProgramAssociationStylesSupported;
                case "StudentReference":
                    return IsStudentReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "BeginDate":
                    return true;
                case "EducationOrganizationId":
                    return true;
                case "ProgramEducationOrganizationId":
                    return true;
                case "ProgramName":
                    return true;
                case "ProgramTypeDescriptor":
                    return true;
                case "StudentUniqueId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentArtProgramAssociationFavoriteBook":
                    return IsStudentArtProgramAssociationFavoriteBookCreatable;
                case "GeneralStudentProgramAssociationProgramParticipationStatuses":
                    return IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable;
                case "StudentArtProgramAssociationArtMedia":
                    return IsStudentArtProgramAssociationArtMediaItemCreatable;
                case "StudentArtProgramAssociationPortfolioYears":
                    return IsStudentArtProgramAssociationPortfolioYearsItemCreatable;
                case "StudentArtProgramAssociationServices":
                    return IsStudentArtProgramAssociationServicesItemCreatable;
                case "StudentArtProgramAssociationStyles":
                    return IsStudentArtProgramAssociationStylesItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationArtMedium model.
    /// </summary>
    public interface IStudentArtProgramAssociationArtMedium : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        
        string ArtMediumDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationArtMediumMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationArtMediumMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ArtMediumDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationFavoriteBook model.
    /// </summary>
    public interface IStudentArtProgramAssociationFavoriteBook : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }

        // Non-PK properties
        string BookTitle { get; set; }
        string FavoriteBookCategoryDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentArtProgramAssociationFavoriteBookArtMedium> StudentArtProgramAssociationFavoriteBookArtMedia { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationFavoriteBookMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationFavoriteBookMappingContract(
            bool isBookTitleSupported,
            bool isFavoriteBookCategoryDescriptorSupported,
            bool isStudentArtProgramAssociationFavoriteBookArtMediaSupported,
            bool isStudentArtProgramAssociationFavoriteBookArtMediaItemCreatable,
            Func<IStudentArtProgramAssociationFavoriteBookArtMedium, bool> isStudentArtProgramAssociationFavoriteBookArtMediumIncluded
            )
        {
            IsBookTitleSupported = isBookTitleSupported;
            IsFavoriteBookCategoryDescriptorSupported = isFavoriteBookCategoryDescriptorSupported;
            IsStudentArtProgramAssociationFavoriteBookArtMediaSupported = isStudentArtProgramAssociationFavoriteBookArtMediaSupported;
            IsStudentArtProgramAssociationFavoriteBookArtMediaItemCreatable = isStudentArtProgramAssociationFavoriteBookArtMediaItemCreatable;
            IsStudentArtProgramAssociationFavoriteBookArtMediumIncluded = isStudentArtProgramAssociationFavoriteBookArtMediumIncluded;
        }

        public bool IsBookTitleSupported { get; }
        public bool IsFavoriteBookCategoryDescriptorSupported { get; }
        public bool IsStudentArtProgramAssociationFavoriteBookArtMediaSupported { get; }
        public bool IsStudentArtProgramAssociationFavoriteBookArtMediaItemCreatable { get; }
        public Func<IStudentArtProgramAssociationFavoriteBookArtMedium, bool> IsStudentArtProgramAssociationFavoriteBookArtMediumIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "BookTitle":
                    return IsBookTitleSupported;
                case "FavoriteBookCategoryDescriptor":
                    return IsFavoriteBookCategoryDescriptorSupported;
                case "StudentArtProgramAssociationFavoriteBookArtMedia":
                    return IsStudentArtProgramAssociationFavoriteBookArtMediaSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentArtProgramAssociationFavoriteBookArtMedia":
                    return IsStudentArtProgramAssociationFavoriteBookArtMediaItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationFavoriteBookArtMedium model.
    /// </summary>
    public interface IStudentArtProgramAssociationFavoriteBookArtMedium : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentArtProgramAssociationFavoriteBook StudentArtProgramAssociationFavoriteBook { get; set; }
        
        string ArtMediumDescriptor { get; set; }

        // Non-PK properties
        int? ArtPieces { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationFavoriteBookArtMediumMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationFavoriteBookArtMediumMappingContract(
            bool isArtPiecesSupported
            )
        {
            IsArtPiecesSupported = isArtPiecesSupported;
        }

        public bool IsArtPiecesSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ArtPieces":
                    return IsArtPiecesSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ArtMediumDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationPortfolioYears model.
    /// </summary>
    public interface IStudentArtProgramAssociationPortfolioYears : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        
        short PortfolioYears { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationPortfolioYearsMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationPortfolioYearsMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "PortfolioYears":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationService model.
    /// </summary>
    public interface IStudentArtProgramAssociationService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        
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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationServiceMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationServiceMappingContract(
            bool isPrimaryIndicatorSupported,
            bool isServiceBeginDateSupported,
            bool isServiceEndDateSupported
            )
        {
            IsPrimaryIndicatorSupported = isPrimaryIndicatorSupported;
            IsServiceBeginDateSupported = isServiceBeginDateSupported;
            IsServiceEndDateSupported = isServiceEndDateSupported;
        }

        public bool IsPrimaryIndicatorSupported { get; }
        public bool IsServiceBeginDateSupported { get; }
        public bool IsServiceEndDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "PrimaryIndicator":
                    return IsPrimaryIndicatorSupported;
                case "ServiceBeginDate":
                    return IsServiceBeginDateSupported;
                case "ServiceEndDate":
                    return IsServiceEndDateSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ServiceDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentArtProgramAssociationStyle model.
    /// </summary>
    public interface IStudentArtProgramAssociationStyle : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentArtProgramAssociation StudentArtProgramAssociation { get; set; }
        
        string Style { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentArtProgramAssociationStyleMappingContract : IMappingContract
    {
        public StudentArtProgramAssociationStyleMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "Style":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationDiscipline model.
    /// </summary>
    public interface IStudentContactAssociationDiscipline : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentContactAssociationExtension StudentContactAssociationExtension { get; set; }
        
        string DisciplineDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationDisciplineMappingContract : IMappingContract
    {
        public StudentContactAssociationDisciplineMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "DisciplineDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationExtension model.
    /// </summary>
    public interface IStudentContactAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentContactAssociation StudentContactAssociation { get; set; }

        // Non-PK properties
        bool BedtimeReader { get; set; }
        decimal? BedtimeReadingRate { get; set; }
        decimal? BookBudget { get; set; }
        int? BooksBorrowed { get; set; }
        long? EducationOrganizationId { get; set; }
        string InterventionStudyIdentificationCode { get; set; }
        int? LibraryDuration { get; set; }
        TimeSpan? LibraryTime { get; set; }
        short? LibraryVisits { get; set; }
        string PriorContactRestrictions { get; set; }
        DateTime? ReadGreenEggsAndHamDate { get; set; }
        string ReadingTimeSpent { get; set; }
        short? StudentRead { get; set; }

        // One-to-one relationships

        IStudentContactAssociationTelephone StudentContactAssociationTelephone { get; set; }

        // Lists
        ICollection<IStudentContactAssociationDiscipline> StudentContactAssociationDisciplines { get; set; }
        ICollection<IStudentContactAssociationFavoriteBookTitle> StudentContactAssociationFavoriteBookTitles { get; set; }
        ICollection<IStudentContactAssociationHoursPerWeek> StudentContactAssociationHoursPerWeeks { get; set; }
        ICollection<IStudentContactAssociationPagesRead> StudentContactAssociationPagesReads { get; set; }
        ICollection<IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation> StudentContactAssociationStaffEducationOrganizationEmploymentAssociations { get; set; }

        // Resource reference data
        Guid? InterventionStudyResourceId { get; set; }
        string InterventionStudyDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationExtensionMappingContract : IMappingContract
    {
        public StudentContactAssociationExtensionMappingContract(
            bool isBedtimeReaderSupported,
            bool isBedtimeReadingRateSupported,
            bool isBookBudgetSupported,
            bool isBooksBorrowedSupported,
            bool isEducationOrganizationIdSupported,
            bool isInterventionStudyIdentificationCodeSupported,
            bool isInterventionStudyReferenceSupported,
            bool isLibraryDurationSupported,
            bool isLibraryTimeSupported,
            bool isLibraryVisitsSupported,
            bool isPriorContactRestrictionsSupported,
            bool isReadGreenEggsAndHamDateSupported,
            bool isReadingTimeSpentSupported,
            bool isStudentContactAssociationDisciplinesSupported,
            bool isStudentContactAssociationFavoriteBookTitlesSupported,
            bool isStudentContactAssociationHoursPerWeeksSupported,
            bool isStudentContactAssociationPagesReadsSupported,
            bool isStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported,
            bool isStudentContactAssociationTelephoneSupported,
            bool isStudentReadSupported,
            bool isStudentContactAssociationTelephoneCreatable,
            bool isStudentContactAssociationDisciplinesItemCreatable,
            Func<IStudentContactAssociationDiscipline, bool> isStudentContactAssociationDisciplineIncluded,
            bool isStudentContactAssociationFavoriteBookTitlesItemCreatable,
            Func<IStudentContactAssociationFavoriteBookTitle, bool> isStudentContactAssociationFavoriteBookTitleIncluded,
            bool isStudentContactAssociationHoursPerWeeksItemCreatable,
            Func<IStudentContactAssociationHoursPerWeek, bool> isStudentContactAssociationHoursPerWeekIncluded,
            bool isStudentContactAssociationPagesReadsItemCreatable,
            Func<IStudentContactAssociationPagesRead, bool> isStudentContactAssociationPagesReadIncluded,
            bool isStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItemCreatable,
            Func<IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation, bool> isStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded
            )
        {
            IsBedtimeReaderSupported = isBedtimeReaderSupported;
            IsBedtimeReadingRateSupported = isBedtimeReadingRateSupported;
            IsBookBudgetSupported = isBookBudgetSupported;
            IsBooksBorrowedSupported = isBooksBorrowedSupported;
            IsEducationOrganizationIdSupported = isEducationOrganizationIdSupported;
            IsInterventionStudyIdentificationCodeSupported = isInterventionStudyIdentificationCodeSupported;
            IsInterventionStudyReferenceSupported = isInterventionStudyReferenceSupported;
            IsLibraryDurationSupported = isLibraryDurationSupported;
            IsLibraryTimeSupported = isLibraryTimeSupported;
            IsLibraryVisitsSupported = isLibraryVisitsSupported;
            IsPriorContactRestrictionsSupported = isPriorContactRestrictionsSupported;
            IsReadGreenEggsAndHamDateSupported = isReadGreenEggsAndHamDateSupported;
            IsReadingTimeSpentSupported = isReadingTimeSpentSupported;
            IsStudentContactAssociationDisciplinesSupported = isStudentContactAssociationDisciplinesSupported;
            IsStudentContactAssociationFavoriteBookTitlesSupported = isStudentContactAssociationFavoriteBookTitlesSupported;
            IsStudentContactAssociationHoursPerWeeksSupported = isStudentContactAssociationHoursPerWeeksSupported;
            IsStudentContactAssociationPagesReadsSupported = isStudentContactAssociationPagesReadsSupported;
            IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported = isStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported;
            IsStudentContactAssociationTelephoneSupported = isStudentContactAssociationTelephoneSupported;
            IsStudentReadSupported = isStudentReadSupported;
            IsStudentContactAssociationTelephoneCreatable = isStudentContactAssociationTelephoneCreatable;
            IsStudentContactAssociationDisciplinesItemCreatable = isStudentContactAssociationDisciplinesItemCreatable;
            IsStudentContactAssociationDisciplineIncluded = isStudentContactAssociationDisciplineIncluded;
            IsStudentContactAssociationFavoriteBookTitlesItemCreatable = isStudentContactAssociationFavoriteBookTitlesItemCreatable;
            IsStudentContactAssociationFavoriteBookTitleIncluded = isStudentContactAssociationFavoriteBookTitleIncluded;
            IsStudentContactAssociationHoursPerWeeksItemCreatable = isStudentContactAssociationHoursPerWeeksItemCreatable;
            IsStudentContactAssociationHoursPerWeekIncluded = isStudentContactAssociationHoursPerWeekIncluded;
            IsStudentContactAssociationPagesReadsItemCreatable = isStudentContactAssociationPagesReadsItemCreatable;
            IsStudentContactAssociationPagesReadIncluded = isStudentContactAssociationPagesReadIncluded;
            IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItemCreatable = isStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItemCreatable;
            IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded = isStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded;
        }

        public bool IsBedtimeReaderSupported { get; }
        public bool IsBedtimeReadingRateSupported { get; }
        public bool IsBookBudgetSupported { get; }
        public bool IsBooksBorrowedSupported { get; }
        public bool IsEducationOrganizationIdSupported { get; }
        public bool IsInterventionStudyIdentificationCodeSupported { get; }
        public bool IsInterventionStudyReferenceSupported { get; }
        public bool IsLibraryDurationSupported { get; }
        public bool IsLibraryTimeSupported { get; }
        public bool IsLibraryVisitsSupported { get; }
        public bool IsPriorContactRestrictionsSupported { get; }
        public bool IsReadGreenEggsAndHamDateSupported { get; }
        public bool IsReadingTimeSpentSupported { get; }
        public bool IsStudentContactAssociationDisciplinesSupported { get; }
        public bool IsStudentContactAssociationFavoriteBookTitlesSupported { get; }
        public bool IsStudentContactAssociationHoursPerWeeksSupported { get; }
        public bool IsStudentContactAssociationPagesReadsSupported { get; }
        public bool IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported { get; }
        public bool IsStudentContactAssociationTelephoneSupported { get; }
        public bool IsStudentReadSupported { get; }
        public bool IsStudentContactAssociationTelephoneCreatable { get; }
        public bool IsStudentContactAssociationDisciplinesItemCreatable { get; }
        public Func<IStudentContactAssociationDiscipline, bool> IsStudentContactAssociationDisciplineIncluded { get; }
        public bool IsStudentContactAssociationFavoriteBookTitlesItemCreatable { get; }
        public Func<IStudentContactAssociationFavoriteBookTitle, bool> IsStudentContactAssociationFavoriteBookTitleIncluded { get; }
        public bool IsStudentContactAssociationHoursPerWeeksItemCreatable { get; }
        public Func<IStudentContactAssociationHoursPerWeek, bool> IsStudentContactAssociationHoursPerWeekIncluded { get; }
        public bool IsStudentContactAssociationPagesReadsItemCreatable { get; }
        public Func<IStudentContactAssociationPagesRead, bool> IsStudentContactAssociationPagesReadIncluded { get; }
        public bool IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItemCreatable { get; }
        public Func<IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation, bool> IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "BedtimeReader":
                    return IsBedtimeReaderSupported;
                case "BedtimeReadingRate":
                    return IsBedtimeReadingRateSupported;
                case "BookBudget":
                    return IsBookBudgetSupported;
                case "BooksBorrowed":
                    return IsBooksBorrowedSupported;
                case "EducationOrganizationId":
                    return IsEducationOrganizationIdSupported;
                case "InterventionStudyIdentificationCode":
                    return IsInterventionStudyIdentificationCodeSupported;
                case "InterventionStudyReference":
                    return IsInterventionStudyReferenceSupported;
                case "LibraryDuration":
                    return IsLibraryDurationSupported;
                case "LibraryTime":
                    return IsLibraryTimeSupported;
                case "LibraryVisits":
                    return IsLibraryVisitsSupported;
                case "PriorContactRestrictions":
                    return IsPriorContactRestrictionsSupported;
                case "ReadGreenEggsAndHamDate":
                    return IsReadGreenEggsAndHamDateSupported;
                case "ReadingTimeSpent":
                    return IsReadingTimeSpentSupported;
                case "StudentContactAssociationDisciplines":
                    return IsStudentContactAssociationDisciplinesSupported;
                case "StudentContactAssociationFavoriteBookTitles":
                    return IsStudentContactAssociationFavoriteBookTitlesSupported;
                case "StudentContactAssociationHoursPerWeeks":
                    return IsStudentContactAssociationHoursPerWeeksSupported;
                case "StudentContactAssociationPagesReads":
                    return IsStudentContactAssociationPagesReadsSupported;
                case "StudentContactAssociationStaffEducationOrganizationEmploymentAssociations":
                    return IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsSupported;
                case "StudentContactAssociationTelephone":
                    return IsStudentContactAssociationTelephoneSupported;
                case "StudentRead":
                    return IsStudentReadSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentContactAssociationTelephone":
                    return IsStudentContactAssociationTelephoneCreatable;
                case "StudentContactAssociationDisciplines":
                    return IsStudentContactAssociationDisciplinesItemCreatable;
                case "StudentContactAssociationFavoriteBookTitles":
                    return IsStudentContactAssociationFavoriteBookTitlesItemCreatable;
                case "StudentContactAssociationHoursPerWeeks":
                    return IsStudentContactAssociationHoursPerWeeksItemCreatable;
                case "StudentContactAssociationPagesReads":
                    return IsStudentContactAssociationPagesReadsItemCreatable;
                case "StudentContactAssociationStaffEducationOrganizationEmploymentAssociations":
                    return IsStudentContactAssociationStaffEducationOrganizationEmploymentAssociationsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationFavoriteBookTitle model.
    /// </summary>
    public interface IStudentContactAssociationFavoriteBookTitle : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentContactAssociationExtension StudentContactAssociationExtension { get; set; }
        
        string FavoriteBookTitle { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationFavoriteBookTitleMappingContract : IMappingContract
    {
        public StudentContactAssociationFavoriteBookTitleMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "FavoriteBookTitle":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationHoursPerWeek model.
    /// </summary>
    public interface IStudentContactAssociationHoursPerWeek : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentContactAssociationExtension StudentContactAssociationExtension { get; set; }
        
        decimal HoursPerWeek { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationHoursPerWeekMappingContract : IMappingContract
    {
        public StudentContactAssociationHoursPerWeekMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "HoursPerWeek":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationPagesRead model.
    /// </summary>
    public interface IStudentContactAssociationPagesRead : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentContactAssociationExtension StudentContactAssociationExtension { get; set; }
        
        decimal PagesRead { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationPagesReadMappingContract : IMappingContract
    {
        public StudentContactAssociationPagesReadMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "PagesRead":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationStaffEducationOrganizationEmploymentAssociation model.
    /// </summary>
    public interface IStudentContactAssociationStaffEducationOrganizationEmploymentAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentContactAssociationExtension StudentContactAssociationExtension { get; set; }
        
        long EducationOrganizationId { get; set; }
        
        string EmploymentStatusDescriptor { get; set; }
        
        DateTime HireDate { get; set; }
        
        string StaffUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StaffEducationOrganizationEmploymentAssociationResourceId { get; set; }
        string StaffEducationOrganizationEmploymentAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMappingContract : IMappingContract
    {
        public StudentContactAssociationStaffEducationOrganizationEmploymentAssociationMappingContract(
            bool isStaffEducationOrganizationEmploymentAssociationReferenceSupported
            )
        {
            IsStaffEducationOrganizationEmploymentAssociationReferenceSupported = isStaffEducationOrganizationEmploymentAssociationReferenceSupported;
        }

        public bool IsStaffEducationOrganizationEmploymentAssociationReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StaffEducationOrganizationEmploymentAssociationReference":
                    return IsStaffEducationOrganizationEmploymentAssociationReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "EducationOrganizationId":
                    return true;
                case "EmploymentStatusDescriptor":
                    return true;
                case "HireDate":
                    return true;
                case "StaffUniqueId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentContactAssociationTelephone model.
    /// </summary>
    public interface IStudentContactAssociationTelephone : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentContactAssociationExtension StudentContactAssociationExtension { get; set; }

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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentContactAssociationTelephoneMappingContract : IMappingContract
    {
        public StudentContactAssociationTelephoneMappingContract(
            bool isDoNotPublishIndicatorSupported,
            bool isOrderOfPrioritySupported,
            bool isTelephoneNumberSupported,
            bool isTelephoneNumberTypeDescriptorSupported,
            bool isTextMessageCapabilityIndicatorSupported
            )
        {
            IsDoNotPublishIndicatorSupported = isDoNotPublishIndicatorSupported;
            IsOrderOfPrioritySupported = isOrderOfPrioritySupported;
            IsTelephoneNumberSupported = isTelephoneNumberSupported;
            IsTelephoneNumberTypeDescriptorSupported = isTelephoneNumberTypeDescriptorSupported;
            IsTextMessageCapabilityIndicatorSupported = isTextMessageCapabilityIndicatorSupported;
        }

        public bool IsDoNotPublishIndicatorSupported { get; }
        public bool IsOrderOfPrioritySupported { get; }
        public bool IsTelephoneNumberSupported { get; }
        public bool IsTelephoneNumberTypeDescriptorSupported { get; }
        public bool IsTextMessageCapabilityIndicatorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "DoNotPublishIndicator":
                    return IsDoNotPublishIndicatorSupported;
                case "OrderOfPriority":
                    return IsOrderOfPrioritySupported;
                case "TelephoneNumber":
                    return IsTelephoneNumberSupported;
                case "TelephoneNumberTypeDescriptor":
                    return IsTelephoneNumberTypeDescriptorSupported;
                case "TextMessageCapabilityIndicator":
                    return IsTextMessageCapabilityIndicatorSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentCTEProgramAssociationExtension model.
    /// </summary>
    public interface IStudentCTEProgramAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentCTEProgramAssociation StudentCTEProgramAssociation { get; set; }

        // Non-PK properties
        bool? AnalysisCompleted { get; set; }
        DateTime? AnalysisDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentCTEProgramAssociationExtensionMappingContract : IMappingContract
    {
        public StudentCTEProgramAssociationExtensionMappingContract(
            bool isAnalysisCompletedSupported,
            bool isAnalysisDateSupported
            )
        {
            IsAnalysisCompletedSupported = isAnalysisCompletedSupported;
            IsAnalysisDateSupported = isAnalysisDateSupported;
        }

        public bool IsAnalysisCompletedSupported { get; }
        public bool IsAnalysisDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AnalysisCompleted":
                    return IsAnalysisCompletedSupported;
                case "AnalysisDate":
                    return IsAnalysisDateSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressExtension model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentEducationOrganizationAssociationAddressExtensionMappingContract : IMappingContract
    {
        public StudentEducationOrganizationAssociationAddressExtensionMappingContract(
            bool isComplexSupported,
            bool isOnBusRouteSupported,
            bool isStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported,
            bool isStudentEducationOrganizationAssociationAddressTermsSupported,
            bool isStudentEducationOrganizationAssociationAddressSchoolDistrictsItemCreatable,
            Func<IStudentEducationOrganizationAssociationAddressSchoolDistrict, bool> isStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded,
            bool isStudentEducationOrganizationAssociationAddressTermsItemCreatable,
            Func<IStudentEducationOrganizationAssociationAddressTerm, bool> isStudentEducationOrganizationAssociationAddressTermIncluded
            )
        {
            IsComplexSupported = isComplexSupported;
            IsOnBusRouteSupported = isOnBusRouteSupported;
            IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported = isStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported;
            IsStudentEducationOrganizationAssociationAddressTermsSupported = isStudentEducationOrganizationAssociationAddressTermsSupported;
            IsStudentEducationOrganizationAssociationAddressSchoolDistrictsItemCreatable = isStudentEducationOrganizationAssociationAddressSchoolDistrictsItemCreatable;
            IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded = isStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded;
            IsStudentEducationOrganizationAssociationAddressTermsItemCreatable = isStudentEducationOrganizationAssociationAddressTermsItemCreatable;
            IsStudentEducationOrganizationAssociationAddressTermIncluded = isStudentEducationOrganizationAssociationAddressTermIncluded;
        }

        public bool IsComplexSupported { get; }
        public bool IsOnBusRouteSupported { get; }
        public bool IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported { get; }
        public bool IsStudentEducationOrganizationAssociationAddressTermsSupported { get; }
        public bool IsStudentEducationOrganizationAssociationAddressSchoolDistrictsItemCreatable { get; }
        public Func<IStudentEducationOrganizationAssociationAddressSchoolDistrict, bool> IsStudentEducationOrganizationAssociationAddressSchoolDistrictIncluded { get; }
        public bool IsStudentEducationOrganizationAssociationAddressTermsItemCreatable { get; }
        public Func<IStudentEducationOrganizationAssociationAddressTerm, bool> IsStudentEducationOrganizationAssociationAddressTermIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "Complex":
                    return IsComplexSupported;
                case "OnBusRoute":
                    return IsOnBusRouteSupported;
                case "StudentEducationOrganizationAssociationAddressSchoolDistricts":
                    return IsStudentEducationOrganizationAssociationAddressSchoolDistrictsSupported;
                case "StudentEducationOrganizationAssociationAddressTerms":
                    return IsStudentEducationOrganizationAssociationAddressTermsSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentEducationOrganizationAssociationAddressSchoolDistricts":
                    return IsStudentEducationOrganizationAssociationAddressSchoolDistrictsItemCreatable;
                case "StudentEducationOrganizationAssociationAddressTerms":
                    return IsStudentEducationOrganizationAssociationAddressTermsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressSchoolDistrict model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressSchoolDistrict : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentEducationOrganizationAssociationAddressExtension StudentEducationOrganizationAssociationAddressExtension { get; set; }
        
        string SchoolDistrict { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentEducationOrganizationAssociationAddressSchoolDistrictMappingContract : IMappingContract
    {
        public StudentEducationOrganizationAssociationAddressSchoolDistrictMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "SchoolDistrict":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationAddressTerm model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationAddressTerm : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentEducationOrganizationAssociationAddressExtension StudentEducationOrganizationAssociationAddressExtension { get; set; }
        
        string TermDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentEducationOrganizationAssociationAddressTermMappingContract : IMappingContract
    {
        public StudentEducationOrganizationAssociationAddressTermMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "TermDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationExtension model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentEducationOrganizationAssociation StudentEducationOrganizationAssociation { get; set; }

        // Non-PK properties
        string FavoriteProgramName { get; set; }
        string FavoriteProgramTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? FavoriteProgramResourceId { get; set; }
        string FavoriteProgramDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentEducationOrganizationAssociationExtensionMappingContract : IMappingContract
    {
        public StudentEducationOrganizationAssociationExtensionMappingContract(
            bool isFavoriteProgramNameSupported,
            bool isFavoriteProgramReferenceSupported,
            bool isFavoriteProgramTypeDescriptorSupported
            )
        {
            IsFavoriteProgramNameSupported = isFavoriteProgramNameSupported;
            IsFavoriteProgramReferenceSupported = isFavoriteProgramReferenceSupported;
            IsFavoriteProgramTypeDescriptorSupported = isFavoriteProgramTypeDescriptorSupported;
        }

        public bool IsFavoriteProgramNameSupported { get; }
        public bool IsFavoriteProgramReferenceSupported { get; }
        public bool IsFavoriteProgramTypeDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "FavoriteProgramName":
                    return IsFavoriteProgramNameSupported;
                case "FavoriteProgramReference":
                    return IsFavoriteProgramReferenceSupported;
                case "FavoriteProgramTypeDescriptor":
                    return IsFavoriteProgramTypeDescriptorSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentCharacteristicExtension model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentEducationOrganizationAssociationStudentCharacteristic StudentEducationOrganizationAssociationStudentCharacteristic { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed> StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentEducationOrganizationAssociationStudentCharacteristicExtensionMappingContract : IMappingContract
    {
        public StudentEducationOrganizationAssociationStudentCharacteristicExtensionMappingContract(
            bool isStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported,
            bool isStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItemCreatable,
            Func<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, bool> isStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded
            )
        {
            IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported = isStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported;
            IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItemCreatable = isStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItemCreatable;
            IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded = isStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded;
        }

        public bool IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported { get; }
        public bool IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItemCreatable { get; }
        public Func<IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed, bool> IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds":
                    return IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentEducationOrganizationAssociationStudentCharacteristicStudentNeeds":
                    return IsStudentEducationOrganizationAssociationStudentCharacteristicStudentNeedsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentEducationOrganizationAssociationStudentCharacteristicStudentNeed model.
    /// </summary>
    public interface IStudentEducationOrganizationAssociationStudentCharacteristicStudentNeed : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentEducationOrganizationAssociationStudentCharacteristicExtension StudentEducationOrganizationAssociationStudentCharacteristicExtension { get; set; }
        
        DateTime BeginDate { get; set; }

        // Non-PK properties
        DateTime? EndDate { get; set; }
        bool? PrimaryStudentNeedIndicator { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMappingContract : IMappingContract
    {
        public StudentEducationOrganizationAssociationStudentCharacteristicStudentNeedMappingContract(
            bool isEndDateSupported,
            bool isPrimaryStudentNeedIndicatorSupported
            )
        {
            IsEndDateSupported = isEndDateSupported;
            IsPrimaryStudentNeedIndicatorSupported = isPrimaryStudentNeedIndicatorSupported;
        }

        public bool IsEndDateSupported { get; }
        public bool IsPrimaryStudentNeedIndicatorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "EndDate":
                    return IsEndDateSupported;
                case "PrimaryStudentNeedIndicator":
                    return IsPrimaryStudentNeedIndicatorSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "BeginDate":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentExtension model.
    /// </summary>
    public interface IStudentExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentExtensionMappingContract : IMappingContract
    {
        public StudentExtensionMappingContract(
            bool isStudentAquaticPetsSupported,
            bool isStudentFavoriteBooksSupported,
            bool isStudentPetPreferenceSupported,
            bool isStudentPetsSupported,
            bool isStudentPetPreferenceCreatable,
            bool isStudentAquaticPetsItemCreatable,
            Func<IStudentAquaticPet, bool> isStudentAquaticPetIncluded,
            bool isStudentFavoriteBooksItemCreatable,
            Func<IStudentFavoriteBook, bool> isStudentFavoriteBookIncluded,
            bool isStudentPetsItemCreatable,
            Func<IStudentPet, bool> isStudentPetIncluded
            )
        {
            IsStudentAquaticPetsSupported = isStudentAquaticPetsSupported;
            IsStudentFavoriteBooksSupported = isStudentFavoriteBooksSupported;
            IsStudentPetPreferenceSupported = isStudentPetPreferenceSupported;
            IsStudentPetsSupported = isStudentPetsSupported;
            IsStudentPetPreferenceCreatable = isStudentPetPreferenceCreatable;
            IsStudentAquaticPetsItemCreatable = isStudentAquaticPetsItemCreatable;
            IsStudentAquaticPetIncluded = isStudentAquaticPetIncluded;
            IsStudentFavoriteBooksItemCreatable = isStudentFavoriteBooksItemCreatable;
            IsStudentFavoriteBookIncluded = isStudentFavoriteBookIncluded;
            IsStudentPetsItemCreatable = isStudentPetsItemCreatable;
            IsStudentPetIncluded = isStudentPetIncluded;
        }

        public bool IsStudentAquaticPetsSupported { get; }
        public bool IsStudentFavoriteBooksSupported { get; }
        public bool IsStudentPetPreferenceSupported { get; }
        public bool IsStudentPetsSupported { get; }
        public bool IsStudentPetPreferenceCreatable { get; }
        public bool IsStudentAquaticPetsItemCreatable { get; }
        public Func<IStudentAquaticPet, bool> IsStudentAquaticPetIncluded { get; }
        public bool IsStudentFavoriteBooksItemCreatable { get; }
        public Func<IStudentFavoriteBook, bool> IsStudentFavoriteBookIncluded { get; }
        public bool IsStudentPetsItemCreatable { get; }
        public Func<IStudentPet, bool> IsStudentPetIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentAquaticPets":
                    return IsStudentAquaticPetsSupported;
                case "StudentFavoriteBooks":
                    return IsStudentFavoriteBooksSupported;
                case "StudentPetPreference":
                    return IsStudentPetPreferenceSupported;
                case "StudentPets":
                    return IsStudentPetsSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentPetPreference":
                    return IsStudentPetPreferenceCreatable;
                case "StudentAquaticPets":
                    return IsStudentAquaticPetsItemCreatable;
                case "StudentFavoriteBooks":
                    return IsStudentFavoriteBooksItemCreatable;
                case "StudentPets":
                    return IsStudentPetsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentFavoriteBook model.
    /// </summary>
    public interface IStudentFavoriteBook : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentExtension StudentExtension { get; set; }
        
        string FavoriteBookCategoryDescriptor { get; set; }

        // Non-PK properties
        string BookTitle { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentFavoriteBookArtMedium> StudentFavoriteBookArtMedia { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentFavoriteBookMappingContract : IMappingContract
    {
        public StudentFavoriteBookMappingContract(
            bool isBookTitleSupported,
            bool isStudentFavoriteBookArtMediaSupported,
            bool isStudentFavoriteBookArtMediaItemCreatable,
            Func<IStudentFavoriteBookArtMedium, bool> isStudentFavoriteBookArtMediumIncluded
            )
        {
            IsBookTitleSupported = isBookTitleSupported;
            IsStudentFavoriteBookArtMediaSupported = isStudentFavoriteBookArtMediaSupported;
            IsStudentFavoriteBookArtMediaItemCreatable = isStudentFavoriteBookArtMediaItemCreatable;
            IsStudentFavoriteBookArtMediumIncluded = isStudentFavoriteBookArtMediumIncluded;
        }

        public bool IsBookTitleSupported { get; }
        public bool IsStudentFavoriteBookArtMediaSupported { get; }
        public bool IsStudentFavoriteBookArtMediaItemCreatable { get; }
        public Func<IStudentFavoriteBookArtMedium, bool> IsStudentFavoriteBookArtMediumIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "BookTitle":
                    return IsBookTitleSupported;
                case "StudentFavoriteBookArtMedia":
                    return IsStudentFavoriteBookArtMediaSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "FavoriteBookCategoryDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentFavoriteBookArtMedia":
                    return IsStudentFavoriteBookArtMediaItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentFavoriteBookArtMedium model.
    /// </summary>
    public interface IStudentFavoriteBookArtMedium : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentFavoriteBook StudentFavoriteBook { get; set; }
        
        string ArtMediumDescriptor { get; set; }

        // Non-PK properties
        int? ArtPieces { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentFavoriteBookArtMediumMappingContract : IMappingContract
    {
        public StudentFavoriteBookArtMediumMappingContract(
            bool isArtPiecesSupported
            )
        {
            IsArtPiecesSupported = isArtPiecesSupported;
        }

        public bool IsArtPiecesSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ArtPieces":
                    return IsArtPiecesSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ArtMediumDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociation model.
    /// </summary>
    public interface IStudentGraduationPlanAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        long EducationOrganizationId { get; set; }
        
        string GraduationPlanTypeDescriptor { get; set; }
        
        short GraduationSchoolYear { get; set; }
        
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

        IStudentGraduationPlanAssociationCTEProgramService StudentGraduationPlanAssociationCTEProgramService { get; set; }

        // Lists
        ICollection<IStudentGraduationPlanAssociationAcademicSubject> StudentGraduationPlanAssociationAcademicSubjects { get; set; }
        ICollection<IStudentGraduationPlanAssociationCareerPathwayCode> StudentGraduationPlanAssociationCareerPathwayCodes { get; set; }
        ICollection<IStudentGraduationPlanAssociationDescription> StudentGraduationPlanAssociationDescriptions { get; set; }
        ICollection<IStudentGraduationPlanAssociationDesignatedBy> StudentGraduationPlanAssociationDesignatedBies { get; set; }
        ICollection<IStudentGraduationPlanAssociationIndustryCredential> StudentGraduationPlanAssociationIndustryCredentials { get; set; }
        ICollection<IStudentGraduationPlanAssociationStudentContactAssociation> StudentGraduationPlanAssociationStudentContactAssociations { get; set; }
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
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationMappingContract(
            bool isCommencementTimeSupported,
            bool isEffectiveDateSupported,
            bool isGraduationFeeSupported,
            bool isGraduationPlanReferenceSupported,
            bool isHighSchoolDurationSupported,
            bool isHoursPerWeekSupported,
            bool isIsActivePlanSupported,
            bool isRequiredAttendanceSupported,
            bool isStaffReferenceSupported,
            bool isStaffUniqueIdSupported,
            bool isStudentGraduationPlanAssociationAcademicSubjectsSupported,
            bool isStudentGraduationPlanAssociationCareerPathwayCodesSupported,
            bool isStudentGraduationPlanAssociationCTEProgramServiceSupported,
            bool isStudentGraduationPlanAssociationDescriptionsSupported,
            bool isStudentGraduationPlanAssociationDesignatedBiesSupported,
            bool isStudentGraduationPlanAssociationIndustryCredentialsSupported,
            bool isStudentGraduationPlanAssociationStudentContactAssociationsSupported,
            bool isStudentGraduationPlanAssociationYearsAttendedsSupported,
            bool isStudentReferenceSupported,
            bool isTargetGPASupported,
            bool isStudentGraduationPlanAssociationCTEProgramServiceCreatable,
            bool isStudentGraduationPlanAssociationAcademicSubjectsItemCreatable,
            Func<IStudentGraduationPlanAssociationAcademicSubject, bool> isStudentGraduationPlanAssociationAcademicSubjectIncluded,
            bool isStudentGraduationPlanAssociationCareerPathwayCodesItemCreatable,
            Func<IStudentGraduationPlanAssociationCareerPathwayCode, bool> isStudentGraduationPlanAssociationCareerPathwayCodeIncluded,
            bool isStudentGraduationPlanAssociationDescriptionsItemCreatable,
            Func<IStudentGraduationPlanAssociationDescription, bool> isStudentGraduationPlanAssociationDescriptionIncluded,
            bool isStudentGraduationPlanAssociationDesignatedBiesItemCreatable,
            Func<IStudentGraduationPlanAssociationDesignatedBy, bool> isStudentGraduationPlanAssociationDesignatedByIncluded,
            bool isStudentGraduationPlanAssociationIndustryCredentialsItemCreatable,
            Func<IStudentGraduationPlanAssociationIndustryCredential, bool> isStudentGraduationPlanAssociationIndustryCredentialIncluded,
            bool isStudentGraduationPlanAssociationStudentContactAssociationsItemCreatable,
            Func<IStudentGraduationPlanAssociationStudentContactAssociation, bool> isStudentGraduationPlanAssociationStudentContactAssociationIncluded,
            bool isStudentGraduationPlanAssociationYearsAttendedsItemCreatable,
            Func<IStudentGraduationPlanAssociationYearsAttended, bool> isStudentGraduationPlanAssociationYearsAttendedIncluded
            )
        {
            IsCommencementTimeSupported = isCommencementTimeSupported;
            IsEffectiveDateSupported = isEffectiveDateSupported;
            IsGraduationFeeSupported = isGraduationFeeSupported;
            IsGraduationPlanReferenceSupported = isGraduationPlanReferenceSupported;
            IsHighSchoolDurationSupported = isHighSchoolDurationSupported;
            IsHoursPerWeekSupported = isHoursPerWeekSupported;
            IsIsActivePlanSupported = isIsActivePlanSupported;
            IsRequiredAttendanceSupported = isRequiredAttendanceSupported;
            IsStaffReferenceSupported = isStaffReferenceSupported;
            IsStaffUniqueIdSupported = isStaffUniqueIdSupported;
            IsStudentGraduationPlanAssociationAcademicSubjectsSupported = isStudentGraduationPlanAssociationAcademicSubjectsSupported;
            IsStudentGraduationPlanAssociationCareerPathwayCodesSupported = isStudentGraduationPlanAssociationCareerPathwayCodesSupported;
            IsStudentGraduationPlanAssociationCTEProgramServiceSupported = isStudentGraduationPlanAssociationCTEProgramServiceSupported;
            IsStudentGraduationPlanAssociationDescriptionsSupported = isStudentGraduationPlanAssociationDescriptionsSupported;
            IsStudentGraduationPlanAssociationDesignatedBiesSupported = isStudentGraduationPlanAssociationDesignatedBiesSupported;
            IsStudentGraduationPlanAssociationIndustryCredentialsSupported = isStudentGraduationPlanAssociationIndustryCredentialsSupported;
            IsStudentGraduationPlanAssociationStudentContactAssociationsSupported = isStudentGraduationPlanAssociationStudentContactAssociationsSupported;
            IsStudentGraduationPlanAssociationYearsAttendedsSupported = isStudentGraduationPlanAssociationYearsAttendedsSupported;
            IsStudentReferenceSupported = isStudentReferenceSupported;
            IsTargetGPASupported = isTargetGPASupported;
            IsStudentGraduationPlanAssociationCTEProgramServiceCreatable = isStudentGraduationPlanAssociationCTEProgramServiceCreatable;
            IsStudentGraduationPlanAssociationAcademicSubjectsItemCreatable = isStudentGraduationPlanAssociationAcademicSubjectsItemCreatable;
            IsStudentGraduationPlanAssociationAcademicSubjectIncluded = isStudentGraduationPlanAssociationAcademicSubjectIncluded;
            IsStudentGraduationPlanAssociationCareerPathwayCodesItemCreatable = isStudentGraduationPlanAssociationCareerPathwayCodesItemCreatable;
            IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded = isStudentGraduationPlanAssociationCareerPathwayCodeIncluded;
            IsStudentGraduationPlanAssociationDescriptionsItemCreatable = isStudentGraduationPlanAssociationDescriptionsItemCreatable;
            IsStudentGraduationPlanAssociationDescriptionIncluded = isStudentGraduationPlanAssociationDescriptionIncluded;
            IsStudentGraduationPlanAssociationDesignatedBiesItemCreatable = isStudentGraduationPlanAssociationDesignatedBiesItemCreatable;
            IsStudentGraduationPlanAssociationDesignatedByIncluded = isStudentGraduationPlanAssociationDesignatedByIncluded;
            IsStudentGraduationPlanAssociationIndustryCredentialsItemCreatable = isStudentGraduationPlanAssociationIndustryCredentialsItemCreatable;
            IsStudentGraduationPlanAssociationIndustryCredentialIncluded = isStudentGraduationPlanAssociationIndustryCredentialIncluded;
            IsStudentGraduationPlanAssociationStudentContactAssociationsItemCreatable = isStudentGraduationPlanAssociationStudentContactAssociationsItemCreatable;
            IsStudentGraduationPlanAssociationStudentContactAssociationIncluded = isStudentGraduationPlanAssociationStudentContactAssociationIncluded;
            IsStudentGraduationPlanAssociationYearsAttendedsItemCreatable = isStudentGraduationPlanAssociationYearsAttendedsItemCreatable;
            IsStudentGraduationPlanAssociationYearsAttendedIncluded = isStudentGraduationPlanAssociationYearsAttendedIncluded;
        }

        public bool IsCommencementTimeSupported { get; }
        public bool IsEffectiveDateSupported { get; }
        public bool IsGraduationFeeSupported { get; }
        public bool IsGraduationPlanReferenceSupported { get; }
        public bool IsHighSchoolDurationSupported { get; }
        public bool IsHoursPerWeekSupported { get; }
        public bool IsIsActivePlanSupported { get; }
        public bool IsRequiredAttendanceSupported { get; }
        public bool IsStaffReferenceSupported { get; }
        public bool IsStaffUniqueIdSupported { get; }
        public bool IsStudentGraduationPlanAssociationAcademicSubjectsSupported { get; }
        public bool IsStudentGraduationPlanAssociationCareerPathwayCodesSupported { get; }
        public bool IsStudentGraduationPlanAssociationCTEProgramServiceSupported { get; }
        public bool IsStudentGraduationPlanAssociationDescriptionsSupported { get; }
        public bool IsStudentGraduationPlanAssociationDesignatedBiesSupported { get; }
        public bool IsStudentGraduationPlanAssociationIndustryCredentialsSupported { get; }
        public bool IsStudentGraduationPlanAssociationStudentContactAssociationsSupported { get; }
        public bool IsStudentGraduationPlanAssociationYearsAttendedsSupported { get; }
        public bool IsStudentReferenceSupported { get; }
        public bool IsTargetGPASupported { get; }
        public bool IsStudentGraduationPlanAssociationCTEProgramServiceCreatable { get; }
        public bool IsStudentGraduationPlanAssociationAcademicSubjectsItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationAcademicSubject, bool> IsStudentGraduationPlanAssociationAcademicSubjectIncluded { get; }
        public bool IsStudentGraduationPlanAssociationCareerPathwayCodesItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationCareerPathwayCode, bool> IsStudentGraduationPlanAssociationCareerPathwayCodeIncluded { get; }
        public bool IsStudentGraduationPlanAssociationDescriptionsItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationDescription, bool> IsStudentGraduationPlanAssociationDescriptionIncluded { get; }
        public bool IsStudentGraduationPlanAssociationDesignatedBiesItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationDesignatedBy, bool> IsStudentGraduationPlanAssociationDesignatedByIncluded { get; }
        public bool IsStudentGraduationPlanAssociationIndustryCredentialsItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationIndustryCredential, bool> IsStudentGraduationPlanAssociationIndustryCredentialIncluded { get; }
        public bool IsStudentGraduationPlanAssociationStudentContactAssociationsItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationStudentContactAssociation, bool> IsStudentGraduationPlanAssociationStudentContactAssociationIncluded { get; }
        public bool IsStudentGraduationPlanAssociationYearsAttendedsItemCreatable { get; }
        public Func<IStudentGraduationPlanAssociationYearsAttended, bool> IsStudentGraduationPlanAssociationYearsAttendedIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CommencementTime":
                    return IsCommencementTimeSupported;
                case "EffectiveDate":
                    return IsEffectiveDateSupported;
                case "GraduationFee":
                    return IsGraduationFeeSupported;
                case "GraduationPlanReference":
                    return IsGraduationPlanReferenceSupported;
                case "HighSchoolDuration":
                    return IsHighSchoolDurationSupported;
                case "HoursPerWeek":
                    return IsHoursPerWeekSupported;
                case "IsActivePlan":
                    return IsIsActivePlanSupported;
                case "RequiredAttendance":
                    return IsRequiredAttendanceSupported;
                case "StaffReference":
                    return IsStaffReferenceSupported;
                case "StaffUniqueId":
                    return IsStaffUniqueIdSupported;
                case "StudentGraduationPlanAssociationAcademicSubjects":
                    return IsStudentGraduationPlanAssociationAcademicSubjectsSupported;
                case "StudentGraduationPlanAssociationCareerPathwayCodes":
                    return IsStudentGraduationPlanAssociationCareerPathwayCodesSupported;
                case "StudentGraduationPlanAssociationCTEProgramService":
                    return IsStudentGraduationPlanAssociationCTEProgramServiceSupported;
                case "StudentGraduationPlanAssociationDescriptions":
                    return IsStudentGraduationPlanAssociationDescriptionsSupported;
                case "StudentGraduationPlanAssociationDesignatedBies":
                    return IsStudentGraduationPlanAssociationDesignatedBiesSupported;
                case "StudentGraduationPlanAssociationIndustryCredentials":
                    return IsStudentGraduationPlanAssociationIndustryCredentialsSupported;
                case "StudentGraduationPlanAssociationStudentContactAssociations":
                    return IsStudentGraduationPlanAssociationStudentContactAssociationsSupported;
                case "StudentGraduationPlanAssociationYearsAttendeds":
                    return IsStudentGraduationPlanAssociationYearsAttendedsSupported;
                case "StudentReference":
                    return IsStudentReferenceSupported;
                case "TargetGPA":
                    return IsTargetGPASupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "EducationOrganizationId":
                    return true;
                case "GraduationPlanTypeDescriptor":
                    return true;
                case "GraduationSchoolYear":
                    return true;
                case "StudentUniqueId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentGraduationPlanAssociationCTEProgramService":
                    return IsStudentGraduationPlanAssociationCTEProgramServiceCreatable;
                case "StudentGraduationPlanAssociationAcademicSubjects":
                    return IsStudentGraduationPlanAssociationAcademicSubjectsItemCreatable;
                case "StudentGraduationPlanAssociationCareerPathwayCodes":
                    return IsStudentGraduationPlanAssociationCareerPathwayCodesItemCreatable;
                case "StudentGraduationPlanAssociationDescriptions":
                    return IsStudentGraduationPlanAssociationDescriptionsItemCreatable;
                case "StudentGraduationPlanAssociationDesignatedBies":
                    return IsStudentGraduationPlanAssociationDesignatedBiesItemCreatable;
                case "StudentGraduationPlanAssociationIndustryCredentials":
                    return IsStudentGraduationPlanAssociationIndustryCredentialsItemCreatable;
                case "StudentGraduationPlanAssociationStudentContactAssociations":
                    return IsStudentGraduationPlanAssociationStudentContactAssociationsItemCreatable;
                case "StudentGraduationPlanAssociationYearsAttendeds":
                    return IsStudentGraduationPlanAssociationYearsAttendedsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationAcademicSubject model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationAcademicSubject : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        string AcademicSubjectDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationAcademicSubjectMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationAcademicSubjectMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "AcademicSubjectDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationCareerPathwayCode model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationCareerPathwayCode : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        int CareerPathwayCode { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationCareerPathwayCodeMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationCareerPathwayCodeMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "CareerPathwayCode":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationCTEProgramService model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationCTEProgramService : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }

        // Non-PK properties
        string CIPCode { get; set; }
        string CTEProgramServiceDescriptor { get; set; }
        bool? PrimaryIndicator { get; set; }
        DateTime? ServiceBeginDate { get; set; }
        DateTime? ServiceEndDate { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationCTEProgramServiceMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationCTEProgramServiceMappingContract(
            bool isCIPCodeSupported,
            bool isCTEProgramServiceDescriptorSupported,
            bool isPrimaryIndicatorSupported,
            bool isServiceBeginDateSupported,
            bool isServiceEndDateSupported
            )
        {
            IsCIPCodeSupported = isCIPCodeSupported;
            IsCTEProgramServiceDescriptorSupported = isCTEProgramServiceDescriptorSupported;
            IsPrimaryIndicatorSupported = isPrimaryIndicatorSupported;
            IsServiceBeginDateSupported = isServiceBeginDateSupported;
            IsServiceEndDateSupported = isServiceEndDateSupported;
        }

        public bool IsCIPCodeSupported { get; }
        public bool IsCTEProgramServiceDescriptorSupported { get; }
        public bool IsPrimaryIndicatorSupported { get; }
        public bool IsServiceBeginDateSupported { get; }
        public bool IsServiceEndDateSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "CIPCode":
                    return IsCIPCodeSupported;
                case "CTEProgramServiceDescriptor":
                    return IsCTEProgramServiceDescriptorSupported;
                case "PrimaryIndicator":
                    return IsPrimaryIndicatorSupported;
                case "ServiceBeginDate":
                    return IsServiceBeginDateSupported;
                case "ServiceEndDate":
                    return IsServiceEndDateSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationDescription model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationDescription : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        string Description { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationDescriptionMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationDescriptionMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "Description":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationDesignatedBy model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationDesignatedBy : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        string DesignatedBy { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationDesignatedByMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationDesignatedByMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "DesignatedBy":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationIndustryCredential model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationIndustryCredential : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        string IndustryCredential { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationIndustryCredentialMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationIndustryCredentialMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "IndustryCredential":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationStudentContactAssociation model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationStudentContactAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        string ContactUniqueId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentContactAssociationResourceId { get; set; }
        string StudentContactAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationStudentContactAssociationMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationStudentContactAssociationMappingContract(
            bool isStudentContactAssociationReferenceSupported
            )
        {
            IsStudentContactAssociationReferenceSupported = isStudentContactAssociationReferenceSupported;
        }

        public bool IsStudentContactAssociationReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentContactAssociationReference":
                    return IsStudentContactAssociationReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "ContactUniqueId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentGraduationPlanAssociationYearsAttended model.
    /// </summary>
    public interface IStudentGraduationPlanAssociationYearsAttended : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentGraduationPlanAssociation StudentGraduationPlanAssociation { get; set; }
        
        short YearsAttended { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentGraduationPlanAssociationYearsAttendedMappingContract : IMappingContract
    {
        public StudentGraduationPlanAssociationYearsAttendedMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "YearsAttended":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentPet model.
    /// </summary>
    public interface IStudentPet : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentExtension StudentExtension { get; set; }
        
        string PetName { get; set; }

        // Non-PK properties
        bool? IsFixed { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentPetMappingContract : IMappingContract
    {
        public StudentPetMappingContract(
            bool isIsFixedSupported
            )
        {
            IsIsFixedSupported = isIsFixedSupported;
        }

        public bool IsIsFixedSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "IsFixed":
                    return IsIsFixedSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "PetName":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentPetPreference model.
    /// </summary>
    public interface IStudentPetPreference : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentExtension StudentExtension { get; set; }

        // Non-PK properties
        int MaximumWeight { get; set; }
        int MinimumWeight { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentPetPreferenceMappingContract : IMappingContract
    {
        public StudentPetPreferenceMappingContract(
            bool isMaximumWeightSupported,
            bool isMinimumWeightSupported
            )
        {
            IsMaximumWeightSupported = isMaximumWeightSupported;
            IsMinimumWeightSupported = isMinimumWeightSupported;
        }

        public bool IsMaximumWeightSupported { get; }
        public bool IsMinimumWeightSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MaximumWeight":
                    return IsMaximumWeightSupported;
                case "MinimumWeight":
                    return IsMinimumWeightSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAssociationExtension model.
    /// </summary>
    public interface IStudentSchoolAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentSchoolAssociation StudentSchoolAssociation { get; set; }

        // Non-PK properties
        string MembershipTypeDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentSchoolAssociationExtensionMappingContract : IMappingContract
    {
        public StudentSchoolAssociationExtensionMappingContract(
            bool isMembershipTypeDescriptorSupported
            )
        {
            IsMembershipTypeDescriptorSupported = isMembershipTypeDescriptorSupported;
        }

        public bool IsMembershipTypeDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "MembershipTypeDescriptor":
                    return IsMembershipTypeDescriptorSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSectionAssociationExtension model.
    /// </summary>
    public interface IStudentSectionAssociationExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        EdFi.IStudentSectionAssociation StudentSectionAssociation { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStudentSectionAssociationRelatedGeneralStudentProgramAssociation> StudentSectionAssociationRelatedGeneralStudentProgramAssociations { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentSectionAssociationExtensionMappingContract : IMappingContract
    {
        public StudentSectionAssociationExtensionMappingContract(
            bool isStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported,
            bool isStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItemCreatable,
            Func<IStudentSectionAssociationRelatedGeneralStudentProgramAssociation, bool> isStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded
            )
        {
            IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported = isStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported;
            IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItemCreatable = isStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItemCreatable;
            IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded = isStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded;
        }

        public bool IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported { get; }
        public bool IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItemCreatable { get; }
        public Func<IStudentSectionAssociationRelatedGeneralStudentProgramAssociation, bool> IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentSectionAssociationRelatedGeneralStudentProgramAssociations":
                    return IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName)
        {
            switch (memberName)
            {
                case "StudentSectionAssociationRelatedGeneralStudentProgramAssociations":
                    return IsStudentSectionAssociationRelatedGeneralStudentProgramAssociationsItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSectionAssociationRelatedGeneralStudentProgramAssociation model.
    /// </summary>
    public interface IStudentSectionAssociationRelatedGeneralStudentProgramAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentSectionAssociationExtension StudentSectionAssociationExtension { get; set; }
        
        DateTime RelatedBeginDate { get; set; }
        
        long RelatedEducationOrganizationId { get; set; }
        
        long RelatedProgramEducationOrganizationId { get; set; }
        
        string RelatedProgramName { get; set; }
        
        string RelatedProgramTypeDescriptor { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? RelatedGeneralStudentProgramAssociationResourceId { get; set; }
        string RelatedGeneralStudentProgramAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentSectionAssociationRelatedGeneralStudentProgramAssociationMappingContract : IMappingContract
    {
        public StudentSectionAssociationRelatedGeneralStudentProgramAssociationMappingContract(
            bool isRelatedGeneralStudentProgramAssociationReferenceSupported
            )
        {
            IsRelatedGeneralStudentProgramAssociationReferenceSupported = isRelatedGeneralStudentProgramAssociationReferenceSupported;
        }

        public bool IsRelatedGeneralStudentProgramAssociationReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "RelatedGeneralStudentProgramAssociationReference":
                    return IsRelatedGeneralStudentProgramAssociationReferenceSupported;
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "RelatedBeginDate":
                    return true;
                case "RelatedEducationOrganizationId":
                    return true;
                case "RelatedProgramEducationOrganizationId":
                    return true;
                case "RelatedProgramName":
                    return true;
                case "RelatedProgramTypeDescriptor":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }
}

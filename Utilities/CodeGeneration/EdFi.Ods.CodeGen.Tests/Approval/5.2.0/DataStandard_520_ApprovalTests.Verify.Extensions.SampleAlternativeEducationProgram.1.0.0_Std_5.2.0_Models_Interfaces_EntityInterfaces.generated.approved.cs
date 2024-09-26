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

namespace EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the AlternativeEducationEligibilityReasonDescriptor model.
    /// </summary>
    public interface IAlternativeEducationEligibilityReasonDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [AutoIncrement]
        int AlternativeEducationEligibilityReasonDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class AlternativeEducationEligibilityReasonDescriptorMappingContract : IMappingContract
    {
        public AlternativeEducationEligibilityReasonDescriptorMappingContract(
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
                case "AlternativeEducationEligibilityReasonDescriptorId":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAlternativeEducationProgramAssociation model.
    /// </summary>
    public interface IStudentAlternativeEducationProgramAssociation : EdFi.IGeneralStudentProgramAssociation, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties

        // Non-PK properties
        string AlternativeEducationEligibilityReasonDescriptor { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentAlternativeEducationProgramAssociationMeetingTime> StudentAlternativeEducationProgramAssociationMeetingTimes { get; set; }

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentAlternativeEducationProgramAssociationMappingContract : IMappingContract
    {
        public StudentAlternativeEducationProgramAssociationMappingContract(
            bool isAlternativeEducationEligibilityReasonDescriptorSupported,
            bool isEducationOrganizationReferenceSupported,
            bool isEndDateSupported,
            bool isGeneralStudentProgramAssociationProgramParticipationStatusesSupported,
            bool isProgramReferenceSupported,
            bool isReasonExitedDescriptorSupported,
            bool isServedOutsideOfRegularSessionSupported,
            bool isStudentAlternativeEducationProgramAssociationMeetingTimesSupported,
            bool isStudentReferenceSupported,
            bool isGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable,
            Func<IGeneralStudentProgramAssociationProgramParticipationStatus, bool> isGeneralStudentProgramAssociationProgramParticipationStatusIncluded,
            bool isStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable,
            Func<IStudentAlternativeEducationProgramAssociationMeetingTime, bool> isStudentAlternativeEducationProgramAssociationMeetingTimeIncluded
            )
        {
            IsAlternativeEducationEligibilityReasonDescriptorSupported = isAlternativeEducationEligibilityReasonDescriptorSupported;
            IsEducationOrganizationReferenceSupported = isEducationOrganizationReferenceSupported;
            IsEndDateSupported = isEndDateSupported;
            IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported = isGeneralStudentProgramAssociationProgramParticipationStatusesSupported;
            IsProgramReferenceSupported = isProgramReferenceSupported;
            IsReasonExitedDescriptorSupported = isReasonExitedDescriptorSupported;
            IsServedOutsideOfRegularSessionSupported = isServedOutsideOfRegularSessionSupported;
            IsStudentAlternativeEducationProgramAssociationMeetingTimesSupported = isStudentAlternativeEducationProgramAssociationMeetingTimesSupported;
            IsStudentReferenceSupported = isStudentReferenceSupported;
            IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable = isGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable;
            IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded = isGeneralStudentProgramAssociationProgramParticipationStatusIncluded;
            IsStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable = isStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable;
            IsStudentAlternativeEducationProgramAssociationMeetingTimeIncluded = isStudentAlternativeEducationProgramAssociationMeetingTimeIncluded;
        }

        public bool IsAlternativeEducationEligibilityReasonDescriptorSupported { get; }
        public bool IsEducationOrganizationReferenceSupported { get; }
        public bool IsEndDateSupported { get; }
        public bool IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported { get; }
        public bool IsProgramReferenceSupported { get; }
        public bool IsReasonExitedDescriptorSupported { get; }
        public bool IsServedOutsideOfRegularSessionSupported { get; }
        public bool IsStudentAlternativeEducationProgramAssociationMeetingTimesSupported { get; }
        public bool IsStudentReferenceSupported { get; }
        public bool IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable { get; }
        public Func<IGeneralStudentProgramAssociationProgramParticipationStatus, bool> IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded { get; }
        public bool IsStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable { get; }
        public Func<IStudentAlternativeEducationProgramAssociationMeetingTime, bool> IsStudentAlternativeEducationProgramAssociationMeetingTimeIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AlternativeEducationEligibilityReasonDescriptor":
                    return IsAlternativeEducationEligibilityReasonDescriptorSupported;
                case "EducationOrganizationReference":
                    return IsEducationOrganizationReferenceSupported;
                case "EndDate":
                    return IsEndDateSupported;
                case "GeneralStudentProgramAssociationProgramParticipationStatuses":
                    return IsGeneralStudentProgramAssociationProgramParticipationStatusesSupported;
                case "ProgramReference":
                    return IsProgramReferenceSupported;
                case "ReasonExitedDescriptor":
                    return IsReasonExitedDescriptorSupported;
                case "ServedOutsideOfRegularSession":
                    return IsServedOutsideOfRegularSessionSupported;
                case "StudentAlternativeEducationProgramAssociationMeetingTimes":
                    return IsStudentAlternativeEducationProgramAssociationMeetingTimesSupported;
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
                case "GeneralStudentProgramAssociationProgramParticipationStatuses":
                    return IsGeneralStudentProgramAssociationProgramParticipationStatusesItemCreatable;
                case "StudentAlternativeEducationProgramAssociationMeetingTimes":
                    return IsStudentAlternativeEducationProgramAssociationMeetingTimesItemCreatable;
                default:
                    throw new Exception($"Unknown child item '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAlternativeEducationProgramAssociationMeetingTime model.
    /// </summary>
    public interface IStudentAlternativeEducationProgramAssociationMeetingTime : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IStudentAlternativeEducationProgramAssociation StudentAlternativeEducationProgramAssociation { get; set; }
        
        TimeSpan EndTime { get; set; }
        
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
    public class StudentAlternativeEducationProgramAssociationMeetingTimeMappingContract : IMappingContract
    {
        public StudentAlternativeEducationProgramAssociationMeetingTimeMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                // Additional inspection support for identifying properties (which are implicitly supported by Profiles) for use during validation
                case "EndTime":
                    return true;
                case "StartTime":
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

        bool IMappingContract.IsItemCreatable(string memberName) => throw new Exception($"Unknown child item member '{memberName}'.");

    }
}

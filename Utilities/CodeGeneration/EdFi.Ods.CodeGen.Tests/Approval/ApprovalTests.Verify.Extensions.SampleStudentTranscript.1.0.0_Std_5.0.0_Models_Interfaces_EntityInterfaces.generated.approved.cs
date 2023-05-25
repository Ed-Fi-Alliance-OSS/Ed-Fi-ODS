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

namespace EdFi.Ods.Entities.Common.SampleStudentTranscript
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InstitutionControlDescriptor model.
    /// </summary>
    public interface IInstitutionControlDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InstitutionControlDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class InstitutionControlDescriptorMappingContract : IMappingContract
    {
        public InstitutionControlDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isPriorDescriptorIdSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsPriorDescriptorIdSupported = isPriorDescriptorIdSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsPriorDescriptorIdSupported { get; }
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
                case "PriorDescriptorId":
                    return IsPriorDescriptorIdSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the InstitutionLevelDescriptor model.
    /// </summary>
    public interface IInstitutionLevelDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int InstitutionLevelDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class InstitutionLevelDescriptorMappingContract : IMappingContract
    {
        public InstitutionLevelDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isPriorDescriptorIdSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsPriorDescriptorIdSupported = isPriorDescriptorIdSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsPriorDescriptorIdSupported { get; }
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
                case "PriorDescriptorId":
                    return IsPriorDescriptorIdSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the PostSecondaryOrganization model.
    /// </summary>
    public interface IPostSecondaryOrganization : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string NameOfInstitution { get; set; }

        // Non-PK properties
        bool AcceptanceIndicator { get; set; }
        string InstitutionControlDescriptor { get; set; }
        string InstitutionLevelDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class PostSecondaryOrganizationMappingContract : IMappingContract
    {
        public PostSecondaryOrganizationMappingContract(
            bool isAcceptanceIndicatorSupported,
            bool isInstitutionControlDescriptorSupported,
            bool isInstitutionLevelDescriptorSupported
            )
        {
            IsAcceptanceIndicatorSupported = isAcceptanceIndicatorSupported;
            IsInstitutionControlDescriptorSupported = isInstitutionControlDescriptorSupported;
            IsInstitutionLevelDescriptorSupported = isInstitutionLevelDescriptorSupported;
        }

        public bool IsAcceptanceIndicatorSupported { get; }
        public bool IsInstitutionControlDescriptorSupported { get; }
        public bool IsInstitutionLevelDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "AcceptanceIndicator":
                    return IsAcceptanceIndicatorSupported;
                case "InstitutionControlDescriptor":
                    return IsInstitutionControlDescriptorSupported;
                case "InstitutionLevelDescriptor":
                    return IsInstitutionLevelDescriptorSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SpecialEducationGraduationStatusDescriptor model.
    /// </summary>
    public interface ISpecialEducationGraduationStatusDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SpecialEducationGraduationStatusDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SpecialEducationGraduationStatusDescriptorMappingContract : IMappingContract
    {
        public SpecialEducationGraduationStatusDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isPriorDescriptorIdSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsPriorDescriptorIdSupported = isPriorDescriptorIdSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsPriorDescriptorIdSupported { get; }
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
                case "PriorDescriptorId":
                    return IsPriorDescriptorIdSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordClassRankingExtension model.
    /// </summary>
    public interface IStudentAcademicRecordClassRankingExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentAcademicRecordClassRanking StudentAcademicRecordClassRanking { get; set; }

        // Non-PK properties
        string SpecialEducationGraduationStatusDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentAcademicRecordClassRankingExtensionMappingContract : IMappingContract
    {
        public StudentAcademicRecordClassRankingExtensionMappingContract(
            bool isSpecialEducationGraduationStatusDescriptorSupported
            )
        {
            IsSpecialEducationGraduationStatusDescriptorSupported = isSpecialEducationGraduationStatusDescriptorSupported;
        }

        public bool IsSpecialEducationGraduationStatusDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SpecialEducationGraduationStatusDescriptor":
                    return IsSpecialEducationGraduationStatusDescriptorSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAcademicRecordExtension model.
    /// </summary>
    public interface IStudentAcademicRecordExtension : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        EdFi.IStudentAcademicRecord StudentAcademicRecord { get; set; }

        // Non-PK properties
        string NameOfInstitution { get; set; }
        string SubmissionCertificationDescriptor { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? PostSecondaryOrganizationResourceId { get; set; }
        string PostSecondaryOrganizationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentAcademicRecordExtensionMappingContract : IMappingContract
    {
        public StudentAcademicRecordExtensionMappingContract(
            bool isNameOfInstitutionSupported,
            bool isSubmissionCertificationDescriptorSupported
            )
        {
            IsNameOfInstitutionSupported = isNameOfInstitutionSupported;
            IsSubmissionCertificationDescriptorSupported = isSubmissionCertificationDescriptorSupported;
        }

        public bool IsNameOfInstitutionSupported { get; }
        public bool IsSubmissionCertificationDescriptorSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "NameOfInstitution":
                    return IsNameOfInstitutionSupported;
                case "SubmissionCertificationDescriptor":
                    return IsSubmissionCertificationDescriptorSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SubmissionCertificationDescriptor model.
    /// </summary>
    public interface ISubmissionCertificationDescriptor : EdFi.IDescriptor, ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember][AutoIncrement]
        int SubmissionCertificationDescriptorId { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SubmissionCertificationDescriptorMappingContract : IMappingContract
    {
        public SubmissionCertificationDescriptorMappingContract(
            bool isCodeValueSupported,
            bool isDescriptionSupported,
            bool isEffectiveBeginDateSupported,
            bool isEffectiveEndDateSupported,
            bool isNamespaceSupported,
            bool isPriorDescriptorIdSupported,
            bool isShortDescriptionSupported
            )
        {
            IsCodeValueSupported = isCodeValueSupported;
            IsDescriptionSupported = isDescriptionSupported;
            IsEffectiveBeginDateSupported = isEffectiveBeginDateSupported;
            IsEffectiveEndDateSupported = isEffectiveEndDateSupported;
            IsNamespaceSupported = isNamespaceSupported;
            IsPriorDescriptorIdSupported = isPriorDescriptorIdSupported;
            IsShortDescriptionSupported = isShortDescriptionSupported;
        }

        public bool IsCodeValueSupported { get; }
        public bool IsDescriptionSupported { get; }
        public bool IsEffectiveBeginDateSupported { get; }
        public bool IsEffectiveEndDateSupported { get; }
        public bool IsNamespaceSupported { get; }
        public bool IsPriorDescriptorIdSupported { get; }
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
                case "PriorDescriptorId":
                    return IsPriorDescriptorIdSupported;
                case "ShortDescription":
                    return IsShortDescriptionSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }
}

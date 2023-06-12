using System;
using System.Linq;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;

#pragma warning disable 108,114

namespace EdFi.Ods.Entities.Common.Homograph
{

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Name model.
    /// </summary>
    public interface IName : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string FirstName { get; set; }
        [NaturalKeyMember]
        string LastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class NameMappingContract : IMappingContract
    {
        public NameMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Parent model.
    /// </summary>
    public interface IParent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string ParentFirstName { get; set; }
        [NaturalKeyMember]
        string ParentLastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IParentAddress> ParentAddresses { get; set; }
        ICollection<IParentStudentSchoolAssociation> ParentStudentSchoolAssociations { get; set; }

        // Resource reference data
        Guid? ParentNameResourceId { get; set; }
        string ParentNameDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ParentMappingContract : IMappingContract
    {
        public ParentMappingContract(
            bool isParentAddressesSupported,
            bool isParentStudentSchoolAssociationsSupported,
            Func<IParentAddress, bool> isParentAddressIncluded,
            Func<IParentStudentSchoolAssociation, bool> isParentStudentSchoolAssociationIncluded
            )
        {
            IsParentAddressesSupported = isParentAddressesSupported;
            IsParentStudentSchoolAssociationsSupported = isParentStudentSchoolAssociationsSupported;
            IsParentAddressIncluded = isParentAddressIncluded;
            IsParentStudentSchoolAssociationIncluded = isParentStudentSchoolAssociationIncluded;
        }

        public bool IsParentAddressesSupported { get; }
        public bool IsParentStudentSchoolAssociationsSupported { get; }
        public Func<IParentAddress, bool> IsParentAddressIncluded { get; }
        public Func<IParentStudentSchoolAssociation, bool> IsParentStudentSchoolAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ParentAddresses":
                    return IsParentAddressesSupported;
                case "ParentStudentSchoolAssociations":
                    return IsParentStudentSchoolAssociationsSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentAddress model.
    /// </summary>
    public interface IParentAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
        [NaturalKeyMember]
        string City { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ParentAddressMappingContract : IMappingContract
    {
        public ParentAddressMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ParentStudentSchoolAssociation model.
    /// </summary>
    public interface IParentStudentSchoolAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IParent Parent { get; set; }
        [NaturalKeyMember]
        string SchoolName { get; set; }
        [NaturalKeyMember]
        string StudentFirstName { get; set; }
        [NaturalKeyMember]
        string StudentLastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentSchoolAssociationResourceId { get; set; }
        string StudentSchoolAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ParentStudentSchoolAssociationMappingContract : IMappingContract
    {
        public ParentStudentSchoolAssociationMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the School model.
    /// </summary>
    public interface ISchool : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string SchoolName { get; set; }

        // Non-PK properties
        string SchoolYear { get; set; }

        // One-to-one relationships

        ISchoolAddress SchoolAddress { get; set; }

        // Lists

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
        string SchoolYearTypeDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolMappingContract : IMappingContract
    {
        public SchoolMappingContract(
            bool isSchoolAddressSupported,
            bool isSchoolYearSupported
            )
        {
            IsSchoolAddressSupported = isSchoolAddressSupported;
            IsSchoolYearSupported = isSchoolYearSupported;
        }

        public bool IsSchoolAddressSupported { get; }
        public bool IsSchoolYearSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolAddress":
                    return IsSchoolAddressSupported;
                case "SchoolYear":
                    return IsSchoolYearSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolAddress model.
    /// </summary>
    public interface ISchoolAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        ISchool School { get; set; }

        // Non-PK properties
        string City { get; set; }

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolAddressMappingContract : IMappingContract
    {
        public SchoolAddressMappingContract(
            bool isCitySupported
            )
        {
            IsCitySupported = isCitySupported;
        }

        public bool IsCitySupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "City":
                    return IsCitySupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the SchoolYearType model.
    /// </summary>
    public interface ISchoolYearType : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string SchoolYear { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class SchoolYearTypeMappingContract : IMappingContract
    {
        public SchoolYearTypeMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Staff model.
    /// </summary>
    public interface IStaff : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string StaffFirstName { get; set; }
        [NaturalKeyMember]
        string StaffLastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IStaffAddress> StaffAddresses { get; set; }
        ICollection<IStaffStudentSchoolAssociation> StaffStudentSchoolAssociations { get; set; }

        // Resource reference data
        Guid? StaffNameResourceId { get; set; }
        string StaffNameDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StaffMappingContract : IMappingContract
    {
        public StaffMappingContract(
            bool isStaffAddressesSupported,
            bool isStaffStudentSchoolAssociationsSupported,
            Func<IStaffAddress, bool> isStaffAddressIncluded,
            Func<IStaffStudentSchoolAssociation, bool> isStaffStudentSchoolAssociationIncluded
            )
        {
            IsStaffAddressesSupported = isStaffAddressesSupported;
            IsStaffStudentSchoolAssociationsSupported = isStaffStudentSchoolAssociationsSupported;
            IsStaffAddressIncluded = isStaffAddressIncluded;
            IsStaffStudentSchoolAssociationIncluded = isStaffStudentSchoolAssociationIncluded;
        }

        public bool IsStaffAddressesSupported { get; }
        public bool IsStaffStudentSchoolAssociationsSupported { get; }
        public Func<IStaffAddress, bool> IsStaffAddressIncluded { get; }
        public Func<IStaffStudentSchoolAssociation, bool> IsStaffStudentSchoolAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StaffAddresses":
                    return IsStaffAddressesSupported;
                case "StaffStudentSchoolAssociations":
                    return IsStaffStudentSchoolAssociationsSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffAddress model.
    /// </summary>
    public interface IStaffAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
        [NaturalKeyMember]
        string City { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StaffAddressMappingContract : IMappingContract
    {
        public StaffAddressMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StaffStudentSchoolAssociation model.
    /// </summary>
    public interface IStaffStudentSchoolAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStaff Staff { get; set; }
        [NaturalKeyMember]
        string SchoolName { get; set; }
        [NaturalKeyMember]
        string StudentFirstName { get; set; }
        [NaturalKeyMember]
        string StudentLastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? StudentSchoolAssociationResourceId { get; set; }
        string StudentSchoolAssociationDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StaffStudentSchoolAssociationMappingContract : IMappingContract
    {
        public StaffStudentSchoolAssociationMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the Student model.
    /// </summary>
    public interface IStudent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string StudentFirstName { get; set; }
        [NaturalKeyMember]
        string StudentLastSurname { get; set; }

        // Non-PK properties
        string SchoolYear { get; set; }

        // One-to-one relationships

        // Lists
        ICollection<IStudentAddress> StudentAddresses { get; set; }

        // Resource reference data
        Guid? SchoolYearTypeResourceId { get; set; }
        string SchoolYearTypeDiscriminator { get; set; }
        Guid? StudentNameResourceId { get; set; }
        string StudentNameDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentMappingContract : IMappingContract
    {
        public StudentMappingContract(
            bool isSchoolYearSupported,
            bool isStudentAddressesSupported,
            Func<IStudentAddress, bool> isStudentAddressIncluded
            )
        {
            IsSchoolYearSupported = isSchoolYearSupported;
            IsStudentAddressesSupported = isStudentAddressesSupported;
            IsStudentAddressIncluded = isStudentAddressIncluded;
        }

        public bool IsSchoolYearSupported { get; }
        public bool IsStudentAddressesSupported { get; }
        public Func<IStudentAddress, bool> IsStudentAddressIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolYear":
                    return IsSchoolYearSupported;
                case "StudentAddresses":
                    return IsStudentAddressesSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentAddress model.
    /// </summary>
    public interface IStudentAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        IStudent Student { get; set; }
        [NaturalKeyMember]
        string City { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentAddressMappingContract : IMappingContract
    {
        public StudentAddressMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the StudentSchoolAssociation model.
    /// </summary>
    public interface IStudentSchoolAssociation : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        [NaturalKeyMember]
        string SchoolName { get; set; }
        [NaturalKeyMember]
        string StudentFirstName { get; set; }
        [NaturalKeyMember]
        string StudentLastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists

        // Resource reference data
        Guid? SchoolResourceId { get; set; }
        string SchoolDiscriminator { get; set; }
        Guid? StudentResourceId { get; set; }
        string StudentDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class StudentSchoolAssociationMappingContract : IMappingContract
    {
        public StudentSchoolAssociationMappingContract(
            )
        {
        }


        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }
}

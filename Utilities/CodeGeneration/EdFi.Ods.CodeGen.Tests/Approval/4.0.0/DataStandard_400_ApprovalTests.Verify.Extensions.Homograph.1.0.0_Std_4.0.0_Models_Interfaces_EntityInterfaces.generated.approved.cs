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
        
        string FirstName { get; set; }
        
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
    /// Defines available properties and methods for the abstraction of the Parent model.
    /// </summary>
    public interface IParent : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string ParentFirstName { get; set; }
        
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
            bool isParentNameReferenceSupported,
            bool isParentStudentSchoolAssociationsSupported,
            Func<IParentAddress, bool> isParentAddressIncluded,
            Func<IParentStudentSchoolAssociation, bool> isParentStudentSchoolAssociationIncluded
            )
        {
            IsParentAddressesSupported = isParentAddressesSupported;
            IsParentNameReferenceSupported = isParentNameReferenceSupported;
            IsParentStudentSchoolAssociationsSupported = isParentStudentSchoolAssociationsSupported;
            IsParentAddressIncluded = isParentAddressIncluded;
            IsParentStudentSchoolAssociationIncluded = isParentStudentSchoolAssociationIncluded;
        }

        public bool IsParentAddressesSupported { get; }
        public bool IsParentNameReferenceSupported { get; }
        public bool IsParentStudentSchoolAssociationsSupported { get; }
        public Func<IParentAddress, bool> IsParentAddressIncluded { get; }
        public Func<IParentStudentSchoolAssociation, bool> IsParentStudentSchoolAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ParentAddresses":
                    return IsParentAddressesSupported;
                case "ParentNameReference":
                    return IsParentNameReferenceSupported;
                case "ParentStudentSchoolAssociations":
                    return IsParentStudentSchoolAssociationsSupported;
                case "ParentFirstName":
                    // Identifying properties are always supported
                    return true;
                case "ParentLastSurname":
                    // Identifying properties are always supported
                    return true;
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
        IParent Parent { get; set; }
        
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
                case "City":
                    // Identifying properties are always supported
                    return true;
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
        IParent Parent { get; set; }
        
        string SchoolName { get; set; }
        
        string StudentFirstName { get; set; }
        
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
            bool isStudentSchoolAssociationReferenceSupported
            )
        {
            IsStudentSchoolAssociationReferenceSupported = isStudentSchoolAssociationReferenceSupported;
        }

        public bool IsStudentSchoolAssociationReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentSchoolAssociationReference":
                    return IsStudentSchoolAssociationReferenceSupported;
                case "SchoolName":
                    // Identifying properties are always supported
                    return true;
                case "StudentFirstName":
                    // Identifying properties are always supported
                    return true;
                case "StudentLastSurname":
                    // Identifying properties are always supported
                    return true;
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
            bool isSchoolYearSupported,
            bool isSchoolYearTypeReferenceSupported
            )
        {
            IsSchoolAddressSupported = isSchoolAddressSupported;
            IsSchoolYearSupported = isSchoolYearSupported;
            IsSchoolYearTypeReferenceSupported = isSchoolYearTypeReferenceSupported;
        }

        public bool IsSchoolAddressSupported { get; }
        public bool IsSchoolYearSupported { get; }
        public bool IsSchoolYearTypeReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolAddress":
                    return IsSchoolAddressSupported;
                case "SchoolYear":
                    return IsSchoolYearSupported;
                case "SchoolYearTypeReference":
                    return IsSchoolYearTypeReferenceSupported;
                case "SchoolName":
                    // Identifying properties are always supported
                    return true;
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
                case "SchoolYear":
                    // Identifying properties are always supported
                    return true;
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
        
        string StaffFirstName { get; set; }
        
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
            bool isStaffNameReferenceSupported,
            bool isStaffStudentSchoolAssociationsSupported,
            Func<IStaffAddress, bool> isStaffAddressIncluded,
            Func<IStaffStudentSchoolAssociation, bool> isStaffStudentSchoolAssociationIncluded
            )
        {
            IsStaffAddressesSupported = isStaffAddressesSupported;
            IsStaffNameReferenceSupported = isStaffNameReferenceSupported;
            IsStaffStudentSchoolAssociationsSupported = isStaffStudentSchoolAssociationsSupported;
            IsStaffAddressIncluded = isStaffAddressIncluded;
            IsStaffStudentSchoolAssociationIncluded = isStaffStudentSchoolAssociationIncluded;
        }

        public bool IsStaffAddressesSupported { get; }
        public bool IsStaffNameReferenceSupported { get; }
        public bool IsStaffStudentSchoolAssociationsSupported { get; }
        public Func<IStaffAddress, bool> IsStaffAddressIncluded { get; }
        public Func<IStaffStudentSchoolAssociation, bool> IsStaffStudentSchoolAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StaffAddresses":
                    return IsStaffAddressesSupported;
                case "StaffNameReference":
                    return IsStaffNameReferenceSupported;
                case "StaffStudentSchoolAssociations":
                    return IsStaffStudentSchoolAssociationsSupported;
                case "StaffFirstName":
                    // Identifying properties are always supported
                    return true;
                case "StaffLastSurname":
                    // Identifying properties are always supported
                    return true;
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
        IStaff Staff { get; set; }
        
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
                case "City":
                    // Identifying properties are always supported
                    return true;
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
        IStaff Staff { get; set; }
        
        string SchoolName { get; set; }
        
        string StudentFirstName { get; set; }
        
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
            bool isStudentSchoolAssociationReferenceSupported
            )
        {
            IsStudentSchoolAssociationReferenceSupported = isStudentSchoolAssociationReferenceSupported;
        }

        public bool IsStudentSchoolAssociationReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "StudentSchoolAssociationReference":
                    return IsStudentSchoolAssociationReferenceSupported;
                case "SchoolName":
                    // Identifying properties are always supported
                    return true;
                case "StudentFirstName":
                    // Identifying properties are always supported
                    return true;
                case "StudentLastSurname":
                    // Identifying properties are always supported
                    return true;
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
        
        string StudentFirstName { get; set; }
        
        string StudentLastSurname { get; set; }

        // Non-PK properties
        string SchoolYear { get; set; }

        // One-to-one relationships

        IStudentAddress StudentAddress { get; set; }

        // Lists

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
            bool isSchoolYearTypeReferenceSupported,
            bool isStudentAddressSupported,
            bool isStudentNameReferenceSupported
            )
        {
            IsSchoolYearSupported = isSchoolYearSupported;
            IsSchoolYearTypeReferenceSupported = isSchoolYearTypeReferenceSupported;
            IsStudentAddressSupported = isStudentAddressSupported;
            IsStudentNameReferenceSupported = isStudentNameReferenceSupported;
        }

        public bool IsSchoolYearSupported { get; }
        public bool IsSchoolYearTypeReferenceSupported { get; }
        public bool IsStudentAddressSupported { get; }
        public bool IsStudentNameReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolYear":
                    return IsSchoolYearSupported;
                case "SchoolYearTypeReference":
                    return IsSchoolYearTypeReferenceSupported;
                case "StudentAddress":
                    return IsStudentAddressSupported;
                case "StudentNameReference":
                    return IsStudentNameReferenceSupported;
                case "StudentFirstName":
                    // Identifying properties are always supported
                    return true;
                case "StudentLastSurname":
                    // Identifying properties are always supported
                    return true;
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
        IStudent Student { get; set; }
        
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
                case "City":
                    // Identifying properties are always supported
                    return true;
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
        
        string SchoolName { get; set; }
        
        string StudentFirstName { get; set; }
        
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
            bool isSchoolReferenceSupported,
            bool isStudentReferenceSupported
            )
        {
            IsSchoolReferenceSupported = isSchoolReferenceSupported;
            IsStudentReferenceSupported = isStudentReferenceSupported;
        }

        public bool IsSchoolReferenceSupported { get; }
        public bool IsStudentReferenceSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolReference":
                    return IsSchoolReferenceSupported;
                case "StudentReference":
                    return IsStudentReferenceSupported;
                case "SchoolName":
                    // Identifying properties are always supported
                    return true;
                case "StudentFirstName":
                    // Identifying properties are always supported
                    return true;
                case "StudentLastSurname":
                    // Identifying properties are always supported
                    return true;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }
}

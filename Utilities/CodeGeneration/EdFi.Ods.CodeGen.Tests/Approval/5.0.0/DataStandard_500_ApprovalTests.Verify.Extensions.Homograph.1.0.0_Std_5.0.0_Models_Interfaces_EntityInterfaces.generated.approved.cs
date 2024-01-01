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
    /// Defines available properties and methods for the abstraction of the Contact model.
    /// </summary>
    public interface IContact : ISynchronizable, IMappable, IHasIdentifier, IGetByExample
    {
        // Primary Key properties
        
        string ContactFirstName { get; set; }
        
        string ContactLastSurname { get; set; }

        // Non-PK properties

        // One-to-one relationships

        // Lists
        ICollection<IContactAddress> ContactAddresses { get; set; }
        ICollection<IContactStudentSchoolAssociation> ContactStudentSchoolAssociations { get; set; }

        // Resource reference data
        Guid? ContactNameResourceId { get; set; }
        string ContactNameDiscriminator { get; set; }
    }

    /// <summary>
    /// Defines a mapping contract appropriate for a particular context when data is either being mapped or synchronized
    /// between entities/resources during API request processing.
    /// </summary>
    public class ContactMappingContract : IMappingContract
    {
        public ContactMappingContract(
            bool isContactAddressesSupported,
            bool isContactStudentSchoolAssociationsSupported,
            Func<IContactAddress, bool> isContactAddressIncluded,
            Func<IContactStudentSchoolAssociation, bool> isContactStudentSchoolAssociationIncluded
            )
        {
            IsContactAddressesSupported = isContactAddressesSupported;
            IsContactStudentSchoolAssociationsSupported = isContactStudentSchoolAssociationsSupported;
            IsContactAddressIncluded = isContactAddressIncluded;
            IsContactStudentSchoolAssociationIncluded = isContactStudentSchoolAssociationIncluded;
        }

        public bool IsContactAddressesSupported { get; }
        public bool IsContactStudentSchoolAssociationsSupported { get; }
        public Func<IContactAddress, bool> IsContactAddressIncluded { get; }
        public Func<IContactStudentSchoolAssociation, bool> IsContactStudentSchoolAssociationIncluded { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "ContactAddresses":
                    return IsContactAddressesSupported;
                case "ContactStudentSchoolAssociations":
                    return IsContactStudentSchoolAssociationsSupported;
                default:
                    throw new Exception($"Unknown member '{memberName}'.");
            }
        }

    }

    /// <summary>
    /// Defines available properties and methods for the abstraction of the ContactAddress model.
    /// </summary>
    public interface IContactAddress : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContact Contact { get; set; }
        
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
    public class ContactAddressMappingContract : IMappingContract
    {
        public ContactAddressMappingContract(
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
    /// Defines available properties and methods for the abstraction of the ContactStudentSchoolAssociation model.
    /// </summary>
    public interface IContactStudentSchoolAssociation : ISynchronizable, IMappable, IGetByExample
    {
        // Primary Key properties
        IContact Contact { get; set; }
        
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
    public class ContactStudentSchoolAssociationMappingContract : IMappingContract
    {
        public ContactStudentSchoolAssociationMappingContract(
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
            bool isStudentAddressSupported
            )
        {
            IsSchoolYearSupported = isSchoolYearSupported;
            IsStudentAddressSupported = isStudentAddressSupported;
        }

        public bool IsSchoolYearSupported { get; }
        public bool IsStudentAddressSupported { get; }

        bool IMappingContract.IsMemberSupported(string memberName)
        {
            switch (memberName)
            {
                case "SchoolYear":
                    return IsSchoolYearSupported;
                case "StudentAddress":
                    return IsStudentAddressSupported;
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

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;

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
}

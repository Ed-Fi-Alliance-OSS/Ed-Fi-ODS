using System;


namespace EdFi.Ods.Entities.Common.Records.Homograph
{ 

    /// <summary>
    /// Interface for the homograph.Name table of the Name aggregate in the Ods Database.
    /// </summary>
    public interface INameRecord
    {     
        // Properties for all columns in physical table
        string FirstName { get; set; }
        Guid Id { get; set; }
        string LastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.Parent table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string ParentFirstName { get; set; }
        string ParentLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.ParentAddress table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentAddressRecord
    {     
        // Properties for all columns in physical table
        string City { get; set; }
        string ParentFirstName { get; set; }
        string ParentLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.ParentStudentSchoolAssociation table of the Parent aggregate in the Ods Database.
    /// </summary>
    public interface IParentStudentSchoolAssociationRecord
    {     
        // Properties for all columns in physical table
        string ParentFirstName { get; set; }
        string ParentLastSurname { get; set; }
        string SchoolName { get; set; }
        string StudentFirstName { get; set; }
        string StudentLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.School table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string SchoolName { get; set; }
        string SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.SchoolAddress table of the School aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolAddressRecord
    {     
        // Properties for all columns in physical table
        string City { get; set; }
        string SchoolName { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.SchoolYearType table of the SchoolYearType aggregate in the Ods Database.
    /// </summary>
    public interface ISchoolYearTypeRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string SchoolYear { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.Staff table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string StaffFirstName { get; set; }
        string StaffLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.StaffAddress table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffAddressRecord
    {     
        // Properties for all columns in physical table
        string City { get; set; }
        string StaffFirstName { get; set; }
        string StaffLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.StaffStudentSchoolAssociation table of the Staff aggregate in the Ods Database.
    /// </summary>
    public interface IStaffStudentSchoolAssociationRecord
    {     
        // Properties for all columns in physical table
        string SchoolName { get; set; }
        string StaffFirstName { get; set; }
        string StaffLastSurname { get; set; }
        string StudentFirstName { get; set; }
        string StudentLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.Student table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string SchoolYear { get; set; }
        string StudentFirstName { get; set; }
        string StudentLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.StudentAddress table of the Student aggregate in the Ods Database.
    /// </summary>
    public interface IStudentAddressRecord
    {     
        // Properties for all columns in physical table
        string City { get; set; }
        string StudentFirstName { get; set; }
        string StudentLastSurname { get; set; }
    }

    /// <summary>
    /// Interface for the homograph.StudentSchoolAssociation table of the StudentSchoolAssociation aggregate in the Ods Database.
    /// </summary>
    public interface IStudentSchoolAssociationRecord
    {     
        // Properties for all columns in physical table
        Guid Id { get; set; }
        string SchoolName { get; set; }
        string StudentFirstName { get; set; }
        string StudentLastSurname { get; set; }
    }
}


using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common;

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
}

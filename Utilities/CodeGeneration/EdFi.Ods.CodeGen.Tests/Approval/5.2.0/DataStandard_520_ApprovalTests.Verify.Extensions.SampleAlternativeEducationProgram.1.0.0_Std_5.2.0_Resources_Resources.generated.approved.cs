using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using EdFi.Common.Extensions;
using EdFi.Ods.Api.Extensions;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Serialization;
using EdFi.Ods.Api.Attributes;
using EdFi.Ods.Common.Adapters;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Validation;
using EdFi.Ods.Entities.Common.EdFi;
using EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram;
using Newtonsoft.Json;
using FluentValidation.Results;
using MessagePack;
using KeyAttribute = MessagePack.KeyAttribute;

// Aggregate: AlternativeEducationEligibilityReasonDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.AlternativeEducationEligibilityReasonDescriptor.SampleAlternativeEducationProgram
{
    /// <summary>
    /// A class which represents the samplealternativeeducationprogram.AlternativeEducationEligibilityReasonDescriptor table of the AlternativeEducationEligibilityReasonDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptor : Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("samplealternativeeducationprogram", "AlternativeEducationEligibilityReasonDescriptor");

        // Fluent validator instance (threadsafe)
        private static AlternativeEducationEligibilityReasonDescriptorPutPostRequestValidator _validator = new AlternativeEducationEligibilityReasonDescriptorPutPostRequestValidator();
        
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the AlternativeEducationEligibilityReasonDescriptor resource.
        /// </summary>
        [DataMember(Name="id")]
        [Key(0)]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [JsonIgnore, IgnoreMember]
        public int AlternativeEducationEligibilityReasonDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return AlternativeEducationEligibilityReasonDescriptorId; }
            set { AlternativeEducationEligibilityReasonDescriptorId = value; }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Equality
        // -------------------------------------------------------------

        /// <summary>
        /// Determines equality based on the natural key properties of the resource.
        /// </summary>
        /// <returns>
        /// A boolean value indicating equality result of the compared resources.
        /// </returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor).AlternativeEducationEligibilityReasonDescriptorId.Equals(compareTo.AlternativeEducationEligibilityReasonDescriptorId))
                return false;


            return true;
        }

        /// <summary>
        /// Builds the hash code based on the unique identifying values.
        /// </summary>
        /// <returns>
        /// A hash code for the resource.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();

            //Derived Property
            hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor).AlternativeEducationEligibilityReasonDescriptorId);

            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// A code or abbreviation that is used to refer to the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(50, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="codeValue")]
        [Key(1)]            
        public string CodeValue { get; set; }

        /// <summary>
        /// The description of the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [NonDefaultStringLength(1024, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="description")]
        [Key(2)]            
        public string Description { get; set; }

        /// <summary>
        /// The beginning date of the period when the descriptor is in effect. If omitted, the default is immediate effectiveness.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveBeginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        [Key(3)]            
        public DateTime? EffectiveBeginDate { get; set; }

        /// <summary>
        /// The end date of the period when the descriptor is in effect.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="effectiveEndDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        [Key(4)]            
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// A globally unique namespace that identifies this descriptor set. Author is strongly encouraged to use the Universal Resource Identifier (http, ftp, file, etc.) for the source of the descriptor definition. Best practice is for this source to be the descriptor file itself, so that it can be machine-readable and be fetched in real-time, if necessary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(255, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="namespace")]
        [Key(5)]            
        public string Namespace { get; set; }

        /// <summary>
        /// A shortened description for the descriptor.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(75, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="shortDescription")]
        [Key(6)]            
        public string ShortDescription { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //              Inherited One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Inherited Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        [Key(7)]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
        [Key(8)]
        public virtual DateTime LastModifiedDate { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptorMapper.SynchronizeTo(this, (Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleAlternativeEducationProgram.AlternativeEducationEligibilityReasonDescriptorMapper.MapTo(this, (Entities.Common.SampleAlternativeEducationProgram.IAlternativeEducationEligibilityReasonDescriptor)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class AlternativeEducationEligibilityReasonDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<AlternativeEducationEligibilityReasonDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<AlternativeEducationEligibilityReasonDescriptor> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    result.Errors.Add(failure);
                }

                return false;
            }

            return true;
        }
    }
    // -----------------------------------------------------------------

}
// Aggregate: StudentAlternativeEducationProgramAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentAlternativeEducationProgramAssociation.SampleAlternativeEducationProgram
{
    /// <summary>
    /// Represents a reference to the StudentAlternativeEducationProgramAssociation resource.
    /// </summary>
    [DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationReference : IResourceReference
    {
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        [Key(0)]
        public DateTime BeginDate { get; set; }

        [DataMember(Name="educationOrganizationId")]
        [Key(1)]
        public long EducationOrganizationId { get; set; }

        [DataMember(Name="programEducationOrganizationId")]
        [Key(2)]
        public long ProgramEducationOrganizationId { get; set; }

        [DataMember(Name="programName")]
        [Key(3)]
        public string ProgramName { get; set; }

        [DataMember(Name="programTypeDescriptor")][DescriptorExists("ProgramTypeDescriptor")]
        [IgnoreMember]
        public string ProgramTypeDescriptor { get; set; }

        [Key(4)][JsonIgnore]
        public int ProgramTypeDescriptorId
        {
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ProgramTypeDescriptor", ProgramTypeDescriptor); }
            set { ProgramTypeDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ProgramTypeDescriptor", value); }
        }

        [DataMember(Name="studentUniqueId")]
        [Key(5)]
        public string StudentUniqueId 
        {
            get => _studentUniqueId;
            set
            {
                _studentUniqueId = value;
                GeneratedArtifactStaticDependencies.UsiLookupsByUniqueIdContextProvider.Get().AddLookup("Student", value);
            }
        }
        private string _studentUniqueId;

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        [Key(6)]
        public Guid ResourceId { get; set; }


        [JsonIgnore]
        [Key(7)]
        public Link _link;

        [IgnoreMember]
        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (IsReferenceFullyDefined())
                        _link = CreateLink();
                }

                return _link;
            }
        }

        /// <summary>
        /// Indicates whether the reference has been fully defined (all key values are currently assigned non-default values).
        /// </summary>
        /// <returns><b>true</b> if the reference's properties are all set to non-default values; otherwise <b>false</b>.</returns>
        public bool IsReferenceFullyDefined()
        {
            return BeginDate != default(DateTime) && EducationOrganizationId != default(long) && ProgramEducationOrganizationId != default(long) && ProgramName != default(string) && ProgramTypeDescriptor != default(string) && StudentUniqueId != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (BeginDate == default)
            {
                yield return "BeginDate";
            }

            if (EducationOrganizationId == default)
            {
                yield return "EducationOrganizationId";
            }

            if (ProgramEducationOrganizationId == default)
            {
                yield return "ProgramEducationOrganizationId";
            }

            if (ProgramName == default)
            {
                yield return "ProgramName";
            }

            if (ProgramTypeDescriptor == default)
            {
                yield return "ProgramTypeDescriptor";
            }

            if (StudentUniqueId == default)
            {
                yield return "StudentUniqueId";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentAlternativeEducationProgramAssociation",
                Href = $"/sample-alternative-education-program/studentAlternativeEducationProgramAssociations/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociation table of the StudentAlternativeEducationProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociation : Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation, Entities.Common.EdFi.IGeneralStudentProgramAssociation, IHasETag, IDateVersionedEntity, IValidatableObject
    {
        private static FullName _fullName = new FullName("samplealternativeeducationprogram", "StudentAlternativeEducationProgramAssociation");

        // Fluent validator instance (threadsafe)
        private static StudentAlternativeEducationProgramAssociationPutPostRequestValidator _validator = new StudentAlternativeEducationProgramAssociationPutPostRequestValidator();
        
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public StudentAlternativeEducationProgramAssociation()
        {
            StudentAlternativeEducationProgramAssociationMeetingTimes = new List<StudentAlternativeEducationProgramAssociationMeetingTime>();

            // Inherited lists
            GeneralStudentProgramAssociationProgramParticipationStatuses = new List<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>();
        }
        
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the StudentAlternativeEducationProgramAssociation resource.
        /// </summary>
        [DataMember(Name="id")]
        [Key(0)]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _educationOrganizationReferenceExplicitlyAssigned;
        private EducationOrganization.EdFi.EducationOrganizationReference _educationOrganizationReference;
        private EducationOrganization.EdFi.EducationOrganizationReference ImplicitEducationOrganizationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_educationOrganizationReference == null && !_educationOrganizationReferenceExplicitlyAssigned)
                    _educationOrganizationReference = new EducationOrganization.EdFi.EducationOrganizationReference();

                return _educationOrganizationReference;
            }
        }

        [DataMember(Name="educationOrganizationReference")]
        [Key(1)]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public EducationOrganization.EdFi.EducationOrganizationReference EducationOrganizationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitEducationOrganizationReference != null
                    && (_educationOrganizationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitEducationOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitEducationOrganizationReference;

                return null;
            }
            set
            {
                _educationOrganizationReferenceExplicitlyAssigned = true;
                _educationOrganizationReference = value;
            }
        }
        private bool _programReferenceExplicitlyAssigned;
        private Program.EdFi.ProgramReference _programReference;
        private Program.EdFi.ProgramReference ImplicitProgramReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_programReference == null && !_programReferenceExplicitlyAssigned)
                    _programReference = new Program.EdFi.ProgramReference();

                return _programReference;
            }
        }

        [DataMember(Name="programReference")]
        [Key(2)]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public Program.EdFi.ProgramReference ProgramReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitProgramReference != null
                    && (_programReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference;

                return null;
            }
            set
            {
                _programReferenceExplicitlyAssigned = true;
                _programReference = value;
            }
        }
        private bool _studentReferenceExplicitlyAssigned;
        private Student.EdFi.StudentReference _studentReference;
        private Student.EdFi.StudentReference ImplicitStudentReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentReference == null && !_studentReferenceExplicitlyAssigned)
                    _studentReference = new Student.EdFi.StudentReference();

                return _studentReference;
            }
        }

        [DataMember(Name="studentReference")]
        [Key(3)]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public Student.EdFi.StudentReference StudentReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentReference != null
                    && (_studentReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentReference.IsReferenceFullyDefined()))
                    return ImplicitStudentReference;

                return null;
            }
            set
            {
                _studentReferenceExplicitlyAssigned = true;
                _studentReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The earliest date the student is involved with the program. Typically, this is the date the student becomes eligible for the program.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        [Key(4)]            
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        long Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationId
        {
            get
            {
                if (ImplicitEducationOrganizationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitEducationOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitEducationOrganizationReference.EducationOrganizationId;

                return default(long);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // EducationOrganization
                _educationOrganizationReferenceExplicitlyAssigned = false;
                ImplicitEducationOrganizationReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        long Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramEducationOrganizationId
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.EducationOrganizationId;

                return default(long);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Program
                _programReferenceExplicitlyAssigned = false;
                ImplicitProgramReference.EducationOrganizationId = value;
            }
        }

        /// <summary>
        /// The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramName
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.ProgramName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Program
                _programReferenceExplicitlyAssigned = false;
                ImplicitProgramReference.ProgramName = value;
            }
        }

        /// <summary>
        /// The type of program.
        /// </summary>

        // IS in a reference (StudentAlternativeEducationProgramAssociation.ProgramTypeDescriptorId), IS a lookup column 
        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramTypeDescriptor
        {
            get
            {
                if (ImplicitProgramReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitProgramReference.IsReferenceFullyDefined()))
                    return ImplicitProgramReference.ProgramTypeDescriptor;

                return null;
            }
            set
            {
                ImplicitProgramReference.ProgramTypeDescriptor = value;
            }
        }

        /// <summary>
        /// A unique alphanumeric code assigned to a student.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.StudentUniqueId
        {
            get
            {
                if (ImplicitStudentReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentReference.IsReferenceFullyDefined()))
                    return ImplicitStudentReference.StudentUniqueId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Student
                _studentReferenceExplicitlyAssigned = false;
                ImplicitStudentReference.StudentUniqueId = value;
                GeneratedArtifactStaticDependencies.UsiLookupsByUniqueIdContextProvider.Get().AddLookup("Student", value);                
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Equality
        // -------------------------------------------------------------

        /// <summary>
        /// Determines equality based on the natural key properties of the resource.
        /// </summary>
        /// <returns>
        /// A boolean value indicating equality result of the compared resources.
        /// </returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if (!(this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).BeginDate.Equals(compareTo.BeginDate))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).EducationOrganizationId.Equals(compareTo.EducationOrganizationId))
                return false;


            // Referenced Property
            if (!(this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).ProgramEducationOrganizationId.Equals(compareTo.ProgramEducationOrganizationId))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).ProgramName, compareTo.ProgramName))
                return false;


            // Unified Type Property
            if (!StringComparer.OrdinalIgnoreCase.Equals((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).ProgramTypeDescriptor, compareTo.ProgramTypeDescriptor))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).StudentUniqueId, compareTo.StudentUniqueId))
                return false;


            return true;
        }

        /// <summary>
        /// Builds the hash code based on the unique identifying values.
        /// </summary>
        /// <returns>
        /// A hash code for the resource.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();

            // Standard Property
                hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).BeginDate);


            //Referenced Property
            hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).EducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).ProgramEducationOrganizationId);

            //Referenced Property
            hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).ProgramName);

            //Unified Type Property
            hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).ProgramTypeDescriptor);


            //Referenced Property
            hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation).StudentUniqueId);
            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The month, day, and year on which the student exited the program or stopped receiving services.  Note: Date interpretation may vary. Ed-Fi recommends inclusive dates, but states may define dates as inclusive or exclusive. For calculations, align with local guidelines.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        [Key(5)]            
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The reason the student left the program within a school or district.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [NonDefaultStringLength(306, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="reasonExitedDescriptor")][DescriptorExists("ReasonExitedDescriptor")]
        [IgnoreMember]            
        public string ReasonExitedDescriptor { get; set; }

        [Key(6)][JsonIgnore]
        public int ReasonExitedDescriptorId
        {
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("ReasonExitedDescriptor", ReasonExitedDescriptor); }
            set { ReasonExitedDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("ReasonExitedDescriptor", value); }
        }

        /// <summary>
        /// Indicates whether the student received services during the summer session or between sessions.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="servedOutsideOfRegularSession")]
        [Key(7)]            
        public bool? ServedOutsideOfRegularSession { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The reason the student is eligible for the program.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(306, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="alternativeEducationEligibilityReasonDescriptor")][DescriptorExists("AlternativeEducationEligibilityReasonDescriptor")]
        [IgnoreMember]
        public string AlternativeEducationEligibilityReasonDescriptor { get; set; }

        [Key(8)][JsonIgnore]
        public int AlternativeEducationEligibilityReasonDescriptorId
        { 
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("AlternativeEducationEligibilityReasonDescriptor", AlternativeEducationEligibilityReasonDescriptor); }
            set { AlternativeEducationEligibilityReasonDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("AlternativeEducationEligibilityReasonDescriptor", value); } 
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //              Inherited One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Inherited Collections
        // -------------------------------------------------------------
        private ICollection<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus> _generalStudentProgramAssociationProgramParticipationStatuses;
        private ICollection<Entities.Common.EdFi.IGeneralStudentProgramAssociationProgramParticipationStatus> _generalStudentProgramAssociationProgramParticipationStatusesCovariant;

        [NoDuplicateMembers]
        [DataMember(Name="programParticipationStatuses")]
        [Key(9)]
        public ICollection<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus> GeneralStudentProgramAssociationProgramParticipationStatuses
        {
            get { return _generalStudentProgramAssociationProgramParticipationStatuses; }
            set
            {
                _generalStudentProgramAssociationProgramParticipationStatuses = value;
                _generalStudentProgramAssociationProgramParticipationStatusesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IGeneralStudentProgramAssociationProgramParticipationStatus, GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IGeneralStudentProgramAssociationProgramParticipationStatus> Entities.Common.EdFi.IGeneralStudentProgramAssociation.GeneralStudentProgramAssociationProgramParticipationStatuses
        {
            get { return _generalStudentProgramAssociationProgramParticipationStatusesCovariant; }
            set { GeneralStudentProgramAssociationProgramParticipationStatuses = new List<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>(value.Cast<GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatus>()); }
        }
        // -------------------------------------------------------------


        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<StudentAlternativeEducationProgramAssociationMeetingTime> _studentAlternativeEducationProgramAssociationMeetingTimes;
        private ICollection<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime> _studentAlternativeEducationProgramAssociationMeetingTimesCovariant;

        [NoDuplicateMembers]
        [DataMember(Name="meetingTimes")]
        [Key(10)]
        public ICollection<StudentAlternativeEducationProgramAssociationMeetingTime> StudentAlternativeEducationProgramAssociationMeetingTimes
        {
            get { return _studentAlternativeEducationProgramAssociationMeetingTimes; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StudentAlternativeEducationProgramAssociationMeetingTime>(value,
                    (s, e) => ((Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime)e.Item).StudentAlternativeEducationProgramAssociation = this);
                _studentAlternativeEducationProgramAssociationMeetingTimes = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime, StudentAlternativeEducationProgramAssociationMeetingTime>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime)e.Item).StudentAlternativeEducationProgramAssociation = this;
                _studentAlternativeEducationProgramAssociationMeetingTimesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime> Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation.StudentAlternativeEducationProgramAssociationMeetingTimes
        {
            get { return _studentAlternativeEducationProgramAssociationMeetingTimesCovariant; }
            set { StudentAlternativeEducationProgramAssociationMeetingTimes = new List<StudentAlternativeEducationProgramAssociationMeetingTime>(value.Cast<StudentAlternativeEducationProgramAssociationMeetingTime>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        [Key(11)]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
        [Key(12)]
        public virtual DateTime LastModifiedDate { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect collection item parent references on deserialization
            if (_generalStudentProgramAssociationProgramParticipationStatuses != null) foreach (var item in _generalStudentProgramAssociationProgramParticipationStatuses)
            {
                item.GeneralStudentProgramAssociation = this;
            }

            if (_studentAlternativeEducationProgramAssociationMeetingTimes != null) foreach (var item in _studentAlternativeEducationProgramAssociationMeetingTimes)
            {
                item.StudentAlternativeEducationProgramAssociation = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMapper.SynchronizeTo(this, (Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMapper.MapDerivedTo(this, (Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationResourceId
        {
            get { return null; }
            set { ImplicitEducationOrganizationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.EducationOrganizationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitEducationOrganizationReference.Discriminator = value; }
        }


        Guid? Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramResourceId
        {
            get { return null; }
            set { ImplicitProgramReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.ProgramDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitProgramReference.Discriminator = value; }
        }


        Guid? Entities.Common.EdFi.IGeneralStudentProgramAssociation.StudentResourceId
        {
            get { return null; }
            set { ImplicitStudentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.EdFi.IGeneralStudentProgramAssociation.StudentDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------

        // ==================================
        //            Validation
        // ----------------------------------
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var mappingContractProvider = GeneratedArtifactStaticDependencies.MappingContractProvider;
            var mappingContract = mappingContractProvider.GetMappingContract(_fullName);
            
            var pathBuilder = ValidationHelpers.GetPathBuilder(validationContext);
            
            int originalLength = pathBuilder.Length;

            try
            {
                // Prepare builders for validating members
                int dotLength = pathBuilder.Length;

                // ----------------------
                //  Validate collections
                // ----------------------
                if (GeneralStudentProgramAssociationProgramParticipationStatuses.Any() && mappingContract?.IsMemberSupported("GeneralStudentProgramAssociationProgramParticipationStatuses") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("GeneralStudentProgramAssociationProgramParticipationStatuses");
    
                    foreach (var result in ValidationHelpers.ValidateCollection(new ValidationContext(GeneralStudentProgramAssociationProgramParticipationStatuses, validationContext, validationContext.Items.ForCollection("GeneralStudentProgramAssociationProgramParticipationStatuses"))))
                    {
                        yield return result;
                    }
                }

                if (StudentAlternativeEducationProgramAssociationMeetingTimes.Any() && mappingContract?.IsMemberSupported("StudentAlternativeEducationProgramAssociationMeetingTimes") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("StudentAlternativeEducationProgramAssociationMeetingTimes");
    
                    foreach (var result in ValidationHelpers.ValidateCollection(new ValidationContext(StudentAlternativeEducationProgramAssociationMeetingTimes, validationContext, validationContext.Items.ForCollection("StudentAlternativeEducationProgramAssociationMeetingTimes"))))
                    {
                        yield return result;
                    }
                }


                // ---------------------------
                //  Validate embedded objects
                // ---------------------------
            
                // Execute the resource's fluent validator
                var fluentValidationResult = _validator.Validate(this);

                if (!fluentValidationResult.IsValid)
                {
                    foreach (var error in fluentValidationResult.Errors)
                    {
                        yield return new System.ComponentModel.DataAnnotations.ValidationResult(error.ErrorMessage, new[] { error.PropertyName });
                    }
                }
            }
            finally
            {
                // Restore original length
                pathBuilder.Length = originalLength;
            }
            // ----------------------------------
        }
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentAlternativeEducationProgramAssociation>
    {
        private static readonly FullName _fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociation = new FullName("samplealternativeeducationprogram", "StudentAlternativeEducationProgramAssociation");

        // Declare collection item validators
        private StudentAlternativeEducationProgramAssociationMeetingTimePutPostRequestValidator _studentAlternativeEducationProgramAssociationMeetingTimesValidator = new ();
        private GeneralStudentProgramAssociation.EdFi.GeneralStudentProgramAssociationProgramParticipationStatusPutPostRequestValidator _generalStudentProgramAssociationProgramParticipationStatusesValidator = new ();

        protected override bool PreValidate(FluentValidation.ValidationContext<StudentAlternativeEducationProgramAssociation> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // Profile-based collection item filter validation
            string profileName = null;

            // Get the current mapping contract
            var mappingContract = (global::EdFi.Ods.Entities.Common.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMappingContract) GeneratedArtifactStaticDependencies.MappingContractProvider
                .GetMappingContract(_fullName_samplealternativeeducationprogram_StudentAlternativeEducationProgramAssociation);

            if (mappingContract != null)
            {
                if (mappingContract.IsStudentAlternativeEducationProgramAssociationMeetingTimeIncluded != null)
                {
                    var hasInvalidStudentAlternativeEducationProgramAssociationMeetingTimesItems = instance.StudentAlternativeEducationProgramAssociationMeetingTimes.Any(x => !mappingContract.IsStudentAlternativeEducationProgramAssociationMeetingTimeIncluded(x));
        
                    if (hasInvalidStudentAlternativeEducationProgramAssociationMeetingTimesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StudentAlternativeEducationProgramAssociationMeetingTimes", $"A supplied 'StudentAlternativeEducationProgramAssociationMeetingTime' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded != null)
                {
                    var hasInvalidGeneralStudentProgramAssociationProgramParticipationStatusesItems = instance.GeneralStudentProgramAssociationProgramParticipationStatuses.Any(x => !mappingContract.IsGeneralStudentProgramAssociationProgramParticipationStatusIncluded(x));
        
                    if (hasInvalidGeneralStudentProgramAssociationProgramParticipationStatusesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("GeneralStudentProgramAssociationProgramParticipationStatuses", $"A supplied 'GeneralStudentProgramAssociationProgramParticipationStatus' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

            }

            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    result.Errors.Add(failure);
                }

                return false;
            }

            return true;
        }
    }
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the samplealternativeeducationprogram.StudentAlternativeEducationProgramAssociationMeetingTime table of the StudentAlternativeEducationProgramAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationMeetingTime : Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime
    {
        private static FullName _fullName = new FullName("samplealternativeeducationprogram", "StudentAlternativeEducationProgramAssociationMeetingTime");

        // Fluent validator instance (threadsafe)
        private static StudentAlternativeEducationProgramAssociationMeetingTimePutPostRequestValidator _validator = new StudentAlternativeEducationProgramAssociationMeetingTimePutPostRequestValidator();
        
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation _studentAlternativeEducationProgramAssociation;

        [IgnoreDataMember]
        Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime.StudentAlternativeEducationProgramAssociation
        {
            get { return _studentAlternativeEducationProgramAssociation; }
            set { SetStudentAlternativeEducationProgramAssociation(value); }
        }

        [IgnoreMember]
        public Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation StudentAlternativeEducationProgramAssociation
        {
            set { SetStudentAlternativeEducationProgramAssociation(value); }
        }

        private void SetStudentAlternativeEducationProgramAssociation(Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociation value)
        {
            _studentAlternativeEducationProgramAssociation = value;
        }

        /// <summary>
        /// An indication of the time of day the meeting time ends.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [DataMember(Name="endTime")][JsonConverter(typeof(UtcTimeConverter))]
        [Key(0)]            
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// An indication of the time of day the meeting time begins.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [DataMember(Name="startTime")][JsonConverter(typeof(UtcTimeConverter))]
        [Key(1)]            
        public TimeSpan StartTime { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Equality
        // -------------------------------------------------------------

        /// <summary>
        /// Determines equality based on the natural key properties of the resource.
        /// </summary>
        /// <returns>
        /// A boolean value indicating equality result of the compared resources.
        /// </returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentAlternativeEducationProgramAssociation == null || !_studentAlternativeEducationProgramAssociation.Equals(compareTo.StudentAlternativeEducationProgramAssociation))
                return false;


            // Standard Property
            if (!(this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime).EndTime.Equals(compareTo.EndTime))
                return false;


            // Standard Property
            if (!(this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime).StartTime.Equals(compareTo.StartTime))
                return false;


            return true;
        }

        /// <summary>
        /// Builds the hash code based on the unique identifying values.
        /// </summary>
        /// <returns>
        /// A hash code for the resource.
        /// </returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            //Parent Property
            if (_studentAlternativeEducationProgramAssociation != null)
                hash.Add(_studentAlternativeEducationProgramAssociation);

            // Standard Property
                hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime).EndTime);


            // Standard Property
                hash.Add((this as Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime).StartTime);

            return hash.ToHashCode();
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //              Inherited One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Inherited Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTimeMapper.SynchronizeTo(this, (Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleAlternativeEducationProgram.StudentAlternativeEducationProgramAssociationMeetingTimeMapper.MapTo(this, (Entities.Common.SampleAlternativeEducationProgram.IStudentAlternativeEducationProgramAssociationMeetingTime)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentAlternativeEducationProgramAssociationMeetingTimePutPostRequestValidator : FluentValidation.AbstractValidator<StudentAlternativeEducationProgramAssociationMeetingTime>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentAlternativeEducationProgramAssociationMeetingTime> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            if (failures.Any())
            {
                foreach (var failure in failures)
                {
                    result.Errors.Add(failure);
                }

                return false;
            }

            return true;
        }
    }
    // -----------------------------------------------------------------

}

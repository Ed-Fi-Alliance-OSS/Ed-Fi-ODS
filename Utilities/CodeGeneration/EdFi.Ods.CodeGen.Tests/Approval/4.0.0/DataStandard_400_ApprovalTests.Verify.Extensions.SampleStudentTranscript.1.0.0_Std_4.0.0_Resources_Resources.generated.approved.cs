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
using EdFi.Ods.Entities.Common.SampleStudentTranscript;
using Newtonsoft.Json;
using FluentValidation.Results;
using MessagePack;
using KeyAttribute = MessagePack.KeyAttribute;

// Aggregate: InstitutionControlDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.InstitutionControlDescriptor.SampleStudentTranscript
{
    /// <summary>
    /// A class which represents the samplestudenttranscript.InstitutionControlDescriptor table of the InstitutionControlDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class InstitutionControlDescriptor : Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "InstitutionControlDescriptor");

        // Fluent validator instance (threadsafe)
        private static InstitutionControlDescriptorPutPostRequestValidator _validator = new InstitutionControlDescriptorPutPostRequestValidator();
        
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
        /// The unique identifier for the InstitutionControlDescriptor resource.
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
        public int InstitutionControlDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return InstitutionControlDescriptorId; }
            set { InstitutionControlDescriptorId = value; }
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor).InstitutionControlDescriptorId.Equals(compareTo.InstitutionControlDescriptorId))
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
            hash.Add((this as Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor).InstitutionControlDescriptorId);

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
            return Entities.Common.SampleStudentTranscript.InstitutionControlDescriptorMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.InstitutionControlDescriptorMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.IInstitutionControlDescriptor)target, null);
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
    public class InstitutionControlDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<InstitutionControlDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<InstitutionControlDescriptor> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: InstitutionLevelDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.InstitutionLevelDescriptor.SampleStudentTranscript
{
    /// <summary>
    /// A class which represents the samplestudenttranscript.InstitutionLevelDescriptor table of the InstitutionLevelDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class InstitutionLevelDescriptor : Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "InstitutionLevelDescriptor");

        // Fluent validator instance (threadsafe)
        private static InstitutionLevelDescriptorPutPostRequestValidator _validator = new InstitutionLevelDescriptorPutPostRequestValidator();
        
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
        /// The unique identifier for the InstitutionLevelDescriptor resource.
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
        public int InstitutionLevelDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return InstitutionLevelDescriptorId; }
            set { InstitutionLevelDescriptorId = value; }
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor).InstitutionLevelDescriptorId.Equals(compareTo.InstitutionLevelDescriptorId))
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
            hash.Add((this as Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor).InstitutionLevelDescriptorId);

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
            return Entities.Common.SampleStudentTranscript.InstitutionLevelDescriptorMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.InstitutionLevelDescriptorMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.IInstitutionLevelDescriptor)target, null);
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
    public class InstitutionLevelDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<InstitutionLevelDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<InstitutionLevelDescriptor> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: PostSecondaryOrganization

namespace EdFi.Ods.Api.Common.Models.Resources.PostSecondaryOrganization.SampleStudentTranscript
{
    /// <summary>
    /// Represents a reference to the PostSecondaryOrganization resource.
    /// </summary>
    [DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class PostSecondaryOrganizationReference : IResourceReference
    {
        [DataMember(Name="nameOfInstitution")]
        [Key(0)]
        public string NameOfInstitution { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        [Key(1)]
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        [Key(2)]
        public string Discriminator { get; set; }


        [JsonIgnore]
        [Key(3)]
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
            return NameOfInstitution != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (NameOfInstitution == default)
            {
                yield return "NameOfInstitution";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "PostSecondaryOrganization",
                Href = $"/sample-student-transcript/postSecondaryOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the samplestudenttranscript.PostSecondaryOrganization table of the PostSecondaryOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    [NoUnsuppliedRequiredMembersWithMeaningfulDefaults]
    public class PostSecondaryOrganization : Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization, IHasETag, IDateVersionedEntity, IHasRequiredMembersWithMeaningfulDefaultValues
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "PostSecondaryOrganization");

        // Fluent validator instance (threadsafe)
        private static PostSecondaryOrganizationPutPostRequestValidator _validator = new PostSecondaryOrganizationPutPostRequestValidator();
        
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
        /// The unique identifier for the PostSecondaryOrganization resource.
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
        /// The name of the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(75, MinimumLength=1, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="nameOfInstitution")]
        [Key(1)]            
        public string NameOfInstitution { get; set; }
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization).NameOfInstitution, compareTo.NameOfInstitution))
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
                hash.Add((this as Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization).NameOfInstitution);

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
        
        private bool _acceptanceIndicatorExplicitlyAssigned = false;
        private bool _acceptanceIndicator;

        /// <summary>
        /// An indication of acceptance.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="acceptanceIndicator")]
        [Key(2)]
        public bool AcceptanceIndicator 
        { 
            get => _acceptanceIndicator;
            set 
            { 
                _acceptanceIndicator = value;
                _acceptanceIndicatorExplicitlyAssigned = true; 
            }
        }


        /// <summary>
        /// The type of control of the institution (i.e., public or private).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(306, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="institutionControlDescriptor")][DescriptorExists("InstitutionControlDescriptor")]
        [IgnoreMember]
        public string InstitutionControlDescriptor { get; set; }

        [Key(3)][JsonIgnore]
        public int InstitutionControlDescriptorId
        { 
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("InstitutionControlDescriptor", InstitutionControlDescriptor); }
            set { InstitutionControlDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("InstitutionControlDescriptor", value); } 
        }

        /// <summary>
        /// The level of the institution.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(306, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="institutionLevelDescriptor")][DescriptorExists("InstitutionLevelDescriptor")]
        [IgnoreMember]
        public string InstitutionLevelDescriptor { get; set; }

        [Key(4)][JsonIgnore]
        public int InstitutionLevelDescriptorId
        { 
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("InstitutionLevelDescriptor", InstitutionLevelDescriptor); }
            set { InstitutionLevelDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("InstitutionLevelDescriptor", value); } 
        }
        // -------------------------------------------------------------

        IEnumerable<string> IHasRequiredMembersWithMeaningfulDefaultValues.GetUnassignedMemberNames()
        {
            if (!_acceptanceIndicatorExplicitlyAssigned)
            {
                yield return "AcceptanceIndicator";
            }
        }

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
        [Key(5)]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
        [Key(6)]
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
            return Entities.Common.SampleStudentTranscript.PostSecondaryOrganizationMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.PostSecondaryOrganizationMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.IPostSecondaryOrganization)target, null);
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
    public class PostSecondaryOrganizationPutPostRequestValidator : FluentValidation.AbstractValidator<PostSecondaryOrganization>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<PostSecondaryOrganization> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: SpecialEducationGraduationStatusDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.SpecialEducationGraduationStatusDescriptor.SampleStudentTranscript
{
    /// <summary>
    /// A class which represents the samplestudenttranscript.SpecialEducationGraduationStatusDescriptor table of the SpecialEducationGraduationStatusDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class SpecialEducationGraduationStatusDescriptor : Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "SpecialEducationGraduationStatusDescriptor");

        // Fluent validator instance (threadsafe)
        private static SpecialEducationGraduationStatusDescriptorPutPostRequestValidator _validator = new SpecialEducationGraduationStatusDescriptorPutPostRequestValidator();
        
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
        /// The unique identifier for the SpecialEducationGraduationStatusDescriptor resource.
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
        public int SpecialEducationGraduationStatusDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return SpecialEducationGraduationStatusDescriptorId; }
            set { SpecialEducationGraduationStatusDescriptorId = value; }
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor).SpecialEducationGraduationStatusDescriptorId.Equals(compareTo.SpecialEducationGraduationStatusDescriptorId))
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
            hash.Add((this as Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor).SpecialEducationGraduationStatusDescriptorId);

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
            return Entities.Common.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptorMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.SpecialEducationGraduationStatusDescriptorMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.ISpecialEducationGraduationStatusDescriptor)target, null);
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
    public class SpecialEducationGraduationStatusDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<SpecialEducationGraduationStatusDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SpecialEducationGraduationStatusDescriptor> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentAcademicRecord

namespace EdFi.Ods.Api.Common.Models.Resources.StudentAcademicRecord.EdFi.Extensions.SampleStudentTranscript
{
    /// <summary>
    /// A class which represents the samplestudenttranscript.StudentAcademicRecordClassRankingExtension table of the StudentAcademicRecord aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    [Display(Name="SampleStudentTranscript")]
    public class StudentAcademicRecordClassRankingExtension : Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension, IChildEntity
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "StudentAcademicRecordClassRankingExtension");

        // Fluent validator instance (threadsafe)
        private static StudentAcademicRecordClassRankingExtensionPutPostRequestValidator _validator = new StudentAcademicRecordClassRankingExtensionPutPostRequestValidator();
        
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
        private Entities.Common.EdFi.IStudentAcademicRecordClassRanking _studentAcademicRecordClassRanking;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentAcademicRecordClassRanking Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension.StudentAcademicRecordClassRanking
        {
            get { return _studentAcademicRecordClassRanking; }
            set { SetStudentAcademicRecordClassRanking(value); }
        }

        [IgnoreMember]
        public Entities.Common.EdFi.IStudentAcademicRecordClassRanking StudentAcademicRecordClassRanking
        {
            set { SetStudentAcademicRecordClassRanking(value); }
        }

        private void SetStudentAcademicRecordClassRanking(Entities.Common.EdFi.IStudentAcademicRecordClassRanking value)
        {
            _studentAcademicRecordClassRanking = value;
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentAcademicRecordClassRanking == null || !_studentAcademicRecordClassRanking.Equals(compareTo.StudentAcademicRecordClassRanking))
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
            if (_studentAcademicRecordClassRanking != null)
                hash.Add(_studentAcademicRecordClassRanking);
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

        /// <summary>
        /// The graduation status for special education.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(306, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="specialEducationGraduationStatusDescriptor")][DescriptorExists("SpecialEducationGraduationStatusDescriptor")]
        [IgnoreMember]
        public string SpecialEducationGraduationStatusDescriptor { get; set; }

        [Key(0)][JsonIgnore]
        public int SpecialEducationGraduationStatusDescriptorId
        { 
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("SpecialEducationGraduationStatusDescriptor", SpecialEducationGraduationStatusDescriptor); }
            set { SpecialEducationGraduationStatusDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("SpecialEducationGraduationStatusDescriptor", value); } 
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
            return Entities.Common.SampleStudentTranscript.StudentAcademicRecordClassRankingExtensionMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.StudentAcademicRecordClassRankingExtensionMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.IStudentAcademicRecordClassRankingExtension)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------

        void IChildEntity.SetParent(object value)
        {
            StudentAcademicRecordClassRanking = (IStudentAcademicRecordClassRanking)value;
        }
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordClassRankingExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentAcademicRecordClassRankingExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentAcademicRecordClassRankingExtension> context, FluentValidation.Results.ValidationResult result)
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

    /// <summary>
    /// A class which represents the samplestudenttranscript.StudentAcademicRecordExtension table of the StudentAcademicRecord aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    [Display(Name="SampleStudentTranscript")]
    public class StudentAcademicRecordExtension : Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension, IChildEntity
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "StudentAcademicRecordExtension");

        // Fluent validator instance (threadsafe)
        private static StudentAcademicRecordExtensionPutPostRequestValidator _validator = new StudentAcademicRecordExtensionPutPostRequestValidator();
        
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

        private bool _postSecondaryOrganizationReferenceExplicitlyAssigned;
        private PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganizationReference _postSecondaryOrganizationReference;
        private PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganizationReference ImplicitPostSecondaryOrganizationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_postSecondaryOrganizationReference == null && !_postSecondaryOrganizationReferenceExplicitlyAssigned)
                    _postSecondaryOrganizationReference = new PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganizationReference();

                return _postSecondaryOrganizationReference;
            }
        }

        [DataMember(Name="postSecondaryOrganizationReference")]
        [Key(0)]
        [FullyDefinedReference]
        public PostSecondaryOrganization.SampleStudentTranscript.PostSecondaryOrganizationReference PostSecondaryOrganizationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitPostSecondaryOrganizationReference != null
                    && (_postSecondaryOrganizationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitPostSecondaryOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitPostSecondaryOrganizationReference;

                return null;
            }
            set
            {
                _postSecondaryOrganizationReferenceExplicitlyAssigned = true;
                _postSecondaryOrganizationReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.EdFi.IStudentAcademicRecord _studentAcademicRecord;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStudentAcademicRecord Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.StudentAcademicRecord
        {
            get { return _studentAcademicRecord; }
            set { SetStudentAcademicRecord(value); }
        }

        [IgnoreMember]
        public Entities.Common.EdFi.IStudentAcademicRecord StudentAcademicRecord
        {
            set { SetStudentAcademicRecord(value); }
        }

        private void SetStudentAcademicRecord(Entities.Common.EdFi.IStudentAcademicRecord value)
        {
            _studentAcademicRecord = value;
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_studentAcademicRecord == null || !_studentAcademicRecord.Equals(compareTo.StudentAcademicRecord))
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
            if (_studentAcademicRecord != null)
                hash.Add(_studentAcademicRecord);
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

        /// <summary>
        /// The name of the institution.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.NameOfInstitution
        {
            get
            {
                if (ImplicitPostSecondaryOrganizationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitPostSecondaryOrganizationReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitPostSecondaryOrganizationReference.NameOfInstitution;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // PostSecondaryOrganization
                _postSecondaryOrganizationReferenceExplicitlyAssigned = false;
                ImplicitPostSecondaryOrganizationReference.NameOfInstitution = value;
            }
        }

        /// <summary>
        /// The type of submission certification.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [NonDefaultStringLength(306, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText]
        [DataMember(Name="submissionCertificationDescriptor")][DescriptorExists("SubmissionCertificationDescriptor")]
        [IgnoreMember]
        public string SubmissionCertificationDescriptor { get; set; }

        [Key(1)][JsonIgnore]
        public int SubmissionCertificationDescriptorId
        { 
            get { return GeneratedArtifactStaticDependencies.DescriptorResolver.GetDescriptorId("SubmissionCertificationDescriptor", SubmissionCertificationDescriptor); }
            set { SubmissionCertificationDescriptor = GeneratedArtifactStaticDependencies.DescriptorResolver.GetUri("SubmissionCertificationDescriptor", value); } 
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
            return Entities.Common.SampleStudentTranscript.StudentAcademicRecordExtensionMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.StudentAcademicRecordExtensionMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.PostSecondaryOrganizationResourceId
        {
            get { return null; }
            set { ImplicitPostSecondaryOrganizationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.SampleStudentTranscript.IStudentAcademicRecordExtension.PostSecondaryOrganizationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitPostSecondaryOrganizationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------

        void IChildEntity.SetParent(object value)
        {
            StudentAcademicRecord = (IStudentAcademicRecord)value;
        }
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentAcademicRecordExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StudentAcademicRecordExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentAcademicRecordExtension> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: SubmissionCertificationDescriptor

namespace EdFi.Ods.Api.Common.Models.Resources.SubmissionCertificationDescriptor.SampleStudentTranscript
{
    /// <summary>
    /// A class which represents the samplestudenttranscript.SubmissionCertificationDescriptor table of the SubmissionCertificationDescriptor aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract, MessagePackObject]
    [ExcludeFromCodeCoverage]
    public class SubmissionCertificationDescriptor : Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor, Entities.Common.EdFi.IDescriptor, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("samplestudenttranscript", "SubmissionCertificationDescriptor");

        // Fluent validator instance (threadsafe)
        private static SubmissionCertificationDescriptorPutPostRequestValidator _validator = new SubmissionCertificationDescriptorPutPostRequestValidator();
        
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
        /// The unique identifier for the SubmissionCertificationDescriptor resource.
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
        public int SubmissionCertificationDescriptorId { get; set; }

        int IDescriptor.DescriptorId
        {
            get { return SubmissionCertificationDescriptorId; }
            set { SubmissionCertificationDescriptorId = value; }
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
            var compareTo = obj as Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Derived Property
            if (!(this as Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor).SubmissionCertificationDescriptorId.Equals(compareTo.SubmissionCertificationDescriptorId))
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
            hash.Add((this as Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor).SubmissionCertificationDescriptorId);

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
            return Entities.Common.SampleStudentTranscript.SubmissionCertificationDescriptorMapper.SynchronizeTo(this, (Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.SampleStudentTranscript.SubmissionCertificationDescriptorMapper.MapTo(this, (Entities.Common.SampleStudentTranscript.ISubmissionCertificationDescriptor)target, null);
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
    public class SubmissionCertificationDescriptorPutPostRequestValidator : FluentValidation.AbstractValidator<SubmissionCertificationDescriptor>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SubmissionCertificationDescriptor> context, FluentValidation.Results.ValidationResult result)
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

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
using EdFi.Ods.Entities.Common.Homograph;
using Newtonsoft.Json;
using FluentValidation.Results;

// Aggregate: Name

namespace EdFi.Ods.Api.Common.Models.Resources.Name.Homograph
{
    /// <summary>
    /// Represents a reference to the Name resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class NameReference : IResourceReference
    {
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        [DataMember(Name="lastSurname")]
        public string LastSurname { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return FirstName != default(string) && LastSurname != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (FirstName == default)
            {
                yield return "FirstName";
            }

            if (LastSurname == default)
            {
                yield return "LastSurname";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Name",
                Href = $"/homograph/names/{ResourceId:n}"
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
    /// A class which represents the homograph.Name table of the Name aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class Name : Entities.Common.Homograph.IName, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("homograph", "Name");

        // Fluent validator instance (threadsafe)
        private static NamePutPostRequestValidator _validator = new NamePutPostRequestValidator();
        
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
        /// The unique identifier for the Name resource.
        /// </summary>
        [DataMember(Name="id")]
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
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(75, MinimumLength=1, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(75, MinimumLength=1, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="lastSurname")]
        public string LastSurname { get; set; }
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
            var compareTo = obj as Entities.Common.Homograph.IName;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IName).FirstName, compareTo.FirstName))
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IName).LastSurname, compareTo.LastSurname))
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
                hash.Add((this as Entities.Common.Homograph.IName).FirstName);


            // Standard Property
                hash.Add((this as Entities.Common.Homograph.IName).LastSurname);

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
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
            return Entities.Common.Homograph.NameMapper.SynchronizeTo(this, (Entities.Common.Homograph.IName)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.NameMapper.MapTo(this, (Entities.Common.Homograph.IName)target, null);
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
    public class NamePutPostRequestValidator : FluentValidation.AbstractValidator<Name>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<Name> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Parent

namespace EdFi.Ods.Api.Common.Models.Resources.Parent.Homograph
{
    /// <summary>
    /// Represents a reference to the Parent resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentReference : IResourceReference
    {
        [DataMember(Name="parentFirstName")]
        public string ParentFirstName { get; set; }

        [DataMember(Name="parentLastSurname")]
        public string ParentLastSurname { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return ParentFirstName != default(string) && ParentLastSurname != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (ParentFirstName == default)
            {
                yield return "ParentFirstName";
            }

            if (ParentLastSurname == default)
            {
                yield return "ParentLastSurname";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Parent",
                Href = $"/homograph/parents/{ResourceId:n}"
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
    /// A class which represents the homograph.Parent table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class Parent : Entities.Common.Homograph.IParent, IHasETag, IDateVersionedEntity, IValidatableObject
    {
        private static FullName _fullName = new FullName("homograph", "Parent");

        // Fluent validator instance (threadsafe)
        private static ParentPutPostRequestValidator _validator = new ParentPutPostRequestValidator();
        
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public Parent()
        {
            ParentAddresses = new List<ParentAddress>();
            ParentStudentSchoolAssociations = new List<ParentStudentSchoolAssociation>();
        }
        
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the Parent resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _parentNameReferenceExplicitlyAssigned;
        private Name.Homograph.NameReference _parentNameReference;
        private Name.Homograph.NameReference ImplicitParentNameReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_parentNameReference == null && !_parentNameReferenceExplicitlyAssigned)
                    _parentNameReference = new Name.Homograph.NameReference();

                return _parentNameReference;
            }
        }

        [DataMember(Name="parentNameReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public Name.Homograph.NameReference ParentNameReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitParentNameReference != null
                    && (_parentNameReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitParentNameReference.IsReferenceFullyDefined()))
                    return ImplicitParentNameReference;

                return null;
            }
            set
            {
                _parentNameReferenceExplicitlyAssigned = true;
                _parentNameReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IParent.ParentFirstName
        {
            get
            {
                if (ImplicitParentNameReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitParentNameReference.IsReferenceFullyDefined()))
                    return ImplicitParentNameReference.FirstName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // ParentName
                _parentNameReferenceExplicitlyAssigned = false;
                ImplicitParentNameReference.FirstName = value;
            }
        }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IParent.ParentLastSurname
        {
            get
            {
                if (ImplicitParentNameReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitParentNameReference.IsReferenceFullyDefined()))
                    return ImplicitParentNameReference.LastSurname;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // ParentName
                _parentNameReferenceExplicitlyAssigned = false;
                ImplicitParentNameReference.LastSurname = value;
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
            var compareTo = obj as Entities.Common.Homograph.IParent;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IParent).ParentFirstName, compareTo.ParentFirstName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IParent).ParentLastSurname, compareTo.ParentLastSurname))
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

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IParent).ParentFirstName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IParent).ParentLastSurname);
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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<ParentAddress> _parentAddresses;
        private ICollection<Entities.Common.Homograph.IParentAddress> _parentAddressesCovariant;

        [NoDuplicateMembers][RequiredCollection]
        [DataMember(Name="addresses")]
        public ICollection<ParentAddress> ParentAddresses
        {
            get { return _parentAddresses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentAddress>(value,
                    (s, e) => ((Entities.Common.Homograph.IParentAddress)e.Item).Parent = this);
                _parentAddresses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Homograph.IParentAddress, ParentAddress>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Homograph.IParentAddress)e.Item).Parent = this;
                _parentAddressesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IParentAddress> Entities.Common.Homograph.IParent.ParentAddresses
        {
            get { return _parentAddressesCovariant; }
            set { ParentAddresses = new List<ParentAddress>(value.Cast<ParentAddress>()); }
        }

        private ICollection<ParentStudentSchoolAssociation> _parentStudentSchoolAssociations;
        private ICollection<Entities.Common.Homograph.IParentStudentSchoolAssociation> _parentStudentSchoolAssociationsCovariant;

        [NoDuplicateMembers][RequiredCollection]
        [DataMember(Name="studentSchoolAssociations")]
        public ICollection<ParentStudentSchoolAssociation> ParentStudentSchoolAssociations
        {
            get { return _parentStudentSchoolAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ParentStudentSchoolAssociation>(value,
                    (s, e) => ((Entities.Common.Homograph.IParentStudentSchoolAssociation)e.Item).Parent = this);
                _parentStudentSchoolAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Homograph.IParentStudentSchoolAssociation, ParentStudentSchoolAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Homograph.IParentStudentSchoolAssociation)e.Item).Parent = this;
                _parentStudentSchoolAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IParentStudentSchoolAssociation> Entities.Common.Homograph.IParent.ParentStudentSchoolAssociations
        {
            get { return _parentStudentSchoolAssociationsCovariant; }
            set { ParentStudentSchoolAssociations = new List<ParentStudentSchoolAssociation>(value.Cast<ParentStudentSchoolAssociation>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect collection item parent references on deserialization
            if (_parentAddresses != null) foreach (var item in _parentAddresses)
            {
                item.Parent = this;
            }

            if (_parentStudentSchoolAssociations != null) foreach (var item in _parentStudentSchoolAssociations)
            {
                item.Parent = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Homograph.ParentMapper.SynchronizeTo(this, (Entities.Common.Homograph.IParent)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.ParentMapper.MapTo(this, (Entities.Common.Homograph.IParent)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.IParent.ParentNameResourceId
        {
            get { return null; }
            set { ImplicitParentNameReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IParent.ParentNameDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitParentNameReference.Discriminator = value; }
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
                if (ParentAddresses.Any() && mappingContract?.IsMemberSupported("ParentAddresses") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("ParentAddresses");
    
                    foreach (var result in ValidationHelpers.ValidateCollection(new ValidationContext(ParentAddresses, validationContext, validationContext.Items.ForCollection("ParentAddresses"))))
                    {
                        yield return result;
                    }
                }

                if (ParentStudentSchoolAssociations.Any() && mappingContract?.IsMemberSupported("ParentStudentSchoolAssociations") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("ParentStudentSchoolAssociations");
    
                    foreach (var result in ValidationHelpers.ValidateCollection(new ValidationContext(ParentStudentSchoolAssociations, validationContext, validationContext.Items.ForCollection("ParentStudentSchoolAssociations"))))
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
    public class ParentPutPostRequestValidator : FluentValidation.AbstractValidator<Parent>
    {
        private static readonly FullName _fullName_homograph_Parent = new FullName("homograph", "Parent");

        // Declare collection item validators
        private ParentAddressPutPostRequestValidator _parentAddressesValidator = new ();
        private ParentStudentSchoolAssociationPutPostRequestValidator _parentStudentSchoolAssociationsValidator = new ();

        protected override bool PreValidate(FluentValidation.ValidationContext<Parent> context, FluentValidation.Results.ValidationResult result)
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
            var mappingContract = (global::EdFi.Ods.Entities.Common.Homograph.ParentMappingContract) GeneratedArtifactStaticDependencies.MappingContractProvider
                .GetMappingContract(_fullName_homograph_Parent);

            if (mappingContract != null)
            {
                if (mappingContract.IsParentAddressIncluded != null)
                {
                    var hasInvalidParentAddressesItems = instance.ParentAddresses.Any(x => !mappingContract.IsParentAddressIncluded(x));
        
                    if (hasInvalidParentAddressesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ParentAddresses", $"A supplied 'ParentAddress' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.IsParentStudentSchoolAssociationIncluded != null)
                {
                    var hasInvalidParentStudentSchoolAssociationsItems = instance.ParentStudentSchoolAssociations.Any(x => !mappingContract.IsParentStudentSchoolAssociationIncluded(x));
        
                    if (hasInvalidParentStudentSchoolAssociationsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("ParentStudentSchoolAssociations", $"A supplied 'ParentStudentSchoolAssociation' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
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
    /// A class which represents the homograph.ParentAddress table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentAddress : Entities.Common.Homograph.IParentAddress
    {
        private static FullName _fullName = new FullName("homograph", "ParentAddress");

        // Fluent validator instance (threadsafe)
        private static ParentAddressPutPostRequestValidator _validator = new ParentAddressPutPostRequestValidator();
        
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
        private Entities.Common.Homograph.IParent _parent;

        [IgnoreDataMember]
        Entities.Common.Homograph.IParent Entities.Common.Homograph.IParentAddress.Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        public Entities.Common.Homograph.IParent Parent
        {
            set { SetParent(value); }
        }

        private void SetParent(Entities.Common.Homograph.IParent value)
        {
            _parent = value;
        }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(30, MinimumLength=2, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="city")]
        public string City { get; set; }
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
            var compareTo = obj as Entities.Common.Homograph.IParentAddress;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parent == null || !_parent.Equals(compareTo.Parent))
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IParentAddress).City, compareTo.City))
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
            if (_parent != null)
                hash.Add(_parent);

            // Standard Property
                hash.Add((this as Entities.Common.Homograph.IParentAddress).City);

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
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
            return Entities.Common.Homograph.ParentAddressMapper.SynchronizeTo(this, (Entities.Common.Homograph.IParentAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.ParentAddressMapper.MapTo(this, (Entities.Common.Homograph.IParentAddress)target, null);
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
    public class ParentAddressPutPostRequestValidator : FluentValidation.AbstractValidator<ParentAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentAddress> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the homograph.ParentStudentSchoolAssociation table of the Parent aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ParentStudentSchoolAssociation : Entities.Common.Homograph.IParentStudentSchoolAssociation
    {
        private static FullName _fullName = new FullName("homograph", "ParentStudentSchoolAssociation");

        // Fluent validator instance (threadsafe)
        private static ParentStudentSchoolAssociationPutPostRequestValidator _validator = new ParentStudentSchoolAssociationPutPostRequestValidator();
        
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

        private bool _studentSchoolAssociationReferenceExplicitlyAssigned;
        private StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference _studentSchoolAssociationReference;
        private StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference ImplicitStudentSchoolAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentSchoolAssociationReference == null && !_studentSchoolAssociationReferenceExplicitlyAssigned)
                    _studentSchoolAssociationReference = new StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference();

                return _studentSchoolAssociationReference;
            }
        }

        [DataMember(Name="studentSchoolAssociationReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference StudentSchoolAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_studentSchoolAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference;

                return null;
            }
            set
            {
                _studentSchoolAssociationReferenceExplicitlyAssigned = true;
                _studentSchoolAssociationReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Homograph.IParent _parent;

        [IgnoreDataMember]
        Entities.Common.Homograph.IParent Entities.Common.Homograph.IParentStudentSchoolAssociation.Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        public Entities.Common.Homograph.IParent Parent
        {
            set { SetParent(value); }
        }

        private void SetParent(Entities.Common.Homograph.IParent value)
        {
            _parent = value;
        }

        /// <summary>
        /// The name of the school.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IParentStudentSchoolAssociation.SchoolName
        {
            get
            {
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference.SchoolName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentSchoolAssociation
                _studentSchoolAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentSchoolAssociationReference.SchoolName = value;
            }
        }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentFirstName
        {
            get
            {
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference.StudentFirstName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentSchoolAssociation
                _studentSchoolAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentSchoolAssociationReference.StudentFirstName = value;
            }
        }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentLastSurname
        {
            get
            {
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference.StudentLastSurname;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentSchoolAssociation
                _studentSchoolAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentSchoolAssociationReference.StudentLastSurname = value;
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
            var compareTo = obj as Entities.Common.Homograph.IParentStudentSchoolAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_parent == null || !_parent.Equals(compareTo.Parent))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IParentStudentSchoolAssociation).SchoolName, compareTo.SchoolName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IParentStudentSchoolAssociation).StudentFirstName, compareTo.StudentFirstName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IParentStudentSchoolAssociation).StudentLastSurname, compareTo.StudentLastSurname))
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
            if (_parent != null)
                hash.Add(_parent);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IParentStudentSchoolAssociation).SchoolName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IParentStudentSchoolAssociation).StudentFirstName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IParentStudentSchoolAssociation).StudentLastSurname);
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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
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
            return Entities.Common.Homograph.ParentStudentSchoolAssociationMapper.SynchronizeTo(this, (Entities.Common.Homograph.IParentStudentSchoolAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.ParentStudentSchoolAssociationMapper.MapTo(this, (Entities.Common.Homograph.IParentStudentSchoolAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentSchoolAssociationResourceId
        {
            get { return null; }
            set { ImplicitStudentSchoolAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IParentStudentSchoolAssociation.StudentSchoolAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentSchoolAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ParentStudentSchoolAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<ParentStudentSchoolAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ParentStudentSchoolAssociation> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: School

namespace EdFi.Ods.Api.Common.Models.Resources.School.Homograph
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference : IResourceReference
    {
        [DataMember(Name="schoolName")]
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return SchoolName != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (SchoolName == default)
            {
                yield return "SchoolName";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/homograph/schools/{ResourceId:n}"
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
    /// A class which represents the homograph.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.Homograph.ISchool, IHasETag, IDateVersionedEntity, IValidatableObject
    {
        private static FullName _fullName = new FullName("homograph", "School");

        // Fluent validator instance (threadsafe)
        private static SchoolPutPostRequestValidator _validator = new SchoolPutPostRequestValidator();
        
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
        /// The unique identifier for the School resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _schoolYearTypeReferenceExplicitlyAssigned;
        private SchoolYearType.Homograph.SchoolYearTypeReference _schoolYearTypeReference;
        private SchoolYearType.Homograph.SchoolYearTypeReference ImplicitSchoolYearTypeReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_schoolYearTypeReference == null && !_schoolYearTypeReferenceExplicitlyAssigned)
                    _schoolYearTypeReference = new SchoolYearType.Homograph.SchoolYearTypeReference();

                return _schoolYearTypeReference;
            }
        }

        [DataMember(Name="schoolYearTypeReference")]
        [FullyDefinedReference]
        public SchoolYearType.Homograph.SchoolYearTypeReference SchoolYearTypeReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitSchoolYearTypeReference != null
                    && (_schoolYearTypeReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitSchoolYearTypeReference.IsReferenceFullyDefined()))
                    return ImplicitSchoolYearTypeReference;

                return null;
            }
            set
            {
                _schoolYearTypeReferenceExplicitlyAssigned = true;
                _schoolYearTypeReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The name of the school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(100, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="schoolName")]
        public string SchoolName { get; set; }
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
            var compareTo = obj as Entities.Common.Homograph.ISchool;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.ISchool).SchoolName, compareTo.SchoolName))
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
                hash.Add((this as Entities.Common.Homograph.ISchool).SchoolName);

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
        /// A school year.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.ISchool.SchoolYear
        {
            get
            {
                if (ImplicitSchoolYearTypeReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitSchoolYearTypeReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitSchoolYearTypeReference.SchoolYear;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // SchoolYearType
                _schoolYearTypeReferenceExplicitlyAssigned = false;
                ImplicitSchoolYearTypeReference.SchoolYear = value;
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// address
        /// </summary>
        
        [DataMember(Name = "address")]
        public SchoolAddress SchoolAddress { get; set; }

        Entities.Common.Homograph.ISchoolAddress Entities.Common.Homograph.ISchool.SchoolAddress
        {
            get { return SchoolAddress; }
            set { SchoolAddress = (SchoolAddress) value; }
        }

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
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
            return Entities.Common.Homograph.SchoolMapper.SynchronizeTo(this, (Entities.Common.Homograph.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.SchoolMapper.MapTo(this, (Entities.Common.Homograph.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.ISchool.SchoolYearTypeResourceId
        {
            get { return null; }
            set { ImplicitSchoolYearTypeReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.ISchool.SchoolYearTypeDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitSchoolYearTypeReference.Discriminator = value; }
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

                // ---------------------------
                //  Validate embedded objects
                // ---------------------------
                if (SchoolAddress != null && mappingContract?.IsMemberSupported("SchoolAddress") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("SchoolAddress");

                    foreach (var result in ValidationHelpers.ValidateEmbeddedObject(new ValidationContext(SchoolAddress, validationContext, validationContext.Items.ForEmbeddedObject("SchoolAddress"))))
                    {
                        yield return result;
                    }
                }

            
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
    public class SchoolPutPostRequestValidator : FluentValidation.AbstractValidator<School>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<School> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the homograph.SchoolAddress table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolAddress : Entities.Common.Homograph.ISchoolAddress
    {
        private static FullName _fullName = new FullName("homograph", "SchoolAddress");

        // Fluent validator instance (threadsafe)
        private static SchoolAddressPutPostRequestValidator _validator = new SchoolAddressPutPostRequestValidator();
        
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
        private Entities.Common.Homograph.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.Homograph.ISchool Entities.Common.Homograph.ISchoolAddress.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        public Entities.Common.Homograph.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.Homograph.ISchool value)
        {
            _school = value;
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
            var compareTo = obj as Entities.Common.Homograph.ISchoolAddress;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
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
            if (_school != null)
                hash.Add(_school);
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
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(30, MinimumLength=2, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText]
        [DataMember(Name="city")]
        public string City { get; set; }
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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
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
            return Entities.Common.Homograph.SchoolAddressMapper.SynchronizeTo(this, (Entities.Common.Homograph.ISchoolAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.SchoolAddressMapper.MapTo(this, (Entities.Common.Homograph.ISchoolAddress)target, null);
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
    public class SchoolAddressPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolAddress> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: SchoolYearType

namespace EdFi.Ods.Api.Common.Models.Resources.SchoolYearType.Homograph
{
    /// <summary>
    /// Represents a reference to the SchoolYearType resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolYearTypeReference : IResourceReference
    {
        [DataMember(Name="schoolYear")]
        public string SchoolYear { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return SchoolYear != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (SchoolYear == default)
            {
                yield return "SchoolYear";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "SchoolYearType",
                Href = $"/homograph/schoolYearTypes/{ResourceId:n}"
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
    /// A class which represents the homograph.SchoolYearType table of the SchoolYearType aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolYearType : Entities.Common.Homograph.ISchoolYearType, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("homograph", "SchoolYearType");

        // Fluent validator instance (threadsafe)
        private static SchoolYearTypePutPostRequestValidator _validator = new SchoolYearTypePutPostRequestValidator();
        
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
        /// The unique identifier for the SchoolYearType resource.
        /// </summary>
        [DataMember(Name="id")]
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
        /// A school year.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(20, ErrorMessage=ValidationHelpers.StringLengthMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="schoolYear")]
        public string SchoolYear { get; set; }
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
            var compareTo = obj as Entities.Common.Homograph.ISchoolYearType;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.ISchoolYearType).SchoolYear, compareTo.SchoolYear))
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
                hash.Add((this as Entities.Common.Homograph.ISchoolYearType).SchoolYear);

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
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
            return Entities.Common.Homograph.SchoolYearTypeMapper.SynchronizeTo(this, (Entities.Common.Homograph.ISchoolYearType)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.SchoolYearTypeMapper.MapTo(this, (Entities.Common.Homograph.ISchoolYearType)target, null);
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
    public class SchoolYearTypePutPostRequestValidator : FluentValidation.AbstractValidator<SchoolYearType>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolYearType> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Staff

namespace EdFi.Ods.Api.Common.Models.Resources.Staff.Homograph
{
    /// <summary>
    /// Represents a reference to the Staff resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffReference : IResourceReference
    {
        [DataMember(Name="staffFirstName")]
        public string StaffFirstName { get; set; }

        [DataMember(Name="staffLastSurname")]
        public string StaffLastSurname { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return StaffFirstName != default(string) && StaffLastSurname != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (StaffFirstName == default)
            {
                yield return "StaffFirstName";
            }

            if (StaffLastSurname == default)
            {
                yield return "StaffLastSurname";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Staff",
                Href = $"/homograph/staffs/{ResourceId:n}"
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
    /// A class which represents the homograph.Staff table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class Staff : Entities.Common.Homograph.IStaff, IHasETag, IDateVersionedEntity, IValidatableObject
    {
        private static FullName _fullName = new FullName("homograph", "Staff");

        // Fluent validator instance (threadsafe)
        private static StaffPutPostRequestValidator _validator = new StaffPutPostRequestValidator();
        
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public Staff()
        {
            StaffAddresses = new List<StaffAddress>();
            StaffStudentSchoolAssociations = new List<StaffStudentSchoolAssociation>();
        }
        
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the Staff resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _staffNameReferenceExplicitlyAssigned;
        private Name.Homograph.NameReference _staffNameReference;
        private Name.Homograph.NameReference ImplicitStaffNameReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_staffNameReference == null && !_staffNameReferenceExplicitlyAssigned)
                    _staffNameReference = new Name.Homograph.NameReference();

                return _staffNameReference;
            }
        }

        [DataMember(Name="staffNameReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public Name.Homograph.NameReference StaffNameReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStaffNameReference != null
                    && (_staffNameReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStaffNameReference.IsReferenceFullyDefined()))
                    return ImplicitStaffNameReference;

                return null;
            }
            set
            {
                _staffNameReferenceExplicitlyAssigned = true;
                _staffNameReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStaff.StaffFirstName
        {
            get
            {
                if (ImplicitStaffNameReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffNameReference.IsReferenceFullyDefined()))
                    return ImplicitStaffNameReference.FirstName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffName
                _staffNameReferenceExplicitlyAssigned = false;
                ImplicitStaffNameReference.FirstName = value;
            }
        }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStaff.StaffLastSurname
        {
            get
            {
                if (ImplicitStaffNameReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStaffNameReference.IsReferenceFullyDefined()))
                    return ImplicitStaffNameReference.LastSurname;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StaffName
                _staffNameReferenceExplicitlyAssigned = false;
                ImplicitStaffNameReference.LastSurname = value;
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
            var compareTo = obj as Entities.Common.Homograph.IStaff;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStaff).StaffFirstName, compareTo.StaffFirstName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStaff).StaffLastSurname, compareTo.StaffLastSurname))
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

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStaff).StaffFirstName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStaff).StaffLastSurname);
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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<StaffAddress> _staffAddresses;
        private ICollection<Entities.Common.Homograph.IStaffAddress> _staffAddressesCovariant;

        [NoDuplicateMembers]
        [DataMember(Name="addresses")]
        public ICollection<StaffAddress> StaffAddresses
        {
            get { return _staffAddresses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StaffAddress>(value,
                    (s, e) => ((Entities.Common.Homograph.IStaffAddress)e.Item).Staff = this);
                _staffAddresses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Homograph.IStaffAddress, StaffAddress>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Homograph.IStaffAddress)e.Item).Staff = this;
                _staffAddressesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IStaffAddress> Entities.Common.Homograph.IStaff.StaffAddresses
        {
            get { return _staffAddressesCovariant; }
            set { StaffAddresses = new List<StaffAddress>(value.Cast<StaffAddress>()); }
        }

        private ICollection<StaffStudentSchoolAssociation> _staffStudentSchoolAssociations;
        private ICollection<Entities.Common.Homograph.IStaffStudentSchoolAssociation> _staffStudentSchoolAssociationsCovariant;

        [NoDuplicateMembers]
        [DataMember(Name="studentSchoolAssociations")]
        public ICollection<StaffStudentSchoolAssociation> StaffStudentSchoolAssociations
        {
            get { return _staffStudentSchoolAssociations; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<StaffStudentSchoolAssociation>(value,
                    (s, e) => ((Entities.Common.Homograph.IStaffStudentSchoolAssociation)e.Item).Staff = this);
                _staffStudentSchoolAssociations = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Homograph.IStaffStudentSchoolAssociation, StaffStudentSchoolAssociation>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Homograph.IStaffStudentSchoolAssociation)e.Item).Staff = this;
                _staffStudentSchoolAssociationsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Homograph.IStaffStudentSchoolAssociation> Entities.Common.Homograph.IStaff.StaffStudentSchoolAssociations
        {
            get { return _staffStudentSchoolAssociationsCovariant; }
            set { StaffStudentSchoolAssociations = new List<StaffStudentSchoolAssociation>(value.Cast<StaffStudentSchoolAssociation>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
        public virtual DateTime LastModifiedDate { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect collection item parent references on deserialization
            if (_staffAddresses != null) foreach (var item in _staffAddresses)
            {
                item.Staff = this;
            }

            if (_staffStudentSchoolAssociations != null) foreach (var item in _staffStudentSchoolAssociations)
            {
                item.Staff = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Homograph.StaffMapper.SynchronizeTo(this, (Entities.Common.Homograph.IStaff)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.StaffMapper.MapTo(this, (Entities.Common.Homograph.IStaff)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.IStaff.StaffNameResourceId
        {
            get { return null; }
            set { ImplicitStaffNameReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IStaff.StaffNameDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStaffNameReference.Discriminator = value; }
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
                if (StaffAddresses.Any() && mappingContract?.IsMemberSupported("StaffAddresses") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("StaffAddresses");
    
                    foreach (var result in ValidationHelpers.ValidateCollection(new ValidationContext(StaffAddresses, validationContext, validationContext.Items.ForCollection("StaffAddresses"))))
                    {
                        yield return result;
                    }
                }

                if (StaffStudentSchoolAssociations.Any() && mappingContract?.IsMemberSupported("StaffStudentSchoolAssociations") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("StaffStudentSchoolAssociations");
    
                    foreach (var result in ValidationHelpers.ValidateCollection(new ValidationContext(StaffStudentSchoolAssociations, validationContext, validationContext.Items.ForCollection("StaffStudentSchoolAssociations"))))
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
    public class StaffPutPostRequestValidator : FluentValidation.AbstractValidator<Staff>
    {
        private static readonly FullName _fullName_homograph_Staff = new FullName("homograph", "Staff");

        // Declare collection item validators
        private StaffAddressPutPostRequestValidator _staffAddressesValidator = new ();
        private StaffStudentSchoolAssociationPutPostRequestValidator _staffStudentSchoolAssociationsValidator = new ();

        protected override bool PreValidate(FluentValidation.ValidationContext<Staff> context, FluentValidation.Results.ValidationResult result)
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
            var mappingContract = (global::EdFi.Ods.Entities.Common.Homograph.StaffMappingContract) GeneratedArtifactStaticDependencies.MappingContractProvider
                .GetMappingContract(_fullName_homograph_Staff);

            if (mappingContract != null)
            {
                if (mappingContract.IsStaffAddressIncluded != null)
                {
                    var hasInvalidStaffAddressesItems = instance.StaffAddresses.Any(x => !mappingContract.IsStaffAddressIncluded(x));
        
                    if (hasInvalidStaffAddressesItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StaffAddresses", $"A supplied 'StaffAddress' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
                    }
                }

                if (mappingContract.IsStaffStudentSchoolAssociationIncluded != null)
                {
                    var hasInvalidStaffStudentSchoolAssociationsItems = instance.StaffStudentSchoolAssociations.Any(x => !mappingContract.IsStaffStudentSchoolAssociationIncluded(x));
        
                    if (hasInvalidStaffStudentSchoolAssociationsItems)
                    {
                        profileName ??= GeneratedArtifactStaticDependencies.ProfileContentTypeContextProvider.Get().ProfileName;
                        failures.Add(new ValidationFailure("StaffStudentSchoolAssociations", $"A supplied 'StaffStudentSchoolAssociation' has a descriptor value that does not conform with the filter values defined by profile '{profileName}'."));
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
    /// A class which represents the homograph.StaffAddress table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffAddress : Entities.Common.Homograph.IStaffAddress
    {
        private static FullName _fullName = new FullName("homograph", "StaffAddress");

        // Fluent validator instance (threadsafe)
        private static StaffAddressPutPostRequestValidator _validator = new StaffAddressPutPostRequestValidator();
        
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
        private Entities.Common.Homograph.IStaff _staff;

        [IgnoreDataMember]
        Entities.Common.Homograph.IStaff Entities.Common.Homograph.IStaffAddress.Staff
        {
            get { return _staff; }
            set { SetStaff(value); }
        }

        public Entities.Common.Homograph.IStaff Staff
        {
            set { SetStaff(value); }
        }

        private void SetStaff(Entities.Common.Homograph.IStaff value)
        {
            _staff = value;
        }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(30, MinimumLength=2, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="city")]
        public string City { get; set; }
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
            var compareTo = obj as Entities.Common.Homograph.IStaffAddress;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staff == null || !_staff.Equals(compareTo.Staff))
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStaffAddress).City, compareTo.City))
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
            if (_staff != null)
                hash.Add(_staff);

            // Standard Property
                hash.Add((this as Entities.Common.Homograph.IStaffAddress).City);

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
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
            return Entities.Common.Homograph.StaffAddressMapper.SynchronizeTo(this, (Entities.Common.Homograph.IStaffAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.StaffAddressMapper.MapTo(this, (Entities.Common.Homograph.IStaffAddress)target, null);
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
    public class StaffAddressPutPostRequestValidator : FluentValidation.AbstractValidator<StaffAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StaffAddress> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the homograph.StaffStudentSchoolAssociation table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffStudentSchoolAssociation : Entities.Common.Homograph.IStaffStudentSchoolAssociation
    {
        private static FullName _fullName = new FullName("homograph", "StaffStudentSchoolAssociation");

        // Fluent validator instance (threadsafe)
        private static StaffStudentSchoolAssociationPutPostRequestValidator _validator = new StaffStudentSchoolAssociationPutPostRequestValidator();
        
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

        private bool _studentSchoolAssociationReferenceExplicitlyAssigned;
        private StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference _studentSchoolAssociationReference;
        private StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference ImplicitStudentSchoolAssociationReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentSchoolAssociationReference == null && !_studentSchoolAssociationReferenceExplicitlyAssigned)
                    _studentSchoolAssociationReference = new StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference();

                return _studentSchoolAssociationReference;
            }
        }

        [DataMember(Name="studentSchoolAssociationReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public StudentSchoolAssociation.Homograph.StudentSchoolAssociationReference StudentSchoolAssociationReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_studentSchoolAssociationReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference;

                return null;
            }
            set
            {
                _studentSchoolAssociationReferenceExplicitlyAssigned = true;
                _studentSchoolAssociationReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Homograph.IStaff _staff;

        [IgnoreDataMember]
        Entities.Common.Homograph.IStaff Entities.Common.Homograph.IStaffStudentSchoolAssociation.Staff
        {
            get { return _staff; }
            set { SetStaff(value); }
        }

        public Entities.Common.Homograph.IStaff Staff
        {
            set { SetStaff(value); }
        }

        private void SetStaff(Entities.Common.Homograph.IStaff value)
        {
            _staff = value;
        }

        /// <summary>
        /// The name of the school.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStaffStudentSchoolAssociation.SchoolName
        {
            get
            {
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference.SchoolName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentSchoolAssociation
                _studentSchoolAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentSchoolAssociationReference.SchoolName = value;
            }
        }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentFirstName
        {
            get
            {
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference.StudentFirstName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentSchoolAssociation
                _studentSchoolAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentSchoolAssociationReference.StudentFirstName = value;
            }
        }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentLastSurname
        {
            get
            {
                if (ImplicitStudentSchoolAssociationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentSchoolAssociationReference.IsReferenceFullyDefined()))
                    return ImplicitStudentSchoolAssociationReference.StudentLastSurname;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentSchoolAssociation
                _studentSchoolAssociationReferenceExplicitlyAssigned = false;
                ImplicitStudentSchoolAssociationReference.StudentLastSurname = value;
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
            var compareTo = obj as Entities.Common.Homograph.IStaffStudentSchoolAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_staff == null || !_staff.Equals(compareTo.Staff))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStaffStudentSchoolAssociation).SchoolName, compareTo.SchoolName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStaffStudentSchoolAssociation).StudentFirstName, compareTo.StudentFirstName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStaffStudentSchoolAssociation).StudentLastSurname, compareTo.StudentLastSurname))
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
            if (_staff != null)
                hash.Add(_staff);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStaffStudentSchoolAssociation).SchoolName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStaffStudentSchoolAssociation).StudentFirstName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStaffStudentSchoolAssociation).StudentLastSurname);
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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
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
            return Entities.Common.Homograph.StaffStudentSchoolAssociationMapper.SynchronizeTo(this, (Entities.Common.Homograph.IStaffStudentSchoolAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.StaffStudentSchoolAssociationMapper.MapTo(this, (Entities.Common.Homograph.IStaffStudentSchoolAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentSchoolAssociationResourceId
        {
            get { return null; }
            set { ImplicitStudentSchoolAssociationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IStaffStudentSchoolAssociation.StudentSchoolAssociationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentSchoolAssociationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StaffStudentSchoolAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StaffStudentSchoolAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StaffStudentSchoolAssociation> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Student

namespace EdFi.Ods.Api.Common.Models.Resources.Student.Homograph
{
    /// <summary>
    /// Represents a reference to the Student resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentReference : IResourceReference
    {
        [DataMember(Name="studentFirstName")]
        public string StudentFirstName { get; set; }

        [DataMember(Name="studentLastSurname")]
        public string StudentLastSurname { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return StudentFirstName != default(string) && StudentLastSurname != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (StudentFirstName == default)
            {
                yield return "StudentFirstName";
            }

            if (StudentLastSurname == default)
            {
                yield return "StudentLastSurname";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Student",
                Href = $"/homograph/students/{ResourceId:n}"
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
    /// A class which represents the homograph.Student table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class Student : Entities.Common.Homograph.IStudent, IHasETag, IDateVersionedEntity, IValidatableObject
    {
        private static FullName _fullName = new FullName("homograph", "Student");

        // Fluent validator instance (threadsafe)
        private static StudentPutPostRequestValidator _validator = new StudentPutPostRequestValidator();
        
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
        /// The unique identifier for the Student resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _schoolYearTypeReferenceExplicitlyAssigned;
        private SchoolYearType.Homograph.SchoolYearTypeReference _schoolYearTypeReference;
        private SchoolYearType.Homograph.SchoolYearTypeReference ImplicitSchoolYearTypeReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_schoolYearTypeReference == null && !_schoolYearTypeReferenceExplicitlyAssigned)
                    _schoolYearTypeReference = new SchoolYearType.Homograph.SchoolYearTypeReference();

                return _schoolYearTypeReference;
            }
        }

        [DataMember(Name="schoolYearTypeReference")]
        [FullyDefinedReference][RequiredReference("homograph", "Student")]
        public SchoolYearType.Homograph.SchoolYearTypeReference SchoolYearTypeReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitSchoolYearTypeReference != null
                    && (_schoolYearTypeReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitSchoolYearTypeReference.IsReferenceFullyDefined()))
                    return ImplicitSchoolYearTypeReference;

                return null;
            }
            set
            {
                _schoolYearTypeReferenceExplicitlyAssigned = true;
                _schoolYearTypeReference = value;
            }
        }
        private bool _studentNameReferenceExplicitlyAssigned;
        private Name.Homograph.NameReference _studentNameReference;
        private Name.Homograph.NameReference ImplicitStudentNameReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentNameReference == null && !_studentNameReferenceExplicitlyAssigned)
                    _studentNameReference = new Name.Homograph.NameReference();

                return _studentNameReference;
            }
        }

        [DataMember(Name="studentNameReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public Name.Homograph.NameReference StudentNameReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitStudentNameReference != null
                    && (_studentNameReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitStudentNameReference.IsReferenceFullyDefined()))
                    return ImplicitStudentNameReference;

                return null;
            }
            set
            {
                _studentNameReferenceExplicitlyAssigned = true;
                _studentNameReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStudent.StudentFirstName
        {
            get
            {
                if (ImplicitStudentNameReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentNameReference.IsReferenceFullyDefined()))
                    return ImplicitStudentNameReference.FirstName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentName
                _studentNameReferenceExplicitlyAssigned = false;
                ImplicitStudentNameReference.FirstName = value;
            }
        }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStudent.StudentLastSurname
        {
            get
            {
                if (ImplicitStudentNameReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentNameReference.IsReferenceFullyDefined()))
                    return ImplicitStudentNameReference.LastSurname;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // StudentName
                _studentNameReferenceExplicitlyAssigned = false;
                ImplicitStudentNameReference.LastSurname = value;
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
            var compareTo = obj as Entities.Common.Homograph.IStudent;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStudent).StudentFirstName, compareTo.StudentFirstName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStudent).StudentLastSurname, compareTo.StudentLastSurname))
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

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStudent).StudentFirstName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStudent).StudentLastSurname);
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
        /// A school year.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStudent.SchoolYear
        {
            get
            {
                if (ImplicitSchoolYearTypeReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitSchoolYearTypeReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitSchoolYearTypeReference.SchoolYear;
                    }

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // SchoolYearType
                _schoolYearTypeReferenceExplicitlyAssigned = false;
                ImplicitSchoolYearTypeReference.SchoolYear = value;
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// address
        /// </summary>
        [Required(ErrorMessage=ValidationHelpers.RequiredObjectMessageFormat)]
        [DataMember(Name = "address")]
        public StudentAddress StudentAddress { get; set; }

        Entities.Common.Homograph.IStudentAddress Entities.Common.Homograph.IStudent.StudentAddress
        {
            get { return StudentAddress; }
            set { StudentAddress = (StudentAddress) value; }
        }

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
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
            return Entities.Common.Homograph.StudentMapper.SynchronizeTo(this, (Entities.Common.Homograph.IStudent)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.StudentMapper.MapTo(this, (Entities.Common.Homograph.IStudent)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.IStudent.SchoolYearTypeResourceId
        {
            get { return null; }
            set { ImplicitSchoolYearTypeReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IStudent.SchoolYearTypeDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitSchoolYearTypeReference.Discriminator = value; }
        }


        Guid? Entities.Common.Homograph.IStudent.StudentNameResourceId
        {
            get { return null; }
            set { ImplicitStudentNameReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IStudent.StudentNameDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentNameReference.Discriminator = value; }
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

                // ---------------------------
                //  Validate embedded objects
                // ---------------------------
                if (StudentAddress != null && mappingContract?.IsMemberSupported("StudentAddress") != false)
                {
                    // Reset path builder
                    pathBuilder.Length = dotLength;
                    pathBuilder.Append("StudentAddress");

                    foreach (var result in ValidationHelpers.ValidateEmbeddedObject(new ValidationContext(StudentAddress, validationContext, validationContext.Items.ForEmbeddedObject("StudentAddress"))))
                    {
                        yield return result;
                    }
                }

            
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
    public class StudentPutPostRequestValidator : FluentValidation.AbstractValidator<Student>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<Student> context, FluentValidation.Results.ValidationResult result)
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
    /// A class which represents the homograph.StudentAddress table of the Student aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentAddress : Entities.Common.Homograph.IStudentAddress
    {
        private static FullName _fullName = new FullName("homograph", "StudentAddress");

        // Fluent validator instance (threadsafe)
        private static StudentAddressPutPostRequestValidator _validator = new StudentAddressPutPostRequestValidator();
        
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
        private Entities.Common.Homograph.IStudent _student;

        [IgnoreDataMember]
        Entities.Common.Homograph.IStudent Entities.Common.Homograph.IStudentAddress.Student
        {
            get { return _student; }
            set { SetStudent(value); }
        }

        public Entities.Common.Homograph.IStudent Student
        {
            set { SetStudent(value); }
        }

        private void SetStudent(Entities.Common.Homograph.IStudent value)
        {
            _student = value;
        }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [RequiredWithNonDefault]
        [NonDefaultStringLength(30, MinimumLength=2, ErrorMessage=ValidationHelpers.StringLengthWithMinimumMessageFormat), NoDangerousText, NoWhitespace]
        [DataMember(Name="city")]
        public string City { get; set; }
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
            var compareTo = obj as Entities.Common.Homograph.IStudentAddress;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            // Parent Property
            if (_student == null || !_student.Equals(compareTo.Student))
                return false;


            // Standard Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStudentAddress).City, compareTo.City))
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
            if (_student != null)
                hash.Add(_student);

            // Standard Property
                hash.Add((this as Entities.Common.Homograph.IStudentAddress).City);

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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
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
            return Entities.Common.Homograph.StudentAddressMapper.SynchronizeTo(this, (Entities.Common.Homograph.IStudentAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.StudentAddressMapper.MapTo(this, (Entities.Common.Homograph.IStudentAddress)target, null);
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
    public class StudentAddressPutPostRequestValidator : FluentValidation.AbstractValidator<StudentAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentAddress> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: StudentSchoolAssociation

namespace EdFi.Ods.Api.Common.Models.Resources.StudentSchoolAssociation.Homograph
{
    /// <summary>
    /// Represents a reference to the StudentSchoolAssociation resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationReference : IResourceReference
    {
        [DataMember(Name="schoolName")]
        public string SchoolName { get; set; }

        [DataMember(Name="studentFirstName")]
        public string StudentFirstName { get; set; }

        [DataMember(Name="studentLastSurname")]
        public string StudentLastSurname { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the discriminator value which identifies the concrete sub-type of the referenced resource
        /// when the referenced resource has been derived; otherwise <b>null</b>.
        /// </summary>
        public string Discriminator { get; set; }


        private Link _link;

        [DataMember(Name="link")]
        public Link Link
        {
            get
            {
                if (_link == null)
                {
                    // Only generate links when all values are present
                    if (GeneratedArtifactStaticDependencies.ResourceLinksEnabled && IsReferenceFullyDefined())
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
            return SchoolName != default(string) && StudentFirstName != default(string) && StudentLastSurname != default(string);
        }

        IEnumerable<string> IResourceReference.GetUndefinedProperties()
        {
            if (SchoolName == default)
            {
                yield return "SchoolName";
            }

            if (StudentFirstName == default)
            {
                yield return "StudentFirstName";
            }

            if (StudentLastSurname == default)
            {
                yield return "StudentLastSurname";
            }

        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "StudentSchoolAssociation",
                Href = $"/homograph/studentSchoolAssociations/{ResourceId:n}"
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
    /// A class which represents the homograph.StudentSchoolAssociation table of the StudentSchoolAssociation aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociation : Entities.Common.Homograph.IStudentSchoolAssociation, IHasETag, IDateVersionedEntity
    {
        private static FullName _fullName = new FullName("homograph", "StudentSchoolAssociation");

        // Fluent validator instance (threadsafe)
        private static StudentSchoolAssociationPutPostRequestValidator _validator = new StudentSchoolAssociationPutPostRequestValidator();
        
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
        /// The unique identifier for the StudentSchoolAssociation resource.
        /// </summary>
        [DataMember(Name="id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        // ------------------------------------------------------------

        // =============================================================
        //                         References
        // -------------------------------------------------------------

        private bool _schoolReferenceExplicitlyAssigned;
        private School.Homograph.SchoolReference _schoolReference;
        private School.Homograph.SchoolReference ImplicitSchoolReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_schoolReference == null && !_schoolReferenceExplicitlyAssigned)
                    _schoolReference = new School.Homograph.SchoolReference();

                return _schoolReference;
            }
        }

        [DataMember(Name="schoolReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public School.Homograph.SchoolReference SchoolReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitSchoolReference != null
                    && (_schoolReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitSchoolReference.IsReferenceFullyDefined()))
                    return ImplicitSchoolReference;

                return null;
            }
            set
            {
                _schoolReferenceExplicitlyAssigned = true;
                _schoolReference = value;
            }
        }
        private bool _studentReferenceExplicitlyAssigned;
        private Student.Homograph.StudentReference _studentReference;
        private Student.Homograph.StudentReference ImplicitStudentReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_studentReference == null && !_studentReferenceExplicitlyAssigned)
                    _studentReference = new Student.Homograph.StudentReference();

                return _studentReference;
            }
        }

        [DataMember(Name="studentReference")]
        [FullyDefinedReference][RequiredReference(isIdentifying: true)]
        public Student.Homograph.StudentReference StudentReference
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
        /// The name of the school.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStudentSchoolAssociation.SchoolName
        {
            get
            {
                if (ImplicitSchoolReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitSchoolReference.IsReferenceFullyDefined()))
                    return ImplicitSchoolReference.SchoolName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // School
                _schoolReferenceExplicitlyAssigned = false;
                ImplicitSchoolReference.SchoolName = value;
            }
        }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStudentSchoolAssociation.StudentFirstName
        {
            get
            {
                if (ImplicitStudentReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentReference.IsReferenceFullyDefined()))
                    return ImplicitStudentReference.StudentFirstName;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Student
                _studentReferenceExplicitlyAssigned = false;
                ImplicitStudentReference.StudentFirstName = value;
            }
        }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Homograph.IStudentSchoolAssociation.StudentLastSurname
        {
            get
            {
                if (ImplicitStudentReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitStudentReference.IsReferenceFullyDefined()))
                    return ImplicitStudentReference.StudentLastSurname;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // Student
                _studentReferenceExplicitlyAssigned = false;
                ImplicitStudentReference.StudentLastSurname = value;
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
            var compareTo = obj as Entities.Common.Homograph.IStudentSchoolAssociation;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStudentSchoolAssociation).SchoolName, compareTo.SchoolName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStudentSchoolAssociation).StudentFirstName, compareTo.StudentFirstName))
                return false;


            // Referenced Property
            if (!GeneratedArtifactStaticDependencies.DatabaseEngineSpecificStringComparer.Equals((this as Entities.Common.Homograph.IStudentSchoolAssociation).StudentLastSurname, compareTo.StudentLastSurname))
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

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStudentSchoolAssociation).SchoolName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStudentSchoolAssociation).StudentFirstName);

            //Referenced Property
            hash.Add((this as Entities.Common.Homograph.IStudentSchoolAssociation).StudentLastSurname);
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
        //                     Extensions
        // -------------------------------------------------------------
        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        public System.Collections.IDictionary Extensions {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }
            
        [DataMember(Name="_lastModifiedDate")]
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
            return Entities.Common.Homograph.StudentSchoolAssociationMapper.SynchronizeTo(this, (Entities.Common.Homograph.IStudentSchoolAssociation)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Homograph.StudentSchoolAssociationMapper.MapTo(this, (Entities.Common.Homograph.IStudentSchoolAssociation)target, null);
        }
        // -------------------------------------------------------------

        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Homograph.IStudentSchoolAssociation.SchoolResourceId
        {
            get { return null; }
            set { ImplicitSchoolReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IStudentSchoolAssociation.SchoolDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitSchoolReference.Discriminator = value; }
        }


        Guid? Entities.Common.Homograph.IStudentSchoolAssociation.StudentResourceId
        {
            get { return null; }
            set { ImplicitStudentReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Homograph.IStudentSchoolAssociation.StudentDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitStudentReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class StudentSchoolAssociationPutPostRequestValidator : FluentValidation.AbstractValidator<StudentSchoolAssociation>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StudentSchoolAssociation> context, FluentValidation.Results.ValidationResult result)
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

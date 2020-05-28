using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Net;
using System.Diagnostics.CodeAnalysis;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Serialization;
using EdFi.Ods.Api.Dependencies;
using EdFi.Ods.Api.Models;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Entities.Common.EdFi;
using Newtonsoft.Json;
using FluentValidation.Results;

// Aggregate: EducationOrganization

namespace EdFi.Ods.Api.Models.Resources.EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School
{
    /// <summary>
    /// Represents a reference to the EducationOrganization resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "EducationOrganization",
                Href = $"/ed-fi/educationOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new Common.Models.Domain.FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference


    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the edfi.EducationOrganizationCategory table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategory : Entities.Common.EdFi.IEducationOrganizationCategory, Entities.Common.EdFi.IEducationOrganizationCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationCategory.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationCategoryDescriptor"), NaturalKeyMember]
        public string EducationOrganizationCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.Equals(compareTo.EducationOrganizationCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationCategoryMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationIdentificationCode table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCode : Entities.Common.EdFi.IEducationOrganizationIdentificationCode, Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationIdentificationCode.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The school system, state, or agency assigning the identification code.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationIdentificationSystemDescriptor"), NaturalKeyMember]
        public string EducationOrganizationIdentificationSystemDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationIdentificationCode;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.Equals(compareTo.EducationOrganizationIdentificationSystemDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="identificationCode")]
        public string IdentificationCode { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationIdentificationCode")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport.IsIdentificationCodeSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCodePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationIdentificationCode>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationIdentificationCode> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInstitutionTelephone table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephone : Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of communication number listed for an individual or organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="institutionTelephoneNumberTypeDescriptor"), NaturalKeyMember]
        public string InstitutionTelephoneNumberTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.Equals(compareTo.InstitutionTelephoneNumberTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="telephoneNumber")]
        public string TelephoneNumber { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInstitutionTelephone")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport.IsTelephoneNumberSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInstitutionTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInstitutionTelephone> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInternationalAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddress : Entities.Common.EdFi.IEducationOrganizationInternationalAddress, Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInternationalAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInternationalAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The first line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine3")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The fourth line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine4")]
        public string AddressLine4 { get; set; }

        /// <summary>
        /// The first date the address is valid. For physical addresses, the date the person moved to that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="countryDescriptor")]
        public string CountryDescriptor { get; set; }

        /// <summary>
        /// The last date the address is valid. For physical addresses, this would be the date the person moved from that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInternationalAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine1Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine2Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine3Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine4Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsBeginDateSupported          { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsCountryDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsEndDateSupported            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLatitudeSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLongitudeSupported          { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInternationalAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInternationalAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Readable
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference
    {
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


        private Link _link;

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
            return SchoolId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/ed-fi/schools/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the edfi.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.EdFi.ISchool, Entities.Common.EdFi.IEducationOrganization, IHasETag, Entities.Common.EdFi.ISchoolSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public School()
        {
            SchoolGradeLevels = new List<SchoolGradeLevel>();

            // Inherited lists
            EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategory>();
            EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCode>();
            EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephone>();
            EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddress>();
        }
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

        private bool _localEducationAgencyReferenceExplicitlyAssigned;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference _localEducationAgencyReference;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference ImplicitLocalEducationAgencyReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_localEducationAgencyReference == null && !_localEducationAgencyReferenceExplicitlyAssigned)
                    _localEducationAgencyReference = new LocalEducationAgency.EdFi.LocalEducationAgencyReference();

                return _localEducationAgencyReference;
            }
        }

        [DataMember(Name="localEducationAgencyReference")]
        public LocalEducationAgency.EdFi.LocalEducationAgencyReference LocalEducationAgencyReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitLocalEducationAgencyReference != null
                    && (_localEducationAgencyReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    return ImplicitLocalEducationAgencyReference;

                return null;
            }
            set
            {
                _localEducationAgencyReferenceExplicitlyAssigned = true;
                _localEducationAgencyReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        int IEducationOrganization.EducationOrganizationId
        {
            get { return SchoolId; }
            set { SchoolId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchool;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Derived Property
            if ((this as Entities.Common.EdFi.ISchool).SchoolId == null
                || !(this as Entities.Common.EdFi.ISchool).SchoolId.Equals(compareTo.SchoolId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
 
                //Derived Property
                if ((this as Entities.Common.EdFi.ISchool).SchoolId != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchool).SchoolId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.NameOfInstitution
        {
            get { return default(string); }
            set { }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.OperationalStatusDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// A short name for the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortNameOfInstitution")]
        public string ShortNameOfInstitution { get; set; }

        /// <summary>
        /// The public web site address (URL) for the EducationOrganization.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="webSite")]
        public string WebSite { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.AdministrativeFundingControlDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// The type of agency that approved the establishment or continuation of a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterApprovalAgencyTypeDescriptor")]
        public string CharterApprovalAgencyTypeDescriptor { get; set; }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        short? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYear
        {
            get { return default(short?); }
            set { }
        }

        /// <summary>
        /// A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterStatusDescriptor")]
        public string CharterStatusDescriptor { get; set; }

        /// <summary>
        /// The type of Internet access available.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="internetAccessDescriptor")]
        public string InternetAccessDescriptor { get; set; }

        /// <summary>
        /// The identifier assigned to a local education agency.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int? Entities.Common.EdFi.ISchool.LocalEducationAgencyId
        {
            get
            {
                if (ImplicitLocalEducationAgencyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitLocalEducationAgencyReference.LocalEducationAgencyId;
                    }

                return default(int?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // LocalEducationAgency
                _localEducationAgencyReferenceExplicitlyAssigned = false;
                ImplicitLocalEducationAgencyReference.LocalEducationAgencyId = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2) to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="magnetSpecialProgramEmphasisSchoolDescriptor")]
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.SchoolTypeDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Denotes the Title I Part A designation for the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="titleIPartASchoolDesignationDescriptor")]
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
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
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationAddresses
        {
            get { return null; }
            set { }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategory> _educationOrganizationCategories;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> _educationOrganizationCategoriesCovariant;

        [DataMember(Name="educationOrganizationCategories"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategory> EducationOrganizationCategories
        {
            get { return _educationOrganizationCategories; }
            set
            {
                _educationOrganizationCategories = value;
                _educationOrganizationCategoriesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationCategory, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategory>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationCategories
        {
            get { return _educationOrganizationCategoriesCovariant; }
            set { EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategory>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategory>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodes;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodesCovariant;

        [DataMember(Name="identificationCodes"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCode> EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodes; }
            set
            {
                _educationOrganizationIdentificationCodes = value;
                _educationOrganizationIdentificationCodesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCode>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodesCovariant; }
            set { EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCode>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCode>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephones;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephonesCovariant;

        [DataMember(Name="institutionTelephones"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephone> EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephones; }
            set
            {
                _educationOrganizationInstitutionTelephones = value;
                _educationOrganizationInstitutionTelephonesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephone>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephonesCovariant; }
            set { EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephone>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephone>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddress> _educationOrganizationInternationalAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> _educationOrganizationInternationalAddressesCovariant;

        [DataMember(Name="internationalAddresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddress> EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddresses; }
            set
            {
                _educationOrganizationInternationalAddresses = value;
                _educationOrganizationInternationalAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddressesCovariant; }
            set { EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddress>()); }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "School")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.ISchoolCategory> Entities.Common.EdFi.ISchool.SchoolCategories
        {
            get { return null; }
            set { }
        }

        private ICollection<SchoolGradeLevel> _schoolGradeLevels;
        private ICollection<Entities.Common.EdFi.ISchoolGradeLevel> _schoolGradeLevelsCovariant;

        [DataMember(Name="gradeLevels"), NoDuplicateMembers]
        public ICollection<SchoolGradeLevel> SchoolGradeLevels
        {
            get { return _schoolGradeLevels; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolGradeLevel>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this);
                _schoolGradeLevels = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolGradeLevel, SchoolGradeLevel>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this;
                _schoolGradeLevelsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolGradeLevel> Entities.Common.EdFi.ISchool.SchoolGradeLevels
        {
            get { return _schoolGradeLevelsCovariant; }
            set { SchoolGradeLevels = new List<SchoolGradeLevel>(value.Cast<SchoolGradeLevel>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _educationOrganizationCategories
            // _educationOrganizationIdentificationCodes
            // _educationOrganizationInstitutionTelephones
            // _educationOrganizationInternationalAddresses
            if (_schoolGradeLevels != null) foreach (var item in _schoolGradeLevels)
            {
                item.School = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.SchoolMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolMapper.MapTo(this, (Entities.Common.EdFi.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsAdministrativeFundingControlDescriptorSupported        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalAgencyTypeDescriptorSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalSchoolYearSupported                     { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterStatusDescriptorSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressesSupported                { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoriesSupported               { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodesSupported      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephonesSupported    { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressesSupported   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsInternetAccessDescriptorSupported                      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsLocalEducationAgencyIdSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsMagnetSpecialProgramEmphasisSchoolDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsNameOfInstitutionSupported                             { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsOperationalStatusDescriptorSupported                   { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoriesSupported                              { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelsSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolTypeDescriptorSupported                          { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsShortNameOfInstitutionSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsTitleIPartASchoolDesignationDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsWebSiteSupported                                       { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodeIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephoneIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolGradeLevel, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYearTypeResourceId 
        { 
            get { return null; }
            // Profile excluded the Reference
            set { }
        }


        Guid? Entities.Common.EdFi.ISchool.LocalEducationAgencyResourceId 
        { 
            get { return null; }
            set { ImplicitLocalEducationAgencyReference.ResourceId = value ?? default(Guid); }
        }


        // -----------------------------------------------------------------
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

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolGradeLevelsValidator = new SchoolGradeLevelPutPostRequestValidator();

            foreach (var item in instance.SchoolGradeLevels)
            {
                var validationResult = schoolGradeLevelsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationCategoriesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationCategoryPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationCategories)
            {
                var validationResult = educationOrganizationCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationIdentificationCodesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationIdentificationCodePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationIdentificationCodes)
            {
                var validationResult = educationOrganizationIdentificationCodesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInstitutionTelephonesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInstitutionTelephonePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInstitutionTelephones)
            {
                var validationResult = educationOrganizationInstitutionTelephonesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInternationalAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.School.EducationOrganizationInternationalAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInternationalAddresses)
            {
                var validationResult = educationOrganizationInternationalAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.SchoolGradeLevel table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevel : Entities.Common.EdFi.ISchoolGradeLevel, Entities.Common.EdFi.ISchoolGradeLevelSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolGradeLevel.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The grade levels served at the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="gradeLevelDescriptor"), NaturalKeyMember]
        public string GradeLevelDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolGradeLevel;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.Equals(compareTo.GradeLevelDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolGradeLevel")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolGradeLevelMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolGradeLevelMapper.MapTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevelPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolGradeLevel>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolGradeLevel> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : Entities.Common.Sample.ISchoolCTEProgram, Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport
    {
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
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolCTEProgram.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolCTEProgram;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.SchoolCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolCTEProgramMapper.MapTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
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
    public class SchoolCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCTEProgram> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolDirectlyOwnedBus table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBus : Entities.Common.Sample.ISchoolDirectlyOwnedBus, Entities.Common.Sample.ISchoolDirectlyOwnedBusSynchronizationSourceSupport
    {
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

        private bool _directlyOwnedBusReferenceExplicitlyAssigned;
        private Bus.Sample.BusReference _directlyOwnedBusReference;
        private Bus.Sample.BusReference ImplicitDirectlyOwnedBusReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_directlyOwnedBusReference == null && !_directlyOwnedBusReferenceExplicitlyAssigned)
                    _directlyOwnedBusReference = new Bus.Sample.BusReference();

                return _directlyOwnedBusReference;
            }
        }

        [DataMember(Name="directlyOwnedBusReference")][NaturalKeyMember]
        public Bus.Sample.BusReference DirectlyOwnedBusReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_directlyOwnedBusReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference;

                return null;
            }
            set
            {
                _directlyOwnedBusReferenceExplicitlyAssigned = true;
                _directlyOwnedBusReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolDirectlyOwnedBus.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
        }

        /// <summary>
        /// The unique identifier for the bus.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusId
        {
            get
            {
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference.BusId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // DirectlyOwnedBus
                _directlyOwnedBusReferenceExplicitlyAssigned = false;
                ImplicitDirectlyOwnedBusReference.BusId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolDirectlyOwnedBus;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

 
            // Referenced Property
            if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId == null
                || !(this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.Equals(compareTo.DirectlyOwnedBusId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
 
                //Referenced Property
                if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId != null) 
                    hash = hash * 23 + (this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
            return Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.MapTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusResourceId 
        { 
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBusPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolDirectlyOwnedBus>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolDirectlyOwnedBus> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.Sample.ISchoolExtension, Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public SchoolExtension()
        {
            SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>();
        }
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.Sample.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the school is exemplary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isExemplary")]
        public bool? IsExemplary { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public SchoolCTEProgram SchoolCTEProgram { get; set; }

        Entities.Common.Sample.ISchoolCTEProgram Entities.Common.Sample.ISchoolExtension.SchoolCTEProgram
        {
            get { return SchoolCTEProgram; }
            set { SchoolCTEProgram = (SchoolCTEProgram) value; }
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
        private ICollection<SchoolDirectlyOwnedBus> _schoolDirectlyOwnedBuses;
        private ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> _schoolDirectlyOwnedBusesCovariant;

        [DataMember(Name="directlyOwnedBuses"), NoDuplicateMembers]
        public ICollection<SchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBuses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolDirectlyOwnedBus>(value,
                    (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this);
                _schoolDirectlyOwnedBuses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.ISchoolDirectlyOwnedBus, SchoolDirectlyOwnedBus>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this;
                _schoolDirectlyOwnedBusesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> Entities.Common.Sample.ISchoolExtension.SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBusesCovariant; }
            set { SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>(value.Cast<SchoolDirectlyOwnedBus>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_schoolDirectlyOwnedBuses != null) foreach (var item in _schoolDirectlyOwnedBuses)
            {
                item.SchoolExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolExtensionMapper.MapTo(this, (Entities.Common.Sample.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsIsExemplarySupported               { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolCTEProgramSupported          { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusesSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.ISchoolDirectlyOwnedBus, bool> Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusIncluded
        { 
            get { return null; }
            set { }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolDirectlyOwnedBusesValidator = new SchoolDirectlyOwnedBusPutPostRequestValidator();

            foreach (var item in instance.SchoolDirectlyOwnedBuses)
            {
                var validationResult = schoolDirectlyOwnedBusesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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

}
// Aggregate: School

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Readable.Extensions.TPDM
{
    /// <summary>
    /// A class which represents the tpdm.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.TPDM.ISchoolExtension, Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.TPDM.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.TPDM.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The federal locale code associated with an education organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="federalLocaleCodeDescriptor")]
        public string FederalLocaleCodeDescriptor { get; set; }

        /// <summary>
        /// An indication of whether a school is identified as an improving school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="improvingSchool")]
        public bool? ImprovingSchool { get; set; }

        /// <summary>
        /// The status of school e.g. priority or focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolStatusDescriptor")]
        public string SchoolStatusDescriptor { get; set; }
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
            return Entities.Common.TPDM.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.TPDM.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.TPDM.SchoolExtensionMapper.MapTo(this, (Entities.Common.TPDM.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsFederalLocaleCodeDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsImprovingSchoolSupported              { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsSchoolStatusDescriptorSupported       { get { return true; } set { } }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
// Aggregate: EducationOrganization

namespace EdFi.Ods.Api.Models.Resources.EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School
{
    /// <summary>
    /// Represents a reference to the EducationOrganization resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "EducationOrganization",
                Href = $"/ed-fi/educationOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new Common.Models.Domain.FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference


    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the edfi.EducationOrganizationAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddress : Entities.Common.EdFi.IEducationOrganizationAddress, Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public EducationOrganizationAddress()
        {
            EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>();
        }
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="city"), NaturalKeyMember]
        public string City { get; set; }

        /// <summary>
        /// The five or nine digit zip code or overseas postal code portion of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="postalCode"), NaturalKeyMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// The abbreviation for the state (within the United States) or outlying area in which an address is located.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="stateAbbreviationDescriptor"), NaturalKeyMember]
        public string StateAbbreviationDescriptor { get; set; }

        /// <summary>
        /// The street number and street name or post office box number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="streetNumberName"), NaturalKeyMember]
        public string StreetNumberName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).City.Equals(compareTo.City)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.Equals(compareTo.PostalCode)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.Equals(compareTo.StateAbbreviationDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.Equals(compareTo.StreetNumberName)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).City.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The apartment, room, or suite number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="apartmentRoomSuiteNumber")]
        public string ApartmentRoomSuiteNumber { get; set; }

        /// <summary>
        /// The number of the building on the site, if more than one building shares the same address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="buildingSiteNumber")]
        public string BuildingSiteNumber { get; set; }

        /// <summary>
        /// The congressional district in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="congressionalDistrict")]
        public string CongressionalDistrict { get; set; }

        /// <summary>
        /// The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="countyFIPSCode")]
        public string CountyFIPSCode { get; set; }

        /// <summary>
        /// An indication that the address should not be published.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="doNotPublishIndicator")]
        public bool? DoNotPublishIndicator { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="localeDescriptor")]
        public string LocaleDescriptor { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// The name of the county, parish, borough, or comparable unit (within a state) in                        'which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfCounty")]
        public string NameOfCounty { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<EducationOrganizationAddressPeriod> _educationOrganizationAddressPeriods;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> _educationOrganizationAddressPeriodsCovariant;

        [DataMember(Name="periods"), NoDuplicateMembers]
        public ICollection<EducationOrganizationAddressPeriod> EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriods; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<EducationOrganizationAddressPeriod>(value,
                    (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this);
                _educationOrganizationAddressPeriods = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, EducationOrganizationAddressPeriod>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this;
                _educationOrganizationAddressPeriodsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriodsCovariant; }
            set { EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>(value.Cast<EducationOrganizationAddressPeriod>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_educationOrganizationAddressPeriods != null) foreach (var item in _educationOrganizationAddressPeriods)
            {
                item.EducationOrganizationAddress = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.EducationOrganizationAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCongressionalDistrictSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodsSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLatitudeSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLocaleDescriptorSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLongitudeSupported                            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsNameOfCountySupported                         { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, bool> Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var educationOrganizationAddressPeriodsValidator = new EducationOrganizationAddressPeriodPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddressPeriods)
            {
                var validationResult = educationOrganizationAddressPeriodsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.EducationOrganizationAddressPeriod table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriod : Entities.Common.EdFi.IEducationOrganizationAddressPeriod, Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganizationAddress _educationOrganizationAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganizationAddress Entities.Common.EdFi.IEducationOrganizationAddressPeriod.EducationOrganizationAddress
        {
            get { return _educationOrganizationAddress; }
            set { SetEducationOrganizationAddress(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganizationAddress EducationOrganizationAddress
        {
            set { SetEducationOrganizationAddress(value); }
        }

        private void SetEducationOrganizationAddress(Entities.Common.EdFi.IEducationOrganizationAddress value)
        {
            _educationOrganizationAddress = value;
        }

        /// <summary>
        /// The month, day, and year for the start of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddressPeriod;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganizationAddress == null || !_educationOrganizationAddress.Equals(compareTo.EducationOrganizationAddress))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.Equals(compareTo.BeginDate)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganizationAddress != null)
                    hash = hash * 23 + _educationOrganizationAddress.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The month, day, and year for the end of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddressPeriod")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport.IsEndDateSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriodPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddressPeriod>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddressPeriod> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationCategory table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategory : Entities.Common.EdFi.IEducationOrganizationCategory, Entities.Common.EdFi.IEducationOrganizationCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationCategory.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationCategoryDescriptor"), NaturalKeyMember]
        public string EducationOrganizationCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.Equals(compareTo.EducationOrganizationCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationCategoryMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationIdentificationCode table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCode : Entities.Common.EdFi.IEducationOrganizationIdentificationCode, Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationIdentificationCode.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The school system, state, or agency assigning the identification code.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationIdentificationSystemDescriptor"), NaturalKeyMember]
        public string EducationOrganizationIdentificationSystemDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationIdentificationCode;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.Equals(compareTo.EducationOrganizationIdentificationSystemDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="identificationCode")]
        public string IdentificationCode { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationIdentificationCode")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport.IsIdentificationCodeSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCodePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationIdentificationCode>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationIdentificationCode> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInstitutionTelephone table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephone : Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of communication number listed for an individual or organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="institutionTelephoneNumberTypeDescriptor"), NaturalKeyMember]
        public string InstitutionTelephoneNumberTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.Equals(compareTo.InstitutionTelephoneNumberTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="telephoneNumber")]
        public string TelephoneNumber { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInstitutionTelephone")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport.IsTelephoneNumberSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInstitutionTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInstitutionTelephone> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference
    {
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


        private Link _link;

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
            return SchoolId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/ed-fi/schools/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the edfi.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.EdFi.ISchool, Entities.Common.EdFi.IEducationOrganization, IHasETag, Entities.Common.EdFi.ISchoolSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public School()
        {
            SchoolCategories = new List<SchoolCategory>();

            // Inherited lists
            EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddress>();
            EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategory>();
            EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCode>();
            EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephone>();
        }
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

        private bool _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned;
        private SchoolYearType.EdFi.SchoolYearTypeReference _charterApprovalSchoolYearTypeReference;
        private SchoolYearType.EdFi.SchoolYearTypeReference ImplicitCharterApprovalSchoolYearTypeReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_charterApprovalSchoolYearTypeReference == null && !_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned)
                    _charterApprovalSchoolYearTypeReference = new SchoolYearType.EdFi.SchoolYearTypeReference();

                return _charterApprovalSchoolYearTypeReference;
            }
        }

        [DataMember(Name="charterApprovalSchoolYearTypeReference")]
        public SchoolYearType.EdFi.SchoolYearTypeReference CharterApprovalSchoolYearTypeReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    return ImplicitCharterApprovalSchoolYearTypeReference;

                return null;
            }
            set
            {
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = true;
                _charterApprovalSchoolYearTypeReference = value;
            }
        }
        private bool _localEducationAgencyReferenceExplicitlyAssigned;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference _localEducationAgencyReference;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference ImplicitLocalEducationAgencyReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_localEducationAgencyReference == null && !_localEducationAgencyReferenceExplicitlyAssigned)
                    _localEducationAgencyReference = new LocalEducationAgency.EdFi.LocalEducationAgencyReference();

                return _localEducationAgencyReference;
            }
        }

        [DataMember(Name="localEducationAgencyReference")]
        public LocalEducationAgency.EdFi.LocalEducationAgencyReference LocalEducationAgencyReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitLocalEducationAgencyReference != null
                    && (_localEducationAgencyReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    return ImplicitLocalEducationAgencyReference;

                return null;
            }
            set
            {
                _localEducationAgencyReferenceExplicitlyAssigned = true;
                _localEducationAgencyReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        int IEducationOrganization.EducationOrganizationId
        {
            get { return SchoolId; }
            set { SchoolId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchool;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Derived Property
            if ((this as Entities.Common.EdFi.ISchool).SchoolId == null
                || !(this as Entities.Common.EdFi.ISchool).SchoolId.Equals(compareTo.SchoolId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
 
                //Derived Property
                if ((this as Entities.Common.EdFi.ISchool).SchoolId != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchool).SchoolId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The full, legally accepted name of the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfInstitution")]
        public string NameOfInstitution { get; set; }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.OperationalStatusDescriptor
        {
            get { return null; }
            set { }
        }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.ShortNameOfInstitution
        {
            get { return default(string); }
            set { }
        }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.WebSite
        {
            get { return default(string); }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.AdministrativeFundingControlDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// The type of agency that approved the establishment or continuation of a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterApprovalAgencyTypeDescriptor")]
        public string CharterApprovalAgencyTypeDescriptor { get; set; }

        /// <summary>
        /// The school year in which a charter school was initially approved.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        short? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYear
        {
            get
            {
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear;
                    }

                return default(short?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // CharterApprovalSchoolYearType
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = false;
                ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear = value.GetValueOrDefault();
            }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.CharterStatusDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// The type of Internet access available.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="internetAccessDescriptor")]
        public string InternetAccessDescriptor { get; set; }

        /// <summary>
        /// The identifier assigned to a local education agency.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int? Entities.Common.EdFi.ISchool.LocalEducationAgencyId
        {
            get
            {
                if (ImplicitLocalEducationAgencyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitLocalEducationAgencyReference.LocalEducationAgencyId;
                    }

                return default(int?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // LocalEducationAgency
                _localEducationAgencyReferenceExplicitlyAssigned = false;
                ImplicitLocalEducationAgencyReference.LocalEducationAgencyId = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2) to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="magnetSpecialProgramEmphasisSchoolDescriptor")]
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }

        /// <summary>
        /// The type of education institution as classified by its primary focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolTypeDescriptor")]
        public string SchoolTypeDescriptor { get; set; }

        /// <summary>
        /// Denotes the Title I Part A designation for the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="titleIPartASchoolDesignationDescriptor")]
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
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
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddress> _educationOrganizationAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> _educationOrganizationAddressesCovariant;

        [DataMember(Name="addresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddress> EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddresses; }
            set
            {
                _educationOrganizationAddresses = value;
                _educationOrganizationAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationAddress, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddressesCovariant; }
            set { EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddress>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategory> _educationOrganizationCategories;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> _educationOrganizationCategoriesCovariant;

        [DataMember(Name="educationOrganizationCategories"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategory> EducationOrganizationCategories
        {
            get { return _educationOrganizationCategories; }
            set
            {
                _educationOrganizationCategories = value;
                _educationOrganizationCategoriesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationCategory, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategory>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationCategories
        {
            get { return _educationOrganizationCategoriesCovariant; }
            set { EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategory>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategory>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodes;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodesCovariant;

        [DataMember(Name="identificationCodes"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCode> EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodes; }
            set
            {
                _educationOrganizationIdentificationCodes = value;
                _educationOrganizationIdentificationCodesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCode>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodesCovariant; }
            set { EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCode>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCode>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephones;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephonesCovariant;

        [DataMember(Name="institutionTelephones"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephone> EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephones; }
            set
            {
                _educationOrganizationInstitutionTelephones = value;
                _educationOrganizationInstitutionTelephonesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephone>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephonesCovariant; }
            set { EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephone>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephone>()); }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInternationalAddresses
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "School")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<SchoolCategory> _schoolCategories;
        private ICollection<Entities.Common.EdFi.ISchoolCategory> _schoolCategoriesCovariant;

        [DataMember(Name="schoolCategories"), NoDuplicateMembers]
        public ICollection<SchoolCategory> SchoolCategories
        {
            get { return _schoolCategories; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolCategory>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this);
                _schoolCategories = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolCategory, SchoolCategory>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this;
                _schoolCategoriesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolCategory> Entities.Common.EdFi.ISchool.SchoolCategories
        {
            get { return _schoolCategoriesCovariant; }
            set { SchoolCategories = new List<SchoolCategory>(value.Cast<SchoolCategory>()); }
        }

        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.ISchoolGradeLevel> Entities.Common.EdFi.ISchool.SchoolGradeLevels
        {
            get { return null; }
            set { }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _educationOrganizationAddresses
            // _educationOrganizationCategories
            // _educationOrganizationIdentificationCodes
            // _educationOrganizationInstitutionTelephones
            if (_schoolCategories != null) foreach (var item in _schoolCategories)
            {
                item.School = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.SchoolMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolMapper.MapTo(this, (Entities.Common.EdFi.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsAdministrativeFundingControlDescriptorSupported        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalAgencyTypeDescriptorSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalSchoolYearSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterStatusDescriptorSupported                       { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressesSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoriesSupported               { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodesSupported      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephonesSupported    { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressesSupported   { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsInternetAccessDescriptorSupported                      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsLocalEducationAgencyIdSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsMagnetSpecialProgramEmphasisSchoolDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsNameOfInstitutionSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsOperationalStatusDescriptorSupported                   { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoriesSupported                              { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelsSupported                             { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolTypeDescriptorSupported                          { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsShortNameOfInstitutionSupported                        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsTitleIPartASchoolDesignationDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsWebSiteSupported                                       { get { return false; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodeIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephoneIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolGradeLevel, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYearTypeResourceId 
        { 
            get { return null; }
            set { ImplicitCharterApprovalSchoolYearTypeReference.ResourceId = value ?? default(Guid); }
        }


        Guid? Entities.Common.EdFi.ISchool.LocalEducationAgencyResourceId 
        { 
            get { return null; }
            set { ImplicitLocalEducationAgencyReference.ResourceId = value ?? default(Guid); }
        }


        // -----------------------------------------------------------------
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

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolCategoriesValidator = new SchoolCategoryPutPostRequestValidator();

            foreach (var item in instance.SchoolCategories)
            {
                var validationResult = schoolCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddresses)
            {
                var validationResult = educationOrganizationAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationCategoriesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationCategoryPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationCategories)
            {
                var validationResult = educationOrganizationCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationIdentificationCodesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationIdentificationCodePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationIdentificationCodes)
            {
                var validationResult = educationOrganizationIdentificationCodesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInstitutionTelephonesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.School.EducationOrganizationInstitutionTelephonePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInstitutionTelephones)
            {
                var validationResult = educationOrganizationInstitutionTelephonesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.SchoolCategory table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCategory : Entities.Common.EdFi.ISchoolCategory, Entities.Common.EdFi.ISchoolCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolCategory.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The one or more categories of school. For example: High School, Middle School, and/or Elementary School.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolCategoryDescriptor"), NaturalKeyMember]
        public string SchoolCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.Equals(compareTo.SchoolCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolCategoryMapper.MapTo(this, (Entities.Common.EdFi.ISchoolCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : Entities.Common.Sample.ISchoolCTEProgram, Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport
    {
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
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolCTEProgram.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolCTEProgram;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.SchoolCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolCTEProgramMapper.MapTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
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
    public class SchoolCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCTEProgram> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolDirectlyOwnedBus table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBus : Entities.Common.Sample.ISchoolDirectlyOwnedBus, Entities.Common.Sample.ISchoolDirectlyOwnedBusSynchronizationSourceSupport
    {
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

        private bool _directlyOwnedBusReferenceExplicitlyAssigned;
        private Bus.Sample.BusReference _directlyOwnedBusReference;
        private Bus.Sample.BusReference ImplicitDirectlyOwnedBusReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_directlyOwnedBusReference == null && !_directlyOwnedBusReferenceExplicitlyAssigned)
                    _directlyOwnedBusReference = new Bus.Sample.BusReference();

                return _directlyOwnedBusReference;
            }
        }

        [DataMember(Name="directlyOwnedBusReference")][NaturalKeyMember]
        public Bus.Sample.BusReference DirectlyOwnedBusReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_directlyOwnedBusReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference;

                return null;
            }
            set
            {
                _directlyOwnedBusReferenceExplicitlyAssigned = true;
                _directlyOwnedBusReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolDirectlyOwnedBus.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
        }

        /// <summary>
        /// The unique identifier for the bus.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusId
        {
            get
            {
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference.BusId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // DirectlyOwnedBus
                _directlyOwnedBusReferenceExplicitlyAssigned = false;
                ImplicitDirectlyOwnedBusReference.BusId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolDirectlyOwnedBus;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

 
            // Referenced Property
            if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId == null
                || !(this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.Equals(compareTo.DirectlyOwnedBusId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
 
                //Referenced Property
                if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId != null) 
                    hash = hash * 23 + (this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
            return Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.MapTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusResourceId 
        { 
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBusPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolDirectlyOwnedBus>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolDirectlyOwnedBus> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.Sample.ISchoolExtension, Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public SchoolExtension()
        {
            SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>();
        }
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.Sample.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the school is exemplary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isExemplary")]
        public bool? IsExemplary { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public SchoolCTEProgram SchoolCTEProgram { get; set; }

        Entities.Common.Sample.ISchoolCTEProgram Entities.Common.Sample.ISchoolExtension.SchoolCTEProgram
        {
            get { return SchoolCTEProgram; }
            set { SchoolCTEProgram = (SchoolCTEProgram) value; }
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
        private ICollection<SchoolDirectlyOwnedBus> _schoolDirectlyOwnedBuses;
        private ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> _schoolDirectlyOwnedBusesCovariant;

        [DataMember(Name="directlyOwnedBuses"), NoDuplicateMembers]
        public ICollection<SchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBuses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolDirectlyOwnedBus>(value,
                    (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this);
                _schoolDirectlyOwnedBuses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.ISchoolDirectlyOwnedBus, SchoolDirectlyOwnedBus>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this;
                _schoolDirectlyOwnedBusesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> Entities.Common.Sample.ISchoolExtension.SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBusesCovariant; }
            set { SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>(value.Cast<SchoolDirectlyOwnedBus>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_schoolDirectlyOwnedBuses != null) foreach (var item in _schoolDirectlyOwnedBuses)
            {
                item.SchoolExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolExtensionMapper.MapTo(this, (Entities.Common.Sample.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsIsExemplarySupported               { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolCTEProgramSupported          { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusesSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.ISchoolDirectlyOwnedBus, bool> Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusIncluded
        { 
            get { return null; }
            set { }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolDirectlyOwnedBusesValidator = new SchoolDirectlyOwnedBusPutPostRequestValidator();

            foreach (var item in instance.SchoolDirectlyOwnedBuses)
            {
                var validationResult = schoolDirectlyOwnedBusesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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

}
// Aggregate: School

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ExcludeOnly_Writable.Extensions.TPDM
{
    /// <summary>
    /// A class which represents the tpdm.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.TPDM.ISchoolExtension, Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.TPDM.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.TPDM.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The federal locale code associated with an education organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="federalLocaleCodeDescriptor")]
        public string FederalLocaleCodeDescriptor { get; set; }

        /// <summary>
        /// An indication of whether a school is identified as an improving school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="improvingSchool")]
        public bool? ImprovingSchool { get; set; }

        /// <summary>
        /// The status of school e.g. priority or focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolStatusDescriptor")]
        public string SchoolStatusDescriptor { get; set; }
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
            return Entities.Common.TPDM.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.TPDM.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.TPDM.SchoolExtensionMapper.MapTo(this, (Entities.Common.TPDM.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsFederalLocaleCodeDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsImprovingSchoolSupported              { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsSchoolStatusDescriptorSupported       { get { return true; } set { } }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
// Aggregate: EducationOrganization

namespace EdFi.Ods.Api.Models.Resources.EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School
{
    /// <summary>
    /// Represents a reference to the EducationOrganization resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "EducationOrganization",
                Href = $"/ed-fi/educationOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new Common.Models.Domain.FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference


    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the edfi.EducationOrganizationAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddress : Entities.Common.EdFi.IEducationOrganizationAddress, Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public EducationOrganizationAddress()
        {
            EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>();
        }
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="city"), NaturalKeyMember]
        public string City { get; set; }

        /// <summary>
        /// The five or nine digit zip code or overseas postal code portion of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="postalCode"), NaturalKeyMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// The abbreviation for the state (within the United States) or outlying area in which an address is located.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="stateAbbreviationDescriptor"), NaturalKeyMember]
        public string StateAbbreviationDescriptor { get; set; }

        /// <summary>
        /// The street number and street name or post office box number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="streetNumberName"), NaturalKeyMember]
        public string StreetNumberName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).City.Equals(compareTo.City)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.Equals(compareTo.PostalCode)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.Equals(compareTo.StateAbbreviationDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.Equals(compareTo.StreetNumberName)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).City.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The apartment, room, or suite number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="apartmentRoomSuiteNumber")]
        public string ApartmentRoomSuiteNumber { get; set; }

        /// <summary>
        /// The number of the building on the site, if more than one building shares the same address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="buildingSiteNumber")]
        public string BuildingSiteNumber { get; set; }

        /// <summary>
        /// The congressional district in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="congressionalDistrict")]
        public string CongressionalDistrict { get; set; }

        /// <summary>
        /// The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="countyFIPSCode")]
        public string CountyFIPSCode { get; set; }

        /// <summary>
        /// An indication that the address should not be published.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="doNotPublishIndicator")]
        public bool? DoNotPublishIndicator { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="localeDescriptor")]
        public string LocaleDescriptor { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// The name of the county, parish, borough, or comparable unit (within a state) in                        'which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfCounty")]
        public string NameOfCounty { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<EducationOrganizationAddressPeriod> _educationOrganizationAddressPeriods;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> _educationOrganizationAddressPeriodsCovariant;

        [DataMember(Name="periods"), NoDuplicateMembers]
        public ICollection<EducationOrganizationAddressPeriod> EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriods; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<EducationOrganizationAddressPeriod>(value,
                    (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this);
                _educationOrganizationAddressPeriods = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, EducationOrganizationAddressPeriod>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this;
                _educationOrganizationAddressPeriodsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriodsCovariant; }
            set { EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>(value.Cast<EducationOrganizationAddressPeriod>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_educationOrganizationAddressPeriods != null) foreach (var item in _educationOrganizationAddressPeriods)
            {
                item.EducationOrganizationAddress = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.EducationOrganizationAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCongressionalDistrictSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodsSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLatitudeSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLocaleDescriptorSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLongitudeSupported                            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsNameOfCountySupported                         { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, bool> Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var educationOrganizationAddressPeriodsValidator = new EducationOrganizationAddressPeriodPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddressPeriods)
            {
                var validationResult = educationOrganizationAddressPeriodsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.EducationOrganizationAddressPeriod table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriod : Entities.Common.EdFi.IEducationOrganizationAddressPeriod, Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganizationAddress _educationOrganizationAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganizationAddress Entities.Common.EdFi.IEducationOrganizationAddressPeriod.EducationOrganizationAddress
        {
            get { return _educationOrganizationAddress; }
            set { SetEducationOrganizationAddress(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganizationAddress EducationOrganizationAddress
        {
            set { SetEducationOrganizationAddress(value); }
        }

        private void SetEducationOrganizationAddress(Entities.Common.EdFi.IEducationOrganizationAddress value)
        {
            _educationOrganizationAddress = value;
        }

        /// <summary>
        /// The month, day, and year for the start of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddressPeriod;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganizationAddress == null || !_educationOrganizationAddress.Equals(compareTo.EducationOrganizationAddress))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.Equals(compareTo.BeginDate)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganizationAddress != null)
                    hash = hash * 23 + _educationOrganizationAddress.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The month, day, and year for the end of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddressPeriod")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport.IsEndDateSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriodPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddressPeriod>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddressPeriod> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Readable
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference
    {
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


        private Link _link;

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
            return SchoolId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/ed-fi/schools/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the edfi.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.EdFi.ISchool, Entities.Common.EdFi.IEducationOrganization, IHasETag, Entities.Common.EdFi.ISchoolSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public School()
        {
            SchoolCategories = new List<SchoolCategory>();

            // Inherited lists
            EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddress>();
        }
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

        private bool _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned;
        private SchoolYearType.EdFi.SchoolYearTypeReference _charterApprovalSchoolYearTypeReference;
        private SchoolYearType.EdFi.SchoolYearTypeReference ImplicitCharterApprovalSchoolYearTypeReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_charterApprovalSchoolYearTypeReference == null && !_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned)
                    _charterApprovalSchoolYearTypeReference = new SchoolYearType.EdFi.SchoolYearTypeReference();

                return _charterApprovalSchoolYearTypeReference;
            }
        }

        [DataMember(Name="charterApprovalSchoolYearTypeReference")]
        public SchoolYearType.EdFi.SchoolYearTypeReference CharterApprovalSchoolYearTypeReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    return ImplicitCharterApprovalSchoolYearTypeReference;

                return null;
            }
            set
            {
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = true;
                _charterApprovalSchoolYearTypeReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        int IEducationOrganization.EducationOrganizationId
        {
            get { return SchoolId; }
            set { SchoolId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchool;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Derived Property
            if ((this as Entities.Common.EdFi.ISchool).SchoolId == null
                || !(this as Entities.Common.EdFi.ISchool).SchoolId.Equals(compareTo.SchoolId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
 
                //Derived Property
                if ((this as Entities.Common.EdFi.ISchool).SchoolId != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchool).SchoolId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The full, legally accepted name of the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfInstitution")]
        public string NameOfInstitution { get; set; }

        /// <summary>
        /// The current operational status of the EducationOrganization (e.g., active, inactive).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="operationalStatusDescriptor")]
        public string OperationalStatusDescriptor { get; set; }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.ShortNameOfInstitution
        {
            get { return default(string); }
            set { }
        }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.WebSite
        {
            get { return default(string); }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The type of education institution as classified by its funding source, for example public or private.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="administrativeFundingControlDescriptor")]
        public string AdministrativeFundingControlDescriptor { get; set; }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.CharterApprovalAgencyTypeDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// The school year in which a charter school was initially approved.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        short? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYear
        {
            get
            {
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear;
                    }

                return default(short?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // CharterApprovalSchoolYearType
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = false;
                ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear = value.GetValueOrDefault();
            }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.CharterStatusDescriptor
        {
            get { return null; }
            set { }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.InternetAccessDescriptor
        {
            get { return null; }
            set { }
        }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        int? Entities.Common.EdFi.ISchool.LocalEducationAgencyId
        {
            get { return default(int?); }
            set { }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.MagnetSpecialProgramEmphasisSchoolDescriptor
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// The type of education institution as classified by its primary focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolTypeDescriptor")]
        public string SchoolTypeDescriptor { get; set; }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.TitleIPartASchoolDesignationDescriptor
        {
            get { return null; }
            set { }
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
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddress> _educationOrganizationAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> _educationOrganizationAddressesCovariant;

        [DataMember(Name="addresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddress> EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddresses; }
            set
            {
                _educationOrganizationAddresses = value;
                _educationOrganizationAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationAddress, EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddressesCovariant; }
            set { EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddress>()); }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationCategories
        {
            get { return null; }
            set { }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationIdentificationCodes
        {
            get { return null; }
            set { }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInstitutionTelephones
        {
            get { return null; }
            set { }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInternationalAddresses
        {
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "School")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<SchoolCategory> _schoolCategories;
        private ICollection<Entities.Common.EdFi.ISchoolCategory> _schoolCategoriesCovariant;

        [DataMember(Name="schoolCategories"), NoDuplicateMembers]
        public ICollection<SchoolCategory> SchoolCategories
        {
            get { return _schoolCategories; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolCategory>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this);
                _schoolCategories = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolCategory, SchoolCategory>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this;
                _schoolCategoriesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolCategory> Entities.Common.EdFi.ISchool.SchoolCategories
        {
            get { return _schoolCategoriesCovariant; }
            set { SchoolCategories = new List<SchoolCategory>(value.Cast<SchoolCategory>()); }
        }

        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.ISchoolGradeLevel> Entities.Common.EdFi.ISchool.SchoolGradeLevels
        {
            get { return null; }
            set { }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _educationOrganizationAddresses
            if (_schoolCategories != null) foreach (var item in _schoolCategories)
            {
                item.School = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.SchoolMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolMapper.MapTo(this, (Entities.Common.EdFi.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsAdministrativeFundingControlDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalAgencyTypeDescriptorSupported           { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalSchoolYearSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterStatusDescriptorSupported                       { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressesSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoriesSupported               { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodesSupported      { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephonesSupported    { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressesSupported   { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsInternetAccessDescriptorSupported                      { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsLocalEducationAgencyIdSupported                        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsMagnetSpecialProgramEmphasisSchoolDescriptorSupported  { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsNameOfInstitutionSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsOperationalStatusDescriptorSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoriesSupported                              { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelsSupported                             { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolTypeDescriptorSupported                          { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsShortNameOfInstitutionSupported                        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsTitleIPartASchoolDesignationDescriptorSupported        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsWebSiteSupported                                       { get { return false; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodeIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephoneIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolGradeLevel, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYearTypeResourceId 
        { 
            get { return null; }
            set { ImplicitCharterApprovalSchoolYearTypeReference.ResourceId = value ?? default(Guid); }
        }


        Guid? Entities.Common.EdFi.ISchool.LocalEducationAgencyResourceId 
        { 
            get { return null; }
            // Profile excluded the Reference
            set { }
        }


        // -----------------------------------------------------------------
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

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolCategoriesValidator = new SchoolCategoryPutPostRequestValidator();

            foreach (var item in instance.SchoolCategories)
            {
                var validationResult = schoolCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Readable.School.EducationOrganizationAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddresses)
            {
                var validationResult = educationOrganizationAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.SchoolCategory table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCategory : Entities.Common.EdFi.ISchoolCategory, Entities.Common.EdFi.ISchoolCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolCategory.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The one or more categories of school. For example: High School, Middle School, and/or Elementary School.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolCategoryDescriptor"), NaturalKeyMember]
        public string SchoolCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.Equals(compareTo.SchoolCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolCategoryMapper.MapTo(this, (Entities.Common.EdFi.ISchoolCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
// Aggregate: EducationOrganization

namespace EdFi.Ods.Api.Models.Resources.EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School
{
    /// <summary>
    /// Represents a reference to the EducationOrganization resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "EducationOrganization",
                Href = $"/ed-fi/educationOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new Common.Models.Domain.FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference


    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the edfi.EducationOrganizationInternationalAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddress : Entities.Common.EdFi.IEducationOrganizationInternationalAddress, Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInternationalAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInternationalAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The first line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine3")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The fourth line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine4")]
        public string AddressLine4 { get; set; }

        /// <summary>
        /// The first date the address is valid. For physical addresses, the date the person moved to that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="countryDescriptor")]
        public string CountryDescriptor { get; set; }

        /// <summary>
        /// The last date the address is valid. For physical addresses, this would be the date the person moved from that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInternationalAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine1Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine2Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine3Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine4Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsBeginDateSupported          { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsCountryDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsEndDateSupported            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLatitudeSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLongitudeSupported          { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInternationalAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInternationalAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_IncludeOnly_Writable
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference
    {
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


        private Link _link;

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
            return SchoolId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/ed-fi/schools/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the edfi.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.EdFi.ISchool, Entities.Common.EdFi.IEducationOrganization, IHasETag, Entities.Common.EdFi.ISchoolSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public School()
        {
            SchoolGradeLevels = new List<SchoolGradeLevel>();

            // Inherited lists
            EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddress>();
        }
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
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        int IEducationOrganization.EducationOrganizationId
        {
            get { return SchoolId; }
            set { SchoolId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchool;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Derived Property
            if ((this as Entities.Common.EdFi.ISchool).SchoolId == null
                || !(this as Entities.Common.EdFi.ISchool).SchoolId.Equals(compareTo.SchoolId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
 
                //Derived Property
                if ((this as Entities.Common.EdFi.ISchool).SchoolId != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchool).SchoolId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.IEducationOrganization.NameOfInstitution
        {
            get { return default(string); }
            set { }
        }

        /// <summary>
        /// The current operational status of the EducationOrganization (e.g., active, inactive).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="operationalStatusDescriptor")]
        public string OperationalStatusDescriptor { get; set; }

        /// <summary>
        /// A short name for the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortNameOfInstitution")]
        public string ShortNameOfInstitution { get; set; }

        /// <summary>
        /// The public web site address (URL) for the EducationOrganization.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="webSite")]
        public string WebSite { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The type of education institution as classified by its funding source, for example public or private.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="administrativeFundingControlDescriptor")]
        public string AdministrativeFundingControlDescriptor { get; set; }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.CharterApprovalAgencyTypeDescriptor
        {
            get { return null; }
            set { }
        }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        short? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYear
        {
            get { return default(short?); }
            set { }
        }

        /// <summary>
        /// A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterStatusDescriptor")]
        public string CharterStatusDescriptor { get; set; }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.InternetAccessDescriptor
        {
            get { return null; }
            set { }
        }

        // NOT a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        int? Entities.Common.EdFi.ISchool.LocalEducationAgencyId
        {
            get { return default(int?); }
            set { }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.MagnetSpecialProgramEmphasisSchoolDescriptor
        {
            get { return null; }
            set { }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.SchoolTypeDescriptor
        {
            get { return null; }
            set { }
        }

        // IS a lookup column, Not supported by this model, so there's "null object pattern" style implementation
        string Entities.Common.EdFi.ISchool.TitleIPartASchoolDesignationDescriptor
        {
            get { return null; }
            set { }
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
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationAddresses
        {
            get { return null; }
            set { }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationCategories
        {
            get { return null; }
            set { }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationIdentificationCodes
        {
            get { return null; }
            set { }
        }
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInstitutionTelephones
        {
            get { return null; }
            set { }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddress> _educationOrganizationInternationalAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> _educationOrganizationInternationalAddressesCovariant;

        [DataMember(Name="internationalAddresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddress> EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddresses; }
            set
            {
                _educationOrganizationInternationalAddresses = value;
                _educationOrganizationInternationalAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddressesCovariant; }
            set { EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddress>()); }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "School")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        // Not supported by this model, so there's "null object pattern" style implementation
        ICollection<Entities.Common.EdFi.ISchoolCategory> Entities.Common.EdFi.ISchool.SchoolCategories
        {
            get { return null; }
            set { }
        }

        private ICollection<SchoolGradeLevel> _schoolGradeLevels;
        private ICollection<Entities.Common.EdFi.ISchoolGradeLevel> _schoolGradeLevelsCovariant;

        [DataMember(Name="gradeLevels"), NoDuplicateMembers]
        public ICollection<SchoolGradeLevel> SchoolGradeLevels
        {
            get { return _schoolGradeLevels; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolGradeLevel>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this);
                _schoolGradeLevels = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolGradeLevel, SchoolGradeLevel>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this;
                _schoolGradeLevelsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolGradeLevel> Entities.Common.EdFi.ISchool.SchoolGradeLevels
        {
            get { return _schoolGradeLevelsCovariant; }
            set { SchoolGradeLevels = new List<SchoolGradeLevel>(value.Cast<SchoolGradeLevel>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _educationOrganizationInternationalAddresses
            if (_schoolGradeLevels != null) foreach (var item in _schoolGradeLevels)
            {
                item.School = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.SchoolMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolMapper.MapTo(this, (Entities.Common.EdFi.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsAdministrativeFundingControlDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalAgencyTypeDescriptorSupported           { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalSchoolYearSupported                     { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterStatusDescriptorSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressesSupported                { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoriesSupported               { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodesSupported      { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephonesSupported    { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressesSupported   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsInternetAccessDescriptorSupported                      { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsLocalEducationAgencyIdSupported                        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsMagnetSpecialProgramEmphasisSchoolDescriptorSupported  { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsNameOfInstitutionSupported                             { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsOperationalStatusDescriptorSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoriesSupported                              { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelsSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolTypeDescriptorSupported                          { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsShortNameOfInstitutionSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsTitleIPartASchoolDesignationDescriptorSupported        { get { return false; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsWebSiteSupported                                       { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodeIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephoneIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolGradeLevel, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYearTypeResourceId 
        { 
            get { return null; }
            // Profile excluded the Reference
            set { }
        }


        Guid? Entities.Common.EdFi.ISchool.LocalEducationAgencyResourceId 
        { 
            get { return null; }
            // Profile excluded the Reference
            set { }
        }


        // -----------------------------------------------------------------
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

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolGradeLevelsValidator = new SchoolGradeLevelPutPostRequestValidator();

            foreach (var item in instance.SchoolGradeLevels)
            {
                var validationResult = schoolGradeLevelsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInternationalAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_IncludeOnly_Writable.School.EducationOrganizationInternationalAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInternationalAddresses)
            {
                var validationResult = educationOrganizationInternationalAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.SchoolGradeLevel table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevel : Entities.Common.EdFi.ISchoolGradeLevel, Entities.Common.EdFi.ISchoolGradeLevelSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolGradeLevel.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The grade levels served at the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="gradeLevelDescriptor"), NaturalKeyMember]
        public string GradeLevelDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolGradeLevel;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.Equals(compareTo.GradeLevelDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolGradeLevel")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolGradeLevelMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolGradeLevelMapper.MapTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return false; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevelPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolGradeLevel>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolGradeLevel> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
// Aggregate: EducationOrganization

namespace EdFi.Ods.Api.Models.Resources.EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School
{
    /// <summary>
    /// Represents a reference to the EducationOrganization resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "EducationOrganization",
                Href = $"/ed-fi/educationOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new Common.Models.Domain.FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference


    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the edfi.EducationOrganizationAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddress : Entities.Common.EdFi.IEducationOrganizationAddress, Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public EducationOrganizationAddress()
        {
            EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>();
        }
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="city"), NaturalKeyMember]
        public string City { get; set; }

        /// <summary>
        /// The five or nine digit zip code or overseas postal code portion of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="postalCode"), NaturalKeyMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// The abbreviation for the state (within the United States) or outlying area in which an address is located.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="stateAbbreviationDescriptor"), NaturalKeyMember]
        public string StateAbbreviationDescriptor { get; set; }

        /// <summary>
        /// The street number and street name or post office box number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="streetNumberName"), NaturalKeyMember]
        public string StreetNumberName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).City.Equals(compareTo.City)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.Equals(compareTo.PostalCode)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.Equals(compareTo.StateAbbreviationDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.Equals(compareTo.StreetNumberName)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).City.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The apartment, room, or suite number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="apartmentRoomSuiteNumber")]
        public string ApartmentRoomSuiteNumber { get; set; }

        /// <summary>
        /// The number of the building on the site, if more than one building shares the same address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="buildingSiteNumber")]
        public string BuildingSiteNumber { get; set; }

        /// <summary>
        /// The congressional district in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="congressionalDistrict")]
        public string CongressionalDistrict { get; set; }

        /// <summary>
        /// The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="countyFIPSCode")]
        public string CountyFIPSCode { get; set; }

        /// <summary>
        /// An indication that the address should not be published.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="doNotPublishIndicator")]
        public bool? DoNotPublishIndicator { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="localeDescriptor")]
        public string LocaleDescriptor { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// The name of the county, parish, borough, or comparable unit (within a state) in                        'which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfCounty")]
        public string NameOfCounty { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<EducationOrganizationAddressPeriod> _educationOrganizationAddressPeriods;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> _educationOrganizationAddressPeriodsCovariant;

        [DataMember(Name="periods"), NoDuplicateMembers]
        public ICollection<EducationOrganizationAddressPeriod> EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriods; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<EducationOrganizationAddressPeriod>(value,
                    (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this);
                _educationOrganizationAddressPeriods = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, EducationOrganizationAddressPeriod>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this;
                _educationOrganizationAddressPeriodsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriodsCovariant; }
            set { EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>(value.Cast<EducationOrganizationAddressPeriod>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_educationOrganizationAddressPeriods != null) foreach (var item in _educationOrganizationAddressPeriods)
            {
                item.EducationOrganizationAddress = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.EducationOrganizationAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCongressionalDistrictSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodsSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLatitudeSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLocaleDescriptorSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLongitudeSupported                            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsNameOfCountySupported                         { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, bool> Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var educationOrganizationAddressPeriodsValidator = new EducationOrganizationAddressPeriodPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddressPeriods)
            {
                var validationResult = educationOrganizationAddressPeriodsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.EducationOrganizationAddressPeriod table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriod : Entities.Common.EdFi.IEducationOrganizationAddressPeriod, Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganizationAddress _educationOrganizationAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganizationAddress Entities.Common.EdFi.IEducationOrganizationAddressPeriod.EducationOrganizationAddress
        {
            get { return _educationOrganizationAddress; }
            set { SetEducationOrganizationAddress(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganizationAddress EducationOrganizationAddress
        {
            set { SetEducationOrganizationAddress(value); }
        }

        private void SetEducationOrganizationAddress(Entities.Common.EdFi.IEducationOrganizationAddress value)
        {
            _educationOrganizationAddress = value;
        }

        /// <summary>
        /// The month, day, and year for the start of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddressPeriod;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganizationAddress == null || !_educationOrganizationAddress.Equals(compareTo.EducationOrganizationAddress))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.Equals(compareTo.BeginDate)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganizationAddress != null)
                    hash = hash * 23 + _educationOrganizationAddress.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The month, day, and year for the end of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddressPeriod")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport.IsEndDateSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriodPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddressPeriod>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddressPeriod> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationCategory table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategory : Entities.Common.EdFi.IEducationOrganizationCategory, Entities.Common.EdFi.IEducationOrganizationCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationCategory.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationCategoryDescriptor"), NaturalKeyMember]
        public string EducationOrganizationCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.Equals(compareTo.EducationOrganizationCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationCategoryMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationIdentificationCode table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCode : Entities.Common.EdFi.IEducationOrganizationIdentificationCode, Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationIdentificationCode.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The school system, state, or agency assigning the identification code.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationIdentificationSystemDescriptor"), NaturalKeyMember]
        public string EducationOrganizationIdentificationSystemDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationIdentificationCode;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.Equals(compareTo.EducationOrganizationIdentificationSystemDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="identificationCode")]
        public string IdentificationCode { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationIdentificationCode")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport.IsIdentificationCodeSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCodePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationIdentificationCode>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationIdentificationCode> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInstitutionTelephone table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephone : Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of communication number listed for an individual or organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="institutionTelephoneNumberTypeDescriptor"), NaturalKeyMember]
        public string InstitutionTelephoneNumberTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.Equals(compareTo.InstitutionTelephoneNumberTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="telephoneNumber")]
        public string TelephoneNumber { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInstitutionTelephone")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport.IsTelephoneNumberSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInstitutionTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInstitutionTelephone> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInternationalAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddress : Entities.Common.EdFi.IEducationOrganizationInternationalAddress, Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInternationalAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInternationalAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The first line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine3")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The fourth line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine4")]
        public string AddressLine4 { get; set; }

        /// <summary>
        /// The first date the address is valid. For physical addresses, the date the person moved to that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="countryDescriptor")]
        public string CountryDescriptor { get; set; }

        /// <summary>
        /// The last date the address is valid. For physical addresses, this would be the date the person moved from that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInternationalAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine1Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine2Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine3Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine4Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsBeginDateSupported          { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsCountryDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsEndDateSupported            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLatitudeSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLongitudeSupported          { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInternationalAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInternationalAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ReadOnly_Readable
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference
    {
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


        private Link _link;

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
            return SchoolId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/ed-fi/schools/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the edfi.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.EdFi.ISchool, Entities.Common.EdFi.IEducationOrganization, IHasETag, Entities.Common.EdFi.ISchoolSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public School()
        {
            SchoolCategories = new List<SchoolCategory>();
            SchoolGradeLevels = new List<SchoolGradeLevel>();

            // Inherited lists
            EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddress>();
            EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategory>();
            EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCode>();
            EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephone>();
            EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddress>();
        }
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

        private bool _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned;
        private SchoolYearType.EdFi.SchoolYearTypeReference _charterApprovalSchoolYearTypeReference;
        private SchoolYearType.EdFi.SchoolYearTypeReference ImplicitCharterApprovalSchoolYearTypeReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_charterApprovalSchoolYearTypeReference == null && !_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned)
                    _charterApprovalSchoolYearTypeReference = new SchoolYearType.EdFi.SchoolYearTypeReference();

                return _charterApprovalSchoolYearTypeReference;
            }
        }

        [DataMember(Name="charterApprovalSchoolYearTypeReference")]
        public SchoolYearType.EdFi.SchoolYearTypeReference CharterApprovalSchoolYearTypeReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    return ImplicitCharterApprovalSchoolYearTypeReference;

                return null;
            }
            set
            {
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = true;
                _charterApprovalSchoolYearTypeReference = value;
            }
        }
        private bool _localEducationAgencyReferenceExplicitlyAssigned;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference _localEducationAgencyReference;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference ImplicitLocalEducationAgencyReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_localEducationAgencyReference == null && !_localEducationAgencyReferenceExplicitlyAssigned)
                    _localEducationAgencyReference = new LocalEducationAgency.EdFi.LocalEducationAgencyReference();

                return _localEducationAgencyReference;
            }
        }

        [DataMember(Name="localEducationAgencyReference")]
        public LocalEducationAgency.EdFi.LocalEducationAgencyReference LocalEducationAgencyReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitLocalEducationAgencyReference != null
                    && (_localEducationAgencyReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    return ImplicitLocalEducationAgencyReference;

                return null;
            }
            set
            {
                _localEducationAgencyReferenceExplicitlyAssigned = true;
                _localEducationAgencyReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        int IEducationOrganization.EducationOrganizationId
        {
            get { return SchoolId; }
            set { SchoolId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchool;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Derived Property
            if ((this as Entities.Common.EdFi.ISchool).SchoolId == null
                || !(this as Entities.Common.EdFi.ISchool).SchoolId.Equals(compareTo.SchoolId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
 
                //Derived Property
                if ((this as Entities.Common.EdFi.ISchool).SchoolId != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchool).SchoolId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The full, legally accepted name of the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfInstitution")]
        public string NameOfInstitution { get; set; }

        /// <summary>
        /// The current operational status of the EducationOrganization (e.g., active, inactive).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="operationalStatusDescriptor")]
        public string OperationalStatusDescriptor { get; set; }

        /// <summary>
        /// A short name for the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortNameOfInstitution")]
        public string ShortNameOfInstitution { get; set; }

        /// <summary>
        /// The public web site address (URL) for the EducationOrganization.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="webSite")]
        public string WebSite { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The type of education institution as classified by its funding source, for example public or private.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="administrativeFundingControlDescriptor")]
        public string AdministrativeFundingControlDescriptor { get; set; }

        /// <summary>
        /// The type of agency that approved the establishment or continuation of a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterApprovalAgencyTypeDescriptor")]
        public string CharterApprovalAgencyTypeDescriptor { get; set; }

        /// <summary>
        /// The school year in which a charter school was initially approved.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        short? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYear
        {
            get
            {
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear;
                    }

                return default(short?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // CharterApprovalSchoolYearType
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = false;
                ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterStatusDescriptor")]
        public string CharterStatusDescriptor { get; set; }

        /// <summary>
        /// The type of Internet access available.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="internetAccessDescriptor")]
        public string InternetAccessDescriptor { get; set; }

        /// <summary>
        /// The identifier assigned to a local education agency.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int? Entities.Common.EdFi.ISchool.LocalEducationAgencyId
        {
            get
            {
                if (ImplicitLocalEducationAgencyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitLocalEducationAgencyReference.LocalEducationAgencyId;
                    }

                return default(int?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // LocalEducationAgency
                _localEducationAgencyReferenceExplicitlyAssigned = false;
                ImplicitLocalEducationAgencyReference.LocalEducationAgencyId = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2) to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="magnetSpecialProgramEmphasisSchoolDescriptor")]
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }

        /// <summary>
        /// The type of education institution as classified by its primary focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolTypeDescriptor")]
        public string SchoolTypeDescriptor { get; set; }

        /// <summary>
        /// Denotes the Title I Part A designation for the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="titleIPartASchoolDesignationDescriptor")]
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
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
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddress> _educationOrganizationAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> _educationOrganizationAddressesCovariant;

        [DataMember(Name="addresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddress> EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddresses; }
            set
            {
                _educationOrganizationAddresses = value;
                _educationOrganizationAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationAddress, EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddressesCovariant; }
            set { EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddress>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategory> _educationOrganizationCategories;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> _educationOrganizationCategoriesCovariant;

        [DataMember(Name="educationOrganizationCategories"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategory> EducationOrganizationCategories
        {
            get { return _educationOrganizationCategories; }
            set
            {
                _educationOrganizationCategories = value;
                _educationOrganizationCategoriesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationCategory, EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategory>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationCategories
        {
            get { return _educationOrganizationCategoriesCovariant; }
            set { EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategory>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategory>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodes;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodesCovariant;

        [DataMember(Name="identificationCodes"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCode> EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodes; }
            set
            {
                _educationOrganizationIdentificationCodes = value;
                _educationOrganizationIdentificationCodesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCode>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodesCovariant; }
            set { EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCode>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCode>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephones;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephonesCovariant;

        [DataMember(Name="institutionTelephones"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephone> EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephones; }
            set
            {
                _educationOrganizationInstitutionTelephones = value;
                _educationOrganizationInstitutionTelephonesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephone>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephonesCovariant; }
            set { EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephone>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephone>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddress> _educationOrganizationInternationalAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> _educationOrganizationInternationalAddressesCovariant;

        [DataMember(Name="internationalAddresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddress> EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddresses; }
            set
            {
                _educationOrganizationInternationalAddresses = value;
                _educationOrganizationInternationalAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddressesCovariant; }
            set { EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddress>()); }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "School")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<SchoolCategory> _schoolCategories;
        private ICollection<Entities.Common.EdFi.ISchoolCategory> _schoolCategoriesCovariant;

        [DataMember(Name="schoolCategories"), NoDuplicateMembers]
        public ICollection<SchoolCategory> SchoolCategories
        {
            get { return _schoolCategories; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolCategory>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this);
                _schoolCategories = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolCategory, SchoolCategory>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this;
                _schoolCategoriesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolCategory> Entities.Common.EdFi.ISchool.SchoolCategories
        {
            get { return _schoolCategoriesCovariant; }
            set { SchoolCategories = new List<SchoolCategory>(value.Cast<SchoolCategory>()); }
        }

        private ICollection<SchoolGradeLevel> _schoolGradeLevels;
        private ICollection<Entities.Common.EdFi.ISchoolGradeLevel> _schoolGradeLevelsCovariant;

        [DataMember(Name="gradeLevels"), NoDuplicateMembers]
        public ICollection<SchoolGradeLevel> SchoolGradeLevels
        {
            get { return _schoolGradeLevels; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolGradeLevel>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this);
                _schoolGradeLevels = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolGradeLevel, SchoolGradeLevel>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this;
                _schoolGradeLevelsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolGradeLevel> Entities.Common.EdFi.ISchool.SchoolGradeLevels
        {
            get { return _schoolGradeLevelsCovariant; }
            set { SchoolGradeLevels = new List<SchoolGradeLevel>(value.Cast<SchoolGradeLevel>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _educationOrganizationAddresses
            // _educationOrganizationCategories
            // _educationOrganizationIdentificationCodes
            // _educationOrganizationInstitutionTelephones
            // _educationOrganizationInternationalAddresses
            if (_schoolCategories != null) foreach (var item in _schoolCategories)
            {
                item.School = this;
            }

            if (_schoolGradeLevels != null) foreach (var item in _schoolGradeLevels)
            {
                item.School = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.SchoolMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolMapper.MapTo(this, (Entities.Common.EdFi.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsAdministrativeFundingControlDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalAgencyTypeDescriptorSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalSchoolYearSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterStatusDescriptorSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressesSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoriesSupported               { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodesSupported      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephonesSupported    { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressesSupported   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsInternetAccessDescriptorSupported                      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsLocalEducationAgencyIdSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsMagnetSpecialProgramEmphasisSchoolDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsNameOfInstitutionSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsOperationalStatusDescriptorSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoriesSupported                              { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelsSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolTypeDescriptorSupported                          { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsShortNameOfInstitutionSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsTitleIPartASchoolDesignationDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsWebSiteSupported                                       { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodeIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephoneIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolGradeLevel, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYearTypeResourceId 
        { 
            get { return null; }
            set { ImplicitCharterApprovalSchoolYearTypeReference.ResourceId = value ?? default(Guid); }
        }


        Guid? Entities.Common.EdFi.ISchool.LocalEducationAgencyResourceId 
        { 
            get { return null; }
            set { ImplicitLocalEducationAgencyReference.ResourceId = value ?? default(Guid); }
        }


        // -----------------------------------------------------------------
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

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolCategoriesValidator = new SchoolCategoryPutPostRequestValidator();

            foreach (var item in instance.SchoolCategories)
            {
                var validationResult = schoolCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var schoolGradeLevelsValidator = new SchoolGradeLevelPutPostRequestValidator();

            foreach (var item in instance.SchoolGradeLevels)
            {
                var validationResult = schoolGradeLevelsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddresses)
            {
                var validationResult = educationOrganizationAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationCategoriesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationCategoryPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationCategories)
            {
                var validationResult = educationOrganizationCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationIdentificationCodesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationIdentificationCodePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationIdentificationCodes)
            {
                var validationResult = educationOrganizationIdentificationCodesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInstitutionTelephonesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInstitutionTelephonePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInstitutionTelephones)
            {
                var validationResult = educationOrganizationInstitutionTelephonesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInternationalAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_ReadOnly_Readable.School.EducationOrganizationInternationalAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInternationalAddresses)
            {
                var validationResult = educationOrganizationInternationalAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.SchoolCategory table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCategory : Entities.Common.EdFi.ISchoolCategory, Entities.Common.EdFi.ISchoolCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolCategory.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The one or more categories of school. For example: High School, Middle School, and/or Elementary School.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolCategoryDescriptor"), NaturalKeyMember]
        public string SchoolCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.Equals(compareTo.SchoolCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolCategoryMapper.MapTo(this, (Entities.Common.EdFi.ISchoolCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.SchoolGradeLevel table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevel : Entities.Common.EdFi.ISchoolGradeLevel, Entities.Common.EdFi.ISchoolGradeLevelSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolGradeLevel.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The grade levels served at the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="gradeLevelDescriptor"), NaturalKeyMember]
        public string GradeLevelDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolGradeLevel;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.Equals(compareTo.GradeLevelDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolGradeLevel")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolGradeLevelMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolGradeLevelMapper.MapTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevelPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolGradeLevel>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolGradeLevel> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ReadOnly_Readable.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : Entities.Common.Sample.ISchoolCTEProgram, Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport
    {
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
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolCTEProgram.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolCTEProgram;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.SchoolCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolCTEProgramMapper.MapTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
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
    public class SchoolCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCTEProgram> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolDirectlyOwnedBus table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBus : Entities.Common.Sample.ISchoolDirectlyOwnedBus, Entities.Common.Sample.ISchoolDirectlyOwnedBusSynchronizationSourceSupport
    {
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

        private bool _directlyOwnedBusReferenceExplicitlyAssigned;
        private Bus.Sample.BusReference _directlyOwnedBusReference;
        private Bus.Sample.BusReference ImplicitDirectlyOwnedBusReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_directlyOwnedBusReference == null && !_directlyOwnedBusReferenceExplicitlyAssigned)
                    _directlyOwnedBusReference = new Bus.Sample.BusReference();

                return _directlyOwnedBusReference;
            }
        }

        [DataMember(Name="directlyOwnedBusReference")][NaturalKeyMember]
        public Bus.Sample.BusReference DirectlyOwnedBusReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_directlyOwnedBusReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference;

                return null;
            }
            set
            {
                _directlyOwnedBusReferenceExplicitlyAssigned = true;
                _directlyOwnedBusReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolDirectlyOwnedBus.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
        }

        /// <summary>
        /// The unique identifier for the bus.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusId
        {
            get
            {
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference.BusId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // DirectlyOwnedBus
                _directlyOwnedBusReferenceExplicitlyAssigned = false;
                ImplicitDirectlyOwnedBusReference.BusId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolDirectlyOwnedBus;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

 
            // Referenced Property
            if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId == null
                || !(this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.Equals(compareTo.DirectlyOwnedBusId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
 
                //Referenced Property
                if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId != null) 
                    hash = hash * 23 + (this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
            return Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.MapTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusResourceId 
        { 
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBusPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolDirectlyOwnedBus>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolDirectlyOwnedBus> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.Sample.ISchoolExtension, Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public SchoolExtension()
        {
            SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>();
        }
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.Sample.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the school is exemplary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isExemplary")]
        public bool? IsExemplary { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public SchoolCTEProgram SchoolCTEProgram { get; set; }

        Entities.Common.Sample.ISchoolCTEProgram Entities.Common.Sample.ISchoolExtension.SchoolCTEProgram
        {
            get { return SchoolCTEProgram; }
            set { SchoolCTEProgram = (SchoolCTEProgram) value; }
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
        private ICollection<SchoolDirectlyOwnedBus> _schoolDirectlyOwnedBuses;
        private ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> _schoolDirectlyOwnedBusesCovariant;

        [DataMember(Name="directlyOwnedBuses"), NoDuplicateMembers]
        public ICollection<SchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBuses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolDirectlyOwnedBus>(value,
                    (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this);
                _schoolDirectlyOwnedBuses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.ISchoolDirectlyOwnedBus, SchoolDirectlyOwnedBus>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this;
                _schoolDirectlyOwnedBusesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> Entities.Common.Sample.ISchoolExtension.SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBusesCovariant; }
            set { SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>(value.Cast<SchoolDirectlyOwnedBus>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_schoolDirectlyOwnedBuses != null) foreach (var item in _schoolDirectlyOwnedBuses)
            {
                item.SchoolExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolExtensionMapper.MapTo(this, (Entities.Common.Sample.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsIsExemplarySupported               { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolCTEProgramSupported          { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusesSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.ISchoolDirectlyOwnedBus, bool> Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusIncluded
        { 
            get { return null; }
            set { }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolDirectlyOwnedBusesValidator = new SchoolDirectlyOwnedBusPutPostRequestValidator();

            foreach (var item in instance.SchoolDirectlyOwnedBuses)
            {
                var validationResult = schoolDirectlyOwnedBusesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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

}
// Aggregate: School

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_ReadOnly_Readable.Extensions.TPDM
{
    /// <summary>
    /// A class which represents the tpdm.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.TPDM.ISchoolExtension, Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.TPDM.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.TPDM.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The federal locale code associated with an education organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="federalLocaleCodeDescriptor")]
        public string FederalLocaleCodeDescriptor { get; set; }

        /// <summary>
        /// An indication of whether a school is identified as an improving school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="improvingSchool")]
        public bool? ImprovingSchool { get; set; }

        /// <summary>
        /// The status of school e.g. priority or focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolStatusDescriptor")]
        public string SchoolStatusDescriptor { get; set; }
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
            return Entities.Common.TPDM.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.TPDM.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.TPDM.SchoolExtensionMapper.MapTo(this, (Entities.Common.TPDM.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsFederalLocaleCodeDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsImprovingSchoolSupported              { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsSchoolStatusDescriptorSupported       { get { return true; } set { } }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
// Aggregate: EducationOrganization

namespace EdFi.Ods.Api.Models.Resources.EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School
{
    /// <summary>
    /// Represents a reference to the EducationOrganization resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationReference
    {
        [DataMember(Name="educationOrganizationId"), NaturalKeyMember]
        public int EducationOrganizationId { get; set; }

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
            return EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "EducationOrganization",
                Href = $"/ed-fi/educationOrganizations/{ResourceId:n}"
            };

            if (string.IsNullOrEmpty(Discriminator))
                return link;

            string[] linkParts = Discriminator.Split('.');

            if (linkParts.Length < 2)
                return link;

            var resource = GeneratedArtifactStaticDependencies.ResourceModelProvider.GetResourceModel()
                .GetResourceByFullName(new Common.Models.Domain.FullName(linkParts[0], linkParts[1]));

            // return the default link if the relationship is already correct, and/or if the resource is not found.
            if (resource == null || link.Rel == resource.Name)
                return link;

            var pm = resource.BaseResourcePropertyMappingsByOtherName();

            return new Link
            {
                Rel = resource.Name,
                Href = $"/{resource.SchemaUriSegment()}/{resource.PluralName.ToCamelCase()}/{ResourceId:n}"
            };
        }
    } // Aggregate reference


    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------
    // -----------------------------------------------------------------

    /// <summary>
    /// A class which represents the edfi.EducationOrganizationAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddress : Entities.Common.EdFi.IEducationOrganizationAddress, Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public EducationOrganizationAddress()
        {
            EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>();
        }
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="city"), NaturalKeyMember]
        public string City { get; set; }

        /// <summary>
        /// The five or nine digit zip code or overseas postal code portion of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="postalCode"), NaturalKeyMember]
        public string PostalCode { get; set; }

        /// <summary>
        /// The abbreviation for the state (within the United States) or outlying area in which an address is located.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="stateAbbreviationDescriptor"), NaturalKeyMember]
        public string StateAbbreviationDescriptor { get; set; }

        /// <summary>
        /// The street number and street name or post office box number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="streetNumberName"), NaturalKeyMember]
        public string StreetNumberName { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).City.Equals(compareTo.City)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.Equals(compareTo.PostalCode)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.Equals(compareTo.StateAbbreviationDescriptor)) 
                return false;
 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.Equals(compareTo.StreetNumberName)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).AddressTypeDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).City != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).City.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).PostalCode.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StateAbbreviationDescriptor.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddress).StreetNumberName.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The apartment, room, or suite number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="apartmentRoomSuiteNumber")]
        public string ApartmentRoomSuiteNumber { get; set; }

        /// <summary>
        /// The number of the building on the site, if more than one building shares the same address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="buildingSiteNumber")]
        public string BuildingSiteNumber { get; set; }

        /// <summary>
        /// The congressional district in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="congressionalDistrict")]
        public string CongressionalDistrict { get; set; }

        /// <summary>
        /// The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="countyFIPSCode")]
        public string CountyFIPSCode { get; set; }

        /// <summary>
        /// An indication that the address should not be published.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="doNotPublishIndicator")]
        public bool? DoNotPublishIndicator { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// A general geographic indicator that categorizes U.S. territory (e.g., City, Suburban).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="localeDescriptor")]
        public string LocaleDescriptor { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// The name of the county, parish, borough, or comparable unit (within a state) in                        'which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfCounty")]
        public string NameOfCounty { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<EducationOrganizationAddressPeriod> _educationOrganizationAddressPeriods;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> _educationOrganizationAddressPeriodsCovariant;

        [DataMember(Name="periods"), NoDuplicateMembers]
        public ICollection<EducationOrganizationAddressPeriod> EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriods; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<EducationOrganizationAddressPeriod>(value,
                    (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this);
                _educationOrganizationAddressPeriods = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, EducationOrganizationAddressPeriod>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.IEducationOrganizationAddressPeriod)e.Item).EducationOrganizationAddress = this;
                _educationOrganizationAddressPeriodsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddressPeriod> Entities.Common.EdFi.IEducationOrganizationAddress.EducationOrganizationAddressPeriods
        {
            get { return _educationOrganizationAddressPeriodsCovariant; }
            set { EducationOrganizationAddressPeriods = new List<EducationOrganizationAddressPeriod>(value.Cast<EducationOrganizationAddressPeriod>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_educationOrganizationAddressPeriods != null) foreach (var item in _educationOrganizationAddressPeriods)
            {
                item.EducationOrganizationAddress = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.EducationOrganizationAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCongressionalDistrictSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsDoNotPublishIndicatorSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodsSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLatitudeSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLocaleDescriptorSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsLongitudeSupported                            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsNameOfCountySupported                         { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddressPeriod, bool> Entities.Common.EdFi.IEducationOrganizationAddressSynchronizationSourceSupport.IsEducationOrganizationAddressPeriodIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var educationOrganizationAddressPeriodsValidator = new EducationOrganizationAddressPeriodPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddressPeriods)
            {
                var validationResult = educationOrganizationAddressPeriodsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.EducationOrganizationAddressPeriod table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriod : Entities.Common.EdFi.IEducationOrganizationAddressPeriod, Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganizationAddress _educationOrganizationAddress;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganizationAddress Entities.Common.EdFi.IEducationOrganizationAddressPeriod.EducationOrganizationAddress
        {
            get { return _educationOrganizationAddress; }
            set { SetEducationOrganizationAddress(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganizationAddress EducationOrganizationAddress
        {
            set { SetEducationOrganizationAddress(value); }
        }

        private void SetEducationOrganizationAddress(Entities.Common.EdFi.IEducationOrganizationAddress value)
        {
            _educationOrganizationAddress = value;
        }

        /// <summary>
        /// The month, day, and year for the start of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate"), NaturalKeyMember][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime BeginDate { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationAddressPeriod;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganizationAddress == null || !_educationOrganizationAddress.Equals(compareTo.EducationOrganizationAddress))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.Equals(compareTo.BeginDate)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganizationAddress != null)
                    hash = hash * 23 + _educationOrganizationAddress.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationAddressPeriod).BeginDate.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The month, day, and year for the end of the period.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationAddressPeriod")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationAddressPeriodMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationAddressPeriod)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationAddressPeriodSynchronizationSourceSupport.IsEndDateSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationAddressPeriodPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationAddressPeriod>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationAddressPeriod> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationCategory table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategory : Entities.Common.EdFi.IEducationOrganizationCategory, Entities.Common.EdFi.IEducationOrganizationCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationCategory.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The classification of the education agency within the geographic boundaries of a state according to the level of administrative and operational control granted by the state.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationCategoryDescriptor"), NaturalKeyMember]
        public string EducationOrganizationCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.Equals(compareTo.EducationOrganizationCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationCategory).EducationOrganizationCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationCategoryMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationIdentificationCode table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCode : Entities.Common.EdFi.IEducationOrganizationIdentificationCode, Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationIdentificationCode.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The school system, state, or agency assigning the identification code.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="educationOrganizationIdentificationSystemDescriptor"), NaturalKeyMember]
        public string EducationOrganizationIdentificationSystemDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationIdentificationCode;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.Equals(compareTo.EducationOrganizationIdentificationSystemDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationIdentificationCode).EducationOrganizationIdentificationSystemDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A unique number or alphanumeric code that is assigned to an education organization by a school, school system, state, or other agency or entity.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="identificationCode")]
        public string IdentificationCode { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationIdentificationCode")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationIdentificationCodeMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationIdentificationCode)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationIdentificationCodeSynchronizationSourceSupport.IsIdentificationCodeSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationIdentificationCodePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationIdentificationCode>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationIdentificationCode> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInstitutionTelephone table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephone : Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of communication number listed for an individual or organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="institutionTelephoneNumberTypeDescriptor"), NaturalKeyMember]
        public string InstitutionTelephoneNumberTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.Equals(compareTo.InstitutionTelephoneNumberTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone).InstitutionTelephoneNumberTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The telephone number including the area code, and extension, if applicable.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="telephoneNumber")]
        public string TelephoneNumber { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInstitutionTelephone")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInstitutionTelephoneMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInstitutionTelephoneSynchronizationSourceSupport.IsTelephoneNumberSupported  { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInstitutionTelephonePutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInstitutionTelephone>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInstitutionTelephone> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.EducationOrganizationInternationalAddress table of the EducationOrganization aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddress : Entities.Common.EdFi.IEducationOrganizationInternationalAddress, Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.IEducationOrganization _educationOrganization;

        [IgnoreDataMember]
        Entities.Common.EdFi.IEducationOrganization Entities.Common.EdFi.IEducationOrganizationInternationalAddress.EducationOrganization
        {
            get { return _educationOrganization; }
            set { SetEducationOrganization(value); }
        }

        internal Entities.Common.EdFi.IEducationOrganization EducationOrganization
        {
            set { SetEducationOrganization(value); }
        }

        private void SetEducationOrganization(Entities.Common.EdFi.IEducationOrganization value)
        {
            _educationOrganization = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization. For example:  Physical Address, Mailing Address, Home Address, etc.)
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="addressTypeDescriptor"), NaturalKeyMember]
        public string AddressTypeDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.IEducationOrganizationInternationalAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_educationOrganization == null || !_educationOrganization.Equals(compareTo.EducationOrganization))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_educationOrganization != null)
                    hash = hash * 23 + _educationOrganization.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.IEducationOrganizationInternationalAddress).AddressTypeDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The first line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine3")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// The fourth line of the address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="addressLine4")]
        public string AddressLine4 { get; set; }

        /// <summary>
        /// The first date the address is valid. For physical addresses, the date the person moved to that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// The name of the country. It is strongly recommended that entries use only ISO 3166 2-letter country codes.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="countryDescriptor")]
        public string CountryDescriptor { get; set; }

        /// <summary>
        /// The last date the address is valid. For physical addresses, this would be the date the person moved from that address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="endDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The geographic latitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// The geographic longitude of the physical address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="longitude")]
        public string Longitude { get; set; }
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "EducationOrganization", "EducationOrganizationInternationalAddress")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.SynchronizeTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.EducationOrganizationInternationalAddressMapper.MapTo(this, (Entities.Common.EdFi.IEducationOrganizationInternationalAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine1Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine2Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine3Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsAddressLine4Supported       { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsBeginDateSupported          { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsCountryDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsEndDateSupported            { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLatitudeSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.IEducationOrganizationInternationalAddressSynchronizationSourceSupport.IsLongitudeSupported          { get { return true; } set { } }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class EducationOrganizationInternationalAddressPutPostRequestValidator : FluentValidation.AbstractValidator<EducationOrganizationInternationalAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<EducationOrganizationInternationalAddress> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable
{
    /// <summary>
    /// Represents a reference to the School resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolReference
    {
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier of the referenced resource.
        /// </summary>
        public Guid ResourceId { get; set; }


        private Link _link;

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
            return SchoolId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "School",
                Href = $"/ed-fi/schools/{ResourceId:n}"
            };

            return link;
        }
    } // Aggregate reference

    /// <summary>
    /// A class which represents the edfi.School table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class School : Entities.Common.EdFi.ISchool, Entities.Common.EdFi.IEducationOrganization, IHasETag, Entities.Common.EdFi.ISchoolSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public School()
        {
            SchoolCategories = new List<SchoolCategory>();
            SchoolGradeLevels = new List<SchoolGradeLevel>();

            // Inherited lists
            EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddress>();
            EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategory>();
            EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCode>();
            EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephone>();
            EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddress>();
        }
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

        private bool _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned;
        private SchoolYearType.EdFi.SchoolYearTypeReference _charterApprovalSchoolYearTypeReference;
        private SchoolYearType.EdFi.SchoolYearTypeReference ImplicitCharterApprovalSchoolYearTypeReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_charterApprovalSchoolYearTypeReference == null && !_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned)
                    _charterApprovalSchoolYearTypeReference = new SchoolYearType.EdFi.SchoolYearTypeReference();

                return _charterApprovalSchoolYearTypeReference;
            }
        }

        [DataMember(Name="charterApprovalSchoolYearTypeReference")]
        public SchoolYearType.EdFi.SchoolYearTypeReference CharterApprovalSchoolYearTypeReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_charterApprovalSchoolYearTypeReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    return ImplicitCharterApprovalSchoolYearTypeReference;

                return null;
            }
            set
            {
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = true;
                _charterApprovalSchoolYearTypeReference = value;
            }
        }
        private bool _localEducationAgencyReferenceExplicitlyAssigned;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference _localEducationAgencyReference;
        private LocalEducationAgency.EdFi.LocalEducationAgencyReference ImplicitLocalEducationAgencyReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_localEducationAgencyReference == null && !_localEducationAgencyReferenceExplicitlyAssigned)
                    _localEducationAgencyReference = new LocalEducationAgency.EdFi.LocalEducationAgencyReference();

                return _localEducationAgencyReference;
            }
        }

        [DataMember(Name="localEducationAgencyReference")]
        public LocalEducationAgency.EdFi.LocalEducationAgencyReference LocalEducationAgencyReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitLocalEducationAgencyReference != null
                    && (_localEducationAgencyReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    return ImplicitLocalEducationAgencyReference;

                return null;
            }
            set
            {
                _localEducationAgencyReferenceExplicitlyAssigned = true;
                _localEducationAgencyReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// The identifier assigned to a school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="schoolId"), NaturalKeyMember]
        public int SchoolId { get; set; }

        int IEducationOrganization.EducationOrganizationId
        {
            get { return SchoolId; }
            set { SchoolId = value; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchool;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Derived Property
            if ((this as Entities.Common.EdFi.ISchool).SchoolId == null
                || !(this as Entities.Common.EdFi.ISchool).SchoolId.Equals(compareTo.SchoolId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
 
                //Derived Property
                if ((this as Entities.Common.EdFi.ISchool).SchoolId != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchool).SchoolId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The full, legally accepted name of the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfInstitution")]
        public string NameOfInstitution { get; set; }

        /// <summary>
        /// The current operational status of the EducationOrganization (e.g., active, inactive).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="operationalStatusDescriptor")]
        public string OperationalStatusDescriptor { get; set; }

        /// <summary>
        /// A short name for the institution.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="shortNameOfInstitution")]
        public string ShortNameOfInstitution { get; set; }

        /// <summary>
        /// The public web site address (URL) for the EducationOrganization.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="webSite")]
        public string WebSite { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Properties
        // -------------------------------------------------------------

        /// <summary>
        /// The type of education institution as classified by its funding source, for example public or private.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="administrativeFundingControlDescriptor")]
        public string AdministrativeFundingControlDescriptor { get; set; }

        /// <summary>
        /// The type of agency that approved the establishment or continuation of a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterApprovalAgencyTypeDescriptor")]
        public string CharterApprovalAgencyTypeDescriptor { get; set; }

        /// <summary>
        /// The school year in which a charter school was initially approved.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        short? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYear
        {
            get
            {
                if (ImplicitCharterApprovalSchoolYearTypeReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitCharterApprovalSchoolYearTypeReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear;
                    }

                return default(short?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // CharterApprovalSchoolYearType
                _charterApprovalSchoolYearTypeReferenceExplicitlyAssigned = false;
                ImplicitCharterApprovalSchoolYearTypeReference.SchoolYear = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A school or agency providing free public elementary or secondary education to eligible students under a specific charter granted by the state legislature or other appropriate authority and designated by such authority to be a charter school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="charterStatusDescriptor")]
        public string CharterStatusDescriptor { get; set; }

        /// <summary>
        /// The type of Internet access available.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="internetAccessDescriptor")]
        public string InternetAccessDescriptor { get; set; }

        /// <summary>
        /// The identifier assigned to a local education agency.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int? Entities.Common.EdFi.ISchool.LocalEducationAgencyId
        {
            get
            {
                if (ImplicitLocalEducationAgencyReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitLocalEducationAgencyReference.IsReferenceFullyDefined()))
                    {
                        return ImplicitLocalEducationAgencyReference.LocalEducationAgencyId;
                    }

                return default(int?);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // LocalEducationAgency
                _localEducationAgencyReferenceExplicitlyAssigned = false;
                ImplicitLocalEducationAgencyReference.LocalEducationAgencyId = value.GetValueOrDefault();
            }
        }

        /// <summary>
        /// A school that has been designed: 1) to attract students of different racial/ethnic backgrounds for the purpose of reducing, preventing, or eliminating racial isolation; and/or 2) to provide an academic or social focus on a particular theme (e.g., science/math, performing arts, gifted/talented, or foreign language).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="magnetSpecialProgramEmphasisSchoolDescriptor")]
        public string MagnetSpecialProgramEmphasisSchoolDescriptor { get; set; }

        /// <summary>
        /// The type of education institution as classified by its primary focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolTypeDescriptor")]
        public string SchoolTypeDescriptor { get; set; }

        /// <summary>
        /// Denotes the Title I Part A designation for the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="titleIPartASchoolDesignationDescriptor")]
        public string TitleIPartASchoolDesignationDescriptor { get; set; }
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
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddress> _educationOrganizationAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> _educationOrganizationAddressesCovariant;

        [DataMember(Name="addresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddress> EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddresses; }
            set
            {
                _educationOrganizationAddresses = value;
                _educationOrganizationAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationAddress, EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationAddresses
        {
            get { return _educationOrganizationAddressesCovariant; }
            set { EducationOrganizationAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddress>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategory> _educationOrganizationCategories;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> _educationOrganizationCategoriesCovariant;

        [DataMember(Name="educationOrganizationCategories"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategory> EducationOrganizationCategories
        {
            get { return _educationOrganizationCategories; }
            set
            {
                _educationOrganizationCategories = value;
                _educationOrganizationCategoriesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationCategory, EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategory>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationCategory> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationCategories
        {
            get { return _educationOrganizationCategoriesCovariant; }
            set { EducationOrganizationCategories = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategory>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategory>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodes;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> _educationOrganizationIdentificationCodesCovariant;

        [DataMember(Name="identificationCodes"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCode> EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodes; }
            set
            {
                _educationOrganizationIdentificationCodes = value;
                _educationOrganizationIdentificationCodesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCode>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationIdentificationCode> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationIdentificationCodes
        {
            get { return _educationOrganizationIdentificationCodesCovariant; }
            set { EducationOrganizationIdentificationCodes = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCode>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCode>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephones;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> _educationOrganizationInstitutionTelephonesCovariant;

        [DataMember(Name="institutionTelephones"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephone> EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephones; }
            set
            {
                _educationOrganizationInstitutionTelephones = value;
                _educationOrganizationInstitutionTelephonesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephone>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInstitutionTelephones
        {
            get { return _educationOrganizationInstitutionTelephonesCovariant; }
            set { EducationOrganizationInstitutionTelephones = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephone>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephone>()); }
        }
        private ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddress> _educationOrganizationInternationalAddresses;
        private ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> _educationOrganizationInternationalAddressesCovariant;

        [DataMember(Name="internationalAddresses"), NoDuplicateMembers]
        public ICollection<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddress> EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddresses; }
            set
            {
                _educationOrganizationInternationalAddresses = value;
                _educationOrganizationInternationalAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.IEducationOrganizationInternationalAddress> Entities.Common.EdFi.IEducationOrganization.EducationOrganizationInternationalAddresses
        {
            get { return _educationOrganizationInternationalAddressesCovariant; }
            set { EducationOrganizationInternationalAddresses = new List<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddress>(value.Cast<EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddress>()); }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                     Extensions
        // -------------------------------------------------------------
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "School")]
        public System.Collections.IDictionary Extensions { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                          Collections
        // -------------------------------------------------------------
        private ICollection<SchoolCategory> _schoolCategories;
        private ICollection<Entities.Common.EdFi.ISchoolCategory> _schoolCategoriesCovariant;

        [DataMember(Name="schoolCategories"), NoDuplicateMembers]
        public ICollection<SchoolCategory> SchoolCategories
        {
            get { return _schoolCategories; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolCategory>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this);
                _schoolCategories = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolCategory, SchoolCategory>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolCategory)e.Item).School = this;
                _schoolCategoriesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolCategory> Entities.Common.EdFi.ISchool.SchoolCategories
        {
            get { return _schoolCategoriesCovariant; }
            set { SchoolCategories = new List<SchoolCategory>(value.Cast<SchoolCategory>()); }
        }

        private ICollection<SchoolGradeLevel> _schoolGradeLevels;
        private ICollection<Entities.Common.EdFi.ISchoolGradeLevel> _schoolGradeLevelsCovariant;

        [DataMember(Name="gradeLevels"), NoDuplicateMembers]
        public ICollection<SchoolGradeLevel> SchoolGradeLevels
        {
            get { return _schoolGradeLevels; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolGradeLevel>(value,
                    (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this);
                _schoolGradeLevels = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.EdFi.ISchoolGradeLevel, SchoolGradeLevel>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.EdFi.ISchoolGradeLevel)e.Item).School = this;
                _schoolGradeLevelsCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.EdFi.ISchoolGradeLevel> Entities.Common.EdFi.ISchool.SchoolGradeLevels
        {
            get { return _schoolGradeLevelsCovariant; }
            set { SchoolGradeLevels = new List<SchoolGradeLevel>(value.Cast<SchoolGradeLevel>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------

        [DataMember(Name="_etag")]
        public virtual string ETag { get; set; }

        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            // _educationOrganizationAddresses
            // _educationOrganizationCategories
            // _educationOrganizationIdentificationCodes
            // _educationOrganizationInstitutionTelephones
            // _educationOrganizationInternationalAddresses
            if (_schoolCategories != null) foreach (var item in _schoolCategories)
            {
                item.School = this;
            }

            if (_schoolGradeLevels != null) foreach (var item in _schoolGradeLevels)
            {
                item.School = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.EdFi.SchoolMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchool)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolMapper.MapTo(this, (Entities.Common.EdFi.ISchool)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsAdministrativeFundingControlDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalAgencyTypeDescriptorSupported           { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterApprovalSchoolYearSupported                     { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsCharterStatusDescriptorSupported                       { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressesSupported                { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoriesSupported               { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodesSupported      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephonesSupported    { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressesSupported   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsInternetAccessDescriptorSupported                      { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsLocalEducationAgencyIdSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsMagnetSpecialProgramEmphasisSchoolDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsNameOfInstitutionSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsOperationalStatusDescriptorSupported                   { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoriesSupported                              { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelsSupported                             { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolTypeDescriptorSupported                          { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsShortNameOfInstitutionSupported                        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsTitleIPartASchoolDesignationDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsWebSiteSupported                                       { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.EdFi.IEducationOrganizationAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationIdentificationCode, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationIdentificationCodeIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInstitutionTelephone, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInstitutionTelephoneIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.IEducationOrganizationInternationalAddress, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsEducationOrganizationInternationalAddressIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolCategory, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolCategoryIncluded
        { 
            get { return null; }
            set { }
        }
        Func<Entities.Common.EdFi.ISchoolGradeLevel, bool> Entities.Common.EdFi.ISchoolSynchronizationSourceSupport.IsSchoolGradeLevelIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.EdFi.ISchool.CharterApprovalSchoolYearTypeResourceId 
        { 
            get { return null; }
            set { ImplicitCharterApprovalSchoolYearTypeReference.ResourceId = value ?? default(Guid); }
        }


        Guid? Entities.Common.EdFi.ISchool.LocalEducationAgencyResourceId 
        { 
            get { return null; }
            set { ImplicitLocalEducationAgencyReference.ResourceId = value ?? default(Guid); }
        }


        // -----------------------------------------------------------------
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

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolCategoriesValidator = new SchoolCategoryPutPostRequestValidator();

            foreach (var item in instance.SchoolCategories)
            {
                var validationResult = schoolCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var schoolGradeLevelsValidator = new SchoolGradeLevelPutPostRequestValidator();

            foreach (var item in instance.SchoolGradeLevels)
            {
                var validationResult = schoolGradeLevelsValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationAddresses)
            {
                var validationResult = educationOrganizationAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationCategoriesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationCategoryPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationCategories)
            {
                var validationResult = educationOrganizationCategoriesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationIdentificationCodesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationIdentificationCodePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationIdentificationCodes)
            {
                var validationResult = educationOrganizationIdentificationCodesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInstitutionTelephonesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInstitutionTelephonePutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInstitutionTelephones)
            {
                var validationResult = educationOrganizationInstitutionTelephonesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
            }

            var educationOrganizationInternationalAddressesValidator = new EducationOrganization.EdFi.Test_Profile_Resource_WriteOnly_Writable.School.EducationOrganizationInternationalAddressPutPostRequestValidator();

            foreach (var item in instance.EducationOrganizationInternationalAddresses)
            {
                var validationResult = educationOrganizationInternationalAddressesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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
    /// A class which represents the edfi.SchoolCategory table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCategory : Entities.Common.EdFi.ISchoolCategory, Entities.Common.EdFi.ISchoolCategorySynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolCategory.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The one or more categories of school. For example: High School, Middle School, and/or Elementary School.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolCategoryDescriptor"), NaturalKeyMember]
        public string SchoolCategoryDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolCategory;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.Equals(compareTo.SchoolCategoryDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolCategory).SchoolCategoryDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolCategory")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolCategoryMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolCategory)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolCategoryMapper.MapTo(this, (Entities.Common.EdFi.ISchoolCategory)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolCategoryPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCategory>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCategory> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the edfi.SchoolGradeLevel table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevel : Entities.Common.EdFi.ISchoolGradeLevel, Entities.Common.EdFi.ISchoolGradeLevelSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.EdFi.ISchoolGradeLevel.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
        {
            _school = value;
        }

        /// <summary>
        /// The grade levels served at the school.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="gradeLevelDescriptor"), NaturalKeyMember]
        public string GradeLevelDescriptor { get; set; }
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.EdFi.ISchoolGradeLevel;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor == null
                || !(this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.Equals(compareTo.GradeLevelDescriptor)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.EdFi.ISchoolGradeLevel).GradeLevelDescriptor.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        [JsonProperty("_ext")]
        [JsonConverter(typeof(ExtensionsConverter), "School", "SchoolGradeLevel")]
        public System.Collections.IDictionary Extensions { get; set; }
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
            return Entities.Common.EdFi.SchoolGradeLevelMapper.SynchronizeTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.EdFi.SchoolGradeLevelMapper.MapTo(this, (Entities.Common.EdFi.ISchoolGradeLevel)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        bool IExtensionsSynchronizationSourceSupport.IsExtensionSupported(string name) { return new [] { "Sample", "TPDM",  }.Contains(name); }
        void IExtensionsSynchronizationSourceSupport.SetExtensionSupported(string name, bool isSupported) { }
        bool IExtensionsSynchronizationSourceSupport.IsExtensionAvailable(string name) { return true; }
        void IExtensionsSynchronizationSourceSupport.SetExtensionAvailable(string name, bool isSupported) { }


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolGradeLevelPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolGradeLevel>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolGradeLevel> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.Extensions.Sample
{
    /// <summary>
    /// A class which represents the sample.SchoolCTEProgram table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolCTEProgram : Entities.Common.Sample.ISchoolCTEProgram, Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport
    {
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
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolCTEProgram.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolCTEProgram;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// A sequence of courses within an area of interest that is a student's educational road map to a chosen career.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="careerPathwayDescriptor")]
        public string CareerPathwayDescriptor { get; set; }

        /// <summary>
        /// Number and description of the CIP Code associated with the student's CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cipCode")]
        public string CIPCode { get; set; }

        /// <summary>
        /// A boolean indicator of whether the Student has completed the CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="cteProgramCompletionIndicator")]
        public bool? CTEProgramCompletionIndicator { get; set; }

        /// <summary>
        /// A boolean indicator of whether this CTEProgram, is the student's primary CTEProgram.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="primaryCTEProgramIndicator")]
        public bool? PrimaryCTEProgramIndicator { get; set; }
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
            return Entities.Common.Sample.SchoolCTEProgramMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolCTEProgramMapper.MapTo(this, (Entities.Common.Sample.ISchoolCTEProgram)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCareerPathwayDescriptorSupported        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCIPCodeSupported                        { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsCTEProgramCompletionIndicatorSupported  { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolCTEProgramSynchronizationSourceSupport.IsPrimaryCTEProgramIndicatorSupported     { get { return true; } set { } }
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
    public class SchoolCTEProgramPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolCTEProgram>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolCTEProgram> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolDirectlyOwnedBus table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBus : Entities.Common.Sample.ISchoolDirectlyOwnedBus, Entities.Common.Sample.ISchoolDirectlyOwnedBusSynchronizationSourceSupport
    {
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

        private bool _directlyOwnedBusReferenceExplicitlyAssigned;
        private Bus.Sample.BusReference _directlyOwnedBusReference;
        private Bus.Sample.BusReference ImplicitDirectlyOwnedBusReference
        {
            get
            {
                // if the Reference is null, it is instantiated unless it has been explicitly assigned to null
                if (_directlyOwnedBusReference == null && !_directlyOwnedBusReferenceExplicitlyAssigned)
                    _directlyOwnedBusReference = new Bus.Sample.BusReference();

                return _directlyOwnedBusReference;
            }
        }

        [DataMember(Name="directlyOwnedBusReference")][NaturalKeyMember]
        public Bus.Sample.BusReference DirectlyOwnedBusReference
        {
            get
            {
                // Only return the reference if it's non-null, and all its properties have non-default values assigned
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_directlyOwnedBusReferenceExplicitlyAssigned || _SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference;

                return null;
            }
            set
            {
                _directlyOwnedBusReferenceExplicitlyAssigned = true;
                _directlyOwnedBusReference = value;
            }
        }
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        private Entities.Common.Sample.ISchoolExtension _schoolExtension;

        [IgnoreDataMember]
        Entities.Common.Sample.ISchoolExtension Entities.Common.Sample.ISchoolDirectlyOwnedBus.SchoolExtension
        {
            get { return _schoolExtension; }
            set { SetSchoolExtension(value); }
        }

        internal Entities.Common.Sample.ISchoolExtension SchoolExtension
        {
            set { SetSchoolExtension(value); }
        }

        private void SetSchoolExtension(Entities.Common.Sample.ISchoolExtension value)
        {
            _schoolExtension = value;
        }

        /// <summary>
        /// The unique identifier for the bus.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusId
        {
            get
            {
                if (ImplicitDirectlyOwnedBusReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitDirectlyOwnedBusReference.IsReferenceFullyDefined()))
                    return ImplicitDirectlyOwnedBusReference.BusId;

                return default(string);
            }
            set
            {
                // When a property is assigned, Reference should not be null even if it has been explicitly assigned to null.
                // All ExplicitlyAssigned are reset to false in advanced

                // DirectlyOwnedBus
                _directlyOwnedBusReferenceExplicitlyAssigned = false;
                ImplicitDirectlyOwnedBusReference.BusId = value;
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolDirectlyOwnedBus;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_schoolExtension == null || !_schoolExtension.Equals(compareTo.SchoolExtension))
                return false;

 
            // Referenced Property
            if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId == null
                || !(this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.Equals(compareTo.DirectlyOwnedBusId)) 
                return false;
            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_schoolExtension != null)
                    hash = hash * 23 + _schoolExtension.GetHashCode();
 
                //Referenced Property
                if ((this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId != null) 
                    hash = hash * 23 + (this as Entities.Common.Sample.ISchoolDirectlyOwnedBus).DirectlyOwnedBusId.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
            return Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolDirectlyOwnedBusMapper.MapTo(this, (Entities.Common.Sample.ISchoolDirectlyOwnedBus)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusResourceId 
        { 
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.Sample.ISchoolDirectlyOwnedBus.DirectlyOwnedBusDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitDirectlyOwnedBusReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class SchoolDirectlyOwnedBusPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolDirectlyOwnedBus>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolDirectlyOwnedBus> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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
    /// A class which represents the sample.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.Sample.ISchoolExtension, Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public SchoolExtension()
        {
            SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>();
        }
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.Sample.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.Sample.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// An indication as to whether the school is exemplary.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="isExemplary")]
        public bool? IsExemplary { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        /// <summary>
        /// cteProgram
        /// </summary>
        [DataMember(Name = "cteProgram")]
        public SchoolCTEProgram SchoolCTEProgram { get; set; }

        Entities.Common.Sample.ISchoolCTEProgram Entities.Common.Sample.ISchoolExtension.SchoolCTEProgram
        {
            get { return SchoolCTEProgram; }
            set { SchoolCTEProgram = (SchoolCTEProgram) value; }
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
        private ICollection<SchoolDirectlyOwnedBus> _schoolDirectlyOwnedBuses;
        private ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> _schoolDirectlyOwnedBusesCovariant;

        [DataMember(Name="directlyOwnedBuses"), NoDuplicateMembers]
        public ICollection<SchoolDirectlyOwnedBus> SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBuses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<SchoolDirectlyOwnedBus>(value,
                    (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this);
                _schoolDirectlyOwnedBuses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.Sample.ISchoolDirectlyOwnedBus, SchoolDirectlyOwnedBus>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.Sample.ISchoolDirectlyOwnedBus)e.Item).SchoolExtension = this;
                _schoolDirectlyOwnedBusesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.Sample.ISchoolDirectlyOwnedBus> Entities.Common.Sample.ISchoolExtension.SchoolDirectlyOwnedBuses
        {
            get { return _schoolDirectlyOwnedBusesCovariant; }
            set { SchoolDirectlyOwnedBuses = new List<SchoolDirectlyOwnedBus>(value.Cast<SchoolDirectlyOwnedBus>()); }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                         Versioning
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // -------------------------------------------------------------
        //                        OnDeserialize
        // -------------------------------------------------------------

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // Reconnect external inbound references on deserialization
            if (_schoolDirectlyOwnedBuses != null) foreach (var item in _schoolDirectlyOwnedBuses)
            {
                item.SchoolExtension = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.Sample.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.Sample.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.Sample.SchoolExtensionMapper.MapTo(this, (Entities.Common.Sample.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsIsExemplarySupported               { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolCTEProgramSupported          { get { return true; } set { } }
        bool Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusesSupported  { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.Sample.ISchoolDirectlyOwnedBus, bool> Entities.Common.Sample.ISchoolExtensionSynchronizationSourceSupport.IsSchoolDirectlyOwnedBusIncluded
        { 
            get { return null; }
            set { }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators
            var schoolDirectlyOwnedBusesValidator = new SchoolDirectlyOwnedBusPutPostRequestValidator();

            foreach (var item in instance.SchoolDirectlyOwnedBuses)
            {
                var validationResult = schoolDirectlyOwnedBusesValidator.Validate(item);

                if (!validationResult.IsValid)
                    failures.AddRange(validationResult.Errors);
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

}
// Aggregate: School

namespace EdFi.Ods.Api.Models.Resources.School.EdFi.Test_Profile_Resource_WriteOnly_Writable.Extensions.TPDM
{
    /// <summary>
    /// A class which represents the tpdm.SchoolExtension table of the School aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class SchoolExtension : Entities.Common.TPDM.ISchoolExtension, Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport
    {
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
        private Entities.Common.EdFi.ISchool _school;

        [IgnoreDataMember]
        Entities.Common.EdFi.ISchool Entities.Common.TPDM.ISchoolExtension.School
        {
            get { return _school; }
            set { SetSchool(value); }
        }

        internal Entities.Common.EdFi.ISchool School
        {
            set { SetSchool(value); }
        }

        private void SetSchool(Entities.Common.EdFi.ISchool value)
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
            #pragma warning disable 472
            var compareTo = obj as Entities.Common.TPDM.ISchoolExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_school == null || !_school.Equals(compareTo.School))
                return false;

            #pragma warning disable 472

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
            #pragma warning disable 472
            unchecked
            {
                int hash = 17;
                //Parent Property
                if (_school != null)
                    hash = hash * 23 + _school.GetHashCode();
                return hash;
            }
            #pragma warning restore 472
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
        /// The federal locale code associated with an education organization.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="federalLocaleCodeDescriptor")]
        public string FederalLocaleCodeDescriptor { get; set; }

        /// <summary>
        /// An indication of whether a school is identified as an improving school.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="improvingSchool")]
        public bool? ImprovingSchool { get; set; }

        /// <summary>
        /// The status of school e.g. priority or focus.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="schoolStatusDescriptor")]
        public string SchoolStatusDescriptor { get; set; }
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
            return Entities.Common.TPDM.SchoolExtensionMapper.SynchronizeTo(this, (Entities.Common.TPDM.ISchoolExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.TPDM.SchoolExtensionMapper.MapTo(this, (Entities.Common.TPDM.ISchoolExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsFederalLocaleCodeDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsImprovingSchoolSupported              { get { return true; } set { } }
        bool Entities.Common.TPDM.ISchoolExtensionSynchronizationSourceSupport.IsSchoolStatusDescriptorSupported       { get { return true; } set { } }
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
    public class SchoolExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<SchoolExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<SchoolExtension> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));

                return false;
            }

            var instance = context.InstanceToValidate;

            var failures = new List<ValidationFailure>();

            // -----------------------
            //  Validate unified keys
            // -----------------------
        
            // Recursively invoke the child collection item validators

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

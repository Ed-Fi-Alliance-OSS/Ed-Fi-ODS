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
using EdFi.Ods.Entities.Common.GrandBend;
using Newtonsoft.Json;
using FluentValidation.Results;

// Aggregate: Applicant

namespace EdFi.Ods.Api.Models.Resources.Applicant.GrandBend
{
    /// <summary>
    /// Represents a reference to the Applicant resource.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ApplicantReference
    {
        [DataMember(Name="applicantIdentifier"), NaturalKeyMember]
        public string ApplicantIdentifier { get; set; }

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
            return ApplicantIdentifier != default(string) && EducationOrganizationId != default(int);
        }

        private Link CreateLink()
        {
            var link = new Link
            {
                Rel = "Applicant",
                Href = $"/grand-bend/applicants/{ResourceId:n}"
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

    /// <summary>
    /// A class which represents the grandbend.Applicant table of the Applicant aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class Applicant : Entities.Common.GrandBend.IApplicant, IHasETag, Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport
    {
#pragma warning disable 414
        private bool _SuspendReferenceAssignmentCheck = false;
        public void SuspendReferenceAssignmentCheck() { _SuspendReferenceAssignmentCheck = true; }
#pragma warning restore 414

        // =============================================================
        //                         Constructor
        // -------------------------------------------------------------

        public Applicant()
        {
            ApplicantAddresses = new List<ApplicantAddress>();
        }
        // ------------------------------------------------------------

        // ============================================================
        //                Unique Identifier
        // ------------------------------------------------------------

        /// <summary>
        /// The unique identifier for the Applicant resource.
        /// </summary>
        [DataMember(Name="id")]
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

        [DataMember(Name="educationOrganizationReference")][NaturalKeyMember]
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
        // -------------------------------------------------------------

        //==============================================================
        //                         Primary Key
        // -------------------------------------------------------------

        /// <summary>
        /// A unique alphanumeric code assigned to an applicant.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="applicantIdentifier"), NaturalKeyMember]
        public string ApplicantIdentifier { get; set; }

        /// <summary>
        /// The identifier assigned to an education organization.
        /// </summary>
        // IS in a reference, NOT a lookup column 
        int Entities.Common.GrandBend.IApplicant.EducationOrganizationId
        {
            get
            {
                if (ImplicitEducationOrganizationReference != null
                    && (_SuspendReferenceAssignmentCheck || ImplicitEducationOrganizationReference.IsReferenceFullyDefined()))
                    return ImplicitEducationOrganizationReference.EducationOrganizationId;

                return default(int);
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
            var compareTo = obj as Entities.Common.GrandBend.IApplicant;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
 
            // Standard Property
            if ((this as Entities.Common.GrandBend.IApplicant).ApplicantIdentifier == null
                || !(this as Entities.Common.GrandBend.IApplicant).ApplicantIdentifier.Equals(compareTo.ApplicantIdentifier)) 
                return false;
 
            // Referenced Property
            if ((this as Entities.Common.GrandBend.IApplicant).EducationOrganizationId == null
                || !(this as Entities.Common.GrandBend.IApplicant).EducationOrganizationId.Equals(compareTo.EducationOrganizationId)) 
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
 
                // Standard Property
                if ((this as Entities.Common.GrandBend.IApplicant).ApplicantIdentifier != null) 
                    hash = hash * 23 + (this as Entities.Common.GrandBend.IApplicant).ApplicantIdentifier.GetHashCode();
 
                //Referenced Property
                if ((this as Entities.Common.GrandBend.IApplicant).EducationOrganizationId != null) 
                    hash = hash * 23 + (this as Entities.Common.GrandBend.IApplicant).EducationOrganizationId.GetHashCode();
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
        /// The month, day, and year on which an individual was born.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="birthDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// An indicator of whether or not the person is a U.S. citizen.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="citizenshipStatusDescriptor")]
        public string CitizenshipStatusDescriptor { get; set; }

        /// <summary>
        /// A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="generationCodeSuffix")]
        public string GenerationCodeSuffix { get; set; }

        /// <summary>
        /// The extent of formal instruction an individual has received (e.g., the highest grade in school completed or its equivalent or the highest degree received).
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="highestCompletedLevelOfEducationDescriptor")]
        public string HighestCompletedLevelOfEducationDescriptor { get; set; }

        /// <summary>
        /// An applicant subject in which a teacher applicant is classified as highly qualified.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="highlyQualifiedAcademicSubjectDescriptor")]
        public string HighlyQualifiedAcademicSubjectDescriptor { get; set; }

        /// <summary>
        /// An indication of whether a teacher applicant is classified as highly qualified for his/her prospective assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections to be taught.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="highlyQualifiedTeacher")]
        public bool? HighlyQualifiedTeacher { get; set; }

        /// <summary>
        /// An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, \"Spanish origin,\" can be used in addition to \"Hispanic or Latino.\"
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="hispanicLatinoEthnicity")]
        public bool? HispanicLatinoEthnicity { get; set; }

        /// <summary>
        /// The name borne in common by members of a family.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="lastSurname")]
        public string LastSurname { get; set; }

        /// <summary>
        /// The login ID for the user; used for security access control interface.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="loginId")]
        public string LoginId { get; set; }

        /// <summary>
        /// The person's maiden name.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="maidenName")]
        public string MaidenName { get; set; }

        /// <summary>
        /// A secondary name given to an individual at birth, baptism, or during another naming ceremony.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// A prefix used to denote the title, degree, position, or seniority of the person.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="personalTitlePrefix")]
        public string PersonalTitlePrefix { get; set; }

        /// <summary>
        /// A person's gender.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="sexDescriptor")]
        public string SexDescriptor { get; set; }

        /// <summary>
        /// The total number of years that an individual has previously held a similar professional position in one or more education institutions.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="yearsOfPriorProfessionalExperience")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal? YearsOfPriorProfessionalExperience { get; set; }

        /// <summary>
        /// The total number of years that an individual has previously held a teaching position in one or more education institutions.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="yearsOfPriorTeachingExperience")][Range(typeof(decimal), "-999.99", "999.99")]
        public decimal? YearsOfPriorTeachingExperience { get; set; }
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
        private ICollection<ApplicantAddress> _applicantAddresses;
        private ICollection<Entities.Common.GrandBend.IApplicantAddress> _applicantAddressesCovariant;

        [DataMember(Name="addresses"), NoDuplicateMembers]
        public ICollection<ApplicantAddress> ApplicantAddresses
        {
            get { return _applicantAddresses; }
            set
            {
                if (value == null) return;
                // Initialize primary list with notifying adapter immediately wired up so existing items are associated with the parent
                var list = new CollectionAdapterWithAddNotifications<ApplicantAddress>(value,
                    (s, e) => ((Entities.Common.GrandBend.IApplicantAddress)e.Item).Applicant = this);
                _applicantAddresses = list;

                // Initialize covariant list with notifying adapter with deferred wire up so only new items are processed (optimization)
                var covariantList = new CovariantCollectionAdapterWithAddNotifications<Entities.Common.GrandBend.IApplicantAddress, ApplicantAddress>(value);
                covariantList.ItemAdded += (s, e) => ((Entities.Common.GrandBend.IApplicantAddress)e.Item).Applicant = this;
                _applicantAddressesCovariant = covariantList;
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.GrandBend.IApplicantAddress> Entities.Common.GrandBend.IApplicant.ApplicantAddresses
        {
            get { return _applicantAddressesCovariant; }
            set { ApplicantAddresses = new List<ApplicantAddress>(value.Cast<ApplicantAddress>()); }
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
            if (_applicantAddresses != null) foreach (var item in _applicantAddresses)
            {
                item.Applicant = this;
            }

        }
        // ------------------------------------------------------------

        // ============================================================
        //                      Data Synchronization
        // ------------------------------------------------------------
        bool ISynchronizable.Synchronize(object target)
        {
            return Entities.Common.GrandBend.ApplicantMapper.SynchronizeTo(this, (Entities.Common.GrandBend.IApplicant)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.GrandBend.ApplicantMapper.MapTo(this, (Entities.Common.GrandBend.IApplicant)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsApplicantAddressesSupported                          { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsBirthDateSupported                                   { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsCitizenshipStatusDescriptorSupported                 { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsFirstNameSupported                                   { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsGenerationCodeSuffixSupported                        { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHighestCompletedLevelOfEducationDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHighlyQualifiedAcademicSubjectDescriptorSupported    { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHighlyQualifiedTeacherSupported                      { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHispanicLatinoEthnicitySupported                     { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsLastSurnameSupported                                 { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsLoginIdSupported                                     { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsMaidenNameSupported                                  { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsMiddleNameSupported                                  { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsPersonalTitlePrefixSupported                         { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsSexDescriptorSupported                               { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsYearsOfPriorProfessionalExperienceSupported          { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsYearsOfPriorTeachingExperienceSupported              { get { return true; } set { } }

        // Child collection item filter delegates
        Func<Entities.Common.GrandBend.IApplicantAddress, bool> Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsApplicantAddressIncluded
        { 
            get { return null; }
            set { }
        }
        // -------------------------------------------------------------


        // =================================================================
        //                    Resource Reference Data
        // -----------------------------------------------------------------
        Guid? Entities.Common.GrandBend.IApplicant.EducationOrganizationResourceId 
        { 
            get { return null; }
            set { ImplicitEducationOrganizationReference.ResourceId = value ?? default(Guid); }
        }

        string Entities.Common.GrandBend.IApplicant.EducationOrganizationDiscriminator
        {
            // Not supported for Resources
            get { return null; }
            set { ImplicitEducationOrganizationReference.Discriminator = value; }
        }


        // -----------------------------------------------------------------
    }

    // =================================================================
    //                         Validators
    // -----------------------------------------------------------------

    [ExcludeFromCodeCoverage]
    public class ApplicantPutPostRequestValidator : FluentValidation.AbstractValidator<Applicant>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<Applicant> context, FluentValidation.Results.ValidationResult result)
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
            var applicantAddressesValidator = new ApplicantAddressPutPostRequestValidator();

            foreach (var item in instance.ApplicantAddresses)
            {
                var validationResult = applicantAddressesValidator.Validate(item);

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
    /// A class which represents the grandbend.ApplicantAddress table of the Applicant aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class ApplicantAddress : Entities.Common.GrandBend.IApplicantAddress, Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport
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
        private Entities.Common.GrandBend.IApplicant _applicant;

        [IgnoreDataMember]
        Entities.Common.GrandBend.IApplicant Entities.Common.GrandBend.IApplicantAddress.Applicant
        {
            get { return _applicant; }
            set { SetApplicant(value); }
        }

        internal Entities.Common.GrandBend.IApplicant Applicant
        {
            set { SetApplicant(value); }
        }

        private void SetApplicant(Entities.Common.GrandBend.IApplicant value)
        {
            _applicant = value;
        }

        /// <summary>
        /// The type of address listed for an individual or organization.    For example:  Physical Address, Mailing Address, Home Address, etc.)
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
            var compareTo = obj as Entities.Common.GrandBend.IApplicantAddress;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_applicant == null || !_applicant.Equals(compareTo.Applicant))
                return false;

 
            // Standard Property
            if ((this as Entities.Common.GrandBend.IApplicantAddress).AddressTypeDescriptor == null
                || !(this as Entities.Common.GrandBend.IApplicantAddress).AddressTypeDescriptor.Equals(compareTo.AddressTypeDescriptor)) 
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
                if (_applicant != null)
                    hash = hash * 23 + _applicant.GetHashCode();
 
                // Standard Property
                if ((this as Entities.Common.GrandBend.IApplicantAddress).AddressTypeDescriptor != null) 
                    hash = hash * 23 + (this as Entities.Common.GrandBend.IApplicantAddress).AddressTypeDescriptor.GetHashCode();
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
        /// The month, day, and year the address became effective.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="beginDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// The number of the building on the site, if more than one building shares the same address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="buildingSiteNumber")]
        public string BuildingSiteNumber { get; set; }

        /// <summary>
        /// The name of the city in which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="city")]
        public string City { get; set; }

        /// <summary>
        /// The Federal Information Processing Standards (FIPS) numeric code for the county issued by the National Institute of Standards and Technology (NIST). Counties are considered to be the \"first-order subdivisions\" of each State and statistically equivalent entity, regardless of their local designations (county, parish, borough, etc.) Counties in different States will have the same code. A unique county number is created when combined with the 2-digit FIPS State Code.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="countyFIPSCode")]
        public string CountyFIPSCode { get; set; }

        /// <summary>
        /// The month, day, and year the address ceased to be in effect.
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

        /// <summary>
        /// The name of the county, parish, borough, or comparable unit (within a state) in                        'which an address is located.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="nameOfCounty")]
        public string NameOfCounty { get; set; }

        /// <summary>
        /// The five or nine digit zip code or overseas postal code portion of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The abbreviation for the state (within the United States) or outlying area in which an address is located.
        /// </summary>
        // NOT in a reference, IS a lookup column 
        [DataMember(Name="stateAbbreviationDescriptor")]
        public string StateAbbreviationDescriptor { get; set; }

        /// <summary>
        /// The street number and street name or post office box number of an address.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="streetNumberName")]
        public string StreetNumberName { get; set; }
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
            return Entities.Common.GrandBend.ApplicantAddressMapper.SynchronizeTo(this, (Entities.Common.GrandBend.IApplicantAddress)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.GrandBend.ApplicantAddressMapper.MapTo(this, (Entities.Common.GrandBend.IApplicantAddress)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported     { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsBeginDateSupported                    { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported           { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsCitySupported                         { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported               { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsEndDateSupported                      { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsLatitudeSupported                     { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsLongitudeSupported                    { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsNameOfCountySupported                 { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsPostalCodeSupported                   { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsStateAbbreviationDescriptorSupported  { get { return true; } set { } }
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsStreetNumberNameSupported             { get { return true; } set { } }
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
    public class ApplicantAddressPutPostRequestValidator : FluentValidation.AbstractValidator<ApplicantAddress>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<ApplicantAddress> context, FluentValidation.Results.ValidationResult result)
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
// Aggregate: Staff

namespace EdFi.Ods.Api.Models.Resources.Staff.EdFi.Extensions.GrandBend
{
    /// <summary>
    /// A class which represents the grandbend.StaffExtension table of the Staff aggregate in the ODS Database.
    /// </summary>
    [Serializable, DataContract]
    [ExcludeFromCodeCoverage]
    public class StaffExtension : Entities.Common.GrandBend.IStaffExtension, Entities.Common.GrandBend.IStaffExtensionSynchronizationSourceSupport
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
        private Entities.Common.EdFi.IStaff _staff;

        [IgnoreDataMember]
        Entities.Common.EdFi.IStaff Entities.Common.GrandBend.IStaffExtension.Staff
        {
            get { return _staff; }
            set { SetStaff(value); }
        }

        internal Entities.Common.EdFi.IStaff Staff
        {
            set { SetStaff(value); }
        }

        private void SetStaff(Entities.Common.EdFi.IStaff value)
        {
            _staff = value;
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
            var compareTo = obj as Entities.Common.GrandBend.IStaffExtension;
        
            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;
            
            // Parent Property
            if (_staff == null || !_staff.Equals(compareTo.Staff))
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
                if (_staff != null)
                    hash = hash * 23 + _staff.GetHashCode();
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
        /// The date that the staff member's new hire probationary period was completed.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="probationCompleteDate")][JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
        public DateTime? ProbationCompleteDate { get; set; }

        /// <summary>
        /// An indication as to whether the staff member is tenured.
        /// </summary>
        // NOT in a reference, NOT a lookup column 
        [DataMember(Name="tenured")]
        public bool? Tenured { get; set; }
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
            return Entities.Common.GrandBend.StaffExtensionMapper.SynchronizeTo(this, (Entities.Common.GrandBend.IStaffExtension)target);
        }

        void IMappable.Map(object target)
        {
            Entities.Common.GrandBend.StaffExtensionMapper.MapTo(this, (Entities.Common.GrandBend.IStaffExtension)target, null);
        }
        // -------------------------------------------------------------

        // =============================================================
        //                Synchronization Source Support
        // -------------------------------------------------------------
        bool Entities.Common.GrandBend.IStaffExtensionSynchronizationSourceSupport.IsProbationCompleteDateSupported  { get { return true; } set { } }
        bool Entities.Common.GrandBend.IStaffExtensionSynchronizationSourceSupport.IsTenuredSupported                { get { return true; } set { } }
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
    public class StaffExtensionPutPostRequestValidator : FluentValidation.AbstractValidator<StaffExtension>
    {
        protected override bool PreValidate(FluentValidation.ValidationContext<StaffExtension> context, FluentValidation.Results.ValidationResult result)
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

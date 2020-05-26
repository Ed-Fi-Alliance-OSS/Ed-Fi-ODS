using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using EdFi.Ods.Api;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Api.Extensibility;
using EdFi.Ods.Api.NHibernate;
using EdFi.Ods.Api.NHibernate.Architecture;
using EdFi.Ods.Api.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Entities.Common.GrandBend;
using EdFi.Ods.Entities.Common.Records.GrandBend;
using Newtonsoft.Json;

// Aggregate: Applicant

namespace EdFi.Ods.Entities.NHibernate.ApplicantAggregate.GrandBend
{
    /// <summary>
    /// Represents a read-only reference to the <see cref="Applicant"/> entity.
    /// </summary>
    public class ApplicantReferenceData : IHasPrimaryKeyValues
    {
        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        public virtual string ApplicantIdentifier { get; set; }
        public virtual int EducationOrganizationId { get; set; }
        // -------------------------------------------------------------

        /// <summary>
        /// The id of the referenced entity (used as the resource identifier in the API).
        /// </summary>
        public virtual Guid? Id { get; set; }

        /// <summary>
        /// Gets and sets the discriminator value which identifies the concrete sub-type of the referenced entity
        /// when that entity has been derived; otherwise <b>null</b>.
        /// </summary>
        public virtual string Discriminator { get; set; }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("ApplicantIdentifier", ApplicantIdentifier);
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);

            return keyValues;
        }

        #region Overrides for Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var compareTo = obj as IHasPrimaryKeyValues;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            var theseKeys = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();
            var thoseKeys = compareTo.GetPrimaryKeyValues();

            foreach (DictionaryEntry entry in theseKeys)
            {
                if (!entry.Value.Equals(thoseKeys[entry.Key]))
                    return false;
            }

            return true;
        }

        private const int HashMultiplier = 31; // or 33, 37, 39, 41

        public override int GetHashCode()
        {
            unchecked
            {
                var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

                if (keyValues.Count == 0)
                    return base.GetHashCode();

                int hashCode = this.GetType().GetHashCode();

                foreach (DictionaryEntry entry in keyValues)
                {
                    if (entry.Value == null)
                        continue;

                    hashCode = (hashCode*HashMultiplier) ^ entry.Value.GetHashCode();
                }

                return hashCode;
            }
        }
        #endregion
    }

// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the grandbend.Applicant table of the Applicant aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("grandbend")]
    [ExcludeFromCodeCoverage]
    public class Applicant : AggregateRootWithCompositeKey,
        Entities.Common.GrandBend.IApplicant, Entities.Common.Records.GrandBend.IApplicantRecord, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public Applicant()
        {
            ApplicantAddresses = new HashSet<ApplicantAddress>();
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, RequiredWithNonDefault, StringLength(32), NoDangerousText, NoWhitespace]
        public virtual string ApplicantIdentifier  { get; set; }
        [DomainSignature, RequiredWithNonDefault]
        public virtual int EducationOrganizationId  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------
        
        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [SqlServerDateTimeRange]
        public virtual DateTime? BirthDate 
        {
            get { return _birthDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _birthDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _birthDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _birthDate;
        
        public virtual int? CitizenshipStatusDescriptorId 
        {
            get
            {
                if (_citizenshipStatusDescriptorId == default(int?))
                    _citizenshipStatusDescriptorId = string.IsNullOrWhiteSpace(_citizenshipStatusDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("CitizenshipStatusDescriptor", _citizenshipStatusDescriptor);

                return _citizenshipStatusDescriptorId;
            } 
            set
            {
                _citizenshipStatusDescriptorId = value;
                _citizenshipStatusDescriptor = null;
            }
        }

        private int? _citizenshipStatusDescriptorId;
        private string _citizenshipStatusDescriptor;

        public virtual string CitizenshipStatusDescriptor
        {
            get
            {
                if (_citizenshipStatusDescriptor == null)
                    _citizenshipStatusDescriptor = _citizenshipStatusDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("CitizenshipStatusDescriptor", _citizenshipStatusDescriptorId.Value);
                    
                return _citizenshipStatusDescriptor;
            }
            set
            {
                _citizenshipStatusDescriptor = value;
                _citizenshipStatusDescriptorId = default(int?);
            }
        }
        [RequiredWithNonDefault, StringLength(75), NoDangerousText]
        public virtual string FirstName  { get; set; }
        [StringLength(10), NoDangerousText]
        public virtual string GenerationCodeSuffix  { get; set; }
        public virtual int? HighestCompletedLevelOfEducationDescriptorId 
        {
            get
            {
                if (_highestCompletedLevelOfEducationDescriptorId == default(int?))
                    _highestCompletedLevelOfEducationDescriptorId = string.IsNullOrWhiteSpace(_highestCompletedLevelOfEducationDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("LevelOfEducationDescriptor", _highestCompletedLevelOfEducationDescriptor);

                return _highestCompletedLevelOfEducationDescriptorId;
            } 
            set
            {
                _highestCompletedLevelOfEducationDescriptorId = value;
                _highestCompletedLevelOfEducationDescriptor = null;
            }
        }

        private int? _highestCompletedLevelOfEducationDescriptorId;
        private string _highestCompletedLevelOfEducationDescriptor;

        public virtual string HighestCompletedLevelOfEducationDescriptor
        {
            get
            {
                if (_highestCompletedLevelOfEducationDescriptor == null)
                    _highestCompletedLevelOfEducationDescriptor = _highestCompletedLevelOfEducationDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("LevelOfEducationDescriptor", _highestCompletedLevelOfEducationDescriptorId.Value);
                    
                return _highestCompletedLevelOfEducationDescriptor;
            }
            set
            {
                _highestCompletedLevelOfEducationDescriptor = value;
                _highestCompletedLevelOfEducationDescriptorId = default(int?);
            }
        }
        public virtual int? HighlyQualifiedAcademicSubjectDescriptorId 
        {
            get
            {
                if (_highlyQualifiedAcademicSubjectDescriptorId == default(int?))
                    _highlyQualifiedAcademicSubjectDescriptorId = string.IsNullOrWhiteSpace(_highlyQualifiedAcademicSubjectDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("AcademicSubjectDescriptor", _highlyQualifiedAcademicSubjectDescriptor);

                return _highlyQualifiedAcademicSubjectDescriptorId;
            } 
            set
            {
                _highlyQualifiedAcademicSubjectDescriptorId = value;
                _highlyQualifiedAcademicSubjectDescriptor = null;
            }
        }

        private int? _highlyQualifiedAcademicSubjectDescriptorId;
        private string _highlyQualifiedAcademicSubjectDescriptor;

        public virtual string HighlyQualifiedAcademicSubjectDescriptor
        {
            get
            {
                if (_highlyQualifiedAcademicSubjectDescriptor == null)
                    _highlyQualifiedAcademicSubjectDescriptor = _highlyQualifiedAcademicSubjectDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("AcademicSubjectDescriptor", _highlyQualifiedAcademicSubjectDescriptorId.Value);
                    
                return _highlyQualifiedAcademicSubjectDescriptor;
            }
            set
            {
                _highlyQualifiedAcademicSubjectDescriptor = value;
                _highlyQualifiedAcademicSubjectDescriptorId = default(int?);
            }
        }
        public virtual bool? HighlyQualifiedTeacher  { get; set; }
        public virtual bool? HispanicLatinoEthnicity  { get; set; }
        [RequiredWithNonDefault, StringLength(75), NoDangerousText]
        public virtual string LastSurname  { get; set; }
        [StringLength(60), NoDangerousText]
        public virtual string LoginId  { get; set; }
        [StringLength(75), NoDangerousText]
        public virtual string MaidenName  { get; set; }
        [StringLength(75), NoDangerousText]
        public virtual string MiddleName  { get; set; }
        [StringLength(30), NoDangerousText]
        public virtual string PersonalTitlePrefix  { get; set; }
        public virtual int? SexDescriptorId 
        {
            get
            {
                if (_sexDescriptorId == default(int?))
                    _sexDescriptorId = string.IsNullOrWhiteSpace(_sexDescriptor) ? default(int?) : DescriptorsCache.GetCache().GetId("SexDescriptor", _sexDescriptor);

                return _sexDescriptorId;
            } 
            set
            {
                _sexDescriptorId = value;
                _sexDescriptor = null;
            }
        }

        private int? _sexDescriptorId;
        private string _sexDescriptor;

        public virtual string SexDescriptor
        {
            get
            {
                if (_sexDescriptor == null)
                    _sexDescriptor = _sexDescriptorId == null ? null : DescriptorsCache.GetCache().GetValue("SexDescriptor", _sexDescriptorId.Value);
                    
                return _sexDescriptor;
            }
            set
            {
                _sexDescriptor = value;
                _sexDescriptorId = default(int?);
            }
        }
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal? YearsOfPriorProfessionalExperience  { get; set; }
        [Range(typeof(decimal), "-999.99", "999.99")]
        public virtual decimal? YearsOfPriorTeachingExperience  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        public virtual NHibernate.EducationOrganizationAggregate.EdFi.EducationOrganizationReferenceData EducationOrganizationReferenceData { get; set; }

        /// <summary>
        /// Read-only property that allows the EducationOrganization discriminator value to be mapped to the resource reference.
        /// </summary>
        string Entities.Common.GrandBend.IApplicant.EducationOrganizationDiscriminator
        {
            get { return EducationOrganizationReferenceData?.Discriminator; }
            set { }
        }

        /// <summary>
        /// Read-only property that allows the EducationOrganization resource identifier value to be mapped to the resource reference.
        /// </summary>
        Guid? Entities.Common.GrandBend.IApplicant.EducationOrganizationResourceId
        {
            get { return EducationOrganizationReferenceData?.Id; }
            set { }
        }

        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------

        private ICollection<Entities.NHibernate.ApplicantAggregate.GrandBend.ApplicantAddress> _applicantAddresses;
        private ICollection<Entities.Common.GrandBend.IApplicantAddress> _applicantAddressesCovariant;
        [ValidateEnumerable, NoDuplicateMembers]
        public virtual ICollection<Entities.NHibernate.ApplicantAggregate.GrandBend.ApplicantAddress> ApplicantAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // On-demand deserialization logic to attach reverse reference of children
                // due to ServiceStack's lack of [OnDeserialized] attribute support.
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _applicantAddresses)
                    if (item.Applicant == null)
                        item.Applicant = this;
                // -------------------------------------------------------------

                return _applicantAddresses;
            }
            set
            {
                _applicantAddresses = value;
                _applicantAddressesCovariant = new CovariantCollectionAdapter<Entities.Common.GrandBend.IApplicantAddress, Entities.NHibernate.ApplicantAggregate.GrandBend.ApplicantAddress>(value);
            }
        }

        // Covariant version, visible only on the interface
        ICollection<Entities.Common.GrandBend.IApplicantAddress> Entities.Common.GrandBend.IApplicant.ApplicantAddresses
        {
            get
            {
                // -------------------------------------------------------------
                // Back-reference is required by NHibernate for persistence.
                // -------------------------------------------------------------
                foreach (var item in _applicantAddresses)
                    if (item.Applicant == null)
                        item.Applicant = this;
                // -------------------------------------------------------------

                return _applicantAddressesCovariant;
            }
            set
            {
                ApplicantAddresses = new HashSet<Entities.NHibernate.ApplicantAggregate.GrandBend.ApplicantAddress>(value.Cast<Entities.NHibernate.ApplicantAggregate.GrandBend.ApplicantAddress>());
            }
        }

        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "CitizenshipStatusDescriptor", new LookupColumnDetails { PropertyName = "CitizenshipStatusDescriptorId", LookupTypeName = "CitizenshipStatusDescriptor"} },
                { "HighestCompletedLevelOfEducationDescriptor", new LookupColumnDetails { PropertyName = "HighestCompletedLevelOfEducationDescriptorId", LookupTypeName = "LevelOfEducationDescriptor"} },
                { "HighlyQualifiedAcademicSubjectDescriptor", new LookupColumnDetails { PropertyName = "HighlyQualifiedAcademicSubjectDescriptorId", LookupTypeName = "AcademicSubjectDescriptor"} },
                { "SexDescriptor", new LookupColumnDetails { PropertyName = "SexDescriptorId", LookupTypeName = "SexDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Initialize a new dictionary to hold the key values
            var keyValues = new OrderedDictionary();

            // Add current key values
            keyValues.Add("ApplicantIdentifier", ApplicantIdentifier);
            keyValues.Add("EducationOrganizationId", EducationOrganizationId);

            return keyValues;
        }

        #region Overrides for Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var compareTo = obj as IHasPrimaryKeyValues;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            var theseKeys = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();
            var thoseKeys = compareTo.GetPrimaryKeyValues();

            foreach (DictionaryEntry entry in theseKeys)
            {
                if (!entry.Value.Equals(thoseKeys[entry.Key]))
                    return false;
            }

            return true;
        }

        private const int HashMultiplier = 31; // or 33, 37, 39, 41

        public override int GetHashCode()
        {
            unchecked
            {
                var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

                if (keyValues.Count == 0)
                    return base.GetHashCode();

                int hashCode = this.GetType().GetHashCode();

                foreach (DictionaryEntry entry in keyValues)
                {
                    if (entry.Value == null)
                        continue;

                    hashCode = (hashCode*HashMultiplier) ^ entry.Value.GetHashCode();
                }

                return hashCode;
            }
        }
        #endregion

        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.GrandBend.IApplicant)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.GrandBend.IApplicant) target, null);
        }


        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isApplicantAddressesSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsApplicantAddressesSupported
        {
            get { return _isApplicantAddressesSupported; }
            set { _isApplicantAddressesSupported = value; }
        }

        private bool _isBirthDateSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsBirthDateSupported
        {
            get { return _isBirthDateSupported; }
            set { _isBirthDateSupported = value; }
        }

        private bool _isCitizenshipStatusDescriptorSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsCitizenshipStatusDescriptorSupported
        {
            get { return _isCitizenshipStatusDescriptorSupported; }
            set { _isCitizenshipStatusDescriptorSupported = value; }
        }

        private bool _isFirstNameSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsFirstNameSupported
        {
            get { return _isFirstNameSupported; }
            set { _isFirstNameSupported = value; }
        }

        private bool _isGenerationCodeSuffixSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsGenerationCodeSuffixSupported
        {
            get { return _isGenerationCodeSuffixSupported; }
            set { _isGenerationCodeSuffixSupported = value; }
        }

        private bool _isHighestCompletedLevelOfEducationDescriptorSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHighestCompletedLevelOfEducationDescriptorSupported
        {
            get { return _isHighestCompletedLevelOfEducationDescriptorSupported; }
            set { _isHighestCompletedLevelOfEducationDescriptorSupported = value; }
        }

        private bool _isHighlyQualifiedAcademicSubjectDescriptorSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHighlyQualifiedAcademicSubjectDescriptorSupported
        {
            get { return _isHighlyQualifiedAcademicSubjectDescriptorSupported; }
            set { _isHighlyQualifiedAcademicSubjectDescriptorSupported = value; }
        }

        private bool _isHighlyQualifiedTeacherSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHighlyQualifiedTeacherSupported
        {
            get { return _isHighlyQualifiedTeacherSupported; }
            set { _isHighlyQualifiedTeacherSupported = value; }
        }

        private bool _isHispanicLatinoEthnicitySupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsHispanicLatinoEthnicitySupported
        {
            get { return _isHispanicLatinoEthnicitySupported; }
            set { _isHispanicLatinoEthnicitySupported = value; }
        }

        private bool _isLastSurnameSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsLastSurnameSupported
        {
            get { return _isLastSurnameSupported; }
            set { _isLastSurnameSupported = value; }
        }

        private bool _isLoginIdSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsLoginIdSupported
        {
            get { return _isLoginIdSupported; }
            set { _isLoginIdSupported = value; }
        }

        private bool _isMaidenNameSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsMaidenNameSupported
        {
            get { return _isMaidenNameSupported; }
            set { _isMaidenNameSupported = value; }
        }

        private bool _isMiddleNameSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsMiddleNameSupported
        {
            get { return _isMiddleNameSupported; }
            set { _isMiddleNameSupported = value; }
        }

        private bool _isPersonalTitlePrefixSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsPersonalTitlePrefixSupported
        {
            get { return _isPersonalTitlePrefixSupported; }
            set { _isPersonalTitlePrefixSupported = value; }
        }

        private bool _isSexDescriptorSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsSexDescriptorSupported
        {
            get { return _isSexDescriptorSupported; }
            set { _isSexDescriptorSupported = value; }
        }

        private bool _isYearsOfPriorProfessionalExperienceSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsYearsOfPriorProfessionalExperienceSupported
        {
            get { return _isYearsOfPriorProfessionalExperienceSupported; }
            set { _isYearsOfPriorProfessionalExperienceSupported = value; }
        }

        private bool _isYearsOfPriorTeachingExperienceSupported = true;
        bool Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsYearsOfPriorTeachingExperienceSupported
        {
            get { return _isYearsOfPriorTeachingExperienceSupported; }
            set { _isYearsOfPriorTeachingExperienceSupported = value; }
        }

        private Func<Entities.Common.GrandBend.IApplicantAddress, bool> _isApplicantAddressIncluded;
        Func<Entities.Common.GrandBend.IApplicantAddress, bool> Entities.Common.GrandBend.IApplicantSynchronizationSourceSupport.IsApplicantAddressIncluded
        {
            get { return _isApplicantAddressIncluded; }
            set { _isApplicantAddressIncluded = value; }
        }

        // -----------------------------------------
    }
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the grandbend.ApplicantAddress table of the Applicant aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("grandbend")]
    [ExcludeFromCodeCoverage]
    public class ApplicantAddress : EntityWithCompositeKey, IChildEntity,
        Entities.Common.GrandBend.IApplicantAddress, Entities.Common.Records.GrandBend.IApplicantAddressRecord, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public ApplicantAddress()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual Applicant Applicant { get; set; }

        Entities.Common.GrandBend.IApplicant IApplicantAddress.Applicant
        {
            get { return Applicant; }
            set { Applicant = (Applicant) value; }
        }

        string Entities.Common.Records.GrandBend.IApplicantAddressRecord.ApplicantIdentifier
        {
            get { return ((Entities.Common.Records.GrandBend.IApplicantRecord) Applicant).ApplicantIdentifier; }
            set { ((Entities.Common.Records.GrandBend.IApplicantRecord) Applicant).ApplicantIdentifier = value; }
        }

        int Entities.Common.Records.GrandBend.IApplicantAddressRecord.EducationOrganizationId
        {
            get { return ((Entities.Common.Records.GrandBend.IApplicantRecord) Applicant).EducationOrganizationId; }
            set { ((Entities.Common.Records.GrandBend.IApplicantRecord) Applicant).EducationOrganizationId = value; }
        }

        [DomainSignature, RequiredWithNonDefault]
        public virtual int AddressTypeDescriptorId 
        {
            get
            {
                if (_addressTypeDescriptorId == default(int))
                    _addressTypeDescriptorId = DescriptorsCache.GetCache().GetId("AddressTypeDescriptor", _addressTypeDescriptor);

                return _addressTypeDescriptorId;
            } 
            set
            {
                _addressTypeDescriptorId = value;
                _addressTypeDescriptor = null;
            }
        }

        private int _addressTypeDescriptorId;
        private string _addressTypeDescriptor;

        public virtual string AddressTypeDescriptor
        {
            get
            {
                if (_addressTypeDescriptor == null)
                    _addressTypeDescriptor = DescriptorsCache.GetCache().GetValue("AddressTypeDescriptor", _addressTypeDescriptorId);
                    
                return _addressTypeDescriptor;
            }
            set
            {
                _addressTypeDescriptor = value;
                _addressTypeDescriptorId = default(int);
            }
        }
        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------
        
        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [StringLength(50), NoDangerousText]
        public virtual string ApartmentRoomSuiteNumber  { get; set; }
        [SqlServerDateTimeRange]
        public virtual DateTime? BeginDate 
        {
            get { return _beginDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _beginDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _beginDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _beginDate;
        
        [StringLength(20), NoDangerousText]
        public virtual string BuildingSiteNumber  { get; set; }
        [RequiredWithNonDefault, StringLength(30), NoDangerousText]
        public virtual string City  { get; set; }
        [StringLength(5), NoDangerousText]
        public virtual string CountyFIPSCode  { get; set; }
        [SqlServerDateTimeRange]
        public virtual DateTime? EndDate 
        {
            get { return _endDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _endDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _endDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _endDate;
        
        [StringLength(20), NoDangerousText]
        public virtual string Latitude  { get; set; }
        [StringLength(20), NoDangerousText]
        public virtual string Longitude  { get; set; }
        [StringLength(30), NoDangerousText]
        public virtual string NameOfCounty  { get; set; }
        [RequiredWithNonDefault, StringLength(17), NoDangerousText]
        public virtual string PostalCode  { get; set; }
        [RequiredWithNonDefault]
        public virtual int StateAbbreviationDescriptorId 
        {
            get
            {
                if (_stateAbbreviationDescriptorId == default(int))
                    _stateAbbreviationDescriptorId = DescriptorsCache.GetCache().GetId("StateAbbreviationDescriptor", _stateAbbreviationDescriptor);

                return _stateAbbreviationDescriptorId;
            } 
            set
            {
                _stateAbbreviationDescriptorId = value;
                _stateAbbreviationDescriptor = null;
            }
        }

        private int _stateAbbreviationDescriptorId;
        private string _stateAbbreviationDescriptor;

        public virtual string StateAbbreviationDescriptor
        {
            get
            {
                if (_stateAbbreviationDescriptor == null)
                    _stateAbbreviationDescriptor = DescriptorsCache.GetCache().GetValue("StateAbbreviationDescriptor", _stateAbbreviationDescriptorId);
                    
                return _stateAbbreviationDescriptor;
            }
            set
            {
                _stateAbbreviationDescriptor = value;
                _stateAbbreviationDescriptorId = default(int);
            }
        }
        [RequiredWithNonDefault, StringLength(150), NoDangerousText]
        public virtual string StreetNumberName  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "AddressTypeDescriptor", new LookupColumnDetails { PropertyName = "AddressTypeDescriptorId", LookupTypeName = "AddressTypeDescriptor"} },
                { "StateAbbreviationDescriptor", new LookupColumnDetails { PropertyName = "StateAbbreviationDescriptorId", LookupTypeName = "StateAbbreviationDescriptor"} },
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Applicant as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values
            keyValues.Add("AddressTypeDescriptorId", AddressTypeDescriptorId);

            return keyValues;
        }

        #region Overrides for Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var compareTo = obj as IHasPrimaryKeyValues;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            var theseKeys = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();
            var thoseKeys = compareTo.GetPrimaryKeyValues();

            foreach (DictionaryEntry entry in theseKeys)
            {
                if (!entry.Value.Equals(thoseKeys[entry.Key]))
                    return false;
            }

            return true;
        }

        private const int HashMultiplier = 31; // or 33, 37, 39, 41

        public override int GetHashCode()
        {
            unchecked
            {
                var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

                if (keyValues.Count == 0)
                    return base.GetHashCode();

                int hashCode = this.GetType().GetHashCode();

                foreach (DictionaryEntry entry in keyValues)
                {
                    if (entry.Value == null)
                        continue;

                    hashCode = (hashCode*HashMultiplier) ^ entry.Value.GetHashCode();
                }

                return hashCode;
            }
        }
        #endregion

        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.GrandBend.IApplicantAddress)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.GrandBend.IApplicantAddress) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Applicant = (Applicant) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isApartmentRoomSuiteNumberSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsApartmentRoomSuiteNumberSupported
        {
            get { return _isApartmentRoomSuiteNumberSupported; }
            set { _isApartmentRoomSuiteNumberSupported = value; }
        }

        private bool _isBeginDateSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsBeginDateSupported
        {
            get { return _isBeginDateSupported; }
            set { _isBeginDateSupported = value; }
        }

        private bool _isBuildingSiteNumberSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsBuildingSiteNumberSupported
        {
            get { return _isBuildingSiteNumberSupported; }
            set { _isBuildingSiteNumberSupported = value; }
        }

        private bool _isCitySupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsCitySupported
        {
            get { return _isCitySupported; }
            set { _isCitySupported = value; }
        }

        private bool _isCountyFIPSCodeSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsCountyFIPSCodeSupported
        {
            get { return _isCountyFIPSCodeSupported; }
            set { _isCountyFIPSCodeSupported = value; }
        }

        private bool _isEndDateSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsEndDateSupported
        {
            get { return _isEndDateSupported; }
            set { _isEndDateSupported = value; }
        }

        private bool _isLatitudeSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsLatitudeSupported
        {
            get { return _isLatitudeSupported; }
            set { _isLatitudeSupported = value; }
        }

        private bool _isLongitudeSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsLongitudeSupported
        {
            get { return _isLongitudeSupported; }
            set { _isLongitudeSupported = value; }
        }

        private bool _isNameOfCountySupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsNameOfCountySupported
        {
            get { return _isNameOfCountySupported; }
            set { _isNameOfCountySupported = value; }
        }

        private bool _isPostalCodeSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsPostalCodeSupported
        {
            get { return _isPostalCodeSupported; }
            set { _isPostalCodeSupported = value; }
        }

        private bool _isStateAbbreviationDescriptorSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsStateAbbreviationDescriptorSupported
        {
            get { return _isStateAbbreviationDescriptorSupported; }
            set { _isStateAbbreviationDescriptorSupported = value; }
        }

        private bool _isStreetNumberNameSupported = true;
        bool Entities.Common.GrandBend.IApplicantAddressSynchronizationSourceSupport.IsStreetNumberNameSupported
        {
            get { return _isStreetNumberNameSupported; }
            set { _isStreetNumberNameSupported = value; }
        }

        // -----------------------------------------
    }
}
// Aggregate: Staff

namespace EdFi.Ods.Entities.NHibernate.StaffAggregate.GrandBend
{
// disable warnings for inheritance from classes marked Obsolete within this generated code only
#pragma warning disable 612, 618

    /// <summary>
    /// A class which represents the grandbend.StaffExtension table of the Staff aggregate in the ODS database.
    /// </summary>
    [Serializable, Schema("grandbend")]
    [ExcludeFromCodeCoverage]
    public class StaffExtension : EntityWithCompositeKey, IChildEntity,
        Entities.Common.GrandBend.IStaffExtension, Entities.Common.Records.GrandBend.IStaffExtensionRecord, IHasPrimaryKeyValues, IHasLookupColumnPropertyMap, Entities.Common.GrandBend.IStaffExtensionSynchronizationSourceSupport
    {
        public virtual void SuspendReferenceAssignmentCheck() { }

        public StaffExtension()
        {
        }
// restore warnings for inheritance from classes marked Obsolete
#pragma warning restore 612, 618

        // =============================================================
        //                         Primary Key
        // -------------------------------------------------------------
        [DomainSignature, JsonIgnore, IgnoreDataMember]
        public virtual EdFi.Staff Staff { get; set; }

        Entities.Common.EdFi.IStaff IStaffExtension.Staff
        {
            get { return Staff; }
            set { Staff = (EdFi.Staff) value; }
        }

        int Entities.Common.Records.GrandBend.IStaffExtensionRecord.StaffUSI
        {
            get { return ((Entities.Common.Records.EdFi.IStaffRecord) Staff).StaffUSI; }
            set { ((Entities.Common.Records.EdFi.IStaffRecord) Staff).StaffUSI = value; }
        }

        // -------------------------------------------------------------

        // =============================================================
        //                      Inherited Properties
        // -------------------------------------------------------------
        // -------------------------------------------------------------
        
        // =============================================================
        //                          Properties
        // -------------------------------------------------------------
        [SqlServerDateTimeRange]
        public virtual DateTime? ProbationCompleteDate 
        {
            get { return _probationCompleteDate; }
            set 
            { 
                //This is only stored as a Date in the DB and NHibernate will retrieve it using the default (local) DateTime.Kind.  We must ensure it is set consistently for any equality/change evaluation.
                if(value == null)
                {
                    _probationCompleteDate = null;
                } else
                {
                    var given = (DateTime) value;
                    _probationCompleteDate = new DateTime(given.Year, given.Month, given.Day);
                }
            }
        }

        private DateTime? _probationCompleteDate;
        
        public virtual bool? Tenured  { get; set; }
        // -------------------------------------------------------------

        // =============================================================
        //                     One-to-one relationships
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                          Extensions
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // =============================================================
        //                     Reference Data
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        //=============================================================
        //                          Collections
        // -------------------------------------------------------------
        // -------------------------------------------------------------

        // Provide lookup property map
        private static readonly Dictionary<string, LookupColumnDetails> _idPropertyByLookupProperty = new Dictionary<string, LookupColumnDetails>(StringComparer.InvariantCultureIgnoreCase)
            {
            };

        Dictionary<string, LookupColumnDetails> IHasLookupColumnPropertyMap.IdPropertyByLookupProperty
        {
            get { return _idPropertyByLookupProperty; }
        }

        // Provide primary key information
        OrderedDictionary IHasPrimaryKeyValues.GetPrimaryKeyValues()
        {
            // Get parent key values
            var keyValues = (Staff as IHasPrimaryKeyValues).GetPrimaryKeyValues();

            // Add current key values

            return keyValues;
        }

        #region Overrides for Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var compareTo = obj as IHasPrimaryKeyValues;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            var theseKeys = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();
            var thoseKeys = compareTo.GetPrimaryKeyValues();

            foreach (DictionaryEntry entry in theseKeys)
            {
                if (!entry.Value.Equals(thoseKeys[entry.Key]))
                    return false;
            }

            return true;
        }

        private const int HashMultiplier = 31; // or 33, 37, 39, 41

        public override int GetHashCode()
        {
            unchecked
            {
                var keyValues = (this as IHasPrimaryKeyValues).GetPrimaryKeyValues();

                if (keyValues.Count == 0)
                    return base.GetHashCode();

                int hashCode = this.GetType().GetHashCode();

                foreach (DictionaryEntry entry in keyValues)
                {
                    if (entry.Value == null)
                        continue;

                    hashCode = (hashCode*HashMultiplier) ^ entry.Value.GetHashCode();
                }

                return hashCode;
            }
        }
        #endregion

        bool ISynchronizable.Synchronize(object target)
        {
            return this.SynchronizeTo((Entities.Common.GrandBend.IStaffExtension)target);
        }

        void IMappable.Map(object target)
        {
            this.MapTo((Entities.Common.GrandBend.IStaffExtension) target, null);
        }

        void IChildEntity.SetParent(object value)
        {
            Staff = (EdFi.Staff) value;
        }

        // =========================================
        //        Synchronization Support
        // -----------------------------------------

        private bool _isProbationCompleteDateSupported = true;
        bool Entities.Common.GrandBend.IStaffExtensionSynchronizationSourceSupport.IsProbationCompleteDateSupported
        {
            get { return _isProbationCompleteDateSupported; }
            set { _isProbationCompleteDateSupported = value; }
        }

        private bool _isTenuredSupported = true;
        bool Entities.Common.GrandBend.IStaffExtensionSynchronizationSourceSupport.IsTenuredSupported
        {
            get { return _isTenuredSupported; }
            set { _isTenuredSupported = value; }
        }

        // -----------------------------------------
    }
}


